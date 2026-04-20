VERSION 5.00
Begin VB.Form MainLegacy
   Caption         =   "XDeluxe Legacy Launcher"
   ClientHeight    =   4200
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   7200
   LinkTopic       =   "Form1"
   ScaleHeight     =   4200
   ScaleWidth      =   7200
   StartUpPosition =   2  'CenterScreen
   Begin VB.CommandButton cmdOpen
      Caption         =   "Open Selected"
      Height          =   375
      Left            =   5640
      TabIndex        =   2
      Top             =   360
      Width           =   1335
   End
   Begin VB.FileListBox lstFiles
      Height          =   3120
      Left            =   240
      Pattern         =   "*.mp4;*.avi;*.mp3;*.m3u;*.swf"
      TabIndex        =   1
      Top             =   840
      Width           =   6735
   End
   Begin VB.DirListBox lstDirs
      Height          =   990
      Left            =   240
      TabIndex        =   0
      Top             =   360
      Width           =   5295
   End
End
Attribute VB_Name = "MainLegacy"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub cmdOpen_Click()
    If lstFiles.FileName <> "" Then
        OpenWithDefault lstFiles.Path & "\" & lstFiles.FileName
    End If
End Sub

Private Sub lstDirs_Change()
    lstFiles.Path = lstDirs.Path
End Sub
