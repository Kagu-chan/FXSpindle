Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Public Class CodeTransportEventArgs
    Inherits EventArgs

    Public ReadOnly Lines As ScintillaNET.LineCollection
    Public ReadOnly CommentBegin As String
    Public ReadOnly CommentEnd As String

    Public Sub New(ByVal lines As ScintillaNET.LineCollection, ByVal commentBegin As String, ByVal commentEnd As String)
        Me.Lines = lines
        Me.CommentBegin = commentBegin
        Me.CommentEnd = commentEnd
    End Sub

End Class