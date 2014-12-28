<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionsControl
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
        Me.MiscOptions1 = New Ruby_KaraInterpreter.MiscOptions()
        Me.AvailableInterpreters1 = New Ruby_KaraInterpreter.AvailableInterpreters()
        Me.PathOptions1 = New Ruby_KaraInterpreter.PathOptions()
        Me.SuspendLayout()
        '
        'MiscOptions1
        '
        Me.MiscOptions1.Location = New System.Drawing.Point(3, 3)
        Me.MiscOptions1.Name = "MiscOptions1"
        Me.MiscOptions1.Size = New System.Drawing.Size(391, 152)
        Me.MiscOptions1.TabIndex = 4
        '
        'AvailableInterpreters1
        '
        Me.AvailableInterpreters1.Dock = System.Windows.Forms.DockStyle.Right
        Me.AvailableInterpreters1.Location = New System.Drawing.Point(706, 0)
        Me.AvailableInterpreters1.Name = "AvailableInterpreters1"
        Me.AvailableInterpreters1.Size = New System.Drawing.Size(300, 540)
        Me.AvailableInterpreters1.TabIndex = 3
        '
        'PathOptions1
        '
        Me.PathOptions1.Location = New System.Drawing.Point(3, 157)
        Me.PathOptions1.Name = "PathOptions1"
        Me.PathOptions1.Size = New System.Drawing.Size(391, 132)
        Me.PathOptions1.TabIndex = 5
        '
        'OptionsControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.PathOptions1)
        Me.Controls.Add(Me.MiscOptions1)
        Me.Controls.Add(Me.AvailableInterpreters1)
        Me.Name = "OptionsControl"
        Me.Size = New System.Drawing.Size(1006, 540)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AvailableInterpreters1 As Ruby_KaraInterpreter.AvailableInterpreters
    Friend WithEvents MiscOptions1 As Ruby_KaraInterpreter.MiscOptions
    Friend WithEvents PathOptions1 As Ruby_KaraInterpreter.PathOptions

End Class
