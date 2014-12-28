<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MiscOptions
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
        Me.GPDefault = New System.Windows.Forms.GroupBox()
        Me.CBShowEncodeState = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CBShowLastEvents = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBShowResourceUsage = New System.Windows.Forms.CheckBox()
        Me.CBWriteName = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBName = New System.Windows.Forms.TextBox()
        Me.LBName = New System.Windows.Forms.Label()
        Me.GPDefault.SuspendLayout()
        Me.SuspendLayout()
        '
        'GPDefault
        '
        Me.GPDefault.Controls.Add(Me.CBShowEncodeState)
        Me.GPDefault.Controls.Add(Me.Label4)
        Me.GPDefault.Controls.Add(Me.CBShowLastEvents)
        Me.GPDefault.Controls.Add(Me.Label3)
        Me.GPDefault.Controls.Add(Me.Label2)
        Me.GPDefault.Controls.Add(Me.CBShowResourceUsage)
        Me.GPDefault.Controls.Add(Me.CBWriteName)
        Me.GPDefault.Controls.Add(Me.Label1)
        Me.GPDefault.Controls.Add(Me.TBName)
        Me.GPDefault.Controls.Add(Me.LBName)
        Me.GPDefault.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GPDefault.Location = New System.Drawing.Point(0, 0)
        Me.GPDefault.Name = "GPDefault"
        Me.GPDefault.Size = New System.Drawing.Size(391, 152)
        Me.GPDefault.TabIndex = 1
        Me.GPDefault.TabStop = False
        Me.GPDefault.Text = "Allgemeine Optionen"
        '
        'CBShowEncodeState
        '
        Me.CBShowEncodeState.AutoSize = True
        Me.CBShowEncodeState.Checked = True
        Me.CBShowEncodeState.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBShowEncodeState.Location = New System.Drawing.Point(237, 129)
        Me.CBShowEncodeState.Name = "CBShowEncodeState"
        Me.CBShowEncodeState.Size = New System.Drawing.Size(15, 14)
        Me.CBShowEncodeState.TabIndex = 9
        Me.CBShowEncodeState.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 129)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Encode-Anzeige"
        '
        'CBShowLastEvents
        '
        Me.CBShowLastEvents.AutoSize = True
        Me.CBShowLastEvents.Checked = True
        Me.CBShowLastEvents.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBShowLastEvents.Location = New System.Drawing.Point(237, 100)
        Me.CBShowLastEvents.Name = "CBShowLastEvents"
        Me.CBShowLastEvents.Size = New System.Drawing.Size(15, 14)
        Me.CBShowLastEvents.TabIndex = 7
        Me.CBShowLastEvents.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(133, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Letzte Ereignisse anzeigen"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(161, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Ressourcenauslastung anzeigen"
        '
        'CBShowResourceUsage
        '
        Me.CBShowResourceUsage.AutoSize = True
        Me.CBShowResourceUsage.Checked = True
        Me.CBShowResourceUsage.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBShowResourceUsage.Location = New System.Drawing.Point(237, 71)
        Me.CBShowResourceUsage.Name = "CBShowResourceUsage"
        Me.CBShowResourceUsage.Size = New System.Drawing.Size(15, 14)
        Me.CBShowResourceUsage.TabIndex = 4
        Me.CBShowResourceUsage.UseVisualStyleBackColor = True
        '
        'CBWriteName
        '
        Me.CBWriteName.AutoSize = True
        Me.CBWriteName.Checked = True
        Me.CBWriteName.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CBWriteName.Location = New System.Drawing.Point(237, 20)
        Me.CBWriteName.Name = "CBWriteName"
        Me.CBWriteName.Size = New System.Drawing.Size(15, 14)
        Me.CBWriteName.TabIndex = 3
        Me.CBWriteName.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(223, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Namen in ASS-Skripte schreiben (Kommentar)"
        '
        'TBName
        '
        Me.TBName.Location = New System.Drawing.Point(237, 41)
        Me.TBName.Name = "TBName"
        Me.TBName.Size = New System.Drawing.Size(142, 20)
        Me.TBName.TabIndex = 1
        '
        'LBName
        '
        Me.LBName.AutoSize = True
        Me.LBName.Location = New System.Drawing.Point(7, 44)
        Me.LBName.Name = "LBName"
        Me.LBName.Size = New System.Drawing.Size(60, 13)
        Me.LBName.TabIndex = 0
        Me.LBName.Text = "Dein Name"
        '
        'MiscOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GPDefault)
        Me.Name = "MiscOptions"
        Me.Size = New System.Drawing.Size(391, 152)
        Me.GPDefault.ResumeLayout(False)
        Me.GPDefault.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GPDefault As System.Windows.Forms.GroupBox
    Friend WithEvents CBShowEncodeState As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CBShowLastEvents As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CBShowResourceUsage As System.Windows.Forms.CheckBox
    Friend WithEvents CBWriteName As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBName As System.Windows.Forms.TextBox
    Friend WithEvents LBName As System.Windows.Forms.Label

End Class
