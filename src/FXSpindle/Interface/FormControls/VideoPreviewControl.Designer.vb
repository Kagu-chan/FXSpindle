﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VideoPreviewControl
    Inherits System.Windows.Forms.UserControl

    'UserControl überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.VPVLC = New Ruby_KaraInterpreter.VLCVideoPlayer()
        Me.SuspendLayout()
        '
        'VPVLC
        '
        Me.VPVLC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VPVLC.Location = New System.Drawing.Point(0, 0)
        Me.VPVLC.Name = "VPVLC"
        Me.VPVLC.Size = New System.Drawing.Size(1008, 540)
        Me.VPVLC.TabIndex = 0
        '
        'InterpreterTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.VPVLC)
        Me.Name = "InterpreterTest"
        Me.Size = New System.Drawing.Size(1008, 540)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VPVLC As Ruby_KaraInterpreter.VLCVideoPlayer

End Class
