
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGoodsReturnedNote : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGoodsReturnedNote))
        Me.fbnSave = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpReturnDate = New System.Windows.Forms.DateTimePicker()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpRecievedDate = New System.Windows.Forms.DateTimePicker()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblGRNNo = New System.Windows.Forms.Label()
        Me.lblReturnDate = New System.Windows.Forms.Label()
        Me.lblAmountWords = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblPurchaseOrderNo = New System.Windows.Forms.Label()
        Me.stbPurchaseOrderNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stbSupplierName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.stbGoodReceivedNoteNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblReceivedDate = New System.Windows.Forms.Label()
        Me.stbReturnNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblReturnNo = New System.Windows.Forms.Label()
        Me.stbLocation = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDeliveryLocation = New System.Windows.Forms.Label()
        Me.pnlPrintOnSaving = New System.Windows.Forms.Panel()
        Me.chkPrintOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblReturnAmount = New System.Windows.Forms.Label()
        Me.stbTotalReturnAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbReturnAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblReturnAmountWords = New System.Windows.Forms.Label()
        Me.dgvGoodsReturnedNoteDetails = New System.Windows.Forms.DataGridView()
        Me.colSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReceivedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPreviousReturned = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsAtHand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnReason = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.pnlPrintOnSaving.SuspendLayout()
        CType(Me.dgvGoodsReturnedNoteDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSave
        '
        Me.fbnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSave.DataSource = Nothing
        Me.fbnSave.Enabled = False
        Me.fbnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSave.Location = New System.Drawing.Point(6, 446)
        Me.fbnSave.Name = "fbnSave"
        Me.fbnSave.Size = New System.Drawing.Size(77, 23)
        Me.fbnSave.TabIndex = 24
        Me.fbnSave.Tag = "GoodsReturnedNote"
        Me.fbnSave.Text = "&Save"
        Me.fbnSave.UseVisualStyleBackColor = False
        '
        'dtpReturnDate
        '
        Me.dtpReturnDate.Checked = False
        Me.fbnSave.SetDataMember(Me.dtpReturnDate, "ReturnDate")
        Me.dtpReturnDate.Location = New System.Drawing.Point(132, 47)
        Me.dtpReturnDate.Name = "dtpReturnDate"
        Me.dtpReturnDate.ShowCheckBox = True
        Me.dtpReturnDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpReturnDate.TabIndex = 6
        '
        'stbAmountWords
        '
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = False
        Me.fbnSave.SetDataMember(Me.stbAmountWords, "AmountWords")
        Me.stbAmountWords.Enabled = False
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(513, 104)
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.Size = New System.Drawing.Size(255, 31)
        Me.stbAmountWords.TabIndex = 18
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = True
        Me.fbnSave.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(132, 69)
        Me.stbNotes.MaxLength = 100
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbNotes.Size = New System.Drawing.Size(223, 56)
        Me.stbNotes.TabIndex = 8
        '
        'dtpRecievedDate
        '
        Me.dtpRecievedDate.Checked = False
        Me.fbnSave.SetDataMember(Me.dtpRecievedDate, "ReturnDate")
        Me.dtpRecievedDate.Enabled = False
        Me.dtpRecievedDate.Location = New System.Drawing.Point(513, 5)
        Me.dtpRecievedDate.Name = "dtpRecievedDate"
        Me.dtpRecievedDate.ShowCheckBox = True
        Me.dtpRecievedDate.Size = New System.Drawing.Size(177, 20)
        Me.dtpRecievedDate.TabIndex = 10
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(899, 451)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 27
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblGRNNo
        '
        Me.lblGRNNo.Location = New System.Drawing.Point(9, 7)
        Me.lblGRNNo.Name = "lblGRNNo"
        Me.lblGRNNo.Size = New System.Drawing.Size(119, 20)
        Me.lblGRNNo.TabIndex = 0
        Me.lblGRNNo.Text = "GRN No"
        '
        'lblReturnDate
        '
        Me.lblReturnDate.Location = New System.Drawing.Point(9, 50)
        Me.lblReturnDate.Name = "lblReturnDate"
        Me.lblReturnDate.Size = New System.Drawing.Size(119, 20)
        Me.lblReturnDate.TabIndex = 5
        Me.lblReturnDate.Text = "Return Date"
        '
        'lblAmountWords
        '
        Me.lblAmountWords.Location = New System.Drawing.Point(378, 105)
        Me.lblAmountWords.Name = "lblAmountWords"
        Me.lblAmountWords.Size = New System.Drawing.Size(129, 20)
        Me.lblAmountWords.TabIndex = 17
        Me.lblAmountWords.Text = "Amount In Words"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(9, 73)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(119, 20)
        Me.lblNotes.TabIndex = 7
        Me.lblNotes.Text = "Notes"
        '
        'lblPurchaseOrderNo
        '
        Me.lblPurchaseOrderNo.Location = New System.Drawing.Point(378, 29)
        Me.lblPurchaseOrderNo.Name = "lblPurchaseOrderNo"
        Me.lblPurchaseOrderNo.Size = New System.Drawing.Size(129, 20)
        Me.lblPurchaseOrderNo.TabIndex = 11
        Me.lblPurchaseOrderNo.Text = "Purchase Order No"
        '
        'stbPurchaseOrderNo
        '
        Me.stbPurchaseOrderNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbPurchaseOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPurchaseOrderNo.CapitalizeFirstLetter = True
        Me.stbPurchaseOrderNo.Enabled = False
        Me.stbPurchaseOrderNo.EntryErrorMSG = ""
        Me.stbPurchaseOrderNo.Location = New System.Drawing.Point(513, 27)
        Me.stbPurchaseOrderNo.MaxLength = 60
        Me.stbPurchaseOrderNo.Name = "stbPurchaseOrderNo"
        Me.stbPurchaseOrderNo.ReadOnly = True
        Me.stbPurchaseOrderNo.RegularExpression = ""
        Me.stbPurchaseOrderNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPurchaseOrderNo.Size = New System.Drawing.Size(177, 20)
        Me.stbPurchaseOrderNo.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(378, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 20)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Supplier Name"
        '
        'stbSupplierName
        '
        Me.stbSupplierName.BackColor = System.Drawing.SystemColors.Info
        Me.stbSupplierName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSupplierName.CapitalizeFirstLetter = True
        Me.stbSupplierName.Enabled = False
        Me.stbSupplierName.EntryErrorMSG = ""
        Me.stbSupplierName.Location = New System.Drawing.Point(513, 48)
        Me.stbSupplierName.MaxLength = 60
        Me.stbSupplierName.Multiline = True
        Me.stbSupplierName.Name = "stbSupplierName"
        Me.stbSupplierName.ReadOnly = True
        Me.stbSupplierName.RegularExpression = ""
        Me.stbSupplierName.Size = New System.Drawing.Size(255, 27)
        Me.stbSupplierName.TabIndex = 14
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(303, 2)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 23)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'stbGoodReceivedNoteNo
        '
        Me.stbGoodReceivedNoteNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGoodReceivedNoteNo.CapitalizeFirstLetter = False
        Me.stbGoodReceivedNoteNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbGoodReceivedNoteNo.EntryErrorMSG = ""
        Me.stbGoodReceivedNoteNo.Location = New System.Drawing.Point(132, 5)
        Me.stbGoodReceivedNoteNo.MaxLength = 20
        Me.stbGoodReceivedNoteNo.Name = "stbGoodReceivedNoteNo"
        Me.stbGoodReceivedNoteNo.RegularExpression = ""
        Me.stbGoodReceivedNoteNo.Size = New System.Drawing.Size(169, 20)
        Me.stbGoodReceivedNoteNo.TabIndex = 1
        '
        'lblReceivedDate
        '
        Me.lblReceivedDate.Location = New System.Drawing.Point(378, 6)
        Me.lblReceivedDate.Name = "lblReceivedDate"
        Me.lblReceivedDate.Size = New System.Drawing.Size(129, 20)
        Me.lblReceivedDate.TabIndex = 9
        Me.lblReceivedDate.Text = "Date Received"
        '
        'stbReturnNo
        '
        Me.stbReturnNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReturnNo.CapitalizeFirstLetter = False
        Me.stbReturnNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbReturnNo.EntryErrorMSG = ""
        Me.stbReturnNo.Location = New System.Drawing.Point(132, 26)
        Me.stbReturnNo.MaxLength = 20
        Me.stbReturnNo.Name = "stbReturnNo"
        Me.stbReturnNo.ReadOnly = True
        Me.stbReturnNo.RegularExpression = ""
        Me.stbReturnNo.Size = New System.Drawing.Size(169, 20)
        Me.stbReturnNo.TabIndex = 4
        '
        'lblReturnNo
        '
        Me.lblReturnNo.Location = New System.Drawing.Point(9, 27)
        Me.lblReturnNo.Name = "lblReturnNo"
        Me.lblReturnNo.Size = New System.Drawing.Size(119, 20)
        Me.lblReturnNo.TabIndex = 3
        Me.lblReturnNo.Text = "Return No"
        '
        'stbLocation
        '
        Me.stbLocation.BackColor = System.Drawing.SystemColors.Info
        Me.stbLocation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLocation.CapitalizeFirstLetter = True
        Me.stbLocation.Enabled = False
        Me.stbLocation.EntryErrorMSG = ""
        Me.stbLocation.Location = New System.Drawing.Point(513, 76)
        Me.stbLocation.MaxLength = 60
        Me.stbLocation.Multiline = True
        Me.stbLocation.Name = "stbLocation"
        Me.stbLocation.ReadOnly = True
        Me.stbLocation.RegularExpression = ""
        Me.stbLocation.Size = New System.Drawing.Size(255, 27)
        Me.stbLocation.TabIndex = 16
        '
        'lblDeliveryLocation
        '
        Me.lblDeliveryLocation.Location = New System.Drawing.Point(378, 77)
        Me.lblDeliveryLocation.Name = "lblDeliveryLocation"
        Me.lblDeliveryLocation.Size = New System.Drawing.Size(129, 20)
        Me.lblDeliveryLocation.TabIndex = 15
        Me.lblDeliveryLocation.Text = "Location"
        '
        'pnlPrintOnSaving
        '
        Me.pnlPrintOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pnlPrintOnSaving.Controls.Add(Me.chkPrintOnSaving)
        Me.pnlPrintOnSaving.Location = New System.Drawing.Point(89, 445)
        Me.pnlPrintOnSaving.Name = "pnlPrintOnSaving"
        Me.pnlPrintOnSaving.Size = New System.Drawing.Size(262, 31)
        Me.pnlPrintOnSaving.TabIndex = 25
        '
        'chkPrintOnSaving
        '
        Me.chkPrintOnSaving.AccessibleDescription = ""
        Me.chkPrintOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintOnSaving.AutoSize = True
        Me.chkPrintOnSaving.Checked = True
        Me.chkPrintOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintOnSaving.Location = New System.Drawing.Point(3, 8)
        Me.chkPrintOnSaving.Name = "chkPrintOnSaving"
        Me.chkPrintOnSaving.Size = New System.Drawing.Size(210, 17)
        Me.chkPrintOnSaving.TabIndex = 0
        Me.chkPrintOnSaving.Text = " Print Goods Returned Note On Saving"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(809, 451)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(84, 24)
        Me.btnPrint.TabIndex = 26
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.Visible = False
        '
        'lblReturnAmount
        '
        Me.lblReturnAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblReturnAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReturnAmount.Location = New System.Drawing.Point(2, 410)
        Me.lblReturnAmount.Name = "lblReturnAmount"
        Me.lblReturnAmount.Size = New System.Drawing.Size(129, 20)
        Me.lblReturnAmount.TabIndex = 20
        Me.lblReturnAmount.Text = "Total Return Amount"
        '
        'stbTotalReturnAmount
        '
        Me.stbTotalReturnAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalReturnAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalReturnAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalReturnAmount.CapitalizeFirstLetter = False
        Me.stbTotalReturnAmount.EntryErrorMSG = ""
        Me.stbTotalReturnAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbTotalReturnAmount.Location = New System.Drawing.Point(132, 407)
        Me.stbTotalReturnAmount.Multiline = True
        Me.stbTotalReturnAmount.Name = "stbTotalReturnAmount"
        Me.stbTotalReturnAmount.ReadOnly = True
        Me.stbTotalReturnAmount.RegularExpression = ""
        Me.stbTotalReturnAmount.Size = New System.Drawing.Size(223, 20)
        Me.stbTotalReturnAmount.TabIndex = 21
        '
        'stbReturnAmountWords
        '
        Me.stbReturnAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stbReturnAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbReturnAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReturnAmountWords.CapitalizeFirstLetter = False
        Me.stbReturnAmountWords.EntryErrorMSG = ""
        Me.stbReturnAmountWords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbReturnAmountWords.Location = New System.Drawing.Point(604, 394)
        Me.stbReturnAmountWords.Multiline = True
        Me.stbReturnAmountWords.Name = "stbReturnAmountWords"
        Me.stbReturnAmountWords.ReadOnly = True
        Me.stbReturnAmountWords.RegularExpression = ""
        Me.stbReturnAmountWords.Size = New System.Drawing.Size(375, 40)
        Me.stbReturnAmountWords.TabIndex = 23
        '
        'lblReturnAmountWords
        '
        Me.lblReturnAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblReturnAmountWords.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReturnAmountWords.Location = New System.Drawing.Point(411, 410)
        Me.lblReturnAmountWords.Name = "lblReturnAmountWords"
        Me.lblReturnAmountWords.Size = New System.Drawing.Size(187, 20)
        Me.lblReturnAmountWords.TabIndex = 22
        Me.lblReturnAmountWords.Text = "Total Return Amount in Words"
        '
        'dgvGoodsReturnedNoteDetails
        '
        Me.dgvGoodsReturnedNoteDetails.AllowUserToOrderColumns = True
        Me.dgvGoodsReturnedNoteDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvGoodsReturnedNoteDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGoodsReturnedNoteDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGoodsReturnedNoteDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colItemCode, Me.colItemName, Me.colItemCategoryID, Me.colItemCategory, Me.colBatchNo, Me.colExpiryDate, Me.colReceivedQuantity, Me.colPreviousReturned, Me.colRate, Me.colDiscount, Me.colUnitsAtHand, Me.colReturnQuantity, Me.colAmount, Me.colReturnReason})
        Me.dgvGoodsReturnedNoteDetails.EnableHeadersVisualStyles = False
        Me.dgvGoodsReturnedNoteDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvGoodsReturnedNoteDetails.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvGoodsReturnedNoteDetails.Location = New System.Drawing.Point(9, 141)
        Me.dgvGoodsReturnedNoteDetails.Name = "dgvGoodsReturnedNoteDetails"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGoodsReturnedNoteDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvGoodsReturnedNoteDetails.Size = New System.Drawing.Size(967, 247)
        Me.dgvGoodsReturnedNoteDetails.TabIndex = 46
        Me.dgvGoodsReturnedNoteDetails.Text = "DataGridView1"
        '
        'colSelect
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.colSelect.DefaultCellStyle = DataGridViewCellStyle2
        Me.colSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSelect.HeaderText = "Select"
        Me.colSelect.Name = "colSelect"
        Me.colSelect.ReadOnly = True
        Me.colSelect.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colSelect.Text = "•••"
        Me.colSelect.UseColumnTextForButtonValue = True
        Me.colSelect.Visible = False
        Me.colSelect.Width = 50
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
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 200
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.DataPropertyName = "ItemCategoryID"
        Me.colItemCategoryID.HeaderText = "Item Category ID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategory.DefaultCellStyle = DataGridViewCellStyle4
        Me.colItemCategory.HeaderText = "Item Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        '
        'colBatchNo
        '
        Me.colBatchNo.DataPropertyName = "BatchNo"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colBatchNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.colBatchNo.HeaderText = "Batch No"
        Me.colBatchNo.Name = "colBatchNo"
        Me.colBatchNo.ReadOnly = True
        '
        'colExpiryDate
        '
        Me.colExpiryDate.DataPropertyName = "ExpiryDate"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colExpiryDate.DefaultCellStyle = DataGridViewCellStyle6
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        '
        'colReceivedQuantity
        '
        Me.colReceivedQuantity.DataPropertyName = "TotalReceived"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colReceivedQuantity.DefaultCellStyle = DataGridViewCellStyle7
        Me.colReceivedQuantity.HeaderText = "Total Received"
        Me.colReceivedQuantity.Name = "colReceivedQuantity"
        Me.colReceivedQuantity.ReadOnly = True
        Me.colReceivedQuantity.Width = 120
        '
        'colPreviousReturned
        '
        Me.colPreviousReturned.DataPropertyName = "PreviousReturned"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colPreviousReturned.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPreviousReturned.HeaderText = "Previous Returned"
        Me.colPreviousReturned.Name = "colPreviousReturned"
        Me.colPreviousReturned.ReadOnly = True
        Me.colPreviousReturned.Width = 120
        '
        'colRate
        '
        Me.colRate.DataPropertyName = "Rate"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colRate.DefaultCellStyle = DataGridViewCellStyle9
        Me.colRate.HeaderText = "Rate"
        Me.colRate.Name = "colRate"
        Me.colRate.ReadOnly = True
        '
        'colDiscount
        '
        Me.colDiscount.DataPropertyName = "Discount"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colDiscount.DefaultCellStyle = DataGridViewCellStyle10
        Me.colDiscount.HeaderText = "Discount"
        Me.colDiscount.Name = "colDiscount"
        Me.colDiscount.ReadOnly = True
        Me.colDiscount.Width = 80
        '
        'colUnitsAtHand
        '
        Me.colUnitsAtHand.DataPropertyName = "UnitsAtHand"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitsAtHand.DefaultCellStyle = DataGridViewCellStyle11
        Me.colUnitsAtHand.HeaderText = "Units At Hand"
        Me.colUnitsAtHand.Name = "colUnitsAtHand"
        Me.colUnitsAtHand.ReadOnly = True
        '
        'colReturnQuantity
        '
        Me.colReturnQuantity.HeaderText = "Return Quantity"
        Me.colReturnQuantity.Name = "colReturnQuantity"
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        '
        'colReturnReason
        '
        Me.colReturnReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colReturnReason.HeaderText = "Return Reason"
        Me.colReturnReason.Name = "colReturnReason"
        Me.colReturnReason.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colReturnReason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colReturnReason.Width = 200
        '
        'frmGoodsReturnedNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(983, 481)
        Me.Controls.Add(Me.dgvGoodsReturnedNoteDetails)
        Me.Controls.Add(Me.stbReturnAmountWords)
        Me.Controls.Add(Me.lblReturnAmountWords)
        Me.Controls.Add(Me.stbTotalReturnAmount)
        Me.Controls.Add(Me.lblReturnAmount)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.pnlPrintOnSaving)
        Me.Controls.Add(Me.stbLocation)
        Me.Controls.Add(Me.lblDeliveryLocation)
        Me.Controls.Add(Me.stbReturnNo)
        Me.Controls.Add(Me.lblReturnNo)
        Me.Controls.Add(Me.dtpRecievedDate)
        Me.Controls.Add(Me.lblReceivedDate)
        Me.Controls.Add(Me.stbGoodReceivedNoteNo)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.stbSupplierName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.stbPurchaseOrderNo)
        Me.Controls.Add(Me.lblPurchaseOrderNo)
        Me.Controls.Add(Me.fbnSave)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblGRNNo)
        Me.Controls.Add(Me.dtpReturnDate)
        Me.Controls.Add(Me.lblReturnDate)
        Me.Controls.Add(Me.stbAmountWords)
        Me.Controls.Add(Me.lblAmountWords)
        Me.Controls.Add(Me.stbNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmGoodsReturnedNote"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Goods Returned Note"
        Me.pnlPrintOnSaving.ResumeLayout(False)
        Me.pnlPrintOnSaving.PerformLayout()
        CType(Me.dgvGoodsReturnedNoteDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSave As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblGRNNo As System.Windows.Forms.Label
    Friend WithEvents dtpReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReturnDate As System.Windows.Forms.Label
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents lblPurchaseOrderNo As System.Windows.Forms.Label
    Friend WithEvents stbPurchaseOrderNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents stbSupplierName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents stbGoodReceivedNoteNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dtpRecievedDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReceivedDate As System.Windows.Forms.Label
    Friend WithEvents stbReturnNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReturnNo As System.Windows.Forms.Label
    Friend WithEvents stbLocation As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDeliveryLocation As System.Windows.Forms.Label
    Friend WithEvents pnlPrintOnSaving As System.Windows.Forms.Panel
    Friend WithEvents chkPrintOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents lblReturnAmount As Label
    Friend WithEvents stbTotalReturnAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbReturnAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReturnAmountWords As Label
    Friend WithEvents dgvGoodsReturnedNoteDetails As DataGridView
    Friend WithEvents colSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReceivedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPreviousReturned As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsAtHand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnReason As System.Windows.Forms.DataGridViewComboBoxColumn
End Class