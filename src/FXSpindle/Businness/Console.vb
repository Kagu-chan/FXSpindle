Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Module Console

    Public Function RunNodeAndReturn(ByVal appPath As String, ByVal args() As String) As String
        Dim p As New Process

        With p
            .StartInfo.CreateNoWindow = True
            .StartInfo.UseShellExecute = False
            .StartInfo.RedirectStandardOutput = True
            .StartInfo.FileName = appPath
            .StartInfo.Arguments = """" & [String].Join(""" """, args) & """"
            AddHandler p.OutputDataReceived, AddressOf WriteProcessOutput

            p.Start()
            ' Asynchrones Lesen starten
            p.BeginOutputReadLine()
        End With
        Return ""
    End Function

    Private Sub WriteProcessOutput(ByVal sender As Object, ByVal e As DataReceivedEventArgs)
        If String.IsNullOrEmpty(e.Data) then Return
        MsgBox(e.Data)
    End Sub

End Module
