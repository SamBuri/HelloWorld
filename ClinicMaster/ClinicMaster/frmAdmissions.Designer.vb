
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdmissions : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal visitNo As String, ByVal staffFullName As String)
        MyClass.New()
        Me.defaultVisitNo = visitNo
        Me.doctorFullName = staffFullName
    End Sub

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdmissions))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpAdmissionDateTime = New System.Windows.Forms.DateTimePicker()
        Me.cboAdmissionStatusID = New System.Windows.Forms.ComboBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbServiceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboWardsID = New System.Windows.Forms.ComboBox()
        Me.cboRoomNo = New System.Windows.Forms.ComboBox()
        Me.cboBedNo = New System.Windows.Forms.ComboBox()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxUnitPrice = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.stbChartNumber = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAssociatedBillNo = New System.Windows.Forms.ComboBox()
        Me.cboBillModesID = New System.Windows.Forms.ComboBox()
        Me.stbMainMemberName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbClaimReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboBillNo = New System.Windows.Forms.ComboBox()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAdmissionNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboCoPayTypeID = New System.Windows.Forms.ComboBox()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbInsuranceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkSmartCardApplicable = New System.Windows.Forms.CheckBox()
        Me.chkAccessCashServices = New System.Windows.Forms.CheckBox()
        Me.stbProvisionalDiagnosis = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboServiceCode = New System.Windows.Forms.ComboBox()
        Me.nbxCoverAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionNo = New System.Windows.Forms.Label()
        Me.lblAdmissionDateTime = New System.Windows.Forms.Label()
        Me.lblAdmissionStatusID = New System.Windows.Forms.Label()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblServiceName = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.pnlAdmissionStatusID = New System.Windows.Forms.Panel()
        Me.btnFindAdmissionNo = New System.Windows.Forms.Button()
        Me.grpLocation = New System.Windows.Forms.GroupBox()
        Me.lblBedNo = New System.Windows.Forms.Label()
        Me.lblWardsID = New System.Windows.Forms.Label()
        Me.lblRoomNo = New System.Windows.Forms.Label()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.lblStaff = New System.Windows.Forms.Label()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.lblChatNo = New System.Windows.Forms.Label()
        Me.imgIDAutomation = New System.Windows.Forms.PictureBox()
        Me.btnPrintBarcode = New System.Windows.Forms.Button()
        Me.chkPrintAdmissionForm = New System.Windows.Forms.CheckBox()
        Me.lblAssociatedBillNo = New System.Windows.Forms.Label()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblMainMemberName = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.lblClaimReferenceNo = New System.Windows.Forms.Label()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.lblAdmissionNotes = New System.Windows.Forms.Label()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.lblInsuranceNo = New System.Windows.Forms.Label()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.lblAgeString = New System.Windows.Forms.Label()
        Me.chkPrintAdmissionConsent = New System.Windows.Forms.CheckBox()
        Me.lblCoverAmount = New System.Windows.Forms.Label()
        Me.chkPrintAdmissionFaceSheet = New System.Windows.Forms.CheckBox()
        Me.nbxToBillServiceFee = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblServiceCode = New System.Windows.Forms.Label()
        Me.lblServiceFee = New System.Windows.Forms.Label()
        Me.lblProvisionalDiagnosis = New System.Windows.Forms.Label()
        Me.btnLoadProvisionalTemplate = New System.Windows.Forms.Button()
        Me.pnlAdmissionStatusID.SuspendLayout()
        Me.grpLocation.SuspendLayout()
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 508)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 68
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(575, 501)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 73
        Me.fbnDelete.Tag = "Admissions"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 535)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 69
        Me.ebnSaveUpdate.Tag = "Admissions"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpAdmissionDateTime
        '
        Me.dtpAdmissionDateTime.Checked = False
        Me.dtpAdmissionDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpAdmissionDateTime, "AdmissionDateTime")
        Me.dtpAdmissionDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdmissionDateTime.Location = New System.Drawing.Point(160, 170)
        Me.dtpAdmissionDateTime.Name = "dtpAdmissionDateTime"
        Me.dtpAdmissionDateTime.ShowCheckBox = True
        Me.dtpAdmissionDateTime.Size = New System.Drawing.Size(174, 20)
        Me.dtpAdmissionDateTime.TabIndex = 11
        '
        'cboAdmissionStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAdmissionStatusID, "AdmissionStatus,AdmissionStatusID")
        Me.cboAdmissionStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAdmissionStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAdmissionStatusID.Location = New System.Drawing.Point(128, 4)
        Me.cboAdmissionStatusID.Name = "cboAdmissionStatusID"
        Me.cboAdmissionStatusID.Size = New System.Drawing.Size(172, 21)
        Me.cboAdmissionStatusID.TabIndex = 1
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitNo, "VisitNo")
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(160, 12)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(124, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitDate, "VisitDate")
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(473, 44)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(174, 20)
        Me.stbVisitDate.TabIndex = 40
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(473, 23)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(174, 20)
        Me.stbPatientNo.TabIndex = 38
        '
        'stbServiceName
        '
        Me.stbServiceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbServiceName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbServiceName, "ServiceName")
        Me.stbServiceName.Enabled = False
        Me.stbServiceName.EntryErrorMSG = ""
        Me.stbServiceName.Location = New System.Drawing.Point(473, 139)
        Me.stbServiceName.MaxLength = 60
        Me.stbServiceName.Name = "stbServiceName"
        Me.stbServiceName.RegularExpression = ""
        Me.stbServiceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbServiceName.Size = New System.Drawing.Size(174, 20)
        Me.stbServiceName.TabIndex = 48
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAge, "Age")
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(473, 65)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(63, 20)
        Me.stbAge.TabIndex = 42
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbGender, "Gender")
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(473, 86)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(174, 20)
        Me.stbGender.TabIndex = 45
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(473, 2)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(174, 20)
        Me.stbFullName.TabIndex = 36
        '
        'cboWardsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboWardsID, "Wards,WardsID")
        Me.cboWardsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWardsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboWardsID.Location = New System.Drawing.Point(156, 12)
        Me.cboWardsID.Name = "cboWardsID"
        Me.cboWardsID.Size = New System.Drawing.Size(178, 21)
        Me.cboWardsID.TabIndex = 1
        '
        'cboRoomNo
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboRoomNo, "RoomNo")
        Me.cboRoomNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRoomNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRoomNo.Location = New System.Drawing.Point(156, 35)
        Me.cboRoomNo.Name = "cboRoomNo"
        Me.cboRoomNo.Size = New System.Drawing.Size(178, 21)
        Me.cboRoomNo.TabIndex = 3
        '
        'cboBedNo
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBedNo, "BedNo")
        Me.cboBedNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBedNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBedNo.Location = New System.Drawing.Point(156, 58)
        Me.cboBedNo.Name = "cboBedNo"
        Me.cboBedNo.Size = New System.Drawing.Size(178, 21)
        Me.cboBedNo.TabIndex = 5
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillCustomerName, "BillCustomerName")
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(473, 161)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(174, 32)
        Me.stbBillCustomerName.TabIndex = 50
        '
        'nbxUnitPrice
        '
        Me.nbxUnitPrice.BackColor = System.Drawing.SystemColors.Info
        Me.nbxUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitPrice.ControlCaption = "Unit Price"
        Me.nbxUnitPrice.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxUnitPrice, "UnitPrice")
        Me.nbxUnitPrice.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxUnitPrice.DecimalPlaces = -1
        Me.nbxUnitPrice.Enabled = False
        Me.nbxUnitPrice.Location = New System.Drawing.Point(473, 313)
        Me.nbxUnitPrice.MaxValue = 0.0R
        Me.nbxUnitPrice.MinValue = 0.0R
        Me.nbxUnitPrice.MustEnterNumeric = True
        Me.nbxUnitPrice.Name = "nbxUnitPrice"
        Me.nbxUnitPrice.Size = New System.Drawing.Size(174, 20)
        Me.nbxUnitPrice.TabIndex = 62
        Me.nbxUnitPrice.Value = ""
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.DropDownWidth = 220
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.FormattingEnabled = True
        Me.cboStaffNo.Location = New System.Drawing.Point(160, 57)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(174, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 8
        '
        'stbChartNumber
        '
        Me.stbChartNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbChartNumber.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbChartNumber, "ChartNumber")
        Me.stbChartNumber.EntryErrorMSG = ""
        Me.stbChartNumber.Location = New System.Drawing.Point(160, 371)
        Me.stbChartNumber.MaxLength = 60
        Me.stbChartNumber.Name = "stbChartNumber"
        Me.stbChartNumber.RegularExpression = ""
        Me.stbChartNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbChartNumber.Size = New System.Drawing.Size(174, 20)
        Me.stbChartNumber.TabIndex = 29
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
        Me.cboAssociatedBillNo.Location = New System.Drawing.Point(160, 304)
        Me.cboAssociatedBillNo.Name = "cboAssociatedBillNo"
        Me.cboAssociatedBillNo.Size = New System.Drawing.Size(174, 21)
        Me.cboAssociatedBillNo.Sorted = True
        Me.cboAssociatedBillNo.TabIndex = 23
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
        Me.cboBillModesID.Location = New System.Drawing.Point(160, 192)
        Me.cboBillModesID.Name = "cboBillModesID"
        Me.cboBillModesID.Size = New System.Drawing.Size(174, 21)
        Me.cboBillModesID.TabIndex = 13
        '
        'stbMainMemberName
        '
        Me.stbMainMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMainMemberName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMainMemberName, "MainMemberName")
        Me.stbMainMemberName.EntryErrorMSG = ""
        Me.stbMainMemberName.Location = New System.Drawing.Point(160, 260)
        Me.stbMainMemberName.MaxLength = 41
        Me.stbMainMemberName.Name = "stbMainMemberName"
        Me.stbMainMemberName.RegularExpression = ""
        Me.stbMainMemberName.Size = New System.Drawing.Size(174, 20)
        Me.stbMainMemberName.TabIndex = 19
        '
        'stbClaimReferenceNo
        '
        Me.stbClaimReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimReferenceNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbClaimReferenceNo, "ClaimReferenceNo")
        Me.stbClaimReferenceNo.EntryErrorMSG = ""
        Me.stbClaimReferenceNo.Location = New System.Drawing.Point(160, 282)
        Me.stbClaimReferenceNo.MaxLength = 30
        Me.stbClaimReferenceNo.Name = "stbClaimReferenceNo"
        Me.stbClaimReferenceNo.RegularExpression = ""
        Me.stbClaimReferenceNo.Size = New System.Drawing.Size(174, 20)
        Me.stbClaimReferenceNo.TabIndex = 21
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
        Me.cboBillNo.Location = New System.Drawing.Point(160, 215)
        Me.cboBillNo.Name = "cboBillNo"
        Me.cboBillNo.Size = New System.Drawing.Size(174, 21)
        Me.cboBillNo.TabIndex = 15
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMemberCardNo, "MemberCardNo")
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(160, 238)
        Me.stbMemberCardNo.MaxLength = 30
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(174, 20)
        Me.stbMemberCardNo.TabIndex = 17
        '
        'stbAdmissionNotes
        '
        Me.stbAdmissionNotes.AcceptsReturn = True
        Me.stbAdmissionNotes.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbAdmissionNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionNotes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAdmissionNotes, "AdmissionNotes")
        Me.stbAdmissionNotes.EntryErrorMSG = ""
        Me.stbAdmissionNotes.Location = New System.Drawing.Point(160, 453)
        Me.stbAdmissionNotes.MaxLength = 2000
        Me.stbAdmissionNotes.Multiline = True
        Me.stbAdmissionNotes.Name = "stbAdmissionNotes"
        Me.stbAdmissionNotes.RegularExpression = ""
        Me.stbAdmissionNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionNotes.Size = New System.Drawing.Size(311, 52)
        Me.stbAdmissionNotes.TabIndex = 34
        '
        'cboCoPayTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCoPayTypeID, "CoPayType,CoPayTypeID")
        Me.cboCoPayTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoPayTypeID.Enabled = False
        Me.cboCoPayTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCoPayTypeID.Location = New System.Drawing.Point(474, 247)
        Me.cboCoPayTypeID.Name = "cboCoPayTypeID"
        Me.cboCoPayTypeID.Size = New System.Drawing.Size(174, 21)
        Me.cboCoPayTypeID.TabIndex = 56
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayValue, "CoPayValue")
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(474, 292)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(174, 20)
        Me.nbxCoPayValue.TabIndex = 60
        Me.nbxCoPayValue.Value = ""
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayPercent, "CoPayPercent")
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(474, 270)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(174, 20)
        Me.nbxCoPayPercent.TabIndex = 58
        Me.nbxCoPayPercent.Value = ""
        '
        'stbInsuranceNo
        '
        Me.stbInsuranceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceNo, "InsuranceNo")
        Me.stbInsuranceNo.EntryErrorMSG = ""
        Me.stbInsuranceNo.Location = New System.Drawing.Point(473, 194)
        Me.stbInsuranceNo.MaxLength = 20
        Me.stbInsuranceNo.Name = "stbInsuranceNo"
        Me.stbInsuranceNo.ReadOnly = True
        Me.stbInsuranceNo.RegularExpression = ""
        Me.stbInsuranceNo.Size = New System.Drawing.Size(177, 20)
        Me.stbInsuranceNo.TabIndex = 52
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(473, 215)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(177, 29)
        Me.stbInsuranceName.TabIndex = 54
        '
        'chkSmartCardApplicable
        '
        Me.chkSmartCardApplicable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkSmartCardApplicable, "SmartCardApplicable")
        Me.chkSmartCardApplicable.Enabled = False
        Me.chkSmartCardApplicable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSmartCardApplicable.Location = New System.Drawing.Point(505, 424)
        Me.chkSmartCardApplicable.Name = "chkSmartCardApplicable"
        Me.chkSmartCardApplicable.Size = New System.Drawing.Size(145, 20)
        Me.chkSmartCardApplicable.TabIndex = 66
        Me.chkSmartCardApplicable.Text = "Smart Card Applicable"
        '
        'chkAccessCashServices
        '
        Me.chkAccessCashServices.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkAccessCashServices, "AccessCashServices")
        Me.chkAccessCashServices.Enabled = False
        Me.chkAccessCashServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAccessCashServices.Location = New System.Drawing.Point(345, 424)
        Me.chkAccessCashServices.Name = "chkAccessCashServices"
        Me.chkAccessCashServices.Size = New System.Drawing.Size(152, 20)
        Me.chkAccessCashServices.TabIndex = 65
        Me.chkAccessCashServices.Text = "Access Cash Services"
        '
        'stbProvisionalDiagnosis
        '
        Me.stbProvisionalDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbProvisionalDiagnosis.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbProvisionalDiagnosis, "ProvisionalDiagnosis")
        Me.stbProvisionalDiagnosis.EntryErrorMSG = ""
        Me.stbProvisionalDiagnosis.Location = New System.Drawing.Point(160, 392)
        Me.stbProvisionalDiagnosis.MaxLength = 60
        Me.stbProvisionalDiagnosis.Multiline = True
        Me.stbProvisionalDiagnosis.Name = "stbProvisionalDiagnosis"
        Me.stbProvisionalDiagnosis.RegularExpression = ""
        Me.stbProvisionalDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbProvisionalDiagnosis.Size = New System.Drawing.Size(174, 59)
        Me.stbProvisionalDiagnosis.TabIndex = 32
        '
        'cboServiceCode
        '
        Me.cboServiceCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboServiceCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboServiceCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiceCode.DropDownWidth = 220
        Me.cboServiceCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboServiceCode.FormattingEnabled = True
        Me.cboServiceCode.ItemHeight = 13
        Me.cboServiceCode.Location = New System.Drawing.Point(160, 327)
        Me.cboServiceCode.Name = "cboServiceCode"
        Me.cboServiceCode.Size = New System.Drawing.Size(174, 21)
        Me.cboServiceCode.TabIndex = 25
        '
        'nbxCoverAmount
        '
        Me.nbxCoverAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxCoverAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoverAmount.ControlCaption = "CoverAmount"
        Me.nbxCoverAmount.Cursor = System.Windows.Forms.Cursors.Default
        Me.nbxCoverAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoverAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoverAmount.DecimalPlaces = -1
        Me.nbxCoverAmount.Enabled = False
        Me.nbxCoverAmount.Location = New System.Drawing.Point(473, 396)
        Me.nbxCoverAmount.MaxValue = 0.0R
        Me.nbxCoverAmount.MinValue = 0.0R
        Me.nbxCoverAmount.MustEnterNumeric = True
        Me.nbxCoverAmount.Name = "nbxCoverAmount"
        Me.nbxCoverAmount.Size = New System.Drawing.Size(174, 20)
        Me.nbxCoverAmount.TabIndex = 64
        Me.nbxCoverAmount.Value = ""
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(575, 528)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 74
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbAdmissionNo
        '
        Me.stbAdmissionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionNo.CapitalizeFirstLetter = False
        Me.stbAdmissionNo.EntryErrorMSG = ""
        Me.stbAdmissionNo.Location = New System.Drawing.Point(160, 34)
        Me.stbAdmissionNo.MaxLength = 20
        Me.stbAdmissionNo.Name = "stbAdmissionNo"
        Me.stbAdmissionNo.RegularExpression = ""
        Me.stbAdmissionNo.Size = New System.Drawing.Size(174, 20)
        Me.stbAdmissionNo.TabIndex = 6
        '
        'lblAdmissionNo
        '
        Me.lblAdmissionNo.Location = New System.Drawing.Point(8, 32)
        Me.lblAdmissionNo.Name = "lblAdmissionNo"
        Me.lblAdmissionNo.Size = New System.Drawing.Size(96, 19)
        Me.lblAdmissionNo.TabIndex = 4
        Me.lblAdmissionNo.Text = "Admission No"
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(4, 171)
        Me.lblAdmissionDateTime.Name = "lblAdmissionDateTime"
        Me.lblAdmissionDateTime.Size = New System.Drawing.Size(140, 20)
        Me.lblAdmissionDateTime.TabIndex = 10
        Me.lblAdmissionDateTime.Text = "Admission Date Time "
        '
        'lblAdmissionStatusID
        '
        Me.lblAdmissionStatusID.Location = New System.Drawing.Point(5, 4)
        Me.lblAdmissionStatusID.Name = "lblAdmissionStatusID"
        Me.lblAdmissionStatusID.Size = New System.Drawing.Size(114, 20)
        Me.lblAdmissionStatusID.TabIndex = 0
        Me.lblAdmissionStatusID.Text = "Admission Status"
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(345, 23)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(119, 20)
        Me.lblPatientsNo.TabIndex = 37
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblServiceName
        '
        Me.lblServiceName.Location = New System.Drawing.Point(345, 141)
        Me.lblServiceName.Name = "lblServiceName"
        Me.lblServiceName.Size = New System.Drawing.Size(119, 20)
        Me.lblServiceName.TabIndex = 47
        Me.lblServiceName.Text = "To-Bill Service"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(345, 64)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(119, 20)
        Me.lblAge.TabIndex = 41
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(345, 85)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(119, 20)
        Me.lblGenderID.TabIndex = 44
        Me.lblGenderID.Text = "Gender"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(345, 43)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(119, 20)
        Me.lblVisitDate.TabIndex = 39
        Me.lblVisitDate.Text = "Visit Date"
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(345, 2)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(119, 20)
        Me.lblFullName.TabIndex = 35
        Me.lblFullName.Text = "Patient's Name"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(128, 9)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(8, 10)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(112, 20)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No"
        '
        'pnlAdmissionStatusID
        '
        Me.pnlAdmissionStatusID.Controls.Add(Me.cboAdmissionStatusID)
        Me.pnlAdmissionStatusID.Controls.Add(Me.lblAdmissionStatusID)
        Me.pnlAdmissionStatusID.Enabled = False
        Me.pnlAdmissionStatusID.Location = New System.Drawing.Point(345, 108)
        Me.pnlAdmissionStatusID.Name = "pnlAdmissionStatusID"
        Me.pnlAdmissionStatusID.Size = New System.Drawing.Size(305, 28)
        Me.pnlAdmissionStatusID.TabIndex = 46
        '
        'btnFindAdmissionNo
        '
        Me.btnFindAdmissionNo.Enabled = False
        Me.btnFindAdmissionNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindAdmissionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindAdmissionNo.Image = CType(resources.GetObject("btnFindAdmissionNo.Image"), System.Drawing.Image)
        Me.btnFindAdmissionNo.Location = New System.Drawing.Point(128, 34)
        Me.btnFindAdmissionNo.Name = "btnFindAdmissionNo"
        Me.btnFindAdmissionNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindAdmissionNo.TabIndex = 5
        '
        'grpLocation
        '
        Me.grpLocation.Controls.Add(Me.cboBedNo)
        Me.grpLocation.Controls.Add(Me.lblBedNo)
        Me.grpLocation.Controls.Add(Me.cboWardsID)
        Me.grpLocation.Controls.Add(Me.lblWardsID)
        Me.grpLocation.Controls.Add(Me.cboRoomNo)
        Me.grpLocation.Controls.Add(Me.lblRoomNo)
        Me.grpLocation.Location = New System.Drawing.Point(4, 81)
        Me.grpLocation.Name = "grpLocation"
        Me.grpLocation.Size = New System.Drawing.Size(338, 87)
        Me.grpLocation.TabIndex = 9
        Me.grpLocation.TabStop = False
        Me.grpLocation.Text = "Location"
        '
        'lblBedNo
        '
        Me.lblBedNo.Location = New System.Drawing.Point(4, 61)
        Me.lblBedNo.Name = "lblBedNo"
        Me.lblBedNo.Size = New System.Drawing.Size(140, 20)
        Me.lblBedNo.TabIndex = 4
        Me.lblBedNo.Text = "Bed No"
        '
        'lblWardsID
        '
        Me.lblWardsID.Location = New System.Drawing.Point(4, 15)
        Me.lblWardsID.Name = "lblWardsID"
        Me.lblWardsID.Size = New System.Drawing.Size(140, 20)
        Me.lblWardsID.TabIndex = 0
        Me.lblWardsID.Text = "Ward"
        '
        'lblRoomNo
        '
        Me.lblRoomNo.Location = New System.Drawing.Point(4, 38)
        Me.lblRoomNo.Name = "lblRoomNo"
        Me.lblRoomNo.Size = New System.Drawing.Size(140, 20)
        Me.lblRoomNo.TabIndex = 2
        Me.lblRoomNo.Text = "Room No"
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(345, 163)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(119, 20)
        Me.lblBillCustomerName.TabIndex = 49
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(290, 9)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 3
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'lblStaff
        '
        Me.lblStaff.Location = New System.Drawing.Point(8, 58)
        Me.lblStaff.Name = "lblStaff"
        Me.lblStaff.Size = New System.Drawing.Size(140, 20)
        Me.lblStaff.TabIndex = 7
        Me.lblStaff.Text = "Attending Doctor (Staff)"
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Location = New System.Drawing.Point(345, 315)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(119, 20)
        Me.lblUnitPrice.TabIndex = 61
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'lblChatNo
        '
        Me.lblChatNo.Location = New System.Drawing.Point(4, 371)
        Me.lblChatNo.Name = "lblChatNo"
        Me.lblChatNo.Size = New System.Drawing.Size(140, 20)
        Me.lblChatNo.TabIndex = 28
        Me.lblChatNo.Text = "Chart Number"
        '
        'imgIDAutomation
        '
        Me.imgIDAutomation.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.imgIDAutomation.Location = New System.Drawing.Point(458, 335)
        Me.imgIDAutomation.Name = "imgIDAutomation"
        Me.imgIDAutomation.Size = New System.Drawing.Size(192, 53)
        Me.imgIDAutomation.TabIndex = 102
        Me.imgIDAutomation.TabStop = False
        '
        'btnPrintBarcode
        '
        Me.btnPrintBarcode.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintBarcode.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnPrintBarcode.Location = New System.Drawing.Point(528, 449)
        Me.btnPrintBarcode.Name = "btnPrintBarcode"
        Me.btnPrintBarcode.Size = New System.Drawing.Size(119, 24)
        Me.btnPrintBarcode.TabIndex = 67
        Me.btnPrintBarcode.Text = "&Print Patient Sticker"
        '
        'chkPrintAdmissionForm
        '
        Me.chkPrintAdmissionForm.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintAdmissionForm.AutoSize = True
        Me.chkPrintAdmissionForm.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chkPrintAdmissionForm.Checked = True
        Me.chkPrintAdmissionForm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintAdmissionForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPrintAdmissionForm.Location = New System.Drawing.Point(256, 541)
        Me.chkPrintAdmissionForm.Name = "chkPrintAdmissionForm"
        Me.chkPrintAdmissionForm.Size = New System.Drawing.Size(120, 17)
        Me.chkPrintAdmissionForm.TabIndex = 71
        Me.chkPrintAdmissionForm.Text = "Print Admission Form"
        Me.chkPrintAdmissionForm.UseVisualStyleBackColor = True
        '
        'lblAssociatedBillNo
        '
        Me.lblAssociatedBillNo.Enabled = False
        Me.lblAssociatedBillNo.Location = New System.Drawing.Point(4, 303)
        Me.lblAssociatedBillNo.Name = "lblAssociatedBillNo"
        Me.lblAssociatedBillNo.Size = New System.Drawing.Size(140, 20)
        Me.lblAssociatedBillNo.TabIndex = 22
        Me.lblAssociatedBillNo.Text = "Associated Bill Customer"
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(4, 193)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(140, 20)
        Me.lblBillMode.TabIndex = 12
        Me.lblBillMode.Text = "To-Bill Mode"
        '
        'lblMainMemberName
        '
        Me.lblMainMemberName.Location = New System.Drawing.Point(4, 259)
        Me.lblMainMemberName.Name = "lblMainMemberName"
        Me.lblMainMemberName.Size = New System.Drawing.Size(140, 20)
        Me.lblMainMemberName.TabIndex = 18
        Me.lblMainMemberName.Text = "Main Member Name"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(4, 215)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(140, 20)
        Me.lblBillNo.TabIndex = 14
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblClaimReferenceNo
        '
        Me.lblClaimReferenceNo.Location = New System.Drawing.Point(4, 281)
        Me.lblClaimReferenceNo.Name = "lblClaimReferenceNo"
        Me.lblClaimReferenceNo.Size = New System.Drawing.Size(140, 20)
        Me.lblClaimReferenceNo.TabIndex = 20
        Me.lblClaimReferenceNo.Text = "Claim Reference No"
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(4, 237)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(140, 20)
        Me.lblMemberCardNo.TabIndex = 16
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'lblAdmissionNotes
        '
        Me.lblAdmissionNotes.Location = New System.Drawing.Point(4, 449)
        Me.lblAdmissionNotes.Name = "lblAdmissionNotes"
        Me.lblAdmissionNotes.Size = New System.Drawing.Size(144, 20)
        Me.lblAdmissionNotes.TabIndex = 33
        Me.lblAdmissionNotes.Text = "Admission Notes"
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.Location = New System.Drawing.Point(345, 272)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(125, 20)
        Me.lblCoPayPercent.TabIndex = 57
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.Location = New System.Drawing.Point(346, 294)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(118, 20)
        Me.lblCoPayValue.TabIndex = 59
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'lblCoPayType
        '
        Me.lblCoPayType.Location = New System.Drawing.Point(346, 245)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(118, 20)
        Me.lblCoPayType.TabIndex = 55
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'lblInsuranceNo
        '
        Me.lblInsuranceNo.Location = New System.Drawing.Point(345, 195)
        Me.lblInsuranceNo.Name = "lblInsuranceNo"
        Me.lblInsuranceNo.Size = New System.Drawing.Size(119, 20)
        Me.lblInsuranceNo.TabIndex = 51
        Me.lblInsuranceNo.Text = "Insurance No"
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(346, 218)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(134, 20)
        Me.lblBillInsuranceName.TabIndex = 53
        Me.lblBillInsuranceName.Text = "To-Bill Insurance Name"
        '
        'lblAgeString
        '
        Me.lblAgeString.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgeString.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAgeString.Location = New System.Drawing.Point(540, 65)
        Me.lblAgeString.Name = "lblAgeString"
        Me.lblAgeString.Size = New System.Drawing.Size(120, 19)
        Me.lblAgeString.TabIndex = 43
        '
        'chkPrintAdmissionConsent
        '
        Me.chkPrintAdmissionConsent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintAdmissionConsent.AutoSize = True
        Me.chkPrintAdmissionConsent.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chkPrintAdmissionConsent.Checked = True
        Me.chkPrintAdmissionConsent.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintAdmissionConsent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPrintAdmissionConsent.Location = New System.Drawing.Point(385, 541)
        Me.chkPrintAdmissionConsent.Name = "chkPrintAdmissionConsent"
        Me.chkPrintAdmissionConsent.Size = New System.Drawing.Size(136, 17)
        Me.chkPrintAdmissionConsent.TabIndex = 72
        Me.chkPrintAdmissionConsent.Text = "Print Admission Consent"
        Me.chkPrintAdmissionConsent.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.chkPrintAdmissionConsent.UseVisualStyleBackColor = True
        '
        'lblCoverAmount
        '
        Me.lblCoverAmount.Location = New System.Drawing.Point(345, 398)
        Me.lblCoverAmount.Name = "lblCoverAmount"
        Me.lblCoverAmount.Size = New System.Drawing.Size(119, 20)
        Me.lblCoverAmount.TabIndex = 63
        Me.lblCoverAmount.Text = "Cover Amount"
        '
        'chkPrintAdmissionFaceSheet
        '
        Me.chkPrintAdmissionFaceSheet.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintAdmissionFaceSheet.AutoSize = True
        Me.chkPrintAdmissionFaceSheet.CheckAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.chkPrintAdmissionFaceSheet.Checked = True
        Me.chkPrintAdmissionFaceSheet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintAdmissionFaceSheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPrintAdmissionFaceSheet.Location = New System.Drawing.Point(95, 541)
        Me.chkPrintAdmissionFaceSheet.Name = "chkPrintAdmissionFaceSheet"
        Me.chkPrintAdmissionFaceSheet.Size = New System.Drawing.Size(152, 17)
        Me.chkPrintAdmissionFaceSheet.TabIndex = 70
        Me.chkPrintAdmissionFaceSheet.Text = "Print Admission Face Sheet"
        Me.chkPrintAdmissionFaceSheet.UseVisualStyleBackColor = True
        Me.chkPrintAdmissionFaceSheet.Visible = False
        '
        'nbxToBillServiceFee
        '
        Me.nbxToBillServiceFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxToBillServiceFee.ControlCaption = "Consultation Fee"
        Me.nbxToBillServiceFee.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxToBillServiceFee.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxToBillServiceFee.DecimalPlaces = -1
        Me.nbxToBillServiceFee.Location = New System.Drawing.Point(160, 350)
        Me.nbxToBillServiceFee.MaxValue = 0.0R
        Me.nbxToBillServiceFee.MinValue = 0.0R
        Me.nbxToBillServiceFee.MustEnterNumeric = True
        Me.nbxToBillServiceFee.Name = "nbxToBillServiceFee"
        Me.nbxToBillServiceFee.Size = New System.Drawing.Size(174, 20)
        Me.nbxToBillServiceFee.TabIndex = 27
        Me.nbxToBillServiceFee.Value = ""
        '
        'lblServiceCode
        '
        Me.lblServiceCode.Location = New System.Drawing.Point(4, 325)
        Me.lblServiceCode.Name = "lblServiceCode"
        Me.lblServiceCode.Size = New System.Drawing.Size(140, 20)
        Me.lblServiceCode.TabIndex = 24
        Me.lblServiceCode.Text = "To-Bill Service"
        '
        'lblServiceFee
        '
        Me.lblServiceFee.Location = New System.Drawing.Point(4, 347)
        Me.lblServiceFee.Name = "lblServiceFee"
        Me.lblServiceFee.Size = New System.Drawing.Size(140, 20)
        Me.lblServiceFee.TabIndex = 26
        Me.lblServiceFee.Text = "To-Bill Service Fee"
        '
        'lblProvisionalDiagnosis
        '
        Me.lblProvisionalDiagnosis.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProvisionalDiagnosis.Location = New System.Drawing.Point(4, 394)
        Me.lblProvisionalDiagnosis.Name = "lblProvisionalDiagnosis"
        Me.lblProvisionalDiagnosis.Size = New System.Drawing.Size(144, 20)
        Me.lblProvisionalDiagnosis.TabIndex = 30
        Me.lblProvisionalDiagnosis.Text = "Provisional Diagnosis"
        '
        'btnLoadProvisionalTemplate
        '
        Me.btnLoadProvisionalTemplate.BackColor = System.Drawing.SystemColors.Control
        Me.btnLoadProvisionalTemplate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadProvisionalTemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.25!, System.Drawing.FontStyle.Bold)
        Me.btnLoadProvisionalTemplate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLoadProvisionalTemplate.Image = CType(resources.GetObject("btnLoadProvisionalTemplate.Image"), System.Drawing.Image)
        Me.btnLoadProvisionalTemplate.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnLoadProvisionalTemplate.Location = New System.Drawing.Point(135, 393)
        Me.btnLoadProvisionalTemplate.Name = "btnLoadProvisionalTemplate"
        Me.btnLoadProvisionalTemplate.Size = New System.Drawing.Size(23, 19)
        Me.btnLoadProvisionalTemplate.TabIndex = 31
        Me.btnLoadProvisionalTemplate.UseVisualStyleBackColor = False
        '
        'frmAdmissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(659, 563)
        Me.Controls.Add(Me.btnLoadProvisionalTemplate)
        Me.Controls.Add(Me.stbProvisionalDiagnosis)
        Me.Controls.Add(Me.lblProvisionalDiagnosis)
        Me.Controls.Add(Me.nbxToBillServiceFee)
        Me.Controls.Add(Me.lblServiceCode)
        Me.Controls.Add(Me.cboServiceCode)
        Me.Controls.Add(Me.lblServiceFee)
        Me.Controls.Add(Me.chkPrintAdmissionFaceSheet)
        Me.Controls.Add(Me.nbxCoverAmount)
        Me.Controls.Add(Me.lblCoverAmount)
        Me.Controls.Add(Me.chkPrintAdmissionConsent)
        Me.Controls.Add(Me.lblAgeString)
        Me.Controls.Add(Me.chkSmartCardApplicable)
        Me.Controls.Add(Me.chkAccessCashServices)
        Me.Controls.Add(Me.stbInsuranceNo)
        Me.Controls.Add(Me.lblInsuranceNo)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.cboCoPayTypeID)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.stbAdmissionNotes)
        Me.Controls.Add(Me.lblAdmissionNotes)
        Me.Controls.Add(Me.cboAssociatedBillNo)
        Me.Controls.Add(Me.lblAssociatedBillNo)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.cboBillModesID)
        Me.Controls.Add(Me.stbMainMemberName)
        Me.Controls.Add(Me.lblMainMemberName)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.stbClaimReferenceNo)
        Me.Controls.Add(Me.lblClaimReferenceNo)
        Me.Controls.Add(Me.cboBillNo)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.chkPrintAdmissionForm)
        Me.Controls.Add(Me.btnPrintBarcode)
        Me.Controls.Add(Me.imgIDAutomation)
        Me.Controls.Add(Me.stbChartNumber)
        Me.Controls.Add(Me.lblChatNo)
        Me.Controls.Add(Me.nbxUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.lblStaff)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.grpLocation)
        Me.Controls.Add(Me.btnFindAdmissionNo)
        Me.Controls.Add(Me.pnlAdmissionStatusID)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbServiceName)
        Me.Controls.Add(Me.lblServiceName)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbAdmissionNo)
        Me.Controls.Add(Me.lblAdmissionNo)
        Me.Controls.Add(Me.dtpAdmissionDateTime)
        Me.Controls.Add(Me.lblAdmissionDateTime)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmAdmissions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Admissions"
        Me.pnlAdmissionStatusID.ResumeLayout(False)
        Me.grpLocation.ResumeLayout(False)
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionNo As System.Windows.Forms.Label
    Friend WithEvents dtpAdmissionDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAdmissionDateTime As System.Windows.Forms.Label
    Friend WithEvents cboAdmissionStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAdmissionStatusID As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbServiceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblServiceName As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents pnlAdmissionStatusID As System.Windows.Forms.Panel
    Friend WithEvents btnFindAdmissionNo As System.Windows.Forms.Button
    Friend WithEvents grpLocation As System.Windows.Forms.GroupBox
    Friend WithEvents cboWardsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblWardsID As System.Windows.Forms.Label
    Friend WithEvents cboRoomNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblRoomNo As System.Windows.Forms.Label
    Friend WithEvents lblBedNo As System.Windows.Forms.Label
    Friend WithEvents cboBedNo As System.Windows.Forms.ComboBox
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaff As System.Windows.Forms.Label
    Friend WithEvents nbxUnitPrice As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents stbChartNumber As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblChatNo As System.Windows.Forms.Label
    Friend WithEvents imgIDAutomation As System.Windows.Forms.PictureBox
    Friend WithEvents btnPrintBarcode As System.Windows.Forms.Button
    Friend WithEvents chkPrintAdmissionForm As System.Windows.Forms.CheckBox
    Friend WithEvents cboAssociatedBillNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblAssociatedBillNo As System.Windows.Forms.Label
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents cboBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents stbMainMemberName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMainMemberName As System.Windows.Forms.Label
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents stbClaimReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClaimReferenceNo As System.Windows.Forms.Label
    Friend WithEvents cboBillNo As System.Windows.Forms.ComboBox
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionNotes As System.Windows.Forms.Label
    Friend WithEvents cboCoPayTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents stbInsuranceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceNo As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents chkSmartCardApplicable As System.Windows.Forms.CheckBox
    Friend WithEvents chkAccessCashServices As System.Windows.Forms.CheckBox
    Friend WithEvents lblAgeString As System.Windows.Forms.Label
    Friend WithEvents chkPrintAdmissionConsent As System.Windows.Forms.CheckBox
    Friend WithEvents nbxCoverAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoverAmount As System.Windows.Forms.Label
    Friend WithEvents chkPrintAdmissionFaceSheet As System.Windows.Forms.CheckBox
    Friend WithEvents nbxToBillServiceFee As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblServiceCode As System.Windows.Forms.Label
    Friend WithEvents cboServiceCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblServiceFee As System.Windows.Forms.Label
    Friend WithEvents lblProvisionalDiagnosis As System.Windows.Forms.Label
    Friend WithEvents stbProvisionalDiagnosis As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadProvisionalTemplate As System.Windows.Forms.Button

End Class