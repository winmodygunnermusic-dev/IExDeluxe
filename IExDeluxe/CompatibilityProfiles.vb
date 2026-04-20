Imports System
Namespace IExDeluxe
    Friend Module CompatibilityProfiles
        Private ReadOnly _supportedProfiles As String() = {
            "windows-98", "windows-2000", "windows-me", "windows-xp", "windows-longhorn", "windows-vista",
            "windows-7", "windows-8", "windows-8.1", "windows-10",
            "beta-me", "beta-whistler", "beta-wishter", "beta-xp", "beta-longhorn", "beta-vista", "beta-7", "beta-8", "beta-8.1", "beta-10"
        }

        Friend Function GetSupportedProfiles() As String()
            Return _supportedProfiles
        End Function

        Friend Function IsKnownProfile(name As String) As Boolean
            If String.IsNullOrEmpty(name) Then Return False

            For Each profile In _supportedProfiles
                If String.Compare(profile, name.Trim(), StringComparison.OrdinalIgnoreCase) = 0 Then
                    Return True
                End If
            Next

            Return False
        End Function
    End Module
End Namespace
