<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BlueprintMerge
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
        Me.components = New System.ComponentModel.Container()
        Me.btnBrowseForOutput = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMergeOutput = New System.Windows.Forms.TextBox()
        Me.btnMergeBlueprints = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.lblBlueprintProgressText = New System.Windows.Forms.Label()
        Me.btnBrowseForBlueprintDirectory = New System.Windows.Forms.Button()
        Me.pbBlueprintProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnScanBlueprints = New System.Windows.Forms.Button()
        Me.lblBlueprintPath = New System.Windows.Forms.Label()
        Me.txtBlueprintPath = New System.Windows.Forms.TextBox()
        Me.dlgResultsSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BlueprintFolderSelector = New System.Windows.Forms.FolderBrowserDialog()
        Me.lvBlueprintList = New System.Windows.Forms.ListView()
        Me.chBlueprintName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.LastModDate = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRemoveBP = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShowDebuggingInfoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScanByLastModAscendingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EnterLicenseKeyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.chkIgnoreScanningAll = New System.Windows.Forms.CheckBox()
        Me.IgnoreScanningAllButLast = New System.Windows.Forms.CheckBox()
        Me.chkShowConsole = New System.Windows.Forms.CheckBox()
        Me.chkPublishRollbacks = New System.Windows.Forms.CheckBox()
        Me.lblLicenseInfo = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBrowseForOutput
        '
        Me.btnBrowseForOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseForOutput.Location = New System.Drawing.Point(778, 421)
        Me.btnBrowseForOutput.Name = "btnBrowseForOutput"
        Me.btnBrowseForOutput.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseForOutput.TabIndex = 29
        Me.btnBrowseForOutput.Text = "Browse"
        Me.btnBrowseForOutput.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 394)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(394, 20)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Step 3: Select Path For Blueprint Merge Output:"
        '
        'txtMergeOutput
        '
        Me.txtMergeOutput.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMergeOutput.Enabled = False
        Me.txtMergeOutput.Location = New System.Drawing.Point(11, 423)
        Me.txtMergeOutput.Name = "txtMergeOutput"
        Me.txtMergeOutput.Size = New System.Drawing.Size(761, 20)
        Me.txtMergeOutput.TabIndex = 27
        '
        'btnMergeBlueprints
        '
        Me.btnMergeBlueprints.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnMergeBlueprints.Enabled = False
        Me.btnMergeBlueprints.Location = New System.Drawing.Point(709, 454)
        Me.btnMergeBlueprints.Name = "btnMergeBlueprints"
        Me.btnMergeBlueprints.Size = New System.Drawing.Size(103, 23)
        Me.btnMergeBlueprints.TabIndex = 26
        Me.btnMergeBlueprints.Text = "Merge Blueprints"
        Me.btnMergeBlueprints.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.Location = New System.Drawing.Point(861, 48)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(0, 486)
        Me.txtLog.TabIndex = 23
        Me.txtLog.Visible = False
        '
        'lblBlueprintProgressText
        '
        Me.lblBlueprintProgressText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBlueprintProgressText.AutoSize = True
        Me.lblBlueprintProgressText.Location = New System.Drawing.Point(428, 492)
        Me.lblBlueprintProgressText.Name = "lblBlueprintProgressText"
        Me.lblBlueprintProgressText.Size = New System.Drawing.Size(24, 13)
        Me.lblBlueprintProgressText.TabIndex = 22
        Me.lblBlueprintProgressText.Text = "0/?"
        '
        'btnBrowseForBlueprintDirectory
        '
        Me.btnBrowseForBlueprintDirectory.Location = New System.Drawing.Point(778, 58)
        Me.btnBrowseForBlueprintDirectory.Name = "btnBrowseForBlueprintDirectory"
        Me.btnBrowseForBlueprintDirectory.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseForBlueprintDirectory.TabIndex = 21
        Me.btnBrowseForBlueprintDirectory.Text = "Browse"
        Me.btnBrowseForBlueprintDirectory.UseVisualStyleBackColor = True
        '
        'pbBlueprintProgressBar
        '
        Me.pbBlueprintProgressBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbBlueprintProgressBar.Location = New System.Drawing.Point(11, 487)
        Me.pbBlueprintProgressBar.Name = "pbBlueprintProgressBar"
        Me.pbBlueprintProgressBar.Size = New System.Drawing.Size(838, 23)
        Me.pbBlueprintProgressBar.Step = 1
        Me.pbBlueprintProgressBar.TabIndex = 20
        '
        'btnScanBlueprints
        '
        Me.btnScanBlueprints.Enabled = False
        Me.btnScanBlueprints.Location = New System.Drawing.Point(621, 93)
        Me.btnScanBlueprints.Name = "btnScanBlueprints"
        Me.btnScanBlueprints.Size = New System.Drawing.Size(112, 23)
        Me.btnScanBlueprints.TabIndex = 19
        Me.btnScanBlueprints.Text = "Scan Blueprints"
        Me.btnScanBlueprints.UseVisualStyleBackColor = True
        '
        'lblBlueprintPath
        '
        Me.lblBlueprintPath.AutoSize = True
        Me.lblBlueprintPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlueprintPath.Location = New System.Drawing.Point(7, 34)
        Me.lblBlueprintPath.Name = "lblBlueprintPath"
        Me.lblBlueprintPath.Size = New System.Drawing.Size(364, 20)
        Me.lblBlueprintPath.TabIndex = 18
        Me.lblBlueprintPath.Text = "Step 1: Select Blueprint Directory for Merge:"
        '
        'txtBlueprintPath
        '
        Me.txtBlueprintPath.Enabled = False
        Me.txtBlueprintPath.Location = New System.Drawing.Point(11, 60)
        Me.txtBlueprintPath.Name = "txtBlueprintPath"
        Me.txtBlueprintPath.Size = New System.Drawing.Size(761, 20)
        Me.txtBlueprintPath.TabIndex = 17
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'lvBlueprintList
        '
        Me.lvBlueprintList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvBlueprintList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chBlueprintName, Me.LastModDate})
        Me.lvBlueprintList.HideSelection = False
        Me.lvBlueprintList.Location = New System.Drawing.Point(12, 122)
        Me.lvBlueprintList.Name = "lvBlueprintList"
        Me.lvBlueprintList.Size = New System.Drawing.Size(802, 266)
        Me.lvBlueprintList.TabIndex = 33
        Me.lvBlueprintList.UseCompatibleStateImageBehavior = False
        Me.lvBlueprintList.View = System.Windows.Forms.View.Details
        '
        'chBlueprintName
        '
        Me.chBlueprintName.Text = "Blueprint Name"
        Me.chBlueprintName.Width = 600
        '
        'LastModDate
        '
        Me.LastModDate.Text = "LastModDate"
        Me.LastModDate.Width = 200
        '
        'btnRemoveBP
        '
        Me.btnRemoveBP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveBP.BackgroundImage = Global.BlueprintMerge.My.Resources.Resources.Button_Delete_icon
        Me.btnRemoveBP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRemoveBP.ImageKey = "(none)"
        Me.btnRemoveBP.Location = New System.Drawing.Point(818, 319)
        Me.btnRemoveBP.Name = "btnRemoveBP"
        Me.btnRemoveBP.Size = New System.Drawing.Size(32, 32)
        Me.btnRemoveBP.TabIndex = 34
        Me.btnRemoveBP.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackgroundImage = Global.BlueprintMerge.My.Resources.Resources.Up_Arrow
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.ImageKey = "(none)"
        Me.Button2.Location = New System.Drawing.Point(818, 281)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(32, 32)
        Me.Button2.TabIndex = 32
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.BlueprintMerge.My.Resources.Resources.Down_Arrow
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.ImageKey = "(none)"
        Me.Button1.Location = New System.Drawing.Point(818, 357)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(32, 32)
        Me.Button1.TabIndex = 31
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Gainsboro
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(862, 24)
        Me.MenuStrip1.TabIndex = 35
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowDebuggingInfoToolStripMenuItem, Me.ScanByLastModAscendingToolStripMenuItem, Me.EnterLicenseKeyToolStripMenuItem})
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ShowDebuggingInfoToolStripMenuItem
        '
        Me.ShowDebuggingInfoToolStripMenuItem.Name = "ShowDebuggingInfoToolStripMenuItem"
        Me.ShowDebuggingInfoToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ShowDebuggingInfoToolStripMenuItem.Text = "Show Debugging Info"
        '
        'ScanByLastModAscendingToolStripMenuItem
        '
        Me.ScanByLastModAscendingToolStripMenuItem.Name = "ScanByLastModAscendingToolStripMenuItem"
        Me.ScanByLastModAscendingToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.ScanByLastModAscendingToolStripMenuItem.Text = "Scan by LastMod Ascending"
        '
        'EnterLicenseKeyToolStripMenuItem
        '
        Me.EnterLicenseKeyToolStripMenuItem.Name = "EnterLicenseKeyToolStripMenuItem"
        Me.EnterLicenseKeyToolStripMenuItem.Size = New System.Drawing.Size(223, 22)
        Me.EnterLicenseKeyToolStripMenuItem.Text = "Enter License Key"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.AboutToolStripMenuItem.Text = "About..."
        Me.AboutToolStripMenuItem.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(606, 20)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Step 2: Scan Blueprints, Use Buttons At Bottom-Right To Order For Merge"
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 454)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(696, 20)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Step 4: After Ordering Blueprints From Oldest (Top) To Newest (Bottom), Press Mer" &
    "ge"
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(11, 516)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(244, 23)
        Me.Button3.TabIndex = 38
        Me.Button3.Text = "Publish Blueprints Directly To Cherwell"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'chkIgnoreScanningAll
        '
        Me.chkIgnoreScanningAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkIgnoreScanningAll.AutoSize = True
        Me.chkIgnoreScanningAll.Location = New System.Drawing.Point(261, 520)
        Me.chkIgnoreScanningAll.Name = "chkIgnoreScanningAll"
        Me.chkIgnoreScanningAll.Size = New System.Drawing.Size(136, 17)
        Me.chkIgnoreScanningAll.TabIndex = 39
        Me.chkIgnoreScanningAll.Text = "Ignore Scanning For All"
        Me.chkIgnoreScanningAll.UseVisualStyleBackColor = True
        '
        'IgnoreScanningAllButLast
        '
        Me.IgnoreScanningAllButLast.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.IgnoreScanningAllButLast.AutoSize = True
        Me.IgnoreScanningAllButLast.Checked = True
        Me.IgnoreScanningAllButLast.CheckState = System.Windows.Forms.CheckState.Checked
        Me.IgnoreScanningAllButLast.Location = New System.Drawing.Point(403, 520)
        Me.IgnoreScanningAllButLast.Name = "IgnoreScanningAllButLast"
        Me.IgnoreScanningAllButLast.Size = New System.Drawing.Size(142, 17)
        Me.IgnoreScanningAllButLast.TabIndex = 39
        Me.IgnoreScanningAllButLast.Text = "Only Scan Last Blueprint"
        Me.IgnoreScanningAllButLast.UseVisualStyleBackColor = True
        '
        'chkShowConsole
        '
        Me.chkShowConsole.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkShowConsole.AutoSize = True
        Me.chkShowConsole.Location = New System.Drawing.Point(551, 520)
        Me.chkShowConsole.Name = "chkShowConsole"
        Me.chkShowConsole.Size = New System.Drawing.Size(185, 17)
        Me.chkShowConsole.TabIndex = 40
        Me.chkShowConsole.Text = "Show Console - Allows Cancelling"
        Me.chkShowConsole.UseVisualStyleBackColor = True
        '
        'chkPublishRollbacks
        '
        Me.chkPublishRollbacks.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPublishRollbacks.AutoSize = True
        Me.chkPublishRollbacks.Location = New System.Drawing.Point(742, 520)
        Me.chkPublishRollbacks.Name = "chkPublishRollbacks"
        Me.chkPublishRollbacks.Size = New System.Drawing.Size(110, 17)
        Me.chkPublishRollbacks.TabIndex = 41
        Me.chkPublishRollbacks.Text = "Publish Rollbacks"
        Me.chkPublishRollbacks.UseVisualStyleBackColor = True
        '
        'lblLicenseInfo
        '
        Me.lblLicenseInfo.AutoSize = True
        Me.lblLicenseInfo.BackColor = System.Drawing.Color.Yellow
        Me.lblLicenseInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLicenseInfo.Location = New System.Drawing.Point(483, 24)
        Me.lblLicenseInfo.Name = "lblLicenseInfo"
        Me.lblLicenseInfo.Size = New System.Drawing.Size(102, 15)
        Me.lblLicenseInfo.TabIndex = 42
        Me.lblLicenseInfo.Text = "License Info Here..."
        '
        'BlueprintMerge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(862, 547)
        Me.Controls.Add(Me.lblLicenseInfo)
        Me.Controls.Add(Me.chkPublishRollbacks)
        Me.Controls.Add(Me.chkShowConsole)
        Me.Controls.Add(Me.IgnoreScanningAllButLast)
        Me.Controls.Add(Me.chkIgnoreScanningAll)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnRemoveBP)
        Me.Controls.Add(Me.lvBlueprintList)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnBrowseForOutput)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMergeOutput)
        Me.Controls.Add(Me.btnMergeBlueprints)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.lblBlueprintProgressText)
        Me.Controls.Add(Me.btnBrowseForBlueprintDirectory)
        Me.Controls.Add(Me.btnScanBlueprints)
        Me.Controls.Add(Me.lblBlueprintPath)
        Me.Controls.Add(Me.txtBlueprintPath)
        Me.Controls.Add(Me.pbBlueprintProgressBar)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Label3)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "BlueprintMerge"
        Me.Text = "Blueprint Merge by DefEdit Software LLC"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnBrowseForOutput As Button
	Friend WithEvents Label1 As Label
	Friend WithEvents txtMergeOutput As TextBox
	Friend WithEvents btnMergeBlueprints As Button
	Friend WithEvents txtLog As TextBox
	Friend WithEvents lblBlueprintProgressText As Label
	Friend WithEvents btnBrowseForBlueprintDirectory As Button
	Friend WithEvents pbBlueprintProgressBar As ProgressBar
	Friend WithEvents btnScanBlueprints As Button
	Friend WithEvents lblBlueprintPath As Label
	Friend WithEvents txtBlueprintPath As TextBox
	Friend WithEvents dlgResultsSaveDialog As SaveFileDialog
	Friend WithEvents ImageList1 As ImageList
	Friend WithEvents BlueprintFolderSelector As FolderBrowserDialog
	Friend WithEvents Button1 As Button
	Friend WithEvents Button2 As Button
	Friend WithEvents lvBlueprintList As ListView
	Friend WithEvents chBlueprintName As ColumnHeader
	Friend WithEvents LastModDate As ColumnHeader
	Friend WithEvents btnRemoveBP As Button
	Friend WithEvents MenuStrip1 As MenuStrip
	Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents ShowDebuggingInfoToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents Label2 As Label
	Friend WithEvents Label3 As Label
	Friend WithEvents ScanByLastModAscendingToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents Button3 As Button
	Friend WithEvents chkIgnoreScanningAll As CheckBox
	Friend WithEvents IgnoreScanningAllButLast As CheckBox
	Friend WithEvents chkShowConsole As CheckBox
	Friend WithEvents chkPublishRollbacks As CheckBox
	Friend WithEvents EnterLicenseKeyToolStripMenuItem As ToolStripMenuItem
	Friend WithEvents lblLicenseInfo As Label
End Class
