
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHIVCARE : Inherits System.Windows.Forms.Form
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal keyNo As String, ByVal itemsKeyNo As ItemsKeyNo)
        MyClass.New()
        Me.defaultKeyNo = keyNo
        Me.patientsKeyNo = itemsKeyNo
    End Sub

    Public Sub New(ByVal CurrentPatient As CurrentPatient)
        MyClass.New()
        Me.oCurrentPatient = CurrentPatient
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHIVCARE))
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle55 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle53 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle54 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tbcPatientsEXTRA = New System.Windows.Forms.TabControl()
        Me.tpgGeneral = New System.Windows.Forms.TabPage()
        Me.stbInsuranceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInsuranceNo = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.nbxOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOutstandingBalance = New System.Windows.Forms.Label()
        Me.stbTotalVisits = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalVisits = New System.Windows.Forms.Label()
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnFindPatientNo = New System.Windows.Forms.Button()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.stbPtClinic = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPtClinic = New System.Windows.Forms.Label()
        Me.stbLC1 = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLC1 = New System.Windows.Forms.Label()
        Me.chkFingerprintCaptured = New System.Windows.Forms.CheckBox()
        Me.btnEnrollFingerprint = New System.Windows.Forms.Button()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.lblStaffNo = New System.Windows.Forms.Label()
        Me.cboDistrictsID = New System.Windows.Forms.ComboBox()
        Me.lblDistrictsID = New System.Windows.Forms.Label()
        Me.stbReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblReferenceNo = New System.Windows.Forms.Label()
        Me.cboHealthUnitCode = New System.Windows.Forms.ComboBox()
        Me.lblHealthUnitCode = New System.Windows.Forms.Label()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.tpgFamilyMembers = New System.Windows.Forms.TabPage()
        Me.dgvFamilyMembers = New System.Windows.Forms.DataGridView()
        Me.colMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHIVStatusID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colHIVCareID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colFamilyMembersUniqueNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFamilyMembersSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgExposedInfants = New System.Windows.Forms.TabPage()
        Me.dgvExposedInfants = New System.Windows.Forms.DataGridView()
        Me.colInfantName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBirthDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInfantFeedingID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colCTXStarted = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHIVTestTypeID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colTestResultsID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInfantStatusID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colExposedInfantsUniqueNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExposedInfantsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgPriorARTDetails = New System.Windows.Forms.TabPage()
        Me.dgvPriorARTDetails = New System.Windows.Forms.DataGridView()
        Me.colPriorARTID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colARTDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colARTWhere = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCombination = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPriorARTDetailsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgHIVCare = New System.Windows.Forms.TabPage()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.chkPCRInfant = New System.Windows.Forms.CheckBox()
        Me.chkPresumptiveHIV = New System.Windows.Forms.CheckBox()
        Me.nbxCD4 = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCD4 = New System.Windows.Forms.Label()
        Me.cboWHOStageID = New System.Windows.Forms.ComboBox()
        Me.lblWHOStageID = New System.Windows.Forms.Label()
        Me.stbTransferInFrom = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.chkHIVCareTransferIn = New System.Windows.Forms.CheckBox()
        Me.stbHIVCareWhere = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblHIVCareWhere = New System.Windows.Forms.Label()
        Me.chkAb = New System.Windows.Forms.CheckBox()
        Me.chkPCR = New System.Windows.Forms.CheckBox()
        Me.dtpConfirmedTestDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpEligibleReadyDate = New System.Windows.Forms.DateTimePicker()
        Me.lblConfirmedTestDate = New System.Windows.Forms.Label()
        Me.lblEligibleReadyDate = New System.Windows.Forms.Label()
        Me.dtpHIVEnrolledDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEligibleARTDate = New System.Windows.Forms.Label()
        Me.lblHIVEnrolledDate = New System.Windows.Forms.Label()
        Me.dtpEligibleARTDate = New System.Windows.Forms.DateTimePicker()
        Me.tpgMedicalConditions = New System.Windows.Forms.TabPage()
        Me.stbMedicalConditions = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMedicalConditions = New System.Windows.Forms.Label()
        Me.tpgARTCare = New System.Windows.Forms.TabPage()
        Me.cboCOHORTYear = New System.Windows.Forms.ComboBox()
        Me.cboCOHORTMonth = New System.Windows.Forms.ComboBox()
        Me.dtpStartARTDate = New System.Windows.Forms.DateTimePicker()
        Me.cboStartARTRegimen = New System.Windows.Forms.ComboBox()
        Me.lblStartARTRegimen = New System.Windows.Forms.Label()
        Me.nbxStartARTWeight = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblStartARTWeight = New System.Windows.Forms.Label()
        Me.cboStartARTWHOStageID = New System.Windows.Forms.ComboBox()
        Me.lblStartARTWHOStageID = New System.Windows.Forms.Label()
        Me.nbxStartARTCD4 = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblStartARTCD4 = New System.Windows.Forms.Label()
        Me.cboPregnancyStatusID = New System.Windows.Forms.ComboBox()
        Me.lblPregnancyStatusID = New System.Windows.Forms.Label()
        Me.cboTransferInRegimen = New System.Windows.Forms.ComboBox()
        Me.lblTransferInRegimen = New System.Windows.Forms.Label()
        Me.lblCOHORTMonth = New System.Windows.Forms.Label()
        Me.lblCOHORTYear = New System.Windows.Forms.Label()
        Me.dtpARTTransferInDate = New System.Windows.Forms.DateTimePicker()
        Me.lblARTTransferInDate = New System.Windows.Forms.Label()
        Me.stbARTTransferInFrom = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblARTTransferInFrom = New System.Windows.Forms.Label()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tbcPatientsEXTRA.SuspendLayout()
        Me.tpgGeneral.SuspendLayout()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgFamilyMembers.SuspendLayout()
        CType(Me.dgvFamilyMembers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgExposedInfants.SuspendLayout()
        CType(Me.dgvExposedInfants, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPriorARTDetails.SuspendLayout()
        CType(Me.dgvPriorARTDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgHIVCare.SuspendLayout()
        Me.tpgMedicalConditions.SuspendLayout()
        Me.tpgARTCare.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbcPatientsEXTRA
        '
        Me.tbcPatientsEXTRA.Controls.Add(Me.tpgGeneral)
        Me.tbcPatientsEXTRA.Controls.Add(Me.tpgFamilyMembers)
        Me.tbcPatientsEXTRA.Controls.Add(Me.tpgExposedInfants)
        Me.tbcPatientsEXTRA.Controls.Add(Me.tpgPriorARTDetails)
        Me.tbcPatientsEXTRA.Controls.Add(Me.tpgHIVCare)
        Me.tbcPatientsEXTRA.Controls.Add(Me.tpgMedicalConditions)
        Me.tbcPatientsEXTRA.Controls.Add(Me.tpgARTCare)
        Me.tbcPatientsEXTRA.HotTrack = True
        Me.tbcPatientsEXTRA.Location = New System.Drawing.Point(12, 3)
        Me.tbcPatientsEXTRA.Name = "tbcPatientsEXTRA"
        Me.tbcPatientsEXTRA.SelectedIndex = 0
        Me.tbcPatientsEXTRA.Size = New System.Drawing.Size(715, 331)
        Me.tbcPatientsEXTRA.TabIndex = 68
        '
        'tpgGeneral
        '
        Me.tpgGeneral.Controls.Add(Me.stbInsuranceNo)
        Me.tpgGeneral.Controls.Add(Me.lblInsuranceNo)
        Me.tpgGeneral.Controls.Add(Me.stbInsuranceName)
        Me.tpgGeneral.Controls.Add(Me.lblBillInsuranceName)
        Me.tpgGeneral.Controls.Add(Me.nbxOutstandingBalance)
        Me.tpgGeneral.Controls.Add(Me.lblOutstandingBalance)
        Me.tpgGeneral.Controls.Add(Me.stbTotalVisits)
        Me.tpgGeneral.Controls.Add(Me.lblTotalVisits)
        Me.tpgGeneral.Controls.Add(Me.stbLastVisitDate)
        Me.tpgGeneral.Controls.Add(Me.lblLastVisitDate)
        Me.tpgGeneral.Controls.Add(Me.stbPhone)
        Me.tpgGeneral.Controls.Add(Me.lblPhone)
        Me.tpgGeneral.Controls.Add(Me.stbAge)
        Me.tpgGeneral.Controls.Add(Me.stbJoinDate)
        Me.tpgGeneral.Controls.Add(Me.stbGender)
        Me.tpgGeneral.Controls.Add(Me.Label1)
        Me.tpgGeneral.Controls.Add(Me.Label2)
        Me.tpgGeneral.Controls.Add(Me.Label3)
        Me.tpgGeneral.Controls.Add(Me.stbFullName)
        Me.tpgGeneral.Controls.Add(Me.lblName)
        Me.tpgGeneral.Controls.Add(Me.btnLoad)
        Me.tpgGeneral.Controls.Add(Me.btnFindPatientNo)
        Me.tpgGeneral.Controls.Add(Me.stbPatientNo)
        Me.tpgGeneral.Controls.Add(Me.lblPatientNo)
        Me.tpgGeneral.Controls.Add(Me.stbPtClinic)
        Me.tpgGeneral.Controls.Add(Me.lblPtClinic)
        Me.tpgGeneral.Controls.Add(Me.stbLC1)
        Me.tpgGeneral.Controls.Add(Me.lblLC1)
        Me.tpgGeneral.Controls.Add(Me.chkFingerprintCaptured)
        Me.tpgGeneral.Controls.Add(Me.btnEnrollFingerprint)
        Me.tpgGeneral.Controls.Add(Me.cboStaffNo)
        Me.tpgGeneral.Controls.Add(Me.lblStaffNo)
        Me.tpgGeneral.Controls.Add(Me.cboDistrictsID)
        Me.tpgGeneral.Controls.Add(Me.lblDistrictsID)
        Me.tpgGeneral.Controls.Add(Me.stbReferenceNo)
        Me.tpgGeneral.Controls.Add(Me.lblReferenceNo)
        Me.tpgGeneral.Controls.Add(Me.cboHealthUnitCode)
        Me.tpgGeneral.Controls.Add(Me.lblHealthUnitCode)
        Me.tpgGeneral.Controls.Add(Me.spbPhoto)
        Me.tpgGeneral.Controls.Add(Me.lblPhoto)
        Me.tpgGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tpgGeneral.Name = "tpgGeneral"
        Me.tpgGeneral.Size = New System.Drawing.Size(707, 305)
        Me.tpgGeneral.TabIndex = 8
        Me.tpgGeneral.Tag = "Patients"
        Me.tpgGeneral.Text = "General"
        Me.tpgGeneral.UseVisualStyleBackColor = True
        '
        'stbInsuranceNo
        '
        Me.stbInsuranceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceNo.CapitalizeFirstLetter = False
        Me.stbInsuranceNo.EntryErrorMSG = ""
        Me.stbInsuranceNo.Location = New System.Drawing.Point(513, 227)
        Me.stbInsuranceNo.MaxLength = 20
        Me.stbInsuranceNo.Name = "stbInsuranceNo"
        Me.stbInsuranceNo.ReadOnly = True
        Me.stbInsuranceNo.RegularExpression = ""
        Me.stbInsuranceNo.Size = New System.Drawing.Size(149, 20)
        Me.stbInsuranceNo.TabIndex = 136
        '
        'lblInsuranceNo
        '
        Me.lblInsuranceNo.Location = New System.Drawing.Point(346, 228)
        Me.lblInsuranceNo.Name = "lblInsuranceNo"
        Me.lblInsuranceNo.Size = New System.Drawing.Size(148, 20)
        Me.lblInsuranceNo.TabIndex = 135
        Me.lblInsuranceNo.Text = "Insurance No"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(513, 248)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(149, 34)
        Me.stbInsuranceName.TabIndex = 138
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(346, 257)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(148, 20)
        Me.lblBillInsuranceName.TabIndex = 137
        Me.lblBillInsuranceName.Text = "To-Bill Insurance Name"
        '
        'nbxOutstandingBalance
        '
        Me.nbxOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOutstandingBalance.DecimalPlaces = -1
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(513, 206)
        Me.nbxOutstandingBalance.MaxValue = 0.0R
        Me.nbxOutstandingBalance.MinValue = 0.0R
        Me.nbxOutstandingBalance.MustEnterNumeric = True
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = True
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(149, 20)
        Me.nbxOutstandingBalance.TabIndex = 134
        Me.nbxOutstandingBalance.Value = ""
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(346, 208)
        Me.lblOutstandingBalance.Name = "lblOutstandingBalance"
        Me.lblOutstandingBalance.Size = New System.Drawing.Size(148, 20)
        Me.lblOutstandingBalance.TabIndex = 133
        Me.lblOutstandingBalance.Text = "Outstanding Balance"
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalVisits.CapitalizeFirstLetter = False
        Me.stbTotalVisits.Enabled = False
        Me.stbTotalVisits.EntryErrorMSG = ""
        Me.stbTotalVisits.Location = New System.Drawing.Point(513, 185)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(149, 20)
        Me.stbTotalVisits.TabIndex = 132
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(346, 186)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(148, 20)
        Me.lblTotalVisits.TabIndex = 131
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.CapitalizeFirstLetter = False
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.EntryErrorMSG = ""
        Me.stbLastVisitDate.Location = New System.Drawing.Point(513, 164)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.RegularExpression = ""
        Me.stbLastVisitDate.Size = New System.Drawing.Size(149, 20)
        Me.stbLastVisitDate.TabIndex = 130
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(346, 166)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(148, 20)
        Me.lblLastVisitDate.TabIndex = 129
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.stbPhone.Enabled = False
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(170, 74)
        Me.stbPhone.MaxLength = 60
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPhone.Size = New System.Drawing.Size(149, 20)
        Me.stbPhone.TabIndex = 128
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(11, 76)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(151, 20)
        Me.lblPhone.TabIndex = 127
        Me.lblPhone.Text = "Phone"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(170, 51)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(44, 20)
        Me.stbAge.TabIndex = 122
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(513, 120)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(149, 20)
        Me.stbJoinDate.TabIndex = 126
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(170, 95)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(149, 20)
        Me.stbGender.TabIndex = 124
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(346, 122)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 20)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Join Date"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(11, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(151, 20)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Age"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(11, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 20)
        Me.Label3.TabIndex = 123
        Me.Label3.Text = "Gender"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(170, 30)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(149, 20)
        Me.stbFullName.TabIndex = 120
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(11, 32)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(151, 20)
        Me.lblName.TabIndex = 119
        Me.lblName.Text = "Patient's Name"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(278, 4)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 118
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'btnFindPatientNo
        '
        Me.btnFindPatientNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindPatientNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindPatientNo.Image = CType(resources.GetObject("btnFindPatientNo.Image"), System.Drawing.Image)
        Me.btnFindPatientNo.Location = New System.Drawing.Point(137, 6)
        Me.btnFindPatientNo.Name = "btnFindPatientNo"
        Me.btnFindPatientNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindPatientNo.TabIndex = 116
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(170, 8)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(102, 20)
        Me.stbPatientNo.TabIndex = 117
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(11, 8)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(151, 20)
        Me.lblPatientNo.TabIndex = 115
        Me.lblPatientNo.Text = "Patient's Number"
        '
        'stbPtClinic
        '
        Me.stbPtClinic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPtClinic.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPtClinic, "PtClinic")
        Me.stbPtClinic.EntryErrorMSG = ""
        Me.stbPtClinic.Location = New System.Drawing.Point(170, 189)
        Me.stbPtClinic.Name = "stbPtClinic"
        Me.stbPtClinic.RegularExpression = ""
        Me.stbPtClinic.Size = New System.Drawing.Size(149, 20)
        Me.stbPtClinic.TabIndex = 111
        '
        'lblPtClinic
        '
        Me.lblPtClinic.Location = New System.Drawing.Point(11, 191)
        Me.lblPtClinic.Name = "lblPtClinic"
        Me.lblPtClinic.Size = New System.Drawing.Size(151, 20)
        Me.lblPtClinic.TabIndex = 112
        Me.lblPtClinic.Text = "Pt Clinic"
        '
        'stbLC1
        '
        Me.stbLC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLC1.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbLC1, "LC1")
        Me.stbLC1.EntryErrorMSG = ""
        Me.stbLC1.Location = New System.Drawing.Point(170, 212)
        Me.stbLC1.Multiline = True
        Me.stbLC1.Name = "stbLC1"
        Me.stbLC1.RegularExpression = ""
        Me.stbLC1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbLC1.Size = New System.Drawing.Size(149, 64)
        Me.stbLC1.TabIndex = 113
        '
        'lblLC1
        '
        Me.lblLC1.Location = New System.Drawing.Point(11, 214)
        Me.lblLC1.Name = "lblLC1"
        Me.lblLC1.Size = New System.Drawing.Size(151, 20)
        Me.lblLC1.TabIndex = 114
        Me.lblLC1.Text = "LC1"
        '
        'chkFingerprintCaptured
        '
        Me.chkFingerprintCaptured.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkFingerprintCaptured.Enabled = False
        Me.chkFingerprintCaptured.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkFingerprintCaptured.Location = New System.Drawing.Point(349, 38)
        Me.chkFingerprintCaptured.Name = "chkFingerprintCaptured"
        Me.chkFingerprintCaptured.Size = New System.Drawing.Size(171, 21)
        Me.chkFingerprintCaptured.TabIndex = 109
        Me.chkFingerprintCaptured.Text = "Fingerprint Captured"
        '
        'btnEnrollFingerprint
        '
        Me.btnEnrollFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEnrollFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnrollFingerprint.Location = New System.Drawing.Point(349, 65)
        Me.btnEnrollFingerprint.Name = "btnEnrollFingerprint"
        Me.btnEnrollFingerprint.Size = New System.Drawing.Size(171, 23)
        Me.btnEnrollFingerprint.TabIndex = 110
        Me.btnEnrollFingerprint.Text = "Enroll Fingerprint"
        Me.btnEnrollFingerprint.UseVisualStyleBackColor = True
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
        Me.cboStaffNo.Location = New System.Drawing.Point(170, 164)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(149, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 74
        '
        'lblStaffNo
        '
        Me.lblStaffNo.Location = New System.Drawing.Point(11, 167)
        Me.lblStaffNo.Name = "lblStaffNo"
        Me.lblStaffNo.Size = New System.Drawing.Size(151, 20)
        Me.lblStaffNo.TabIndex = 73
        Me.lblStaffNo.Text = "Clinical Team Leader"
        '
        'cboDistrictsID
        '
        Me.cboDistrictsID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDistrictsID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboDistrictsID, "District,DistrictsID")
        Me.cboDistrictsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDistrictsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDistrictsID.Location = New System.Drawing.Point(170, 118)
        Me.cboDistrictsID.Name = "cboDistrictsID"
        Me.cboDistrictsID.Size = New System.Drawing.Size(149, 21)
        Me.cboDistrictsID.TabIndex = 70
        '
        'lblDistrictsID
        '
        Me.lblDistrictsID.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistrictsID.Location = New System.Drawing.Point(11, 118)
        Me.lblDistrictsID.Name = "lblDistrictsID"
        Me.lblDistrictsID.Size = New System.Drawing.Size(151, 20)
        Me.lblDistrictsID.TabIndex = 69
        Me.lblDistrictsID.Text = "District"
        '
        'stbReferenceNo
        '
        Me.stbReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferenceNo.CapitalizeFirstLetter = False
        Me.stbReferenceNo.Enabled = False
        Me.stbReferenceNo.EntryErrorMSG = ""
        Me.stbReferenceNo.Location = New System.Drawing.Point(513, 142)
        Me.stbReferenceNo.Name = "stbReferenceNo"
        Me.stbReferenceNo.RegularExpression = ""
        Me.stbReferenceNo.Size = New System.Drawing.Size(149, 20)
        Me.stbReferenceNo.TabIndex = 82
        '
        'lblReferenceNo
        '
        Me.lblReferenceNo.Location = New System.Drawing.Point(346, 141)
        Me.lblReferenceNo.Name = "lblReferenceNo"
        Me.lblReferenceNo.Size = New System.Drawing.Size(148, 20)
        Me.lblReferenceNo.TabIndex = 81
        Me.lblReferenceNo.Text = "Reference No"
        '
        'cboHealthUnitCode
        '
        Me.cboHealthUnitCode.AccessibleDescription = " "
        Me.cboHealthUnitCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboHealthUnitCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboHealthUnitCode, "HealthUnitName,HealthUnitCode")
        Me.cboHealthUnitCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHealthUnitCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHealthUnitCode.Location = New System.Drawing.Point(170, 141)
        Me.cboHealthUnitCode.Name = "cboHealthUnitCode"
        Me.cboHealthUnitCode.Size = New System.Drawing.Size(149, 21)
        Me.cboHealthUnitCode.TabIndex = 72
        '
        'lblHealthUnitCode
        '
        Me.lblHealthUnitCode.Location = New System.Drawing.Point(11, 141)
        Me.lblHealthUnitCode.Name = "lblHealthUnitCode"
        Me.lblHealthUnitCode.Size = New System.Drawing.Size(151, 20)
        Me.lblHealthUnitCode.TabIndex = 71
        Me.lblHealthUnitCode.Text = "Health Unit"
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(526, 9)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = False
        Me.spbPhoto.Size = New System.Drawing.Size(108, 105)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 108
        Me.spbPhoto.TabStop = False
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(350, 11)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(171, 20)
        Me.lblPhoto.TabIndex = 105
        Me.lblPhoto.Text = "Photo"
        '
        'tpgFamilyMembers
        '
        Me.tpgFamilyMembers.Controls.Add(Me.dgvFamilyMembers)
        Me.tpgFamilyMembers.Location = New System.Drawing.Point(4, 22)
        Me.tpgFamilyMembers.Name = "tpgFamilyMembers"
        Me.tpgFamilyMembers.Size = New System.Drawing.Size(707, 305)
        Me.tpgFamilyMembers.TabIndex = 2
        Me.tpgFamilyMembers.Tag = "FamilyMembers"
        Me.tpgFamilyMembers.Text = "Family Members"
        Me.tpgFamilyMembers.UseVisualStyleBackColor = True
        '
        'dgvFamilyMembers
        '
        Me.dgvFamilyMembers.AllowUserToOrderColumns = True
        Me.dgvFamilyMembers.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle45.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFamilyMembers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle45
        Me.dgvFamilyMembers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMemberName, Me.colAge, Me.colHIVStatusID, Me.colHIVCareID, Me.colFamilyMembersUniqueNo, Me.colFamilyMembersSaved})
        Me.dgvFamilyMembers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFamilyMembers.EnableHeadersVisualStyles = False
        Me.dgvFamilyMembers.GridColor = System.Drawing.Color.Khaki
        Me.dgvFamilyMembers.Location = New System.Drawing.Point(0, 0)
        Me.dgvFamilyMembers.Name = "dgvFamilyMembers"
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle48.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvFamilyMembers.RowHeadersDefaultCellStyle = DataGridViewCellStyle48
        Me.dgvFamilyMembers.Size = New System.Drawing.Size(707, 305)
        Me.dgvFamilyMembers.TabIndex = 0
        Me.dgvFamilyMembers.Text = "DataGridView1"
        '
        'colMemberName
        '
        Me.colMemberName.DataPropertyName = "MemberName"
        Me.colMemberName.HeaderText = "Member Name"
        Me.colMemberName.MaxInputLength = 20
        Me.colMemberName.Name = "colMemberName"
        Me.colMemberName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colMemberName.Width = 200
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        DataGridViewCellStyle46.Format = "N0"
        DataGridViewCellStyle46.NullValue = Nothing
        Me.colAge.DefaultCellStyle = DataGridViewCellStyle46
        Me.colAge.HeaderText = "Age"
        Me.colAge.MaxInputLength = 3
        Me.colAge.Name = "colAge"
        Me.colAge.Width = 50
        '
        'colHIVStatusID
        '
        Me.colHIVStatusID.DataPropertyName = "HIVStatusID"
        Me.colHIVStatusID.DisplayStyleForCurrentCellOnly = True
        Me.colHIVStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colHIVStatusID.HeaderText = "HIV Status"
        Me.colHIVStatusID.Name = "colHIVStatusID"
        Me.colHIVStatusID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colHIVStatusID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colHIVStatusID.Width = 125
        '
        'colHIVCareID
        '
        Me.colHIVCareID.DataPropertyName = "HIVCareID"
        Me.colHIVCareID.DisplayStyleForCurrentCellOnly = True
        Me.colHIVCareID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colHIVCareID.HeaderText = "HIV Care"
        Me.colHIVCareID.Name = "colHIVCareID"
        Me.colHIVCareID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colHIVCareID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colHIVCareID.Width = 75
        '
        'colFamilyMembersUniqueNo
        '
        Me.colFamilyMembersUniqueNo.DataPropertyName = "UniqueNo"
        Me.colFamilyMembersUniqueNo.HeaderText = "Unique No"
        Me.colFamilyMembersUniqueNo.Name = "colFamilyMembersUniqueNo"
        '
        'colFamilyMembersSaved
        '
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle47.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle47.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle47.NullValue = False
        Me.colFamilyMembersSaved.DefaultCellStyle = DataGridViewCellStyle47
        Me.colFamilyMembersSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colFamilyMembersSaved.HeaderText = "Saved"
        Me.colFamilyMembersSaved.Name = "colFamilyMembersSaved"
        Me.colFamilyMembersSaved.ReadOnly = True
        Me.colFamilyMembersSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colFamilyMembersSaved.Width = 50
        '
        'tpgExposedInfants
        '
        Me.tpgExposedInfants.Controls.Add(Me.dgvExposedInfants)
        Me.tpgExposedInfants.Location = New System.Drawing.Point(4, 22)
        Me.tpgExposedInfants.Name = "tpgExposedInfants"
        Me.tpgExposedInfants.Size = New System.Drawing.Size(707, 305)
        Me.tpgExposedInfants.TabIndex = 1
        Me.tpgExposedInfants.Tag = "ExposedInfants"
        Me.tpgExposedInfants.Text = "Exposed Infant follow-up"
        Me.tpgExposedInfants.UseVisualStyleBackColor = True
        '
        'dgvExposedInfants
        '
        Me.dgvExposedInfants.AllowUserToOrderColumns = True
        Me.dgvExposedInfants.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle49.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExposedInfants.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle49
        Me.dgvExposedInfants.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInfantName, Me.colBirthDate, Me.colInfantFeedingID, Me.colCTXStarted, Me.colHIVTestTypeID, Me.colTestResultsID, Me.colInfantStatusID, Me.colExposedInfantsUniqueNo, Me.colExposedInfantsSaved})
        Me.dgvExposedInfants.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvExposedInfants.EnableHeadersVisualStyles = False
        Me.dgvExposedInfants.GridColor = System.Drawing.Color.Khaki
        Me.dgvExposedInfants.Location = New System.Drawing.Point(0, 0)
        Me.dgvExposedInfants.Name = "dgvExposedInfants"
        DataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle51.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle51.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle51.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle51.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle51.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExposedInfants.RowHeadersDefaultCellStyle = DataGridViewCellStyle51
        Me.dgvExposedInfants.Size = New System.Drawing.Size(707, 305)
        Me.dgvExposedInfants.TabIndex = 0
        Me.dgvExposedInfants.Text = "DataGridView1"
        '
        'colInfantName
        '
        Me.colInfantName.DataPropertyName = "InfantName"
        Me.colInfantName.HeaderText = "Exposed Infant (Name/#)"
        Me.colInfantName.MaxInputLength = 41
        Me.colInfantName.Name = "colInfantName"
        Me.colInfantName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colInfantName.Width = 150
        '
        'colBirthDate
        '
        Me.colBirthDate.DataPropertyName = "BirthDate"
        Me.colBirthDate.HeaderText = "DOB"
        Me.colBirthDate.Name = "colBirthDate"
        '
        'colInfantFeedingID
        '
        Me.colInfantFeedingID.DataPropertyName = "InfantFeedingID"
        Me.colInfantFeedingID.DisplayStyleForCurrentCellOnly = True
        Me.colInfantFeedingID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInfantFeedingID.HeaderText = "Infant feeding practice"
        Me.colInfantFeedingID.Name = "colInfantFeedingID"
        Me.colInfantFeedingID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colInfantFeedingID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colCTXStarted
        '
        Me.colCTXStarted.DataPropertyName = "CTXStarted"
        Me.colCTXStarted.HeaderText = "CTX Started"
        Me.colCTXStarted.Name = "colCTXStarted"
        '
        'colHIVTestTypeID
        '
        Me.colHIVTestTypeID.DataPropertyName = "HIVTestTypeID"
        Me.colHIVTestTypeID.DisplayStyleForCurrentCellOnly = True
        Me.colHIVTestTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colHIVTestTypeID.HeaderText = "HIV Test Type"
        Me.colHIVTestTypeID.Name = "colHIVTestTypeID"
        Me.colHIVTestTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colHIVTestTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colTestResultsID
        '
        Me.colTestResultsID.DataPropertyName = "TestResultsID"
        Me.colTestResultsID.DisplayStyleForCurrentCellOnly = True
        Me.colTestResultsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTestResultsID.HeaderText = "Test Result"
        Me.colTestResultsID.Name = "colTestResultsID"
        Me.colTestResultsID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTestResultsID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colInfantStatusID
        '
        Me.colInfantStatusID.DataPropertyName = "InfantStatusID"
        Me.colInfantStatusID.DisplayStyleForCurrentCellOnly = True
        Me.colInfantStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInfantStatusID.HeaderText = "Final Status"
        Me.colInfantStatusID.Name = "colInfantStatusID"
        Me.colInfantStatusID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colInfantStatusID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colExposedInfantsUniqueNo
        '
        Me.colExposedInfantsUniqueNo.DataPropertyName = "UniqueNo"
        Me.colExposedInfantsUniqueNo.HeaderText = "Unique ID"
        Me.colExposedInfantsUniqueNo.Name = "colExposedInfantsUniqueNo"
        '
        'colExposedInfantsSaved
        '
        DataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle50.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle50.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle50.NullValue = False
        Me.colExposedInfantsSaved.DefaultCellStyle = DataGridViewCellStyle50
        Me.colExposedInfantsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExposedInfantsSaved.HeaderText = "Saved"
        Me.colExposedInfantsSaved.Name = "colExposedInfantsSaved"
        Me.colExposedInfantsSaved.ReadOnly = True
        Me.colExposedInfantsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colExposedInfantsSaved.Width = 50
        '
        'tpgPriorARTDetails
        '
        Me.tpgPriorARTDetails.Controls.Add(Me.dgvPriorARTDetails)
        Me.tpgPriorARTDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgPriorARTDetails.Name = "tpgPriorARTDetails"
        Me.tpgPriorARTDetails.Size = New System.Drawing.Size(707, 305)
        Me.tpgPriorARTDetails.TabIndex = 4
        Me.tpgPriorARTDetails.Tag = "PriorARTDetails"
        Me.tpgPriorARTDetails.Text = "Prior ART"
        Me.tpgPriorARTDetails.UseVisualStyleBackColor = True
        '
        'dgvPriorARTDetails
        '
        Me.dgvPriorARTDetails.AllowUserToOrderColumns = True
        Me.dgvPriorARTDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle52.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle52.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle52.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle52.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle52.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPriorARTDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle52
        Me.dgvPriorARTDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPriorARTID, Me.colARTDate, Me.colARTWhere, Me.colCombination, Me.colPriorARTDetailsSaved})
        Me.dgvPriorARTDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPriorARTDetails.EnableHeadersVisualStyles = False
        Me.dgvPriorARTDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvPriorARTDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvPriorARTDetails.Name = "dgvPriorARTDetails"
        DataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle55.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle55.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle55.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle55.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle55.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPriorARTDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle55
        Me.dgvPriorARTDetails.Size = New System.Drawing.Size(707, 305)
        Me.dgvPriorARTDetails.TabIndex = 0
        Me.dgvPriorARTDetails.Text = "DataGridView1"
        '
        'colPriorARTID
        '
        Me.colPriorARTID.DataPropertyName = "PriorARTID"
        Me.colPriorARTID.DisplayStyleForCurrentCellOnly = True
        Me.colPriorARTID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPriorARTID.HeaderText = "Prior ART"
        Me.colPriorARTID.Name = "colPriorARTID"
        Me.colPriorARTID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPriorARTID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colARTDate
        '
        Me.colARTDate.DataPropertyName = "ARTDate"
        DataGridViewCellStyle53.Format = "D"
        DataGridViewCellStyle53.NullValue = Nothing
        Me.colARTDate.DefaultCellStyle = DataGridViewCellStyle53
        Me.colARTDate.HeaderText = "Date"
        Me.colARTDate.MaxInputLength = 20
        Me.colARTDate.Name = "colARTDate"
        '
        'colARTWhere
        '
        Me.colARTWhere.DataPropertyName = "ARTWhere"
        Me.colARTWhere.HeaderText = "Where"
        Me.colARTWhere.Name = "colARTWhere"
        Me.colARTWhere.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colARTWhere.Width = 125
        '
        'colCombination
        '
        Me.colCombination.DataPropertyName = "Combination"
        Me.colCombination.DisplayStyleForCurrentCellOnly = True
        Me.colCombination.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colCombination.HeaderText = "Combination (ARV)"
        Me.colCombination.Name = "colCombination"
        Me.colCombination.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colCombination.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colCombination.Width = 200
        '
        'colPriorARTDetailsSaved
        '
        DataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle54.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle54.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle54.NullValue = False
        Me.colPriorARTDetailsSaved.DefaultCellStyle = DataGridViewCellStyle54
        Me.colPriorARTDetailsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPriorARTDetailsSaved.HeaderText = "Saved"
        Me.colPriorARTDetailsSaved.Name = "colPriorARTDetailsSaved"
        Me.colPriorARTDetailsSaved.ReadOnly = True
        Me.colPriorARTDetailsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPriorARTDetailsSaved.Width = 50
        '
        'tpgHIVCare
        '
        Me.tpgHIVCare.Controls.Add(Me.lblDate)
        Me.tpgHIVCare.Controls.Add(Me.chkPCRInfant)
        Me.tpgHIVCare.Controls.Add(Me.chkPresumptiveHIV)
        Me.tpgHIVCare.Controls.Add(Me.nbxCD4)
        Me.tpgHIVCare.Controls.Add(Me.lblCD4)
        Me.tpgHIVCare.Controls.Add(Me.cboWHOStageID)
        Me.tpgHIVCare.Controls.Add(Me.lblWHOStageID)
        Me.tpgHIVCare.Controls.Add(Me.stbTransferInFrom)
        Me.tpgHIVCare.Controls.Add(Me.chkHIVCareTransferIn)
        Me.tpgHIVCare.Controls.Add(Me.stbHIVCareWhere)
        Me.tpgHIVCare.Controls.Add(Me.lblHIVCareWhere)
        Me.tpgHIVCare.Controls.Add(Me.chkAb)
        Me.tpgHIVCare.Controls.Add(Me.chkPCR)
        Me.tpgHIVCare.Controls.Add(Me.dtpConfirmedTestDate)
        Me.tpgHIVCare.Controls.Add(Me.dtpEligibleReadyDate)
        Me.tpgHIVCare.Controls.Add(Me.lblConfirmedTestDate)
        Me.tpgHIVCare.Controls.Add(Me.lblEligibleReadyDate)
        Me.tpgHIVCare.Controls.Add(Me.dtpHIVEnrolledDate)
        Me.tpgHIVCare.Controls.Add(Me.lblEligibleARTDate)
        Me.tpgHIVCare.Controls.Add(Me.lblHIVEnrolledDate)
        Me.tpgHIVCare.Controls.Add(Me.dtpEligibleARTDate)
        Me.tpgHIVCare.Location = New System.Drawing.Point(4, 22)
        Me.tpgHIVCare.Name = "tpgHIVCare"
        Me.tpgHIVCare.Size = New System.Drawing.Size(707, 305)
        Me.tpgHIVCare.TabIndex = 5
        Me.tpgHIVCare.Tag = "Patients"
        Me.tpgHIVCare.Text = "HIV Care"
        Me.tpgHIVCare.UseVisualStyleBackColor = True
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(167, 7)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(142, 20)
        Me.lblDate.TabIndex = 20
        Me.lblDate.Text = "Date"
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkPCRInfant
        '
        Me.ebnSaveUpdate.SetDataMember(Me.chkPCRInfant, "PCRInfant")
        Me.chkPCRInfant.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPCRInfant.Location = New System.Drawing.Point(320, 108)
        Me.chkPCRInfant.Name = "chkPCRInfant"
        Me.chkPCRInfant.Size = New System.Drawing.Size(150, 20)
        Me.chkPCRInfant.TabIndex = 19
        Me.chkPCRInfant.Text = "PCR Infant"
        '
        'chkPresumptiveHIV
        '
        Me.ebnSaveUpdate.SetDataMember(Me.chkPresumptiveHIV, "PresumptiveHIV")
        Me.chkPresumptiveHIV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPresumptiveHIV.Location = New System.Drawing.Point(320, 82)
        Me.chkPresumptiveHIV.Name = "chkPresumptiveHIV"
        Me.chkPresumptiveHIV.Size = New System.Drawing.Size(367, 20)
        Me.chkPresumptiveHIV.TabIndex = 18
        Me.chkPresumptiveHIV.Text = "Presumptive clinical HIV diagnosis of severe HIV infection in infant"
        '
        'nbxCD4
        '
        Me.nbxCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCD4.ControlCaption = "CD4"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCD4, "CD4")
        Me.nbxCD4.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCD4.DecimalPlaces = -1
        Me.nbxCD4.Location = New System.Drawing.Point(550, 59)
        Me.nbxCD4.MaxValue = 0.0R
        Me.nbxCD4.MinValue = 0.0R
        Me.nbxCD4.MustEnterNumeric = True
        Me.nbxCD4.Name = "nbxCD4"
        Me.nbxCD4.Size = New System.Drawing.Size(137, 20)
        Me.nbxCD4.TabIndex = 17
        Me.nbxCD4.Value = ""
        '
        'lblCD4
        '
        Me.lblCD4.Location = New System.Drawing.Point(493, 62)
        Me.lblCD4.Name = "lblCD4"
        Me.lblCD4.Size = New System.Drawing.Size(49, 20)
        Me.lblCD4.TabIndex = 16
        Me.lblCD4.Text = "CD4"
        '
        'cboWHOStageID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboWHOStageID, "WHOStage,WHOStageID")
        Me.cboWHOStageID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboWHOStageID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboWHOStageID.Location = New System.Drawing.Point(387, 59)
        Me.cboWHOStageID.Name = "cboWHOStageID"
        Me.cboWHOStageID.Size = New System.Drawing.Size(100, 21)
        Me.cboWHOStageID.TabIndex = 15
        '
        'lblWHOStageID
        '
        Me.lblWHOStageID.Location = New System.Drawing.Point(317, 59)
        Me.lblWHOStageID.Name = "lblWHOStageID"
        Me.lblWHOStageID.Size = New System.Drawing.Size(93, 20)
        Me.lblWHOStageID.TabIndex = 14
        Me.lblWHOStageID.Text = "WHO Stage"
        '
        'stbTransferInFrom
        '
        Me.stbTransferInFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTransferInFrom.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbTransferInFrom, "TransferInFrom")
        Me.stbTransferInFrom.EntryErrorMSG = ""
        Me.stbTransferInFrom.Location = New System.Drawing.Point(472, 33)
        Me.stbTransferInFrom.Name = "stbTransferInFrom"
        Me.stbTransferInFrom.RegularExpression = ""
        Me.stbTransferInFrom.Size = New System.Drawing.Size(215, 20)
        Me.stbTransferInFrom.TabIndex = 13
        '
        'chkHIVCareTransferIn
        '
        Me.ebnSaveUpdate.SetDataMember(Me.chkHIVCareTransferIn, "HIVCareTransferIn")
        Me.chkHIVCareTransferIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHIVCareTransferIn.Location = New System.Drawing.Point(317, 35)
        Me.chkHIVCareTransferIn.Name = "chkHIVCareTransferIn"
        Me.chkHIVCareTransferIn.Size = New System.Drawing.Size(149, 20)
        Me.chkHIVCareTransferIn.TabIndex = 12
        Me.chkHIVCareTransferIn.Text = "HIV care transfer in from"
        '
        'stbHIVCareWhere
        '
        Me.stbHIVCareWhere.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbHIVCareWhere.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbHIVCareWhere, "HIVCareWhere")
        Me.stbHIVCareWhere.EntryErrorMSG = ""
        Me.stbHIVCareWhere.Location = New System.Drawing.Point(472, 7)
        Me.stbHIVCareWhere.Name = "stbHIVCareWhere"
        Me.stbHIVCareWhere.RegularExpression = ""
        Me.stbHIVCareWhere.Size = New System.Drawing.Size(215, 20)
        Me.stbHIVCareWhere.TabIndex = 11
        '
        'lblHIVCareWhere
        '
        Me.lblHIVCareWhere.Location = New System.Drawing.Point(420, 9)
        Me.lblHIVCareWhere.Name = "lblHIVCareWhere"
        Me.lblHIVCareWhere.Size = New System.Drawing.Size(46, 20)
        Me.lblHIVCareWhere.TabIndex = 10
        Me.lblHIVCareWhere.Text = "Where"
        '
        'chkAb
        '
        Me.ebnSaveUpdate.SetDataMember(Me.chkAb, "Ab")
        Me.chkAb.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAb.Location = New System.Drawing.Point(317, 9)
        Me.chkAb.Name = "chkAb"
        Me.chkAb.Size = New System.Drawing.Size(44, 20)
        Me.chkAb.TabIndex = 8
        Me.chkAb.Text = "Ab"
        '
        'chkPCR
        '
        Me.ebnSaveUpdate.SetDataMember(Me.chkPCR, "PCR")
        Me.chkPCR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPCR.Location = New System.Drawing.Point(366, 9)
        Me.chkPCR.Name = "chkPCR"
        Me.chkPCR.Size = New System.Drawing.Size(44, 20)
        Me.chkPCR.TabIndex = 9
        Me.chkPCR.Text = "PCR"
        '
        'dtpConfirmedTestDate
        '
        Me.dtpConfirmedTestDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpConfirmedTestDate, "ConfirmedTestDate")
        Me.dtpConfirmedTestDate.Location = New System.Drawing.Point(166, 31)
        Me.dtpConfirmedTestDate.Name = "dtpConfirmedTestDate"
        Me.dtpConfirmedTestDate.ShowCheckBox = True
        Me.dtpConfirmedTestDate.Size = New System.Drawing.Size(143, 20)
        Me.dtpConfirmedTestDate.TabIndex = 1
        '
        'dtpEligibleReadyDate
        '
        Me.dtpEligibleReadyDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpEligibleReadyDate, "EligibleReadyDate")
        Me.dtpEligibleReadyDate.Location = New System.Drawing.Point(166, 100)
        Me.dtpEligibleReadyDate.Name = "dtpEligibleReadyDate"
        Me.dtpEligibleReadyDate.ShowCheckBox = True
        Me.dtpEligibleReadyDate.Size = New System.Drawing.Size(143, 20)
        Me.dtpEligibleReadyDate.TabIndex = 7
        '
        'lblConfirmedTestDate
        '
        Me.lblConfirmedTestDate.Location = New System.Drawing.Point(12, 31)
        Me.lblConfirmedTestDate.Name = "lblConfirmedTestDate"
        Me.lblConfirmedTestDate.Size = New System.Drawing.Size(144, 20)
        Me.lblConfirmedTestDate.TabIndex = 0
        Me.lblConfirmedTestDate.Text = "Confirmed HIV+ Test"
        '
        'lblEligibleReadyDate
        '
        Me.lblEligibleReadyDate.Location = New System.Drawing.Point(12, 100)
        Me.lblEligibleReadyDate.Name = "lblEligibleReadyDate"
        Me.lblEligibleReadyDate.Size = New System.Drawing.Size(144, 20)
        Me.lblEligibleReadyDate.TabIndex = 6
        Me.lblEligibleReadyDate.Text = "Eligible and Ready"
        '
        'dtpHIVEnrolledDate
        '
        Me.dtpHIVEnrolledDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpHIVEnrolledDate, "HIVEnrolledDate")
        Me.dtpHIVEnrolledDate.Location = New System.Drawing.Point(166, 54)
        Me.dtpHIVEnrolledDate.Name = "dtpHIVEnrolledDate"
        Me.dtpHIVEnrolledDate.ShowCheckBox = True
        Me.dtpHIVEnrolledDate.Size = New System.Drawing.Size(143, 20)
        Me.dtpHIVEnrolledDate.TabIndex = 3
        '
        'lblEligibleARTDate
        '
        Me.lblEligibleARTDate.Location = New System.Drawing.Point(12, 77)
        Me.lblEligibleARTDate.Name = "lblEligibleARTDate"
        Me.lblEligibleARTDate.Size = New System.Drawing.Size(144, 20)
        Me.lblEligibleARTDate.TabIndex = 4
        Me.lblEligibleARTDate.Text = "Eligible for ART"
        '
        'lblHIVEnrolledDate
        '
        Me.lblHIVEnrolledDate.Location = New System.Drawing.Point(12, 54)
        Me.lblHIVEnrolledDate.Name = "lblHIVEnrolledDate"
        Me.lblHIVEnrolledDate.Size = New System.Drawing.Size(144, 20)
        Me.lblHIVEnrolledDate.TabIndex = 2
        Me.lblHIVEnrolledDate.Text = "HIV Enrolled"
        '
        'dtpEligibleARTDate
        '
        Me.dtpEligibleARTDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpEligibleARTDate, "EligibleARTDate")
        Me.dtpEligibleARTDate.Location = New System.Drawing.Point(166, 77)
        Me.dtpEligibleARTDate.Name = "dtpEligibleARTDate"
        Me.dtpEligibleARTDate.ShowCheckBox = True
        Me.dtpEligibleARTDate.Size = New System.Drawing.Size(143, 20)
        Me.dtpEligibleARTDate.TabIndex = 5
        '
        'tpgMedicalConditions
        '
        Me.tpgMedicalConditions.Controls.Add(Me.stbMedicalConditions)
        Me.tpgMedicalConditions.Controls.Add(Me.lblMedicalConditions)
        Me.tpgMedicalConditions.Location = New System.Drawing.Point(4, 22)
        Me.tpgMedicalConditions.Name = "tpgMedicalConditions"
        Me.tpgMedicalConditions.Size = New System.Drawing.Size(707, 305)
        Me.tpgMedicalConditions.TabIndex = 6
        Me.tpgMedicalConditions.Tag = "Patients"
        Me.tpgMedicalConditions.Text = "Medical Conditions"
        Me.tpgMedicalConditions.UseVisualStyleBackColor = True
        '
        'stbMedicalConditions
        '
        Me.stbMedicalConditions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMedicalConditions.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMedicalConditions, "MedicalConditions")
        Me.stbMedicalConditions.EntryErrorMSG = ""
        Me.stbMedicalConditions.Location = New System.Drawing.Point(189, 17)
        Me.stbMedicalConditions.Multiline = True
        Me.stbMedicalConditions.Name = "stbMedicalConditions"
        Me.stbMedicalConditions.RegularExpression = ""
        Me.stbMedicalConditions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMedicalConditions.Size = New System.Drawing.Size(494, 38)
        Me.stbMedicalConditions.TabIndex = 57
        '
        'lblMedicalConditions
        '
        Me.lblMedicalConditions.Location = New System.Drawing.Point(12, 27)
        Me.lblMedicalConditions.Name = "lblMedicalConditions"
        Me.lblMedicalConditions.Size = New System.Drawing.Size(171, 20)
        Me.lblMedicalConditions.TabIndex = 56
        Me.lblMedicalConditions.Text = "Medical Conditions"
        '
        'tpgARTCare
        '
        Me.tpgARTCare.Controls.Add(Me.cboCOHORTYear)
        Me.tpgARTCare.Controls.Add(Me.cboCOHORTMonth)
        Me.tpgARTCare.Controls.Add(Me.dtpStartARTDate)
        Me.tpgARTCare.Controls.Add(Me.cboStartARTRegimen)
        Me.tpgARTCare.Controls.Add(Me.lblStartARTRegimen)
        Me.tpgARTCare.Controls.Add(Me.nbxStartARTWeight)
        Me.tpgARTCare.Controls.Add(Me.lblStartARTWeight)
        Me.tpgARTCare.Controls.Add(Me.cboStartARTWHOStageID)
        Me.tpgARTCare.Controls.Add(Me.lblStartARTWHOStageID)
        Me.tpgARTCare.Controls.Add(Me.nbxStartARTCD4)
        Me.tpgARTCare.Controls.Add(Me.lblStartARTCD4)
        Me.tpgARTCare.Controls.Add(Me.cboPregnancyStatusID)
        Me.tpgARTCare.Controls.Add(Me.lblPregnancyStatusID)
        Me.tpgARTCare.Controls.Add(Me.cboTransferInRegimen)
        Me.tpgARTCare.Controls.Add(Me.lblTransferInRegimen)
        Me.tpgARTCare.Controls.Add(Me.lblCOHORTMonth)
        Me.tpgARTCare.Controls.Add(Me.lblCOHORTYear)
        Me.tpgARTCare.Controls.Add(Me.dtpARTTransferInDate)
        Me.tpgARTCare.Controls.Add(Me.lblARTTransferInDate)
        Me.tpgARTCare.Controls.Add(Me.stbARTTransferInFrom)
        Me.tpgARTCare.Controls.Add(Me.lblARTTransferInFrom)
        Me.tpgARTCare.Location = New System.Drawing.Point(4, 22)
        Me.tpgARTCare.Name = "tpgARTCare"
        Me.tpgARTCare.Size = New System.Drawing.Size(707, 305)
        Me.tpgARTCare.TabIndex = 7
        Me.tpgARTCare.Tag = "Patients"
        Me.tpgARTCare.Text = "ART Care"
        Me.tpgARTCare.UseVisualStyleBackColor = True
        '
        'cboCOHORTYear
        '
        Me.cboCOHORTYear.AccessibleDescription = ""
        Me.cboCOHORTYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCOHORTYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboCOHORTYear, "COHORTYear")
        Me.cboCOHORTYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCOHORTYear.FormattingEnabled = True
        Me.cboCOHORTYear.Items.AddRange(New Object() {"2004", "2005", "2006", "2007", "2008", "2009", "2010", "2011"})
        Me.cboCOHORTYear.Location = New System.Drawing.Point(515, 5)
        Me.cboCOHORTYear.MaxLength = 4
        Me.cboCOHORTYear.Name = "cboCOHORTYear"
        Me.cboCOHORTYear.Size = New System.Drawing.Size(168, 21)
        Me.cboCOHORTYear.TabIndex = 69
        '
        'cboCOHORTMonth
        '
        Me.cboCOHORTMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCOHORTMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboCOHORTMonth, "COHORTMonth")
        Me.cboCOHORTMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCOHORTMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCOHORTMonth.FormattingEnabled = True
        Me.cboCOHORTMonth.Items.AddRange(New Object() {"", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"})
        Me.cboCOHORTMonth.Location = New System.Drawing.Point(297, 8)
        Me.cboCOHORTMonth.Name = "cboCOHORTMonth"
        Me.cboCOHORTMonth.Size = New System.Drawing.Size(103, 21)
        Me.cboCOHORTMonth.TabIndex = 67
        '
        'dtpStartARTDate
        '
        Me.dtpStartARTDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpStartARTDate, "StartARTDate")
        Me.dtpStartARTDate.Location = New System.Drawing.Point(11, 56)
        Me.dtpStartARTDate.Name = "dtpStartARTDate"
        Me.dtpStartARTDate.ShowCheckBox = True
        Me.dtpStartARTDate.Size = New System.Drawing.Size(152, 20)
        Me.dtpStartARTDate.TabIndex = 10
        '
        'cboStartARTRegimen
        '
        Me.cboStartARTRegimen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStartARTRegimen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStartARTRegimen, "StartARTRegimen")
        Me.cboStartARTRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStartARTRegimen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStartARTRegimen.Location = New System.Drawing.Point(515, 58)
        Me.cboStartARTRegimen.Name = "cboStartARTRegimen"
        Me.cboStartARTRegimen.Size = New System.Drawing.Size(168, 21)
        Me.cboStartARTRegimen.TabIndex = 12
        '
        'lblStartARTRegimen
        '
        Me.lblStartARTRegimen.Location = New System.Drawing.Point(169, 60)
        Me.lblStartARTRegimen.Name = "lblStartARTRegimen"
        Me.lblStartARTRegimen.Size = New System.Drawing.Size(282, 20)
        Me.lblStartARTRegimen.TabIndex = 11
        Me.lblStartARTRegimen.Text = "Start ART 1st-line initial regimen"
        '
        'nbxStartARTWeight
        '
        Me.nbxStartARTWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxStartARTWeight.ControlCaption = "Start ART Weight"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxStartARTWeight, "StartARTWeight")
        Me.nbxStartARTWeight.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxStartARTWeight.DecimalPlaces = -1
        Me.nbxStartARTWeight.Location = New System.Drawing.Point(175, 83)
        Me.nbxStartARTWeight.MaxValue = 0.0R
        Me.nbxStartARTWeight.MinValue = 0.0R
        Me.nbxStartARTWeight.MustEnterNumeric = True
        Me.nbxStartARTWeight.Name = "nbxStartARTWeight"
        Me.nbxStartARTWeight.Size = New System.Drawing.Size(151, 20)
        Me.nbxStartARTWeight.TabIndex = 14
        Me.nbxStartARTWeight.Value = ""
        '
        'lblStartARTWeight
        '
        Me.lblStartARTWeight.Location = New System.Drawing.Point(11, 83)
        Me.lblStartARTWeight.Name = "lblStartARTWeight"
        Me.lblStartARTWeight.Size = New System.Drawing.Size(152, 20)
        Me.lblStartARTWeight.TabIndex = 13
        Me.lblStartARTWeight.Text = "Start ART Weight"
        '
        'cboStartARTWHOStageID
        '
        Me.cboStartARTWHOStageID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStartARTWHOStageID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStartARTWHOStageID, "StartARTWHOStage,StartARTWHOStageID")
        Me.cboStartARTWHOStageID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStartARTWHOStageID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStartARTWHOStageID.Location = New System.Drawing.Point(515, 85)
        Me.cboStartARTWHOStageID.Name = "cboStartARTWHOStageID"
        Me.cboStartARTWHOStageID.Size = New System.Drawing.Size(168, 21)
        Me.cboStartARTWHOStageID.TabIndex = 16
        '
        'lblStartARTWHOStageID
        '
        Me.lblStartARTWHOStageID.Location = New System.Drawing.Point(339, 85)
        Me.lblStartARTWHOStageID.Name = "lblStartARTWHOStageID"
        Me.lblStartARTWHOStageID.Size = New System.Drawing.Size(129, 20)
        Me.lblStartARTWHOStageID.TabIndex = 15
        Me.lblStartARTWHOStageID.Text = "Clinical Stage"
        '
        'nbxStartARTCD4
        '
        Me.nbxStartARTCD4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxStartARTCD4.ControlCaption = "StartARTCD4"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxStartARTCD4, "StartARTCD4")
        Me.nbxStartARTCD4.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxStartARTCD4.DecimalPlaces = -1
        Me.nbxStartARTCD4.Location = New System.Drawing.Point(175, 109)
        Me.nbxStartARTCD4.MaxValue = 0.0R
        Me.nbxStartARTCD4.MinValue = 0.0R
        Me.nbxStartARTCD4.MustEnterNumeric = True
        Me.nbxStartARTCD4.Name = "nbxStartARTCD4"
        Me.nbxStartARTCD4.Size = New System.Drawing.Size(151, 20)
        Me.nbxStartARTCD4.TabIndex = 18
        Me.nbxStartARTCD4.Value = ""
        '
        'lblStartARTCD4
        '
        Me.lblStartARTCD4.Location = New System.Drawing.Point(11, 109)
        Me.lblStartARTCD4.Name = "lblStartARTCD4"
        Me.lblStartARTCD4.Size = New System.Drawing.Size(126, 20)
        Me.lblStartARTCD4.TabIndex = 17
        Me.lblStartARTCD4.Text = "CD4"
        '
        'cboPregnancyStatusID
        '
        Me.cboPregnancyStatusID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPregnancyStatusID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboPregnancyStatusID, "PregnancyStatus,PregnancyStatusID")
        Me.cboPregnancyStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPregnancyStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPregnancyStatusID.Location = New System.Drawing.Point(515, 111)
        Me.cboPregnancyStatusID.Name = "cboPregnancyStatusID"
        Me.cboPregnancyStatusID.Size = New System.Drawing.Size(168, 21)
        Me.cboPregnancyStatusID.TabIndex = 20
        '
        'lblPregnancyStatusID
        '
        Me.lblPregnancyStatusID.Location = New System.Drawing.Point(339, 111)
        Me.lblPregnancyStatusID.Name = "lblPregnancyStatusID"
        Me.lblPregnancyStatusID.Size = New System.Drawing.Size(112, 20)
        Me.lblPregnancyStatusID.TabIndex = 19
        Me.lblPregnancyStatusID.Text = "Pregnancy Status"
        '
        'cboTransferInRegimen
        '
        Me.cboTransferInRegimen.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboTransferInRegimen.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboTransferInRegimen, "TransferInRegimen")
        Me.cboTransferInRegimen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransferInRegimen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTransferInRegimen.Location = New System.Drawing.Point(515, 34)
        Me.cboTransferInRegimen.Name = "cboTransferInRegimen"
        Me.cboTransferInRegimen.Size = New System.Drawing.Size(168, 21)
        Me.cboTransferInRegimen.TabIndex = 9
        '
        'lblTransferInRegimen
        '
        Me.lblTransferInRegimen.Location = New System.Drawing.Point(457, 37)
        Me.lblTransferInRegimen.Name = "lblTransferInRegimen"
        Me.lblTransferInRegimen.Size = New System.Drawing.Size(66, 20)
        Me.lblTransferInRegimen.TabIndex = 8
        Me.lblTransferInRegimen.Text = "ARVs"
        '
        'lblCOHORTMonth
        '
        Me.lblCOHORTMonth.Location = New System.Drawing.Point(172, 11)
        Me.lblCOHORTMonth.Name = "lblCOHORTMonth"
        Me.lblCOHORTMonth.Size = New System.Drawing.Size(119, 20)
        Me.lblCOHORTMonth.TabIndex = 1
        Me.lblCOHORTMonth.Text = "COHORT Month"
        '
        'lblCOHORTYear
        '
        Me.lblCOHORTYear.Location = New System.Drawing.Point(406, 11)
        Me.lblCOHORTYear.Name = "lblCOHORTYear"
        Me.lblCOHORTYear.Size = New System.Drawing.Size(86, 20)
        Me.lblCOHORTYear.TabIndex = 3
        Me.lblCOHORTYear.Text = "COHORT Year"
        '
        'dtpARTTransferInDate
        '
        Me.dtpARTTransferInDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpARTTransferInDate, "ARTTransferInDate")
        Me.dtpARTTransferInDate.Location = New System.Drawing.Point(11, 33)
        Me.dtpARTTransferInDate.Name = "dtpARTTransferInDate"
        Me.dtpARTTransferInDate.ShowCheckBox = True
        Me.dtpARTTransferInDate.Size = New System.Drawing.Size(152, 20)
        Me.dtpARTTransferInDate.TabIndex = 5
        '
        'lblARTTransferInDate
        '
        Me.lblARTTransferInDate.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.lblARTTransferInDate.Location = New System.Drawing.Point(8, 5)
        Me.lblARTTransferInDate.Name = "lblARTTransferInDate"
        Me.lblARTTransferInDate.Size = New System.Drawing.Size(129, 20)
        Me.lblARTTransferInDate.TabIndex = 0
        Me.lblARTTransferInDate.Text = "Date"
        Me.lblARTTransferInDate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'stbARTTransferInFrom
        '
        Me.stbARTTransferInFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbARTTransferInFrom.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbARTTransferInFrom, "ARTTransferInFrom")
        Me.stbARTTransferInFrom.EntryErrorMSG = ""
        Me.stbARTTransferInFrom.Location = New System.Drawing.Point(297, 35)
        Me.stbARTTransferInFrom.Name = "stbARTTransferInFrom"
        Me.stbARTTransferInFrom.RegularExpression = ""
        Me.stbARTTransferInFrom.Size = New System.Drawing.Size(154, 20)
        Me.stbARTTransferInFrom.TabIndex = 7
        '
        'lblARTTransferInFrom
        '
        Me.lblARTTransferInFrom.Location = New System.Drawing.Point(172, 33)
        Me.lblARTTransferInFrom.Name = "lblARTTransferInFrom"
        Me.lblARTTransferInFrom.Size = New System.Drawing.Size(122, 20)
        Me.lblARTTransferInFrom.TabIndex = 6
        Me.lblARTTransferInFrom.Text = "ART Transfer In From"
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(16, 354)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 69
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(655, 353)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 70
        Me.fbnDelete.Tag = "HIVCARE"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(16, 381)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 71
        Me.ebnSaveUpdate.Tag = "HIVCARE"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(655, 380)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 72
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'frmHIVCARE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(733, 417)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.tbcPatientsEXTRA)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmHIVCARE"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Patients -ART"
        Me.tbcPatientsEXTRA.ResumeLayout(False)
        Me.tpgGeneral.ResumeLayout(False)
        Me.tpgGeneral.PerformLayout()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgFamilyMembers.ResumeLayout(False)
        CType(Me.dgvFamilyMembers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgExposedInfants.ResumeLayout(False)
        CType(Me.dgvExposedInfants, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPriorARTDetails.ResumeLayout(False)
        CType(Me.dgvPriorARTDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgHIVCare.ResumeLayout(False)
        Me.tpgHIVCare.PerformLayout()
        Me.tpgMedicalConditions.ResumeLayout(False)
        Me.tpgMedicalConditions.PerformLayout()
        Me.tpgARTCare.ResumeLayout(False)
        Me.tpgARTCare.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tbcPatientsEXTRA As System.Windows.Forms.TabControl
    Friend WithEvents tpgGeneral As System.Windows.Forms.TabPage
    Friend WithEvents chkFingerprintCaptured As System.Windows.Forms.CheckBox
    Friend WithEvents btnEnrollFingerprint As System.Windows.Forms.Button
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaffNo As System.Windows.Forms.Label
    Friend WithEvents cboDistrictsID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDistrictsID As System.Windows.Forms.Label
    Friend WithEvents stbReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferenceNo As System.Windows.Forms.Label
    Friend WithEvents cboHealthUnitCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblHealthUnitCode As System.Windows.Forms.Label
    Protected WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents tpgFamilyMembers As System.Windows.Forms.TabPage
    Friend WithEvents dgvFamilyMembers As System.Windows.Forms.DataGridView
    Friend WithEvents colMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHIVStatusID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colHIVCareID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colFamilyMembersUniqueNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFamilyMembersSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgExposedInfants As System.Windows.Forms.TabPage
    Friend WithEvents dgvExposedInfants As System.Windows.Forms.DataGridView
    Friend WithEvents colInfantName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBirthDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInfantFeedingID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colCTXStarted As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHIVTestTypeID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colTestResultsID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInfantStatusID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colExposedInfantsUniqueNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExposedInfantsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgPriorARTDetails As System.Windows.Forms.TabPage
    Friend WithEvents dgvPriorARTDetails As System.Windows.Forms.DataGridView
    Friend WithEvents colPriorARTID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colARTDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colARTWhere As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCombination As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPriorARTDetailsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgHIVCare As System.Windows.Forms.TabPage
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents chkPCRInfant As System.Windows.Forms.CheckBox
    Friend WithEvents chkPresumptiveHIV As System.Windows.Forms.CheckBox
    Friend WithEvents nbxCD4 As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCD4 As System.Windows.Forms.Label
    Friend WithEvents cboWHOStageID As System.Windows.Forms.ComboBox
    Friend WithEvents lblWHOStageID As System.Windows.Forms.Label
    Friend WithEvents stbTransferInFrom As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents chkHIVCareTransferIn As System.Windows.Forms.CheckBox
    Friend WithEvents stbHIVCareWhere As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblHIVCareWhere As System.Windows.Forms.Label
    Friend WithEvents chkAb As System.Windows.Forms.CheckBox
    Friend WithEvents chkPCR As System.Windows.Forms.CheckBox
    Friend WithEvents dtpConfirmedTestDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEligibleReadyDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblConfirmedTestDate As System.Windows.Forms.Label
    Friend WithEvents lblEligibleReadyDate As System.Windows.Forms.Label
    Friend WithEvents dtpHIVEnrolledDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEligibleARTDate As System.Windows.Forms.Label
    Friend WithEvents lblHIVEnrolledDate As System.Windows.Forms.Label
    Friend WithEvents dtpEligibleARTDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents tpgMedicalConditions As System.Windows.Forms.TabPage
    Friend WithEvents stbMedicalConditions As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMedicalConditions As System.Windows.Forms.Label
    Friend WithEvents tpgARTCare As System.Windows.Forms.TabPage
    Friend WithEvents cboCOHORTYear As System.Windows.Forms.ComboBox
    Friend WithEvents cboCOHORTMonth As System.Windows.Forms.ComboBox
    Friend WithEvents dtpStartARTDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboStartARTRegimen As System.Windows.Forms.ComboBox
    Friend WithEvents lblStartARTRegimen As System.Windows.Forms.Label
    Friend WithEvents nbxStartARTWeight As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblStartARTWeight As System.Windows.Forms.Label
    Friend WithEvents cboStartARTWHOStageID As System.Windows.Forms.ComboBox
    Friend WithEvents lblStartARTWHOStageID As System.Windows.Forms.Label
    Friend WithEvents nbxStartARTCD4 As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblStartARTCD4 As System.Windows.Forms.Label
    Friend WithEvents cboPregnancyStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblPregnancyStatusID As System.Windows.Forms.Label
    Friend WithEvents cboTransferInRegimen As System.Windows.Forms.ComboBox
    Friend WithEvents lblTransferInRegimen As System.Windows.Forms.Label
    Friend WithEvents lblCOHORTMonth As System.Windows.Forms.Label
    Friend WithEvents lblCOHORTYear As System.Windows.Forms.Label
    Friend WithEvents dtpARTTransferInDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblARTTransferInDate As System.Windows.Forms.Label
    Friend WithEvents stbARTTransferInFrom As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblARTTransferInFrom As System.Windows.Forms.Label
    Friend WithEvents stbPtClinic As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPtClinic As System.Windows.Forms.Label
    Friend WithEvents stbLC1 As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLC1 As System.Windows.Forms.Label
    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnFindPatientNo As System.Windows.Forms.Button
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents nbxOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBalance As System.Windows.Forms.Label
    Friend WithEvents stbTotalVisits As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalVisits As System.Windows.Forms.Label
    Friend WithEvents stbLastVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceNo As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label


End Class