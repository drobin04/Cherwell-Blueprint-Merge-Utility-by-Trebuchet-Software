Imports CSMConnectionPrompt

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Prompt As New CSMConnectionPrompt.Prompt
        Prompt.ShowDialog()
        MsgBox(Prompt.ConnectionName)

    End Sub
End Class
