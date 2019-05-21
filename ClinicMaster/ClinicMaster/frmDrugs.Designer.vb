<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmDrugs : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal drugNo As String, ByVal disableCallOnKeyEdit As Boolean)
        MyClass.New()
        Me.defaultDrugNo = drugNo
        Me.noCallOnKeyEdit = disableCallOnKeyEdit
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDrugs))
        Me.stbDrugName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxUnitPrice = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxKeepingUnit = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxOrderLevel = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxUnitsReceived = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.fcbUnitMeasurID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.fcbCategoryNo = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.lblKeepingUnit = New System.Windows.Forms.Label()
        Me.lblOrderLevel = New System.Windows.Forms.Label()
        Me.lblUnitsReceived = New System.Windows.Forms.Label()
        Me.lblUnitMeasureID = New System.Windows.Forms.Label()
        Me.lblCategoryNo = New System.Windows.Forms.Label()
        Me.lblDrugName = New System.Windows.Forms.Label()
        Me.lblDrugNo = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.nbxUnitCost = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.chkHalted = New System.Windows.Forms.CheckBox()
        Me.stbAlternateName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboGroupsID = New System.Windows.Forms.ComboBox()
        Me.nbxVATPercentage = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.lblAlternateName = New System.Windows.Forms.Label()
        Me.cboDrugNo = New System.Windows.Forms.ComboBox()
        Me.pnlInventory = New System.Windows.Forms.Panel()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.dtpExpiryDate = New System.Windows.Forms.DateTimePicker()
        Me.lblExpiryDate = New System.Windows.Forms.Label()
        Me.stbBatchNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBatchNo = New System.Windows.Forms.Label()
        Me.lblGroupsID = New System.Windows.Forms.Label()
        Me.tpgInsuranceCustomFee = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceCustomFee = New System.Windows.Forms.DataGridView()
        Me.colInsuranceName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInsuranceCustomFee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInsuranceCurrenciesID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceCustomFeeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgBillCustomFee = New System.Windows.Forms.TabPage()
        Me.dgvBillCustomFee = New System.Windows.Forms.DataGridView()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colAccountNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomFee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCurrenciesID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colBillCustomFeeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgAlternateDrugs = New System.Windows.Forms.TabPage()
        Me.dgvAlternateDrugs = New System.Windows.Forms.DataGridView()
        Me.colAlternateDrugName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colAlternateDrugNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAlternateDrugsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tbcBillExcludedItems = New System.Windows.Forms.TabControl()
        Me.tpgItemLocationOrderLevel = New System.Windows.Forms.TabPage()
        Me.dgvItemLocationOrderLevels = New System.Windows.Forms.DataGridView()
        Me.colLocation = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colLocationOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemLocationOrderLevelsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgPossibleConsumables = New System.Windows.Forms.TabPage()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColConsumableItemsSaved = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.lblVATPercentage = New System.Windows.Forms.Label()
        Me.pnlAlertItems = New System.Windows.Forms.Panel()
        Me.btnViewReceivedDrugs = New System.Windows.Forms.Button()
        Me.lblToCompleteItems = New System.Windows.Forms.Label()
        Me.pnlInventory.SuspendLayout()
        Me.tpgInsuranceCustomFee.SuspendLayout()
        CType(Me.dgvInsuranceCustomFee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgBillCustomFee.SuspendLayout()
        CType(Me.dgvBillCustomFee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgAlternateDrugs.SuspendLayout()
        CType(Me.dgvAlternateDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcBillExcludedItems.SuspendLayout()
        Me.tpgItemLocationOrderLevel.SuspendLayout()
        CType(Me.dgvItemLocationOrderLevels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPossibleConsumables.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAlertItems.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbDrugName
        '
        Me.stbDrugName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDrugName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbDrugName, "DrugName")
        Me.stbDrugName.EntryErrorMSG = ""
        Me.stbDrugName.Location = New System.Drawing.Point(194, 26)
        Me.stbDrugName.MaxLength = 100
        Me.stbDrugName.Name = "stbDrugName"
        Me.stbDrugName.RegularExpression = ""
        Me.stbDrugName.Size = New System.Drawing.Size(230, 20)
        Me.stbDrugName.TabIndex = 3
        Me.stbDrugName.Tag = "DrugName"
        '
        'nbxUnitPrice
        '
        Me.nbxUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitPrice.ControlCaption = "Unit Price"
        Me.nbxUnitPrice.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxUnitPrice, "UnitPrice")
        Me.nbxUnitPrice.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxUnitPrice.DecimalPlaces = -1
        Me.nbxUnitPrice.Location = New System.Drawing.Point(528, 112)
        Me.nbxUnitPrice.MaxValue = 0.0R
        Me.nbxUnitPrice.MinValue = 0.0R
        Me.nbxUnitPrice.MustEnterNumeric = True
        Me.nbxUnitPrice.Name = "nbxUnitPrice"
        Me.nbxUnitPrice.Size = New System.Drawing.Size(190, 20)
        Me.nbxUnitPrice.TabIndex = 25
        Me.nbxUnitPrice.Tag = "DrugPrices"
        Me.nbxUnitPrice.Value = ""
        '
        'nbxKeepingUnit
        '
        Me.nbxKeepingUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxKeepingUnit.ControlCaption = "Keeping Unit"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxKeepingUnit, "KeepingUnit")
        Me.nbxKeepingUnit.DecimalPlaces = -1
        Me.nbxKeepingUnit.Location = New System.Drawing.Point(194, 157)
        Me.nbxKeepingUnit.MaxValue = 0.0R
        Me.nbxKeepingUnit.MinValue = 0.0R
        Me.nbxKeepingUnit.MustEnterNumeric = True
        Me.nbxKeepingUnit.Name = "nbxKeepingUnit"
        Me.nbxKeepingUnit.Size = New System.Drawing.Size(230, 20)
        Me.nbxKeepingUnit.TabIndex = 15
        Me.nbxKeepingUnit.Value = ""
        '
        'nbxOrderLevel
        '
        Me.nbxOrderLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOrderLevel.ControlCaption = "Order Level"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxOrderLevel, "OrderLevel")
        Me.nbxOrderLevel.DecimalPlaces = -1
        Me.nbxOrderLevel.Location = New System.Drawing.Point(194, 136)
        Me.nbxOrderLevel.MaxValue = 0.0R
        Me.nbxOrderLevel.MinValue = 0.0R
        Me.nbxOrderLevel.MustEnterNumeric = True
        Me.nbxOrderLevel.Name = "nbxOrderLevel"
        Me.nbxOrderLevel.Size = New System.Drawing.Size(230, 20)
        Me.nbxOrderLevel.TabIndex = 13
        Me.nbxOrderLevel.Value = ""
        '
        'nbxUnitsReceived
        '
        Me.nbxUnitsReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitsReceived.ControlCaption = "Units Received"
        Me.nbxUnitsReceived.DecimalPlaces = -1
        Me.nbxUnitsReceived.Location = New System.Drawing.Point(194, 179)
        Me.nbxUnitsReceived.MaxValue = 0.0R
        Me.nbxUnitsReceived.MinValue = 0.0R
        Me.nbxUnitsReceived.MustEnterNumeric = True
        Me.nbxUnitsReceived.Name = "nbxUnitsReceived"
        Me.nbxUnitsReceived.Size = New System.Drawing.Size(230, 20)
        Me.nbxUnitsReceived.TabIndex = 17
        Me.nbxUnitsReceived.Value = ""
        '
        'fcbUnitMeasurID
        '
        Me.fcbUnitMeasurID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.fcbUnitMeasurID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.fcbUnitMeasurID, "UnitMeasure,UnitMeasureID")
        Me.fcbUnitMeasurID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbUnitMeasurID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbUnitMeasurID.FormattingEnabled = True
        Me.fcbUnitMeasurID.Location = New System.Drawing.Point(194, 113)
        Me.fcbUnitMeasurID.Name = "fcbUnitMeasurID"
        Me.fcbUnitMeasurID.ReadOnly = True
        Me.fcbUnitMeasurID.Size = New System.Drawing.Size(230, 21)
        Me.fcbUnitMeasurID.TabIndex = 11
        '
        'fcbCategoryNo
        '
        Me.fcbCategoryNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.fcbCategoryNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.fcbCategoryNo, "CategoryName")
        Me.fcbCategoryNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbCategoryNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbCategoryNo.FormattingEnabled = True
        Me.fcbCategoryNo.Location = New System.Drawing.Point(194, 69)
        Me.fcbCategoryNo.Name = "fcbCategoryNo"
        Me.fcbCategoryNo.ReadOnly = True
        Me.fcbCategoryNo.Size = New System.Drawing.Size(230, 21)
        Me.fcbCategoryNo.TabIndex = 7
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(632, 466)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(79, 24)
        Me.fbnClose.TabIndex = 32
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Location = New System.Drawing.Point(434, 113)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(88, 20)
        Me.lblUnitPrice.TabIndex = 24
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'lblKeepingUnit
        '
        Me.lblKeepingUnit.Location = New System.Drawing.Point(12, 157)
        Me.lblKeepingUnit.Name = "lblKeepingUnit"
        Me.lblKeepingUnit.Size = New System.Drawing.Size(95, 20)
        Me.lblKeepingUnit.TabIndex = 14
        Me.lblKeepingUnit.Text = "Keeping Unit"
        '
        'lblOrderLevel
        '
        Me.lblOrderLevel.Location = New System.Drawing.Point(12, 136)
        Me.lblOrderLevel.Name = "lblOrderLevel"
        Me.lblOrderLevel.Size = New System.Drawing.Size(95, 20)
        Me.lblOrderLevel.TabIndex = 12
        Me.lblOrderLevel.Text = "Order Level"
        '
        'lblUnitsReceived
        '
        Me.lblUnitsReceived.Location = New System.Drawing.Point(12, 185)
        Me.lblUnitsReceived.Name = "lblUnitsReceived"
        Me.lblUnitsReceived.Size = New System.Drawing.Size(88, 20)
        Me.lblUnitsReceived.TabIndex = 16
        Me.lblUnitsReceived.Text = "Units Received"
        '
        'lblUnitMeasureID
        '
        Me.lblUnitMeasureID.Location = New System.Drawing.Point(12, 113)
        Me.lblUnitMeasureID.Name = "lblUnitMeasureID"
        Me.lblUnitMeasureID.Size = New System.Drawing.Size(95, 21)
        Me.lblUnitMeasureID.TabIndex = 10
        Me.lblUnitMeasureID.Text = "Unit Measure"
        '
        'lblCategoryNo
        '
        Me.lblCategoryNo.Location = New System.Drawing.Point(12, 69)
        Me.lblCategoryNo.Name = "lblCategoryNo"
        Me.lblCategoryNo.Size = New System.Drawing.Size(95, 21)
        Me.lblCategoryNo.TabIndex = 6
        Me.lblCategoryNo.Text = "Drug Category"
        '
        'lblDrugName
        '
        Me.lblDrugName.Location = New System.Drawing.Point(12, 26)
        Me.lblDrugName.Name = "lblDrugName"
        Me.lblDrugName.Size = New System.Drawing.Size(95, 20)
        Me.lblDrugName.TabIndex = 2
        Me.lblDrugName.Text = "Drug Name"
        '
        'lblDrugNo
        '
        Me.lblDrugNo.Location = New System.Drawing.Point(12, 5)
        Me.lblDrugNo.Name = "lblDrugNo"
        Me.lblDrugNo.Size = New System.Drawing.Size(95, 20)
        Me.lblDrugNo.TabIndex = 0
        Me.lblDrugNo.Text = "Drug Number"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(18, 441)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 29
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(632, 439)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(79, 24)
        Me.fbnDelete.TabIndex = 31
        Me.fbnDelete.Tag = "Drugs"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(18, 468)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 30
        Me.ebnSaveUpdate.Tag = "Drugs"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'nbxUnitCost
        '
        Me.nbxUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitCost.ControlCaption = "Unit Cost"
        Me.nbxUnitCost.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxUnitCost, "UnitCost")
        Me.nbxUnitCost.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxUnitCost.DecimalPlaces = -1
        Me.nbxUnitCost.Location = New System.Drawing.Point(528, 70)
        Me.nbxUnitCost.MaxValue = 0.0R
        Me.nbxUnitCost.MinValue = 0.0R
        Me.nbxUnitCost.MustEnterNumeric = True
        Me.nbxUnitCost.Name = "nbxUnitCost"
        Me.nbxUnitCost.Size = New System.Drawing.Size(191, 20)
        Me.nbxUnitCost.TabIndex = 21
        Me.nbxUnitCost.Tag = "DrugPrices"
        Me.nbxUnitCost.Value = ""
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHidden, "Hidden")
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(568, 138)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(102, 20)
        Me.chkHidden.TabIndex = 27
        Me.chkHidden.Text = "Hidden"
        '
        'chkHalted
        '
        Me.chkHalted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHalted, "Halted")
        Me.chkHalted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHalted.Location = New System.Drawing.Point(430, 138)
        Me.chkHalted.Name = "chkHalted"
        Me.chkHalted.Size = New System.Drawing.Size(110, 20)
        Me.chkHalted.TabIndex = 26
        Me.chkHalted.Text = "Halted"
        '
        'stbAlternateName
        '
        Me.stbAlternateName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAlternateName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbAlternateName, "AlternateName")
        Me.stbAlternateName.EntryErrorMSG = ""
        Me.stbAlternateName.Location = New System.Drawing.Point(194, 47)
        Me.stbAlternateName.MaxLength = 100
        Me.stbAlternateName.Name = "stbAlternateName"
        Me.stbAlternateName.RegularExpression = ""
        Me.stbAlternateName.Size = New System.Drawing.Size(230, 20)
        Me.stbAlternateName.TabIndex = 5
        '
        'cboGroupsID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboGroupsID, "Groups,GroupsID")
        Me.cboGroupsID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGroupsID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboGroupsID.Location = New System.Drawing.Point(194, 91)
        Me.cboGroupsID.Name = "cboGroupsID"
        Me.cboGroupsID.Size = New System.Drawing.Size(230, 21)
        Me.cboGroupsID.TabIndex = 9
        '
        'nbxVATPercentage
        '
        Me.nbxVATPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxVATPercentage.ControlCaption = "VATPercentage"
        Me.nbxVATPercentage.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxVATPercentage, "VATPercentage")
        Me.nbxVATPercentage.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxVATPercentage.DecimalPlaces = -1
        Me.nbxVATPercentage.Location = New System.Drawing.Point(528, 91)
        Me.nbxVATPercentage.MaxLength = 20
        Me.nbxVATPercentage.MaxValue = 0.0R
        Me.nbxVATPercentage.MinValue = 0.0R
        Me.nbxVATPercentage.MustEnterNumeric = True
        Me.nbxVATPercentage.Name = "nbxVATPercentage"
        Me.nbxVATPercentage.Size = New System.Drawing.Size(191, 20)
        Me.nbxVATPercentage.TabIndex = 23
        Me.nbxVATPercentage.Tag = "DrugPrices"
        Me.nbxVATPercentage.Value = ""
        '
        'lblUnitCost
        '
        Me.lblUnitCost.Location = New System.Drawing.Point(434, 70)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(95, 20)
        Me.lblUnitCost.TabIndex = 20
        Me.lblUnitCost.Text = "Unit Cost"
        '
        'lblAlternateName
        '
        Me.lblAlternateName.Location = New System.Drawing.Point(12, 47)
        Me.lblAlternateName.Name = "lblAlternateName"
        Me.lblAlternateName.Size = New System.Drawing.Size(95, 20)
        Me.lblAlternateName.TabIndex = 4
        Me.lblAlternateName.Text = "Alternate Name"
        '
        'cboDrugNo
        '
        Me.cboDrugNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDrugNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDrugNo.DropDownWidth = 300
        Me.cboDrugNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDrugNo.FormattingEnabled = True
        Me.cboDrugNo.Location = New System.Drawing.Point(194, 3)
        Me.cboDrugNo.MaxLength = 40
        Me.cboDrugNo.Name = "cboDrugNo"
        Me.cboDrugNo.Size = New System.Drawing.Size(230, 21)
        Me.cboDrugNo.TabIndex = 1
        '
        'pnlInventory
        '
        Me.pnlInventory.Controls.Add(Me.cboLocationID)
        Me.pnlInventory.Controls.Add(Me.lblLocationID)
        Me.pnlInventory.Controls.Add(Me.dtpExpiryDate)
        Me.pnlInventory.Controls.Add(Me.lblExpiryDate)
        Me.pnlInventory.Controls.Add(Me.stbBatchNo)
        Me.pnlInventory.Controls.Add(Me.lblBatchNo)
        Me.pnlInventory.Location = New System.Drawing.Point(0, 200)
        Me.pnlInventory.Name = "pnlInventory"
        Me.pnlInventory.Size = New System.Drawing.Size(437, 71)
        Me.pnlInventory.TabIndex = 18
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(194, 3)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(230, 21)
        Me.cboLocationID.TabIndex = 1
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(12, 3)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(125, 21)
        Me.lblLocationID.TabIndex = 0
        Me.lblLocationID.Text = "Location"
        '
        'dtpExpiryDate
        '
        Me.dtpExpiryDate.Checked = False
        Me.dtpExpiryDate.Location = New System.Drawing.Point(194, 47)
        Me.dtpExpiryDate.Name = "dtpExpiryDate"
        Me.dtpExpiryDate.ShowCheckBox = True
        Me.dtpExpiryDate.Size = New System.Drawing.Size(230, 20)
        Me.dtpExpiryDate.TabIndex = 5
        '
        'lblExpiryDate
        '
        Me.lblExpiryDate.Location = New System.Drawing.Point(12, 48)
        Me.lblExpiryDate.Name = "lblExpiryDate"
        Me.lblExpiryDate.Size = New System.Drawing.Size(125, 21)
        Me.lblExpiryDate.TabIndex = 4
        Me.lblExpiryDate.Text = "Expiry Date"
        '
        'stbBatchNo
        '
        Me.stbBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBatchNo.CapitalizeFirstLetter = False
        Me.stbBatchNo.EntryErrorMSG = ""
        Me.stbBatchNo.Location = New System.Drawing.Point(194, 26)
        Me.stbBatchNo.MaxLength = 20
        Me.stbBatchNo.Name = "stbBatchNo"
        Me.stbBatchNo.RegularExpression = ""
        Me.stbBatchNo.Size = New System.Drawing.Size(230, 20)
        Me.stbBatchNo.TabIndex = 3
        '
        'lblBatchNo
        '
        Me.lblBatchNo.Location = New System.Drawing.Point(12, 25)
        Me.lblBatchNo.Name = "lblBatchNo"
        Me.lblBatchNo.Size = New System.Drawing.Size(125, 21)
        Me.lblBatchNo.TabIndex = 2
        Me.lblBatchNo.Text = "Batch No"
        '
        'lblGroupsID
        '
        Me.lblGroupsID.Location = New System.Drawing.Point(12, 89)
        Me.lblGroupsID.Name = "lblGroupsID"
        Me.lblGroupsID.Size = New System.Drawing.Size(158, 20)
        Me.lblGroupsID.TabIndex = 8
        Me.lblGroupsID.Text = "Group"
        '
        'tpgInsuranceCustomFee
        '
        Me.tpgInsuranceCustomFee.Controls.Add(Me.dgvInsuranceCustomFee)
        Me.tpgInsuranceCustomFee.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceCustomFee.Name = "tpgInsuranceCustomFee"
        Me.tpgInsuranceCustomFee.Size = New System.Drawing.Size(689, 138)
        Me.tpgInsuranceCustomFee.TabIndex = 1
        Me.tpgInsuranceCustomFee.Tag = "InsuranceCustomFee"
        Me.tpgInsuranceCustomFee.Text = "Insurance Custom Fee"
        Me.tpgInsuranceCustomFee.UseVisualStyleBackColor = True
        '
        'dgvInsuranceCustomFee
        '
        Me.dgvInsuranceCustomFee.AllowUserToOrderColumns = True
        Me.dgvInsuranceCustomFee.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceCustomFee.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInsuranceCustomFee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInsuranceName, Me.colInsuranceNo, Me.colInsuranceCustomFee, Me.colInsuranceCurrenciesID, Me.colInsuranceCustomFeeSaved})
        Me.dgvInsuranceCustomFee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceCustomFee.EnableHeadersVisualStyles = False
        Me.dgvInsuranceCustomFee.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceCustomFee.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceCustomFee.Name = "dgvInsuranceCustomFee"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceCustomFee.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvInsuranceCustomFee.Size = New System.Drawing.Size(689, 138)
        Me.dgvInsuranceCustomFee.TabIndex = 21
        Me.dgvInsuranceCustomFee.Tag = "DrugPrices"
        Me.dgvInsuranceCustomFee.Text = "DataGridView1"
        '
        'colInsuranceName
        '
        Me.colInsuranceName.DataPropertyName = "InsuranceNo"
        Me.colInsuranceName.DisplayStyleForCurrentCellOnly = True
        Me.colInsuranceName.DropDownWidth = 200
        Me.colInsuranceName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceName.HeaderText = "Insurance Name"
        Me.colInsuranceName.Name = "colInsuranceName"
        Me.colInsuranceName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colInsuranceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colInsuranceName.Width = 200
        '
        'colInsuranceNo
        '
        Me.colInsuranceNo.DataPropertyName = "InsuranceNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colInsuranceNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colInsuranceNo.HeaderText = "Insurance No"
        Me.colInsuranceNo.Name = "colInsuranceNo"
        Me.colInsuranceNo.ReadOnly = True
        '
        'colInsuranceCustomFee
        '
        Me.colInsuranceCustomFee.DataPropertyName = "CustomFee"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colInsuranceCustomFee.DefaultCellStyle = DataGridViewCellStyle3
        Me.colInsuranceCustomFee.HeaderText = "Custom Fee"
        Me.colInsuranceCustomFee.MaxInputLength = 12
        Me.colInsuranceCustomFee.Name = "colInsuranceCustomFee"
        '
        'colInsuranceCurrenciesID
        '
        Me.colInsuranceCurrenciesID.DataPropertyName = "CurrenciesID"
        Me.colInsuranceCurrenciesID.DisplayStyleForCurrentCellOnly = True
        Me.colInsuranceCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceCurrenciesID.HeaderText = "Currency"
        Me.colInsuranceCurrenciesID.Name = "colInsuranceCurrenciesID"
        Me.colInsuranceCurrenciesID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colInsuranceCustomFeeSaved
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.NullValue = False
        Me.colInsuranceCustomFeeSaved.DefaultCellStyle = DataGridViewCellStyle4
        Me.colInsuranceCustomFeeSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceCustomFeeSaved.HeaderText = "Saved"
        Me.colInsuranceCustomFeeSaved.Name = "colInsuranceCustomFeeSaved"
        Me.colInsuranceCustomFeeSaved.ReadOnly = True
        Me.colInsuranceCustomFeeSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceCustomFeeSaved.Width = 50
        '
        'tpgBillCustomFee
        '
        Me.tpgBillCustomFee.Controls.Add(Me.dgvBillCustomFee)
        Me.tpgBillCustomFee.Location = New System.Drawing.Point(4, 22)
        Me.tpgBillCustomFee.Name = "tpgBillCustomFee"
        Me.tpgBillCustomFee.Size = New System.Drawing.Size(689, 138)
        Me.tpgBillCustomFee.TabIndex = 2
        Me.tpgBillCustomFee.Tag = "BillCustomFee"
        Me.tpgBillCustomFee.Text = "Bill Custom Fee"
        Me.tpgBillCustomFee.UseVisualStyleBackColor = True
        '
        'dgvBillCustomFee
        '
        Me.dgvBillCustomFee.AllowUserToOrderColumns = True
        Me.dgvBillCustomFee.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillCustomFee.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvBillCustomFee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBillCustomerName, Me.colAccountNo, Me.colBillCustomFee, Me.colBillCurrenciesID, Me.colBillCustomFeeSaved})
        Me.dgvBillCustomFee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBillCustomFee.EnableHeadersVisualStyles = False
        Me.dgvBillCustomFee.GridColor = System.Drawing.Color.Khaki
        Me.dgvBillCustomFee.Location = New System.Drawing.Point(0, 0)
        Me.dgvBillCustomFee.Name = "dgvBillCustomFee"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillCustomFee.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvBillCustomFee.Size = New System.Drawing.Size(689, 138)
        Me.dgvBillCustomFee.TabIndex = 0
        Me.dgvBillCustomFee.Tag = "DrugPrices"
        Me.dgvBillCustomFee.Text = "DataGridView1"
        '
        'colBillCustomerName
        '
        Me.colBillCustomerName.DataPropertyName = "AccountNo"
        Me.colBillCustomerName.DisplayStyleForCurrentCellOnly = True
        Me.colBillCustomerName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colBillCustomerName.HeaderText = "To-Bill Account Name"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colBillCustomerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colBillCustomerName.Width = 200
        '
        'colAccountNo
        '
        Me.colAccountNo.DataPropertyName = "AccountNo"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colAccountNo.DefaultCellStyle = DataGridViewCellStyle7
        Me.colAccountNo.HeaderText = "Account No"
        Me.colAccountNo.Name = "colAccountNo"
        Me.colAccountNo.ReadOnly = True
        '
        'colBillCustomFee
        '
        Me.colBillCustomFee.DataPropertyName = "CustomFee"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colBillCustomFee.DefaultCellStyle = DataGridViewCellStyle8
        Me.colBillCustomFee.HeaderText = "Custom Fee"
        Me.colBillCustomFee.MaxInputLength = 12
        Me.colBillCustomFee.Name = "colBillCustomFee"
        '
        'colBillCurrenciesID
        '
        Me.colBillCurrenciesID.DataPropertyName = "CurrenciesID"
        Me.colBillCurrenciesID.DisplayStyleForCurrentCellOnly = True
        Me.colBillCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colBillCurrenciesID.HeaderText = "Currency"
        Me.colBillCurrenciesID.Name = "colBillCurrenciesID"
        Me.colBillCurrenciesID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colBillCustomFeeSaved
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = False
        Me.colBillCustomFeeSaved.DefaultCellStyle = DataGridViewCellStyle9
        Me.colBillCustomFeeSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colBillCustomFeeSaved.HeaderText = "Saved"
        Me.colBillCustomFeeSaved.Name = "colBillCustomFeeSaved"
        Me.colBillCustomFeeSaved.ReadOnly = True
        Me.colBillCustomFeeSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colBillCustomFeeSaved.Width = 50
        '
        'tpgAlternateDrugs
        '
        Me.tpgAlternateDrugs.Controls.Add(Me.dgvAlternateDrugs)
        Me.tpgAlternateDrugs.Location = New System.Drawing.Point(4, 22)
        Me.tpgAlternateDrugs.Name = "tpgAlternateDrugs"
        Me.tpgAlternateDrugs.Size = New System.Drawing.Size(689, 138)
        Me.tpgAlternateDrugs.TabIndex = 3
        Me.tpgAlternateDrugs.Tag = "AlternateDrugs"
        Me.tpgAlternateDrugs.Text = "Alternate Drug(s)"
        Me.tpgAlternateDrugs.UseVisualStyleBackColor = True
        '
        'dgvAlternateDrugs
        '
        Me.dgvAlternateDrugs.AllowUserToOrderColumns = True
        Me.dgvAlternateDrugs.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAlternateDrugs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvAlternateDrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAlternateDrugName, Me.colAlternateDrugNo, Me.colAlternateDrugsSaved})
        Me.dgvAlternateDrugs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvAlternateDrugs.EnableHeadersVisualStyles = False
        Me.dgvAlternateDrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvAlternateDrugs.Location = New System.Drawing.Point(0, 0)
        Me.dgvAlternateDrugs.Name = "dgvAlternateDrugs"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAlternateDrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvAlternateDrugs.Size = New System.Drawing.Size(689, 138)
        Me.dgvAlternateDrugs.TabIndex = 0
        Me.dgvAlternateDrugs.Text = "DataGridView1"
        '
        'colAlternateDrugName
        '
        Me.colAlternateDrugName.DataPropertyName = "AlternateDrugNo"
        Me.colAlternateDrugName.DisplayStyleForCurrentCellOnly = True
        Me.colAlternateDrugName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colAlternateDrugName.HeaderText = "Alternate Drug Name"
        Me.colAlternateDrugName.Name = "colAlternateDrugName"
        Me.colAlternateDrugName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAlternateDrugName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colAlternateDrugName.Width = 300
        '
        'colAlternateDrugNo
        '
        Me.colAlternateDrugNo.DataPropertyName = "AlternateDrugNo"
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colAlternateDrugNo.DefaultCellStyle = DataGridViewCellStyle12
        Me.colAlternateDrugNo.HeaderText = "Alternate Drug No"
        Me.colAlternateDrugNo.Name = "colAlternateDrugNo"
        Me.colAlternateDrugNo.ReadOnly = True
        '
        'colAlternateDrugsSaved
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle13.NullValue = False
        Me.colAlternateDrugsSaved.DefaultCellStyle = DataGridViewCellStyle13
        Me.colAlternateDrugsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colAlternateDrugsSaved.HeaderText = "Saved"
        Me.colAlternateDrugsSaved.Name = "colAlternateDrugsSaved"
        Me.colAlternateDrugsSaved.ReadOnly = True
        Me.colAlternateDrugsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colAlternateDrugsSaved.Width = 50
        '
        'tbcBillExcludedItems
        '
        Me.tbcBillExcludedItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgAlternateDrugs)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgBillCustomFee)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgInsuranceCustomFee)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgItemLocationOrderLevel)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgPossibleConsumables)
        Me.tbcBillExcludedItems.HotTrack = True
        Me.tbcBillExcludedItems.Location = New System.Drawing.Point(15, 272)
        Me.tbcBillExcludedItems.Name = "tbcBillExcludedItems"
        Me.tbcBillExcludedItems.SelectedIndex = 0
        Me.tbcBillExcludedItems.Size = New System.Drawing.Size(697, 164)
        Me.tbcBillExcludedItems.TabIndex = 28
        '
        'tpgItemLocationOrderLevel
        '
        Me.tpgItemLocationOrderLevel.Controls.Add(Me.dgvItemLocationOrderLevels)
        Me.tpgItemLocationOrderLevel.Location = New System.Drawing.Point(4, 22)
        Me.tpgItemLocationOrderLevel.Name = "tpgItemLocationOrderLevel"
        Me.tpgItemLocationOrderLevel.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgItemLocationOrderLevel.Size = New System.Drawing.Size(689, 138)
        Me.tpgItemLocationOrderLevel.TabIndex = 4
        Me.tpgItemLocationOrderLevel.Text = "Location Order Level"
        Me.tpgItemLocationOrderLevel.UseVisualStyleBackColor = True
        '
        'dgvItemLocationOrderLevels
        '
        Me.dgvItemLocationOrderLevels.AllowUserToOrderColumns = True
        Me.dgvItemLocationOrderLevels.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemLocationOrderLevels.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvItemLocationOrderLevels.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colLocation, Me.colLocationOrderLevel, Me.colItemLocationOrderLevelsSaved})
        Me.dgvItemLocationOrderLevels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItemLocationOrderLevels.EnableHeadersVisualStyles = False
        Me.dgvItemLocationOrderLevels.GridColor = System.Drawing.Color.Khaki
        Me.dgvItemLocationOrderLevels.Location = New System.Drawing.Point(3, 3)
        Me.dgvItemLocationOrderLevels.Name = "dgvItemLocationOrderLevels"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemLocationOrderLevels.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvItemLocationOrderLevels.Size = New System.Drawing.Size(683, 132)
        Me.dgvItemLocationOrderLevels.TabIndex = 24
        Me.dgvItemLocationOrderLevels.Text = "DataGridView1"
        '
        'colLocation
        '
        Me.colLocation.DataPropertyName = "LocationID"
        Me.colLocation.DisplayStyleForCurrentCellOnly = True
        Me.colLocation.DropDownWidth = 200
        Me.colLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colLocation.HeaderText = "Location"
        Me.colLocation.Name = "colLocation"
        Me.colLocation.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colLocation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colLocation.Width = 200
        '
        'colLocationOrderLevel
        '
        Me.colLocationOrderLevel.DataPropertyName = "LocationOrderLevel"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.colLocationOrderLevel.DefaultCellStyle = DataGridViewCellStyle16
        Me.colLocationOrderLevel.HeaderText = "Order Level"
        Me.colLocationOrderLevel.MaxInputLength = 12
        Me.colLocationOrderLevel.Name = "colLocationOrderLevel"
        '
        'colItemLocationOrderLevelsSaved
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle17.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle17.NullValue = False
        Me.colItemLocationOrderLevelsSaved.DefaultCellStyle = DataGridViewCellStyle17
        Me.colItemLocationOrderLevelsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colItemLocationOrderLevelsSaved.HeaderText = "Saved"
        Me.colItemLocationOrderLevelsSaved.Name = "colItemLocationOrderLevelsSaved"
        Me.colItemLocationOrderLevelsSaved.ReadOnly = True
        Me.colItemLocationOrderLevelsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colItemLocationOrderLevelsSaved.Width = 50
        '
        'tpgPossibleConsumables
        '
        Me.tpgPossibleConsumables.Controls.Add(Me.dgvConsumables)
        Me.tpgPossibleConsumables.Location = New System.Drawing.Point(4, 22)
        Me.tpgPossibleConsumables.Name = "tpgPossibleConsumables"
        Me.tpgPossibleConsumables.Size = New System.Drawing.Size(689, 138)
        Me.tpgPossibleConsumables.TabIndex = 5
        Me.tpgPossibleConsumables.Text = "Possible Consumables"
        Me.tpgPossibleConsumables.UseVisualStyleBackColor = True
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToOrderColumns = True
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumableName, Me.colConsumableQuantity, Me.ColUnitCost, Me.ColUnitPrice, Me.colConsumableNotes, Me.ColConsumableItemsSaved})
        Me.dgvConsumables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(0, 0)
        Me.dgvConsumables.Name = "dgvConsumables"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvConsumables.Size = New System.Drawing.Size(689, 138)
        Me.dgvConsumables.TabIndex = 42
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'colConsumableName
        '
        Me.colConsumableName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colConsumableName.DataPropertyName = "ConsumableFullName"
        Me.colConsumableName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colConsumableName.DisplayStyleForCurrentCellOnly = True
        Me.colConsumableName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.Sorted = True
        Me.colConsumableName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colConsumableQuantity
        '
        Me.colConsumableQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colConsumableQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "N0"
        DataGridViewCellStyle20.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle20.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle20
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        '
        'ColUnitCost
        '
        Me.ColUnitCost.DataPropertyName = "UnitCost"
        Me.ColUnitCost.HeaderText = "Unit Cost"
        Me.ColUnitCost.Name = "ColUnitCost"
        '
        'ColUnitPrice
        '
        Me.ColUnitPrice.DataPropertyName = "UnitPrice"
        Me.ColUnitPrice.HeaderText = "Unit Price"
        Me.ColUnitPrice.Name = "ColUnitPrice"
        '
        'colConsumableNotes
        '
        Me.colConsumableNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colConsumableNotes.DataPropertyName = "Notes"
        Me.colConsumableNotes.HeaderText = "Notes"
        Me.colConsumableNotes.MaxInputLength = 40
        Me.colConsumableNotes.Name = "colConsumableNotes"
        '
        'ColConsumableItemsSaved
        '
        Me.ColConsumableItemsSaved.ControlCaption = Nothing
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle21.NullValue = False
        Me.ColConsumableItemsSaved.DefaultCellStyle = DataGridViewCellStyle21
        Me.ColConsumableItemsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColConsumableItemsSaved.HeaderText = "Saved"
        Me.ColConsumableItemsSaved.Name = "ColConsumableItemsSaved"
        Me.ColConsumableItemsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColConsumableItemsSaved.SourceColumn = Nothing
        Me.ColConsumableItemsSaved.Width = 50
        '
        'lblVATPercentage
        '
        Me.lblVATPercentage.Location = New System.Drawing.Point(434, 91)
        Me.lblVATPercentage.Name = "lblVATPercentage"
        Me.lblVATPercentage.Size = New System.Drawing.Size(95, 20)
        Me.lblVATPercentage.TabIndex = 22
        Me.lblVATPercentage.Text = "VATPercentage"
        '
        'pnlAlertItems
        '
        Me.pnlAlertItems.Controls.Add(Me.btnViewReceivedDrugs)
        Me.pnlAlertItems.Controls.Add(Me.lblToCompleteItems)
        Me.pnlAlertItems.Location = New System.Drawing.Point(430, 3)
        Me.pnlAlertItems.Name = "pnlAlertItems"
        Me.pnlAlertItems.Size = New System.Drawing.Size(172, 64)
        Me.pnlAlertItems.TabIndex = 19
        '
        'btnViewReceivedDrugs
        '
        Me.btnViewReceivedDrugs.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewReceivedDrugs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewReceivedDrugs.Location = New System.Drawing.Point(6, 4)
        Me.btnViewReceivedDrugs.Name = "btnViewReceivedDrugs"
        Me.btnViewReceivedDrugs.Size = New System.Drawing.Size(68, 24)
        Me.btnViewReceivedDrugs.TabIndex = 0
        Me.btnViewReceivedDrugs.Tag = ""
        Me.btnViewReceivedDrugs.Text = "&View List"
        '
        'lblToCompleteItems
        '
        Me.lblToCompleteItems.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToCompleteItems.ForeColor = System.Drawing.Color.Red
        Me.lblToCompleteItems.Location = New System.Drawing.Point(3, 31)
        Me.lblToCompleteItems.Name = "lblToCompleteItems"
        Me.lblToCompleteItems.Size = New System.Drawing.Size(157, 20)
        Me.lblToCompleteItems.TabIndex = 1
        Me.lblToCompleteItems.Text = "Pending Drugs: 0"
        '
        'frmDrugs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(730, 498)
        Me.Controls.Add(Me.pnlAlertItems)
        Me.Controls.Add(Me.nbxVATPercentage)
        Me.Controls.Add(Me.lblVATPercentage)
        Me.Controls.Add(Me.cboGroupsID)
        Me.Controls.Add(Me.lblGroupsID)
        Me.Controls.Add(Me.pnlInventory)
        Me.Controls.Add(Me.cboDrugNo)
        Me.Controls.Add(Me.stbAlternateName)
        Me.Controls.Add(Me.lblAlternateName)
        Me.Controls.Add(Me.chkHalted)
        Me.Controls.Add(Me.tbcBillExcludedItems)
        Me.Controls.Add(Me.chkHidden)
        Me.Controls.Add(Me.nbxUnitCost)
        Me.Controls.Add(Me.lblUnitCost)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.stbDrugName)
        Me.Controls.Add(Me.nbxUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.nbxKeepingUnit)
        Me.Controls.Add(Me.lblKeepingUnit)
        Me.Controls.Add(Me.nbxOrderLevel)
        Me.Controls.Add(Me.lblOrderLevel)
        Me.Controls.Add(Me.nbxUnitsReceived)
        Me.Controls.Add(Me.lblUnitsReceived)
        Me.Controls.Add(Me.fcbUnitMeasurID)
        Me.Controls.Add(Me.lblUnitMeasureID)
        Me.Controls.Add(Me.fcbCategoryNo)
        Me.Controls.Add(Me.lblCategoryNo)
        Me.Controls.Add(Me.lblDrugName)
        Me.Controls.Add(Me.lblDrugNo)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDrugs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Drugs"
        Me.pnlInventory.ResumeLayout(False)
        Me.pnlInventory.PerformLayout()
        Me.tpgInsuranceCustomFee.ResumeLayout(False)
        CType(Me.dgvInsuranceCustomFee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgBillCustomFee.ResumeLayout(False)
        CType(Me.dgvBillCustomFee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgAlternateDrugs.ResumeLayout(False)
        CType(Me.dgvAlternateDrugs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcBillExcludedItems.ResumeLayout(False)
        Me.tpgItemLocationOrderLevel.ResumeLayout(False)
        CType(Me.dgvItemLocationOrderLevels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPossibleConsumables.ResumeLayout(False)
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAlertItems.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbDrugName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents nbxUnitPrice As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents nbxKeepingUnit As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblKeepingUnit As System.Windows.Forms.Label
    Friend WithEvents nbxOrderLevel As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOrderLevel As System.Windows.Forms.Label
    Friend WithEvents nbxUnitsReceived As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUnitsReceived As System.Windows.Forms.Label
    Friend WithEvents fcbUnitMeasurID As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents lblUnitMeasureID As System.Windows.Forms.Label
    Friend WithEvents fcbCategoryNo As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents lblCategoryNo As System.Windows.Forms.Label
    Friend WithEvents lblDrugName As System.Windows.Forms.Label
    Friend WithEvents lblDrugNo As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents nbxUnitCost As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUnitCost As System.Windows.Forms.Label
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents chkHalted As System.Windows.Forms.CheckBox
    Friend WithEvents stbAlternateName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAlternateName As System.Windows.Forms.Label
    Friend WithEvents cboDrugNo As System.Windows.Forms.ComboBox
    Friend WithEvents pnlInventory As System.Windows.Forms.Panel
    Friend WithEvents dtpExpiryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblExpiryDate As System.Windows.Forms.Label
    Friend WithEvents stbBatchNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBatchNo As System.Windows.Forms.Label
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents cboGroupsID As ComboBox
    Friend WithEvents lblGroupsID As Label
    Friend WithEvents tpgInsuranceCustomFee As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceCustomFee As System.Windows.Forms.DataGridView
    Friend WithEvents colInsuranceName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInsuranceCustomFee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInsuranceCurrenciesID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceCustomFeeSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgBillCustomFee As System.Windows.Forms.TabPage
    Friend WithEvents dgvBillCustomFee As System.Windows.Forms.DataGridView
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colAccountNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomFee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCurrenciesID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colBillCustomFeeSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgAlternateDrugs As System.Windows.Forms.TabPage
    Friend WithEvents dgvAlternateDrugs As System.Windows.Forms.DataGridView
    Friend WithEvents colAlternateDrugName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colAlternateDrugNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAlternateDrugsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tbcBillExcludedItems As System.Windows.Forms.TabControl
    Friend WithEvents tpgItemLocationOrderLevel As System.Windows.Forms.TabPage
    Friend WithEvents dgvItemLocationOrderLevels As System.Windows.Forms.DataGridView
    Friend WithEvents colLocation As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colLocationOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemLocationOrderLevelsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents nbxVATPercentage As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblVATPercentage As Label
    Friend WithEvents pnlAlertItems As System.Windows.Forms.Panel
    Friend WithEvents btnViewReceivedDrugs As System.Windows.Forms.Button
    Friend WithEvents lblToCompleteItems As System.Windows.Forms.Label
    Friend WithEvents tpgPossibleConsumables As System.Windows.Forms.TabPage
    Friend WithEvents dgvConsumables As System.Windows.Forms.DataGridView
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColConsumableItemsSaved As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
End Class
