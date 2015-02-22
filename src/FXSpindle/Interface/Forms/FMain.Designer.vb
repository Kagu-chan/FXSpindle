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
        Me.PLeft = New System.Windows.Forms.Panel()
        Me.GBMainMenu = New System.Windows.Forms.GroupBox()
        Me.PLeft.SuspendLayout()
        Me.SuspendLayout()
        '
        'PLeft
        '
        Me.PLeft.Controls.Add(Me.GBMainMenu)
        Me.PLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.PLeft.Location = New System.Drawing.Point(0, 0)
        Me.PLeft.Name = "PLeft"
        Me.PLeft.Size = New System.Drawing.Size(200, 682)
        Me.PLeft.TabIndex = 0
        '
        'GBMainMenu
        '
        Me.GBMainMenu.Dock = System.Windows.Forms.DockStyle.Top
        Me.GBMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.GBMainMenu.Name = "GBMainMenu"
        Me.GBMainMenu.Size = New System.Drawing.Size(200, 100)
        Me.GBMainMenu.TabIndex = 0
        Me.GBMainMenu.TabStop = False
        '
        'FMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 682)
        Me.Controls.Add(Me.PLeft)
        Me.MinimumSize = New System.Drawing.Size(1024, 720)
        Me.Name = "FMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FMain"
        Me.PLeft.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PLeft As System.Windows.Forms.Panel
    Friend WithEvents GBMainMenu As System.Windows.Forms.GroupBox
End Class
