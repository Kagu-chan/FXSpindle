Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Imports System.Environment
Imports System.IO

Namespace FXSpindle.Businness

    Public Class EnvironmentManager

        Public Shared ReadOnly Property AppPath As String
            Get
                Dim path As String = GetFolderPath(SpecialFolder.ApplicationData)
                Return IO.Path.Combine(path, "FXSpindle")
            End Get
        End Property

        Public Shared ReadOnly Property ProjectsPath As String
            Get
                Return Path.Combine(AppPath, "Projects")
            End Get
        End Property

        Public Shared ReadOnly Property SettingsPath As String
            Get
                Return Path.Combine(AppPath, "Config")
            End Get
        End Property

        Public Shared ReadOnly Property RendererXMLPath As String
            Get
                Return Path.Combine(AppPath, "Renderer.xml")
            End Get
        End Property

        Public Shared Sub CheckAndManifestEnvironment()
            If Not Directory.Exists(AppPath) Then Directory.CreateDirectory(AppPath)
            If Not Directory.Exists(ProjectsPath) Then Directory.CreateDirectory(ProjectsPath)
            If Not Directory.Exists(SettingsPath) Then Directory.CreateDirectory(SettingsPath)
        End Sub

    End Class

End Namespace