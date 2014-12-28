<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RubyEditor
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
        Me.SEditor = New ScintillaNET.Scintilla()
        CType(Me.SEditor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SEditor
        '
        Me.SEditor.AutoComplete.AutoHide = False
        Me.SEditor.AutoComplete.IsCaseSensitive = False
        Me.SEditor.AutoComplete.ListString = ""
        Me.SEditor.ConfigurationManager.Language = "ruby"
        Me.SEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SEditor.Folding.MarkerScheme = ScintillaNET.FoldMarkerScheme.Custom
        Me.SEditor.Folding.UseCompactFolding = True
        Me.SEditor.Indentation.BackspaceUnindents = True
        Me.SEditor.Indentation.ShowGuides = True
        Me.SEditor.Indentation.TabWidth = 2
        Me.SEditor.Lexing.Lexer = ScintillaNET.Lexer.Ruby
        Me.SEditor.Lexing.LexerName = "ruby"
        Me.SEditor.Lexing.LineCommentPrefix = "# "
        Me.SEditor.Lexing.StreamCommentPrefix = "=begin "
        Me.SEditor.Lexing.StreamCommentSufix = "=end "
        Me.SEditor.Location = New System.Drawing.Point(0, 0)
        Me.SEditor.Margins.Left = 3
        Me.SEditor.Margins.Margin0.Width = 13
        Me.SEditor.Margins.Margin1.Width = 0
        Me.SEditor.Margins.Margin2.Width = 16
        Me.SEditor.Margins.Right = 3
        Me.SEditor.Markers.Folder.BackColor = System.Drawing.Color.Gray
        Me.SEditor.Markers.Folder.ForeColor = System.Drawing.Color.White
        Me.SEditor.Markers.Folder.Number = 30
        Me.SEditor.Markers.Folder.Symbol = ScintillaNET.MarkerSymbol.CirclePlus
        Me.SEditor.Markers.FolderEnd.BackColor = System.Drawing.Color.Gray
        Me.SEditor.Markers.FolderEnd.ForeColor = System.Drawing.Color.White
        Me.SEditor.Markers.FolderEnd.Number = 25
        Me.SEditor.Markers.FolderEnd.Symbol = ScintillaNET.MarkerSymbol.CirclePlusConnected
        Me.SEditor.Markers.FolderOpen.BackColor = System.Drawing.Color.Gray
        Me.SEditor.Markers.FolderOpen.ForeColor = System.Drawing.Color.White
        Me.SEditor.Markers.FolderOpen.Number = 31
        Me.SEditor.Markers.FolderOpen.Symbol = ScintillaNET.MarkerSymbol.CircleMinus
        Me.SEditor.Markers.FolderOpenMid.BackColor = System.Drawing.Color.Gray
        Me.SEditor.Markers.FolderOpenMid.ForeColor = System.Drawing.Color.White
        Me.SEditor.Markers.FolderOpenMid.Number = 26
        Me.SEditor.Markers.FolderOpenMid.Symbol = ScintillaNET.MarkerSymbol.CircleMinusConnected
        Me.SEditor.Markers.FolderOpenMidTail.BackColor = System.Drawing.Color.Gray
        Me.SEditor.Markers.FolderOpenMidTail.ForeColor = System.Drawing.Color.White
        Me.SEditor.Markers.FolderOpenMidTail.Number = 27
        Me.SEditor.Markers.FolderOpenMidTail.Symbol = ScintillaNET.MarkerSymbol.TCorner
        Me.SEditor.Markers.FolderSub.BackColor = System.Drawing.Color.Gray
        Me.SEditor.Markers.FolderSub.ForeColor = System.Drawing.Color.White
        Me.SEditor.Markers.FolderSub.Number = 29
        Me.SEditor.Markers.FolderSub.Symbol = ScintillaNET.MarkerSymbol.VLine
        Me.SEditor.Markers.FolderTail.BackColor = System.Drawing.Color.Gray
        Me.SEditor.Markers.FolderTail.ForeColor = System.Drawing.Color.White
        Me.SEditor.Markers.FolderTail.Number = 28
        Me.SEditor.Markers.FolderTail.Symbol = ScintillaNET.MarkerSymbol.LCorner
        Me.SEditor.Name = "SEditor"
        Me.SEditor.Size = New System.Drawing.Size(150, 150)
        Me.SEditor.Styles.BraceBad.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.SEditor.Styles.BraceLight.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.SEditor.Styles.CallTip.FontName = "Segoe UI" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.SEditor.Styles.ControlChar.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.SEditor.Styles.Default.BackColor = System.Drawing.SystemColors.Window
        Me.SEditor.Styles.Default.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.SEditor.Styles.IndentGuide.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.SEditor.Styles.LastPredefined.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.SEditor.Styles.LineNumber.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.SEditor.Styles.Max.FontName = "Verdana" & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0) & Global.Microsoft.VisualBasic.ChrW(0)
        Me.SEditor.TabIndex = 1
        '
        'RubyEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SEditor)
        Me.Name = "RubyEditor"
        CType(Me.SEditor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SEditor As ScintillaNET.Scintilla

End Class
