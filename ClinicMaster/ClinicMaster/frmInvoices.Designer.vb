
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoices : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoices))
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
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.stbBPAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.cboBillAccountNo = New System.Windows.Forms.ComboBox()
        Me.stbBPTotalBill = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInvoiceNo = New System.Windows.Forms.Label()
        Me.lblInvoiceDate = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.grpInvoiceDetails = New System.Windows.Forms.GroupBox()
        Me.dgvInvoiceDetails = New System.Windows.Forms.DataGridView()
        Me.cmsInvoiceDetails = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsInvoiceDetailsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsAddExtraCharge = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsEditVisit = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsEditBill = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.btnLoadPendingBillsPayment = New System.Windows.Forms.Button()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.lblBPAmountWords = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.lblBillAccountNo = New System.Windows.Forms.Label()
        Me.cboBillModesID = New System.Windows.Forms.ComboBox()
        Me.lblBillModesID = New System.Windows.Forms.Label()
        Me.lblBPTotalAmountPaid = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.btnAddExtraCharge = New System.Windows.Forms.Button()
        Me.navVisits = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.chkNavigateVisits = New System.Windows.Forms.CheckBox()
        Me.pnlNavigateVisits = New System.Windows.Forms.Panel()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.chkPrintInvoiceOnSaving = New System.Windows.Forms.CheckBox()
        Me.chkReconciliationRequired = New System.Windows.Forms.CheckBox()
        Me.chkPrintInvoiceDetailedOnSaving = New System.Windows.Forms.CheckBox()
        Me.fbnLoadInvoices = New System.Windows.Forms.Button()
        Me.lblLoadInvoices = New System.Windows.Forms.Label()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMappedCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDisplayAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMemberCardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMainMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClaimReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCoPayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCoPayPercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCoPayValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.grpInvoiceDetails.SuspendLayout()
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsInvoiceDetails.SuspendLayout()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.pnlNavigateVisits.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 436)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 24
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(818, 436)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 25
        Me.fbnDelete.Tag = "Invoices"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 463)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 26
        Me.ebnSaveUpdate.Tag = "Invoices"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpInvoiceDate, "InvoiceDate")
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(192, 109)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.ShowCheckBox = True
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(157, 20)
        Me.dtpInvoiceDate.TabIndex = 11
        '
        'stbBPAmountWords
        '
        Me.stbBPAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBPAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPAmountWords.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBPAmountWords, "AmountWords")
        Me.stbBPAmountWords.EntryErrorMSG = ""
        Me.stbBPAmountWords.Location = New System.Drawing.Point(520, 86)
        Me.stbBPAmountWords.MaxLength = 100
        Me.stbBPAmountWords.Multiline = True
        Me.stbBPAmountWords.Name = "stbBPAmountWords"
        Me.stbBPAmountWords.ReadOnly = True
        Me.stbBPAmountWords.RegularExpression = ""
        Me.stbBPAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBPAmountWords.Size = New System.Drawing.Size(350, 43)
        Me.stbBPAmountWords.TabIndex = 16
        '
        'dtpEndDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpEndDate, "EndDate")
        Me.dtpEndDate.Location = New System.Drawing.Point(86, 28)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(216, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'dtpStartDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpStartDate, "StartDate")
        Me.dtpStartDate.Location = New System.Drawing.Point(86, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(216, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'cboBillAccountNo
        '
        Me.cboBillAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillAccountNo.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboBillAccountNo, "PayNo")
        Me.cboBillAccountNo.DropDownWidth = 276
        Me.cboBillAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillAccountNo.FormattingEnabled = True
        Me.cboBillAccountNo.ItemHeight = 13
        Me.cboBillAccountNo.Location = New System.Drawing.Point(192, 27)
        Me.cboBillAccountNo.Name = "cboBillAccountNo"
        Me.cboBillAccountNo.Size = New System.Drawing.Size(157, 21)
        Me.cboBillAccountNo.TabIndex = 4
        Me.cboBillAccountNo.Tag = "777888"
        '
        'stbBPTotalBill
        '
        Me.stbBPTotalBill.BackColor = System.Drawing.SystemColors.Info
        Me.stbBPTotalBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPTotalBill.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBPTotalBill, "InvoiceAmount")
        Me.stbBPTotalBill.Enabled = False
        Me.stbBPTotalBill.EntryErrorMSG = ""
        Me.stbBPTotalBill.Location = New System.Drawing.Point(192, 130)
        Me.stbBPTotalBill.MaxLength = 20
        Me.stbBPTotalBill.Name = "stbBPTotalBill"
        Me.stbBPTotalBill.RegularExpression = ""
        Me.stbBPTotalBill.Size = New System.Drawing.Size(157, 20)
        Me.stbBPTotalBill.TabIndex = 13
        Me.stbBPTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(818, 463)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 28
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbInvoiceNo
        '
        Me.stbInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceNo.CapitalizeFirstLetter = False
        Me.stbInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbInvoiceNo.EntryErrorMSG = ""
        Me.stbInvoiceNo.Location = New System.Drawing.Point(192, 88)
        Me.stbInvoiceNo.MaxLength = 20
        Me.stbInvoiceNo.Name = "stbInvoiceNo"
        Me.stbInvoiceNo.RegularExpression = ""
        Me.stbInvoiceNo.Size = New System.Drawing.Size(157, 20)
        Me.stbInvoiceNo.TabIndex = 9
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.Location = New System.Drawing.Point(12, 88)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(143, 18)
        Me.lblInvoiceNo.TabIndex = 8
        Me.lblInvoiceNo.Text = "Invoice No"
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Location = New System.Drawing.Point(12, 110)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(143, 18)
        Me.lblInvoiceDate.TabIndex = 10
        Me.lblInvoiceDate.Text = "Invoice Date"
        '
        'cboLoginID
        '
        Me.cboLoginID.Location = New System.Drawing.Point(0, 0)
        Me.cboLoginID.Name = "cboLoginID"
        Me.cboLoginID.Size = New System.Drawing.Size(121, 21)
        Me.cboLoginID.TabIndex = 0
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(0, 0)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(100, 23)
        Me.lblLoginID.TabIndex = 0
        '
        'grpInvoiceDetails
        '
        Me.grpInvoiceDetails.AccessibleDescription = ""
        Me.grpInvoiceDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpInvoiceDetails.Controls.Add(Me.dgvInvoiceDetails)
        Me.grpInvoiceDetails.Location = New System.Drawing.Point(15, 164)
        Me.grpInvoiceDetails.Name = "grpInvoiceDetails"
        Me.grpInvoiceDetails.Size = New System.Drawing.Size(875, 255)
        Me.grpInvoiceDetails.TabIndex = 22
        Me.grpInvoiceDetails.TabStop = False
        Me.grpInvoiceDetails.Text = "Invoice Details"
        '
        'dgvInvoiceDetails
        '
        Me.dgvInvoiceDetails.AllowUserToAddRows = False
        Me.dgvInvoiceDetails.AllowUserToOrderColumns = True
        Me.dgvInvoiceDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInvoiceDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInvoiceDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInvoiceDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVisitNo, Me.colVisitDate, Me.colPatientNo, Me.colFullName, Me.colItemCode, Me.ColMappedCode, Me.colItemName, Me.colCategory, Me.colQuantity, Me.colUnitPrice, Me.colDiscount, Me.colAmount, Me.colDisplayAmount, Me.colItemStatus, Me.colMemberCardNo, Me.colBillPrice, Me.colMainMemberName, Me.colClaimReferenceNo, Me.colBillCustomerName, Me.colCoPayType, Me.colCoPayPercent, Me.colCoPayValue, Me.colItemCategoryID, Me.colSaved})
        Me.dgvInvoiceDetails.ContextMenuStrip = Me.cmsInvoiceDetails
        Me.dgvInvoiceDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoiceDetails.EnableHeadersVisualStyles = False
        Me.dgvInvoiceDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvInvoiceDetails.Location = New System.Drawing.Point(3, 16)
        Me.dgvInvoiceDetails.Name = "dgvInvoiceDetails"
        Me.dgvInvoiceDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle25.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle25
        Me.dgvInvoiceDetails.Size = New System.Drawing.Size(869, 236)
        Me.dgvInvoiceDetails.TabIndex = 1
        Me.dgvInvoiceDetails.Text = "DataGridView1"
        '
        'cmsInvoiceDetails
        '
        Me.cmsInvoiceDetails.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsInvoiceDetails.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsInvoiceDetailsCopy, Me.cmsInvoiceDetailsSelectAll, Me.cmsInvoiceDetailsAddExtraCharge, Me.cmsInvoiceDetailsEditVisit, Me.cmsInvoiceDetailsEditBill})
        Me.cmsInvoiceDetails.Name = "cmsSearch"
        Me.cmsInvoiceDetails.Size = New System.Drawing.Size(175, 114)
        '
        'cmsInvoiceDetailsCopy
        '
        Me.cmsInvoiceDetailsCopy.Enabled = False
        Me.cmsInvoiceDetailsCopy.Image = CType(resources.GetObject("cmsInvoiceDetailsCopy.Image"), System.Drawing.Image)
        Me.cmsInvoiceDetailsCopy.Name = "cmsInvoiceDetailsCopy"
        Me.cmsInvoiceDetailsCopy.Size = New System.Drawing.Size(174, 22)
        Me.cmsInvoiceDetailsCopy.Text = "Copy"
        Me.cmsInvoiceDetailsCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsInvoiceDetailsSelectAll
        '
        Me.cmsInvoiceDetailsSelectAll.Enabled = False
        Me.cmsInvoiceDetailsSelectAll.Name = "cmsInvoiceDetailsSelectAll"
        Me.cmsInvoiceDetailsSelectAll.Size = New System.Drawing.Size(174, 22)
        Me.cmsInvoiceDetailsSelectAll.Text = "Select All"
        '
        'cmsInvoiceDetailsAddExtraCharge
        '
        Me.cmsInvoiceDetailsAddExtraCharge.Enabled = False
        Me.cmsInvoiceDetailsAddExtraCharge.Image = CType(resources.GetObject("cmsInvoiceDetailsAddExtraCharge.Image"), System.Drawing.Image)
        Me.cmsInvoiceDetailsAddExtraCharge.Name = "cmsInvoiceDetailsAddExtraCharge"
        Me.cmsInvoiceDetailsAddExtraCharge.Size = New System.Drawing.Size(174, 22)
        Me.cmsInvoiceDetailsAddExtraCharge.Text = "Add Extra Charge..."
        '
        'cmsInvoiceDetailsEditVisit
        '
        Me.cmsInvoiceDetailsEditVisit.Enabled = False
        Me.cmsInvoiceDetailsEditVisit.Image = CType(resources.GetObject("cmsInvoiceDetailsEditVisit.Image"), System.Drawing.Image)
        Me.cmsInvoiceDetailsEditVisit.Name = "cmsInvoiceDetailsEditVisit"
        Me.cmsInvoiceDetailsEditVisit.Size = New System.Drawing.Size(174, 22)
        Me.cmsInvoiceDetailsEditVisit.Tag = "Visits"
        Me.cmsInvoiceDetailsEditVisit.Text = "Edit Visit"
        '
        'cmsInvoiceDetailsEditBill
        '
        Me.cmsInvoiceDetailsEditBill.Enabled = False
        Me.cmsInvoiceDetailsEditBill.Image = CType(resources.GetObject("cmsInvoiceDetailsEditBill.Image"), System.Drawing.Image)
        Me.cmsInvoiceDetailsEditBill.Name = "cmsInvoiceDetailsEditBill"
        Me.cmsInvoiceDetailsEditBill.Size = New System.Drawing.Size(174, 22)
        Me.cmsInvoiceDetailsEditBill.Tag = "SelfRequests"
        Me.cmsInvoiceDetailsEditBill.Text = "Edit Bill"
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.btnLoadPendingBillsPayment)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Location = New System.Drawing.Point(405, 4)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(485, 80)
        Me.grpSetParameters.TabIndex = 14
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Visit Period"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(6, 16)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(317, 53)
        Me.pnlPeriod.TabIndex = 0
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(10, 5)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(70, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(10, 28)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(70, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLoadPendingBillsPayment
        '
        Me.btnLoadPendingBillsPayment.AccessibleDescription = ""
        Me.btnLoadPendingBillsPayment.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPendingBillsPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPendingBillsPayment.Location = New System.Drawing.Point(385, 42)
        Me.btnLoadPendingBillsPayment.Name = "btnLoadPendingBillsPayment"
        Me.btnLoadPendingBillsPayment.Size = New System.Drawing.Size(78, 24)
        Me.btnLoadPendingBillsPayment.TabIndex = 2
        Me.btnLoadPendingBillsPayment.Tag = ""
        Me.btnLoadPendingBillsPayment.Text = "Load &Bill"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(280, 17)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(180, 13)
        Me.lblRecordsNo.TabIndex = 1
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBPAmountWords
        '
        Me.lblBPAmountWords.Location = New System.Drawing.Point(369, 95)
        Me.lblBPAmountWords.Name = "lblBPAmountWords"
        Me.lblBPAmountWords.Size = New System.Drawing.Size(145, 21)
        Me.lblBPAmountWords.TabIndex = 15
        Me.lblBPAmountWords.Text = "Amount in Words"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(192, 53)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(157, 34)
        Me.stbBillCustomerName.TabIndex = 7
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(12, 60)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(143, 18)
        Me.lblBillCustomerName.TabIndex = 6
        Me.lblBillCustomerName.Text = "To-Bill Customer Name"
        '
        'lblBillAccountNo
        '
        Me.lblBillAccountNo.Location = New System.Drawing.Point(12, 30)
        Me.lblBillAccountNo.Name = "lblBillAccountNo"
        Me.lblBillAccountNo.Size = New System.Drawing.Size(133, 18)
        Me.lblBillAccountNo.TabIndex = 2
        Me.lblBillAccountNo.Text = "To-Bill Account Number"
        '
        'cboBillModesID
        '
        Me.cboBillModesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillModesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillModesID.FormattingEnabled = True
        Me.cboBillModesID.ItemHeight = 13
        Me.cboBillModesID.Location = New System.Drawing.Point(192, 4)
        Me.cboBillModesID.Name = "cboBillModesID"
        Me.cboBillModesID.Size = New System.Drawing.Size(157, 21)
        Me.cboBillModesID.TabIndex = 1
        '
        'lblBillModesID
        '
        Me.lblBillModesID.Location = New System.Drawing.Point(12, 7)
        Me.lblBillModesID.Name = "lblBillModesID"
        Me.lblBillModesID.Size = New System.Drawing.Size(143, 18)
        Me.lblBillModesID.TabIndex = 0
        Me.lblBillModesID.Text = "To-Bill Account Category"
        '
        'lblBPTotalAmountPaid
        '
        Me.lblBPTotalAmountPaid.Location = New System.Drawing.Point(12, 130)
        Me.lblBPTotalAmountPaid.Name = "lblBPTotalAmountPaid"
        Me.lblBPTotalAmountPaid.Size = New System.Drawing.Size(143, 18)
        Me.lblBPTotalAmountPaid.TabIndex = 12
        Me.lblBPTotalAmountPaid.Text = "Total Bill"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.Enabled = False
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(159, 26)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 3
        '
        'btnAddExtraCharge
        '
        Me.btnAddExtraCharge.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnAddExtraCharge.Enabled = False
        Me.btnAddExtraCharge.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnAddExtraCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddExtraCharge.Location = New System.Drawing.Point(439, 425)
        Me.btnAddExtraCharge.Name = "btnAddExtraCharge"
        Me.btnAddExtraCharge.Size = New System.Drawing.Size(110, 23)
        Me.btnAddExtraCharge.TabIndex = 23
        Me.btnAddExtraCharge.Tag = "ExtraCharge"
        Me.btnAddExtraCharge.Text = "Add Extra Charge"
        Me.btnAddExtraCharge.UseVisualStyleBackColor = True
        '
        'navVisits
        '
        Me.navVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navVisits.ColumnName = "VisitNo"
        Me.navVisits.DataSource = Nothing
        Me.navVisits.Location = New System.Drawing.Point(171, 1)
        Me.navVisits.Margin = New System.Windows.Forms.Padding(4)
        Me.navVisits.Name = "navVisits"
        Me.navVisits.NavAllEnabled = False
        Me.navVisits.NavLeftEnabled = False
        Me.navVisits.NavRightEnabled = False
        Me.navVisits.Size = New System.Drawing.Size(413, 32)
        Me.navVisits.TabIndex = 1
        '
        'chkNavigateVisits
        '
        Me.chkNavigateVisits.AccessibleDescription = ""
        Me.chkNavigateVisits.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateVisits.Location = New System.Drawing.Point(8, 7)
        Me.chkNavigateVisits.Name = "chkNavigateVisits"
        Me.chkNavigateVisits.Size = New System.Drawing.Size(144, 20)
        Me.chkNavigateVisits.TabIndex = 0
        Me.chkNavigateVisits.Text = "Navigate Patient Visits"
        '
        'pnlNavigateVisits
        '
        Me.pnlNavigateVisits.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateVisits.Controls.Add(Me.chkNavigateVisits)
        Me.pnlNavigateVisits.Controls.Add(Me.navVisits)
        Me.pnlNavigateVisits.Location = New System.Drawing.Point(112, 453)
        Me.pnlNavigateVisits.Name = "pnlNavigateVisits"
        Me.pnlNavigateVisits.Size = New System.Drawing.Size(601, 33)
        Me.pnlNavigateVisits.TabIndex = 27
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.Enabled = False
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(355, 26)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 5
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'chkPrintInvoiceOnSaving
        '
        Me.chkPrintInvoiceOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintInvoiceOnSaving.AutoSize = True
        Me.chkPrintInvoiceOnSaving.Checked = True
        Me.chkPrintInvoiceOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintInvoiceOnSaving.Location = New System.Drawing.Point(98, 432)
        Me.chkPrintInvoiceOnSaving.Name = "chkPrintInvoiceOnSaving"
        Me.chkPrintInvoiceOnSaving.Size = New System.Drawing.Size(141, 17)
        Me.chkPrintInvoiceOnSaving.TabIndex = 29
        Me.chkPrintInvoiceOnSaving.Text = " Print Invoice On Saving"
        '
        'chkReconciliationRequired
        '
        Me.chkReconciliationRequired.AccessibleDescription = ""
        Me.chkReconciliationRequired.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkReconciliationRequired.Enabled = False
        Me.chkReconciliationRequired.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkReconciliationRequired.ForeColor = System.Drawing.Color.Red
        Me.chkReconciliationRequired.Location = New System.Drawing.Point(687, 134)
        Me.chkReconciliationRequired.Name = "chkReconciliationRequired"
        Me.chkReconciliationRequired.Size = New System.Drawing.Size(201, 20)
        Me.chkReconciliationRequired.TabIndex = 35
        Me.chkReconciliationRequired.Text = "Reconciliation Required"
        '
        'chkPrintInvoiceDetailedOnSaving
        '
        Me.chkPrintInvoiceDetailedOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintInvoiceDetailedOnSaving.AutoSize = True
        Me.chkPrintInvoiceDetailedOnSaving.Location = New System.Drawing.Point(250, 430)
        Me.chkPrintInvoiceDetailedOnSaving.Name = "chkPrintInvoiceDetailedOnSaving"
        Me.chkPrintInvoiceDetailedOnSaving.Size = New System.Drawing.Size(183, 17)
        Me.chkPrintInvoiceDetailedOnSaving.TabIndex = 36
        Me.chkPrintInvoiceDetailedOnSaving.Text = " Print Detailed Invoice On Saving"
        '
        'fbnLoadInvoices
        '
        Me.fbnLoadInvoices.Enabled = False
        Me.fbnLoadInvoices.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoadInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoadInvoices.Location = New System.Drawing.Point(613, 134)
        Me.fbnLoadInvoices.Name = "fbnLoadInvoices"
        Me.fbnLoadInvoices.Size = New System.Drawing.Size(68, 24)
        Me.fbnLoadInvoices.TabIndex = 37
        Me.fbnLoadInvoices.Tag = ""
        Me.fbnLoadInvoices.Text = "&Load"
        Me.fbnLoadInvoices.Visible = False
        '
        'lblLoadInvoices
        '
        Me.lblLoadInvoices.BackColor = System.Drawing.SystemColors.Control
        Me.lblLoadInvoices.ForeColor = System.Drawing.Color.Red
        Me.lblLoadInvoices.Location = New System.Drawing.Point(372, 134)
        Me.lblLoadInvoices.Name = "lblLoadInvoices"
        Me.lblLoadInvoices.Size = New System.Drawing.Size(199, 20)
        Me.lblLoadInvoices.TabIndex = 38
        Me.lblLoadInvoices.Text = "Previous Invoiced"
        Me.lblLoadInvoices.Visible = False
        '
        'colVisitNo
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colVisitNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colVisitNo.HeaderText = "Visit Number"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        Me.colVisitNo.Width = 75
        '
        'colVisitDate
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colVisitDate.DefaultCellStyle = DataGridViewCellStyle3
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 70
        '
        'colPatientNo
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colPatientNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        Me.colPatientNo.Width = 70
        '
        'colFullName
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colFullName.DefaultCellStyle = DataGridViewCellStyle5
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        Me.colFullName.Width = 80
        '
        'colItemCode
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle6
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 65
        '
        'ColMappedCode
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.ColMappedCode.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColMappedCode.HeaderText = "Mapped Code"
        Me.ColMappedCode.Name = "ColMappedCode"
        '
        'colItemName
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle8
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 80
        '
        'colCategory
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colCategory.DefaultCellStyle = DataGridViewCellStyle9
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        Me.colCategory.Width = 70
        '
        'colQuantity
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.Format = "N0"
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.NullValue = Nothing
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle10
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 50
        '
        'colUnitPrice
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Format = "N2"
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle11
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 60
        '
        'colDiscount
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDiscount.DefaultCellStyle = DataGridViewCellStyle12
        Me.colDiscount.HeaderText = "Discount"
        Me.colDiscount.Name = "colDiscount"
        Me.colDiscount.Width = 60
        '
        'colAmount
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle13.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle13
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Visible = False
        Me.colAmount.Width = 80
        '
        'colDisplayAmount
        '
        Me.colDisplayAmount.HeaderText = "Amount"
        Me.colDisplayAmount.Name = "colDisplayAmount"
        Me.colDisplayAmount.ReadOnly = True
        '
        'colItemStatus
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colItemStatus.DefaultCellStyle = DataGridViewCellStyle14
        Me.colItemStatus.HeaderText = "Item Status"
        Me.colItemStatus.Name = "colItemStatus"
        Me.colItemStatus.ReadOnly = True
        Me.colItemStatus.Width = 70
        '
        'colMemberCardNo
        '
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colMemberCardNo.DefaultCellStyle = DataGridViewCellStyle15
        Me.colMemberCardNo.HeaderText = "Member Card No"
        Me.colMemberCardNo.Name = "colMemberCardNo"
        Me.colMemberCardNo.ReadOnly = True
        '
        'colBillPrice
        '
        Me.colBillPrice.DataPropertyName = "BillPrice"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle16.NullValue = Nothing
        Me.colBillPrice.DefaultCellStyle = DataGridViewCellStyle16
        Me.colBillPrice.HeaderText = "Bill Price"
        Me.colBillPrice.Name = "colBillPrice"
        Me.colBillPrice.ReadOnly = True
        Me.colBillPrice.Visible = False
        '
        'colMainMemberName
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        Me.colMainMemberName.DefaultCellStyle = DataGridViewCellStyle17
        Me.colMainMemberName.HeaderText = "Main Member Name"
        Me.colMainMemberName.Name = "colMainMemberName"
        Me.colMainMemberName.ReadOnly = True
        Me.colMainMemberName.Width = 115
        '
        'colClaimReferenceNo
        '
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        Me.colClaimReferenceNo.DefaultCellStyle = DataGridViewCellStyle18
        Me.colClaimReferenceNo.HeaderText = "Claim Reference No"
        Me.colClaimReferenceNo.Name = "colClaimReferenceNo"
        Me.colClaimReferenceNo.ReadOnly = True
        Me.colClaimReferenceNo.Width = 110
        '
        'colBillCustomerName
        '
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        Me.colBillCustomerName.DefaultCellStyle = DataGridViewCellStyle19
        Me.colBillCustomerName.HeaderText = "To-Bill Customer Name"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.ReadOnly = True
        Me.colBillCustomerName.Width = 120
        '
        'colCoPayType
        '
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.colCoPayType.DefaultCellStyle = DataGridViewCellStyle20
        Me.colCoPayType.HeaderText = "Co-Pay Type"
        Me.colCoPayType.Name = "colCoPayType"
        Me.colCoPayType.ReadOnly = True
        Me.colCoPayType.Width = 80
        '
        'colCoPayPercent
        '
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle21.Format = "N2"
        DataGridViewCellStyle21.NullValue = Nothing
        Me.colCoPayPercent.DefaultCellStyle = DataGridViewCellStyle21
        Me.colCoPayPercent.HeaderText = "Co-Pay Percent"
        Me.colCoPayPercent.Name = "colCoPayPercent"
        Me.colCoPayPercent.ReadOnly = True
        '
        'colCoPayValue
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.NullValue = Nothing
        Me.colCoPayValue.DefaultCellStyle = DataGridViewCellStyle22
        Me.colCoPayValue.HeaderText = "Co-Pay Value"
        Me.colCoPayValue.Name = "colCoPayValue"
        Me.colCoPayValue.ReadOnly = True
        Me.colCoPayValue.Width = 80
        '
        'colItemCategoryID
        '
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategoryID.DefaultCellStyle = DataGridViewCellStyle23
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        '
        'colSaved
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle24.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle24.NullValue = False
        Me.colSaved.DefaultCellStyle = DataGridViewCellStyle24
        Me.colSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSaved.HeaderText = "Saved"
        Me.colSaved.Name = "colSaved"
        Me.colSaved.ReadOnly = True
        Me.colSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colSaved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSaved.Width = 50
        '
        'frmInvoices
        '
        Me.AcceptButton = Me.btnLoadPendingBillsPayment
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(902, 500)
        Me.Controls.Add(Me.lblLoadInvoices)
        Me.Controls.Add(Me.fbnLoadInvoices)
        Me.Controls.Add(Me.chkPrintInvoiceDetailedOnSaving)
        Me.Controls.Add(Me.chkReconciliationRequired)
        Me.Controls.Add(Me.chkPrintInvoiceOnSaving)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.pnlNavigateVisits)
        Me.Controls.Add(Me.btnAddExtraCharge)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.stbBPTotalBill)
        Me.Controls.Add(Me.lblBPTotalAmountPaid)
        Me.Controls.Add(Me.cboBillModesID)
        Me.Controls.Add(Me.lblBillModesID)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.cboBillAccountNo)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.lblBillAccountNo)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.lblBPAmountWords)
        Me.Controls.Add(Me.grpInvoiceDetails)
        Me.Controls.Add(Me.stbBPAmountWords)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbInvoiceNo)
        Me.Controls.Add(Me.lblInvoiceNo)
        Me.Controls.Add(Me.dtpInvoiceDate)
        Me.Controls.Add(Me.lblInvoiceDate)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmInvoices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Invoices"
        Me.grpInvoiceDetails.ResumeLayout(False)
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsInvoiceDetails.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.pnlNavigateVisits.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbInvoiceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents grpInvoiceDetails As System.Windows.Forms.GroupBox
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents btnLoadPendingBillsPayment As System.Windows.Forms.Button
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents stbBPAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBPAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboBillAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblBillAccountNo As System.Windows.Forms.Label
    Friend WithEvents cboBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillModesID As System.Windows.Forms.Label
    Friend WithEvents stbBPTotalBill As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBPTotalAmountPaid As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents cmsInvoiceDetails As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsInvoiceDetailsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsInvoiceDetailsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnAddExtraCharge As System.Windows.Forms.Button
    Friend WithEvents cmsInvoiceDetailsAddExtraCharge As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents navVisits As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents chkNavigateVisits As System.Windows.Forms.CheckBox
    Friend WithEvents pnlNavigateVisits As System.Windows.Forms.Panel
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents chkPrintInvoiceOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents cmsInvoiceDetailsEditVisit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsInvoiceDetailsEditBill As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgvInvoiceDetails As System.Windows.Forms.DataGridView
    Friend WithEvents chkReconciliationRequired As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintInvoiceDetailedOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents fbnLoadInvoices As System.Windows.Forms.Button
    Friend WithEvents lblLoadInvoices As System.Windows.Forms.Label
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMappedCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDisplayAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberCardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMainMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClaimReferenceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCoPayType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCoPayPercent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCoPayValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaved As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class