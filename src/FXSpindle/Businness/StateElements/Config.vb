Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Namespace AppState

    Public Class Config
        Private Shared _instance As Config = Nothing

        Public Shared ReadOnly Property I As Config
            Get
                If _instance Is Nothing Then
                    _instance = New Config
                End If
                Return _instance
            End Get
        End Property

        Private Sub New()

        End Sub

        Public Event UseCreditsNameChanged As EventHandler
        Public Event CreditsNameChanged As EventHandler
        Public Event ShowLastEventsChanged As EventHandler
        Public Event ShowRessourceHandleChanged As EventHandler
        Public Event ShowEncodeStateChanged As EventHandler
        Public Event RubyExecutablePathChanged As EventHandler

        Private _useCreditsName As Boolean = False
        Private _creditsName As String = String.Empty
        Private _showLastEvents As Boolean = True
        Private _showRessourceHandler As Boolean = True
        Private _showEncodeState As Boolean = True
        Private _rubyExecutablePath As String = String.Empty

        Public Property UseCreditsName As Boolean
            Get
                Return _useCreditsName
            End Get
            Set(ByVal value As Boolean)
                If _useCreditsName = value Then Return
                _useCreditsName = value

                RaiseEvent UseCreditsNameChanged(Me, EventArgs.Empty)
            End Set
        End Property
        Public Property CreditsName As String
            Get
                Return _creditsName
            End Get
            Set(ByVal value As String)
                If _creditsName.Equals(value) Then Return
                _creditsName = value

                RaiseEvent CreditsNameChanged(Me, EventArgs.Empty)
            End Set
        End Property
        Public Property ShowLastEvents As Boolean
            Get
                Return _showLastEvents
            End Get
            Set(ByVal value As Boolean)
                If _showLastEvents = value Then Return
                _showLastEvents = value

                RaiseEvent ShowLastEventsChanged(Me, EventArgs.Empty)
            End Set
        End Property
        Public Property ShowRessourceHandle As Boolean
            Get
                Return _showRessourceHandler
            End Get
            Set(ByVal value As Boolean)
                If _showRessourceHandler = value Then Return
                _showRessourceHandler = value

                RaiseEvent ShowRessourceHandleChanged(Me, EventArgs.Empty)
            End Set
        End Property
        Public Property ShowEncodeState As Boolean
            Get
                Return _showEncodeState
            End Get
            Set(ByVal value As Boolean)
                If _showEncodeState = value Then Return
                _showEncodeState = value

                RaiseEvent ShowEncodeStateChanged(Me, EventArgs.Empty)
            End Set
        End Property
        Public Property RubyExecutablePath As String
            Get
                Return _rubyExecutablePath
            End Get
            Set(ByVal value As String)
                If _rubyExecutablePath.Equals(value) Then Return
                _rubyExecutablePath = value

                RaiseEvent RubyExecutablePathChanged(Me, EventArgs.Empty)
            End Set
        End Property

    End Class

End Namespace