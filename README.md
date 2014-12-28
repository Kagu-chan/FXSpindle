# FXSpindle
---
##Definition
**FXSpindle** is an application to create ASS (Advanced Substation Alpha) files with karaoke effects, preview and encode them and manage single projects for this.

###Environment

It supports scripting in Ruby or Lua, provides for booth a own editor and includes the NyuFX library, the Youka library and a own library for creating karaoke effects.
Each library has a port for booth scripting engines.

Booth environments are extended by many functions and variables to make FXSpindle easier to use and more than easy text manipulation.
Pre-calculated values and graphic+media functions allow advanced effects without much effort.

It's recommend to learn ASS plus Ruby or Lua before usage, but even without is's possible to use since booth scripting languages and ASS are really easy to understand and learn.

###Management
FXSpindle provides a own project management. Here its possible to decide between "Link-Mode" and "File-Mode".
File-Mode will copy all datas to a own directory in users appdata.
Link-Mode means that all files will be included as symlinks (Win 7 or higher) - The software access will be the same, but it will not require additional space to save videos or greater ASS source files.

###Preview
FXSpindle provides a preview based on the last created ASS script and used video (If a video in configuration given)

###Encoding
When installed on your system, FXSpindle is able to call AviSynth directly to show your work in a more professional software.
Also its possible directly to encode your karaoke effect with a given video as "Hardsub" (depending on a given video, start- and end-times in frames)

##Releases
Currently they're no releases since its a early development state.
The next days I'll share compiled binaries to show and test some single features.

##Build
FXSpindle has a project file for Visual Studio 2010 (see ***src/FXSpindle.sln*** or ***src/FXSpindle/FXSpindle.vbproj***).

* Open the project file.
* Change 'AppState.Video.I.VideoToPlay' in ***src/FXSpindle/Interface/Forms/Main.vb*** (Line 117) to a existing video file on your system
* Build the project map.

##Installation
Currently there is no installer for this software.

##Requirements
See REQUIREMENTS file

##License
See LICENSE file

##Want to help?
If you find an issue in my code or want to share some usefull additions for the libraries, please fork this project, commit your changes and swend a pull request.
If it possible and fits the library and coding style maybe it will get included.

##Help
Please post a issue if you need some help.

##See also
* Ruby: https://en.wikipedia.org/wiki/Ruby_(programming_language)
* Lua: https://en.wikipedia.org/wiki/Lua_(programming_language)
* NyuFX: https://github.com/Youka/NyuFX/
* Youtils: https://github.com/Youka/Yutils
* AviSynth: http://avisynth.nl/index.php/Main_Page