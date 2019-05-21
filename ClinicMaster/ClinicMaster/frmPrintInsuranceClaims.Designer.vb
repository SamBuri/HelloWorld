
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintInsuranceClaims : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintInsuranceClaims))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMedicalCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbCompanyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPolicyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPolicyStartDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPolicyEndDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMemberType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMainMemberName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbClaimNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClaimNo = New System.Windows.Forms.Label()
        Me.lblMedicalCardNo = New System.Windows.Forms.Label()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.lblVisitTime = New System.Windows.Forms.Label()
        Me.lblHealthUnitName = New System.Windows.Forms.Label()
        Me.lblAmountWords = New System.Windows.Forms.Label()
        Me.lblClaimStatus = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.tbcClaims = New System.Windows.Forms.TabControl()
        Me.tpgClaimDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvDiagnosis = New System.Windows.Forms.DataGridView()
        Me.colDiseaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgClaimDetails = New System.Windows.Forms.TabPage()
        Me.dgvClaimDetails = New System.Windows.Forms.DataGridView()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblInsuranceName = New System.Windows.Forms.Label()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.lblPolicyName = New System.Windows.Forms.Label()
        Me.lblPolicyStartDate = New System.Windows.Forms.Label()
        Me.lblPolicyEndDate = New System.Windows.Forms.Label()
        Me.stbTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberType = New System.Windows.Forms.Label()
        Me.btnFindClaimNo = New System.Windows.Forms.Button()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.lblClaimEntry = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblMainMemberName = New System.Windows.Forms.Label()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbHealthUnitName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbClaimStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbClaimEntry = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadPeriodicClaims = New System.Windows.Forms.Button()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBenefitName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcClaims.SuspendLayout()
        Me.tpgClaimDiagnosis.SuspendLayout()
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgClaimDetails.SuspendLayout()
        CType(Me.dgvClaimDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(142, 48)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(170, 20)
        Me.stbPatientNo.TabIndex = 6
        '
        'stbMedicalCardNo
        '
        Me.stbMedicalCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMedicalCardNo.CapitalizeFirstLetter = False
        Me.stbMedicalCardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbMedicalCardNo.Enabled = False
        Me.stbMedicalCardNo.EntryErrorMSG = ""
        Me.stbMedicalCardNo.Location = New System.Drawing.Point(142, 27)
        Me.stbMedicalCardNo.MaxLength = 20
        Me.stbMedicalCardNo.Name = "stbMedicalCardNo"
        Me.stbMedicalCardNo.RegularExpression = ""
        Me.stbMedicalCardNo.Size = New System.Drawing.Size(170, 20)
        Me.stbMedicalCardNo.TabIndex = 4
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(462, 25)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(172, 20)
        Me.stbAge.TabIndex = 26
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(462, 67)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(172, 20)
        Me.stbJoinDate.TabIndex = 30
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(462, 46)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(172, 20)
        Me.stbGender.TabIndex = 28
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(462, 4)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(172, 20)
        Me.stbFullName.TabIndex = 24
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(462, 160)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(172, 29)
        Me.stbInsuranceName.TabIndex = 38
        '
        'stbCompanyName
        '
        Me.stbCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCompanyName.CapitalizeFirstLetter = False
        Me.stbCompanyName.EntryErrorMSG = ""
        Me.stbCompanyName.Location = New System.Drawing.Point(462, 130)
        Me.stbCompanyName.MaxLength = 41
        Me.stbCompanyName.Multiline = True
        Me.stbCompanyName.Name = "stbCompanyName"
        Me.stbCompanyName.ReadOnly = True
        Me.stbCompanyName.RegularExpression = ""
        Me.stbCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCompanyName.Size = New System.Drawing.Size(172, 29)
        Me.stbCompanyName.TabIndex = 36
        '
        'stbPolicyName
        '
        Me.stbPolicyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPolicyName.CapitalizeFirstLetter = True
        Me.stbPolicyName.Enabled = False
        Me.stbPolicyName.EntryErrorMSG = ""
        Me.stbPolicyName.Location = New System.Drawing.Point(462, 190)
        Me.stbPolicyName.MaxLength = 40
        Me.stbPolicyName.Name = "stbPolicyName"
        Me.stbPolicyName.RegularExpression = ""
        Me.stbPolicyName.Size = New System.Drawing.Size(172, 20)
        Me.stbPolicyName.TabIndex = 40
        '
        'stbPolicyStartDate
        '
        Me.stbPolicyStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPolicyStartDate.CapitalizeFirstLetter = False
        Me.stbPolicyStartDate.Enabled = False
        Me.stbPolicyStartDate.EntryErrorMSG = ""
        Me.stbPolicyStartDate.Location = New System.Drawing.Point(462, 211)
        Me.stbPolicyStartDate.MaxLength = 20
        Me.stbPolicyStartDate.Name = "stbPolicyStartDate"
        Me.stbPolicyStartDate.RegularExpression = ""
        Me.stbPolicyStartDate.Size = New System.Drawing.Size(172, 20)
        Me.stbPolicyStartDate.TabIndex = 42
        '
        'stbPolicyEndDate
        '
        Me.stbPolicyEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPolicyEndDate.CapitalizeFirstLetter = False
        Me.stbPolicyEndDate.Enabled = False
        Me.stbPolicyEndDate.EntryErrorMSG = ""
        Me.stbPolicyEndDate.Location = New System.Drawing.Point(462, 232)
        Me.stbPolicyEndDate.MaxLength = 20
        Me.stbPolicyEndDate.Name = "stbPolicyEndDate"
        Me.stbPolicyEndDate.RegularExpression = ""
        Me.stbPolicyEndDate.Size = New System.Drawing.Size(172, 20)
        Me.stbPolicyEndDate.TabIndex = 44
        '
        'stbMemberType
        '
        Me.stbMemberType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberType.CapitalizeFirstLetter = False
        Me.stbMemberType.Enabled = False
        Me.stbMemberType.EntryErrorMSG = ""
        Me.stbMemberType.Location = New System.Drawing.Point(462, 88)
        Me.stbMemberType.MaxLength = 60
        Me.stbMemberType.Name = "stbMemberType"
        Me.stbMemberType.RegularExpression = ""
        Me.stbMemberType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMemberType.Size = New System.Drawing.Size(172, 20)
        Me.stbMemberType.TabIndex = 32
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = True
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(142, 132)
        Me.stbPrimaryDoctor.MaxLength = 41
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(170, 20)
        Me.stbPrimaryDoctor.TabIndex = 14
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(462, 253)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.ReadOnly = True
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(172, 20)
        Me.stbVisitNo.TabIndex = 46
        '
        'stbMainMemberName
        '
        Me.stbMainMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMainMemberName.CapitalizeFirstLetter = False
        Me.stbMainMemberName.Enabled = False
        Me.stbMainMemberName.EntryErrorMSG = ""
        Me.stbMainMemberName.Location = New System.Drawing.Point(462, 109)
        Me.stbMainMemberName.MaxLength = 60
        Me.stbMainMemberName.Name = "stbMainMemberName"
        Me.stbMainMemberName.RegularExpression = ""
        Me.stbMainMemberName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMainMemberName.Size = New System.Drawing.Size(172, 20)
        Me.stbMainMemberName.TabIndex = 34
        '
        'stbAmountWords
        '
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = True
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(142, 216)
        Me.stbAmountWords.MaxLength = 200
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(170, 30)
        Me.stbAmountWords.TabIndex = 22
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Location = New System.Drawing.Point(12, 196)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(124, 20)
        Me.lblTotalAmount.TabIndex = 19
        Me.lblTotalAmount.Text = "Total Amount"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(534, 429)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(100, 24)
        Me.fbnClose.TabIndex = 50
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbClaimNo
        '
        Me.stbClaimNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimNo.CapitalizeFirstLetter = False
        Me.stbClaimNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbClaimNo.EntryErrorMSG = ""
        Me.stbClaimNo.Location = New System.Drawing.Point(142, 6)
        Me.stbClaimNo.MaxLength = 20
        Me.stbClaimNo.Name = "stbClaimNo"
        Me.stbClaimNo.RegularExpression = ""
        Me.stbClaimNo.Size = New System.Drawing.Size(120, 20)
        Me.stbClaimNo.TabIndex = 2
        '
        'lblClaimNo
        '
        Me.lblClaimNo.Location = New System.Drawing.Point(12, 6)
        Me.lblClaimNo.Name = "lblClaimNo"
        Me.lblClaimNo.Size = New System.Drawing.Size(91, 20)
        Me.lblClaimNo.TabIndex = 0
        Me.lblClaimNo.Text = "Claim No"
        '
        'lblMedicalCardNo
        '
        Me.lblMedicalCardNo.Location = New System.Drawing.Point(12, 27)
        Me.lblMedicalCardNo.Name = "lblMedicalCardNo"
        Me.lblMedicalCardNo.Size = New System.Drawing.Size(124, 20)
        Me.lblMedicalCardNo.TabIndex = 3
        Me.lblMedicalCardNo.Text = "Medical Card No"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(12, 48)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(124, 20)
        Me.lblPatientNo.TabIndex = 5
        Me.lblPatientNo.Text = "Patient No"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(12, 69)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitDate.TabIndex = 7
        Me.lblVisitDate.Text = "Visit Date"
        '
        'lblVisitTime
        '
        Me.lblVisitTime.Location = New System.Drawing.Point(12, 90)
        Me.lblVisitTime.Name = "lblVisitTime"
        Me.lblVisitTime.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitTime.TabIndex = 9
        Me.lblVisitTime.Text = "Visit Time"
        '
        'lblHealthUnitName
        '
        Me.lblHealthUnitName.Location = New System.Drawing.Point(12, 111)
        Me.lblHealthUnitName.Name = "lblHealthUnitName"
        Me.lblHealthUnitName.Size = New System.Drawing.Size(124, 20)
        Me.lblHealthUnitName.TabIndex = 11
        Me.lblHealthUnitName.Text = "Health Unit"
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Location = New System.Drawing.Point(12, 220)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(124, 20)
        Me.lblAmountWords.TabIndex = 21
        Me.lblAmountWords.Text = "Amount in Words"
        '
        'lblClaimStatus
        '
        Me.lblClaimStatus.Location = New System.Drawing.Point(12, 153)
        Me.lblClaimStatus.Name = "lblClaimStatus"
        Me.lblClaimStatus.Size = New System.Drawing.Size(124, 20)
        Me.lblClaimStatus.TabIndex = 15
        Me.lblClaimStatus.Text = "Claim Status"
        '
        'cboLoginID
        '
        Me.cboLoginID.Location = New System.Drawing.Point(0, 0)
        Me.cboLoginID.Name = "cboLoginID"
        Me.cboLoginID.Size = New System.Drawing.Size(121, 21)
        Me.cboLoginID.TabIndex = 0
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(0, 0)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(100, 23)
        Me.lblLoginID.TabIndex = 0
        '
        'tbcClaims
        '
        Me.tbcClaims.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcClaims.Controls.Add(Me.tpgClaimDiagnosis)
        Me.tbcClaims.Controls.Add(Me.tpgClaimDetails)
        Me.tbcClaims.HotTrack = True
        Me.tbcClaims.Location = New System.Drawing.Point(15, 284)
        Me.tbcClaims.Name = "tbcClaims"
        Me.tbcClaims.SelectedIndex = 0
        Me.tbcClaims.Size = New System.Drawing.Size(619, 139)
        Me.tbcClaims.TabIndex = 47
        '
        'tpgClaimDiagnosis
        '
        Me.tpgClaimDiagnosis.Controls.Add(Me.dgvDiagnosis)
        Me.tpgClaimDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgClaimDiagnosis.Name = "tpgClaimDiagnosis"
        Me.tpgClaimDiagnosis.Size = New System.Drawing.Size(611, 113)
        Me.tpgClaimDiagnosis.TabIndex = 2
        Me.tpgClaimDiagnosis.Tag = "ClaimDiagnosis"
        Me.tpgClaimDiagnosis.Text = "Diagnosis"
        Me.tpgClaimDiagnosis.UseVisualStyleBackColor = True
        '
        'dgvDiagnosis
        '
        Me.dgvDiagnosis.AllowUserToAddRows = False
        Me.dgvDiagnosis.AllowUserToOrderColumns = True
        Me.dgvDiagnosis.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDiseaseName, Me.colDiseaseCategory})
        Me.dgvDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiagnosis.EnableHeadersVisualStyles = False
        Me.dgvDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvDiagnosis.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiagnosis.Name = "dgvDiagnosis"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDiagnosis.Size = New System.Drawing.Size(611, 113)
        Me.dgvDiagnosis.TabIndex = 0
        Me.dgvDiagnosis.Text = "DataGridView1"
        '
        'colDiseaseName
        '
        Me.colDiseaseName.DataPropertyName = "DiseaseName"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseName.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDiseaseName.HeaderText = "Diagnosis"
        Me.colDiseaseName.Name = "colDiseaseName"
        Me.colDiseaseName.ReadOnly = True
        Me.colDiseaseName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDiseaseName.Width = 400
        '
        'colDiseaseCategory
        '
        Me.colDiseaseCategory.DataPropertyName = "DiseaseCategories"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseCategory.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDiseaseCategory.HeaderText = "Category"
        Me.colDiseaseCategory.Name = "colDiseaseCategory"
        Me.colDiseaseCategory.ReadOnly = True
        Me.colDiseaseCategory.Width = 150
        '
        'tpgClaimDetails
        '
        Me.tpgClaimDetails.Controls.Add(Me.dgvClaimDetails)
        Me.tpgClaimDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgClaimDetails.Name = "tpgClaimDetails"
        Me.tpgClaimDetails.Size = New System.Drawing.Size(611, 113)
        Me.tpgClaimDetails.TabIndex = 1
        Me.tpgClaimDetails.Tag = "ClaimDetails"
        Me.tpgClaimDetails.Text = "Services"
        Me.tpgClaimDetails.UseVisualStyleBackColor = True
        '
        'dgvClaimDetails
        '
        Me.dgvClaimDetails.AllowUserToAddRows = False
        Me.dgvClaimDetails.AllowUserToOrderColumns = True
        Me.dgvClaimDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClaimDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvClaimDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemName, Me.colBenefitName, Me.colNotes, Me.colQuantity, Me.colUnitPrice, Me.colAmount})
        Me.dgvClaimDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClaimDetails.EnableHeadersVisualStyles = False
        Me.dgvClaimDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvClaimDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvClaimDetails.Name = "dgvClaimDetails"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClaimDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvClaimDetails.Size = New System.Drawing.Size(611, 113)
        Me.dgvClaimDetails.TabIndex = 1
        Me.dgvClaimDetails.Text = "DataGridView1"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(326, 69)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(130, 20)
        Me.lblJoinDate.TabIndex = 29
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(326, 27)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(130, 20)
        Me.lblAge.TabIndex = 25
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(326, 48)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(130, 20)
        Me.lblGenderID.TabIndex = 27
        Me.lblGenderID.Text = "Gender"
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(326, 6)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(130, 20)
        Me.lblName.TabIndex = 23
        Me.lblName.Text = "Member's Name"
        '
        'lblInsuranceName
        '
        Me.lblInsuranceName.Location = New System.Drawing.Point(326, 166)
        Me.lblInsuranceName.Name = "lblInsuranceName"
        Me.lblInsuranceName.Size = New System.Drawing.Size(130, 20)
        Me.lblInsuranceName.TabIndex = 37
        Me.lblInsuranceName.Text = "Insurance Name"
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(326, 135)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(130, 20)
        Me.lblBillCustomerName.TabIndex = 35
        Me.lblBillCustomerName.Text = "Company Name"
        '
        'lblPolicyName
        '
        Me.lblPolicyName.Location = New System.Drawing.Point(326, 190)
        Me.lblPolicyName.Name = "lblPolicyName"
        Me.lblPolicyName.Size = New System.Drawing.Size(130, 20)
        Me.lblPolicyName.TabIndex = 39
        Me.lblPolicyName.Text = "Policy Name"
        '
        'lblPolicyStartDate
        '
        Me.lblPolicyStartDate.Location = New System.Drawing.Point(326, 212)
        Me.lblPolicyStartDate.Name = "lblPolicyStartDate"
        Me.lblPolicyStartDate.Size = New System.Drawing.Size(130, 20)
        Me.lblPolicyStartDate.TabIndex = 41
        Me.lblPolicyStartDate.Text = "Policy Start Date"
        '
        'lblPolicyEndDate
        '
        Me.lblPolicyEndDate.Location = New System.Drawing.Point(326, 234)
        Me.lblPolicyEndDate.Name = "lblPolicyEndDate"
        Me.lblPolicyEndDate.Size = New System.Drawing.Size(130, 20)
        Me.lblPolicyEndDate.TabIndex = 43
        Me.lblPolicyEndDate.Text = "Policy End Date"
        '
        'stbTotalAmount
        '
        Me.stbTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalAmount.CapitalizeFirstLetter = False
        Me.stbTotalAmount.Enabled = False
        Me.stbTotalAmount.EntryErrorMSG = ""
        Me.stbTotalAmount.Location = New System.Drawing.Point(142, 195)
        Me.stbTotalAmount.MaxLength = 20
        Me.stbTotalAmount.Name = "stbTotalAmount"
        Me.stbTotalAmount.RegularExpression = ""
        Me.stbTotalAmount.Size = New System.Drawing.Size(170, 20)
        Me.stbTotalAmount.TabIndex = 20
        Me.stbTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMemberType
        '
        Me.lblMemberType.Location = New System.Drawing.Point(326, 90)
        Me.lblMemberType.Name = "lblMemberType"
        Me.lblMemberType.Size = New System.Drawing.Size(130, 20)
        Me.lblMemberType.TabIndex = 31
        Me.lblMemberType.Text = "Member Type"
        '
        'btnFindClaimNo
        '
        Me.btnFindClaimNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindClaimNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindClaimNo.Image = CType(resources.GetObject("btnFindClaimNo.Image"), System.Drawing.Image)
        Me.btnFindClaimNo.Location = New System.Drawing.Point(114, 5)
        Me.btnFindClaimNo.Name = "btnFindClaimNo"
        Me.btnFindClaimNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindClaimNo.TabIndex = 1
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(12, 132)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(124, 20)
        Me.lblPrimaryDoctor.TabIndex = 13
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'lblClaimEntry
        '
        Me.lblClaimEntry.Location = New System.Drawing.Point(12, 174)
        Me.lblClaimEntry.Name = "lblClaimEntry"
        Me.lblClaimEntry.Size = New System.Drawing.Size(124, 20)
        Me.lblClaimEntry.TabIndex = 17
        Me.lblClaimEntry.Text = "Claim Entry"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(326, 253)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(130, 20)
        Me.lblVisitNo.TabIndex = 45
        Me.lblVisitNo.Text = "Visit No"
        '
        'lblMainMemberName
        '
        Me.lblMainMemberName.Location = New System.Drawing.Point(326, 111)
        Me.lblMainMemberName.Name = "lblMainMemberName"
        Me.lblMainMemberName.Size = New System.Drawing.Size(130, 20)
        Me.lblMainMemberName.TabIndex = 33
        Me.lblMainMemberName.Text = "Main Member Name"
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(124, 429)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(104, 24)
        Me.btnPrintPreview.TabIndex = 49
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(15, 429)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(103, 24)
        Me.btnPrint.TabIndex = 48
        Me.btnPrint.Text = "&Print"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(142, 69)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitDate.TabIndex = 8
        '
        'stbVisitTime
        '
        Me.stbVisitTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitTime.CapitalizeFirstLetter = False
        Me.stbVisitTime.Enabled = False
        Me.stbVisitTime.EntryErrorMSG = ""
        Me.stbVisitTime.Location = New System.Drawing.Point(142, 90)
        Me.stbVisitTime.MaxLength = 60
        Me.stbVisitTime.Name = "stbVisitTime"
        Me.stbVisitTime.RegularExpression = ""
        Me.stbVisitTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitTime.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitTime.TabIndex = 10
        '
        'stbHealthUnitName
        '
        Me.stbHealthUnitName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbHealthUnitName.CapitalizeFirstLetter = False
        Me.stbHealthUnitName.Enabled = False
        Me.stbHealthUnitName.EntryErrorMSG = ""
        Me.stbHealthUnitName.Location = New System.Drawing.Point(142, 111)
        Me.stbHealthUnitName.MaxLength = 60
        Me.stbHealthUnitName.Name = "stbHealthUnitName"
        Me.stbHealthUnitName.RegularExpression = ""
        Me.stbHealthUnitName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbHealthUnitName.Size = New System.Drawing.Size(170, 20)
        Me.stbHealthUnitName.TabIndex = 12
        '
        'stbClaimStatus
        '
        Me.stbClaimStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimStatus.CapitalizeFirstLetter = False
        Me.stbClaimStatus.Enabled = False
        Me.stbClaimStatus.EntryErrorMSG = ""
        Me.stbClaimStatus.Location = New System.Drawing.Point(142, 153)
        Me.stbClaimStatus.MaxLength = 60
        Me.stbClaimStatus.Name = "stbClaimStatus"
        Me.stbClaimStatus.RegularExpression = ""
        Me.stbClaimStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbClaimStatus.Size = New System.Drawing.Size(170, 20)
        Me.stbClaimStatus.TabIndex = 16
        '
        'stbClaimEntry
        '
        Me.stbClaimEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimEntry.CapitalizeFirstLetter = False
        Me.stbClaimEntry.Enabled = False
        Me.stbClaimEntry.EntryErrorMSG = ""
        Me.stbClaimEntry.Location = New System.Drawing.Point(142, 174)
        Me.stbClaimEntry.MaxLength = 60
        Me.stbClaimEntry.Name = "stbClaimEntry"
        Me.stbClaimEntry.RegularExpression = ""
        Me.stbClaimEntry.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbClaimEntry.Size = New System.Drawing.Size(170, 20)
        Me.stbClaimEntry.TabIndex = 18
        '
        'btnLoadPeriodicClaims
        '
        Me.btnLoadPeriodicClaims.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicClaims.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicClaims.Location = New System.Drawing.Point(268, 2)
        Me.btnLoadPeriodicClaims.Name = "btnLoadPeriodicClaims"
        Me.btnLoadPeriodicClaims.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicClaims.TabIndex = 51
        Me.btnLoadPeriodicClaims.Tag = ""
        Me.btnLoadPeriodicClaims.Text = "&Load"
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle6
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.MaxInputLength = 40
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 200
        '
        'colBenefitName
        '
        Me.colBenefitName.DataPropertyName = "BenefitName"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colBenefitName.DefaultCellStyle = DataGridViewCellStyle7
        Me.colBenefitName.HeaderText = "Benefit Name"
        Me.colBenefitName.Name = "colBenefitName"
        Me.colBenefitName.ReadOnly = True
        Me.colBenefitName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colBenefitName.Width = 80
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colNotes.DefaultCellStyle = DataGridViewCellStyle8
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.Name = "colNotes"
        Me.colNotes.ReadOnly = True
        Me.colNotes.Width = 80
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle9
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 50
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle10
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 65
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle11
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 65
        '
        'frmPrintInsuranceClaims
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(651, 471)
        Me.Controls.Add(Me.btnLoadPeriodicClaims)
        Me.Controls.Add(Me.stbClaimEntry)
        Me.Controls.Add(Me.stbClaimStatus)
        Me.Controls.Add(Me.stbHealthUnitName)
        Me.Controls.Add(Me.stbVisitTime)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.stbMainMemberName)
        Me.Controls.Add(Me.lblMainMemberName)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.lblClaimEntry)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.btnFindClaimNo)
        Me.Controls.Add(Me.stbMemberType)
        Me.Controls.Add(Me.lblMemberType)
        Me.Controls.Add(Me.stbTotalAmount)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.stbPolicyEndDate)
        Me.Controls.Add(Me.lblPolicyEndDate)
        Me.Controls.Add(Me.stbPolicyStartDate)
        Me.Controls.Add(Me.lblPolicyStartDate)
        Me.Controls.Add(Me.stbPolicyName)
        Me.Controls.Add(Me.lblPolicyName)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblInsuranceName)
        Me.Controls.Add(Me.stbCompanyName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.stbMedicalCardNo)
        Me.Controls.Add(Me.tbcClaims)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbClaimNo)
        Me.Controls.Add(Me.lblClaimNo)
        Me.Controls.Add(Me.lblMedicalCardNo)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.lblVisitTime)
        Me.Controls.Add(Me.lblHealthUnitName)
        Me.Controls.Add(Me.stbAmountWords)
        Me.Controls.Add(Me.lblAmountWords)
        Me.Controls.Add(Me.lblClaimStatus)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPrintInsuranceClaims"
        Me.Text = "Print Insurance Claims"
        Me.tbcClaims.ResumeLayout(False)
        Me.tpgClaimDiagnosis.ResumeLayout(False)
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgClaimDetails.ResumeLayout(False)
        CType(Me.dgvClaimDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbClaimNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClaimNo As System.Windows.Forms.Label
    Friend WithEvents lblMedicalCardNo As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents lblVisitTime As System.Windows.Forms.Label
    Friend WithEvents lblHealthUnitName As System.Windows.Forms.Label
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountWords As System.Windows.Forms.Label
    Friend WithEvents lblClaimStatus As System.Windows.Forms.Label
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents tbcClaims As System.Windows.Forms.TabControl
    Friend WithEvents tpgClaimDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents tpgClaimDetails As System.Windows.Forms.TabPage
    Friend WithEvents dgvDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents stbMedicalCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbCompanyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbPolicyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPolicyName As System.Windows.Forms.Label
    Friend WithEvents stbPolicyStartDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPolicyStartDate As System.Windows.Forms.Label
    Friend WithEvents stbPolicyEndDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPolicyEndDate As System.Windows.Forms.Label
    Friend WithEvents stbTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents stbMemberType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberType As System.Windows.Forms.Label
    Friend WithEvents dgvClaimDetails As System.Windows.Forms.DataGridView
    Friend WithEvents btnFindClaimNo As System.Windows.Forms.Button
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents lblClaimEntry As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbMainMemberName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMainMemberName As System.Windows.Forms.Label
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbHealthUnitName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbClaimStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbClaimEntry As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents colDiseaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnLoadPeriodicClaims As System.Windows.Forms.Button
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBenefitName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn

End Class