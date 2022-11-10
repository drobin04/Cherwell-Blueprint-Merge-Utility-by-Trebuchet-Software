Imports System.IO
Imports System.Windows.Forms


Public Module CSMInstallFinderModule

    Public CSMInstallationPath As String = ""

    Public CherwellFileBrowser As New OpenFileDialog


    Public Function GetCSMInstallationPath(SpecificAppFileName As String) As String

        If File.Exists("C:\Program Files (x86)\Cherwell Software\Cherwell Service Management\" & SpecificAppFileName) Then
            CSMInstallationPath = "C:\Program Files (x86)\Cherwell Software\Cherwell Service Management\" & SpecificAppFileName


        ElseIf File.Exists("C:\Program Files (x86)\Cherwell Service Management\" & SpecificAppFileName) Then
            CSMInstallationPath = "C:\Program Files (x86)\Cherwell Service Management\" & SpecificAppFileName

        Else
            MsgBox("Please find and open the installation directory for your Cherwell installation on the next screen; We are trying to find the " & SpecificAppFileName & " file in your installation.")

            CherwellFileBrowser.Filter = SpecificAppFileName & "|" & SpecificAppFileName
            CherwellFileBrowser.InitialDirectory = "C:\Program Files (x86)\"
            CherwellFileBrowser.ShowDialog()

            If CherwellFileBrowser.FileName <> "" Then
                CSMInstallationPath = CherwellFileBrowser.FileName

            Else
                MsgBox("File name not selected or not recognized, please restart the app and try again.")

            End If

        End If

        Return CSMInstallationPath
    End Function

End Module
