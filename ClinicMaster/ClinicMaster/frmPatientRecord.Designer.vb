<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPatientRecord
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPatientRecord))
        Me.tbcAccountStatement = New System.Windows.Forms.TabControl()
        Me.tpgOPDVisits = New System.Windows.Forms.TabPage()
        Me.dgvOPDVisits = New System.Windows.Forms.DataGridView()
        Me.tpgIPDVisits = New System.Windows.Forms.TabPage()
        Me.dgvIPDVisits = New System.Windows.Forms.DataGridView()
        Me.stbPatientChequePaymentsWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblExpenditureTotalAmount = New System.Windows.Forms.Label()
        Me.lblExpenditureAmountWords = New System.Windows.Forms.Label()
        Me.stbPatientChequePayments = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblName = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.stbTotalVisits = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalVisits = New System.Windows.Forms.Label()
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.lblAgeString = New System.Windows.Forms.Label()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.colDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBillMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTotalAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDDateAndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDDetails = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDBillMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcAccountStatement.SuspendLayout()
        Me.tpgOPDVisits.SuspendLayout()
        CType(Me.dgvOPDVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgIPDVisits.SuspendLayout()
        CType(Me.dgvIPDVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbcAccountStatement
        '
        Me.tbcAccountStatement.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcAccountStatement.Controls.Add(Me.tpgOPDVisits)
        Me.tbcAccountStatement.Controls.Add(Me.tpgIPDVisits)
        Me.tbcAccountStatement.HotTrack = True
        Me.tbcAccountStatement.Location = New System.Drawing.Point(8, 101)
        Me.tbcAccountStatement.Name = "tbcAccountStatement"
        Me.tbcAccountStatement.SelectedIndex = 0
        Me.tbcAccountStatement.Size = New System.Drawing.Size(922, 326)
        Me.tbcAccountStatement.TabIndex = 1
        '
        'tpgOPDVisits
        '
        Me.tpgOPDVisits.Controls.Add(Me.dgvOPDVisits)
        Me.tpgOPDVisits.Location = New System.Drawing.Point(4, 22)
        Me.tpgOPDVisits.Name = "tpgOPDVisits"
        Me.tpgOPDVisits.Size = New System.Drawing.Size(914, 300)
        Me.tpgOPDVisits.TabIndex = 8
        Me.tpgOPDVisits.Tag = "Visit Payment"
        Me.tpgOPDVisits.Text = "OPD Consumption"
        Me.tpgOPDVisits.UseVisualStyleBackColor = True
        '
        'dgvOPDVisits
        '
        Me.dgvOPDVisits.AllowUserToAddRows = False
        Me.dgvOPDVisits.AllowUserToDeleteRows = False
        Me.dgvOPDVisits.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvOPDVisits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOPDVisits.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOPDVisits.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOPDVisits.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOPDVisits.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDVisits.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOPDVisits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDateTime, Me.colItemDetails, Me.ColQuantity, Me.ColBillMode, Me.ColTotalAmount, Me.ColStatus, Me.ColPayStatus})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOPDVisits.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOPDVisits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOPDVisits.EnableHeadersVisualStyles = False
        Me.dgvOPDVisits.GridColor = System.Drawing.Color.Khaki
        Me.dgvOPDVisits.Location = New System.Drawing.Point(0, 0)
        Me.dgvOPDVisits.Name = "dgvOPDVisits"
        Me.dgvOPDVisits.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOPDVisits.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvOPDVisits.RowHeadersVisible = False
        Me.dgvOPDVisits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOPDVisits.Size = New System.Drawing.Size(914, 300)
        Me.dgvOPDVisits.TabIndex = 0
        Me.dgvOPDVisits.Text = "DataGridView1"
        '
        'tpgIPDVisits
        '
        Me.tpgIPDVisits.Controls.Add(Me.dgvIPDVisits)
        Me.tpgIPDVisits.Controls.Add(Me.stbPatientChequePaymentsWords)
        Me.tpgIPDVisits.Controls.Add(Me.lblExpenditureTotalAmount)
        Me.tpgIPDVisits.Controls.Add(Me.lblExpenditureAmountWords)
        Me.tpgIPDVisits.Controls.Add(Me.stbPatientChequePayments)
        Me.tpgIPDVisits.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDVisits.Name = "tpgIPDVisits"
        Me.tpgIPDVisits.Size = New System.Drawing.Size(914, 300)
        Me.tpgIPDVisits.TabIndex = 7
        Me.tpgIPDVisits.Tag = ""
        Me.tpgIPDVisits.Text = "IPD Consumption"
        Me.tpgIPDVisits.UseVisualStyleBackColor = True
        '
        'dgvIPDVisits
        '
        Me.dgvIPDVisits.AllowUserToAddRows = False
        Me.dgvIPDVisits.AllowUserToDeleteRows = False
        Me.dgvIPDVisits.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIPDVisits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvIPDVisits.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDVisits.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIPDVisits.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIPDVisits.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDVisits.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvIPDVisits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIPDDateAndTime, Me.ColIPDDetails, Me.ColIPDQuantity, Me.ColIPDBillMode, Me.ColAmount, Me.ColIPDItemStatus, Me.ColIPDPayStatus})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPDVisits.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvIPDVisits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPDVisits.EnableHeadersVisualStyles = False
        Me.dgvIPDVisits.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDVisits.Location = New System.Drawing.Point(0, 0)
        Me.dgvIPDVisits.Name = "dgvIPDVisits"
        Me.dgvIPDVisits.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDVisits.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvIPDVisits.RowHeadersVisible = False
        Me.dgvIPDVisits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvIPDVisits.Size = New System.Drawing.Size(914, 300)
        Me.dgvIPDVisits.TabIndex = 13
        Me.dgvIPDVisits.Text = "DataGridView1"
        '
        'stbPatientChequePaymentsWords
        '
        Me.stbPatientChequePaymentsWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbPatientChequePaymentsWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientChequePaymentsWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientChequePaymentsWords.CapitalizeFirstLetter = False
        Me.stbPatientChequePaymentsWords.EntryErrorMSG = ""
        Me.stbPatientChequePaymentsWords.Location = New System.Drawing.Point(419, 300)
        Me.stbPatientChequePaymentsWords.MaxLength = 100
        Me.stbPatientChequePaymentsWords.Multiline = True
        Me.stbPatientChequePaymentsWords.Name = "stbPatientChequePaymentsWords"
        Me.stbPatientChequePaymentsWords.ReadOnly = True
        Me.stbPatientChequePaymentsWords.RegularExpression = ""
        Me.stbPatientChequePaymentsWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPatientChequePaymentsWords.Size = New System.Drawing.Size(377, 39)
        Me.stbPatientChequePaymentsWords.TabIndex = 12
        '
        'lblExpenditureTotalAmount
        '
        Me.lblExpenditureTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpenditureTotalAmount.Location = New System.Drawing.Point(7, 313)
        Me.lblExpenditureTotalAmount.Name = "lblExpenditureTotalAmount"
        Me.lblExpenditureTotalAmount.Size = New System.Drawing.Size(84, 20)
        Me.lblExpenditureTotalAmount.TabIndex = 9
        Me.lblExpenditureTotalAmount.Text = "Total Amount"
        '
        'lblExpenditureAmountWords
        '
        Me.lblExpenditureAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpenditureAmountWords.Location = New System.Drawing.Point(287, 313)
        Me.lblExpenditureAmountWords.Name = "lblExpenditureAmountWords"
        Me.lblExpenditureAmountWords.Size = New System.Drawing.Size(126, 21)
        Me.lblExpenditureAmountWords.TabIndex = 11
        Me.lblExpenditureAmountWords.Text = "Amount in Words"
        '
        'stbPatientChequePayments
        '
        Me.stbPatientChequePayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbPatientChequePayments.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientChequePayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientChequePayments.CapitalizeFirstLetter = False
        Me.stbPatientChequePayments.Enabled = False
        Me.stbPatientChequePayments.EntryErrorMSG = ""
        Me.stbPatientChequePayments.Location = New System.Drawing.Point(97, 311)
        Me.stbPatientChequePayments.MaxLength = 20
        Me.stbPatientChequePayments.Name = "stbPatientChequePayments"
        Me.stbPatientChequePayments.RegularExpression = ""
        Me.stbPatientChequePayments.Size = New System.Drawing.Size(184, 20)
        Me.stbPatientChequePayments.TabIndex = 10
        Me.stbPatientChequePayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrintPreview.Enabled = False
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(108, 442)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(90, 24)
        Me.btnPrintPreview.TabIndex = 5
        Me.btnPrintPreview.Text = "Print Pre&view"
        Me.btnPrintPreview.Visible = False
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(12, 442)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(90, 24)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "&Print"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(858, 442)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 6
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(12, 35)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(105, 20)
        Me.lblName.TabIndex = 92
        Me.lblName.Text = "Patient's Name"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(180, 33)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(149, 20)
        Me.stbFullName.TabIndex = 93
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(12, 77)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(105, 20)
        Me.lblGenderID.TabIndex = 97
        Me.lblGenderID.Text = "Gender"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(12, 56)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(105, 20)
        Me.lblAge.TabIndex = 94
        Me.lblAge.Text = "Age"
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(383, 10)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(102, 20)
        Me.lblJoinDate.TabIndex = 99
        Me.lblJoinDate.Text = "Join Date"
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(180, 75)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(149, 20)
        Me.stbGender.TabIndex = 98
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(517, 8)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(149, 20)
        Me.stbJoinDate.TabIndex = 100
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(180, 54)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(44, 20)
        Me.stbAge.TabIndex = 95
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.stbPhone.Enabled = False
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(517, 30)
        Me.stbPhone.MaxLength = 60
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPhone.Size = New System.Drawing.Size(149, 20)
        Me.stbPhone.TabIndex = 102
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(383, 32)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(102, 20)
        Me.lblPhone.TabIndex = 101
        Me.lblPhone.Text = "Phone"
        '
        'stbTotalVisits
        '
        Me.stbTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalVisits.CapitalizeFirstLetter = False
        Me.stbTotalVisits.Enabled = False
        Me.stbTotalVisits.EntryErrorMSG = ""
        Me.stbTotalVisits.Location = New System.Drawing.Point(517, 73)
        Me.stbTotalVisits.MaxLength = 60
        Me.stbTotalVisits.Name = "stbTotalVisits"
        Me.stbTotalVisits.RegularExpression = ""
        Me.stbTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTotalVisits.Size = New System.Drawing.Size(149, 20)
        Me.stbTotalVisits.TabIndex = 106
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(383, 74)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(102, 20)
        Me.lblTotalVisits.TabIndex = 105
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.CapitalizeFirstLetter = False
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.EntryErrorMSG = ""
        Me.stbLastVisitDate.Location = New System.Drawing.Point(517, 52)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.RegularExpression = ""
        Me.stbLastVisitDate.Size = New System.Drawing.Size(149, 20)
        Me.stbLastVisitDate.TabIndex = 104
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(383, 54)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(102, 20)
        Me.lblLastVisitDate.TabIndex = 103
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(288, 6)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 110
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(180, 10)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(102, 20)
        Me.stbPatientNo.TabIndex = 109
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(12, 12)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(120, 20)
        Me.lblPatientNo.TabIndex = 107
        Me.lblPatientNo.Text = "Patient's Number"
        '
        'lblAgeString
        '
        Me.lblAgeString.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgeString.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAgeString.Location = New System.Drawing.Point(227, 55)
        Me.lblAgeString.Name = "lblAgeString"
        Me.lblAgeString.Size = New System.Drawing.Size(99, 17)
        Me.lblAgeString.TabIndex = 96
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.Image = CType(resources.GetObject("spbPhoto.Image"), System.Drawing.Image)
        Me.spbPhoto.ImageSizeLimit = CType(200000, Long)
        Me.spbPhoto.InitialImage = CType(resources.GetObject("spbPhoto.InitialImage"), System.Drawing.Image)
        Me.spbPhoto.Location = New System.Drawing.Point(731, 6)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = True
        Me.spbPhoto.Size = New System.Drawing.Size(100, 87)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 111
        Me.spbPhoto.TabStop = False
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(672, 8)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(94, 20)
        Me.lblPhoto.TabIndex = 112
        Me.lblPhoto.Text = "Photo"
        '
        'colDateTime
        '
        Me.colDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colDateTime.DataPropertyName = "DateAndTime"
        Me.colDateTime.HeaderText = "Date"
        Me.colDateTime.Name = "colDateTime"
        '
        'colItemDetails
        '
        Me.colItemDetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colItemDetails.DataPropertyName = "Details"
        Me.colItemDetails.HeaderText = "Item Details"
        Me.colItemDetails.Name = "colItemDetails"
        '
        'ColQuantity
        '
        Me.ColQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColQuantity.DataPropertyName = "Quantity"
        Me.ColQuantity.HeaderText = "Quantity"
        Me.ColQuantity.Name = "ColQuantity"
        '
        'ColBillMode
        '
        Me.ColBillMode.DataPropertyName = "BillCustomerName"
        Me.ColBillMode.HeaderText = "Bill Customer"
        Me.ColBillMode.Name = "ColBillMode"
        '
        'ColTotalAmount
        '
        Me.ColTotalAmount.DataPropertyName = "Amount"
        Me.ColTotalAmount.HeaderText = "Amount"
        Me.ColTotalAmount.Name = "ColTotalAmount"
        '
        'ColStatus
        '
        Me.ColStatus.DataPropertyName = "ItemStatus"
        Me.ColStatus.HeaderText = "Item Status"
        Me.ColStatus.Name = "ColStatus"
        '
        'ColPayStatus
        '
        Me.ColPayStatus.DataPropertyName = "PayStatus"
        Me.ColPayStatus.HeaderText = "Pay Status"
        Me.ColPayStatus.Name = "ColPayStatus"
        '
        'ColIPDDateAndTime
        '
        Me.ColIPDDateAndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColIPDDateAndTime.DataPropertyName = "DateAndTime"
        Me.ColIPDDateAndTime.HeaderText = "Date"
        Me.ColIPDDateAndTime.Name = "ColIPDDateAndTime"
        '
        'ColIPDDetails
        '
        Me.ColIPDDetails.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColIPDDetails.DataPropertyName = "Details"
        Me.ColIPDDetails.HeaderText = "Item Details"
        Me.ColIPDDetails.Name = "ColIPDDetails"
        '
        'ColIPDQuantity
        '
        Me.ColIPDQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColIPDQuantity.DataPropertyName = "Quantity"
        Me.ColIPDQuantity.HeaderText = "Quantity"
        Me.ColIPDQuantity.Name = "ColIPDQuantity"
        '
        'ColIPDBillMode
        '
        Me.ColIPDBillMode.DataPropertyName = "BillCustomerName"
        Me.ColIPDBillMode.HeaderText = "Bill Mode"
        Me.ColIPDBillMode.Name = "ColIPDBillMode"
        '
        'ColAmount
        '
        Me.ColAmount.DataPropertyName = "Amount"
        Me.ColAmount.HeaderText = "Amount"
        Me.ColAmount.Name = "ColAmount"
        '
        'ColIPDItemStatus
        '
        Me.ColIPDItemStatus.DataPropertyName = "ItemStatus"
        Me.ColIPDItemStatus.HeaderText = "Item Status"
        Me.ColIPDItemStatus.Name = "ColIPDItemStatus"
        '
        'ColIPDPayStatus
        '
        Me.ColIPDPayStatus.DataPropertyName = "PayStatus"
        Me.ColIPDPayStatus.HeaderText = "Pay Status"
        Me.ColIPDPayStatus.Name = "ColIPDPayStatus"
        '
        'frmPatientRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 478)
        Me.Controls.Add(Me.spbPhoto)
        Me.Controls.Add(Me.lblPhoto)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.stbPhone)
        Me.Controls.Add(Me.lblPhone)
        Me.Controls.Add(Me.stbTotalVisits)
        Me.Controls.Add(Me.lblTotalVisits)
        Me.Controls.Add(Me.stbLastVisitDate)
        Me.Controls.Add(Me.lblLastVisitDate)
        Me.Controls.Add(Me.lblAgeString)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.tbcAccountStatement)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPatientRecord"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Full Patient Record"
        Me.tbcAccountStatement.ResumeLayout(False)
        Me.tpgOPDVisits.ResumeLayout(False)
        CType(Me.dgvOPDVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgIPDVisits.ResumeLayout(False)
        Me.tpgIPDVisits.PerformLayout()
        CType(Me.dgvIPDVisits, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tbcAccountStatement As System.Windows.Forms.TabControl
    Friend WithEvents tpgOPDVisits As System.Windows.Forms.TabPage
    Friend WithEvents dgvOPDVisits As System.Windows.Forms.DataGridView
    Friend WithEvents tpgIPDVisits As System.Windows.Forms.TabPage
    Friend WithEvents stbPatientChequePaymentsWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExpenditureTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblExpenditureAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbPatientChequePayments As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents stbTotalVisits As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalVisits As System.Windows.Forms.Label
    Friend WithEvents stbLastVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastVisitDate As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents lblAgeString As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents dgvIPDVisits As System.Windows.Forms.DataGridView
    Friend WithEvents colDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemDetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBillMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTotalAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDDateAndTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDDetails As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDBillMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
