<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsolidatedFinancialReport
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsolidatedFinancialReport))
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grpPeriod = New System.Windows.Forms.GroupBox()
        Me.cboItemCategoryID = New System.Windows.Forms.ComboBox()
        Me.lblItemCategoryID = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.cmsIncomeSummaries = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsIncomeSummariesCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsIncomeSummariesSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.colPaymentDetailsFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaymentDetailsVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaymentDetailsReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvIncomePaymentDetails = New System.Windows.Forms.DataGridView()
        Me.colIncomePaymentDetailsCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaymentDetailsTotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaymentDetailsPaidAfterDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaymentDetailsRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaymentDetailsRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgIncomePaymentDetails = New System.Windows.Forms.TabPage()
        Me.tbcPeriodicReport = New System.Windows.Forms.TabControl()
        Me.tpgCreditCashSales = New System.Windows.Forms.TabPage()
        Me.dgvCreditCashSales = New System.Windows.Forms.DataGridView()
        Me.colCCSVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCCSVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCCSFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCCSIncomeCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCCSTotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCCSRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCCSRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgIPDCashPayments = New System.Windows.Forms.TabPage()
        Me.dgvIPDCashPayments = New System.Windows.Forms.DataGridView()
        Me.ColIPDReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDIncomeCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDTotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDPaidAfterDays = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgIPDCreditBillsPayment = New System.Windows.Forms.TabPage()
        Me.dgvIPDCreditBillPayment = New System.Windows.Forms.DataGridView()
        Me.ColIPDCreditBillVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDCreditBillVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDCreditBillFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDCreditBillIncomeCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDCreditBillTotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDCreditBillRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDCreditBillRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgSupplierHistory = New System.Windows.Forms.TabPage()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.lblAmountWords = New System.Windows.Forms.Label()
        Me.stbTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dgvSupplierHistory = New System.Windows.Forms.DataGridView()
        Me.colSupplierNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhoneNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantityReturned = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVATValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnAmont = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNetAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLoginID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpPeriod.SuspendLayout()
        Me.cmsIncomeSummaries.SuspendLayout()
        CType(Me.dgvIncomePaymentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgIncomePaymentDetails.SuspendLayout()
        Me.tbcPeriodicReport.SuspendLayout()
        Me.tpgCreditCashSales.SuspendLayout()
        CType(Me.dgvCreditCashSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgIPDCashPayments.SuspendLayout()
        CType(Me.dgvIPDCashPayments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgIPDCreditBillsPayment.SuspendLayout()
        CType(Me.dgvIPDCreditBillPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgSupplierHistory.SuspendLayout()
        CType(Me.dgvSupplierHistory, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpPeriod
        '
        Me.grpPeriod.Controls.Add(Me.cboItemCategoryID)
        Me.grpPeriod.Controls.Add(Me.lblItemCategoryID)
        Me.grpPeriod.Controls.Add(Me.dtpEndDate)
        Me.grpPeriod.Controls.Add(Me.dtpStartDate)
        Me.grpPeriod.Controls.Add(Me.fbnLoad)
        Me.grpPeriod.Controls.Add(Me.lblEndDate)
        Me.grpPeriod.Controls.Add(Me.fbnExportTo)
        Me.grpPeriod.Controls.Add(Me.lblStartDate)
        Me.grpPeriod.Location = New System.Drawing.Point(6, 10)
        Me.grpPeriod.Name = "grpPeriod"
        Me.grpPeriod.Size = New System.Drawing.Size(1016, 75)
        Me.grpPeriod.TabIndex = 4
        Me.grpPeriod.TabStop = False
        Me.grpPeriod.Text = "Visit Period"
        '
        'cboItemCategoryID
        '
        Me.cboItemCategoryID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemCategoryID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCategoryID.FormattingEnabled = True
        Me.cboItemCategoryID.Location = New System.Drawing.Point(281, 41)
        Me.cboItemCategoryID.Name = "cboItemCategoryID"
        Me.cboItemCategoryID.Size = New System.Drawing.Size(189, 21)
        Me.cboItemCategoryID.TabIndex = 18
        '
        'lblItemCategoryID
        '
        Me.lblItemCategoryID.Location = New System.Drawing.Point(6, 46)
        Me.lblItemCategoryID.Name = "lblItemCategoryID"
        Me.lblItemCategoryID.Size = New System.Drawing.Size(240, 20)
        Me.lblItemCategoryID.TabIndex = 17
        Me.lblItemCategoryID.Text = "Item Category (Leave blank or use ‘*’ for all)"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(568, 14)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDate.TabIndex = 4
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(281, 18)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(189, 20)
        Me.dtpStartDate.TabIndex = 6
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(775, 12)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(116, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "Load..."
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(479, 16)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(83, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnExportTo
        '
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(906, 12)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(106, 22)
        Me.fbnExportTo.TabIndex = 5
        Me.fbnExportTo.Text = "Export to Excel..."
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(6, 16)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(72, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmsIncomeSummaries
        '
        Me.cmsIncomeSummaries.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsIncomeSummaries.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsIncomeSummariesCopy, Me.cmsIncomeSummariesSelectAll})
        Me.cmsIncomeSummaries.Name = "cmsSearch"
        Me.cmsIncomeSummaries.Size = New System.Drawing.Size(123, 48)
        '
        'cmsIncomeSummariesCopy
        '
        Me.cmsIncomeSummariesCopy.Enabled = False
        Me.cmsIncomeSummariesCopy.Image = CType(resources.GetObject("cmsIncomeSummariesCopy.Image"), System.Drawing.Image)
        Me.cmsIncomeSummariesCopy.Name = "cmsIncomeSummariesCopy"
        Me.cmsIncomeSummariesCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsIncomeSummariesCopy.Text = "Copy"
        Me.cmsIncomeSummariesCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsIncomeSummariesSelectAll
        '
        Me.cmsIncomeSummariesSelectAll.Enabled = False
        Me.cmsIncomeSummariesSelectAll.Name = "cmsIncomeSummariesSelectAll"
        Me.cmsIncomeSummariesSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsIncomeSummariesSelectAll.Text = "Select All"
        '
        'colPaymentDetailsFullName
        '
        Me.colPaymentDetailsFullName.DataPropertyName = "FullName"
        Me.colPaymentDetailsFullName.HeaderText = "Full Name"
        Me.colPaymentDetailsFullName.Name = "colPaymentDetailsFullName"
        Me.colPaymentDetailsFullName.ReadOnly = True
        Me.colPaymentDetailsFullName.Width = 180
        '
        'colPaymentDetailsVisitDate
        '
        Me.colPaymentDetailsVisitDate.DataPropertyName = "VisitDate"
        Me.colPaymentDetailsVisitDate.HeaderText = "Visit Date"
        Me.colPaymentDetailsVisitDate.Name = "colPaymentDetailsVisitDate"
        Me.colPaymentDetailsVisitDate.ReadOnly = True
        '
        'colPaymentDetailsReceiptNo
        '
        Me.colPaymentDetailsReceiptNo.DataPropertyName = "ReceiptNo"
        Me.colPaymentDetailsReceiptNo.HeaderText = "Receipt No"
        Me.colPaymentDetailsReceiptNo.Name = "colPaymentDetailsReceiptNo"
        Me.colPaymentDetailsReceiptNo.ReadOnly = True
        '
        'dgvIncomePaymentDetails
        '
        Me.dgvIncomePaymentDetails.AllowUserToAddRows = False
        Me.dgvIncomePaymentDetails.AllowUserToDeleteRows = False
        DataGridViewCellStyle39.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle39.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIncomePaymentDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle39
        Me.dgvIncomePaymentDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIncomePaymentDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvIncomePaymentDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIncomePaymentDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle40.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle40.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIncomePaymentDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle40
        Me.dgvIncomePaymentDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPaymentDetailsReceiptNo, Me.colPaymentDetailsVisitDate, Me.colPaymentDetailsFullName, Me.colIncomePaymentDetailsCategory, Me.colPaymentDetailsTotalAmount, Me.colPaymentDetailsPaidAfterDays, Me.colPaymentDetailsRecordDate, Me.colPaymentDetailsRecordTime})
        Me.dgvIncomePaymentDetails.ContextMenuStrip = Me.cmsIncomeSummaries
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle43.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle43.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIncomePaymentDetails.DefaultCellStyle = DataGridViewCellStyle43
        Me.dgvIncomePaymentDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIncomePaymentDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvIncomePaymentDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvIncomePaymentDetails.Name = "dgvIncomePaymentDetails"
        Me.dgvIncomePaymentDetails.ReadOnly = True
        Me.dgvIncomePaymentDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle44.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle44.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle44.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle44.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle44.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle44.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle44.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIncomePaymentDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle44
        Me.dgvIncomePaymentDetails.RowHeadersVisible = False
        Me.dgvIncomePaymentDetails.Size = New System.Drawing.Size(1008, 358)
        Me.dgvIncomePaymentDetails.TabIndex = 21
        Me.dgvIncomePaymentDetails.Text = "DataGridView1"
        '
        'colIncomePaymentDetailsCategory
        '
        Me.colIncomePaymentDetailsCategory.DataPropertyName = "IncomeCategory"
        Me.colIncomePaymentDetailsCategory.HeaderText = "Income Category"
        Me.colIncomePaymentDetailsCategory.Name = "colIncomePaymentDetailsCategory"
        Me.colIncomePaymentDetailsCategory.ReadOnly = True
        Me.colIncomePaymentDetailsCategory.Width = 150
        '
        'colPaymentDetailsTotalAmount
        '
        Me.colPaymentDetailsTotalAmount.DataPropertyName = "TotalAmount"
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPaymentDetailsTotalAmount.DefaultCellStyle = DataGridViewCellStyle41
        Me.colPaymentDetailsTotalAmount.HeaderText = "Total Amount"
        Me.colPaymentDetailsTotalAmount.Name = "colPaymentDetailsTotalAmount"
        Me.colPaymentDetailsTotalAmount.ReadOnly = True
        '
        'colPaymentDetailsPaidAfterDays
        '
        Me.colPaymentDetailsPaidAfterDays.DataPropertyName = "PaidAfterDays"
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colPaymentDetailsPaidAfterDays.DefaultCellStyle = DataGridViewCellStyle42
        Me.colPaymentDetailsPaidAfterDays.HeaderText = "Paid After (Days)"
        Me.colPaymentDetailsPaidAfterDays.Name = "colPaymentDetailsPaidAfterDays"
        Me.colPaymentDetailsPaidAfterDays.ReadOnly = True
        '
        'colPaymentDetailsRecordDate
        '
        Me.colPaymentDetailsRecordDate.DataPropertyName = "RecordDate"
        Me.colPaymentDetailsRecordDate.HeaderText = "Record Date"
        Me.colPaymentDetailsRecordDate.Name = "colPaymentDetailsRecordDate"
        Me.colPaymentDetailsRecordDate.ReadOnly = True
        '
        'colPaymentDetailsRecordTime
        '
        Me.colPaymentDetailsRecordTime.DataPropertyName = "RecordTime"
        Me.colPaymentDetailsRecordTime.HeaderText = "Record Time"
        Me.colPaymentDetailsRecordTime.Name = "colPaymentDetailsRecordTime"
        Me.colPaymentDetailsRecordTime.ReadOnly = True
        Me.colPaymentDetailsRecordTime.Width = 80
        '
        'tpgIncomePaymentDetails
        '
        Me.tpgIncomePaymentDetails.Controls.Add(Me.dgvIncomePaymentDetails)
        Me.tpgIncomePaymentDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgIncomePaymentDetails.Name = "tpgIncomePaymentDetails"
        Me.tpgIncomePaymentDetails.Size = New System.Drawing.Size(1008, 358)
        Me.tpgIncomePaymentDetails.TabIndex = 8
        Me.tpgIncomePaymentDetails.Tag = "IncomeSummaries"
        Me.tpgIncomePaymentDetails.Text = "Cash Payments"
        Me.tpgIncomePaymentDetails.UseVisualStyleBackColor = True
        '
        'tbcPeriodicReport
        '
        Me.tbcPeriodicReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcPeriodicReport.Controls.Add(Me.tpgIncomePaymentDetails)
        Me.tbcPeriodicReport.Controls.Add(Me.tpgCreditCashSales)
        Me.tbcPeriodicReport.Controls.Add(Me.tpgIPDCashPayments)
        Me.tbcPeriodicReport.Controls.Add(Me.tpgIPDCreditBillsPayment)
        Me.tbcPeriodicReport.Controls.Add(Me.tpgSupplierHistory)
        Me.tbcPeriodicReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbcPeriodicReport.HotTrack = True
        Me.tbcPeriodicReport.Location = New System.Drawing.Point(6, 91)
        Me.tbcPeriodicReport.Name = "tbcPeriodicReport"
        Me.tbcPeriodicReport.SelectedIndex = 0
        Me.tbcPeriodicReport.Size = New System.Drawing.Size(1016, 384)
        Me.tbcPeriodicReport.TabIndex = 5
        '
        'tpgCreditCashSales
        '
        Me.tpgCreditCashSales.Controls.Add(Me.dgvCreditCashSales)
        Me.tpgCreditCashSales.Location = New System.Drawing.Point(4, 22)
        Me.tpgCreditCashSales.Name = "tpgCreditCashSales"
        Me.tpgCreditCashSales.Size = New System.Drawing.Size(1008, 358)
        Me.tpgCreditCashSales.TabIndex = 14
        Me.tpgCreditCashSales.Text = "Credit Cash Sales"
        Me.tpgCreditCashSales.UseVisualStyleBackColor = True
        '
        'dgvCreditCashSales
        '
        Me.dgvCreditCashSales.AllowUserToAddRows = False
        Me.dgvCreditCashSales.AllowUserToDeleteRows = False
        DataGridViewCellStyle28.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle28.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvCreditCashSales.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle28
        Me.dgvCreditCashSales.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvCreditCashSales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvCreditCashSales.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCreditCashSales.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle29.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCreditCashSales.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.dgvCreditCashSales.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colCCSVisitNo, Me.colCCSVisitDate, Me.colCCSFullName, Me.ColCCSIncomeCategory, Me.ColCCSTotalAmount, Me.ColCCSRecordDate, Me.ColCCSRecordTime})
        Me.dgvCreditCashSales.ContextMenuStrip = Me.cmsIncomeSummaries
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvCreditCashSales.DefaultCellStyle = DataGridViewCellStyle33
        Me.dgvCreditCashSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvCreditCashSales.GridColor = System.Drawing.Color.Khaki
        Me.dgvCreditCashSales.Location = New System.Drawing.Point(0, 0)
        Me.dgvCreditCashSales.Name = "dgvCreditCashSales"
        Me.dgvCreditCashSales.ReadOnly = True
        Me.dgvCreditCashSales.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle45.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle45.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle45.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle45.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle45.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle45.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCreditCashSales.RowHeadersDefaultCellStyle = DataGridViewCellStyle45
        Me.dgvCreditCashSales.RowHeadersVisible = False
        Me.dgvCreditCashSales.Size = New System.Drawing.Size(1008, 358)
        Me.dgvCreditCashSales.TabIndex = 22
        Me.dgvCreditCashSales.Text = "DataGridView1"
        '
        'colCCSVisitNo
        '
        Me.colCCSVisitNo.DataPropertyName = "VisitNo"
        Me.colCCSVisitNo.HeaderText = "Visit No"
        Me.colCCSVisitNo.Name = "colCCSVisitNo"
        Me.colCCSVisitNo.ReadOnly = True
        '
        'colCCSVisitDate
        '
        Me.colCCSVisitDate.DataPropertyName = "VisitDate"
        Me.colCCSVisitDate.HeaderText = "Visit Date"
        Me.colCCSVisitDate.Name = "colCCSVisitDate"
        Me.colCCSVisitDate.ReadOnly = True
        '
        'colCCSFullName
        '
        Me.colCCSFullName.DataPropertyName = "FullName"
        Me.colCCSFullName.HeaderText = "Full Name"
        Me.colCCSFullName.Name = "colCCSFullName"
        Me.colCCSFullName.ReadOnly = True
        Me.colCCSFullName.Width = 180
        '
        'ColCCSIncomeCategory
        '
        Me.ColCCSIncomeCategory.DataPropertyName = "IncomeCategory"
        Me.ColCCSIncomeCategory.HeaderText = "Income Category"
        Me.ColCCSIncomeCategory.Name = "ColCCSIncomeCategory"
        Me.ColCCSIncomeCategory.ReadOnly = True
        Me.ColCCSIncomeCategory.Width = 150
        '
        'ColCCSTotalAmount
        '
        Me.ColCCSTotalAmount.DataPropertyName = "TotalAmount"
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColCCSTotalAmount.DefaultCellStyle = DataGridViewCellStyle32
        Me.ColCCSTotalAmount.HeaderText = "Total Amount"
        Me.ColCCSTotalAmount.Name = "ColCCSTotalAmount"
        Me.ColCCSTotalAmount.ReadOnly = True
        '
        'ColCCSRecordDate
        '
        Me.ColCCSRecordDate.DataPropertyName = "RecordDate"
        Me.ColCCSRecordDate.HeaderText = "Record Date"
        Me.ColCCSRecordDate.Name = "ColCCSRecordDate"
        Me.ColCCSRecordDate.ReadOnly = True
        '
        'ColCCSRecordTime
        '
        Me.ColCCSRecordTime.DataPropertyName = "RecordTime"
        Me.ColCCSRecordTime.HeaderText = "Record Time"
        Me.ColCCSRecordTime.Name = "ColCCSRecordTime"
        Me.ColCCSRecordTime.ReadOnly = True
        Me.ColCCSRecordTime.Width = 80
        '
        'tpgIPDCashPayments
        '
        Me.tpgIPDCashPayments.Controls.Add(Me.dgvIPDCashPayments)
        Me.tpgIPDCashPayments.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDCashPayments.Name = "tpgIPDCashPayments"
        Me.tpgIPDCashPayments.Size = New System.Drawing.Size(1008, 358)
        Me.tpgIPDCashPayments.TabIndex = 10
        Me.tpgIPDCashPayments.Text = "IPD Cash Payments"
        Me.tpgIPDCashPayments.UseVisualStyleBackColor = True
        '
        'dgvIPDCashPayments
        '
        Me.dgvIPDCashPayments.AllowUserToAddRows = False
        Me.dgvIPDCashPayments.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIPDCashPayments.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIPDCashPayments.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDCashPayments.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvIPDCashPayments.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIPDCashPayments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDCashPayments.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIPDCashPayments.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIPDReceiptNo, Me.ColIPDVisitDate, Me.ColIPDFullName, Me.ColIPDIncomeCategory, Me.ColIPDTotalAmount, Me.ColIPDPaidAfterDays, Me.ColIPDRecordDate, Me.ColIPDRecordTime})
        Me.dgvIPDCashPayments.ContextMenuStrip = Me.cmsIncomeSummaries
        DataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle46.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle46.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle46.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle46.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPDCashPayments.DefaultCellStyle = DataGridViewCellStyle46
        Me.dgvIPDCashPayments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPDCashPayments.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDCashPayments.Location = New System.Drawing.Point(0, 0)
        Me.dgvIPDCashPayments.Name = "dgvIPDCashPayments"
        Me.dgvIPDCashPayments.ReadOnly = True
        Me.dgvIPDCashPayments.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle47.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle47.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle47.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle47.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDCashPayments.RowHeadersDefaultCellStyle = DataGridViewCellStyle47
        Me.dgvIPDCashPayments.RowHeadersVisible = False
        Me.dgvIPDCashPayments.Size = New System.Drawing.Size(1008, 358)
        Me.dgvIPDCashPayments.TabIndex = 22
        Me.dgvIPDCashPayments.Text = "DataGridView1"
        '
        'ColIPDReceiptNo
        '
        Me.ColIPDReceiptNo.DataPropertyName = "ReceiptNo"
        Me.ColIPDReceiptNo.HeaderText = "Receipt No"
        Me.ColIPDReceiptNo.Name = "ColIPDReceiptNo"
        Me.ColIPDReceiptNo.ReadOnly = True
        '
        'ColIPDVisitDate
        '
        Me.ColIPDVisitDate.DataPropertyName = "VisitDate"
        Me.ColIPDVisitDate.HeaderText = "Visit Date"
        Me.ColIPDVisitDate.Name = "ColIPDVisitDate"
        Me.ColIPDVisitDate.ReadOnly = True
        '
        'ColIPDFullName
        '
        Me.ColIPDFullName.DataPropertyName = "FullName"
        Me.ColIPDFullName.HeaderText = "Full Name"
        Me.ColIPDFullName.Name = "ColIPDFullName"
        Me.ColIPDFullName.ReadOnly = True
        Me.ColIPDFullName.Width = 180
        '
        'ColIPDIncomeCategory
        '
        Me.ColIPDIncomeCategory.DataPropertyName = "IncomeCategory"
        Me.ColIPDIncomeCategory.HeaderText = "Income Category"
        Me.ColIPDIncomeCategory.Name = "ColIPDIncomeCategory"
        Me.ColIPDIncomeCategory.ReadOnly = True
        Me.ColIPDIncomeCategory.Width = 150
        '
        'ColIPDTotalAmount
        '
        Me.ColIPDTotalAmount.DataPropertyName = "TotalAmount"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColIPDTotalAmount.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColIPDTotalAmount.HeaderText = "Total Amount"
        Me.ColIPDTotalAmount.Name = "ColIPDTotalAmount"
        Me.ColIPDTotalAmount.ReadOnly = True
        '
        'ColIPDPaidAfterDays
        '
        Me.ColIPDPaidAfterDays.DataPropertyName = "PaidAfterDays"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColIPDPaidAfterDays.DefaultCellStyle = DataGridViewCellStyle34
        Me.ColIPDPaidAfterDays.HeaderText = "Paid After (Days)"
        Me.ColIPDPaidAfterDays.Name = "ColIPDPaidAfterDays"
        Me.ColIPDPaidAfterDays.ReadOnly = True
        '
        'ColIPDRecordDate
        '
        Me.ColIPDRecordDate.DataPropertyName = "RecordDate"
        Me.ColIPDRecordDate.HeaderText = "Record Date"
        Me.ColIPDRecordDate.Name = "ColIPDRecordDate"
        Me.ColIPDRecordDate.ReadOnly = True
        '
        'ColIPDRecordTime
        '
        Me.ColIPDRecordTime.DataPropertyName = "RecordTime"
        Me.ColIPDRecordTime.HeaderText = "Record Time"
        Me.ColIPDRecordTime.Name = "ColIPDRecordTime"
        Me.ColIPDRecordTime.ReadOnly = True
        Me.ColIPDRecordTime.Width = 80
        '
        'tpgIPDCreditBillsPayment
        '
        Me.tpgIPDCreditBillsPayment.Controls.Add(Me.dgvIPDCreditBillPayment)
        Me.tpgIPDCreditBillsPayment.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDCreditBillsPayment.Name = "tpgIPDCreditBillsPayment"
        Me.tpgIPDCreditBillsPayment.Size = New System.Drawing.Size(1008, 358)
        Me.tpgIPDCreditBillsPayment.TabIndex = 11
        Me.tpgIPDCreditBillsPayment.Text = "IPD Credit Bills Payment"
        Me.tpgIPDCreditBillsPayment.UseVisualStyleBackColor = True
        '
        'dgvIPDCreditBillPayment
        '
        Me.dgvIPDCreditBillPayment.AllowUserToAddRows = False
        Me.dgvIPDCreditBillPayment.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIPDCreditBillPayment.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvIPDCreditBillPayment.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDCreditBillPayment.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvIPDCreditBillPayment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIPDCreditBillPayment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDCreditBillPayment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvIPDCreditBillPayment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIPDCreditBillVisitNo, Me.ColIPDCreditBillVisitDate, Me.ColIPDCreditBillFullName, Me.ColIPDCreditBillIncomeCategory, Me.ColIPDCreditBillTotalAmount, Me.ColIPDCreditBillRecordDate, Me.ColIPDCreditBillRecordTime})
        Me.dgvIPDCreditBillPayment.ContextMenuStrip = Me.cmsIncomeSummaries
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPDCreditBillPayment.DefaultCellStyle = DataGridViewCellStyle36
        Me.dgvIPDCreditBillPayment.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPDCreditBillPayment.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDCreditBillPayment.Location = New System.Drawing.Point(0, 0)
        Me.dgvIPDCreditBillPayment.Name = "dgvIPDCreditBillPayment"
        Me.dgvIPDCreditBillPayment.ReadOnly = True
        Me.dgvIPDCreditBillPayment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle48.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle48.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle48.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle48.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle48.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle48.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDCreditBillPayment.RowHeadersDefaultCellStyle = DataGridViewCellStyle48
        Me.dgvIPDCreditBillPayment.RowHeadersVisible = False
        Me.dgvIPDCreditBillPayment.Size = New System.Drawing.Size(1008, 358)
        Me.dgvIPDCreditBillPayment.TabIndex = 23
        Me.dgvIPDCreditBillPayment.Text = "DataGridView1"
        '
        'ColIPDCreditBillVisitNo
        '
        Me.ColIPDCreditBillVisitNo.DataPropertyName = "VisitNo"
        Me.ColIPDCreditBillVisitNo.HeaderText = "Visit No"
        Me.ColIPDCreditBillVisitNo.Name = "ColIPDCreditBillVisitNo"
        Me.ColIPDCreditBillVisitNo.ReadOnly = True
        '
        'ColIPDCreditBillVisitDate
        '
        Me.ColIPDCreditBillVisitDate.DataPropertyName = "VisitDate"
        Me.ColIPDCreditBillVisitDate.HeaderText = "Visit Date"
        Me.ColIPDCreditBillVisitDate.Name = "ColIPDCreditBillVisitDate"
        Me.ColIPDCreditBillVisitDate.ReadOnly = True
        '
        'ColIPDCreditBillFullName
        '
        Me.ColIPDCreditBillFullName.DataPropertyName = "FullName"
        Me.ColIPDCreditBillFullName.HeaderText = "Full Name"
        Me.ColIPDCreditBillFullName.Name = "ColIPDCreditBillFullName"
        Me.ColIPDCreditBillFullName.ReadOnly = True
        Me.ColIPDCreditBillFullName.Width = 180
        '
        'ColIPDCreditBillIncomeCategory
        '
        Me.ColIPDCreditBillIncomeCategory.DataPropertyName = "IncomeCategory"
        Me.ColIPDCreditBillIncomeCategory.HeaderText = "Income Category"
        Me.ColIPDCreditBillIncomeCategory.Name = "ColIPDCreditBillIncomeCategory"
        Me.ColIPDCreditBillIncomeCategory.ReadOnly = True
        Me.ColIPDCreditBillIncomeCategory.Width = 150
        '
        'ColIPDCreditBillTotalAmount
        '
        Me.ColIPDCreditBillTotalAmount.DataPropertyName = "TotalAmount"
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ColIPDCreditBillTotalAmount.DefaultCellStyle = DataGridViewCellStyle35
        Me.ColIPDCreditBillTotalAmount.HeaderText = "Total Amount"
        Me.ColIPDCreditBillTotalAmount.Name = "ColIPDCreditBillTotalAmount"
        Me.ColIPDCreditBillTotalAmount.ReadOnly = True
        '
        'ColIPDCreditBillRecordDate
        '
        Me.ColIPDCreditBillRecordDate.DataPropertyName = "RecordDate"
        Me.ColIPDCreditBillRecordDate.HeaderText = "Record Date"
        Me.ColIPDCreditBillRecordDate.Name = "ColIPDCreditBillRecordDate"
        Me.ColIPDCreditBillRecordDate.ReadOnly = True
        '
        'ColIPDCreditBillRecordTime
        '
        Me.ColIPDCreditBillRecordTime.DataPropertyName = "RecordTime"
        Me.ColIPDCreditBillRecordTime.HeaderText = "Record Time"
        Me.ColIPDCreditBillRecordTime.Name = "ColIPDCreditBillRecordTime"
        Me.ColIPDCreditBillRecordTime.ReadOnly = True
        Me.ColIPDCreditBillRecordTime.Width = 80
        '
        'tpgSupplierHistory
        '
        Me.tpgSupplierHistory.Controls.Add(Me.stbAmountWords)
        Me.tpgSupplierHistory.Controls.Add(Me.lblTotalAmount)
        Me.tpgSupplierHistory.Controls.Add(Me.lblAmountWords)
        Me.tpgSupplierHistory.Controls.Add(Me.stbTotalAmount)
        Me.tpgSupplierHistory.Controls.Add(Me.dgvSupplierHistory)
        Me.tpgSupplierHistory.Location = New System.Drawing.Point(4, 22)
        Me.tpgSupplierHistory.Name = "tpgSupplierHistory"
        Me.tpgSupplierHistory.Size = New System.Drawing.Size(1008, 358)
        Me.tpgSupplierHistory.TabIndex = 12
        Me.tpgSupplierHistory.Text = "Supplier History"
        Me.tpgSupplierHistory.UseVisualStyleBackColor = True
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(939, 484)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(79, 24)
        Me.fbnClose.TabIndex = 7
        Me.fbnClose.Text = "Close"
        '
        'stbAmountWords
        '
        Me.stbAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = False
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(532, 317)
        Me.stbAmountWords.MaxLength = 100
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(473, 39)
        Me.stbAmountWords.TabIndex = 95
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAmount.Location = New System.Drawing.Point(8, 322)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(124, 20)
        Me.lblTotalAmount.TabIndex = 92
        Me.lblTotalAmount.Text = "Total Net Amount"
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAmountWords.Location = New System.Drawing.Point(382, 322)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(144, 21)
        Me.lblAmountWords.TabIndex = 94
        Me.lblAmountWords.Text = "Amount in Words"
        '
        'stbTotalAmount
        '
        Me.stbTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalAmount.CapitalizeFirstLetter = False
        Me.stbTotalAmount.Enabled = False
        Me.stbTotalAmount.EntryErrorMSG = ""
        Me.stbTotalAmount.Location = New System.Drawing.Point(135, 320)
        Me.stbTotalAmount.MaxLength = 20
        Me.stbTotalAmount.Name = "stbTotalAmount"
        Me.stbTotalAmount.RegularExpression = ""
        Me.stbTotalAmount.Size = New System.Drawing.Size(206, 20)
        Me.stbTotalAmount.TabIndex = 93
        Me.stbTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvSupplierHistory
        '
        Me.dgvSupplierHistory.AllowUserToAddRows = False
        Me.dgvSupplierHistory.AllowUserToDeleteRows = False
        Me.dgvSupplierHistory.AllowUserToOrderColumns = True
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvSupplierHistory.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvSupplierHistory.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSupplierHistory.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvSupplierHistory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSupplierHistory.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSupplierHistory.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSupplierHistory.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvSupplierHistory.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSupplierNo, Me.colSupplierName, Me.colPhoneNo, Me.colItemCategory, Me.colItemCode, Me.colItemName, Me.colTotalReceived, Me.colQuantityReturned, Me.colRate, Me.colVATValue, Me.colTotalAmount, Me.colReturnAmont, Me.colNetAmount, Me.colRecordDateTime, Me.colLoginID})
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSupplierHistory.DefaultCellStyle = DataGridViewCellStyle37
        Me.dgvSupplierHistory.EnableHeadersVisualStyles = False
        Me.dgvSupplierHistory.GridColor = System.Drawing.Color.Khaki
        Me.dgvSupplierHistory.Location = New System.Drawing.Point(5, 3)
        Me.dgvSupplierHistory.Name = "dgvSupplierHistory"
        Me.dgvSupplierHistory.ReadOnly = True
        Me.dgvSupplierHistory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle49.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle49.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSupplierHistory.RowHeadersDefaultCellStyle = DataGridViewCellStyle49
        Me.dgvSupplierHistory.RowHeadersVisible = False
        Me.dgvSupplierHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSupplierHistory.Size = New System.Drawing.Size(1000, 308)
        Me.dgvSupplierHistory.TabIndex = 91
        Me.dgvSupplierHistory.Text = "DataGridView1"
        '
        'colSupplierNo
        '
        Me.colSupplierNo.DataPropertyName = "SupplierNo"
        Me.colSupplierNo.HeaderText = "Supplier No"
        Me.colSupplierNo.Name = "colSupplierNo"
        Me.colSupplierNo.ReadOnly = True
        '
        'colSupplierName
        '
        Me.colSupplierName.DataPropertyName = "SupplierName"
        Me.colSupplierName.HeaderText = "Supplier Name"
        Me.colSupplierName.Name = "colSupplierName"
        Me.colSupplierName.ReadOnly = True
        Me.colSupplierName.Width = 120
        '
        'colPhoneNo
        '
        Me.colPhoneNo.DataPropertyName = "Phone"
        Me.colPhoneNo.HeaderText = "Phone No"
        Me.colPhoneNo.Name = "colPhoneNo"
        Me.colPhoneNo.ReadOnly = True
        Me.colPhoneNo.Visible = False
        Me.colPhoneNo.Width = 80
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        Me.colItemCategory.HeaderText = "Item Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        '
        'colTotalReceived
        '
        Me.colTotalReceived.DataPropertyName = "TotalReceived"
        Me.colTotalReceived.HeaderText = "Quantity Received"
        Me.colTotalReceived.Name = "colTotalReceived"
        Me.colTotalReceived.ReadOnly = True
        '
        'colQuantityReturned
        '
        Me.colQuantityReturned.DataPropertyName = "ReturnQuantity"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colQuantityReturned.DefaultCellStyle = DataGridViewCellStyle17
        Me.colQuantityReturned.HeaderText = "Quantity Returned"
        Me.colQuantityReturned.Name = "colQuantityReturned"
        Me.colQuantityReturned.ReadOnly = True
        '
        'colRate
        '
        Me.colRate.DataPropertyName = "Rate"
        Me.colRate.HeaderText = "Rate"
        Me.colRate.Name = "colRate"
        Me.colRate.ReadOnly = True
        Me.colRate.Width = 80
        '
        'colVATValue
        '
        Me.colVATValue.DataPropertyName = "VATValue"
        Me.colVATValue.HeaderText = "VAT VAlue"
        Me.colVATValue.Name = "colVATValue"
        Me.colVATValue.ReadOnly = True
        Me.colVATValue.Width = 80
        '
        'colTotalAmount
        '
        Me.colTotalAmount.DataPropertyName = "TotalReceivedAmount"
        Me.colTotalAmount.HeaderText = "Total Amount"
        Me.colTotalAmount.Name = "colTotalAmount"
        Me.colTotalAmount.ReadOnly = True
        '
        'colReturnAmont
        '
        Me.colReturnAmont.DataPropertyName = "ReturnAmount"
        Me.colReturnAmont.HeaderText = "Return Amount"
        Me.colReturnAmont.Name = "colReturnAmont"
        Me.colReturnAmont.ReadOnly = True
        '
        'colNetAmount
        '
        Me.colNetAmount.DataPropertyName = "NetAmount"
        Me.colNetAmount.HeaderText = "Net Amount"
        Me.colNetAmount.Name = "colNetAmount"
        Me.colNetAmount.ReadOnly = True
        '
        'colRecordDateTime
        '
        Me.colRecordDateTime.DataPropertyName = "RecordDateTime"
        Me.colRecordDateTime.HeaderText = "Record Date Time"
        Me.colRecordDateTime.Name = "colRecordDateTime"
        Me.colRecordDateTime.ReadOnly = True
        '
        'colLoginID
        '
        Me.colLoginID.DataPropertyName = "LoginID"
        Me.colLoginID.HeaderText = "Login ID"
        Me.colLoginID.Name = "colLoginID"
        Me.colLoginID.ReadOnly = True
        Me.colLoginID.Width = 80
        '
        'frmConsolidatedFinancialReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1034, 516)
        Me.Controls.Add(Me.grpPeriod)
        Me.Controls.Add(Me.tbcPeriodicReport)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsolidatedFinancialReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consolidated Financial Report"
        Me.grpPeriod.ResumeLayout(False)
        Me.cmsIncomeSummaries.ResumeLayout(False)
        CType(Me.dgvIncomePaymentDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgIncomePaymentDetails.ResumeLayout(False)
        Me.tbcPeriodicReport.ResumeLayout(False)
        Me.tpgCreditCashSales.ResumeLayout(False)
        CType(Me.dgvCreditCashSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgIPDCashPayments.ResumeLayout(False)
        CType(Me.dgvIPDCashPayments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgIPDCreditBillsPayment.ResumeLayout(False)
        CType(Me.dgvIPDCreditBillPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgSupplierHistory.ResumeLayout(False)
        Me.tpgSupplierHistory.PerformLayout()
        CType(Me.dgvSupplierHistory, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents cmsIncomeSummaries As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsIncomeSummariesCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsIncomeSummariesSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colPaymentDetailsFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaymentDetailsVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaymentDetailsReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvIncomePaymentDetails As System.Windows.Forms.DataGridView
    Friend WithEvents colIncomePaymentDetailsCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaymentDetailsTotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaymentDetailsPaidAfterDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaymentDetailsRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaymentDetailsRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpgIncomePaymentDetails As System.Windows.Forms.TabPage
    Friend WithEvents tbcPeriodicReport As System.Windows.Forms.TabControl
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tpgIPDCashPayments As System.Windows.Forms.TabPage
    Friend WithEvents dgvIPDCashPayments As System.Windows.Forms.DataGridView
    Friend WithEvents tpgIPDCreditBillsPayment As System.Windows.Forms.TabPage
    Friend WithEvents lblItemCategoryID As System.Windows.Forms.Label
    Friend WithEvents tpgCreditCashSales As System.Windows.Forms.TabPage
    Friend WithEvents tpgSupplierHistory As System.Windows.Forms.TabPage
    Friend WithEvents cboItemCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents dgvCreditCashSales As System.Windows.Forms.DataGridView
    Friend WithEvents colCCSVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCCSVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCCSFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCCSIncomeCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCCSTotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCCSRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCCSRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDIncomeCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDTotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDPaidAfterDays As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvIPDCreditBillPayment As System.Windows.Forms.DataGridView
    Friend WithEvents ColIPDCreditBillVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDCreditBillVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDCreditBillFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDCreditBillIncomeCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDCreditBillTotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDCreditBillRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDCreditBillRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dgvSupplierHistory As System.Windows.Forms.DataGridView
    Friend WithEvents colSupplierNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPhoneNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalReceived As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantityReturned As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVATValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnAmont As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNetAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoginID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
