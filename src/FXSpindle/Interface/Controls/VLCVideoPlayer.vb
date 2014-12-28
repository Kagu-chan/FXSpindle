Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Public Class VLCVideoPlayer

    Public Sub New()
        InitializeComponent()
        AddHandlers()
    End Sub

    Public Sub AddHandlers()
        AddHandler AppState.Video.I.VideoToPlayChanged, AddressOf OnVideoChanged
        AddHandler AppState.Video.I.StopPlayback, Sub()
                                                      Me.Player.playlist.stop()
                                                  End Sub
        AddHandler AppState.Video.I.StartPlayback, Sub()
                                                       Me.Player.playlist.playItem(0)
                                                   End Sub
    End Sub

    Private Sub OnVideoChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If Me.Player.playlist.isPlaying Then AppState.Video.I.RaiseStopPlayback()
        Catch ex As Exception
        End Try

        Dim uri As New Uri(AppState.Video.I.VideoToPlay)
        Me.Player.playlist.items.clear()
        Me.Player.playlist.add(uri.AbsoluteUri)
    End Sub

End Class
