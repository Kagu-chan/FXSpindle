Option Compare Binary
Option Strict On
Option Explicit On
Option Infer On

Namespace AppState

    Public Class Remember
        Private Shared _instance As Remember = Nothing

        Public Shared ReadOnly Property I As Remember
            Get
                If _instance Is Nothing Then
                    _instance = New Remember
                End If
                Return _instance
            End Get
        End Property

        Private Sub New()
            'NOP
        End Sub

        'Private _iniLib As IniLib = New IniLib(IO.Path.Combine(EnvironmentManager.SettingsPath, "Config.ini"))
        Private _section As String = "RememberMe"

        Public Property LastOpenEditor As Integer
            Get
                'Return _iniLib.ReadValue(_section, "LastOpenEditor", 0)
            End Get
            Set(ByVal value As Integer)
                '_iniLib.WriteValue(_section, "LastOpenEditor", value)
            End Set
        End Property

    End Class

End Namespace