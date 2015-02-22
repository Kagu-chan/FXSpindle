Option Compare Binary
Option Strict On
Option Infer On
Option Explicit On

Namespace AppState

    Public Class Controls
        Private Shared _instance As Controls = Nothing

        Public Shared ReadOnly Property I As Controls
            Get
                If _instance Is Nothing Then
                    _instance = New Controls
                End If
                Return _instance
            End Get
        End Property

        Private _controls As Dictionary(Of String, Control)

        Private Sub New()
            _controls = New Dictionary(Of String, Control)
        End Sub

        Public Sub Add(ByVal key As String, ByVal ctrl As Control)
            key = key.ToLower
            If Not _controls.ContainsKey(key) Then
                _controls.Add(key, ctrl)
            End If
        End Sub

        Public Function [Get](ByVal key As String) As Control
            key = key.ToLower
            If Not _controls.ContainsKey(key) Then Return Nothing
            Return _controls(key)
        End Function

        Public Sub Update(ByVal key As String, ByVal ctrl As Control)
            key = key.ToLower
            If _controls.ContainsKey(key) Then
                _controls(key) = ctrl
            End If
        End Sub

    End Class

End Namespace