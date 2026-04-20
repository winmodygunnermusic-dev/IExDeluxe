Imports System
Imports System.Windows.Forms

Namespace IExDeluxe
    Friend Module Program
        <STAThread>
        Friend Sub Main()
            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())
        End Sub
    End Module
End Namespace
