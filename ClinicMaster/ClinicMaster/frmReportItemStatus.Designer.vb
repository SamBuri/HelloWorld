<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReportItemStatus
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReportItemStatus))
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboBillModeID = New System.Windows.Forms.ComboBox()
        Me.cboItemCategoryID = New System.Windows.Forms.ComboBox()
        Me.lblItemCategory = New System.Windows.Forms.Label()
        Me.fbnReportOperations = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboPayStatusID = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.cboItemStatusID = New System.Windows.Forms.ComboBox()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.tbcReportOperation = New System.Windows.Forms.TabControl()
        Me.tpgOPDItemsStatus = New System.Windows.Forms.TabPage()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblExpenditureTotalAmount = New System.Windows.Forms.Label()
        Me.lblExpenditureAmountWords = New System.Windows.Forms.Label()
        Me.stbTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dgvOPDItemsStatus = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOPDUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOPDTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOPDBillMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOPDOfferedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOfferingMachine = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgIPDItemStatus = New System.Windows.Forms.TabPage()
        Me.StbIPDAmountInWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.stbIPDTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dgvIPDItemsStatus = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.tbcReportOperation.SuspendLayout()
        Me.tpgOPDItemsStatus.SuspendLayout()
        CType(Me.dgvOPDItemsStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgIPDItemStatus.SuspendLayout()
        CType(Me.dgvIPDItemsStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Location = New System.Drawing.Point(7, 6)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(1141, 95)
        Me.grpSetParameters.TabIndex = 5
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Collection Period"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.lblRecordsNo)
        Me.pnlPeriod.Controls.Add(Me.Label3)
        Me.pnlPeriod.Controls.Add(Me.cboBillModeID)
        Me.pnlPeriod.Controls.Add(Me.cboItemCategoryID)
        Me.pnlPeriod.Controls.Add(Me.lblItemCategory)
        Me.pnlPeriod.Controls.Add(Me.fbnReportOperations)
        Me.pnlPeriod.Controls.Add(Me.Label2)
        Me.pnlPeriod.Controls.Add(Me.cboPayStatusID)
        Me.pnlPeriod.Controls.Add(Me.Label1)
        Me.pnlPeriod.Controls.Add(Me.fbnExport)
        Me.pnlPeriod.Controls.Add(Me.cboItemStatusID)
        Me.pnlPeriod.Controls.Add(Me.dtpEndDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblStartDateTime)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblEndDateTime)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 15)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(1130, 73)
        Me.pnlPeriod.TabIndex = 0
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(846, 11)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(269, 23)
        Me.lblRecordsNo.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(424, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(191, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Bill Mode (Leave blank or use ‘*’ for all)"
        '
        'cboBillModeID
        '
        Me.cboBillModeID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillModeID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillModeID.BackColor = System.Drawing.SystemColors.Window
        Me.cboBillModeID.DropDownWidth = 203
        Me.cboBillModeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillModeID.FormattingEnabled = True
        Me.cboBillModeID.ItemHeight = 13
        Me.cboBillModeID.Location = New System.Drawing.Point(644, 49)
        Me.cboBillModeID.MaxLength = 20
        Me.cboBillModeID.Name = "cboBillModeID"
        Me.cboBillModeID.Size = New System.Drawing.Size(189, 21)
        Me.cboBillModeID.TabIndex = 12
        '
        'cboItemCategoryID
        '
        Me.cboItemCategoryID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemCategoryID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemCategoryID.BackColor = System.Drawing.SystemColors.Window
        Me.cboItemCategoryID.DropDownWidth = 203
        Me.cboItemCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCategoryID.FormattingEnabled = True
        Me.cboItemCategoryID.ItemHeight = 13
        Me.cboItemCategoryID.Location = New System.Drawing.Point(229, 25)
        Me.cboItemCategoryID.MaxLength = 20
        Me.cboItemCategoryID.Name = "cboItemCategoryID"
        Me.cboItemCategoryID.Size = New System.Drawing.Size(189, 21)
        Me.cboItemCategoryID.TabIndex = 5
        '
        'lblItemCategory
        '
        Me.lblItemCategory.AutoSize = True
        Me.lblItemCategory.Location = New System.Drawing.Point(8, 29)
        Me.lblItemCategory.Name = "lblItemCategory"
        Me.lblItemCategory.Size = New System.Drawing.Size(213, 13)
        Me.lblItemCategory.TabIndex = 7
        Me.lblItemCategory.Text = "Item Category (Leave blank or use ‘*’ for all)"
        '
        'fbnReportOperations
        '
        Me.fbnReportOperations.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnReportOperations.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnReportOperations.Location = New System.Drawing.Point(849, 45)
        Me.fbnReportOperations.Name = "fbnReportOperations"
        Me.fbnReportOperations.Size = New System.Drawing.Size(74, 22)
        Me.fbnReportOperations.TabIndex = 6
        Me.fbnReportOperations.Text = "&Load"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(199, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Pay Status (Leave blank or use ‘*’ for all)"
        '
        'cboPayStatusID
        '
        Me.cboPayStatusID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPayStatusID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPayStatusID.BackColor = System.Drawing.SystemColors.Window
        Me.cboPayStatusID.DropDownWidth = 203
        Me.cboPayStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPayStatusID.FormattingEnabled = True
        Me.cboPayStatusID.ItemHeight = 13
        Me.cboPayStatusID.Location = New System.Drawing.Point(229, 49)
        Me.cboPayStatusID.MaxLength = 20
        Me.cboPayStatusID.Name = "cboPayStatusID"
        Me.cboPayStatusID.Size = New System.Drawing.Size(189, 21)
        Me.cboPayStatusID.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(424, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Item Status (Leave blank or use ‘*’ for all)"
        '
        'fbnExport
        '
        Me.fbnExport.Enabled = False
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(929, 45)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(74, 22)
        Me.fbnExport.TabIndex = 6
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        '
        'cboItemStatusID
        '
        Me.cboItemStatusID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboItemStatusID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboItemStatusID.BackColor = System.Drawing.SystemColors.Window
        Me.cboItemStatusID.DropDownWidth = 203
        Me.cboItemStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemStatusID.FormattingEnabled = True
        Me.cboItemStatusID.ItemHeight = 13
        Me.cboItemStatusID.Location = New System.Drawing.Point(644, 26)
        Me.cboItemStatusID.MaxLength = 20
        Me.cboItemStatusID.Name = "cboItemStatusID"
        Me.cboItemStatusID.Size = New System.Drawing.Size(189, 21)
        Me.cboItemStatusID.TabIndex = 8
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(644, 4)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDateTime.TabIndex = 3
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(74, 3)
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
        Me.dtpStartDateTime.Location = New System.Drawing.Point(229, 3)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpStartDateTime.TabIndex = 1
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(499, 3)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(139, 20)
        Me.lblEndDateTime.TabIndex = 2
        Me.lblEndDateTime.Text = "End Record Date && Time"
        Me.lblEndDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbcReportOperation
        '
        Me.tbcReportOperation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcReportOperation.Controls.Add(Me.tpgOPDItemsStatus)
        Me.tbcReportOperation.Controls.Add(Me.tpgIPDItemStatus)
        Me.tbcReportOperation.HotTrack = True
        Me.tbcReportOperation.Location = New System.Drawing.Point(7, 107)
        Me.tbcReportOperation.Name = "tbcReportOperation"
        Me.tbcReportOperation.SelectedIndex = 0
        Me.tbcReportOperation.Size = New System.Drawing.Size(1141, 419)
        Me.tbcReportOperation.TabIndex = 6
        '
        'tpgOPDItemsStatus
        '
        Me.tpgOPDItemsStatus.Controls.Add(Me.stbAmountWords)
        Me.tpgOPDItemsStatus.Controls.Add(Me.lblExpenditureTotalAmount)
        Me.tpgOPDItemsStatus.Controls.Add(Me.lblExpenditureAmountWords)
        Me.tpgOPDItemsStatus.Controls.Add(Me.stbTotalAmount)
        Me.tpgOPDItemsStatus.Controls.Add(Me.dgvOPDItemsStatus)
        Me.tpgOPDItemsStatus.Location = New System.Drawing.Point(4, 22)
        Me.tpgOPDItemsStatus.Name = "tpgOPDItemsStatus"
        Me.tpgOPDItemsStatus.Size = New System.Drawing.Size(1133, 393)
        Me.tpgOPDItemsStatus.TabIndex = 13
        Me.tpgOPDItemsStatus.Text = "OPD Items Status"
        Me.tpgOPDItemsStatus.UseVisualStyleBackColor = True
        '
        'stbAmountWords
        '
        Me.stbAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = False
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(445, 345)
        Me.stbAmountWords.MaxLength = 100
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(377, 39)
        Me.stbAmountWords.TabIndex = 16
        '
        'lblExpenditureTotalAmount
        '
        Me.lblExpenditureTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpenditureTotalAmount.Location = New System.Drawing.Point(13, 354)
        Me.lblExpenditureTotalAmount.Name = "lblExpenditureTotalAmount"
        Me.lblExpenditureTotalAmount.Size = New System.Drawing.Size(84, 20)
        Me.lblExpenditureTotalAmount.TabIndex = 13
        Me.lblExpenditureTotalAmount.Text = "Total Amount"
        '
        'lblExpenditureAmountWords
        '
        Me.lblExpenditureAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpenditureAmountWords.Location = New System.Drawing.Point(313, 354)
        Me.lblExpenditureAmountWords.Name = "lblExpenditureAmountWords"
        Me.lblExpenditureAmountWords.Size = New System.Drawing.Size(126, 21)
        Me.lblExpenditureAmountWords.TabIndex = 15
        Me.lblExpenditureAmountWords.Text = "Amount in Words"
        '
        'stbTotalAmount
        '
        Me.stbTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalAmount.CapitalizeFirstLetter = False
        Me.stbTotalAmount.Enabled = False
        Me.stbTotalAmount.EntryErrorMSG = ""
        Me.stbTotalAmount.Location = New System.Drawing.Point(103, 354)
        Me.stbTotalAmount.MaxLength = 20
        Me.stbTotalAmount.Name = "stbTotalAmount"
        Me.stbTotalAmount.RegularExpression = ""
        Me.stbTotalAmount.Size = New System.Drawing.Size(184, 20)
        Me.stbTotalAmount.TabIndex = 14
        Me.stbTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvOPDItemsStatus
        '
        Me.dgvOPDItemsStatus.AllowUserToAddRows = False
        Me.dgvOPDItemsStatus.AllowUserToDeleteRows = False
        Me.dgvOPDItemsStatus.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvOPDItemsStatus.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOPDItemsStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOPDItemsStatus.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOPDItemsStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOPDItemsStatus.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOPDItemsStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDItemsStatus.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOPDItemsStatus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.ColOPDUnitCost, Me.ColOPDTotal, Me.ColOPDBillMode, Me.ColOPDOfferedBy, Me.ColOfferingMachine})
        Me.dgvOPDItemsStatus.EnableHeadersVisualStyles = False
        Me.dgvOPDItemsStatus.GridColor = System.Drawing.Color.Khaki
        Me.dgvOPDItemsStatus.Location = New System.Drawing.Point(3, 3)
        Me.dgvOPDItemsStatus.Name = "dgvOPDItemsStatus"
        Me.dgvOPDItemsStatus.ReadOnly = True
        Me.dgvOPDItemsStatus.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDItemsStatus.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvOPDItemsStatus.RowHeadersVisible = False
        Me.dgvOPDItemsStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOPDItemsStatus.Size = New System.Drawing.Size(1124, 333)
        Me.dgvOPDItemsStatus.TabIndex = 2
        Me.dgvOPDItemsStatus.Text = "DataGridView1"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "VisitNo"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Visit No"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "PatientFullName"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Patient Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Phone"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Phone Number"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "ItemName"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Item Name"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "Quantity"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn5.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn5.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        '
        'ColOPDUnitCost
        '
        Me.ColOPDUnitCost.DataPropertyName = "UnitPrice"
        Me.ColOPDUnitCost.HeaderText = "Unit Price"
        Me.ColOPDUnitCost.Name = "ColOPDUnitCost"
        Me.ColOPDUnitCost.ReadOnly = True
        '
        'ColOPDTotal
        '
        Me.ColOPDTotal.DataPropertyName = "TotalAmount"
        Me.ColOPDTotal.HeaderText = "Total"
        Me.ColOPDTotal.Name = "ColOPDTotal"
        Me.ColOPDTotal.ReadOnly = True
        '
        'ColOPDBillMode
        '
        Me.ColOPDBillMode.DataPropertyName = "BillMode"
        Me.ColOPDBillMode.HeaderText = "Bill Mode"
        Me.ColOPDBillMode.Name = "ColOPDBillMode"
        Me.ColOPDBillMode.ReadOnly = True
        '
        'ColOPDOfferedBy
        '
        Me.ColOPDOfferedBy.DataPropertyName = "Offeredby"
        Me.ColOPDOfferedBy.HeaderText = "Offered By"
        Me.ColOPDOfferedBy.Name = "ColOPDOfferedBy"
        Me.ColOPDOfferedBy.ReadOnly = True
        '
        'ColOfferingMachine
        '
        Me.ColOfferingMachine.DataPropertyName = "CreatorClientMachine"
        Me.ColOfferingMachine.HeaderText = "Client Machine"
        Me.ColOfferingMachine.Name = "ColOfferingMachine"
        Me.ColOfferingMachine.ReadOnly = True
        '
        'tpgIPDItemStatus
        '
        Me.tpgIPDItemStatus.Controls.Add(Me.StbIPDAmountInWords)
        Me.tpgIPDItemStatus.Controls.Add(Me.Label4)
        Me.tpgIPDItemStatus.Controls.Add(Me.Label5)
        Me.tpgIPDItemStatus.Controls.Add(Me.stbIPDTotalAmount)
        Me.tpgIPDItemStatus.Controls.Add(Me.dgvIPDItemsStatus)
        Me.tpgIPDItemStatus.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDItemStatus.Name = "tpgIPDItemStatus"
        Me.tpgIPDItemStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgIPDItemStatus.Size = New System.Drawing.Size(1133, 393)
        Me.tpgIPDItemStatus.TabIndex = 14
        Me.tpgIPDItemStatus.Text = "IPD Item Status"
        Me.tpgIPDItemStatus.UseVisualStyleBackColor = True
        '
        'StbIPDAmountInWords
        '
        Me.StbIPDAmountInWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.StbIPDAmountInWords.BackColor = System.Drawing.SystemColors.Info
        Me.StbIPDAmountInWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StbIPDAmountInWords.CapitalizeFirstLetter = False
        Me.StbIPDAmountInWords.EntryErrorMSG = ""
        Me.StbIPDAmountInWords.Location = New System.Drawing.Point(446, 348)
        Me.StbIPDAmountInWords.MaxLength = 100
        Me.StbIPDAmountInWords.Multiline = True
        Me.StbIPDAmountInWords.Name = "StbIPDAmountInWords"
        Me.StbIPDAmountInWords.ReadOnly = True
        Me.StbIPDAmountInWords.RegularExpression = ""
        Me.StbIPDAmountInWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.StbIPDAmountInWords.Size = New System.Drawing.Size(377, 39)
        Me.StbIPDAmountInWords.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(14, 357)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 20)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Total Amount"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(314, 357)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 21)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Amount in Words"
        '
        'stbIPDTotalAmount
        '
        Me.stbIPDTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbIPDTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbIPDTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbIPDTotalAmount.CapitalizeFirstLetter = False
        Me.stbIPDTotalAmount.Enabled = False
        Me.stbIPDTotalAmount.EntryErrorMSG = ""
        Me.stbIPDTotalAmount.Location = New System.Drawing.Point(104, 357)
        Me.stbIPDTotalAmount.MaxLength = 20
        Me.stbIPDTotalAmount.Name = "stbIPDTotalAmount"
        Me.stbIPDTotalAmount.RegularExpression = ""
        Me.stbIPDTotalAmount.Size = New System.Drawing.Size(184, 20)
        Me.stbIPDTotalAmount.TabIndex = 19
        Me.stbIPDTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvIPDItemsStatus
        '
        Me.dgvIPDItemsStatus.AllowUserToAddRows = False
        Me.dgvIPDItemsStatus.AllowUserToDeleteRows = False
        Me.dgvIPDItemsStatus.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIPDItemsStatus.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvIPDItemsStatus.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvIPDItemsStatus.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDItemsStatus.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIPDItemsStatus.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIPDItemsStatus.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDItemsStatus.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvIPDItemsStatus.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15})
        Me.dgvIPDItemsStatus.EnableHeadersVisualStyles = False
        Me.dgvIPDItemsStatus.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDItemsStatus.Location = New System.Drawing.Point(4, 6)
        Me.dgvIPDItemsStatus.Name = "dgvIPDItemsStatus"
        Me.dgvIPDItemsStatus.ReadOnly = True
        Me.dgvIPDItemsStatus.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDItemsStatus.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvIPDItemsStatus.RowHeadersVisible = False
        Me.dgvIPDItemsStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvIPDItemsStatus.Size = New System.Drawing.Size(1124, 333)
        Me.dgvIPDItemsStatus.TabIndex = 17
        Me.dgvIPDItemsStatus.Text = "DataGridView1"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "VisitNo"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Visit No"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "PatientFullName"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Patient Name"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "Phone"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Phone Number"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "ItemName"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Item Name"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Quantity"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn10.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewTextBoxColumn10.HeaderText = "Quantity"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "UnitPrice"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Unit Price"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "TotalAmount"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "BillMode"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Bill Mode"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Offeredby"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Offered By"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "CreatorClientMachine"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Client Machine"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(1076, 532)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 8
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'frmReportItemStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1158, 566)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.tbcReportOperation)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmReportItemStatus"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Report Item Status"
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.pnlPeriod.PerformLayout()
        Me.tbcReportOperation.ResumeLayout(False)
        Me.tpgOPDItemsStatus.ResumeLayout(False)
        Me.tpgOPDItemsStatus.PerformLayout()
        CType(Me.dgvOPDItemsStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgIPDItemStatus.ResumeLayout(False)
        Me.tpgIPDItemStatus.PerformLayout()
        CType(Me.dgvIPDItemsStatus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents fbnReportOperations As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblItemCategory As System.Windows.Forms.Label
    Friend WithEvents cboItemCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDateTime As System.Windows.Forms.Label
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDateTime As System.Windows.Forms.Label
    Friend WithEvents tbcReportOperation As System.Windows.Forms.TabControl
    Friend WithEvents tpgOPDItemsStatus As System.Windows.Forms.TabPage
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExpenditureTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblExpenditureAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dgvOPDItemsStatus As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOPDUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOPDTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOPDBillMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOPDOfferedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOfferingMachine As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboPayStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboItemStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboBillModeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents tpgIPDItemStatus As System.Windows.Forms.TabPage
    Friend WithEvents StbIPDAmountInWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents stbIPDTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dgvIPDItemsStatus As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
