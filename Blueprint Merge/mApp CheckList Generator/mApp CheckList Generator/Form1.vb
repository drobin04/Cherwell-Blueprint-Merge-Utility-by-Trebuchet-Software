Imports System.IO
Imports System.Data.SQLite



Public Class Form1

    Public BlueprintPath As String = ""
    Public DefinitionsArray(2000) As CherwellDef
    Public DefCount As Integer = 0
    Public CommandlineTask As String
    Public ResultsPath As String
    Public CurrentBlueprint As String
    Public CurrentBlueprintLastModDate As Date
    Public DefinitionsGenerator As New mApp_CheckList_Generator.Blueprint_Tools
    Public TrebuchetDB As SQLiteDatabase
    Public TrebuchetDBLoaded As Boolean = False
    Public Debugging = True

    Public Sub DebugLog(LogText As String)
        If Debugging = True Then
            System.Diagnostics.Debug.WriteLine(LogText)

        End If
    End Sub

    Public Async Sub BeginProcessing(sender As Object, e As EventArgs) Handles btnBeginProcessing.Click
        System.Diagnostics.Debug.WriteLine("Beginning Blueprint Scan Process.")
        Try
            Await DefinitionsGenerator.CountBlueprintFilesForProgressBar(BlueprintPath)

        Catch
        End Try
        Try
            Await DefinitionsGenerator.GenerateCombinedDefsList(BlueprintPath)

        Catch ex As Exception

        End Try


        txtLog.Text += vbCrLf & "Def Count: " & DefCount

        Try
            'ExportResults()

        Catch ex As Exception

        End Try

        btnCheckmAppProgress.Enabled = True

        txtMessageBox.Text = DefCount & " Defs have been found for your mApp."

    End Sub

    Private Sub btnBrowseForBlueprintDirectory_Click(sender As Object, e As EventArgs) Handles btnBrowseForBlueprintDirectory.Click
        'Prompt user for directory
        BlueprintFolderSelector.ShowDialog()

        'Display selected path in text box
        txtBlueprintPath.Text = BlueprintFolderSelector.SelectedPath
        BlueprintPath = BlueprintFolderSelector.SelectedPath

        btnBeginProcessing.Enabled = True



    End Sub

    Public Function IncrementProgressBar() As Task
        pbBlueprintProgressBar.PerformStep()
        lblBlueprintProgressText.Text = pbBlueprintProgressBar.Value & "/" & pbBlueprintProgressBar.Maximum

    End Function

    Public Sub SetProgressBarBounds(MaxValue As Integer)
        pbBlueprintProgressBar.Maximum = MaxValue
        UpdateProgressBarLabel()


    End Sub

    Public Sub UpdateProgressBarLabel()
        lblBlueprintProgressText.Text = pbBlueprintProgressBar.Value & "/" & pbBlueprintProgressBar.Maximum
    End Sub

    Public Sub CollectCherwellDefs(Definition As CherwellDef)
        If Definition Is Nothing Then
            DebugLog("Def was empty when sent for array")
        End If
        Dim matchfound As Boolean = False

        If DefCount = 0 Then
            DefinitionsArray.SetValue(Definition, 1)
            DefCount += 1
            DebugLog("First Def scanned to list - " & Definition.DefType & " - " & Definition.DefName)
        Else

            For Each TempDef As CherwellDef In DefinitionsArray
                If Not (TempDef Is Nothing) Then

                    If TempDef.DefID = Definition.DefID Then
                        matchfound = True
                        DebugLog("Duplicate found, discarding")
                    End If

                End If

            Next TempDef

        End If

        If matchfound = False Then
            Try
                DefinitionsArray.SetValue(Definition, DefCount)
                Dim Association As String
                Select Case Definition.DefType
                    Case "BusinessObjectDef"
                        Association = GetAssociation(Definition.DefID)
                    Case Else
                        Association = GetAssociation(Definition.Owner)

                End Select
                If Association Is Nothing Or Association = "" Then
                    Association = "None"
                End If

                Dim DefItemsForListView() As String = {Definition.BlueprintName, Definition.DefType, Association, Definition.DefName, Definition.DefAlias, Definition.Scope, Definition.Description, Definition.DefID}
                Dim DefItemListView As New ListViewItem(DefItemsForListView)

                lvDefList.Items.Add(DefItemListView)

            Catch
                DebugLog("Error setting value for new Def.")
            End Try

            DefCount += 1
        End If


    End Sub

    Public Sub WriteLog(LogText As String)
        txtLog.Text += vbCrLf & LogText

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Count As Integer = 1
        For Each Argument As String In Environment.GetCommandLineArgs
            'txtMessageBox.Text += " " & Argument
            Select Case Count
                Case 1

                Case 2
                    'CommandlineTask = Argument

                Case 3
                    'BlueprintPath = Argument
                    'txtBlueprintPath.Text = Argument

                Case 4
                    'ResultsPath = Argument
                    'txtSaveDirectory.Text = Argument
            End Select

            Count += 1
        Next

        'If CommandlineTask = "BlueprintScan" Then
        'CommandLineBeginProcessing()

        'End If

        If IO.File.Exists(My.Resources.TrebuchetDBPath) Then
            TrebuchetDB = New SQLiteDatabase(My.Resources.TrebuchetDBPath)
            TrebuchetDBLoaded = True
            btnLoadDefs.Enabled = False
            btnLoadDefs.Visible = False
            PopulateProjectComboBox()

        Else
            btnLoadDefs.Enabled = True
            btnLoadDefs.Visible = True

        End If


    End Sub

    Public Sub PopulateProjectComboBox()
        Dim dt As New DataTable

        If TrebuchetDBLoaded = True Then
            Try
                'Query for Project Values
                dt = TrebuchetDB.GetDataTable("Select * From mAppProject")

                'Assign values to combobox
                cboxmAppProject.DropDownStyle = ComboBoxStyle.DropDownList
                With cboxmAppProject
                    .DataSource = dt
                    .DisplayMember = "mAppProjectName"
                    .ValueMember = "ID"
                    If cboxmAppProject.Items.Count > 0 Then
                        .SelectedIndex = 0
                    End If

                End With
            Catch ex As Exception

            End Try

        End If



    End Sub


    Private Sub btnBrowseFormApp_Click(sender As Object, e As EventArgs) Handles btnBrowseFormApp.Click
        dlgmAppFileSelector.ShowDialog()
        txtmAppFile.Text = dlgmAppFileSelector.FileName
    End Sub

    Private Async Sub btnCheckmAppProgress_Click(sender As Object, e As EventArgs) Handles btnCheckmAppProgress.Click
        Dim mAppScanner As New Blueprint_Tools

        Try
            Await mAppScanner.ScanmAppForMatchingDefs(txtmAppFile.Text)

        Catch ex As Exception

        End Try


        'txtMessageBox.Text = DefCount & " Defs have been found for your mApp."
    End Sub

    Private Sub tmrBlueprintUpdates_Tick(sender As Object, e As EventArgs) Handles tmrBlueprintUpdates.Tick

        Dim NewBlueprint As String

        NewBlueprint = GetLastBlueprint()

        Dim blueprint As New FileInfo(NewBlueprint)

        'If Last-Blueprint key in registry changes, scan blueprint for defs
        If (Not NewBlueprint Is Nothing) And (NewBlueprint <> CurrentBlueprint Or blueprint.LastWriteTime <> CurrentBlueprintLastModDate) Then

            ScanBlueprintForDefs(blueprint)
            CurrentBlueprint = NewBlueprint
            CurrentBlueprintLastModDate = blueprint.LastWriteTime

        End If



    End Sub

    Public Sub ScanBlueprintForDefs(Blueprint As FileInfo)
        'Dim blueprint As New FileInfo(NewBlueprint)
        Try
            DefinitionsGenerator.ScanBlueprintForDefs(blueprint)
            pbBlueprintProgressBar.Maximum += 1
            pbBlueprintProgressBar.Value += 1
            UpdateProgressBarLabel()

        Catch
        End Try

    End Sub

    Public Function GetLastBlueprint() As String
        Dim LastBlueprint As String = ""

        Try
            LastBlueprint = My.Computer.Registry.GetValue(
    "HKEY_CURRENT_USER\Software\Trebuchet\Blueprints", "LastBlueprint", Nothing)
        Catch ex As Exception

        End Try
        Return LastBlueprint
    End Function

    Private Sub btnStartWorking_Click(sender As Object, e As EventArgs) Handles btnStartWorking.Click
        'Read in current blueprint so we can detect changes
        CurrentBlueprint = GetLastBlueprint()
        Dim blueprint As New FileInfo(CurrentBlueprint)
        CurrentBlueprintLastModDate = blueprint.LastWriteTime

        'Update ProgressBar Max value to correctly count blueprint files
        pbBlueprintProgressBar.Maximum = pbBlueprintProgressBar.Value

        'Start timer so we will begin scanning for changes on an interval
        tmrBlueprintUpdates.Start()
        btnStopWorking.Enabled = True
        btnStartWorking.Enabled = False

    End Sub

    Private Sub btnStopWorking_Click(sender As Object, e As EventArgs) Handles btnStopWorking.Click
        tmrBlueprintUpdates.Stop()
        btnStartWorking.Enabled = True
        btnStopWorking.Enabled = False

    End Sub

    Private Sub btnLoadDefs_Click(sender As Object, e As EventArgs) Handles btnLoadDefs.Click
        Dim BrowseFile As New OpenFileDialog

        BrowseFile.ShowDialog()
        If Not BrowseFile.FileName Is Nothing Then
            TrebuchetDB = New SQLiteDatabase(BrowseFile.FileName)
            TrebuchetDBLoaded = True

        End If

    End Sub

    Public Function GetAssociation(BusObID As String) As String
        'WriteLog("Getting Association For " & BusObID)
        Dim Association As String = ""
        Try
            Association = TrebuchetDB.ExecuteScalar("Select Association From AssociationList Where BusinessObjectID = '" & BusObID & "' ;")
        Catch
        End Try

        Try
            'WriteLog("Association: " & Association)
        Catch
        End Try

        Return Association

    End Function

    Private Sub ShowTrebuchetDBManager(sender As Object, e As EventArgs) Handles Button2.Click
        TrebuchetDBManager.Show()

    End Sub

    Private Sub btnNewProject_Click(sender As Object, e As EventArgs) Handles btnNewProject.Click
        Dim NewProjectName As String = ""

        NewProjectName = InputBox("Please enter the name of the new Project.", "New mApp Project")

        If NewProjectName <> "" Then
            Dim data As Dictionary(Of String, String) = New Dictionary(Of String, String)()
            data.Add("mAppProjectName", NewProjectName)
            'data.Add("Association", txtAssociation.Text)

            TrebuchetDB.Insert("mAppProject", data)
            PopulateProjectComboBox()

        End If

    End Sub

    Private Sub SaveToProject(sender As Object, e As EventArgs) Handles btnSavetoProject.Click
        RemovemAppDetailRecordsAfterLoad()

        For Each mAppDef As ListViewItem In lvDefList.Items
            'Send data to dictionary
            Dim data As Dictionary(Of String, String) = New Dictionary(Of String, String)()
            data.Add("mAppProjectName", cboxmAppProject.Text)
            data.Add("BlueprintName", mAppDef.SubItems(0).Text)
            data.Add("DefType", mAppDef.SubItems(1).Text)
            data.Add("Association", mAppDef.SubItems(2).Text)
            data.Add("DefName", mAppDef.SubItems(3).Text.Replace("'", "''"))
            data.Add("Alias", mAppDef.SubItems(4).Text)
            data.Add("Scope", mAppDef.SubItems(5).Text)
            data.Add("Description", mAppDef.SubItems(6).Text.Replace(vbCr, "").Replace(vbLf, "").Replace("'", "''"))
            data.Add("DefID", mAppDef.SubItems(7).Text)


            Try
                'Send data to SQLite DB
                TrebuchetDB.Insert("mAppProjectDefs", data)
            Catch
            End Try



        Next
    End Sub

    Public Sub LoadmAppDetailsFromProject()

        Dim dt As New DataTable

        If TrebuchetDBLoaded = True Then
            Try
                'Query for Project Values
                dt = TrebuchetDB.GetDataTable("Select BlueprintName, DefType, Association, DefName, Alias, Scope, CAST(Description as varchar(255)) As Description, DefID From mAppProjectDefs Where mAppProjectName = '" & cboxmAppProject.Text & "'")

                'Assign values to Listview
                For Each row As DataRow In dt.Rows

                    lvDefList.Items.Add(row.Item(0))
                    lvDefList.Items(lvDefList.Items.Count - 1).SubItems.Add(row.Item(1))
                    lvDefList.Items(lvDefList.Items.Count - 1).SubItems.Add(row.Item(2))
                    lvDefList.Items(lvDefList.Items.Count - 1).SubItems.Add(row.Item(3))
                    lvDefList.Items(lvDefList.Items.Count - 1).SubItems.Add(row.Item(4))
                    lvDefList.Items(lvDefList.Items.Count - 1).SubItems.Add(row.Item(5))
                    lvDefList.Items(lvDefList.Items.Count - 1).SubItems.Add(row.Item(6))
                    lvDefList.Items(lvDefList.Items.Count - 1).SubItems.Add(row.Item(7))

                    'Dim lst As ListViewItem
                    'lst = lvDefList.Items.Add(If(row(0) IsNot Nothing, row(0).ToString, ""))
                    'For i As Integer = 1 To dt.Columns.Count - 1

                    'lst.SubItems.Add(If(row(i) IsNot Nothing, row(i).ToString, ""))

                    'Next

                    'Dim DefItemsForListView() As String = {Definition.BlueprintName, Definition.DefType, Association, Definition.DefName, Definition.DefAlias, Definition.Scope, Definition.Description, Definition.DefID}
                    'Dim DefItemListView As New ListViewItem(DefItemsForListView)

                    'lvDefList.Items.Add(DefItemListView)


                Next

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If

    End Sub

    Private Sub RemovemAppDetailRecordsAfterLoad()
        Try
            TrebuchetDB.Delete("mAppProjectDefs", "mAppProjectName = '" & cboxmAppProject.Text & "'")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnLoadFromProject_Click(sender As Object, e As EventArgs) Handles btnLoadFromProject.Click
        Try
            LoadmAppDetailsFromProject()
        Catch
        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        lvDefList.Items.Clear()

        Array.Clear(DefinitionsArray, 0, DefinitionsArray.Count)

        DefCount = 0
    End Sub
End Class

