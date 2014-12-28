Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Public Structure Interpreter
    Public Name As String
    Public ViewName As String
    Public InterpreterType As InterpreterType
    Public CheckAvailable As Func(Of InterpreterAvailableState)
End Structure

Public Structure InterpreterAvailableState
    Public Available As Boolean
    Public Version As String
End Structure