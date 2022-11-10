<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BlueprintInspector
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
        Me.lvDefList = New System.Windows.Forms.ListView()
        Me.chDefType = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chAssociation = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDefName = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDefAlias = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chScope = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDescription = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.chDefID = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnBrowseForBlueprintDirectory = New System.Windows.Forms.Button()
        Me.lblBlueprintPath = New System.Windows.Forms.Label()
        Me.txtBlueprintPath = New System.Windows.Forms.TextBox()
        Me.dlgResultsSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.ofdFileSelector = New System.Windows.Forms.OpenFileDialog()
        Me.btnScanBlueprints = New System.Windows.Forms.Button()
        Me.txtLog = New System.Windows.Forms.TextBox()
        Me.chDefView = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'lvDefList
        '
        Me.lvDefList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lvDefList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.chDefType, Me.chAssociation, Me.chDefName, Me.chDefAlias, Me.chScope, Me.chDescription, Me.chDefID, Me.chDefView})
        Me.lvDefList.Location = New System.Drawing.Point(12, 87)
        Me.lvDefList.Name = "lvDefList"
        Me.lvDefList.Size = New System.Drawing.Size(1033, 279)
        Me.lvDefList.TabIndex = 13
        Me.lvDefList.UseCompatibleStateImageBehavior = False
        Me.lvDefList.View = System.Windows.Forms.View.Details
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
        'btnBrowseForBlueprintDirectory
        '
        Me.btnBrowseForBlueprintDirectory.Location = New System.Drawing.Point(780, 32)
        Me.btnBrowseForBlueprintDirectory.Name = "btnBrowseForBlueprintDirectory"
        Me.btnBrowseForBlueprintDirectory.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseForBlueprintDirectory.TabIndex = 24
        Me.btnBrowseForBlueprintDirectory.Text = "Browse"
        Me.btnBrowseForBlueprintDirectory.UseVisualStyleBackColor = True
        '
        'lblBlueprintPath
        '
        Me.lblBlueprintPath.AutoSize = True
        Me.lblBlueprintPath.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBlueprintPath.Location = New System.Drawing.Point(9, 8)
        Me.lblBlueprintPath.Name = "lblBlueprintPath"
        Me.lblBlueprintPath.Size = New System.Drawing.Size(326, 20)
        Me.lblBlueprintPath.TabIndex = 23
        Me.lblBlueprintPath.Text = "Step 1: Select Blueprint For Inspection:"
        '
        'txtBlueprintPath
        '
        Me.txtBlueprintPath.Enabled = False
        Me.txtBlueprintPath.Location = New System.Drawing.Point(13, 34)
        Me.txtBlueprintPath.Name = "txtBlueprintPath"
        Me.txtBlueprintPath.Size = New System.Drawing.Size(761, 20)
        Me.txtBlueprintPath.TabIndex = 22
        '
        'btnScanBlueprints
        '
        Me.btnScanBlueprints.Enabled = False
        Me.btnScanBlueprints.Location = New System.Drawing.Point(885, 31)
        Me.btnScanBlueprints.Name = "btnScanBlueprints"
        Me.btnScanBlueprints.Size = New System.Drawing.Size(112, 23)
        Me.btnScanBlueprints.TabIndex = 25
        Me.btnScanBlueprints.Text = "Scan Blueprint"
        Me.btnScanBlueprints.UseVisualStyleBackColor = True
        '
        'txtLog
        '
        Me.txtLog.Location = New System.Drawing.Point(1051, 12)
        Me.txtLog.Multiline = True
        Me.txtLog.Name = "txtLog"
        Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtLog.Size = New System.Drawing.Size(244, 354)
        Me.txtLog.TabIndex = 26
        '
        'chDefView
        '
        Me.chDefView.Text = "Def View"
        '
        'BlueprintInspector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1305, 420)
        Me.Controls.Add(Me.txtLog)
        Me.Controls.Add(Me.btnScanBlueprints)
        Me.Controls.Add(Me.btnBrowseForBlueprintDirectory)
        Me.Controls.Add(Me.lblBlueprintPath)
        Me.Controls.Add(Me.txtBlueprintPath)
        Me.Controls.Add(Me.lvDefList)
        Me.Name = "BlueprintInspector"
        Me.Text = "Blueprint Inspector"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lvDefList As ListView
    Friend WithEvents chDefType As ColumnHeader
    Friend WithEvents chAssociation As ColumnHeader
    Friend WithEvents chDefName As ColumnHeader
    Friend WithEvents chDefAlias As ColumnHeader
    Friend WithEvents chScope As ColumnHeader
    Friend WithEvents chDescription As ColumnHeader
    Friend WithEvents chDefID As ColumnHeader
    Friend WithEvents btnBrowseForBlueprintDirectory As Button
    Friend WithEvents lblBlueprintPath As Label
    Friend WithEvents txtBlueprintPath As TextBox
    Friend WithEvents dlgResultsSaveDialog As SaveFileDialog
    Friend WithEvents ofdFileSelector As OpenFileDialog
    Friend WithEvents btnScanBlueprints As Button
    Friend WithEvents txtLog As TextBox
    Friend WithEvents chDefView As ColumnHeader
End Class
