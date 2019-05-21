
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmINTAgents : Inherits System.Windows.Forms.Form

'Form overrides dispose to clean up the component list.
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
	If disposing AndAlso components IsNot Nothing Then
		components.Dispose()
	End If
	MyBase.Dispose(disposing)
End Sub

'Required by the Windows Form Designer
Private components As System.ComponentModel.IContainer

'NOTE: The following procedure is required by the Windows Form Designer
'It can be modified using the Windows Form Designer.
'Do not modify it using the code editor.
<System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmINTAgents))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbAgentName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboConnectionModeID = New System.Windows.Forms.ComboBox()
        Me.cboDatabaseTypeID = New System.Windows.Forms.ComboBox()
        Me.stbDataSource = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbDBName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPassword = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAgentNo = New System.Windows.Forms.ComboBox()
        Me.stbUsername = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxPort = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblAgentNo = New System.Windows.Forms.Label()
        Me.lblAgentName = New System.Windows.Forms.Label()
        Me.lblConnectionModeID = New System.Windows.Forms.Label()
        Me.lblDatabaseTypeID = New System.Windows.Forms.Label()
        Me.lblDataSource = New System.Windows.Forms.Label()
        Me.lblDBName = New System.Windows.Forms.Label()
        Me.lblPort = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 228)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(316, 228)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "INTAgents"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 255)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "INTAgents"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbAgentName
        '
        Me.stbAgentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAgentName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAgentName, "AgentName")
        Me.stbAgentName.EntryErrorMSG = ""
        Me.stbAgentName.Location = New System.Drawing.Point(218, 35)
        Me.stbAgentName.Name = "stbAgentName"
        Me.stbAgentName.RegularExpression = ""
        Me.stbAgentName.Size = New System.Drawing.Size(170, 20)
        Me.stbAgentName.TabIndex = 6
        '
        'cboConnectionModeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboConnectionModeID, "ConnectionMode,ConnectionModeID")
        Me.cboConnectionModeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConnectionModeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboConnectionModeID.Location = New System.Drawing.Point(218, 58)
        Me.cboConnectionModeID.Name = "cboConnectionModeID"
        Me.cboConnectionModeID.Size = New System.Drawing.Size(170, 21)
        Me.cboConnectionModeID.TabIndex = 8
        '
        'cboDatabaseTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDatabaseTypeID, "DatabaseType,DatabaseTypeID")
        Me.cboDatabaseTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDatabaseTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDatabaseTypeID.Location = New System.Drawing.Point(218, 81)
        Me.cboDatabaseTypeID.Name = "cboDatabaseTypeID"
        Me.cboDatabaseTypeID.Size = New System.Drawing.Size(170, 21)
        Me.cboDatabaseTypeID.TabIndex = 10
        '
        'stbDataSource
        '
        Me.stbDataSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDataSource.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDataSource, "DataSource")
        Me.stbDataSource.EntryErrorMSG = ""
        Me.stbDataSource.Location = New System.Drawing.Point(218, 104)
        Me.stbDataSource.Name = "stbDataSource"
        Me.stbDataSource.RegularExpression = ""
        Me.stbDataSource.Size = New System.Drawing.Size(170, 20)
        Me.stbDataSource.TabIndex = 12
        '
        'stbDBName
        '
        Me.stbDBName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDBName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDBName, "DBName")
        Me.stbDBName.EntryErrorMSG = ""
        Me.stbDBName.Location = New System.Drawing.Point(218, 127)
        Me.stbDBName.Name = "stbDBName"
        Me.stbDBName.RegularExpression = ""
        Me.stbDBName.Size = New System.Drawing.Size(170, 20)
        Me.stbDBName.TabIndex = 14
        '
        'stbPassword
        '
        Me.stbPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPassword.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPassword, "Password")
        Me.stbPassword.EntryErrorMSG = ""
        Me.stbPassword.Location = New System.Drawing.Point(218, 196)
        Me.stbPassword.Name = "stbPassword"
        Me.stbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(73)
        Me.stbPassword.RegularExpression = ""
        Me.stbPassword.Size = New System.Drawing.Size(170, 20)
        Me.stbPassword.TabIndex = 18
        '
        'cboAgentNo
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAgentNo, "DatabaseType,DatabaseTypeID")
        Me.cboAgentNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAgentNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAgentNo.Location = New System.Drawing.Point(218, 11)
        Me.cboAgentNo.Name = "cboAgentNo"
        Me.cboAgentNo.Size = New System.Drawing.Size(170, 21)
        Me.cboAgentNo.TabIndex = 20
        '
        'stbUsername
        '
        Me.stbUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbUsername.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbUsername, "Username")
        Me.stbUsername.EntryErrorMSG = ""
        Me.stbUsername.Location = New System.Drawing.Point(218, 172)
        Me.stbUsername.Name = "stbUsername"
        Me.stbUsername.RegularExpression = ""
        Me.stbUsername.Size = New System.Drawing.Size(170, 20)
        Me.stbUsername.TabIndex = 21
        '
        'nbxPort
        '
        Me.nbxPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxPort.ControlCaption = "Keeping Unit"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxPort, "Port")
        Me.nbxPort.DecimalPlaces = -1
        Me.nbxPort.Location = New System.Drawing.Point(218, 149)
        Me.nbxPort.MaxValue = 0.0R
        Me.nbxPort.MinValue = 0.0R
        Me.nbxPort.MustEnterNumeric = True
        Me.nbxPort.Name = "nbxPort"
        Me.nbxPort.Size = New System.Drawing.Size(170, 20)
        Me.nbxPort.TabIndex = 23
        Me.nbxPort.Value = ""
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 255)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblAgentNo
        '
        Me.lblAgentNo.Location = New System.Drawing.Point(12, 12)
        Me.lblAgentNo.Name = "lblAgentNo"
        Me.lblAgentNo.Size = New System.Drawing.Size(200, 20)
        Me.lblAgentNo.TabIndex = 5
        Me.lblAgentNo.Text = "Agent No"
        '
        'lblAgentName
        '
        Me.lblAgentName.Location = New System.Drawing.Point(12, 35)
        Me.lblAgentName.Name = "lblAgentName"
        Me.lblAgentName.Size = New System.Drawing.Size(200, 20)
        Me.lblAgentName.TabIndex = 7
        Me.lblAgentName.Text = "Agent Name"
        '
        'lblConnectionModeID
        '
        Me.lblConnectionModeID.Location = New System.Drawing.Point(12, 58)
        Me.lblConnectionModeID.Name = "lblConnectionModeID"
        Me.lblConnectionModeID.Size = New System.Drawing.Size(200, 20)
        Me.lblConnectionModeID.TabIndex = 9
        Me.lblConnectionModeID.Text = "Connection Mode"
        '
        'lblDatabaseTypeID
        '
        Me.lblDatabaseTypeID.Location = New System.Drawing.Point(12, 81)
        Me.lblDatabaseTypeID.Name = "lblDatabaseTypeID"
        Me.lblDatabaseTypeID.Size = New System.Drawing.Size(200, 20)
        Me.lblDatabaseTypeID.TabIndex = 11
        Me.lblDatabaseTypeID.Text = "Database Type"
        '
        'lblDataSource
        '
        Me.lblDataSource.Location = New System.Drawing.Point(12, 104)
        Me.lblDataSource.Name = "lblDataSource"
        Me.lblDataSource.Size = New System.Drawing.Size(200, 20)
        Me.lblDataSource.TabIndex = 13
        Me.lblDataSource.Text = "Data Source"
        '
        'lblDBName
        '
        Me.lblDBName.Location = New System.Drawing.Point(12, 127)
        Me.lblDBName.Name = "lblDBName"
        Me.lblDBName.Size = New System.Drawing.Size(200, 20)
        Me.lblDBName.TabIndex = 15
        Me.lblDBName.Text = "DB Name"
        '
        'lblPort
        '
        Me.lblPort.Location = New System.Drawing.Point(12, 150)
        Me.lblPort.Name = "lblPort"
        Me.lblPort.Size = New System.Drawing.Size(200, 20)
        Me.lblPort.TabIndex = 17
        Me.lblPort.Text = "Port"
        '
        'lblPassword
        '
        Me.lblPassword.Location = New System.Drawing.Point(12, 196)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(200, 20)
        Me.lblPassword.TabIndex = 19
        Me.lblPassword.Text = "Password"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(12, 172)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 20)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Username"
        '
        'frmINTAgents
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(415, 300)
        Me.Controls.Add(Me.nbxPort)
        Me.Controls.Add(Me.stbUsername)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboAgentNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblAgentNo)
        Me.Controls.Add(Me.stbAgentName)
        Me.Controls.Add(Me.lblAgentName)
        Me.Controls.Add(Me.cboConnectionModeID)
        Me.Controls.Add(Me.lblConnectionModeID)
        Me.Controls.Add(Me.cboDatabaseTypeID)
        Me.Controls.Add(Me.lblDatabaseTypeID)
        Me.Controls.Add(Me.stbDataSource)
        Me.Controls.Add(Me.lblDataSource)
        Me.Controls.Add(Me.stbDBName)
        Me.Controls.Add(Me.lblDBName)
        Me.Controls.Add(Me.lblPort)
        Me.Controls.Add(Me.stbPassword)
        Me.Controls.Add(Me.lblPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmINTAgents"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "INTAgents"
        Me.Text = "INT Agents"
        Me.ResumeLayout(False)
        Me.PerformLayout()

End Sub

Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblAgentNo As System.Windows.Forms.Label
Friend WithEvents stbAgentName As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblAgentName As System.Windows.Forms.Label
Friend WithEvents cboConnectionModeID As System.Windows.Forms.ComboBox
Friend WithEvents lblConnectionModeID As System.Windows.Forms.Label
Friend WithEvents cboDatabaseTypeID As System.Windows.Forms.ComboBox
Friend WithEvents lblDatabaseTypeID As System.Windows.Forms.Label
Friend WithEvents stbDataSource As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblDataSource As System.Windows.Forms.Label
Friend WithEvents stbDBName As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblDBName As System.Windows.Forms.Label
    Friend WithEvents lblPort As System.Windows.Forms.Label
Friend WithEvents stbPassword As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents cboAgentNo As System.Windows.Forms.ComboBox
    Friend WithEvents stbUsername As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nbxPort As SyncSoft.Common.Win.Controls.NumericBox

End Class