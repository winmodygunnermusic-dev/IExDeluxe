Imports System
Imports System.Diagnostics
Imports System.IO

Namespace IExDeluxe
    Friend Module FeatureModules
        Friend Sub OpenLink(url As String)
            If String.IsNullOrWhiteSpace(url) Then Throw New ArgumentException("URL is required.")
            Process.Start(url)
        End Sub

        Friend Sub OpenFile(path As String)
            If String.IsNullOrWhiteSpace(path) OrElse Not File.Exists(path) Then
                Throw New FileNotFoundException("File not found.", path)
            End If

            Process.Start(path)
        End Sub

        Friend Function BuildYouTubeUrl(queryOrUrl As String) As String
            If String.IsNullOrWhiteSpace(queryOrUrl) Then
                Return "https://www.youtube.com"
            End If

            If queryOrUrl.StartsWith("http", StringComparison.OrdinalIgnoreCase) Then
                Return queryOrUrl
            End If

            Return "https://www.youtube.com/results?search_query=" & Uri.EscapeDataString(queryOrUrl)
        End Function

        Friend Function BuildWaybackUrl(targetUrl As String) As String
            If String.IsNullOrWhiteSpace(targetUrl) Then
                Return "https://web.archive.org"
            End If

            Return "https://web.archive.org/web/*/" & targetUrl
        End Function

        Friend Function BuildInternetArchiveVideoSearch(query As String) As String
            If String.IsNullOrWhiteSpace(query) Then
                Return "https://archive.org/details/movies"
            End If

            Return "https://archive.org/details/movies?query=" & Uri.EscapeDataString(query)
        End Function

        Friend Function ParseM3uCount(content As String) As Integer
            If String.IsNullOrWhiteSpace(content) Then Return 0

            Dim lines = content.Split({ControlChars.Cr, ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries)
            Dim count As Integer = 0

            For Each line In lines
                Dim trimmed = line.Trim()
                If trimmed.Length = 0 OrElse trimmed.StartsWith("#", StringComparison.Ordinal) Then
                    Continue For
                End If
                count += 1
            Next

            Return count
        End Function
    End Module
End Namespace
