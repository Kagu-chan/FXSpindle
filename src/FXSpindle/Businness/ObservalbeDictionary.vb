Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Imports System.ComponentModel
Imports System.Collections.Specialized

Public Class ObservableDictionary(Of TKey, TValue)
    Implements IDictionary(Of TKey, TValue), INotifyPropertyChanged, INotifyCollectionChanged

#Region "Constructors"
    Public Sub New()
        _dictionary = New Dictionary(Of TKey, TValue)
    End Sub
    Public Sub New(ByVal dictionary As IDictionary(Of TKey, TValue))
        _dictionary = New Dictionary(Of TKey, TValue)(dictionary)
    End Sub
    Public Sub New(ByVal comparer As IEqualityComparer(Of TKey))
        _dictionary = New Dictionary(Of TKey, TValue)(comparer)
    End Sub
    Public Sub New(ByVal capacity As Integer)
        _dictionary = New Dictionary(Of TKey, TValue)(capacity)
    End Sub
    Public Sub New(ByVal dictionary As IDictionary(Of TKey, TValue), ByVal comparer As IEqualityComparer(Of TKey))
        _dictionary = New Dictionary(Of TKey, TValue)(dictionary, comparer)
    End Sub
    Public Sub New(ByVal capacity As Integer, ByVal comparer As IEqualityComparer(Of TKey))
        _dictionary = New Dictionary(Of TKey, TValue)(capacity, comparer)
    End Sub
#End Region 'Constructors

#Region "Fields"

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
    Public Event CollectionChanged(ByVal sender As Object, ByVal e As NotifyCollectionChangedEventArgs) Implements INotifyCollectionChanged.CollectionChanged
    Public Event ContentModified(ByVal sender As Object, ByVal e As EventArgs)

    Private Const CountString As String = "Count"
    Private Const IndexerName As String = "Item[]"
    Private Const KeysName As String = "Keys"
    Private Const ValuesName As String = "Values"
    Private _dictionary As IDictionary(Of TKey, TValue)

#End Region 'Fields

    Protected ReadOnly Property Dictionary As IDictionary(Of TKey, TValue)
        Get
            Return _dictionary
        End Get
    End Property

    Public Overloads Sub Clear() Implements ICollection(Of KeyValuePair(Of TKey, TValue)).Clear
        If Dictionary.Count > 0 Then
            Dictionary.Clear()
            OnCollectionChanged()
        End If
    End Sub

    Public Sub Add(ByVal item As KeyValuePair(Of TKey, TValue)) Implements ICollection(Of KeyValuePair(Of TKey, TValue)).Add
        Insert(item.Key, item.Value, True)
    End Sub
    Public Sub Add(ByVal key As TKey, ByVal value As TValue) Implements IDictionary(Of TKey, TValue).Add
        Insert(key, value, True)
    End Sub
    Public Sub AddRange(ByVal items As IDictionary(Of TKey, TValue))
        If items Is Nothing Then Throw New ArgumentNullException("items")
        If items.Count > 0 Then
            If Dictionary.Count > 0 Then
                If items.Keys.Any(Function(key) Dictionary.ContainsKey(key)) Then
                    Throw New ArgumentException("An item with the same key has already been added.")

                Else
                    For Each i In items
                        Dictionary.Add(i)
                    Next
                End If
            Else
                _dictionary = New Dictionary(Of TKey, TValue)(items)

            End If
            OnCollectionChanged(NotifyCollectionChangedAction.Add, items.ToArray)
        End If
    End Sub

    Private Function Remove(ByVal item As KeyValuePair(Of TKey, TValue)) As Boolean _
      Implements ICollection(Of KeyValuePair(Of TKey, TValue)).Remove
        Return Remove(item.Key)
    End Function
    Public Function Remove(ByVal key As TKey) As Boolean Implements IDictionary(Of TKey, TValue).Remove
        If key Is Nothing Then Throw New ArgumentNullException("key")

        Dim item As TValue
        Dictionary.TryGetValue(key, item)
        Dim removed = Dictionary.Remove(key)
        If removed Then OnCollectionChanged() 'FieldsNotifyCollectionChangedAction.Remove, New KeyValuePair(Of TKey, TValue)(key, item)
        Return removed
    End Function
    Default Public Property Item(ByVal key As TKey) As TValue Implements IDictionary(Of TKey, TValue).Item
        Get
            Return Dictionary(key)
        End Get
        Set(ByVal value As TValue)
            Insert(key, value, False)
        End Set
    End Property

    Private Sub Insert(ByVal key As TKey, ByVal value As TValue, ByVal add As Boolean)
        If key Is Nothing Then Throw New ArgumentNullException("key")

        Dim item As TValue
        If Dictionary.TryGetValue(key, item) Then
            If add Then Throw New ArgumentException("An item with the same key has already been added.")
            If Equals(item, value) Then Exit Sub
            Dictionary(key) = value
            OnCollectionChanged(NotifyCollectionChangedAction.Replace, New KeyValuePair(Of TKey, TValue)(key, value),
                                New KeyValuePair(Of TKey, TValue)(key, item))
        Else
            Dictionary(key) = value
            OnCollectionChanged(NotifyCollectionChangedAction.Add, New KeyValuePair(Of TKey, TValue)(key, value))
        End If
    End Sub

