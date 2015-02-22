Option Compare Binary
Option Infer On
Option Explicit On
Option Strict On

Public Class FSplash

    Public Sub New()
        InitializeComponent()

        AddHandler Me.Shown,
            Sub()
                ' Load users configuration
                EnvironmentManager.CheckAndManifestEnvironment()

                ' Load interpreters
                Interpreters.Load()

                ' Initialize controls
                AppState.Controls.I.Add("_testControl", New TestControl)
                AppState.Controls.I.Add("_optionsControl", New OptionsControl)
                AppState.Controls.I.Add("_editorsControl", New EditorControl)
                AppState.Controls.I.Add("_videoPreviewControl", New VideoPreviewControl)

                FMain.Show()
                Me.Close()
            End Sub
    End Sub

End Class