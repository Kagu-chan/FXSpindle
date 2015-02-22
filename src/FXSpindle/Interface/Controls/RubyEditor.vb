Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Imports System.Text.RegularExpressions

Public Class RubyEditor

    Private _tweaks As EditorTweaks

    Public Sub New()
        InitializeComponent()

        _tweaks = New EditorTweaks(Me.SEditor)
        _tweaks.AddHandlers()
        _tweaks.SetCommentCommands("#", "=begin", "=end")
        _tweaks.SetWords({
            "BEGIN class ensure nil self " + _
            "when END def false not " + _
            "super while alias defined? for " + _
            "or then yield and do nil?" + _
            "if redo true begin else " + _
            "in rescue undef break elsif " + _
            "module retry unless case end " + _
            "next return until __FILE__ __LINE__" + _
            "private public protected module_function " + _
            "STDERR include require include raise " + _
            "attr_accessor attr_reader attr_writer ARGV"
        })

        _tweaks.SetBold({"WORD", "CLASSNAME", "DEFNAME", "MODULE_NAME", "OPERATOR", "CHARACTER", "REGEX", "GLOBAL"})
        _tweaks.SetItalic({"COMMENTLINE", "POD", "REGEX"})

        _tweaks.SetForeColor("#0080C0", "CLASSNAME")
        _tweaks.SetForeColor("#8080FF", "DEFNAME")
        _tweaks.SetForeColor("#804000", "MODULE_NAME")
        _tweaks.SetForeColor("#0066ff", "INSTANCE_VAR")
        _tweaks.SetForeColor("000080", "OPERATOR")
        _tweaks.SetForeColor(Color.DarkOrange, "GLOBAL")
        _tweaks.SetForeColor(Color.DarkViolet, "REGEX")
        _tweaks.SetForeColor(Color.DarkViolet, "STRING")
        _tweaks.SetForeColor(Color.Red, "SYMBOL")
        _tweaks.SetForeColor(Color.Green, "POD")

        _tweaks.SetBackColor("#FFFFCC", "DEFNAME")
        _tweaks.SetBackColor("#FFFFCC", "REGEX")

        AddHandler AppState.Editors.I.RunRuby,
            Sub()

            End Sub

        AddHandler AppState.Editors.I.TransportToRuby, AddressOf _tweaks.ImportTransport
    End Sub

End Class
