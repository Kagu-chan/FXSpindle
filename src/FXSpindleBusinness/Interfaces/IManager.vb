Namespace Spindle.Businness

    Interface IManager

        Function Create(ByVal filePath As String) As Boolean
        Function Delete(ByVal filePath As String) As Boolean
        Function Copy(ByVal fromPath As String, ByVal toPath As String) As Boolean
        Function Move(ByVal fromPath As String, ByVal toPath As String) As Boolean
        Function Rename(ByVal fromPath As String, ByVal toPath As String) As Boolean

    End Interface

End Namespace