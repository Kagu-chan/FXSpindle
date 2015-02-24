Option Compare Binary
Option Strict On
Option Infer On
Option Explicit On

Imports System.IO
Imports SpindleBusinness
Imports SpindleBusinness.FXSpindle.Businness

Public Class FMain

    Public Sub New()
        InitializeComponent()

        If Not Configuring.RendererXMLExist Then
            MsgBox("HELLO")
        End If
    End Sub

End Class