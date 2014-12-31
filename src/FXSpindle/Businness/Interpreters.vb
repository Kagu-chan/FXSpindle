Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Module Interpreters

    Private _notAvailable As New InterpreterAvailableState With {.Available = False}

    Public Sub Load()
        Dim rubyInterpreter As New Interpreter
        With rubyInterpreter
            .CheckAvailable = AddressOf RubyInterpreterAvailable
            .Name = "RubyAV"
            .ViewName = "Ruby Basis-Interpreter"
            .InterpreterType = InterpreterType.Interpreter
        End With
        AppState.App.I.AvailableInterpreters.Add("RubyAV", rubyInterpreter)

        Dim luaInterpreter As New Interpreter
        With luaInterpreter
            .CheckAvailable = AddressOf LuaInterpreterAvailable
            .Name = "LuaAV"
            .ViewName = "Lua Basis-Interpreter"
            .InterpreterType = InterpreterType.Interpreter
        End With
        AppState.App.I.AvailableInterpreters.Add("LuaAV", luaInterpreter)

        Dim rbkl As New Interpreter
        With rbkl
            .CheckAvailable = AddressOf CheckRuby_KaguLib
            .Name = "RBKL"
            .ViewName = "Ruby KaraLib"
            .InterpreterType = InterpreterType.Ruby
        End With
        AppState.App.I.AvailableInterpreters.Add("RBKL", rbkl)

        Dim luakl As New Interpreter
        With luakl
            .CheckAvailable = AddressOf CheckLua_KaguLib
            .Name = "LUAKL"
            .ViewName = "Lua KaraLib"
            .InterpreterType = InterpreterType.Lua
        End With
        AppState.App.I.AvailableInterpreters.Add("LUAKL", luakl)

        Dim luanyul As New Interpreter
        With luanyul
            .CheckAvailable = AddressOf CheckLua_NyuLib
            .Name = "LUANYUL"
            .ViewName = "Youkas NyuFX"
            .InterpreterType = InterpreterType.Lua
        End With
        AppState.App.I.AvailableInterpreters.Add("LUANYUL", luanyul)
    End Sub

    Public Function CheckRuby_KaguLib() As InterpreterAvailableState
        Return _notAvailable
    End Function

    Public Function CheckLua_KaguLib() As InterpreterAvailableState
        Return _notAvailable
    End Function

    Public Function CheckLua_NyuLib() As InterpreterAvailableState
        Return _notAvailable
    End Function

    Public Function RubyInterpreterAvailable() As InterpreterAvailableState
        'Dim path As String = IO.Path.Combine(AppState.Config.I.RubyExecutablePath)
        'Dim out As String = String.Empty

        'If String.IsNullOrEmpty(path) Then Return _notAvailable
        'Try
        '    Dim p As New Process

        '    With p
        '        .StartInfo.CreateNoWindow = True
        '        .StartInfo.UseShellExecute = False
        '        .StartInfo.RedirectStandardOutput = True
        '        .StartInfo.FileName = path
        '        .StartInfo.Arguments = "-e ""puts RUBY_VERSION"""
        '        .Start()
        '        out = .StandardOutput.ReadToEnd()
        '        MsgBox(out)
        '    End With
        'Catch ex As Exception

        'End Try
        'Return New InterpreterAvailableState With {.Version = out, .Available = True}

        Return _notAvailable
    End Function

    Public Function LuaInterpreterAvailable() As InterpreterAvailableState
        Return _notAvailable

        'Dim state As New InterpreterAvailableState
        'Try
        '    Dim [lib] As New lua51
        '    Dim version As String = [lib].GetGlobal("_VERSION").ToString
        '    state.Version = version.Substring(4)
        '    state.Available = True
        'Catch ex As Exception
        '    state.Available = False
        'End Try
        'Return state
    End Function
End Module
