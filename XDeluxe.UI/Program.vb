Imports System
Imports System.Windows.Forms
Imports CefSharp

Namespace XDeluxe.UI
    Friend Module Program
        <STAThread>
        Friend Sub Main()
            Dim settings As New CefSettings()
            settings.CachePath = IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XDeluxe", "cef-cache")
            Cef.Initialize(settings, performDependencyCheck:=False, browserProcessHandler:=Nothing)

            Application.EnableVisualStyles()
            Application.SetCompatibleTextRenderingDefault(False)
            Application.Run(New MainForm())

            Cef.Shutdown()
        End Sub
    End Module
End Namespace