#Region "ReadOnly methods and properties"

    Public Overloads Sub CopyTo(ByVal array() As KeyValuePair(Of TKey, TValue), ByVal arrayIndex As Integer) _
      Implements ICollection(Of KeyValuePair(Of TKey, TValue)).CopyTo
        Dictionary.CopyTo(array, arrayIndex)
    End Sub

    Public Overloads ReadOnly Property Count As Integer Implements ICollection(Of KeyValuePair(Of TKey, TValue)).Count
        Get
            Return Dictionary.Count
        End Get
    End Property

    Public ReadOnly Property IsReadOnly As Boolean Implements ICollection(Of KeyValuePair(Of TKey, TValue)).IsReadOnly
        Get
            Return Dictionary.IsReadOnly
        End Get
    End Property

    Public ReadOnly Property Keys As ICollection(Of TKey) Implements IDictionary(Of TKey, TValue).Keys
        Get
            Return Dictionary.Keys
        End Get
    End Property
    Public ReadOnly Property Values As ICollection(Of TValue) Implements IDictionary(Of TKey, TValue).Values
        Get
            Return Dictionary.Values
        End Get
    End Property

    Public Function Contains(ByVal item As KeyValuePair(Of TKey, TValue)) As Boolean _
      Implements ICollection(Of KeyValuePair(Of TKey, TValue)).Contains
        Return Dictionary.Contains(item)
    End Function
    Public Function ContainsKey(ByVal key As TKey) As Boolean Implements IDictionary(Of TKey, TValue).ContainsKey
        Return Dictionary.ContainsKey(key)
    End Function
    Public Function ContainsValue(ByVal value As TValue) As Boolean
        Return Dictionary.Values.Contains(value)
    End Function

    Public Function TryGetValue(ByVal key As TKey, ByRef value As TValue) As Boolean _
      Implements IDictionary(Of TKey, TValue).TryGetValue
        Return Dictionary.TryGetValue(key, value)
    End Function

    Public Overloads Function GetEnumerator() As IEnumerator(Of KeyValuePair(Of TKey, TValue)) _
      Implements IEnumerable(Of KeyValuePair(Of TKey, TValue)).GetEnumerator
        Return Dictionary.GetEnumerator
    End Function
    Private Function GetIEnumerableEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return DirectCast(Dictionary, IEnumerable).GetEnumerator
    End Function

    Private Sub OnPropertyChanged()
        OnPropertyChanged(CountString)
        OnPropertyChanged(IndexerName)
        OnPropertyChanged(KeysName)
        OnPropertyChanged(ValuesName)
        RaiseEvent ContentModified(Me, EventArgs.Empty)
    End Sub

    Protected Overridable Sub OnPropertyChanged(ByVal propertyName As String)
        RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
    End Sub

    Private Sub OnCollectionChanged()
        OnPropertyChanged()
        RaiseEvent CollectionChanged(Me, New NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset))
    End Sub

    Private Sub OnCollectionChanged(ByVal action As NotifyCollectionChangedAction,
                                    ByVal changedItem As KeyValuePair(Of TKey, TValue))
        OnPropertyChanged()
        RaiseEvent CollectionChanged(Me, New NotifyCollectionChangedEventArgs(action, changedItem))
    End Sub

    Private Sub OnCollectionChanged(ByVal action As NotifyCollectionChangedAction, ByVal newItem As KeyValuePair(Of TKey, TValue),
                                    ByVal oldItem As KeyValuePair(Of TKey, TValue))
        OnPropertyChanged()
        RaiseEvent CollectionChanged(Me, New NotifyCollectionChangedEventArgs(action, newItem, oldItem))
    End Sub

    Private Sub OnCollectionChanged(ByVal action As NotifyCollectionChangedAction, ByVal newItems As IList)
        OnPropertyChanged()
        RaiseEvent CollectionChanged(Me, New NotifyCollectionChangedEventArgs(action, newItems))
    End Sub


#End Region 'ReadOnly methods and properties
End Class