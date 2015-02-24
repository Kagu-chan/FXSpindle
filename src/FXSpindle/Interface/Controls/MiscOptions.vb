'Option Compare Binary
'Option Explicit On
'Option Infer On
'Option Strict On

'Public Class MiscOptions

'    Public Sub New()
'        InitializeComponent()
'        AddHandlers()
'    End Sub

'    Private Sub AddHandlers()
'        AddHandler CBWriteName.CheckedChanged,
'            Sub()
'                AppState.Config.I.UseCreditsName = CBWriteName.Checked
'                TBName.Enabled = CBWriteName.Checked
'                Configuring.SaveConfig()
'            End Sub
'        AddHandler CBShowLastEvents.CheckedChanged,
'            Sub()
'                AppState.Config.I.ShowLastEvents = CBShowLastEvents.Checked
'                Configuring.SaveConfig()
'            End Sub
'        AddHandler CBShowResourceUsage.CheckedChanged,
'            Sub()
'                AppState.Config.I.ShowRessourceHandle = CBShowResourceUsage.Checked
'                Configuring.SaveConfig()
'            End Sub
'        AddHandler CBShowEncodeState.CheckedChanged,
'            Sub()
'                AppState.Config.I.ShowEncodeState = CBShowEncodeState.Checked
'                Configuring.SaveConfig()
'            End Sub
'        AddHandler TBName.TextChanged,
'            Sub()
'                AppState.Config.I.CreditsName = TBName.Text
'                Configuring.SaveConfig()
'            End Sub
'        AddHandler AppState.App.I.OptionWindowRequireReload,
'            Sub()
'                With AppState.Config.I
'                    CBWriteName.Checked = .UseCreditsName
'                    CBShowLastEvents.Checked = .ShowLastEvents
'                    CBShowResourceUsage.Checked = .ShowRessourceHandle
'                    CBShowEncodeState.Checked = .ShowEncodeState

'                    TBName.Enabled = .UseCreditsName
'                    TBName.Text = .CreditsName
'                End With
'            End Sub
'    End Sub

'End Class
