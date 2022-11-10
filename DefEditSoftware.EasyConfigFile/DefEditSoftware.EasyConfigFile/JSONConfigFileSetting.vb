Public Class JSONConfigFileSetting

	Public Property SettingName As String

	Public Property SettingValue As String

	Public Sub New()

	End Sub

	Public Sub New(Name As String, Value As String)
		SettingName = Name

		SettingValue = Value '.Replace("\", "\\")

	End Sub

	Public Function GetSettingText() As String
		Dim JSONSettingText As String = """SettingName"": """ & SettingName & """, ""SettingValue"": """ & SettingValue & """"

		Return JSONSettingText
	End Function

End Class