<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPackageReport
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPackageReport))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tpgIPDReport = New System.Windows.Forms.TabPage()
        Me.dgvCashCollections = New System.Windows.Forms.DataGridView()
        Me.cmsEdit = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsEditCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsEditSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.stbCashAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCashTotalAmount = New System.Windows.Forms.Label()
        Me.lblCashAmountWords = New System.Windows.Forms.Label()
        Me.stbCashTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.tbcCashCollections = New System.Windows.Forms.TabControl()
        Me.tpgOPDReport = New System.Windows.Forms.TabPage()
        Me.dgvBillFormCollections = New System.Windows.Forms.DataGridView()
        Me.colBFPReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBFPVisitsBranch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPPayDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPAmountPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPCurrency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPAmountTendered = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPExchangeRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPChange = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPSendBalanceToAccount = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colBFPUseAccountBalance = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colBFPPayModes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPLoginID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBFPRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbBFPAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBFPTotalAmount = New System.Windows.Forms.Label()
        Me.lblBFPAmountWords = New System.Windows.Forms.Label()
        Me.stbBFPTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGrandTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGrandAmountWords = New System.Windows.Forms.Label()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.fbnRefresh = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.stbGrandAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGrandTotalAmount = New System.Windows.Forms.Label()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmountPaid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashCurrency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSendBalanceToAccount = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colCashLoginID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgIPDReport.SuspendLayout()
        CType(Me.dgvCashCollections, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsEdit.SuspendLayout()
        Me.tbcCashCollections.SuspendLayout()
        Me.tpgOPDReport.SuspendLayout()
        CType(Me.dgvBillFormCollections, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'tpgIPDReport
        '
        Me.tpgIPDReport.Controls.Add(Me.dgvCashCollections)
        Me.tpgIPDReport.Controls.Add(Me.stbCashAmountWords)
        Me.tpgIPDReport.Controls.Add(Me.lblCashTotalAmount)
        Me.tpgIPDReport.Controls.Add(Me.lblCashAmountWords)
        Me.tpgIPDReport.Controls.Add(Me.stbCashTotalAmount)
        Me.tpgIPDReport.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDReport.Name = "tpgIPDReport"
        Me.tpgIPDReport.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgIPDReport.Size = New System.Drawing.Size(998, 391)
        Me.tpgIPDReport.TabIndex = 0
        Me.tpgIPDReport.Tag = ""
        Me.tpgIPDReport.Text = "OPD Report"
        Me.tpgIPDReport.UseVisualStyleBackColor = True
        '
        'dgvCashCollections
        '
        Me.dgvCashCollections.AllowUserToAddRows = False
        Me.dgvCashCollections.AllowUserToDeleteRows = False
        Me.dgvCashCollections.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvCashCollections.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCashCollections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCashCollections.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvCashCollections.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCashCollections.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvCashCollections.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCashCollections.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvCashCollections.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVisitNo, Me.colVisitDate, Me.colPatientNo, Me.colFullName, Me.colGender, Me.colAge, Me.colAmountPaid, Me.colCashCurrency, Me.colSendBalanceToAccount, Me.colCashLoginID, Me.colCashRecordDate, Me.colCashRecordTime})
        Me.dgvCashCollections.ContextMenuStrip = Me.cmsEdit
        Me.dgvCashCollections.EnableHeadersVisualStyles = False
        Me.dgvCashCollections.GridColor = System.Drawing.Color.Khaki
        Me.dgvCashCollections.Location = New System.Drawing.Point(10, 10)
        Me.dgvCashCollections.Name = "dgvCashCollections"
        Me.dgvCashCollections.ReadOnly = True
        Me.dgvCashCollections.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvCashCollections.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvCashCollections.RowHeadersVisible = False
        Me.dgvCashCollections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvCashCollections.Size = New System.Drawing.Size(980, 331)
        Me.dgvCashCollections.TabIndex = 0
        Me.dgvCashCollections.Text = "DataGridView1"
        '
        'cmsEdit
        '
        Me.cmsEdit.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsEdit.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsEditCopy, Me.cmsEditSelectAll})
        Me.cmsEdit.Name = "cmsSearch"
        Me.cmsEdit.Size = New System.Drawing.Size(123, 48)
        '
        'cmsEditCopy
        '
        Me.cmsEditCopy.Enabled = False
        Me.cmsEditCopy.Image = CType(resources.GetObject("cmsEditCopy.Image"), System.Drawing.Image)
        Me.cmsEditCopy.Name = "cmsEditCopy"
        Me.cmsEditCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsEditCopy.Text = "Copy"
        Me.cmsEditCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsEditSelectAll
        '
        Me.cmsEditSelectAll.Enabled = False
        Me.cmsEditSelectAll.Name = "cmsEditSelectAll"
        Me.cmsEditSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsEditSelectAll.Text = "Select All"
        '
        'stbCashAmountWords
        '
        Me.stbCashAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbCashAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbCashAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCashAmountWords.CapitalizeFirstLetter = False
        Me.stbCashAmountWords.EntryErrorMSG = ""
        Me.stbCashAmountWords.Location = New System.Drawing.Point(419, 347)
        Me.stbCashAmountWords.MaxLength = 100
        Me.stbCashAmountWords.Multiline = True
        Me.stbCashAmountWords.Name = "stbCashAmountWords"
        Me.stbCashAmountWords.ReadOnly = True
        Me.stbCashAmountWords.RegularExpression = ""
        Me.stbCashAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCashAmountWords.Size = New System.Drawing.Size(377, 39)
        Me.stbCashAmountWords.TabIndex = 4
        '
        'lblCashTotalAmount
        '
        Me.lblCashTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCashTotalAmount.Location = New System.Drawing.Point(6, 364)
        Me.lblCashTotalAmount.Name = "lblCashTotalAmount"
        Me.lblCashTotalAmount.Size = New System.Drawing.Size(84, 20)
        Me.lblCashTotalAmount.TabIndex = 1
        Me.lblCashTotalAmount.Text = "Total Amount"
        '
        'lblCashAmountWords
        '
        Me.lblCashAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblCashAmountWords.Location = New System.Drawing.Point(286, 360)
        Me.lblCashAmountWords.Name = "lblCashAmountWords"
        Me.lblCashAmountWords.Size = New System.Drawing.Size(127, 21)
        Me.lblCashAmountWords.TabIndex = 3
        Me.lblCashAmountWords.Text = "Amount in Words"
        '
        'stbCashTotalAmount
        '
        Me.stbCashTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbCashTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbCashTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCashTotalAmount.CapitalizeFirstLetter = False
        Me.stbCashTotalAmount.Enabled = False
        Me.stbCashTotalAmount.EntryErrorMSG = ""
        Me.stbCashTotalAmount.Location = New System.Drawing.Point(96, 364)
        Me.stbCashTotalAmount.MaxLength = 20
        Me.stbCashTotalAmount.Name = "stbCashTotalAmount"
        Me.stbCashTotalAmount.RegularExpression = ""
        Me.stbCashTotalAmount.Size = New System.Drawing.Size(184, 20)
        Me.stbCashTotalAmount.TabIndex = 2
        Me.stbCashTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tbcCashCollections
        '
        Me.tbcCashCollections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcCashCollections.Controls.Add(Me.tpgIPDReport)
        Me.tbcCashCollections.Controls.Add(Me.tpgOPDReport)
        Me.tbcCashCollections.HotTrack = True
        Me.tbcCashCollections.Location = New System.Drawing.Point(12, 90)
        Me.tbcCashCollections.Name = "tbcCashCollections"
        Me.tbcCashCollections.SelectedIndex = 0
        Me.tbcCashCollections.Size = New System.Drawing.Size(1006, 417)
        Me.tbcCashCollections.TabIndex = 16
        '
        'tpgOPDReport
        '
        Me.tpgOPDReport.Controls.Add(Me.dgvBillFormCollections)
        Me.tpgOPDReport.Controls.Add(Me.stbBFPAmountWords)
        Me.tpgOPDReport.Controls.Add(Me.lblBFPTotalAmount)
        Me.tpgOPDReport.Controls.Add(Me.lblBFPAmountWords)
        Me.tpgOPDReport.Controls.Add(Me.stbBFPTotalAmount)
        Me.tpgOPDReport.Location = New System.Drawing.Point(4, 22)
        Me.tpgOPDReport.Name = "tpgOPDReport"
        Me.tpgOPDReport.Size = New System.Drawing.Size(998, 391)
        Me.tpgOPDReport.TabIndex = 6
        Me.tpgOPDReport.Tag = ""
        Me.tpgOPDReport.Text = "IPD Report"
        Me.tpgOPDReport.UseVisualStyleBackColor = True
        '
        'dgvBillFormCollections
        '
        Me.dgvBillFormCollections.AllowUserToAddRows = False
        Me.dgvBillFormCollections.AllowUserToDeleteRows = False
        Me.dgvBillFormCollections.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvBillFormCollections.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvBillFormCollections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBillFormCollections.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvBillFormCollections.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvBillFormCollections.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvBillFormCollections.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillFormCollections.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvBillFormCollections.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBFPReceiptNo, Me.ColBFPVisitsBranch, Me.colBFPPayDate, Me.colBFPVisitNo, Me.colBFPVisitDate, Me.colBFPPatientNo, Me.colBFPFullName, Me.colBFPGender, Me.colBFPAge, Me.colBFPAmountPaid, Me.colBFPCurrency, Me.colBFPAmountTendered, Me.colBFPExchangeRate, Me.colBFPChange, Me.colBFPSendBalanceToAccount, Me.colBFPUseAccountBalance, Me.colBFPPayModes, Me.colBFPLoginID, Me.colBFPRecordDate, Me.colBFPRecordTime})
        Me.dgvBillFormCollections.ContextMenuStrip = Me.cmsEdit
        Me.dgvBillFormCollections.EnableHeadersVisualStyles = False
        Me.dgvBillFormCollections.GridColor = System.Drawing.Color.Khaki
        Me.dgvBillFormCollections.Location = New System.Drawing.Point(10, 10)
        Me.dgvBillFormCollections.Name = "dgvBillFormCollections"
        Me.dgvBillFormCollections.ReadOnly = True
        Me.dgvBillFormCollections.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillFormCollections.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvBillFormCollections.RowHeadersVisible = False
        Me.dgvBillFormCollections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvBillFormCollections.Size = New System.Drawing.Size(980, 331)
        Me.dgvBillFormCollections.TabIndex = 10
        Me.dgvBillFormCollections.Text = "DataGridView1"
        '
        'colBFPReceiptNo
        '
        Me.colBFPReceiptNo.DataPropertyName = "ReceiptNo"
        Me.colBFPReceiptNo.HeaderText = "Receipt No"
        Me.colBFPReceiptNo.Name = "colBFPReceiptNo"
        Me.colBFPReceiptNo.ReadOnly = True
        Me.colBFPReceiptNo.Width = 70
        '
        'ColBFPVisitsBranch
        '
        Me.ColBFPVisitsBranch.DataPropertyName = "BranchName"
        Me.ColBFPVisitsBranch.HeaderText = "Branch Name"
        Me.ColBFPVisitsBranch.Name = "ColBFPVisitsBranch"
        Me.ColBFPVisitsBranch.ReadOnly = True
        '
        'colBFPPayDate
        '
        Me.colBFPPayDate.DataPropertyName = "PayDate"
        Me.colBFPPayDate.HeaderText = "Pay Date"
        Me.colBFPPayDate.Name = "colBFPPayDate"
        Me.colBFPPayDate.ReadOnly = True
        Me.colBFPPayDate.Width = 80
        '
        'colBFPVisitNo
        '
        Me.colBFPVisitNo.DataPropertyName = "VisitNo"
        Me.colBFPVisitNo.HeaderText = "Visit No"
        Me.colBFPVisitNo.Name = "colBFPVisitNo"
        Me.colBFPVisitNo.ReadOnly = True
        Me.colBFPVisitNo.Width = 80
        '
        'colBFPVisitDate
        '
        Me.colBFPVisitDate.DataPropertyName = "VisitDate"
        Me.colBFPVisitDate.HeaderText = "Visit Date"
        Me.colBFPVisitDate.Name = "colBFPVisitDate"
        Me.colBFPVisitDate.ReadOnly = True
        Me.colBFPVisitDate.Width = 80
        '
        'colBFPPatientNo
        '
        Me.colBFPPatientNo.DataPropertyName = "PatientNo"
        Me.colBFPPatientNo.HeaderText = "Patient No"
        Me.colBFPPatientNo.Name = "colBFPPatientNo"
        Me.colBFPPatientNo.ReadOnly = True
        Me.colBFPPatientNo.Width = 75
        '
        'colBFPFullName
        '
        Me.colBFPFullName.DataPropertyName = "FullName"
        Me.colBFPFullName.HeaderText = "Full Name"
        Me.colBFPFullName.Name = "colBFPFullName"
        Me.colBFPFullName.ReadOnly = True
        Me.colBFPFullName.Width = 120
        '
        'colBFPGender
        '
        Me.colBFPGender.DataPropertyName = "Gender"
        Me.colBFPGender.HeaderText = "Gender"
        Me.colBFPGender.Name = "colBFPGender"
        Me.colBFPGender.ReadOnly = True
        Me.colBFPGender.Width = 50
        '
        'colBFPAge
        '
        Me.colBFPAge.DataPropertyName = "Age"
        Me.colBFPAge.HeaderText = "Age"
        Me.colBFPAge.Name = "colBFPAge"
        Me.colBFPAge.ReadOnly = True
        Me.colBFPAge.Width = 40
        '
        'colBFPAmountPaid
        '
        Me.colBFPAmountPaid.DataPropertyName = "AmountPaid"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colBFPAmountPaid.DefaultCellStyle = DataGridViewCellStyle7
        Me.colBFPAmountPaid.HeaderText = "Total Amount"
        Me.colBFPAmountPaid.Name = "colBFPAmountPaid"
        Me.colBFPAmountPaid.ReadOnly = True
        Me.colBFPAmountPaid.Width = 80
        '
        'colBFPCurrency
        '
        Me.colBFPCurrency.DataPropertyName = "Currency"
        Me.colBFPCurrency.HeaderText = "Pay in Currency"
        Me.colBFPCurrency.Name = "colBFPCurrency"
        Me.colBFPCurrency.ReadOnly = True
        Me.colBFPCurrency.Width = 90
        '
        'colBFPAmountTendered
        '
        Me.colBFPAmountTendered.DataPropertyName = "AmountTendered"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colBFPAmountTendered.DefaultCellStyle = DataGridViewCellStyle8
        Me.colBFPAmountTendered.HeaderText = "Amount Tendered"
        Me.colBFPAmountTendered.Name = "colBFPAmountTendered"
        Me.colBFPAmountTendered.ReadOnly = True
        '
        'colBFPExchangeRate
        '
        Me.colBFPExchangeRate.DataPropertyName = "ExchangeRate"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colBFPExchangeRate.DefaultCellStyle = DataGridViewCellStyle9
        Me.colBFPExchangeRate.HeaderText = "Exchange Rate"
        Me.colBFPExchangeRate.Name = "colBFPExchangeRate"
        Me.colBFPExchangeRate.ReadOnly = True
        '
        'colBFPChange
        '
        Me.colBFPChange.DataPropertyName = "Change"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colBFPChange.DefaultCellStyle = DataGridViewCellStyle10
        Me.colBFPChange.HeaderText = "Change"
        Me.colBFPChange.Name = "colBFPChange"
        Me.colBFPChange.ReadOnly = True
        Me.colBFPChange.Width = 60
        '
        'colBFPSendBalanceToAccount
        '
        Me.colBFPSendBalanceToAccount.DataPropertyName = "SendBalanceToAccount"
        Me.colBFPSendBalanceToAccount.HeaderText = "Send Balance To Account"
        Me.colBFPSendBalanceToAccount.Name = "colBFPSendBalanceToAccount"
        Me.colBFPSendBalanceToAccount.ReadOnly = True
        Me.colBFPSendBalanceToAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colBFPSendBalanceToAccount.Width = 140
        '
        'colBFPUseAccountBalance
        '
        Me.colBFPUseAccountBalance.DataPropertyName = "UseAccountBalance"
        Me.colBFPUseAccountBalance.HeaderText = "Use Account Balance"
        Me.colBFPUseAccountBalance.Name = "colBFPUseAccountBalance"
        Me.colBFPUseAccountBalance.ReadOnly = True
        Me.colBFPUseAccountBalance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colBFPUseAccountBalance.Width = 120
        '
        'colBFPPayModes
        '
        Me.colBFPPayModes.DataPropertyName = "PayModes"
        Me.colBFPPayModes.HeaderText = "Mode of Payment"
        Me.colBFPPayModes.Name = "colBFPPayModes"
        Me.colBFPPayModes.ReadOnly = True
        '
        'colBFPLoginID
        '
        Me.colBFPLoginID.DataPropertyName = "LoginID"
        Me.colBFPLoginID.HeaderText = "Login ID"
        Me.colBFPLoginID.Name = "colBFPLoginID"
        Me.colBFPLoginID.ReadOnly = True
        Me.colBFPLoginID.Width = 60
        '
        'colBFPRecordDate
        '
        Me.colBFPRecordDate.DataPropertyName = "RecordDate"
        Me.colBFPRecordDate.HeaderText = "Record Date"
        Me.colBFPRecordDate.Name = "colBFPRecordDate"
        Me.colBFPRecordDate.ReadOnly = True
        Me.colBFPRecordDate.Width = 80
        '
        'colBFPRecordTime
        '
        Me.colBFPRecordTime.DataPropertyName = "RecordTime"
        Me.colBFPRecordTime.HeaderText = "Record Time"
        Me.colBFPRecordTime.Name = "colBFPRecordTime"
        Me.colBFPRecordTime.ReadOnly = True
        Me.colBFPRecordTime.Width = 80
        '
        'stbBFPAmountWords
        '
        Me.stbBFPAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbBFPAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBFPAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPAmountWords.CapitalizeFirstLetter = False
        Me.stbBFPAmountWords.EntryErrorMSG = ""
        Me.stbBFPAmountWords.Location = New System.Drawing.Point(419, 347)
        Me.stbBFPAmountWords.MaxLength = 100
        Me.stbBFPAmountWords.Multiline = True
        Me.stbBFPAmountWords.Name = "stbBFPAmountWords"
        Me.stbBFPAmountWords.ReadOnly = True
        Me.stbBFPAmountWords.RegularExpression = ""
        Me.stbBFPAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBFPAmountWords.Size = New System.Drawing.Size(377, 39)
        Me.stbBFPAmountWords.TabIndex = 14
        '
        'lblBFPTotalAmount
        '
        Me.lblBFPTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBFPTotalAmount.Location = New System.Drawing.Point(6, 358)
        Me.lblBFPTotalAmount.Name = "lblBFPTotalAmount"
        Me.lblBFPTotalAmount.Size = New System.Drawing.Size(84, 20)
        Me.lblBFPTotalAmount.TabIndex = 11
        Me.lblBFPTotalAmount.Text = "Total Amount"
        '
        'lblBFPAmountWords
        '
        Me.lblBFPAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblBFPAmountWords.Location = New System.Drawing.Point(286, 360)
        Me.lblBFPAmountWords.Name = "lblBFPAmountWords"
        Me.lblBFPAmountWords.Size = New System.Drawing.Size(127, 21)
        Me.lblBFPAmountWords.TabIndex = 13
        Me.lblBFPAmountWords.Text = "Amount in Words"
        '
        'stbBFPTotalAmount
        '
        Me.stbBFPTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbBFPTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbBFPTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBFPTotalAmount.CapitalizeFirstLetter = False
        Me.stbBFPTotalAmount.Enabled = False
        Me.stbBFPTotalAmount.EntryErrorMSG = ""
        Me.stbBFPTotalAmount.Location = New System.Drawing.Point(96, 358)
        Me.stbBFPTotalAmount.MaxLength = 20
        Me.stbBFPTotalAmount.Name = "stbBFPTotalAmount"
        Me.stbBFPTotalAmount.RegularExpression = ""
        Me.stbBFPTotalAmount.Size = New System.Drawing.Size(184, 20)
        Me.stbBFPTotalAmount.TabIndex = 12
        Me.stbBFPTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbGrandTotalAmount
        '
        Me.stbGrandTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbGrandTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbGrandTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGrandTotalAmount.CapitalizeFirstLetter = False
        Me.stbGrandTotalAmount.Enabled = False
        Me.stbGrandTotalAmount.EntryErrorMSG = ""
        Me.stbGrandTotalAmount.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbGrandTotalAmount.Location = New System.Drawing.Point(113, 520)
        Me.stbGrandTotalAmount.MaxLength = 20
        Me.stbGrandTotalAmount.Name = "stbGrandTotalAmount"
        Me.stbGrandTotalAmount.RegularExpression = ""
        Me.stbGrandTotalAmount.Size = New System.Drawing.Size(184, 22)
        Me.stbGrandTotalAmount.TabIndex = 11
        Me.stbGrandTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblGrandAmountWords
        '
        Me.lblGrandAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGrandAmountWords.Location = New System.Drawing.Point(306, 522)
        Me.lblGrandAmountWords.Name = "lblGrandAmountWords"
        Me.lblGrandAmountWords.Size = New System.Drawing.Size(124, 21)
        Me.lblGrandAmountWords.TabIndex = 12
        Me.lblGrandAmountWords.Text = "Grand Total in Words"
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.cboLoginID)
        Me.grpSetParameters.Controls.Add(Me.fbnRefresh)
        Me.grpSetParameters.Controls.Add(Me.fbnExport)
        Me.grpSetParameters.Controls.Add(Me.lblLoginID)
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(12, 1)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(1006, 83)
        Me.grpSetParameters.TabIndex = 9
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Subscription Period"
        '
        'cboLoginID
        '
        Me.cboLoginID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLoginID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLoginID.BackColor = System.Drawing.SystemColors.Window
        Me.cboLoginID.DropDownWidth = 203
        Me.cboLoginID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLoginID.FormattingEnabled = True
        Me.cboLoginID.ItemHeight = 13
        Me.cboLoginID.Location = New System.Drawing.Point(298, 51)
        Me.cboLoginID.MaxLength = 20
        Me.cboLoginID.Name = "cboLoginID"
        Me.cboLoginID.Size = New System.Drawing.Size(203, 21)
        Me.cboLoginID.TabIndex = 3
        '
        'fbnRefresh
        '
        Me.fbnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnRefresh.Location = New System.Drawing.Point(840, 49)
        Me.fbnRefresh.Name = "fbnRefresh"
        Me.fbnRefresh.Size = New System.Drawing.Size(74, 22)
        Me.fbnRefresh.TabIndex = 5
        Me.fbnRefresh.Text = "&Refresh"
        '
        'fbnExport
        '
        Me.fbnExport.Enabled = False
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(920, 49)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(74, 22)
        Me.fbnExport.TabIndex = 6
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(18, 51)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(274, 20)
        Me.lblLoginID.TabIndex = 2
        Me.lblLoginID.Text = "Package Name (Leave blank or use ‘*’ for all)"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblStartDateTime)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblEndDateTime)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 15)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(700, 31)
        Me.pnlPeriod.TabIndex = 0
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(502, 5)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDateTime.TabIndex = 3
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(10, 5)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(137, 20)
        Me.lblStartDateTime.TabIndex = 0
        Me.lblStartDateTime.Text = "Start Record Date && Time"
        Me.lblStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(153, 5)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpStartDateTime.TabIndex = 1
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(357, 5)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(139, 20)
        Me.lblEndDateTime.TabIndex = 2
        Me.lblEndDateTime.Text = "End Record Date && Time"
        Me.lblEndDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(711, 15)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(283, 13)
        Me.lblRecordsNo.TabIndex = 1
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(760, 49)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(74, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "&Load"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(942, 513)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 15
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(864, 513)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 14
        Me.btnPrint.Text = "&Print"
        '
        'stbGrandAmountWords
        '
        Me.stbGrandAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbGrandAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbGrandAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGrandAmountWords.CapitalizeFirstLetter = False
        Me.stbGrandAmountWords.EntryErrorMSG = ""
        Me.stbGrandAmountWords.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbGrandAmountWords.Location = New System.Drawing.Point(436, 516)
        Me.stbGrandAmountWords.MaxLength = 100
        Me.stbGrandAmountWords.Multiline = True
        Me.stbGrandAmountWords.Name = "stbGrandAmountWords"
        Me.stbGrandAmountWords.ReadOnly = True
        Me.stbGrandAmountWords.RegularExpression = ""
        Me.stbGrandAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGrandAmountWords.Size = New System.Drawing.Size(377, 30)
        Me.stbGrandAmountWords.TabIndex = 13
        '
        'lblGrandTotalAmount
        '
        Me.lblGrandTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblGrandTotalAmount.Location = New System.Drawing.Point(26, 520)
        Me.lblGrandTotalAmount.Name = "lblGrandTotalAmount"
        Me.lblGrandTotalAmount.Size = New System.Drawing.Size(81, 20)
        Me.lblGrandTotalAmount.TabIndex = 10
        Me.lblGrandTotalAmount.Text = "Grand Total"
        '
        'colVisitNo
        '
        Me.colVisitNo.DataPropertyName = "VisitNo"
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        Me.colVisitNo.Width = 80
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 80
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        Me.colPatientNo.Width = 75
        '
        'colFullName
        '
        Me.colFullName.DataPropertyName = "FullName"
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        Me.colFullName.Width = 120
        '
        'colGender
        '
        Me.colGender.DataPropertyName = "Gender"
        Me.colGender.HeaderText = "Gender"
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 50
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        Me.colAge.HeaderText = "Age"
        Me.colAge.Name = "colAge"
        Me.colAge.ReadOnly = True
        Me.colAge.Width = 40
        '
        'colAmountPaid
        '
        Me.colAmountPaid.DataPropertyName = "AmountPaid"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colAmountPaid.DefaultCellStyle = DataGridViewCellStyle3
        Me.colAmountPaid.HeaderText = "Package Amount"
        Me.colAmountPaid.Name = "colAmountPaid"
        Me.colAmountPaid.ReadOnly = True
        Me.colAmountPaid.Width = 120
        '
        'colCashCurrency
        '
        Me.colCashCurrency.DataPropertyName = "Currency"
        Me.colCashCurrency.HeaderText = "Amount Paid"
        Me.colCashCurrency.Name = "colCashCurrency"
        Me.colCashCurrency.ReadOnly = True
        Me.colCashCurrency.Width = 120
        '
        'colSendBalanceToAccount
        '
        Me.colSendBalanceToAccount.DataPropertyName = "SendBalanceToAccount"
        Me.colSendBalanceToAccount.HeaderText = "Send Balance To Account"
        Me.colSendBalanceToAccount.Name = "colSendBalanceToAccount"
        Me.colSendBalanceToAccount.ReadOnly = True
        Me.colSendBalanceToAccount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSendBalanceToAccount.Width = 140
        '
        'colCashLoginID
        '
        Me.colCashLoginID.DataPropertyName = "LoginID"
        Me.colCashLoginID.HeaderText = "Login ID"
        Me.colCashLoginID.Name = "colCashLoginID"
        Me.colCashLoginID.ReadOnly = True
        Me.colCashLoginID.Width = 60
        '
        'colCashRecordDate
        '
        Me.colCashRecordDate.DataPropertyName = "RecordDate"
        Me.colCashRecordDate.HeaderText = "Record Date"
        Me.colCashRecordDate.Name = "colCashRecordDate"
        Me.colCashRecordDate.ReadOnly = True
        Me.colCashRecordDate.Width = 80
        '
        'colCashRecordTime
        '
        Me.colCashRecordTime.DataPropertyName = "RecordTime"
        Me.colCashRecordTime.HeaderText = "Record Time"
        Me.colCashRecordTime.Name = "colCashRecordTime"
        Me.colCashRecordTime.ReadOnly = True
        Me.colCashRecordTime.Width = 80
        '
        'frmPackageReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 561)
        Me.Controls.Add(Me.tbcCashCollections)
        Me.Controls.Add(Me.stbGrandTotalAmount)
        Me.Controls.Add(Me.lblGrandAmountWords)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.stbGrandAmountWords)
        Me.Controls.Add(Me.lblGrandTotalAmount)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPackageReport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Packages Report"
        Me.tpgIPDReport.ResumeLayout(False)
        Me.tpgIPDReport.PerformLayout()
        CType(Me.dgvCashCollections, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsEdit.ResumeLayout(False)
        Me.tbcCashCollections.ResumeLayout(False)
        Me.tpgOPDReport.ResumeLayout(False)
        Me.tpgOPDReport.PerformLayout()
        CType(Me.dgvBillFormCollections, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tpgIPDReport As System.Windows.Forms.TabPage
    Friend WithEvents dgvCashCollections As System.Windows.Forms.DataGridView
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmountPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCashCurrency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSendBalanceToAccount As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colCashLoginID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCashRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCashRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsEdit As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsEditCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsEditSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbCashAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCashTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblCashAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbCashTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents tbcCashCollections As System.Windows.Forms.TabControl
    Friend WithEvents tpgOPDReport As System.Windows.Forms.TabPage
    Friend WithEvents dgvBillFormCollections As System.Windows.Forms.DataGridView
    Friend WithEvents colBFPReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBFPVisitsBranch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPPayDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPAmountPaid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPCurrency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPAmountTendered As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPExchangeRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPChange As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPSendBalanceToAccount As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colBFPUseAccountBalance As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colBFPPayModes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPLoginID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBFPRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stbBFPAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBFPTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblBFPAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbBFPTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGrandTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGrandAmountWords As System.Windows.Forms.Label
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents fbnRefresh As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDateTime As System.Windows.Forms.Label
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDateTime As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents stbGrandAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGrandTotalAmount As System.Windows.Forms.Label
End Class
