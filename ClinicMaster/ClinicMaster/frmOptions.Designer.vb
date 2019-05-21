<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOptions
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
        InitOptions.Dispose()
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOptions))
        Me.hlpOptions = New System.Windows.Forms.HelpProvider()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.cboStartUpWindow = New System.Windows.Forms.ComboBox()
        Me.cboCurrency = New System.Windows.Forms.ComboBox()
        Me.nudDecimalPlaces = New System.Windows.Forms.NumericUpDown()
        Me.tpgGeneral = New System.Windows.Forms.TabPage()
        Me.lblPasswordComplexityID = New System.Windows.Forms.Label()
        Me.cboPasswordComplexityID = New System.Windows.Forms.ComboBox()
        Me.cbodefaultLanguage = New System.Windows.Forms.ComboBox()
        Me.lblDefaultLanguage = New System.Windows.Forms.Label()
        Me.stbSearchCustomInsertCharacter = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSearchCustomInsertCharacter = New System.Windows.Forms.Label()
        Me.nbxSearchCustomInsertPosition = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblSearchCustomInsertPosition = New System.Windows.Forms.Label()
        Me.nbxSearchCustomInsertLength = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblSearchCustomInsertLength = New System.Windows.Forms.Label()
        Me.nbxUserIdleDuration = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblUserIdleDuration = New System.Windows.Forms.Label()
        Me.chkAlertSoundOn = New System.Windows.Forms.CheckBox()
        Me.nbxAlertCheckPeriod = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAlertCheckPeriod = New System.Windows.Forms.Label()
        Me.grpManageBulkData = New System.Windows.Forms.GroupBox()
        Me.lblDisableConstraints = New System.Windows.Forms.Label()
        Me.cboDisableConstraints = New System.Windows.Forms.ComboBox()
        Me.lblManageBulkData = New System.Windows.Forms.Label()
        Me.btnProcess = New System.Windows.Forms.Button()
        Me.chkEnableAuditTrail = New System.Windows.Forms.CheckBox()
        Me.lblDecimalPlaces = New System.Windows.Forms.Label()
        Me.lblCurrency = New System.Windows.Forms.Label()
        Me.grpRestore = New System.Windows.Forms.GroupBox()
        Me.btnChangeRestore = New System.Windows.Forms.Button()
        Me.lblRestore = New System.Windows.Forms.Label()
        Me.grpBackup = New System.Windows.Forms.GroupBox()
        Me.btnChangeBackup = New System.Windows.Forms.Button()
        Me.lblBackup = New System.Windows.Forms.Label()
        Me.lblNullDateValue = New System.Windows.Forms.Label()
        Me.mtbNullDateValue = New System.Windows.Forms.MaskedTextBox()
        Me.lblStartUpWindow = New System.Windows.Forms.Label()
        Me.tbcOptions = New System.Windows.Forms.TabControl()
        Me.tpgSetupData = New System.Windows.Forms.TabPage()
        Me.ChkEnableViewCashCollections = New System.Windows.Forms.CheckBox()
        Me.cboSMSNotificationPoint = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDefaultSelfRequestNo = New System.Windows.Forms.ComboBox()
        Me.lblDefaultPatientNo = New System.Windows.Forms.Label()
        Me.chkOpenPharmacyAfterCashier = New System.Windows.Forms.CheckBox()
        Me.chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest = New System.Windows.Forms.CheckBox()
        Me.chkEnableChatNotification = New System.Windows.Forms.CheckBox()
        Me.chkOpenCashierAfterSelfRequest = New System.Windows.Forms.CheckBox()
        Me.cboCashierPrinterPaperSize = New System.Windows.Forms.ComboBox()
        Me.lblCashierPaperSize = New System.Windows.Forms.Label()
        Me.cboPharmacyPrinterPaperSize = New System.Windows.Forms.ComboBox()
        Me.lblPrinterPaperSize = New System.Windows.Forms.Label()
        Me.chkLoadConsumableItemsAtStart = New System.Windows.Forms.CheckBox()
        Me.chkToBillServiceFeeLocked = New System.Windows.Forms.CheckBox()
        Me.cboVisitCategory = New System.Windows.Forms.ComboBox()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.cboAssociatedBillNo = New System.Windows.Forms.ComboBox()
        Me.lblAssociatedBillNo = New System.Windows.Forms.Label()
        Me.cboLocation = New System.Windows.Forms.ComboBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.grpSmartCardData = New System.Windows.Forms.GroupBox()
        Me.btnSmartCardData = New System.Windows.Forms.Button()
        Me.lblSmartCardData = New System.Windows.Forms.Label()
        Me.chkForceFingerprintCapture = New System.Windows.Forms.CheckBox()
        Me.chkLoadPatientFingerprintsAtStart = New System.Windows.Forms.CheckBox()
        Me.chkLoadDentalServicesAtStart = New System.Windows.Forms.CheckBox()
        Me.chkLoadDiseasesAtStart = New System.Windows.Forms.CheckBox()
        Me.chkLoadProceduresAtStart = New System.Windows.Forms.CheckBox()
        Me.chkPromptForExtraChargeRegistration = New System.Windows.Forms.CheckBox()
        Me.chkForceVisitBillConfirmation = New System.Windows.Forms.CheckBox()
        Me.chkLoadDrugsAtStart = New System.Windows.Forms.CheckBox()
        Me.chkLoadRadiologyExaminationsAtStart = New System.Windows.Forms.CheckBox()
        Me.chkLoadLabTestsAtStart = New System.Windows.Forms.CheckBox()
        Me.chkLoadBillCustomersAtStart = New System.Windows.Forms.CheckBox()
        Me.tpgAutoNumbers = New System.Windows.Forms.TabPage()
        Me.dgvAutoNumbers = New System.Windows.Forms.DataGridView()
        Me.colObjectCaption = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAutoColumnName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAutoColumnLEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaddingCHAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaddingLEN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSeparatorCHAR = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSeparatorPositions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStartValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIncrement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAllowJumpTo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colJumpToValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colObjectName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgAutoNumberControls = New System.Windows.Forms.TabPage()
        Me.chkTheatreCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkCardiologyExamCode = New System.Windows.Forms.CheckBox()
        Me.chkEyeCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkTestCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkServiceCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkRadiologyExamNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkProcedureCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkOpticalCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkNonMedicalItemCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkDentalCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkMaternityCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkPathologyExamCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkPackageNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkICUCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkExtraChargeItemCodeLocked = New System.Windows.Forms.CheckBox()
        Me.chkBedNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkStaffNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkDrugNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkConsumableNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkGRNNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkPurchaseOrderNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkSupplierNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkOrderNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkTransferNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkMainMemberNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkMedicalCardNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkOutwardNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkQuotationNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkRefundNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkInvoiceNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkExtraBillNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkClaimNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkCompanyNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkPolicyNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkInsuranceNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkRoundNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkAdmissionNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkTranNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkIncomeNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkExpenditureNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkReceiptNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkSpecimenNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkVisitNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkAccountNoLocked = New System.Windows.Forms.CheckBox()
        Me.chkPatientNoLocked = New System.Windows.Forms.CheckBox()
        Me.tpgProductOwnerInfo = New System.Windows.Forms.TabPage()
        Me.stbFacilityNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFacilityNo = New System.Windows.Forms.Label()
        Me.nudTextLeftMargin = New System.Windows.Forms.NumericUpDown()
        Me.lblTextLeftMargin = New System.Windows.Forms.Label()
        Me.nudLogoLeftMargin = New System.Windows.Forms.NumericUpDown()
        Me.lblLogoLeftMargin = New System.Windows.Forms.Label()
        Me.nudTextTopMargin = New System.Windows.Forms.NumericUpDown()
        Me.lblTextTopMargin = New System.Windows.Forms.Label()
        Me.nudLogoTopMargin = New System.Windows.Forms.NumericUpDown()
        Me.lblLogoTopMargin = New System.Windows.Forms.Label()
        Me.lblPrintHeaderAlignmentID = New System.Windows.Forms.Label()
        Me.cboPrintHeaderAlignmentID = New System.Windows.Forms.ComboBox()
        Me.btnClearAlternatePhoto = New System.Windows.Forms.Button()
        Me.btnLoadAlternatePhoto = New System.Windows.Forms.Button()
        Me.lblAlternatePhoto = New System.Windows.Forms.Label()
        Me.lblAlternateEmail = New System.Windows.Forms.Label()
        Me.lblAlternatePhone = New System.Windows.Forms.Label()
        Me.lblVATNo = New System.Windows.Forms.Label()
        Me.lblTINNo = New System.Windows.Forms.Label()
        Me.btnClearPhoto = New System.Windows.Forms.Button()
        Me.btnLoadPhoto = New System.Windows.Forms.Button()
        Me.lblProductOwner = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblFax = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblWebsite = New System.Windows.Forms.Label()
        Me.lblPhoto = New System.Windows.Forms.Label()
        Me.spbAlternatePhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.stbAlternateEmail = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAlternatePhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVATNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbTINNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbProductOwner = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAddress = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPhone = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFax = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbEmail = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbWebsite = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.spbPhoto = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.tpgOtherVariousOptions = New System.Windows.Forms.TabPage()
        Me.dgvOptions = New System.Windows.Forms.DataGridView()
        Me.colOptionName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOptionValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDataTypeID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colMaxLength = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOptionsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgSearchObjects = New System.Windows.Forms.TabPage()
        Me.dgvSearchObjects = New System.Windows.Forms.DataGridView()
        Me.colSearchObjectsObjectCaption = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSearhInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colSearchObjectsObjectName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgOthers = New System.Windows.Forms.TabPage()
        Me.cboCommunityID = New System.Windows.Forms.ComboBox()
        Me.lblCommunity = New System.Windows.Forms.Label()
        Me.cboServicePointQueue = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboRoomID = New System.Windows.Forms.ComboBox()
        Me.lblRoomName = New System.Windows.Forms.Label()
        Me.cboVoices = New System.Windows.Forms.ComboBox()
        Me.lblVoice = New System.Windows.Forms.Label()
        Me.cboBranch = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.clbIssueLocations = New System.Windows.Forms.CheckedListBox()
        Me.lblIssueFromLocations = New System.Windows.Forms.Label()
        CType(Me.nudDecimalPlaces, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgGeneral.SuspendLayout()
        Me.grpManageBulkData.SuspendLayout()
        Me.grpRestore.SuspendLayout()
        Me.grpBackup.SuspendLayout()
        Me.tbcOptions.SuspendLayout()
        Me.tpgSetupData.SuspendLayout()
        Me.grpSmartCardData.SuspendLayout()
        Me.tpgAutoNumbers.SuspendLayout()
        CType(Me.dgvAutoNumbers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgAutoNumberControls.SuspendLayout()
        Me.tpgProductOwnerInfo.SuspendLayout()
        CType(Me.nudTextLeftMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLogoLeftMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTextTopMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudLogoTopMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spbAlternatePhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOtherVariousOptions.SuspendLayout()
        CType(Me.dgvOptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgSearchObjects.SuspendLayout()
        CType(Me.dgvSearchObjects, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOthers.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.hlpOptions.SetHelpString(Me.btnCancel, "Closes without applying options")
        Me.btnCancel.Location = New System.Drawing.Point(639, 411)
        Me.btnCancel.Name = "btnCancel"
        Me.hlpOptions.SetShowHelp(Me.btnCancel, True)
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "&Cancel"
        '
        'btnApply
        '
        Me.btnApply.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnApply.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.hlpOptions.SetHelpString(Me.btnApply, "Apply Options")
        Me.btnApply.Location = New System.Drawing.Point(334, 411)
        Me.btnApply.Name = "btnApply"
        Me.hlpOptions.SetShowHelp(Me.btnApply, True)
        Me.btnApply.Size = New System.Drawing.Size(75, 23)
        Me.btnApply.TabIndex = 2
        Me.btnApply.Tag = "Options"
        Me.btnApply.Text = "&Apply"
        '
        'btnOK
        '
        Me.btnOK.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnOK.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.hlpOptions.SetHelpString(Me.btnOK, "Apply Options and close window")
        Me.btnOK.Location = New System.Drawing.Point(16, 411)
        Me.btnOK.Name = "btnOK"
        Me.hlpOptions.SetShowHelp(Me.btnOK, True)
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Tag = "Options"
        Me.btnOK.Text = "&OK"
        '
        'cboStartUpWindow
        '
        Me.cboStartUpWindow.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStartUpWindow.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboStartUpWindow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStartUpWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStartUpWindow.FormattingEnabled = True
        Me.hlpOptions.SetHelpString(Me.cboStartUpWindow, "The selected window will load as default window when application starts")
        Me.cboStartUpWindow.Items.AddRange(New Object() {"Home", "Search", "Unsent Text Messages", "Patients", "Visits", "Triage", "Cashier", "Doctor", "Lab Requests", "Lab Results", "Pharmacy", "Appointments", "Admissions", "Discharges", "Deaths", "Self Request", "ART Regimen", "ART Stopped", "Inventory"})
        Me.cboStartUpWindow.Location = New System.Drawing.Point(163, 12)
        Me.cboStartUpWindow.Name = "cboStartUpWindow"
        Me.hlpOptions.SetShowHelp(Me.cboStartUpWindow, True)
        Me.cboStartUpWindow.Size = New System.Drawing.Size(151, 21)
        Me.cboStartUpWindow.TabIndex = 1
        '
        'cboCurrency
        '
        Me.cboCurrency.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCurrency.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrency.Enabled = False
        Me.cboCurrency.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCurrency.FormattingEnabled = True
        Me.hlpOptions.SetHelpString(Me.cboCurrency, "Currency in the application")
        Me.cboCurrency.Items.AddRange(New Object() {"UGX", "USD"})
        Me.cboCurrency.Location = New System.Drawing.Point(163, 86)
        Me.cboCurrency.Name = "cboCurrency"
        Me.hlpOptions.SetShowHelp(Me.cboCurrency, True)
        Me.cboCurrency.Size = New System.Drawing.Size(151, 21)
        Me.cboCurrency.TabIndex = 7
        '
        'nudDecimalPlaces
        '
        Me.nudDecimalPlaces.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudDecimalPlaces.Enabled = False
        Me.hlpOptions.SetHelpString(Me.nudDecimalPlaces, "Number of digits for the decimal places")
        Me.nudDecimalPlaces.Location = New System.Drawing.Point(163, 60)
        Me.nudDecimalPlaces.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.nudDecimalPlaces.Name = "nudDecimalPlaces"
        Me.hlpOptions.SetShowHelp(Me.nudDecimalPlaces, True)
        Me.nudDecimalPlaces.Size = New System.Drawing.Size(40, 20)
        Me.nudDecimalPlaces.TabIndex = 5
        Me.nudDecimalPlaces.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'tpgGeneral
        '
        Me.tpgGeneral.Controls.Add(Me.lblPasswordComplexityID)
        Me.tpgGeneral.Controls.Add(Me.cboPasswordComplexityID)
        Me.tpgGeneral.Controls.Add(Me.cbodefaultLanguage)
        Me.tpgGeneral.Controls.Add(Me.lblDefaultLanguage)
        Me.tpgGeneral.Controls.Add(Me.stbSearchCustomInsertCharacter)
        Me.tpgGeneral.Controls.Add(Me.lblSearchCustomInsertCharacter)
        Me.tpgGeneral.Controls.Add(Me.nbxSearchCustomInsertPosition)
        Me.tpgGeneral.Controls.Add(Me.lblSearchCustomInsertPosition)
        Me.tpgGeneral.Controls.Add(Me.nbxSearchCustomInsertLength)
        Me.tpgGeneral.Controls.Add(Me.lblSearchCustomInsertLength)
        Me.tpgGeneral.Controls.Add(Me.nbxUserIdleDuration)
        Me.tpgGeneral.Controls.Add(Me.lblUserIdleDuration)
        Me.tpgGeneral.Controls.Add(Me.chkAlertSoundOn)
        Me.tpgGeneral.Controls.Add(Me.nbxAlertCheckPeriod)
        Me.tpgGeneral.Controls.Add(Me.lblAlertCheckPeriod)
        Me.tpgGeneral.Controls.Add(Me.grpManageBulkData)
        Me.tpgGeneral.Controls.Add(Me.chkEnableAuditTrail)
        Me.tpgGeneral.Controls.Add(Me.nudDecimalPlaces)
        Me.tpgGeneral.Controls.Add(Me.lblDecimalPlaces)
        Me.tpgGeneral.Controls.Add(Me.cboCurrency)
        Me.tpgGeneral.Controls.Add(Me.lblCurrency)
        Me.tpgGeneral.Controls.Add(Me.grpRestore)
        Me.tpgGeneral.Controls.Add(Me.grpBackup)
        Me.tpgGeneral.Controls.Add(Me.lblNullDateValue)
        Me.tpgGeneral.Controls.Add(Me.mtbNullDateValue)
        Me.tpgGeneral.Controls.Add(Me.cboStartUpWindow)
        Me.tpgGeneral.Controls.Add(Me.lblStartUpWindow)
        Me.hlpOptions.SetHelpString(Me.tpgGeneral, "If date value is not entered, this value is used for null date")
        Me.tpgGeneral.Location = New System.Drawing.Point(4, 22)
        Me.tpgGeneral.Name = "tpgGeneral"
        Me.hlpOptions.SetShowHelp(Me.tpgGeneral, True)
        Me.tpgGeneral.Size = New System.Drawing.Size(696, 376)
        Me.tpgGeneral.TabIndex = 0
        Me.tpgGeneral.Text = "General"
        Me.tpgGeneral.UseVisualStyleBackColor = True
        '
        'lblPasswordComplexityID
        '
        Me.lblPasswordComplexityID.Location = New System.Drawing.Point(320, 143)
        Me.lblPasswordComplexityID.Name = "lblPasswordComplexityID"
        Me.lblPasswordComplexityID.Size = New System.Drawing.Size(137, 20)
        Me.lblPasswordComplexityID.TabIndex = 25
        Me.lblPasswordComplexityID.Text = "Password Complexity"
        '
        'cboPasswordComplexityID
        '
        Me.cboPasswordComplexityID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPasswordComplexityID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPasswordComplexityID.Location = New System.Drawing.Point(534, 142)
        Me.cboPasswordComplexityID.Name = "cboPasswordComplexityID"
        Me.cboPasswordComplexityID.Size = New System.Drawing.Size(151, 21)
        Me.cboPasswordComplexityID.TabIndex = 26
        '
        'cbodefaultLanguage
        '
        Me.cbodefaultLanguage.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cbodefaultLanguage.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cbodefaultLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbodefaultLanguage.Enabled = False
        Me.cbodefaultLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbodefaultLanguage.FormattingEnabled = True
        Me.hlpOptions.SetHelpString(Me.cbodefaultLanguage, "The selected window will load as default window when application starts")
        Me.cbodefaultLanguage.Items.AddRange(New Object() {"", "English", "French", "Swahili"})
        Me.cbodefaultLanguage.Location = New System.Drawing.Point(163, 137)
        Me.cbodefaultLanguage.Name = "cbodefaultLanguage"
        Me.hlpOptions.SetShowHelp(Me.cbodefaultLanguage, True)
        Me.cbodefaultLanguage.Size = New System.Drawing.Size(151, 21)
        Me.cbodefaultLanguage.TabIndex = 24
        '
        'lblDefaultLanguage
        '
        Me.lblDefaultLanguage.Location = New System.Drawing.Point(14, 137)
        Me.lblDefaultLanguage.Name = "lblDefaultLanguage"
        Me.lblDefaultLanguage.Size = New System.Drawing.Size(131, 13)
        Me.lblDefaultLanguage.TabIndex = 23
        Me.lblDefaultLanguage.Text = "Default Language"
        '
        'stbSearchCustomInsertCharacter
        '
        Me.stbSearchCustomInsertCharacter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSearchCustomInsertCharacter.CapitalizeFirstLetter = True
        Me.stbSearchCustomInsertCharacter.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbSearchCustomInsertCharacter.EntryErrorMSG = ""
        Me.stbSearchCustomInsertCharacter.Location = New System.Drawing.Point(534, 77)
        Me.stbSearchCustomInsertCharacter.MaxLength = 1
        Me.stbSearchCustomInsertCharacter.Name = "stbSearchCustomInsertCharacter"
        Me.stbSearchCustomInsertCharacter.RegularExpression = ""
        Me.stbSearchCustomInsertCharacter.Size = New System.Drawing.Size(54, 20)
        Me.stbSearchCustomInsertCharacter.TabIndex = 15
        '
        'lblSearchCustomInsertCharacter
        '
        Me.lblSearchCustomInsertCharacter.Location = New System.Drawing.Point(320, 78)
        Me.lblSearchCustomInsertCharacter.Name = "lblSearchCustomInsertCharacter"
        Me.lblSearchCustomInsertCharacter.Size = New System.Drawing.Size(187, 20)
        Me.lblSearchCustomInsertCharacter.TabIndex = 14
        Me.lblSearchCustomInsertCharacter.Text = "Search Custom Insert Character"
        '
        'nbxSearchCustomInsertPosition
        '
        Me.nbxSearchCustomInsertPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxSearchCustomInsertPosition.ControlCaption = "Search Custom Insert Position"
        Me.nbxSearchCustomInsertPosition.DecimalPlaces = -1
        Me.nbxSearchCustomInsertPosition.Location = New System.Drawing.Point(534, 119)
        Me.nbxSearchCustomInsertPosition.MaxLength = 3
        Me.nbxSearchCustomInsertPosition.MaxValue = 500.0R
        Me.nbxSearchCustomInsertPosition.MinValue = 5.0R
        Me.nbxSearchCustomInsertPosition.MustEnterNumeric = True
        Me.nbxSearchCustomInsertPosition.Name = "nbxSearchCustomInsertPosition"
        Me.nbxSearchCustomInsertPosition.Size = New System.Drawing.Size(54, 20)
        Me.nbxSearchCustomInsertPosition.TabIndex = 19
        Me.nbxSearchCustomInsertPosition.Value = ""
        '
        'lblSearchCustomInsertPosition
        '
        Me.lblSearchCustomInsertPosition.Location = New System.Drawing.Point(320, 120)
        Me.lblSearchCustomInsertPosition.Name = "lblSearchCustomInsertPosition"
        Me.lblSearchCustomInsertPosition.Size = New System.Drawing.Size(187, 20)
        Me.lblSearchCustomInsertPosition.TabIndex = 18
        Me.lblSearchCustomInsertPosition.Text = "Search Custom Insert Position"
        '
        'nbxSearchCustomInsertLength
        '
        Me.nbxSearchCustomInsertLength.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxSearchCustomInsertLength.ControlCaption = "Search Custom Insert Length"
        Me.nbxSearchCustomInsertLength.DecimalPlaces = -1
        Me.nbxSearchCustomInsertLength.Location = New System.Drawing.Point(534, 98)
        Me.nbxSearchCustomInsertLength.MaxLength = 3
        Me.nbxSearchCustomInsertLength.MaxValue = 1000.0R
        Me.nbxSearchCustomInsertLength.MinValue = 10.0R
        Me.nbxSearchCustomInsertLength.MustEnterNumeric = True
        Me.nbxSearchCustomInsertLength.Name = "nbxSearchCustomInsertLength"
        Me.nbxSearchCustomInsertLength.Size = New System.Drawing.Size(54, 20)
        Me.nbxSearchCustomInsertLength.TabIndex = 17
        Me.nbxSearchCustomInsertLength.Value = ""
        '
        'lblSearchCustomInsertLength
        '
        Me.lblSearchCustomInsertLength.Location = New System.Drawing.Point(320, 99)
        Me.lblSearchCustomInsertLength.Name = "lblSearchCustomInsertLength"
        Me.lblSearchCustomInsertLength.Size = New System.Drawing.Size(187, 20)
        Me.lblSearchCustomInsertLength.TabIndex = 16
        Me.lblSearchCustomInsertLength.Text = "Search Custom Insert Length"
        '
        'nbxUserIdleDuration
        '
        Me.nbxUserIdleDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUserIdleDuration.ControlCaption = "User Idle Duration"
        Me.nbxUserIdleDuration.DecimalPlaces = -1
        Me.nbxUserIdleDuration.Location = New System.Drawing.Point(534, 56)
        Me.nbxUserIdleDuration.MaxLength = 3
        Me.nbxUserIdleDuration.MaxValue = 90.0R
        Me.nbxUserIdleDuration.MinValue = 1.0R
        Me.nbxUserIdleDuration.MustEnterNumeric = True
        Me.nbxUserIdleDuration.Name = "nbxUserIdleDuration"
        Me.nbxUserIdleDuration.Size = New System.Drawing.Size(54, 20)
        Me.nbxUserIdleDuration.TabIndex = 13
        Me.nbxUserIdleDuration.Value = ""
        '
        'lblUserIdleDuration
        '
        Me.lblUserIdleDuration.Location = New System.Drawing.Point(320, 58)
        Me.lblUserIdleDuration.Name = "lblUserIdleDuration"
        Me.lblUserIdleDuration.Size = New System.Drawing.Size(187, 20)
        Me.lblUserIdleDuration.TabIndex = 12
        Me.lblUserIdleDuration.Text = "User Idle Duration (Min)"
        '
        'chkAlertSoundOn
        '
        Me.chkAlertSoundOn.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAlertSoundOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAlertSoundOn.Location = New System.Drawing.Point(320, 34)
        Me.chkAlertSoundOn.Name = "chkAlertSoundOn"
        Me.chkAlertSoundOn.Size = New System.Drawing.Size(226, 20)
        Me.chkAlertSoundOn.TabIndex = 11
        Me.chkAlertSoundOn.Text = "Alert Sound On"
        '
        'nbxAlertCheckPeriod
        '
        Me.nbxAlertCheckPeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAlertCheckPeriod.ControlCaption = "Alert Check Period"
        Me.nbxAlertCheckPeriod.DecimalPlaces = -1
        Me.nbxAlertCheckPeriod.Location = New System.Drawing.Point(534, 12)
        Me.nbxAlertCheckPeriod.MaxLength = 3
        Me.nbxAlertCheckPeriod.MaxValue = 60.0R
        Me.nbxAlertCheckPeriod.MinValue = 1.0R
        Me.nbxAlertCheckPeriod.MustEnterNumeric = True
        Me.nbxAlertCheckPeriod.Name = "nbxAlertCheckPeriod"
        Me.nbxAlertCheckPeriod.Size = New System.Drawing.Size(54, 20)
        Me.nbxAlertCheckPeriod.TabIndex = 10
        Me.nbxAlertCheckPeriod.Value = ""
        '
        'lblAlertCheckPeriod
        '
        Me.lblAlertCheckPeriod.Location = New System.Drawing.Point(320, 12)
        Me.lblAlertCheckPeriod.Name = "lblAlertCheckPeriod"
        Me.lblAlertCheckPeriod.Size = New System.Drawing.Size(187, 20)
        Me.lblAlertCheckPeriod.TabIndex = 9
        Me.lblAlertCheckPeriod.Text = "Alert Check Period (Min)"
        '
        'grpManageBulkData
        '
        Me.grpManageBulkData.BackColor = System.Drawing.Color.Transparent
        Me.grpManageBulkData.Controls.Add(Me.lblDisableConstraints)
        Me.grpManageBulkData.Controls.Add(Me.cboDisableConstraints)
        Me.grpManageBulkData.Controls.Add(Me.lblManageBulkData)
        Me.grpManageBulkData.Controls.Add(Me.btnProcess)
        Me.grpManageBulkData.Location = New System.Drawing.Point(14, 287)
        Me.grpManageBulkData.Name = "grpManageBulkData"
        Me.grpManageBulkData.Size = New System.Drawing.Size(667, 64)
        Me.grpManageBulkData.TabIndex = 22
        Me.grpManageBulkData.TabStop = False
        '
        'lblDisableConstraints
        '
        Me.lblDisableConstraints.ForeColor = System.Drawing.Color.DarkRed
        Me.lblDisableConstraints.Location = New System.Drawing.Point(12, 39)
        Me.lblDisableConstraints.Name = "lblDisableConstraints"
        Me.lblDisableConstraints.Size = New System.Drawing.Size(431, 22)
        Me.lblDisableConstraints.TabIndex = 3
        Me.lblDisableConstraints.Text = "It’s recommended that you enable data rules that have been disabled."
        Me.lblDisableConstraints.Visible = False
        '
        'cboDisableConstraints
        '
        Me.cboDisableConstraints.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDisableConstraints.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDisableConstraints.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDisableConstraints.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDisableConstraints.FormattingEnabled = True
        Me.hlpOptions.SetHelpString(Me.cboDisableConstraints, "Enables or Disables Data Rules for Bulk Deletion and/or Updates")
        Me.cboDisableConstraints.Items.AddRange(New Object() {"Enable", "Disable"})
        Me.cboDisableConstraints.Location = New System.Drawing.Point(306, 15)
        Me.cboDisableConstraints.Name = "cboDisableConstraints"
        Me.hlpOptions.SetShowHelp(Me.cboDisableConstraints, True)
        Me.cboDisableConstraints.Size = New System.Drawing.Size(137, 21)
        Me.cboDisableConstraints.TabIndex = 1
        '
        'lblManageBulkData
        '
        Me.lblManageBulkData.Location = New System.Drawing.Point(12, 15)
        Me.lblManageBulkData.Name = "lblManageBulkData"
        Me.lblManageBulkData.Size = New System.Drawing.Size(288, 24)
        Me.lblManageBulkData.TabIndex = 0
        Me.lblManageBulkData.Text = "Manage Bulk Data Deletion and/or Update Rule(s)"
        '
        'btnProcess
        '
        Me.btnProcess.BackColor = System.Drawing.SystemColors.Control
        Me.btnProcess.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProcess.Location = New System.Drawing.Point(473, 14)
        Me.btnProcess.Name = "btnProcess"
        Me.hlpOptions.SetShowHelp(Me.btnProcess, True)
        Me.btnProcess.Size = New System.Drawing.Size(80, 24)
        Me.btnProcess.TabIndex = 2
        Me.btnProcess.Text = "&Process..."
        Me.btnProcess.UseVisualStyleBackColor = False
        '
        'chkEnableAuditTrail
        '
        Me.chkEnableAuditTrail.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEnableAuditTrail.Enabled = False
        Me.chkEnableAuditTrail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkEnableAuditTrail.Location = New System.Drawing.Point(11, 114)
        Me.chkEnableAuditTrail.Name = "chkEnableAuditTrail"
        Me.chkEnableAuditTrail.Size = New System.Drawing.Size(164, 16)
        Me.chkEnableAuditTrail.TabIndex = 8
        Me.chkEnableAuditTrail.Text = "Enable Audit Trail"
        '
        'lblDecimalPlaces
        '
        Me.lblDecimalPlaces.Enabled = False
        Me.lblDecimalPlaces.Location = New System.Drawing.Point(11, 62)
        Me.lblDecimalPlaces.Name = "lblDecimalPlaces"
        Me.lblDecimalPlaces.Size = New System.Drawing.Size(131, 13)
        Me.lblDecimalPlaces.TabIndex = 4
        Me.lblDecimalPlaces.Text = "Decimal Places"
        '
        'lblCurrency
        '
        Me.lblCurrency.Enabled = False
        Me.lblCurrency.Location = New System.Drawing.Point(11, 87)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.Size = New System.Drawing.Size(131, 13)
        Me.lblCurrency.TabIndex = 6
        Me.lblCurrency.Text = "Currency"
        '
        'grpRestore
        '
        Me.grpRestore.BackColor = System.Drawing.Color.Transparent
        Me.grpRestore.Controls.Add(Me.btnChangeRestore)
        Me.grpRestore.Controls.Add(Me.lblRestore)
        Me.grpRestore.Location = New System.Drawing.Point(14, 220)
        Me.grpRestore.Name = "grpRestore"
        Me.grpRestore.Size = New System.Drawing.Size(667, 69)
        Me.grpRestore.TabIndex = 21
        Me.grpRestore.TabStop = False
        Me.grpRestore.Text = "Restore Data From"
        '
        'btnChangeRestore
        '
        Me.btnChangeRestore.BackColor = System.Drawing.SystemColors.Control
        Me.btnChangeRestore.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnChangeRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeRestore.Location = New System.Drawing.Point(473, 28)
        Me.btnChangeRestore.Name = "btnChangeRestore"
        Me.hlpOptions.SetShowHelp(Me.btnChangeRestore, True)
        Me.btnChangeRestore.Size = New System.Drawing.Size(80, 24)
        Me.btnChangeRestore.TabIndex = 1
        Me.btnChangeRestore.Text = "Cha&nge..."
        Me.btnChangeRestore.UseVisualStyleBackColor = False
        '
        'lblRestore
        '
        Me.lblRestore.Location = New System.Drawing.Point(12, 20)
        Me.lblRestore.Name = "lblRestore"
        Me.lblRestore.Size = New System.Drawing.Size(439, 38)
        Me.lblRestore.TabIndex = 0
        Me.lblRestore.Text = "C:\SIL Backup\DatabaseName"
        Me.lblRestore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpBackup
        '
        Me.grpBackup.BackColor = System.Drawing.Color.Transparent
        Me.grpBackup.Controls.Add(Me.btnChangeBackup)
        Me.grpBackup.Controls.Add(Me.lblBackup)
        Me.grpBackup.Location = New System.Drawing.Point(14, 164)
        Me.grpBackup.Name = "grpBackup"
        Me.grpBackup.Size = New System.Drawing.Size(667, 76)
        Me.grpBackup.TabIndex = 20
        Me.grpBackup.TabStop = False
        Me.grpBackup.Text = "Backup Data to"
        '
        'btnChangeBackup
        '
        Me.btnChangeBackup.BackColor = System.Drawing.SystemColors.Control
        Me.btnChangeBackup.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnChangeBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeBackup.Location = New System.Drawing.Point(473, 27)
        Me.btnChangeBackup.Name = "btnChangeBackup"
        Me.hlpOptions.SetShowHelp(Me.btnChangeBackup, True)
        Me.btnChangeBackup.Size = New System.Drawing.Size(80, 24)
        Me.btnChangeBackup.TabIndex = 1
        Me.btnChangeBackup.Text = "C&hange..."
        Me.btnChangeBackup.UseVisualStyleBackColor = False
        '
        'lblBackup
        '
        Me.lblBackup.Location = New System.Drawing.Point(9, 16)
        Me.lblBackup.Name = "lblBackup"
        Me.lblBackup.Size = New System.Drawing.Size(442, 44)
        Me.lblBackup.TabIndex = 0
        Me.lblBackup.Text = "C:\SIL Backup\DatabaseName"
        Me.lblBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNullDateValue
        '
        Me.lblNullDateValue.Enabled = False
        Me.lblNullDateValue.Location = New System.Drawing.Point(11, 41)
        Me.lblNullDateValue.Name = "lblNullDateValue"
        Me.lblNullDateValue.Size = New System.Drawing.Size(131, 13)
        Me.lblNullDateValue.TabIndex = 2
        Me.lblNullDateValue.Text = "Null Date Value"
        '
        'mtbNullDateValue
        '
        Me.mtbNullDateValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.mtbNullDateValue.Enabled = False
        Me.mtbNullDateValue.Location = New System.Drawing.Point(163, 41)
        Me.mtbNullDateValue.Mask = "00/00/0000"
        Me.mtbNullDateValue.Name = "mtbNullDateValue"
        Me.hlpOptions.SetShowHelp(Me.mtbNullDateValue, True)
        Me.mtbNullDateValue.Size = New System.Drawing.Size(181, 13)
        Me.mtbNullDateValue.TabIndex = 3
        Me.mtbNullDateValue.ValidatingType = GetType(Date)
        '
        'lblStartUpWindow
        '
        Me.lblStartUpWindow.Location = New System.Drawing.Point(11, 15)
        Me.lblStartUpWindow.Name = "lblStartUpWindow"
        Me.lblStartUpWindow.Size = New System.Drawing.Size(131, 13)
        Me.lblStartUpWindow.TabIndex = 0
        Me.lblStartUpWindow.Text = "Start Up Window"
        '
        'tbcOptions
        '
        Me.tbcOptions.Controls.Add(Me.tpgGeneral)
        Me.tbcOptions.Controls.Add(Me.tpgSetupData)
        Me.tbcOptions.Controls.Add(Me.tpgAutoNumbers)
        Me.tbcOptions.Controls.Add(Me.tpgAutoNumberControls)
        Me.tbcOptions.Controls.Add(Me.tpgProductOwnerInfo)
        Me.tbcOptions.Controls.Add(Me.tpgOtherVariousOptions)
        Me.tbcOptions.Controls.Add(Me.tpgSearchObjects)
        Me.tbcOptions.Controls.Add(Me.tpgOthers)
        Me.tbcOptions.HotTrack = True
        Me.tbcOptions.Location = New System.Drawing.Point(16, 3)
        Me.tbcOptions.Name = "tbcOptions"
        Me.tbcOptions.SelectedIndex = 0
        Me.tbcOptions.Size = New System.Drawing.Size(704, 402)
        Me.tbcOptions.TabIndex = 0
        '
        'tpgSetupData
        '
        Me.tpgSetupData.Controls.Add(Me.ChkEnableViewCashCollections)
        Me.tpgSetupData.Controls.Add(Me.cboSMSNotificationPoint)
        Me.tpgSetupData.Controls.Add(Me.Label2)
        Me.tpgSetupData.Controls.Add(Me.cboDefaultSelfRequestNo)
        Me.tpgSetupData.Controls.Add(Me.lblDefaultPatientNo)
        Me.tpgSetupData.Controls.Add(Me.chkOpenPharmacyAfterCashier)
        Me.tpgSetupData.Controls.Add(Me.chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest)
        Me.tpgSetupData.Controls.Add(Me.chkEnableChatNotification)
        Me.tpgSetupData.Controls.Add(Me.chkOpenCashierAfterSelfRequest)
        Me.tpgSetupData.Controls.Add(Me.cboCashierPrinterPaperSize)
        Me.tpgSetupData.Controls.Add(Me.lblCashierPaperSize)
        Me.tpgSetupData.Controls.Add(Me.cboPharmacyPrinterPaperSize)
        Me.tpgSetupData.Controls.Add(Me.lblPrinterPaperSize)
        Me.tpgSetupData.Controls.Add(Me.chkLoadConsumableItemsAtStart)
        Me.tpgSetupData.Controls.Add(Me.chkToBillServiceFeeLocked)
        Me.tpgSetupData.Controls.Add(Me.cboVisitCategory)
        Me.tpgSetupData.Controls.Add(Me.lblVisitCategory)
        Me.tpgSetupData.Controls.Add(Me.cboAssociatedBillNo)
        Me.tpgSetupData.Controls.Add(Me.lblAssociatedBillNo)
        Me.tpgSetupData.Controls.Add(Me.cboLocation)
        Me.tpgSetupData.Controls.Add(Me.lblLocation)
        Me.tpgSetupData.Controls.Add(Me.grpSmartCardData)
        Me.tpgSetupData.Controls.Add(Me.chkForceFingerprintCapture)
        Me.tpgSetupData.Controls.Add(Me.chkLoadPatientFingerprintsAtStart)
        Me.tpgSetupData.Controls.Add(Me.chkLoadDentalServicesAtStart)
        Me.tpgSetupData.Controls.Add(Me.chkLoadDiseasesAtStart)
        Me.tpgSetupData.Controls.Add(Me.chkLoadProceduresAtStart)
        Me.tpgSetupData.Controls.Add(Me.chkPromptForExtraChargeRegistration)
        Me.tpgSetupData.Controls.Add(Me.chkForceVisitBillConfirmation)
        Me.tpgSetupData.Controls.Add(Me.chkLoadDrugsAtStart)
        Me.tpgSetupData.Controls.Add(Me.chkLoadRadiologyExaminationsAtStart)
        Me.tpgSetupData.Controls.Add(Me.chkLoadLabTestsAtStart)
        Me.tpgSetupData.Controls.Add(Me.chkLoadBillCustomersAtStart)
        Me.tpgSetupData.Location = New System.Drawing.Point(4, 22)
        Me.tpgSetupData.Name = "tpgSetupData"
        Me.tpgSetupData.Size = New System.Drawing.Size(696, 376)
        Me.tpgSetupData.TabIndex = 5
        Me.tpgSetupData.Text = "Setup Data"
        Me.tpgSetupData.UseVisualStyleBackColor = True
        '
        'ChkEnableViewCashCollections
        '
        Me.ChkEnableViewCashCollections.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkEnableViewCashCollections.Checked = True
        Me.ChkEnableViewCashCollections.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkEnableViewCashCollections.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkEnableViewCashCollections.Location = New System.Drawing.Point(255, 105)
        Me.ChkEnableViewCashCollections.Name = "ChkEnableViewCashCollections"
        Me.ChkEnableViewCashCollections.Size = New System.Drawing.Size(343, 17)
        Me.ChkEnableViewCashCollections.TabIndex = 33
        Me.ChkEnableViewCashCollections.Text = "Enable View My Cash Collections"
        '
        'cboSMSNotificationPoint
        '
        Me.cboSMSNotificationPoint.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboSMSNotificationPoint.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboSMSNotificationPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSMSNotificationPoint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSMSNotificationPoint.FormattingEnabled = True
        Me.cboSMSNotificationPoint.Location = New System.Drawing.Point(466, 266)
        Me.cboSMSNotificationPoint.Name = "cboSMSNotificationPoint"
        Me.cboSMSNotificationPoint.Size = New System.Drawing.Size(132, 21)
        Me.cboSMSNotificationPoint.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(255, 268)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(203, 20)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Use PC As SMS Notification Point"
        '
        'cboDefaultSelfRequestNo
        '
        Me.cboDefaultSelfRequestNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDefaultSelfRequestNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDefaultSelfRequestNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDefaultSelfRequestNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDefaultSelfRequestNo.FormattingEnabled = True
        Me.cboDefaultSelfRequestNo.Location = New System.Drawing.Point(464, 244)
        Me.cboDefaultSelfRequestNo.Name = "cboDefaultSelfRequestNo"
        Me.cboDefaultSelfRequestNo.Size = New System.Drawing.Size(134, 21)
        Me.cboDefaultSelfRequestNo.TabIndex = 30
        '
        'lblDefaultPatientNo
        '
        Me.lblDefaultPatientNo.Location = New System.Drawing.Point(255, 242)
        Me.lblDefaultPatientNo.Name = "lblDefaultPatientNo"
        Me.lblDefaultPatientNo.Size = New System.Drawing.Size(171, 20)
        Me.lblDefaultPatientNo.TabIndex = 29
        Me.lblDefaultPatientNo.Text = "Default Patient No"
        '
        'chkOpenPharmacyAfterCashier
        '
        Me.chkOpenPharmacyAfterCashier.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOpenPharmacyAfterCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOpenPharmacyAfterCashier.Location = New System.Drawing.Point(11, 220)
        Me.chkOpenPharmacyAfterCashier.Name = "chkOpenPharmacyAfterCashier"
        Me.chkOpenPharmacyAfterCashier.Size = New System.Drawing.Size(230, 20)
        Me.chkOpenPharmacyAfterCashier.TabIndex = 12
        Me.chkOpenPharmacyAfterCashier.Text = "Open Pharmacy After Cashier"
        '
        'chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest
        '
        Me.chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest.Location = New System.Drawing.Point(255, 85)
        Me.chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest.Name = "chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest"
        Me.chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest.Size = New System.Drawing.Size(343, 17)
        Me.chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest.TabIndex = 18
        Me.chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest.Text = "Enable Only Prescription, Extras,Consumables At Self Request"
        '
        'chkEnableChatNotification
        '
        Me.chkEnableChatNotification.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEnableChatNotification.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkEnableChatNotification.Location = New System.Drawing.Point(255, 65)
        Me.chkEnableChatNotification.Name = "chkEnableChatNotification"
        Me.chkEnableChatNotification.Size = New System.Drawing.Size(343, 17)
        Me.chkEnableChatNotification.TabIndex = 17
        Me.chkEnableChatNotification.Text = "Enable Chat Notifications"
        '
        'chkOpenCashierAfterSelfRequest
        '
        Me.chkOpenCashierAfterSelfRequest.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOpenCashierAfterSelfRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOpenCashierAfterSelfRequest.Location = New System.Drawing.Point(12, 198)
        Me.chkOpenCashierAfterSelfRequest.Name = "chkOpenCashierAfterSelfRequest"
        Me.chkOpenCashierAfterSelfRequest.Size = New System.Drawing.Size(230, 16)
        Me.chkOpenCashierAfterSelfRequest.TabIndex = 11
        Me.chkOpenCashierAfterSelfRequest.Text = "Open Cashier After Self Request"
        '
        'cboCashierPrinterPaperSize
        '
        Me.cboCashierPrinterPaperSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCashierPrinterPaperSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCashierPrinterPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCashierPrinterPaperSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCashierPrinterPaperSize.FormattingEnabled = True
        Me.cboCashierPrinterPaperSize.Location = New System.Drawing.Point(464, 221)
        Me.cboCashierPrinterPaperSize.Name = "cboCashierPrinterPaperSize"
        Me.cboCashierPrinterPaperSize.Size = New System.Drawing.Size(134, 21)
        Me.cboCashierPrinterPaperSize.TabIndex = 28
        '
        'lblCashierPaperSize
        '
        Me.lblCashierPaperSize.Location = New System.Drawing.Point(255, 221)
        Me.lblCashierPaperSize.Name = "lblCashierPaperSize"
        Me.lblCashierPaperSize.Size = New System.Drawing.Size(171, 20)
        Me.lblCashierPaperSize.TabIndex = 27
        Me.lblCashierPaperSize.Text = "Cashier Printer Paper Size"
        '
        'cboPharmacyPrinterPaperSize
        '
        Me.cboPharmacyPrinterPaperSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboPharmacyPrinterPaperSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboPharmacyPrinterPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPharmacyPrinterPaperSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPharmacyPrinterPaperSize.FormattingEnabled = True
        Me.cboPharmacyPrinterPaperSize.Location = New System.Drawing.Point(464, 198)
        Me.cboPharmacyPrinterPaperSize.Name = "cboPharmacyPrinterPaperSize"
        Me.cboPharmacyPrinterPaperSize.Size = New System.Drawing.Size(134, 21)
        Me.cboPharmacyPrinterPaperSize.TabIndex = 26
        '
        'lblPrinterPaperSize
        '
        Me.lblPrinterPaperSize.Location = New System.Drawing.Point(255, 198)
        Me.lblPrinterPaperSize.Name = "lblPrinterPaperSize"
        Me.lblPrinterPaperSize.Size = New System.Drawing.Size(171, 20)
        Me.lblPrinterPaperSize.TabIndex = 25
        Me.lblPrinterPaperSize.Text = "Pharmacy Printer Paper Size"
        '
        'chkLoadConsumableItemsAtStart
        '
        Me.chkLoadConsumableItemsAtStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLoadConsumableItemsAtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLoadConsumableItemsAtStart.Location = New System.Drawing.Point(12, 90)
        Me.chkLoadConsumableItemsAtStart.Name = "chkLoadConsumableItemsAtStart"
        Me.chkLoadConsumableItemsAtStart.Size = New System.Drawing.Size(230, 16)
        Me.chkLoadConsumableItemsAtStart.TabIndex = 4
        Me.chkLoadConsumableItemsAtStart.Text = "Load Consumable Items At Start"
        '
        'chkToBillServiceFeeLocked
        '
        Me.chkToBillServiceFeeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkToBillServiceFeeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkToBillServiceFeeLocked.Location = New System.Drawing.Point(12, 248)
        Me.chkToBillServiceFeeLocked.Name = "chkToBillServiceFeeLocked"
        Me.chkToBillServiceFeeLocked.Size = New System.Drawing.Size(230, 20)
        Me.chkToBillServiceFeeLocked.TabIndex = 13
        Me.chkToBillServiceFeeLocked.Text = "To-Bill Service Fee Locked"
        '
        'cboVisitCategory
        '
        Me.cboVisitCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVisitCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVisitCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVisitCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVisitCategory.FormattingEnabled = True
        Me.cboVisitCategory.Location = New System.Drawing.Point(464, 126)
        Me.cboVisitCategory.Name = "cboVisitCategory"
        Me.cboVisitCategory.Size = New System.Drawing.Size(134, 21)
        Me.cboVisitCategory.TabIndex = 20
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(255, 127)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(171, 20)
        Me.lblVisitCategory.TabIndex = 19
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'cboAssociatedBillNo
        '
        Me.cboAssociatedBillNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAssociatedBillNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAssociatedBillNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAssociatedBillNo.DropDownWidth = 230
        Me.cboAssociatedBillNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAssociatedBillNo.FormattingEnabled = True
        Me.cboAssociatedBillNo.Location = New System.Drawing.Point(464, 175)
        Me.cboAssociatedBillNo.Name = "cboAssociatedBillNo"
        Me.cboAssociatedBillNo.Size = New System.Drawing.Size(134, 21)
        Me.cboAssociatedBillNo.Sorted = True
        Me.cboAssociatedBillNo.TabIndex = 24
        '
        'lblAssociatedBillNo
        '
        Me.lblAssociatedBillNo.Location = New System.Drawing.Point(255, 174)
        Me.lblAssociatedBillNo.Name = "lblAssociatedBillNo"
        Me.lblAssociatedBillNo.Size = New System.Drawing.Size(171, 20)
        Me.lblAssociatedBillNo.TabIndex = 23
        Me.lblAssociatedBillNo.Text = "Associated Bill Customer"
        '
        'cboLocation
        '
        Me.cboLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocation.FormattingEnabled = True
        Me.cboLocation.Location = New System.Drawing.Point(464, 151)
        Me.cboLocation.Name = "cboLocation"
        Me.cboLocation.Size = New System.Drawing.Size(134, 21)
        Me.cboLocation.TabIndex = 22
        '
        'lblLocation
        '
        Me.lblLocation.Location = New System.Drawing.Point(255, 151)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(171, 20)
        Me.lblLocation.TabIndex = 21
        Me.lblLocation.Text = "Location"
        '
        'grpSmartCardData
        '
        Me.grpSmartCardData.BackColor = System.Drawing.Color.Transparent
        Me.grpSmartCardData.Controls.Add(Me.btnSmartCardData)
        Me.grpSmartCardData.Controls.Add(Me.lblSmartCardData)
        Me.grpSmartCardData.Location = New System.Drawing.Point(16, 303)
        Me.grpSmartCardData.Name = "grpSmartCardData"
        Me.grpSmartCardData.Size = New System.Drawing.Size(667, 64)
        Me.grpSmartCardData.TabIndex = 20
        Me.grpSmartCardData.TabStop = False
        Me.grpSmartCardData.Text = "Smart Card Data"
        '
        'btnSmartCardData
        '
        Me.btnSmartCardData.BackColor = System.Drawing.SystemColors.Control
        Me.btnSmartCardData.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSmartCardData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSmartCardData.Location = New System.Drawing.Point(501, 26)
        Me.btnSmartCardData.Name = "btnSmartCardData"
        Me.btnSmartCardData.Size = New System.Drawing.Size(80, 24)
        Me.btnSmartCardData.TabIndex = 1
        Me.btnSmartCardData.Text = "C&hange..."
        Me.btnSmartCardData.UseVisualStyleBackColor = False
        '
        'lblSmartCardData
        '
        Me.lblSmartCardData.Location = New System.Drawing.Point(9, 16)
        Me.lblSmartCardData.Name = "lblSmartCardData"
        Me.lblSmartCardData.Size = New System.Drawing.Size(442, 44)
        Me.lblSmartCardData.TabIndex = 0
        Me.lblSmartCardData.Text = "C:\TransferFiles"
        Me.lblSmartCardData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkForceFingerprintCapture
        '
        Me.chkForceFingerprintCapture.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkForceFingerprintCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkForceFingerprintCapture.Location = New System.Drawing.Point(255, 47)
        Me.chkForceFingerprintCapture.Name = "chkForceFingerprintCapture"
        Me.chkForceFingerprintCapture.Size = New System.Drawing.Size(343, 16)
        Me.chkForceFingerprintCapture.TabIndex = 16
        Me.chkForceFingerprintCapture.Text = "Force Fingerprint Capture"
        '
        'chkLoadPatientFingerprintsAtStart
        '
        Me.chkLoadPatientFingerprintsAtStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLoadPatientFingerprintsAtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLoadPatientFingerprintsAtStart.Location = New System.Drawing.Point(12, 175)
        Me.chkLoadPatientFingerprintsAtStart.Name = "chkLoadPatientFingerprintsAtStart"
        Me.chkLoadPatientFingerprintsAtStart.Size = New System.Drawing.Size(230, 16)
        Me.chkLoadPatientFingerprintsAtStart.TabIndex = 8
        Me.chkLoadPatientFingerprintsAtStart.Text = "Load Patient Fingerprints At Start"
        '
        'chkLoadDentalServicesAtStart
        '
        Me.chkLoadDentalServicesAtStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLoadDentalServicesAtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLoadDentalServicesAtStart.Location = New System.Drawing.Point(12, 133)
        Me.chkLoadDentalServicesAtStart.Name = "chkLoadDentalServicesAtStart"
        Me.chkLoadDentalServicesAtStart.Size = New System.Drawing.Size(230, 16)
        Me.chkLoadDentalServicesAtStart.TabIndex = 6
        Me.chkLoadDentalServicesAtStart.Text = "Load Dental Services At Start"
        '
        'chkLoadDiseasesAtStart
        '
        Me.chkLoadDiseasesAtStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLoadDiseasesAtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLoadDiseasesAtStart.Location = New System.Drawing.Point(12, 155)
        Me.chkLoadDiseasesAtStart.Name = "chkLoadDiseasesAtStart"
        Me.chkLoadDiseasesAtStart.Size = New System.Drawing.Size(230, 16)
        Me.chkLoadDiseasesAtStart.TabIndex = 7
        Me.chkLoadDiseasesAtStart.Text = "Load Diseases At Start"
        '
        'chkLoadProceduresAtStart
        '
        Me.chkLoadProceduresAtStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLoadProceduresAtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLoadProceduresAtStart.Location = New System.Drawing.Point(12, 111)
        Me.chkLoadProceduresAtStart.Name = "chkLoadProceduresAtStart"
        Me.chkLoadProceduresAtStart.Size = New System.Drawing.Size(230, 16)
        Me.chkLoadProceduresAtStart.TabIndex = 5
        Me.chkLoadProceduresAtStart.Text = "Load Procedures At Start"
        '
        'chkPromptForExtraChargeRegistration
        '
        Me.chkPromptForExtraChargeRegistration.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPromptForExtraChargeRegistration.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPromptForExtraChargeRegistration.Location = New System.Drawing.Point(255, 29)
        Me.chkPromptForExtraChargeRegistration.Name = "chkPromptForExtraChargeRegistration"
        Me.chkPromptForExtraChargeRegistration.Size = New System.Drawing.Size(343, 16)
        Me.chkPromptForExtraChargeRegistration.TabIndex = 15
        Me.chkPromptForExtraChargeRegistration.Text = "Prompt For Extra Charge Registration"
        '
        'chkForceVisitBillConfirmation
        '
        Me.chkForceVisitBillConfirmation.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkForceVisitBillConfirmation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkForceVisitBillConfirmation.Location = New System.Drawing.Point(255, 11)
        Me.chkForceVisitBillConfirmation.Name = "chkForceVisitBillConfirmation"
        Me.chkForceVisitBillConfirmation.Size = New System.Drawing.Size(343, 16)
        Me.chkForceVisitBillConfirmation.TabIndex = 14
        Me.chkForceVisitBillConfirmation.Text = "Force Visit Bill Confirmation"
        '
        'chkLoadDrugsAtStart
        '
        Me.chkLoadDrugsAtStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLoadDrugsAtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLoadDrugsAtStart.Location = New System.Drawing.Point(12, 72)
        Me.chkLoadDrugsAtStart.Name = "chkLoadDrugsAtStart"
        Me.chkLoadDrugsAtStart.Size = New System.Drawing.Size(230, 16)
        Me.chkLoadDrugsAtStart.TabIndex = 3
        Me.chkLoadDrugsAtStart.Text = "Load Drugs At Start"
        '
        'chkLoadRadiologyExaminationsAtStart
        '
        Me.chkLoadRadiologyExaminationsAtStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLoadRadiologyExaminationsAtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLoadRadiologyExaminationsAtStart.Location = New System.Drawing.Point(12, 50)
        Me.chkLoadRadiologyExaminationsAtStart.Name = "chkLoadRadiologyExaminationsAtStart"
        Me.chkLoadRadiologyExaminationsAtStart.Size = New System.Drawing.Size(230, 16)
        Me.chkLoadRadiologyExaminationsAtStart.TabIndex = 2
        Me.chkLoadRadiologyExaminationsAtStart.Text = "Load Radiology Examinations At Start"
        '
        'chkLoadLabTestsAtStart
        '
        Me.chkLoadLabTestsAtStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLoadLabTestsAtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLoadLabTestsAtStart.Location = New System.Drawing.Point(12, 28)
        Me.chkLoadLabTestsAtStart.Name = "chkLoadLabTestsAtStart"
        Me.chkLoadLabTestsAtStart.Size = New System.Drawing.Size(230, 16)
        Me.chkLoadLabTestsAtStart.TabIndex = 1
        Me.chkLoadLabTestsAtStart.Text = "Load Lab Tests At Start"
        '
        'chkLoadBillCustomersAtStart
        '
        Me.chkLoadBillCustomersAtStart.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkLoadBillCustomersAtStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLoadBillCustomersAtStart.Location = New System.Drawing.Point(12, 6)
        Me.chkLoadBillCustomersAtStart.Name = "chkLoadBillCustomersAtStart"
        Me.chkLoadBillCustomersAtStart.Size = New System.Drawing.Size(230, 16)
        Me.chkLoadBillCustomersAtStart.TabIndex = 0
        Me.chkLoadBillCustomersAtStart.Text = "Load Bill Customers At Start"
        '
        'tpgAutoNumbers
        '
        Me.tpgAutoNumbers.Controls.Add(Me.dgvAutoNumbers)
        Me.tpgAutoNumbers.Location = New System.Drawing.Point(4, 22)
        Me.tpgAutoNumbers.Name = "tpgAutoNumbers"
        Me.tpgAutoNumbers.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgAutoNumbers.Size = New System.Drawing.Size(696, 376)
        Me.tpgAutoNumbers.TabIndex = 1
        Me.tpgAutoNumbers.Text = "Auto Numbers"
        Me.tpgAutoNumbers.UseVisualStyleBackColor = True
        '
        'dgvAutoNumbers
        '
        Me.dgvAutoNumbers.AllowUserToAddRows = False
        Me.dgvAutoNumbers.AllowUserToDeleteRows = False
        Me.dgvAutoNumbers.AllowUserToOrderColumns = True
        Me.dgvAutoNumbers.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAutoNumbers.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvAutoNumbers.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAutoNumbers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAutoNumbers.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAutoNumbers.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colObjectCaption, Me.colAutoColumnName, Me.colAutoColumnLEN, Me.colPaddingCHAR, Me.colPaddingLEN, Me.colSeparatorCHAR, Me.colSeparatorPositions, Me.colStartValue, Me.colIncrement, Me.colAllowJumpTo, Me.colJumpToValue, Me.colObjectName})
        Me.dgvAutoNumbers.EnableHeadersVisualStyles = False
        Me.dgvAutoNumbers.GridColor = System.Drawing.Color.Khaki
        Me.dgvAutoNumbers.Location = New System.Drawing.Point(6, 6)
        Me.dgvAutoNumbers.Name = "dgvAutoNumbers"
        Me.dgvAutoNumbers.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAutoNumbers.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvAutoNumbers.Size = New System.Drawing.Size(684, 367)
        Me.dgvAutoNumbers.TabIndex = 24
        Me.dgvAutoNumbers.Text = "DataGridView1"
        '
        'colObjectCaption
        '
        Me.colObjectCaption.DataPropertyName = "ObjectCaption"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colObjectCaption.DefaultCellStyle = DataGridViewCellStyle2
        Me.colObjectCaption.HeaderText = "Object"
        Me.colObjectCaption.Name = "colObjectCaption"
        Me.colObjectCaption.ReadOnly = True
        '
        'colAutoColumnName
        '
        Me.colAutoColumnName.DataPropertyName = "AutoColumnName"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colAutoColumnName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colAutoColumnName.HeaderText = "Column Name"
        Me.colAutoColumnName.Name = "colAutoColumnName"
        Me.colAutoColumnName.ReadOnly = True
        '
        'colAutoColumnLEN
        '
        Me.colAutoColumnLEN.DataPropertyName = "AutoColumnLEN"
        Me.colAutoColumnLEN.HeaderText = "Auto Column Length"
        Me.colAutoColumnLEN.Name = "colAutoColumnLEN"
        Me.colAutoColumnLEN.Width = 110
        '
        'colPaddingCHAR
        '
        Me.colPaddingCHAR.DataPropertyName = "PaddingCHAR"
        Me.colPaddingCHAR.HeaderText = "Padding Character"
        Me.colPaddingCHAR.MaxInputLength = 1
        Me.colPaddingCHAR.Name = "colPaddingCHAR"
        '
        'colPaddingLEN
        '
        Me.colPaddingLEN.DataPropertyName = "PaddingLEN"
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colPaddingLEN.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPaddingLEN.HeaderText = "Padding Length"
        Me.colPaddingLEN.Name = "colPaddingLEN"
        Me.colPaddingLEN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colSeparatorCHAR
        '
        Me.colSeparatorCHAR.DataPropertyName = "SeparatorCHAR"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colSeparatorCHAR.DefaultCellStyle = DataGridViewCellStyle5
        Me.colSeparatorCHAR.HeaderText = "Separator Character"
        Me.colSeparatorCHAR.MaxInputLength = 1
        Me.colSeparatorCHAR.Name = "colSeparatorCHAR"
        Me.colSeparatorCHAR.ReadOnly = True
        Me.colSeparatorCHAR.Width = 125
        '
        'colSeparatorPositions
        '
        Me.colSeparatorPositions.DataPropertyName = "SeparatorPositions"
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colSeparatorPositions.DefaultCellStyle = DataGridViewCellStyle6
        Me.colSeparatorPositions.HeaderText = "Separator Positions"
        Me.colSeparatorPositions.Name = "colSeparatorPositions"
        Me.colSeparatorPositions.Width = 125
        '
        'colStartValue
        '
        Me.colStartValue.DataPropertyName = "StartValue"
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colStartValue.DefaultCellStyle = DataGridViewCellStyle7
        Me.colStartValue.HeaderText = "Start Value"
        Me.colStartValue.Name = "colStartValue"
        Me.colStartValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colStartValue.Width = 75
        '
        'colIncrement
        '
        Me.colIncrement.DataPropertyName = "Increment"
        Me.colIncrement.HeaderText = "Increment"
        Me.colIncrement.Name = "colIncrement"
        Me.colIncrement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.colIncrement.Width = 75
        '
        'colAllowJumpTo
        '
        Me.colAllowJumpTo.DataPropertyName = "AllowJumpTo"
        Me.colAllowJumpTo.DefaultCellStyle = DataGridViewCellStyle8
        Me.colAllowJumpTo.HeaderText = "Allow Jump To"
        Me.colAllowJumpTo.Name = "colAllowJumpTo"
        '
        'colJumpToValue
        '
        Me.colJumpToValue.DataPropertyName = "JumpToValue"
        Me.colJumpToValue.HeaderText = "Jump To Value"
        Me.colJumpToValue.Name = "colJumpToValue"
        Me.colJumpToValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'colObjectName
        '
        Me.colObjectName.DataPropertyName = "ObjectName"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colObjectName.DefaultCellStyle = DataGridViewCellStyle9
        Me.colObjectName.HeaderText = "Object Name"
        Me.colObjectName.Name = "colObjectName"
        Me.colObjectName.ReadOnly = True
        Me.colObjectName.Visible = False
        Me.colObjectName.Width = 85
        '
        'tpgAutoNumberControls
        '
        Me.tpgAutoNumberControls.Controls.Add(Me.chkTheatreCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkCardiologyExamCode)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkEyeCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkTestCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkServiceCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkRadiologyExamNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkProcedureCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkOpticalCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkNonMedicalItemCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkDentalCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkMaternityCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkPathologyExamCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkPackageNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkICUCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkExtraChargeItemCodeLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkBedNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkStaffNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkDrugNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkConsumableNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkGRNNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkPurchaseOrderNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkSupplierNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkOrderNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkTransferNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkMainMemberNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkMedicalCardNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkOutwardNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkQuotationNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkRefundNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkInvoiceNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkExtraBillNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkClaimNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkCompanyNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkPolicyNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkInsuranceNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkRoundNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkAdmissionNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkTranNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkIncomeNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkExpenditureNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkReceiptNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkSpecimenNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkVisitNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkAccountNoLocked)
        Me.tpgAutoNumberControls.Controls.Add(Me.chkPatientNoLocked)
        Me.tpgAutoNumberControls.Location = New System.Drawing.Point(4, 22)
        Me.tpgAutoNumberControls.Name = "tpgAutoNumberControls"
        Me.tpgAutoNumberControls.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgAutoNumberControls.Size = New System.Drawing.Size(696, 376)
        Me.tpgAutoNumberControls.TabIndex = 6
        Me.tpgAutoNumberControls.Text = "Auto Number Controls"
        Me.tpgAutoNumberControls.UseVisualStyleBackColor = True
        '
        'chkTheatreCodeLocked
        '
        Me.chkTheatreCodeLocked.AccessibleDescription = ""
        Me.chkTheatreCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTheatreCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTheatreCodeLocked.Location = New System.Drawing.Point(361, 278)
        Me.chkTheatreCodeLocked.Name = "chkTheatreCodeLocked"
        Me.chkTheatreCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkTheatreCodeLocked.TabIndex = 45
        Me.chkTheatreCodeLocked.Text = "Theatre Code"
        '
        'chkCardiologyExamCode
        '
        Me.chkCardiologyExamCode.AccessibleDescription = ""
        Me.chkCardiologyExamCode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCardiologyExamCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkCardiologyExamCode.Location = New System.Drawing.Point(361, 256)
        Me.chkCardiologyExamCode.Name = "chkCardiologyExamCode"
        Me.chkCardiologyExamCode.Size = New System.Drawing.Size(163, 16)
        Me.chkCardiologyExamCode.TabIndex = 44
        Me.chkCardiologyExamCode.Text = "Cardiology Exam Code"
        '
        'chkEyeCodeLocked
        '
        Me.chkEyeCodeLocked.AccessibleDescription = ""
        Me.chkEyeCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkEyeCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkEyeCodeLocked.Location = New System.Drawing.Point(361, 234)
        Me.chkEyeCodeLocked.Name = "chkEyeCodeLocked"
        Me.chkEyeCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkEyeCodeLocked.TabIndex = 43
        Me.chkEyeCodeLocked.Text = "Eye Code Locked "
        '
        'chkTestCodeLocked
        '
        Me.chkTestCodeLocked.AccessibleDescription = ""
        Me.chkTestCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTestCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTestCodeLocked.Location = New System.Drawing.Point(361, 210)
        Me.chkTestCodeLocked.Name = "chkTestCodeLocked"
        Me.chkTestCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkTestCodeLocked.TabIndex = 42
        Me.chkTestCodeLocked.Text = "Test Code Locked"
        '
        'chkServiceCodeLocked
        '
        Me.chkServiceCodeLocked.AccessibleDescription = ""
        Me.chkServiceCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkServiceCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkServiceCodeLocked.Location = New System.Drawing.Point(361, 190)
        Me.chkServiceCodeLocked.Name = "chkServiceCodeLocked"
        Me.chkServiceCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkServiceCodeLocked.TabIndex = 41
        Me.chkServiceCodeLocked.Text = "Service Code  Locked"
        '
        'chkRadiologyExamNoLocked
        '
        Me.chkRadiologyExamNoLocked.AccessibleDescription = ""
        Me.chkRadiologyExamNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRadiologyExamNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkRadiologyExamNoLocked.Location = New System.Drawing.Point(361, 168)
        Me.chkRadiologyExamNoLocked.Name = "chkRadiologyExamNoLocked"
        Me.chkRadiologyExamNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkRadiologyExamNoLocked.TabIndex = 40
        Me.chkRadiologyExamNoLocked.Text = "Radiology Exam No Locked"
        '
        'chkProcedureCodeLocked
        '
        Me.chkProcedureCodeLocked.AccessibleDescription = ""
        Me.chkProcedureCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkProcedureCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkProcedureCodeLocked.Location = New System.Drawing.Point(361, 146)
        Me.chkProcedureCodeLocked.Name = "chkProcedureCodeLocked"
        Me.chkProcedureCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkProcedureCodeLocked.TabIndex = 39
        Me.chkProcedureCodeLocked.Text = "Procedure Code Locked"
        '
        'chkOpticalCodeLocked
        '
        Me.chkOpticalCodeLocked.AccessibleDescription = ""
        Me.chkOpticalCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOpticalCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOpticalCodeLocked.Location = New System.Drawing.Point(361, 124)
        Me.chkOpticalCodeLocked.Name = "chkOpticalCodeLocked"
        Me.chkOpticalCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkOpticalCodeLocked.TabIndex = 38
        Me.chkOpticalCodeLocked.Text = "Optical Code Locked"
        '
        'chkNonMedicalItemCodeLocked
        '
        Me.chkNonMedicalItemCodeLocked.AccessibleDescription = ""
        Me.chkNonMedicalItemCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNonMedicalItemCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNonMedicalItemCodeLocked.Location = New System.Drawing.Point(361, 102)
        Me.chkNonMedicalItemCodeLocked.Name = "chkNonMedicalItemCodeLocked"
        Me.chkNonMedicalItemCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkNonMedicalItemCodeLocked.TabIndex = 37
        Me.chkNonMedicalItemCodeLocked.Text = "Non Medical Item Code"
        '
        'chkDentalCodeLocked
        '
        Me.chkDentalCodeLocked.AccessibleDescription = ""
        Me.chkDentalCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDentalCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkDentalCodeLocked.Location = New System.Drawing.Point(361, 78)
        Me.chkDentalCodeLocked.Name = "chkDentalCodeLocked"
        Me.chkDentalCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkDentalCodeLocked.TabIndex = 36
        Me.chkDentalCodeLocked.Text = "Dental Code Locked"
        '
        'chkMaternityCodeLocked
        '
        Me.chkMaternityCodeLocked.AccessibleDescription = ""
        Me.chkMaternityCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkMaternityCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMaternityCodeLocked.Location = New System.Drawing.Point(361, 58)
        Me.chkMaternityCodeLocked.Name = "chkMaternityCodeLocked"
        Me.chkMaternityCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkMaternityCodeLocked.TabIndex = 35
        Me.chkMaternityCodeLocked.Text = "Maternity Code Locked"
        '
        'chkPathologyExamCodeLocked
        '
        Me.chkPathologyExamCodeLocked.AccessibleDescription = ""
        Me.chkPathologyExamCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPathologyExamCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPathologyExamCodeLocked.Location = New System.Drawing.Point(361, 36)
        Me.chkPathologyExamCodeLocked.Name = "chkPathologyExamCodeLocked"
        Me.chkPathologyExamCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkPathologyExamCodeLocked.TabIndex = 34
        Me.chkPathologyExamCodeLocked.Text = "Pathology Exam Code"
        '
        'chkPackageNoLocked
        '
        Me.chkPackageNoLocked.AccessibleDescription = ""
        Me.chkPackageNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPackageNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPackageNoLocked.Location = New System.Drawing.Point(361, 14)
        Me.chkPackageNoLocked.Name = "chkPackageNoLocked"
        Me.chkPackageNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkPackageNoLocked.TabIndex = 33
        Me.chkPackageNoLocked.Text = "Package No Locked"
        '
        'chkICUCodeLocked
        '
        Me.chkICUCodeLocked.AccessibleDescription = ""
        Me.chkICUCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkICUCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkICUCodeLocked.Location = New System.Drawing.Point(178, 343)
        Me.chkICUCodeLocked.Name = "chkICUCodeLocked"
        Me.chkICUCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkICUCodeLocked.TabIndex = 32
        Me.chkICUCodeLocked.Text = "ICU Code Locked"
        '
        'chkExtraChargeItemCodeLocked
        '
        Me.chkExtraChargeItemCodeLocked.AccessibleDescription = ""
        Me.chkExtraChargeItemCodeLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkExtraChargeItemCodeLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkExtraChargeItemCodeLocked.Location = New System.Drawing.Point(178, 322)
        Me.chkExtraChargeItemCodeLocked.Name = "chkExtraChargeItemCodeLocked"
        Me.chkExtraChargeItemCodeLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkExtraChargeItemCodeLocked.TabIndex = 31
        Me.chkExtraChargeItemCodeLocked.Text = "Extra Charge Item Code Locked"
        '
        'chkBedNoLocked
        '
        Me.chkBedNoLocked.AccessibleDescription = ""
        Me.chkBedNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBedNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkBedNoLocked.Location = New System.Drawing.Point(178, 300)
        Me.chkBedNoLocked.Name = "chkBedNoLocked"
        Me.chkBedNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkBedNoLocked.TabIndex = 29
        Me.chkBedNoLocked.Text = "Bed No Locked"
        '
        'chkStaffNoLocked
        '
        Me.chkStaffNoLocked.AccessibleDescription = ""
        Me.chkStaffNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkStaffNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkStaffNoLocked.Location = New System.Drawing.Point(178, 234)
        Me.chkStaffNoLocked.Name = "chkStaffNoLocked"
        Me.chkStaffNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkStaffNoLocked.TabIndex = 26
        Me.chkStaffNoLocked.Text = "Staff No Locked"
        '
        'chkDrugNoLocked
        '
        Me.chkDrugNoLocked.AccessibleDescription = ""
        Me.chkDrugNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDrugNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkDrugNoLocked.Location = New System.Drawing.Point(178, 256)
        Me.chkDrugNoLocked.Name = "chkDrugNoLocked"
        Me.chkDrugNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkDrugNoLocked.TabIndex = 27
        Me.chkDrugNoLocked.Text = "Drug No Locked"
        '
        'chkConsumableNoLocked
        '
        Me.chkConsumableNoLocked.AccessibleDescription = ""
        Me.chkConsumableNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkConsumableNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkConsumableNoLocked.Location = New System.Drawing.Point(178, 278)
        Me.chkConsumableNoLocked.Name = "chkConsumableNoLocked"
        Me.chkConsumableNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkConsumableNoLocked.TabIndex = 28
        Me.chkConsumableNoLocked.Text = "Consumable No Locked"
        '
        'chkGRNNoLocked
        '
        Me.chkGRNNoLocked.AccessibleDescription = ""
        Me.chkGRNNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkGRNNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkGRNNoLocked.Location = New System.Drawing.Point(178, 168)
        Me.chkGRNNoLocked.Name = "chkGRNNoLocked"
        Me.chkGRNNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkGRNNoLocked.TabIndex = 23
        Me.chkGRNNoLocked.Text = "GRN No Locked"
        '
        'chkPurchaseOrderNoLocked
        '
        Me.chkPurchaseOrderNoLocked.AccessibleDescription = ""
        Me.chkPurchaseOrderNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPurchaseOrderNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPurchaseOrderNoLocked.Location = New System.Drawing.Point(178, 146)
        Me.chkPurchaseOrderNoLocked.Name = "chkPurchaseOrderNoLocked"
        Me.chkPurchaseOrderNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkPurchaseOrderNoLocked.TabIndex = 22
        Me.chkPurchaseOrderNoLocked.Text = "Purchase Order No Locked"
        '
        'chkSupplierNoLocked
        '
        Me.chkSupplierNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSupplierNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSupplierNoLocked.Location = New System.Drawing.Point(178, 58)
        Me.chkSupplierNoLocked.Name = "chkSupplierNoLocked"
        Me.chkSupplierNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkSupplierNoLocked.TabIndex = 18
        Me.chkSupplierNoLocked.Text = "Supplier No Locked"
        '
        'chkOrderNoLocked
        '
        Me.chkOrderNoLocked.AccessibleDescription = ""
        Me.chkOrderNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOrderNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOrderNoLocked.Location = New System.Drawing.Point(178, 190)
        Me.chkOrderNoLocked.Name = "chkOrderNoLocked"
        Me.chkOrderNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkOrderNoLocked.TabIndex = 24
        Me.chkOrderNoLocked.Text = "Order No Locked"
        '
        'chkTransferNoLocked
        '
        Me.chkTransferNoLocked.AccessibleDescription = ""
        Me.chkTransferNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTransferNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTransferNoLocked.Location = New System.Drawing.Point(178, 212)
        Me.chkTransferNoLocked.Name = "chkTransferNoLocked"
        Me.chkTransferNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkTransferNoLocked.TabIndex = 25
        Me.chkTransferNoLocked.Text = "Transfer No Locked"
        '
        'chkMainMemberNoLocked
        '
        Me.chkMainMemberNoLocked.AccessibleDescription = ""
        Me.chkMainMemberNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkMainMemberNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMainMemberNoLocked.Location = New System.Drawing.Point(178, 124)
        Me.chkMainMemberNoLocked.Name = "chkMainMemberNoLocked"
        Me.chkMainMemberNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkMainMemberNoLocked.TabIndex = 21
        Me.chkMainMemberNoLocked.Text = "Main Member No Locked"
        '
        'chkMedicalCardNoLocked
        '
        Me.chkMedicalCardNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkMedicalCardNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMedicalCardNoLocked.Location = New System.Drawing.Point(178, 102)
        Me.chkMedicalCardNoLocked.Name = "chkMedicalCardNoLocked"
        Me.chkMedicalCardNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkMedicalCardNoLocked.TabIndex = 20
        Me.chkMedicalCardNoLocked.Text = "Medical Card No Locked"
        '
        'chkOutwardNoLocked
        '
        Me.chkOutwardNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkOutwardNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkOutwardNoLocked.Location = New System.Drawing.Point(14, 320)
        Me.chkOutwardNoLocked.Name = "chkOutwardNoLocked"
        Me.chkOutwardNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkOutwardNoLocked.TabIndex = 14
        Me.chkOutwardNoLocked.Text = "Outward No Locked"
        '
        'chkQuotationNoLocked
        '
        Me.chkQuotationNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkQuotationNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkQuotationNoLocked.Location = New System.Drawing.Point(14, 144)
        Me.chkQuotationNoLocked.Name = "chkQuotationNoLocked"
        Me.chkQuotationNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkQuotationNoLocked.TabIndex = 6
        Me.chkQuotationNoLocked.Text = "Quotation No Locked"
        '
        'chkRefundNoLocked
        '
        Me.chkRefundNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRefundNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkRefundNoLocked.Location = New System.Drawing.Point(14, 166)
        Me.chkRefundNoLocked.Name = "chkRefundNoLocked"
        Me.chkRefundNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkRefundNoLocked.TabIndex = 7
        Me.chkRefundNoLocked.Text = "Refund No Locked"
        '
        'chkInvoiceNoLocked
        '
        Me.chkInvoiceNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkInvoiceNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkInvoiceNoLocked.Location = New System.Drawing.Point(14, 298)
        Me.chkInvoiceNoLocked.Name = "chkInvoiceNoLocked"
        Me.chkInvoiceNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkInvoiceNoLocked.TabIndex = 13
        Me.chkInvoiceNoLocked.Text = "Invoice No Locked"
        '
        'chkExtraBillNoLocked
        '
        Me.chkExtraBillNoLocked.AccessibleDescription = ""
        Me.chkExtraBillNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkExtraBillNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkExtraBillNoLocked.Location = New System.Drawing.Point(14, 122)
        Me.chkExtraBillNoLocked.Name = "chkExtraBillNoLocked"
        Me.chkExtraBillNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkExtraBillNoLocked.TabIndex = 5
        Me.chkExtraBillNoLocked.Text = "Extra Bill No Locked"
        '
        'chkClaimNoLocked
        '
        Me.chkClaimNoLocked.AccessibleDescription = ""
        Me.chkClaimNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkClaimNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkClaimNoLocked.Location = New System.Drawing.Point(178, 80)
        Me.chkClaimNoLocked.Name = "chkClaimNoLocked"
        Me.chkClaimNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkClaimNoLocked.TabIndex = 19
        Me.chkClaimNoLocked.Text = "Claim No Locked"
        '
        'chkCompanyNoLocked
        '
        Me.chkCompanyNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkCompanyNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkCompanyNoLocked.Location = New System.Drawing.Point(178, 36)
        Me.chkCompanyNoLocked.Name = "chkCompanyNoLocked"
        Me.chkCompanyNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkCompanyNoLocked.TabIndex = 17
        Me.chkCompanyNoLocked.Text = "Company No Locked"
        '
        'chkPolicyNoLocked
        '
        Me.chkPolicyNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPolicyNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPolicyNoLocked.Location = New System.Drawing.Point(178, 14)
        Me.chkPolicyNoLocked.Name = "chkPolicyNoLocked"
        Me.chkPolicyNoLocked.Size = New System.Drawing.Size(163, 16)
        Me.chkPolicyNoLocked.TabIndex = 16
        Me.chkPolicyNoLocked.Text = "Policy No Locked"
        '
        'chkInsuranceNoLocked
        '
        Me.chkInsuranceNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkInsuranceNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkInsuranceNoLocked.Location = New System.Drawing.Point(14, 343)
        Me.chkInsuranceNoLocked.Name = "chkInsuranceNoLocked"
        Me.chkInsuranceNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkInsuranceNoLocked.TabIndex = 15
        Me.chkInsuranceNoLocked.Text = "Insurance No Locked"
        '
        'chkRoundNoLocked
        '
        Me.chkRoundNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRoundNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkRoundNoLocked.Location = New System.Drawing.Point(14, 276)
        Me.chkRoundNoLocked.Name = "chkRoundNoLocked"
        Me.chkRoundNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkRoundNoLocked.TabIndex = 12
        Me.chkRoundNoLocked.Text = "Round No Locked"
        '
        'chkAdmissionNoLocked
        '
        Me.chkAdmissionNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAdmissionNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAdmissionNoLocked.Location = New System.Drawing.Point(14, 100)
        Me.chkAdmissionNoLocked.Name = "chkAdmissionNoLocked"
        Me.chkAdmissionNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkAdmissionNoLocked.TabIndex = 4
        Me.chkAdmissionNoLocked.Text = "Admission No Locked"
        '
        'chkTranNoLocked
        '
        Me.chkTranNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkTranNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTranNoLocked.Location = New System.Drawing.Point(14, 34)
        Me.chkTranNoLocked.Name = "chkTranNoLocked"
        Me.chkTranNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkTranNoLocked.TabIndex = 1
        Me.chkTranNoLocked.Text = "Transaction No Locked"
        '
        'chkIncomeNoLocked
        '
        Me.chkIncomeNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncomeNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIncomeNoLocked.Location = New System.Drawing.Point(14, 254)
        Me.chkIncomeNoLocked.Name = "chkIncomeNoLocked"
        Me.chkIncomeNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkIncomeNoLocked.TabIndex = 11
        Me.chkIncomeNoLocked.Text = "Income No Locked"
        '
        'chkExpenditureNoLocked
        '
        Me.chkExpenditureNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkExpenditureNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkExpenditureNoLocked.Location = New System.Drawing.Point(14, 232)
        Me.chkExpenditureNoLocked.Name = "chkExpenditureNoLocked"
        Me.chkExpenditureNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkExpenditureNoLocked.TabIndex = 10
        Me.chkExpenditureNoLocked.Text = "Expenditure No Locked"
        '
        'chkReceiptNoLocked
        '
        Me.chkReceiptNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkReceiptNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkReceiptNoLocked.Location = New System.Drawing.Point(14, 12)
        Me.chkReceiptNoLocked.Name = "chkReceiptNoLocked"
        Me.chkReceiptNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkReceiptNoLocked.TabIndex = 0
        Me.chkReceiptNoLocked.Text = "Receipt No Locked"
        '
        'chkSpecimenNoLocked
        '
        Me.chkSpecimenNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSpecimenNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSpecimenNoLocked.Location = New System.Drawing.Point(14, 210)
        Me.chkSpecimenNoLocked.Name = "chkSpecimenNoLocked"
        Me.chkSpecimenNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkSpecimenNoLocked.TabIndex = 9
        Me.chkSpecimenNoLocked.Text = "Specimen No Locked"
        '
        'chkVisitNoLocked
        '
        Me.chkVisitNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkVisitNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkVisitNoLocked.Location = New System.Drawing.Point(14, 188)
        Me.chkVisitNoLocked.Name = "chkVisitNoLocked"
        Me.chkVisitNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkVisitNoLocked.TabIndex = 8
        Me.chkVisitNoLocked.Text = "Visit No Locked"
        '
        'chkAccountNoLocked
        '
        Me.chkAccountNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkAccountNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkAccountNoLocked.Location = New System.Drawing.Point(14, 78)
        Me.chkAccountNoLocked.Name = "chkAccountNoLocked"
        Me.chkAccountNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkAccountNoLocked.TabIndex = 3
        Me.chkAccountNoLocked.Text = "Account No Locked"
        '
        'chkPatientNoLocked
        '
        Me.chkPatientNoLocked.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkPatientNoLocked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkPatientNoLocked.Location = New System.Drawing.Point(14, 56)
        Me.chkPatientNoLocked.Name = "chkPatientNoLocked"
        Me.chkPatientNoLocked.Size = New System.Drawing.Size(148, 16)
        Me.chkPatientNoLocked.TabIndex = 2
        Me.chkPatientNoLocked.Text = "Patient No Locked"
        '
        'tpgProductOwnerInfo
        '
        Me.tpgProductOwnerInfo.Controls.Add(Me.stbFacilityNo)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblFacilityNo)
        Me.tpgProductOwnerInfo.Controls.Add(Me.nudTextLeftMargin)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblTextLeftMargin)
        Me.tpgProductOwnerInfo.Controls.Add(Me.nudLogoLeftMargin)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblLogoLeftMargin)
        Me.tpgProductOwnerInfo.Controls.Add(Me.nudTextTopMargin)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblTextTopMargin)
        Me.tpgProductOwnerInfo.Controls.Add(Me.nudLogoTopMargin)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblLogoTopMargin)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblPrintHeaderAlignmentID)
        Me.tpgProductOwnerInfo.Controls.Add(Me.cboPrintHeaderAlignmentID)
        Me.tpgProductOwnerInfo.Controls.Add(Me.btnClearAlternatePhoto)
        Me.tpgProductOwnerInfo.Controls.Add(Me.btnLoadAlternatePhoto)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblAlternatePhoto)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblAlternateEmail)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblAlternatePhone)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblVATNo)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblTINNo)
        Me.tpgProductOwnerInfo.Controls.Add(Me.btnClearPhoto)
        Me.tpgProductOwnerInfo.Controls.Add(Me.btnLoadPhoto)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblProductOwner)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblAddress)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblPhone)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblFax)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblEmail)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblWebsite)
        Me.tpgProductOwnerInfo.Controls.Add(Me.lblPhoto)
        Me.tpgProductOwnerInfo.Controls.Add(Me.spbAlternatePhoto)
        Me.tpgProductOwnerInfo.Controls.Add(Me.stbAlternateEmail)
        Me.tpgProductOwnerInfo.Controls.Add(Me.stbAlternatePhone)
        Me.tpgProductOwnerInfo.Controls.Add(Me.stbVATNo)
        Me.tpgProductOwnerInfo.Controls.Add(Me.stbTINNo)
        Me.tpgProductOwnerInfo.Controls.Add(Me.stbProductOwner)
        Me.tpgProductOwnerInfo.Controls.Add(Me.stbAddress)
        Me.tpgProductOwnerInfo.Controls.Add(Me.stbPhone)
        Me.tpgProductOwnerInfo.Controls.Add(Me.stbFax)
        Me.tpgProductOwnerInfo.Controls.Add(Me.stbEmail)
        Me.tpgProductOwnerInfo.Controls.Add(Me.stbWebsite)
        Me.tpgProductOwnerInfo.Controls.Add(Me.spbPhoto)
        Me.tpgProductOwnerInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpgProductOwnerInfo.Name = "tpgProductOwnerInfo"
        Me.tpgProductOwnerInfo.Size = New System.Drawing.Size(696, 376)
        Me.tpgProductOwnerInfo.TabIndex = 2
        Me.tpgProductOwnerInfo.Text = "Product Owner Info"
        Me.tpgProductOwnerInfo.UseVisualStyleBackColor = True
        '
        'stbFacilityNo
        '
        Me.stbFacilityNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFacilityNo.CapitalizeFirstLetter = False
        Me.stbFacilityNo.Enabled = False
        Me.stbFacilityNo.EntryErrorMSG = ""
        Me.stbFacilityNo.Location = New System.Drawing.Point(410, 16)
        Me.stbFacilityNo.MaxLength = 100
        Me.stbFacilityNo.Name = "stbFacilityNo"
        Me.stbFacilityNo.RegularExpression = ""
        Me.stbFacilityNo.Size = New System.Drawing.Size(155, 20)
        Me.stbFacilityNo.TabIndex = 70
        '
        'lblFacilityNo
        '
        Me.lblFacilityNo.Location = New System.Drawing.Point(335, 18)
        Me.lblFacilityNo.Name = "lblFacilityNo"
        Me.lblFacilityNo.Size = New System.Drawing.Size(69, 20)
        Me.lblFacilityNo.TabIndex = 69
        Me.lblFacilityNo.Text = "Facility No "
        '
        'nudTextLeftMargin
        '
        Me.nudTextLeftMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTextLeftMargin.Location = New System.Drawing.Point(525, 286)
        Me.nudTextLeftMargin.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudTextLeftMargin.Name = "nudTextLeftMargin"
        Me.nudTextLeftMargin.Size = New System.Drawing.Size(40, 20)
        Me.nudTextLeftMargin.TabIndex = 68
        Me.nudTextLeftMargin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblTextLeftMargin
        '
        Me.lblTextLeftMargin.Location = New System.Drawing.Point(410, 288)
        Me.lblTextLeftMargin.Name = "lblTextLeftMargin"
        Me.lblTextLeftMargin.Size = New System.Drawing.Size(109, 20)
        Me.lblTextLeftMargin.TabIndex = 67
        Me.lblTextLeftMargin.Text = "Text Left Margin"
        '
        'nudLogoLeftMargin
        '
        Me.nudLogoLeftMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudLogoLeftMargin.Location = New System.Drawing.Point(525, 265)
        Me.nudLogoLeftMargin.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.nudLogoLeftMargin.Name = "nudLogoLeftMargin"
        Me.nudLogoLeftMargin.Size = New System.Drawing.Size(40, 20)
        Me.nudLogoLeftMargin.TabIndex = 66
        Me.nudLogoLeftMargin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblLogoLeftMargin
        '
        Me.lblLogoLeftMargin.Location = New System.Drawing.Point(410, 267)
        Me.lblLogoLeftMargin.Name = "lblLogoLeftMargin"
        Me.lblLogoLeftMargin.Size = New System.Drawing.Size(109, 20)
        Me.lblLogoLeftMargin.TabIndex = 65
        Me.lblLogoLeftMargin.Text = "Logo Left Margin"
        '
        'nudTextTopMargin
        '
        Me.nudTextTopMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudTextTopMargin.Location = New System.Drawing.Point(136, 328)
        Me.nudTextTopMargin.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nudTextTopMargin.Name = "nudTextTopMargin"
        Me.nudTextTopMargin.Size = New System.Drawing.Size(40, 20)
        Me.nudTextTopMargin.TabIndex = 60
        Me.nudTextTopMargin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblTextTopMargin
        '
        Me.lblTextTopMargin.Location = New System.Drawing.Point(9, 330)
        Me.lblTextTopMargin.Name = "lblTextTopMargin"
        Me.lblTextTopMargin.Size = New System.Drawing.Size(121, 20)
        Me.lblTextTopMargin.TabIndex = 59
        Me.lblTextTopMargin.Text = "Text Top Margin"
        '
        'nudLogoTopMargin
        '
        Me.nudLogoTopMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nudLogoTopMargin.Location = New System.Drawing.Point(136, 307)
        Me.nudLogoTopMargin.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.nudLogoTopMargin.Name = "nudLogoTopMargin"
        Me.nudLogoTopMargin.Size = New System.Drawing.Size(40, 20)
        Me.nudLogoTopMargin.TabIndex = 58
        Me.nudLogoTopMargin.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblLogoTopMargin
        '
        Me.lblLogoTopMargin.Location = New System.Drawing.Point(9, 309)
        Me.lblLogoTopMargin.Name = "lblLogoTopMargin"
        Me.lblLogoTopMargin.Size = New System.Drawing.Size(121, 20)
        Me.lblLogoTopMargin.TabIndex = 57
        Me.lblLogoTopMargin.Text = "Logo Top Margin"
        '
        'lblPrintHeaderAlignmentID
        '
        Me.lblPrintHeaderAlignmentID.Location = New System.Drawing.Point(9, 283)
        Me.lblPrintHeaderAlignmentID.Name = "lblPrintHeaderAlignmentID"
        Me.lblPrintHeaderAlignmentID.Size = New System.Drawing.Size(121, 20)
        Me.lblPrintHeaderAlignmentID.TabIndex = 20
        Me.lblPrintHeaderAlignmentID.Text = "Print Header Alignment"
        '
        'cboPrintHeaderAlignmentID
        '
        Me.cboPrintHeaderAlignmentID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPrintHeaderAlignmentID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPrintHeaderAlignmentID.Location = New System.Drawing.Point(136, 283)
        Me.cboPrintHeaderAlignmentID.Name = "cboPrintHeaderAlignmentID"
        Me.cboPrintHeaderAlignmentID.Size = New System.Drawing.Size(193, 21)
        Me.cboPrintHeaderAlignmentID.TabIndex = 21
        '
        'btnClearAlternatePhoto
        '
        Me.btnClearAlternatePhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClearAlternatePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearAlternatePhoto.Location = New System.Drawing.Point(571, 239)
        Me.btnClearAlternatePhoto.Name = "btnClearAlternatePhoto"
        Me.btnClearAlternatePhoto.Size = New System.Drawing.Size(59, 23)
        Me.btnClearAlternatePhoto.TabIndex = 27
        Me.btnClearAlternatePhoto.Text = "Clear"
        Me.btnClearAlternatePhoto.UseVisualStyleBackColor = True
        '
        'btnLoadAlternatePhoto
        '
        Me.btnLoadAlternatePhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadAlternatePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadAlternatePhoto.Location = New System.Drawing.Point(571, 153)
        Me.btnLoadAlternatePhoto.Name = "btnLoadAlternatePhoto"
        Me.btnLoadAlternatePhoto.Size = New System.Drawing.Size(59, 23)
        Me.btnLoadAlternatePhoto.TabIndex = 26
        Me.btnLoadAlternatePhoto.Text = "Load..."
        Me.btnLoadAlternatePhoto.UseVisualStyleBackColor = True
        '
        'lblAlternatePhoto
        '
        Me.lblAlternatePhoto.Location = New System.Drawing.Point(336, 155)
        Me.lblAlternatePhoto.Name = "lblAlternatePhoto"
        Me.lblAlternatePhoto.Size = New System.Drawing.Size(68, 62)
        Me.lblAlternatePhoto.TabIndex = 25
        Me.lblAlternatePhoto.Text = "Alternate Photo"
        Me.lblAlternatePhoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAlternateEmail
        '
        Me.lblAlternateEmail.Location = New System.Drawing.Point(9, 197)
        Me.lblAlternateEmail.Name = "lblAlternateEmail"
        Me.lblAlternateEmail.Size = New System.Drawing.Size(121, 20)
        Me.lblAlternateEmail.TabIndex = 12
        Me.lblAlternateEmail.Text = "Alternate Email"
        '
        'lblAlternatePhone
        '
        Me.lblAlternatePhone.Location = New System.Drawing.Point(9, 134)
        Me.lblAlternatePhone.Name = "lblAlternatePhone"
        Me.lblAlternatePhone.Size = New System.Drawing.Size(121, 20)
        Me.lblAlternatePhone.TabIndex = 6
        Me.lblAlternatePhone.Text = "Alternate Phone"
        '
        'lblVATNo
        '
        Me.lblVATNo.Location = New System.Drawing.Point(9, 260)
        Me.lblVATNo.Name = "lblVATNo"
        Me.lblVATNo.Size = New System.Drawing.Size(121, 20)
        Me.lblVATNo.TabIndex = 18
        Me.lblVATNo.Text = "VAT Number"
        '
        'lblTINNo
        '
        Me.lblTINNo.Location = New System.Drawing.Point(9, 239)
        Me.lblTINNo.Name = "lblTINNo"
        Me.lblTINNo.Size = New System.Drawing.Size(121, 20)
        Me.lblTINNo.TabIndex = 16
        Me.lblTINNo.Text = "TIN Number"
        '
        'btnClearPhoto
        '
        Me.btnClearPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClearPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearPhoto.Location = New System.Drawing.Point(571, 125)
        Me.btnClearPhoto.Name = "btnClearPhoto"
        Me.btnClearPhoto.Size = New System.Drawing.Size(59, 23)
        Me.btnClearPhoto.TabIndex = 24
        Me.btnClearPhoto.Text = "Clear"
        Me.btnClearPhoto.UseVisualStyleBackColor = True
        '
        'btnLoadPhoto
        '
        Me.btnLoadPhoto.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPhoto.Location = New System.Drawing.Point(571, 38)
        Me.btnLoadPhoto.Name = "btnLoadPhoto"
        Me.btnLoadPhoto.Size = New System.Drawing.Size(59, 23)
        Me.btnLoadPhoto.TabIndex = 23
        Me.btnLoadPhoto.Text = "Load..."
        Me.btnLoadPhoto.UseVisualStyleBackColor = True
        '
        'lblProductOwner
        '
        Me.lblProductOwner.Location = New System.Drawing.Point(9, 27)
        Me.lblProductOwner.Name = "lblProductOwner"
        Me.lblProductOwner.Size = New System.Drawing.Size(121, 20)
        Me.lblProductOwner.TabIndex = 0
        Me.lblProductOwner.Text = "Product Owner"
        '
        'lblAddress
        '
        Me.lblAddress.Location = New System.Drawing.Point(9, 82)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(121, 20)
        Me.lblAddress.TabIndex = 2
        Me.lblAddress.Text = "Address"
        '
        'lblPhone
        '
        Me.lblPhone.Location = New System.Drawing.Point(9, 113)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(121, 20)
        Me.lblPhone.TabIndex = 4
        Me.lblPhone.Text = "Phone"
        '
        'lblFax
        '
        Me.lblFax.Location = New System.Drawing.Point(9, 155)
        Me.lblFax.Name = "lblFax"
        Me.lblFax.Size = New System.Drawing.Size(121, 20)
        Me.lblFax.TabIndex = 8
        Me.lblFax.Text = "Fax"
        '
        'lblEmail
        '
        Me.lblEmail.Location = New System.Drawing.Point(9, 176)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(121, 20)
        Me.lblEmail.TabIndex = 10
        Me.lblEmail.Text = "Email"
        '
        'lblWebsite
        '
        Me.lblWebsite.Location = New System.Drawing.Point(9, 218)
        Me.lblWebsite.Name = "lblWebsite"
        Me.lblWebsite.Size = New System.Drawing.Size(121, 20)
        Me.lblWebsite.TabIndex = 14
        Me.lblWebsite.Text = "Website"
        '
        'lblPhoto
        '
        Me.lblPhoto.Location = New System.Drawing.Point(338, 39)
        Me.lblPhoto.Name = "lblPhoto"
        Me.lblPhoto.Size = New System.Drawing.Size(66, 24)
        Me.lblPhoto.TabIndex = 22
        Me.lblPhoto.Text = "Logo"
        Me.lblPhoto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'spbAlternatePhoto
        '
        Me.spbAlternatePhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbAlternatePhoto.ImageSizeLimit = CType(500000, Long)
        Me.spbAlternatePhoto.Location = New System.Drawing.Point(410, 152)
        Me.spbAlternatePhoto.Name = "spbAlternatePhoto"
        Me.spbAlternatePhoto.ReadOnly = False
        Me.spbAlternatePhoto.Size = New System.Drawing.Size(155, 110)
        Me.spbAlternatePhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbAlternatePhoto.TabIndex = 56
        Me.spbAlternatePhoto.TabStop = False
        '
        'stbAlternateEmail
        '
        Me.stbAlternateEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAlternateEmail.CapitalizeFirstLetter = False
        Me.stbAlternateEmail.EntryErrorMSG = "Invalid e-mail address"
        Me.stbAlternateEmail.Location = New System.Drawing.Point(136, 197)
        Me.stbAlternateEmail.MaxLength = 100
        Me.stbAlternateEmail.Name = "stbAlternateEmail"
        Me.stbAlternateEmail.RegularExpression = ""
        Me.stbAlternateEmail.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Email
        Me.stbAlternateEmail.Size = New System.Drawing.Size(193, 20)
        Me.stbAlternateEmail.TabIndex = 13
        '
        'stbAlternatePhone
        '
        Me.stbAlternatePhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAlternatePhone.CapitalizeFirstLetter = False
        Me.stbAlternatePhone.EntryErrorMSG = ""
        Me.stbAlternatePhone.Location = New System.Drawing.Point(136, 134)
        Me.stbAlternatePhone.MaxLength = 100
        Me.stbAlternatePhone.Name = "stbAlternatePhone"
        Me.stbAlternatePhone.RegularExpression = ""
        Me.stbAlternatePhone.Size = New System.Drawing.Size(193, 20)
        Me.stbAlternatePhone.TabIndex = 7
        '
        'stbVATNo
        '
        Me.stbVATNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVATNo.CapitalizeFirstLetter = False
        Me.stbVATNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVATNo.EntryErrorMSG = ""
        Me.stbVATNo.Location = New System.Drawing.Point(136, 260)
        Me.stbVATNo.MaxLength = 100
        Me.stbVATNo.Name = "stbVATNo"
        Me.stbVATNo.RegularExpression = ""
        Me.stbVATNo.Size = New System.Drawing.Size(193, 20)
        Me.stbVATNo.TabIndex = 19
        '
        'stbTINNo
        '
        Me.stbTINNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTINNo.CapitalizeFirstLetter = False
        Me.stbTINNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbTINNo.EntryErrorMSG = ""
        Me.stbTINNo.Location = New System.Drawing.Point(136, 239)
        Me.stbTINNo.MaxLength = 100
        Me.stbTINNo.Name = "stbTINNo"
        Me.stbTINNo.RegularExpression = ""
        Me.stbTINNo.Size = New System.Drawing.Size(193, 20)
        Me.stbTINNo.TabIndex = 17
        '
        'stbProductOwner
        '
        Me.stbProductOwner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbProductOwner.CapitalizeFirstLetter = False
        Me.stbProductOwner.EntryErrorMSG = ""
        Me.stbProductOwner.Location = New System.Drawing.Point(136, 14)
        Me.stbProductOwner.MaxLength = 200
        Me.stbProductOwner.Multiline = True
        Me.stbProductOwner.Name = "stbProductOwner"
        Me.stbProductOwner.ReadOnly = True
        Me.stbProductOwner.RegularExpression = ""
        Me.stbProductOwner.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbProductOwner.Size = New System.Drawing.Size(193, 49)
        Me.stbProductOwner.TabIndex = 1
        '
        'stbAddress
        '
        Me.stbAddress.AcceptsReturn = True
        Me.stbAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAddress.CapitalizeFirstLetter = True
        Me.stbAddress.EntryErrorMSG = ""
        Me.stbAddress.Location = New System.Drawing.Point(136, 64)
        Me.stbAddress.MaxLength = 200
        Me.stbAddress.Multiline = True
        Me.stbAddress.Name = "stbAddress"
        Me.stbAddress.RegularExpression = ""
        Me.stbAddress.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAddress.Size = New System.Drawing.Size(193, 48)
        Me.stbAddress.TabIndex = 3
        '
        'stbPhone
        '
        Me.stbPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPhone.CapitalizeFirstLetter = False
        Me.stbPhone.EntryErrorMSG = ""
        Me.stbPhone.Location = New System.Drawing.Point(136, 113)
        Me.stbPhone.MaxLength = 100
        Me.stbPhone.Name = "stbPhone"
        Me.stbPhone.RegularExpression = ""
        Me.stbPhone.Size = New System.Drawing.Size(193, 20)
        Me.stbPhone.TabIndex = 5
        '
        'stbFax
        '
        Me.stbFax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFax.CapitalizeFirstLetter = False
        Me.stbFax.EntryErrorMSG = ""
        Me.stbFax.Location = New System.Drawing.Point(136, 155)
        Me.stbFax.MaxLength = 100
        Me.stbFax.Name = "stbFax"
        Me.stbFax.RegularExpression = ""
        Me.stbFax.Size = New System.Drawing.Size(193, 20)
        Me.stbFax.TabIndex = 9
        '
        'stbEmail
        '
        Me.stbEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEmail.CapitalizeFirstLetter = False
        Me.stbEmail.EntryErrorMSG = "Invalid e-mail address"
        Me.stbEmail.Location = New System.Drawing.Point(136, 176)
        Me.stbEmail.MaxLength = 100
        Me.stbEmail.Name = "stbEmail"
        Me.stbEmail.RegularExpression = ""
        Me.stbEmail.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Email
        Me.stbEmail.Size = New System.Drawing.Size(193, 20)
        Me.stbEmail.TabIndex = 11
        '
        'stbWebsite
        '
        Me.stbWebsite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbWebsite.CapitalizeFirstLetter = False
        Me.stbWebsite.EntryErrorMSG = "Invalid website address"
        Me.stbWebsite.Location = New System.Drawing.Point(136, 218)
        Me.stbWebsite.MaxLength = 100
        Me.stbWebsite.Name = "stbWebsite"
        Me.stbWebsite.RegularExpression = ""
        Me.stbWebsite.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Website
        Me.stbWebsite.Size = New System.Drawing.Size(193, 20)
        Me.stbWebsite.TabIndex = 15
        '
        'spbPhoto
        '
        Me.spbPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbPhoto.ImageSizeLimit = CType(500000, Long)
        Me.spbPhoto.Location = New System.Drawing.Point(410, 38)
        Me.spbPhoto.Name = "spbPhoto"
        Me.spbPhoto.ReadOnly = False
        Me.spbPhoto.Size = New System.Drawing.Size(155, 110)
        Me.spbPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbPhoto.TabIndex = 48
        Me.spbPhoto.TabStop = False
        '
        'tpgOtherVariousOptions
        '
        Me.tpgOtherVariousOptions.Controls.Add(Me.dgvOptions)
        Me.tpgOtherVariousOptions.Location = New System.Drawing.Point(4, 22)
        Me.tpgOtherVariousOptions.Name = "tpgOtherVariousOptions"
        Me.tpgOtherVariousOptions.Size = New System.Drawing.Size(696, 376)
        Me.tpgOtherVariousOptions.TabIndex = 3
        Me.tpgOtherVariousOptions.Text = "Other Various Options"
        Me.tpgOtherVariousOptions.UseVisualStyleBackColor = True
        '
        'dgvOptions
        '
        Me.dgvOptions.AllowUserToAddRows = False
        Me.dgvOptions.AllowUserToDeleteRows = False
        Me.dgvOptions.AllowUserToOrderColumns = True
        Me.dgvOptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOptions.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOptions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvOptions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colOptionName, Me.colOptionValue, Me.colDataTypeID, Me.colMaxLength, Me.colOptionsSaved})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOptions.DefaultCellStyle = DataGridViewCellStyle16
        Me.dgvOptions.EnableHeadersVisualStyles = False
        Me.dgvOptions.GridColor = System.Drawing.Color.Khaki
        Me.dgvOptions.Location = New System.Drawing.Point(3, 3)
        Me.dgvOptions.Name = "dgvOptions"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOptions.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvOptions.Size = New System.Drawing.Size(690, 375)
        Me.dgvOptions.TabIndex = 2
        Me.dgvOptions.Text = "DataGridView1"
        '
        'colOptionName
        '
        Me.colOptionName.DataPropertyName = "OptionName"
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colOptionName.DefaultCellStyle = DataGridViewCellStyle12
        Me.colOptionName.HeaderText = "Option Name"
        Me.colOptionName.MaxInputLength = 40
        Me.colOptionName.Name = "colOptionName"
        Me.colOptionName.ReadOnly = True
        Me.colOptionName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colOptionName.Width = 150
        '
        'colOptionValue
        '
        Me.colOptionValue.DataPropertyName = "OptionValue"
        Me.colOptionValue.HeaderText = "Option Value"
        Me.colOptionValue.MaxInputLength = 200
        Me.colOptionValue.Name = "colOptionValue"
        Me.colOptionValue.Width = 120
        '
        'colDataTypeID
        '
        Me.colDataTypeID.DataPropertyName = "DataTypeID"
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colDataTypeID.DefaultCellStyle = DataGridViewCellStyle13
        Me.colDataTypeID.DisplayStyleForCurrentCellOnly = True
        Me.colDataTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDataTypeID.HeaderText = "Data Type"
        Me.colDataTypeID.Name = "colDataTypeID"
        Me.colDataTypeID.ReadOnly = True
        Me.colDataTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDataTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colMaxLength
        '
        Me.colMaxLength.DataPropertyName = "MaxLength"
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colMaxLength.DefaultCellStyle = DataGridViewCellStyle14
        Me.colMaxLength.HeaderText = "Max Length"
        Me.colMaxLength.Name = "colMaxLength"
        Me.colMaxLength.ReadOnly = True
        '
        'colOptionsSaved
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle15.NullValue = False
        Me.colOptionsSaved.DefaultCellStyle = DataGridViewCellStyle15
        Me.colOptionsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colOptionsSaved.HeaderText = "Saved"
        Me.colOptionsSaved.Name = "colOptionsSaved"
        Me.colOptionsSaved.ReadOnly = True
        Me.colOptionsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colOptionsSaved.Width = 57
        '
        'tpgSearchObjects
        '
        Me.tpgSearchObjects.Controls.Add(Me.dgvSearchObjects)
        Me.tpgSearchObjects.Location = New System.Drawing.Point(4, 22)
        Me.tpgSearchObjects.Name = "tpgSearchObjects"
        Me.tpgSearchObjects.Size = New System.Drawing.Size(696, 376)
        Me.tpgSearchObjects.TabIndex = 4
        Me.tpgSearchObjects.Text = "Search Engine"
        Me.tpgSearchObjects.UseVisualStyleBackColor = True
        '
        'dgvSearchObjects
        '
        Me.dgvSearchObjects.AllowUserToAddRows = False
        Me.dgvSearchObjects.AllowUserToDeleteRows = False
        Me.dgvSearchObjects.AllowUserToOrderColumns = True
        Me.dgvSearchObjects.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSearchObjects.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvSearchObjects.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSearchObjects.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSearchObjects.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvSearchObjects.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSearchObjectsObjectCaption, Me.colSearhInclude, Me.colSearchObjectsObjectName})
        Me.dgvSearchObjects.EnableHeadersVisualStyles = False
        Me.dgvSearchObjects.GridColor = System.Drawing.Color.Khaki
        Me.dgvSearchObjects.Location = New System.Drawing.Point(6, 8)
        Me.dgvSearchObjects.Name = "dgvSearchObjects"
        Me.dgvSearchObjects.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSearchObjects.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvSearchObjects.Size = New System.Drawing.Size(684, 366)
        Me.dgvSearchObjects.TabIndex = 11
        Me.dgvSearchObjects.Text = "DataGridView1"
        '
        'colSearchObjectsObjectCaption
        '
        Me.colSearchObjectsObjectCaption.DataPropertyName = "ObjectCaption"
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        Me.colSearchObjectsObjectCaption.DefaultCellStyle = DataGridViewCellStyle19
        Me.colSearchObjectsObjectCaption.HeaderText = "Search Item Name"
        Me.colSearchObjectsObjectCaption.Name = "colSearchObjectsObjectCaption"
        Me.colSearchObjectsObjectCaption.ReadOnly = True
        Me.colSearchObjectsObjectCaption.Width = 300
        '
        'colSearhInclude
        '
        Me.colSearhInclude.DataPropertyName = "SearhInclude"
        Me.colSearhInclude.DefaultCellStyle = DataGridViewCellStyle20
        Me.colSearhInclude.HeaderText = "Search Include"
        Me.colSearhInclude.Name = "colSearhInclude"
        Me.colSearhInclude.Width = 150
        '
        'colSearchObjectsObjectName
        '
        Me.colSearchObjectsObjectName.DataPropertyName = "ObjectName"
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle21.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colSearchObjectsObjectName.DefaultCellStyle = DataGridViewCellStyle21
        Me.colSearchObjectsObjectName.HeaderText = "Object Name"
        Me.colSearchObjectsObjectName.Name = "colSearchObjectsObjectName"
        Me.colSearchObjectsObjectName.ReadOnly = True
        Me.colSearchObjectsObjectName.Visible = False
        '
        'tpgOthers
        '
        Me.tpgOthers.Controls.Add(Me.cboCommunityID)
        Me.tpgOthers.Controls.Add(Me.lblCommunity)
        Me.tpgOthers.Controls.Add(Me.cboServicePointQueue)
        Me.tpgOthers.Controls.Add(Me.Label3)
        Me.tpgOthers.Controls.Add(Me.cboRoomID)
        Me.tpgOthers.Controls.Add(Me.lblRoomName)
        Me.tpgOthers.Controls.Add(Me.cboVoices)
        Me.tpgOthers.Controls.Add(Me.lblVoice)
        Me.tpgOthers.Controls.Add(Me.cboBranch)
        Me.tpgOthers.Controls.Add(Me.Label1)
        Me.tpgOthers.Controls.Add(Me.clbIssueLocations)
        Me.tpgOthers.Controls.Add(Me.lblIssueFromLocations)
        Me.tpgOthers.Location = New System.Drawing.Point(4, 22)
        Me.tpgOthers.Name = "tpgOthers"
        Me.tpgOthers.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgOthers.Size = New System.Drawing.Size(696, 376)
        Me.tpgOthers.TabIndex = 7
        Me.tpgOthers.Text = "Others"
        Me.tpgOthers.UseVisualStyleBackColor = True
        '
        'cboCommunityID
        '
        Me.cboCommunityID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCommunityID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCommunityID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCommunityID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCommunityID.FormattingEnabled = True
        Me.cboCommunityID.Location = New System.Drawing.Point(171, 186)
        Me.cboCommunityID.Name = "cboCommunityID"
        Me.cboCommunityID.Size = New System.Drawing.Size(182, 21)
        Me.cboCommunityID.TabIndex = 40
        '
        'lblCommunity
        '
        Me.lblCommunity.Location = New System.Drawing.Point(10, 186)
        Me.lblCommunity.Name = "lblCommunity"
        Me.lblCommunity.Size = New System.Drawing.Size(121, 20)
        Me.lblCommunity.TabIndex = 39
        Me.lblCommunity.Text = "Community"
        '
        'cboServicePointQueue
        '
        Me.cboServicePointQueue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboServicePointQueue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboServicePointQueue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboServicePointQueue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboServicePointQueue.FormattingEnabled = True
        Me.cboServicePointQueue.Location = New System.Drawing.Point(169, 159)
        Me.cboServicePointQueue.Name = "cboServicePointQueue"
        Me.cboServicePointQueue.Size = New System.Drawing.Size(182, 21)
        Me.cboServicePointQueue.TabIndex = 38
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 159)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(121, 20)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Queue at Service Point"
        '
        'cboRoomID
        '
        Me.cboRoomID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRoomID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboRoomID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRoomID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRoomID.FormattingEnabled = True
        Me.cboRoomID.Location = New System.Drawing.Point(171, 129)
        Me.cboRoomID.Name = "cboRoomID"
        Me.cboRoomID.Size = New System.Drawing.Size(182, 21)
        Me.cboRoomID.TabIndex = 36
        '
        'lblRoomName
        '
        Me.lblRoomName.Location = New System.Drawing.Point(10, 129)
        Me.lblRoomName.Name = "lblRoomName"
        Me.lblRoomName.Size = New System.Drawing.Size(121, 20)
        Me.lblRoomName.TabIndex = 35
        Me.lblRoomName.Text = "Room Name"
        '
        'cboVoices
        '
        Me.cboVoices.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboVoices.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVoices.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboVoices.FormattingEnabled = True
        Me.cboVoices.Location = New System.Drawing.Point(171, 102)
        Me.cboVoices.Name = "cboVoices"
        Me.cboVoices.Size = New System.Drawing.Size(182, 21)
        Me.cboVoices.TabIndex = 34
        '
        'lblVoice
        '
        Me.lblVoice.Location = New System.Drawing.Point(11, 102)
        Me.lblVoice.Name = "lblVoice"
        Me.lblVoice.Size = New System.Drawing.Size(171, 20)
        Me.lblVoice.TabIndex = 33
        Me.lblVoice.Text = "Voice"
        '
        'cboBranch
        '
        Me.cboBranch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBranch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBranch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBranch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBranch.FormattingEnabled = True
        Me.cboBranch.Location = New System.Drawing.Point(166, 7)
        Me.cboBranch.Name = "cboBranch"
        Me.cboBranch.Size = New System.Drawing.Size(182, 21)
        Me.cboBranch.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(171, 20)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Branch"
        '
        'clbIssueLocations
        '
        Me.clbIssueLocations.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.clbIssueLocations.FormattingEnabled = True
        Me.clbIssueLocations.Location = New System.Drawing.Point(171, 36)
        Me.clbIssueLocations.Name = "clbIssueLocations"
        Me.clbIssueLocations.Size = New System.Drawing.Size(177, 60)
        Me.clbIssueLocations.TabIndex = 18
        Me.clbIssueLocations.Visible = False
        '
        'lblIssueFromLocations
        '
        Me.lblIssueFromLocations.AutoSize = True
        Me.lblIssueFromLocations.Location = New System.Drawing.Point(11, 36)
        Me.lblIssueFromLocations.Name = "lblIssueFromLocations"
        Me.lblIssueFromLocations.Size = New System.Drawing.Size(143, 13)
        Me.lblIssueFromLocations.TabIndex = 0
        Me.lblIssueFromLocations.Text = "Doctor Dispensing Locations"
        Me.lblIssueFromLocations.Visible = False
        '
        'frmOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(726, 442)
        Me.Controls.Add(Me.tbcOptions)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Options"
        CType(Me.nudDecimalPlaces, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgGeneral.ResumeLayout(False)
        Me.tpgGeneral.PerformLayout()
        Me.grpManageBulkData.ResumeLayout(False)
        Me.grpRestore.ResumeLayout(False)
        Me.grpBackup.ResumeLayout(False)
        Me.tbcOptions.ResumeLayout(False)
        Me.tpgSetupData.ResumeLayout(False)
        Me.grpSmartCardData.ResumeLayout(False)
        Me.tpgAutoNumbers.ResumeLayout(False)
        CType(Me.dgvAutoNumbers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgAutoNumberControls.ResumeLayout(False)
        Me.tpgProductOwnerInfo.ResumeLayout(False)
        Me.tpgProductOwnerInfo.PerformLayout()
        CType(Me.nudTextLeftMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLogoLeftMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTextTopMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudLogoTopMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spbAlternatePhoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.spbPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOtherVariousOptions.ResumeLayout(False)
        CType(Me.dgvOptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgSearchObjects.ResumeLayout(False)
        CType(Me.dgvSearchObjects, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOthers.ResumeLayout(False)
        Me.tpgOthers.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents hlpOptions As System.Windows.Forms.HelpProvider
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents tpgGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tbcOptions As System.Windows.Forms.TabControl
    Friend WithEvents cboStartUpWindow As System.Windows.Forms.ComboBox
    Friend WithEvents lblStartUpWindow As System.Windows.Forms.Label
    Friend WithEvents lblNullDateValue As System.Windows.Forms.Label
    Friend WithEvents mtbNullDateValue As System.Windows.Forms.MaskedTextBox
    Friend WithEvents grpRestore As System.Windows.Forms.GroupBox
    Friend WithEvents btnChangeRestore As System.Windows.Forms.Button
    Friend WithEvents lblRestore As System.Windows.Forms.Label
    Friend WithEvents grpBackup As System.Windows.Forms.GroupBox
    Friend WithEvents btnChangeBackup As System.Windows.Forms.Button
    Friend WithEvents lblBackup As System.Windows.Forms.Label
    Friend WithEvents tpgAutoNumbers As System.Windows.Forms.TabPage
    Friend WithEvents cboCurrency As System.Windows.Forms.ComboBox
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents nudDecimalPlaces As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblDecimalPlaces As System.Windows.Forms.Label
    Friend WithEvents dgvAutoNumbers As System.Windows.Forms.DataGridView
    Friend WithEvents chkEnableAuditTrail As System.Windows.Forms.CheckBox
    Friend WithEvents grpManageBulkData As System.Windows.Forms.GroupBox
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents cboDisableConstraints As System.Windows.Forms.ComboBox
    Friend WithEvents lblManageBulkData As System.Windows.Forms.Label
    Friend WithEvents lblDisableConstraints As System.Windows.Forms.Label
    Friend WithEvents colObjectCaption As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAutoColumnName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAutoColumnLEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaddingCHAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaddingLEN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSeparatorCHAR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSeparatorPositions As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIncrement As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAllowJumpTo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colJumpToValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colObjectName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tpgProductOwnerInfo As System.Windows.Forms.TabPage
    Friend WithEvents btnClearPhoto As System.Windows.Forms.Button
    Friend WithEvents btnLoadPhoto As System.Windows.Forms.Button
    Friend WithEvents stbProductOwner As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblProductOwner As System.Windows.Forms.Label
    Friend WithEvents stbAddress As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents stbPhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPhone As System.Windows.Forms.Label
    Friend WithEvents stbFax As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFax As System.Windows.Forms.Label
    Friend WithEvents stbEmail As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblEmail As System.Windows.Forms.Label
    Friend WithEvents stbWebsite As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblWebsite As System.Windows.Forms.Label
    Friend WithEvents spbPhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblPhoto As System.Windows.Forms.Label
    Friend WithEvents tpgOtherVariousOptions As System.Windows.Forms.TabPage
    Friend WithEvents dgvOptions As System.Windows.Forms.DataGridView
    Friend WithEvents tpgSearchObjects As System.Windows.Forms.TabPage
    Friend WithEvents dgvSearchObjects As System.Windows.Forms.DataGridView
    Friend WithEvents nbxAlertCheckPeriod As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAlertCheckPeriod As System.Windows.Forms.Label
    Friend WithEvents chkAlertSoundOn As System.Windows.Forms.CheckBox
    Friend WithEvents tpgSetupData As System.Windows.Forms.TabPage
    Friend WithEvents chkLoadBillCustomersAtStart As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoadLabTestsAtStart As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoadDrugsAtStart As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoadRadiologyExaminationsAtStart As System.Windows.Forms.CheckBox
    Friend WithEvents nbxUserIdleDuration As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUserIdleDuration As System.Windows.Forms.Label
    Friend WithEvents chkForceVisitBillConfirmation As System.Windows.Forms.CheckBox
    Friend WithEvents colOptionName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOptionValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDataTypeID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMaxLength As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOptionsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkPromptForExtraChargeRegistration As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoadDiseasesAtStart As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoadProceduresAtStart As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoadDentalServicesAtStart As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoadPatientFingerprintsAtStart As System.Windows.Forms.CheckBox
    Friend WithEvents chkForceFingerprintCapture As System.Windows.Forms.CheckBox
    Friend WithEvents grpSmartCardData As System.Windows.Forms.GroupBox
    Friend WithEvents btnSmartCardData As System.Windows.Forms.Button
    Friend WithEvents lblSmartCardData As System.Windows.Forms.Label
    Friend WithEvents stbVATNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVATNo As System.Windows.Forms.Label
    Friend WithEvents stbTINNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTINNo As System.Windows.Forms.Label
    Friend WithEvents stbSearchCustomInsertCharacter As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSearchCustomInsertCharacter As System.Windows.Forms.Label
    Friend WithEvents nbxSearchCustomInsertPosition As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblSearchCustomInsertPosition As System.Windows.Forms.Label
    Friend WithEvents nbxSearchCustomInsertLength As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblSearchCustomInsertLength As System.Windows.Forms.Label
    Friend WithEvents cboLocation As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocation As System.Windows.Forms.Label
    Friend WithEvents cboAssociatedBillNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblAssociatedBillNo As System.Windows.Forms.Label
    Friend WithEvents cboVisitCategory As System.Windows.Forms.ComboBox
    Friend WithEvents lblVisitCategory As System.Windows.Forms.Label
    Friend WithEvents stbAlternateEmail As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAlternateEmail As System.Windows.Forms.Label
    Friend WithEvents stbAlternatePhone As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAlternatePhone As System.Windows.Forms.Label
    Friend WithEvents btnClearAlternatePhoto As System.Windows.Forms.Button
    Friend WithEvents btnLoadAlternatePhoto As System.Windows.Forms.Button
    Friend WithEvents spbAlternatePhoto As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents lblAlternatePhoto As System.Windows.Forms.Label
    Friend WithEvents lblPrintHeaderAlignmentID As System.Windows.Forms.Label
    Friend WithEvents cboPrintHeaderAlignmentID As System.Windows.Forms.ComboBox
    Friend WithEvents nudLogoTopMargin As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblLogoTopMargin As System.Windows.Forms.Label
    Friend WithEvents nudTextTopMargin As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTextTopMargin As System.Windows.Forms.Label
    Friend WithEvents nudTextLeftMargin As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTextLeftMargin As System.Windows.Forms.Label
    Friend WithEvents nudLogoLeftMargin As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblLogoLeftMargin As System.Windows.Forms.Label
    Friend WithEvents chkToBillServiceFeeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents tpgAutoNumberControls As System.Windows.Forms.TabPage
    Friend WithEvents chkSupplierNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkOrderNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkTransferNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkMainMemberNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkMedicalCardNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkOutwardNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkQuotationNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkRefundNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkInvoiceNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkExtraBillNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkClaimNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkCompanyNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkPolicyNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkInsuranceNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkRoundNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkAdmissionNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkTranNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkIncomeNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkExpenditureNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkSpecimenNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkVisitNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkAccountNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkPatientNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkPurchaseOrderNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkGRNNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkStaffNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkDrugNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkConsumableNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkLoadConsumableItemsAtStart As System.Windows.Forms.CheckBox
    Friend WithEvents cboPharmacyPrinterPaperSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblPrinterPaperSize As System.Windows.Forms.Label
    Friend WithEvents stbFacilityNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFacilityNo As System.Windows.Forms.Label
    Friend WithEvents cboCashierPrinterPaperSize As System.Windows.Forms.ComboBox
    Friend WithEvents lblCashierPaperSize As System.Windows.Forms.Label
    Friend WithEvents chkOpenCashierAfterSelfRequest As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableChatNotification As System.Windows.Forms.CheckBox
    Friend WithEvents chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpenPharmacyAfterCashier As System.Windows.Forms.CheckBox
    Friend WithEvents lblDefaultPatientNo As System.Windows.Forms.Label
    Friend WithEvents cbodefaultLanguage As System.Windows.Forms.ComboBox
    Friend WithEvents lblDefaultLanguage As System.Windows.Forms.Label
    Friend WithEvents cboDefaultSelfRequestNo As System.Windows.Forms.ComboBox
    Friend WithEvents tpgOthers As System.Windows.Forms.TabPage
    Friend WithEvents lblIssueFromLocations As System.Windows.Forms.Label
    Friend WithEvents clbIssueLocations As System.Windows.Forms.CheckedListBox
    Friend WithEvents cboBranch As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSMSNotificationPoint As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboServicePointQueue As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboRoomID As ComboBox
    Friend WithEvents lblRoomName As Label
    Friend WithEvents cboVoices As ComboBox
    Friend WithEvents lblVoice As Label
    Friend WithEvents chkReceiptNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents ChkEnableViewCashCollections As System.Windows.Forms.CheckBox
    Friend WithEvents colSearchObjectsObjectCaption As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSearhInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colSearchObjectsObjectName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboCommunityID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCommunity As System.Windows.Forms.Label
    Friend WithEvents lblPasswordComplexityID As System.Windows.Forms.Label
    Friend WithEvents cboPasswordComplexityID As System.Windows.Forms.ComboBox
    Friend WithEvents chkExtraChargeItemCodeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkBedNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkDentalCodeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkMaternityCodeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkPathologyExamCodeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkPackageNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkICUCodeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkTheatreCodeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkCardiologyExamCode As System.Windows.Forms.CheckBox
    Friend WithEvents chkEyeCodeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkTestCodeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkServiceCodeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkRadiologyExamNoLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkProcedureCodeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkOpticalCodeLocked As System.Windows.Forms.CheckBox
    Friend WithEvents chkNonMedicalItemCodeLocked As System.Windows.Forms.CheckBox
End Class
