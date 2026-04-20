Imports System

Namespace XDeluxe.Core
    Public Module WaybackClient
        Public Function BuildLookupUrl(targetUrl As String) As String
            If String.IsNullOrWhiteSpace(targetUrl) Then
                Return "https://web.archive.org"
            End If
            Return "https://web.archive.org/web/*/" & targetUrl
        End Function

        Public Function BuildArchiveVideoSearch(query As String) As String
            If String.IsNullOrWhiteSpace(query) Then
                Return "https://archive.org/details/movies"
            End If
            Return "https://archive.org/details/movies?query=" & Uri.EscapeDataString(query)
        End Function
    End Module
End Namespace
