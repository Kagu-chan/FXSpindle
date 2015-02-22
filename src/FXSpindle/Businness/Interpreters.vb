Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Module Interpreters

    Private _notAvailable As New InterpreterAvailableState With {.Available = False}

    Public Sub Load()
        Dim rubyInterpreter As New Interpreter With {
            .CheckAvailable = AddressOf RubyInterpreterAvailable,
            .Name = "RubyAV",
            .ViewName = "Ruby Basis-Interpreter",
            .InterpreterType = InterpreterType.Interpreter
        }
        AppState.App.I.AvailableInterpreters.Add("RubyAV", rubyInterpreter)

        Dim luaInterpreter As New Interpreter With {
            .CheckAvailable = AddressOf LuaInterpreterAvailable,
            .Name = "LuaAV",
            .ViewName = "Lua Basis-Interpreter",
            .InterpreterType = InterpreterType.Interpreter
        }
        AppState.App.I.AvailableInterpreters.Add("LuaAV", luaInterpreter)

        CheckDynamicInterpreters()
    End Sub

    Private Function RubyInterpreterAvailable() As InterpreterAvailableState
        Dim version = Console.RunNodeAndReturn("script/bin/ruby.exe", {"script/bin/version.rb"})

        If String.IsNullOrEmpty(version) Then Return _notAvailable
        Return New InterpreterAvailableState With {.Version = version, .Available = True}
    End Function

    Private Function LuaInterpreterAvailable() As InterpreterAvailableState
        Dim version = Console.RunNodeAndReturn("script/bin/luajit32.exe", {"script/bin/version.lua"})

        If String.IsNullOrEmpty(version) Then Return _notAvailable
        Return New InterpreterAvailableState With {.Version = version, .Available = True}
    End Function

    Private Sub CheckDynamicInterpreters()
        Dim interpretersFile As String = "script/bin/libraries/libs"

        Dim lines As IEnumerable(Of String) = IO.File.ReadLines(interpretersFile)
        For Each line As String In lines
            Dim partials() As String = line.Split("|"c)

            Dim viewName As String = partials(0)
            Dim version As String = partials(1)
            Dim type As InterpreterType = Nothing

            Select Case partials(2)
                Case "lua"
                    type = InterpreterType.Lua
                    Exit Select
                Case "ruby"
                    type = InterpreterType.Ruby
                    Exit Select
                Case Else
                    Continue For
            End Select

            Dim dir As String = partials(3)

            Dim interpreter As New Interpreter With {
                .CheckAvailable = Function() As InterpreterAvailableState
                                      If Not IO.Directory.Exists("script/bin/libraries/" & dir) Then Return _notAvailable
                                      Return New InterpreterAvailableState With {.Available = True, .Version = version}
                                  End Function,
                .Name = dir,
                .ViewName = viewName,
                .InterpreterType = type
            }
            AppState.App.I.AvailableInterpreters.Add(dir, interpreter)
        Next
    End Sub

End Module
