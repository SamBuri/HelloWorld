
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCancerDiagnosis : Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCancerDiagnosis))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmsDoctor = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsDoctorCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsDoctorSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsDoctorQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblServicePayStatusID = New System.Windows.Forms.Label()
        Me.stbCombination = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCombination = New System.Windows.Forms.Label()
        Me.stbBillServiceFee = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillServiceFee = New System.Windows.Forms.Label()
        Me.cboServiceCode = New System.Windows.Forms.ComboBox()
        Me.lblServiceCode = New System.Windows.Forms.Label()
        Me.nbxOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOutstandingBalance = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbTotalVisits = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalVisits = New System.Windows.Forms.Label()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.lblStaff = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitServiceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitServiceName = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.pnlVisitNo = New System.Windows.Forms.Panel()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadSeeDrVisits = New System.Windows.Forms.Button()
        Me.pnlNavigateVisits = New System.Windows.Forms.Panel()
        Me.chkNavigateVisits = New System.Windows.Forms.CheckBox()
        Me.navVisits = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.tpgDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvCancerDiagnosis = New System.Windows.Forms.DataGridView()
        Me.tbcDrCancerRoles = New System.Windows.Forms.TabControl()
        Me.ColTopology = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDiseaseCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colCancerDiagnosisCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBasisOfDiagnosis = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColCancerStage = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiagnosisSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsDoctor.SuspendLayout()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlVisitNo.SuspendLayout()
        Me.pnlNavigateVisits.SuspendLayout()
        Me.tpgDiagnosis.SuspendLayout()
        CType(Me.dgvCancerDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcDrCancerRoles.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsDoctor
        '
        Me.cmsDoctor.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsDoctor.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsDoctorCopy, Me.cmsDoctorSelectAll, Me.cmsDoctorQuickSearch})
        Me.cmsDoctor.Name = "cmsSearch"
        Me.cmsDoctor.Size = New System.Drawing.Size(144, 70)
        '
        'cmsDoctorCopy
        '
        Me.cmsDoctorCopy.Enabled = False
        Me.cmsDoctorCopy.Image = CType(resources.GetObject("cmsDoctorCopy.Image"), System.Drawing.Image)
        Me.cmsDoctorCopy.Name = "cmsDoctorCopy"
        Me.cmsDoctorCopy.Size = New System.Drawing.Size(143, 22)
        Me.cmsDoctorCopy.Text = "Copy"
        Me.cmsDoctorCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsDoctorSelectAll
        '
        Me.cmsDoctorSelectAll.Enabled = False
        Me.cmsDoctorSelectAll.Name = "cmsDoctorSelectAll"
        Me.cmsDoctorSelectAll.Size = New System.Drawing.Size(143, 22)
        Me.cmsDoctorSelectAll.Text = "Select All"
        '
        'cmsDoctorQuickSearch
        '
        Me.cmsDoctorQuickSearch.Image = CType(resources.GetObject("cmsDoctorQuickSearch.Image"), System.Drawing.Image)
        Me.cmsDoctorQuickSearch.Name = "cmsDoctorQuickSearch"
        Me.cmsDoctorQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsDoctorQuickSearch.Text = "Quick Search"
        '
        'lblServicePayStatusID
        '
        Me.lblServicePayStatusID.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblServicePayStatusID.Location = New System.Drawing.Point(241, 104)
        Me.lblServicePayStatusID.Name = "lblServicePayStatusID"
        Me.lblServicePayStatusID.Size = New System.Drawing.Size(63, 19)
        Me.lblServicePayStatusID.TabIndex = 58
        Me.lblServicePayStatusID.Text = "Not Paid"
        Me.lblServicePayStatusID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stbCombination
        '
        Me.stbCombination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCombination.CapitalizeFirstLetter = False
        Me.stbCombination.Enabled = False
        Me.stbCombination.EntryErrorMSG = ""
        Me.stbCombination.Location = New System.Drawing.Point(446, 118)
        Me.stbCombination.MaxLength = 41
        Me.stbCombination.Name = "stbCombination"
        Me.stbCombination.RegularExpression = ""
        Me.stbCombination.Size = New System.Drawing.Size(149, 20)
        Me.stbCombination.TabIndex = 72
        '
        'lblCombination
        '
        Me.lblCombination.Location = New System.Drawing.Point(318, 120)
        Me.lblCombination.Name = "lblCombination"
        Me.lblCombination.Size = New System.Drawing.Size(110, 20)
        Me.lblCombination.TabIndex = 71
        Me.lblCombination.Text = "Combination"
        '
        'stbBillServiceFee
        '
        Me.stbBillServiceFee.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillServiceFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillServiceFee.CapitalizeFirstLetter = False
        Me.stbBillServiceFee.EntryErrorMSG = ""
        Me.stbBillServiceFee.ForeColor = System.Drawing.SystemColors.WindowText
        Me.stbBillServiceFee.Location = New System.Drawing.Point(146, 103)
        Me.stbBillServiceFee.MaxLength = 20
        Me.stbBillServiceFee.Name = "stbBillServiceFee"
        Me.stbBillServiceFee.ReadOnly = True
        Me.stbBillServiceFee.RegularExpression = ""
        Me.stbBillServiceFee.Size = New System.Drawing.Size(89, 20)
        Me.stbBillServiceFee.TabIndex = 57
        '
        'lblBillServiceFee
        '
        Me.lblBillServiceFee.Location = New System.Drawing.Point(8, 103)
        Me.lblBillServiceFee.Name = "lblBillServiceFee"
        Me.lblBillServiceFee.Size = New System.Drawing.Size(132, 18)
        Me.lblBillServiceFee.TabIndex = 56
        Me.lblBillServiceFee.Text = "To-Bill Service Fee"
        '
        'cboServiceCode
        '
        Me.cboServiceCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiceCode.DropDownWidth = 220
        Me.cboServiceCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboServiceCode.FormattingEnabled = True
        Me.cboServiceCode.ItemHeight = 13
        Me.cboServiceCode.Location = New System.Drawing.Point(146, 80)
        Me.cboServiceCode.Name = "cboServiceCode"
        Me.cboServiceCode.Size = New System.Drawing.Size(158, 21)
        Me.cboServiceCode.TabIndex = 55
        '
        'lblServiceCode
        '
        Me.lblServiceCode.Location = New System.Drawing.Point(8, 79)
        Me.lblServiceCode.Name = "lblServiceCode"
        Me.lblServiceCode.Size = New System.Drawing.Size(132, 20)
        Me.lblServiceCode.TabIndex = 54
        Me.lblServiceCode.Text = "To-Bill Service"
        '
        'nbxOutstandingBalance
        '
        Me.nbxOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOutstandingBalance.DecimalPlaces = -1
        Me.nbxOutstandingBalance.ForeColor = System.Drawing.SystemColors.WindowText
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(801, 93)
        Me.nbxOutstandingBalance.MaxValue = 0R
        Me.nbxOutstandingBalance.MinValue = 0R
        Me.nbxOutstandingBalance.MustEnterNumeric = True
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = True
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(135, 20)
        Me.nbxOutstandingBalance.TabIndex = 82
        Me.nbxOutstandingBalance.Value = ""
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(601, 94)
        Me.lblOutstandingBalance.Name = "lblOutstandingBalance"
        Me.lblOutstandingBalance.Size = New System.Drawing.Size(159, 20)
        Me.lblOutstandingBalance.TabIndex = 81
        Me.lblOutstandingBalance.Text = "Outstanding Balance"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(446, 88)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(149, 29)
        Me.stbBillCustomerName.TabIndex = 70
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(318, 93)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(110, 20)
        Me.lblBillCustomerName.TabIndex = 69
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalVisits.CapitalizeFirstLetter = False
        Me.stbTotalVisits.Enabled = False
        Me.stbTotalVisits.EntryErrorMSG = ""
        Me.stbTotalVisits.Location = New System.Drawing.Point(678, 66)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(152, 20)
        Me.stbTotalVisits.TabIndex = 80
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(601, 66)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(71, 20)
        Me.lblTotalVisits.TabIndex = 79
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(836, 3)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(100, 89)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 83
        Me.spbPhoto.TabStop = False
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(65, 7)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 48
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(146, 125)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitDate.TabIndex = 60
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(446, 25)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(149, 20)
        Me.stbPatientNo.TabIndex = 64
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(318, 26)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(110, 20)
        Me.lblPatientsNo.TabIndex = 63
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.DropDownWidth = 220
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.FormattingEnabled = True
        Me.cboStaffNo.Location = New System.Drawing.Point(146, 35)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(158, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 51
        '
        'lblStaff
        '
        Me.lblStaff.Location = New System.Drawing.Point(8, 37)
        Me.lblStaff.Name = "lblStaff"
        Me.lblStaff.Size = New System.Drawing.Size(132, 20)
        Me.lblStaff.TabIndex = 50
        Me.lblStaff.Text = "Primary Dr. (Staff)"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(678, 45)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(152, 20)
        Me.stbBillMode.TabIndex = 78
        '
        'stbVisitServiceName
        '
        Me.stbVisitServiceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitServiceName.CapitalizeFirstLetter = False
        Me.stbVisitServiceName.Enabled = False
        Me.stbVisitServiceName.EntryErrorMSG = ""
        Me.stbVisitServiceName.Location = New System.Drawing.Point(146, 58)
        Me.stbVisitServiceName.MaxLength = 60
        Me.stbVisitServiceName.Name = "stbVisitServiceName"
        Me.stbVisitServiceName.RegularExpression = ""
        Me.stbVisitServiceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitServiceName.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitServiceName.TabIndex = 53
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(601, 47)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(71, 20)
        Me.lblBillMode.TabIndex = 77
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitServiceName
        '
        Me.lblVisitServiceName.Location = New System.Drawing.Point(8, 58)
        Me.lblVisitServiceName.Name = "lblVisitServiceName"
        Me.lblVisitServiceName.Size = New System.Drawing.Size(132, 20)
        Me.lblVisitServiceName.TabIndex = 52
        Me.lblVisitServiceName.Text = "Visit Registered Service"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(446, 67)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(149, 20)
        Me.stbBillNo.TabIndex = 68
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(678, 3)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(152, 20)
        Me.stbAge.TabIndex = 74
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(446, 46)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(149, 20)
        Me.stbJoinDate.TabIndex = 66
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(678, 24)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(152, 20)
        Me.stbGender.TabIndex = 76
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(318, 45)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(110, 20)
        Me.lblJoinDate.TabIndex = 65
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(318, 67)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(110, 20)
        Me.lblBillNo.TabIndex = 67
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(601, 3)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(71, 20)
        Me.lblAge.TabIndex = 73
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(601, 24)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(71, 20)
        Me.lblGenderID.TabIndex = 75
        Me.lblGenderID.Text = "Gender"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(8, 125)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(132, 20)
        Me.lblVisitDate.TabIndex = 59
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(446, 4)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(149, 20)
        Me.stbFullName.TabIndex = 62
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(318, 4)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(110, 20)
        Me.lblFullName.TabIndex = 61
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(8, 9)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(52, 18)
        Me.lblVisitNo.TabIndex = 47
        Me.lblVisitNo.Text = "Visit No."
        '
        'pnlVisitNo
        '
        Me.pnlVisitNo.Controls.Add(Me.stbVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.btnLoadSeeDrVisits)
        Me.pnlVisitNo.Location = New System.Drawing.Point(98, 3)
        Me.pnlVisitNo.Name = "pnlVisitNo"
        Me.pnlVisitNo.Size = New System.Drawing.Size(216, 30)
        Me.pnlVisitNo.TabIndex = 49
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(4, 5)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(149, 20)
        Me.stbVisitNo.TabIndex = 0
        '
        'btnLoadSeeDrVisits
        '
        Me.btnLoadSeeDrVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadSeeDrVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadSeeDrVisits.Location = New System.Drawing.Point(156, 3)
        Me.btnLoadSeeDrVisits.Name = "btnLoadSeeDrVisits"
        Me.btnLoadSeeDrVisits.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadSeeDrVisits.TabIndex = 1
        Me.btnLoadSeeDrVisits.Tag = ""
        Me.btnLoadSeeDrVisits.Text = "&Load"
        '
        'pnlNavigateVisits
        '
        Me.pnlNavigateVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateVisits.Controls.Add(Me.chkNavigateVisits)
        Me.pnlNavigateVisits.Controls.Add(Me.navVisits)
        Me.pnlNavigateVisits.Location = New System.Drawing.Point(116, 434)
        Me.pnlNavigateVisits.Name = "pnlNavigateVisits"
        Me.pnlNavigateVisits.Size = New System.Drawing.Size(601, 33)
        Me.pnlNavigateVisits.TabIndex = 85
        '
        'chkNavigateVisits
        '
        Me.chkNavigateVisits.AccessibleDescription = ""
        Me.chkNavigateVisits.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateVisits.Location = New System.Drawing.Point(8, 9)
        Me.chkNavigateVisits.Name = "chkNavigateVisits"
        Me.chkNavigateVisits.Size = New System.Drawing.Size(144, 20)
        Me.chkNavigateVisits.TabIndex = 0
        Me.chkNavigateVisits.Text = "Navigate Patient Visits"
        '
        'navVisits
        '
        Me.navVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navVisits.ColumnName = "VisitNo"
        Me.navVisits.DataSource = Nothing
        Me.navVisits.Location = New System.Drawing.Point(171, 2)
        Me.navVisits.Name = "navVisits"
        Me.navVisits.NavAllEnabled = False
        Me.navVisits.NavLeftEnabled = False
        Me.navVisits.NavRightEnabled = False
        Me.navVisits.Size = New System.Drawing.Size(413, 32)
        Me.navVisits.TabIndex = 1
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(813, 436)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(59, 24)
        Me.btnPrint.TabIndex = 87
        Me.btnPrint.Text = "&Print"
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(752, 436)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(59, 24)
        Me.btnDelete.TabIndex = 86
        Me.btnDelete.Tag = "ClinicalFindings"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(19, 434)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(57, 24)
        Me.btnSave.TabIndex = 84
        Me.btnSave.Tag = ""
        Me.btnSave.Text = "&Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(878, 436)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(58, 24)
        Me.btnClose.TabIndex = 88
        Me.btnClose.Text = "&Close"
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(821, 122)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(115, 23)
        Me.btnFindByFingerprint.TabIndex = 89
        Me.btnFindByFingerprint.Text = "Find By &Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'tpgDiagnosis
        '
        Me.tpgDiagnosis.Controls.Add(Me.dgvCancerDiagnosis)
        Me.tpgDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgDiagnosis.Name = "tpgDiagnosis"
        Me.tpgDiagnosis.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgDiagnosis.Size = New System.Drawing.Size(935, 240)
        Me.tpgDiagnosis.TabIndex = 6
        Me.tpgDiagnosis.Tag = "Diagnosis"
        Me.tpgDiagnosis.Text = "Diagnosis"
        Me.tpgDiagnosis.UseVisualStyleBackColor = True
        '
        'dgvCancerDiagnosis
        '
        Me.dgvCancerDiagnosis.AllowUserToOrderColumns = True
        Me.dgvCancerDiagnosis.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCancerDiagnosis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCancerDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColTopology, Me.colDiseaseCode, Me.colCancerDiagnosisCode, Me.colDiseaseCategory, Me.ColBasisOfDiagnosis, Me.ColCancerStage, Me.colNotes, Me.colDiagnosisSaved})
        Me.dgvCancerDiagnosis.ContextMenuStrip = Me.cmsDoctor
        Me.dgvCancerDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCancerDiagnosis.EnableHeadersVisualStyles = False
        Me.dgvCancerDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvCancerDiagnosis.Location = New System.Drawing.Point(3, 3)
        Me.dgvCancerDiagnosis.Name = "dgvCancerDiagnosis"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCancerDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvCancerDiagnosis.Size = New System.Drawing.Size(929, 234)
        Me.dgvCancerDiagnosis.TabIndex = 0
        Me.dgvCancerDiagnosis.Text = "DataGridView1"
        '
        'tbcDrCancerRoles
        '
        Me.tbcDrCancerRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDrCancerRoles.Controls.Add(Me.tpgDiagnosis)
        Me.tbcDrCancerRoles.HotTrack = True
        Me.tbcDrCancerRoles.Location = New System.Drawing.Point(12, 151)
        Me.tbcDrCancerRoles.Name = "tbcDrCancerRoles"
        Me.tbcDrCancerRoles.SelectedIndex = 0
        Me.tbcDrCancerRoles.Size = New System.Drawing.Size(943, 266)
        Me.tbcDrCancerRoles.TabIndex = 46
        '
        'ColTopology
        '
        Me.ColTopology.DisplayStyleForCurrentCellOnly = True
        Me.ColTopology.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColTopology.HeaderText = "Topology / Site"
        Me.ColTopology.Name = "ColTopology"
        Me.ColTopology.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColTopology.Width = 150
        '
        'colDiseaseCode
        '
        Me.colDiseaseCode.DisplayStyleForCurrentCellOnly = True
        Me.colDiseaseCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDiseaseCode.HeaderText = "Diagnosis"
        Me.colDiseaseCode.Name = "colDiseaseCode"
        Me.colDiseaseCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDiseaseCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDiseaseCode.Width = 200
        '
        'colCancerDiagnosisCode
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colCancerDiagnosisCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colCancerDiagnosisCode.HeaderText = "Code"
        Me.colCancerDiagnosisCode.Name = "colCancerDiagnosisCode"
        Me.colCancerDiagnosisCode.ReadOnly = True
        Me.colCancerDiagnosisCode.Width = 80
        '
        'colDiseaseCategory
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseCategory.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDiseaseCategory.HeaderText = "Category"
        Me.colDiseaseCategory.Name = "colDiseaseCategory"
        Me.colDiseaseCategory.ReadOnly = True
        '
        'ColBasisOfDiagnosis
        '
        Me.ColBasisOfDiagnosis.DisplayStyleForCurrentCellOnly = True
        Me.ColBasisOfDiagnosis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColBasisOfDiagnosis.HeaderText = "Basis Of Diagnosis"
        Me.ColBasisOfDiagnosis.Name = "ColBasisOfDiagnosis"
        Me.ColBasisOfDiagnosis.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColBasisOfDiagnosis.Width = 120
        '
        'ColCancerStage
        '
        Me.ColCancerStage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColCancerStage.HeaderText = "Stage"
        Me.ColCancerStage.Name = "ColCancerStage"
        Me.ColCancerStage.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColCancerStage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColCancerStage.Width = 50
        '
        'colNotes
        '
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 100
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Width = 120
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
        'frmCancerDiagnosis
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(966, 478)
        Me.Controls.Add(Me.btnFindByFingerprint)
        Me.Controls.Add(Me.pnlNavigateVisits)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblServicePayStatusID)
        Me.Controls.Add(Me.stbCombination)
        Me.Controls.Add(Me.lblCombination)
        Me.Controls.Add(Me.stbBillServiceFee)
        Me.Controls.Add(Me.lblBillServiceFee)
        Me.Controls.Add(Me.cboServiceCode)
        Me.Controls.Add(Me.lblServiceCode)
        Me.Controls.Add(Me.nbxOutstandingBalance)
        Me.Controls.Add(Me.lblOutstandingBalance)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbTotalVisits)
        Me.Controls.Add(Me.lblTotalVisits)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.lblStaff)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.stbVisitServiceName)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.lblVisitServiceName)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.pnlVisitNo)
        Me.Controls.Add(Me.tbcDrCancerRoles)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmCancerDiagnosis"
        Me.Text = "Cancer Diagnosis"
        Me.cmsDoctor.ResumeLayout(False)
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlVisitNo.ResumeLayout(False)
        Me.pnlVisitNo.PerformLayout()
        Me.pnlNavigateVisits.ResumeLayout(False)
        Me.tpgDiagnosis.ResumeLayout(False)
        CType(Me.dgvCancerDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcDrCancerRoles.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblServicePayStatusID As System.Windows.Forms.Label
    Friend WithEvents stbCombination As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCombination As System.Windows.Forms.Label
    Friend WithEvents stbBillServiceFee As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillServiceFee As System.Windows.Forms.Label
    Friend WithEvents cboServiceCode As System.Windows.Forms.ComboBox
    Friend WithEvents lblServiceCode As System.Windows.Forms.Label
    Friend WithEvents nbxOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBalance As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbTotalVisits As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalVisits As System.Windows.Forms.Label
    Protected WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaff As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitServiceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents lblVisitServiceName As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents pnlVisitNo As System.Windows.Forms.Panel
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadSeeDrVisits As System.Windows.Forms.Button
    Friend WithEvents pnlNavigateVisits As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateVisits As System.Windows.Forms.CheckBox
    Friend WithEvents navVisits As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents cmsDoctor As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsDoctorCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsDoctorSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsDoctorQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tpgDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents dgvCancerDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents tbcDrCancerRoles As System.Windows.Forms.TabControl
    Friend WithEvents ColTopology As DataGridViewComboBoxColumn
    Friend WithEvents colDiseaseCode As DataGridViewComboBoxColumn
    Friend WithEvents colCancerDiagnosisCode As DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseCategory As DataGridViewTextBoxColumn
    Friend WithEvents ColBasisOfDiagnosis As DataGridViewComboBoxColumn
    Friend WithEvents ColCancerStage As DataGridViewComboBoxColumn
    Friend WithEvents colNotes As DataGridViewTextBoxColumn
    Friend WithEvents colDiagnosisSaved As DataGridViewCheckBoxColumn
End Class