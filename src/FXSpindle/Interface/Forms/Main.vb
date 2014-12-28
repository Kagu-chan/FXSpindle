Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Public Class Main

    Private _createdTabs As New List(Of String)
    Private _titles As New Dictionary(Of String, String)
    Private _lastTab As String = String.Empty

    Public Sub New()
        ' Designer instanciating
        InitializeComponent()

        ' Own instanciating
        AddHandlers()
        EnvironmentManager.CheckAndManifestEnvironment()
        If Not Configuring.ConfigValid Then
            Me.TCMain.SelectTab("TPOptions")
        End If
        If Configuring.ConfigExists Then
            Configuring.LoadConfig()
        End If

        With _titles
            .Add("TPHome", "Home")
            .Add("TPProjects", "Projekte")
            .Add("TPEditor", "Editor")
            .Add("TPOptions", "Optionen")
            .Add("TPVideoView", "Test")
        End With

        OnSelectedTabChanged(Nothing, EventArgs.Empty)
        Interpreters.Load()

        'Me.TCMain.SelectTab("TPEditor")
        'Dim ctrl As New EditorControl
        'TPEditor.Controls.Add(ctrl)
        '_createdTabs.Add("TPEditor")
    End Sub

    Private Sub AddHandlers()
        AddHandler Me.Load, AddressOf OnFormLoad
        AddHandler AppState.App.I.AppTitleChanged, AddressOf OnAppTitleChanged
        AddHandler AppState.Config.I.ShowLastEventsChanged, AddressOf OnShowLastEventsChanged
        AddHandler AppState.Config.I.ShowRessourceHandleChanged, AddressOf OnShowRessourceHandleChanged
        AddHandler AppState.Config.I.ShowEncodeStateChanged, AddressOf OnShowEncodeStateChanged
        AddHandler Me.TCMain.SelectedIndexChanged, AddressOf OnSelectedTabChanged
        AddHandler Me.TCMain.Selecting, AddressOf OnTabControlSelecting
    End Sub

    Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs)
        Me.PLastEvents.Controls.Add(New LastEvents)
        Me.PLastEvents.Visible = AppState.Config.I.ShowLastEvents

        Me.PRessources.Controls.Add(New ResourcesView)
        Me.PRessources.Visible = AppState.Config.I.ShowRessourceHandle

        Me.PEncodeView.Controls.Add(New EncodeViewer)
        Me.PEncodeView.Visible = AppState.Config.I.ShowEncodeState
    End Sub

    Private Sub OnAppTitleChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.Text = AppState.App.I.AppTitle
    End Sub

    Private Sub OnShowRessourceHandleChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.PRessources.Visible = AppState.Config.I.ShowRessourceHandle
        CheckAndFixWindowSize()
    End Sub

    Private Sub OnShowLastEventsChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.PLastEvents.Visible = AppState.Config.I.ShowLastEvents
        CheckAndFixWindowSize()
    End Sub

    Private Sub OnShowEncodeStateChanged(ByVal sender As Object, ByVal e As EventArgs)
        Me.PEncodeView.Visible = AppState.Config.I.ShowEncodeState
        CheckAndFixWindowSize()
    End Sub

    Private Sub OnSelectedTabChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim tabName As String = Me.TCMain.SelectedTab.Name
        AppState.App.I.AppTitle = _titles.Item(tabName)
        If Not _createdTabs.Contains(tabName) Then
            Select Case tabName
                Case "TPHome"
                    Dim ctrl As New TestControl
                    TPHome.Controls.Add(ctrl)
                    Exit Select
                Case "TPOptions"
                    Dim ctrl As New OptionsControl
                    TPOptions.Controls.Add(ctrl)
                    Exit Select
                Case "TPEditor"
                    Dim ctrl As New EditorControl
                    TPEditor.Controls.Add(ctrl)
                    Exit Select
                Case "TPVideoView"
                    Dim ctrl As New VideoPreviewControl
                    TPVideoView.Controls.Add(ctrl)
                    Exit Select
            End Select
            _createdTabs.Add(tabName)
        End If

        If _lastTab.Equals("TPVideoView") Then
            AppState.Video.I.RaiseStopPlayback()
        End If

        Select Case tabName
            Case "TPOptions"
                AppState.App.I.RaiseOptionWindowRequireReload()
                Exit Select
            Case "TPVideoView"
                AppState.Video.I.VideoToPlay = "Z:\KaraFX\Working\Rohi - Kakuzetsu = Tanatosu\rohi_kakuzetsu_tanatosu_logoencode.mkv"
                AppState.Video.I.RaiseStartPlayback()
                Exit Select
        End Select

        _lastTab = tabName
    End Sub

    Private Sub CheckAndFixWindowSize()
        Dim s As System.Drawing.Size = Me.Size
        With AppState.Config.I
            If Not .ShowEncodeState AndAlso
                Not .ShowLastEvents AndAlso
                Not .ShowRessourceHandle Then
                Me.PDelimeter.Visible = False
                s.Height = 720 - PDelimeter.Size.Height - PEncodeView.Size.Height
            Else
                Me.PDelimeter.Visible = True
                s.Height = 720
            End If
            Me.Size = s
        End With
    End Sub

    Private Sub OnTabControlSelecting(ByVal sender As Object, ByVal e As TabControlCancelEventArgs)
        If Not Me.TCMain.SelectedTab.Enabled OrElse
           (Not Configuring.ConfigValid AndAlso Not Me.TCMain.SelectedTab.Name.Equals("TPOptions")) Then
            e.Cancel = True
        End If
    End Sub

End Class
