
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankingRegister : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBankingRegister))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpBankingDate = New System.Windows.Forms.DateTimePicker()
        Me.cboBankNameID = New System.Windows.Forms.ComboBox()
        Me.stbAccountNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAccountNames = New System.Windows.Forms.ComboBox()
        Me.nbxAmountCollected = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxAmountBanked = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbAmountInWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBankedBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbCurrency = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.dtpCollectionStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpCollectionEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.cboCollectionSource = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbRegisterNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRegisterNo = New System.Windows.Forms.Label()
        Me.lblCollectionStartDate = New System.Windows.Forms.Label()
        Me.lblCollectionEndDate = New System.Windows.Forms.Label()
        Me.lblBankingDate = New System.Windows.Forms.Label()
        Me.lblBankNameID = New System.Windows.Forms.Label()
        Me.lblAccountName = New System.Windows.Forms.Label()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.lblAmountCollected = New System.Windows.Forms.Label()
        Me.lblAmountBanked = New System.Windows.Forms.Label()
        Me.lblAmountInWords = New System.Windows.Forms.Label()
        Me.lblBankedBy = New System.Windows.Forms.Label()
        Me.nbxExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblExchangeRate = New System.Windows.Forms.Label()
        Me.lblAmountBankedInAccountCurrency = New System.Windows.Forms.Label()
        Me.lblBankedInAmountCurrency = New System.Windows.Forms.Label()
        Me.lblTotalBanked = New System.Windows.Forms.Label()
        Me.nbxBankedInAmountCurrency = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.tbcCollections = New System.Windows.Forms.TabControl()
        Me.tpgAllCollections = New System.Windows.Forms.TabPage()
        Me.dgvAllCollections = New System.Windows.Forms.DataGridView()
        Me.colAllInclude = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.colPayModes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmountCollected = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmountRefunded = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNetPatientPaymentAmountCollected = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmountBanked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBankMode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colAllCollectionsDocumentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgChequePayments = New System.Windows.Forms.TabPage()
        Me.stbPatientChequePaymentsWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblExpenditureTotalAmount = New System.Windows.Forms.Label()
        Me.lblExpenditureAmountWords = New System.Windows.Forms.Label()
        Me.stbPatientChequePayments = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dgvChequeCollections = New System.Windows.Forms.DataGridView()
        Me.tpgOtherPayment = New System.Windows.Forms.TabPage()
        Me.dgvOtherIncomes = New System.Windows.Forms.DataGridView()
        Me.colIncludeOtherIncome = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.colOtherIncomePayMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIncomeReceived = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherIncomeBanked = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherIncomeBankMode = New SyncSoft.Common.Win.Controls.GridComboBoxColumn()
        Me.colOtherIncomeDocumentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgOtherPaymentCheque = New System.Windows.Forms.TabPage()
        Me.dgvOtherIncomeCheque = New System.Windows.Forms.DataGridView()
        Me.stbOtherIncomeChequePayMentInWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.stbOtherIncomeChequePayments = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.tpgAccounts = New System.Windows.Forms.TabPage()
        Me.dgvAccounts = New System.Windows.Forms.DataGridView()
        Me.colAccountInclude = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.colAccountPayMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountAmountCredited = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountBankedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountBankMode = New SyncSoft.Common.Win.Controls.GridComboBoxColumn()
        Me.colAccountDocumentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgAccountsCheque = New System.Windows.Forms.TabPage()
        Me.stbAccountChequeInWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.stbAccountCheque = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dgvAccountsCheque = New System.Windows.Forms.DataGridView()
        Me.lblIncomeSourceCategory = New System.Windows.Forms.Label()
        Me.colIncludeChequePayment = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientChequeDocumentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientPaymentChequeAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colAccountChequeInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colTranNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountChequePayModes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountChequeDocument = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountChequeAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountChequeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colIncludeOtherIncomeCheque = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colIncomeNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherIncomeChequePayModes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherIncomeChequeReceivedIncome = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherIncomeChequeDocumentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOtherIncomeChequeSaved = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.tbcCollections.SuspendLayout()
        Me.tpgAllCollections.SuspendLayout()
        CType(Me.dgvAllCollections, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgChequePayments.SuspendLayout()
        CType(Me.dgvChequeCollections, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOtherPayment.SuspendLayout()
        CType(Me.dgvOtherIncomes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOtherPaymentCheque.SuspendLayout()
        CType(Me.dgvOtherIncomeCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgAccounts.SuspendLayout()
        CType(Me.dgvAccounts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgAccountsCheque.SuspendLayout()
        CType(Me.dgvAccountsCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 434)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(788, 434)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "BankingRegister"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 461)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "BankingRegister"
        Me.ebnSaveUpdate.Text = " &Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpBankingDate
        '
        Me.dtpBankingDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpBankingDate, "BankingDate")
        Me.dtpBankingDate.Location = New System.Drawing.Point(682, 146)
        Me.dtpBankingDate.Name = "dtpBankingDate"
        Me.dtpBankingDate.ShowCheckBox = True
        Me.dtpBankingDate.Size = New System.Drawing.Size(194, 20)
        Me.dtpBankingDate.TabIndex = 60
        '
        'cboBankNameID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBankNameID, "BankName,BankNameID")
        Me.cboBankNameID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBankNameID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBankNameID.Location = New System.Drawing.Point(258, 128)
        Me.cboBankNameID.Name = "cboBankNameID"
        Me.cboBankNameID.Size = New System.Drawing.Size(180, 21)
        Me.cboBankNameID.TabIndex = 20
        '
        'stbAccountNo
        '
        Me.stbAccountNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbAccountNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAccountNo, "AccountNo")
        Me.stbAccountNo.EntryErrorMSG = ""
        Me.stbAccountNo.Location = New System.Drawing.Point(256, 174)
        Me.stbAccountNo.Name = "stbAccountNo"
        Me.stbAccountNo.ReadOnly = True
        Me.stbAccountNo.RegularExpression = ""
        Me.stbAccountNo.Size = New System.Drawing.Size(180, 20)
        Me.stbAccountNo.TabIndex = 24
        '
        'cboAccountNames
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAccountNames, "AccountName")
        Me.cboAccountNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountNames.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountNames.Location = New System.Drawing.Point(258, 151)
        Me.cboAccountNames.Name = "cboAccountNames"
        Me.cboAccountNames.Size = New System.Drawing.Size(180, 21)
        Me.cboAccountNames.TabIndex = 22
        '
        'nbxAmountCollected
        '
        Me.nbxAmountCollected.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAmountCollected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAmountCollected.ControlCaption = "Amount Collected"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAmountCollected, "AmountCollected")
        Me.nbxAmountCollected.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAmountCollected.DecimalPlaces = -1
        Me.nbxAmountCollected.Location = New System.Drawing.Point(256, 106)
        Me.nbxAmountCollected.MaxValue = 0R
        Me.nbxAmountCollected.MinValue = 0R
        Me.nbxAmountCollected.MustEnterNumeric = True
        Me.nbxAmountCollected.Name = "nbxAmountCollected"
        Me.nbxAmountCollected.ReadOnly = True
        Me.nbxAmountCollected.Size = New System.Drawing.Size(180, 20)
        Me.nbxAmountCollected.TabIndex = 18
        Me.nbxAmountCollected.Value = ""
        '
        'nbxAmountBanked
        '
        Me.nbxAmountBanked.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAmountBanked.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAmountBanked.ControlCaption = "Amount Banked"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAmountBanked, "AmountBanked")
        Me.nbxAmountBanked.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAmountBanked.DecimalPlaces = -1
        Me.nbxAmountBanked.Location = New System.Drawing.Point(682, 6)
        Me.nbxAmountBanked.MaxValue = 0R
        Me.nbxAmountBanked.MinValue = 0R
        Me.nbxAmountBanked.MustEnterNumeric = True
        Me.nbxAmountBanked.Name = "nbxAmountBanked"
        Me.nbxAmountBanked.ReadOnly = True
        Me.nbxAmountBanked.Size = New System.Drawing.Size(194, 20)
        Me.nbxAmountBanked.TabIndex = 44
        Me.nbxAmountBanked.Value = ""
        '
        'stbAmountInWords
        '
        Me.stbAmountInWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountInWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountInWords.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAmountInWords, "AmountInWords")
        Me.stbAmountInWords.EntryErrorMSG = ""
        Me.stbAmountInWords.Location = New System.Drawing.Point(682, 29)
        Me.stbAmountInWords.Multiline = True
        Me.stbAmountInWords.Name = "stbAmountInWords"
        Me.stbAmountInWords.ReadOnly = True
        Me.stbAmountInWords.RegularExpression = ""
        Me.stbAmountInWords.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbAmountInWords.Size = New System.Drawing.Size(194, 42)
        Me.stbAmountInWords.TabIndex = 46
        '
        'stbBankedBy
        '
        Me.stbBankedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBankedBy.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBankedBy, "BankedBy")
        Me.stbBankedBy.EntryErrorMSG = ""
        Me.stbBankedBy.Location = New System.Drawing.Point(681, 122)
        Me.stbBankedBy.Name = "stbBankedBy"
        Me.stbBankedBy.RegularExpression = ""
        Me.stbBankedBy.Size = New System.Drawing.Size(194, 20)
        Me.stbBankedBy.TabIndex = 52
        '
        'stbCurrency
        '
        Me.stbCurrency.BackColor = System.Drawing.SystemColors.Info
        Me.stbCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ebnSaveUpdate.SetDataMember(Me.stbCurrency, "Currency")
        Me.stbCurrency.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.stbCurrency.DecimalPlaces = -1
        Me.stbCurrency.Location = New System.Drawing.Point(256, 198)
        Me.stbCurrency.MaxValue = 0R
        Me.stbCurrency.MinValue = 0R
        Me.stbCurrency.MustEnterNumeric = True
        Me.stbCurrency.Name = "stbCurrency"
        Me.stbCurrency.ReadOnly = True
        Me.stbCurrency.Size = New System.Drawing.Size(180, 20)
        Me.stbCurrency.TabIndex = 42
        Me.stbCurrency.Value = ""
        '
        'dtpCollectionStartDateTime
        '
        Me.dtpCollectionStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpCollectionStartDateTime, "CollectionStartDate")
        Me.dtpCollectionStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCollectionStartDateTime.Location = New System.Drawing.Point(258, 57)
        Me.dtpCollectionStartDateTime.Name = "dtpCollectionStartDateTime"
        Me.dtpCollectionStartDateTime.ShowCheckBox = True
        Me.dtpCollectionStartDateTime.Size = New System.Drawing.Size(179, 20)
        Me.dtpCollectionStartDateTime.TabIndex = 6
        '
        'dtpCollectionEndDateTime
        '
        Me.dtpCollectionEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpCollectionEndDateTime, "CollectionEndDate")
        Me.dtpCollectionEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCollectionEndDateTime.Location = New System.Drawing.Point(257, 80)
        Me.dtpCollectionEndDateTime.Name = "dtpCollectionEndDateTime"
        Me.dtpCollectionEndDateTime.ShowCheckBox = True
        Me.dtpCollectionEndDateTime.Size = New System.Drawing.Size(179, 20)
        Me.dtpCollectionEndDateTime.TabIndex = 8
        '
        'cboCollectionSource
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCollectionSource, "CollectionSource,CollectionSourceID")
        Me.cboCollectionSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCollectionSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCollectionSource.Location = New System.Drawing.Point(261, 30)
        Me.cboCollectionSource.Name = "cboCollectionSource"
        Me.cboCollectionSource.Size = New System.Drawing.Size(177, 21)
        Me.cboCollectionSource.TabIndex = 63
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(788, 461)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbRegisterNo
        '
        Me.stbRegisterNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbRegisterNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRegisterNo.CapitalizeFirstLetter = False
        Me.stbRegisterNo.EntryErrorMSG = ""
        Me.stbRegisterNo.Location = New System.Drawing.Point(261, 7)
        Me.stbRegisterNo.Name = "stbRegisterNo"
        Me.stbRegisterNo.ReadOnly = True
        Me.stbRegisterNo.RegularExpression = ""
        Me.stbRegisterNo.Size = New System.Drawing.Size(180, 20)
        Me.stbRegisterNo.TabIndex = 4
        '
        'lblRegisterNo
        '
        Me.lblRegisterNo.Location = New System.Drawing.Point(13, 9)
        Me.lblRegisterNo.Name = "lblRegisterNo"
        Me.lblRegisterNo.Size = New System.Drawing.Size(211, 20)
        Me.lblRegisterNo.TabIndex = 5
        Me.lblRegisterNo.Text = "Register No"
        '
        'lblCollectionStartDate
        '
        Me.lblCollectionStartDate.Location = New System.Drawing.Point(13, 60)
        Me.lblCollectionStartDate.Name = "lblCollectionStartDate"
        Me.lblCollectionStartDate.Size = New System.Drawing.Size(211, 20)
        Me.lblCollectionStartDate.TabIndex = 7
        Me.lblCollectionStartDate.Text = "Collection Start Date"
        '
        'lblCollectionEndDate
        '
        Me.lblCollectionEndDate.Location = New System.Drawing.Point(13, 83)
        Me.lblCollectionEndDate.Name = "lblCollectionEndDate"
        Me.lblCollectionEndDate.Size = New System.Drawing.Size(211, 20)
        Me.lblCollectionEndDate.TabIndex = 9
        Me.lblCollectionEndDate.Text = "Collection End Date"
        '
        'lblBankingDate
        '
        Me.lblBankingDate.Location = New System.Drawing.Point(478, 152)
        Me.lblBankingDate.Name = "lblBankingDate"
        Me.lblBankingDate.Size = New System.Drawing.Size(174, 20)
        Me.lblBankingDate.TabIndex = 11
        Me.lblBankingDate.Text = "Banking Date"
        '
        'lblBankNameID
        '
        Me.lblBankNameID.Location = New System.Drawing.Point(14, 131)
        Me.lblBankNameID.Name = "lblBankNameID"
        Me.lblBankNameID.Size = New System.Drawing.Size(211, 20)
        Me.lblBankNameID.TabIndex = 13
        Me.lblBankNameID.Text = "Bank Name"
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(15, 155)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(211, 20)
        Me.lblAccountName.TabIndex = 15
        Me.lblAccountName.Text = "Account Name"
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(15, 175)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(211, 20)
        Me.lblAccountNo.TabIndex = 17
        Me.lblAccountNo.Text = "Account No"
        '
        'lblAmountCollected
        '
        Me.lblAmountCollected.Location = New System.Drawing.Point(13, 107)
        Me.lblAmountCollected.Name = "lblAmountCollected"
        Me.lblAmountCollected.Size = New System.Drawing.Size(213, 20)
        Me.lblAmountCollected.TabIndex = 19
        Me.lblAmountCollected.Text = "Total Net Collected (Local Currency)"
        '
        'lblAmountBanked
        '
        Me.lblAmountBanked.Location = New System.Drawing.Point(476, 7)
        Me.lblAmountBanked.Name = "lblAmountBanked"
        Me.lblAmountBanked.Size = New System.Drawing.Size(177, 20)
        Me.lblAmountBanked.TabIndex = 21
        Me.lblAmountBanked.Text = "Amount Banked"
        '
        'lblAmountInWords
        '
        Me.lblAmountInWords.Location = New System.Drawing.Point(479, 33)
        Me.lblAmountInWords.Name = "lblAmountInWords"
        Me.lblAmountInWords.Size = New System.Drawing.Size(174, 20)
        Me.lblAmountInWords.TabIndex = 23
        Me.lblAmountInWords.Text = "Amount In Words"
        '
        'lblBankedBy
        '
        Me.lblBankedBy.Location = New System.Drawing.Point(478, 125)
        Me.lblBankedBy.Name = "lblBankedBy"
        Me.lblBankedBy.Size = New System.Drawing.Size(174, 20)
        Me.lblBankedBy.TabIndex = 29
        Me.lblBankedBy.Text = "Banked By"
        '
        'nbxExchangeRate
        '
        Me.nbxExchangeRate.BackColor = System.Drawing.SystemColors.Info
        Me.nbxExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxExchangeRate.ControlCaption = "Exchange Rate"
        Me.nbxExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxExchangeRate.DecimalPlaces = -1
        Me.nbxExchangeRate.DenyZeroEntryValue = True
        Me.nbxExchangeRate.Location = New System.Drawing.Point(681, 96)
        Me.nbxExchangeRate.MaxValue = 0R
        Me.nbxExchangeRate.MinValue = 0R
        Me.nbxExchangeRate.MustEnterNumeric = True
        Me.nbxExchangeRate.Name = "nbxExchangeRate"
        Me.nbxExchangeRate.Size = New System.Drawing.Size(196, 20)
        Me.nbxExchangeRate.TabIndex = 50
        Me.nbxExchangeRate.Value = ""
        '
        'lblExchangeRate
        '
        Me.lblExchangeRate.Location = New System.Drawing.Point(477, 99)
        Me.lblExchangeRate.Name = "lblExchangeRate"
        Me.lblExchangeRate.Size = New System.Drawing.Size(173, 20)
        Me.lblExchangeRate.TabIndex = 37
        Me.lblExchangeRate.Text = "Exchange Rate"
        '
        'lblAmountBankedInAccountCurrency
        '
        Me.lblAmountBankedInAccountCurrency.Location = New System.Drawing.Point(15, 201)
        Me.lblAmountBankedInAccountCurrency.Name = "lblAmountBankedInAccountCurrency"
        Me.lblAmountBankedInAccountCurrency.Size = New System.Drawing.Size(211, 20)
        Me.lblAmountBankedInAccountCurrency.TabIndex = 40
        Me.lblAmountBankedInAccountCurrency.Text = "Account Currency"
        '
        'lblBankedInAmountCurrency
        '
        Me.lblBankedInAmountCurrency.Location = New System.Drawing.Point(480, 74)
        Me.lblBankedInAmountCurrency.Name = "lblBankedInAmountCurrency"
        Me.lblBankedInAmountCurrency.Size = New System.Drawing.Size(174, 20)
        Me.lblBankedInAmountCurrency.TabIndex = 43
        Me.lblBankedInAmountCurrency.Text = "Amount Banked"
        '
        'lblTotalBanked
        '
        Me.lblTotalBanked.Location = New System.Drawing.Point(479, 8)
        Me.lblTotalBanked.Name = "lblTotalBanked"
        Me.lblTotalBanked.Size = New System.Drawing.Size(174, 20)
        Me.lblTotalBanked.TabIndex = 21
        Me.lblTotalBanked.Text = "Total Banked (Local Currency)"
        '
        'nbxBankedInAmountCurrency
        '
        Me.nbxBankedInAmountCurrency.BackColor = System.Drawing.SystemColors.Info
        Me.nbxBankedInAmountCurrency.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxBankedInAmountCurrency.ControlCaption = "Exchange Rate"
        Me.nbxBankedInAmountCurrency.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxBankedInAmountCurrency.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxBankedInAmountCurrency.DecimalPlaces = -1
        Me.nbxBankedInAmountCurrency.DenyZeroEntryValue = True
        Me.nbxBankedInAmountCurrency.Location = New System.Drawing.Point(681, 75)
        Me.nbxBankedInAmountCurrency.MaxValue = 0R
        Me.nbxBankedInAmountCurrency.MinValue = 0R
        Me.nbxBankedInAmountCurrency.MustEnterNumeric = True
        Me.nbxBankedInAmountCurrency.Name = "nbxBankedInAmountCurrency"
        Me.nbxBankedInAmountCurrency.Size = New System.Drawing.Size(196, 20)
        Me.nbxBankedInAmountCurrency.TabIndex = 48
        Me.nbxBankedInAmountCurrency.Value = ""
        '
        'tbcCollections
        '
        Me.tbcCollections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcCollections.Controls.Add(Me.tpgAllCollections)
        Me.tbcCollections.Controls.Add(Me.tpgChequePayments)
        Me.tbcCollections.Controls.Add(Me.tpgOtherPayment)
        Me.tbcCollections.Controls.Add(Me.tpgOtherPaymentCheque)
        Me.tbcCollections.Controls.Add(Me.tpgAccounts)
        Me.tbcCollections.Controls.Add(Me.tpgAccountsCheque)
        Me.tbcCollections.HotTrack = True
        Me.tbcCollections.Location = New System.Drawing.Point(12, 229)
        Me.tbcCollections.Name = "tbcCollections"
        Me.tbcCollections.SelectedIndex = 0
        Me.tbcCollections.Size = New System.Drawing.Size(860, 199)
        Me.tbcCollections.TabIndex = 61
        '
        'tpgAllCollections
        '
        Me.tpgAllCollections.Controls.Add(Me.dgvAllCollections)
        Me.tpgAllCollections.Location = New System.Drawing.Point(4, 22)
        Me.tpgAllCollections.Name = "tpgAllCollections"
        Me.tpgAllCollections.Size = New System.Drawing.Size(852, 173)
        Me.tpgAllCollections.TabIndex = 8
        Me.tpgAllCollections.Tag = "All Collections"
        Me.tpgAllCollections.Text = "All Collections"
        Me.tpgAllCollections.UseVisualStyleBackColor = True
        '
        'dgvAllCollections
        '
        Me.dgvAllCollections.AllowUserToAddRows = False
        Me.dgvAllCollections.AllowUserToDeleteRows = False
        Me.dgvAllCollections.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvAllCollections.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAllCollections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAllCollections.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvAllCollections.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAllCollections.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAllCollections.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAllCollections.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAllCollections.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAllInclude, Me.colPayModes, Me.colAmountCollected, Me.colAmountRefunded, Me.colNetPatientPaymentAmountCollected, Me.colAmountBanked, Me.colBankMode, Me.colAllCollectionsDocumentNo})
        Me.dgvAllCollections.EnableHeadersVisualStyles = False
        Me.dgvAllCollections.GridColor = System.Drawing.Color.Khaki
        Me.dgvAllCollections.Location = New System.Drawing.Point(3, 10)
        Me.dgvAllCollections.Name = "dgvAllCollections"
        Me.dgvAllCollections.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAllCollections.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvAllCollections.RowHeadersVisible = False
        Me.dgvAllCollections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvAllCollections.Size = New System.Drawing.Size(867, 160)
        Me.dgvAllCollections.TabIndex = 10
        Me.dgvAllCollections.Text = "DataGridView1"
        '
        'colAllInclude
        '
        Me.colAllInclude.ControlCaption = Nothing
        Me.colAllInclude.HeaderText = "Include"
        Me.colAllInclude.Name = "colAllInclude"
        Me.colAllInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAllInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colAllInclude.SourceColumn = Nothing
        Me.colAllInclude.Width = 50
        '
        'colPayModes
        '
        Me.colPayModes.DataPropertyName = "PayModes"
        Me.colPayModes.HeaderText = "Pay Mode"
        Me.colPayModes.Name = "colPayModes"
        '
        'colAmountCollected
        '
        Me.colAmountCollected.DataPropertyName = "AmountCollected"
        Me.colAmountCollected.HeaderText = "Amount Collected"
        Me.colAmountCollected.Name = "colAmountCollected"
        Me.colAmountCollected.Width = 120
        '
        'colAmountRefunded
        '
        Me.colAmountRefunded.DataPropertyName = "TotalAmountRefunded"
        Me.colAmountRefunded.HeaderText = "Refunded"
        Me.colAmountRefunded.Name = "colAmountRefunded"
        Me.colAmountRefunded.Width = 80
        '
        'colNetPatientPaymentAmountCollected
        '
        Me.colNetPatientPaymentAmountCollected.DataPropertyName = "NetAmountCollected"
        Me.colNetPatientPaymentAmountCollected.HeaderText = "Net  Collected"
        Me.colNetPatientPaymentAmountCollected.Name = "colNetPatientPaymentAmountCollected"
        Me.colNetPatientPaymentAmountCollected.Width = 80
        '
        'colAmountBanked
        '
        Me.colAmountBanked.DataPropertyName = "NetAmountCollected"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colAmountBanked.DefaultCellStyle = DataGridViewCellStyle3
        Me.colAmountBanked.HeaderText = "Banked(Local Currency)"
        Me.colAmountBanked.Name = "colAmountBanked"
        Me.colAmountBanked.Width = 150
        '
        'colBankMode
        '
        Me.colBankMode.HeaderText = "Bank Mode"
        Me.colBankMode.Name = "colBankMode"
        Me.colBankMode.Width = 80
        '
        'colAllCollectionsDocumentNo
        '
        Me.colAllCollectionsDocumentNo.HeaderText = "Document No"
        Me.colAllCollectionsDocumentNo.Name = "colAllCollectionsDocumentNo"
        '
        'tpgChequePayments
        '
        Me.tpgChequePayments.Controls.Add(Me.stbPatientChequePaymentsWords)
        Me.tpgChequePayments.Controls.Add(Me.lblExpenditureTotalAmount)
        Me.tpgChequePayments.Controls.Add(Me.lblExpenditureAmountWords)
        Me.tpgChequePayments.Controls.Add(Me.stbPatientChequePayments)
        Me.tpgChequePayments.Controls.Add(Me.dgvChequeCollections)
        Me.tpgChequePayments.Location = New System.Drawing.Point(4, 22)
        Me.tpgChequePayments.Name = "tpgChequePayments"
        Me.tpgChequePayments.Size = New System.Drawing.Size(852, 173)
        Me.tpgChequePayments.TabIndex = 7
        Me.tpgChequePayments.Tag = "Cheque Payments"
        Me.tpgChequePayments.Text = "Cheque Payments"
        Me.tpgChequePayments.UseVisualStyleBackColor = True
        '
        'stbPatientChequePaymentsWords
        '
        Me.stbPatientChequePaymentsWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbPatientChequePaymentsWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientChequePaymentsWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientChequePaymentsWords.CapitalizeFirstLetter = False
        Me.stbPatientChequePaymentsWords.EntryErrorMSG = ""
        Me.stbPatientChequePaymentsWords.Location = New System.Drawing.Point(419, 129)
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
        Me.lblExpenditureTotalAmount.Location = New System.Drawing.Point(7, 142)
        Me.lblExpenditureTotalAmount.Name = "lblExpenditureTotalAmount"
        Me.lblExpenditureTotalAmount.Size = New System.Drawing.Size(84, 20)
        Me.lblExpenditureTotalAmount.TabIndex = 9
        Me.lblExpenditureTotalAmount.Text = "Total Amount"
        '
        'lblExpenditureAmountWords
        '
        Me.lblExpenditureAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpenditureAmountWords.Location = New System.Drawing.Point(287, 142)
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
        Me.stbPatientChequePayments.Location = New System.Drawing.Point(97, 140)
        Me.stbPatientChequePayments.MaxLength = 20
        Me.stbPatientChequePayments.Name = "stbPatientChequePayments"
        Me.stbPatientChequePayments.RegularExpression = ""
        Me.stbPatientChequePayments.Size = New System.Drawing.Size(184, 20)
        Me.stbPatientChequePayments.TabIndex = 10
        Me.stbPatientChequePayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvChequeCollections
        '
        Me.dgvChequeCollections.AllowUserToAddRows = False
        Me.dgvChequeCollections.AllowUserToDeleteRows = False
        Me.dgvChequeCollections.AllowUserToOrderColumns = True
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvChequeCollections.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvChequeCollections.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvChequeCollections.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvChequeCollections.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvChequeCollections.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvChequeCollections.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvChequeCollections.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvChequeCollections.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIncludeChequePayment, Me.ColReceiptNo, Me.colPayDate, Me.colPatientChequeDocumentNo, Me.colPatientPaymentChequeAmount, Me.colSaved})
        Me.dgvChequeCollections.EnableHeadersVisualStyles = False
        Me.dgvChequeCollections.GridColor = System.Drawing.Color.Khaki
        Me.dgvChequeCollections.Location = New System.Drawing.Point(3, 10)
        Me.dgvChequeCollections.Name = "dgvChequeCollections"
        Me.dgvChequeCollections.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvChequeCollections.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvChequeCollections.RowHeadersVisible = False
        Me.dgvChequeCollections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvChequeCollections.Size = New System.Drawing.Size(841, 108)
        Me.dgvChequeCollections.TabIndex = 2
        Me.dgvChequeCollections.Text = "DataGridView1"
        '
        'tpgOtherPayment
        '
        Me.tpgOtherPayment.Controls.Add(Me.dgvOtherIncomes)
        Me.tpgOtherPayment.Location = New System.Drawing.Point(4, 22)
        Me.tpgOtherPayment.Name = "tpgOtherPayment"
        Me.tpgOtherPayment.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgOtherPayment.Size = New System.Drawing.Size(852, 173)
        Me.tpgOtherPayment.TabIndex = 9
        Me.tpgOtherPayment.Text = "Other Incomes"
        Me.tpgOtherPayment.UseVisualStyleBackColor = True
        '
        'dgvOtherIncomes
        '
        Me.dgvOtherIncomes.AllowUserToAddRows = False
        Me.dgvOtherIncomes.AllowUserToDeleteRows = False
        Me.dgvOtherIncomes.AllowUserToOrderColumns = True
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvOtherIncomes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvOtherIncomes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOtherIncomes.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOtherIncomes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOtherIncomes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOtherIncomes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherIncomes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvOtherIncomes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIncludeOtherIncome, Me.colOtherIncomePayMode, Me.colIncomeReceived, Me.colOtherIncomeBanked, Me.colOtherIncomeBankMode, Me.colOtherIncomeDocumentNo})
        Me.dgvOtherIncomes.EnableHeadersVisualStyles = False
        Me.dgvOtherIncomes.GridColor = System.Drawing.Color.Khaki
        Me.dgvOtherIncomes.Location = New System.Drawing.Point(6, 6)
        Me.dgvOtherIncomes.Name = "dgvOtherIncomes"
        Me.dgvOtherIncomes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherIncomes.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvOtherIncomes.RowHeadersVisible = False
        Me.dgvOtherIncomes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOtherIncomes.Size = New System.Drawing.Size(864, 161)
        Me.dgvOtherIncomes.TabIndex = 15
        Me.dgvOtherIncomes.Text = "DataGridView1"
        '
        'colIncludeOtherIncome
        '
        Me.colIncludeOtherIncome.ControlCaption = Nothing
        Me.colIncludeOtherIncome.HeaderText = "Include"
        Me.colIncludeOtherIncome.Name = "colIncludeOtherIncome"
        Me.colIncludeOtherIncome.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colIncludeOtherIncome.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colIncludeOtherIncome.SourceColumn = Nothing
        Me.colIncludeOtherIncome.Width = 50
        '
        'colOtherIncomePayMode
        '
        Me.colOtherIncomePayMode.DataPropertyName = "PayModes"
        Me.colOtherIncomePayMode.HeaderText = "Pay Mode"
        Me.colOtherIncomePayMode.Name = "colOtherIncomePayMode"
        '
        'colIncomeReceived
        '
        Me.colIncomeReceived.DataPropertyName = "Amount"
        Me.colIncomeReceived.HeaderText = "Income Received"
        Me.colIncomeReceived.Name = "colIncomeReceived"
        Me.colIncomeReceived.Width = 120
        '
        'colOtherIncomeBanked
        '
        Me.colOtherIncomeBanked.DataPropertyName = "Amount"
        Me.colOtherIncomeBanked.HeaderText = "Amount Banked(Local Currency)"
        Me.colOtherIncomeBanked.Name = "colOtherIncomeBanked"
        Me.colOtherIncomeBanked.Width = 200
        '
        'colOtherIncomeBankMode
        '
        Me.colOtherIncomeBankMode.ControlCaption = Nothing
        Me.colOtherIncomeBankMode.DisplayStyleForCurrentCellOnly = True
        Me.colOtherIncomeBankMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOtherIncomeBankMode.HeaderText = "Bank Mode"
        Me.colOtherIncomeBankMode.Name = "colOtherIncomeBankMode"
        Me.colOtherIncomeBankMode.SourceColumn = Nothing
        '
        'colOtherIncomeDocumentNo
        '
        Me.colOtherIncomeDocumentNo.HeaderText = "DocumentNo"
        Me.colOtherIncomeDocumentNo.Name = "colOtherIncomeDocumentNo"
        '
        'tpgOtherPaymentCheque
        '
        Me.tpgOtherPaymentCheque.Controls.Add(Me.dgvOtherIncomeCheque)
        Me.tpgOtherPaymentCheque.Controls.Add(Me.stbOtherIncomeChequePayMentInWords)
        Me.tpgOtherPaymentCheque.Controls.Add(Me.Label3)
        Me.tpgOtherPaymentCheque.Controls.Add(Me.Label4)
        Me.tpgOtherPaymentCheque.Controls.Add(Me.stbOtherIncomeChequePayments)
        Me.tpgOtherPaymentCheque.Location = New System.Drawing.Point(4, 22)
        Me.tpgOtherPaymentCheque.Name = "tpgOtherPaymentCheque"
        Me.tpgOtherPaymentCheque.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgOtherPaymentCheque.Size = New System.Drawing.Size(852, 173)
        Me.tpgOtherPaymentCheque.TabIndex = 10
        Me.tpgOtherPaymentCheque.Text = "Other Cheque Payment"
        Me.tpgOtherPaymentCheque.UseVisualStyleBackColor = True
        '
        'dgvOtherIncomeCheque
        '
        Me.dgvOtherIncomeCheque.AllowUserToAddRows = False
        Me.dgvOtherIncomeCheque.AllowUserToDeleteRows = False
        Me.dgvOtherIncomeCheque.AllowUserToOrderColumns = True
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvOtherIncomeCheque.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvOtherIncomeCheque.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOtherIncomeCheque.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOtherIncomeCheque.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOtherIncomeCheque.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOtherIncomeCheque.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherIncomeCheque.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvOtherIncomeCheque.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colIncludeOtherIncomeCheque, Me.colIncomeNo, Me.colOtherIncomeChequePayModes, Me.colOtherIncomeChequeReceivedIncome, Me.colOtherIncomeChequeDocumentNo, Me.colOtherIncomeChequeSaved})
        Me.dgvOtherIncomeCheque.EnableHeadersVisualStyles = False
        Me.dgvOtherIncomeCheque.GridColor = System.Drawing.Color.Khaki
        Me.dgvOtherIncomeCheque.Location = New System.Drawing.Point(4, 7)
        Me.dgvOtherIncomeCheque.Name = "dgvOtherIncomeCheque"
        Me.dgvOtherIncomeCheque.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOtherIncomeCheque.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvOtherIncomeCheque.RowHeadersVisible = False
        Me.dgvOtherIncomeCheque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOtherIncomeCheque.Size = New System.Drawing.Size(842, 113)
        Me.dgvOtherIncomeCheque.TabIndex = 20
        Me.dgvOtherIncomeCheque.Text = "DataGridView1"
        '
        'stbOtherIncomeChequePayMentInWords
        '
        Me.stbOtherIncomeChequePayMentInWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbOtherIncomeChequePayMentInWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbOtherIncomeChequePayMentInWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOtherIncomeChequePayMentInWords.CapitalizeFirstLetter = False
        Me.stbOtherIncomeChequePayMentInWords.EntryErrorMSG = ""
        Me.stbOtherIncomeChequePayMentInWords.Location = New System.Drawing.Point(417, 127)
        Me.stbOtherIncomeChequePayMentInWords.MaxLength = 100
        Me.stbOtherIncomeChequePayMentInWords.Multiline = True
        Me.stbOtherIncomeChequePayMentInWords.Name = "stbOtherIncomeChequePayMentInWords"
        Me.stbOtherIncomeChequePayMentInWords.ReadOnly = True
        Me.stbOtherIncomeChequePayMentInWords.RegularExpression = ""
        Me.stbOtherIncomeChequePayMentInWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbOtherIncomeChequePayMentInWords.Size = New System.Drawing.Size(377, 39)
        Me.stbOtherIncomeChequePayMentInWords.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(5, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 20)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Total Amount"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.Location = New System.Drawing.Point(285, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 21)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Amount in Words"
        '
        'stbOtherIncomeChequePayments
        '
        Me.stbOtherIncomeChequePayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbOtherIncomeChequePayments.BackColor = System.Drawing.SystemColors.Info
        Me.stbOtherIncomeChequePayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOtherIncomeChequePayments.CapitalizeFirstLetter = False
        Me.stbOtherIncomeChequePayments.Enabled = False
        Me.stbOtherIncomeChequePayments.EntryErrorMSG = ""
        Me.stbOtherIncomeChequePayments.Location = New System.Drawing.Point(95, 144)
        Me.stbOtherIncomeChequePayments.MaxLength = 20
        Me.stbOtherIncomeChequePayments.Name = "stbOtherIncomeChequePayments"
        Me.stbOtherIncomeChequePayments.RegularExpression = ""
        Me.stbOtherIncomeChequePayments.Size = New System.Drawing.Size(184, 20)
        Me.stbOtherIncomeChequePayments.TabIndex = 22
        Me.stbOtherIncomeChequePayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'tpgAccounts
        '
        Me.tpgAccounts.Controls.Add(Me.dgvAccounts)
        Me.tpgAccounts.Location = New System.Drawing.Point(4, 22)
        Me.tpgAccounts.Name = "tpgAccounts"
        Me.tpgAccounts.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgAccounts.Size = New System.Drawing.Size(852, 173)
        Me.tpgAccounts.TabIndex = 11
        Me.tpgAccounts.Text = "Accounts"
        Me.tpgAccounts.UseVisualStyleBackColor = True
        '
        'dgvAccounts
        '
        Me.dgvAccounts.AllowUserToAddRows = False
        Me.dgvAccounts.AllowUserToDeleteRows = False
        Me.dgvAccounts.AllowUserToOrderColumns = True
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvAccounts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvAccounts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAccounts.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvAccounts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAccounts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAccounts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccounts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvAccounts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAccountInclude, Me.colAccountPayMode, Me.colAccountAmountCredited, Me.colAccountBankedAmount, Me.colAccountBankMode, Me.colAccountDocumentNo})
        Me.dgvAccounts.EnableHeadersVisualStyles = False
        Me.dgvAccounts.GridColor = System.Drawing.Color.Khaki
        Me.dgvAccounts.Location = New System.Drawing.Point(4, 6)
        Me.dgvAccounts.Name = "dgvAccounts"
        Me.dgvAccounts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccounts.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvAccounts.RowHeadersVisible = False
        Me.dgvAccounts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvAccounts.Size = New System.Drawing.Size(843, 161)
        Me.dgvAccounts.TabIndex = 16
        Me.dgvAccounts.Text = "DataGridView1"
        '
        'colAccountInclude
        '
        Me.colAccountInclude.ControlCaption = Nothing
        Me.colAccountInclude.HeaderText = "Include"
        Me.colAccountInclude.Name = "colAccountInclude"
        Me.colAccountInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAccountInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colAccountInclude.SourceColumn = Nothing
        Me.colAccountInclude.Width = 50
        '
        'colAccountPayMode
        '
        Me.colAccountPayMode.DataPropertyName = "PayModes"
        Me.colAccountPayMode.HeaderText = "Pay Mode"
        Me.colAccountPayMode.Name = "colAccountPayMode"
        '
        'colAccountAmountCredited
        '
        Me.colAccountAmountCredited.DataPropertyName = "Amount"
        Me.colAccountAmountCredited.HeaderText = "Amount Credited"
        Me.colAccountAmountCredited.Name = "colAccountAmountCredited"
        Me.colAccountAmountCredited.Width = 120
        '
        'colAccountBankedAmount
        '
        Me.colAccountBankedAmount.DataPropertyName = "Amount"
        Me.colAccountBankedAmount.HeaderText = "Amount Banked(Local Currency)"
        Me.colAccountBankedAmount.Name = "colAccountBankedAmount"
        Me.colAccountBankedAmount.Width = 200
        '
        'colAccountBankMode
        '
        Me.colAccountBankMode.ControlCaption = Nothing
        Me.colAccountBankMode.DisplayStyleForCurrentCellOnly = True
        Me.colAccountBankMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colAccountBankMode.HeaderText = "Bank Mode"
        Me.colAccountBankMode.Name = "colAccountBankMode"
        Me.colAccountBankMode.SourceColumn = Nothing
        '
        'colAccountDocumentNo
        '
        Me.colAccountDocumentNo.HeaderText = "DocumentNo"
        Me.colAccountDocumentNo.Name = "colAccountDocumentNo"
        '
        'tpgAccountsCheque
        '
        Me.tpgAccountsCheque.Controls.Add(Me.stbAccountChequeInWords)
        Me.tpgAccountsCheque.Controls.Add(Me.Label5)
        Me.tpgAccountsCheque.Controls.Add(Me.Label6)
        Me.tpgAccountsCheque.Controls.Add(Me.stbAccountCheque)
        Me.tpgAccountsCheque.Controls.Add(Me.dgvAccountsCheque)
        Me.tpgAccountsCheque.Location = New System.Drawing.Point(4, 22)
        Me.tpgAccountsCheque.Name = "tpgAccountsCheque"
        Me.tpgAccountsCheque.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgAccountsCheque.Size = New System.Drawing.Size(852, 173)
        Me.tpgAccountsCheque.TabIndex = 12
        Me.tpgAccountsCheque.Text = "Account Cheques"
        Me.tpgAccountsCheque.UseVisualStyleBackColor = True
        '
        'stbAccountChequeInWords
        '
        Me.stbAccountChequeInWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbAccountChequeInWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAccountChequeInWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountChequeInWords.CapitalizeFirstLetter = False
        Me.stbAccountChequeInWords.EntryErrorMSG = ""
        Me.stbAccountChequeInWords.Location = New System.Drawing.Point(419, 126)
        Me.stbAccountChequeInWords.MaxLength = 100
        Me.stbAccountChequeInWords.Multiline = True
        Me.stbAccountChequeInWords.Name = "stbAccountChequeInWords"
        Me.stbAccountChequeInWords.ReadOnly = True
        Me.stbAccountChequeInWords.RegularExpression = ""
        Me.stbAccountChequeInWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAccountChequeInWords.Size = New System.Drawing.Size(377, 39)
        Me.stbAccountChequeInWords.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.Location = New System.Drawing.Point(7, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 20)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Total Amount"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label6.Location = New System.Drawing.Point(287, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 21)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Amount in Words"
        '
        'stbAccountCheque
        '
        Me.stbAccountCheque.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbAccountCheque.BackColor = System.Drawing.SystemColors.Info
        Me.stbAccountCheque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountCheque.CapitalizeFirstLetter = False
        Me.stbAccountCheque.Enabled = False
        Me.stbAccountCheque.EntryErrorMSG = ""
        Me.stbAccountCheque.Location = New System.Drawing.Point(97, 137)
        Me.stbAccountCheque.MaxLength = 20
        Me.stbAccountCheque.Name = "stbAccountCheque"
        Me.stbAccountCheque.RegularExpression = ""
        Me.stbAccountCheque.Size = New System.Drawing.Size(184, 20)
        Me.stbAccountCheque.TabIndex = 15
        Me.stbAccountCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgvAccountsCheque
        '
        Me.dgvAccountsCheque.AllowUserToAddRows = False
        Me.dgvAccountsCheque.AllowUserToDeleteRows = False
        Me.dgvAccountsCheque.AllowUserToOrderColumns = True
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle17.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvAccountsCheque.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvAccountsCheque.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAccountsCheque.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvAccountsCheque.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAccountsCheque.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAccountsCheque.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountsCheque.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvAccountsCheque.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAccountChequeInclude, Me.colTranNo, Me.colAccountChequePayModes, Me.colAccountChequeDocument, Me.colAccountChequeAmount, Me.colAccountChequeSaved})
        Me.dgvAccountsCheque.EnableHeadersVisualStyles = False
        Me.dgvAccountsCheque.GridColor = System.Drawing.Color.Khaki
        Me.dgvAccountsCheque.Location = New System.Drawing.Point(2, 6)
        Me.dgvAccountsCheque.Name = "dgvAccountsCheque"
        Me.dgvAccountsCheque.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountsCheque.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvAccountsCheque.RowHeadersVisible = False
        Me.dgvAccountsCheque.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvAccountsCheque.Size = New System.Drawing.Size(844, 108)
        Me.dgvAccountsCheque.TabIndex = 13
        Me.dgvAccountsCheque.Text = "DataGridView1"
        '
        'lblIncomeSourceCategory
        '
        Me.lblIncomeSourceCategory.Location = New System.Drawing.Point(14, 32)
        Me.lblIncomeSourceCategory.Name = "lblIncomeSourceCategory"
        Me.lblIncomeSourceCategory.Size = New System.Drawing.Size(212, 20)
        Me.lblIncomeSourceCategory.TabIndex = 62
        Me.lblIncomeSourceCategory.Text = "Collection Source"
        '
        'colIncludeChequePayment
        '
        Me.colIncludeChequePayment.DataPropertyName = "IsSaved"
        Me.colIncludeChequePayment.HeaderText = "Include"
        Me.colIncludeChequePayment.Name = "colIncludeChequePayment"
        Me.colIncludeChequePayment.Width = 50
        '
        'ColReceiptNo
        '
        Me.ColReceiptNo.DataPropertyName = "ReceiptNo"
        Me.ColReceiptNo.HeaderText = "Receipt No"
        Me.ColReceiptNo.Name = "ColReceiptNo"
        Me.ColReceiptNo.Width = 150
        '
        'colPayDate
        '
        Me.colPayDate.DataPropertyName = "PayDate"
        Me.colPayDate.FillWeight = 120.0!
        Me.colPayDate.HeaderText = "Pay Date"
        Me.colPayDate.Name = "colPayDate"
        Me.colPayDate.Width = 150
        '
        'colPatientChequeDocumentNo
        '
        Me.colPatientChequeDocumentNo.DataPropertyName = "DocumentNo"
        Me.colPatientChequeDocumentNo.HeaderText = "Document No"
        Me.colPatientChequeDocumentNo.Name = "colPatientChequeDocumentNo"
        Me.colPatientChequeDocumentNo.Width = 150
        '
        'colPatientPaymentChequeAmount
        '
        Me.colPatientPaymentChequeAmount.DataPropertyName = "AmountPaid"
        Me.colPatientPaymentChequeAmount.HeaderText = "Amount Paid"
        Me.colPatientPaymentChequeAmount.Name = "colPatientPaymentChequeAmount"
        Me.colPatientPaymentChequeAmount.Width = 150
        '
        'colSaved
        '
        Me.colSaved.HeaderText = "Saved"
        Me.colSaved.Name = "colSaved"
        '
        'colAccountChequeInclude
        '
        Me.colAccountChequeInclude.HeaderText = "Include"
        Me.colAccountChequeInclude.Name = "colAccountChequeInclude"
        Me.colAccountChequeInclude.Width = 50
        '
        'colTranNo
        '
        Me.colTranNo.DataPropertyName = "TranNo"
        Me.colTranNo.HeaderText = "Trans No"
        Me.colTranNo.Name = "colTranNo"
        Me.colTranNo.Width = 150
        '
        'colAccountChequePayModes
        '
        Me.colAccountChequePayModes.DataPropertyName = "PayModes"
        Me.colAccountChequePayModes.FillWeight = 120.0!
        Me.colAccountChequePayModes.HeaderText = "Pay Mode"
        Me.colAccountChequePayModes.Name = "colAccountChequePayModes"
        Me.colAccountChequePayModes.Width = 150
        '
        'colAccountChequeDocument
        '
        Me.colAccountChequeDocument.DataPropertyName = "DocumentNo"
        Me.colAccountChequeDocument.HeaderText = "Document No"
        Me.colAccountChequeDocument.Name = "colAccountChequeDocument"
        Me.colAccountChequeDocument.Width = 150
        '
        'colAccountChequeAmount
        '
        Me.colAccountChequeAmount.DataPropertyName = "Amount"
        Me.colAccountChequeAmount.HeaderText = "Amount"
        Me.colAccountChequeAmount.Name = "colAccountChequeAmount"
        Me.colAccountChequeAmount.Width = 150
        '
        'colAccountChequeSaved
        '
        Me.colAccountChequeSaved.DataPropertyName = "IsSaved"
        Me.colAccountChequeSaved.HeaderText = "Saved"
        Me.colAccountChequeSaved.Name = "colAccountChequeSaved"
        Me.colAccountChequeSaved.Width = 50
        '
        'colIncludeOtherIncomeCheque
        '
        Me.colIncludeOtherIncomeCheque.HeaderText = "Include"
        Me.colIncludeOtherIncomeCheque.Name = "colIncludeOtherIncomeCheque"
        Me.colIncludeOtherIncomeCheque.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colIncludeOtherIncomeCheque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colIncludeOtherIncomeCheque.Width = 50
        '
        'colIncomeNo
        '
        Me.colIncomeNo.DataPropertyName = "IncomeNo"
        Me.colIncomeNo.HeaderText = "Income No"
        Me.colIncomeNo.Name = "colIncomeNo"
        Me.colIncomeNo.ReadOnly = True
        '
        'colOtherIncomeChequePayModes
        '
        Me.colOtherIncomeChequePayModes.DataPropertyName = "PayModes"
        Me.colOtherIncomeChequePayModes.HeaderText = "Pay Mode"
        Me.colOtherIncomeChequePayModes.Name = "colOtherIncomeChequePayModes"
        '
        'colOtherIncomeChequeReceivedIncome
        '
        Me.colOtherIncomeChequeReceivedIncome.DataPropertyName = "Amount"
        Me.colOtherIncomeChequeReceivedIncome.HeaderText = "Income Received"
        Me.colOtherIncomeChequeReceivedIncome.Name = "colOtherIncomeChequeReceivedIncome"
        Me.colOtherIncomeChequeReceivedIncome.Width = 120
        '
        'colOtherIncomeChequeDocumentNo
        '
        Me.colOtherIncomeChequeDocumentNo.DataPropertyName = "DocumentNo"
        Me.colOtherIncomeChequeDocumentNo.HeaderText = "Document No"
        Me.colOtherIncomeChequeDocumentNo.Name = "colOtherIncomeChequeDocumentNo"
        Me.colOtherIncomeChequeDocumentNo.Width = 120
        '
        'colOtherIncomeChequeSaved
        '
        Me.colOtherIncomeChequeSaved.ControlCaption = Nothing
        Me.colOtherIncomeChequeSaved.DataPropertyName = "IsSaved"
        Me.colOtherIncomeChequeSaved.HeaderText = "Saved"
        Me.colOtherIncomeChequeSaved.Name = "colOtherIncomeChequeSaved"
        Me.colOtherIncomeChequeSaved.ReadOnly = True
        Me.colOtherIncomeChequeSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colOtherIncomeChequeSaved.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colOtherIncomeChequeSaved.SourceColumn = Nothing
        '
        'frmBankingRegister
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(884, 491)
        Me.Controls.Add(Me.cboCollectionSource)
        Me.Controls.Add(Me.lblIncomeSourceCategory)
        Me.Controls.Add(Me.tbcCollections)
        Me.Controls.Add(Me.nbxBankedInAmountCurrency)
        Me.Controls.Add(Me.dtpCollectionEndDateTime)
        Me.Controls.Add(Me.dtpCollectionStartDateTime)
        Me.Controls.Add(Me.stbCurrency)
        Me.Controls.Add(Me.lblBankedInAmountCurrency)
        Me.Controls.Add(Me.lblAmountBankedInAccountCurrency)
        Me.Controls.Add(Me.nbxExchangeRate)
        Me.Controls.Add(Me.lblExchangeRate)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbRegisterNo)
        Me.Controls.Add(Me.lblRegisterNo)
        Me.Controls.Add(Me.lblCollectionStartDate)
        Me.Controls.Add(Me.lblCollectionEndDate)
        Me.Controls.Add(Me.dtpBankingDate)
        Me.Controls.Add(Me.lblBankingDate)
        Me.Controls.Add(Me.cboBankNameID)
        Me.Controls.Add(Me.lblBankNameID)
        Me.Controls.Add(Me.stbAccountNo)
        Me.Controls.Add(Me.lblAccountName)
        Me.Controls.Add(Me.cboAccountNames)
        Me.Controls.Add(Me.lblAccountNo)
        Me.Controls.Add(Me.nbxAmountCollected)
        Me.Controls.Add(Me.lblAmountCollected)
        Me.Controls.Add(Me.lblTotalBanked)
        Me.Controls.Add(Me.nbxAmountBanked)
        Me.Controls.Add(Me.lblAmountBanked)
        Me.Controls.Add(Me.stbAmountInWords)
        Me.Controls.Add(Me.lblAmountInWords)
        Me.Controls.Add(Me.stbBankedBy)
        Me.Controls.Add(Me.lblBankedBy)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmBankingRegister"
        Me.Text = "Banking Register"
        Me.tbcCollections.ResumeLayout(False)
        Me.tpgAllCollections.ResumeLayout(False)
        CType(Me.dgvAllCollections, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgChequePayments.ResumeLayout(False)
        Me.tpgChequePayments.PerformLayout()
        CType(Me.dgvChequeCollections, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOtherPayment.ResumeLayout(False)
        CType(Me.dgvOtherIncomes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOtherPaymentCheque.ResumeLayout(False)
        Me.tpgOtherPaymentCheque.PerformLayout()
        CType(Me.dgvOtherIncomeCheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgAccounts.ResumeLayout(False)
        CType(Me.dgvAccounts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgAccountsCheque.ResumeLayout(False)
        Me.tpgAccountsCheque.PerformLayout()
        CType(Me.dgvAccountsCheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents stbRegisterNo As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblRegisterNo As System.Windows.Forms.Label
    Friend WithEvents lblCollectionStartDate As System.Windows.Forms.Label
    Friend WithEvents lblCollectionEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpBankingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblBankingDate As System.Windows.Forms.Label
    Friend WithEvents cboBankNameID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBankNameID As System.Windows.Forms.Label
    Friend WithEvents stbAccountNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountName As System.Windows.Forms.Label
    Friend WithEvents cboAccountNames As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents nbxAmountCollected As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAmountCollected As System.Windows.Forms.Label
    Friend WithEvents nbxAmountBanked As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAmountBanked As System.Windows.Forms.Label
    Friend WithEvents stbAmountInWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountInWords As System.Windows.Forms.Label
    Friend WithEvents stbBankedBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBankedBy As System.Windows.Forms.Label
    Friend WithEvents nbxExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblExchangeRate As Label
    Friend WithEvents lblAmountBankedInAccountCurrency As Label
    Friend WithEvents stbCurrency As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblBankedInAmountCurrency As Label
    Friend WithEvents dtpCollectionStartDateTime As DateTimePicker
    Friend WithEvents dtpCollectionEndDateTime As DateTimePicker
    Friend WithEvents lblTotalBanked As System.Windows.Forms.Label
    Friend WithEvents nbxBankedInAmountCurrency As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents tbcCollections As TabControl
    Friend WithEvents tpgAllCollections As TabPage
    Friend WithEvents dgvAllCollections As DataGridView
    Friend WithEvents tpgChequePayments As TabPage
    Friend WithEvents stbPatientChequePaymentsWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExpenditureTotalAmount As Label
    Friend WithEvents lblExpenditureAmountWords As Label
    Friend WithEvents stbPatientChequePayments As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dgvChequeCollections As DataGridView
    Friend WithEvents cboCollectionSource As ComboBox
    Friend WithEvents lblIncomeSourceCategory As Label
    Friend WithEvents tpgOtherPayment As TabPage
    Friend WithEvents dgvOtherIncomes As DataGridView
    Friend WithEvents tpgOtherPaymentCheque As TabPage
    Friend WithEvents dgvOtherIncomeCheque As DataGridView
    Friend WithEvents stbOtherIncomeChequePayMentInWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents stbOtherIncomeChequePayments As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents tpgAccounts As TabPage
    Friend WithEvents dgvAccounts As DataGridView
    Friend WithEvents tpgAccountsCheque As TabPage
    Friend WithEvents stbAccountChequeInWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents stbAccountCheque As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dgvAccountsCheque As DataGridView
    Friend WithEvents colAllInclude As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents colPayModes As DataGridViewTextBoxColumn
    Friend WithEvents colAmountCollected As DataGridViewTextBoxColumn
    Friend WithEvents colAmountRefunded As DataGridViewTextBoxColumn
    Friend WithEvents colNetPatientPaymentAmountCollected As DataGridViewTextBoxColumn
    Friend WithEvents colAmountBanked As DataGridViewTextBoxColumn
    Friend WithEvents colBankMode As DataGridViewComboBoxColumn
    Friend WithEvents colAllCollectionsDocumentNo As DataGridViewTextBoxColumn
    Friend WithEvents colIncludeOtherIncome As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents colOtherIncomePayMode As DataGridViewTextBoxColumn
    Friend WithEvents colIncomeReceived As DataGridViewTextBoxColumn
    Friend WithEvents colOtherIncomeBanked As DataGridViewTextBoxColumn
    Friend WithEvents colOtherIncomeBankMode As SyncSoft.Common.Win.Controls.GridComboBoxColumn
    Friend WithEvents colOtherIncomeDocumentNo As DataGridViewTextBoxColumn
    Friend WithEvents colAccountInclude As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents colAccountPayMode As DataGridViewTextBoxColumn
    Friend WithEvents colAccountAmountCredited As DataGridViewTextBoxColumn
    Friend WithEvents colAccountBankedAmount As DataGridViewTextBoxColumn
    Friend WithEvents colAccountBankMode As SyncSoft.Common.Win.Controls.GridComboBoxColumn
    Friend WithEvents colAccountDocumentNo As DataGridViewTextBoxColumn
    Friend WithEvents colIncludeChequePayment As DataGridViewCheckBoxColumn
    Friend WithEvents ColReceiptNo As DataGridViewTextBoxColumn
    Friend WithEvents colPayDate As DataGridViewTextBoxColumn
    Friend WithEvents colPatientChequeDocumentNo As DataGridViewTextBoxColumn
    Friend WithEvents colPatientPaymentChequeAmount As DataGridViewTextBoxColumn
    Friend WithEvents colSaved As DataGridViewCheckBoxColumn
    Friend WithEvents colIncludeOtherIncomeCheque As DataGridViewCheckBoxColumn
    Friend WithEvents colIncomeNo As DataGridViewTextBoxColumn
    Friend WithEvents colOtherIncomeChequePayModes As DataGridViewTextBoxColumn
    Friend WithEvents colOtherIncomeChequeReceivedIncome As DataGridViewTextBoxColumn
    Friend WithEvents colOtherIncomeChequeDocumentNo As DataGridViewTextBoxColumn
    Friend WithEvents colOtherIncomeChequeSaved As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents colAccountChequeInclude As DataGridViewCheckBoxColumn
    Friend WithEvents colTranNo As DataGridViewTextBoxColumn
    Friend WithEvents colAccountChequePayModes As DataGridViewTextBoxColumn
    Friend WithEvents colAccountChequeDocument As DataGridViewTextBoxColumn
    Friend WithEvents colAccountChequeAmount As DataGridViewTextBoxColumn
    Friend WithEvents colAccountChequeSaved As DataGridViewCheckBoxColumn
End Class