Imports System.IO
Imports System.Windows.Forms
Imports System.Xml

Public Class BlueprintTools




    Public Sub New(ByRef frm As Form, ByRef txtBox As TextBox, ByRef PGBar As ProgressBar, ByRef ProgressLabel As Label, ByRef ListViewControl As ListView)
        Form1 = frm
        MessageBox = txtBox
        PBar = PGBar
        lblBlueprintProgressText = ProgressLabel
        lvListView = ListViewControl


        MessageBox.Text += "Blueprint Tools Loaded Successfully."


    End Sub

    Public Sub New(ByRef txt As TextBox)
        MessageBox = txt
    End Sub

    Public Sub New()

    End Sub

    Public Property Form1 As Form
    Public Property MessageBox As TextBox

    Public Property PBar As ProgressBar
    Public Property lblBlueprintProgressText As Label

    Public Property lvListView As ListView
    Public Property MessageConsole As String

    Public DefinitionsArray(2000) As CherwellDef
    Public DefCount As Integer = 1
    Public SQLDBPath As String = "Def-EditSoftware.TrebuchetData.s3db"

    Private SQLDB As SQLiteDatabase

    Public Function GetLastBlueprint() As String
        Dim LastBlueprint As String = ""

        Try
            LastBlueprint = My.Computer.Registry.GetValue(
    "HKEY_CURRENT_USER\Software\Trebuchet\Blueprints", "LastBlueprint", Nothing)
        Catch ex As Exception

        End Try
        Return LastBlueprint
    End Function

    Public Sub AddBlueprintToListView(blueprintname As String, LastModDateTime As String)


        Try

            Dim Blueprints() As String = {blueprintname, LastModDateTime}
            Dim DefItemListView As New ListViewItem(Blueprints)
            Dim matchfound As Boolean = False


            Try
                Dim FoundExistingItem As ListViewItem
                If lvListView.Items.Count <> 0 Then
                    FoundExistingItem = lvListView.FindItemWithText(blueprintname, False, 0, False)
                End If
                If Not FoundExistingItem Is Nothing Then
                    matchfound = True

                End If
            Catch ex As Exception
                WriteLog("Error occurred when checking for duplicate blueprints on """ & blueprintname)
            End Try

            If lvListView Is Nothing Then
                WriteLog("ListView Item 'Is Nothing'.")
            ElseIf matchfound = True Then
                WriteLog("Blueprint """ & blueprintname & """ was scanned previously and is not being re-added to list.")

            Else

                lvListView.Items.Add(DefItemListView)
            End If


        Catch

        End Try


    End Sub

    Public Sub WriteLog(LogText As String)

        If Not MessageBox Is Nothing Then
            MessageBox.Text += vbCrLf & LogText
        Else
            Console.WriteLine(LogText)

        End If

        MessageConsole += vbCrLf & LogText

    End Sub

    Public Sub IncrementProgressBar()
        PBar.PerformStep()
        lblBlueprintProgressText.Text = PBar.Value & "/" & PBar.Maximum

    End Sub
    Public Sub SetProgressBarBounds(MaxValue As Integer)
        PBar.Maximum = MaxValue
        lblBlueprintProgressText.Text = PBar.Value & "/" & PBar.Maximum

    End Sub


    Public Sub CollectCherwellDefs(Definition As CherwellDef)
        If Definition Is Nothing Then
            WriteLog("Def was empty when sent for array")
        End If
        Dim matchfound As Boolean = False

        Dim TempDefCount As Integer = 0
        Dim TempDefCountMatch As Integer

        If DefCount = 0 Then
            DefinitionsArray.SetValue(Definition, 1)
            DefCount += 1
            WriteLog("Writing First Definition - " & Definition.DefType & " - " & Definition.DefName)
            TempDefCount += 1

        Else

            For Each TempDef As CherwellDef In DefinitionsArray
                If Not (TempDef Is Nothing) Then


                    If TempDef.DefID = Definition.DefID And TempDef.View = Definition.View Then

                        matchfound = True
                        TempDefCountMatch = TempDefCount
                        'MsgBox(TempDefCount)
                    End If

                End If
                TempDefCount += 1
            Next TempDef

            If matchfound = False Then
                Try
                    DefinitionsArray.SetValue(Definition, DefCount)

                Catch

                End Try

                WriteLog("Writing Definition" & DefCount & " - " & Definition.DefType & " - " & Definition.DefName & " - " & Definition.DefID & " - " & Definition.View)

                DefCount += 1

            End If

            If matchfound = True Then
                Try
                    DefinitionsArray.SetValue(Definition, TempDefCountMatch)

                Catch

                End Try

                WriteLog("Updating Definition" & TempDefCountMatch & " - " & Definition.DefType & " - " & Definition.DefName & " - " & Definition.DefID & " - " & Definition.View)

                'DefCount += 1


            End If

        End If

        'DefCount += 1
        'lboxBlueprintList.Items.Add(Definition.DefName)


    End Sub

    Public Sub CountBlueprintFilesForProgressBar(BlueprintPath As String, Optional ScanByLastMod As Boolean = False)

        ' Make a reference to a directory.
        Dim di As New DirectoryInfo(BlueprintPath)
        ' Get a reference to each file in that directory.
        Dim fileArray As FileInfo()
        Select Case ScanByLastMod ' If chosen to scan by last mod date time in ascending order, then scan that way. 
            Case False
                fileArray = di.GetFiles()

            Case True
                fileArray = di.GetFiles().OrderBy(Function(f As FileInfo) f.CreationTime).ToArray()
        End Select
        WriteLog("File Array Count: " & fileArray.Count)
        ' Display the names of the files.
        Dim blueprint As FileInfo
        Dim BlueprintCount As Integer = 0
        For Each blueprint In fileArray
            Try
                If blueprint.Extension.ToUpper = ".BP" And Not blueprint.Name.ToUpper.Contains("ROLLBACK") Then


                    BlueprintCount += 1

                    AddBlueprintToListView(blueprint.FullName, blueprint.LastWriteTime)

                End If
            Catch
                WriteLog("Error evaluating Defs")

            End Try



        Next blueprint

        SetProgressBarBounds(BlueprintCount)


    End Sub

    Public Function ScanBlueprintForDefs(blueprint As FileInfo) As CherwellDef()
        Dim DefsList(2000) As CherwellDef

        Try

            If blueprint.Extension.ToUpper = ".BP" And Not blueprint.Name.ToUpper.Contains("ROLLBACK") Then

                'DebugLog("Preparing to scan Blueprint for Defs, file: " & blueprint.Name)


                Dim CurrentDef As Integer = 0
                Dim TrebuchetBlueprint As New XmlDocument()
                WriteLog(blueprint.FullName)
                TrebuchetBlueprint.Load(blueprint.FullName)
                Dim VersionHolderList As XmlNodeList

                VersionHolderList = TrebuchetBlueprint.GetElementsByTagName("VersionHolder")

                For Each node As XmlElement In VersionHolderList
                    'WriteLog(node.GetAttribute("ID"))
                    Dim Definition As New CherwellDef
                    Definition.DefID = node.GetAttribute("ID")
                    Definition.DefName = node.GetAttribute("Name")
                    Definition.DefType = node.GetAttribute("DefType")
                    Definition.Scope = node.GetAttribute("Scope")
                    Definition.ScopeOwner = node.GetAttribute("ScopeOwner")
                    Definition.Description = node("Description").InnerText
                    'Definition.BlueprintName = blueprint.Name
                    Definition.DefAlias = node("Alias").InnerText
                    Try
                        Definition.Owner = node("Owner").InnerText
                        Definition.View = node.GetAttribute("View")
                        Definition.Definition = node.InnerText
                    Catch

                    End Try

                    Try
                        Definition.View = node.GetAttribute("View")
                    Catch ex As Exception

                    End Try

                    Try
                        DefsList(CurrentDef) = Definition
                        CurrentDef += 1

                    Catch ex As Exception
                        WriteLog("Error adding Def to list")

                    End Try

                Next

            End If

        Catch
            WriteLog("Error evaluating Defs")

        End Try
        Return DefsList
    End Function


    Public Async Function GenerateCombinedDefsList(BlueprintPath As String) As Task



        ' Make a reference to a directory.
        Dim di As New DirectoryInfo(BlueprintPath)
        'WriteLog(di.FullName)
        ' Get a reference to each file in that directory.
        Dim fileArray As FileInfo() = di.GetFiles()
        WriteLog("File Array Count: " & fileArray.Count)
        ' Display the names of the files.
        Dim blueprint As FileInfo
        Dim Count As Integer = 1

        For Each blueprint In fileArray

            If blueprint.Extension.ToUpper = ".BP" And Not blueprint.Name.ToUpper.Contains("ROLLBACK") Then

                Dim TrebuchetBlueprint As New XmlDocument()
                WriteLog(blueprint.FullName)
                TrebuchetBlueprint.Load(blueprint.FullName)
                Dim VersionHolderList As XmlNodeList

                VersionHolderList = TrebuchetBlueprint.GetElementsByTagName("VersionHolder")

                For Each node As XmlElement In VersionHolderList
                    'WriteLog(node.GetAttribute("ID"))
                    Dim Definition As New CherwellDef
                    Definition.DefID = node.GetAttribute("ID")
                    Definition.DefName = node.GetAttribute("Name")
                    Definition.DefType = node.GetAttribute("DefType")
                    Definition.Scope = node.GetAttribute("Scope")
                    Definition.ScopeOwner = node.GetAttribute("ScopeOwner")
                    Definition.Description = node("Description").InnerText
                    Definition.BlueprintName = blueprint.Name
                    Definition.DefAlias = node("Alias").InnerText
                    Try

                        If node("Owner") Is Nothing Then
                            Definition.Owner = ""
                        Else

                            Definition.Owner = node("Owner").InnerText
                        End If


                        If node.GetAttribute("View") Is Nothing Then
                            Definition.View = "Nothing"
                        Else
                            Definition.View = node.GetAttribute("View")
                        End If

                        Definition.XMLDefinition = XmlElementToXelement(node)
                        If Count = 1 Then
                            'MsgBox(node.InnerXml)
                            Count += 1


                        End If


                    Catch

                    End Try

                    Try
                        CollectCherwellDefs(Definition)
                    Catch ex As Exception
                        WriteLog("Error adding Def to list")

                    End Try

                Next

            End If

            Try
                IncrementProgressBar()
            Catch
            End Try

        Next blueprint


    End Function

    Public Async Function GenerateCombinedDefsList(BlueprintList As ListView) As Task


        Try
            Dim currentblueprint As ListViewItem
            'BlueprintList.Items
            Dim Count As Integer = 1

            For Each currentblueprint In BlueprintList.Items

                Dim blueprint As New FileInfo(currentblueprint.Text)

                WriteLog("Opening Blueprint " & blueprint.FullName)


                If blueprint.Extension.ToUpper = ".BP" And Not blueprint.Name.ToUpper.Contains("ROLLBACK") Then

                    Dim TrebuchetBlueprint As New XmlDocument()
                    WriteLog(blueprint.FullName)
                    TrebuchetBlueprint.Load(blueprint.FullName)
                    Dim VersionHolderList As XmlNodeList

                    VersionHolderList = TrebuchetBlueprint.GetElementsByTagName("VersionHolder")

                    For Each node As XmlElement In VersionHolderList
                        'WriteLog(node.GetAttribute("ID"))
                        Dim Definition As New CherwellDef
                        Definition.DefID = node.GetAttribute("ID")
                        Definition.DefName = node.GetAttribute("Name")
                        Definition.DefType = node.GetAttribute("DefType")
                        Definition.Scope = node.GetAttribute("Scope")
                        Definition.ScopeOwner = node.GetAttribute("ScopeOwner")
                        Try
                            If node("Description") Is Nothing Then

                                Definition.Description = ""
                            Else
                                Definition.Description = node("Description").InnerText
                            End If
                            
                        Catch ex As Exception
                            WriteLog("Error setting description node for Definition. " & vbCrLf & ex.ToString())

                        End Try

                        Definition.BlueprintName = blueprint.Name
                        Definition.DefAlias = node("Alias").InnerText
                        Try

                            If node("Owner") Is Nothing Then
                                Definition.Owner = ""
                            Else

                                Definition.Owner = node("Owner").InnerText
                            End If


                            If node.GetAttribute("View") Is Nothing Then
                                Definition.View = "Nothing"
                            Else
                                Definition.View = node.GetAttribute("View")
                            End If

                            Definition.XMLDefinition = XmlElementToXelement(node)
                            If Count = 1 Then
                                'MsgBox(node.InnerXml)
                                Count += 1


                            End If


                        Catch

                        End Try

                        Try
                            CollectCherwellDefs(Definition)
                        Catch ex As Exception
                            WriteLog("Error adding Def to list")

                        End Try

                    Next

                End If

                Try
                    IncrementProgressBar()
                Catch
                End Try

            Next currentblueprint

        Catch ex As Exception
            WriteLog("Error caught while combining blueprints: " & ex.ToString())
        End Try

    End Function

    Public Function XmlElementToXelement(ByVal e As XmlElement) As XElement
        Return XElement.Parse(e.OuterXml)
    End Function

    Public Sub ExportResults(ExportPath As String)

        Dim header As String = "<TrebuchetBlueprint ID=""" & Guid.NewGuid().ToString("N") & """" & " Version=""1"" WhenWritten=""" & DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss") & """ ></TrebuchetBlueprint>"

        Dim doc As XDocument = XDocument.Parse(header)
        Dim root As XElement = doc.Root
        Dim VersionHolderList As XElement = New XElement("VersionHolderList")
        Dim Count = 0


        For Each TempDef As CherwellDef In DefinitionsArray
            If Not (TempDef Is Nothing) Then
                Dim NewDefinition As XElement = TempDef.XMLDefinition
                'Dim NewDefinition As XElement = New XElement("VersionHolder", TempDef.Definition)

                'With NewDefinition
                '.SetAttributeValue("DefType", TempDef.DefType)
                '.SetAttributeValue("ID", TempDef.DefID)
                '.SetAttributeValue("Name", TempDef.DefName)
                '.SetAttributeValue("SubType", TempDef.SubType)
                '.SetAttributeValue("Culture", TempDef.Culture)
                '.SetAttributeValue("View", TempDef.View)



                'End With

                'VersionHolderList.Add(NewDefinition)
                WriteLog("Exporting Definition" & Count & " - " & TempDef.DefType & " - " & TempDef.DefName)
                VersionHolderList.Add(NewDefinition)


            End If
            Count += 1
        Next TempDef

        root.Add(VersionHolderList)


        Dim xws As XmlWriterSettings = New XmlWriterSettings
        xws.OmitXmlDeclaration = True
        Dim xw As XmlWriter = XmlWriter.Create(ExportPath, xws)
        Using (xw)
            doc.Save(xw)
        End Using


    End Sub


    Public Function ScanmAppForMatchingDefs(mAppFile) As Task

        Dim TrebuchetBlueprint As New XmlDocument()

        TrebuchetBlueprint.Load(mAppFile)
        Dim VersionHolderList As XmlNodeList

        VersionHolderList = TrebuchetBlueprint.GetElementsByTagName("VersionHolder")

        For Each node As XmlElement In VersionHolderList

            For Each Item As ListViewItem In lvListView.Items
                If Item.SubItems.Item(6).Text = node.GetAttribute("ID") Then
                    Item.ImageIndex = 0


                End If

            Next Item


            'WriteLog(node.GetAttribute("ID"))
            Dim Definition As New CherwellDef
            Definition.DefID = node.GetAttribute("ID")
            Definition.DefName = node.GetAttribute("Name")
            Definition.DefType = node.GetAttribute("DefType")
            Definition.Scope = node.GetAttribute("Scope")
            Definition.ScopeOwner = node.GetAttribute("ScopeOwner")
            Definition.Description = node("Description").InnerText
            'Definition.BlueprintName = blueprint.Name
            Definition.DefAlias = node("Alias").InnerText
            Try
                Definition.Owner = node("Owner").InnerText
                Definition.View = node.GetAttribute("View")
                Definition.Definition = node.InnerText
            Catch

            End Try

            Try
                Definition.View = node.GetAttribute("View")
            Catch ex As Exception

            End Try

        Next

        For Each Item As ListViewItem In lvListView.Items
            If Item.ImageIndex <> 0 Then
                Item.ImageIndex = 1


            End If

        Next Item


    End Function

    Public Sub ConnectToSQLDB()
        SQLDB = New SQLiteDatabase

        If IO.File.Exists(SQLDBPath) Then
            SQLDB = New SQLiteDatabase(SQLDBPath)

        End If

    End Sub

    Public Function GetAssociationFromSQLDB(Owner As String) As String
        Dim Association As String = ""
        If IO.File.Exists(SQLDBPath) Then


            ConnectToSQLDB()

            Try
                Association = SQLDB.ExecuteScalar("Select Association From AssociationList Where BusinessObjectID = '" & Owner & "' ;")
            Catch ex As Exception
                WriteLog(ex.ToString)
            End Try

        End If
        Return Association
    End Function

End Class
