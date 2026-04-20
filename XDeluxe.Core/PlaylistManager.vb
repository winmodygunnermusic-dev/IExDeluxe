Imports System.Collections.Generic

Namespace XDeluxe.Core
    Public Class PlaylistManager
        Public Property Items As IList(Of String)

        Public Sub New()
            Items = New List(Of String)()
        End Sub

        Public Sub LoadFromM3u(content As String)
            Items = M3uParser.Parse(content)
        End Sub
    End Class
End Namespace
