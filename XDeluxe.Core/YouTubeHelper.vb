Imports System

Namespace XDeluxe.Core
    Public Module YouTubeHelper
        Public Function BuildWatchOrSearch(input As String) As String
            If String.IsNullOrWhiteSpace(input) Then Return "https://www.youtube.com"
            If input.StartsWith("http", StringComparison.OrdinalIgnoreCase) Then Return input
            Return "https://www.youtube.com/results?search_query=" & Uri.EscapeDataString(input)
        End Function
    End Module
End Namespace
