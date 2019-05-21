
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageAccounts : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal billModesID As String, ByVal accountNo As String)
        MyClass.New()
        Me.defaultBillModesID = billModesID
        Me.defaultAccountNo = accountNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageAccounts))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lblAccountTranNo = New System.Windows.Forms.Label()
        Me.stbAccountTranNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAccountActionID = New System.Windows.Forms.ComboBox()
        Me.lblAccountActionID = New System.Windows.Forms.Label()
        Me.cboBillModesID = New System.Windows.Forms.ComboBox()
        Me.lblBillModesID = New System.Windows.Forms.Label()
        Me.nbxAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxAccountAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.stbAccountNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountBalance = New System.Windows.Forms.Label()
        Me.cboPayModesID = New System.Windows.Forms.ComboBox()
        Me.dtpTransactionDate = New System.Windows.Forms.DateTimePicker()
        Me.lblAccountPayModes = New System.Windows.Forms.Label()
        Me.lblTransactionDate = New System.Windows.Forms.Label()
        Me.lblAccountDocumentNo = New System.Windows.Forms.Label()
        Me.stbAccountDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAccountNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountNotes = New System.Windows.Forms.Label()
        Me.stbAccountName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountName = New System.Windows.Forms.Label()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintReceiptOnSaving = New System.Windows.Forms.CheckBox()
        Me.stbAccountChange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountChange = New System.Windows.Forms.Label()
        Me.nbxAccountAmountTendered = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxAccountExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAccountAmountTendered = New System.Windows.Forms.Label()
        Me.lblAccountExchangeRate = New System.Windows.Forms.Label()
        Me.cboAccountCurrenciesID = New System.Windows.Forms.ComboBox()
        Me.lblAccountCurrenciesID = New System.Windows.Forms.Label()
        Me.cboAccountGroupID = New System.Windows.Forms.ComboBox()
        Me.lblAccountGroupID = New System.Windows.Forms.Label()
        Me.btnAccountExchangeRate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.stbAccountPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(260, 437)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 38
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(17, 435)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 37
        Me.btnSave.Tag = "Accounts"
        Me.btnSave.Text = "&Save"
        '
        'lblAccountTranNo
        '
        Me.lblAccountTranNo.Location = New System.Drawing.Point(14, 117)
        Me.lblAccountTranNo.Name = "lblAccountTranNo"
        Me.lblAccountTranNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountTranNo.TabIndex = 10
        Me.lblAccountTranNo.Text = "Transaction No"
        '
        'stbAccountTranNo
        '
        Me.stbAccountTranNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountTranNo.CapitalizeFirstLetter = False
        Me.stbAccountTranNo.EntryErrorMSG = ""
        Me.stbAccountTranNo.Location = New System.Drawing.Point(149, 117)
        Me.stbAccountTranNo.MaxLength = 20
        Me.stbAccountTranNo.Name = "stbAccountTranNo"
        Me.stbAccountTranNo.RegularExpression = ""
        Me.stbAccountTranNo.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountTranNo.TabIndex = 11
        '
        'cboAccountActionID
        '
        Me.cboAccountActionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountActionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountActionID.FormattingEnabled = True
        Me.cboAccountActionID.Location = New System.Drawing.Point(149, 162)
        Me.cboAccountActionID.Name = "cboAccountActionID"
        Me.cboAccountActionID.Size = New System.Drawing.Size(183, 21)
        Me.cboAccountActionID.TabIndex = 15
        '
        'lblAccountActionID
        '
        Me.lblAccountActionID.Location = New System.Drawing.Point(14, 162)
        Me.lblAccountActionID.Name = "lblAccountActionID"
        Me.lblAccountActionID.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountActionID.TabIndex = 14
        Me.lblAccountActionID.Text = "Account Action"
        '
        'cboBillModesID
        '
        Me.cboBillModesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillModesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillModesID.FormattingEnabled = True
        Me.cboBillModesID.ItemHeight = 13
        Me.cboBillModesID.Location = New System.Drawing.Point(149, 5)
        Me.cboBillModesID.Name = "cboBillModesID"
        Me.cboBillModesID.Size = New System.Drawing.Size(183, 21)
        Me.cboBillModesID.TabIndex = 1
        '
        'lblBillModesID
        '
        Me.lblBillModesID.Location = New System.Drawing.Point(14, 8)
        Me.lblBillModesID.Name = "lblBillModesID"
        Me.lblBillModesID.Size = New System.Drawing.Size(129, 18)
        Me.lblBillModesID.TabIndex = 0
        Me.lblBillModesID.Text = "Account Category"
        '
        'nbxAccountBalance
        '
        Me.nbxAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountBalance.ControlCaption = "Balance"
        Me.nbxAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountBalance.DecimalPlaces = -1
        Me.nbxAccountBalance.Enabled = False
        Me.nbxAccountBalance.Location = New System.Drawing.Point(149, 292)
        Me.nbxAccountBalance.MaxValue = 0.0R
        Me.nbxAccountBalance.MinValue = 0.0R
        Me.nbxAccountBalance.MustEnterNumeric = True
        Me.nbxAccountBalance.Name = "nbxAccountBalance"
        Me.nbxAccountBalance.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountBalance.TabIndex = 28
        Me.nbxAccountBalance.Value = ""
        '
        'nbxAccountAmount
        '
        Me.nbxAccountAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountAmount.ControlCaption = "Amount"
        Me.nbxAccountAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountAmount.DecimalPlaces = -1
        Me.nbxAccountAmount.Enabled = False
        Me.nbxAccountAmount.Location = New System.Drawing.Point(149, 250)
        Me.nbxAccountAmount.MaxValue = 0.0R
        Me.nbxAccountAmount.MinValue = 0.0R
        Me.nbxAccountAmount.MustEnterNumeric = True
        Me.nbxAccountAmount.Name = "nbxAccountAmount"
        Me.nbxAccountAmount.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountAmount.TabIndex = 24
        Me.nbxAccountAmount.Value = ""
        '
        'lblAmount
        '
        Me.lblAmount.Location = New System.Drawing.Point(14, 250)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(129, 18)
        Me.lblAmount.TabIndex = 23
        Me.lblAmount.Text = "Amount"
        '
        'stbAccountNo
        '
        Me.stbAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountNo.CapitalizeFirstLetter = False
        Me.stbAccountNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbAccountNo.EntryErrorMSG = ""
        Me.stbAccountNo.Location = New System.Drawing.Point(149, 29)
        Me.stbAccountNo.MaxLength = 12
        Me.stbAccountNo.Name = "stbAccountNo"
        Me.stbAccountNo.RegularExpression = ""
        Me.stbAccountNo.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountNo.TabIndex = 3
        '
        'lblAccountBalance
        '
        Me.lblAccountBalance.Location = New System.Drawing.Point(14, 292)
        Me.lblAccountBalance.Name = "lblAccountBalance"
        Me.lblAccountBalance.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountBalance.TabIndex = 27
        Me.lblAccountBalance.Text = "Balance"
        '
        'cboPayModesID
        '
        Me.cboPayModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPayModesID.FormattingEnabled = True
        Me.cboPayModesID.ItemHeight = 13
        Me.cboPayModesID.Location = New System.Drawing.Point(149, 139)
        Me.cboPayModesID.Name = "cboPayModesID"
        Me.cboPayModesID.Size = New System.Drawing.Size(183, 21)
        Me.cboPayModesID.TabIndex = 13
        '
        'dtpTransactionDate
        '
        Me.dtpTransactionDate.Enabled = False
        Me.dtpTransactionDate.Location = New System.Drawing.Point(149, 94)
        Me.dtpTransactionDate.Name = "dtpTransactionDate"
        Me.dtpTransactionDate.ShowCheckBox = True
        Me.dtpTransactionDate.Size = New System.Drawing.Size(183, 20)
        Me.dtpTransactionDate.TabIndex = 9
        '
        'lblAccountPayModes
        '
        Me.lblAccountPayModes.Location = New System.Drawing.Point(14, 142)
        Me.lblAccountPayModes.Name = "lblAccountPayModes"
        Me.lblAccountPayModes.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountPayModes.TabIndex = 12
        Me.lblAccountPayModes.Text = "Mode of Payment"
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.Location = New System.Drawing.Point(14, 96)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(129, 18)
        Me.lblTransactionDate.TabIndex = 8
        Me.lblTransactionDate.Text = "Transaction Date"
        '
        'lblAccountDocumentNo
        '
        Me.lblAccountDocumentNo.Location = New System.Drawing.Point(14, 315)
        Me.lblAccountDocumentNo.Name = "lblAccountDocumentNo"
        Me.lblAccountDocumentNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountDocumentNo.TabIndex = 29
        Me.lblAccountDocumentNo.Text = "Document No."
        '
        'stbAccountDocumentNo
        '
        Me.stbAccountDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountDocumentNo.CapitalizeFirstLetter = False
        Me.stbAccountDocumentNo.EntryErrorMSG = ""
        Me.stbAccountDocumentNo.Location = New System.Drawing.Point(149, 313)
        Me.stbAccountDocumentNo.MaxLength = 12
        Me.stbAccountDocumentNo.Name = "stbAccountDocumentNo"
        Me.stbAccountDocumentNo.RegularExpression = ""
        Me.stbAccountDocumentNo.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountDocumentNo.TabIndex = 30
        '
        'stbAccountNotes
        '
        Me.stbAccountNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountNotes.CapitalizeFirstLetter = True
        Me.stbAccountNotes.EntryErrorMSG = ""
        Me.stbAccountNotes.Location = New System.Drawing.Point(149, 358)
        Me.stbAccountNotes.MaxLength = 100
        Me.stbAccountNotes.Multiline = True
        Me.stbAccountNotes.Name = "stbAccountNotes"
        Me.stbAccountNotes.RegularExpression = ""
        Me.stbAccountNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountNotes.Size = New System.Drawing.Size(183, 41)
        Me.stbAccountNotes.TabIndex = 34
        '
        'lblAccountNotes
        '
        Me.lblAccountNotes.Location = New System.Drawing.Point(14, 368)
        Me.lblAccountNotes.Name = "lblAccountNotes"
        Me.lblAccountNotes.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountNotes.TabIndex = 33
        Me.lblAccountNotes.Text = "Notes"
        '
        'stbAccountName
        '
        Me.stbAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountName.CapitalizeFirstLetter = False
        Me.stbAccountName.EntryErrorMSG = ""
        Me.stbAccountName.Location = New System.Drawing.Point(149, 50)
        Me.stbAccountName.MaxLength = 41
        Me.stbAccountName.Name = "stbAccountName"
        Me.stbAccountName.ReadOnly = True
        Me.stbAccountName.RegularExpression = ""
        Me.stbAccountName.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountName.TabIndex = 5
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(14, 51)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountName.TabIndex = 4
        Me.lblAccountName.Text = "Account Name"
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(14, 29)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountNo.TabIndex = 2
        Me.lblAccountNo.Text = "Account No"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(260, 407)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 36
        Me.btnPrint.Text = "&Print"
        '
        'chkPrintReceiptOnSaving
        '
        Me.chkPrintReceiptOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintReceiptOnSaving.AutoSize = True
        Me.chkPrintReceiptOnSaving.Checked = True
        Me.chkPrintReceiptOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintReceiptOnSaving.Location = New System.Drawing.Point(17, 412)
        Me.chkPrintReceiptOnSaving.Name = "chkPrintReceiptOnSaving"
        Me.chkPrintReceiptOnSaving.Size = New System.Drawing.Size(143, 17)
        Me.chkPrintReceiptOnSaving.TabIndex = 35
        Me.chkPrintReceiptOnSaving.Text = " Print Receipt On Saving"
        '
        'stbAccountChange
        '
        Me.stbAccountChange.BackColor = System.Drawing.SystemColors.Info
        Me.stbAccountChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountChange.CapitalizeFirstLetter = False
        Me.stbAccountChange.Enabled = False
        Me.stbAccountChange.EntryErrorMSG = ""
        Me.stbAccountChange.Location = New System.Drawing.Point(149, 271)
        Me.stbAccountChange.MaxLength = 20
        Me.stbAccountChange.Name = "stbAccountChange"
        Me.stbAccountChange.RegularExpression = ""
        Me.stbAccountChange.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountChange.TabIndex = 26
        Me.stbAccountChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAccountChange
        '
        Me.lblAccountChange.Location = New System.Drawing.Point(14, 272)
        Me.lblAccountChange.Name = "lblAccountChange"
        Me.lblAccountChange.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountChange.TabIndex = 25
        Me.lblAccountChange.Text = "Change"
        '
        'nbxAccountAmountTendered
        '
        Me.nbxAccountAmountTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountAmountTendered.ControlCaption = "Unit Price"
        Me.nbxAccountAmountTendered.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountAmountTendered.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountAmountTendered.DecimalPlaces = -1
        Me.nbxAccountAmountTendered.Location = New System.Drawing.Point(149, 208)
        Me.nbxAccountAmountTendered.MaxValue = 0.0R
        Me.nbxAccountAmountTendered.MinValue = 0.0R
        Me.nbxAccountAmountTendered.MustEnterNumeric = True
        Me.nbxAccountAmountTendered.Name = "nbxAccountAmountTendered"
        Me.nbxAccountAmountTendered.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountAmountTendered.TabIndex = 19
        Me.nbxAccountAmountTendered.Value = ""
        '
        'nbxAccountExchangeRate
        '
        Me.nbxAccountExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountExchangeRate.ControlCaption = "Unit Price"
        Me.nbxAccountExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountExchangeRate.DecimalPlaces = -1
        Me.nbxAccountExchangeRate.Location = New System.Drawing.Point(149, 229)
        Me.nbxAccountExchangeRate.MaxValue = 0.0R
        Me.nbxAccountExchangeRate.MinValue = 0.0R
        Me.nbxAccountExchangeRate.MustEnterNumeric = True
        Me.nbxAccountExchangeRate.Name = "nbxAccountExchangeRate"
        Me.nbxAccountExchangeRate.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountExchangeRate.TabIndex = 22
        Me.nbxAccountExchangeRate.Value = ""
        '
        'lblAccountAmountTendered
        '
        Me.lblAccountAmountTendered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAccountAmountTendered.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAccountAmountTendered.Location = New System.Drawing.Point(14, 208)
        Me.lblAccountAmountTendered.Name = "lblAccountAmountTendered"
        Me.lblAccountAmountTendered.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountAmountTendered.TabIndex = 18
        Me.lblAccountAmountTendered.Text = "Amount Tendered"
        '
        'lblAccountExchangeRate
        '
        Me.lblAccountExchangeRate.Location = New System.Drawing.Point(14, 230)
        Me.lblAccountExchangeRate.Name = "lblAccountExchangeRate"
        Me.lblAccountExchangeRate.Size = New System.Drawing.Size(96, 18)
        Me.lblAccountExchangeRate.TabIndex = 20
        Me.lblAccountExchangeRate.Text = "Exchange Rate"
        '
        'cboAccountCurrenciesID
        '
        Me.cboAccountCurrenciesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountCurrenciesID.FormattingEnabled = True
        Me.cboAccountCurrenciesID.ItemHeight = 13
        Me.cboAccountCurrenciesID.Location = New System.Drawing.Point(149, 185)
        Me.cboAccountCurrenciesID.Name = "cboAccountCurrenciesID"
        Me.cboAccountCurrenciesID.Size = New System.Drawing.Size(183, 21)
        Me.cboAccountCurrenciesID.TabIndex = 17
        '
        'lblAccountCurrenciesID
        '
        Me.lblAccountCurrenciesID.Location = New System.Drawing.Point(14, 185)
        Me.lblAccountCurrenciesID.Name = "lblAccountCurrenciesID"
        Me.lblAccountCurrenciesID.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountCurrenciesID.TabIndex = 16
        Me.lblAccountCurrenciesID.Text = "Pay in Currency"
        '
        'cboAccountGroupID
        '
        Me.cboAccountGroupID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountGroupID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountGroupID.FormattingEnabled = True
        Me.cboAccountGroupID.ItemHeight = 13
        Me.cboAccountGroupID.Location = New System.Drawing.Point(149, 335)
        Me.cboAccountGroupID.Name = "cboAccountGroupID"
        Me.cboAccountGroupID.Size = New System.Drawing.Size(183, 21)
        Me.cboAccountGroupID.TabIndex = 32
        '
        'lblAccountGroupID
        '
        Me.lblAccountGroupID.Location = New System.Drawing.Point(14, 335)
        Me.lblAccountGroupID.Name = "lblAccountGroupID"
        Me.lblAccountGroupID.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountGroupID.TabIndex = 31
        Me.lblAccountGroupID.Text = "Account Group"
        '
        'btnAccountExchangeRate
        '
        Me.btnAccountExchangeRate.Enabled = False
        Me.btnAccountExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnAccountExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccountExchangeRate.Image = CType(resources.GetObject("btnAccountExchangeRate.Image"), System.Drawing.Image)
        Me.btnAccountExchangeRate.Location = New System.Drawing.Point(116, 228)
        Me.btnAccountExchangeRate.Name = "btnAccountExchangeRate"
        Me.btnAccountExchangeRate.Size = New System.Drawing.Size(27, 21)
        Me.btnAccountExchangeRate.TabIndex = 21
        Me.btnAccountExchangeRate.Tag = "ExchangeRates"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(14, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Phone"
        '
        'stbAccountPhone
        '
        Me.stbAccountPhone.BackColor = System.Drawing.SystemColors.Control
        Me.stbAccountPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountPhone.CapitalizeFirstLetter = True
        Me.stbAccountPhone.EntryErrorMSG = ""
        Me.stbAccountPhone.Location = New System.Drawing.Point(149, 72)
        Me.stbAccountPhone.MaxLength = 100
        Me.stbAccountPhone.Multiline = True
        Me.stbAccountPhone.Name = "stbAccountPhone"
        Me.stbAccountPhone.ReadOnly = True
        Me.stbAccountPhone.RegularExpression = ""
        Me.stbAccountPhone.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountPhone.TabIndex = 7
        '
        'frmManageAccounts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(353, 469)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.stbAccountPhone)
        Me.Controls.Add(Me.btnAccountExchangeRate)
        Me.Controls.Add(Me.cboAccountGroupID)
        Me.Controls.Add(Me.lblAccountGroupID)
        Me.Controls.Add(Me.stbAccountChange)
        Me.Controls.Add(Me.lblAccountChange)
        Me.Controls.Add(Me.nbxAccountAmountTendered)
        Me.Controls.Add(Me.nbxAccountExchangeRate)
        Me.Controls.Add(Me.lblAccountAmountTendered)
        Me.Controls.Add(Me.lblAccountExchangeRate)
        Me.Controls.Add(Me.cboAccountCurrenciesID)
        Me.Controls.Add(Me.lblAccountCurrenciesID)
        Me.Controls.Add(Me.chkPrintReceiptOnSaving)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblAccountTranNo)
        Me.Controls.Add(Me.stbAccountTranNo)
        Me.Controls.Add(Me.cboAccountActionID)
        Me.Controls.Add(Me.lblAccountActionID)
        Me.Controls.Add(Me.cboBillModesID)
        Me.Controls.Add(Me.lblBillModesID)
        Me.Controls.Add(Me.nbxAccountBalance)
        Me.Controls.Add(Me.nbxAccountAmount)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.stbAccountNo)
        Me.Controls.Add(Me.lblAccountBalance)
        Me.Controls.Add(Me.cboPayModesID)
        Me.Controls.Add(Me.dtpTransactionDate)
        Me.Controls.Add(Me.lblAccountPayModes)
        Me.Controls.Add(Me.lblTransactionDate)
        Me.Controls.Add(Me.lblAccountDocumentNo)
        Me.Controls.Add(Me.stbAccountDocumentNo)
        Me.Controls.Add(Me.stbAccountNotes)
        Me.Controls.Add(Me.lblAccountNotes)
        Me.Controls.Add(Me.stbAccountName)
        Me.Controls.Add(Me.lblAccountName)
        Me.Controls.Add(Me.lblAccountNo)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmManageAccounts"
        Me.Text = "Manage Accounts"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents lblAccountTranNo As System.Windows.Forms.Label
    Friend WithEvents stbAccountTranNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboAccountActionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountActionID As System.Windows.Forms.Label
    Friend WithEvents cboBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillModesID As System.Windows.Forms.Label
    Friend WithEvents nbxAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxAccountAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents stbAccountNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountBalance As System.Windows.Forms.Label
    Friend WithEvents cboPayModesID As System.Windows.Forms.ComboBox
    Friend WithEvents dtpTransactionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblAccountPayModes As System.Windows.Forms.Label
    Friend WithEvents lblTransactionDate As System.Windows.Forms.Label
    Friend WithEvents lblAccountDocumentNo As System.Windows.Forms.Label
    Friend WithEvents stbAccountDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAccountNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountNotes As System.Windows.Forms.Label
    Friend WithEvents stbAccountName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountName As System.Windows.Forms.Label
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintReceiptOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents stbAccountChange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountChange As System.Windows.Forms.Label
    Friend WithEvents nbxAccountAmountTendered As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxAccountExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAccountAmountTendered As System.Windows.Forms.Label
    Friend WithEvents lblAccountExchangeRate As System.Windows.Forms.Label
    Friend WithEvents cboAccountCurrenciesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountCurrenciesID As System.Windows.Forms.Label
    Friend WithEvents cboAccountGroupID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountGroupID As System.Windows.Forms.Label
    Friend WithEvents btnAccountExchangeRate As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents stbAccountPhone As SyncSoft.Common.Win.Controls.SmartTextBox

End Class