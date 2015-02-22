Option Compare Binary
Option Explicit On
Option Infer On
Option Strict On

Imports ScintillaNET

Public Class EditorTweaks

    Private _control As Scintilla

    Public Sub New(ByVal editor As Scintilla)
        _control = editor
    End Sub

    Public Sub AddHandlers()
        AddHandler _control.TextChanged,
            Sub()
                Dim linesSpace As Integer = _control.Lines.Count.ToString.Length * 10 + 3
                _control.Margins(0).Width = linesSpace
            End Sub

        AddHandler _control.KeyDown,
            Sub(sender As Object, e As KeyEventArgs)
                If Not e.KeyCode = Keys.Enter Then Return

                Dim indentation As Integer = _control.Lines.Current.Indentation
                _control.InsertText(vbNewLine)

                If indentation > 0 Then
                    _control.InsertText(" ".PadLeft(indentation))
                End If

                e.Handled = True
            End Sub

    End Sub

    Public Sub SetCommentCommands(ByVal commandLinePrefix As String, ByVal multiLinePrefix As String, ByVal multiLineSufix As String)
        With _control.Lexing
            .LineCommentPrefix = commandLinePrefix
            .StreamCommentPrefix = multiLinePrefix
            .StreamCommentSufix = multiLineSufix
        End With
    End Sub

    Public Sub SetWords(ByVal words() As String)
        Dim i As Integer = 0
        For Each list As String In words
            _control.Lexing.SetKeywords(i, list)

            i += 1
            If i = words.Length Then Exit For
        Next
    End Sub

    Public Sub SetForeColor(ByVal color As Color, ByVal words() As String)
        For Each word As String In words
            InternalSetForeColor(word, color)
        Next
    End Sub

    Public Sub SetForeColor(ByVal color As Color, ByVal word As String)
        InternalSetForeColor(word, color)
    End Sub

    Public Sub SetForeColor(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, ByVal word As String)
        InternalSetForeColor(word, ColorTranslator.FromWin32(RGB(r, g, b)))
    End Sub

    Public Sub SetForeColor(ByVal colorCode As String, ByVal word As String)
        InternalSetForeColor(word, ColorTranslator.FromHtml(colorCode))
    End Sub

    Public Sub SetBackColor(ByVal color As Color, ByVal words() As String)
        For Each word As String In words
            InternalSetBackColor(word, color)
        Next
    End Sub

    Public Sub SetBackColor(ByVal color As Color, ByVal word As String)
        InternalSetBackColor(word, color)
    End Sub

    Public Sub SetBackColor(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer, ByVal word As String)
        InternalSetBackColor(word, ColorTranslator.FromWin32(RGB(r, g, b)))
    End Sub

    Public Sub SetBackColor(ByVal colorCode As String, ByVal word As String)
        InternalSetBackColor(word, ColorTranslator.FromHtml(colorCode))
    End Sub

    Public Sub SetBold(ByVal words() As String)
        For Each word As String In words
            InternalSetBold(word)
        Next
    End Sub

    Public Sub SetItalic(ByVal words() As String)
        For Each word As String In words
            InternalSetItalic(word)
        Next
    End Sub

    Public Function GetParseString() As String
        Dim code As String = _control.Text
        code = code & vbNewLine & "main()"
        Return code
    End Function

    Public Sub ImportTransport(ByVal sender As Object, ByVal e As CodeTransportEventArgs)
        Dim startFlag As String = "{importsection:start}"
        Dim endFlag As String = "{importsection:end}"
        Dim originalText As String
        Dim addComment As Boolean = True

        With _control
            originalText = .Text

            If originalText.Contains(startFlag) AndAlso originalText.Contains(endFlag) Then
                Dim result As DialogResult = MessageBox.Show(
                    "Es ist bereits ein importiertes Skript vorhanden!" & vbNewLine & "Ersetzen?",
                    "Warnung",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning)

                If result = DialogResult.Cancel Then Return
                addComment = False
            End If

            Dim code As String = String.Empty
            For Each line As Line In e.Lines
                Static copyLine As Boolean = True
                If line.Text.Contains(e.CommentBegin) Then copyLine = False
                If Not copyLine AndAlso line.Text.Contains(e.CommentEnd) Then
                    copyLine = True
                    Continue For
                End If

                If copyLine Then code = code & " ".PadLeft(.Indentation.TabWidth) & line.Text
            Next

            Dim rawBefore As String = startFlag & vbNewLine.PadLeft(2)
            Dim rawAfter As String = vbNewLine.PadLeft(2)

            If addComment Then
                Dim beforeText As String = vbNewLine.PadLeft(2) & .Lexing.StreamCommentPrefix & vbNewLine & rawBefore
                Dim afterText As String = rawAfter & endFlag & vbNewLine & .Lexing.StreamCommentSufix

                .Text = originalText & beforeText & code & afterText
            Else
                .GetRange(
                    .Text.IndexOf(startFlag),
                    .Text.IndexOf(endFlag)
                ).Text = rawBefore & code & rawAfter
            End If
        End With
    End Sub

    Private Sub InternalSetForeColor(ByVal keyMap As String, ByVal c As Color)
        _control.Styles(_control.Lexing.StyleNameMap(keyMap)).ForeColor = c
    End Sub

    Private Sub InternalSetBackColor(ByVal keyMap As String, ByVal c As Color)
        _control.Styles(_control.Lexing.StyleNameMap(keyMap)).BackColor = c
    End Sub

    Private Sub InternalSetBold(ByVal keyMap As String)
        _control.Styles(_control.Lexing.StyleNameMap(keyMap)).Bold = True
    End Sub

    Private Sub InternalSetItalic(ByVal keyMap As String)
        _control.Styles(_control.Lexing.StyleNameMap(keyMap)).Italic = True
    End Sub

End Class
