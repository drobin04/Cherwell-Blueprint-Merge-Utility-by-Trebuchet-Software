Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Web.Script.Serialization

Public Class ConfigurationFile

	Public Property FilePath As String
	Public Property SettingsCount As Integer = 0

	Public Property SettingsList As New List(Of JSONConfigFileSetting)

	Public Property EncryptedFile As Boolean = False

    Public Property EncryptedPassword As String = ""

    Public Property SettingsContents As String = ""


    'Instructions - 
    'Send file path to New constructor
    'Use Add-setting method to add a key-value pair for a setting
    'Use ExportSettingsToFile method to save.

#Region "Constructors"
    Public Sub New(Path As String)
		FilePath = Path



	End Sub

	Public Sub New(Path As String, EncryptionPassword As String)
		FilePath = Path
		If EncryptionPassword <> "" Then
			EncryptedFile = True
			EncryptedPassword = EncryptionPassword


        End If


	End Sub

#End Region

	Public Sub AddSetting(Name As String, Value As String)
		Dim NewSetting As New JSONConfigFileSetting(Name, Value.Replace("\", "\\"))
		SettingsList.Add(NewSetting)

	End Sub

	Public Sub ExportSettingsToFile()
		Try
			Dim File As New IO.StreamWriter(FilePath)
			File.Write("{")
			File.Write("""SettingsList"": [") 'Write settings as part of an array to make deserializing a list easier

			For Each Setting As JSONConfigFileSetting In SettingsList

				If SettingsCount >= 1 Then
					File.Write(",")
				End If
				File.Write("{")
				File.Write(Setting.GetSettingText)
				File.Write("}")
				SettingsCount += 1
			Next
			File.Write("]}") 'End JSON Array

			File.Close()

			'If Encryption required, Encrypt and overwrite the file
			If EncryptedFile = True Then
				EncryptFile(FilePath)
			End If
		Catch ex As Exception
			MsgBox(ex.Message)

		End Try


	End Sub

	Public Sub EncryptFile(FilePath As String)
		Dim File As New IO.StreamReader(FilePath)
		Dim Contents As String
		Contents = File.ReadToEnd()
		'MsgBox(Contents)

		File.Close()


		'Encrypt Contents Before Writing Back Out To Disk
		Dim Encryptor As New DefEditSoftware.Encryption.Encryption_Interface
		Contents = Encryptor.Encrypt(Contents, EncryptedPassword)
		'MsgBox(Contents)
		Dim OutputFile As New IO.StreamWriter(FilePath)
		OutputFile.Write(Contents)
		OutputFile.Close()


	End Sub

	Public Sub ReadEncryptedFileSettings(FilePath As String)
		Dim File As New IO.StreamReader(FilePath)
		Dim Contents As String
		Contents = File.ReadToEnd
		File.Close()

		'Modify contents to strip out ASP.NET Response.End error:
		Dim IndexOfDelimiter As Integer = 0
		Dim TextBeforeDelimiter As String = ""
		Try
			If Contents.Contains("Thread was being aborted.") Then
				IndexOfDelimiter = Contents.IndexOf("Thread was being aborted.")
				Contents = Contents.Substring(0, IndexOfDelimiter)

			End If
		Catch
		End Try



		'Decrypt Contents
		Dim Decryptor As New DefEditSoftware.Encryption.Encryption_Interface
		Contents = Decryptor.Decrypt(Contents, EncryptedPassword)

        SettingsContents = Contents
        ReadSettingsFromFile(Contents)



	End Sub

	Public Sub ReadSettingsFromFile(Optional InboundFileContents As String = "")

		Dim FileContents As String

		If InboundFileContents = "" Then
			Dim File As StreamReader
			File = IO.File.OpenText(FilePath)
			FileContents = File.ReadToEnd
			File.Close()

		Else
			FileContents = InboundFileContents
		End If



		Dim jss As New JavaScriptSerializer()
		Dim settings As New SettingsList
		settings = jss.Deserialize(Of SettingsList)(FileContents)
		SettingsList = settings.SettingsList


	End Sub

	Public Function GetSettingValueByName(SettingName As String) As String

		For Each Setting As JSONConfigFileSetting In SettingsList
			If Setting.SettingName = SettingName Then
				Return Setting.SettingValue

			Else
				'Return ""
			End If


		Next

		Return ""

	End Function


End Class
