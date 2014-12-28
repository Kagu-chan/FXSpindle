Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Namespace AppState

    Public Class Video
        Private Shared _instance As Video = Nothing

        Public Shared ReadOnly Property I As Video
            Get
                If _instance Is Nothing Then
                    _instance = New Video
                End If
                Return _instance
            End Get
        End Property
        Private Sub New()

        End Sub

        Public Event VideoToPlayChanged As EventHandler
        Public Event StartPlayback As EventHandler
        Public Event StopPlayback As EventHandler

        Private _videoToPlay As String = String.Empty

        Public Property VideoToPlay As String
            Get
                Return _videoToPlay
            End Get
            Set(ByVal value As String)
                If _videoToPlay.Equals(value) Then Return
                _videoToPlay = value

                RaiseEvent VideoToPlayChanged(Me, EventArgs.Empty)
            End Set
        End Property

        Public Sub RaiseStopPlayback()
            RaiseEvent StopPlayback(Me, EventArgs.Empty)
        End Sub

        Public Sub RaiseStartPlayback()
            RaiseEvent StartPlayback(Me, EventArgs.Empty)
        End Sub
    End Class

End Namespace