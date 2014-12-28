Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Imports System.Text.RegularExpressions

Public Class LuaEditor

    Private _tweaks As EditorTweaks

    Public Sub New()
        InitializeComponent()

        _tweaks = New EditorTweaks(Me.SEditor)
        _tweaks.AddHandlers()
        _tweaks.SetCommentCommands("--", "--[[", "]]")
        _tweaks.SetBaseSyntax("local function", "end")
        _tweaks.SetWords({
            "function for while repeat until if else elseif end break return in do then",
            "local",
            "and or not",
            "nil true false"
        })

        _tweaks.SetBold({"OPERATOR", "WORD"})
        _tweaks.SetItalic({"COMMENT", "COMMENTLINE", "COMMENTDOC"})

        _tweaks.SetForeColor(Color.White, {"BRACELIGHT", "BRACEBAD"})
        _tweaks.SetForeColor(Color.Black, {"DEFAULT", "IDENTIFIER"})
        _tweaks.SetForeColor(Color.Red, {"STRING", "STRINGEOL"})
        _tweaks.SetForeColor(Color.Blue, {"WORD", "WORD2"})
        _tweaks.SetForeColor(Color.Gray, {"COMMENT", "COMMENTLINE", "COMMENTDOC"})
        _tweaks.SetForeColor(0, 196, 0, "NUMBER")
        _tweaks.SetForeColor(0, 128, 255, "CHARACTER")
        _tweaks.SetForeColor(196, 0, 0, "LITERALSTRING")
        _tweaks.SetForeColor(64, 64, 64, "PREPROCESSOR")
        _tweaks.SetForeColor(128, 0, 196, "OPERATOR")
        _tweaks.SetForeColor(0, 128, 255, "WORD3")
        _tweaks.SetForeColor(196, 196, 0, "WORD4")

        _tweaks.SetBackColor(Color.Red, "BRACEBAD")
        _tweaks.SetBackColor(128, 0, 196, "BRACELIGHT")

        AddHandler AppState.Editors.I.RunLua,
            Sub()
                MsgBox(_tweaks.GetParseString())
                '_interpreter.DoString(code)
            End Sub

        AddHandler AppState.Editors.I.TransportToLua, AddressOf _tweaks.ImportTransport
    End Sub

End Class
