print("LuaJit " .. _VERSION)

-- Read command line arguments
if not arg[1] or not arg[2] or not arg[3] then
	error("Wrong usage! Usage is \n\tluajit loader.lua autoload_dir working_dir filename_base", 1)
end

command_line_args = {}

command_line_args.autoload = 	arg[1]
command_line_args.working_dir = arg[2]
command_line_args.filebase = 	arg[3]

-- Define autoload directory
autoload_path = "autoload/lua"

-- Define read_dir
read_dir = require("fileutils_thin")

-- Autoload the autoload directory content (*.lua)
local autoload_files = read_dir(autoload_path)
for i=1, autoload_files.n do
	local file = autoload_files[i]
	if file.type == "file" and file.name:find("%.lua$") then
		dofile(autoload_path .. "/" .. file.name)
	end
end

-- Autoload the users autoload directory (*.lua)
local user_files = read_dir(command_line_args.autoload)
for i=1, user_files.n do
	local file = user_files[i]
	if file.type == "file" and file.name:find("%.lua$") then
		dofile(command_line_args.autoload .. "/" .. file.name)
	end
end

-- filebase
local f_base = command_line_args.working_dir .. "/" .. command_line_args.filebase

-- Load users file
local userfile = dofile(f_base .. ".lua")

-- Initialize Environment
_init(f_base .. ".ass", f_base .. "_out.ass")

-- Clock for process time
local pTime = os.clock()

-- Run users skript
main()

-- Exit application and write Output
_exit(pTime)