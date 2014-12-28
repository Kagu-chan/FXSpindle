Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Public Class EditorControl

    Private _editor As Integer = 0
    Private _names As String() = {"Ruby-Editor", "Lua-Editor"}

    Public Sub New()

        ' Dieser Aufruf ist für den Designer erforderlich.
        InitializeComponent()

        PEditor.Controls.AddRange({
            New RubyEditor With {.Dock = DockStyle.Fill, .Visible = True},
            New LuaEditor With {.Dock = DockStyle.Fill, .Visible = False}
        })

        PEditor.Controls(_editor).Focus()
        AppState.App.I.AppTitle = _names(_editor)
    End Sub

    Private Sub BTToggleEditor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTToggleEditor.Click
        PEditor.Controls(_editor).Visible = False
        _editor = CInt(IIf(_editor = 0, 1, 0))
        PEditor.Controls(_editor).Visible = True
        PEditor.Controls(_editor).Focus()
        AppState.App.I.AppTitle = _names(_editor)
    End Sub

    Private Sub BTRunLua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTRunLua.Click
        AppState.Editors.I.RaiseRunLua()
    End Sub

    Private Sub BTRunRuby_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTRunRuby.Click
        Dim path As String = IO.Path.Combine(AppState.Config.I.RubyExecutablePath)
        Dim out As String = String.Empty

        Dim rbFile As String = "rbr/rbrun.rb"

        If IO.File.Exists(rbFile) Then IO.File.Delete(rbFile)
        Dim objWriter As New IO.StreamWriter(rbFile)
        objWriter.Write(PEditor.Controls(0).Controls("SEditor").Text)
        objWriter.Close()
        
        Dim code As String = PEditor.Controls(0).Controls("SEditor").Text.Replace("""", "\""")

        Dim p As New Process

        With p
            .StartInfo.CreateNoWindow = True
            .StartInfo.UseShellExecute = False
            .StartInfo.RedirectStandardOutput = True
            .StartInfo.FileName = "rbr/rbr.exe"
            '.StartInfo.FileName = "luajit.exe"
            .StartInfo.Arguments = ""
            '.StartInfo.Arguments = "test.lua"
            .Start()
            out = .StandardOutput.ReadToEnd()
            'MsgBox(out)
        End With
        '# Ruby Core
        'module Kernel
        '	module_function

        '    # Overwrite function p
        '		# 	Should have same behavior as Kernel.puts
        '		def p(*args, &object)
        '			puts(*args,&block)
        '		end
        'end
        'puts "nana"
        AppState.Editors.I.RaiseRunRuby()
    End Sub

    Private Sub BTTransport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTTransport.Click
        Dim ctrl As ScintillaNET.Scintilla = _
            DirectCast(PEditor.Controls(_editor).Controls("SEditor"), ScintillaNET.Scintilla)

        If _editor = 0 Then
            AppState.Editors.I.RaiseTransportToLua(ctrl.Lines, "=begin", "=end")
        Else
            AppState.Editors.I.RaiseTransportToRuby(ctrl.Lines, "--[[", "]]")
        End If
    End Sub
End Class
