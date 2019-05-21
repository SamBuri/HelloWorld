
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompanies : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCompanies))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbCompanyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbContactPerson = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpContractStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpContractEndDate = New System.Windows.Forms.DateTimePicker()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblCompanyNo = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.lblContactPerson = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblContractStartDate = New System.Windows.Forms.Label()
        Me.lblContractEndDate = New System.Windows.Forms.Label()
        Me.cboCompanyNo = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 218)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 14
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(263, 218)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 15
        Me.fbnDelete.Tag = "Companies"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 245)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 16
        Me.ebnSaveUpdate.Tag = "Companies"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbCompanyName
        '
        Me.stbCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCompanyName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbCompanyName, "CompanyName")
        Me.stbCompanyName.EntryErrorMSG = ""
        Me.stbCompanyName.Location = New System.Drawing.Point(170, 26)
        Me.stbCompanyName.MaxLength = 60
        Me.stbCompanyName.Name = "stbCompanyName"
        Me.stbCompanyName.RegularExpression = ""
        Me.stbCompanyName.Size = New System.Drawing.Size(165, 20)
        Me.stbCompanyName.TabIndex = 3
        '
        'stbContactPerson
        '
        Me.stbContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbContactPerson.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbContactPerson, "ContactPerson")
        Me.stbContactPerson.EntryErrorMSG = ""
        Me.stbContactPerson.Location = New System.Drawing.Point(170, 47)
        Me.stbContactPerson.MaxLength = 100
        Me.stbContactPerson.Name = "stbContactPerson"
        Me.stbContactPerson.RegularExpression = ""
        Me.stbContactPerson.Size = New System.Drawing.Size(165, 20)
        Me.stbContactPerson.TabIndex = 5
        '
        'stbAddress
        '
        Me.stbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAddress.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAddress, "Address")
        Me.stbAddress.EntryErrorMSG = ""
        Me.stbAddress.Location = New System.Drawing.Point(170, 109)
        Me.stbAddress.MaxLength = 200
        Me.stbAddress.Multiline = True
        Me.stbAddress.Name = "stbAddress"
        Me.stbAddress.RegularExpression = ""
        Me.stbAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAddress.Size = New System.Drawing.Size(165, 70)
        Me.stbAddress.TabIndex = 11
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhone, "Phone")
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(170, 180)
        Me.stbPhone.MaxLength = 30
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(165, 20)
        Me.stbPhone.TabIndex = 13
        '
        'dtpContractStartDate
        '
        Me.dtpContractStartDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpContractStartDate, "ContractStartDate")
        Me.dtpContractStartDate.Location = New System.Drawing.Point(170, 68)
        Me.dtpContractStartDate.Name = "dtpContractStartDate"
        Me.dtpContractStartDate.ShowCheckBox = True
        Me.dtpContractStartDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpContractStartDate.TabIndex = 7
        '
        'dtpContractEndDate
        '
        Me.dtpContractEndDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpContractEndDate, "ContractEndDate")
        Me.dtpContractEndDate.Location = New System.Drawing.Point(170, 89)
        Me.dtpContractEndDate.Name = "dtpContractEndDate"
        Me.dtpContractEndDate.ShowCheckBox = True
        Me.dtpContractEndDate.Size = New System.Drawing.Size(165, 20)
        Me.dtpContractEndDate.TabIndex = 9
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(263, 245)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 17
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblCompanyNo
        '
        Me.lblCompanyNo.Location = New System.Drawing.Point(12, 5)
        Me.lblCompanyNo.Name = "lblCompanyNo"
        Me.lblCompanyNo.Size = New System.Drawing.Size(107, 20)
        Me.lblCompanyNo.TabIndex = 0
        Me.lblCompanyNo.Text = "Company No"
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Location = New System.Drawing.Point(12, 26)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(107, 20)
        Me.lblCompanyName.TabIndex = 2
        Me.lblCompanyName.Text = "Company Name"
        '
        'lblContactPerson
        '
        Me.lblContactPerson.Location = New System.Drawing.Point(12, 47)
        Me.lblContactPerson.Name = "lblContactPerson"
        Me.lblContactPerson.Size = New System.Drawing.Size(107, 20)
        Me.lblContactPerson.TabIndex = 4
        Me.lblContactPerson.Text = "Contact Person"
        '
        'lblAddress
        '
        Me.lblAddress.Location = New System.Drawing.Point(12, 130)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(107, 20)
        Me.lblAddress.TabIndex = 10
        Me.lblAddress.Text = "Address"
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(12, 180)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(107, 20)
        Me.lblPhone.TabIndex = 12
        Me.lblPhone.Text = "Phone"
        '
        'lblContractStartDate
        '
        Me.lblContractStartDate.Location = New System.Drawing.Point(12, 68)
        Me.lblContractStartDate.Name = "lblContractStartDate"
        Me.lblContractStartDate.Size = New System.Drawing.Size(107, 20)
        Me.lblContractStartDate.TabIndex = 6
        Me.lblContractStartDate.Text = "Contract Start Date"
        '
        'lblContractEndDate
        '
        Me.lblContractEndDate.Location = New System.Drawing.Point(12, 89)
        Me.lblContractEndDate.Name = "lblContractEndDate"
        Me.lblContractEndDate.Size = New System.Drawing.Size(107, 20)
        Me.lblContractEndDate.TabIndex = 8
        Me.lblContractEndDate.Text = "Scheme End Date"
        '
        'cboCompanyNo
        '
        Me.cboCompanyNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCompanyNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCompanyNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboCompanyNo.DropDownWidth = 256
        Me.cboCompanyNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCompanyNo.FormattingEnabled = True
        Me.cboCompanyNo.ItemHeight = 13
        Me.cboCompanyNo.Location = New System.Drawing.Point(170, 5)
        Me.cboCompanyNo.Name = "cboCompanyNo"
        Me.cboCompanyNo.Size = New System.Drawing.Size(165, 21)
        Me.cboCompanyNo.TabIndex = 19
        '
        'frmCompanies
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(347, 280)
        Me.Controls.Add(Me.cboCompanyNo)
        Me.Controls.Add(Me.dtpContractStartDate)
        Me.Controls.Add(Me.lblContractStartDate)
        Me.Controls.Add(Me.dtpContractEndDate)
        Me.Controls.Add(Me.lblContractEndDate)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblCompanyNo)
        Me.Controls.Add(Me.stbCompanyName)
        Me.Controls.Add(Me.lblCompanyName)
        Me.Controls.Add(Me.stbContactPerson)
        Me.Controls.Add(Me.lblContactPerson)
        Me.Controls.Add(Me.stbAddress)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmCompanies"
        Me.Text = "Companies"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblCompanyNo As System.Windows.Forms.Label
    Friend WithEvents stbCompanyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents stbContactPerson As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblContactPerson As System.Windows.Forms.Label
    Friend WithEvents stbAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents dtpContractStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContractStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpContractEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblContractEndDate As System.Windows.Forms.Label
    Friend WithEvents cboCompanyNo As ComboBox
End Class