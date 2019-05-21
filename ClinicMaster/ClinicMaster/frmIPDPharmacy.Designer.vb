<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmIPDPharmacy : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal roundNo As String)
        MyClass.New()
        Me.defaultRoundNo = roundNo
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIPDPharmacy))
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvPrescription = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colDrugNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDosage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.cmsPrescription = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsPrescriptionCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsPrescriptionSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsPrescriptionInventory = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsPrescriptionEditPrescription = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsPrescriptionRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtpIssueDate = New System.Windows.Forms.DateTimePicker()
        Me.lblIssueDate = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadToPharmacyIPDDoctor = New System.Windows.Forms.Button()
        Me.btnFindRoundNo = New System.Windows.Forms.Button()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnIPDConsumables = New System.Windows.Forms.Button()
        Me.lblIPDAlertsConsumables = New System.Windows.Forms.Label()
        Me.pnlToOrderDrugs = New System.Windows.Forms.Panel()
        Me.btnViewToExpireDrugsList = New System.Windows.Forms.Button()
        Me.lblToExpireDrugs = New System.Windows.Forms.Label()
        Me.btnViewToOrderDrugsList = New System.Windows.Forms.Button()
        Me.lblToOrderDrugs = New System.Windows.Forms.Label()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnPendingIventoryAcknowledgements = New System.Windows.Forms.Button()
        Me.lblPendingIventoryAcknowledgements = New System.Windows.Forms.Label()
        Me.btnViewList = New System.Windows.Forms.Button()
        Me.lblIPDAlerts = New System.Windows.Forms.Label()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForPrescription = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForPrescription = New System.Windows.Forms.Label()
        Me.stbRefillDuration = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefillDuration = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintPrescriptionOnSaving = New System.Windows.Forms.CheckBox()
        Me.tmrIPDAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbRoundDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRoundDateTime = New System.Windows.Forms.Label()
        Me.stbAdmissionDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionDateTime = New System.Windows.Forms.Label()
        Me.stbAttendingDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAttendingDoctor = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.stbAdmissionStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionStatus = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnFindAdmissionNo = New System.Windows.Forms.Button()
        Me.lblAdmissionNo = New System.Windows.Forms.Label()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.cboPharmacist = New System.Windows.Forms.ComboBox()
        Me.lblPharmacist = New System.Windows.Forms.Label()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.pnlPrintPrescription = New System.Windows.Forms.Panel()
        Me.chkPrintDrugBarcode = New System.Windows.Forms.CheckBox()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.btnAddConsumables = New System.Windows.Forms.Button()
        Me.tbcPharmacy = New System.Windows.Forms.TabControl()
        Me.tpgPrescription = New System.Windows.Forms.TabPage()
        Me.tpgConsumables = New System.Windows.Forms.TabPage()
        Me.stbGrandAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGrandTotalAmount = New System.Windows.Forms.Label()
        Me.lblGrandAmountWords = New System.Windows.Forms.Label()
        Me.stbGrandTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
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
        Me.tpgDiagnosis = New System.Windows.Forms.TabPage()
        Me.dgvDiagnosis = New System.Windows.Forms.DataGridView()
        Me.colDiseaseName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiseaseCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlNavigateRounds = New System.Windows.Forms.Panel()
        Me.chkNavigateRounds = New System.Windows.Forms.CheckBox()
        Me.navRounds = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.imgIDAutomation = New System.Windows.Forms.PictureBox()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPrescription.SuspendLayout()
        Me.pnlBill.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlToOrderDrugs.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        Me.pnlPrintPrescription.SuspendLayout()
        Me.tbcPharmacy.SuspendLayout()
        Me.tpgPrescription.SuspendLayout()
        Me.tpgConsumables.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgDiagnosis.SuspendLayout()
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigateRounds.SuspendLayout()
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPrescription
        '
        Me.dgvPrescription.AllowUserToAddRows = False
        Me.dgvPrescription.AllowUserToDeleteRows = False
        Me.dgvPrescription.AllowUserToOrderColumns = True
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
        Me.dgvPrescription.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colDrugNo, Me.colDrugName, Me.colDosage, Me.colDuration, Me.colQuantity, Me.colFormula, Me.colUnitMeasure, Me.colUnitPrice, Me.colAmount, Me.colPayStatus, Me.colDrugLocationBalance, Me.colUnitsInStock, Me.colExpiryDate, Me.colOrderLevel, Me.colHasAlternateDrugs, Me.colAvailableStock})
        Me.dgvPrescription.ContextMenuStrip = Me.cmsPrescription
        Me.dgvPrescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrescription.EnableHeadersVisualStyles = False
        Me.dgvPrescription.GridColor = System.Drawing.Color.Khaki
        Me.dgvPrescription.Location = New System.Drawing.Point(0, 0)
        Me.dgvPrescription.Name = "dgvPrescription"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvPrescription.RowHeadersVisible = False
        Me.dgvPrescription.Size = New System.Drawing.Size(940, 176)
        Me.dgvPrescription.TabIndex = 0
        Me.dgvPrescription.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'colDrugNo
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDrugNo.HeaderText = "Drug No"
        Me.colDrugNo.Name = "colDrugNo"
        Me.colDrugNo.ReadOnly = True
        Me.colDrugNo.Width = 65
        '
        'colDrugName
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDrugName.HeaderText = "Drug Name"
        Me.colDrugName.Name = "colDrugName"
        Me.colDrugName.ReadOnly = True
        Me.colDrugName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDrugName.Width = 150
        '
        'colDosage
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colDosage.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDosage.HeaderText = "Dosage"
        Me.colDosage.MaxInputLength = 100
        Me.colDosage.Name = "colDosage"
        Me.colDosage.ReadOnly = True
        Me.colDosage.Width = 60
        '
        'colDuration
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colDuration.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDuration.HeaderText = "Duration"
        Me.colDuration.Name = "colDuration"
        Me.colDuration.ReadOnly = True
        Me.colDuration.Width = 50
        '
        'colQuantity
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.colQuantity.FillWeight = 150.0!
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 60
        '
        'colFormula
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colFormula.DefaultCellStyle = DataGridViewCellStyle7
        Me.colFormula.FillWeight = 150.0!
        Me.colFormula.HeaderText = "Notes"
        Me.colFormula.MaxInputLength = 100
        Me.colFormula.Name = "colFormula"
        Me.colFormula.ReadOnly = True
        Me.colFormula.Width = 75
        '
        'colUnitMeasure
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitMeasure.DefaultCellStyle = DataGridViewCellStyle8
        Me.colUnitMeasure.HeaderText = "Unit Measure"
        Me.colUnitMeasure.Name = "colUnitMeasure"
        Me.colUnitMeasure.ReadOnly = True
        Me.colUnitMeasure.Width = 85
        '
        'colUnitPrice
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle9
        Me.colUnitPrice.FillWeight = 150.0!
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 60
        '
        'colAmount
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle10
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 60
        '
        'colPayStatus
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colPayStatus.DefaultCellStyle = DataGridViewCellStyle11
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 70
        '
        'colDrugLocationBalance
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugLocationBalance.DefaultCellStyle = DataGridViewCellStyle12
        Me.colDrugLocationBalance.HeaderText = "Location Balance"
        Me.colDrugLocationBalance.Name = "colDrugLocationBalance"
        Me.colDrugLocationBalance.ReadOnly = True
        '
        'colUnitsInStock
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitsInStock.DefaultCellStyle = DataGridViewCellStyle13
        Me.colUnitsInStock.HeaderText = "Units In Stock"
        Me.colUnitsInStock.Name = "colUnitsInStock"
        Me.colUnitsInStock.ReadOnly = True
        Me.colUnitsInStock.Width = 80
        '
        'colExpiryDate
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colExpiryDate.DefaultCellStyle = DataGridViewCellStyle14
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        Me.colExpiryDate.Width = 110
        '
        'colOrderLevel
        '
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colOrderLevel.DefaultCellStyle = DataGridViewCellStyle15
        Me.colOrderLevel.HeaderText = "Order Level"
        Me.colOrderLevel.Name = "colOrderLevel"
        Me.colOrderLevel.ReadOnly = True
        Me.colOrderLevel.Width = 70
        '
        'colHasAlternateDrugs
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle16.NullValue = False
        Me.colHasAlternateDrugs.DefaultCellStyle = DataGridViewCellStyle16
        Me.colHasAlternateDrugs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colHasAlternateDrugs.HeaderText = "Has Alternate Drugs"
        Me.colHasAlternateDrugs.Name = "colHasAlternateDrugs"
        Me.colHasAlternateDrugs.ReadOnly = True
        Me.colHasAlternateDrugs.Width = 110
        '
        'colAvailableStock
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        Me.colAvailableStock.DefaultCellStyle = DataGridViewCellStyle17
        Me.colAvailableStock.HeaderText = "Available Stock"
        Me.colAvailableStock.Name = "colAvailableStock"
        Me.colAvailableStock.ReadOnly = True
        Me.colAvailableStock.Width = 90
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
        'dtpIssueDate
        '
        Me.dtpIssueDate.Location = New System.Drawing.Point(145, 50)
        Me.dtpIssueDate.Name = "dtpIssueDate"
        Me.dtpIssueDate.ShowCheckBox = True
        Me.dtpIssueDate.Size = New System.Drawing.Size(159, 20)
        Me.dtpIssueDate.TabIndex = 8
        '
        'lblIssueDate
        '
        Me.lblIssueDate.Location = New System.Drawing.Point(16, 49)
        Me.lblIssueDate.Name = "lblIssueDate"
        Me.lblIssueDate.Size = New System.Drawing.Size(124, 20)
        Me.lblIssueDate.TabIndex = 7
        Me.lblIssueDate.Text = "Issue Date"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(22, 517)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(79, 24)
        Me.btnSave.TabIndex = 59
        Me.btnSave.Tag = "IPDPharmacy"
        Me.btnSave.Text = "&Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(879, 517)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(81, 24)
        Me.btnClose.TabIndex = 61
        Me.btnClose.Text = "&Close"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(438, 65)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(113, 20)
        Me.stbBillNo.TabIndex = 24
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(310, 65)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(124, 20)
        Me.lblBillNo.TabIndex = 23
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'stbRoundNo
        '
        Me.stbRoundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundNo.CapitalizeFirstLetter = False
        Me.stbRoundNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbRoundNo.EntryErrorMSG = ""
        Me.stbRoundNo.Location = New System.Drawing.Point(146, 27)
        Me.stbRoundNo.MaxLength = 20
        Me.stbRoundNo.Name = "stbRoundNo"
        Me.stbRoundNo.RegularExpression = ""
        Me.stbRoundNo.Size = New System.Drawing.Size(103, 20)
        Me.stbRoundNo.TabIndex = 5
        '
        'btnLoadToPharmacyIPDDoctor
        '
        Me.btnLoadToPharmacyIPDDoctor.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadToPharmacyIPDDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadToPharmacyIPDDoctor.Location = New System.Drawing.Point(255, 25)
        Me.btnLoadToPharmacyIPDDoctor.Name = "btnLoadToPharmacyIPDDoctor"
        Me.btnLoadToPharmacyIPDDoctor.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadToPharmacyIPDDoctor.TabIndex = 6
        Me.btnLoadToPharmacyIPDDoctor.Tag = ""
        Me.btnLoadToPharmacyIPDDoctor.Text = "&Load"
        '
        'btnFindRoundNo
        '
        Me.btnFindRoundNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindRoundNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindRoundNo.Image = CType(resources.GetObject("btnFindRoundNo.Image"), System.Drawing.Image)
        Me.btnFindRoundNo.Location = New System.Drawing.Point(113, 26)
        Me.btnFindRoundNo.Name = "btnFindRoundNo"
        Me.btnFindRoundNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindRoundNo.TabIndex = 4
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(16, 26)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(89, 20)
        Me.lblRoundNo.TabIndex = 3
        Me.lblRoundNo.Text = "Round No"
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.Panel1)
        Me.pnlBill.Controls.Add(Me.pnlToOrderDrugs)
        Me.pnlBill.Controls.Add(Me.pnlAlerts)
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForPrescription)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForPrescription)
        Me.pnlBill.Location = New System.Drawing.Point(6, 158)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(961, 105)
        Me.pnlBill.TabIndex = 53
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnIPDConsumables)
        Me.Panel1.Controls.Add(Me.lblIPDAlertsConsumables)
        Me.Panel1.Location = New System.Drawing.Point(357, 72)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(305, 30)
        Me.Panel1.TabIndex = 6
        '
        'btnIPDConsumables
        '
        Me.btnIPDConsumables.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnIPDConsumables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnIPDConsumables.Location = New System.Drawing.Point(235, 4)
        Me.btnIPDConsumables.Name = "btnIPDConsumables"
        Me.btnIPDConsumables.Size = New System.Drawing.Size(63, 24)
        Me.btnIPDConsumables.TabIndex = 1
        Me.btnIPDConsumables.Tag = ""
        Me.btnIPDConsumables.Text = "&View List"
        '
        'lblIPDAlertsConsumables
        '
        Me.lblIPDAlertsConsumables.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIPDAlertsConsumables.ForeColor = System.Drawing.Color.Red
        Me.lblIPDAlertsConsumables.Location = New System.Drawing.Point(9, 6)
        Me.lblIPDAlertsConsumables.Name = "lblIPDAlertsConsumables"
        Me.lblIPDAlertsConsumables.Size = New System.Drawing.Size(220, 20)
        Me.lblIPDAlertsConsumables.TabIndex = 0
        Me.lblIPDAlertsConsumables.Text = "Sent IPD Consumables: 0"
        '
        'pnlToOrderDrugs
        '
        Me.pnlToOrderDrugs.Controls.Add(Me.btnViewToExpireDrugsList)
        Me.pnlToOrderDrugs.Controls.Add(Me.lblToExpireDrugs)
        Me.pnlToOrderDrugs.Controls.Add(Me.btnViewToOrderDrugsList)
        Me.pnlToOrderDrugs.Controls.Add(Me.lblToOrderDrugs)
        Me.pnlToOrderDrugs.Location = New System.Drawing.Point(355, 37)
        Me.pnlToOrderDrugs.Name = "pnlToOrderDrugs"
        Me.pnlToOrderDrugs.Size = New System.Drawing.Size(602, 34)
        Me.pnlToOrderDrugs.TabIndex = 5
        '
        'btnViewToExpireDrugsList
        '
        Me.btnViewToExpireDrugsList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToExpireDrugsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToExpireDrugsList.Location = New System.Drawing.Point(511, 3)
        Me.btnViewToExpireDrugsList.Name = "btnViewToExpireDrugsList"
        Me.btnViewToExpireDrugsList.Size = New System.Drawing.Size(81, 24)
        Me.btnViewToExpireDrugsList.TabIndex = 3
        Me.btnViewToExpireDrugsList.Tag = ""
        Me.btnViewToExpireDrugsList.Text = "&View List"
        '
        'lblToExpireDrugs
        '
        Me.lblToExpireDrugs.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToExpireDrugs.ForeColor = System.Drawing.Color.Red
        Me.lblToExpireDrugs.Location = New System.Drawing.Point(266, 7)
        Me.lblToExpireDrugs.Name = "lblToExpireDrugs"
        Me.lblToExpireDrugs.Size = New System.Drawing.Size(241, 20)
        Me.lblToExpireDrugs.TabIndex = 2
        Me.lblToExpireDrugs.Text = "To Expire/Expired Drugs: 0"
        '
        'btnViewToOrderDrugsList
        '
        Me.btnViewToOrderDrugsList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewToOrderDrugsList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewToOrderDrugsList.Location = New System.Drawing.Point(174, 5)
        Me.btnViewToOrderDrugsList.Name = "btnViewToOrderDrugsList"
        Me.btnViewToOrderDrugsList.Size = New System.Drawing.Size(81, 24)
        Me.btnViewToOrderDrugsList.TabIndex = 1
        Me.btnViewToOrderDrugsList.Tag = ""
        Me.btnViewToOrderDrugsList.Text = "&View List"
        '
        'lblToOrderDrugs
        '
        Me.lblToOrderDrugs.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToOrderDrugs.ForeColor = System.Drawing.Color.Red
        Me.lblToOrderDrugs.Location = New System.Drawing.Point(1, 7)
        Me.lblToOrderDrugs.Name = "lblToOrderDrugs"
        Me.lblToOrderDrugs.Size = New System.Drawing.Size(168, 20)
        Me.lblToOrderDrugs.TabIndex = 0
        Me.lblToOrderDrugs.Text = "To Order Drugs: 0"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnPendingIventoryAcknowledgements)
        Me.pnlAlerts.Controls.Add(Me.lblPendingIventoryAcknowledgements)
        Me.pnlAlerts.Controls.Add(Me.btnViewList)
        Me.pnlAlerts.Controls.Add(Me.lblIPDAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(0, 37)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(350, 63)
        Me.pnlAlerts.TabIndex = 4
        '
        'btnPendingIventoryAcknowledgements
        '
        Me.btnPendingIventoryAcknowledgements.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPendingIventoryAcknowledgements.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPendingIventoryAcknowledgements.Location = New System.Drawing.Point(274, 35)
        Me.btnPendingIventoryAcknowledgements.Name = "btnPendingIventoryAcknowledgements"
        Me.btnPendingIventoryAcknowledgements.Size = New System.Drawing.Size(71, 24)
        Me.btnPendingIventoryAcknowledgements.TabIndex = 3
        Me.btnPendingIventoryAcknowledgements.Tag = ""
        Me.btnPendingIventoryAcknowledgements.Text = "&View List"
        '
        'lblPendingIventoryAcknowledgements
        '
        Me.lblPendingIventoryAcknowledgements.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingIventoryAcknowledgements.ForeColor = System.Drawing.Color.Red
        Me.lblPendingIventoryAcknowledgements.Location = New System.Drawing.Point(8, 38)
        Me.lblPendingIventoryAcknowledgements.Name = "lblPendingIventoryAcknowledgements"
        Me.lblPendingIventoryAcknowledgements.Size = New System.Drawing.Size(260, 20)
        Me.lblPendingIventoryAcknowledgements.TabIndex = 2
        Me.lblPendingIventoryAcknowledgements.Text = "Pending Ack: 0"
        '
        'btnViewList
        '
        Me.btnViewList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewList.Location = New System.Drawing.Point(274, 4)
        Me.btnViewList.Name = "btnViewList"
        Me.btnViewList.Size = New System.Drawing.Size(71, 24)
        Me.btnViewList.TabIndex = 1
        Me.btnViewList.Tag = ""
        Me.btnViewList.Text = "&View List"
        '
        'lblIPDAlerts
        '
        Me.lblIPDAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIPDAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblIPDAlerts.Location = New System.Drawing.Point(9, 6)
        Me.lblIPDAlerts.Name = "lblIPDAlerts"
        Me.lblIPDAlerts.Size = New System.Drawing.Size(210, 20)
        Me.lblIPDAlerts.TabIndex = 0
        Me.lblIPDAlerts.Text = "Doctor Prescription: 0"
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(307, 6)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(121, 18)
        Me.lblBillWords.TabIndex = 2
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
        Me.stbBillForPrescription.TabIndex = 1
        Me.stbBillForPrescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(432, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(522, 31)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForPrescription
        '
        Me.lblBillForPrescription.Location = New System.Drawing.Point(13, 6)
        Me.lblBillForPrescription.Name = "lblBillForPrescription"
        Me.lblBillForPrescription.Size = New System.Drawing.Size(121, 18)
        Me.lblBillForPrescription.TabIndex = 0
        Me.lblBillForPrescription.Text = "Bill for Prescription"
        '
        'stbRefillDuration
        '
        Me.stbRefillDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefillDuration.CapitalizeFirstLetter = False
        Me.stbRefillDuration.Enabled = False
        Me.stbRefillDuration.EntryErrorMSG = ""
        Me.stbRefillDuration.Location = New System.Drawing.Point(146, 137)
        Me.stbRefillDuration.MaxLength = 60
        Me.stbRefillDuration.Name = "stbRefillDuration"
        Me.stbRefillDuration.RegularExpression = ""
        Me.stbRefillDuration.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRefillDuration.Size = New System.Drawing.Size(158, 20)
        Me.stbRefillDuration.TabIndex = 16
        Me.stbRefillDuration.Visible = False
        '
        'lblRefillDuration
        '
        Me.lblRefillDuration.Location = New System.Drawing.Point(16, 138)
        Me.lblRefillDuration.Name = "lblRefillDuration"
        Me.lblRefillDuration.Size = New System.Drawing.Size(124, 20)
        Me.lblRefillDuration.TabIndex = 15
        Me.lblRefillDuration.Text = "Refill Duration (Days)"
        Me.lblRefillDuration.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(879, 492)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(81, 24)
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
        Me.chkPrintPrescriptionOnSaving.Location = New System.Drawing.Point(3, 7)
        Me.chkPrintPrescriptionOnSaving.Name = "chkPrintPrescriptionOnSaving"
        Me.chkPrintPrescriptionOnSaving.Size = New System.Drawing.Size(161, 17)
        Me.chkPrintPrescriptionOnSaving.TabIndex = 0
        Me.chkPrintPrescriptionOnSaving.Text = " Print Prescription On Saving"
        '
        'tmrIPDAlerts
        '
        Me.tmrIPDAlerts.Enabled = True
        Me.tmrIPDAlerts.Interval = 120000
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(146, 116)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitNo.TabIndex = 14
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(16, 116)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitNo.TabIndex = 13
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbRoundDateTime
        '
        Me.stbRoundDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundDateTime.CapitalizeFirstLetter = False
        Me.stbRoundDateTime.Enabled = False
        Me.stbRoundDateTime.EntryErrorMSG = ""
        Me.stbRoundDateTime.Location = New System.Drawing.Point(438, 128)
        Me.stbRoundDateTime.MaxLength = 60
        Me.stbRoundDateTime.Name = "stbRoundDateTime"
        Me.stbRoundDateTime.RegularExpression = ""
        Me.stbRoundDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRoundDateTime.Size = New System.Drawing.Size(113, 20)
        Me.stbRoundDateTime.TabIndex = 30
        '
        'lblRoundDateTime
        '
        Me.lblRoundDateTime.Location = New System.Drawing.Point(310, 128)
        Me.lblRoundDateTime.Name = "lblRoundDateTime"
        Me.lblRoundDateTime.Size = New System.Drawing.Size(124, 20)
        Me.lblRoundDateTime.TabIndex = 29
        Me.lblRoundDateTime.Text = "Round Date and Time"
        '
        'stbAdmissionDateTime
        '
        Me.stbAdmissionDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionDateTime.CapitalizeFirstLetter = False
        Me.stbAdmissionDateTime.Enabled = False
        Me.stbAdmissionDateTime.EntryErrorMSG = ""
        Me.stbAdmissionDateTime.Location = New System.Drawing.Point(438, 107)
        Me.stbAdmissionDateTime.MaxLength = 60
        Me.stbAdmissionDateTime.Name = "stbAdmissionDateTime"
        Me.stbAdmissionDateTime.RegularExpression = ""
        Me.stbAdmissionDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionDateTime.Size = New System.Drawing.Size(113, 20)
        Me.stbAdmissionDateTime.TabIndex = 28
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(310, 109)
        Me.lblAdmissionDateTime.Name = "lblAdmissionDateTime"
        Me.lblAdmissionDateTime.Size = New System.Drawing.Size(124, 20)
        Me.lblAdmissionDateTime.TabIndex = 27
        Me.lblAdmissionDateTime.Text = "Admission Date Time"
        '
        'stbAttendingDoctor
        '
        Me.stbAttendingDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAttendingDoctor.CapitalizeFirstLetter = False
        Me.stbAttendingDoctor.Enabled = False
        Me.stbAttendingDoctor.EntryErrorMSG = ""
        Me.stbAttendingDoctor.Location = New System.Drawing.Point(438, 86)
        Me.stbAttendingDoctor.MaxLength = 60
        Me.stbAttendingDoctor.Name = "stbAttendingDoctor"
        Me.stbAttendingDoctor.RegularExpression = ""
        Me.stbAttendingDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAttendingDoctor.Size = New System.Drawing.Size(113, 20)
        Me.stbAttendingDoctor.TabIndex = 26
        '
        'lblAttendingDoctor
        '
        Me.lblAttendingDoctor.Location = New System.Drawing.Point(310, 87)
        Me.lblAttendingDoctor.Name = "lblAttendingDoctor"
        Me.lblAttendingDoctor.Size = New System.Drawing.Size(124, 20)
        Me.lblAttendingDoctor.TabIndex = 25
        Me.lblAttendingDoctor.Text = "Attending Doctor"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(438, 2)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(113, 20)
        Me.stbVisitDate.TabIndex = 18
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(310, 4)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitDate.TabIndex = 17
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(438, 23)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(113, 20)
        Me.stbFullName.TabIndex = 20
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(310, 25)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(124, 20)
        Me.lblFullName.TabIndex = 19
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(438, 44)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(113, 20)
        Me.stbPatientNo.TabIndex = 22
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(310, 46)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(124, 20)
        Me.lblPatientsNo.TabIndex = 21
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(889, 66)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(71, 20)
        Me.stbBillMode.TabIndex = 46
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(663, 23)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(128, 20)
        Me.stbVisitCategory.TabIndex = 34
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(797, 66)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(86, 20)
        Me.lblBillMode.TabIndex = 45
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(558, 24)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(99, 20)
        Me.lblVisitCategory.TabIndex = 33
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbAdmissionStatus
        '
        Me.stbAdmissionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionStatus.CapitalizeFirstLetter = False
        Me.stbAdmissionStatus.Enabled = False
        Me.stbAdmissionStatus.EntryErrorMSG = ""
        Me.stbAdmissionStatus.Location = New System.Drawing.Point(889, 24)
        Me.stbAdmissionStatus.MaxLength = 60
        Me.stbAdmissionStatus.Name = "stbAdmissionStatus"
        Me.stbAdmissionStatus.RegularExpression = ""
        Me.stbAdmissionStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionStatus.Size = New System.Drawing.Size(71, 20)
        Me.stbAdmissionStatus.TabIndex = 42
        '
        'lblAdmissionStatus
        '
        Me.lblAdmissionStatus.Location = New System.Drawing.Point(797, 24)
        Me.lblAdmissionStatus.Name = "lblAdmissionStatus"
        Me.lblAdmissionStatus.Size = New System.Drawing.Size(86, 20)
        Me.lblAdmissionStatus.TabIndex = 41
        Me.lblAdmissionStatus.Text = "Status"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(889, 3)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(71, 20)
        Me.stbAge.TabIndex = 40
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(663, 2)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(128, 20)
        Me.stbJoinDate.TabIndex = 32
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(889, 45)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(71, 20)
        Me.stbGender.TabIndex = 44
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(558, 2)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(99, 20)
        Me.lblJoinDate.TabIndex = 31
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(797, 3)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(86, 20)
        Me.lblAge.TabIndex = 39
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(797, 45)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(86, 20)
        Me.lblGenderID.TabIndex = 43
        Me.lblGenderID.Text = "Gender"
        '
        'stbAdmissionNo
        '
        Me.stbAdmissionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionNo.CapitalizeFirstLetter = False
        Me.stbAdmissionNo.EntryErrorMSG = ""
        Me.stbAdmissionNo.Location = New System.Drawing.Point(146, 3)
        Me.stbAdmissionNo.MaxLength = 20
        Me.stbAdmissionNo.Name = "stbAdmissionNo"
        Me.stbAdmissionNo.ReadOnly = True
        Me.stbAdmissionNo.RegularExpression = ""
        Me.stbAdmissionNo.Size = New System.Drawing.Size(158, 20)
        Me.stbAdmissionNo.TabIndex = 2
        '
        'btnFindAdmissionNo
        '
        Me.btnFindAdmissionNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindAdmissionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindAdmissionNo.Image = CType(resources.GetObject("btnFindAdmissionNo.Image"), System.Drawing.Image)
        Me.btnFindAdmissionNo.Location = New System.Drawing.Point(113, 3)
        Me.btnFindAdmissionNo.Name = "btnFindAdmissionNo"
        Me.btnFindAdmissionNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindAdmissionNo.TabIndex = 1
        '
        'lblAdmissionNo
        '
        Me.lblAdmissionNo.AccessibleDescription = " "
        Me.lblAdmissionNo.Location = New System.Drawing.Point(16, 3)
        Me.lblAdmissionNo.Name = "lblAdmissionNo"
        Me.lblAdmissionNo.Size = New System.Drawing.Size(89, 20)
        Me.lblAdmissionNo.TabIndex = 0
        Me.lblAdmissionNo.Text = "Admission No"
        '
        'btnEdit
        '
        Me.btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEdit.Location = New System.Drawing.Point(511, 477)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(118, 23)
        Me.btnEdit.TabIndex = 57
        Me.btnEdit.Tag = "DoctorPrescription"
        Me.btnEdit.Text = "&Edit"
        '
        'cboPharmacist
        '
        Me.cboPharmacist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPharmacist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPharmacist.Location = New System.Drawing.Point(146, 71)
        Me.cboPharmacist.Name = "cboPharmacist"
        Me.cboPharmacist.Size = New System.Drawing.Size(158, 21)
        Me.cboPharmacist.TabIndex = 10
        '
        'lblPharmacist
        '
        Me.lblPharmacist.Location = New System.Drawing.Point(16, 70)
        Me.lblPharmacist.Name = "lblPharmacist"
        Me.lblPharmacist.Size = New System.Drawing.Size(123, 20)
        Me.lblPharmacist.TabIndex = 9
        Me.lblPharmacist.Text = "Pharmacist"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(889, 129)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(71, 20)
        Me.nbxCoPayValue.TabIndex = 52
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(797, 130)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(86, 20)
        Me.lblCoPayValue.TabIndex = 51
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(889, 108)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(71, 20)
        Me.nbxCoPayPercent.TabIndex = 50
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(797, 109)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(86, 20)
        Me.lblCoPayPercent.TabIndex = 49
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(889, 87)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(71, 20)
        Me.stbCoPayType.TabIndex = 48
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(797, 87)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(86, 20)
        Me.lblCoPayType.TabIndex = 47
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(663, 78)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(128, 36)
        Me.stbInsuranceName.TabIndex = 38
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(562, 80)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(99, 20)
        Me.lblBillInsuranceName.TabIndex = 37
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(663, 44)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(128, 31)
        Me.stbBillCustomerName.TabIndex = 36
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(558, 55)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(99, 20)
        Me.lblBillCustomerName.TabIndex = 35
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'pnlPrintPrescription
        '
        Me.pnlPrintPrescription.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPrintPrescription.Controls.Add(Me.chkPrintDrugBarcode)
        Me.pnlPrintPrescription.Controls.Add(Me.chkPrintPrescriptionOnSaving)
        Me.pnlPrintPrescription.Location = New System.Drawing.Point(23, 477)
        Me.pnlPrintPrescription.Name = "pnlPrintPrescription"
        Me.pnlPrintPrescription.Size = New System.Drawing.Size(302, 31)
        Me.pnlPrintPrescription.TabIndex = 55
        '
        'chkPrintDrugBarcode
        '
        Me.chkPrintDrugBarcode.AccessibleDescription = ""
        Me.chkPrintDrugBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintDrugBarcode.AutoSize = True
        Me.chkPrintDrugBarcode.Location = New System.Drawing.Point(170, 6)
        Me.chkPrintDrugBarcode.Name = "chkPrintDrugBarcode"
        Me.chkPrintDrugBarcode.Size = New System.Drawing.Size(119, 17)
        Me.chkPrintDrugBarcode.TabIndex = 3
        Me.chkPrintDrugBarcode.Text = " Print Drug Barcode"
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(146, 93)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(158, 21)
        Me.cboLocationID.TabIndex = 12
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(16, 94)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(123, 20)
        Me.lblLocationID.TabIndex = 11
        Me.lblLocationID.Text = "Location"
        '
        'btnAddConsumables
        '
        Me.btnAddConsumables.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAddConsumables.Enabled = False
        Me.btnAddConsumables.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnAddConsumables.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddConsumables.Location = New System.Drawing.Point(387, 477)
        Me.btnAddConsumables.Name = "btnAddConsumables"
        Me.btnAddConsumables.Size = New System.Drawing.Size(118, 23)
        Me.btnAddConsumables.TabIndex = 56
        Me.btnAddConsumables.Tag = "IPDConsumables"
        Me.btnAddConsumables.Text = "Add &Consumables"
        Me.btnAddConsumables.UseVisualStyleBackColor = True
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
        Me.tbcPharmacy.Location = New System.Drawing.Point(19, 265)
        Me.tbcPharmacy.Name = "tbcPharmacy"
        Me.tbcPharmacy.SelectedIndex = 0
        Me.tbcPharmacy.Size = New System.Drawing.Size(948, 202)
        Me.tbcPharmacy.TabIndex = 54
        '
        'tpgPrescription
        '
        Me.tpgPrescription.Controls.Add(Me.dgvPrescription)
        Me.tpgPrescription.Location = New System.Drawing.Point(4, 22)
        Me.tpgPrescription.Name = "tpgPrescription"
        Me.tpgPrescription.Size = New System.Drawing.Size(940, 176)
        Me.tpgPrescription.TabIndex = 1
        Me.tpgPrescription.Tag = ""
        Me.tpgPrescription.Text = "Prescription"
        Me.tpgPrescription.UseVisualStyleBackColor = True
        '
        'tpgConsumables
        '
        Me.tpgConsumables.Controls.Add(Me.stbGrandAmountWords)
        Me.tpgConsumables.Controls.Add(Me.lblGrandTotalAmount)
        Me.tpgConsumables.Controls.Add(Me.lblGrandAmountWords)
        Me.tpgConsumables.Controls.Add(Me.stbGrandTotalAmount)
        Me.tpgConsumables.Controls.Add(Me.stbConsumablesAmountWords)
        Me.tpgConsumables.Controls.Add(Me.lblBillForConsumables)
        Me.tpgConsumables.Controls.Add(Me.lblConsumablesAmountWords)
        Me.tpgConsumables.Controls.Add(Me.stbBillForConsumables)
        Me.tpgConsumables.Controls.Add(Me.dgvConsumables)
        Me.tpgConsumables.Location = New System.Drawing.Point(4, 22)
        Me.tpgConsumables.Name = "tpgConsumables"
        Me.tpgConsumables.Size = New System.Drawing.Size(940, 176)
        Me.tpgConsumables.TabIndex = 3
        Me.tpgConsumables.Text = "Consumables"
        Me.tpgConsumables.UseVisualStyleBackColor = True
        '
        'stbGrandAmountWords
        '
        Me.stbGrandAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbGrandAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbGrandAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGrandAmountWords.CapitalizeFirstLetter = False
        Me.stbGrandAmountWords.EntryErrorMSG = ""
        Me.stbGrandAmountWords.Location = New System.Drawing.Point(499, 169)
        Me.stbGrandAmountWords.MaxLength = 100
        Me.stbGrandAmountWords.Multiline = True
        Me.stbGrandAmountWords.Name = "stbGrandAmountWords"
        Me.stbGrandAmountWords.ReadOnly = True
        Me.stbGrandAmountWords.RegularExpression = ""
        Me.stbGrandAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGrandAmountWords.Size = New System.Drawing.Size(438, 34)
        Me.stbGrandAmountWords.TabIndex = 8
        '
        'lblGrandTotalAmount
        '
        Me.lblGrandTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGrandTotalAmount.Location = New System.Drawing.Point(9, 179)
        Me.lblGrandTotalAmount.Name = "lblGrandTotalAmount"
        Me.lblGrandTotalAmount.Size = New System.Drawing.Size(121, 20)
        Me.lblGrandTotalAmount.TabIndex = 5
        Me.lblGrandTotalAmount.Text = "Grand Total"
        '
        'lblGrandAmountWords
        '
        Me.lblGrandAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGrandAmountWords.Location = New System.Drawing.Point(310, 179)
        Me.lblGrandAmountWords.Name = "lblGrandAmountWords"
        Me.lblGrandAmountWords.Size = New System.Drawing.Size(184, 21)
        Me.lblGrandAmountWords.TabIndex = 7
        Me.lblGrandAmountWords.Text = "Grand Total in Words"
        '
        'stbGrandTotalAmount
        '
        Me.stbGrandTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbGrandTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbGrandTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGrandTotalAmount.CapitalizeFirstLetter = False
        Me.stbGrandTotalAmount.Enabled = False
        Me.stbGrandTotalAmount.EntryErrorMSG = ""
        Me.stbGrandTotalAmount.Location = New System.Drawing.Point(136, 179)
        Me.stbGrandTotalAmount.MaxLength = 20
        Me.stbGrandTotalAmount.Name = "stbGrandTotalAmount"
        Me.stbGrandTotalAmount.RegularExpression = ""
        Me.stbGrandTotalAmount.Size = New System.Drawing.Size(158, 20)
        Me.stbGrandTotalAmount.TabIndex = 6
        Me.stbGrandTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbConsumablesAmountWords
        '
        Me.stbConsumablesAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbConsumablesAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbConsumablesAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbConsumablesAmountWords.CapitalizeFirstLetter = False
        Me.stbConsumablesAmountWords.EntryErrorMSG = ""
        Me.stbConsumablesAmountWords.Location = New System.Drawing.Point(499, 134)
        Me.stbConsumablesAmountWords.MaxLength = 100
        Me.stbConsumablesAmountWords.Multiline = True
        Me.stbConsumablesAmountWords.Name = "stbConsumablesAmountWords"
        Me.stbConsumablesAmountWords.ReadOnly = True
        Me.stbConsumablesAmountWords.RegularExpression = ""
        Me.stbConsumablesAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbConsumablesAmountWords.Size = New System.Drawing.Size(438, 34)
        Me.stbConsumablesAmountWords.TabIndex = 4
        '
        'lblBillForConsumables
        '
        Me.lblBillForConsumables.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBillForConsumables.Location = New System.Drawing.Point(9, 144)
        Me.lblBillForConsumables.Name = "lblBillForConsumables"
        Me.lblBillForConsumables.Size = New System.Drawing.Size(121, 20)
        Me.lblBillForConsumables.TabIndex = 1
        Me.lblBillForConsumables.Text = "Bill for Consumables"
        '
        'lblConsumablesAmountWords
        '
        Me.lblConsumablesAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblConsumablesAmountWords.Location = New System.Drawing.Point(310, 144)
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
        Me.stbBillForConsumables.Location = New System.Drawing.Point(136, 144)
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
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumableName, Me.colConsumableNotes, Me.colConsumableQuantity, Me.colConsumableUnitPrice, Me.colConsumableAmount})
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(3, 3)
        Me.dgvConsumables.Name = "dgvConsumables"
        Me.dgvConsumables.ReadOnly = True
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvConsumables.Size = New System.Drawing.Size(934, 125)
        Me.dgvConsumables.TabIndex = 0
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'colConsumableName
        '
        Me.colConsumableName.DataPropertyName = "ItemName"
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableName.DefaultCellStyle = DataGridViewCellStyle20
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.ReadOnly = True
        Me.colConsumableName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colConsumableName.Width = 250
        '
        'colConsumableNotes
        '
        Me.colConsumableNotes.DataPropertyName = "ItemDetails"
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableNotes.DefaultCellStyle = DataGridViewCellStyle21
        Me.colConsumableNotes.HeaderText = "Notes"
        Me.colConsumableNotes.MaxInputLength = 40
        Me.colConsumableNotes.Name = "colConsumableNotes"
        Me.colConsumableNotes.ReadOnly = True
        '
        'colConsumableQuantity
        '
        Me.colConsumableQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle22.Format = "N0"
        DataGridViewCellStyle22.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle22.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle22
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.ReadOnly = True
        Me.colConsumableQuantity.Width = 60
        '
        'colConsumableUnitPrice
        '
        Me.colConsumableUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle23.Format = "N2"
        DataGridViewCellStyle23.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle23.NullValue = Nothing
        Me.colConsumableUnitPrice.DefaultCellStyle = DataGridViewCellStyle23
        Me.colConsumableUnitPrice.HeaderText = "Unit Price"
        Me.colConsumableUnitPrice.MaxInputLength = 12
        Me.colConsumableUnitPrice.Name = "colConsumableUnitPrice"
        Me.colConsumableUnitPrice.ReadOnly = True
        Me.colConsumableUnitPrice.Width = 80
        '
        'colConsumableAmount
        '
        Me.colConsumableAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle24.Format = "N2"
        DataGridViewCellStyle24.NullValue = Nothing
        Me.colConsumableAmount.DefaultCellStyle = DataGridViewCellStyle24
        Me.colConsumableAmount.HeaderText = "Amount"
        Me.colConsumableAmount.MaxInputLength = 12
        Me.colConsumableAmount.Name = "colConsumableAmount"
        Me.colConsumableAmount.ReadOnly = True
        Me.colConsumableAmount.Width = 80
        '
        'tpgDiagnosis
        '
        Me.tpgDiagnosis.Controls.Add(Me.dgvDiagnosis)
        Me.tpgDiagnosis.Location = New System.Drawing.Point(4, 22)
        Me.tpgDiagnosis.Name = "tpgDiagnosis"
        Me.tpgDiagnosis.Size = New System.Drawing.Size(940, 176)
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
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.dgvDiagnosis.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDiseaseName, Me.colDiseaseCategory})
        Me.dgvDiagnosis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDiagnosis.EnableHeadersVisualStyles = False
        Me.dgvDiagnosis.GridColor = System.Drawing.Color.Khaki
        Me.dgvDiagnosis.Location = New System.Drawing.Point(0, 0)
        Me.dgvDiagnosis.Name = "dgvDiagnosis"
        Me.dgvDiagnosis.ReadOnly = True
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDiagnosis.RowHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.dgvDiagnosis.Size = New System.Drawing.Size(940, 176)
        Me.dgvDiagnosis.TabIndex = 0
        Me.dgvDiagnosis.Text = "DataGridView1"
        '
        'colDiseaseName
        '
        Me.colDiseaseName.DataPropertyName = "DiseaseName"
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseName.DefaultCellStyle = DataGridViewCellStyle27
        Me.colDiseaseName.HeaderText = "Diagnosis"
        Me.colDiseaseName.Name = "colDiseaseName"
        Me.colDiseaseName.ReadOnly = True
        Me.colDiseaseName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDiseaseName.Width = 400
        '
        'colDiseaseCategory
        '
        Me.colDiseaseCategory.DataPropertyName = "DiseaseCategories"
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Info
        Me.colDiseaseCategory.DefaultCellStyle = DataGridViewCellStyle28
        Me.colDiseaseCategory.HeaderText = "Category"
        Me.colDiseaseCategory.Name = "colDiseaseCategory"
        Me.colDiseaseCategory.ReadOnly = True
        Me.colDiseaseCategory.Width = 150
        '
        'pnlNavigateRounds
        '
        Me.pnlNavigateRounds.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateRounds.Controls.Add(Me.chkNavigateRounds)
        Me.pnlNavigateRounds.Controls.Add(Me.navRounds)
        Me.pnlNavigateRounds.Location = New System.Drawing.Point(180, 508)
        Me.pnlNavigateRounds.Name = "pnlNavigateRounds"
        Me.pnlNavigateRounds.Size = New System.Drawing.Size(620, 33)
        Me.pnlNavigateRounds.TabIndex = 60
        '
        'chkNavigateRounds
        '
        Me.chkNavigateRounds.AccessibleDescription = ""
        Me.chkNavigateRounds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateRounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateRounds.Location = New System.Drawing.Point(8, 9)
        Me.chkNavigateRounds.Name = "chkNavigateRounds"
        Me.chkNavigateRounds.Size = New System.Drawing.Size(167, 20)
        Me.chkNavigateRounds.TabIndex = 0
        Me.chkNavigateRounds.Text = "Navigate Admission Rounds"
        '
        'navRounds
        '
        Me.navRounds.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navRounds.ColumnName = "RoundNo"
        Me.navRounds.DataSource = Nothing
        Me.navRounds.Location = New System.Drawing.Point(181, 2)
        Me.navRounds.Name = "navRounds"
        Me.navRounds.NavAllEnabled = False
        Me.navRounds.NavLeftEnabled = False
        Me.navRounds.NavRightEnabled = False
        Me.navRounds.Size = New System.Drawing.Size(413, 32)
        Me.navRounds.TabIndex = 1
        '
        'imgIDAutomation
        '
        Me.imgIDAutomation.Location = New System.Drawing.Point(591, 118)
        Me.imgIDAutomation.Name = "imgIDAutomation"
        Me.imgIDAutomation.Size = New System.Drawing.Size(200, 40)
        Me.imgIDAutomation.TabIndex = 68
        Me.imgIDAutomation.TabStop = False
        '
        'frmIPDPharmacy
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(978, 561)
        Me.Controls.Add(Me.imgIDAutomation)
        Me.Controls.Add(Me.pnlNavigateRounds)
        Me.Controls.Add(Me.tbcPharmacy)
        Me.Controls.Add(Me.cboLocationID)
        Me.Controls.Add(Me.btnAddConsumables)
        Me.Controls.Add(Me.lblLocationID)
        Me.Controls.Add(Me.pnlPrintPrescription)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.cboPharmacist)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.lblPharmacist)
        Me.Controls.Add(Me.stbRoundNo)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.stbAdmissionNo)
        Me.Controls.Add(Me.btnLoadToPharmacyIPDDoctor)
        Me.Controls.Add(Me.btnFindRoundNo)
        Me.Controls.Add(Me.btnFindAdmissionNo)
        Me.Controls.Add(Me.lblRoundNo)
        Me.Controls.Add(Me.lblAdmissionNo)
        Me.Controls.Add(Me.stbRoundDateTime)
        Me.Controls.Add(Me.lblRoundDateTime)
        Me.Controls.Add(Me.stbAdmissionDateTime)
        Me.Controls.Add(Me.lblAdmissionDateTime)
        Me.Controls.Add(Me.stbAttendingDoctor)
        Me.Controls.Add(Me.lblAttendingDoctor)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.stbVisitCategory)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.lblVisitCategory)
        Me.Controls.Add(Me.stbAdmissionStatus)
        Me.Controls.Add(Me.lblAdmissionStatus)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbRefillDuration)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblRefillDuration)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.dtpIssueDate)
        Me.Controls.Add(Me.lblIssueDate)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmIPDPharmacy"
        Me.Text = "IPD Pharmacy"
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPrescription.ResumeLayout(False)
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlToOrderDrugs.ResumeLayout(False)
        Me.pnlAlerts.ResumeLayout(False)
        Me.pnlPrintPrescription.ResumeLayout(False)
        Me.pnlPrintPrescription.PerformLayout()
        Me.tbcPharmacy.ResumeLayout(False)
        Me.tpgPrescription.ResumeLayout(False)
        Me.tpgConsumables.ResumeLayout(False)
        Me.tpgConsumables.PerformLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgDiagnosis.ResumeLayout(False)
        CType(Me.dgvDiagnosis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigateRounds.ResumeLayout(False)
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvPrescription As System.Windows.Forms.DataGridView
    Friend WithEvents dtpIssueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblIssueDate As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents btnFindRoundNo As System.Windows.Forms.Button
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForPrescription As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForPrescription As System.Windows.Forms.Label
    Friend WithEvents stbRefillDuration As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefillDuration As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintPrescriptionOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnViewList As System.Windows.Forms.Button
    Friend WithEvents lblIPDAlerts As System.Windows.Forms.Label
    Friend WithEvents tmrIPDAlerts As System.Windows.Forms.Timer
    Friend WithEvents btnLoadToPharmacyIPDDoctor As System.Windows.Forms.Button
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbRoundDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoundDateTime As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionDateTime As System.Windows.Forms.Label
    Friend WithEvents stbAttendingDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAttendingDoctor As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitCategory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents lblVisitCategory As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionStatus As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindAdmissionNo As System.Windows.Forms.Button
    Friend WithEvents lblAdmissionNo As System.Windows.Forms.Label
    Friend WithEvents pnlToOrderDrugs As System.Windows.Forms.Panel
    Friend WithEvents lblToOrderDrugs As System.Windows.Forms.Label
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents cboPharmacist As System.Windows.Forms.ComboBox
    Friend WithEvents lblPharmacist As System.Windows.Forms.Label
    Friend WithEvents btnViewToExpireDrugsList As System.Windows.Forms.Button
    Friend WithEvents lblToExpireDrugs As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents cmsPrescription As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsPrescriptionCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsPrescriptionSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsPrescriptionInventory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents pnlPrintPrescription As System.Windows.Forms.Panel
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents btnAddConsumables As System.Windows.Forms.Button
    Friend WithEvents tbcPharmacy As System.Windows.Forms.TabControl
    Friend WithEvents tpgPrescription As System.Windows.Forms.TabPage
    Friend WithEvents tpgConsumables As System.Windows.Forms.TabPage
    Friend WithEvents stbGrandAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGrandTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblGrandAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbGrandTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbConsumablesAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForConsumables As System.Windows.Forms.Label
    Friend WithEvents lblConsumablesAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForConsumables As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dgvConsumables As System.Windows.Forms.DataGridView
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpgDiagnosis As System.Windows.Forms.TabPage
    Friend WithEvents dgvDiagnosis As System.Windows.Forms.DataGridView
    Friend WithEvents colDiseaseName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiseaseCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlNavigateRounds As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateRounds As System.Windows.Forms.CheckBox
    Friend WithEvents navRounds As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents cmsPrescriptionEditPrescription As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsPrescriptionRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colDrugNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDosage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
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
    Friend WithEvents lblPendingIventoryAcknowledgements As System.Windows.Forms.Label
    Friend WithEvents btnPendingIventoryAcknowledgements As System.Windows.Forms.Button
    Friend WithEvents btnViewToOrderDrugsList As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnIPDConsumables As System.Windows.Forms.Button
    Friend WithEvents lblIPDAlertsConsumables As System.Windows.Forms.Label
    Friend WithEvents chkPrintDrugBarcode As System.Windows.Forms.CheckBox
    Friend WithEvents imgIDAutomation As System.Windows.Forms.PictureBox
End Class
