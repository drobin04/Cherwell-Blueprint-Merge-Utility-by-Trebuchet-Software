Imports System.IO
Imports Blueprint_Tools.vb

Public Class BlueprintInspector

    Public Property BlueprintToolSet As BlueprintTools

    Private Sub BlueprintInspector_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BlueprintToolSet = New BlueprintTools(txtLog)

    End Sub

    Private Sub btnBrowseForBlueprintDirectory_Click(sender As Object, e As EventArgs) Handles btnBrowseForBlueprintDirectory.Click
        ofdFileSelector.DefaultExt = "BP"
        ofdFileSelector.ShowDialog()

        txtBlueprintPath.Text = ofdFileSelector.FileName

        btnScanBlueprints.Enabled = True

    End Sub

    Private Sub btnScanBlueprints_Click(sender As Object, e As EventArgs) Handles btnScanBlueprints.Click

        Dim blueprint As New FileInfo(txtBlueprintPath.Text)

        Dim DefsList(2000) As CherwellDef

        DefsList = BlueprintToolSet.ScanBlueprintForDefs(blueprint)
        BlueprintToolSet.WriteLog("Blueprint Scan Completed.")
        Dim Association As String = ""

        For Each Definition As CherwellDef In DefsList
            If Not Definition Is Nothing Then
                Dim DefItemsForListView() As String = {Definition.DefType, Definition.Association, Definition.DefName, Definition.DefAlias, Definition.Scope, Definition.Description, Definition.DefID, Definition.View}
                Dim DefItemListView As New ListViewItem(DefItemsForListView)

                lvDefList.Items.Add(DefItemListView)

            End If

        Next

    End Sub
End Class
