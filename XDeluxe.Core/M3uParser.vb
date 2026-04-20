Imports System
Imports System.Collections.Generic

Namespace XDeluxe.Core
    Public Module M3uParser
        Public Function Parse(content As String) As IList(Of String)
            Dim channels As New List(Of String)()
            If String.IsNullOrWhiteSpace(content) Then Return channels

            For Each rawLine In content.Split({ControlChars.Cr, ControlChars.Lf}, StringSplitOptions.RemoveEmptyEntries)
                Dim line = rawLine.Trim()
                If line.Length = 0 OrElse line.StartsWith("#", StringComparison.Ordinal) Then Continue For
                channels.Add(line)
            Next

            Return channels
        End Function
    End Module
End Namespace
