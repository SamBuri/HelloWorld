<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientAccountStatement
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientAccountStatement))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnPrint = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.cboAccountNo = New System.Windows.Forms.ComboBox()
        Me.cboBillModesID = New System.Windows.Forms.ComboBox()
        Me.lblBillModesID = New System.Windows.Forms.Label()
        Me.stbAccountName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountName = New System.Windows.Forms.Label()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.nbxAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAccountBalance = New System.Windows.Forms.Label()
        Me.fbnLoadStatement = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tbcAccountStatement = New System.Windows.Forms.TabControl()
        Me.tpgAccountStatement = New System.Windows.Forms.TabPage()
        Me.dgvPatientsAccount = New System.Windows.Forms.DataGridView()
        Me.fbnExportTo = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.lblTotalDeposit = New System.Windows.Forms.Label()
        Me.stbTotalDeposit = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBill = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalBill = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.lblOpeningBalance = New System.Windows.Forms.Label()
        Me.nbxAccountOpeningBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.ColRecordDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTransNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBill = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDeposit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcAccountStatement.SuspendLayout()
        Me.tpgAccountStatement.SuspendLayout()
        CType(Me.dgvPatientsAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(850, 434)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 2
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'fbnPrint
        '
        Me.fbnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnPrint.Location = New System.Drawing.Point(15, 434)
        Me.fbnPrint.Name = "fbnPrint"
        Me.fbnPrint.Size = New System.Drawing.Size(70, 24)
        Me.fbnPrint.TabIndex = 17
        Me.fbnPrint.Text = "&Print"
        Me.fbnPrint.UseVisualStyleBackColor = False
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(172, 54)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(183, 20)
        Me.dtpStartDateTime.TabIndex = 5
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(12, 56)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(154, 20)
        Me.lblStartDateTime.TabIndex = 4
        Me.lblStartDateTime.Text = "Start Record Date Time"
        Me.lblStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(172, 76)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(183, 20)
        Me.dtpEndDateTime.TabIndex = 12
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(12, 78)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(135, 20)
        Me.lblEndDateTime.TabIndex = 11
        Me.lblEndDateTime.Text = "End Record Date Time"
        Me.lblEndDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboAccountNo
        '
        Me.cboAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboAccountNo.DropDownWidth = 256
        Me.cboAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountNo.FormattingEnabled = True
        Me.cboAccountNo.ItemHeight = 13
        Me.cboAccountNo.Location = New System.Drawing.Point(172, 31)
        Me.cboAccountNo.Name = "cboAccountNo"
        Me.cboAccountNo.Size = New System.Drawing.Size(183, 21)
        Me.cboAccountNo.TabIndex = 3
        '
        'cboBillModesID
        '
        Me.cboBillModesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillModesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillModesID.FormattingEnabled = True
        Me.cboBillModesID.ItemHeight = 13
        Me.cboBillModesID.Location = New System.Drawing.Point(172, 8)
        Me.cboBillModesID.Name = "cboBillModesID"
        Me.cboBillModesID.Size = New System.Drawing.Size(183, 21)
        Me.cboBillModesID.TabIndex = 1
        '
        'lblBillModesID
        '
        Me.lblBillModesID.Location = New System.Drawing.Point(12, 11)
        Me.lblBillModesID.Name = "lblBillModesID"
        Me.lblBillModesID.Size = New System.Drawing.Size(154, 18)
        Me.lblBillModesID.TabIndex = 0
        Me.lblBillModesID.Text = "Account Category"
        '
        'stbAccountName
        '
        Me.stbAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountName.CapitalizeFirstLetter = True
        Me.stbAccountName.EntryErrorMSG = ""
        Me.stbAccountName.Location = New System.Drawing.Point(589, 8)
        Me.stbAccountName.MaxLength = 60
        Me.stbAccountName.Name = "stbAccountName"
        Me.stbAccountName.ReadOnly = True
        Me.stbAccountName.RegularExpression = ""
        Me.stbAccountName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountName.Size = New System.Drawing.Size(220, 20)
        Me.stbAccountName.TabIndex = 7
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(447, 11)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(134, 18)
        Me.lblAccountName.TabIndex = 6
        Me.lblAccountName.Text = "Account Name"
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(12, 34)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(154, 18)
        Me.lblAccountNo.TabIndex = 2
        Me.lblAccountNo.Text = "Account No"
        '
        'nbxAccountBalance
        '
        Me.nbxAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountBalance.ControlCaption = "Balance"
        Me.nbxAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountBalance.DecimalPlaces = -1
        Me.nbxAccountBalance.Enabled = False
        Me.nbxAccountBalance.Location = New System.Drawing.Point(589, 50)
        Me.nbxAccountBalance.MaxValue = 0.0R
        Me.nbxAccountBalance.MinValue = 0.0R
        Me.nbxAccountBalance.MustEnterNumeric = True
        Me.nbxAccountBalance.Name = "nbxAccountBalance"
        Me.nbxAccountBalance.Size = New System.Drawing.Size(220, 20)
        Me.nbxAccountBalance.TabIndex = 10
        Me.nbxAccountBalance.Value = ""
        '
        'lblAccountBalance
        '
        Me.lblAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblAccountBalance.Location = New System.Drawing.Point(447, 54)
        Me.lblAccountBalance.Name = "lblAccountBalance"
        Me.lblAccountBalance.Size = New System.Drawing.Size(134, 18)
        Me.lblAccountBalance.TabIndex = 8
        Me.lblAccountBalance.Text = "Account Balance"
        '
        'fbnLoadStatement
        '
        Me.fbnLoadStatement.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoadStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoadStatement.Location = New System.Drawing.Point(285, 99)
        Me.fbnLoadStatement.Name = "fbnLoadStatement"
        Me.fbnLoadStatement.Size = New System.Drawing.Size(70, 24)
        Me.fbnLoadStatement.TabIndex = 15
        Me.fbnLoadStatement.Text = "Load"
        '
        'tbcAccountStatement
        '
        Me.tbcAccountStatement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcAccountStatement.Controls.Add(Me.tpgAccountStatement)
        Me.tbcAccountStatement.Location = New System.Drawing.Point(8, 129)
        Me.tbcAccountStatement.Name = "tbcAccountStatement"
        Me.tbcAccountStatement.SelectedIndex = 0
        Me.tbcAccountStatement.Size = New System.Drawing.Size(921, 299)
        Me.tbcAccountStatement.TabIndex = 14
        '
        'tpgAccountStatement
        '
        Me.tpgAccountStatement.Controls.Add(Me.dgvPatientsAccount)
        Me.tpgAccountStatement.Location = New System.Drawing.Point(4, 22)
        Me.tpgAccountStatement.Name = "tpgAccountStatement"
        Me.tpgAccountStatement.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgAccountStatement.Size = New System.Drawing.Size(913, 273)
        Me.tpgAccountStatement.TabIndex = 0
        Me.tpgAccountStatement.Text = "Account Statement"
        Me.tpgAccountStatement.UseVisualStyleBackColor = True
        '
        'dgvPatientsAccount
        '
        Me.dgvPatientsAccount.AllowUserToAddRows = False
        Me.dgvPatientsAccount.AllowUserToDeleteRows = False
        Me.dgvPatientsAccount.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPatientsAccount.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPatientsAccount.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPatientsAccount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPatientsAccount.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPatientsAccount.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientsAccount.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPatientsAccount.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColRecordDateTime, Me.ColName, Me.colTransNo, Me.ColBill, Me.colDeposit, Me.colBalance})
        Me.dgvPatientsAccount.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPatientsAccount.EnableHeadersVisualStyles = False
        Me.dgvPatientsAccount.GridColor = System.Drawing.Color.Khaki
        Me.dgvPatientsAccount.Location = New System.Drawing.Point(3, 3)
        Me.dgvPatientsAccount.Name = "dgvPatientsAccount"
        Me.dgvPatientsAccount.ReadOnly = True
        Me.dgvPatientsAccount.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPatientsAccount.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPatientsAccount.RowHeadersVisible = False
        Me.dgvPatientsAccount.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPatientsAccount.Size = New System.Drawing.Size(907, 267)
        Me.dgvPatientsAccount.TabIndex = 0
        Me.dgvPatientsAccount.Text = "DataGridView1"
        '
        'fbnExportTo
        '
        Me.fbnExportTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnExportTo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExportTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExportTo.Location = New System.Drawing.Point(736, 434)
        Me.fbnExportTo.Name = "fbnExportTo"
        Me.fbnExportTo.Size = New System.Drawing.Size(106, 24)
        Me.fbnExportTo.TabIndex = 0
        Me.fbnExportTo.Text = "Export to Excel..."
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(91, 434)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(87, 24)
        Me.btnPrintPreview.TabIndex = 16
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'lblTotalDeposit
        '
        Me.lblTotalDeposit.ForeColor = System.Drawing.Color.Red
        Me.lblTotalDeposit.Location = New System.Drawing.Point(447, 97)
        Me.lblTotalDeposit.Name = "lblTotalDeposit"
        Me.lblTotalDeposit.Size = New System.Drawing.Size(134, 20)
        Me.lblTotalDeposit.TabIndex = 20
        Me.lblTotalDeposit.Text = "Total Deposit"
        Me.lblTotalDeposit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'stbTotalDeposit
        '
        Me.stbTotalDeposit.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalDeposit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalDeposit.CapitalizeFirstLetter = False
        Me.stbTotalDeposit.Enabled = False
        Me.stbTotalDeposit.EntryErrorMSG = ""
        Me.stbTotalDeposit.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbTotalDeposit.Location = New System.Drawing.Point(589, 93)
        Me.stbTotalDeposit.MaxLength = 20
        Me.stbTotalDeposit.Name = "stbTotalDeposit"
        Me.stbTotalDeposit.RegularExpression = ""
        Me.stbTotalDeposit.Size = New System.Drawing.Size(220, 22)
        Me.stbTotalDeposit.TabIndex = 21
        Me.stbTotalDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBill
        '
        Me.stbBill.BackColor = System.Drawing.SystemColors.Info
        Me.stbBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBill.CapitalizeFirstLetter = False
        Me.stbBill.Enabled = False
        Me.stbBill.EntryErrorMSG = ""
        Me.stbBill.Location = New System.Drawing.Point(589, 72)
        Me.stbBill.MaxLength = 20
        Me.stbBill.Name = "stbBill"
        Me.stbBill.RegularExpression = ""
        Me.stbBill.Size = New System.Drawing.Size(220, 20)
        Me.stbBill.TabIndex = 19
        Me.stbBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTotalBill
        '
        Me.lblTotalBill.ForeColor = System.Drawing.Color.Red
        Me.lblTotalBill.Location = New System.Drawing.Point(447, 73)
        Me.lblTotalBill.Name = "lblTotalBill"
        Me.lblTotalBill.Size = New System.Drawing.Size(134, 20)
        Me.lblTotalBill.TabIndex = 18
        Me.lblTotalBill.Text = "Total Bill"
        Me.lblTotalBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(361, 28)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(70, 24)
        Me.btnLoad.TabIndex = 23
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Patients"
        Me.btnLoad.Visible = False
        '
        'lblOpeningBalance
        '
        Me.lblOpeningBalance.ForeColor = System.Drawing.Color.Red
        Me.lblOpeningBalance.Location = New System.Drawing.Point(449, 28)
        Me.lblOpeningBalance.Name = "lblOpeningBalance"
        Me.lblOpeningBalance.Size = New System.Drawing.Size(134, 20)
        Me.lblOpeningBalance.TabIndex = 24
        Me.lblOpeningBalance.Text = "Opening Balance"
        Me.lblOpeningBalance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'nbxAccountOpeningBalance
        '
        Me.nbxAccountOpeningBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountOpeningBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountOpeningBalance.ControlCaption = "Balance"
        Me.nbxAccountOpeningBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountOpeningBalance.DecimalPlaces = -1
        Me.nbxAccountOpeningBalance.Enabled = False
        Me.nbxAccountOpeningBalance.Location = New System.Drawing.Point(589, 29)
        Me.nbxAccountOpeningBalance.MaxValue = 0.0R
        Me.nbxAccountOpeningBalance.MinValue = 0.0R
        Me.nbxAccountOpeningBalance.MustEnterNumeric = True
        Me.nbxAccountOpeningBalance.Name = "nbxAccountOpeningBalance"
        Me.nbxAccountOpeningBalance.Size = New System.Drawing.Size(220, 20)
        Me.nbxAccountOpeningBalance.TabIndex = 25
        Me.nbxAccountOpeningBalance.Value = ""
        '
        'ColRecordDateTime
        '
        Me.ColRecordDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColRecordDateTime.DataPropertyName = "RecordDate"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.ColRecordDateTime.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColRecordDateTime.HeaderText = "Date"
        Me.ColRecordDateTime.Name = "ColRecordDateTime"
        Me.ColRecordDateTime.ReadOnly = True
        '
        'ColName
        '
        Me.ColName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColName.DataPropertyName = "AccountName"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.ColName.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColName.HeaderText = "Description"
        Me.ColName.Name = "ColName"
        Me.ColName.ReadOnly = True
        '
        'colTransNo
        '
        Me.colTransNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTransNo.DataPropertyName = "TranNo"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colTransNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.colTransNo.HeaderText = "Tran No"
        Me.colTransNo.Name = "colTransNo"
        Me.colTransNo.ReadOnly = True
        '
        'ColBill
        '
        Me.ColBill.DataPropertyName = "Debit"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.ColBill.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColBill.HeaderText = "Bill"
        Me.ColBill.Name = "ColBill"
        Me.ColBill.ReadOnly = True
        '
        'colDeposit
        '
        Me.colDeposit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDeposit.DataPropertyName = "Credit"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colDeposit.DefaultCellStyle = DataGridViewCellStyle7
        Me.colDeposit.HeaderText = "Deposit"
        Me.colDeposit.Name = "colDeposit"
        Me.colDeposit.ReadOnly = True
        '
        'colBalance
        '
        Me.colBalance.DataPropertyName = "Balance"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colBalance.DefaultCellStyle = DataGridViewCellStyle8
        Me.colBalance.HeaderText = "Balance"
        Me.colBalance.Name = "colBalance"
        Me.colBalance.ReadOnly = True
        '
        'frmPatientAccountStatement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(936, 468)
        Me.Controls.Add(Me.nbxAccountOpeningBalance)
        Me.Controls.Add(Me.lblOpeningBalance)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.lblTotalDeposit)
        Me.Controls.Add(Me.stbTotalDeposit)
        Me.Controls.Add(Me.stbBill)
        Me.Controls.Add(Me.lblTotalBill)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.fbnExportTo)
        Me.Controls.Add(Me.tbcAccountStatement)
        Me.Controls.Add(Me.fbnLoadStatement)
        Me.Controls.Add(Me.nbxAccountBalance)
        Me.Controls.Add(Me.lblAccountBalance)
        Me.Controls.Add(Me.cboAccountNo)
        Me.Controls.Add(Me.cboBillModesID)
        Me.Controls.Add(Me.lblBillModesID)
        Me.Controls.Add(Me.stbAccountName)
        Me.Controls.Add(Me.lblAccountName)
        Me.Controls.Add(Me.lblAccountNo)
        Me.Controls.Add(Me.dtpEndDateTime)
        Me.Controls.Add(Me.lblEndDateTime)
        Me.Controls.Add(Me.dtpStartDateTime)
        Me.Controls.Add(Me.lblStartDateTime)
        Me.Controls.Add(Me.fbnPrint)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPatientAccountStatement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Statement"
        Me.tbcAccountStatement.ResumeLayout(false)
        Me.tpgAccountStatement.ResumeLayout(false)
        CType(Me.dgvPatientsAccount,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnPrint As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDateTime As System.Windows.Forms.Label
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDateTime As System.Windows.Forms.Label
    Friend WithEvents cboAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents cboBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillModesID As System.Windows.Forms.Label
    Friend WithEvents stbAccountName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountName As System.Windows.Forms.Label
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents nbxAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAccountBalance As System.Windows.Forms.Label
    Friend WithEvents fbnLoadStatement As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tbcAccountStatement As System.Windows.Forms.TabControl
    Friend WithEvents tpgAccountStatement As System.Windows.Forms.TabPage
    Friend WithEvents dgvPatientsAccount As System.Windows.Forms.DataGridView
    Friend WithEvents fbnExportTo As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents lblTotalDeposit As System.Windows.Forms.Label
    Friend WithEvents stbTotalDeposit As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBill As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalBill As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents lblOpeningBalance As System.Windows.Forms.Label
    Friend WithEvents nbxAccountOpeningBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents ColRecordDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTransNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBill As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDeposit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBalance As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
