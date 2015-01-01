print("LuaJit Version" .. _VERSION)

-- Read command line arguments
if not arg[1] or not arg[2] or not arg[3] or not arg[4] or not arg[5] then
	error("Wrong usage! Usage is \n\tluajit[32|64] loader.lua autoload_dir global_user_autoload library_user_autoload working_dir filename_base", 1)
end

-- Define global list of loaded files
_G.autoload_files = {}
local fi = 1

-- Define read_dir and load_dir
local read_dir = require("fileutils_thin")
local function load_dir(files)
	local ffiles = read_dir(files)
	for i=1, ffiles.n do
		local file = ffiles[i]
		if file.type == "file" and file.name:find("%.lua$") then
			local lFile = files .. "/" .. file.name
			autoload_files[fi] = lFile
			dofile(lFile)
			fi = fi + 1
		end
	end
end

_G.command_line_args = {}

command_line_args.autoload_dir = 		  arg[1]
command_line_args.global_user_autoload =  arg[2]
command_line_args.library_user_autoload = arg[3]
command_line_args.working_dir = 		  arg[4]
command_line_args.filebase = 			  arg[5]

-- Autoload the autoload directory content (*.lua)
load_dir("libraries/" .. command_line_args.autoload_dir)

-- Autoload the users autoload directory and library-bounded autoload directory (*.lua)
load_dir(command_line_args.global_user_autoload)
load_dir(command_line_args.library_user_autoload)

-- filebase
local f_base = command_line_args.working_dir .. "/" .. command_line_args.filebase

-- Initialize Environment
_init(f_base .. ".ass", f_base .. "_out.ass")

-- Run users skript
dofile(f_base .. ".lua")

-- Exit application and write Output
_exit()