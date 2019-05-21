
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmServiceInvoices : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal ServiceInvoiceNo As String)
        MyClass.New()
        Me.defaultServiceInvoiceNo = ServiceInvoiceNo
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
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServiceInvoices))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
        Me.stbDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbShipAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSupplierName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboSupplierNo = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbServiceInvoiceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblServiceInvoiceNo = New System.Windows.Forms.Label()
        Me.lblInvoiceDate = New System.Windows.Forms.Label()
        Me.stbClientMachine = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClientMachine = New System.Windows.Forms.Label()
        Me.cmsServiceInvoices = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsServiceInvoicesQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblDocumentNo = New System.Windows.Forms.Label()
        Me.lblShipAddress = New System.Windows.Forms.Label()
        Me.lblSupplierName = New System.Windows.Forms.Label()
        Me.lblSupplierNo = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.pnlPrintOnSaving = New System.Windows.Forms.Panel()
        Me.chkPrintOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.tbcServiceInvoices = New System.Windows.Forms.TabControl()
        Me.tpgOthers = New System.Windows.Forms.TabPage()
        Me.dgvOtherItems = New System.Windows.Forms.DataGridView()
        Me.colOtherItemselect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colOtherItemsNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsItemGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsPack = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColOtherItemsPackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsTotalUnits = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsVATPercentage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsVATValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOtherItemsNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherItemsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVATValue = New System.Windows.Forms.Label()
        Me.stbVATValue = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForItem = New System.Windows.Forms.Label()
        Me.cmsServiceInvoices.SuspendLayout()
        Me.pnlPrintOnSaving.SuspendLayout()
        Me.tbcServiceInvoices.SuspendLayout()
        Me.tpgOthers.SuspendLayout()
        CType(Me.dgvOtherItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBill.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 407)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 15
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(975, 406)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 16
        Me.fbnDelete.Tag = "ServiceInvoices"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 432)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 17
        Me.ebnSaveUpdate.Tag = "ServiceInvoices"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpInvoiceDate
        '
        Me.dtpInvoiceDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpInvoiceDate, "InvoiceDate")
        Me.dtpInvoiceDate.Location = New System.Drawing.Point(165, 26)
        Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
        Me.dtpInvoiceDate.ShowCheckBox = True
        Me.dtpInvoiceDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpInvoiceDate.TabIndex = 4
        '
        'stbDocumentNo
        '
        Me.stbDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDocumentNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDocumentNo, "DocumentNo")
        Me.stbDocumentNo.EntryErrorMSG = ""
        Me.stbDocumentNo.Location = New System.Drawing.Point(165, 46)
        Me.stbDocumentNo.MaxLength = 20
        Me.stbDocumentNo.Name = "stbDocumentNo"
        Me.stbDocumentNo.RegularExpression = ""
        Me.stbDocumentNo.Size = New System.Drawing.Size(179, 20)
        Me.stbDocumentNo.TabIndex = 6
        '
        'stbShipAddress
        '
        Me.stbShipAddress.AcceptsReturn = True
        Me.stbShipAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbShipAddress.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbShipAddress, "ShipAddress")
        Me.stbShipAddress.EntryErrorMSG = ""
        Me.stbShipAddress.Location = New System.Drawing.Point(509, 6)
        Me.stbShipAddress.MaxLength = 300
        Me.stbShipAddress.Multiline = True
        Me.stbShipAddress.Name = "stbShipAddress"
        Me.stbShipAddress.RegularExpression = ""
        Me.stbShipAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbShipAddress.Size = New System.Drawing.Size(304, 60)
        Me.stbShipAddress.TabIndex = 12
        '
        'stbSupplierName
        '
        Me.stbSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSupplierName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbSupplierName, "SupplierName")
        Me.stbSupplierName.EntryErrorMSG = ""
        Me.stbSupplierName.Location = New System.Drawing.Point(165, 90)
        Me.stbSupplierName.MaxLength = 60
        Me.stbSupplierName.Multiline = True
        Me.stbSupplierName.Name = "stbSupplierName"
        Me.stbSupplierName.ReadOnly = True
        Me.stbSupplierName.RegularExpression = ""
        Me.stbSupplierName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbSupplierName.Size = New System.Drawing.Size(179, 35)
        Me.stbSupplierName.TabIndex = 10
        '
        'cboSupplierNo
        '
        Me.cboSupplierNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSupplierNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSupplierNo.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboSupplierNo, "SupplierNo")
        Me.cboSupplierNo.DropDownWidth = 256
        Me.cboSupplierNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSupplierNo.FormattingEnabled = True
        Me.cboSupplierNo.ItemHeight = 13
        Me.cboSupplierNo.Location = New System.Drawing.Point(165, 67)
        Me.cboSupplierNo.Name = "cboSupplierNo"
        Me.cboSupplierNo.Size = New System.Drawing.Size(179, 21)
        Me.cboSupplierNo.TabIndex = 8
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(975, 432)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 20
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbServiceInvoiceNo
        '
        Me.stbServiceInvoiceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbServiceInvoiceNo.CapitalizeFirstLetter = False
        Me.stbServiceInvoiceNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbServiceInvoiceNo.Enabled = False
        Me.stbServiceInvoiceNo.EntryErrorMSG = ""
        Me.stbServiceInvoiceNo.Location = New System.Drawing.Point(165, 5)
        Me.stbServiceInvoiceNo.MaxLength = 20
        Me.stbServiceInvoiceNo.Name = "stbServiceInvoiceNo"
        Me.stbServiceInvoiceNo.ReadOnly = True
        Me.stbServiceInvoiceNo.RegularExpression = ""
        Me.stbServiceInvoiceNo.Size = New System.Drawing.Size(127, 20)
        Me.stbServiceInvoiceNo.TabIndex = 1
        '
        'lblServiceInvoiceNo
        '
        Me.lblServiceInvoiceNo.Location = New System.Drawing.Point(12, 7)
        Me.lblServiceInvoiceNo.Name = "lblServiceInvoiceNo"
        Me.lblServiceInvoiceNo.Size = New System.Drawing.Size(147, 20)
        Me.lblServiceInvoiceNo.TabIndex = 0
        Me.lblServiceInvoiceNo.Text = "Invoice No"
        '
        'lblInvoiceDate
        '
        Me.lblInvoiceDate.Location = New System.Drawing.Point(12, 28)
        Me.lblInvoiceDate.Name = "lblInvoiceDate"
        Me.lblInvoiceDate.Size = New System.Drawing.Size(147, 20)
        Me.lblInvoiceDate.TabIndex = 3
        Me.lblInvoiceDate.Text = "Invoice Date"
        '
        'stbClientMachine
        '
        Me.stbClientMachine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClientMachine.CapitalizeFirstLetter = False
        Me.stbClientMachine.EntryErrorMSG = ""
        Me.stbClientMachine.Location = New System.Drawing.Point(0, 0)
        Me.stbClientMachine.Name = "stbClientMachine"
        Me.stbClientMachine.RegularExpression = ""
        Me.stbClientMachine.Size = New System.Drawing.Size(100, 20)
        Me.stbClientMachine.TabIndex = 0
        '
        'lblClientMachine
        '
        Me.lblClientMachine.Location = New System.Drawing.Point(0, 0)
        Me.lblClientMachine.Name = "lblClientMachine"
        Me.lblClientMachine.Size = New System.Drawing.Size(100, 23)
        Me.lblClientMachine.TabIndex = 0
        '
        'cmsServiceInvoices
        '
        Me.cmsServiceInvoices.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsServiceInvoices.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsServiceInvoicesQuickSearch})
        Me.cmsServiceInvoices.Name = "cmsSearch"
        Me.cmsServiceInvoices.Size = New System.Drawing.Size(144, 26)
        '
        'cmsServiceInvoicesQuickSearch
        '
        Me.cmsServiceInvoicesQuickSearch.Name = "cmsServiceInvoicesQuickSearch"
        Me.cmsServiceInvoicesQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsServiceInvoicesQuickSearch.Text = "Quick Search"
        '
        'lblDocumentNo
        '
        Me.lblDocumentNo.Location = New System.Drawing.Point(12, 47)
        Me.lblDocumentNo.Name = "lblDocumentNo"
        Me.lblDocumentNo.Size = New System.Drawing.Size(147, 20)
        Me.lblDocumentNo.TabIndex = 5
        Me.lblDocumentNo.Text = "Document No"
        '
        'lblShipAddress
        '
        Me.lblShipAddress.Location = New System.Drawing.Point(365, 9)
        Me.lblShipAddress.Name = "lblShipAddress"
        Me.lblShipAddress.Size = New System.Drawing.Size(141, 20)
        Me.lblShipAddress.TabIndex = 11
        Me.lblShipAddress.Text = "Ship To Address"
        '
        'lblSupplierName
        '
        Me.lblSupplierName.Location = New System.Drawing.Point(12, 97)
        Me.lblSupplierName.Name = "lblSupplierName"
        Me.lblSupplierName.Size = New System.Drawing.Size(147, 20)
        Me.lblSupplierName.TabIndex = 9
        Me.lblSupplierName.Text = "Supplier Name"
        '
        'lblSupplierNo
        '
        Me.lblSupplierNo.Location = New System.Drawing.Point(12, 69)
        Me.lblSupplierNo.Name = "lblSupplierNo"
        Me.lblSupplierNo.Size = New System.Drawing.Size(147, 20)
        Me.lblSupplierNo.TabIndex = 7
        Me.lblSupplierNo.Text = "Supplier Number"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(298, 2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 23)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'pnlPrintOnSaving
        '
        Me.pnlPrintOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPrintOnSaving.Controls.Add(Me.chkPrintOnSaving)
        Me.pnlPrintOnSaving.Location = New System.Drawing.Point(98, 425)
        Me.pnlPrintOnSaving.Name = "pnlPrintOnSaving"
        Me.pnlPrintOnSaving.Size = New System.Drawing.Size(225, 31)
        Me.pnlPrintOnSaving.TabIndex = 18
        '
        'chkPrintOnSaving
        '
        Me.chkPrintOnSaving.AccessibleDescription = ""
        Me.chkPrintOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintOnSaving.AutoSize = True
        Me.chkPrintOnSaving.Checked = True
        Me.chkPrintOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintOnSaving.Location = New System.Drawing.Point(3, 11)
        Me.chkPrintOnSaving.Name = "chkPrintOnSaving"
        Me.chkPrintOnSaving.Size = New System.Drawing.Size(127, 17)
        Me.chkPrintOnSaving.TabIndex = 0
        Me.chkPrintOnSaving.Text = " Print LPO On Saving"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(897, 432)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 19
        Me.btnPrint.Text = "&Print"
        '
        'tbcServiceInvoices
        '
        Me.tbcServiceInvoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcServiceInvoices.Controls.Add(Me.tpgOthers)
        Me.tbcServiceInvoices.HotTrack = True
        Me.tbcServiceInvoices.Location = New System.Drawing.Point(15, 131)
        Me.tbcServiceInvoices.Name = "tbcServiceInvoices"
        Me.tbcServiceInvoices.SelectedIndex = 0
        Me.tbcServiceInvoices.Size = New System.Drawing.Size(1037, 269)
        Me.tbcServiceInvoices.TabIndex = 25
        '
        'tpgOthers
        '
        Me.tpgOthers.Controls.Add(Me.dgvOtherItems)
        Me.tpgOthers.Location = New System.Drawing.Point(4, 22)
        Me.tpgOthers.Name = "tpgOthers"
        Me.tpgOthers.Size = New System.Drawing.Size(1029, 243)
        Me.tpgOthers.TabIndex = 13
        Me.tpgOthers.Tag = ""
        Me.tpgOthers.Text = "Service Information"
        Me.tpgOthers.UseVisualStyleBackColor = True
        '
        'dgvOtherItems
        '
        Me.dgvOtherItems.AllowUserToOrderColumns = True
        Me.dgvOtherItems.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOtherItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOtherItemselect, Me.colOtherItemsNo, Me.ColOtherItemsItemName, Me.ColOtherItemsUnitMeasure, Me.ColOtherItemsItemGroup, Me.colOtherItemsPack, Me.ColOtherItemsPackSize, Me.ColOtherItemsQuantity, Me.colOtherItemsTotalUnits, Me.ColOtherItemsRate, Me.ColOtherItemsVATPercentage, Me.ColOtherItemsVATValue, Me.ColOtherItemsAmount, Me.ColOtherItemsNotes, Me.colOtherItemPayStatus, Me.colOtherItemsSaved})
        Me.dgvOtherItems.ContextMenuStrip = Me.cmsServiceInvoices
        Me.dgvOtherItems.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOtherItems.EnableHeadersVisualStyles = False
        Me.dgvOtherItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvOtherItems.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvOtherItems.Location = New System.Drawing.Point(0, 0)
        Me.dgvOtherItems.Name = "dgvOtherItems"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvOtherItems.Size = New System.Drawing.Size(1029, 243)
        Me.dgvOtherItems.TabIndex = 47
        Me.dgvOtherItems.Text = "DataGridView2"
        '
        'colOtherItemselect
        '
        Me.colOtherItemselect.DataPropertyName = "VATPercentage"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.colOtherItemselect.DefaultCellStyle = DataGridViewCellStyle2
        Me.colOtherItemselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOtherItemselect.HeaderText = "Select"
        Me.colOtherItemselect.Name = "colOtherItemselect"
        Me.colOtherItemselect.ReadOnly = True
        Me.colOtherItemselect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colOtherItemselect.Text = "•••"
        Me.colOtherItemselect.UseColumnTextForButtonValue = True
        Me.colOtherItemselect.Width = 50
        '
        'colOtherItemsNo
        '
        Me.colOtherItemsNo.DataPropertyName = "ItemCode"
        Me.colOtherItemsNo.HeaderText = "Item No"
        Me.colOtherItemsNo.MaxInputLength = 20
        Me.colOtherItemsNo.Name = "colOtherItemsNo"
        Me.colOtherItemsNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colOtherItemsNo.Width = 90
        '
        'ColOtherItemsItemName
        '
        Me.ColOtherItemsItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.ColOtherItemsItemName.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColOtherItemsItemName.HeaderText = "Item Name"
        Me.ColOtherItemsItemName.MaxInputLength = 100
        Me.ColOtherItemsItemName.Name = "ColOtherItemsItemName"
        Me.ColOtherItemsItemName.ReadOnly = True
        Me.ColOtherItemsItemName.Width = 140
        '
        'ColOtherItemsUnitMeasure
        '
        Me.ColOtherItemsUnitMeasure.DataPropertyName = "UnitMeasure"
        Me.ColOtherItemsUnitMeasure.HeaderText = "Unit Measure"
        Me.ColOtherItemsUnitMeasure.MaxInputLength = 100
        Me.ColOtherItemsUnitMeasure.Name = "ColOtherItemsUnitMeasure"
        Me.ColOtherItemsUnitMeasure.Width = 80
        '
        'ColOtherItemsItemGroup
        '
        Me.ColOtherItemsItemGroup.DataPropertyName = "ItemGroup"
        Me.ColOtherItemsItemGroup.HeaderText = "Item Group"
        Me.ColOtherItemsItemGroup.MaxInputLength = 100
        Me.ColOtherItemsItemGroup.Name = "ColOtherItemsItemGroup"
        Me.ColOtherItemsItemGroup.Width = 80
        '
        'colOtherItemsPack
        '
        Me.colOtherItemsPack.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colOtherItemsPack.HeaderText = "Pack"
        Me.colOtherItemsPack.Name = "colOtherItemsPack"
        Me.colOtherItemsPack.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colOtherItemsPack.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColOtherItemsPackSize
        '
        Me.ColOtherItemsPackSize.DataPropertyName = "PackSize"
        Me.ColOtherItemsPackSize.HeaderText = "PackSize"
        Me.ColOtherItemsPackSize.Name = "ColOtherItemsPackSize"
        '
        'ColOtherItemsQuantity
        '
        Me.ColOtherItemsQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.NullValue = Nothing
        Me.ColOtherItemsQuantity.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColOtherItemsQuantity.HeaderText = "Quantity"
        Me.ColOtherItemsQuantity.MaxInputLength = 12
        Me.ColOtherItemsQuantity.Name = "ColOtherItemsQuantity"
        Me.ColOtherItemsQuantity.Width = 60
        '
        'colOtherItemsTotalUnits
        '
        Me.colOtherItemsTotalUnits.DataPropertyName = "TotalOrdered"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colOtherItemsTotalUnits.DefaultCellStyle = DataGridViewCellStyle5
        Me.colOtherItemsTotalUnits.HeaderText = "Total Units"
        Me.colOtherItemsTotalUnits.Name = "colOtherItemsTotalUnits"
        Me.colOtherItemsTotalUnits.ReadOnly = True
        '
        'ColOtherItemsRate
        '
        Me.ColOtherItemsRate.DataPropertyName = "Rate"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ColOtherItemsRate.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColOtherItemsRate.HeaderText = "Rate"
        Me.ColOtherItemsRate.MaxInputLength = 12
        Me.ColOtherItemsRate.Name = "ColOtherItemsRate"
        Me.ColOtherItemsRate.Width = 80
        '
        'ColOtherItemsVATPercentage
        '
        Me.ColOtherItemsVATPercentage.DataPropertyName = "VATPercentage"
        Me.ColOtherItemsVATPercentage.HeaderText = "VAT Percentage"
        Me.ColOtherItemsVATPercentage.Name = "ColOtherItemsVATPercentage"
        Me.ColOtherItemsVATPercentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic
        '
        'ColOtherItemsVATValue
        '
        Me.ColOtherItemsVATValue.DataPropertyName = "VATValue"
        Me.ColOtherItemsVATValue.HeaderText = "VAT Value"
        Me.ColOtherItemsVATValue.Name = "ColOtherItemsVATValue"
        Me.ColOtherItemsVATValue.ReadOnly = True
        '
        'ColOtherItemsAmount
        '
        Me.ColOtherItemsAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.ColOtherItemsAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColOtherItemsAmount.HeaderText = "Amount"
        Me.ColOtherItemsAmount.MaxInputLength = 12
        Me.ColOtherItemsAmount.Name = "ColOtherItemsAmount"
        '
        'ColOtherItemsNotes
        '
        Me.ColOtherItemsNotes.DataPropertyName = "Notes"
        Me.ColOtherItemsNotes.HeaderText = "Notes"
        Me.ColOtherItemsNotes.MaxInputLength = 200
        Me.ColOtherItemsNotes.Name = "ColOtherItemsNotes"
        Me.ColOtherItemsNotes.Width = 80
        '
        'colOtherItemPayStatus
        '
        Me.colOtherItemPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colOtherItemPayStatus.DefaultCellStyle = DataGridViewCellStyle8
        Me.colOtherItemPayStatus.HeaderText = "Pay Status"
        Me.colOtherItemPayStatus.MaxInputLength = 100
        Me.colOtherItemPayStatus.Name = "colOtherItemPayStatus"
        Me.colOtherItemPayStatus.ReadOnly = True
        Me.colOtherItemPayStatus.Visible = False
        Me.colOtherItemPayStatus.Width = 80
        '
        'colOtherItemsSaved
        '
        Me.colOtherItemsSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = False
        Me.colOtherItemsSaved.DefaultCellStyle = DataGridViewCellStyle9
        Me.colOtherItemsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOtherItemsSaved.HeaderText = "Saved"
        Me.colOtherItemsSaved.Name = "colOtherItemsSaved"
        Me.colOtherItemsSaved.ReadOnly = True
        Me.colOtherItemsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colOtherItemsSaved.Width = 50
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblVATValue)
        Me.pnlBill.Controls.Add(Me.stbVATValue)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(350, 68)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(702, 49)
        Me.pnlBill.TabIndex = 26
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(366, 7)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(86, 18)
        Me.lblBillWords.TabIndex = 2
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForItem
        '
        Me.stbBillForItem.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForItem.CapitalizeFirstLetter = False
        Me.stbBillForItem.Enabled = False
        Me.stbBillForItem.EntryErrorMSG = ""
        Me.stbBillForItem.Location = New System.Drawing.Point(162, 26)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(198, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(458, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(238, 43)
        Me.stbBillWords.TabIndex = 3
        '
        'lblVATValue
        '
        Me.lblVATValue.Location = New System.Drawing.Point(14, 7)
        Me.lblVATValue.Name = "lblVATValue"
        Me.lblVATValue.Size = New System.Drawing.Size(120, 18)
        Me.lblVATValue.TabIndex = 0
        Me.lblVATValue.Text = "VAT Value"
        '
        'stbVATValue
        '
        Me.stbVATValue.BackColor = System.Drawing.SystemColors.Info
        Me.stbVATValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVATValue.CapitalizeFirstLetter = False
        Me.stbVATValue.Enabled = False
        Me.stbVATValue.EntryErrorMSG = ""
        Me.stbVATValue.Location = New System.Drawing.Point(162, 5)
        Me.stbVATValue.MaxLength = 20
        Me.stbVATValue.Name = "stbVATValue"
        Me.stbVATValue.RegularExpression = ""
        Me.stbVATValue.Size = New System.Drawing.Size(198, 20)
        Me.stbVATValue.TabIndex = 1
        Me.stbVATValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(14, 28)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(120, 18)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Bill Amount"
        '
        'frmServiceInvoices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1059, 471)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.tbcServiceInvoices)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.pnlPrintOnSaving)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.stbSupplierName)
        Me.Controls.Add(Me.cboSupplierNo)
        Me.Controls.Add(Me.lblSupplierName)
        Me.Controls.Add(Me.lblSupplierNo)
        Me.Controls.Add(Me.stbDocumentNo)
        Me.Controls.Add(Me.lblDocumentNo)
        Me.Controls.Add(Me.stbShipAddress)
        Me.Controls.Add(Me.lblShipAddress)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbServiceInvoiceNo)
        Me.Controls.Add(Me.lblServiceInvoiceNo)
        Me.Controls.Add(Me.dtpInvoiceDate)
        Me.Controls.Add(Me.lblInvoiceDate)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmServiceInvoices"
        Me.Text = "Service Invoices"
        Me.cmsServiceInvoices.ResumeLayout(False)
        Me.pnlPrintOnSaving.ResumeLayout(False)
        Me.pnlPrintOnSaving.PerformLayout()
        Me.tbcServiceInvoices.ResumeLayout(False)
        Me.tpgOthers.ResumeLayout(False)
        CType(Me.dgvOtherItems,System.ComponentModel.ISupportInitialize).EndInit
        Me.pnlBill.ResumeLayout(false)
        Me.pnlBill.PerformLayout
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbServiceInvoiceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblServiceInvoiceNo As System.Windows.Forms.Label
    Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
    Friend WithEvents stbClientMachine As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClientMachine As System.Windows.Forms.Label
    Friend WithEvents cmsServiceInvoices As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsServiceInvoicesQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDocumentNo As System.Windows.Forms.Label
    Friend WithEvents stbShipAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblShipAddress As System.Windows.Forms.Label
    Friend WithEvents stbSupplierName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboSupplierNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblSupplierName As System.Windows.Forms.Label
    Friend WithEvents lblSupplierNo As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents pnlPrintOnSaving As System.Windows.Forms.Panel
    Friend WithEvents chkPrintOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents tbcServiceInvoices As TabControl
    Friend WithEvents pnlBill As Panel
    Friend WithEvents lblBillWords As Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVATValue As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForItem As Label
    Friend WithEvents lblVATValue As Label
    Friend WithEvents tpgOthers As System.Windows.Forms.TabPage
    Friend WithEvents dgvOtherItems As System.Windows.Forms.DataGridView
    Friend WithEvents colOtherItemselect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colOtherItemsNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsItemGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsPack As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColOtherItemsPackSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsTotalUnits As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsVATPercentage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsVATValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOtherItemsNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOtherItemsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class