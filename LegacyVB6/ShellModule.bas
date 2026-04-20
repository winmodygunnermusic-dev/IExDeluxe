Attribute VB_Name = "ShellModule"
Option Explicit

Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (
    ByVal hwnd As Long,
    ByVal lpOperation As String,
    ByVal lpFile As String,
    ByVal lpParameters As String,
    ByVal lpDirectory As String,
    ByVal nShowCmd As Long) As Long

Public Sub OpenWithDefault(ByVal target As String)
    Call ShellExecute(0, "open", target, vbNullString, vbNullString, 1)
End Sub
