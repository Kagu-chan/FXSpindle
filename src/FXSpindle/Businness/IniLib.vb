Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports System.Environment

Public Class IniLib

    Public Delegate Function CastToT(Of T)(ByVal input As String) As T
    Public Path As String

    Public Sub New(ByVal path As String)
        Me.Path = path
    End Sub

#Region "DLL Calls"

    Private Declare Unicode Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringW" (
        ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String,
        ByVal lpReturnedString As String, ByVal nSize As Integer, ByVal lpFileName As String) As Integer

    Private Declare Unicode Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringW" (
        ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String,
        ByVal lpFileName As String) As Integer

    Private Declare Unicode Function DeletePrivateProfileSection Lib "kernel32" Alias "WritePrivateProfileStringW" (
        ByVal section As String, ByVal noKey As Integer, ByVal noSetting As Integer,
        ByVal fileName As String) As Integer

#End Region

#Region "ReadValue"
    Public Function ReadValue(ByVal section As String, ByVal key As String, ByVal defaultValue As String) As String
        Return ReadValue(section, key, defaultValue, 1024)
    End Function

    Public Function ReadValue(ByVal section As String, ByVal key As String, ByVal defaultValue As String, ByVal bufferSize As Integer) As String
        Return ReadValue(Of String)(section, key, defaultValue, AddressOf DelegString, bufferSize)
    End Function

    Public Function ReadValue(ByVal section As String, ByVal key As String, ByVal defaultValue As Integer) As Integer
        Return ReadValue(section, key, defaultValue, 1024)
    End Function

    Public Function ReadValue(ByVal section As String, ByVal key As String, ByVal defaultValue As Integer, ByVal bufferSize As Integer) As Integer
        Return ReadValue(Of Integer)(section, key, defaultValue, AddressOf DelegInt, bufferSize)
    End Function

    Public Function ReadValue(ByVal section As String, ByVal key As String, ByVal defaultValue As Boolean) As Boolean
        Return ReadValue(section, key, defaultValue, 1024)
    End Function

    Public Function ReadValue(ByVal section As String, ByVal key As String, ByVal defaultValue As Boolean, ByVal bufferSize As Integer) As Boolean
        Return ReadValue(Of Boolean)(section, key, defaultValue, AddressOf DelegBool, bufferSize)
    End Function

    Public Function ReadValue(Of T)(ByVal section As String, ByVal key As String, ByVal defaultValue As T, ByVal deleg As CastToT(Of T)) As T
        Return ReadValue(Of T)(section, key, defaultValue, deleg, 1024)
    End Function

    Public Function ReadValue(Of T)(ByVal section As String, ByVal key As String, ByVal defaultValue As T, ByVal deleg As CastToT(Of T), ByVal bufferSize As Integer) As T
        If String.IsNullOrEmpty(section) OrElse String.IsNullOrEmpty(key) Then
            Throw New NullReferenceException
        End If
        CheckPath()

        Dim temp As String = Space(bufferSize)
        Dim value As Integer = GetPrivateProfileString(section, key, defaultValue.ToString, temp, bufferSize, Me.Path)

        Return deleg.Invoke(
            Left(
                temp,
                value
           )
        )
    End Function
#End Region

    Private Sub CheckPath()
        If Not IO.File.Exists(Me.Path) Then
            Throw New IO.FileNotFoundException
        End If
    End Sub

    Public Sub WriteValue(ByVal section As String, ByVal key As String, ByVal value As Object)
        If String.IsNullOrEmpty(section) OrElse String.IsNullOrEmpty(key) Then
            Throw New NullReferenceException
        End If

        WritePrivateProfileString(section, key, value.ToString, Me.Path)
    End Sub

    Public Sub DestroyKey(ByVal section As String, ByVal key As String)
        If String.IsNullOrEmpty(section) OrElse String.IsNullOrEmpty(key) Then
            Throw New NullReferenceException
        End If
        CheckPath()

        WritePrivateProfileString(section, key, Nothing, Me.Path)
    End Sub

    Public Sub DestroySection(ByVal section As String)
        If String.IsNullOrEmpty(section) Then
            Throw New NullReferenceException
        End If
        CheckPath()

        DeletePrivateProfileSection(section, 0, 0, Me.Path)
    End Sub

    Public Sub CreateBackup(ByVal destinationFileName As String)
        If String.IsNullOrEmpty(destinationFileName) Then
            Throw New NullReferenceException
        End If
        CheckPath()

        IO.File.Copy(Me.Path, destinationFileName)
    End Sub

    Public Sub DestroyIniFile()
        CheckPath()

        IO.File.Delete(Me.Path)
    End Sub

    Private Function DelegString(ByVal input As String) As String
        Return input
    End Function

    Private Function DelegInt(ByVal input As String) As Integer
        Return CInt(input)
    End Function

    Private Function DelegBool(ByVal input As String) As Boolean
        Return CBool(input)
    End Function

End Class