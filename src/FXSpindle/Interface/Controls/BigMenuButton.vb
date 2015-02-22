Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Public Class BigMenuButton

    Private _text As String

    Public Sub New(ByVal text As String)
        InitializeComponent()

        _text = text
    End Sub

End Class
