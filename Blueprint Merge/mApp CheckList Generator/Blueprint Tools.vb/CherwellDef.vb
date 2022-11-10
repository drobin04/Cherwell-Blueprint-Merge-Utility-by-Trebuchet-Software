Public Class CherwellDef
    Public Property DefID As String

    Public Property DefName As String

    Public Property DefType As String

    Public Property DefAlias As String

    Public Property Scope As String

    Public Property ScopeOwner As String

    Public Property Description As String

    Public Property BlueprintName As String

    Public Property Owner As String
    Public Property View As String
        Set(value As String)
            prvView = value

        End Set
        Get
            If prvView = "" Then
                Return "Default"

            Else
                Return prvView

            End If
        End Get
    End Property
    Private Property prvView As String

    Public Property Definition As String

    Public Property XMLDefinition As XElement

    Public Property SubType As String

    Public Property Culture As String

    Private Property prvAssociation As String

    Public Property Association As String
        Set(value As String)

            prvAssociation = value


        End Set
        Get
            If prvAssociation = "" Then
                Dim BPTools As New BlueprintTools

                Dim BusObID As String = ""
                If DefType = "BusinessObjectDef" Then
                    BusObID = DefID

                Else
                    BusObID = Owner

                End If

                Try
                    Dim temp_Association As String = ""
                    temp_Association = BPTools.GetAssociationFromSQLDB(BusObID)
                    'Console.WriteLine("Association: " & temp_Association)


                    If temp_Association = "" Then
                        prvAssociation = Owner

                    ElseIf temp_Association <> "" Then
                        prvAssociation = temp_Association
                    End If

                Catch Ex As Exception

                End Try
            End If


            Return prvAssociation
        End Get
    End Property


End Class
