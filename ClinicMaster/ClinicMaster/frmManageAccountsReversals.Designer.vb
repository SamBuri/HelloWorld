<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageAccountsReversals
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmManageAccountsReversals))
        Me.btnSave = New System.Windows.Forms.Button()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbAccountGroup = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountGroup = New System.Windows.Forms.Label()
        Me.stbAccountCurrency = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAccountChange = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountChange = New System.Windows.Forms.Label()
        Me.nbxAccountAmountTendered = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxAccountExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAccountAmountTendered = New System.Windows.Forms.Label()
        Me.lblAccountExchangeRate = New System.Windows.Forms.Label()
        Me.lblAccountCurrenciesID = New System.Windows.Forms.Label()
        Me.stbAccountNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillModes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAccountAction = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAccountPayModes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbTransactionDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPreviousTranNo = New System.Windows.Forms.Label()
        Me.stbPreviousTranNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountAction = New System.Windows.Forms.Label()
        Me.lblBillModes = New System.Windows.Forms.Label()
        Me.nbxAccountAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblAccountPayModes = New System.Windows.Forms.Label()
        Me.lblTransactionDate = New System.Windows.Forms.Label()
        Me.lblAccountDocumentNo = New System.Windows.Forms.Label()
        Me.stbAccountDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAccountNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountNotes = New System.Windows.Forms.Label()
        Me.stbAccountName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountName = New System.Windows.Forms.Label()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.lblAccountTranNo = New System.Windows.Forms.Label()
        Me.stbAccountTranNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAccountActionID = New System.Windows.Forms.ComboBox()
        Me.lblAccountActionID = New System.Windows.Forms.Label()
        Me.btnLoadManageAccounts = New System.Windows.Forms.Button()
        Me.nbxAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAccountBalance = New System.Windows.Forms.Label()
        Me.chkPrintReceiptOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(17, 464)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(72, 24)
        Me.btnSave.TabIndex = 37
        Me.btnSave.Tag = "Accounts"
        Me.btnSave.Text = "&Save"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(309, 464)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 38
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbAccountGroup
        '
        Me.stbAccountGroup.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountGroup.CapitalizeFirstLetter = False
        Me.stbAccountGroup.Enabled = False
        Me.stbAccountGroup.EntryErrorMSG = ""
        Me.stbAccountGroup.Location = New System.Drawing.Point(148, 365)
        Me.stbAccountGroup.MaxLength = 60
        Me.stbAccountGroup.Name = "stbAccountGroup"
        Me.stbAccountGroup.RegularExpression = ""
        Me.stbAccountGroup.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountGroup.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountGroup.TabIndex = 34
        '
        'lblAccountGroup
        '
        Me.lblAccountGroup.Location = New System.Drawing.Point(15, 364)
        Me.lblAccountGroup.Name = "lblAccountGroup"
        Me.lblAccountGroup.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountGroup.TabIndex = 33
        Me.lblAccountGroup.Text = "Account Group"
        '
        'stbAccountCurrency
        '
        Me.stbAccountCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountCurrency.CapitalizeFirstLetter = False
        Me.stbAccountCurrency.Enabled = False
        Me.stbAccountCurrency.EntryErrorMSG = ""
        Me.stbAccountCurrency.Location = New System.Drawing.Point(148, 218)
        Me.stbAccountCurrency.MaxLength = 60
        Me.stbAccountCurrency.Name = "stbAccountCurrency"
        Me.stbAccountCurrency.RegularExpression = ""
        Me.stbAccountCurrency.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountCurrency.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountCurrency.TabIndex = 20
        '
        'stbAccountChange
        '
        Me.stbAccountChange.BackColor = System.Drawing.SystemColors.Info
        Me.stbAccountChange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountChange.CapitalizeFirstLetter = False
        Me.stbAccountChange.Enabled = False
        Me.stbAccountChange.EntryErrorMSG = ""
        Me.stbAccountChange.Location = New System.Drawing.Point(148, 302)
        Me.stbAccountChange.MaxLength = 20
        Me.stbAccountChange.Name = "stbAccountChange"
        Me.stbAccountChange.RegularExpression = ""
        Me.stbAccountChange.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountChange.TabIndex = 28
        Me.stbAccountChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblAccountChange
        '
        Me.lblAccountChange.Location = New System.Drawing.Point(15, 303)
        Me.lblAccountChange.Name = "lblAccountChange"
        Me.lblAccountChange.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountChange.TabIndex = 27
        Me.lblAccountChange.Text = "Change"
        '
        'nbxAccountAmountTendered
        '
        Me.nbxAccountAmountTendered.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountAmountTendered.ControlCaption = "Unit Price"
        Me.nbxAccountAmountTendered.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountAmountTendered.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountAmountTendered.DecimalPlaces = -1
        Me.nbxAccountAmountTendered.Enabled = False
        Me.nbxAccountAmountTendered.Location = New System.Drawing.Point(148, 239)
        Me.nbxAccountAmountTendered.MaxValue = 0.0R
        Me.nbxAccountAmountTendered.MinValue = 0.0R
        Me.nbxAccountAmountTendered.MustEnterNumeric = True
        Me.nbxAccountAmountTendered.Name = "nbxAccountAmountTendered"
        Me.nbxAccountAmountTendered.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountAmountTendered.TabIndex = 22
        Me.nbxAccountAmountTendered.Value = ""
        '
        'nbxAccountExchangeRate
        '
        Me.nbxAccountExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountExchangeRate.ControlCaption = "Unit Price"
        Me.nbxAccountExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountExchangeRate.DecimalPlaces = -1
        Me.nbxAccountExchangeRate.Enabled = False
        Me.nbxAccountExchangeRate.Location = New System.Drawing.Point(148, 260)
        Me.nbxAccountExchangeRate.MaxValue = 0.0R
        Me.nbxAccountExchangeRate.MinValue = 0.0R
        Me.nbxAccountExchangeRate.MustEnterNumeric = True
        Me.nbxAccountExchangeRate.Name = "nbxAccountExchangeRate"
        Me.nbxAccountExchangeRate.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountExchangeRate.TabIndex = 24
        Me.nbxAccountExchangeRate.Value = ""
        '
        'lblAccountAmountTendered
        '
        Me.lblAccountAmountTendered.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.lblAccountAmountTendered.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAccountAmountTendered.Location = New System.Drawing.Point(15, 239)
        Me.lblAccountAmountTendered.Name = "lblAccountAmountTendered"
        Me.lblAccountAmountTendered.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountAmountTendered.TabIndex = 21
        Me.lblAccountAmountTendered.Text = "Amount Tendered"
        '
        'lblAccountExchangeRate
        '
        Me.lblAccountExchangeRate.Location = New System.Drawing.Point(15, 261)
        Me.lblAccountExchangeRate.Name = "lblAccountExchangeRate"
        Me.lblAccountExchangeRate.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountExchangeRate.TabIndex = 23
        Me.lblAccountExchangeRate.Text = "Exchange Rate"
        '
        'lblAccountCurrenciesID
        '
        Me.lblAccountCurrenciesID.Location = New System.Drawing.Point(15, 216)
        Me.lblAccountCurrenciesID.Name = "lblAccountCurrenciesID"
        Me.lblAccountCurrenciesID.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountCurrenciesID.TabIndex = 19
        Me.lblAccountCurrenciesID.Text = "Pay in Currency"
        '
        'stbAccountNo
        '
        Me.stbAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountNo.CapitalizeFirstLetter = False
        Me.stbAccountNo.Enabled = False
        Me.stbAccountNo.EntryErrorMSG = ""
        Me.stbAccountNo.Location = New System.Drawing.Point(148, 72)
        Me.stbAccountNo.MaxLength = 60
        Me.stbAccountNo.Name = "stbAccountNo"
        Me.stbAccountNo.RegularExpression = ""
        Me.stbAccountNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountNo.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountNo.TabIndex = 8
        '
        'stbBillModes
        '
        Me.stbBillModes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillModes.CapitalizeFirstLetter = False
        Me.stbBillModes.Enabled = False
        Me.stbBillModes.EntryErrorMSG = ""
        Me.stbBillModes.Location = New System.Drawing.Point(148, 51)
        Me.stbBillModes.MaxLength = 60
        Me.stbBillModes.Name = "stbBillModes"
        Me.stbBillModes.RegularExpression = ""
        Me.stbBillModes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillModes.Size = New System.Drawing.Size(183, 20)
        Me.stbBillModes.TabIndex = 6
        '
        'stbAccountAction
        '
        Me.stbAccountAction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountAction.CapitalizeFirstLetter = False
        Me.stbAccountAction.Enabled = False
        Me.stbAccountAction.EntryErrorMSG = ""
        Me.stbAccountAction.Location = New System.Drawing.Point(148, 197)
        Me.stbAccountAction.MaxLength = 60
        Me.stbAccountAction.Name = "stbAccountAction"
        Me.stbAccountAction.RegularExpression = ""
        Me.stbAccountAction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountAction.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountAction.TabIndex = 18
        '
        'stbAccountPayModes
        '
        Me.stbAccountPayModes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountPayModes.CapitalizeFirstLetter = False
        Me.stbAccountPayModes.Enabled = False
        Me.stbAccountPayModes.EntryErrorMSG = ""
        Me.stbAccountPayModes.Location = New System.Drawing.Point(148, 176)
        Me.stbAccountPayModes.MaxLength = 60
        Me.stbAccountPayModes.Name = "stbAccountPayModes"
        Me.stbAccountPayModes.RegularExpression = ""
        Me.stbAccountPayModes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountPayModes.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountPayModes.TabIndex = 16
        '
        'stbTransactionDate
        '
        Me.stbTransactionDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTransactionDate.CapitalizeFirstLetter = False
        Me.stbTransactionDate.Enabled = False
        Me.stbTransactionDate.EntryErrorMSG = ""
        Me.stbTransactionDate.Location = New System.Drawing.Point(148, 30)
        Me.stbTransactionDate.MaxLength = 60
        Me.stbTransactionDate.Name = "stbTransactionDate"
        Me.stbTransactionDate.RegularExpression = ""
        Me.stbTransactionDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbTransactionDate.Size = New System.Drawing.Size(183, 20)
        Me.stbTransactionDate.TabIndex = 4
        '
        'lblPreviousTranNo
        '
        Me.lblPreviousTranNo.Location = New System.Drawing.Point(15, 9)
        Me.lblPreviousTranNo.Name = "lblPreviousTranNo"
        Me.lblPreviousTranNo.Size = New System.Drawing.Size(129, 18)
        Me.lblPreviousTranNo.TabIndex = 0
        Me.lblPreviousTranNo.Text = "Prev. TranNo"
        '
        'stbPreviousTranNo
        '
        Me.stbPreviousTranNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPreviousTranNo.CapitalizeFirstLetter = False
        Me.stbPreviousTranNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPreviousTranNo.EntryErrorMSG = ""
        Me.stbPreviousTranNo.Location = New System.Drawing.Point(148, 9)
        Me.stbPreviousTranNo.MaxLength = 20
        Me.stbPreviousTranNo.Name = "stbPreviousTranNo"
        Me.stbPreviousTranNo.RegularExpression = ""
        Me.stbPreviousTranNo.Size = New System.Drawing.Size(183, 20)
        Me.stbPreviousTranNo.TabIndex = 1
        '
        'lblAccountAction
        '
        Me.lblAccountAction.Location = New System.Drawing.Point(15, 196)
        Me.lblAccountAction.Name = "lblAccountAction"
        Me.lblAccountAction.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountAction.TabIndex = 17
        Me.lblAccountAction.Text = "Account Action"
        '
        'lblBillModes
        '
        Me.lblBillModes.Location = New System.Drawing.Point(15, 53)
        Me.lblBillModes.Name = "lblBillModes"
        Me.lblBillModes.Size = New System.Drawing.Size(129, 18)
        Me.lblBillModes.TabIndex = 5
        Me.lblBillModes.Text = "Account Category"
        '
        'nbxAccountAmount
        '
        Me.nbxAccountAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountAmount.ControlCaption = "Amount"
        Me.nbxAccountAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxAccountAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountAmount.DecimalPlaces = -1
        Me.nbxAccountAmount.Enabled = False
        Me.nbxAccountAmount.Location = New System.Drawing.Point(148, 281)
        Me.nbxAccountAmount.MaxValue = 0.0R
        Me.nbxAccountAmount.MinValue = 0.0R
        Me.nbxAccountAmount.MustEnterNumeric = True
        Me.nbxAccountAmount.Name = "nbxAccountAmount"
        Me.nbxAccountAmount.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountAmount.TabIndex = 26
        Me.nbxAccountAmount.Value = ""
        '
        'lblAmount
        '
        Me.lblAmount.Location = New System.Drawing.Point(15, 281)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(129, 18)
        Me.lblAmount.TabIndex = 25
        Me.lblAmount.Text = "Amount"
        '
        'lblAccountPayModes
        '
        Me.lblAccountPayModes.Location = New System.Drawing.Point(15, 177)
        Me.lblAccountPayModes.Name = "lblAccountPayModes"
        Me.lblAccountPayModes.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountPayModes.TabIndex = 15
        Me.lblAccountPayModes.Text = "Mode of Payment"
        '
        'lblTransactionDate
        '
        Me.lblTransactionDate.Location = New System.Drawing.Point(15, 32)
        Me.lblTransactionDate.Name = "lblTransactionDate"
        Me.lblTransactionDate.Size = New System.Drawing.Size(129, 18)
        Me.lblTransactionDate.TabIndex = 3
        Me.lblTransactionDate.Text = "Transaction Date"
        '
        'lblAccountDocumentNo
        '
        Me.lblAccountDocumentNo.Location = New System.Drawing.Point(15, 346)
        Me.lblAccountDocumentNo.Name = "lblAccountDocumentNo"
        Me.lblAccountDocumentNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountDocumentNo.TabIndex = 31
        Me.lblAccountDocumentNo.Text = "Document No"
        '
        'stbAccountDocumentNo
        '
        Me.stbAccountDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountDocumentNo.CapitalizeFirstLetter = False
        Me.stbAccountDocumentNo.Enabled = False
        Me.stbAccountDocumentNo.EntryErrorMSG = ""
        Me.stbAccountDocumentNo.Location = New System.Drawing.Point(148, 344)
        Me.stbAccountDocumentNo.MaxLength = 12
        Me.stbAccountDocumentNo.Name = "stbAccountDocumentNo"
        Me.stbAccountDocumentNo.RegularExpression = ""
        Me.stbAccountDocumentNo.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountDocumentNo.TabIndex = 32
        '
        'stbAccountNotes
        '
        Me.stbAccountNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountNotes.CapitalizeFirstLetter = True
        Me.stbAccountNotes.EntryErrorMSG = ""
        Me.stbAccountNotes.Location = New System.Drawing.Point(148, 386)
        Me.stbAccountNotes.MaxLength = 100
        Me.stbAccountNotes.Multiline = True
        Me.stbAccountNotes.Name = "stbAccountNotes"
        Me.stbAccountNotes.RegularExpression = ""
        Me.stbAccountNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountNotes.Size = New System.Drawing.Size(183, 42)
        Me.stbAccountNotes.TabIndex = 36
        '
        'lblAccountNotes
        '
        Me.lblAccountNotes.Location = New System.Drawing.Point(15, 402)
        Me.lblAccountNotes.Name = "lblAccountNotes"
        Me.lblAccountNotes.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountNotes.TabIndex = 35
        Me.lblAccountNotes.Text = "Notes"
        '
        'stbAccountName
        '
        Me.stbAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountName.CapitalizeFirstLetter = True
        Me.stbAccountName.EntryErrorMSG = ""
        Me.stbAccountName.Location = New System.Drawing.Point(148, 93)
        Me.stbAccountName.MaxLength = 60
        Me.stbAccountName.Multiline = True
        Me.stbAccountName.Name = "stbAccountName"
        Me.stbAccountName.ReadOnly = True
        Me.stbAccountName.RegularExpression = ""
        Me.stbAccountName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountName.Size = New System.Drawing.Size(183, 37)
        Me.stbAccountName.TabIndex = 10
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(15, 103)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountName.TabIndex = 9
        Me.lblAccountName.Text = "Account Name"
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(15, 74)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountNo.TabIndex = 7
        Me.lblAccountNo.Text = "Account No"
        '
        'lblAccountTranNo
        '
        Me.lblAccountTranNo.Location = New System.Drawing.Point(15, 131)
        Me.lblAccountTranNo.Name = "lblAccountTranNo"
        Me.lblAccountTranNo.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountTranNo.TabIndex = 11
        Me.lblAccountTranNo.Text = "Transaction No"
        '
        'stbAccountTranNo
        '
        Me.stbAccountTranNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountTranNo.CapitalizeFirstLetter = False
        Me.stbAccountTranNo.EntryErrorMSG = ""
        Me.stbAccountTranNo.Location = New System.Drawing.Point(148, 131)
        Me.stbAccountTranNo.MaxLength = 20
        Me.stbAccountTranNo.Name = "stbAccountTranNo"
        Me.stbAccountTranNo.RegularExpression = ""
        Me.stbAccountTranNo.Size = New System.Drawing.Size(183, 20)
        Me.stbAccountTranNo.TabIndex = 12
        '
        'cboAccountActionID
        '
        Me.cboAccountActionID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountActionID.Enabled = False
        Me.cboAccountActionID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountActionID.FormattingEnabled = True
        Me.cboAccountActionID.Location = New System.Drawing.Point(148, 153)
        Me.cboAccountActionID.Name = "cboAccountActionID"
        Me.cboAccountActionID.Size = New System.Drawing.Size(183, 21)
        Me.cboAccountActionID.TabIndex = 14
        '
        'lblAccountActionID
        '
        Me.lblAccountActionID.Location = New System.Drawing.Point(15, 153)
        Me.lblAccountActionID.Name = "lblAccountActionID"
        Me.lblAccountActionID.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountActionID.TabIndex = 13
        Me.lblAccountActionID.Text = "New Account Action"
        '
        'btnLoadManageAccounts
        '
        Me.btnLoadManageAccounts.AccessibleDescription = ""
        Me.btnLoadManageAccounts.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadManageAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadManageAccounts.Location = New System.Drawing.Point(335, 9)
        Me.btnLoadManageAccounts.Name = "btnLoadManageAccounts"
        Me.btnLoadManageAccounts.Size = New System.Drawing.Size(46, 24)
        Me.btnLoadManageAccounts.TabIndex = 2
        Me.btnLoadManageAccounts.Tag = ""
        Me.btnLoadManageAccounts.Text = "&Load"
        '
        'nbxAccountBalance
        '
        Me.nbxAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountBalance.ControlCaption = "Balance"
        Me.nbxAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountBalance.DecimalPlaces = -1
        Me.nbxAccountBalance.Enabled = False
        Me.nbxAccountBalance.Location = New System.Drawing.Point(148, 323)
        Me.nbxAccountBalance.MaxValue = 0.0R
        Me.nbxAccountBalance.MinValue = 0.0R
        Me.nbxAccountBalance.MustEnterNumeric = True
        Me.nbxAccountBalance.Name = "nbxAccountBalance"
        Me.nbxAccountBalance.Size = New System.Drawing.Size(183, 20)
        Me.nbxAccountBalance.TabIndex = 30
        Me.nbxAccountBalance.Value = ""
        '
        'lblAccountBalance
        '
        Me.lblAccountBalance.Location = New System.Drawing.Point(13, 323)
        Me.lblAccountBalance.Name = "lblAccountBalance"
        Me.lblAccountBalance.Size = New System.Drawing.Size(129, 18)
        Me.lblAccountBalance.TabIndex = 29
        Me.lblAccountBalance.Text = "Balance"
        '
        'chkPrintReceiptOnSaving
        '
        Me.chkPrintReceiptOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintReceiptOnSaving.AutoSize = True
        Me.chkPrintReceiptOnSaving.Checked = True
        Me.chkPrintReceiptOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintReceiptOnSaving.Location = New System.Drawing.Point(18, 441)
        Me.chkPrintReceiptOnSaving.Name = "chkPrintReceiptOnSaving"
        Me.chkPrintReceiptOnSaving.Size = New System.Drawing.Size(143, 17)
        Me.chkPrintReceiptOnSaving.TabIndex = 39
        Me.chkPrintReceiptOnSaving.Text = " Print Receipt On Saving"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(309, 436)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 40
        Me.btnPrint.Text = "&Print"
        '
        'frmManageAccountsReversals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 503)
        Me.Controls.Add(Me.chkPrintReceiptOnSaving)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.nbxAccountBalance)
        Me.Controls.Add(Me.lblAccountBalance)
        Me.Controls.Add(Me.btnLoadManageAccounts)
        Me.Controls.Add(Me.cboAccountActionID)
        Me.Controls.Add(Me.lblAccountActionID)
        Me.Controls.Add(Me.lblAccountTranNo)
        Me.Controls.Add(Me.stbAccountTranNo)
        Me.Controls.Add(Me.stbAccountGroup)
        Me.Controls.Add(Me.lblAccountGroup)
        Me.Controls.Add(Me.stbAccountCurrency)
        Me.Controls.Add(Me.stbAccountChange)
        Me.Controls.Add(Me.lblAccountChange)
        Me.Controls.Add(Me.nbxAccountAmountTendered)
        Me.Controls.Add(Me.nbxAccountExchangeRate)
        Me.Controls.Add(Me.lblAccountAmountTendered)
        Me.Controls.Add(Me.lblAccountExchangeRate)
        Me.Controls.Add(Me.lblAccountCurrenciesID)
        Me.Controls.Add(Me.stbAccountNo)
        Me.Controls.Add(Me.stbBillModes)
        Me.Controls.Add(Me.stbAccountAction)
        Me.Controls.Add(Me.stbAccountPayModes)
        Me.Controls.Add(Me.stbTransactionDate)
        Me.Controls.Add(Me.lblPreviousTranNo)
        Me.Controls.Add(Me.stbPreviousTranNo)
        Me.Controls.Add(Me.lblAccountAction)
        Me.Controls.Add(Me.lblBillModes)
        Me.Controls.Add(Me.nbxAccountAmount)
        Me.Controls.Add(Me.lblAmount)
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
        Me.MaximizeBox = False
        Me.Name = "frmManageAccountsReversals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Manage Accounts Reversals"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbAccountGroup As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountGroup As System.Windows.Forms.Label
    Friend WithEvents stbAccountCurrency As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAccountChange As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountChange As System.Windows.Forms.Label
    Friend WithEvents nbxAccountAmountTendered As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxAccountExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAccountAmountTendered As System.Windows.Forms.Label
    Friend WithEvents lblAccountExchangeRate As System.Windows.Forms.Label
    Friend WithEvents lblAccountCurrenciesID As System.Windows.Forms.Label
    Friend WithEvents stbAccountNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillModes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAccountAction As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAccountPayModes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbTransactionDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPreviousTranNo As System.Windows.Forms.Label
    Friend WithEvents stbPreviousTranNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountAction As System.Windows.Forms.Label
    Friend WithEvents lblBillModes As System.Windows.Forms.Label
    Friend WithEvents nbxAccountAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblAccountPayModes As System.Windows.Forms.Label
    Friend WithEvents lblTransactionDate As System.Windows.Forms.Label
    Friend WithEvents lblAccountDocumentNo As System.Windows.Forms.Label
    Friend WithEvents stbAccountDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAccountNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountNotes As System.Windows.Forms.Label
    Friend WithEvents stbAccountName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountName As System.Windows.Forms.Label
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents lblAccountTranNo As System.Windows.Forms.Label
    Friend WithEvents stbAccountTranNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboAccountActionID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountActionID As System.Windows.Forms.Label
    Friend WithEvents btnLoadManageAccounts As System.Windows.Forms.Button
    Friend WithEvents nbxAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAccountBalance As System.Windows.Forms.Label
    Friend WithEvents chkPrintReceiptOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
End Class
