<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorControl
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
        Me.PEditor = New System.Windows.Forms.Panel()
        Me.BTToggleEditor = New System.Windows.Forms.Button()
        Me.BTRunRuby = New System.Windows.Forms.Button()
        Me.BTRunLua = New System.Windows.Forms.Button()
        Me.BTTransport = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PEditor
        '
        Me.PEditor.Dock = System.Windows.Forms.DockStyle.Top
        Me.PEditor.Location = New System.Drawing.Point(0, 0)
        Me.PEditor.Name = "PEditor"
        Me.PEditor.Size = New System.Drawing.Size(1008, 482)
        Me.PEditor.TabIndex = 0
        '
        'BTToggleEditor
        '
        Me.BTToggleEditor.Location = New System.Drawing.Point(262, 498)
        Me.BTToggleEditor.Name = "BTToggleEditor"
        Me.BTToggleEditor.Size = New System.Drawing.Size(75, 23)
        Me.BTToggleEditor.TabIndex = 1
        Me.BTToggleEditor.Text = "ToggleEditor"
        Me.BTToggleEditor.UseVisualStyleBackColor = True
        '
        'BTRunRuby
        '
        Me.BTRunRuby.Location = New System.Drawing.Point(392, 497)
        Me.BTRunRuby.Name = "BTRunRuby"
        Me.BTRunRuby.Size = New System.Drawing.Size(113, 23)
        Me.BTRunRuby.TabIndex = 2
        Me.BTRunRuby.Text = "Ruby ausführen"
        Me.BTRunRuby.UseVisualStyleBackColor = True
        '
        'BTRunLua
        '
        Me.BTRunLua.Location = New System.Drawing.Point(584, 496)
        Me.BTRunLua.Name = "BTRunLua"
        Me.BTRunLua.Size = New System.Drawing.Size(98, 23)
        Me.BTRunLua.TabIndex = 3
        Me.BTRunLua.Text = "Lua ausführen"
        Me.BTRunLua.UseVisualStyleBackColor = True
        '
        'BTTransport
        '
        Me.BTTransport.Location = New System.Drawing.Point(759, 495)
        Me.BTTransport.Name = "BTTransport"
        Me.BTTransport.Size = New System.Drawing.Size(137, 23)
        Me.BTTransport.TabIndex = 4
        Me.BTTransport.Text = "Code Übertragen"
        Me.BTTransport.UseVisualStyleBackColor = True
        '
        'EditorControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.BTTransport)
        Me.Controls.Add(Me.BTRunLua)
        Me.Controls.Add(Me.BTRunRuby)
        Me.Controls.Add(Me.BTToggleEditor)
        Me.Controls.Add(Me.PEditor)
        Me.Name = "EditorControl"
        Me.Size = New System.Drawing.Size(1008, 540)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PEditor As System.Windows.Forms.Panel
    Friend WithEvents BTToggleEditor As System.Windows.Forms.Button
    Friend WithEvents BTRunRuby As System.Windows.Forms.Button
    Friend WithEvents BTRunLua As System.Windows.Forms.Button
    Friend WithEvents BTTransport As System.Windows.Forms.Button

End Class
