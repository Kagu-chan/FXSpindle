Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Imports System.Environment

Public Class EnvironmentManager

    Public Shared ReadOnly Property AppPath As String
        Get
            Dim path As String = GetFolderPath(SpecialFolder.ApplicationData)
            Return IO.Path.Combine(path, "FXSpindle")
        End Get
    End Property

    Public Shared ReadOnly Property ProjectsPath As String
        Get
            Return IO.Path.Combine(AppPath, "Projects")
        End Get
    End Property

    Public Shared ReadOnly Property SettingsPath As String
        Get
            Return IO.Path.Combine(AppPath, "Config")
        End Get
    End Property

    Public Shared Sub CheckAndManifestEnvironment()
        If Not IO.Directory.Exists(AppPath) Then IO.Directory.CreateDirectory(AppPath)
        If Not IO.Directory.Exists(ProjectsPath) Then IO.Directory.CreateDirectory(ProjectsPath)
        If Not IO.Directory.Exists(SettingsPath) Then IO.Directory.CreateDirectory(SettingsPath)
    End Sub

End Class
