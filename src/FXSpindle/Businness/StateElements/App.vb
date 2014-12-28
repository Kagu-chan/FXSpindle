Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Namespace AppState

    Public Class App
        Private Shared _instance As App = Nothing

        Public Shared ReadOnly Property I As App
            Get
                If _instance Is Nothing Then
                    _instance = New App
                End If
                Return _instance
            End Get
        End Property

        Private Sub New()
            AddHandler _availableInterpreters.ContentModified,
            Sub()
                RaiseEvent AvailableInterpretersChanged(Me, EventArgs.Empty)
            End Sub
        End Sub

        Public Version As String = "0.3"

        Public Event AppTitleChanged As EventHandler
        Public Event AvailableInterpretersChanged As EventHandler
        Public Event OptionWindowRequireReload As EventHandler

        Private _appTitle As String = String.Empty
        Private _rawAppTitle As String = String.Empty
        Private _availableInterpreters As New ObservableDictionary(Of String, Interpreter)

        Public Property AppTitle As String
            Get
                Return _appTitle
            End Get
            Set(ByVal value As String)
                If value.Equals(_rawAppTitle) Then Return
                _appTitle = "FXSpindle - " + value
                _rawAppTitle = value

                RaiseEvent AppTitleChanged(Me, EventArgs.Empty)
            End Set
        End Property
        Public ReadOnly Property AvailableInterpreters As ObservableDictionary(Of String, Interpreter)
            Get
                Return _availableInterpreters
            End Get
        End Property

        Public Sub RaiseOptionWindowRequireReload()
            RaiseEvent OptionWindowRequireReload(Me, EventArgs.Empty)
        End Sub
        Public Sub RaiseAvailableInterpretersChanged()
            RaiseEvent AvailableInterpretersChanged(Me, EventArgs.Empty)
        End Sub
    End Class

End Namespace