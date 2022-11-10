<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.BlueprintFolderSelector = New System.Windows.Forms.FolderBrowserDialog()
        Me.txtBlueprintPath = New System.Windows.Forms.TextBox()
        Me.lblBlueprintPath = New System.Windows.Forms.Label()
        Me.btnBeginProcessing = New System.Windows.Forms.Button()
        Me.pbBlueprintProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnBrowseForBlueprintDirectory = New System.Windows.Forms.Button()
        Me.lblBlueprintProgressText = New System.Windows.Forms.Label()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.dlgResultsSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.txtMessageBox = New System.Windows.Forms.TextBox()
        Me.lvDefList = New System.Windows.Forms.ListView()
        Me.chBlueprintName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDefType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAssociation = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDefName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDefAlias = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chScope = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDefID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.btnCheckmAppProgress = New System.Windows.Forms.Button()
        Me.btnBrowseFormApp = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtmAppFile = New System.Windows.Forms.TextBox()
        Me.dlgmAppFileSelector = New System.Windows.Forms.OpenFileDialog()
        Me.tmrBlueprintUpdates = New System.Windows.Forms.Timer(Me.components)
        Me.btnStartWorking = New System.Windows.Forms.Button()
        Me.btnStopWorking = New System.Windows.Forms.Button()
        Me.btnLoadDefs = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnSavetoProject = New System.Windows.Forms.Button()
        Me.btnLoadFromProject = New System.Windows.Forms.Button()
        Me.gboxmAppProject = New System.Windows.Forms.GroupBox()
        Me.btnNewProject = New System.Windows.Forms.Button()
        Me.cboxmAppProject = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gboxmAppProject.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBlueprintPath
        '
        Me.txtBlueprintPath.Enabled = False
        Me.txtBlueprintPath.Location = New System.Drawing.Point(12, 29)
        Me.txtBlueprintPath.Name = "txtBlueprintPath"
        Me.txtBlueprintPath.Size = New System.Drawing.Size(761, 20)
        Me.txtBlueprintPath.TabIndex = 0
        '
        'lblBlueprintPath
        '
        Me.lblBlueprintPath.AutoSize = True
        Me.lblBlueprintPath.Location = New System.Drawing.Point(12, 13)
        Me.lblBlueprintPath.Name = "lblBlueprintPath"
        Me.lblBlueprintPath.Size = New System.Drawing.Size(189, 13)
        Me.lblBlueprintPath.TabIndex = 1
        Me.lblBlueprintPath.Text = "Blueprint Directory for mApp/Migration:"
        '
        'btnBeginProcessing
        '
        Me.btnBeginProcessing.Enabled = False
        Me.btnBeginProcessing.Location = New System.Drawing.Point(11, 98)
        Me.btnBeginProcessing.Name = "btnBeginProcessing"
        Me.btnBeginProcessing.Size = New System.Drawing.Size(112, 23)
        Me.btnBeginProcessing.TabIndex = 2
        Me.btnBeginProcessing.Text = "Scan Blueprints"
        Me.btnBeginProcessing.UseVisualStyleBackColor = True
        '
        'pbBlueprintProgressBar
        '
        Me.pbBlueprintProgressBar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pbBlueprintProgressBar.Location = New System.Drawing.Point(11, 412)
        Me.pbBlueprintProgressBar.Name = "pbBlueprintProgressBar"
        Me.pbBlueprintProgressBar.Size = New System.Drawing.Size(995, 23)
        Me.pbBlueprintProgressBar.Step = 1
        Me.pbBlueprintProgressBar.TabIndex = 4
        '
        'btnBrowseForBlueprintDirectory
        '
        Me.btnBrowseForBlueprintDirectory.Location = New System.Drawing.Point(779, 27)
        Me.btnBrowseForBlueprintDirectory.Name = "btnBrowseForBlueprintDirectory"
        Me.btnBrowseForBlueprintDirectory.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseForBlueprintDirectory.TabIndex = 5
        Me.btnBrowseForBlueprintDirectory.Text = "Browse"
        Me.btnBrowseForBlueprintDirectory.UseVisualStyleBackColor = True
        '
        'lblBlueprintProgressText
        '
        Me.lblBlueprintProgressText.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBlueprintProgressText.AutoSize = True
        Me.lblBlueprintProgressText.Location = New System.Drawing.Point(496, 417)
        Me.lblBlueprintProgressText.Name = "lblBlueprintProgressText"
        Me.lblBlueprintProgressText.Size = New System.Drawing.Size(24, 13)
        Me.lblBlueprintProgressText.TabIndex = 6
        Me.lblBlueprintProgressText.Text = "0/?"
        '
        'txtLog
        '
        Me.txtLog.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtLog.Location = New System.Drawing.Point(1012, 5)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(0, 453)
        Me.txtLog.TabIndex = 7
        Me.txtLog.Visible = False
        '
        'txtMessageBox
        '
        Me.txtMessageBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtMessageBox.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.txtMessageBox.Location = New System.Drawing.Point(12, 438)
        Me.txtMessageBox.Name = "txtMessageBox"
        Me.txtMessageBox.Size = New System.Drawing.Size(994, 20)
        Me.txtMessageBox.TabIndex = 11
        '
        'lvDefList
        '
        Me.lvDefList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvDefList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chBlueprintName, Me.chDefType, Me.chAssociation, Me.chDefName, Me.chDefAlias, Me.chScope, Me.chDescription, Me.chDefID})
        Me.lvDefList.Location = New System.Drawing.Point(11, 127)
        Me.lvDefList.Name = "lvDefList"
        Me.lvDefList.Size = New System.Drawing.Size(995, 279)
        Me.lvDefList.SmallImageList = Me.ImageList1
        Me.lvDefList.TabIndex = 12
        Me.lvDefList.UseCompatibleStateImageBehavior = False
        Me.lvDefList.View = System.Windows.Forms.View.Details
        '
        'chBlueprintName
        '
        Me.chBlueprintName.Text = "Blueprint Name"
        Me.chBlueprintName.Width = 240
        '
        'chDefType
        '
        Me.chDefType.Text = "DefType"
        Me.chDefType.Width = 120
        '
        'chAssociation
        '
        Me.chAssociation.Text = "Association"
        Me.chAssociation.Width = 120
        '
        'chDefName
        '
        Me.chDefName.Text = "DefName"
        Me.chDefName.Width = 120
        '
        'chDefAlias
        '
        Me.chDefAlias.Text = "Alias"
        '
        'chScope
        '
        Me.chScope.Text = "Scope"
        '
        'chDescription
        '
        Me.chDescription.Text = "Description"
        Me.chDescription.Width = 200
        '
        'chDefID
        '
        Me.chDefID.Text = "Def ID"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8-ok-50.png")
        Me.ImageList1.Images.SetKeyName(1, "icons8-cancel-50.png")
        '
        'btnCheckmAppProgress
        '
        Me.btnCheckmAppProgress.Location = New System.Drawing.Point(232, 98)
        Me.btnCheckmAppProgress.Name = "btnCheckmAppProgress"
        Me.btnCheckmAppProgress.Size = New System.Drawing.Size(128, 23)
        Me.btnCheckmAppProgress.TabIndex = 13
        Me.btnCheckmAppProgress.Text = "Check mApp Progress"
        Me.btnCheckmAppProgress.UseVisualStyleBackColor = True
        '
        'btnBrowseFormApp
        '
        Me.btnBrowseFormApp.Location = New System.Drawing.Point(779, 70)
        Me.btnBrowseFormApp.Name = "btnBrowseFormApp"
        Me.btnBrowseFormApp.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseFormApp.TabIndex = 16
        Me.btnBrowseFormApp.Text = "Browse"
        Me.btnBrowseFormApp.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(160, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "mAppBP File for Progress Check"
        '
        'txtmAppFile
        '
        Me.txtmAppFile.Enabled = False
        Me.txtmAppFile.Location = New System.Drawing.Point(12, 72)
        Me.txtmAppFile.Name = "txtmAppFile"
        Me.txtmAppFile.Size = New System.Drawing.Size(761, 20)
        Me.txtmAppFile.TabIndex = 14
        '
        'dlgmAppFileSelector
        '
        Me.dlgmAppFileSelector.FileName = "OpenFileDialog1"
        '
        'tmrBlueprintUpdates
        '
        Me.tmrBlueprintUpdates.Interval = 5000
        '
        'btnStartWorking
        '
        Me.btnStartWorking.Location = New System.Drawing.Point(304, 2)
        Me.btnStartWorking.Name = "btnStartWorking"
        Me.btnStartWorking.Size = New System.Drawing.Size(92, 23)
        Me.btnStartWorking.TabIndex = 17
        Me.btnStartWorking.Text = "Start Working"
        Me.btnStartWorking.UseVisualStyleBackColor = True
        '
        'btnStopWorking
        '
        Me.btnStopWorking.Enabled = False
        Me.btnStopWorking.Location = New System.Drawing.Point(409, 2)
        Me.btnStopWorking.Name = "btnStopWorking"
        Me.btnStopWorking.Size = New System.Drawing.Size(92, 23)
        Me.btnStopWorking.TabIndex = 18
        Me.btnStopWorking.Text = "Stop Working"
        Me.btnStopWorking.UseVisualStyleBackColor = True
        '
        'btnLoadDefs
        '
        Me.btnLoadDefs.Enabled = False
        Me.btnLoadDefs.Location = New System.Drawing.Point(534, 2)
        Me.btnLoadDefs.Name = "btnLoadDefs"
        Me.btnLoadDefs.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadDefs.TabIndex = 19
        Me.btnLoadDefs.Text = "Load Defs"
        Me.btnLoadDefs.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(615, 3)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(158, 23)
        Me.Button2.TabIndex = 21
        Me.Button2.Text = "Manage Association Cache"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'btnSavetoProject
        '
        Me.btnSavetoProject.Location = New System.Drawing.Point(6, 91)
        Me.btnSavetoProject.Name = "btnSavetoProject"
        Me.btnSavetoProject.Size = New System.Drawing.Size(141, 23)
        Me.btnSavetoProject.TabIndex = 22
        Me.btnSavetoProject.Text = "Save to Project"
        Me.btnSavetoProject.UseVisualStyleBackColor = True
        '
        'btnLoadFromProject
        '
        Me.btnLoadFromProject.Location = New System.Drawing.Point(6, 66)
        Me.btnLoadFromProject.Name = "btnLoadFromProject"
        Me.btnLoadFromProject.Size = New System.Drawing.Size(141, 23)
        Me.btnLoadFromProject.TabIndex = 23
        Me.btnLoadFromProject.Text = "Load From Project"
        Me.btnLoadFromProject.UseVisualStyleBackColor = True
        '
        'gboxmAppProject
        '
        Me.gboxmAppProject.Controls.Add(Me.btnNewProject)
        Me.gboxmAppProject.Controls.Add(Me.cboxmAppProject)
        Me.gboxmAppProject.Controls.Add(Me.btnLoadFromProject)
        Me.gboxmAppProject.Controls.Add(Me.btnSavetoProject)
        Me.gboxmAppProject.Location = New System.Drawing.Point(859, 5)
        Me.gboxmAppProject.Name = "gboxmAppProject"
        Me.gboxmAppProject.Size = New System.Drawing.Size(153, 119)
        Me.gboxmAppProject.TabIndex = 24
        Me.gboxmAppProject.TabStop = False
        Me.gboxmAppProject.Text = "mApp Project"
        '
        'btnNewProject
        '
        Me.btnNewProject.Location = New System.Drawing.Point(6, 41)
        Me.btnNewProject.Name = "btnNewProject"
        Me.btnNewProject.Size = New System.Drawing.Size(141, 23)
        Me.btnNewProject.TabIndex = 25
        Me.btnNewProject.Text = "New Project"
        Me.btnNewProject.UseVisualStyleBackColor = True
        '
        'cboxmAppProject
        '
        Me.cboxmAppProject.FormattingEnabled = True
        Me.cboxmAppProject.Location = New System.Drawing.Point(6, 16)
        Me.cboxmAppProject.Name = "cboxmAppProject"
        Me.cboxmAppProject.Size = New System.Drawing.Size(141, 21)
        Me.cboxmAppProject.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(409, 99)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 23)
        Me.Button1.TabIndex = 25
        Me.Button1.Text = "Clear Defs List"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1022, 470)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.gboxmAppProject)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.btnLoadDefs)
        Me.Controls.Add(Me.btnStopWorking)
        Me.Controls.Add(Me.btnStartWorking)
        Me.Controls.Add(Me.btnBrowseFormApp)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtmAppFile)
        Me.Controls.Add(Me.btnCheckmAppProgress)
        Me.Controls.Add(Me.lvDefList)
        Me.Controls.Add(Me.txtMessageBox)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.lblBlueprintProgressText)
        Me.Controls.Add(Me.btnBrowseForBlueprintDirectory)
        Me.Controls.Add(Me.pbBlueprintProgressBar)
        Me.Controls.Add(Me.btnBeginProcessing)
        Me.Controls.Add(Me.lblBlueprintPath)
        Me.Controls.Add(Me.txtBlueprintPath)
        Me.Name = "Form1"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Blueprint Checklist Generator"
        Me.gboxmAppProject.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BlueprintFolderSelector As FolderBrowserDialog
    Friend WithEvents txtBlueprintPath As TextBox
    Friend WithEvents lblBlueprintPath As Label
    Friend WithEvents btnBeginProcessing As Button
    Friend WithEvents pbBlueprintProgressBar As ProgressBar
    Friend WithEvents btnBrowseForBlueprintDirectory As Button
    Friend WithEvents lblBlueprintProgressText As Label
    Friend WithEvents txtLog As TextBox
    Friend WithEvents dlgResultsSaveDialog As SaveFileDialog
    Friend WithEvents txtMessageBox As TextBox
    Friend WithEvents lvDefList As ListView
    Friend WithEvents chBlueprintName As ColumnHeader
    Friend WithEvents chDefType As ColumnHeader
    Friend WithEvents chDefName As ColumnHeader
    Friend WithEvents chDefAlias As ColumnHeader
    Friend WithEvents chScope As ColumnHeader
    Friend WithEvents chDescription As ColumnHeader
    Friend WithEvents chDefID As ColumnHeader
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents btnCheckmAppProgress As Button
    Friend WithEvents btnBrowseFormApp As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtmAppFile As TextBox
    Friend WithEvents dlgmAppFileSelector As OpenFileDialog
    Friend WithEvents tmrBlueprintUpdates As Timer
    Friend WithEvents btnStartWorking As Button
    Friend WithEvents btnStopWorking As Button
    Friend WithEvents btnLoadDefs As Button
    Friend WithEvents chAssociation As ColumnHeader
    Friend WithEvents Button2 As Button
    Friend WithEvents btnSavetoProject As Button
    Friend WithEvents btnLoadFromProject As Button
    Friend WithEvents gboxmAppProject As GroupBox
    Friend WithEvents btnNewProject As Button
    Friend WithEvents cboxmAppProject As ComboBox
    Friend WithEvents Button1 As Button
End Class
