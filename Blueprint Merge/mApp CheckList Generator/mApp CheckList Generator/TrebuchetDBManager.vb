Public Class TrebuchetDBManager

    Public Property ThisDB As SQLiteDatabase

    Private Sub TrebuchetDBManager_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ThisDB = Form1.TrebuchetDB

        PopulateDataTable(ThisDB)



    End Sub


    Public Sub PopulateDataTable(TrebuchetDB As SQLiteDatabase)
        Try

            Dim recipe As DataTable
            Dim query As String = "select RecID, BusinessObjectID, Association From Associationlist"
            recipe = TrebuchetDB.GetDataTable(query)
            DataGridView1.DataSource = recipe
        Catch fail As Exception
            Dim [error] As String = "The following error has occurred:" & vbLf & vbLf
            [error] += fail.Message.ToString() & vbLf & vbLf
            MessageBox.Show([error])
            Me.Close()
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Dim data As Dictionary(Of String, String) = New Dictionary(Of String, String)()
        data.Add("BusinessObjectID", txtBusObID.Text)
        data.Add("Association", txtAssociation.Text)

        Try
            ThisDB.Insert("AssociationList", data)
            PopulateDataTable(ThisDB)

        Catch crap As Exception
            MessageBox.Show(crap.Message)
        End Try


    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        For Each Cell As DataGridViewCell In DataGridView1.SelectedCells
            Dim RowIndex As Integer
            RowIndex = Cell.RowIndex
            Dim BusObID As String = ""

            BusObID = DataGridView1.Rows.Item(RowIndex).Cells(1).Value.ToString


            'Next

            'For Each Row As DataGridViewRow In DataGridView1.SelectedCells


            'BusObID = Row.Cells(1).Value.ToString

            ThisDB.Delete("AssociationList", "BusinessObjectID = '" & BusObID & "'")


        Next

        PopulateDataTable(ThisDB)

    End Sub
End Class