# FXSpindle
---
##Definition
**FXSpindle** is an application to create ASS (Advanced Substation Alpha) files with karaoke effects, preview and encode them and manage single projects for this.

##Project Paused!
Please refer to [AegiSpindle](https://github.com/Kagurame/AegiSpindle) for updates and new source!

###Environment
It supports scripting in Ruby or Lua, provides a seperate editor for each scripting language and includes the NyuFX library, the Yutils library and its own library for creating karaoke effects.
Each library has a port for both scripting engines.

Both environments are extended by many functions and variables to make FXSpindle easier to use and more powerful than simple text manipulation.
Pre-calculated values and graphic+media functions allow advanced effects without much effort.

It's recommend to learn ASS as well as Ruby or Lua before usage, but even without that it's possible to use it since both scripting languages and ASS are really easy to understand and learn.

###Management
FXSpindle provides its own project management. Here it is possible to decide between "Link-Mode" and "File-Mode". File-Mode will copy all data to a dedicated directory in users appdata. Link-Mode means that all files will be included as symlinks (Win 7 or higher) - The software access will be the same, but it will not require additional space to save videos or bigger ASS source files.

###Preview
FXSpindle provides a preview based on the last created ASS script and used video (If a video is given in project configuration)

###Encoding
When installed on your system, FXSpindle is able to open AviSynth directly to show your work in a more professional software.
Also its possible to directly encode your karaoke effect with a given video as "Hardsub" (depending on a given video, start- and end-times in frames)

##Releases
Currently there are no releases since it's a early development state.
The next days I'll share compiled binaries to showcase and test some features.

##Build
FXSpindle has a project file for Visual Studio 2010 (see ***src/FXSpindle.sln*** or ***src/FXSpindle/FXSpindle.vbproj***).

* Open the project file.
* Change '***AppState.Video.I.VideoToPlay***' in ***src/FXSpindle/Interface/Forms/Main.vb*** (Line 117) to an existing video file on your system.
* Build the project map.

##Installation
Currently there is no installer for this software.

##Requirements
See REQUIREMENTS file

##License
See LICENSE file

##Want to help?
If you find an issue in my code or want to share some useful additions for the libraries, please fork this project, commit your changes and send a pull request.
If it is doable and if it fits the library and coding style maybe it will get included.

##Help
Please post your issue if you need some help.

##See also
* Ruby: https://www.ruby-lang.org
* Lua: http://www.lua.org
* NyuFX: https://github.com/Youka/NyuFX
* Yutils: https://github.com/Youka/Yutils
* AviSynth: http://avisynth.nl