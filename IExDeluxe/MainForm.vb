Imports System
Imports System.IO
Imports System.Windows.Forms

Namespace IExDeluxe
    Public Class MainForm
        Inherits Form

        Private ReadOnly _txtInput As New TextBox()
        Private ReadOnly _txtLog As New TextBox()

        Public Sub New()
            Text = "Internet Explorer XDeluxe"
            Width = 960
            Height = 640
            StartPosition = FormStartPosition.CenterScreen

            Dim panel As New FlowLayoutPanel() With {
                .Dock = DockStyle.Top,
                .AutoSize = True,
                .WrapContents = True,
                .Padding = New Padding(8)
            }

            _txtInput.Width = 600
            _txtInput.Text = "https://example.com"
            panel.Controls.Add(_txtInput)

            AddButton(panel, "Open Link", AddressOf OnOpenLink)
            AddButton(panel, "Open File", AddressOf OnOpenFile)
            AddButton(panel, "YouTube", AddressOf OnOpenYouTube)
            AddButton(panel, "Classic Video", AddressOf OnClassicVideo)
            AddButton(panel, "SWF Flash", AddressOf OnSwfFlash)
            AddButton(panel, "IPTV M3U", AddressOf OnIptv)
            AddButton(panel, "Wayback", AddressOf OnWayback)
            AddButton(panel, "Archive Videos", AddressOf OnArchiveVideos)

            _txtLog.Multiline = True
            _txtLog.Dock = DockStyle.Fill
            _txtLog.ScrollBars = ScrollBars.Vertical
            _txtLog.ReadOnly = True

            Controls.Add(_txtLog)
            Controls.Add(panel)

            Log("IExDeluxe starter loaded.")
            Log("Enter URL/file/query above, then click feature buttons.")
            Log("Compatibility profiles: " & String.Join(", ", CompatibilityProfiles.GetSupportedProfiles()))
        End Sub

        Private Sub AddButton(parent As Control, text As String, handler As EventHandler)
            Dim button As New Button() With {
                .Text = text,
                .AutoSize = True,
                .Margin = New Padding(4)
            }
            AddHandler button.Click, handler
            parent.Controls.Add(button)
        End Sub

        Private Sub OnOpenLink(sender As Object, e As EventArgs)
            Try
                OpenLink(_txtInput.Text.Trim())
                Log("Opened link: " & _txtInput.Text.Trim())
            Catch ex As Exception
                Log("Open Link error: " & ex.Message)
            End Try
        End Sub

        Private Sub OnOpenFile(sender As Object, e As EventArgs)
            Try
                OpenFile(_txtInput.Text.Trim())
                Log("Opened file: " & _txtInput.Text.Trim())
            Catch ex As Exception
                Log("Open File error: " & ex.Message)
            End Try
        End Sub

        Private Sub OnOpenYouTube(sender As Object, e As EventArgs)
            Dim url = BuildYouTubeUrl(_txtInput.Text.Trim())
            OpenLink(url)
            Log("YouTube launcher: " & url)
        End Sub

        Private Sub OnClassicVideo(sender As Object, e As EventArgs)
            Log("Classic video player: stub hook (integrate VLC/MPC-HC/DirectShow).")
        End Sub

        Private Sub OnSwfFlash(sender As Object, e As EventArgs)
            Log("SWF Flash player: stub hook (e.g., Ruffle integration or legacy ActiveX host).")
        End Sub

        Private Sub OnIptv(sender As Object, e As EventArgs)
            Dim input = _txtInput.Text.Trim()

            If File.Exists(input) Then
                Dim count = ParseM3uCount(File.ReadAllText(input))
                Log("IPTV M3U loaded from file. Channels detected: " & count.ToString())
                Return
            End If

            Log("IPTV M3U: provide a local .m3u/.m3u8 file path in input.")
        End Sub

        Private Sub OnWayback(sender As Object, e As EventArgs)
            Dim url = BuildWaybackUrl(_txtInput.Text.Trim())
            OpenLink(url)
            Log("Wayback finder: " & url)
        End Sub

        Private Sub OnArchiveVideos(sender As Object, e As EventArgs)
            Dim url = BuildInternetArchiveVideoSearch(_txtInput.Text.Trim())
            OpenLink(url)
            Log("Internet Archive video search: " & url)
        End Sub

        Private Sub Log(message As String)
            _txtLog.AppendText(DateTime.Now.ToString("u") & " | " & message & Environment.NewLine)
        End Sub
    End Class
End Namespace
