<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResourcesView
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PRam = New System.Windows.Forms.ProgressBar()
        Me.PProc = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Arbeitsspeicher"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Prozessorlast"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PRam
        '
        Me.PRam.Location = New System.Drawing.Point(91, 32)
        Me.PRam.Name = "PRam"
        Me.PRam.Size = New System.Drawing.Size(400, 23)
        Me.PRam.TabIndex = 2
        '
        'PProc
        '
        Me.PProc.Location = New System.Drawing.Point(91, 3)
        Me.PProc.Name = "PProc"
        Me.PProc.Size = New System.Drawing.Size(400, 23)
        Me.PProc.TabIndex = 3
        '
        'ResourcesView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.PProc)
        Me.Controls.Add(Me.PRam)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ResourcesView"
        Me.Size = New System.Drawing.Size(496, 59)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PRam As System.Windows.Forms.ProgressBar
    Friend WithEvents PProc As System.Windows.Forms.ProgressBar

End Class
