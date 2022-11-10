Imports System.Xml
Imports System.Windows.Forms
Imports System.IO
Imports DefEditSoftware.Encryption
Imports DefEditSoftware.EasyConfigFile
Imports DefEditSoftware.MessageDialogs.TextBoxMessage
Imports DefEditSoftware.Extensions
Imports DefEditSoftware.Extensions.DefExtensions

Public Class Prompt
	Public Property ConnectionName As String
	Public Property Username As String
	Public Property Password As String
	Public Property URL As String


	Private filePath As String = "Accounts.xml"
	Private xmlFile As XmlReader
	Private ds As New DataSet

	Private enc_key As String = "CSMC0nnecti0nPr0mpt!@#"

	Public Sub New()

		' This call is required by the designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call.
		Try

			If Not IO.Directory.Exists("C:\ProgramData\DefEdit Software LLC") Then
				IO.Directory.CreateDirectory("C:\ProgramData\DefEdit Software LLC")
			End If
			Config = New DefEditSoftware.EasyConfigFile.ConfigurationFile("C:\ProgramData\DefEdit Software LLC\CSMConnectionPromptConfig.config")
		Catch ex As Exception
			Dim msg As New DefEditSoftware.MessageDialogs.TextBoxMessage(ex.Message)
			msg.Show()

		End Try

	End Sub

	Private Sub Prompt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Try
			Dim reader As XmlTextReader
			reader = New XmlTextReader("C:\ProgramData\Trebuchet\Connections.xml")
			reader.WhitespaceHandling = WhitespaceHandling.None

			reader.Read() '<trebuchet>
			reader.Read() '<connectiondeflist>

			While Not reader.EOF
				reader.Read() '<ConnectionDef>

				If reader.GetAttribute("Name") <> "" Then
					lv_prompt.Items.Add(reader.GetAttribute("Name"))
				End If
			End While



		Catch ex As Exception
			MessageBox.Show(ex.ToString)
			Me.Close()
		End Try

		Try
			ReadConfigFile()
			If cboxSavedCredentials.Items.Count >= 1 Then
				cboxSavedCredentials.SelectedIndex = 0

			End If
		Catch ex As Exception

		End Try
	End Sub

	Public Sub SelectConnection()
		ConnectionName = lv_prompt.SelectedItems(0).Text
		Username = txtUsername.Text
		Password = txtPassword.Text
		Me.Close()
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		SelectConnection()


	End Sub

	Public Function FormatCredentials() As String
		Dim returnstring As String = ""

		Try
			returnstring = Encrypt(txtUsername.Text & ";" & txtPassword.Text)
		Catch ex As Exception
			Dim msgbox As New DefEditSoftware.MessageDialogs.TextBoxMessage(ex.ToString)
		End Try



		Return returnstring
	End Function

	Public Function GetvalueForSavedConfig(CredentialName As String) As String
		Dim returnvalue As String = ""
		For Each setting As JSONConfigFileSetting In Config.SettingsList
			If setting.SettingName = CredentialName Then
				returnvalue = setting.SettingValue

			End If
		Next


		Return returnvalue
	End Function
	'EasyConfigFile Data
	Public Property Config As DefEditSoftware.EasyConfigFile.ConfigurationFile

	Public Sub ReadConfigFile()
		Config.ReadSettingsFromFile()
		For Each setting As JSONConfigFileSetting In Config.SettingsList
			If setting.SettingName <> "" Then cboxSavedCredentials.Items.Add(setting.SettingName)
		Next

	End Sub

#Region "Saved Credentials Methods"
	Public Sub BuildSavedCredentialsDropdown()
		cboxSavedCredentials.Items.Clear()

		For Each setting As JSONConfigFileSetting In Config.SettingsList
			cboxSavedCredentials.Items.Add(setting.SettingName)


		Next
	End Sub

	Private Sub btnSaveCreds_Click(sender As Object, e As EventArgs) Handles btnSaveCreds.Click
		Try
			Config.AddSetting(txtCredentialName.Text, FormatCredentials)
			Config.ExportSettingsToFile()
		Catch ex As Exception
			MsgBox(ex.ToString)


		End Try
	End Sub

	Private Sub cboxSavedCredentials_SelectedValueChanged(sender As Object, e As EventArgs) Handles cboxSavedCredentials.SelectedValueChanged
		Try
			DecryptCredentialIntoTextFields(GetvalueForSavedConfig(cboxSavedCredentials.Text))
		Catch ex As Exception
			Dim msg As New DefEditSoftware.MessageDialogs.TextBoxMessage(ex.ToString)

		End Try

	End Sub

	Private Sub cboxSavedCredentials_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboxSavedCredentials.SelectedIndexChanged
		Try
			DecryptCredentialIntoTextFields(GetvalueForSavedConfig(cboxSavedCredentials.Text))
		Catch ex As Exception
			Dim msg As New DefEditSoftware.MessageDialogs.TextBoxMessage(ex.ToString)

		End Try
	End Sub

#End Region

	Private Sub lv_prompt_DoubleClick(sender As Object, e As EventArgs) Handles lv_prompt.DoubleClick
		SelectConnection()
	End Sub


#Region "Encryption Code"
	Function Encrypt(incomingdata As String) As String

		Dim EncInterface As New Encryption_Interface



		Dim EncryptedData As String

		EncryptedData = EncInterface.Encrypt(incomingdata, enc_key)

		Return EncryptedData

	End Function

	Function Encrypt(incomingdata As String, EncryptionKey As String) As String

		Dim EncInterface As New Encryption_Interface

		Dim EncryptedData As String

		EncryptedData = EncInterface.Encrypt(incomingdata, enc_key)

		Return EncryptedData

	End Function


	Function Decrypt(incomingdata As String) As String
		Dim EncInterface As New Encryption_Interface

		Dim EncryptedData As String

		EncryptedData = EncInterface.Decrypt(incomingdata, enc_key)

		Return EncryptedData
	End Function

	Public Sub DecryptCredentialIntoTextFields(EncryptedKey As String)

		Dim decryptedvalue As String = Decrypt(EncryptedKey)
		txtUsername.Text = decryptedvalue.TextBefore(";")
		txtPassword.Text = decryptedvalue.TextAfter(";")


	End Sub

#End Region


End Class