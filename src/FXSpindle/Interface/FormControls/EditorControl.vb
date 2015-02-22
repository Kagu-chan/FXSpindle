Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Public Class EditorControl

    Private _editor As Integer
    Private _names As String() = {"Ruby-Editor", "Lua-Editor"}

    Public Sub New()
        InitializeComponent()

        _editor = AppState.Remember.I.LastOpenEditor
        PEditor.Controls.AddRange({
            New RubyEditor With {.Dock = DockStyle.Fill, .Visible = CBool(IIf(_editor = 0, True, False))},
            New LuaEditor With {.Dock = DockStyle.Fill, .Visible = CBool(IIf(_editor = 1, True, False))}
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
        AppState.Remember.I.LastOpenEditor = _editor
    End Sub

    Private Sub BTRunLua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTRunLua.Click
        AppState.Editors.I.RaiseRunLua()
    End Sub

    Private Sub BTRunRuby_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTRunRuby.Click
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
