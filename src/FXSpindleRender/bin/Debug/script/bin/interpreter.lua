-- Load foreign functions interface
local ffi = require("ffi")

-- Load Ruby library & define function headers
local ruby = ffi.load("msvcrt-ruby210")
ffi.cdef([[
void ruby_init(void);
int ruby_setup(void);
void* ruby_options(int, char**);
int ruby_run_node(void*);
]])

-- Argument data
local args = arg

print(ruby.ruby_init)
ruby.ruby_init()

--[[
-- Initialize Ruby
if ruby.ruby_setup() == 0 then
	-- Run Ruby with options
	local args_n = #args
	local options = ffi.new("char*[?]", 1 + args_n)
	options[0] = ffi.cast("char*", "ruby.exe")
	for i=1, args_n do
		options[i] = ffi.cast("char*", args[i])
	end
	local status = ruby.ruby_run_node(ruby.ruby_options(1 + args_n, options))
	if status ~= 0 then
		print("Ruby error code: " .. status)
	end
else
	print("Couldn't setup Ruby!")
end
]]