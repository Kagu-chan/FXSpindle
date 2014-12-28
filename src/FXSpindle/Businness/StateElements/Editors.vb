Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Namespace AppState

    Public Class Editors
        Private Shared _instance As Editors = Nothing

        Public Shared ReadOnly Property I As Editors
            Get
                If _instance Is Nothing Then
                    _instance = New Editors
                End If
                Return _instance
            End Get
        End Property

        Private Sub New()
        End Sub

        Public Event RunRuby As EventHandler
        Public Event RunLua As EventHandler
        Public Event TransportToLua As EventHandler(Of CodeTransportEventArgs)
        Public Event TransportToRuby As EventHandler(Of CodeTransportEventArgs)

        Public Sub RaiseRunRuby()
            RaiseEvent RunRuby(Me, EventArgs.Empty)
        End Sub

        Public Sub RaiseRunLua()
            RaiseEvent RunLua(Me, EventArgs.Empty)
        End Sub

        Public Sub RaiseTransportToRuby(ByVal lines As ScintillaNET.LineCollection, ByVal commentBegin As String, ByVal commentEnd As String)
            RaiseEvent TransportToRuby(Me, New CodeTransportEventArgs(lines, commentBegin, commentEnd))
        End Sub

        Public Sub RaiseTransportToLua(ByVal lines As ScintillaNET.LineCollection, ByVal commentBegin As String, ByVal commentEnd As String)
            RaiseEvent TransportToLua(Me, New CodeTransportEventArgs(lines, commentBegin, commentEnd))
        End Sub
    End Class

End Namespace