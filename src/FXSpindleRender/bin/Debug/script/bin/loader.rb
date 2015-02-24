puts "Ruby Thin Core Version #{RUBY_VERSION}"

# Command line parameters
#	0: Users autoload directory
#	1: Filename base in %temp% (e.g. 201412241940 will load 201412241940.ASS and render with 201412241940.RB
#	2: Destination File Name
$command_line_args = {}
$command_line_args[:autoload] 			 = ARGV[0]
$command_line_args[:user_autoload_dir_a] = ARGV[1]
$command_line_args[:user_autoload_dir_b] = ARGV[2]
$command_line_args[:working_dir] 		 = ARGV[3]
$command_line_args[:filebase] 			 = ARGV[4]

# Check if the arguments are given. If not, exit()
#	This is NO check if they are valid!
$command_line_args.each_value { |item|
	if item.nil? then
		puts "Wrong usage! Usage is \n\tluajit[32|64] interpreter.lua loader.rb autoload_dir user_autoload_dir_a user_autoload_dir_b working_dir filename_base"
		Kernel.exit()
	end
}

$autoload_files = []

def load_dir(dir)
	files = Dir.entries(dir)
	files.each { |f| 
		$autoload_files << f
		require("./#{dir}/#{f}") if f.end_with?('.rb')
	}
end

# Autoload the autoload directory content (*.lua)
load_dir("autoload/#{$command_line_args[:autoload]}")

# Autoload the users autoload directory and library-bounded autoload directory (*.lua)
load_dir($command_line_args[:user_autoload_dir_a])
load_dir($command_line_args[:user_autoload_dir_b])

# filebase
f_base = "#{$command_line_args[:working_dir]}/#{$command_line_args[:filebase]}"

# Load users file
userfile = require("#{f_base}.rb")

# Initialize Environment
_init("#{f_base}.ass", "#{f_base}_out.ass")

# Clock for process time
pTime = Time.now

# Run users skript
main()

# Exit application and write Output
_exit(pTime)