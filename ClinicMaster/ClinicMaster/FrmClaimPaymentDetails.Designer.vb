<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClaimPaymentDetails
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


    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal claimNo As String)
        MyClass.New()
        Me._claimNo = claimNo
    End Sub

   
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmClaimPaymentDetails))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmsClaims = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsClaimsQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMainMemberName = New System.Windows.Forms.Label()
        Me.stbMainMemberName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblClaimEntry = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.btnFindClaimNo = New System.Windows.Forms.Button()
        Me.stbMemberType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberType = New System.Windows.Forms.Label()
        Me.stbTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.stbPolicyEndDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPolicyEndDate = New System.Windows.Forms.Label()
        Me.stbPolicyStartDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPolicyStartDate = New System.Windows.Forms.Label()
        Me.stbPolicyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPolicyName = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInsuranceName = New System.Windows.Forms.Label()
        Me.stbCompanyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.stbMedicalCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbHealthUnit = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbClaimEntry = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbClaimStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbClaimNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClaimNo = New System.Windows.Forms.Label()
        Me.lblMedicalCardNo = New System.Windows.Forms.Label()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.lblHealthUnitCode = New System.Windows.Forms.Label()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAmountWords = New System.Windows.Forms.Label()
        Me.lblClaimStatusID = New System.Windows.Forms.Label()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnLoadList = New System.Windows.Forms.Button()
        Me.lblWaitingToPayForClaims = New System.Windows.Forms.Label()
        Me.btnLoadPeriodicClaims = New System.Windows.Forms.Button()
        Me.dtpPaymentDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblPaymentDateTime = New System.Windows.Forms.Label()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tpgClaimDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvDiagnosis = New System.Windows.Forms.DataGridView()
        Me.tpgClaimDetails = New System.Windows.Forms.TabPage()
        Me.dgvClaimDetails = New System.Windows.Forms.DataGridView()
        Me.tbcClaims = New System.Windows.Forms.TabControl()
        Me.colDiseaseCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiagnosisSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdjustment = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClaimDetailsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colLimitAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLimitBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsClaims.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        Me.tpgClaimDiagnosis.SuspendLayout()
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgClaimDetails.SuspendLayout()
        CType(Me.dgvClaimDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcClaims.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsClaims
        '
        Me.cmsClaims.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsClaims.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsClaimsQuickSearch})
        Me.cmsClaims.Name = "cmsSearch"
        Me.cmsClaims.Size = New System.Drawing.Size(144, 26)
        '
        'cmsClaimsQuickSearch
        '
        Me.cmsClaimsQuickSearch.Image = CType(resources.GetObject("cmsClaimsQuickSearch.Image"), System.Drawing.Image)
        Me.cmsClaimsQuickSearch.Name = "cmsClaimsQuickSearch"
        Me.cmsClaimsQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsClaimsQuickSearch.Text = "Quick Search"
        '
        'lblMainMemberName
        '
        Me.lblMainMemberName.Location = New System.Drawing.Point(366, 117)
        Me.lblMainMemberName.Name = "lblMainMemberName"
        Me.lblMainMemberName.Size = New System.Drawing.Size(119, 20)
        Me.lblMainMemberName.TabIndex = 88
        Me.lblMainMemberName.Text = "Main Member Name"
        '
        'stbMainMemberName
        '
        Me.stbMainMemberName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMainMemberName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMainMemberName, "MainMemberName")
        Me.stbMainMemberName.Enabled = False
        Me.stbMainMemberName.EntryErrorMSG = ""
        Me.stbMainMemberName.Location = New System.Drawing.Point(502, 115)
        Me.stbMainMemberName.MaxLength = 60
        Me.stbMainMemberName.Name = "stbMainMemberName"
        Me.stbMainMemberName.ReadOnly = True
        Me.stbMainMemberName.RegularExpression = ""
        Me.stbMainMemberName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMainMemberName.Size = New System.Drawing.Size(161, 20)
        Me.stbMainMemberName.TabIndex = 89
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitNo, "VisitNo")
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(813, 133)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.ReadOnly = True
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(161, 20)
        Me.stbVisitNo.TabIndex = 101
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(694, 133)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(119, 20)
        Me.lblVisitNo.TabIndex = 100
        Me.lblVisitNo.Text = "Visit No"
        '
        'lblClaimEntry
        '
        Me.lblClaimEntry.Location = New System.Drawing.Point(23, 144)
        Me.lblClaimEntry.Name = "lblClaimEntry"
        Me.lblClaimEntry.Size = New System.Drawing.Size(124, 20)
        Me.lblClaimEntry.TabIndex = 72
        Me.lblClaimEntry.Text = "Claim Entry"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbPrimaryDoctor, "PrimaryDoctor")
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(158, 96)
        Me.stbPrimaryDoctor.MaxLength = 41
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.ReadOnly = True
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(189, 20)
        Me.stbPrimaryDoctor.TabIndex = 69
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(23, 99)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(124, 20)
        Me.lblPrimaryDoctor.TabIndex = 68
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'btnFindClaimNo
        '
        Me.btnFindClaimNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindClaimNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindClaimNo.Image = CType(resources.GetObject("btnFindClaimNo.Image"), System.Drawing.Image)
        Me.btnFindClaimNo.Location = New System.Drawing.Point(130, 10)
        Me.btnFindClaimNo.Name = "btnFindClaimNo"
        Me.btnFindClaimNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindClaimNo.TabIndex = 58
        '
        'stbMemberType
        '
        Me.stbMemberType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberType.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbMemberType, "MemberType")
        Me.stbMemberType.Enabled = False
        Me.stbMemberType.EntryErrorMSG = ""
        Me.stbMemberType.Location = New System.Drawing.Point(502, 94)
        Me.stbMemberType.MaxLength = 60
        Me.stbMemberType.Name = "stbMemberType"
        Me.stbMemberType.ReadOnly = True
        Me.stbMemberType.RegularExpression = ""
        Me.stbMemberType.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMemberType.Size = New System.Drawing.Size(161, 20)
        Me.stbMemberType.TabIndex = 87
        '
        'lblMemberType
        '
        Me.lblMemberType.Location = New System.Drawing.Point(366, 96)
        Me.lblMemberType.Name = "lblMemberType"
        Me.lblMemberType.Size = New System.Drawing.Size(119, 20)
        Me.lblMemberType.TabIndex = 86
        Me.lblMemberType.Text = "Member Type"
        '
        'stbTotalAmount
        '
        Me.stbTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalAmount.CapitalizeFirstLetter = False
        Me.stbTotalAmount.Enabled = False
        Me.stbTotalAmount.EntryErrorMSG = ""
        Me.stbTotalAmount.Location = New System.Drawing.Point(502, 136)
        Me.stbTotalAmount.MaxLength = 20
        Me.stbTotalAmount.Name = "stbTotalAmount"
        Me.stbTotalAmount.ReadOnly = True
        Me.stbTotalAmount.RegularExpression = ""
        Me.stbTotalAmount.Size = New System.Drawing.Size(159, 20)
        Me.stbTotalAmount.TabIndex = 75
        Me.stbTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Location = New System.Drawing.Point(366, 137)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(119, 20)
        Me.lblTotalAmount.TabIndex = 74
        Me.lblTotalAmount.Text = "Total Amount"
        '
        'stbPolicyEndDate
        '
        Me.stbPolicyEndDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPolicyEndDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPolicyEndDate, "PolicyEndDate")
        Me.stbPolicyEndDate.Enabled = False
        Me.stbPolicyEndDate.EntryErrorMSG = ""
        Me.stbPolicyEndDate.Location = New System.Drawing.Point(813, 112)
        Me.stbPolicyEndDate.MaxLength = 20
        Me.stbPolicyEndDate.Name = "stbPolicyEndDate"
        Me.stbPolicyEndDate.ReadOnly = True
        Me.stbPolicyEndDate.RegularExpression = ""
        Me.stbPolicyEndDate.Size = New System.Drawing.Size(161, 20)
        Me.stbPolicyEndDate.TabIndex = 99
        '
        'lblPolicyEndDate
        '
        Me.lblPolicyEndDate.Location = New System.Drawing.Point(694, 114)
        Me.lblPolicyEndDate.Name = "lblPolicyEndDate"
        Me.lblPolicyEndDate.Size = New System.Drawing.Size(119, 20)
        Me.lblPolicyEndDate.TabIndex = 98
        Me.lblPolicyEndDate.Text = "Policy End Date"
        '
        'stbPolicyStartDate
        '
        Me.stbPolicyStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPolicyStartDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPolicyStartDate, "PolicyStartDate")
        Me.stbPolicyStartDate.Enabled = False
        Me.stbPolicyStartDate.EntryErrorMSG = ""
        Me.stbPolicyStartDate.Location = New System.Drawing.Point(813, 91)
        Me.stbPolicyStartDate.MaxLength = 20
        Me.stbPolicyStartDate.Name = "stbPolicyStartDate"
        Me.stbPolicyStartDate.ReadOnly = True
        Me.stbPolicyStartDate.RegularExpression = ""
        Me.stbPolicyStartDate.Size = New System.Drawing.Size(161, 20)
        Me.stbPolicyStartDate.TabIndex = 97
        '
        'lblPolicyStartDate
        '
        Me.lblPolicyStartDate.Location = New System.Drawing.Point(694, 92)
        Me.lblPolicyStartDate.Name = "lblPolicyStartDate"
        Me.lblPolicyStartDate.Size = New System.Drawing.Size(119, 20)
        Me.lblPolicyStartDate.TabIndex = 96
        Me.lblPolicyStartDate.Text = "Policy Start Date"
        '
        'stbPolicyName
        '
        Me.stbPolicyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPolicyName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbPolicyName, "PolicyName")
        Me.stbPolicyName.Enabled = False
        Me.stbPolicyName.EntryErrorMSG = ""
        Me.stbPolicyName.Location = New System.Drawing.Point(813, 70)
        Me.stbPolicyName.MaxLength = 40
        Me.stbPolicyName.Name = "stbPolicyName"
        Me.stbPolicyName.ReadOnly = True
        Me.stbPolicyName.RegularExpression = ""
        Me.stbPolicyName.Size = New System.Drawing.Size(161, 20)
        Me.stbPolicyName.TabIndex = 95
        '
        'lblPolicyName
        '
        Me.lblPolicyName.Location = New System.Drawing.Point(694, 70)
        Me.lblPolicyName.Name = "lblPolicyName"
        Me.lblPolicyName.Size = New System.Drawing.Size(119, 20)
        Me.lblPolicyName.TabIndex = 94
        Me.lblPolicyName.Text = "Policy Name"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(813, 40)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(161, 29)
        Me.stbInsuranceName.TabIndex = 93
        '
        'lblInsuranceName
        '
        Me.lblInsuranceName.Location = New System.Drawing.Point(694, 46)
        Me.lblInsuranceName.Name = "lblInsuranceName"
        Me.lblInsuranceName.Size = New System.Drawing.Size(119, 20)
        Me.lblInsuranceName.TabIndex = 92
        Me.lblInsuranceName.Text = "Insurance Name"
        '
        'stbCompanyName
        '
        Me.stbCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCompanyName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbCompanyName, "CompanyName")
        Me.stbCompanyName.EntryErrorMSG = ""
        Me.stbCompanyName.Location = New System.Drawing.Point(813, 10)
        Me.stbCompanyName.MaxLength = 41
        Me.stbCompanyName.Multiline = True
        Me.stbCompanyName.Name = "stbCompanyName"
        Me.stbCompanyName.ReadOnly = True
        Me.stbCompanyName.RegularExpression = ""
        Me.stbCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCompanyName.Size = New System.Drawing.Size(161, 29)
        Me.stbCompanyName.TabIndex = 91
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(694, 15)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(119, 20)
        Me.lblBillCustomerName.TabIndex = 90
        Me.lblBillCustomerName.Text = "Company Name"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAge, "Age")
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(502, 31)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.ReadOnly = True
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(161, 20)
        Me.stbAge.TabIndex = 81
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbJoinDate, "JoinDate")
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(502, 73)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.ReadOnly = True
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(161, 20)
        Me.stbJoinDate.TabIndex = 85
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbGender, "Gender")
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(502, 52)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.ReadOnly = True
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(161, 20)
        Me.stbGender.TabIndex = 83
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(366, 75)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(119, 20)
        Me.lblJoinDate.TabIndex = 84
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(366, 33)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(119, 20)
        Me.lblAge.TabIndex = 80
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(366, 54)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(119, 20)
        Me.lblGenderID.TabIndex = 82
        Me.lblGenderID.Text = "Gender"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(502, 10)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(161, 20)
        Me.stbFullName.TabIndex = 79
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(366, 12)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(119, 20)
        Me.lblName.TabIndex = 78
        Me.lblName.Text = "Member's Name"
        '
        'stbMedicalCardNo
        '
        Me.stbMedicalCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMedicalCardNo.CapitalizeFirstLetter = False
        Me.stbMedicalCardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbMedicalCardNo, "MedicalCardNo")
        Me.stbMedicalCardNo.EntryErrorMSG = ""
        Me.stbMedicalCardNo.Location = New System.Drawing.Point(158, 33)
        Me.stbMedicalCardNo.MaxLength = 20
        Me.stbMedicalCardNo.Name = "stbMedicalCardNo"
        Me.stbMedicalCardNo.ReadOnly = True
        Me.stbMedicalCardNo.RegularExpression = ""
        Me.stbMedicalCardNo.Size = New System.Drawing.Size(189, 20)
        Me.stbMedicalCardNo.TabIndex = 56
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(26, 545)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 104
        Me.ebnSaveUpdate.Tag = "Claims"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(158, 54)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(189, 20)
        Me.stbPatientNo.TabIndex = 61
        '
        'stbHealthUnit
        '
        Me.stbHealthUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbHealthUnit.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbHealthUnit, "HealthUnitName")
        Me.stbHealthUnit.EntryErrorMSG = ""
        Me.stbHealthUnit.Location = New System.Drawing.Point(158, 75)
        Me.stbHealthUnit.MaxLength = 41
        Me.stbHealthUnit.Name = "stbHealthUnit"
        Me.stbHealthUnit.ReadOnly = True
        Me.stbHealthUnit.RegularExpression = ""
        Me.stbHealthUnit.Size = New System.Drawing.Size(189, 20)
        Me.stbHealthUnit.TabIndex = 107
        '
        'stbClaimEntry
        '
        Me.stbClaimEntry.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimEntry.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbClaimEntry, "ClaimEntry")
        Me.stbClaimEntry.EntryErrorMSG = ""
        Me.stbClaimEntry.Location = New System.Drawing.Point(158, 138)
        Me.stbClaimEntry.MaxLength = 41
        Me.stbClaimEntry.Name = "stbClaimEntry"
        Me.stbClaimEntry.ReadOnly = True
        Me.stbClaimEntry.RegularExpression = ""
        Me.stbClaimEntry.Size = New System.Drawing.Size(189, 20)
        Me.stbClaimEntry.TabIndex = 108
        '
        'stbClaimStatus
        '
        Me.stbClaimStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimStatus.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbClaimStatus, "ClaimStatus")
        Me.stbClaimStatus.EntryErrorMSG = ""
        Me.stbClaimStatus.Location = New System.Drawing.Point(158, 117)
        Me.stbClaimStatus.MaxLength = 41
        Me.stbClaimStatus.Name = "stbClaimStatus"
        Me.stbClaimStatus.ReadOnly = True
        Me.stbClaimStatus.RegularExpression = ""
        Me.stbClaimStatus.Size = New System.Drawing.Size(189, 20)
        Me.stbClaimStatus.TabIndex = 109
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitDate, "VisitDate")
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(813, 154)
        Me.stbVisitDate.MaxLength = 20
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.ReadOnly = True
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.Size = New System.Drawing.Size(161, 20)
        Me.stbVisitDate.TabIndex = 116
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(902, 545)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 106
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbClaimNo
        '
        Me.stbClaimNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClaimNo.CapitalizeFirstLetter = False
        Me.stbClaimNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbClaimNo.EntryErrorMSG = ""
        Me.stbClaimNo.Location = New System.Drawing.Point(158, 11)
        Me.stbClaimNo.MaxLength = 20
        Me.stbClaimNo.Name = "stbClaimNo"
        Me.stbClaimNo.RegularExpression = ""
        Me.stbClaimNo.Size = New System.Drawing.Size(135, 20)
        Me.stbClaimNo.TabIndex = 59
        '
        'lblClaimNo
        '
        Me.lblClaimNo.Location = New System.Drawing.Point(23, 11)
        Me.lblClaimNo.Name = "lblClaimNo"
        Me.lblClaimNo.Size = New System.Drawing.Size(91, 20)
        Me.lblClaimNo.TabIndex = 57
        Me.lblClaimNo.Text = "Claim No"
        '
        'lblMedicalCardNo
        '
        Me.lblMedicalCardNo.Location = New System.Drawing.Point(23, 33)
        Me.lblMedicalCardNo.Name = "lblMedicalCardNo"
        Me.lblMedicalCardNo.Size = New System.Drawing.Size(124, 20)
        Me.lblMedicalCardNo.TabIndex = 54
        Me.lblMedicalCardNo.Text = "Medical Card No"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(23, 54)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(124, 20)
        Me.lblPatientNo.TabIndex = 60
        Me.lblPatientNo.Text = "Patient No"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(694, 154)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(119, 20)
        Me.lblVisitDate.TabIndex = 62
        Me.lblVisitDate.Text = "Visit Date "
        '
        'lblHealthUnitCode
        '
        Me.lblHealthUnitCode.Location = New System.Drawing.Point(23, 76)
        Me.lblHealthUnitCode.Name = "lblHealthUnitCode"
        Me.lblHealthUnitCode.Size = New System.Drawing.Size(124, 20)
        Me.lblHealthUnitCode.TabIndex = 66
        Me.lblHealthUnitCode.Text = "Health Unit"
        '
        'stbAmountWords
        '
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = True
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(502, 157)
        Me.stbAmountWords.MaxLength = 200
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(159, 30)
        Me.stbAmountWords.TabIndex = 77
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Location = New System.Drawing.Point(366, 161)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(119, 20)
        Me.lblAmountWords.TabIndex = 76
        Me.lblAmountWords.Text = "Amount in Words"
        '
        'lblClaimStatusID
        '
        Me.lblClaimStatusID.Location = New System.Drawing.Point(23, 121)
        Me.lblClaimStatusID.Name = "lblClaimStatusID"
        Me.lblClaimStatusID.Size = New System.Drawing.Size(124, 20)
        Me.lblClaimStatusID.TabIndex = 70
        Me.lblClaimStatusID.Text = "Claim Status"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnLoadList)
        Me.pnlAlerts.Controls.Add(Me.lblWaitingToPayForClaims)
        Me.pnlAlerts.Location = New System.Drawing.Point(640, 192)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(345, 42)
        Me.pnlAlerts.TabIndex = 112
        '
        'btnLoadList
        '
        Me.btnLoadList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadList.Location = New System.Drawing.Point(272, 6)
        Me.btnLoadList.Name = "btnLoadList"
        Me.btnLoadList.Size = New System.Drawing.Size(66, 24)
        Me.btnLoadList.TabIndex = 1
        Me.btnLoadList.Tag = ""
        Me.btnLoadList.Text = "&Load List"
        '
        'lblWaitingToPayForClaims
        '
        Me.lblWaitingToPayForClaims.AccessibleDescription = ""
        Me.lblWaitingToPayForClaims.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaitingToPayForClaims.ForeColor = System.Drawing.Color.Red
        Me.lblWaitingToPayForClaims.Location = New System.Drawing.Point(3, 9)
        Me.lblWaitingToPayForClaims.Name = "lblWaitingToPayForClaims"
        Me.lblWaitingToPayForClaims.Size = New System.Drawing.Size(258, 20)
        Me.lblWaitingToPayForClaims.TabIndex = 0
        Me.lblWaitingToPayForClaims.Text = "Waiting To Pay For Claims:"
        Me.lblWaitingToPayForClaims.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnLoadPeriodicClaims
        '
        Me.btnLoadPeriodicClaims.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicClaims.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicClaims.Location = New System.Drawing.Point(299, 7)
        Me.btnLoadPeriodicClaims.Name = "btnLoadPeriodicClaims"
        Me.btnLoadPeriodicClaims.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadPeriodicClaims.TabIndex = 113
        Me.btnLoadPeriodicClaims.Tag = ""
        Me.btnLoadPeriodicClaims.Text = "&Load"
        '
        'dtpPaymentDateTime
        '
        Me.dtpPaymentDateTime.Checked = False
        Me.dtpPaymentDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpPaymentDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpPaymentDateTime.Location = New System.Drawing.Point(158, 161)
        Me.dtpPaymentDateTime.Name = "dtpPaymentDateTime"
        Me.dtpPaymentDateTime.ShowCheckBox = True
        Me.dtpPaymentDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpPaymentDateTime.TabIndex = 115
        '
        'lblPaymentDateTime
        '
        Me.lblPaymentDateTime.Location = New System.Drawing.Point(23, 164)
        Me.lblPaymentDateTime.Name = "lblPaymentDateTime"
        Me.lblPaymentDateTime.Size = New System.Drawing.Size(129, 20)
        Me.lblPaymentDateTime.TabIndex = 114
        Me.lblPaymentDateTime.Text = "Payment DateTime"
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(902, 515)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 117
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        '
        'tpgClaimDiagnosis
        '
        Me.tpgClaimDiagnosis.Controls.Add(Me.dgvDiagnosis)
        Me.tpgClaimDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgClaimDiagnosis.Name = "tpgClaimDiagnosis"
        Me.tpgClaimDiagnosis.Size = New System.Drawing.Size(969, 236)
        Me.tpgClaimDiagnosis.TabIndex = 2
        Me.tpgClaimDiagnosis.Tag = "ClaimDiagnosis"
        Me.tpgClaimDiagnosis.Text = "Diagnosis"
        Me.tpgClaimDiagnosis.UseVisualStyleBackColor = True
        '
        'dgvDiagnosis
        '
        Me.dgvDiagnosis.AllowUserToDeleteRows = False
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
        Me.dgvDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDiseaseCode, Me.colDiseaseCategory, Me.colDiagnosisSaved})
        Me.dgvDiagnosis.ContextMenuStrip = Me.cmsClaims
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDiagnosis.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiagnosis.EnableHeadersVisualStyles = False
        Me.dgvDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvDiagnosis.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiagnosis.Name = "dgvDiagnosis"
        Me.dgvDiagnosis.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDiagnosis.Size = New System.Drawing.Size(969, 236)
        Me.dgvDiagnosis.TabIndex = 0
        Me.dgvDiagnosis.Text = "DataGridView1"
        '
        'tpgClaimDetails
        '
        Me.tpgClaimDetails.Controls.Add(Me.dgvClaimDetails)
        Me.tpgClaimDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgClaimDetails.Name = "tpgClaimDetails"
        Me.tpgClaimDetails.Size = New System.Drawing.Size(969, 236)
        Me.tpgClaimDetails.TabIndex = 1
        Me.tpgClaimDetails.Tag = "ClaimDetails"
        Me.tpgClaimDetails.Text = "Services"
        Me.tpgClaimDetails.UseVisualStyleBackColor = True
        '
        'dgvClaimDetails
        '
        Me.dgvClaimDetails.AllowUserToDeleteRows = False
        Me.dgvClaimDetails.AllowUserToOrderColumns = True
        Me.dgvClaimDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClaimDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvClaimDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemName, Me.colQuantity, Me.colUnitPrice, Me.colAdjustment, Me.colAmount, Me.colNotes, Me.colClaimDetailsSaved, Me.colLimitAmount, Me.colConsumedAmount, Me.colLimitBalance})
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvClaimDetails.DefaultCellStyle = DataGridViewCellStyle18
        Me.dgvClaimDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvClaimDetails.EnableHeadersVisualStyles = False
        Me.dgvClaimDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvClaimDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvClaimDetails.Name = "dgvClaimDetails"
        Me.dgvClaimDetails.ReadOnly = True
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClaimDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvClaimDetails.Size = New System.Drawing.Size(969, 236)
        Me.dgvClaimDetails.TabIndex = 1
        Me.dgvClaimDetails.Text = "DataGridView1"
        '
        'tbcClaims
        '
        Me.tbcClaims.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcClaims.Controls.Add(Me.tpgClaimDetails)
        Me.tbcClaims.Controls.Add(Me.tpgClaimDiagnosis)
        Me.tbcClaims.HotTrack = True
        Me.tbcClaims.Location = New System.Drawing.Point(12, 239)
        Me.tbcClaims.Name = "tbcClaims"
        Me.tbcClaims.SelectedIndex = 0
        Me.tbcClaims.Size = New System.Drawing.Size(977, 262)
        Me.tbcClaims.TabIndex = 102
        '
        'colDiseaseCode
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDiseaseCode.HeaderText = "Diagnosis"
        Me.colDiseaseCode.Name = "colDiseaseCode"
        Me.colDiseaseCode.ReadOnly = True
        Me.colDiseaseCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDiseaseCode.Width = 350
        '
        'colDiseaseCategory
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseCategory.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDiseaseCategory.HeaderText = "Category"
        Me.colDiseaseCategory.Name = "colDiseaseCategory"
        Me.colDiseaseCategory.ReadOnly = True
        Me.colDiseaseCategory.Width = 150
        '
        'colDiagnosisSaved
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle4.NullValue = False
        Me.colDiagnosisSaved.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDiagnosisSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDiagnosisSaved.HeaderText = "Saved"
        Me.colDiagnosisSaved.Name = "colDiagnosisSaved"
        Me.colDiagnosisSaved.ReadOnly = True
        Me.colDiagnosisSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colDiagnosisSaved.Width = 50
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle8
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.MaxInputLength = 100
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 150
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
        'colAdjustment
        '
        Me.colAdjustment.DataPropertyName = "Adjustment"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colAdjustment.DefaultCellStyle = DataGridViewCellStyle11
        Me.colAdjustment.HeaderText = "Adjustment"
        Me.colAdjustment.Name = "colAdjustment"
        Me.colAdjustment.ReadOnly = True
        Me.colAdjustment.Width = 65
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle12.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle12
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 65
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colNotes.DefaultCellStyle = DataGridViewCellStyle13
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 400
        Me.colNotes.Name = "colNotes"
        Me.colNotes.ReadOnly = True
        Me.colNotes.Width = 120
        '
        'colClaimDetailsSaved
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle14.NullValue = False
        Me.colClaimDetailsSaved.DefaultCellStyle = DataGridViewCellStyle14
        Me.colClaimDetailsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colClaimDetailsSaved.HeaderText = "Saved"
        Me.colClaimDetailsSaved.Name = "colClaimDetailsSaved"
        Me.colClaimDetailsSaved.ReadOnly = True
        Me.colClaimDetailsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colClaimDetailsSaved.Width = 50
        '
        'colLimitAmount
        '
        Me.colLimitAmount.DataPropertyName = "LimitAmount"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.colLimitAmount.DefaultCellStyle = DataGridViewCellStyle15
        Me.colLimitAmount.HeaderText = "Limit Amount"
        Me.colLimitAmount.Name = "colLimitAmount"
        Me.colLimitAmount.ReadOnly = True
        Me.colLimitAmount.Width = 85
        '
        'colConsumedAmount
        '
        Me.colConsumedAmount.DataPropertyName = "ConsumedAmount"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.colConsumedAmount.DefaultCellStyle = DataGridViewCellStyle16
        Me.colConsumedAmount.HeaderText = "Consumed Amount"
        Me.colConsumedAmount.Name = "colConsumedAmount"
        Me.colConsumedAmount.ReadOnly = True
        Me.colConsumedAmount.Width = 110
        '
        'colLimitBalance
        '
        Me.colLimitBalance.DataPropertyName = "LimitBalance"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle17.Format = "N2"
        DataGridViewCellStyle17.NullValue = Nothing
        Me.colLimitBalance.DefaultCellStyle = DataGridViewCellStyle17
        Me.colLimitBalance.HeaderText = "Limit Balance"
        Me.colLimitBalance.Name = "colLimitBalance"
        Me.colLimitBalance.ReadOnly = True
        Me.colLimitBalance.Width = 85
        '
        'FrmClaimPaymentDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1003, 583)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.dtpPaymentDateTime)
        Me.Controls.Add(Me.lblPaymentDateTime)
        Me.Controls.Add(Me.btnLoadPeriodicClaims)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.stbClaimStatus)
        Me.Controls.Add(Me.stbClaimEntry)
        Me.Controls.Add(Me.stbHealthUnit)
        Me.Controls.Add(Me.lblMainMemberName)
        Me.Controls.Add(Me.stbMainMemberName)
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
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbClaimNo)
        Me.Controls.Add(Me.lblClaimNo)
        Me.Controls.Add(Me.lblMedicalCardNo)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.lblHealthUnitCode)
        Me.Controls.Add(Me.stbAmountWords)
        Me.Controls.Add(Me.lblAmountWords)
        Me.Controls.Add(Me.lblClaimStatusID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmClaimPaymentDetails"
        Me.Text = "Claim Payment Details"
        Me.cmsClaims.ResumeLayout(False)
        Me.pnlAlerts.ResumeLayout(False)
        Me.tpgClaimDiagnosis.ResumeLayout(False)
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgClaimDetails.ResumeLayout(False)
        CType(Me.dgvClaimDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcClaims.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmsClaims As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsClaimsQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMainMemberName As System.Windows.Forms.Label
    Friend WithEvents stbMainMemberName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents lblClaimEntry As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents btnFindClaimNo As System.Windows.Forms.Button
    Friend WithEvents stbMemberType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberType As System.Windows.Forms.Label
    Friend WithEvents stbTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents stbPolicyEndDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPolicyEndDate As System.Windows.Forms.Label
    Friend WithEvents stbPolicyStartDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPolicyStartDate As System.Windows.Forms.Label
    Friend WithEvents stbPolicyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPolicyName As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbCompanyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents stbMedicalCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbClaimNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClaimNo As System.Windows.Forms.Label
    Friend WithEvents lblMedicalCardNo As System.Windows.Forms.Label
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents lblHealthUnitCode As System.Windows.Forms.Label
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountWords As System.Windows.Forms.Label
    Friend WithEvents lblClaimStatusID As System.Windows.Forms.Label
    Friend WithEvents stbHealthUnit As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbClaimEntry As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbClaimStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnLoadList As System.Windows.Forms.Button
    Friend WithEvents lblWaitingToPayForClaims As System.Windows.Forms.Label
    Friend WithEvents btnLoadPeriodicClaims As System.Windows.Forms.Button
    Friend WithEvents dtpPaymentDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPaymentDateTime As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tpgClaimDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents dgvDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents tpgClaimDetails As System.Windows.Forms.TabPage
    Friend WithEvents dgvClaimDetails As System.Windows.Forms.DataGridView
    Friend WithEvents tbcClaims As System.Windows.Forms.TabControl
    Friend WithEvents colDiseaseCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiagnosisSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdjustment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClaimDetailsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colLimitAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLimitBalance As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
