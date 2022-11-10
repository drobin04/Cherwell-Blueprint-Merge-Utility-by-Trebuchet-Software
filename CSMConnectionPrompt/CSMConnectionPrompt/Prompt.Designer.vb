<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Prompt
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
		Me.lv_prompt = New System.Windows.Forms.ListView()
		Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
		Me.Button1 = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.txtUsername = New System.Windows.Forms.TextBox()
		Me.txtPassword = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.btnSaveCreds = New System.Windows.Forms.Button()
		Me.cboxSavedCredentials = New System.Windows.Forms.ComboBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtCredentialName = New System.Windows.Forms.TextBox()
		Me.SuspendLayout()
		'
		'lv_prompt
		'
		Me.lv_prompt.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
		Me.lv_prompt.HideSelection = False
		Me.lv_prompt.Location = New System.Drawing.Point(12, 12)
		Me.lv_prompt.Name = "lv_prompt"
		Me.lv_prompt.Size = New System.Drawing.Size(150, 244)
		Me.lv_prompt.TabIndex = 0
		Me.lv_prompt.UseCompatibleStateImageBehavior = False
		Me.lv_prompt.View = System.Windows.Forms.View.Details
		'
		'ColumnHeader1
		'
		Me.ColumnHeader1.Text = "Connection Name"
		Me.ColumnHeader1.Width = 121
		'
		'Button1
		'
		Me.Button1.Location = New System.Drawing.Point(12, 262)
		Me.Button1.Name = "Button1"
		Me.Button1.Size = New System.Drawing.Size(150, 35)
		Me.Button1.TabIndex = 1
		Me.Button1.Text = "Select"
		Me.Button1.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Location = New System.Drawing.Point(169, 55)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(58, 13)
		Me.Label1.TabIndex = 2
		Me.Label1.Text = "Username:"
		'
		'txtUsername
		'
		Me.txtUsername.Location = New System.Drawing.Point(169, 72)
		Me.txtUsername.Name = "txtUsername"
		Me.txtUsername.Size = New System.Drawing.Size(100, 20)
		Me.txtUsername.TabIndex = 3
		'
		'txtPassword
		'
		Me.txtPassword.Location = New System.Drawing.Point(169, 115)
		Me.txtPassword.Name = "txtPassword"
		Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
		Me.txtPassword.Size = New System.Drawing.Size(100, 20)
		Me.txtPassword.TabIndex = 5
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(169, 98)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(56, 13)
		Me.Label2.TabIndex = 4
		Me.Label2.Text = "Password:"
		'
		'btnSaveCreds
		'
		Me.btnSaveCreds.Location = New System.Drawing.Point(169, 210)
		Me.btnSaveCreds.Name = "btnSaveCreds"
		Me.btnSaveCreds.Size = New System.Drawing.Size(100, 24)
		Me.btnSaveCreds.TabIndex = 6
		Me.btnSaveCreds.Text = "Save Credentials"
		Me.btnSaveCreds.UseVisualStyleBackColor = True
		'
		'cboxSavedCredentials
		'
		Me.cboxSavedCredentials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cboxSavedCredentials.FormattingEnabled = True
		Me.cboxSavedCredentials.Location = New System.Drawing.Point(169, 31)
		Me.cboxSavedCredentials.Name = "cboxSavedCredentials"
		Me.cboxSavedCredentials.Size = New System.Drawing.Size(100, 21)
		Me.cboxSavedCredentials.TabIndex = 7
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Location = New System.Drawing.Point(169, 15)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(96, 13)
		Me.Label3.TabIndex = 8
		Me.Label3.Text = "Saved Credentials:"
		'
		'Label4
		'
		Me.Label4.AutoSize = True
		Me.Label4.Location = New System.Drawing.Point(169, 167)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(88, 13)
		Me.Label4.TabIndex = 4
		Me.Label4.Text = "Credential Name:"
		'
		'txtCredentialName
		'
		Me.txtCredentialName.Location = New System.Drawing.Point(169, 184)
		Me.txtCredentialName.Name = "txtCredentialName"
		Me.txtCredentialName.Size = New System.Drawing.Size(100, 20)
		Me.txtCredentialName.TabIndex = 5
		'
		'Prompt
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(275, 304)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.cboxSavedCredentials)
		Me.Controls.Add(Me.btnSaveCreds)
		Me.Controls.Add(Me.txtCredentialName)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.txtPassword)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.txtUsername)
		Me.Controls.Add(Me.Label1)
		Me.Controls.Add(Me.Button1)
		Me.Controls.Add(Me.lv_prompt)
		Me.Name = "Prompt"
		Me.Text = "Connection Prompt"
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents lv_prompt As Windows.Forms.ListView
    Friend WithEvents Button1 As Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As Windows.Forms.ColumnHeader
	Friend WithEvents Label1 As Windows.Forms.Label
	Friend WithEvents txtUsername As Windows.Forms.TextBox
	Friend WithEvents txtPassword As Windows.Forms.TextBox
	Friend WithEvents Label2 As Windows.Forms.Label
	Friend WithEvents btnSaveCreds As Windows.Forms.Button
	Friend WithEvents cboxSavedCredentials As Windows.Forms.ComboBox
	Friend WithEvents Label3 As Windows.Forms.Label
	Friend WithEvents Label4 As Windows.Forms.Label
	Friend WithEvents txtCredentialName As Windows.Forms.TextBox
End Class
