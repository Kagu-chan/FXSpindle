local ffi = require("ffi")

ffi.cdef([[
static const int MAX_PATH = 260;
enum{FILE_ATTRIBUTE_DIRECTORY = 0x10};

typedef unsigned int UINT;
typedef int BOOL;
typedef int* LPBOOL;
typedef wchar_t WCHAR;
typedef unsigned long DWORD;
typedef char* LPSTR;
typedef const char* LPCSTR;
typedef wchar_t* LPWSTR;
typedef const wchar_t* LPCWSTR;
typedef void* HANDLE;

typedef struct{
	DWORD dwLowDateTime;
	DWORD dwHighDateTime;
}FILETIME;
typedef struct{
	DWORD dwFileAttributes;
	FILETIME ftCreationTime;
	FILETIME ftLastAccessTime;
	FILETIME ftLastWriteTime;
	DWORD nFileSizeHight;
	DWORD nFileSizeLow;
	DWORD dwReserved0;
	DWORD dwReserved1;
	WCHAR cFileName[MAX_PATH];
	WCHAR cAlternateFilename[14];
}WIN32_FIND_DATAW, *LPWIN32_FIND_DATAW;

int MultiByteToWideChar(UINT, DWORD, LPCSTR, int, LPWSTR, int);
int WideCharToMultiByte(UINT, DWORD, LPCWSTR, int, LPSTR, int, LPCSTR, LPBOOL);
HANDLE FindFirstFileW(LPCWSTR, LPWIN32_FIND_DATAW);
BOOL FindNextFileW(HANDLE, LPWIN32_FIND_DATAW);
BOOL FindClose(HANDLE);
]])

local CP_UTF8 = 65001
local function utf8_to_utf16(s)
	local wlen = ffi.C.MultiByteToWideChar(CP_UTF8, 0x0, s, -1, nil, 0)
	local ws = ffi.new("wchar_t[?]", wlen)
	ffi.C.MultiByteToWideChar(CP_UTF8, 0x0, s, -1, ws, wlen)
	return ws
end
local function utf16_to_utf8(ws)
	local slen = ffi.C.WideCharToMultiByte(CP_UTF8, 0x0, ws, -1, nil, 0, nil, nil)
	local s = ffi.new("char[?]", slen)
	ffi.C.WideCharToMultiByte(CP_UTF8, 0x0, ws, -1, s, slen, nil, nil)
	return ffi.string(s)
end
return function(dir_name)
	if ffi.os == "Windows" then
		local find_data = ffi.new("WIN32_FIND_DATAW[1]")
		local dir_handle = ffi.gc(ffi.C.FindFirstFileW(utf8_to_utf16(dir_name.."\\*"), find_data), ffi.C.FindClose)
		if not dir_handle then
			error("Couldn't find directory!", 2)
		end
		local files = {n = 0}
		repeat
			files.n = files.n + 1
			files[files.n] = {
				name = utf16_to_utf8(find_data[0].cFileName),
				type = find_data[0].dwFileAttributes == ffi.C.FILE_ATTRIBUTE_DIRECTORY and "directory" or "file"
			}
		until ffi.C.FindNextFileW(dir_handle, find_data) == 0
		return files
	else
		local result = { n=0 }
		local p = io.popen('find "'.. dir_name ..'" -type f')
		for file in p:lines() do
			local f = { name = file:gsub(dir_name .. "/", ""), type="file" }
			result.n = result.n + 1
			result[result.n] = f
		end
		
		return result
	end
end