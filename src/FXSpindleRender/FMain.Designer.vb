<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMain
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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
        Me.GBGUI = New System.Windows.Forms.GroupBox()
        Me.GBOut = New System.Windows.Forms.GroupBox()
        Me.TBConsole = New System.Windows.Forms.TextBox()
        Me.GBOut.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBGUI
        '
        Me.GBGUI.Dock = System.Windows.Forms.DockStyle.Left
        Me.GBGUI.Location = New System.Drawing.Point(0, 0)
        Me.GBGUI.Name = "GBGUI"
        Me.GBGUI.Size = New System.Drawing.Size(315, 442)
        Me.GBGUI.TabIndex = 0
        Me.GBGUI.TabStop = False
        Me.GBGUI.Text = "Control"
        '
        'GBOut
        '
        Me.GBOut.Controls.Add(Me.TBConsole)
        Me.GBOut.Dock = System.Windows.Forms.DockStyle.Right
        Me.GBOut.Location = New System.Drawing.Point(312, 0)
        Me.GBOut.Name = "GBOut"
        Me.GBOut.Size = New System.Drawing.Size(312, 442)
        Me.GBOut.TabIndex = 1
        Me.GBOut.TabStop = False
        Me.GBOut.Text = "Console"
        '
        'TBConsole
        '
        Me.TBConsole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBConsole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TBConsole.Location = New System.Drawing.Point(3, 16)
        Me.TBConsole.Multiline = True
        Me.TBConsole.Name = "TBConsole"
        Me.TBConsole.ReadOnly = True
        Me.TBConsole.Size = New System.Drawing.Size(306, 423)
        Me.TBConsole.TabIndex = 0
        '
        'FMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 442)
        Me.Controls.Add(Me.GBOut)
        Me.Controls.Add(Me.GBGUI)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "FMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FXSpindle Renderer"
        Me.GBOut.ResumeLayout(False)
        Me.GBOut.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GBGUI As System.Windows.Forms.GroupBox
    Friend WithEvents GBOut As System.Windows.Forms.GroupBox
    Friend WithEvents TBConsole As System.Windows.Forms.TextBox

End Class
