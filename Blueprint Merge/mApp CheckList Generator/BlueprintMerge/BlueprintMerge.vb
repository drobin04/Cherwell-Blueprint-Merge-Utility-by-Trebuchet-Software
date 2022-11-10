Imports Blueprint_Tools.vb
Imports DefEditSoftware.MessageDialogs
Imports CSMConnectionPrompt.Prompt
Imports DefEditSoftware.Extensions
Imports DefEditSoftware.Extensions.DefExtensions

Public Class BlueprintMerge

	Public Property BlueprintToolSet As BlueprintTools
	Public Property ScanByLastModAscending As Boolean = False
	Public Property BlueprintCount As Integer = 0
	Public Property VerboseLogging As Boolean = True

	Private Sub BlueprintMerge_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		BlueprintToolSet = New BlueprintTools(My.Forms.BlueprintMerge, txtLog, pbBlueprintProgressBar, lblBlueprintProgressText, lvBlueprintList)

        'ValidateLicenseKey()


    End Sub

#Region "Original BPMerge Code"



	Private Sub btnBrowseForBlueprintDirectory_Click(sender As Object, e As EventArgs) Handles btnBrowseForBlueprintDirectory.Click
		'Prompt user for directory
		BlueprintFolderSelector.ShowDialog()

		'Display selected path in text box
		txtBlueprintPath.Text = BlueprintFolderSelector.SelectedPath

		'Allow scanning blueprint now that the path has been selected
		btnScanBlueprints.Enabled = True

	End Sub

	Private Sub BtnScanBlueprints_Click(sender As Object, e As EventArgs) Handles btnScanBlueprints.Click
		Try
			BlueprintToolSet.CountBlueprintFilesForProgressBar(txtBlueprintPath.Text, ScanByLastModAscending)
			BlueprintCount = pbBlueprintProgressBar.Maximum

			btnMergeBlueprints.Enabled = True

		Catch Ex As Exception
			MsgBox(Ex.ToString)

		End Try
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

		Try

			btnUp_Click(sender, e)

		Catch ex As Exception

		End Try

	End Sub

	Private Sub btnUp_Click(ByVal sender As Object, ByVal e As EventArgs)
		Try
			If lvBlueprintList.SelectedItems.Count > 0 Then
				Dim selected As ListViewItem = lvBlueprintList.SelectedItems(0)
				Dim indx As Integer = selected.Index
				Dim totl As Integer = lvBlueprintList.Items.Count
				If indx = 0 Then
					lvBlueprintList.Items.Remove(selected)
					lvBlueprintList.Items.Insert(totl - 1, selected)
				Else
					lvBlueprintList.Items.Remove(selected)
					lvBlueprintList.Items.Insert(indx - 1, selected)
				End If
			Else
				MessageBox.Show("You can only move one item at a time. Please select only one item and try again.", "Item Select", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
			End If
		Catch ex As Exception
		End Try
	End Sub

	Private Sub btnDown_Click(ByVal sender As Object, ByVal e As EventArgs)
		Try
			If lvBlueprintList.SelectedItems.Count > 0 Then
				Dim selected As ListViewItem = lvBlueprintList.SelectedItems(0)
				Dim indx As Integer = selected.Index
				Dim totl As Integer = lvBlueprintList.Items.Count
				If indx = totl - 1 Then
					lvBlueprintList.Items.Remove(selected)
					lvBlueprintList.Items.Insert(0, selected)
				Else
					lvBlueprintList.Items.Remove(selected)
					lvBlueprintList.Items.Insert(indx + 1, selected)
				End If
			Else
				MessageBox.Show("You can only move one item at a time. Please select only one item and try again.", "Item Select", MessageBoxButtons.OK, MessageBoxIcon.[Stop])
			End If
		Catch ex As Exception
		End Try
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Try
			btnDown_Click(sender, e)
		Catch ex As Exception

		End Try

	End Sub

	Private Async Sub btnCheckmAppProgress_Click(sender As Object, e As EventArgs) Handles btnMergeBlueprints.Click
		'Re-instance Blueprint ToolSet; so that multiple merge's don't cause duplicate writes to the same file, causing files that are 2x, 3x size as original.
		BlueprintToolSet = New BlueprintTools(My.Forms.BlueprintMerge, txtLog, pbBlueprintProgressBar, lblBlueprintProgressText, lvBlueprintList)

		'Await BlueprintToolSet.GenerateCombinedDefsList(txtBlueprintPath.Text)
		Await BlueprintToolSet.GenerateCombinedDefsList(lvBlueprintList)
		BlueprintToolSet.ExportResults(txtMergeOutput.Text)
		MsgBox("Blueprint Merge has been completed. You should be able to publish your merged blueprint now.")

	End Sub

	Private Sub btnBrowseForOutput_Click(sender As Object, e As EventArgs) Handles btnBrowseForOutput.Click
		dlgResultsSaveDialog.AddExtension = True
		dlgResultsSaveDialog.DefaultExt = "BP"
		dlgResultsSaveDialog.ShowDialog()
		txtMergeOutput.Text = dlgResultsSaveDialog.FileName

	End Sub

	Private Sub btnRemoveBP_Click(sender As Object, e As EventArgs) Handles btnRemoveBP.Click
		For Each Item As ListViewItem In lvBlueprintList.SelectedItems
			lvBlueprintList.Items.Remove(Item)

		Next

	End Sub

	Private Sub ShowDebuggingInfoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ShowDebuggingInfoToolStripMenuItem.Click

		If ShowDebuggingInfoToolStripMenuItem.Checked = True Then
			Me.Size = New Size(878, 556)
			txtLog.Visible = False
			ShowDebuggingInfoToolStripMenuItem.Checked = False

		Else
			Me.Size = New Size(1140, 556)
			txtLog.Visible = True
			ShowDebuggingInfoToolStripMenuItem.Checked = True

		End If





	End Sub

	Private Sub Button3_Click(sender As Object, e As EventArgs)
		For Each Item In lvBlueprintList.SelectedItems
			'Deprecated?
			Console.WriteLine(Item.ToString)

		Next
	End Sub

	Private Sub ScanByLastModAscendingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScanByLastModAscendingToolStripMenuItem.Click

		Select Case ScanByLastModAscending
			Case False
				ScanByLastModAscending = True
				ScanByLastModAscendingToolStripMenuItem.Checked = True

			Case True
				ScanByLastModAscending = False
				ScanByLastModAscendingToolStripMenuItem.Checked = False

		End Select


	End Sub

#End Region

#Region "BPMerge V2 - Direct Publishing Code"

	Public Property EasyPB As New DefEditSoftware.MessageDialogs.EasyProgressBar
	Public Property ConnectionDetails As New CSMConnectionPrompt.Prompt



	Private Async Sub PublishAllBlueprints(sender As Object, e As EventArgs) Handles Button3.Click
		'Get ConnectionInfo
		Try
			ConnectionDetails = New CSMConnectionPrompt.Prompt
			ConnectionDetails.ShowDialog() ' Show prompt for connection info
			CherwellConnectionName = ConnectionDetails.ConnectionName 'Get connection name from prompt



			'Configure easy progress bar with number of blueprints to be published and message to be shown
			EasyPB.ConfigurePB(BlueprintCount, "Current Blueprint Progress Below. Estimated 1 Minute Per Blueprint.")

			If chkIgnoreScanningAll.Checked Then
				EasyPB.AppendToTextLog("You have elected not to scan blueprints.")

			ElseIf IgnoreScanningAllButLast.Checked Then
				EasyPB.AppendToTextLog("You have elected to only scan the last blueprint in the list.")


			End If

			EasyPB.Show() 'Display the progress bar
			EasyPB.Update() 'Render changes to the progress bar - If you don't do this, it won't finish displaying before publishing blueprints and freezing


			If chkPublishRollbacks.Checked Then ' Publish Rollbacks instead

				For i As Integer = lvBlueprintList.Items.Count - 1 To 0 Step -1
					Dim currentlvitem As ListViewItem = lvBlueprintList.Items(i)

					'Get Rollback Filename for blueprint
					If currentlvitem.Text.Contains(".BP") Then
						currentlvitem.Text = currentlvitem.Text.TextBefore(".BP")
					ElseIf currentlvitem.Text.Contains(".bp") Then
						currentlvitem.Text = currentlvitem.Text.TextBefore(".bp")

					End If

					currentlvitem.Text = currentlvitem.Text & "_rollback.bp"
					If IO.File.Exists(currentlvitem.Text) Then
						Await PublishLVIBPAsync(currentlvitem)
					Else
						EasyPB.AppendToTextLog("ERROR: Could Not Locate Rollback File... " & currentlvitem.Text)
					End If



				Next i

			Else ' Publish Blueprints In Normal Order
				For i As Integer = 0 To lvBlueprintList.Items.Count - 1 Step 1
					Dim currentlvitem As ListViewItem = lvBlueprintList.Items(i)

					Await PublishLVIBPAsync(currentlvitem)


				Next i

			End If

			'Commented this section out to try publishing in reverse.... see https://stackoverflow.com/questions/952136/is-it-possible-to-do-a-for-each-loop-backwards
			'For Each lvi As ListViewItem In lvBlueprintList.Items 'Step thru each blueprint in the list to publish
			'Await PublishLVIBPAsync(lvi)

			'Next
		Catch ex As Exception
			MsgBox(ex.ToString)
		End Try


	End Sub

	Public Async Function PublishLVIBPAsync(lvi As ListViewItem) As Task
		If ErrorFound = False Then

			Try
				EasyPB.AppendToTextLog(Date.Now & " - Publishing Blueprint '" & lvi.Text & "'")

				Await PublishBlueprintGetResults(lvi.Text)
				If EasyPB.PBCurrentValue <= EasyPB.PBMax Then EasyPB.PBCurrentValue += 1
				EasyPB.UpdateProgressBar()

			Catch

			End Try
		End If



	End Function

	Public AllPublishesComplete As Boolean = False
	Public ErrorFound As Boolean = False
	Public CherwellConnectionName As String = ""

	Public Sub InitialCherwellInstallPathConfig()

		If Not IO.File.Exists("CSMInstallPath") Then
			Dim cherwellpath As New DefEditSoftware.EasyConfigFile.ConfigurationFile("CSMInstallPath")
			cherwellpath.AddSetting("CherwellPath", "C:\Program Files (x86)\Cherwell Software\Cherwell Service Management\")
			cherwellpath.ExportSettingsToFile()

		End If

	End Sub

	Public Async Function PublishBlueprintGetResults(BlueprintPath As String) As Task(Of String)
		Dim Results As String = ""

		Dim CherwellFinder As New DefEditSoftware.CSMInstallationFinder.CSMInstallationFinder

		If Not IO.File.Exists("CSMInstallPath") Then
			InitialCherwellInstallPathConfig()

		End If

		Dim CherwellInstallLocation As New DefEditSoftware.EasyConfigFile.ConfigurationFile("CSMInstallPath")
		CherwellInstallLocation.ReadSettingsFromFile()

		Dim CherwellPath As String = ""
		CherwellPath = CherwellInstallLocation.GetSettingValueByName("CherwellPath") & "Trebuchet.CommandLineConfigure.exe"




		If Not IO.File.Exists(CherwellPath & "Trebuchet.CommandLineConfigure.exe") Then
			My.Settings.CherwellInstallPath = CherwellFinder.GetCSMInstallationPath("Trebuchet.CommandLineConfigure.exe")
			My.Settings.Save()

		End If

		Dim ConnectionName As String = CherwellConnectionName
		Dim ConnectionUserID As String = ConnectionDetails.Username
		Dim ConnectionPassword As String = ConnectionDetails.Password

		'Ignore Scanning based on conditions
		Dim IgnoreScan As String = ""
		If chkIgnoreScanningAll.Checked Or (IgnoreScanningAllButLast.Checked And lvBlueprintList.Items.GetLastItemsText <> BlueprintPath) Then
			IgnoreScan = "/scanblueprint=False"
		End If

		Dim RollbackCommandAppendText As String = ""
		If chkPublishRollbacks.Checked Then
			RollbackCommandAppendText = "/createrollback=False"
		End If

		'Run trebuchetcommandlineconfigure app with selected blueprint

		Dim Commandlineargs As String = " /publish /blueprint=""" _
					  & BlueprintPath & """ /connection=""" & ConnectionName & """ /connectionuserid=""" _
					  & ConnectionUserID & """ /connectionpassword=""" & ConnectionPassword & """ " & IgnoreScan

		'Process.Start(CSMInstallationPath & "Trebuchet.CommandlineConfigure.exe")


		Dim CurrentEventLog As String = ""
		Try

			Dim BPPublishLog As Process = New Process()
			BPPublishLog.StartInfo.FileName = CherwellPath
			BPPublishLog.StartInfo.Arguments = Commandlineargs
			BPPublishLog.StartInfo.UseShellExecute = False
			BPPublishLog.StartInfo.RedirectStandardOutput = True
			'Show console if user checks box to show console - to allow closing manually and cancelling; as this app freezes when running
			If chkShowConsole.Checked = False Then BPPublishLog.StartInfo.CreateNoWindow = True
			BPPublishLog.Start()
			CurrentEventLog = BPPublishLog.StandardOutput.ReadToEnd()
			BPPublishLog.WaitForExit()

			'Add results to the Progress Bar's text log!

			If VerboseLogging = True Then
				EasyPB.AppendToTextLog(CurrentEventLog)

			End If


			Dim PublishComplete As Boolean = False

			For Each Line As String In CurrentEventLog.Split(Environment.NewLine)
				'MsgBox(Line)


				If PublishComplete = False And ErrorFound <> True Then

					If Line.StartsWith("ERROR:") Then
						ErrorFound = True
						EasyPB.AppendToTextLog(Line)
					End If

					If Line.Contains("Publish Blueprint: Complete") Then
						PublishComplete = True
						EasyPB.AppendToTextLog("Publish Complete.")
					End If
				End If


			Next

			If PublishComplete = False Then
				ErrorFound = True
				EasyPB.AppendToTextLog("Publish did not complete, cancelling the rest of the publishes." &
									   vbCrLf & "NOTE: YOU WILL NEED TO MANUALLY ROLLBACK ANY ITEMS ALREADY PUBLISHED.")


			End If




		Catch ex As Exception

			Dim msg As New DefEditSoftware.MessageDialogs.TextBoxMessage(CurrentEventLog & vbCrLf & ex.ToString & vbCrLf & "Cherwell Path: " & CherwellPath)
			msg.Show()

			'MsgBox(ex.ToString)

		End Try

		Return Results

	End Function

	Private Sub Button4_Click(sender As Object, e As EventArgs)
		MsgBox(lvBlueprintList.Items.GetLastItemsText)

	End Sub

#End Region

    Public Sub ValidateLicenseKey()

        'Check If License Key File Exists
        If Not IO.File.Exists(Environment.CurrentDirectory & "\LicenseKey.deslic") Then
            Dim msg As New TextBoxMessage("License key could not be found;" &
                    vbCrLf & "Please copy license key to the following location:" &
                   vbCrLf & Environment.CurrentDirectory & "\LicenseKey.deslic", "License Key Could Not Be Found")
            msg.ShowDialog()
            Me.Close()

        End If


        'Check If License Key File Is Valid
        Dim LicenseFile As New DefEditSoftware.EasyConfigFile.ConfigurationFile("LicenseKey.deslic", "DES_Easy_Encrypt!onPa$$word")
        'Decrypt License File and read settings
        LicenseFile.ReadEncryptedFileSettings(Environment.CurrentDirectory & "\LicenseKey.deslic")

        'Read Expiration Date
        Dim ExpDate As Date
        ExpDate = LicenseFile.GetSettingValueByName("ExpirationDate")

        Dim CompanyName As String = ""
        CompanyName = LicenseFile.GetSettingValueByName("CompanyName")

        Dim ProductName As String = ""
        ProductName = LicenseFile.GetSettingValueByName("ProductName")

        If ExpDate < Date.Now() Then
            Dim msg As New DefEditSoftware.MessageDialogs.TextBoxMessage(
            "The license key for this software has expired. Please acquire and install a new license key." _
            & vbCrLf & "Product Name: " & ProductName _
            & vbCrLf & "Expiration Date: " & ExpDate, "License Key Invalid")
            msg.ShowDialog()

            Me.Close()

        ElseIf ProductName <> "Blueprint Merge" Then
            Dim msg As New DefEditSoftware.MessageDialogs.TextBoxMessage(
                "The License Key installed in this application directory is not meant for this application - Please acquire and install the appropriate license for this product." _
                 & vbCrLf & "Product Name: " & ProductName)
            msg.ShowDialog()
            Me.Close()


        Else 'License Key Is Valid
            Me.Text += " - Licensed To " & CompanyName


        End If
        'MsgBox(ExpDate)
        lblLicenseInfo.Text = "Licensed To " & CompanyName & " until " & ExpDate.ToShortDateString

    End Sub
End Class
