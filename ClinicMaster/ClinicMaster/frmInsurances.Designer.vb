
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsurances : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInsurances))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbContactPerson = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.spbLogoPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbFax = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbEmail = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbWebsite = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMemberDeclaration = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbDoctorDeclaration = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkUseCustomFee = New System.Windows.Forms.CheckBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblInsuranceNo = New System.Windows.Forms.Label()
        Me.lblInsuranceName = New System.Windows.Forms.Label()
        Me.lblContactPerson = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.btnClearLogoPhoto = New System.Windows.Forms.Button()
        Me.btnLoadLogoPhoto = New System.Windows.Forms.Button()
        Me.lblLogoPhoto = New System.Windows.Forms.Label()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblWebsite = New System.Windows.Forms.Label()
        Me.lblMemberDeclaration = New System.Windows.Forms.Label()
        Me.lblDoctorDeclaration = New System.Windows.Forms.Label()
        Me.tbcInsuranceExcludedItems = New System.Windows.Forms.TabControl()
        Me.tpgInsuranceExcludedServices = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceExcludedServices = New System.Windows.Forms.DataGridView()
        Me.colServiceCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceExcludedServicesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgInsuranceExcludedDrugs = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceExcludedDrugs = New System.Windows.Forms.DataGridView()
        Me.colDrugNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceExcludedDrugsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgInsuranceExcludedLabTests = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceExcludedLabTests = New System.Windows.Forms.DataGridView()
        Me.colTestCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceExcludedLabTestsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgInsuranceExcludedRadiology = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceExcludedRadiology = New System.Windows.Forms.DataGridView()
        Me.colExamCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceExcludedRadiologySaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgInsuranceExcludedProcedures = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceExcludedProcedures = New System.Windows.Forms.DataGridView()
        Me.colProcedureCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceExcludedProceduresSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cboInsuranceNo = New System.Windows.Forms.ComboBox()
        CType(Me.spbLogoPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcInsuranceExcludedItems.SuspendLayout()
        Me.tpgInsuranceExcludedServices.SuspendLayout()
        CType(Me.dgvInsuranceExcludedServices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInsuranceExcludedDrugs.SuspendLayout()
        CType(Me.dgvInsuranceExcludedDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInsuranceExcludedLabTests.SuspendLayout()
        CType(Me.dgvInsuranceExcludedLabTests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInsuranceExcludedRadiology.SuspendLayout()
        CType(Me.dgvInsuranceExcludedRadiology, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInsuranceExcludedProcedures.SuspendLayout()
        CType(Me.dgvInsuranceExcludedProcedures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 453)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 25
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(682, 452)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 26
        Me.fbnDelete.Tag = "Insurances"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 480)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 27
        Me.ebnSaveUpdate.Tag = "Insurances"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(151, 27)
        Me.stbInsuranceName.MaxLength = 60
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.Size = New System.Drawing.Size(180, 20)
        Me.stbInsuranceName.TabIndex = 3
        '
        'stbContactPerson
        '
        Me.stbContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbContactPerson.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbContactPerson, "ContactPerson")
        Me.stbContactPerson.EntryErrorMSG = ""
        Me.stbContactPerson.Location = New System.Drawing.Point(151, 48)
        Me.stbContactPerson.MaxLength = 40
        Me.stbContactPerson.Name = "stbContactPerson"
        Me.stbContactPerson.RegularExpression = ""
        Me.stbContactPerson.Size = New System.Drawing.Size(180, 20)
        Me.stbContactPerson.TabIndex = 5
        '
        'stbAddress
        '
        Me.stbAddress.AcceptsReturn = True
        Me.stbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAddress.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAddress, "Address")
        Me.stbAddress.EntryErrorMSG = ""
        Me.stbAddress.Location = New System.Drawing.Point(151, 69)
        Me.stbAddress.MaxLength = 100
        Me.stbAddress.Multiline = True
        Me.stbAddress.Name = "stbAddress"
        Me.stbAddress.RegularExpression = ""
        Me.stbAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAddress.Size = New System.Drawing.Size(180, 36)
        Me.stbAddress.TabIndex = 7
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhone, "Phone")
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(151, 106)
        Me.stbPhone.MaxLength = 100
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(180, 20)
        Me.stbPhone.TabIndex = 9
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHidden, "Hidden")
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(340, 213)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(131, 20)
        Me.chkHidden.TabIndex = 21
        Me.chkHidden.Text = "Hidden"
        '
        'spbLogoPhoto
        '
        Me.spbLogoPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.spbLogoPhoto, "LogoPhoto")
        Me.spbLogoPhoto.ImageSizeLimit = CType(500000, Long)
        Me.spbLogoPhoto.Location = New System.Drawing.Point(459, 48)
        Me.spbLogoPhoto.Name = "spbLogoPhoto"
        Me.spbLogoPhoto.ReadOnly = False
        Me.spbLogoPhoto.Size = New System.Drawing.Size(230, 136)
        Me.spbLogoPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbLogoPhoto.TabIndex = 52
        Me.spbLogoPhoto.TabStop = False
        '
        'stbFax
        '
        Me.stbFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFax.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFax, "Fax")
        Me.stbFax.EntryErrorMSG = ""
        Me.stbFax.Location = New System.Drawing.Point(151, 127)
        Me.stbFax.MaxLength = 100
        Me.stbFax.Name = "stbFax"
        Me.stbFax.RegularExpression = ""
        Me.stbFax.Size = New System.Drawing.Size(180, 20)
        Me.stbFax.TabIndex = 11
        '
        'stbEmail
        '
        Me.stbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEmail.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbEmail, "Email")
        Me.stbEmail.EntryErrorMSG = "Invalid e-mail address"
        Me.stbEmail.Location = New System.Drawing.Point(151, 148)
        Me.stbEmail.MaxLength = 100
        Me.stbEmail.Name = "stbEmail"
        Me.stbEmail.RegularExpression = ""
        Me.stbEmail.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Email
        Me.stbEmail.Size = New System.Drawing.Size(180, 20)
        Me.stbEmail.TabIndex = 13
        '
        'stbWebsite
        '
        Me.stbWebsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbWebsite.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbWebsite, "Website")
        Me.stbWebsite.EntryErrorMSG = "Invalid website address"
        Me.stbWebsite.Location = New System.Drawing.Point(151, 169)
        Me.stbWebsite.MaxLength = 100
        Me.stbWebsite.Name = "stbWebsite"
        Me.stbWebsite.RegularExpression = ""
        Me.stbWebsite.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Website
        Me.stbWebsite.Size = New System.Drawing.Size(180, 20)
        Me.stbWebsite.TabIndex = 15
        '
        'stbMemberDeclaration
        '
        Me.stbMemberDeclaration.AcceptsReturn = True
        Me.stbMemberDeclaration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberDeclaration.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMemberDeclaration, "MemberDeclaration")
        Me.stbMemberDeclaration.EntryErrorMSG = ""
        Me.stbMemberDeclaration.Location = New System.Drawing.Point(151, 190)
        Me.stbMemberDeclaration.MaxLength = 800
        Me.stbMemberDeclaration.Multiline = True
        Me.stbMemberDeclaration.Name = "stbMemberDeclaration"
        Me.stbMemberDeclaration.RegularExpression = ""
        Me.stbMemberDeclaration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMemberDeclaration.Size = New System.Drawing.Size(180, 48)
        Me.stbMemberDeclaration.TabIndex = 17
        '
        'stbDoctorDeclaration
        '
        Me.stbDoctorDeclaration.AcceptsReturn = True
        Me.stbDoctorDeclaration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDoctorDeclaration.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDoctorDeclaration, "DoctorDeclaration")
        Me.stbDoctorDeclaration.EntryErrorMSG = ""
        Me.stbDoctorDeclaration.Location = New System.Drawing.Point(459, 6)
        Me.stbDoctorDeclaration.MaxLength = 800
        Me.stbDoctorDeclaration.Multiline = True
        Me.stbDoctorDeclaration.Name = "stbDoctorDeclaration"
        Me.stbDoctorDeclaration.RegularExpression = ""
        Me.stbDoctorDeclaration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDoctorDeclaration.Size = New System.Drawing.Size(230, 41)
        Me.stbDoctorDeclaration.TabIndex = 19
        '
        'chkUseCustomFee
        '
        Me.chkUseCustomFee.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkUseCustomFee, "UseCustomFee")
        Me.chkUseCustomFee.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkUseCustomFee.Location = New System.Drawing.Point(340, 188)
        Me.chkUseCustomFee.Name = "chkUseCustomFee"
        Me.chkUseCustomFee.Size = New System.Drawing.Size(130, 20)
        Me.chkUseCustomFee.TabIndex = 20
        Me.chkUseCustomFee.Text = "Use Custom Fee"
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(682, 479)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 28
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblInsuranceNo
        '
        Me.lblInsuranceNo.Location = New System.Drawing.Point(12, 6)
        Me.lblInsuranceNo.Name = "lblInsuranceNo"
        Me.lblInsuranceNo.Size = New System.Drawing.Size(133, 20)
        Me.lblInsuranceNo.TabIndex = 0
        Me.lblInsuranceNo.Text = "Insurance No"
        '
        'lblInsuranceName
        '
        Me.lblInsuranceName.Location = New System.Drawing.Point(12, 27)
        Me.lblInsuranceName.Name = "lblInsuranceName"
        Me.lblInsuranceName.Size = New System.Drawing.Size(133, 20)
        Me.lblInsuranceName.TabIndex = 2
        Me.lblInsuranceName.Text = "Insurance Name"
        '
        'lblContactPerson
        '
        Me.lblContactPerson.Location = New System.Drawing.Point(12, 48)
        Me.lblContactPerson.Name = "lblContactPerson"
        Me.lblContactPerson.Size = New System.Drawing.Size(133, 20)
        Me.lblContactPerson.TabIndex = 4
        Me.lblContactPerson.Text = "Contact Person"
        '
        'lblAddress
        '
        Me.lblAddress.Location = New System.Drawing.Point(12, 77)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(133, 20)
        Me.lblAddress.TabIndex = 6
        Me.lblAddress.Text = "Address"
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(12, 106)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(133, 20)
        Me.lblPhone.TabIndex = 8
        Me.lblPhone.Text = "Phone"
        '
        'btnClearLogoPhoto
        '
        Me.btnClearLogoPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClearLogoPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearLogoPhoto.Location = New System.Drawing.Point(695, 159)
        Me.btnClearLogoPhoto.Name = "btnClearLogoPhoto"
        Me.btnClearLogoPhoto.Size = New System.Drawing.Size(59, 23)
        Me.btnClearLogoPhoto.TabIndex = 24
        Me.btnClearLogoPhoto.Text = "Clear"
        Me.btnClearLogoPhoto.UseVisualStyleBackColor = True
        '
        'btnLoadLogoPhoto
        '
        Me.btnLoadLogoPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadLogoPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadLogoPhoto.Location = New System.Drawing.Point(695, 53)
        Me.btnLoadLogoPhoto.Name = "btnLoadLogoPhoto"
        Me.btnLoadLogoPhoto.Size = New System.Drawing.Size(59, 23)
        Me.btnLoadLogoPhoto.TabIndex = 23
        Me.btnLoadLogoPhoto.Text = "Load..."
        Me.btnLoadLogoPhoto.UseVisualStyleBackColor = True
        '
        'lblLogoPhoto
        '
        Me.lblLogoPhoto.Location = New System.Drawing.Point(337, 108)
        Me.lblLogoPhoto.Name = "lblLogoPhoto"
        Me.lblLogoPhoto.Size = New System.Drawing.Size(116, 20)
        Me.lblLogoPhoto.TabIndex = 22
        Me.lblLogoPhoto.Text = "Logo"
        '
        'lblFax
        '
        Me.lblFax.Location = New System.Drawing.Point(12, 127)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(133, 20)
        Me.lblFax.TabIndex = 10
        Me.lblFax.Text = "Fax"
        '
        'lblEmail
        '
        Me.lblEmail.Location = New System.Drawing.Point(12, 148)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(133, 20)
        Me.lblEmail.TabIndex = 12
        Me.lblEmail.Text = "Email"
        '
        'lblWebsite
        '
        Me.lblWebsite.Location = New System.Drawing.Point(12, 169)
        Me.lblWebsite.Name = "lblWebsite"
        Me.lblWebsite.Size = New System.Drawing.Size(133, 20)
        Me.lblWebsite.TabIndex = 14
        Me.lblWebsite.Text = "Website"
        '
        'lblMemberDeclaration
        '
        Me.lblMemberDeclaration.Location = New System.Drawing.Point(12, 202)
        Me.lblMemberDeclaration.Name = "lblMemberDeclaration"
        Me.lblMemberDeclaration.Size = New System.Drawing.Size(133, 20)
        Me.lblMemberDeclaration.TabIndex = 16
        Me.lblMemberDeclaration.Text = "Member Declaration"
        '
        'lblDoctorDeclaration
        '
        Me.lblDoctorDeclaration.Location = New System.Drawing.Point(337, 9)
        Me.lblDoctorDeclaration.Name = "lblDoctorDeclaration"
        Me.lblDoctorDeclaration.Size = New System.Drawing.Size(116, 20)
        Me.lblDoctorDeclaration.TabIndex = 18
        Me.lblDoctorDeclaration.Text = "Doctor Declaration"
        '
        'tbcInsuranceExcludedItems
        '
        Me.tbcInsuranceExcludedItems.Controls.Add(Me.tpgInsuranceExcludedServices)
        Me.tbcInsuranceExcludedItems.Controls.Add(Me.tpgInsuranceExcludedDrugs)
        Me.tbcInsuranceExcludedItems.Controls.Add(Me.tpgInsuranceExcludedLabTests)
        Me.tbcInsuranceExcludedItems.Controls.Add(Me.tpgInsuranceExcludedRadiology)
        Me.tbcInsuranceExcludedItems.Controls.Add(Me.tpgInsuranceExcludedProcedures)
        Me.tbcInsuranceExcludedItems.HotTrack = True
        Me.tbcInsuranceExcludedItems.Location = New System.Drawing.Point(17, 244)
        Me.tbcInsuranceExcludedItems.Name = "tbcInsuranceExcludedItems"
        Me.tbcInsuranceExcludedItems.SelectedIndex = 0
        Me.tbcInsuranceExcludedItems.Size = New System.Drawing.Size(737, 202)
        Me.tbcInsuranceExcludedItems.TabIndex = 53
        '
        'tpgInsuranceExcludedServices
        '
        Me.tpgInsuranceExcludedServices.Controls.Add(Me.dgvInsuranceExcludedServices)
        Me.tpgInsuranceExcludedServices.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceExcludedServices.Name = "tpgInsuranceExcludedServices"
        Me.tpgInsuranceExcludedServices.Size = New System.Drawing.Size(729, 176)
        Me.tpgInsuranceExcludedServices.TabIndex = 2
        Me.tpgInsuranceExcludedServices.Tag = "InsuranceExcludedItems"
        Me.tpgInsuranceExcludedServices.Text = "Excluded Services"
        Me.tpgInsuranceExcludedServices.UseVisualStyleBackColor = True
        '
        'dgvInsuranceExcludedServices
        '
        Me.dgvInsuranceExcludedServices.AllowUserToOrderColumns = True
        Me.dgvInsuranceExcludedServices.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedServices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInsuranceExcludedServices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colServiceCode, Me.colInsuranceExcludedServicesSaved})
        Me.dgvInsuranceExcludedServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceExcludedServices.EnableHeadersVisualStyles = False
        Me.dgvInsuranceExcludedServices.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceExcludedServices.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceExcludedServices.Name = "dgvInsuranceExcludedServices"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedServices.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInsuranceExcludedServices.Size = New System.Drawing.Size(729, 176)
        Me.dgvInsuranceExcludedServices.TabIndex = 0
        Me.dgvInsuranceExcludedServices.Text = "DataGridView1"
        '
        'colServiceCode
        '
        Me.colServiceCode.DataPropertyName = "ItemCode"
        Me.colServiceCode.DisplayStyleForCurrentCellOnly = True
        Me.colServiceCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colServiceCode.HeaderText = "Service"
        Me.colServiceCode.Name = "colServiceCode"
        Me.colServiceCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colServiceCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colServiceCode.Width = 400
        '
        'colInsuranceExcludedServicesSaved
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = False
        Me.colInsuranceExcludedServicesSaved.DefaultCellStyle = DataGridViewCellStyle2
        Me.colInsuranceExcludedServicesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceExcludedServicesSaved.HeaderText = "Saved"
        Me.colInsuranceExcludedServicesSaved.Name = "colInsuranceExcludedServicesSaved"
        Me.colInsuranceExcludedServicesSaved.ReadOnly = True
        Me.colInsuranceExcludedServicesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceExcludedServicesSaved.Width = 50
        '
        'tpgInsuranceExcludedDrugs
        '
        Me.tpgInsuranceExcludedDrugs.Controls.Add(Me.dgvInsuranceExcludedDrugs)
        Me.tpgInsuranceExcludedDrugs.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceExcludedDrugs.Name = "tpgInsuranceExcludedDrugs"
        Me.tpgInsuranceExcludedDrugs.Size = New System.Drawing.Size(729, 176)
        Me.tpgInsuranceExcludedDrugs.TabIndex = 1
        Me.tpgInsuranceExcludedDrugs.Tag = "InsuranceExcludedItems"
        Me.tpgInsuranceExcludedDrugs.Text = "Excluded Drugs"
        Me.tpgInsuranceExcludedDrugs.UseVisualStyleBackColor = True
        '
        'dgvInsuranceExcludedDrugs
        '
        Me.dgvInsuranceExcludedDrugs.AllowUserToOrderColumns = True
        Me.dgvInsuranceExcludedDrugs.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedDrugs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvInsuranceExcludedDrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrugNo, Me.colInsuranceExcludedDrugsSaved})
        Me.dgvInsuranceExcludedDrugs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceExcludedDrugs.EnableHeadersVisualStyles = False
        Me.dgvInsuranceExcludedDrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceExcludedDrugs.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceExcludedDrugs.Name = "dgvInsuranceExcludedDrugs"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedDrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvInsuranceExcludedDrugs.Size = New System.Drawing.Size(729, 176)
        Me.dgvInsuranceExcludedDrugs.TabIndex = 19
        Me.dgvInsuranceExcludedDrugs.Text = "DataGridView1"
        '
        'colDrugNo
        '
        Me.colDrugNo.DataPropertyName = "ItemCode"
        Me.colDrugNo.DisplayStyleForCurrentCellOnly = True
        Me.colDrugNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrugNo.HeaderText = "Drug"
        Me.colDrugNo.Name = "colDrugNo"
        Me.colDrugNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDrugNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDrugNo.Width = 400
        '
        'colInsuranceExcludedDrugsSaved
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = False
        Me.colInsuranceExcludedDrugsSaved.DefaultCellStyle = DataGridViewCellStyle5
        Me.colInsuranceExcludedDrugsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceExcludedDrugsSaved.HeaderText = "Saved"
        Me.colInsuranceExcludedDrugsSaved.Name = "colInsuranceExcludedDrugsSaved"
        Me.colInsuranceExcludedDrugsSaved.ReadOnly = True
        Me.colInsuranceExcludedDrugsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceExcludedDrugsSaved.Width = 50
        '
        'tpgInsuranceExcludedLabTests
        '
        Me.tpgInsuranceExcludedLabTests.Controls.Add(Me.dgvInsuranceExcludedLabTests)
        Me.tpgInsuranceExcludedLabTests.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceExcludedLabTests.Name = "tpgInsuranceExcludedLabTests"
        Me.tpgInsuranceExcludedLabTests.Size = New System.Drawing.Size(729, 176)
        Me.tpgInsuranceExcludedLabTests.TabIndex = 3
        Me.tpgInsuranceExcludedLabTests.Tag = "InsuranceExcludedItems"
        Me.tpgInsuranceExcludedLabTests.Text = "Excluded Lab Tests"
        Me.tpgInsuranceExcludedLabTests.UseVisualStyleBackColor = True
        '
        'dgvInsuranceExcludedLabTests
        '
        Me.dgvInsuranceExcludedLabTests.AllowUserToOrderColumns = True
        Me.dgvInsuranceExcludedLabTests.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedLabTests.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvInsuranceExcludedLabTests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTestCode, Me.colInsuranceExcludedLabTestsSaved})
        Me.dgvInsuranceExcludedLabTests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceExcludedLabTests.EnableHeadersVisualStyles = False
        Me.dgvInsuranceExcludedLabTests.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceExcludedLabTests.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceExcludedLabTests.Name = "dgvInsuranceExcludedLabTests"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedLabTests.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvInsuranceExcludedLabTests.Size = New System.Drawing.Size(729, 176)
        Me.dgvInsuranceExcludedLabTests.TabIndex = 16
        Me.dgvInsuranceExcludedLabTests.Text = "DataGridView1"
        '
        'colTestCode
        '
        Me.colTestCode.DataPropertyName = "ItemCode"
        Me.colTestCode.DisplayStyleForCurrentCellOnly = True
        Me.colTestCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTestCode.HeaderText = "Lab Test"
        Me.colTestCode.Name = "colTestCode"
        Me.colTestCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTestCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTestCode.Width = 400
        '
        'colInsuranceExcludedLabTestsSaved
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = False
        Me.colInsuranceExcludedLabTestsSaved.DefaultCellStyle = DataGridViewCellStyle8
        Me.colInsuranceExcludedLabTestsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceExcludedLabTestsSaved.HeaderText = "Saved"
        Me.colInsuranceExcludedLabTestsSaved.Name = "colInsuranceExcludedLabTestsSaved"
        Me.colInsuranceExcludedLabTestsSaved.ReadOnly = True
        Me.colInsuranceExcludedLabTestsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceExcludedLabTestsSaved.Width = 50
        '
        'tpgInsuranceExcludedRadiology
        '
        Me.tpgInsuranceExcludedRadiology.Controls.Add(Me.dgvInsuranceExcludedRadiology)
        Me.tpgInsuranceExcludedRadiology.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceExcludedRadiology.Name = "tpgInsuranceExcludedRadiology"
        Me.tpgInsuranceExcludedRadiology.Size = New System.Drawing.Size(729, 176)
        Me.tpgInsuranceExcludedRadiology.TabIndex = 4
        Me.tpgInsuranceExcludedRadiology.Tag = "InsuranceExcludedItems"
        Me.tpgInsuranceExcludedRadiology.Text = "Excluded Radiology Examinations"
        Me.tpgInsuranceExcludedRadiology.UseVisualStyleBackColor = True
        '
        'dgvInsuranceExcludedRadiology
        '
        Me.dgvInsuranceExcludedRadiology.AllowUserToOrderColumns = True
        Me.dgvInsuranceExcludedRadiology.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedRadiology.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvInsuranceExcludedRadiology.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colExamCode, Me.colInsuranceExcludedRadiologySaved})
        Me.dgvInsuranceExcludedRadiology.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceExcludedRadiology.EnableHeadersVisualStyles = False
        Me.dgvInsuranceExcludedRadiology.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceExcludedRadiology.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceExcludedRadiology.Name = "dgvInsuranceExcludedRadiology"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedRadiology.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvInsuranceExcludedRadiology.Size = New System.Drawing.Size(729, 176)
        Me.dgvInsuranceExcludedRadiology.TabIndex = 21
        Me.dgvInsuranceExcludedRadiology.Text = "DataGridView1"
        '
        'colExamCode
        '
        Me.colExamCode.DataPropertyName = "ItemCode"
        Me.colExamCode.DisplayStyleForCurrentCellOnly = True
        Me.colExamCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExamCode.HeaderText = "Radiology Examination"
        Me.colExamCode.Name = "colExamCode"
        Me.colExamCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colExamCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colExamCode.Width = 400
        '
        'colInsuranceExcludedRadiologySaved
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.NullValue = False
        Me.colInsuranceExcludedRadiologySaved.DefaultCellStyle = DataGridViewCellStyle11
        Me.colInsuranceExcludedRadiologySaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceExcludedRadiologySaved.HeaderText = "Saved"
        Me.colInsuranceExcludedRadiologySaved.Name = "colInsuranceExcludedRadiologySaved"
        Me.colInsuranceExcludedRadiologySaved.ReadOnly = True
        Me.colInsuranceExcludedRadiologySaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceExcludedRadiologySaved.Width = 50
        '
        'tpgInsuranceExcludedProcedures
        '
        Me.tpgInsuranceExcludedProcedures.Controls.Add(Me.dgvInsuranceExcludedProcedures)
        Me.tpgInsuranceExcludedProcedures.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceExcludedProcedures.Name = "tpgInsuranceExcludedProcedures"
        Me.tpgInsuranceExcludedProcedures.Size = New System.Drawing.Size(729, 176)
        Me.tpgInsuranceExcludedProcedures.TabIndex = 5
        Me.tpgInsuranceExcludedProcedures.Tag = "InsuranceExcludedItems"
        Me.tpgInsuranceExcludedProcedures.Text = "Excluded Procedures"
        Me.tpgInsuranceExcludedProcedures.UseVisualStyleBackColor = True
        '
        'dgvInsuranceExcludedProcedures
        '
        Me.dgvInsuranceExcludedProcedures.AllowUserToOrderColumns = True
        Me.dgvInsuranceExcludedProcedures.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedProcedures.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvInsuranceExcludedProcedures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colProcedureCode, Me.colInsuranceExcludedProceduresSaved})
        Me.dgvInsuranceExcludedProcedures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceExcludedProcedures.EnableHeadersVisualStyles = False
        Me.dgvInsuranceExcludedProcedures.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceExcludedProcedures.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceExcludedProcedures.Name = "dgvInsuranceExcludedProcedures"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedProcedures.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvInsuranceExcludedProcedures.Size = New System.Drawing.Size(729, 176)
        Me.dgvInsuranceExcludedProcedures.TabIndex = 23
        Me.dgvInsuranceExcludedProcedures.Text = "DataGridView1"
        '
        'colProcedureCode
        '
        Me.colProcedureCode.DataPropertyName = "ItemCode"
        Me.colProcedureCode.DisplayStyleForCurrentCellOnly = True
        Me.colProcedureCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colProcedureCode.HeaderText = "Procedure"
        Me.colProcedureCode.Name = "colProcedureCode"
        Me.colProcedureCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colProcedureCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colProcedureCode.Width = 400
        '
        'colInsuranceExcludedProceduresSaved
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle14.NullValue = False
        Me.colInsuranceExcludedProceduresSaved.DefaultCellStyle = DataGridViewCellStyle14
        Me.colInsuranceExcludedProceduresSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceExcludedProceduresSaved.HeaderText = "Saved"
        Me.colInsuranceExcludedProceduresSaved.Name = "colInsuranceExcludedProceduresSaved"
        Me.colInsuranceExcludedProceduresSaved.ReadOnly = True
        Me.colInsuranceExcludedProceduresSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceExcludedProceduresSaved.Width = 50
        '
        'cboInsuranceNo
        '
        Me.cboInsuranceNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInsuranceNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInsuranceNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboInsuranceNo.DropDownWidth = 256
        Me.cboInsuranceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboInsuranceNo.FormattingEnabled = True
        Me.cboInsuranceNo.ItemHeight = 13
        Me.cboInsuranceNo.Location = New System.Drawing.Point(151, 0)
        Me.cboInsuranceNo.Name = "cboInsuranceNo"
        Me.cboInsuranceNo.Size = New System.Drawing.Size(180, 21)
        Me.cboInsuranceNo.TabIndex = 55
        '
        'frmInsurances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(771, 519)
        Me.Controls.Add(Me.cboInsuranceNo)
        Me.Controls.Add(Me.tbcInsuranceExcludedItems)
        Me.Controls.Add(Me.chkUseCustomFee)
        Me.Controls.Add(Me.stbDoctorDeclaration)
        Me.Controls.Add(Me.lblDoctorDeclaration)
        Me.Controls.Add(Me.stbMemberDeclaration)
        Me.Controls.Add(Me.lblMemberDeclaration)
        Me.Controls.Add(Me.stbFax)
        Me.Controls.Add(Me.lblFax)
        Me.Controls.Add(Me.stbEmail)
        Me.Controls.Add(Me.lblEmail)
        Me.Controls.Add(Me.stbWebsite)
        Me.Controls.Add(Me.lblWebsite)
        Me.Controls.Add(Me.btnClearLogoPhoto)
        Me.Controls.Add(Me.btnLoadLogoPhoto)
        Me.Controls.Add(Me.spbLogoPhoto)
        Me.Controls.Add(Me.lblLogoPhoto)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblInsuranceNo)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblInsuranceName)
        Me.Controls.Add(Me.stbContactPerson)
        Me.Controls.Add(Me.lblContactPerson)
        Me.Controls.Add(Me.stbAddress)
        Me.Controls.Add(Me.lblAddress)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.chkHidden)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmInsurances"
        Me.Text = "Insurances"
        CType(Me.spbLogoPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcInsuranceExcludedItems.ResumeLayout(False)
        Me.tpgInsuranceExcludedServices.ResumeLayout(False)
        CType(Me.dgvInsuranceExcludedServices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInsuranceExcludedDrugs.ResumeLayout(False)
        CType(Me.dgvInsuranceExcludedDrugs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInsuranceExcludedLabTests.ResumeLayout(False)
        CType(Me.dgvInsuranceExcludedLabTests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInsuranceExcludedRadiology.ResumeLayout(False)
        CType(Me.dgvInsuranceExcludedRadiology, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInsuranceExcludedProcedures.ResumeLayout(False)
        CType(Me.dgvInsuranceExcludedProcedures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblInsuranceNo As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbContactPerson As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblContactPerson As System.Windows.Forms.Label
    Friend WithEvents stbAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents btnClearLogoPhoto As System.Windows.Forms.Button
    Friend WithEvents btnLoadLogoPhoto As System.Windows.Forms.Button
    Friend WithEvents spbLogoPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblLogoPhoto As System.Windows.Forms.Label
    Friend WithEvents stbFax As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents stbEmail As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents stbWebsite As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblWebsite As System.Windows.Forms.Label
    Friend WithEvents stbMemberDeclaration As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberDeclaration As System.Windows.Forms.Label
    Friend WithEvents stbDoctorDeclaration As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDoctorDeclaration As System.Windows.Forms.Label
    Friend WithEvents chkUseCustomFee As System.Windows.Forms.CheckBox
    Friend WithEvents tbcInsuranceExcludedItems As System.Windows.Forms.TabControl
    Friend WithEvents tpgInsuranceExcludedServices As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceExcludedServices As System.Windows.Forms.DataGridView
    Friend WithEvents colServiceCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceExcludedServicesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgInsuranceExcludedDrugs As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceExcludedDrugs As System.Windows.Forms.DataGridView
    Friend WithEvents colDrugNo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceExcludedDrugsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgInsuranceExcludedLabTests As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceExcludedLabTests As System.Windows.Forms.DataGridView
    Friend WithEvents colTestCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceExcludedLabTestsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgInsuranceExcludedRadiology As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceExcludedRadiology As System.Windows.Forms.DataGridView
    Friend WithEvents colExamCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceExcludedRadiologySaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgInsuranceExcludedProcedures As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceExcludedProcedures As System.Windows.Forms.DataGridView
    Friend WithEvents colProcedureCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceExcludedProceduresSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboInsuranceNo As ComboBox
End Class