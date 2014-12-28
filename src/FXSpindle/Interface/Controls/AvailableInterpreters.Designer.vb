<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AvailableInterpreters
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
        Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Basis-Interpreter", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup(".NET-Interpreter", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Ruby-Interpreter", System.Windows.Forms.HorizontalAlignment.Left)
        Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Lua-Interpreter", System.Windows.Forms.HorizontalAlignment.Left)
        Me.GBInterpreters = New System.Windows.Forms.GroupBox()
        Me.LVInterpreters = New System.Windows.Forms.ListView()
        Me.CHInterpreter = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CHAvailable = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.GBInterpreters.SuspendLayout()
        Me.SuspendLayout()
        '
        'GBInterpreters
        '
        Me.GBInterpreters.Controls.Add(Me.LVInterpreters)
        Me.GBInterpreters.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GBInterpreters.Location = New System.Drawing.Point(0, 0)
        Me.GBInterpreters.Name = "GBInterpreters"
        Me.GBInterpreters.Size = New System.Drawing.Size(300, 300)
        Me.GBInterpreters.TabIndex = 2
        Me.GBInterpreters.TabStop = False
        Me.GBInterpreters.Text = "Verfügbare Interpreter"
        '
        'LVInterpreters
        '
        Me.LVInterpreters.BackColor = System.Drawing.SystemColors.Control
        Me.LVInterpreters.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.LVInterpreters.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CHInterpreter, Me.CHAvailable})
        Me.LVInterpreters.Dock = System.Windows.Forms.DockStyle.Fill
        ListViewGroup1.Header = "Basis-Interpreter"
        ListViewGroup1.Name = "LVGBase"
        ListViewGroup2.Header = ".NET-Interpreter"
        ListViewGroup2.Name = "LVGNet"
        ListViewGroup3.Header = "Ruby-Interpreter"
        ListViewGroup3.Name = "LVGRuby"
        ListViewGroup4.Header = "Lua-Interpreter"
        ListViewGroup4.Name = "LVGLua"
        Me.LVInterpreters.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4})
        Me.LVInterpreters.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.LVInterpreters.HideSelection = False
        Me.LVInterpreters.Location = New System.Drawing.Point(3, 16)
        Me.LVInterpreters.MultiSelect = False
        Me.LVInterpreters.Name = "LVInterpreters"
        Me.LVInterpreters.Size = New System.Drawing.Size(294, 281)
        Me.LVInterpreters.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LVInterpreters.TabIndex = 0
        Me.LVInterpreters.UseCompatibleStateImageBehavior = False
        Me.LVInterpreters.View = System.Windows.Forms.View.Details
        '
        'CHInterpreter
        '
        Me.CHInterpreter.Text = "Interpreter"
        Me.CHInterpreter.Width = 138
        '
        'CHAvailable
        '
        Me.CHAvailable.Text = "Verfügbare Version"
        Me.CHAvailable.Width = 156
        '
        'AvailableInterpreters
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GBInterpreters)
        Me.Name = "AvailableInterpreters"
        Me.Size = New System.Drawing.Size(300, 300)
        Me.GBInterpreters.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GBInterpreters As System.Windows.Forms.GroupBox
    Friend WithEvents LVInterpreters As System.Windows.Forms.ListView
    Friend WithEvents CHInterpreter As System.Windows.Forms.ColumnHeader
    Friend WithEvents CHAvailable As System.Windows.Forms.ColumnHeader

End Class
