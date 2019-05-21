<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmPharmacy : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal visitNo As String)
        MyClass.New()
        Me.defaultVisitNo = visitNo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPharmacy))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.stbStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cmsPrescription = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsPrescriptionCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsPrescriptionSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsPrescriptionInventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsPrescriptionEditPrescription = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsPrescriptionRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.dtpIssueDate = New System.Windows.Forms.DateTimePicker()
        Me.lblIssueDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.pnlUpdateVisitStatusTo = New System.Windows.Forms.Panel()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadToPharmacyVisits = New System.Windows.Forms.Button()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForPrescription = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForPrescription = New System.Windows.Forms.Label()
        Me.pnlDrugs = New System.Windows.Forms.Panel()
        Me.btnViewToExpireDrugsList = New System.Windows.Forms.Button()
        Me.lblToExpireDrugs = New System.Windows.Forms.Label()
        Me.btnViewToOrderDrugsList = New System.Windows.Forms.Button()
        Me.lblToOrderDrugs = New System.Windows.Forms.Label()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnPendingIventoryAcknowledgements = New System.Windows.Forms.Button()
        Me.lblPendingIventoryAcknowledgements = New System.Windows.Forms.Label()
        Me.btnViewList = New System.Windows.Forms.Button()
        Me.lblAlerts = New System.Windows.Forms.Label()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.stbRefillDuration = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefillDuration = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintPrescriptionOnSaving = New System.Windows.Forms.CheckBox()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.chkSmartCardApplicable = New System.Windows.Forms.CheckBox()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.cboPharmacist = New System.Windows.Forms.ComboBox()
        Me.lblPharmacist = New System.Windows.Forms.Label()
        Me.nbxWeight = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblWeight = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.btnGenerateInvoice = New System.Windows.Forms.Button()
        Me.pnlGenerateInvoice = New System.Windows.Forms.Panel()
        Me.chkGenerateInvoiceOnSaving = New System.Windows.Forms.CheckBox()
        Me.pnlPrintPrescription = New System.Windows.Forms.Panel()
        Me.chkPrintDrugLabel = New System.Windows.Forms.CheckBox()
        Me.tbcPharmacy = New System.Windows.Forms.TabControl()
        Me.tpgPrescription = New System.Windows.Forms.TabPage()
        Me.stbGrandAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dgvPrescription = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colDrugNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDosage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFormula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHasAlternateDrugs = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colAvailableStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblGrandTotalAmount = New System.Windows.Forms.Label()
        Me.stbGrandTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGrandAmountWords = New System.Windows.Forms.Label()
        Me.tpgConsumables = New System.Windows.Forms.TabPage()
        Me.stbConsumablesAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForConsumables = New System.Windows.Forms.Label()
        Me.lblConsumablesAmountWords = New System.Windows.Forms.Label()
        Me.stbBillForConsumables = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvDiagnosis = New System.Windows.Forms.DataGridView()
        Me.colDiseaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.btnAddConsumables = New System.Windows.Forms.Button()
        Me.pnlNavigateVisits = New System.Windows.Forms.Panel()
        Me.chkNavigateVisits = New System.Windows.Forms.CheckBox()
        Me.navVisits = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.stbPhoneNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stbAppointmentDetails = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.stbNextAppointmentDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnAddExtraCharge = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnOPDConsumables = New System.Windows.Forms.Button()
        Me.lblConsumableAlerts = New System.Windows.Forms.Label()
        Me.imgIDAutomation = New System.Windows.Forms.PictureBox()
        Me.chkPrintDrugBarcode = New System.Windows.Forms.CheckBox()
        Me.cmsPrescription.SuspendLayout()
        Me.pnlUpdateVisitStatusTo.SuspendLayout()
        Me.pnlBill.SuspendLayout()
        Me.pnlDrugs.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        Me.pnlGenerateInvoice.SuspendLayout()
        Me.pnlPrintPrescription.SuspendLayout()
        Me.tbcPharmacy.SuspendLayout()
        Me.tpgPrescription.SuspendLayout()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgConsumables.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgDiagnosis.SuspendLayout()
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigateVisits.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(915, 47)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(122, 20)
        Me.stbStatus.TabIndex = 41
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(833, 45)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(76, 20)
        Me.lblStatus.TabIndex = 40
        Me.lblStatus.Text = "Status"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(915, 26)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(122, 20)
        Me.stbAge.TabIndex = 39
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(915, 5)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.ReadOnly = True
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(122, 20)
        Me.stbJoinDate.TabIndex = 37
        '
        'cmsPrescription
        '
        Me.cmsPrescription.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsPrescription.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsPrescriptionCopy, Me.cmsPrescriptionSelectAll, Me.cmsPrescriptionInventory, Me.cmsPrescriptionEditPrescription, Me.ToolStripMenuItem1, Me.cmsPrescriptionRefresh})
        Me.cmsPrescription.Name = "cmsSearch"
        Me.cmsPrescription.Size = New System.Drawing.Size(161, 120)
        '
        'cmsPrescriptionCopy
        '
        Me.cmsPrescriptionCopy.Enabled = False
        Me.cmsPrescriptionCopy.Image = CType(resources.GetObject("cmsPrescriptionCopy.Image"), System.Drawing.Image)
        Me.cmsPrescriptionCopy.Name = "cmsPrescriptionCopy"
        Me.cmsPrescriptionCopy.Size = New System.Drawing.Size(160, 22)
        Me.cmsPrescriptionCopy.Text = "Copy"
        Me.cmsPrescriptionCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsPrescriptionSelectAll
        '
        Me.cmsPrescriptionSelectAll.Enabled = False
        Me.cmsPrescriptionSelectAll.Name = "cmsPrescriptionSelectAll"
        Me.cmsPrescriptionSelectAll.Size = New System.Drawing.Size(160, 22)
        Me.cmsPrescriptionSelectAll.Text = "Select All"
        '
        'cmsPrescriptionInventory
        '
        Me.cmsPrescriptionInventory.Enabled = False
        Me.cmsPrescriptionInventory.Image = CType(resources.GetObject("cmsPrescriptionInventory.Image"), System.Drawing.Image)
        Me.cmsPrescriptionInventory.Name = "cmsPrescriptionInventory"
        Me.cmsPrescriptionInventory.Size = New System.Drawing.Size(160, 22)
        Me.cmsPrescriptionInventory.Tag = "DrugInventory"
        Me.cmsPrescriptionInventory.Text = "Go to Inventory"
        '
        'cmsPrescriptionEditPrescription
        '
        Me.cmsPrescriptionEditPrescription.Enabled = False
        Me.cmsPrescriptionEditPrescription.Image = CType(resources.GetObject("cmsPrescriptionEditPrescription.Image"), System.Drawing.Image)
        Me.cmsPrescriptionEditPrescription.Name = "cmsPrescriptionEditPrescription"
        Me.cmsPrescriptionEditPrescription.Size = New System.Drawing.Size(160, 22)
        Me.cmsPrescriptionEditPrescription.Tag = "DoctorPrescription"
        Me.cmsPrescriptionEditPrescription.Text = "Edit Prescription"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(157, 6)
        '
        'cmsPrescriptionRefresh
        '
        Me.cmsPrescriptionRefresh.Enabled = False
        Me.cmsPrescriptionRefresh.Image = CType(resources.GetObject("cmsPrescriptionRefresh.Image"), System.Drawing.Image)
        Me.cmsPrescriptionRefresh.Name = "cmsPrescriptionRefresh"
        Me.cmsPrescriptionRefresh.Size = New System.Drawing.Size(160, 22)
        Me.cmsPrescriptionRefresh.Text = "Refresh"
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(915, 68)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(122, 20)
        Me.stbGender.TabIndex = 43
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(833, 5)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(76, 20)
        Me.lblJoinDate.TabIndex = 36
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(833, 24)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(76, 20)
        Me.lblAge.TabIndex = 38
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(833, 67)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(76, 20)
        Me.lblGenderID.TabIndex = 42
        Me.lblGenderID.Text = "Gender"
        '
        'dtpIssueDate
        '
        Me.dtpIssueDate.Location = New System.Drawing.Point(145, 40)
        Me.dtpIssueDate.Name = "dtpIssueDate"
        Me.dtpIssueDate.ShowCheckBox = True
        Me.dtpIssueDate.Size = New System.Drawing.Size(159, 20)
        Me.dtpIssueDate.TabIndex = 2
        '
        'lblIssueDate
        '
        Me.lblIssueDate.Location = New System.Drawing.Point(16, 39)
        Me.lblIssueDate.Name = "lblIssueDate"
        Me.lblIssueDate.Size = New System.Drawing.Size(124, 20)
        Me.lblIssueDate.TabIndex = 1
        Me.lblIssueDate.Text = "Issue Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(440, 50)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(133, 20)
        Me.stbFullName.TabIndex = 18
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(317, 50)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(117, 20)
        Me.lblFullName.TabIndex = 17
        Me.lblFullName.Text = "Full Name"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(22, 590)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(79, 24)
        Me.btnSave.TabIndex = 56
        Me.btnSave.Text = "&Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(961, 590)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(84, 24)
        Me.btnClose.TabIndex = 59
        Me.btnClose.Text = "&Close"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(915, 89)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(122, 20)
        Me.stbBillMode.TabIndex = 45
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(440, 92)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(133, 20)
        Me.stbVisitCategory.TabIndex = 22
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(833, 90)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(76, 20)
        Me.lblBillMode.TabIndex = 44
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(317, 92)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(117, 20)
        Me.lblVisitCategory.TabIndex = 21
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(146, 148)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(157, 20)
        Me.stbBillNo.TabIndex = 12
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(16, 150)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(124, 20)
        Me.lblBillNo.TabIndex = 11
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'pnlUpdateVisitStatusTo
        '
        Me.pnlUpdateVisitStatusTo.Controls.Add(Me.stbVisitNo)
        Me.pnlUpdateVisitStatusTo.Controls.Add(Me.btnLoadToPharmacyVisits)
        Me.pnlUpdateVisitStatusTo.Controls.Add(Me.btnFindVisitNo)
        Me.pnlUpdateVisitStatusTo.Controls.Add(Me.lblVisitNo)
        Me.pnlUpdateVisitStatusTo.Location = New System.Drawing.Point(6, 8)
        Me.pnlUpdateVisitStatusTo.Name = "pnlUpdateVisitStatusTo"
        Me.pnlUpdateVisitStatusTo.Size = New System.Drawing.Size(305, 29)
        Me.pnlUpdateVisitStatusTo.TabIndex = 0
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(140, 5)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(103, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'btnLoadToPharmacyVisits
        '
        Me.btnLoadToPharmacyVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadToPharmacyVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadToPharmacyVisits.Location = New System.Drawing.Point(249, 2)
        Me.btnLoadToPharmacyVisits.Name = "btnLoadToPharmacyVisits"
        Me.btnLoadToPharmacyVisits.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadToPharmacyVisits.TabIndex = 3
        Me.btnLoadToPharmacyVisits.Tag = ""
        Me.btnLoadToPharmacyVisits.Text = "&Load"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(107, 3)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(13, 3)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(82, 21)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No."
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(440, 8)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(133, 20)
        Me.stbVisitDate.TabIndex = 14
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(440, 29)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(133, 20)
        Me.stbPatientNo.TabIndex = 16
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(317, 29)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(117, 20)
        Me.lblPatientsNo.TabIndex = 15
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(317, 8)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(117, 20)
        Me.lblVisitDate.TabIndex = 13
        Me.lblVisitDate.Text = "Visit Date"
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForPrescription)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForPrescription)
        Me.pnlBill.Location = New System.Drawing.Point(10, 192)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(1035, 34)
        Me.pnlBill.TabIndex = 48
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(311, 6)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(114, 18)
        Me.lblBillWords.TabIndex = 1
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForPrescription
        '
        Me.stbBillForPrescription.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForPrescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForPrescription.CapitalizeFirstLetter = False
        Me.stbBillForPrescription.Enabled = False
        Me.stbBillForPrescription.EntryErrorMSG = ""
        Me.stbBillForPrescription.Location = New System.Drawing.Point(140, 4)
        Me.stbBillForPrescription.MaxLength = 20
        Me.stbBillForPrescription.Name = "stbBillForPrescription"
        Me.stbBillForPrescription.RegularExpression = ""
        Me.stbBillForPrescription.Size = New System.Drawing.Size(158, 20)
        Me.stbBillForPrescription.TabIndex = 0
        Me.stbBillForPrescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(434, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(541, 28)
        Me.stbBillWords.TabIndex = 2
        '
        'lblBillForPrescription
        '
        Me.lblBillForPrescription.Location = New System.Drawing.Point(13, 6)
        Me.lblBillForPrescription.Name = "lblBillForPrescription"
        Me.lblBillForPrescription.Size = New System.Drawing.Size(121, 18)
        Me.lblBillForPrescription.TabIndex = 0
        Me.lblBillForPrescription.Text = "Bill for Prescription"
        '
        'pnlDrugs
        '
        Me.pnlDrugs.Controls.Add(Me.btnViewToExpireDrugsList)
        Me.pnlDrugs.Controls.Add(Me.lblToExpireDrugs)
        Me.pnlDrugs.Controls.Add(Me.btnViewToOrderDrugsList)
        Me.pnlDrugs.Controls.Add(Me.lblToOrderDrugs)
        Me.pnlDrugs.Location = New System.Drawing.Point(383, 228)
        Me.pnlDrugs.Name = "pnlDrugs"
        Me.pnlDrugs.Size = New System.Drawing.Size(662, 29)
        Me.pnlDrugs.TabIndex = 4
        '
        'btnViewToExpireDrugsList
        '
        Me.btnViewToExpireDrugsList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToExpireDrugsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToExpireDrugsList.Location = New System.Drawing.Point(514, 2)
        Me.btnViewToExpireDrugsList.Name = "btnViewToExpireDrugsList"
        Me.btnViewToExpireDrugsList.Size = New System.Drawing.Size(84, 24)
        Me.btnViewToExpireDrugsList.TabIndex = 3
        Me.btnViewToExpireDrugsList.Tag = ""
        Me.btnViewToExpireDrugsList.Text = "&View List"
        '
        'lblToExpireDrugs
        '
        Me.lblToExpireDrugs.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToExpireDrugs.ForeColor = System.Drawing.Color.Red
        Me.lblToExpireDrugs.Location = New System.Drawing.Point(266, 6)
        Me.lblToExpireDrugs.Name = "lblToExpireDrugs"
        Me.lblToExpireDrugs.Size = New System.Drawing.Size(245, 20)
        Me.lblToExpireDrugs.TabIndex = 2
        Me.lblToExpireDrugs.Text = "To Expire/Expired Drugs: 0"
        '
        'btnViewToOrderDrugsList
        '
        Me.btnViewToOrderDrugsList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToOrderDrugsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToOrderDrugsList.Location = New System.Drawing.Point(191, 0)
        Me.btnViewToOrderDrugsList.Name = "btnViewToOrderDrugsList"
        Me.btnViewToOrderDrugsList.Size = New System.Drawing.Size(72, 24)
        Me.btnViewToOrderDrugsList.TabIndex = 1
        Me.btnViewToOrderDrugsList.Tag = ""
        Me.btnViewToOrderDrugsList.Text = "&View List"
        '
        'lblToOrderDrugs
        '
        Me.lblToOrderDrugs.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToOrderDrugs.ForeColor = System.Drawing.Color.Red
        Me.lblToOrderDrugs.Location = New System.Drawing.Point(4, 6)
        Me.lblToOrderDrugs.Name = "lblToOrderDrugs"
        Me.lblToOrderDrugs.Size = New System.Drawing.Size(176, 20)
        Me.lblToOrderDrugs.TabIndex = 0
        Me.lblToOrderDrugs.Text = "To Order Drugs: 0"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnPendingIventoryAcknowledgements)
        Me.pnlAlerts.Controls.Add(Me.lblPendingIventoryAcknowledgements)
        Me.pnlAlerts.Controls.Add(Me.btnViewList)
        Me.pnlAlerts.Controls.Add(Me.lblAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(13, 228)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(362, 58)
        Me.pnlAlerts.TabIndex = 3
        '
        'btnPendingIventoryAcknowledgements
        '
        Me.btnPendingIventoryAcknowledgements.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPendingIventoryAcknowledgements.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPendingIventoryAcknowledgements.Location = New System.Drawing.Point(280, 30)
        Me.btnPendingIventoryAcknowledgements.Name = "btnPendingIventoryAcknowledgements"
        Me.btnPendingIventoryAcknowledgements.Size = New System.Drawing.Size(72, 24)
        Me.btnPendingIventoryAcknowledgements.TabIndex = 3
        Me.btnPendingIventoryAcknowledgements.Tag = ""
        Me.btnPendingIventoryAcknowledgements.Text = "&View List"
        '
        'lblPendingIventoryAcknowledgements
        '
        Me.lblPendingIventoryAcknowledgements.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingIventoryAcknowledgements.ForeColor = System.Drawing.Color.Red
        Me.lblPendingIventoryAcknowledgements.Location = New System.Drawing.Point(10, 33)
        Me.lblPendingIventoryAcknowledgements.Name = "lblPendingIventoryAcknowledgements"
        Me.lblPendingIventoryAcknowledgements.Size = New System.Drawing.Size(270, 20)
        Me.lblPendingIventoryAcknowledgements.TabIndex = 2
        Me.lblPendingIventoryAcknowledgements.Text = "Pending Ack: 0"
        '
        'btnViewList
        '
        Me.btnViewList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewList.Location = New System.Drawing.Point(280, 4)
        Me.btnViewList.Name = "btnViewList"
        Me.btnViewList.Size = New System.Drawing.Size(72, 24)
        Me.btnViewList.TabIndex = 1
        Me.btnViewList.Tag = ""
        Me.btnViewList.Text = "&View List"
        '
        'lblAlerts
        '
        Me.lblAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblAlerts.Location = New System.Drawing.Point(10, 8)
        Me.lblAlerts.Name = "lblAlerts"
        Me.lblAlerts.Size = New System.Drawing.Size(270, 20)
        Me.lblAlerts.TabIndex = 0
        Me.lblAlerts.Text = "Doctor Prescription: 0"
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(912, 163)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(125, 23)
        Me.btnFindByFingerprint.TabIndex = 49
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'stbRefillDuration
        '
        Me.stbRefillDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefillDuration.CapitalizeFirstLetter = False
        Me.stbRefillDuration.Enabled = False
        Me.stbRefillDuration.EntryErrorMSG = ""
        Me.stbRefillDuration.Location = New System.Drawing.Point(440, 113)
        Me.stbRefillDuration.MaxLength = 60
        Me.stbRefillDuration.Name = "stbRefillDuration"
        Me.stbRefillDuration.RegularExpression = ""
        Me.stbRefillDuration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRefillDuration.Size = New System.Drawing.Size(133, 20)
        Me.stbRefillDuration.TabIndex = 24
        Me.stbRefillDuration.Visible = False
        '
        'lblRefillDuration
        '
        Me.lblRefillDuration.Location = New System.Drawing.Point(317, 112)
        Me.lblRefillDuration.Name = "lblRefillDuration"
        Me.lblRefillDuration.Size = New System.Drawing.Size(117, 20)
        Me.lblRefillDuration.TabIndex = 23
        Me.lblRefillDuration.Text = "Refill Duration (Days)"
        Me.lblRefillDuration.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(961, 565)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 24)
        Me.btnPrint.TabIndex = 58
        Me.btnPrint.Text = "&Print"
        '
        'chkPrintPrescriptionOnSaving
        '
        Me.chkPrintPrescriptionOnSaving.AccessibleDescription = ""
        Me.chkPrintPrescriptionOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintPrescriptionOnSaving.AutoSize = True
        Me.chkPrintPrescriptionOnSaving.Checked = True
        Me.chkPrintPrescriptionOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintPrescriptionOnSaving.Location = New System.Drawing.Point(3, 2)
        Me.chkPrintPrescriptionOnSaving.Name = "chkPrintPrescriptionOnSaving"
        Me.chkPrintPrescriptionOnSaving.Size = New System.Drawing.Size(161, 17)
        Me.chkPrintPrescriptionOnSaving.TabIndex = 0
        Me.chkPrintPrescriptionOnSaving.Text = " Print Prescription On Saving"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(701, 50)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.ReadOnly = True
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(126, 20)
        Me.stbPrimaryDoctor.TabIndex = 30
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(586, 51)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(109, 18)
        Me.lblPrimaryDoctor.TabIndex = 29
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Location = New System.Drawing.Point(569, 551)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(79, 24)
        Me.btnEdit.TabIndex = 53
        Me.btnEdit.Tag = "DoctorPrescription"
        Me.btnEdit.Text = "&Edit"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(440, 134)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(133, 20)
        Me.nbxCoPayValue.TabIndex = 26
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(317, 135)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(117, 20)
        Me.lblCoPayValue.TabIndex = 25
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(146, 127)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(158, 20)
        Me.nbxCoPayPercent.TabIndex = 10
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(16, 128)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(124, 20)
        Me.lblCoPayPercent.TabIndex = 9
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(146, 106)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(158, 20)
        Me.stbCoPayType.TabIndex = 8
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(16, 106)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(124, 20)
        Me.lblCoPayType.TabIndex = 7
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'chkSmartCardApplicable
        '
        Me.chkSmartCardApplicable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSmartCardApplicable.Enabled = False
        Me.chkSmartCardApplicable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSmartCardApplicable.Location = New System.Drawing.Point(890, 135)
        Me.chkSmartCardApplicable.Name = "chkSmartCardApplicable"
        Me.chkSmartCardApplicable.Size = New System.Drawing.Size(147, 20)
        Me.chkSmartCardApplicable.TabIndex = 35
        Me.chkSmartCardApplicable.Text = "Smart Card Applicable"
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(701, 29)
        Me.stbMemberCardNo.MaxLength = 20
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.ReadOnly = True
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(126, 20)
        Me.stbMemberCardNo.TabIndex = 28
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(586, 29)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(109, 18)
        Me.lblMemberCardNo.TabIndex = 27
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'cboPharmacist
        '
        Me.cboPharmacist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPharmacist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPharmacist.Location = New System.Drawing.Point(146, 61)
        Me.cboPharmacist.Name = "cboPharmacist"
        Me.cboPharmacist.Size = New System.Drawing.Size(158, 21)
        Me.cboPharmacist.TabIndex = 4
        '
        'lblPharmacist
        '
        Me.lblPharmacist.Location = New System.Drawing.Point(16, 60)
        Me.lblPharmacist.Name = "lblPharmacist"
        Me.lblPharmacist.Size = New System.Drawing.Size(124, 20)
        Me.lblPharmacist.TabIndex = 3
        Me.lblPharmacist.Text = "Pharmacist"
        '
        'nbxWeight
        '
        Me.nbxWeight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxWeight.ControlCaption = "Weight"
        Me.nbxWeight.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxWeight.DecimalPlaces = 2
        Me.nbxWeight.Enabled = False
        Me.nbxWeight.Location = New System.Drawing.Point(915, 110)
        Me.nbxWeight.MaxLength = 6
        Me.nbxWeight.MaxValue = 200.0R
        Me.nbxWeight.MinValue = 1.0R
        Me.nbxWeight.Name = "nbxWeight"
        Me.nbxWeight.Size = New System.Drawing.Size(122, 20)
        Me.nbxWeight.TabIndex = 47
        Me.nbxWeight.Value = ""
        '
        'lblWeight
        '
        Me.lblWeight.Location = New System.Drawing.Point(833, 111)
        Me.lblWeight.Name = "lblWeight"
        Me.lblWeight.Size = New System.Drawing.Size(76, 20)
        Me.lblWeight.TabIndex = 46
        Me.lblWeight.Text = "Weight (Kg)"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(701, 106)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(126, 37)
        Me.stbInsuranceName.TabIndex = 34
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(586, 109)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(109, 18)
        Me.lblBillInsuranceName.TabIndex = 33
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(701, 71)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(126, 33)
        Me.stbBillCustomerName.TabIndex = 32
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(586, 77)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(109, 18)
        Me.lblBillCustomerName.TabIndex = 31
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'btnGenerateInvoice
        '
        Me.btnGenerateInvoice.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnGenerateInvoice.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnGenerateInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenerateInvoice.Location = New System.Drawing.Point(653, 551)
        Me.btnGenerateInvoice.Name = "btnGenerateInvoice"
        Me.btnGenerateInvoice.Size = New System.Drawing.Size(117, 24)
        Me.btnGenerateInvoice.TabIndex = 55
        Me.btnGenerateInvoice.Tag = "Invoices"
        Me.btnGenerateInvoice.Text = "Generate Invoice"
        Me.btnGenerateInvoice.UseVisualStyleBackColor = True
        '
        'pnlGenerateInvoice
        '
        Me.pnlGenerateInvoice.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlGenerateInvoice.Controls.Add(Me.chkGenerateInvoiceOnSaving)
        Me.pnlGenerateInvoice.Location = New System.Drawing.Point(776, 545)
        Me.pnlGenerateInvoice.Name = "pnlGenerateInvoice"
        Me.pnlGenerateInvoice.Size = New System.Drawing.Size(176, 31)
        Me.pnlGenerateInvoice.TabIndex = 54
        '
        'chkGenerateInvoiceOnSaving
        '
        Me.chkGenerateInvoiceOnSaving.AccessibleDescription = ""
        Me.chkGenerateInvoiceOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkGenerateInvoiceOnSaving.AutoSize = True
        Me.chkGenerateInvoiceOnSaving.Checked = True
        Me.chkGenerateInvoiceOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkGenerateInvoiceOnSaving.Location = New System.Drawing.Point(3, 9)
        Me.chkGenerateInvoiceOnSaving.Name = "chkGenerateInvoiceOnSaving"
        Me.chkGenerateInvoiceOnSaving.Size = New System.Drawing.Size(161, 17)
        Me.chkGenerateInvoiceOnSaving.TabIndex = 0
        Me.chkGenerateInvoiceOnSaving.Text = "Generate Invoice On Saving"
        '
        'pnlPrintPrescription
        '
        Me.pnlPrintPrescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPrintPrescription.Controls.Add(Me.chkPrintDrugBarcode)
        Me.pnlPrintPrescription.Controls.Add(Me.chkPrintDrugLabel)
        Me.pnlPrintPrescription.Controls.Add(Me.chkPrintPrescriptionOnSaving)
        Me.pnlPrintPrescription.Location = New System.Drawing.Point(22, 544)
        Me.pnlPrintPrescription.Name = "pnlPrintPrescription"
        Me.pnlPrintPrescription.Size = New System.Drawing.Size(300, 40)
        Me.pnlPrintPrescription.TabIndex = 51
        '
        'chkPrintDrugLabel
        '
        Me.chkPrintDrugLabel.AccessibleDescription = ""
        Me.chkPrintDrugLabel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintDrugLabel.AutoSize = True
        Me.chkPrintDrugLabel.Location = New System.Drawing.Point(3, 18)
        Me.chkPrintDrugLabel.Name = "chkPrintDrugLabel"
        Me.chkPrintDrugLabel.Size = New System.Drawing.Size(158, 17)
        Me.chkPrintDrugLabel.TabIndex = 1
        Me.chkPrintDrugLabel.Text = " Print Drug Label On Saving"
        '
        'tbcPharmacy
        '
        Me.tbcPharmacy.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcPharmacy.Controls.Add(Me.tpgPrescription)
        Me.tbcPharmacy.Controls.Add(Me.tpgConsumables)
        Me.tbcPharmacy.Controls.Add(Me.tpgDiagnosis)
        Me.tbcPharmacy.HotTrack = True
        Me.tbcPharmacy.Location = New System.Drawing.Point(6, 290)
        Me.tbcPharmacy.Name = "tbcPharmacy"
        Me.tbcPharmacy.SelectedIndex = 0
        Me.tbcPharmacy.Size = New System.Drawing.Size(1039, 252)
        Me.tbcPharmacy.TabIndex = 50
        '
        'tpgPrescription
        '
        Me.tpgPrescription.Controls.Add(Me.stbGrandAmountWords)
        Me.tpgPrescription.Controls.Add(Me.dgvPrescription)
        Me.tpgPrescription.Controls.Add(Me.lblGrandTotalAmount)
        Me.tpgPrescription.Controls.Add(Me.stbGrandTotalAmount)
        Me.tpgPrescription.Controls.Add(Me.lblGrandAmountWords)
        Me.tpgPrescription.Location = New System.Drawing.Point(4, 22)
        Me.tpgPrescription.Name = "tpgPrescription"
        Me.tpgPrescription.Size = New System.Drawing.Size(1031, 226)
        Me.tpgPrescription.TabIndex = 1
        Me.tpgPrescription.Tag = ""
        Me.tpgPrescription.Text = "Prescription"
        Me.tpgPrescription.UseVisualStyleBackColor = True
        '
        'stbGrandAmountWords
        '
        Me.stbGrandAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stbGrandAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbGrandAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGrandAmountWords.CapitalizeFirstLetter = False
        Me.stbGrandAmountWords.EntryErrorMSG = ""
        Me.stbGrandAmountWords.Location = New System.Drawing.Point(554, 197)
        Me.stbGrandAmountWords.MaxLength = 100
        Me.stbGrandAmountWords.Multiline = True
        Me.stbGrandAmountWords.Name = "stbGrandAmountWords"
        Me.stbGrandAmountWords.ReadOnly = True
        Me.stbGrandAmountWords.RegularExpression = ""
        Me.stbGrandAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGrandAmountWords.Size = New System.Drawing.Size(464, 25)
        Me.stbGrandAmountWords.TabIndex = 4
        '
        'dgvPrescription
        '
        Me.dgvPrescription.AllowUserToAddRows = False
        Me.dgvPrescription.AllowUserToDeleteRows = False
        Me.dgvPrescription.AllowUserToOrderColumns = True
        Me.dgvPrescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPrescription.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvPrescription.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPrescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPrescription.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colDrugNo, Me.colDrQuantity, Me.colDrugName, Me.colDosage, Me.colDuration, Me.colQuantity, Me.colBalance, Me.colFormula, Me.colUnitMeasure, Me.colUnitPrice, Me.colAmount, Me.colPayStatus, Me.colDrugLocationBalance, Me.colUnitsInStock, Me.colExpiryDate, Me.colOrderLevel, Me.colHasAlternateDrugs, Me.colAvailableStock, Me.colCashAmount, Me.colCashPayStatus})
        Me.dgvPrescription.ContextMenuStrip = Me.cmsPrescription
        Me.dgvPrescription.EnableHeadersVisualStyles = False
        Me.dgvPrescription.GridColor = System.Drawing.Color.Khaki
        Me.dgvPrescription.Location = New System.Drawing.Point(3, 3)
        Me.dgvPrescription.Name = "dgvPrescription"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.RowHeadersDefaultCellStyle = DataGridViewCellStyle21
        Me.dgvPrescription.RowHeadersVisible = False
        Me.dgvPrescription.Size = New System.Drawing.Size(1025, 195)
        Me.dgvPrescription.TabIndex = 0
        Me.dgvPrescription.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FillWeight = 114.5833!
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 48
        '
        'colDrugNo
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDrugNo.FillWeight = 143.2097!
        Me.colDrugNo.HeaderText = "Drug No"
        Me.colDrugNo.Name = "colDrugNo"
        Me.colDrugNo.ReadOnly = True
        Me.colDrugNo.Width = 72
        '
        'colDrQuantity
        '
        Me.colDrQuantity.DataPropertyName = "DoctorQuantity"
        Me.colDrQuantity.HeaderText = "DrQty"
        Me.colDrQuantity.Name = "colDrQuantity"
        Me.colDrQuantity.Visible = False
        Me.colDrQuantity.Width = 59
        '
        'colDrugName
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDrugName.FillWeight = 312.7449!
        Me.colDrugName.HeaderText = "Drug Name"
        Me.colDrugName.Name = "colDrugName"
        Me.colDrugName.ReadOnly = True
        Me.colDrugName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDrugName.Width = 86
        '
        'colDosage
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colDosage.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDosage.FillWeight = 107.4064!
        Me.colDosage.HeaderText = "Dosage"
        Me.colDosage.MaxInputLength = 100
        Me.colDosage.Name = "colDosage"
        Me.colDosage.ReadOnly = True
        Me.colDosage.Width = 69
        '
        'colDuration
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colDuration.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDuration.FillWeight = 85.45711!
        Me.colDuration.HeaderText = "Duration"
        Me.colDuration.Name = "colDuration"
        Me.colDuration.ReadOnly = True
        Me.colDuration.Width = 72
        '
        'colQuantity
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.colQuantity.FillWeight = 99.06245!
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 71
        '
        'colBalance
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colBalance.DefaultCellStyle = DataGridViewCellStyle7
        Me.colBalance.FillWeight = 95.65357!
        Me.colBalance.HeaderText = "Balance"
        Me.colBalance.Name = "colBalance"
        Me.colBalance.ReadOnly = True
        Me.colBalance.Width = 71
        '
        'colFormula
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colFormula.DefaultCellStyle = DataGridViewCellStyle8
        Me.colFormula.FillWeight = 115.5722!
        Me.colFormula.HeaderText = "Notes"
        Me.colFormula.MaxInputLength = 100
        Me.colFormula.Name = "colFormula"
        Me.colFormula.ReadOnly = True
        Me.colFormula.Width = 60
        '
        'colUnitMeasure
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitMeasure.DefaultCellStyle = DataGridViewCellStyle9
        Me.colUnitMeasure.FillWeight = 124.6907!
        Me.colUnitMeasure.HeaderText = "Unit Measure"
        Me.colUnitMeasure.Name = "colUnitMeasure"
        Me.colUnitMeasure.ReadOnly = True
        Me.colUnitMeasure.Width = 95
        '
        'colUnitPrice
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle10
        Me.colUnitPrice.FillWeight = 82.07883!
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 78
        '
        'colAmount
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle11
        Me.colAmount.FillWeight = 79.73141!
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 68
        '
        'colPayStatus
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colPayStatus.DefaultCellStyle = DataGridViewCellStyle12
        Me.colPayStatus.FillWeight = 89.37043!
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 83
        '
        'colDrugLocationBalance
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugLocationBalance.DefaultCellStyle = DataGridViewCellStyle13
        Me.colDrugLocationBalance.FillWeight = 121.4543!
        Me.colDrugLocationBalance.HeaderText = "Location Balance"
        Me.colDrugLocationBalance.Name = "colDrugLocationBalance"
        Me.colDrugLocationBalance.ReadOnly = True
        Me.colDrugLocationBalance.Width = 115
        '
        'colUnitsInStock
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitsInStock.DefaultCellStyle = DataGridViewCellStyle14
        Me.colUnitsInStock.FillWeight = 89.51558!
        Me.colUnitsInStock.HeaderText = "Units In Stock"
        Me.colUnitsInStock.Name = "colUnitsInStock"
        Me.colUnitsInStock.ReadOnly = True
        Me.colUnitsInStock.Width = 99
        '
        'colExpiryDate
        '
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colExpiryDate.DefaultCellStyle = DataGridViewCellStyle15
        Me.colExpiryDate.FillWeight = 116.2278!
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        Me.colExpiryDate.Width = 86
        '
        'colOrderLevel
        '
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colOrderLevel.DefaultCellStyle = DataGridViewCellStyle16
        Me.colOrderLevel.FillWeight = 67.65237!
        Me.colOrderLevel.HeaderText = "Order Level"
        Me.colOrderLevel.Name = "colOrderLevel"
        Me.colOrderLevel.ReadOnly = True
        Me.colOrderLevel.Width = 87
        '
        'colHasAlternateDrugs
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle17.NullValue = False
        Me.colHasAlternateDrugs.DefaultCellStyle = DataGridViewCellStyle17
        Me.colHasAlternateDrugs.FillWeight = 101.9599!
        Me.colHasAlternateDrugs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colHasAlternateDrugs.HeaderText = "Has Alternate Drugs"
        Me.colHasAlternateDrugs.Name = "colHasAlternateDrugs"
        Me.colHasAlternateDrugs.ReadOnly = True
        Me.colHasAlternateDrugs.Width = 108
        '
        'colAvailableStock
        '
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        Me.colAvailableStock.DefaultCellStyle = DataGridViewCellStyle18
        Me.colAvailableStock.FillWeight = 76.64548!
        Me.colAvailableStock.HeaderText = "Available Stock"
        Me.colAvailableStock.Name = "colAvailableStock"
        Me.colAvailableStock.ReadOnly = True
        Me.colAvailableStock.Width = 106
        '
        'colCashAmount
        '
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle19.Format = "N2"
        DataGridViewCellStyle19.NullValue = Nothing
        Me.colCashAmount.DefaultCellStyle = DataGridViewCellStyle19
        Me.colCashAmount.FillWeight = 96.32335!
        Me.colCashAmount.HeaderText = "Cash Co-Pay Amount"
        Me.colCashAmount.Name = "colCashAmount"
        Me.colCashAmount.ReadOnly = True
        Me.colCashAmount.Width = 132
        '
        'colCashPayStatus
        '
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.colCashPayStatus.DefaultCellStyle = DataGridViewCellStyle20
        Me.colCashPayStatus.FillWeight = 80.66019!
        Me.colCashPayStatus.HeaderText = "Cash Co-Pay Status"
        Me.colCashPayStatus.Name = "colCashPayStatus"
        Me.colCashPayStatus.ReadOnly = True
        Me.colCashPayStatus.Width = 126
        '
        'lblGrandTotalAmount
        '
        Me.lblGrandTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGrandTotalAmount.Location = New System.Drawing.Point(8, 201)
        Me.lblGrandTotalAmount.Name = "lblGrandTotalAmount"
        Me.lblGrandTotalAmount.Size = New System.Drawing.Size(121, 20)
        Me.lblGrandTotalAmount.TabIndex = 1
        Me.lblGrandTotalAmount.Text = "Grand Total"
        '
        'stbGrandTotalAmount
        '
        Me.stbGrandTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbGrandTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbGrandTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGrandTotalAmount.CapitalizeFirstLetter = False
        Me.stbGrandTotalAmount.Enabled = False
        Me.stbGrandTotalAmount.EntryErrorMSG = ""
        Me.stbGrandTotalAmount.Location = New System.Drawing.Point(132, 201)
        Me.stbGrandTotalAmount.MaxLength = 20
        Me.stbGrandTotalAmount.Name = "stbGrandTotalAmount"
        Me.stbGrandTotalAmount.RegularExpression = ""
        Me.stbGrandTotalAmount.Size = New System.Drawing.Size(158, 20)
        Me.stbGrandTotalAmount.TabIndex = 2
        Me.stbGrandTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGrandAmountWords
        '
        Me.lblGrandAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblGrandAmountWords.Location = New System.Drawing.Point(353, 203)
        Me.lblGrandAmountWords.Name = "lblGrandAmountWords"
        Me.lblGrandAmountWords.Size = New System.Drawing.Size(184, 21)
        Me.lblGrandAmountWords.TabIndex = 3
        Me.lblGrandAmountWords.Text = "Grand Total in Words"
        '
        'tpgConsumables
        '
        Me.tpgConsumables.Controls.Add(Me.stbConsumablesAmountWords)
        Me.tpgConsumables.Controls.Add(Me.lblBillForConsumables)
        Me.tpgConsumables.Controls.Add(Me.lblConsumablesAmountWords)
        Me.tpgConsumables.Controls.Add(Me.stbBillForConsumables)
        Me.tpgConsumables.Controls.Add(Me.dgvConsumables)
        Me.tpgConsumables.Location = New System.Drawing.Point(4, 22)
        Me.tpgConsumables.Name = "tpgConsumables"
        Me.tpgConsumables.Size = New System.Drawing.Size(1031, 226)
        Me.tpgConsumables.TabIndex = 3
        Me.tpgConsumables.Text = "Consumables"
        Me.tpgConsumables.UseVisualStyleBackColor = True
        '
        'stbConsumablesAmountWords
        '
        Me.stbConsumablesAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbConsumablesAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbConsumablesAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbConsumablesAmountWords.CapitalizeFirstLetter = False
        Me.stbConsumablesAmountWords.EntryErrorMSG = ""
        Me.stbConsumablesAmountWords.Location = New System.Drawing.Point(499, 180)
        Me.stbConsumablesAmountWords.MaxLength = 100
        Me.stbConsumablesAmountWords.Multiline = True
        Me.stbConsumablesAmountWords.Name = "stbConsumablesAmountWords"
        Me.stbConsumablesAmountWords.ReadOnly = True
        Me.stbConsumablesAmountWords.RegularExpression = ""
        Me.stbConsumablesAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbConsumablesAmountWords.Size = New System.Drawing.Size(464, 34)
        Me.stbConsumablesAmountWords.TabIndex = 4
        '
        'lblBillForConsumables
        '
        Me.lblBillForConsumables.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBillForConsumables.Location = New System.Drawing.Point(9, 190)
        Me.lblBillForConsumables.Name = "lblBillForConsumables"
        Me.lblBillForConsumables.Size = New System.Drawing.Size(121, 20)
        Me.lblBillForConsumables.TabIndex = 1
        Me.lblBillForConsumables.Text = "Bill for Consumables"
        '
        'lblConsumablesAmountWords
        '
        Me.lblConsumablesAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblConsumablesAmountWords.Location = New System.Drawing.Point(310, 190)
        Me.lblConsumablesAmountWords.Name = "lblConsumablesAmountWords"
        Me.lblConsumablesAmountWords.Size = New System.Drawing.Size(184, 21)
        Me.lblConsumablesAmountWords.TabIndex = 3
        Me.lblConsumablesAmountWords.Text = "Consumables Amount in Words"
        '
        'stbBillForConsumables
        '
        Me.stbBillForConsumables.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbBillForConsumables.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForConsumables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForConsumables.CapitalizeFirstLetter = False
        Me.stbBillForConsumables.Enabled = False
        Me.stbBillForConsumables.EntryErrorMSG = ""
        Me.stbBillForConsumables.Location = New System.Drawing.Point(136, 190)
        Me.stbBillForConsumables.MaxLength = 20
        Me.stbBillForConsumables.Name = "stbBillForConsumables"
        Me.stbBillForConsumables.RegularExpression = ""
        Me.stbBillForConsumables.Size = New System.Drawing.Size(158, 20)
        Me.stbBillForConsumables.TabIndex = 2
        Me.stbBillForConsumables.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToAddRows = False
        Me.dgvConsumables.AllowUserToDeleteRows = False
        Me.dgvConsumables.AllowUserToOrderColumns = True
        Me.dgvConsumables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumableName, Me.colConsumableNotes, Me.colConsumableQuantity, Me.colConsumableUnitPrice, Me.colConsumableAmount, Me.colConsumableItemStatus})
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(3, 3)
        Me.dgvConsumables.Name = "dgvConsumables"
        Me.dgvConsumables.ReadOnly = True
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.dgvConsumables.Size = New System.Drawing.Size(1025, 171)
        Me.dgvConsumables.TabIndex = 0
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'colConsumableName
        '
        Me.colConsumableName.DataPropertyName = "ItemName"
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableName.DefaultCellStyle = DataGridViewCellStyle23
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.ReadOnly = True
        Me.colConsumableName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colConsumableName.Width = 250
        '
        'colConsumableNotes
        '
        Me.colConsumableNotes.DataPropertyName = "ItemDetails"
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableNotes.DefaultCellStyle = DataGridViewCellStyle24
        Me.colConsumableNotes.HeaderText = "Notes"
        Me.colConsumableNotes.MaxInputLength = 40
        Me.colConsumableNotes.Name = "colConsumableNotes"
        Me.colConsumableNotes.ReadOnly = True
        '
        'colConsumableQuantity
        '
        Me.colConsumableQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle25.Format = "N0"
        DataGridViewCellStyle25.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle25.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle25
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.ReadOnly = True
        Me.colConsumableQuantity.Width = 60
        '
        'colConsumableUnitPrice
        '
        Me.colConsumableUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle26.Format = "N2"
        DataGridViewCellStyle26.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle26.NullValue = Nothing
        Me.colConsumableUnitPrice.DefaultCellStyle = DataGridViewCellStyle26
        Me.colConsumableUnitPrice.HeaderText = "Unit Price"
        Me.colConsumableUnitPrice.MaxInputLength = 12
        Me.colConsumableUnitPrice.Name = "colConsumableUnitPrice"
        Me.colConsumableUnitPrice.ReadOnly = True
        Me.colConsumableUnitPrice.Width = 80
        '
        'colConsumableAmount
        '
        Me.colConsumableAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle27.Format = "N2"
        DataGridViewCellStyle27.NullValue = Nothing
        Me.colConsumableAmount.DefaultCellStyle = DataGridViewCellStyle27
        Me.colConsumableAmount.HeaderText = "Amount"
        Me.colConsumableAmount.MaxInputLength = 12
        Me.colConsumableAmount.Name = "colConsumableAmount"
        Me.colConsumableAmount.ReadOnly = True
        Me.colConsumableAmount.Width = 80
        '
        'colConsumableItemStatus
        '
        Me.colConsumableItemStatus.DataPropertyName = "ItemStatus"
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableItemStatus.DefaultCellStyle = DataGridViewCellStyle28
        Me.colConsumableItemStatus.HeaderText = "Item Status"
        Me.colConsumableItemStatus.Name = "colConsumableItemStatus"
        Me.colConsumableItemStatus.ReadOnly = True
        Me.colConsumableItemStatus.Width = 80
        '
        'tpgDiagnosis
        '
        Me.tpgDiagnosis.Controls.Add(Me.dgvDiagnosis)
        Me.tpgDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgDiagnosis.Name = "tpgDiagnosis"
        Me.tpgDiagnosis.Size = New System.Drawing.Size(1031, 226)
        Me.tpgDiagnosis.TabIndex = 2
        Me.tpgDiagnosis.Tag = ""
        Me.tpgDiagnosis.Text = "Diagnosis"
        Me.tpgDiagnosis.UseVisualStyleBackColor = True
        '
        'dgvDiagnosis
        '
        Me.dgvDiagnosis.AllowUserToAddRows = False
        Me.dgvDiagnosis.AllowUserToDeleteRows = False
        Me.dgvDiagnosis.AllowUserToOrderColumns = True
        Me.dgvDiagnosis.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle30
        Me.dgvDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDiseaseName, Me.colDiseaseCategory})
        Me.dgvDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiagnosis.EnableHeadersVisualStyles = False
        Me.dgvDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvDiagnosis.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiagnosis.Name = "dgvDiagnosis"
        Me.dgvDiagnosis.ReadOnly = True
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle33
        Me.dgvDiagnosis.Size = New System.Drawing.Size(1031, 226)
        Me.dgvDiagnosis.TabIndex = 0
        Me.dgvDiagnosis.Text = "DataGridView1"
        '
        'colDiseaseName
        '
        Me.colDiseaseName.DataPropertyName = "DiseaseName"
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseName.DefaultCellStyle = DataGridViewCellStyle31
        Me.colDiseaseName.HeaderText = "Diagnosis"
        Me.colDiseaseName.Name = "colDiseaseName"
        Me.colDiseaseName.ReadOnly = True
        Me.colDiseaseName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDiseaseName.Width = 400
        '
        'colDiseaseCategory
        '
        Me.colDiseaseCategory.DataPropertyName = "DiseaseCategories"
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseCategory.DefaultCellStyle = DataGridViewCellStyle32
        Me.colDiseaseCategory.HeaderText = "Category"
        Me.colDiseaseCategory.Name = "colDiseaseCategory"
        Me.colDiseaseCategory.ReadOnly = True
        Me.colDiseaseCategory.Width = 150
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(146, 83)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(158, 21)
        Me.cboLocationID.TabIndex = 6
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(16, 84)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(124, 20)
        Me.lblLocationID.TabIndex = 5
        Me.lblLocationID.Text = "Location"
        '
        'btnAddConsumables
        '
        Me.btnAddConsumables.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAddConsumables.Enabled = False
        Me.btnAddConsumables.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnAddConsumables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddConsumables.Location = New System.Drawing.Point(447, 552)
        Me.btnAddConsumables.Name = "btnAddConsumables"
        Me.btnAddConsumables.Size = New System.Drawing.Size(118, 23)
        Me.btnAddConsumables.TabIndex = 52
        Me.btnAddConsumables.Tag = "Consumables"
        Me.btnAddConsumables.Text = "Add &Consumables"
        Me.btnAddConsumables.UseVisualStyleBackColor = True
        '
        'pnlNavigateVisits
        '
        Me.pnlNavigateVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateVisits.Controls.Add(Me.chkNavigateVisits)
        Me.pnlNavigateVisits.Controls.Add(Me.navVisits)
        Me.pnlNavigateVisits.Location = New System.Drawing.Point(340, 581)
        Me.pnlNavigateVisits.Name = "pnlNavigateVisits"
        Me.pnlNavigateVisits.Size = New System.Drawing.Size(614, 33)
        Me.pnlNavigateVisits.TabIndex = 57
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
        Me.navVisits.Location = New System.Drawing.Point(178, 2)
        Me.navVisits.Name = "navVisits"
        Me.navVisits.NavAllEnabled = False
        Me.navVisits.NavLeftEnabled = False
        Me.navVisits.NavRightEnabled = False
        Me.navVisits.Size = New System.Drawing.Size(413, 32)
        Me.navVisits.TabIndex = 1
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(317, 73)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(104, 20)
        Me.lblPhone.TabIndex = 19
        Me.lblPhone.Text = "Phone"
        '
        'stbPhoneNo
        '
        Me.stbPhoneNo.BackColor = System.Drawing.SystemColors.Control
        Me.stbPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhoneNo.CapitalizeFirstLetter = True
        Me.stbPhoneNo.EntryErrorMSG = ""
        Me.stbPhoneNo.Location = New System.Drawing.Point(440, 71)
        Me.stbPhoneNo.MaxLength = 100
        Me.stbPhoneNo.Multiline = True
        Me.stbPhoneNo.Name = "stbPhoneNo"
        Me.stbPhoneNo.ReadOnly = True
        Me.stbPhoneNo.RegularExpression = ""
        Me.stbPhoneNo.Size = New System.Drawing.Size(133, 20)
        Me.stbPhoneNo.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label1.Location = New System.Drawing.Point(317, 158)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 20)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Next Appointment"
        '
        'stbAppointmentDetails
        '
        Me.stbAppointmentDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAppointmentDetails.CapitalizeFirstLetter = False
        Me.stbAppointmentDetails.EntryErrorMSG = ""
        Me.stbAppointmentDetails.Location = New System.Drawing.Point(701, 8)
        Me.stbAppointmentDetails.MaxLength = 60
        Me.stbAppointmentDetails.Name = "stbAppointmentDetails"
        Me.stbAppointmentDetails.ReadOnly = True
        Me.stbAppointmentDetails.RegularExpression = ""
        Me.stbAppointmentDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAppointmentDetails.Size = New System.Drawing.Size(126, 20)
        Me.stbAppointmentDetails.TabIndex = 63
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(586, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 20)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "App Details"
        '
        'stbNextAppointmentDate
        '
        Me.stbNextAppointmentDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNextAppointmentDate.CapitalizeFirstLetter = False
        Me.stbNextAppointmentDate.EntryErrorMSG = ""
        Me.stbNextAppointmentDate.Location = New System.Drawing.Point(440, 156)
        Me.stbNextAppointmentDate.MaxLength = 60
        Me.stbNextAppointmentDate.Name = "stbNextAppointmentDate"
        Me.stbNextAppointmentDate.ReadOnly = True
        Me.stbNextAppointmentDate.RegularExpression = ""
        Me.stbNextAppointmentDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbNextAppointmentDate.Size = New System.Drawing.Size(133, 20)
        Me.stbNextAppointmentDate.TabIndex = 64
        '
        'btnAddExtraCharge
        '
        Me.btnAddExtraCharge.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAddExtraCharge.Enabled = False
        Me.btnAddExtraCharge.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnAddExtraCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddExtraCharge.Location = New System.Drawing.Point(340, 552)
        Me.btnAddExtraCharge.Name = "btnAddExtraCharge"
        Me.btnAddExtraCharge.Size = New System.Drawing.Size(104, 23)
        Me.btnAddExtraCharge.TabIndex = 65
        Me.btnAddExtraCharge.Tag = "ExtraCharge"
        Me.btnAddExtraCharge.Text = "Add &Extra Charge"
        Me.btnAddExtraCharge.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnOPDConsumables)
        Me.Panel1.Controls.Add(Me.lblConsumableAlerts)
        Me.Panel1.Location = New System.Drawing.Point(383, 259)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(324, 32)
        Me.Panel1.TabIndex = 66
        '
        'btnOPDConsumables
        '
        Me.btnOPDConsumables.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnOPDConsumables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOPDConsumables.Location = New System.Drawing.Point(191, 5)
        Me.btnOPDConsumables.Name = "btnOPDConsumables"
        Me.btnOPDConsumables.Size = New System.Drawing.Size(72, 24)
        Me.btnOPDConsumables.TabIndex = 1
        Me.btnOPDConsumables.Tag = ""
        Me.btnOPDConsumables.Text = "&View List"
        '
        'lblConsumableAlerts
        '
        Me.lblConsumableAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsumableAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblConsumableAlerts.Location = New System.Drawing.Point(5, 8)
        Me.lblConsumableAlerts.Name = "lblConsumableAlerts"
        Me.lblConsumableAlerts.Size = New System.Drawing.Size(185, 20)
        Me.lblConsumableAlerts.TabIndex = 0
        Me.lblConsumableAlerts.Text = "Sent Consumables: 0"
        '
        'imgIDAutomation
        '
        Me.imgIDAutomation.Location = New System.Drawing.Point(627, 146)
        Me.imgIDAutomation.Name = "imgIDAutomation"
        Me.imgIDAutomation.Size = New System.Drawing.Size(200, 40)
        Me.imgIDAutomation.TabIndex = 67
        Me.imgIDAutomation.TabStop = False
        '
        'chkPrintDrugBarcode
        '
        Me.chkPrintDrugBarcode.AccessibleDescription = ""
        Me.chkPrintDrugBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintDrugBarcode.AutoSize = True
        Me.chkPrintDrugBarcode.Location = New System.Drawing.Point(176, 6)
        Me.chkPrintDrugBarcode.Name = "chkPrintDrugBarcode"
        Me.chkPrintDrugBarcode.Size = New System.Drawing.Size(119, 17)
        Me.chkPrintDrugBarcode.TabIndex = 2
        Me.chkPrintDrugBarcode.Text = " Print Drug Barcode"
        '
        'frmPharmacy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1049, 625)
        Me.Controls.Add(Me.imgIDAutomation)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnAddExtraCharge)
        Me.Controls.Add(Me.stbNextAppointmentDate)
        Me.Controls.Add(Me.stbAppointmentDetails)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlDrugs)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.stbPhoneNo)
        Me.Controls.Add(Me.pnlNavigateVisits)
        Me.Controls.Add(Me.btnFindByFingerprint)
        Me.Controls.Add(Me.btnAddConsumables)
        Me.Controls.Add(Me.cboLocationID)
        Me.Controls.Add(Me.lblLocationID)
        Me.Controls.Add(Me.tbcPharmacy)
        Me.Controls.Add(Me.pnlGenerateInvoice)
        Me.Controls.Add(Me.pnlPrintPrescription)
        Me.Controls.Add(Me.btnGenerateInvoice)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.cboPharmacist)
        Me.Controls.Add(Me.lblPharmacist)
        Me.Controls.Add(Me.lblWeight)
        Me.Controls.Add(Me.nbxWeight)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.chkSmartCardApplicable)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.stbRefillDuration)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblRefillDuration)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.pnlUpdateVisitStatusTo)
        Me.Controls.Add(Me.stbVisitCategory)
        Me.Controls.Add(Me.lblVisitCategory)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.dtpIssueDate)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.stbStatus)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.lblIssueDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPharmacy"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pharmacy"
        Me.cmsPrescription.ResumeLayout(False)
        Me.pnlUpdateVisitStatusTo.ResumeLayout(False)
        Me.pnlUpdateVisitStatusTo.PerformLayout()
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.pnlDrugs.ResumeLayout(False)
        Me.pnlAlerts.ResumeLayout(False)
        Me.pnlGenerateInvoice.ResumeLayout(False)
        Me.pnlGenerateInvoice.PerformLayout()
        Me.pnlPrintPrescription.ResumeLayout(False)
        Me.pnlPrintPrescription.PerformLayout()
        Me.tbcPharmacy.ResumeLayout(False)
        Me.tpgPrescription.ResumeLayout(False)
        Me.tpgPrescription.PerformLayout()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgConsumables.ResumeLayout(False)
        Me.tpgConsumables.PerformLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgDiagnosis.ResumeLayout(False)
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigateVisits.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents dtpIssueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblIssueDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitCategory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents lblVisitCategory As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents pnlUpdateVisitStatusTo As System.Windows.Forms.Panel
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForPrescription As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForPrescription As System.Windows.Forms.Label
    Friend WithEvents stbRefillDuration As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefillDuration As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintPrescriptionOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnViewList As System.Windows.Forms.Button
    Friend WithEvents lblAlerts As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents btnLoadToPharmacyVisits As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents pnlDrugs As System.Windows.Forms.Panel
    Friend WithEvents btnViewToOrderDrugsList As System.Windows.Forms.Button
    Friend WithEvents lblToOrderDrugs As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents chkSmartCardApplicable As System.Windows.Forms.CheckBox
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents cboPharmacist As System.Windows.Forms.ComboBox
    Friend WithEvents lblPharmacist As System.Windows.Forms.Label
    Friend WithEvents btnViewToExpireDrugsList As System.Windows.Forms.Button
    Friend WithEvents lblToExpireDrugs As System.Windows.Forms.Label
    Friend WithEvents cmsPrescription As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsPrescriptionCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsPrescriptionSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsPrescriptionInventory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents nbxWeight As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblWeight As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents btnGenerateInvoice As System.Windows.Forms.Button
    Friend WithEvents pnlGenerateInvoice As System.Windows.Forms.Panel
    Friend WithEvents chkGenerateInvoiceOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents cmsPrescriptionEditPrescription As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pnlPrintPrescription As System.Windows.Forms.Panel
    Friend WithEvents tbcPharmacy As System.Windows.Forms.TabControl
    Friend WithEvents tpgPrescription As System.Windows.Forms.TabPage
    Friend WithEvents tpgDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents dgvDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents colDiseaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents btnAddConsumables As System.Windows.Forms.Button
    Friend WithEvents pnlNavigateVisits As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateVisits As System.Windows.Forms.CheckBox
    Friend WithEvents navVisits As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents tpgConsumables As System.Windows.Forms.TabPage
    Friend WithEvents dgvConsumables As System.Windows.Forms.DataGridView
    Friend WithEvents stbConsumablesAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForConsumables As System.Windows.Forms.Label
    Friend WithEvents lblConsumablesAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForConsumables As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsPrescriptionRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stbGrandAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGrandTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblGrandAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbGrandTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dgvPrescription As System.Windows.Forms.DataGridView
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colDrugNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDosage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFormula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHasAlternateDrugs As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colAvailableStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCashAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCashPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnPendingIventoryAcknowledgements As System.Windows.Forms.Button
    Friend WithEvents lblPendingIventoryAcknowledgements As System.Windows.Forms.Label
    Friend WithEvents chkPrintDrugLabel As System.Windows.Forms.CheckBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents stbPhoneNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents stbAppointmentDetails As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents stbNextAppointmentDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnAddExtraCharge As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnOPDConsumables As System.Windows.Forms.Button
    Friend WithEvents lblConsumableAlerts As System.Windows.Forms.Label
    Friend WithEvents imgIDAutomation As System.Windows.Forms.PictureBox
    Friend WithEvents chkPrintDrugBarcode As System.Windows.Forms.CheckBox
End Class
