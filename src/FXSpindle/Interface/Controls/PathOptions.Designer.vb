<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PathOptions
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
        Me.GBPaths = New System.Windows.Forms.GroupBox()
        Me.BTSearchRubyExecutable = New System.Windows.Forms.Button()
        Me.TBRubyExecutable = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GBPaths.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBPaths
        '
        Me.GBPaths.Controls.Add(Me.BTSearchRubyExecutable)
        Me.GBPaths.Controls.Add(Me.TBRubyExecutable)
        Me.GBPaths.Controls.Add(Me.Label5)
        Me.GBPaths.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GBPaths.Location = New System.Drawing.Point(0, 0)
        Me.GBPaths.Name = "GBPaths"
        Me.GBPaths.Size = New System.Drawing.Size(391, 132)
        Me.GBPaths.TabIndex = 3
        Me.GBPaths.TabStop = False
        Me.GBPaths.Text = "Programmpfade"
        '
        'BTSearchRubyExecutable
        '
        Me.BTSearchRubyExecutable.Location = New System.Drawing.Point(356, 15)
        Me.BTSearchRubyExecutable.Name = "BTSearchRubyExecutable"
        Me.BTSearchRubyExecutable.Size = New System.Drawing.Size(23, 23)
        Me.BTSearchRubyExecutable.TabIndex = 2
        Me.BTSearchRubyExecutable.Text = "..."
        Me.BTSearchRubyExecutable.UseVisualStyleBackColor = True
        '
        'TBRubyExecutable
        '
        Me.TBRubyExecutable.Location = New System.Drawing.Point(114, 17)
        Me.TBRubyExecutable.Name = "TBRubyExecutable"
        Me.TBRubyExecutable.Size = New System.Drawing.Size(236, 20)
        Me.TBRubyExecutable.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Ruby"
        '
        'PathOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GBPaths)
        Me.Name = "PathOptions"
        Me.Size = New System.Drawing.Size(391, 132)
        Me.GBPaths.ResumeLayout(False)
        Me.GBPaths.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GBPaths As System.Windows.Forms.GroupBox
    Friend WithEvents BTSearchRubyExecutable As System.Windows.Forms.Button
    Friend WithEvents TBRubyExecutable As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label

End Class
