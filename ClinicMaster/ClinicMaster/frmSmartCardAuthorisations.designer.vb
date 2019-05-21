
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmartCardAuthorisations : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSmartCardAuthorisations))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbAuthorisedBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAuthorisationReason = New System.Windows.Forms.ComboBox()
        Me.stbClaimReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboBillNo = New System.Windows.Forms.ComboBox()
        Me.cboBillModesID = New System.Windows.Forms.ComboBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.dtpToVisitDate = New System.Windows.Forms.DateTimePicker()
        Me.lblToVisitDate = New System.Windows.Forms.Label()
        Me.lblAuthorisedBy = New System.Windows.Forms.Label()
        Me.lblAuthorisationReason = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblClaimReferenceNo = New System.Windows.Forms.Label()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(20, 450)
        Me.fbnSearch.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(103, 28)
        Me.fbnSearch.TabIndex = 31
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(356, 450)
        Me.fbnDelete.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(103, 28)
        Me.fbnDelete.TabIndex = 32
        Me.fbnDelete.Tag = "SmartCardAuthorisations"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(20, 484)
        Me.ebnSaveUpdate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(103, 28)
        Me.ebnSaveUpdate.TabIndex = 33
        Me.ebnSaveUpdate.Tag = "SmartCardAuthorisations"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbAuthorisedBy
        '
        Me.stbAuthorisedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAuthorisedBy.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAuthorisedBy, "AuthorisedBy")
        Me.stbAuthorisedBy.EntryErrorMSG = ""
        Me.stbAuthorisedBy.Location = New System.Drawing.Point(231, 364)
        Me.stbAuthorisedBy.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbAuthorisedBy.MaxLength = 41
        Me.stbAuthorisedBy.Name = "stbAuthorisedBy"
        Me.stbAuthorisedBy.RegularExpression = ""
        Me.stbAuthorisedBy.Size = New System.Drawing.Size(227, 22)
        Me.stbAuthorisedBy.TabIndex = 26
        '
        'cboAuthorisationReason
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAuthorisationReason, "AuthorisationReasonDesc,AuthorisationReason")
        Me.cboAuthorisationReason.DisplayMember = "AuthorisationReason"
        Me.cboAuthorisationReason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAuthorisationReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAuthorisationReason.Location = New System.Drawing.Point(231, 390)
        Me.cboAuthorisationReason.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboAuthorisationReason.Name = "cboAuthorisationReason"
        Me.cboAuthorisationReason.Size = New System.Drawing.Size(227, 24)
        Me.cboAuthorisationReason.TabIndex = 28
        Me.cboAuthorisationReason.Tag = ""
        Me.cboAuthorisationReason.ValueMember = "AuthorisationReason"
        '
        'stbClaimReferenceNo
        '
        Me.stbClaimReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimReferenceNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbClaimReferenceNo, "ClaimReferenceNo")
        Me.stbClaimReferenceNo.EntryErrorMSG = ""
        Me.stbClaimReferenceNo.Location = New System.Drawing.Point(231, 418)
        Me.stbClaimReferenceNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbClaimReferenceNo.MaxLength = 30
        Me.stbClaimReferenceNo.Name = "stbClaimReferenceNo"
        Me.stbClaimReferenceNo.RegularExpression = ""
        Me.stbClaimReferenceNo.Size = New System.Drawing.Size(227, 22)
        Me.stbClaimReferenceNo.TabIndex = 30
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMemberCardNo, "MedicalCardNo")
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(231, 338)
        Me.stbMemberCardNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbMemberCardNo.MaxLength = 30
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(227, 22)
        Me.stbMemberCardNo.TabIndex = 24
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillCustomerName, "BillCustomerName")
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(231, 222)
        Me.stbBillCustomerName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(227, 44)
        Me.stbBillCustomerName.TabIndex = 18
        '
        'cboBillNo
        '
        Me.cboBillNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillNo.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboBillNo, "BillNo")
        Me.cboBillNo.DropDownWidth = 256
        Me.cboBillNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillNo.FormattingEnabled = True
        Me.cboBillNo.ItemHeight = 16
        Me.cboBillNo.Location = New System.Drawing.Point(231, 193)
        Me.cboBillNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboBillNo.Name = "cboBillNo"
        Me.cboBillNo.Size = New System.Drawing.Size(227, 24)
        Me.cboBillNo.TabIndex = 16
        '
        'cboBillModesID
        '
        Me.cboBillModesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillModesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboBillModesID, "BillMode,BillModesID")
        Me.cboBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillModesID.FormattingEnabled = True
        Me.cboBillModesID.ItemHeight = 16
        Me.cboBillModesID.Location = New System.Drawing.Point(231, 165)
        Me.cboBillModesID.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboBillModesID.Name = "cboBillModesID"
        Me.cboBillModesID.Size = New System.Drawing.Size(227, 24)
        Me.cboBillModesID.TabIndex = 14
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(231, 267)
        Me.stbInsuranceName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(227, 44)
        Me.stbInsuranceName.TabIndex = 20
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(231, 60)
        Me.stbGender.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbGender.MaxLength = 20
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.Size = New System.Drawing.Size(159, 22)
        Me.stbGender.TabIndex = 6
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(231, 86)
        Me.stbAge.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbAge.MaxLength = 20
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.Size = New System.Drawing.Size(159, 22)
        Me.stbAge.TabIndex = 8
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(231, 112)
        Me.stbJoinDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbJoinDate.MaxLength = 20
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.Size = New System.Drawing.Size(227, 22)
        Me.stbJoinDate.TabIndex = 10
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(356, 484)
        Me.fbnClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(103, 28)
        Me.fbnClose.TabIndex = 34
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(231, 9)
        Me.stbPatientNo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(159, 22)
        Me.stbPatientNo.TabIndex = 1
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(16, 11)
        Me.lblPatientNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(200, 25)
        Me.lblPatientNo.TabIndex = 0
        Me.lblPatientNo.Text = "Patient No"
        '
        'dtpToVisitDate
        '
        Me.dtpToVisitDate.Location = New System.Drawing.Point(231, 313)
        Me.dtpToVisitDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpToVisitDate.Name = "dtpToVisitDate"
        Me.dtpToVisitDate.ShowCheckBox = True
        Me.dtpToVisitDate.Size = New System.Drawing.Size(227, 22)
        Me.dtpToVisitDate.TabIndex = 22
        '
        'lblToVisitDate
        '
        Me.lblToVisitDate.Location = New System.Drawing.Point(16, 313)
        Me.lblToVisitDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblToVisitDate.Name = "lblToVisitDate"
        Me.lblToVisitDate.Size = New System.Drawing.Size(200, 25)
        Me.lblToVisitDate.TabIndex = 21
        Me.lblToVisitDate.Text = "To Visit Date"
        '
        'lblAuthorisedBy
        '
        Me.lblAuthorisedBy.Location = New System.Drawing.Point(16, 369)
        Me.lblAuthorisedBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAuthorisedBy.Name = "lblAuthorisedBy"
        Me.lblAuthorisedBy.Size = New System.Drawing.Size(200, 25)
        Me.lblAuthorisedBy.TabIndex = 25
        Me.lblAuthorisedBy.Text = "Authorised By"
        '
        'lblAuthorisationReason
        '
        Me.lblAuthorisationReason.Location = New System.Drawing.Point(16, 394)
        Me.lblAuthorisationReason.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAuthorisationReason.Name = "lblAuthorisationReason"
        Me.lblAuthorisationReason.Size = New System.Drawing.Size(200, 25)
        Me.lblAuthorisationReason.TabIndex = 27
        Me.lblAuthorisationReason.Text = "Authorisation Reason"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(397, 3)
        Me.btnLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(61, 30)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'lblGender
        '
        Me.lblGender.Location = New System.Drawing.Point(16, 60)
        Me.lblGender.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(200, 25)
        Me.lblGender.TabIndex = 5
        Me.lblGender.Text = "Gender"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(16, 87)
        Me.lblAge.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(200, 25)
        Me.lblAge.TabIndex = 7
        Me.lblAge.Text = "Age"
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.CapitalizeFirstLetter = False
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.EntryErrorMSG = ""
        Me.stbLastVisitDate.Location = New System.Drawing.Point(231, 138)
        Me.stbLastVisitDate.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.RegularExpression = ""
        Me.stbLastVisitDate.Size = New System.Drawing.Size(227, 22)
        Me.stbLastVisitDate.TabIndex = 12
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(16, 138)
        Me.lblLastVisitDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(200, 25)
        Me.lblLastVisitDate.TabIndex = 11
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(16, 113)
        Me.lblJoinDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(200, 25)
        Me.lblJoinDate.TabIndex = 9
        Me.lblJoinDate.Text = "Join Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(231, 34)
        Me.stbFullName.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(227, 22)
        Me.stbFullName.TabIndex = 4
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(16, 34)
        Me.lblFullName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(200, 25)
        Me.lblFullName.TabIndex = 3
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblClaimReferenceNo
        '
        Me.lblClaimReferenceNo.Location = New System.Drawing.Point(16, 418)
        Me.lblClaimReferenceNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblClaimReferenceNo.Name = "lblClaimReferenceNo"
        Me.lblClaimReferenceNo.Size = New System.Drawing.Size(200, 25)
        Me.lblClaimReferenceNo.TabIndex = 29
        Me.lblClaimReferenceNo.Text = "Claim Reference No"
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(16, 338)
        Me.lblMemberCardNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(200, 25)
        Me.lblMemberCardNo.TabIndex = 23
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(16, 231)
        Me.lblBillCustomerName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(200, 25)
        Me.lblBillCustomerName.TabIndex = 17
        Me.lblBillCustomerName.Text = "To-Bill Customer Name"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(16, 197)
        Me.lblBillNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(200, 25)
        Me.lblBillNo.TabIndex = 15
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(16, 169)
        Me.lblBillMode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(200, 25)
        Me.lblBillMode.TabIndex = 13
        Me.lblBillMode.Text = "To-Bill Mode"
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(16, 278)
        Me.lblBillInsuranceName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(200, 25)
        Me.lblBillInsuranceName.TabIndex = 19
        Me.lblBillInsuranceName.Text = "To-Bill Insurance Name"
        '
        'frmSmartCardAuthorisations
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(488, 532)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.cboBillNo)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.cboBillModesID)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.stbLastVisitDate)
        Me.Controls.Add(Me.lblLastVisitDate)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.dtpToVisitDate)
        Me.Controls.Add(Me.lblToVisitDate)
        Me.Controls.Add(Me.stbClaimReferenceNo)
        Me.Controls.Add(Me.lblClaimReferenceNo)
        Me.Controls.Add(Me.stbAuthorisedBy)
        Me.Controls.Add(Me.lblAuthorisedBy)
        Me.Controls.Add(Me.cboAuthorisationReason)
        Me.Controls.Add(Me.lblAuthorisationReason)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "frmSmartCardAuthorisations"
        Me.Tag = ""
        Me.Text = "Smart Card Authorisations"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents dtpToVisitDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblToVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbAuthorisedBy As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblAuthorisedBy As System.Windows.Forms.Label
Friend WithEvents cboAuthorisationReason As System.Windows.Forms.ComboBox
    Friend WithEvents lblAuthorisationReason As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents stbLastVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblClaimReferenceNo As System.Windows.Forms.Label
    Friend WithEvents stbClaimReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboBillNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents cboBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label

End Class