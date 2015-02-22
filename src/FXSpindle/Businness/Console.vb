Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Module Console

    Public Function RunNodeAndReturn(ByVal appPath As String, ByVal args() As String) As String
        Dim p As New Process

        Try
            With p
                .StartInfo.CreateNoWindow = True
                .StartInfo.UseShellExecute = False
                .StartInfo.RedirectStandardOutput = True
                .StartInfo.FileName = appPath
                .StartInfo.Arguments = """" & [String].Join(""" """, args) & """"
                p.Start()
                Dim result As String = p.StandardOutput.ReadToEnd()

                p.WaitForExit()
                Return result
            End With
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

End Module
