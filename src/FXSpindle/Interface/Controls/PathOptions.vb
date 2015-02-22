Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Public Class PathOptions

    Public Sub New()
        InitializeComponent()
        AddHandlers()
    End Sub

    Private Sub AddHandlers()
        AddHandler BTSearchRubyExecutable.Click,
            Sub()
                Dim ofd As New OpenFileDialog
                ofd.Filter = "Executables|*.exe"
                ofd.Title = "Select Ruby Executable"
                If ofd.ShowDialog() = DialogResult.OK Then
                    TBRubyExecutable.Text = ofd.FileName()
                End If
            End Sub
        AddHandler TBRubyExecutable.TextChanged,
            Sub()
                AppState.Config.I.RubyExecutablePath = TBRubyExecutable.Text
                Configuring.SaveConfig()
            End Sub
        AddHandler AppState.App.I.OptionWindowRequireReload,
            Sub()
                TBRubyExecutable.Text = AppState.Config.I.RubyExecutablePath
            End Sub
        AddHandler AppState.Config.I.RubyExecutablePathChanged,
            Sub()
                AppState.App.I.RaiseAvailableInterpretersChanged()
            End Sub
    End Sub

End Class
