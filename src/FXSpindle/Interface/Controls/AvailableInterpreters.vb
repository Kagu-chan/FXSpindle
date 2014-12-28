Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On



Public Class AvailableInterpreters

    Public Sub New()
        InitializeComponent()

        AddHandlers()
        AppState.App.I.RaiseAvailableInterpretersChanged()
    End Sub

    Private Sub AddHandlers()
        AddHandler AppState.App.I.AvailableInterpretersChanged,
            Sub()
                Me.LVInterpreters.Items.Clear()

                AddInterpretersToListView(Me.LVInterpreters, InterpreterType.Interpreter, "LVGBase")
                AddInterpretersToListView(Me.LVInterpreters, InterpreterType.Net, "LVGNet")
                AddInterpretersToListView(Me.LVInterpreters, InterpreterType.Ruby, "LVGRuby")
                AddInterpretersToListView(Me.LVInterpreters, InterpreterType.Lua, "LVGLua")
            End Sub
    End Sub

    Private Sub AddInterpretersToListView(ByRef listView As ListView, ByVal key As InterpreterType, ByVal groupName As String)
        Dim grp As ListViewGroup = (From group As ListViewGroup In listView.Groups.Cast(Of ListViewGroup)() Where group.Name = groupName Select group).FirstOrDefault
        For Each element As Interpreter In GetInterpreters(key)
            Dim newItem As New ListViewItem(element.ViewName, grp) With {.UseItemStyleForSubItems = False}

            Dim availableState As InterpreterAvailableState = element.CheckAvailable()
            Dim text As String = IIf(availableState.Available, "Version " & availableState.Version, "Nicht verfügbar").ToString
            Dim color As Color = DirectCast(IIf(availableState.Available, color.Green, color.Red), Color)
            Dim availableStateItem As New ListViewItem.ListViewSubItem() With {.Text = text, .ForeColor = color}

            newItem.SubItems.Add(availableStateItem)
            listView.Items.Add(newItem)
        Next
    End Sub

    Private Function GetInterpreters(ByVal key As InterpreterType) As IEnumerable(Of Interpreter)
        Return From item As KeyValuePair(Of String, Interpreter) In AppState.App.I.AvailableInterpreters Where item.Value.InterpreterType = key Select item.Value
    End Function

End Class
