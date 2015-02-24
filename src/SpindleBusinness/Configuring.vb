Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Namespace FXSpindle.Businness

    Public Class Configuring

        Private Shared _iniLib As IniLib = New IniLib(IO.Path.Combine(EnvironmentManager.SettingsPath, "Config.ini"))

        Public Shared Function ConfigValid(ByVal v As String) As Boolean
            If Not ConfigExists() Then Return False
            Dim iniVersion = _iniLib.ReadValue("Settings", "Version", "0")
            If Not iniVersion.Equals(v) Then Return False
            Return True
        End Function

        Public Shared Function ConfigExists() As Boolean
            Return IO.File.Exists(IO.Path.Combine(EnvironmentManager.SettingsPath, "Config.ini"))
        End Function

        Public Shared Function RendererXMLExist() As Boolean
            Return IO.File.Exists(EnvironmentManager.RendererXMLPath)
        End Function

    End Class

End Namespace