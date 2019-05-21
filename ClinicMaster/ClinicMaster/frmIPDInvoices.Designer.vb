
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIPDInvoices : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIPDInvoices))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle44 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle45 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle46 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle47 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle48 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.stbBPAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.cboBillAccountNo = New System.Windows.Forms.ComboBox()
        Me.stbBPTotalBill = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInvoiceDetailsAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbInvoiceDetailsTotalBill = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblInvoiceNo = New System.Windows.Forms.Label()
        Me.lblInvoiceDate = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.cmsInvoiceExtraBillItems = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsInvoiceExtraBillItemsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceExtraBillItemsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.lblBillForItem = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.navVisits = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.chkNavigateVisits = New System.Windows.Forms.CheckBox()
        Me.pnlNavigateVisits = New System.Windows.Forms.Panel()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.chkPrintInvoiceOnSaving = New System.Windows.Forms.CheckBox()
        Me.chkIncludeOPDBill = New System.Windows.Forms.CheckBox()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.tbcIPDInvoiceDetails = New SyncSoft.Common.Win.Controls.SmartTabControl()
        Me.tpgIPDInvoiceDetails = New System.Windows.Forms.TabPage()
        Me.dgvInvoiceExtraBillItems = New System.Windows.Forms.DataGridView()
        Me.tpgOPDBill = New System.Windows.Forms.TabPage()
        Me.pnlOPDBill = New System.Windows.Forms.Panel()
        Me.lblInvoiceDetailsBillForItem = New System.Windows.Forms.Label()
        Me.lblBillForInvoiceDetailsItem = New System.Windows.Forms.Label()
        Me.dgvInvoiceDetails = New System.Windows.Forms.DataGridView()
        Me.chkReconciliationRequired = New System.Windows.Forms.CheckBox()
        Me.chkPrintInvoiceDetailedOnSaving = New System.Windows.Forms.CheckBox()
        Me.lblLoadInvoices = New System.Windows.Forms.Label()
        Me.fbnLoadInvoices = New System.Windows.Forms.Button()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraBillDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMappedCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDisplayAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMemberCardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMainMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClaimReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCoPayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCoPayPercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCoPayValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colInvoiceDetailsVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsBillPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMappedCodeVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsDisplayAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsMemberCardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsMainMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsClaimReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsCoPayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsCopayPercent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsCoPayValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInvoiceDetailsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsInvoiceExtraBillItems.SuspendLayout()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.pnlNavigateVisits.SuspendLayout()
        Me.pnlBill.SuspendLayout()
        Me.tbcIPDInvoiceDetails.SuspendLayout()
        Me.tpgIPDInvoiceDetails.SuspendLayout()
        CType(Me.dgvInvoiceExtraBillItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOPDBill.SuspendLayout()
        Me.pnlOPDBill.SuspendLayout()
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 465)
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
        Me.fbnDelete.Location = New System.Drawing.Point(818, 465)
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 492)
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
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(192, 128)
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
        Me.stbBPAmountWords.Location = New System.Drawing.Point(122, 3)
        Me.stbBPAmountWords.MaxLength = 100
        Me.stbBPAmountWords.Multiline = True
        Me.stbBPAmountWords.Name = "stbBPAmountWords"
        Me.stbBPAmountWords.ReadOnly = True
        Me.stbBPAmountWords.RegularExpression = ""
        Me.stbBPAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBPAmountWords.Size = New System.Drawing.Size(357, 43)
        Me.stbBPAmountWords.TabIndex = 16
        '
        'dtpEndDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpEndDate, "EndDate")
        Me.dtpEndDate.Location = New System.Drawing.Point(71, 29)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(231, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'dtpStartDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpStartDate, "StartDate")
        Me.dtpStartDate.Location = New System.Drawing.Point(71, 6)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(231, 20)
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
        Me.cboBillAccountNo.Location = New System.Drawing.Point(192, 46)
        Me.cboBillAccountNo.Name = "cboBillAccountNo"
        Me.cboBillAccountNo.Size = New System.Drawing.Size(157, 21)
        Me.cboBillAccountNo.TabIndex = 4
        '
        'stbBPTotalBill
        '
        Me.stbBPTotalBill.BackColor = System.Drawing.SystemColors.Info
        Me.stbBPTotalBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBPTotalBill.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBPTotalBill, "InvoiceAmount")
        Me.stbBPTotalBill.Enabled = False
        Me.stbBPTotalBill.EntryErrorMSG = ""
        Me.stbBPTotalBill.Location = New System.Drawing.Point(122, 47)
        Me.stbBPTotalBill.MaxLength = 20
        Me.stbBPTotalBill.Name = "stbBPTotalBill"
        Me.stbBPTotalBill.RegularExpression = ""
        Me.stbBPTotalBill.Size = New System.Drawing.Size(157, 20)
        Me.stbBPTotalBill.TabIndex = 13
        Me.stbBPTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbInvoiceDetailsAmountWords
        '
        Me.stbInvoiceDetailsAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbInvoiceDetailsAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceDetailsAmountWords.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInvoiceDetailsAmountWords, "AmountWords")
        Me.stbInvoiceDetailsAmountWords.EntryErrorMSG = ""
        Me.stbInvoiceDetailsAmountWords.Location = New System.Drawing.Point(472, 4)
        Me.stbInvoiceDetailsAmountWords.MaxLength = 100
        Me.stbInvoiceDetailsAmountWords.Multiline = True
        Me.stbInvoiceDetailsAmountWords.Name = "stbInvoiceDetailsAmountWords"
        Me.stbInvoiceDetailsAmountWords.ReadOnly = True
        Me.stbInvoiceDetailsAmountWords.RegularExpression = ""
        Me.stbInvoiceDetailsAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInvoiceDetailsAmountWords.Size = New System.Drawing.Size(385, 43)
        Me.stbInvoiceDetailsAmountWords.TabIndex = 16
        '
        'stbInvoiceDetailsTotalBill
        '
        Me.stbInvoiceDetailsTotalBill.BackColor = System.Drawing.SystemColors.Info
        Me.stbInvoiceDetailsTotalBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInvoiceDetailsTotalBill.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInvoiceDetailsTotalBill, "InvoiceAmount")
        Me.stbInvoiceDetailsTotalBill.Enabled = False
        Me.stbInvoiceDetailsTotalBill.EntryErrorMSG = ""
        Me.stbInvoiceDetailsTotalBill.Location = New System.Drawing.Point(158, 15)
        Me.stbInvoiceDetailsTotalBill.MaxLength = 20
        Me.stbInvoiceDetailsTotalBill.Name = "stbInvoiceDetailsTotalBill"
        Me.stbInvoiceDetailsTotalBill.RegularExpression = ""
        Me.stbInvoiceDetailsTotalBill.Size = New System.Drawing.Size(157, 20)
        Me.stbInvoiceDetailsTotalBill.TabIndex = 13
        Me.stbInvoiceDetailsTotalBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(818, 492)
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
        Me.stbInvoiceNo.Location = New System.Drawing.Point(192, 107)
        Me.stbInvoiceNo.MaxLength = 20
        Me.stbInvoiceNo.Name = "stbInvoiceNo"
        Me.stbInvoiceNo.RegularExpression = ""
        Me.stbInvoiceNo.Size = New System.Drawing.Size(157, 20)
        Me.stbInvoiceNo.TabIndex = 9
        '
        'lblInvoiceNo
        '
        Me.lblInvoiceNo.Location = New System.Drawing.Point(12, 107)
        Me.lblInvoiceNo.Name = "lblInvoiceNo"
        Me.lblInvoiceNo.Size = New System.Drawing.Size(143, 18)
        Me.lblInvoiceNo.TabIndex = 8
        Me.lblInvoiceNo.Text = "Invoice No"
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Location = New System.Drawing.Point(12, 129)
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
        'cmsInvoiceExtraBillItems
        '
        Me.cmsInvoiceExtraBillItems.AccessibleDescription = ""
        Me.cmsInvoiceExtraBillItems.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsInvoiceExtraBillItems.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsInvoiceExtraBillItemsCopy, Me.cmsInvoiceExtraBillItemsSelectAll})
        Me.cmsInvoiceExtraBillItems.Name = "cmsSearch"
        Me.cmsInvoiceExtraBillItems.Size = New System.Drawing.Size(123, 48)
        '
        'cmsInvoiceExtraBillItemsCopy
        '
        Me.cmsInvoiceExtraBillItemsCopy.Enabled = False
        Me.cmsInvoiceExtraBillItemsCopy.Image = CType(resources.GetObject("cmsInvoiceExtraBillItemsCopy.Image"), System.Drawing.Image)
        Me.cmsInvoiceExtraBillItemsCopy.Name = "cmsInvoiceExtraBillItemsCopy"
        Me.cmsInvoiceExtraBillItemsCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsInvoiceExtraBillItemsCopy.Text = "Copy"
        Me.cmsInvoiceExtraBillItemsCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsInvoiceExtraBillItemsSelectAll
        '
        Me.cmsInvoiceExtraBillItemsSelectAll.Enabled = False
        Me.cmsInvoiceExtraBillItemsSelectAll.Name = "cmsInvoiceExtraBillItemsSelectAll"
        Me.cmsInvoiceExtraBillItemsSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsInvoiceExtraBillItemsSelectAll.Text = "Select All"
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
        Me.pnlPeriod.Size = New System.Drawing.Size(311, 53)
        Me.pnlPeriod.TabIndex = 0
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(10, 3)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(57, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(10, 26)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(57, 20)
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
        Me.lblRecordsNo.Location = New System.Drawing.Point(259, 17)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(220, 22)
        Me.lblRecordsNo.TabIndex = 1
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblBPAmountWords
        '
        Me.lblBPAmountWords.Location = New System.Drawing.Point(6, 12)
        Me.lblBPAmountWords.Name = "lblBPAmountWords"
        Me.lblBPAmountWords.Size = New System.Drawing.Size(111, 21)
        Me.lblBPAmountWords.TabIndex = 15
        Me.lblBPAmountWords.Text = "Amount in Words"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(192, 72)
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
        Me.lblBillCustomerName.Location = New System.Drawing.Point(12, 79)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(143, 18)
        Me.lblBillCustomerName.TabIndex = 6
        Me.lblBillCustomerName.Text = "To-Bill Customer Name"
        '
        'lblBillAccountNo
        '
        Me.lblBillAccountNo.Location = New System.Drawing.Point(12, 49)
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
        Me.cboBillModesID.Location = New System.Drawing.Point(192, 23)
        Me.cboBillModesID.Name = "cboBillModesID"
        Me.cboBillModesID.Size = New System.Drawing.Size(157, 21)
        Me.cboBillModesID.TabIndex = 1
        '
        'lblBillModesID
        '
        Me.lblBillModesID.Location = New System.Drawing.Point(12, 26)
        Me.lblBillModesID.Name = "lblBillModesID"
        Me.lblBillModesID.Size = New System.Drawing.Size(143, 18)
        Me.lblBillModesID.TabIndex = 0
        Me.lblBillModesID.Text = "To-Bill Account Category"
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(6, 49)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(111, 18)
        Me.lblBillForItem.TabIndex = 12
        Me.lblBillForItem.Text = "Total Bill For"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.Enabled = False
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(159, 45)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 3
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
        Me.pnlNavigateVisits.Location = New System.Drawing.Point(112, 482)
        Me.pnlNavigateVisits.Name = "pnlNavigateVisits"
        Me.pnlNavigateVisits.Size = New System.Drawing.Size(601, 33)
        Me.pnlNavigateVisits.TabIndex = 27
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.Enabled = False
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(355, 45)
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
        Me.chkPrintInvoiceOnSaving.Location = New System.Drawing.Point(98, 461)
        Me.chkPrintInvoiceOnSaving.Name = "chkPrintInvoiceOnSaving"
        Me.chkPrintInvoiceOnSaving.Size = New System.Drawing.Size(141, 17)
        Me.chkPrintInvoiceOnSaving.TabIndex = 29
        Me.chkPrintInvoiceOnSaving.Text = " Print Invoice On Saving"
        '
        'chkIncludeOPDBill
        '
        Me.chkIncludeOPDBill.AccessibleDescription = ""
        Me.chkIncludeOPDBill.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludeOPDBill.Enabled = False
        Me.chkIncludeOPDBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIncludeOPDBill.Location = New System.Drawing.Point(15, 167)
        Me.chkIncludeOPDBill.Name = "chkIncludeOPDBill"
        Me.chkIncludeOPDBill.Size = New System.Drawing.Size(148, 20)
        Me.chkIncludeOPDBill.TabIndex = 31
        Me.chkIncludeOPDBill.Text = "Include OPD Bill"
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.stbBPAmountWords)
        Me.pnlBill.Controls.Add(Me.lblBPAmountWords)
        Me.pnlBill.Controls.Add(Me.stbBPTotalBill)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(406, 88)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(484, 76)
        Me.pnlBill.TabIndex = 32
        '
        'tbcIPDInvoiceDetails
        '
        Me.tbcIPDInvoiceDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcIPDInvoiceDetails.Controls.Add(Me.tpgIPDInvoiceDetails)
        Me.tbcIPDInvoiceDetails.Controls.Add(Me.tpgOPDBill)
        Me.tbcIPDInvoiceDetails.HotTrack = True
        Me.tbcIPDInvoiceDetails.Location = New System.Drawing.Point(13, 200)
        Me.tbcIPDInvoiceDetails.Name = "tbcIPDInvoiceDetails"
        Me.tbcIPDInvoiceDetails.SelectedIndex = 0
        Me.tbcIPDInvoiceDetails.Size = New System.Drawing.Size(874, 249)
        Me.tbcIPDInvoiceDetails.TabIndex = 33
        '
        'tpgIPDInvoiceDetails
        '
        Me.tpgIPDInvoiceDetails.Controls.Add(Me.dgvInvoiceExtraBillItems)
        Me.tpgIPDInvoiceDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDInvoiceDetails.Name = "tpgIPDInvoiceDetails"
        Me.tpgIPDInvoiceDetails.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgIPDInvoiceDetails.Size = New System.Drawing.Size(866, 223)
        Me.tpgIPDInvoiceDetails.TabIndex = 0
        Me.tpgIPDInvoiceDetails.Text = "IPD Invoice Details"
        Me.tpgIPDInvoiceDetails.UseVisualStyleBackColor = True
        '
        'dgvInvoiceExtraBillItems
        '
        Me.dgvInvoiceExtraBillItems.AllowUserToAddRows = False
        Me.dgvInvoiceExtraBillItems.AllowUserToOrderColumns = True
        Me.dgvInvoiceExtraBillItems.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInvoiceExtraBillItems.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInvoiceExtraBillItems.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceExtraBillItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInvoiceExtraBillItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVisitNo, Me.colVisitDate, Me.colBillPrice, Me.colPatientNo, Me.colFullName, Me.colExtraBillNo, Me.colExtraBillDate, Me.colItemCode, Me.ColMappedCode, Me.colItemName, Me.colQuantity, Me.colUnitPrice, Me.colDisplayAmount, Me.colAmount, Me.colCategory, Me.colDiscount, Me.colEntryMode, Me.colMemberCardNo, Me.colMainMemberName, Me.colClaimReferenceNo, Me.colBillCustomerName, Me.colCoPayType, Me.colCoPayPercent, Me.colCoPayValue, Me.colItemCategoryID, Me.colSaved})
        Me.dgvInvoiceExtraBillItems.ContextMenuStrip = Me.cmsInvoiceExtraBillItems
        Me.dgvInvoiceExtraBillItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInvoiceExtraBillItems.EnableHeadersVisualStyles = False
        Me.dgvInvoiceExtraBillItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvInvoiceExtraBillItems.Location = New System.Drawing.Point(3, 3)
        Me.dgvInvoiceExtraBillItems.Name = "dgvInvoiceExtraBillItems"
        Me.dgvInvoiceExtraBillItems.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceExtraBillItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.dgvInvoiceExtraBillItems.Size = New System.Drawing.Size(860, 217)
        Me.dgvInvoiceExtraBillItems.TabIndex = 0
        Me.dgvInvoiceExtraBillItems.Text = "DataGridView1"
        '
        'tpgOPDBill
        '
        Me.tpgOPDBill.Controls.Add(Me.pnlOPDBill)
        Me.tpgOPDBill.Controls.Add(Me.dgvInvoiceDetails)
        Me.tpgOPDBill.Location = New System.Drawing.Point(4, 22)
        Me.tpgOPDBill.Name = "tpgOPDBill"
        Me.tpgOPDBill.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgOPDBill.Size = New System.Drawing.Size(866, 223)
        Me.tpgOPDBill.TabIndex = 1
        Me.tpgOPDBill.Text = "OPD Bill"
        Me.tpgOPDBill.UseVisualStyleBackColor = True
        '
        'pnlOPDBill
        '
        Me.pnlOPDBill.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlOPDBill.Controls.Add(Me.stbInvoiceDetailsAmountWords)
        Me.pnlOPDBill.Controls.Add(Me.lblInvoiceDetailsBillForItem)
        Me.pnlOPDBill.Controls.Add(Me.stbInvoiceDetailsTotalBill)
        Me.pnlOPDBill.Controls.Add(Me.lblBillForInvoiceDetailsItem)
        Me.pnlOPDBill.Location = New System.Drawing.Point(6, 167)
        Me.pnlOPDBill.Name = "pnlOPDBill"
        Me.pnlOPDBill.Size = New System.Drawing.Size(860, 50)
        Me.pnlOPDBill.TabIndex = 33
        '
        'lblInvoiceDetailsBillForItem
        '
        Me.lblInvoiceDetailsBillForItem.Location = New System.Drawing.Point(351, 15)
        Me.lblInvoiceDetailsBillForItem.Name = "lblInvoiceDetailsBillForItem"
        Me.lblInvoiceDetailsBillForItem.Size = New System.Drawing.Size(117, 21)
        Me.lblInvoiceDetailsBillForItem.TabIndex = 15
        Me.lblInvoiceDetailsBillForItem.Text = "Amount in Words"
        '
        'lblBillForInvoiceDetailsItem
        '
        Me.lblBillForInvoiceDetailsItem.Location = New System.Drawing.Point(7, 15)
        Me.lblBillForInvoiceDetailsItem.Name = "lblBillForInvoiceDetailsItem"
        Me.lblBillForInvoiceDetailsItem.Size = New System.Drawing.Size(145, 18)
        Me.lblBillForInvoiceDetailsItem.TabIndex = 12
        Me.lblBillForInvoiceDetailsItem.Text = "Total Bill For"
        '
        'dgvInvoiceDetails
        '
        Me.dgvInvoiceDetails.AllowUserToAddRows = False
        Me.dgvInvoiceDetails.AllowUserToOrderColumns = True
        Me.dgvInvoiceDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInvoiceDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInvoiceDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInvoiceDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle27.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle27.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle27
        Me.dgvInvoiceDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInvoiceDetailsVisitNo, Me.colInvoiceDetailsBillPrice, Me.colInvoiceDetailsVisitDate, Me.colInvoiceDetailsPatientNo, Me.colInvoiceDetailsFullName, Me.colInvoiceDetailsItemCode, Me.ColMappedCodeVisitNo, Me.colInvoiceDetailsItemName, Me.colInvoiceDetailsCategory, Me.colInvoiceDetailsQuantity, Me.colInvoiceDetailsUnitPrice, Me.colInvoiceDetailsDiscount, Me.colInvoiceDetailsDisplayAmount, Me.colInvoiceDetailsAmount, Me.colInvoiceDetailsItemStatus, Me.colInvoiceDetailsMemberCardNo, Me.colInvoiceDetailsMainMemberName, Me.colInvoiceDetailsClaimReferenceNo, Me.colInvoiceDetailsBillCustomerName, Me.colInvoiceDetailsCoPayType, Me.colInvoiceDetailsCopayPercent, Me.colInvoiceDetailsCoPayValue, Me.colInvoiceDetailsItemCategoryID, Me.colInvoiceDetailsSaved})
        Me.dgvInvoiceDetails.ContextMenuStrip = Me.cmsInvoiceExtraBillItems
        Me.dgvInvoiceDetails.EnableHeadersVisualStyles = False
        Me.dgvInvoiceDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvInvoiceDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvInvoiceDetails.Name = "dgvInvoiceDetails"
        Me.dgvInvoiceDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle49.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle49.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInvoiceDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle49
        Me.dgvInvoiceDetails.Size = New System.Drawing.Size(863, 165)
        Me.dgvInvoiceDetails.TabIndex = 1
        Me.dgvInvoiceDetails.Text = "DataGridView1"
        '
        'chkReconciliationRequired
        '
        Me.chkReconciliationRequired.AccessibleDescription = ""
        Me.chkReconciliationRequired.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkReconciliationRequired.Enabled = False
        Me.chkReconciliationRequired.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkReconciliationRequired.ForeColor = System.Drawing.Color.Red
        Me.chkReconciliationRequired.Location = New System.Drawing.Point(689, 170)
        Me.chkReconciliationRequired.Name = "chkReconciliationRequired"
        Me.chkReconciliationRequired.Size = New System.Drawing.Size(201, 20)
        Me.chkReconciliationRequired.TabIndex = 34
        Me.chkReconciliationRequired.Text = "Reconciliation Required"
        '
        'chkPrintInvoiceDetailedOnSaving
        '
        Me.chkPrintInvoiceDetailedOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintInvoiceDetailedOnSaving.AutoSize = True
        Me.chkPrintInvoiceDetailedOnSaving.Location = New System.Drawing.Point(254, 459)
        Me.chkPrintInvoiceDetailedOnSaving.Name = "chkPrintInvoiceDetailedOnSaving"
        Me.chkPrintInvoiceDetailedOnSaving.Size = New System.Drawing.Size(183, 17)
        Me.chkPrintInvoiceDetailedOnSaving.TabIndex = 37
        Me.chkPrintInvoiceDetailedOnSaving.Text = " Print Detailed Invoice On Saving"
        '
        'lblLoadInvoices
        '
        Me.lblLoadInvoices.BackColor = System.Drawing.SystemColors.Control
        Me.lblLoadInvoices.ForeColor = System.Drawing.Color.Red
        Me.lblLoadInvoices.Location = New System.Drawing.Point(352, 174)
        Me.lblLoadInvoices.Name = "lblLoadInvoices"
        Me.lblLoadInvoices.Size = New System.Drawing.Size(227, 20)
        Me.lblLoadInvoices.TabIndex = 40
        Me.lblLoadInvoices.Text = "Previous Invoiced"
        Me.lblLoadInvoices.Visible = False
        '
        'fbnLoadInvoices
        '
        Me.fbnLoadInvoices.Enabled = False
        Me.fbnLoadInvoices.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoadInvoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoadInvoices.Location = New System.Drawing.Point(585, 170)
        Me.fbnLoadInvoices.Name = "fbnLoadInvoices"
        Me.fbnLoadInvoices.Size = New System.Drawing.Size(98, 24)
        Me.fbnLoadInvoices.TabIndex = 39
        Me.fbnLoadInvoices.Tag = ""
        Me.fbnLoadInvoices.Text = "&Load"
        Me.fbnLoadInvoices.Visible = False
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
        'colBillPrice
        '
        Me.colBillPrice.HeaderText = "Bill Price"
        Me.colBillPrice.Name = "colBillPrice"
        Me.colBillPrice.ReadOnly = True
        Me.colBillPrice.Visible = False
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
        'colExtraBillNo
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colExtraBillNo.DefaultCellStyle = DataGridViewCellStyle6
        Me.colExtraBillNo.HeaderText = "Bill No"
        Me.colExtraBillNo.Name = "colExtraBillNo"
        Me.colExtraBillNo.ReadOnly = True
        Me.colExtraBillNo.Width = 80
        '
        'colExtraBillDate
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colExtraBillDate.DefaultCellStyle = DataGridViewCellStyle7
        Me.colExtraBillDate.HeaderText = "Bill Date"
        Me.colExtraBillDate.Name = "colExtraBillDate"
        Me.colExtraBillDate.ReadOnly = True
        Me.colExtraBillDate.Width = 70
        '
        'colItemCode
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle8
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 65
        '
        'ColMappedCode
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.ColMappedCode.DefaultCellStyle = DataGridViewCellStyle9
        Me.ColMappedCode.HeaderText = "Mapped Code"
        Me.ColMappedCode.Name = "ColMappedCode"
        '
        'colItemName
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle10
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 80
        '
        'colQuantity
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.Format = "N0"
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.NullValue = Nothing
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle11
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 50
        '
        'colUnitPrice
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle12.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle12
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 60
        '
        'colDisplayAmount
        '
        Me.colDisplayAmount.HeaderText = "Amount"
        Me.colDisplayAmount.Name = "colDisplayAmount"
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
        Me.colAmount.Width = 80
        '
        'colCategory
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colCategory.DefaultCellStyle = DataGridViewCellStyle14
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        Me.colCategory.Width = 70
        '
        'colDiscount
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDiscount.DefaultCellStyle = DataGridViewCellStyle15
        Me.colDiscount.HeaderText = "Discount"
        Me.colDiscount.Name = "colDiscount"
        Me.colDiscount.Width = 60
        '
        'colEntryMode
        '
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colEntryMode.DefaultCellStyle = DataGridViewCellStyle16
        Me.colEntryMode.HeaderText = "Entry Mode"
        Me.colEntryMode.Name = "colEntryMode"
        Me.colEntryMode.ReadOnly = True
        Me.colEntryMode.Width = 70
        '
        'colMemberCardNo
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        Me.colMemberCardNo.DefaultCellStyle = DataGridViewCellStyle17
        Me.colMemberCardNo.HeaderText = "Member Card No"
        Me.colMemberCardNo.Name = "colMemberCardNo"
        Me.colMemberCardNo.ReadOnly = True
        '
        'colMainMemberName
        '
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        Me.colMainMemberName.DefaultCellStyle = DataGridViewCellStyle18
        Me.colMainMemberName.HeaderText = "Main Member Name"
        Me.colMainMemberName.Name = "colMainMemberName"
        Me.colMainMemberName.ReadOnly = True
        Me.colMainMemberName.Width = 115
        '
        'colClaimReferenceNo
        '
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        Me.colClaimReferenceNo.DefaultCellStyle = DataGridViewCellStyle19
        Me.colClaimReferenceNo.HeaderText = "Claim Reference No"
        Me.colClaimReferenceNo.Name = "colClaimReferenceNo"
        Me.colClaimReferenceNo.ReadOnly = True
        Me.colClaimReferenceNo.Width = 110
        '
        'colBillCustomerName
        '
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.colBillCustomerName.DefaultCellStyle = DataGridViewCellStyle20
        Me.colBillCustomerName.HeaderText = "To-Bill Customer Name"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.ReadOnly = True
        Me.colBillCustomerName.Width = 120
        '
        'colCoPayType
        '
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        Me.colCoPayType.DefaultCellStyle = DataGridViewCellStyle21
        Me.colCoPayType.HeaderText = "Co-Pay Type"
        Me.colCoPayType.Name = "colCoPayType"
        Me.colCoPayType.ReadOnly = True
        Me.colCoPayType.Width = 80
        '
        'colCoPayPercent
        '
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle22.Format = "N2"
        DataGridViewCellStyle22.NullValue = Nothing
        Me.colCoPayPercent.DefaultCellStyle = DataGridViewCellStyle22
        Me.colCoPayPercent.HeaderText = "Co-Pay Percent"
        Me.colCoPayPercent.Name = "colCoPayPercent"
        Me.colCoPayPercent.ReadOnly = True
        '
        'colCoPayValue
        '
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle23.Format = "N2"
        DataGridViewCellStyle23.NullValue = Nothing
        Me.colCoPayValue.DefaultCellStyle = DataGridViewCellStyle23
        Me.colCoPayValue.HeaderText = "Co-Pay Value"
        Me.colCoPayValue.Name = "colCoPayValue"
        Me.colCoPayValue.ReadOnly = True
        Me.colCoPayValue.Width = 80
        '
        'colItemCategoryID
        '
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategoryID.DefaultCellStyle = DataGridViewCellStyle24
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        '
        'colSaved
        '
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle25.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle25.NullValue = False
        Me.colSaved.DefaultCellStyle = DataGridViewCellStyle25
        Me.colSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSaved.HeaderText = "Saved"
        Me.colSaved.Name = "colSaved"
        Me.colSaved.ReadOnly = True
        Me.colSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colSaved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colSaved.Width = 50
        '
        'colInvoiceDetailsVisitNo
        '
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle28.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colInvoiceDetailsVisitNo.DefaultCellStyle = DataGridViewCellStyle28
        Me.colInvoiceDetailsVisitNo.HeaderText = "Visit Number"
        Me.colInvoiceDetailsVisitNo.Name = "colInvoiceDetailsVisitNo"
        Me.colInvoiceDetailsVisitNo.ReadOnly = True
        Me.colInvoiceDetailsVisitNo.Width = 75
        '
        'colInvoiceDetailsBillPrice
        '
        Me.colInvoiceDetailsBillPrice.DataPropertyName = "BillPrice"
        Me.colInvoiceDetailsBillPrice.HeaderText = "Bill Price"
        Me.colInvoiceDetailsBillPrice.Name = "colInvoiceDetailsBillPrice"
        Me.colInvoiceDetailsBillPrice.ReadOnly = True
        Me.colInvoiceDetailsBillPrice.Visible = False
        '
        'colInvoiceDetailsVisitDate
        '
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceDetailsVisitDate.DefaultCellStyle = DataGridViewCellStyle29
        Me.colInvoiceDetailsVisitDate.HeaderText = "Visit Date"
        Me.colInvoiceDetailsVisitDate.Name = "colInvoiceDetailsVisitDate"
        Me.colInvoiceDetailsVisitDate.ReadOnly = True
        Me.colInvoiceDetailsVisitDate.Width = 70
        '
        'colInvoiceDetailsPatientNo
        '
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceDetailsPatientNo.DefaultCellStyle = DataGridViewCellStyle30
        Me.colInvoiceDetailsPatientNo.HeaderText = "Patient No"
        Me.colInvoiceDetailsPatientNo.Name = "colInvoiceDetailsPatientNo"
        Me.colInvoiceDetailsPatientNo.ReadOnly = True
        Me.colInvoiceDetailsPatientNo.Width = 70
        '
        'colInvoiceDetailsFullName
        '
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceDetailsFullName.DefaultCellStyle = DataGridViewCellStyle31
        Me.colInvoiceDetailsFullName.HeaderText = "Full Name"
        Me.colInvoiceDetailsFullName.Name = "colInvoiceDetailsFullName"
        Me.colInvoiceDetailsFullName.ReadOnly = True
        Me.colInvoiceDetailsFullName.Width = 80
        '
        'colInvoiceDetailsItemCode
        '
        DataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle32.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colInvoiceDetailsItemCode.DefaultCellStyle = DataGridViewCellStyle32
        Me.colInvoiceDetailsItemCode.HeaderText = "Item Code"
        Me.colInvoiceDetailsItemCode.Name = "colInvoiceDetailsItemCode"
        Me.colInvoiceDetailsItemCode.ReadOnly = True
        Me.colInvoiceDetailsItemCode.Width = 65
        '
        'ColMappedCodeVisitNo
        '
        Me.ColMappedCodeVisitNo.HeaderText = "Mapped Code"
        Me.ColMappedCodeVisitNo.Name = "ColMappedCodeVisitNo"
        '
        'colInvoiceDetailsItemName
        '
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle33.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colInvoiceDetailsItemName.DefaultCellStyle = DataGridViewCellStyle33
        Me.colInvoiceDetailsItemName.HeaderText = "Item Name"
        Me.colInvoiceDetailsItemName.Name = "colInvoiceDetailsItemName"
        Me.colInvoiceDetailsItemName.ReadOnly = True
        Me.colInvoiceDetailsItemName.Width = 80
        '
        'colInvoiceDetailsCategory
        '
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle34.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colInvoiceDetailsCategory.DefaultCellStyle = DataGridViewCellStyle34
        Me.colInvoiceDetailsCategory.HeaderText = "Category"
        Me.colInvoiceDetailsCategory.Name = "colInvoiceDetailsCategory"
        Me.colInvoiceDetailsCategory.ReadOnly = True
        Me.colInvoiceDetailsCategory.Width = 70
        '
        'colInvoiceDetailsQuantity
        '
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle35.Format = "N0"
        DataGridViewCellStyle35.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle35.NullValue = Nothing
        Me.colInvoiceDetailsQuantity.DefaultCellStyle = DataGridViewCellStyle35
        Me.colInvoiceDetailsQuantity.HeaderText = "Quantity"
        Me.colInvoiceDetailsQuantity.Name = "colInvoiceDetailsQuantity"
        Me.colInvoiceDetailsQuantity.Width = 50
        '
        'colInvoiceDetailsUnitPrice
        '
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle36.Format = "N2"
        DataGridViewCellStyle36.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle36.NullValue = Nothing
        Me.colInvoiceDetailsUnitPrice.DefaultCellStyle = DataGridViewCellStyle36
        Me.colInvoiceDetailsUnitPrice.HeaderText = "Unit Price"
        Me.colInvoiceDetailsUnitPrice.Name = "colInvoiceDetailsUnitPrice"
        Me.colInvoiceDetailsUnitPrice.Width = 60
        '
        'colInvoiceDetailsDiscount
        '
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle37.Format = "N2"
        DataGridViewCellStyle37.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colInvoiceDetailsDiscount.DefaultCellStyle = DataGridViewCellStyle37
        Me.colInvoiceDetailsDiscount.HeaderText = "Discount"
        Me.colInvoiceDetailsDiscount.Name = "colInvoiceDetailsDiscount"
        Me.colInvoiceDetailsDiscount.Width = 60
        '
        'colInvoiceDetailsDisplayAmount
        '
        Me.colInvoiceDetailsDisplayAmount.HeaderText = "Amount"
        Me.colInvoiceDetailsDisplayAmount.Name = "colInvoiceDetailsDisplayAmount"
        '
        'colInvoiceDetailsAmount
        '
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle38.Format = "N2"
        DataGridViewCellStyle38.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle38.NullValue = Nothing
        Me.colInvoiceDetailsAmount.DefaultCellStyle = DataGridViewCellStyle38
        Me.colInvoiceDetailsAmount.HeaderText = "Amount"
        Me.colInvoiceDetailsAmount.Name = "colInvoiceDetailsAmount"
        Me.colInvoiceDetailsAmount.ReadOnly = True
        Me.colInvoiceDetailsAmount.Width = 80
        '
        'colInvoiceDetailsItemStatus
        '
        DataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceDetailsItemStatus.DefaultCellStyle = DataGridViewCellStyle39
        Me.colInvoiceDetailsItemStatus.HeaderText = "Item Status"
        Me.colInvoiceDetailsItemStatus.Name = "colInvoiceDetailsItemStatus"
        Me.colInvoiceDetailsItemStatus.ReadOnly = True
        Me.colInvoiceDetailsItemStatus.Width = 70
        '
        'colInvoiceDetailsMemberCardNo
        '
        DataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceDetailsMemberCardNo.DefaultCellStyle = DataGridViewCellStyle40
        Me.colInvoiceDetailsMemberCardNo.HeaderText = "Member Card No"
        Me.colInvoiceDetailsMemberCardNo.Name = "colInvoiceDetailsMemberCardNo"
        Me.colInvoiceDetailsMemberCardNo.ReadOnly = True
        '
        'colInvoiceDetailsMainMemberName
        '
        DataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceDetailsMainMemberName.DefaultCellStyle = DataGridViewCellStyle41
        Me.colInvoiceDetailsMainMemberName.HeaderText = "Main Member Name"
        Me.colInvoiceDetailsMainMemberName.Name = "colInvoiceDetailsMainMemberName"
        Me.colInvoiceDetailsMainMemberName.ReadOnly = True
        Me.colInvoiceDetailsMainMemberName.Width = 115
        '
        'colInvoiceDetailsClaimReferenceNo
        '
        DataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceDetailsClaimReferenceNo.DefaultCellStyle = DataGridViewCellStyle42
        Me.colInvoiceDetailsClaimReferenceNo.HeaderText = "Claim Reference No"
        Me.colInvoiceDetailsClaimReferenceNo.Name = "colInvoiceDetailsClaimReferenceNo"
        Me.colInvoiceDetailsClaimReferenceNo.ReadOnly = True
        Me.colInvoiceDetailsClaimReferenceNo.Width = 110
        '
        'colInvoiceDetailsBillCustomerName
        '
        DataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceDetailsBillCustomerName.DefaultCellStyle = DataGridViewCellStyle43
        Me.colInvoiceDetailsBillCustomerName.HeaderText = "To-Bill Customer Name"
        Me.colInvoiceDetailsBillCustomerName.Name = "colInvoiceDetailsBillCustomerName"
        Me.colInvoiceDetailsBillCustomerName.ReadOnly = True
        Me.colInvoiceDetailsBillCustomerName.Width = 120
        '
        'colInvoiceDetailsCoPayType
        '
        DataGridViewCellStyle44.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceDetailsCoPayType.DefaultCellStyle = DataGridViewCellStyle44
        Me.colInvoiceDetailsCoPayType.HeaderText = "Co-Pay Type"
        Me.colInvoiceDetailsCoPayType.Name = "colInvoiceDetailsCoPayType"
        Me.colInvoiceDetailsCoPayType.ReadOnly = True
        Me.colInvoiceDetailsCoPayType.Width = 80
        '
        'colInvoiceDetailsCopayPercent
        '
        DataGridViewCellStyle45.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle45.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle45.Format = "N2"
        DataGridViewCellStyle45.NullValue = Nothing
        Me.colInvoiceDetailsCopayPercent.DefaultCellStyle = DataGridViewCellStyle45
        Me.colInvoiceDetailsCopayPercent.HeaderText = "Co-Pay Percent"
        Me.colInvoiceDetailsCopayPercent.Name = "colInvoiceDetailsCopayPercent"
        Me.colInvoiceDetailsCopayPercent.ReadOnly = True
        '
        'colInvoiceDetailsCoPayValue
        '
        DataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle46.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle46.Format = "N2"
        DataGridViewCellStyle46.NullValue = Nothing
        Me.colInvoiceDetailsCoPayValue.DefaultCellStyle = DataGridViewCellStyle46
        Me.colInvoiceDetailsCoPayValue.HeaderText = "Co-Pay Value"
        Me.colInvoiceDetailsCoPayValue.Name = "colInvoiceDetailsCoPayValue"
        Me.colInvoiceDetailsCoPayValue.ReadOnly = True
        Me.colInvoiceDetailsCoPayValue.Width = 80
        '
        'colInvoiceDetailsItemCategoryID
        '
        DataGridViewCellStyle47.BackColor = System.Drawing.SystemColors.Info
        Me.colInvoiceDetailsItemCategoryID.DefaultCellStyle = DataGridViewCellStyle47
        Me.colInvoiceDetailsItemCategoryID.HeaderText = "Item Category ID"
        Me.colInvoiceDetailsItemCategoryID.Name = "colInvoiceDetailsItemCategoryID"
        Me.colInvoiceDetailsItemCategoryID.ReadOnly = True
        Me.colInvoiceDetailsItemCategoryID.Visible = False
        '
        'colInvoiceDetailsSaved
        '
        DataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle48.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle48.NullValue = False
        Me.colInvoiceDetailsSaved.DefaultCellStyle = DataGridViewCellStyle48
        Me.colInvoiceDetailsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInvoiceDetailsSaved.HeaderText = "Saved"
        Me.colInvoiceDetailsSaved.Name = "colInvoiceDetailsSaved"
        Me.colInvoiceDetailsSaved.ReadOnly = True
        Me.colInvoiceDetailsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInvoiceDetailsSaved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colInvoiceDetailsSaved.Width = 50
        '
        'frmIPDInvoices
        '
        Me.AcceptButton = Me.btnLoadPendingBillsPayment
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(902, 529)
        Me.Controls.Add(Me.lblLoadInvoices)
        Me.Controls.Add(Me.fbnLoadInvoices)
        Me.Controls.Add(Me.chkPrintInvoiceDetailedOnSaving)
        Me.Controls.Add(Me.chkReconciliationRequired)
        Me.Controls.Add(Me.tbcIPDInvoiceDetails)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.chkIncludeOPDBill)
        Me.Controls.Add(Me.chkPrintInvoiceOnSaving)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.pnlNavigateVisits)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.cboBillModesID)
        Me.Controls.Add(Me.lblBillModesID)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.cboBillAccountNo)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.lblBillAccountNo)
        Me.Controls.Add(Me.grpSetParameters)
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
        Me.Name = "frmIPDInvoices"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IPD Invoices"
        Me.cmsInvoiceExtraBillItems.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.pnlNavigateVisits.ResumeLayout(False)
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.tbcIPDInvoiceDetails.ResumeLayout(False)
        Me.tpgIPDInvoiceDetails.ResumeLayout(False)
        CType(Me.dgvInvoiceExtraBillItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOPDBill.ResumeLayout(False)
        Me.pnlOPDBill.ResumeLayout(False)
        Me.pnlOPDBill.PerformLayout()
        CType(Me.dgvInvoiceDetails, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents lblBillForItem As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents cmsInvoiceExtraBillItems As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsInvoiceExtraBillItemsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsInvoiceExtraBillItemsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents navVisits As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents chkNavigateVisits As System.Windows.Forms.CheckBox
    Friend WithEvents pnlNavigateVisits As System.Windows.Forms.Panel
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents chkPrintInvoiceOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncludeOPDBill As System.Windows.Forms.CheckBox
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents tbcIPDInvoiceDetails As SyncSoft.Common.Win.Controls.SmartTabControl
    Friend WithEvents tpgIPDInvoiceDetails As System.Windows.Forms.TabPage
    Friend WithEvents dgvInvoiceExtraBillItems As System.Windows.Forms.DataGridView
    Friend WithEvents tpgOPDBill As System.Windows.Forms.TabPage
    Friend WithEvents pnlOPDBill As System.Windows.Forms.Panel
    Friend WithEvents stbInvoiceDetailsAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInvoiceDetailsBillForItem As System.Windows.Forms.Label
    Friend WithEvents stbInvoiceDetailsTotalBill As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForInvoiceDetailsItem As System.Windows.Forms.Label
    Friend WithEvents dgvInvoiceDetails As System.Windows.Forms.DataGridView
    Friend WithEvents chkReconciliationRequired As System.Windows.Forms.CheckBox
    Friend WithEvents chkPrintInvoiceDetailedOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents lblLoadInvoices As System.Windows.Forms.Label
    Friend WithEvents fbnLoadInvoices As System.Windows.Forms.Button
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraBillDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMappedCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDisplayAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberCardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMainMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClaimReferenceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCoPayType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCoPayPercent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCoPayValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colInvoiceDetailsVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsBillPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMappedCodeVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsDisplayAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsMemberCardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsMainMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsClaimReferenceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsCoPayType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsCopayPercent As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsCoPayValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInvoiceDetailsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class