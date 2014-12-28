Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Imports System.Runtime.CompilerServices

Module Extensions

    <Extension()>
    Public Sub SetProgressBarWithoutAnimation(ByVal pBar As ProgressBar, ByVal value As Integer)
        If value = pBar.Maximum Then
            pBar.Value = value
            pBar.Value = value - 1
        Else
            pBar.Value = value + 1
        End If
        pBar.Value = value
    End Sub

End Module
