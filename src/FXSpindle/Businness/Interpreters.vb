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

        'Dim luanyul As New Interpreter
        'With luanyul
        '    .CheckAvailable = AddressOf CheckLua_NyuLib
        '    .Name = "LUANYUL"
        '    .ViewName = "Youkas NyuFX"
        '    .InterpreterType = InterpreterType.Lua
        'End With
        'AppState.App.I.AvailableInterpreters.Add("LUANYUL", luanyul)
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
        Dim resultVersion = Console.RunNodeAndReturn("script/bin/ruby.exe", {"script/bin/version.rb"})

        Return _notAvailable

        ' Ruby currently not available since they are failures in msvcrt-ruby210 dll


        'Try
        '    Console.RunNodeAndReturn("script/bin/luajit32.exe", {"script/bin/interpreter.lua", "script/bin/version.rb"})
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Return _notAvailable
        'End Try
        'Return _notAvailable
    End Function

    Public Function LuaInterpreterAvailable() As InterpreterAvailableState
        Try
            Console.RunNodeAndReturn("script/bin/luajit32.exe", {"script/bin/version.lua"})
        Catch ex As Exception
            MsgBox(ex.Message)
            Return _notAvailable
        End Try

        Return _notAvailable

    End Function
End Module
