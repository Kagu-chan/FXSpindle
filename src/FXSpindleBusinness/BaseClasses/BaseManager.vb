Option Compare Binary
Option Infer On
Option Explicit On
Option Strict On

Imports System.IO

Namespace Spindle.Businness

    Public MustInherit Class BaseManager
        Implements IManager

        Public Function Copy(ByVal fromPath As String, ByVal toPath As String) As Boolean Implements IManager.Copy
            Throw New NotImplementedException
        End Function

        Public Function Create(ByVal filePath As String) As Boolean Implements IManager.Create
            Throw New NotImplementedException
        End Function

        Public Function Delete(ByVal filePath As String) As Boolean Implements IManager.Delete
            Throw New NotImplementedException
        End Function

        Public Overridable Function Move(ByVal fromPath As String, ByVal toPath As String) As Boolean Implements IManager.Move
            If IO.Path.GetDirectoryName(fromPath) = IO.Path.GetDirectoryName(toPath) Then Return False

            Return InternalMove(fromPath, toPath)
        End Function

        Public Overridable Function Rename(ByVal fromPath As String, ByVal toPath As String) As Boolean Implements IManager.Rename
            If IO.Path.GetDirectoryName(fromPath) <> IO.Path.GetDirectoryName(toPath) Then Return False
            If IO.Path.GetFileName(fromPath) = IO.Path.GetFileName(toPath) Then Return False

            Return InternalMove(fromPath, toPath)
        End Function

        Protected Function InternalMove(ByVal fromPath As String, ByVal toPath As String) As Boolean
            If Copy(fromPath, toPath) Then
                Return Delete(fromPath)
            End If
            Return False
        End Function
    End Class

End Namespace