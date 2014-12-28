<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
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
        Me.PRessources = New System.Windows.Forms.Panel()
        Me.PEncodeView = New System.Windows.Forms.Panel()
        Me.PDelimeter = New System.Windows.Forms.Panel()
        Me.TCMain = New System.Windows.Forms.TabControl()
        Me.TPHome = New System.Windows.Forms.TabPage()
        Me.TPProjects = New System.Windows.Forms.TabPage()
        Me.TPOptions = New System.Windows.Forms.TabPage()
        Me.TPVideoView = New System.Windows.Forms.TabPage()
        Me.PLastEvents = New System.Windows.Forms.Panel()
        Me.TPEditor = New System.Windows.Forms.TabPage()
        Me.TCMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'PRessources
        '
        Me.PRessources.Location = New System.Drawing.Point(0, 630)
        Me.PRessources.Name = "PRessources"
        Me.PRessources.Size = New System.Drawing.Size(496, 59)
        Me.PRessources.TabIndex = 0
        '
        'PEncodeView
        '
        Me.PEncodeView.Location = New System.Drawing.Point(496, 569)
        Me.PEncodeView.Name = "PEncodeView"
        Me.PEncodeView.Size = New System.Drawing.Size(519, 120)
        Me.PEncodeView.TabIndex = 1
        '
        'PDelimeter
        '
        Me.PDelimeter.BackColor = System.Drawing.SystemColors.ControlText
        Me.PDelimeter.Location = New System.Drawing.Point(0, 566)
        Me.PDelimeter.Name = "PDelimeter"
        Me.PDelimeter.Size = New System.Drawing.Size(1024, 3)
        Me.PDelimeter.TabIndex = 2
        '
        'TCMain
        '
        Me.TCMain.Controls.Add(Me.TPHome)
        Me.TCMain.Controls.Add(Me.TPProjects)
        Me.TCMain.Controls.Add(Me.TPEditor)
        Me.TCMain.Controls.Add(Me.TPOptions)
        Me.TCMain.Controls.Add(Me.TPVideoView)
        Me.TCMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.TCMain.HotTrack = True
        Me.TCMain.Location = New System.Drawing.Point(0, 0)
        Me.TCMain.Name = "TCMain"
        Me.TCMain.SelectedIndex = 0
        Me.TCMain.Size = New System.Drawing.Size(1014, 566)
        Me.TCMain.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.TCMain.TabIndex = 3
        '
        'TPHome
        '
        Me.TPHome.BackColor = System.Drawing.Color.Transparent
        Me.TPHome.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TPHome.Location = New System.Drawing.Point(4, 22)
        Me.TPHome.Name = "TPHome"
        Me.TPHome.Padding = New System.Windows.Forms.Padding(3)
        Me.TPHome.Size = New System.Drawing.Size(1006, 540)
        Me.TPHome.TabIndex = 0
        Me.TPHome.Text = "Home"
        '
        'TPProjects
        '
        Me.TPProjects.BackColor = System.Drawing.Color.Transparent
        Me.TPProjects.Location = New System.Drawing.Point(4, 22)
        Me.TPProjects.Name = "TPProjects"
        Me.TPProjects.Padding = New System.Windows.Forms.Padding(3)
        Me.TPProjects.Size = New System.Drawing.Size(1006, 540)
        Me.TPProjects.TabIndex = 1
        Me.TPProjects.Text = "Projekte"
        '
        'TPOptions
        '
        Me.TPOptions.Location = New System.Drawing.Point(4, 22)
        Me.TPOptions.Name = "TPOptions"
        Me.TPOptions.Size = New System.Drawing.Size(1006, 540)
        Me.TPOptions.TabIndex = 2
        Me.TPOptions.Text = "Optionen"
        '
        'TPVideoView
        '
        Me.TPVideoView.Location = New System.Drawing.Point(4, 22)
        Me.TPVideoView.Name = "TPVideoView"
        Me.TPVideoView.Size = New System.Drawing.Size(1006, 540)
        Me.TPVideoView.TabIndex = 3
        Me.TPVideoView.Text = "Video-Vorschau"
        '
        'PLastEvents
        '
        Me.PLastEvents.Location = New System.Drawing.Point(0, 569)
        Me.PLastEvents.Name = "PLastEvents"
        Me.PLastEvents.Size = New System.Drawing.Size(496, 60)
        Me.PLastEvents.TabIndex = 4
        '
        'TPEditor
        '
        Me.TPEditor.Location = New System.Drawing.Point(4, 22)
        Me.TPEditor.Name = "TPEditor"
        Me.TPEditor.Size = New System.Drawing.Size(1006, 540)
        Me.TPEditor.TabIndex = 4
        Me.TPEditor.Text = "Editor"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1014, 688)
        Me.Controls.Add(Me.PLastEvents)
        Me.Controls.Add(Me.TCMain)
        Me.Controls.Add(Me.PDelimeter)
        Me.Controls.Add(Me.PEncodeView)
        Me.Controls.Add(Me.PRessources)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.Text = "Form1"
        Me.TCMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PRessources As System.Windows.Forms.Panel
    Friend WithEvents PEncodeView As System.Windows.Forms.Panel
    Friend WithEvents PDelimeter As System.Windows.Forms.Panel
    Friend WithEvents TCMain As System.Windows.Forms.TabControl
    Friend WithEvents TPHome As System.Windows.Forms.TabPage
    Friend WithEvents TPProjects As System.Windows.Forms.TabPage
    Friend WithEvents TPOptions As System.Windows.Forms.TabPage
    Friend WithEvents PLastEvents As System.Windows.Forms.Panel
    Friend WithEvents TPVideoView As System.Windows.Forms.TabPage
    Friend WithEvents TPEditor As System.Windows.Forms.TabPage

End Class
