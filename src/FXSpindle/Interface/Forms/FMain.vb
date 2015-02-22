Option Compare Binary
Option Strict On
Option Infer On
Option Explicit On

Public Class FMain

    Private _mainMenu As New Dictionary(Of String, Control)

    Public Sub New()
        InitializeComponent()

        AddHandlers()
    End Sub

    Private Sub AddHandlers()
        AddHandler Me.Load, AddressOf OnFormLoads

    End Sub

    Private Sub OnFormLoads(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub InitMainMenu()
        AddMenuButton("home", "Home", True)

    End Sub

    Private Sub AddMenuButton(ByVal key As String, ByVal text As String, ByVal enabled As Boolean)
        _mainMenu.Add(key, New BigMenuButton(text) With {.Enabled = enabled})
    End Sub

End Class