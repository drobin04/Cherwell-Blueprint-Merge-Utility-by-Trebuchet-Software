Imports System.IO
Imports System.Xml

Public Class Blueprint_Tools


    Public Sub WriteLog(LogText As String)
        Form1.txtLog.Text += vbCrLf & LogText
    End Sub

    Public Sub DebugLog(LogText As String)

        Form1.DebugLog(LogText)

    End Sub

    Public Sub ScanBlueprintForDefs(blueprint As FileInfo)
        If blueprint.Extension.ToUpper = ".BP" And Not blueprint.Name.ToUpper.Contains("ROLLBACK") Then

            DebugLog("Preparing to scan Blueprint for Defs, file: " & blueprint.Name)

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
                    Definition.Owner = node("Owner").InnerText
                Catch

                End Try

                Try
                    Form1.CollectCherwellDefs(Definition)
                Catch ex As Exception
                    WriteLog("Error adding Def to list")

                End Try

            Next

        End If


        Form1.IncrementProgressBar()

    End Sub



    Public Function GenerateCombinedDefsList(BlueprintPath As String) As Task



        ' Make a reference to a directory.
        Dim di As New DirectoryInfo(BlueprintPath)
        WriteLog(di.FullName)
        ' Get a reference to each file in that directory.
        Dim fileArray As FileInfo() = di.GetFiles()
        Form1.txtLog.Text += vbCrLf & "File Array Count: " & fileArray.Count
        ' Display the names of the files.
        Dim blueprint As FileInfo

        For Each blueprint In fileArray
            ScanBlueprintForDefs(blueprint)

        Next blueprint


    End Function

    Public Function CountBlueprintFilesForProgressBar(BlueprintPath As String) As Task


        ' Make a reference to a directory.
        Dim di As New DirectoryInfo(BlueprintPath)
        ' Get a reference to each file in that directory.
        Dim fileArray As FileInfo() = di.GetFiles()
        For Each File As FileInfo In fileArray

        Next
        Form1.txtLog.Text += vbCrLf & "File Array Count: " & fileArray.Count
        ' Display the names of the files.
        Dim blueprint As FileInfo
        Dim BlueprintCount As Integer = 0
        For Each blueprint In fileArray
            Try
                If blueprint.Extension.ToUpper = ".BP" And Not blueprint.Name.ToUpper.Contains("ROLLBACK") Then
                    DebugLog("Counting Blueprint " & blueprint.Name)

                    BlueprintCount += 1


                End If
            Catch
                WriteLog("Error evaluating Defs")

            End Try



        Next blueprint

        Form1.SetProgressBarBounds(BlueprintCount)


    End Function



    Public Function ScanmAppForMatchingDefs(mAppFile) As Task

        Dim TrebuchetBlueprint As New XmlDocument()

        TrebuchetBlueprint.Load(mAppFile)
        Dim VersionHolderList As XmlNodeList

        VersionHolderList = TrebuchetBlueprint.GetElementsByTagName("VersionHolder")

        For Each node As XmlElement In VersionHolderList

            For Each Item As ListViewItem In Form1.lvDefList.Items
                If Item.SubItems.Item(7).Text = node.GetAttribute("ID") Then
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
            Catch

            End Try

        Next

        For Each Item As ListViewItem In Form1.lvDefList.Items
            If Item.ImageIndex <> 0 Then
                Item.ImageIndex = 1


            End If

        Next Item


    End Function

End Class
