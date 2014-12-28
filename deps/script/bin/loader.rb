puts "Ruby Thin Core Version #{RUBY_VERSION}"

# Command line parameters
#	0: Users autoload directory
#	1: Filename base in %temp% (e.g. 201412241940 will load 201412241940.ASS and render with 201412241940.RB
#	2: Destination File Name
$command_line_args = {}
$command_line_args[:autoload] = ARGV[0]
$command_line_args[:filebase] = ARGV[1]
$command_line_args[:destfile] = ARGV[2]

# Check if the arguments are given. If not, cancel ERROR-CODE 3
#	This is NO check if they are valid!
$command_line_args.each_value { |item|
	if item.nil? then
		puts "Wrong usage! Usage is \n\tluajit interpreter.lua loader.rb autoload_dir filename_base destination_file"
		exit 3
	end
}

# Define, scan and require default autoload directory
#	Loads only autoload core, not users autoload - this will required later in other script
$autoload_path = "autoload/ruby"
$autoload_files = Dir.entries($autoload_path)

$autoload_files.each { |f| require("./#{$autoload_path}/#{f}") if f.end_with?('.rb') }