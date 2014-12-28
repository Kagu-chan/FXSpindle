<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EncodeViewer
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
        Me.LNoEnc = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LNoEnc
        '
        Me.LNoEnc.BackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.LNoEnc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LNoEnc.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LNoEnc.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.LNoEnc.Location = New System.Drawing.Point(0, 0)
        Me.LNoEnc.Name = "LNoEnc"
        Me.LNoEnc.Size = New System.Drawing.Size(519, 120)
        Me.LNoEnc.TabIndex = 0
        Me.LNoEnc.Text = "Derzeit kein aktiver Encode"
        Me.LNoEnc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EncodeViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Controls.Add(Me.LNoEnc)
        Me.Name = "EncodeViewer"
        Me.Size = New System.Drawing.Size(519, 120)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents LNoEnc As System.Windows.Forms.Label

End Class
