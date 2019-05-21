
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmVisits : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal keyNo As String, ByVal itemsKeyNo As ItemsKeyNo)
        MyClass.New()
        Me.defaultKeyNo = keyNo
        Me.visitsKeyNo = itemsKeyNo
    End Sub

    Public Sub New(ByVal currentVisit As CurrentVisit)
        MyClass.New()
        Me.oCurrentVisit = currentVisit
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisits))
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboBillNo = New System.Windows.Forms.ComboBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboBillModesID = New System.Windows.Forms.ComboBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.cboVisitCategoryID = New System.Windows.Forms.ComboBox()
        Me.dtpVisitDate = New System.Windows.Forms.DateTimePicker()
        Me.lblCategory = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbReferredBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblReferredBy = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.cboServiceCode = New System.Windows.Forms.ComboBox()
        Me.chkAccessCashServices = New System.Windows.Forms.CheckBox()
        Me.cboDoctorSpecialtyID = New System.Windows.Forms.ComboBox()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboCoPayTypeID = New System.Windows.Forms.ComboBox()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbClaimReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMainMemberName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAssociatedBillNo = New System.Windows.Forms.ComboBox()
        Me.cboVisitPriority = New System.Windows.Forms.ComboBox()
        Me.stbInsuranceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkSmartCardApplicable = New System.Windows.Forms.CheckBox()
        Me.stbCombination = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbTotalVisits = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboVisitStatusID = New System.Windows.Forms.ComboBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkHasPackage = New System.Windows.Forms.CheckBox()
        Me.nbxMemberLimitBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboPackageName = New System.Windows.Forms.ComboBox()
        Me.cboCommunityID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.nbxToBillServiceFee = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblStaffNo = New System.Windows.Forms.Label()
        Me.lblServiceCode = New System.Windows.Forms.Label()
        Me.lblServiceFee = New System.Windows.Forms.Label()
        Me.lblDoctorSpecialtyID = New System.Windows.Forms.Label()
        Me.btnFindPatientNo = New System.Windows.Forms.Button()
        Me.btnEditPatient = New System.Windows.Forms.Button()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.lblClaimReferenceNo = New System.Windows.Forms.Label()
        Me.lblMainMemberName = New System.Windows.Forms.Label()
        Me.lblAssociatedBillNo = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.pnlVisitsPriority = New System.Windows.Forms.Panel()
        Me.lblVisitPriority = New System.Windows.Forms.Label()
        Me.btnViewTodaysBirthdays = New System.Windows.Forms.Button()
        Me.lblAgeString = New System.Windows.Forms.Label()
        Me.lblInsuranceNo = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.btnViewTodayAppointments = New System.Windows.Forms.Button()
        Me.chkFingerprintCaptured = New System.Windows.Forms.CheckBox()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.lblOutstandingBalance = New System.Windows.Forms.Label()
        Me.lblTotalVisits = New System.Windows.Forms.Label()
        Me.lblCombination = New System.Windows.Forms.Label()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.pnlVisitStatus = New System.Windows.Forms.Panel()
        Me.lblVisitStatus = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.nbxCashAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCashAccountBalance = New System.Windows.Forms.Label()
        Me.lblMemberLimitBalance = New System.Windows.Forms.Label()
        Me.lblPackageName = New System.Windows.Forms.Label()
        Me.lblCommunityID = New System.Windows.Forms.Label()
        Me.pnlCommunity = New System.Windows.Forms.Panel()
        Me.ChkPrintFormFive = New System.Windows.Forms.CheckBox()
        Me.btnPrintForm5 = New System.Windows.Forms.Button()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVisitsPriority.SuspendLayout()
        Me.pnlVisitStatus.SuspendLayout()
        Me.pnlCommunity.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillCustomerName, "BillCustomerName")
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(173, 228)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(154, 34)
        Me.stbBillCustomerName.TabIndex = 24
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
        Me.cboBillNo.ItemHeight = 13
        Me.cboBillNo.Location = New System.Drawing.Point(173, 184)
        Me.cboBillNo.Name = "cboBillNo"
        Me.cboBillNo.Size = New System.Drawing.Size(154, 21)
        Me.cboBillNo.TabIndex = 20
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(10, 236)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(151, 20)
        Me.lblBillCustomerName.TabIndex = 23
        Me.lblBillCustomerName.Text = "To-Bill Customer Name"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(10, 187)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(151, 20)
        Me.lblBillNo.TabIndex = 19
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(173, 8)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(102, 20)
        Me.stbPatientNo.TabIndex = 2
        '
        'cboBillModesID
        '
        Me.cboBillModesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillModesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboBillModesID, "BillMode,BillModesID")
        Me.cboBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillModesID.FormattingEnabled = True
        Me.cboBillModesID.ItemHeight = 13
        Me.cboBillModesID.Location = New System.Drawing.Point(173, 161)
        Me.cboBillModesID.Name = "cboBillModesID"
        Me.cboBillModesID.Size = New System.Drawing.Size(154, 21)
        Me.cboBillModesID.TabIndex = 18
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(10, 164)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(151, 20)
        Me.lblBillMode.TabIndex = 17
        Me.lblBillMode.Text = "To-Bill Mode"
        '
        'cboVisitCategoryID
        '
        Me.cboVisitCategoryID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVisitCategoryID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboVisitCategoryID, "VisitCategory,VisitCategoryID")
        Me.cboVisitCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisitCategoryID.FormattingEnabled = True
        Me.cboVisitCategoryID.ItemHeight = 13
        Me.cboVisitCategoryID.Location = New System.Drawing.Point(173, 117)
        Me.cboVisitCategoryID.Name = "cboVisitCategoryID"
        Me.cboVisitCategoryID.Size = New System.Drawing.Size(154, 21)
        Me.cboVisitCategoryID.TabIndex = 14
        '
        'dtpVisitDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpVisitDate, "VisitDate")
        Me.dtpVisitDate.Location = New System.Drawing.Point(173, 50)
        Me.dtpVisitDate.Name = "dtpVisitDate"
        Me.dtpVisitDate.ShowCheckBox = True
        Me.dtpVisitDate.Size = New System.Drawing.Size(154, 20)
        Me.dtpVisitDate.TabIndex = 8
        '
        'lblCategory
        '
        Me.lblCategory.Location = New System.Drawing.Point(10, 118)
        Me.lblCategory.Name = "lblCategory"
        Me.lblCategory.Size = New System.Drawing.Size(151, 20)
        Me.lblCategory.TabIndex = 13
        Me.lblCategory.Text = "Category"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(10, 50)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(151, 20)
        Me.lblVisitDate.TabIndex = 7
        Me.lblVisitDate.Text = "Visit Date"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(10, 29)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(120, 20)
        Me.lblVisitNo.TabIndex = 4
        Me.lblVisitNo.Text = "Visit Number"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(10, 8)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(120, 20)
        Me.lblPatientNo.TabIndex = 0
        Me.lblPatientNo.Text = "Patient's Number"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(173, 29)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(154, 20)
        Me.stbVisitNo.TabIndex = 6
        '
        'stbReferredBy
        '
        Me.stbReferredBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferredBy.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReferredBy, "ReferredBy")
        Me.stbReferredBy.EntryErrorMSG = ""
        Me.stbReferredBy.Location = New System.Drawing.Point(173, 140)
        Me.stbReferredBy.MaxLength = 40
        Me.stbReferredBy.Name = "stbReferredBy"
        Me.stbReferredBy.ReadOnly = True
        Me.stbReferredBy.RegularExpression = ""
        Me.stbReferredBy.Size = New System.Drawing.Size(154, 20)
        Me.stbReferredBy.TabIndex = 16
        '
        'lblReferredBy
        '
        Me.lblReferredBy.Location = New System.Drawing.Point(10, 141)
        Me.lblReferredBy.Name = "lblReferredBy"
        Me.lblReferredBy.Size = New System.Drawing.Size(151, 20)
        Me.lblReferredBy.TabIndex = 15
        Me.lblReferredBy.Text = "Referred By"
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(11, 499)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 79
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(578, 498)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(77, 23)
        Me.btnDelete.TabIndex = 80
        Me.btnDelete.Tag = "Visits"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(11, 525)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 81
        Me.ebnSaveUpdate.Tag = "Visits"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.DropDownWidth = 230
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.FormattingEnabled = True
        Me.cboStaffNo.Location = New System.Drawing.Point(173, 94)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(154, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 12
        '
        'cboServiceCode
        '
        Me.cboServiceCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboServiceCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboServiceCode, "ServiceName")
        Me.cboServiceCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiceCode.DropDownWidth = 220
        Me.cboServiceCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboServiceCode.FormattingEnabled = True
        Me.cboServiceCode.ItemHeight = 13
        Me.cboServiceCode.Location = New System.Drawing.Point(173, 329)
        Me.cboServiceCode.Name = "cboServiceCode"
        Me.cboServiceCode.Size = New System.Drawing.Size(154, 21)
        Me.cboServiceCode.TabIndex = 32
        '
        'chkAccessCashServices
        '
        Me.chkAccessCashServices.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkAccessCashServices, "AccessCashServices")
        Me.chkAccessCashServices.Enabled = False
        Me.chkAccessCashServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAccessCashServices.Location = New System.Drawing.Point(352, 439)
        Me.chkAccessCashServices.Name = "chkAccessCashServices"
        Me.chkAccessCashServices.Size = New System.Drawing.Size(152, 20)
        Me.chkAccessCashServices.TabIndex = 76
        Me.chkAccessCashServices.Text = "Access Cash Services"
        '
        'cboDoctorSpecialtyID
        '
        Me.cboDoctorSpecialtyID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDoctorSpecialtyID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboDoctorSpecialtyID, "DoctorSpecialty,DoctorSpecialtyID")
        Me.cboDoctorSpecialtyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDoctorSpecialtyID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDoctorSpecialtyID.FormattingEnabled = True
        Me.cboDoctorSpecialtyID.ItemHeight = 13
        Me.cboDoctorSpecialtyID.Location = New System.Drawing.Point(173, 71)
        Me.cboDoctorSpecialtyID.Name = "cboDoctorSpecialtyID"
        Me.cboDoctorSpecialtyID.Size = New System.Drawing.Size(154, 21)
        Me.cboDoctorSpecialtyID.TabIndex = 10
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayPercent, "CoPayPercent")
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(173, 419)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(154, 20)
        Me.nbxCoPayPercent.TabIndex = 40
        Me.nbxCoPayPercent.Value = ""
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayValue, "CoPayValue")
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(173, 440)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(154, 20)
        Me.nbxCoPayValue.TabIndex = 42
        Me.nbxCoPayValue.Value = ""
        '
        'cboCoPayTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCoPayTypeID, "CoPayType,CoPayTypeID")
        Me.cboCoPayTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoPayTypeID.Enabled = False
        Me.cboCoPayTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCoPayTypeID.Location = New System.Drawing.Point(173, 396)
        Me.cboCoPayTypeID.Name = "cboCoPayTypeID"
        Me.cboCoPayTypeID.Size = New System.Drawing.Size(154, 21)
        Me.cboCoPayTypeID.TabIndex = 38
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMemberCardNo, "MemberCardNo")
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(173, 208)
        Me.stbMemberCardNo.MaxLength = 30
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(154, 20)
        Me.stbMemberCardNo.TabIndex = 22
        '
        'stbClaimReferenceNo
        '
        Me.stbClaimReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimReferenceNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbClaimReferenceNo, "ClaimReferenceNo")
        Me.stbClaimReferenceNo.EntryErrorMSG = ""
        Me.stbClaimReferenceNo.Location = New System.Drawing.Point(173, 284)
        Me.stbClaimReferenceNo.MaxLength = 30
        Me.stbClaimReferenceNo.Name = "stbClaimReferenceNo"
        Me.stbClaimReferenceNo.RegularExpression = ""
        Me.stbClaimReferenceNo.Size = New System.Drawing.Size(154, 20)
        Me.stbClaimReferenceNo.TabIndex = 28
        '
        'stbMainMemberName
        '
        Me.stbMainMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMainMemberName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMainMemberName, "MainMemberName")
        Me.stbMainMemberName.EntryErrorMSG = ""
        Me.stbMainMemberName.Location = New System.Drawing.Point(173, 263)
        Me.stbMainMemberName.MaxLength = 41
        Me.stbMainMemberName.Name = "stbMainMemberName"
        Me.stbMainMemberName.RegularExpression = ""
        Me.stbMainMemberName.Size = New System.Drawing.Size(154, 20)
        Me.stbMainMemberName.TabIndex = 26
        '
        'cboAssociatedBillNo
        '
        Me.cboAssociatedBillNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssociatedBillNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboAssociatedBillNo, "AssociatedFullBillCustomer")
        Me.cboAssociatedBillNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssociatedBillNo.DropDownWidth = 230
        Me.cboAssociatedBillNo.Enabled = False
        Me.cboAssociatedBillNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAssociatedBillNo.FormattingEnabled = True
        Me.cboAssociatedBillNo.Location = New System.Drawing.Point(173, 306)
        Me.cboAssociatedBillNo.Name = "cboAssociatedBillNo"
        Me.cboAssociatedBillNo.Size = New System.Drawing.Size(154, 21)
        Me.cboAssociatedBillNo.Sorted = True
        Me.cboAssociatedBillNo.TabIndex = 30
        '
        'cboVisitPriority
        '
        Me.cboVisitPriority.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVisitPriority.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboVisitPriority, "Priority,VisitsPriorityID")
        Me.cboVisitPriority.DisplayMember = "Priority"
        Me.cboVisitPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitPriority.DropDownWidth = 220
        Me.cboVisitPriority.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisitPriority.FormattingEnabled = True
        Me.cboVisitPriority.ItemHeight = 13
        Me.cboVisitPriority.Location = New System.Drawing.Point(167, 3)
        Me.cboVisitPriority.Name = "cboVisitPriority"
        Me.cboVisitPriority.Size = New System.Drawing.Size(154, 21)
        Me.cboVisitPriority.TabIndex = 1
        Me.cboVisitPriority.Tag = "Priority"
        '
        'stbInsuranceNo
        '
        Me.stbInsuranceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceNo, "InsuranceNo")
        Me.stbInsuranceNo.EntryErrorMSG = ""
        Me.stbInsuranceNo.Location = New System.Drawing.Point(507, 366)
        Me.stbInsuranceNo.MaxLength = 20
        Me.stbInsuranceNo.Name = "stbInsuranceNo"
        Me.stbInsuranceNo.ReadOnly = True
        Me.stbInsuranceNo.RegularExpression = ""
        Me.stbInsuranceNo.Size = New System.Drawing.Size(149, 20)
        Me.stbInsuranceNo.TabIndex = 71
        '
        'chkSmartCardApplicable
        '
        Me.chkSmartCardApplicable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkSmartCardApplicable, "SmartCardApplicable")
        Me.chkSmartCardApplicable.Enabled = False
        Me.chkSmartCardApplicable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSmartCardApplicable.Location = New System.Drawing.Point(511, 439)
        Me.chkSmartCardApplicable.Name = "chkSmartCardApplicable"
        Me.chkSmartCardApplicable.Size = New System.Drawing.Size(145, 20)
        Me.chkSmartCardApplicable.TabIndex = 77
        Me.chkSmartCardApplicable.Text = "Smart Card Applicable"
        '
        'stbCombination
        '
        Me.stbCombination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCombination.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbCombination, "Combination")
        Me.stbCombination.Enabled = False
        Me.stbCombination.EntryErrorMSG = ""
        Me.stbCombination.Location = New System.Drawing.Point(507, 418)
        Me.stbCombination.MaxLength = 41
        Me.stbCombination.Name = "stbCombination"
        Me.stbCombination.RegularExpression = ""
        Me.stbCombination.Size = New System.Drawing.Size(149, 20)
        Me.stbCombination.TabIndex = 75
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPhone, "Phone")
        Me.stbPhone.Enabled = False
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(507, 220)
        Me.stbPhone.MaxLength = 60
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPhone.Size = New System.Drawing.Size(149, 20)
        Me.stbPhone.TabIndex = 58
        '
        'nbxOutstandingBalance
        '
        Me.nbxOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxOutstandingBalance, "OutstandingBalance")
        Me.nbxOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOutstandingBalance.DecimalPlaces = -1
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(507, 304)
        Me.nbxOutstandingBalance.MaxValue = 0.0R
        Me.nbxOutstandingBalance.MinValue = 0.0R
        Me.nbxOutstandingBalance.MustEnterNumeric = True
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = True
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(149, 20)
        Me.nbxOutstandingBalance.TabIndex = 66
        Me.nbxOutstandingBalance.Value = ""
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalVisits.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbTotalVisits, "TotalVisits")
        Me.stbTotalVisits.Enabled = False
        Me.stbTotalVisits.EntryErrorMSG = ""
        Me.stbTotalVisits.Location = New System.Drawing.Point(507, 262)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(149, 20)
        Me.stbTotalVisits.TabIndex = 62
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(507, 387)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(159, 29)
        Me.stbInsuranceName.TabIndex = 73
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.spbPhoto, "Photo")
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(507, 6)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(100, 97)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 78
        Me.spbPhoto.TabStop = False
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbLastVisitDate, "LastVisitDate")
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.EntryErrorMSG = ""
        Me.stbLastVisitDate.Location = New System.Drawing.Point(507, 241)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.RegularExpression = ""
        Me.stbLastVisitDate.Size = New System.Drawing.Size(149, 20)
        Me.stbLastVisitDate.TabIndex = 60
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAge, "Age")
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(507, 157)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(44, 20)
        Me.stbAge.TabIndex = 51
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbJoinDate, "JoinDate")
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(507, 199)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(149, 20)
        Me.stbJoinDate.TabIndex = 56
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbGender, "Gender")
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(507, 178)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(149, 20)
        Me.stbGender.TabIndex = 54
        '
        'cboVisitStatusID
        '
        Me.cboVisitStatusID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVisitStatusID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboVisitStatusID, "VisitStatus,VisitStatusID")
        Me.cboVisitStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitStatusID.Enabled = False
        Me.cboVisitStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisitStatusID.FormattingEnabled = True
        Me.cboVisitStatusID.ItemHeight = 13
        Me.cboVisitStatusID.Location = New System.Drawing.Point(169, 5)
        Me.cboVisitStatusID.Name = "cboVisitStatusID"
        Me.cboVisitStatusID.Size = New System.Drawing.Size(149, 21)
        Me.cboVisitStatusID.TabIndex = 1
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(507, 136)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(149, 20)
        Me.stbFullName.TabIndex = 49
        '
        'chkHasPackage
        '
        Me.chkHasPackage.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHasPackage, "HasPackage")
        Me.chkHasPackage.Enabled = False
        Me.chkHasPackage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHasPackage.ForeColor = System.Drawing.Color.Red
        Me.chkHasPackage.Location = New System.Drawing.Point(351, 345)
        Me.chkHasPackage.Name = "chkHasPackage"
        Me.chkHasPackage.Size = New System.Drawing.Size(167, 18)
        Me.chkHasPackage.TabIndex = 69
        Me.chkHasPackage.Text = "Package Active"
        '
        'nbxMemberLimitBalance
        '
        Me.nbxMemberLimitBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxMemberLimitBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxMemberLimitBalance.ControlCaption = "Outstanding Balance"
        Me.nbxMemberLimitBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxMemberLimitBalance, "OutstandingBalance")
        Me.nbxMemberLimitBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxMemberLimitBalance.DecimalPlaces = -1
        Me.nbxMemberLimitBalance.Location = New System.Drawing.Point(507, 283)
        Me.nbxMemberLimitBalance.MaxValue = 0.0R
        Me.nbxMemberLimitBalance.MinValue = 0.0R
        Me.nbxMemberLimitBalance.MustEnterNumeric = True
        Me.nbxMemberLimitBalance.Name = "nbxMemberLimitBalance"
        Me.nbxMemberLimitBalance.ReadOnly = True
        Me.nbxMemberLimitBalance.Size = New System.Drawing.Size(149, 20)
        Me.nbxMemberLimitBalance.TabIndex = 64
        Me.nbxMemberLimitBalance.Value = ""
        '
        'cboPackageName
        '
        Me.cboPackageName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPackageName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboPackageName, "PackageFullName")
        Me.cboPackageName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPackageName.DropDownWidth = 220
        Me.cboPackageName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPackageName.FormattingEnabled = True
        Me.cboPackageName.ItemHeight = 13
        Me.cboPackageName.Location = New System.Drawing.Point(173, 373)
        Me.cboPackageName.Name = "cboPackageName"
        Me.cboPackageName.Size = New System.Drawing.Size(154, 21)
        Me.cboPackageName.TabIndex = 36
        '
        'cboCommunityID
        '
        Me.cboCommunityID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCommunityID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboCommunityID, "CommunityID")
        Me.cboCommunityID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCommunityID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCommunityID.Location = New System.Drawing.Point(160, 3)
        Me.cboCommunityID.Name = "cboCommunityID"
        Me.cboCommunityID.Size = New System.Drawing.Size(145, 21)
        Me.cboCommunityID.TabIndex = 1
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(578, 523)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(77, 23)
        Me.fbnClose.TabIndex = 85
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(140, 28)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 5
        '
        'nbxToBillServiceFee
        '
        Me.nbxToBillServiceFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxToBillServiceFee.ControlCaption = "Consultation Fee"
        Me.nbxToBillServiceFee.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxToBillServiceFee.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxToBillServiceFee.DecimalPlaces = -1
        Me.nbxToBillServiceFee.Location = New System.Drawing.Point(173, 353)
        Me.nbxToBillServiceFee.MaxValue = 0.0R
        Me.nbxToBillServiceFee.MinValue = 0.0R
        Me.nbxToBillServiceFee.MustEnterNumeric = True
        Me.nbxToBillServiceFee.Name = "nbxToBillServiceFee"
        Me.nbxToBillServiceFee.Size = New System.Drawing.Size(154, 20)
        Me.nbxToBillServiceFee.TabIndex = 34
        Me.nbxToBillServiceFee.Value = ""
        '
        'lblStaffNo
        '
        Me.lblStaffNo.Location = New System.Drawing.Point(10, 97)
        Me.lblStaffNo.Name = "lblStaffNo"
        Me.lblStaffNo.Size = New System.Drawing.Size(151, 20)
        Me.lblStaffNo.TabIndex = 11
        Me.lblStaffNo.Text = "To-See  Doctor"
        '
        'lblServiceCode
        '
        Me.lblServiceCode.Location = New System.Drawing.Point(9, 332)
        Me.lblServiceCode.Name = "lblServiceCode"
        Me.lblServiceCode.Size = New System.Drawing.Size(151, 20)
        Me.lblServiceCode.TabIndex = 31
        Me.lblServiceCode.Text = "To-Bill Service"
        '
        'lblServiceFee
        '
        Me.lblServiceFee.Location = New System.Drawing.Point(9, 353)
        Me.lblServiceFee.Name = "lblServiceFee"
        Me.lblServiceFee.Size = New System.Drawing.Size(151, 20)
        Me.lblServiceFee.TabIndex = 33
        Me.lblServiceFee.Text = "To-Bill Service Fee"
        '
        'lblDoctorSpecialtyID
        '
        Me.lblDoctorSpecialtyID.Location = New System.Drawing.Point(10, 72)
        Me.lblDoctorSpecialtyID.Name = "lblDoctorSpecialtyID"
        Me.lblDoctorSpecialtyID.Size = New System.Drawing.Size(151, 20)
        Me.lblDoctorSpecialtyID.TabIndex = 9
        Me.lblDoctorSpecialtyID.Text = "To-See Doctor Specialty"
        '
        'btnFindPatientNo
        '
        Me.btnFindPatientNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindPatientNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindPatientNo.Image = CType(resources.GetObject("btnFindPatientNo.Image"), System.Drawing.Image)
        Me.btnFindPatientNo.Location = New System.Drawing.Point(140, 6)
        Me.btnFindPatientNo.Name = "btnFindPatientNo"
        Me.btnFindPatientNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindPatientNo.TabIndex = 1
        '
        'btnEditPatient
        '
        Me.btnEditPatient.Enabled = False
        Me.btnEditPatient.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEditPatient.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditPatient.Location = New System.Drawing.Point(189, 524)
        Me.btnEditPatient.Name = "btnEditPatient"
        Me.btnEditPatient.Size = New System.Drawing.Size(87, 24)
        Me.btnEditPatient.TabIndex = 82
        Me.btnEditPatient.Tag = "Patients"
        Me.btnEditPatient.Text = "E&dit Patient"
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.Location = New System.Drawing.Point(10, 420)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(151, 20)
        Me.lblCoPayPercent.TabIndex = 39
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.Location = New System.Drawing.Point(10, 441)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(151, 20)
        Me.lblCoPayValue.TabIndex = 41
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'lblCoPayType
        '
        Me.lblCoPayType.Location = New System.Drawing.Point(10, 400)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(151, 20)
        Me.lblCoPayType.TabIndex = 37
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(10, 208)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(151, 20)
        Me.lblMemberCardNo.TabIndex = 21
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'lblClaimReferenceNo
        '
        Me.lblClaimReferenceNo.Location = New System.Drawing.Point(10, 284)
        Me.lblClaimReferenceNo.Name = "lblClaimReferenceNo"
        Me.lblClaimReferenceNo.Size = New System.Drawing.Size(151, 20)
        Me.lblClaimReferenceNo.TabIndex = 27
        Me.lblClaimReferenceNo.Text = "Claim Reference No"
        '
        'lblMainMemberName
        '
        Me.lblMainMemberName.Location = New System.Drawing.Point(10, 263)
        Me.lblMainMemberName.Name = "lblMainMemberName"
        Me.lblMainMemberName.Size = New System.Drawing.Size(151, 20)
        Me.lblMainMemberName.TabIndex = 25
        Me.lblMainMemberName.Text = "Main Member Name"
        '
        'lblAssociatedBillNo
        '
        Me.lblAssociatedBillNo.Enabled = False
        Me.lblAssociatedBillNo.Location = New System.Drawing.Point(10, 307)
        Me.lblAssociatedBillNo.Name = "lblAssociatedBillNo"
        Me.lblAssociatedBillNo.Size = New System.Drawing.Size(151, 20)
        Me.lblAssociatedBillNo.TabIndex = 29
        Me.lblAssociatedBillNo.Text = "Associated Bill Customer"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(281, 4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 3
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'pnlVisitsPriority
        '
        Me.pnlVisitsPriority.Controls.Add(Me.cboVisitPriority)
        Me.pnlVisitsPriority.Controls.Add(Me.lblVisitPriority)
        Me.pnlVisitsPriority.Location = New System.Drawing.Point(6, 462)
        Me.pnlVisitsPriority.Name = "pnlVisitsPriority"
        Me.pnlVisitsPriority.Size = New System.Drawing.Size(328, 28)
        Me.pnlVisitsPriority.TabIndex = 43
        '
        'lblVisitPriority
        '
        Me.lblVisitPriority.Location = New System.Drawing.Point(6, 4)
        Me.lblVisitPriority.Name = "lblVisitPriority"
        Me.lblVisitPriority.Size = New System.Drawing.Size(149, 20)
        Me.lblVisitPriority.TabIndex = 0
        Me.lblVisitPriority.Text = "Visit Priority"
        '
        'btnViewTodaysBirthdays
        '
        Me.btnViewTodaysBirthdays.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewTodaysBirthdays.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewTodaysBirthdays.Location = New System.Drawing.Point(444, 523)
        Me.btnViewTodaysBirthdays.Name = "btnViewTodaysBirthdays"
        Me.btnViewTodaysBirthdays.Size = New System.Drawing.Size(130, 24)
        Me.btnViewTodaysBirthdays.TabIndex = 84
        Me.btnViewTodaysBirthdays.Tag = ""
        Me.btnViewTodaysBirthdays.Text = "&View Today's Birthdays"
        '
        'lblAgeString
        '
        Me.lblAgeString.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgeString.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAgeString.Location = New System.Drawing.Point(556, 158)
        Me.lblAgeString.Name = "lblAgeString"
        Me.lblAgeString.Size = New System.Drawing.Size(99, 17)
        Me.lblAgeString.TabIndex = 52
        '
        'lblInsuranceNo
        '
        Me.lblInsuranceNo.Location = New System.Drawing.Point(352, 367)
        Me.lblInsuranceNo.Name = "lblInsuranceNo"
        Me.lblInsuranceNo.Size = New System.Drawing.Size(148, 20)
        Me.lblInsuranceNo.TabIndex = 70
        Me.lblInsuranceNo.Text = "Insurance No"
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(352, 222)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(148, 20)
        Me.lblPhone.TabIndex = 57
        Me.lblPhone.Text = "Phone"
        '
        'btnViewTodayAppointments
        '
        Me.btnViewTodayAppointments.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewTodayAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewTodayAppointments.Location = New System.Drawing.Point(281, 524)
        Me.btnViewTodayAppointments.Name = "btnViewTodayAppointments"
        Me.btnViewTodayAppointments.Size = New System.Drawing.Size(158, 24)
        Me.btnViewTodayAppointments.TabIndex = 83
        Me.btnViewTodayAppointments.Tag = ""
        Me.btnViewTodayAppointments.Text = "&View Today's Appointments"
        '
        'chkFingerprintCaptured
        '
        Me.chkFingerprintCaptured.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFingerprintCaptured.Enabled = False
        Me.chkFingerprintCaptured.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFingerprintCaptured.Location = New System.Drawing.Point(351, 32)
        Me.chkFingerprintCaptured.Name = "chkFingerprintCaptured"
        Me.chkFingerprintCaptured.Size = New System.Drawing.Size(145, 21)
        Me.chkFingerprintCaptured.TabIndex = 45
        Me.chkFingerprintCaptured.Text = "Fingerprint Captured"
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(356, 77)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(145, 23)
        Me.btnFindByFingerprint.TabIndex = 46
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(352, 306)
        Me.lblOutstandingBalance.Name = "lblOutstandingBalance"
        Me.lblOutstandingBalance.Size = New System.Drawing.Size(148, 20)
        Me.lblOutstandingBalance.TabIndex = 65
        Me.lblOutstandingBalance.Text = "Outstanding Balance"
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(352, 263)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(148, 20)
        Me.lblTotalVisits.TabIndex = 61
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'lblCombination
        '
        Me.lblCombination.Location = New System.Drawing.Point(352, 420)
        Me.lblCombination.Name = "lblCombination"
        Me.lblCombination.Size = New System.Drawing.Size(148, 18)
        Me.lblCombination.TabIndex = 74
        Me.lblCombination.Text = "Combination"
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(352, 396)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(148, 20)
        Me.lblBillInsuranceName.TabIndex = 72
        Me.lblBillInsuranceName.Text = "To-Bill Insurance Name"
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(352, 10)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(148, 20)
        Me.lblPhoto.TabIndex = 44
        Me.lblPhoto.Text = "Photo"
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(352, 243)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(148, 20)
        Me.lblLastVisitDate.TabIndex = 59
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(352, 201)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(148, 20)
        Me.lblJoinDate.TabIndex = 55
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(352, 159)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(148, 20)
        Me.lblAge.TabIndex = 50
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(352, 180)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(148, 20)
        Me.lblGenderID.TabIndex = 53
        Me.lblGenderID.Text = "Gender"
        '
        'pnlVisitStatus
        '
        Me.pnlVisitStatus.Controls.Add(Me.lblVisitStatus)
        Me.pnlVisitStatus.Controls.Add(Me.cboVisitStatusID)
        Me.pnlVisitStatus.Location = New System.Drawing.Point(338, 106)
        Me.pnlVisitStatus.Name = "pnlVisitStatus"
        Me.pnlVisitStatus.Size = New System.Drawing.Size(324, 29)
        Me.pnlVisitStatus.TabIndex = 47
        '
        'lblVisitStatus
        '
        Me.lblVisitStatus.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblVisitStatus.Location = New System.Drawing.Point(13, 8)
        Me.lblVisitStatus.Name = "lblVisitStatus"
        Me.lblVisitStatus.Size = New System.Drawing.Size(131, 16)
        Me.lblVisitStatus.TabIndex = 0
        Me.lblVisitStatus.Text = "Visit Status"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(352, 138)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(148, 20)
        Me.lblName.TabIndex = 48
        Me.lblName.Text = "Patient's Name"
        '
        'nbxCashAccountBalance
        '
        Me.nbxCashAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxCashAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCashAccountBalance.ControlCaption = "Cash Account Balance"
        Me.nbxCashAccountBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCashAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCashAccountBalance.DecimalPlaces = -1
        Me.nbxCashAccountBalance.Location = New System.Drawing.Point(507, 325)
        Me.nbxCashAccountBalance.MaxValue = 0.0R
        Me.nbxCashAccountBalance.MinValue = 0.0R
        Me.nbxCashAccountBalance.MustEnterNumeric = True
        Me.nbxCashAccountBalance.Name = "nbxCashAccountBalance"
        Me.nbxCashAccountBalance.ReadOnly = True
        Me.nbxCashAccountBalance.Size = New System.Drawing.Size(149, 20)
        Me.nbxCashAccountBalance.TabIndex = 68
        Me.nbxCashAccountBalance.Value = ""
        '
        'lblCashAccountBalance
        '
        Me.lblCashAccountBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblCashAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblCashAccountBalance.Location = New System.Drawing.Point(352, 325)
        Me.lblCashAccountBalance.Name = "lblCashAccountBalance"
        Me.lblCashAccountBalance.Size = New System.Drawing.Size(127, 20)
        Me.lblCashAccountBalance.TabIndex = 67
        Me.lblCashAccountBalance.Text = "Account Balance"
        '
        'lblMemberLimitBalance
        '
        Me.lblMemberLimitBalance.ForeColor = System.Drawing.Color.Red
        Me.lblMemberLimitBalance.Location = New System.Drawing.Point(352, 285)
        Me.lblMemberLimitBalance.Name = "lblMemberLimitBalance"
        Me.lblMemberLimitBalance.Size = New System.Drawing.Size(148, 20)
        Me.lblMemberLimitBalance.TabIndex = 63
        Me.lblMemberLimitBalance.Text = "Member Limit Balance"
        '
        'lblPackageName
        '
        Me.lblPackageName.Location = New System.Drawing.Point(10, 375)
        Me.lblPackageName.Name = "lblPackageName"
        Me.lblPackageName.Size = New System.Drawing.Size(151, 20)
        Me.lblPackageName.TabIndex = 35
        Me.lblPackageName.Text = "Package"
        '
        'lblCommunityID
        '
        Me.lblCommunityID.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCommunityID.Location = New System.Drawing.Point(5, 4)
        Me.lblCommunityID.Name = "lblCommunityID"
        Me.lblCommunityID.Size = New System.Drawing.Size(145, 20)
        Me.lblCommunityID.TabIndex = 0
        Me.lblCommunityID.Text = "Community "
        '
        'pnlCommunity
        '
        Me.pnlCommunity.Controls.Add(Me.lblCommunityID)
        Me.pnlCommunity.Controls.Add(Me.cboCommunityID)
        Me.pnlCommunity.Location = New System.Drawing.Point(351, 461)
        Me.pnlCommunity.Name = "pnlCommunity"
        Me.pnlCommunity.Size = New System.Drawing.Size(311, 28)
        Me.pnlCommunity.TabIndex = 78
        '
        'ChkPrintFormFive
        '
        Me.ChkPrintFormFive.Checked = True
        Me.ChkPrintFormFive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkPrintFormFive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkPrintFormFive.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ChkPrintFormFive.Location = New System.Drawing.Point(94, 527)
        Me.ChkPrintFormFive.Name = "ChkPrintFormFive"
        Me.ChkPrintFormFive.Size = New System.Drawing.Size(95, 20)
        Me.ChkPrintFormFive.TabIndex = 86
        Me.ChkPrintFormFive.Text = " Print Form 5"
        '
        'btnPrintForm5
        '
        Me.btnPrintForm5.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintForm5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintForm5.Location = New System.Drawing.Point(444, 497)
        Me.btnPrintForm5.Name = "btnPrintForm5"
        Me.btnPrintForm5.Size = New System.Drawing.Size(130, 24)
        Me.btnPrintForm5.TabIndex = 87
        Me.btnPrintForm5.Tag = ""
        Me.btnPrintForm5.Text = "&Print Form 5"
        '
        'frmVisits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(673, 568)
        Me.Controls.Add(Me.btnPrintForm5)
        Me.Controls.Add(Me.ChkPrintFormFive)
        Me.Controls.Add(Me.pnlCommunity)
        Me.Controls.Add(Me.lblPackageName)
        Me.Controls.Add(Me.cboPackageName)
        Me.Controls.Add(Me.nbxMemberLimitBalance)
        Me.Controls.Add(Me.lblMemberLimitBalance)
        Me.Controls.Add(Me.nbxCashAccountBalance)
        Me.Controls.Add(Me.lblCashAccountBalance)
        Me.Controls.Add(Me.chkHasPackage)
        Me.Controls.Add(Me.btnViewTodaysBirthdays)
        Me.Controls.Add(Me.btnViewTodayAppointments)
        Me.Controls.Add(Me.pnlVisitsPriority)
        Me.Controls.Add(Me.btnEditPatient)
        Me.Controls.Add(Me.lblAgeString)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.stbInsuranceNo)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.cboAssociatedBillNo)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblInsuranceNo)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.lblAssociatedBillNo)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.chkSmartCardApplicable)
        Me.Controls.Add(Me.cboBillModesID)
        Me.Controls.Add(Me.stbMainMemberName)
        Me.Controls.Add(Me.cboVisitCategoryID)
        Me.Controls.Add(Me.stbCombination)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblMainMemberName)
        Me.Controls.Add(Me.dtpVisitDate)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.stbClaimReferenceNo)
        Me.Controls.Add(Me.lblCategory)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.lblClaimReferenceNo)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.cboBillNo)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.chkFingerprintCaptured)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.nbxToBillServiceFee)
        Me.Controls.Add(Me.btnFindByFingerprint)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.cboCoPayTypeID)
        Me.Controls.Add(Me.stbReferredBy)
        Me.Controls.Add(Me.nbxOutstandingBalance)
        Me.Controls.Add(Me.lblReferredBy)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.lblOutstandingBalance)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.stbTotalVisits)
        Me.Controls.Add(Me.pnlVisitStatus)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblTotalVisits)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblCombination)
        Me.Controls.Add(Me.lblStaffNo)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.btnFindPatientNo)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.lblServiceCode)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.cboDoctorSpecialtyID)
        Me.Controls.Add(Me.cboServiceCode)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.lblDoctorSpecialtyID)
        Me.Controls.Add(Me.lblServiceFee)
        Me.Controls.Add(Me.stbLastVisitDate)
        Me.Controls.Add(Me.lblLastVisitDate)
        Me.Controls.Add(Me.chkAccessCashServices)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmVisits"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Visits"
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVisitsPriority.ResumeLayout(False)
        Me.pnlVisitStatus.ResumeLayout(False)
        Me.pnlCommunity.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboBillNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents cboVisitCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpVisitDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCategory As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbReferredBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferredBy As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents nbxToBillServiceFee As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaffNo As System.Windows.Forms.Label
    Friend WithEvents cboServiceCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblServiceCode As System.Windows.Forms.Label
    Friend WithEvents lblServiceFee As System.Windows.Forms.Label
    Friend WithEvents chkAccessCashServices As System.Windows.Forms.CheckBox
    Friend WithEvents cboDoctorSpecialtyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDoctorSpecialtyID As System.Windows.Forms.Label
    Friend WithEvents btnFindPatientNo As System.Windows.Forms.Button
    Friend WithEvents btnEditPatient As System.Windows.Forms.Button
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents cboCoPayTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents stbClaimReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClaimReferenceNo As System.Windows.Forms.Label
    Friend WithEvents stbMainMemberName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMainMemberName As System.Windows.Forms.Label
    Friend WithEvents cboAssociatedBillNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblAssociatedBillNo As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents pnlVisitsPriority As System.Windows.Forms.Panel
    Friend WithEvents cboVisitPriority As System.Windows.Forms.ComboBox
    Friend WithEvents lblVisitPriority As System.Windows.Forms.Label
    Friend WithEvents btnViewTodaysBirthdays As System.Windows.Forms.Button
    Friend WithEvents lblAgeString As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceNo As System.Windows.Forms.Label
    Friend WithEvents chkSmartCardApplicable As System.Windows.Forms.CheckBox
    Friend WithEvents stbCombination As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents btnViewTodayAppointments As System.Windows.Forms.Button
    Friend WithEvents chkFingerprintCaptured As System.Windows.Forms.CheckBox
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents nbxOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBalance As System.Windows.Forms.Label
    Friend WithEvents stbTotalVisits As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalVisits As System.Windows.Forms.Label
    Friend WithEvents lblCombination As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents stbLastVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents pnlVisitStatus As System.Windows.Forms.Panel
    Friend WithEvents lblVisitStatus As System.Windows.Forms.Label
    Friend WithEvents cboVisitStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents chkHasPackage As System.Windows.Forms.CheckBox
    Friend WithEvents nbxCashAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCashAccountBalance As System.Windows.Forms.Label
    Friend WithEvents nbxMemberLimitBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblMemberLimitBalance As System.Windows.Forms.Label
    Friend WithEvents lblPackageName As System.Windows.Forms.Label
    Friend WithEvents cboPackageName As System.Windows.Forms.ComboBox
    Friend WithEvents cboCommunityID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCommunityID As System.Windows.Forms.Label
    Friend WithEvents pnlCommunity As System.Windows.Forms.Panel
    Friend WithEvents ChkPrintFormFive As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrintForm5 As System.Windows.Forms.Button

  
End Class
