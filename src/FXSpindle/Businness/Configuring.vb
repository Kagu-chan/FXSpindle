Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Public Class Configuring

    Private Shared _iniLib As IniLib = New IniLib(IO.Path.Combine(EnvironmentManager.SettingsPath, "Config.ini"))

    Public Shared Function ConfigValid() As Boolean
        If Not ConfigExists() Then Return False
        Dim iniVersion = _iniLib.ReadValue("Settings", "Version", "0")
        If Not iniVersion.Equals(AppState.App.I.Version) Then Return False
        Return True
    End Function

    Public Shared Function ConfigExists() As Boolean
        Return IO.File.Exists(IO.Path.Combine(EnvironmentManager.SettingsPath, "Config.ini"))
    End Function

    Public Shared Sub SaveConfig()
        With AppState.Config.I
            _iniLib.WriteValue("Settings", "UseCreditsName", .UseCreditsName)
            _iniLib.WriteValue("Settings", "CreditsName", .CreditsName)
            _iniLib.WriteValue("Settings", "ShowLastEvents", .ShowLastEvents)
            _iniLib.WriteValue("Settings", "ShowRessourceHandle", .ShowRessourceHandle)
            _iniLib.WriteValue("Settings", "ShowEncodeState", .ShowEncodeState)
        End With
        _iniLib.WriteValue("Settings", "Version", AppState.App.I.Version)
    End Sub

    Public Shared Sub LoadConfig()
        With AppState.Config.I
            .UseCreditsName = _iniLib.ReadValue("Settings", "UseCreditsName", .UseCreditsName)
            .CreditsName = _iniLib.ReadValue("Settings", "CreditsName", .CreditsName)
            .ShowLastEvents = _iniLib.ReadValue("Settings", "ShowLastEvents", .ShowLastEvents)
            .ShowRessourceHandle = _iniLib.ReadValue("Settings", "ShowRessourceHandle", .ShowRessourceHandle)
            .ShowEncodeState = _iniLib.ReadValue("Settings", "ShowEncodeState", .ShowEncodeState)
        End With
        AppState.App.I.RaiseOptionWindowRequireReload()
    End Sub

End Class
