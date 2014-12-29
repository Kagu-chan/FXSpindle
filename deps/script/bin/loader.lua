print("LuaJit " .. _VERSION)

if not arg[1] or not arg[2] or not arg[3] then
	error("Wrong usage! Usage is \n\tluajit loader.lua autoload_dir filename_base destination_file", 1)
end

command_line_args = {}

command_line_args.autoload = arg[1]
command_line_args.filebase = arg[2]
command_line_args.destfile = arg[3]

autoload_path = "autoload/lua"

func = require("fileutils_thin")

local autoload_files = func(autoload_path)
for i=1, autoload_files.n do
	local file = autoload_files[i]
	if file.type == "file" and file.name:find("%.lua$") then
		dofile(autoload_path .. "/" .. file.name)
	end
end