Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Windows.Forms
Imports CefSharp.WinForms
Imports LibVLCSharp.Shared
Imports LibVLCSharp.WinForms
Imports XDeluxe.Core

Namespace XDeluxe.UI
    Public Class MainForm
        Inherits Form

        Private ReadOnly _input As New TextBox()
        Private ReadOnly _log As New TextBox()
        Private ReadOnly _browser As ChromiumWebBrowser
        Private ReadOnly _videoView As VideoView
        Private _libVlc As LibVLC
        Private _player As MediaPlayer

        Public Sub New()
            Text = "XDeluxe"
            Width = 1200
            Height = 760

            Core.Initialize()
            _libVlc = New LibVLC()
            _player = New MediaPlayer(_libVlc)
            _videoView = New VideoView() With {.Dock = DockStyle.Fill, .MediaPlayer = _player}
            _browser = New ChromiumWebBrowser("https://www.youtube.com") With {.Dock = DockStyle.Fill}

            Dim topBar As New FlowLayoutPanel() With {.Dock = DockStyle.Top, .AutoSize = True, .Padding = New Padding(8)}
            _input.Width = 700
            _input.Text = "https://example.com"
            topBar.Controls.Add(_input)
            AddButton(topBar, "YouTube", Sub() Browse(YouTubeHelper.BuildWatchOrSearch(_input.Text.Trim())))
            AddButton(topBar, "Wayback", Sub() Browse(WaybackClient.BuildLookupUrl(_input.Text.Trim())))
            AddButton(topBar, "Archive Search", Sub() Browse(WaybackClient.BuildArchiveVideoSearch(_input.Text.Trim())))
            AddButton(topBar, "Play File", AddressOf PlayFile)
            AddButton(topBar, "Play IPTV M3U", AddressOf PlayIptv)
            AddButton(topBar, "Open SWF Wrapper", AddressOf OpenRuffleWrapper)

            Dim tabs As New TabControl() With {.Dock = DockStyle.Fill}
            tabs.TabPages.Add(New TabPage("Embedded Browser") With {.Controls = {_browser}})
            tabs.TabPages.Add(New TabPage("Classic Player / IPTV") With {.Controls = {_videoView}})
            tabs.TabPages.Add(New TabPage("Logs") With {.Controls = {BuildLogBox()}})

            Controls.Add(tabs)
            Controls.Add(topBar)

            Log("CefSharp browser + LibVLC player initialized.")
            Log("Use release/bin/<arch> payload folders for native dependency packaging.")
        End Sub

        Private Function BuildLogBox() As Control
            _log.Multiline = True
            _log.Dock = DockStyle.Fill
            _log.ReadOnly = True
            _log.ScrollBars = ScrollBars.Vertical
            Return _log
        End Function

        Private Sub AddButton(parent As Control, caption As String, action As Action)
            Dim b As New Button() With {.Text = caption, .AutoSize = True, .Margin = New Padding(4)}
            AddHandler b.Click, Sub(sender, args) action()
            parent.Controls.Add(b)
        End Sub

        Private Sub Browse(url As String)
            _browser.Load(url)
            Log("Browser URL: " & url)
        End Sub

        Private Sub PlayFile()
            Dim path = _input.Text.Trim()
            If Not File.Exists(path) Then
                Log("Video file not found: " & path)
                Return
            End If

            Using media = New Media(_libVlc, New Uri(path))
                _player.Play(media)
            End Using
            Log("Playing local file via LibVLC: " & path)
        End Sub

        Private Sub PlayIptv()
            Dim path = _input.Text.Trim()
            If Not File.Exists(path) Then
                Log("M3U file not found: " & path)
                Return
            End If

            Dim manager As New PlaylistManager()
            manager.LoadFromM3u(File.ReadAllText(path))
            If manager.Items.Count = 0 Then
                Log("No stream entries found in M3U.")
                Return
            End If

            Using media = New Media(_libVlc, New Uri(manager.Items(0)))
                _player.Play(media)
            End Using
            Log("Playing first IPTV stream via LibVLC: " & manager.Items(0))
        End Sub

        Private Sub OpenRuffleWrapper()
            Dim wrapperPath = Path.Combine(Application.StartupPath, "ruffle", "ruffle_player.html")
            If Not File.Exists(wrapperPath) Then
                Log("Ruffle wrapper missing. Add ruffle_player.html + ruffle.js under release/ruffle.")
                Return
            End If

            Dim url = New Uri(wrapperPath).AbsoluteUri
            _browser.Load(url)
            Log("Loaded SWF wrapper HTML: " & wrapperPath)
        End Sub

        Private Sub Log(message As String)
            _log.AppendText(DateTime.Now.ToString("u") & " | " & message & Environment.NewLine)
        End Sub

        Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
            If _player IsNot Nothing Then _player.Dispose()
            If _libVlc IsNot Nothing Then _libVlc.Dispose()
            MyBase.OnFormClosed(e)
        End Sub
    End Class
End Namespace
