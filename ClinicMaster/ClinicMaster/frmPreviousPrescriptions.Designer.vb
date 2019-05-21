<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmPreviousPrescriptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreviousPrescriptions))
        Me.lblServicePayStatusID = New System.Windows.Forms.Label()
        Me.stbCombination = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCombination = New System.Windows.Forms.Label()
        Me.dgvPrescription = New System.Windows.Forms.DataGridView()
        Me.colDrug = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDosage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDoctorQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugFormula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlNavigateVisits = New System.Windows.Forms.Panel()
        Me.chkNavigateVisits = New System.Windows.Forms.CheckBox()
        Me.navVisits = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.stbBillServiceFee = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillServiceFee = New System.Windows.Forms.Label()
        Me.cboServiceCode = New System.Windows.Forms.ComboBox()
        Me.lblServiceCode = New System.Windows.Forms.Label()
        Me.nbxOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOutstandingBalance = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
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
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.tbcDrRoles = New System.Windows.Forms.TabControl()
        Me.tpgPrescriptions = New System.Windows.Forms.TabPage()
        Me.pnlVisitNo = New System.Windows.Forms.Panel()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadSeeDrVisits = New System.Windows.Forms.Button()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForPrescription = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForPrescription = New System.Windows.Forms.Label()
        Me.btnSelfRequests = New System.Windows.Forms.Button()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigateVisits.SuspendLayout()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcDrRoles.SuspendLayout()
        Me.tpgPrescriptions.SuspendLayout()
        Me.pnlVisitNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblServicePayStatusID
        '
        Me.lblServicePayStatusID.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblServicePayStatusID.Location = New System.Drawing.Point(245, 105)
        Me.lblServicePayStatusID.Name = "lblServicePayStatusID"
        Me.lblServicePayStatusID.Size = New System.Drawing.Size(63, 19)
        Me.lblServicePayStatusID.TabIndex = 61
        Me.lblServicePayStatusID.Text = "Not Paid"
        Me.lblServicePayStatusID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stbCombination
        '
        Me.stbCombination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCombination.CapitalizeFirstLetter = False
        Me.stbCombination.Enabled = False
        Me.stbCombination.EntryErrorMSG = ""
        Me.stbCombination.Location = New System.Drawing.Point(450, 119)
        Me.stbCombination.MaxLength = 41
        Me.stbCombination.Name = "stbCombination"
        Me.stbCombination.RegularExpression = ""
        Me.stbCombination.Size = New System.Drawing.Size(149, 20)
        Me.stbCombination.TabIndex = 75
        '
        'lblCombination
        '
        Me.lblCombination.Location = New System.Drawing.Point(322, 121)
        Me.lblCombination.Name = "lblCombination"
        Me.lblCombination.Size = New System.Drawing.Size(110, 20)
        Me.lblCombination.TabIndex = 74
        Me.lblCombination.Text = "Combination"
        '
        'dgvPrescription
        '
        Me.dgvPrescription.AllowUserToOrderColumns = True
        Me.dgvPrescription.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPrescription.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrug, Me.colDosage, Me.colDuration, Me.colDoctorQuantity, Me.colDrugQuantity, Me.colBalance, Me.colDrugFormula, Me.colPrescriptionUnitMeasure, Me.colDrugUnitPrice, Me.colAmount, Me.colDrugPayStatus, Me.colDrugItemStatus, Me.colPrescriptionSaved})
        Me.dgvPrescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrescription.EnableHeadersVisualStyles = False
        Me.dgvPrescription.GridColor = System.Drawing.Color.Khaki
        Me.dgvPrescription.Location = New System.Drawing.Point(0, 0)
        Me.dgvPrescription.Name = "dgvPrescription"
        Me.dgvPrescription.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPrescription.Size = New System.Drawing.Size(960, 229)
        Me.dgvPrescription.TabIndex = 0
        Me.dgvPrescription.Text = "DataGridView1"
        '
        'colDrug
        '
        Me.colDrug.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDrug.DisplayStyleForCurrentCellOnly = True
        Me.colDrug.DropDownWidth = 10
        Me.colDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrug.HeaderText = "Drug"
        Me.colDrug.Name = "colDrug"
        Me.colDrug.ReadOnly = True
        Me.colDrug.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDrug.Width = 220
        '
        'colDosage
        '
        Me.colDosage.HeaderText = "Dosage"
        Me.colDosage.MaxInputLength = 100
        Me.colDosage.Name = "colDosage"
        Me.colDosage.ReadOnly = True
        Me.colDosage.ToolTipText = "Enter dosage in a format as set in drug categories"
        Me.colDosage.Width = 50
        '
        'colDuration
        '
        Me.colDuration.HeaderText = "Duration"
        Me.colDuration.Name = "colDuration"
        Me.colDuration.ReadOnly = True
        Me.colDuration.ToolTipText = "Duration in Days"
        Me.colDuration.Width = 50
        '
        'colDoctorQuantity
        '
        Me.colDoctorQuantity.HeaderText = "DrQuantity"
        Me.colDoctorQuantity.Name = "colDoctorQuantity"
        Me.colDoctorQuantity.ReadOnly = True
        Me.colDoctorQuantity.Width = 60
        '
        'colDrugQuantity
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.ReadOnly = True
        Me.colDrugQuantity.Width = 50
        '
        'colBalance
        '
        Me.colBalance.HeaderText = "Balance"
        Me.colBalance.Name = "colBalance"
        Me.colBalance.ReadOnly = True
        Me.colBalance.Width = 50
        '
        'colDrugFormula
        '
        Me.colDrugFormula.HeaderText = "Notes"
        Me.colDrugFormula.MaxInputLength = 100
        Me.colDrugFormula.Name = "colDrugFormula"
        Me.colDrugFormula.ReadOnly = True
        Me.colDrugFormula.Width = 70
        '
        'colPrescriptionUnitMeasure
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colPrescriptionUnitMeasure.DefaultCellStyle = DataGridViewCellStyle3
        Me.colPrescriptionUnitMeasure.HeaderText = "Unit Measure"
        Me.colPrescriptionUnitMeasure.Name = "colPrescriptionUnitMeasure"
        Me.colPrescriptionUnitMeasure.ReadOnly = True
        Me.colPrescriptionUnitMeasure.Width = 80
        '
        'colDrugUnitPrice
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colDrugUnitPrice.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDrugUnitPrice.HeaderText = "Unit Price"
        Me.colDrugUnitPrice.Name = "colDrugUnitPrice"
        Me.colDrugUnitPrice.ReadOnly = True
        Me.colDrugUnitPrice.Width = 65
        '
        'colAmount
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle5
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 65
        '
        'colDrugPayStatus
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugPayStatus.DefaultCellStyle = DataGridViewCellStyle6
        Me.colDrugPayStatus.HeaderText = "Pay Status"
        Me.colDrugPayStatus.Name = "colDrugPayStatus"
        Me.colDrugPayStatus.ReadOnly = True
        '
        'colDrugItemStatus
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugItemStatus.DefaultCellStyle = DataGridViewCellStyle7
        Me.colDrugItemStatus.HeaderText = "Item Status"
        Me.colDrugItemStatus.Name = "colDrugItemStatus"
        Me.colDrugItemStatus.ReadOnly = True
        '
        'colPrescriptionSaved
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = False
        Me.colPrescriptionSaved.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPrescriptionSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPrescriptionSaved.HeaderText = "Saved"
        Me.colPrescriptionSaved.Name = "colPrescriptionSaved"
        Me.colPrescriptionSaved.ReadOnly = True
        Me.colPrescriptionSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPrescriptionSaved.Width = 50
        '
        'pnlNavigateVisits
        '
        Me.pnlNavigateVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateVisits.Controls.Add(Me.chkNavigateVisits)
        Me.pnlNavigateVisits.Controls.Add(Me.navVisits)
        Me.pnlNavigateVisits.Location = New System.Drawing.Point(12, 435)
        Me.pnlNavigateVisits.Name = "pnlNavigateVisits"
        Me.pnlNavigateVisits.Size = New System.Drawing.Size(601, 33)
        Me.pnlNavigateVisits.TabIndex = 97
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
        'stbBillServiceFee
        '
        Me.stbBillServiceFee.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillServiceFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillServiceFee.CapitalizeFirstLetter = False
        Me.stbBillServiceFee.EntryErrorMSG = ""
        Me.stbBillServiceFee.ForeColor = System.Drawing.SystemColors.WindowText
        Me.stbBillServiceFee.Location = New System.Drawing.Point(150, 104)
        Me.stbBillServiceFee.MaxLength = 20
        Me.stbBillServiceFee.Name = "stbBillServiceFee"
        Me.stbBillServiceFee.ReadOnly = True
        Me.stbBillServiceFee.RegularExpression = ""
        Me.stbBillServiceFee.Size = New System.Drawing.Size(89, 20)
        Me.stbBillServiceFee.TabIndex = 60
        '
        'lblBillServiceFee
        '
        Me.lblBillServiceFee.Location = New System.Drawing.Point(12, 104)
        Me.lblBillServiceFee.Name = "lblBillServiceFee"
        Me.lblBillServiceFee.Size = New System.Drawing.Size(132, 18)
        Me.lblBillServiceFee.TabIndex = 59
        Me.lblBillServiceFee.Text = "To-Bill Service Fee"
        '
        'cboServiceCode
        '
        Me.cboServiceCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiceCode.DropDownWidth = 220
        Me.cboServiceCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboServiceCode.FormattingEnabled = True
        Me.cboServiceCode.ItemHeight = 13
        Me.cboServiceCode.Location = New System.Drawing.Point(150, 81)
        Me.cboServiceCode.Name = "cboServiceCode"
        Me.cboServiceCode.Size = New System.Drawing.Size(158, 21)
        Me.cboServiceCode.TabIndex = 58
        '
        'lblServiceCode
        '
        Me.lblServiceCode.Location = New System.Drawing.Point(12, 80)
        Me.lblServiceCode.Name = "lblServiceCode"
        Me.lblServiceCode.Size = New System.Drawing.Size(132, 20)
        Me.lblServiceCode.TabIndex = 57
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
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(805, 94)
        Me.nbxOutstandingBalance.MaxValue = 0.0R
        Me.nbxOutstandingBalance.MinValue = 0.0R
        Me.nbxOutstandingBalance.MustEnterNumeric = True
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = True
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(135, 20)
        Me.nbxOutstandingBalance.TabIndex = 85
        Me.nbxOutstandingBalance.Value = ""
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(605, 95)
        Me.lblOutstandingBalance.Name = "lblOutstandingBalance"
        Me.lblOutstandingBalance.Size = New System.Drawing.Size(159, 20)
        Me.lblOutstandingBalance.TabIndex = 84
        Me.lblOutstandingBalance.Text = "Outstanding Balance"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(450, 89)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(149, 29)
        Me.stbBillCustomerName.TabIndex = 73
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(322, 94)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(110, 20)
        Me.lblBillCustomerName.TabIndex = 72
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(775, 442)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 24)
        Me.btnPrint.TabIndex = 99
        Me.btnPrint.Text = "&Print"
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalVisits.CapitalizeFirstLetter = False
        Me.stbTotalVisits.Enabled = False
        Me.stbTotalVisits.EntryErrorMSG = ""
        Me.stbTotalVisits.Location = New System.Drawing.Point(682, 67)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(152, 20)
        Me.stbTotalVisits.TabIndex = 83
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(605, 67)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(71, 20)
        Me.lblTotalVisits.TabIndex = 82
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(840, 4)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(100, 89)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 96
        Me.spbPhoto.TabStop = False
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(69, 8)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 51
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(150, 126)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitDate.TabIndex = 63
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(450, 26)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(149, 20)
        Me.stbPatientNo.TabIndex = 67
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(322, 27)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(110, 20)
        Me.lblPatientsNo.TabIndex = 66
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
        Me.cboStaffNo.Location = New System.Drawing.Point(150, 36)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(158, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 54
        '
        'lblStaff
        '
        Me.lblStaff.Location = New System.Drawing.Point(12, 38)
        Me.lblStaff.Name = "lblStaff"
        Me.lblStaff.Size = New System.Drawing.Size(132, 20)
        Me.lblStaff.TabIndex = 53
        Me.lblStaff.Text = "Primary Dr. (Staff)"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(682, 46)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(152, 20)
        Me.stbBillMode.TabIndex = 81
        '
        'stbVisitServiceName
        '
        Me.stbVisitServiceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitServiceName.CapitalizeFirstLetter = False
        Me.stbVisitServiceName.Enabled = False
        Me.stbVisitServiceName.EntryErrorMSG = ""
        Me.stbVisitServiceName.Location = New System.Drawing.Point(150, 59)
        Me.stbVisitServiceName.MaxLength = 60
        Me.stbVisitServiceName.Name = "stbVisitServiceName"
        Me.stbVisitServiceName.RegularExpression = ""
        Me.stbVisitServiceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitServiceName.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitServiceName.TabIndex = 56
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(605, 48)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(71, 20)
        Me.lblBillMode.TabIndex = 80
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitServiceName
        '
        Me.lblVisitServiceName.Location = New System.Drawing.Point(12, 59)
        Me.lblVisitServiceName.Name = "lblVisitServiceName"
        Me.lblVisitServiceName.Size = New System.Drawing.Size(132, 20)
        Me.lblVisitServiceName.TabIndex = 55
        Me.lblVisitServiceName.Text = "Visit Registered Service"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(450, 68)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(149, 20)
        Me.stbBillNo.TabIndex = 71
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(682, 4)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(152, 20)
        Me.stbAge.TabIndex = 77
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(450, 47)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(149, 20)
        Me.stbJoinDate.TabIndex = 69
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(682, 25)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(152, 20)
        Me.stbGender.TabIndex = 79
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(322, 46)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(110, 20)
        Me.lblJoinDate.TabIndex = 68
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(322, 68)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(110, 20)
        Me.lblBillNo.TabIndex = 70
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(605, 4)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(71, 20)
        Me.lblAge.TabIndex = 76
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(605, 25)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(71, 20)
        Me.lblGenderID.TabIndex = 78
        Me.lblGenderID.Text = "Gender"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(911, 442)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(58, 24)
        Me.btnClose.TabIndex = 100
        Me.btnClose.Text = "&Close"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(12, 126)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(132, 20)
        Me.lblVisitDate.TabIndex = 62
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(450, 5)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(149, 20)
        Me.stbFullName.TabIndex = 65
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(322, 5)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(110, 20)
        Me.lblFullName.TabIndex = 64
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(12, 10)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(52, 18)
        Me.lblVisitNo.TabIndex = 50
        Me.lblVisitNo.Text = "Visit No."
        '
        'tbcDrRoles
        '
        Me.tbcDrRoles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcDrRoles.Controls.Add(Me.tpgPrescriptions)
        Me.tbcDrRoles.HotTrack = True
        Me.tbcDrRoles.Location = New System.Drawing.Point(8, 174)
        Me.tbcDrRoles.Name = "tbcDrRoles"
        Me.tbcDrRoles.SelectedIndex = 0
        Me.tbcDrRoles.Size = New System.Drawing.Size(968, 255)
        Me.tbcDrRoles.TabIndex = 94
        '
        'tpgPrescriptions
        '
        Me.tpgPrescriptions.Controls.Add(Me.dgvPrescription)
        Me.tpgPrescriptions.Location = New System.Drawing.Point(4, 22)
        Me.tpgPrescriptions.Name = "tpgPrescriptions"
        Me.tpgPrescriptions.Size = New System.Drawing.Size(960, 229)
        Me.tpgPrescriptions.TabIndex = 2
        Me.tpgPrescriptions.Tag = "DoctorPrescription"
        Me.tpgPrescriptions.Text = "Previous Prescriptions"
        Me.tpgPrescriptions.UseVisualStyleBackColor = True
        '
        'pnlVisitNo
        '
        Me.pnlVisitNo.Controls.Add(Me.stbVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.btnLoadSeeDrVisits)
        Me.pnlVisitNo.Location = New System.Drawing.Point(102, 4)
        Me.pnlVisitNo.Name = "pnlVisitNo"
        Me.pnlVisitNo.Size = New System.Drawing.Size(216, 30)
        Me.pnlVisitNo.TabIndex = 52
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
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(322, 148)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(114, 18)
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
        Me.stbBillForPrescription.Location = New System.Drawing.Point(150, 148)
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
        Me.stbBillWords.Location = New System.Drawing.Point(450, 140)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(498, 28)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForPrescription
        '
        Me.lblBillForPrescription.Location = New System.Drawing.Point(13, 150)
        Me.lblBillForPrescription.Name = "lblBillForPrescription"
        Me.lblBillForPrescription.Size = New System.Drawing.Size(121, 18)
        Me.lblBillForPrescription.TabIndex = 0
        Me.lblBillForPrescription.Text = "Bill for Prescription"
        '
        'btnSelfRequests
        '
        Me.btnSelfRequests.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnSelfRequests.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSelfRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSelfRequests.Location = New System.Drawing.Point(630, 443)
        Me.btnSelfRequests.Name = "btnSelfRequests"
        Me.btnSelfRequests.Size = New System.Drawing.Size(139, 23)
        Me.btnSelfRequests.TabIndex = 101
        Me.btnSelfRequests.Tag = "SelfRequests"
        Me.btnSelfRequests.Text = "&Self Requests"
        '
        'frmPreviousPrescriptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 480)
        Me.Controls.Add(Me.btnSelfRequests)
        Me.Controls.Add(Me.lblBillForPrescription)
        Me.Controls.Add(Me.stbBillForPrescription)
        Me.Controls.Add(Me.lblBillWords)
        Me.Controls.Add(Me.lblServicePayStatusID)
        Me.Controls.Add(Me.stbBillWords)
        Me.Controls.Add(Me.stbCombination)
        Me.Controls.Add(Me.lblCombination)
        Me.Controls.Add(Me.pnlNavigateVisits)
        Me.Controls.Add(Me.stbBillServiceFee)
        Me.Controls.Add(Me.lblBillServiceFee)
        Me.Controls.Add(Me.cboServiceCode)
        Me.Controls.Add(Me.lblServiceCode)
        Me.Controls.Add(Me.nbxOutstandingBalance)
        Me.Controls.Add(Me.lblOutstandingBalance)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.btnPrint)
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
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.tbcDrRoles)
        Me.Controls.Add(Me.pnlVisitNo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPreviousPrescriptions"
        Me.Text = "Previous Prescriptions"
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigateVisits.ResumeLayout(False)
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcDrRoles.ResumeLayout(False)
        Me.tpgPrescriptions.ResumeLayout(False)
        Me.pnlVisitNo.ResumeLayout(False)
        Me.pnlVisitNo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents lblServicePayStatusID As Label
    Friend WithEvents stbCombination As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCombination As Label
    Friend WithEvents dgvPrescription As DataGridView
    Friend WithEvents pnlNavigateVisits As Panel
    Friend WithEvents chkNavigateVisits As CheckBox
    Friend WithEvents navVisits As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents stbBillServiceFee As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillServiceFee As Label
    Friend WithEvents cboServiceCode As ComboBox
    Friend WithEvents lblServiceCode As Label
    Friend WithEvents nbxOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBalance As Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents stbTotalVisits As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalVisits As Label
    Protected WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents btnFindVisitNo As Button
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As Label
    Friend WithEvents cboStaffNo As ComboBox
    Friend WithEvents lblStaff As Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitServiceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As Label
    Friend WithEvents lblVisitServiceName As Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As Label
    Friend WithEvents lblBillNo As Label
    Friend WithEvents lblAge As Label
    Friend WithEvents lblGenderID As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents lblVisitDate As Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As Label
    Friend WithEvents lblVisitNo As Label
    Friend WithEvents tbcDrRoles As TabControl
    Friend WithEvents tpgPrescriptions As TabPage
    Friend WithEvents pnlVisitNo As Panel
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadSeeDrVisits As Button
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForPrescription As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForPrescription As System.Windows.Forms.Label
    Friend WithEvents colDrug As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDosage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDoctorQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugFormula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnSelfRequests As System.Windows.Forms.Button
End Class
