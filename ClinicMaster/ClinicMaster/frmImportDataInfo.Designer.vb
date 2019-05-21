
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportDataInfo : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportDataInfo))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboDatabaseTypeID = New System.Windows.Forms.ComboBox()
        Me.cboConnectionModeID = New System.Windows.Forms.ComboBox()
        Me.stbImportServer = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbImportLogin = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSP_Name = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbItemCode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSourceCaption = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbImportPassword = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbSourceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSourceName = New System.Windows.Forms.Label()
        Me.lblItemCode = New System.Windows.Forms.Label()
        Me.lblDatabaseTypeID = New System.Windows.Forms.Label()
        Me.lblConnectionModeID = New System.Windows.Forms.Label()
        Me.lblImportServer = New System.Windows.Forms.Label()
        Me.lblSourceCaption = New System.Windows.Forms.Label()
        Me.lblImportLogin = New System.Windows.Forms.Label()
        Me.lblImportPassword = New System.Windows.Forms.Label()
        Me.lblSP_Name = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 200)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 18
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(274, 200)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 19
        Me.fbnDelete.Tag = "ImportDataInfo"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 227)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 20
        Me.ebnSaveUpdate.Tag = "ImportDataInfo"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboDatabaseTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDatabaseTypeID, "DatabaseType,DatabaseTypeID")
        Me.cboDatabaseTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDatabaseTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDatabaseTypeID.Location = New System.Drawing.Point(139, 67)
        Me.cboDatabaseTypeID.Name = "cboDatabaseTypeID"
        Me.cboDatabaseTypeID.Size = New System.Drawing.Size(207, 21)
        Me.cboDatabaseTypeID.TabIndex = 7
        '
        'cboConnectionModeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboConnectionModeID, "ConnectionMode,ConnectionModeID")
        Me.cboConnectionModeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboConnectionModeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboConnectionModeID.Location = New System.Drawing.Point(139, 89)
        Me.cboConnectionModeID.Name = "cboConnectionModeID"
        Me.cboConnectionModeID.Size = New System.Drawing.Size(207, 21)
        Me.cboConnectionModeID.TabIndex = 9
        '
        'stbImportServer
        '
        Me.stbImportServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbImportServer.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbImportServer, "ImportServer")
        Me.stbImportServer.EntryErrorMSG = ""
        Me.stbImportServer.Location = New System.Drawing.Point(139, 111)
        Me.stbImportServer.MaxLength = 100
        Me.stbImportServer.Name = "stbImportServer"
        Me.stbImportServer.RegularExpression = ""
        Me.stbImportServer.Size = New System.Drawing.Size(207, 20)
        Me.stbImportServer.TabIndex = 11
        '
        'stbImportLogin
        '
        Me.stbImportLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbImportLogin.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbImportLogin, "ImportLogin")
        Me.stbImportLogin.EntryErrorMSG = ""
        Me.stbImportLogin.Location = New System.Drawing.Point(139, 132)
        Me.stbImportLogin.MaxLength = 100
        Me.stbImportLogin.Name = "stbImportLogin"
        Me.stbImportLogin.RegularExpression = ""
        Me.stbImportLogin.Size = New System.Drawing.Size(207, 20)
        Me.stbImportLogin.TabIndex = 13
        '
        'stbSP_Name
        '
        Me.stbSP_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSP_Name.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbSP_Name, "SP_Name")
        Me.stbSP_Name.EntryErrorMSG = ""
        Me.stbSP_Name.Location = New System.Drawing.Point(139, 174)
        Me.stbSP_Name.MaxLength = 100
        Me.stbSP_Name.Name = "stbSP_Name"
        Me.stbSP_Name.RegularExpression = ""
        Me.stbSP_Name.Size = New System.Drawing.Size(207, 20)
        Me.stbSP_Name.TabIndex = 17
        '
        'stbItemCode
        '
        Me.stbItemCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbItemCode.CapitalizeFirstLetter = False
        Me.stbItemCode.EntryErrorMSG = ""
        Me.stbItemCode.Location = New System.Drawing.Point(139, 3)
        Me.stbItemCode.MaxLength = 20
        Me.stbItemCode.Name = "stbItemCode"
        Me.stbItemCode.RegularExpression = ""
        Me.stbItemCode.Size = New System.Drawing.Size(207, 20)
        Me.stbItemCode.TabIndex = 1
        '
        'stbSourceCaption
        '
        Me.stbSourceCaption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSourceCaption.CapitalizeFirstLetter = False
        Me.stbSourceCaption.EntryErrorMSG = ""
        Me.stbSourceCaption.Location = New System.Drawing.Point(139, 45)
        Me.stbSourceCaption.MaxLength = 100
        Me.stbSourceCaption.Name = "stbSourceCaption"
        Me.stbSourceCaption.RegularExpression = ""
        Me.stbSourceCaption.Size = New System.Drawing.Size(207, 20)
        Me.stbSourceCaption.TabIndex = 5
        '
        'stbImportPassword
        '
        Me.stbImportPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbImportPassword.CapitalizeFirstLetter = False
        Me.stbImportPassword.EntryErrorMSG = ""
        Me.stbImportPassword.Location = New System.Drawing.Point(139, 153)
        Me.stbImportPassword.MaxLength = 100
        Me.stbImportPassword.Name = "stbImportPassword"
        Me.stbImportPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(124)
        Me.stbImportPassword.RegularExpression = ""
        Me.stbImportPassword.Size = New System.Drawing.Size(207, 20)
        Me.stbImportPassword.TabIndex = 15
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(274, 227)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 21
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbSourceName
        '
        Me.stbSourceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSourceName.CapitalizeFirstLetter = False
        Me.stbSourceName.EntryErrorMSG = ""
        Me.stbSourceName.Location = New System.Drawing.Point(139, 24)
        Me.stbSourceName.MaxLength = 60
        Me.stbSourceName.Name = "stbSourceName"
        Me.stbSourceName.RegularExpression = ""
        Me.stbSourceName.Size = New System.Drawing.Size(207, 20)
        Me.stbSourceName.TabIndex = 3
        '
        'lblSourceName
        '
        Me.lblSourceName.Location = New System.Drawing.Point(12, 24)
        Me.lblSourceName.Name = "lblSourceName"
        Me.lblSourceName.Size = New System.Drawing.Size(121, 20)
        Me.lblSourceName.TabIndex = 2
        Me.lblSourceName.Text = "Source Name"
        '
        'lblItemCode
        '
        Me.lblItemCode.Location = New System.Drawing.Point(12, 3)
        Me.lblItemCode.Name = "lblItemCode"
        Me.lblItemCode.Size = New System.Drawing.Size(121, 20)
        Me.lblItemCode.TabIndex = 0
        Me.lblItemCode.Text = "Item Code"
        '
        'lblDatabaseTypeID
        '
        Me.lblDatabaseTypeID.Location = New System.Drawing.Point(12, 67)
        Me.lblDatabaseTypeID.Name = "lblDatabaseTypeID"
        Me.lblDatabaseTypeID.Size = New System.Drawing.Size(121, 20)
        Me.lblDatabaseTypeID.TabIndex = 6
        Me.lblDatabaseTypeID.Text = "Database Type"
        '
        'lblConnectionModeID
        '
        Me.lblConnectionModeID.Location = New System.Drawing.Point(12, 89)
        Me.lblConnectionModeID.Name = "lblConnectionModeID"
        Me.lblConnectionModeID.Size = New System.Drawing.Size(121, 20)
        Me.lblConnectionModeID.TabIndex = 8
        Me.lblConnectionModeID.Text = "Connection Mode"
        '
        'lblImportServer
        '
        Me.lblImportServer.Location = New System.Drawing.Point(12, 111)
        Me.lblImportServer.Name = "lblImportServer"
        Me.lblImportServer.Size = New System.Drawing.Size(121, 20)
        Me.lblImportServer.TabIndex = 10
        Me.lblImportServer.Text = "Import Server"
        '
        'lblSourceCaption
        '
        Me.lblSourceCaption.Location = New System.Drawing.Point(12, 45)
        Me.lblSourceCaption.Name = "lblSourceCaption"
        Me.lblSourceCaption.Size = New System.Drawing.Size(121, 20)
        Me.lblSourceCaption.TabIndex = 4
        Me.lblSourceCaption.Text = "Source Caption"
        '
        'lblImportLogin
        '
        Me.lblImportLogin.Location = New System.Drawing.Point(12, 132)
        Me.lblImportLogin.Name = "lblImportLogin"
        Me.lblImportLogin.Size = New System.Drawing.Size(121, 20)
        Me.lblImportLogin.TabIndex = 12
        Me.lblImportLogin.Text = "Import Login"
        '
        'lblImportPassword
        '
        Me.lblImportPassword.Location = New System.Drawing.Point(12, 153)
        Me.lblImportPassword.Name = "lblImportPassword"
        Me.lblImportPassword.Size = New System.Drawing.Size(121, 20)
        Me.lblImportPassword.TabIndex = 14
        Me.lblImportPassword.Text = "Import Password"
        '
        'lblSP_Name
        '
        Me.lblSP_Name.Location = New System.Drawing.Point(12, 174)
        Me.lblSP_Name.Name = "lblSP_Name"
        Me.lblSP_Name.Size = New System.Drawing.Size(121, 20)
        Me.lblSP_Name.TabIndex = 16
        Me.lblSP_Name.Text = "SP Name"
        '
        'frmImportDataInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(364, 268)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbSourceName)
        Me.Controls.Add(Me.lblSourceName)
        Me.Controls.Add(Me.stbItemCode)
        Me.Controls.Add(Me.lblItemCode)
        Me.Controls.Add(Me.cboDatabaseTypeID)
        Me.Controls.Add(Me.lblDatabaseTypeID)
        Me.Controls.Add(Me.cboConnectionModeID)
        Me.Controls.Add(Me.lblConnectionModeID)
        Me.Controls.Add(Me.stbImportServer)
        Me.Controls.Add(Me.lblImportServer)
        Me.Controls.Add(Me.stbSourceCaption)
        Me.Controls.Add(Me.lblSourceCaption)
        Me.Controls.Add(Me.stbImportLogin)
        Me.Controls.Add(Me.lblImportLogin)
        Me.Controls.Add(Me.stbImportPassword)
        Me.Controls.Add(Me.lblImportPassword)
        Me.Controls.Add(Me.stbSP_Name)
        Me.Controls.Add(Me.lblSP_Name)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmImportDataInfo"
        Me.Text = "Import Data Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbSourceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSourceName As System.Windows.Forms.Label
    Friend WithEvents stbItemCode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblItemCode As System.Windows.Forms.Label
    Friend WithEvents cboDatabaseTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDatabaseTypeID As System.Windows.Forms.Label
    Friend WithEvents cboConnectionModeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblConnectionModeID As System.Windows.Forms.Label
    Friend WithEvents stbImportServer As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblImportServer As System.Windows.Forms.Label
    Friend WithEvents stbSourceCaption As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSourceCaption As System.Windows.Forms.Label
Friend WithEvents stbImportLogin As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblImportLogin As System.Windows.Forms.Label
Friend WithEvents stbImportPassword As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblImportPassword As System.Windows.Forms.Label
Friend WithEvents stbSP_Name As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblSP_Name As System.Windows.Forms.Label

End Class