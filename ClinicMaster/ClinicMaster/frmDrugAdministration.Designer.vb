
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDrugAdministration : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDrugAdministration))
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpDrugAdminDateTime = New System.Windows.Forms.DateTimePicker()
        Me.dgvPrescription = New System.Windows.Forms.DataGridView()
        Me.colDrug = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDosage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColGivenQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRemainingQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColQuantitytoGive = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNurseNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlVisitNo = New System.Windows.Forms.Panel()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadSeeDrVisits = New System.Windows.Forms.Button()
        Me.tbcDrugAdministration = New System.Windows.Forms.TabControl()
        Me.tpgDrugAdministration = New System.Windows.Forms.TabPage()
        Me.tpgGivenDrugs = New System.Windows.Forms.TabPage()
        Me.dgvGivendrugs = New System.Windows.Forms.DataGridView()
        Me.ColReturnItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReturnQuantityTaken = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReturnGivenDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReturnNurseNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReturnGivenBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReturnSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.SmartTextBox1 = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.CboAdminStaff = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDischargeDateTime = New System.Windows.Forms.Label()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        CType(Me.dgvPrescription,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.spbPhoto,System.ComponentModel.ISupportInitialize).BeginInit
        Me.pnlVisitNo.SuspendLayout
        Me.tbcDrugAdministration.SuspendLayout
        Me.tpgDrugAdministration.SuspendLayout
        Me.tpgGivenDrugs.SuspendLayout
        CType(Me.dgvGivendrugs,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left),System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(13, 434)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "DrugAdministration"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = false
        '
        'dtpDrugAdminDateTime
        '
        Me.dtpDrugAdminDateTime.Checked = false
        Me.dtpDrugAdminDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpDrugAdminDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDrugAdminDateTime.Location = New System.Drawing.Point(155, 134)
        Me.dtpDrugAdminDateTime.Name = "dtpDrugAdminDateTime"
        Me.dtpDrugAdminDateTime.ShowCheckBox = true
        Me.dtpDrugAdminDateTime.Size = New System.Drawing.Size(170, 20)
        Me.dtpDrugAdminDateTime.TabIndex = 143
        '
        'dgvPrescription
        '
        Me.dgvPrescription.AllowUserToOrderColumns = true
        Me.dgvPrescription.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPrescription.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrug, Me.colDosage, Me.colDuration, Me.colDrugQuantity, Me.colNotes, Me.ColGivenQty, Me.ColRemainingQty, Me.ColQuantitytoGive, Me.ColNurseNotes, Me.colPrescriptionUnitMeasure, Me.colPrescriptionSaved})
        Me.dgvPrescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrescription.EnableHeadersVisualStyles = false
        Me.dgvPrescription.GridColor = System.Drawing.Color.Khaki
        Me.dgvPrescription.Location = New System.Drawing.Point(0, 0)
        Me.dgvPrescription.Name = "dgvPrescription"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvPrescription.Size = New System.Drawing.Size(965, 188)
        Me.dgvPrescription.TabIndex = 0
        Me.dgvPrescription.Text = "DataGridView1"
        '
        'colDrug
        '
        Me.colDrug.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDrug.DisplayStyleForCurrentCellOnly = true
        Me.colDrug.DropDownWidth = 10
        Me.colDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrug.Frozen = true
        Me.colDrug.HeaderText = "Drug"
        Me.colDrug.Name = "colDrug"
        Me.colDrug.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDrug.Width = 180
        '
        'colDosage
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colDosage.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDosage.Frozen = true
        Me.colDosage.HeaderText = "Dosage"
        Me.colDosage.MaxInputLength = 100
        Me.colDosage.Name = "colDosage"
        Me.colDosage.ReadOnly = true
        Me.colDosage.ToolTipText = "Enter dosage in a format as set in drug categories"
        Me.colDosage.Width = 50
        '
        'colDuration
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colDuration.DefaultCellStyle = DataGridViewCellStyle3
        Me.colDuration.Frozen = true
        Me.colDuration.HeaderText = "Duration"
        Me.colDuration.Name = "colDuration"
        Me.colDuration.ReadOnly = true
        Me.colDuration.ToolTipText = "Duration in Days"
        Me.colDuration.Width = 50
        '
        'colDrugQuantity
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle4
        Me.colDrugQuantity.Frozen = true
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.ReadOnly = true
        Me.colDrugQuantity.Width = 50
        '
        'colNotes
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colNotes.DefaultCellStyle = DataGridViewCellStyle5
        Me.colNotes.Frozen = true
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 100
        Me.colNotes.Name = "colNotes"
        Me.colNotes.ReadOnly = true
        Me.colNotes.Width = 70
        '
        'ColGivenQty
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.ColGivenQty.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColGivenQty.Frozen = true
        Me.ColGivenQty.HeaderText = "Given Qty"
        Me.ColGivenQty.Name = "ColGivenQty"
        Me.ColGivenQty.ReadOnly = true
        Me.ColGivenQty.Width = 60
        '
        'ColRemainingQty
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.ColRemainingQty.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColRemainingQty.Frozen = true
        Me.ColRemainingQty.HeaderText = "Remaining Qty"
        Me.ColRemainingQty.Name = "ColRemainingQty"
        Me.ColRemainingQty.ReadOnly = true
        Me.ColRemainingQty.Width = 90
        '
        'ColQuantitytoGive
        '
        Me.ColQuantitytoGive.Frozen = true
        Me.ColQuantitytoGive.HeaderText = "Quantity To Give"
        Me.ColQuantitytoGive.Name = "ColQuantitytoGive"
        '
        'ColNurseNotes
        '
        Me.ColNurseNotes.HeaderText = "Nurse Notes"
        Me.ColNurseNotes.Name = "ColNurseNotes"
        Me.ColNurseNotes.Width = 120
        '
        'colPrescriptionUnitMeasure
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colPrescriptionUnitMeasure.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPrescriptionUnitMeasure.HeaderText = "Unit Measure"
        Me.colPrescriptionUnitMeasure.Name = "colPrescriptionUnitMeasure"
        Me.colPrescriptionUnitMeasure.ReadOnly = true
        Me.colPrescriptionUnitMeasure.Width = 80
        '
        'colPrescriptionSaved
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = false
        Me.colPrescriptionSaved.DefaultCellStyle = DataGridViewCellStyle9
        Me.colPrescriptionSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPrescriptionSaved.HeaderText = "Saved"
        Me.colPrescriptionSaved.Name = "colPrescriptionSaved"
        Me.colPrescriptionSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPrescriptionSaved.Width = 50
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(901, 430)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = false
        '
        'lblServicePayStatusID
        '
        Me.lblServicePayStatusID.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblServicePayStatusID.Location = New System.Drawing.Point(250, 114)
        Me.lblServicePayStatusID.Name = "lblServicePayStatusID"
        Me.lblServicePayStatusID.Size = New System.Drawing.Size(63, 19)
        Me.lblServicePayStatusID.TabIndex = 112
        Me.lblServicePayStatusID.Text = "Not Paid"
        Me.lblServicePayStatusID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stbCombination
        '
        Me.stbCombination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCombination.CapitalizeFirstLetter = false
        Me.stbCombination.Enabled = false
        Me.stbCombination.EntryErrorMSG = ""
        Me.stbCombination.Location = New System.Drawing.Point(447, 150)
        Me.stbCombination.MaxLength = 41
        Me.stbCombination.Name = "stbCombination"
        Me.stbCombination.RegularExpression = ""
        Me.stbCombination.Size = New System.Drawing.Size(149, 20)
        Me.stbCombination.TabIndex = 126
        '
        'lblCombination
        '
        Me.lblCombination.Location = New System.Drawing.Point(330, 152)
        Me.lblCombination.Name = "lblCombination"
        Me.lblCombination.Size = New System.Drawing.Size(110, 20)
        Me.lblCombination.TabIndex = 125
        Me.lblCombination.Text = "Combination"
        '
        'stbBillServiceFee
        '
        Me.stbBillServiceFee.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillServiceFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillServiceFee.CapitalizeFirstLetter = false
        Me.stbBillServiceFee.EntryErrorMSG = ""
        Me.stbBillServiceFee.ForeColor = System.Drawing.SystemColors.WindowText
        Me.stbBillServiceFee.Location = New System.Drawing.Point(155, 113)
        Me.stbBillServiceFee.MaxLength = 20
        Me.stbBillServiceFee.Name = "stbBillServiceFee"
        Me.stbBillServiceFee.ReadOnly = true
        Me.stbBillServiceFee.RegularExpression = ""
        Me.stbBillServiceFee.Size = New System.Drawing.Size(89, 20)
        Me.stbBillServiceFee.TabIndex = 111
        '
        'lblBillServiceFee
        '
        Me.lblBillServiceFee.Location = New System.Drawing.Point(9, 113)
        Me.lblBillServiceFee.Name = "lblBillServiceFee"
        Me.lblBillServiceFee.Size = New System.Drawing.Size(132, 18)
        Me.lblBillServiceFee.TabIndex = 110
        Me.lblBillServiceFee.Text = "To-Bill Service Fee"
        '
        'cboServiceCode
        '
        Me.cboServiceCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServiceCode.DropDownWidth = 220
        Me.cboServiceCode.Enabled = false
        Me.cboServiceCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboServiceCode.FormattingEnabled = true
        Me.cboServiceCode.ItemHeight = 13
        Me.cboServiceCode.Location = New System.Drawing.Point(155, 89)
        Me.cboServiceCode.Name = "cboServiceCode"
        Me.cboServiceCode.Size = New System.Drawing.Size(168, 21)
        Me.cboServiceCode.TabIndex = 109
        '
        'lblServiceCode
        '
        Me.lblServiceCode.Location = New System.Drawing.Point(9, 88)
        Me.lblServiceCode.Name = "lblServiceCode"
        Me.lblServiceCode.Size = New System.Drawing.Size(132, 20)
        Me.lblServiceCode.TabIndex = 108
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
        Me.nbxOutstandingBalance.Location = New System.Drawing.Point(802, 103)
        Me.nbxOutstandingBalance.MaxValue = 0R
        Me.nbxOutstandingBalance.MinValue = 0R
        Me.nbxOutstandingBalance.MustEnterNumeric = true
        Me.nbxOutstandingBalance.Name = "nbxOutstandingBalance"
        Me.nbxOutstandingBalance.ReadOnly = true
        Me.nbxOutstandingBalance.Size = New System.Drawing.Size(135, 20)
        Me.nbxOutstandingBalance.TabIndex = 136
        Me.nbxOutstandingBalance.Value = ""
        '
        'lblOutstandingBalance
        '
        Me.lblOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblOutstandingBalance.Location = New System.Drawing.Point(602, 104)
        Me.lblOutstandingBalance.Name = "lblOutstandingBalance"
        Me.lblOutstandingBalance.Size = New System.Drawing.Size(159, 20)
        Me.lblOutstandingBalance.TabIndex = 135
        Me.lblOutstandingBalance.Text = "Outstanding Balance"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = false
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(447, 120)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = true
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = true
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(149, 29)
        Me.stbBillCustomerName.TabIndex = 124
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(330, 125)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(110, 20)
        Me.lblBillCustomerName.TabIndex = 123
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalVisits.CapitalizeFirstLetter = false
        Me.stbTotalVisits.Enabled = false
        Me.stbTotalVisits.EntryErrorMSG = ""
        Me.stbTotalVisits.Location = New System.Drawing.Point(679, 76)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(152, 20)
        Me.stbTotalVisits.TabIndex = 134
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(602, 76)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(71, 20)
        Me.lblTotalVisits.TabIndex = 133
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"),System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000,Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"),System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(837, 13)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = true
        Me.spbPhoto.Size = New System.Drawing.Size(100, 89)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 137
        Me.spbPhoto.TabStop = false
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"),System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(66, 17)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 102
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = false
        Me.stbVisitDate.Enabled = false
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(447, 57)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(149, 20)
        Me.stbVisitDate.TabIndex = 114
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = false
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = false
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(447, 35)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(149, 20)
        Me.stbPatientNo.TabIndex = 118
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(330, 36)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(110, 20)
        Me.lblPatientsNo.TabIndex = 117
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = false
        Me.stbBillMode.Enabled = false
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(679, 55)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(152, 20)
        Me.stbBillMode.TabIndex = 132
        '
        'stbVisitServiceName
        '
        Me.stbVisitServiceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitServiceName.CapitalizeFirstLetter = false
        Me.stbVisitServiceName.Enabled = false
        Me.stbVisitServiceName.EntryErrorMSG = ""
        Me.stbVisitServiceName.Location = New System.Drawing.Point(155, 67)
        Me.stbVisitServiceName.MaxLength = 60
        Me.stbVisitServiceName.Name = "stbVisitServiceName"
        Me.stbVisitServiceName.RegularExpression = ""
        Me.stbVisitServiceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitServiceName.Size = New System.Drawing.Size(168, 20)
        Me.stbVisitServiceName.TabIndex = 107
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(602, 57)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(71, 20)
        Me.lblBillMode.TabIndex = 131
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitServiceName
        '
        Me.lblVisitServiceName.Location = New System.Drawing.Point(9, 68)
        Me.lblVisitServiceName.Name = "lblVisitServiceName"
        Me.lblVisitServiceName.Size = New System.Drawing.Size(132, 20)
        Me.lblVisitServiceName.TabIndex = 106
        Me.lblVisitServiceName.Text = "Visit Registered Service"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = false
        Me.stbBillNo.Enabled = false
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(447, 99)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(149, 20)
        Me.stbBillNo.TabIndex = 122
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = false
        Me.stbAge.Enabled = false
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(679, 13)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(152, 20)
        Me.stbAge.TabIndex = 128
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = false
        Me.stbJoinDate.Enabled = false
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(447, 78)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(149, 20)
        Me.stbJoinDate.TabIndex = 120
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = false
        Me.stbGender.Enabled = false
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(679, 34)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(152, 20)
        Me.stbGender.TabIndex = 130
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(330, 77)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(110, 20)
        Me.lblJoinDate.TabIndex = 119
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(330, 99)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(110, 20)
        Me.lblBillNo.TabIndex = 121
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(602, 13)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(71, 20)
        Me.lblAge.TabIndex = 127
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(602, 34)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(71, 20)
        Me.lblGenderID.TabIndex = 129
        Me.lblGenderID.Text = "Gender"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(330, 59)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(110, 20)
        Me.lblVisitDate.TabIndex = 113
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = false
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(447, 14)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = true
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(149, 20)
        Me.stbFullName.TabIndex = 116
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(330, 14)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(110, 20)
        Me.lblFullName.TabIndex = 115
        Me.lblFullName.Text = "Patient's Name"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(9, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 18)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Visit No."
        '
        'pnlVisitNo
        '
        Me.pnlVisitNo.Controls.Add(Me.stbVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.btnLoadSeeDrVisits)
        Me.pnlVisitNo.Location = New System.Drawing.Point(103, 13)
        Me.pnlVisitNo.Name = "pnlVisitNo"
        Me.pnlVisitNo.Size = New System.Drawing.Size(216, 30)
        Me.pnlVisitNo.TabIndex = 103
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = false
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
        'tbcDrugAdministration
        '
        Me.tbcDrugAdministration.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom)  _
            Or System.Windows.Forms.AnchorStyles.Left)  _
            Or System.Windows.Forms.AnchorStyles.Right),System.Windows.Forms.AnchorStyles)
        Me.tbcDrugAdministration.Controls.Add(Me.tpgDrugAdministration)
        Me.tbcDrugAdministration.Controls.Add(Me.tpgGivenDrugs)
        Me.tbcDrugAdministration.HotTrack = true
        Me.tbcDrugAdministration.Location = New System.Drawing.Point(9, 195)
        Me.tbcDrugAdministration.Name = "tbcDrugAdministration"
        Me.tbcDrugAdministration.SelectedIndex = 0
        Me.tbcDrugAdministration.Size = New System.Drawing.Size(973, 214)
        Me.tbcDrugAdministration.TabIndex = 138
        '
        'tpgDrugAdministration
        '
        Me.tpgDrugAdministration.Controls.Add(Me.dgvPrescription)
        Me.tpgDrugAdministration.Location = New System.Drawing.Point(4, 22)
        Me.tpgDrugAdministration.Name = "tpgDrugAdministration"
        Me.tpgDrugAdministration.Size = New System.Drawing.Size(965, 188)
        Me.tpgDrugAdministration.TabIndex = 2
        Me.tpgDrugAdministration.Tag = "DoctorPrescription"
        Me.tpgDrugAdministration.Text = "Drug Administration"
        Me.tpgDrugAdministration.UseVisualStyleBackColor = true
        '
        'tpgGivenDrugs
        '
        Me.tpgGivenDrugs.Controls.Add(Me.dgvGivendrugs)
        Me.tpgGivenDrugs.Location = New System.Drawing.Point(4, 22)
        Me.tpgGivenDrugs.Name = "tpgGivenDrugs"
        Me.tpgGivenDrugs.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgGivenDrugs.Size = New System.Drawing.Size(965, 188)
        Me.tpgGivenDrugs.TabIndex = 3
        Me.tpgGivenDrugs.Text = "Given Drugs"
        Me.tpgGivenDrugs.UseVisualStyleBackColor = true
        '
        'dgvGivendrugs
        '
        Me.dgvGivendrugs.AllowUserToOrderColumns = true
        Me.dgvGivendrugs.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGivendrugs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvGivendrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColReturnItemName, Me.ColReturnQuantityTaken, Me.ColReturnGivenDateTime, Me.ColReturnNurseNotes, Me.ColReturnGivenBy, Me.ColReturnSaved})
        Me.dgvGivendrugs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvGivendrugs.EnableHeadersVisualStyles = false
        Me.dgvGivendrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvGivendrugs.Location = New System.Drawing.Point(3, 3)
        Me.dgvGivendrugs.Name = "dgvGivendrugs"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGivendrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvGivendrugs.Size = New System.Drawing.Size(959, 182)
        Me.dgvGivendrugs.TabIndex = 1
        Me.dgvGivendrugs.Text = "DataGridView1"
        '
        'ColReturnItemName
        '
        Me.ColReturnItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.ColReturnItemName.DefaultCellStyle = DataGridViewCellStyle12
        Me.ColReturnItemName.Frozen = true
        Me.ColReturnItemName.HeaderText = "Drug"
        Me.ColReturnItemName.Name = "ColReturnItemName"
        Me.ColReturnItemName.ReadOnly = true
        Me.ColReturnItemName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ColReturnItemName.Width = 280
        '
        'ColReturnQuantityTaken
        '
        Me.ColReturnQuantityTaken.DataPropertyName = "QuantityTaken"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.ColReturnQuantityTaken.DefaultCellStyle = DataGridViewCellStyle13
        Me.ColReturnQuantityTaken.Frozen = true
        Me.ColReturnQuantityTaken.HeaderText = "Quantity"
        Me.ColReturnQuantityTaken.Name = "ColReturnQuantityTaken"
        Me.ColReturnQuantityTaken.ReadOnly = true
        Me.ColReturnQuantityTaken.Width = 70
        '
        'ColReturnGivenDateTime
        '
        Me.ColReturnGivenDateTime.DataPropertyName = "TakenDateTime"
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.ColReturnGivenDateTime.DefaultCellStyle = DataGridViewCellStyle14
        Me.ColReturnGivenDateTime.HeaderText = "Given At"
        Me.ColReturnGivenDateTime.Name = "ColReturnGivenDateTime"
        Me.ColReturnGivenDateTime.ReadOnly = true
        Me.ColReturnGivenDateTime.Width = 150
        '
        'ColReturnNurseNotes
        '
        Me.ColReturnNurseNotes.DataPropertyName = "NurseNotes"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.ColReturnNurseNotes.DefaultCellStyle = DataGridViewCellStyle15
        Me.ColReturnNurseNotes.HeaderText = "Nurse Notes"
        Me.ColReturnNurseNotes.Name = "ColReturnNurseNotes"
        Me.ColReturnNurseNotes.ReadOnly = true
        Me.ColReturnNurseNotes.Width = 150
        '
        'ColReturnGivenBy
        '
        Me.ColReturnGivenBy.DataPropertyName = "StaffName"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.ColReturnGivenBy.DefaultCellStyle = DataGridViewCellStyle16
        Me.ColReturnGivenBy.HeaderText = "Given By"
        Me.ColReturnGivenBy.Name = "ColReturnGivenBy"
        Me.ColReturnGivenBy.ReadOnly = true
        Me.ColReturnGivenBy.Width = 150
        '
        'ColReturnSaved
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle17.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle17.NullValue = false
        Me.ColReturnSaved.DefaultCellStyle = DataGridViewCellStyle17
        Me.ColReturnSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColReturnSaved.HeaderText = "Saved"
        Me.ColReturnSaved.Name = "ColReturnSaved"
        Me.ColReturnSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColReturnSaved.Width = 50
        '
        'SmartTextBox1
        '
        Me.SmartTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SmartTextBox1.CapitalizeFirstLetter = false
        Me.SmartTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SmartTextBox1.EntryErrorMSG = ""
        Me.SmartTextBox1.Location = New System.Drawing.Point(4, 5)
        Me.SmartTextBox1.MaxLength = 20
        Me.SmartTextBox1.Name = "SmartTextBox1"
        Me.SmartTextBox1.RegularExpression = ""
        Me.SmartTextBox1.Size = New System.Drawing.Size(149, 20)
        Me.SmartTextBox1.TabIndex = 0
        '
        'CboAdminStaff
        '
        Me.CboAdminStaff.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CboAdminStaff.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CboAdminStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAdminStaff.DropDownWidth = 220
        Me.CboAdminStaff.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CboAdminStaff.FormattingEnabled = true
        Me.CboAdminStaff.Location = New System.Drawing.Point(156, 156)
        Me.CboAdminStaff.Name = "CboAdminStaff"
        Me.CboAdminStaff.Size = New System.Drawing.Size(168, 21)
        Me.CboAdminStaff.Sorted = true
        Me.CboAdminStaff.TabIndex = 141
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(10, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 20)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Administrator Nurse. (Staff)"
        '
        'lblDischargeDateTime
        '
        Me.lblDischargeDateTime.Location = New System.Drawing.Point(12, 139)
        Me.lblDischargeDateTime.Name = "lblDischargeDateTime"
        Me.lblDischargeDateTime.Size = New System.Drawing.Size(138, 18)
        Me.lblDischargeDateTime.TabIndex = 142
        Me.lblDischargeDateTime.Text = "Administrator Date Time"
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(9, 48)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(109, 18)
        Me.lblPrimaryDoctor.TabIndex = 144
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = false
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(155, 46)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.ReadOnly = true
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(164, 20)
        Me.stbPrimaryDoctor.TabIndex = 145
        '
        'frmDrugAdministration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(992, 468)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.dtpDrugAdminDateTime)
        Me.Controls.Add(Me.lblDischargeDateTime)
        Me.Controls.Add(Me.CboAdminStaff)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbcDrugAdministration)
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
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.pnlVisitNo)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.Name = "frmDrugAdministration"
        Me.Text = "Drug Administration"
        CType(Me.dgvPrescription,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.spbPhoto,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlVisitNo.ResumeLayout(false)
        Me.pnlVisitNo.PerformLayout
        Me.tbcDrugAdministration.ResumeLayout(false)
        Me.tpgDrugAdministration.ResumeLayout(false)
        Me.tpgGivenDrugs.ResumeLayout(false)
        CType(Me.dgvGivendrugs,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlVisitNo As System.Windows.Forms.Panel
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadSeeDrVisits As System.Windows.Forms.Button
    Friend WithEvents tbcDrugAdministration As System.Windows.Forms.TabControl
    Friend WithEvents tpgDrugAdministration As System.Windows.Forms.TabPage
    Friend WithEvents dgvPrescription As System.Windows.Forms.DataGridView
    Friend WithEvents SmartTextBox1 As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents CboAdminStaff As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpDrugAdminDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDischargeDateTime As System.Windows.Forms.Label
    Friend WithEvents colDrug As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDosage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColGivenQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRemainingQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColQuantitytoGive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNurseNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgGivenDrugs As System.Windows.Forms.TabPage
    Friend WithEvents dgvGivendrugs As System.Windows.Forms.DataGridView
    Friend WithEvents ColReturnItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColReturnQuantityTaken As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColReturnGivenDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColReturnNurseNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColReturnGivenBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColReturnSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox

End Class