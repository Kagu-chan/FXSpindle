Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Imports System.ComponentModel

Public Class ResourcesView

    Private Delegate Sub SetDeleg(ByVal ram As Integer, ByVal proc As Integer)
    Private _bgThread As Threading.Thread
    Private _perfCounter As System.Diagnostics.PerformanceCounter
    Private _fullRam As ULong

    Public Sub New()
        ' Designer instanciating
        InitializeComponent()

        ' Own instanciating
        AddHandlers()
        _fullRam = My.Computer.Info.TotalPhysicalMemory
        _perfCounter = New System.Diagnostics.PerformanceCounter
        _perfCounter.CategoryName = "Processor"
        _perfCounter.CounterName = "% Processor Time"
        _perfCounter.InstanceName = "_Total"
    End Sub

    Private Sub AddHandlers()
        AddHandler Me.Load, AddressOf OnFormLoad
    End Sub

    Private Sub OnFormLoad(ByVal sender As Object, ByVal e As EventArgs)
        _bgThread = New Threading.Thread(New Threading.ThreadStart(
                                             Sub()
                                                 Dim counter As Integer = 10
                                                 Dim proc As Integer = 0
                                                 While Me.Created
                                                     If counter Mod 10 = 0 Then
                                                         proc = CalculateAvailableCPU()
                                                         counter = 0
                                                     End If
                                                     counter += 1
                                                     Threading.Thread.Sleep(100)
                                                     Dim ram As Integer = CalculateAvailabeRam()
                                                     SetSub(ram, proc)
                                                 End While
                                             End Sub))
        _bgThread.Start()
    End Sub

    Private Sub SetSub(ByVal ram As Integer, ByVal proc As Integer)
        If Me.PRam.InvokeRequired Then
            Dim deleg As New SetDeleg(AddressOf SetSub)
            Me.Invoke(deleg, New Object() {ram, proc})
        Else
            Me.PRam.SetProgressBarWithoutAnimation(ram)
            Me.PProc.SetProgressBarWithoutAnimation(proc)
        End If
    End Sub

    Private Function CalculateAvailabeRam() As Integer
        Dim usRam As ULong = My.Computer.Info.AvailablePhysicalMemory
        Dim avRam As ULong = _fullRam - usRam
        Dim ramP As Integer = CInt(Math.Round(avRam * 100 / _fullRam, 0))

        Return ramP
    End Function

    Private Function CalculateAvailableCPU() As Integer
        Return CInt(_perfCounter.NextValue())
    End Function

    Protected Overrides Sub OnHandleDestroyed(ByVal e As System.EventArgs)
        _bgThread.Abort()
        MyBase.OnHandleDestroyed(e)
    End Sub
End Class
