<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmConsumableItems : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal ConsumableNo As String, ByVal disableCallOnKeyEdit As Boolean)
        MyClass.New()
        Me.defaultConsumableNo = ConsumableNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsumableItems))
        Me.stbConsumableName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxUnitPrice = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxKeepingUnit = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxOrderLevel = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxUnitsReceived = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.fcbUnitMeasurID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.lblKeepingUnit = New System.Windows.Forms.Label()
        Me.lblOrderLevel = New System.Windows.Forms.Label()
        Me.lblUnitsReceived = New System.Windows.Forms.Label()
        Me.lblUnitMeasureID = New System.Windows.Forms.Label()
        Me.lblConsumableName = New System.Windows.Forms.Label()
        Me.lblConsumableNo = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.nbxUnitCost = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.chkHalted = New System.Windows.Forms.CheckBox()
        Me.stbAlternateName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxVATPercentage = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboCategoryNo = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.dgvBillCustomFee = New System.Windows.Forms.DataGridView()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colAccountNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomFee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCurrenciesID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colBillCustomFeeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.tbcBillExcludedItems = New System.Windows.Forms.TabControl()
        Me.tpgBillCustomFee = New System.Windows.Forms.TabPage()
        Me.tpgInsuranceCustomFee = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceCustomFee = New System.Windows.Forms.DataGridView()
        Me.colInsuranceName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInsuranceCustomFee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInsuranceCurrenciesID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceCustomFeeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgItemLocationOrderLevels = New System.Windows.Forms.TabPage()
        Me.dgvItemLocationOrderLevels = New System.Windows.Forms.DataGridView()
        Me.colLocation = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colLocationOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemLocationOrderLevelsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblAlternateName = New System.Windows.Forms.Label()
        Me.cboConsumableNo = New System.Windows.Forms.ComboBox()
        Me.pnlInventory = New System.Windows.Forms.Panel()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.dtpExpiryDate = New System.Windows.Forms.DateTimePicker()
        Me.lblExpiryDate = New System.Windows.Forms.Label()
        Me.stbBatchNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBatchNo = New System.Windows.Forms.Label()
        Me.lblVATPercentage = New System.Windows.Forms.Label()
        Me.lblCategoryNo = New System.Windows.Forms.Label()
        CType(Me.dgvBillCustomFee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcBillExcludedItems.SuspendLayout()
        Me.tpgBillCustomFee.SuspendLayout()
        Me.tpgInsuranceCustomFee.SuspendLayout()
        CType(Me.dgvInsuranceCustomFee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgItemLocationOrderLevels.SuspendLayout()
        CType(Me.dgvItemLocationOrderLevels, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlInventory.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbConsumableName
        '
        Me.stbConsumableName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbConsumableName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbConsumableName, "ConsumableName")
        Me.stbConsumableName.EntryErrorMSG = ""
        Me.stbConsumableName.Location = New System.Drawing.Point(194, 26)
        Me.stbConsumableName.MaxLength = 100
        Me.stbConsumableName.Name = "stbConsumableName"
        Me.stbConsumableName.RegularExpression = ""
        Me.stbConsumableName.Size = New System.Drawing.Size(201, 20)
        Me.stbConsumableName.TabIndex = 3
        '
        'nbxUnitPrice
        '
        Me.nbxUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitPrice.ControlCaption = "Unit Price"
        Me.nbxUnitPrice.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxUnitPrice, "UnitPrice")
        Me.nbxUnitPrice.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxUnitPrice.DecimalPlaces = -1
        Me.nbxUnitPrice.Location = New System.Drawing.Point(538, 69)
        Me.nbxUnitPrice.MaxValue = 0.0R
        Me.nbxUnitPrice.MinValue = 0.0R
        Me.nbxUnitPrice.MustEnterNumeric = True
        Me.nbxUnitPrice.Name = "nbxUnitPrice"
        Me.nbxUnitPrice.Size = New System.Drawing.Size(201, 20)
        Me.nbxUnitPrice.TabIndex = 22
        Me.nbxUnitPrice.Tag = "ConsumablePrices"
        Me.nbxUnitPrice.Value = ""
        '
        'nbxKeepingUnit
        '
        Me.nbxKeepingUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxKeepingUnit.ControlCaption = "Keeping Unit"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxKeepingUnit, "KeepingUnit")
        Me.nbxKeepingUnit.DecimalPlaces = -1
        Me.nbxKeepingUnit.Location = New System.Drawing.Point(194, 135)
        Me.nbxKeepingUnit.MaxValue = 0.0R
        Me.nbxKeepingUnit.MinValue = 0.0R
        Me.nbxKeepingUnit.MustEnterNumeric = True
        Me.nbxKeepingUnit.Name = "nbxKeepingUnit"
        Me.nbxKeepingUnit.Size = New System.Drawing.Size(201, 20)
        Me.nbxKeepingUnit.TabIndex = 13
        Me.nbxKeepingUnit.Value = ""
        '
        'nbxOrderLevel
        '
        Me.nbxOrderLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOrderLevel.ControlCaption = "Order Level"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxOrderLevel, "OrderLevel")
        Me.nbxOrderLevel.DecimalPlaces = -1
        Me.nbxOrderLevel.Location = New System.Drawing.Point(194, 114)
        Me.nbxOrderLevel.MaxValue = 0.0R
        Me.nbxOrderLevel.MinValue = 0.0R
        Me.nbxOrderLevel.MustEnterNumeric = True
        Me.nbxOrderLevel.Name = "nbxOrderLevel"
        Me.nbxOrderLevel.Size = New System.Drawing.Size(201, 20)
        Me.nbxOrderLevel.TabIndex = 11
        Me.nbxOrderLevel.Value = ""
        '
        'nbxUnitsReceived
        '
        Me.nbxUnitsReceived.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitsReceived.ControlCaption = "Units Received"
        Me.nbxUnitsReceived.DecimalPlaces = -1
        Me.nbxUnitsReceived.Location = New System.Drawing.Point(194, 156)
        Me.nbxUnitsReceived.MaxValue = 0.0R
        Me.nbxUnitsReceived.MinValue = 0.0R
        Me.nbxUnitsReceived.MustEnterNumeric = True
        Me.nbxUnitsReceived.Name = "nbxUnitsReceived"
        Me.nbxUnitsReceived.Size = New System.Drawing.Size(201, 20)
        Me.nbxUnitsReceived.TabIndex = 15
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
        Me.fcbUnitMeasurID.Location = New System.Drawing.Point(194, 91)
        Me.fcbUnitMeasurID.Name = "fcbUnitMeasurID"
        Me.fcbUnitMeasurID.ReadOnly = True
        Me.fcbUnitMeasurID.Size = New System.Drawing.Size(201, 21)
        Me.fcbUnitMeasurID.TabIndex = 9
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(678, 504)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(79, 24)
        Me.fbnClose.TabIndex = 29
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Location = New System.Drawing.Point(406, 69)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(126, 20)
        Me.lblUnitPrice.TabIndex = 21
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'lblKeepingUnit
        '
        Me.lblKeepingUnit.Location = New System.Drawing.Point(12, 135)
        Me.lblKeepingUnit.Name = "lblKeepingUnit"
        Me.lblKeepingUnit.Size = New System.Drawing.Size(140, 20)
        Me.lblKeepingUnit.TabIndex = 12
        Me.lblKeepingUnit.Text = "Keeping Unit"
        '
        'lblOrderLevel
        '
        Me.lblOrderLevel.Location = New System.Drawing.Point(12, 114)
        Me.lblOrderLevel.Name = "lblOrderLevel"
        Me.lblOrderLevel.Size = New System.Drawing.Size(140, 20)
        Me.lblOrderLevel.TabIndex = 10
        Me.lblOrderLevel.Text = "Order Level"
        '
        'lblUnitsReceived
        '
        Me.lblUnitsReceived.Location = New System.Drawing.Point(12, 156)
        Me.lblUnitsReceived.Name = "lblUnitsReceived"
        Me.lblUnitsReceived.Size = New System.Drawing.Size(140, 20)
        Me.lblUnitsReceived.TabIndex = 14
        Me.lblUnitsReceived.Text = "Units Received"
        '
        'lblUnitMeasureID
        '
        Me.lblUnitMeasureID.Location = New System.Drawing.Point(12, 91)
        Me.lblUnitMeasureID.Name = "lblUnitMeasureID"
        Me.lblUnitMeasureID.Size = New System.Drawing.Size(140, 20)
        Me.lblUnitMeasureID.TabIndex = 8
        Me.lblUnitMeasureID.Text = "Unit Measure"
        '
        'lblConsumableName
        '
        Me.lblConsumableName.Location = New System.Drawing.Point(12, 26)
        Me.lblConsumableName.Name = "lblConsumableName"
        Me.lblConsumableName.Size = New System.Drawing.Size(140, 20)
        Me.lblConsumableName.TabIndex = 2
        Me.lblConsumableName.Text = "Consumable Name"
        '
        'lblConsumableNo
        '
        Me.lblConsumableNo.Location = New System.Drawing.Point(12, 5)
        Me.lblConsumableNo.Name = "lblConsumableNo"
        Me.lblConsumableNo.Size = New System.Drawing.Size(140, 20)
        Me.lblConsumableNo.TabIndex = 0
        Me.lblConsumableNo.Text = "Consumable Number"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(19, 478)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 26
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(678, 478)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(79, 24)
        Me.fbnDelete.TabIndex = 28
        Me.fbnDelete.Tag = "ConsumableItems"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(19, 503)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 27
        Me.ebnSaveUpdate.Tag = "ConsumableItems"
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
        Me.nbxUnitCost.Location = New System.Drawing.Point(538, 26)
        Me.nbxUnitCost.MaxValue = 0.0R
        Me.nbxUnitCost.MinValue = 0.0R
        Me.nbxUnitCost.MustEnterNumeric = True
        Me.nbxUnitCost.Name = "nbxUnitCost"
        Me.nbxUnitCost.Size = New System.Drawing.Size(201, 20)
        Me.nbxUnitCost.TabIndex = 18
        Me.nbxUnitCost.Tag = "ConsumablePrices"
        Me.nbxUnitCost.Value = ""
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHidden, "Hidden")
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(580, 95)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(159, 20)
        Me.chkHidden.TabIndex = 24
        Me.chkHidden.Text = "Hidden"
        '
        'chkHalted
        '
        Me.chkHalted.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHalted, "Halted")
        Me.chkHalted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHalted.Location = New System.Drawing.Point(406, 94)
        Me.chkHalted.Name = "chkHalted"
        Me.chkHalted.Size = New System.Drawing.Size(135, 20)
        Me.chkHalted.TabIndex = 23
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
        Me.stbAlternateName.Size = New System.Drawing.Size(201, 20)
        Me.stbAlternateName.TabIndex = 5
        '
        'nbxVATPercentage
        '
        Me.nbxVATPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxVATPercentage.ControlCaption = "VAT Percentage"
        Me.nbxVATPercentage.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxVATPercentage, "VATPercentage")
        Me.nbxVATPercentage.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxVATPercentage.DecimalPlaces = -1
        Me.nbxVATPercentage.Location = New System.Drawing.Point(538, 47)
        Me.nbxVATPercentage.MaxValue = 0.0R
        Me.nbxVATPercentage.MinValue = 0.0R
        Me.nbxVATPercentage.MustEnterNumeric = True
        Me.nbxVATPercentage.Name = "nbxVATPercentage"
        Me.nbxVATPercentage.Size = New System.Drawing.Size(201, 20)
        Me.nbxVATPercentage.TabIndex = 20
        Me.nbxVATPercentage.Tag = "ConsumablePrices"
        Me.nbxVATPercentage.Value = ""
        '
        'cboCategoryNo
        '
        Me.cboCategoryNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCategoryNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboCategoryNo, "CategoryName")
        Me.cboCategoryNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCategoryNo.FormattingEnabled = True
        Me.cboCategoryNo.Location = New System.Drawing.Point(194, 68)
        Me.cboCategoryNo.Name = "cboCategoryNo"
        Me.cboCategoryNo.ReadOnly = True
        Me.cboCategoryNo.Size = New System.Drawing.Size(201, 21)
        Me.cboCategoryNo.TabIndex = 7
        '
        'dgvBillCustomFee
        '
        Me.dgvBillCustomFee.AllowUserToOrderColumns = True
        Me.dgvBillCustomFee.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillCustomFee.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBillCustomFee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBillCustomerName, Me.colAccountNo, Me.colBillCustomFee, Me.colBillCurrenciesID, Me.colBillCustomFeeSaved})
        Me.dgvBillCustomFee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvBillCustomFee.EnableHeadersVisualStyles = False
        Me.dgvBillCustomFee.GridColor = System.Drawing.Color.Khaki
        Me.dgvBillCustomFee.Location = New System.Drawing.Point(0, 0)
        Me.dgvBillCustomFee.Name = "dgvBillCustomFee"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBillCustomFee.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvBillCustomFee.Size = New System.Drawing.Size(734, 185)
        Me.dgvBillCustomFee.TabIndex = 0
        Me.dgvBillCustomFee.Tag = "ConsumablePrices"
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
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colAccountNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colAccountNo.HeaderText = "Account No"
        Me.colAccountNo.Name = "colAccountNo"
        Me.colAccountNo.ReadOnly = True
        '
        'colBillCustomFee
        '
        Me.colBillCustomFee.DataPropertyName = "CustomFee"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colBillCustomFee.DefaultCellStyle = DataGridViewCellStyle3
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
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.NullValue = False
        Me.colBillCustomFeeSaved.DefaultCellStyle = DataGridViewCellStyle4
        Me.colBillCustomFeeSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colBillCustomFeeSaved.HeaderText = "Saved"
        Me.colBillCustomFeeSaved.Name = "colBillCustomFeeSaved"
        Me.colBillCustomFeeSaved.ReadOnly = True
        Me.colBillCustomFeeSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colBillCustomFeeSaved.Width = 50
        '
        'lblUnitCost
        '
        Me.lblUnitCost.Location = New System.Drawing.Point(406, 26)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(126, 20)
        Me.lblUnitCost.TabIndex = 17
        Me.lblUnitCost.Text = "Unit Cost"
        '
        'tbcBillExcludedItems
        '
        Me.tbcBillExcludedItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgBillCustomFee)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgInsuranceCustomFee)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgItemLocationOrderLevels)
        Me.tbcBillExcludedItems.HotTrack = True
        Me.tbcBillExcludedItems.Location = New System.Drawing.Point(5, 257)
        Me.tbcBillExcludedItems.Name = "tbcBillExcludedItems"
        Me.tbcBillExcludedItems.SelectedIndex = 0
        Me.tbcBillExcludedItems.Size = New System.Drawing.Size(752, 215)
        Me.tbcBillExcludedItems.TabIndex = 25
        '
        'tpgBillCustomFee
        '
        Me.tpgBillCustomFee.Controls.Add(Me.dgvBillCustomFee)
        Me.tpgBillCustomFee.Location = New System.Drawing.Point(4, 22)
        Me.tpgBillCustomFee.Name = "tpgBillCustomFee"
        Me.tpgBillCustomFee.Size = New System.Drawing.Size(734, 185)
        Me.tpgBillCustomFee.TabIndex = 2
        Me.tpgBillCustomFee.Tag = "BillCustomFee"
        Me.tpgBillCustomFee.Text = "Bill Custom Fee"
        Me.tpgBillCustomFee.UseVisualStyleBackColor = True
        '
        'tpgInsuranceCustomFee
        '
        Me.tpgInsuranceCustomFee.Controls.Add(Me.dgvInsuranceCustomFee)
        Me.tpgInsuranceCustomFee.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceCustomFee.Name = "tpgInsuranceCustomFee"
        Me.tpgInsuranceCustomFee.Size = New System.Drawing.Size(744, 189)
        Me.tpgInsuranceCustomFee.TabIndex = 1
        Me.tpgInsuranceCustomFee.Tag = "InsuranceCustomFee"
        Me.tpgInsuranceCustomFee.Text = "Insurance Custom Fee"
        Me.tpgInsuranceCustomFee.UseVisualStyleBackColor = True
        '
        'dgvInsuranceCustomFee
        '
        Me.dgvInsuranceCustomFee.AllowUserToOrderColumns = True
        Me.dgvInsuranceCustomFee.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceCustomFee.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvInsuranceCustomFee.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInsuranceName, Me.colInsuranceNo, Me.colInsuranceCustomFee, Me.colInsuranceCurrenciesID, Me.colInsuranceCustomFeeSaved})
        Me.dgvInsuranceCustomFee.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceCustomFee.EnableHeadersVisualStyles = False
        Me.dgvInsuranceCustomFee.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceCustomFee.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceCustomFee.Name = "dgvInsuranceCustomFee"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceCustomFee.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvInsuranceCustomFee.Size = New System.Drawing.Size(744, 189)
        Me.dgvInsuranceCustomFee.TabIndex = 0
        Me.dgvInsuranceCustomFee.Tag = "ConsumablePrices"
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
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colInsuranceNo.DefaultCellStyle = DataGridViewCellStyle7
        Me.colInsuranceNo.HeaderText = "Insurance No"
        Me.colInsuranceNo.Name = "colInsuranceNo"
        Me.colInsuranceNo.ReadOnly = True
        '
        'colInsuranceCustomFee
        '
        Me.colInsuranceCustomFee.DataPropertyName = "CustomFee"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.colInsuranceCustomFee.DefaultCellStyle = DataGridViewCellStyle8
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
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = False
        Me.colInsuranceCustomFeeSaved.DefaultCellStyle = DataGridViewCellStyle9
        Me.colInsuranceCustomFeeSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceCustomFeeSaved.HeaderText = "Saved"
        Me.colInsuranceCustomFeeSaved.Name = "colInsuranceCustomFeeSaved"
        Me.colInsuranceCustomFeeSaved.ReadOnly = True
        Me.colInsuranceCustomFeeSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceCustomFeeSaved.Width = 50
        '
        'tpgItemLocationOrderLevels
        '
        Me.tpgItemLocationOrderLevels.Controls.Add(Me.dgvItemLocationOrderLevels)
        Me.tpgItemLocationOrderLevels.Location = New System.Drawing.Point(4, 22)
        Me.tpgItemLocationOrderLevels.Name = "tpgItemLocationOrderLevels"
        Me.tpgItemLocationOrderLevels.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgItemLocationOrderLevels.Size = New System.Drawing.Size(744, 189)
        Me.tpgItemLocationOrderLevels.TabIndex = 3
        Me.tpgItemLocationOrderLevels.Text = "Location Order Level"
        Me.tpgItemLocationOrderLevels.UseVisualStyleBackColor = True
        '
        'dgvItemLocationOrderLevels
        '
        Me.dgvItemLocationOrderLevels.AllowUserToOrderColumns = True
        Me.dgvItemLocationOrderLevels.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemLocationOrderLevels.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvItemLocationOrderLevels.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colLocation, Me.colLocationOrderLevel, Me.colItemLocationOrderLevelsSaved})
        Me.dgvItemLocationOrderLevels.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvItemLocationOrderLevels.EnableHeadersVisualStyles = False
        Me.dgvItemLocationOrderLevels.GridColor = System.Drawing.Color.Khaki
        Me.dgvItemLocationOrderLevels.Location = New System.Drawing.Point(3, 3)
        Me.dgvItemLocationOrderLevels.Name = "dgvItemLocationOrderLevels"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItemLocationOrderLevels.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvItemLocationOrderLevels.Size = New System.Drawing.Size(738, 183)
        Me.dgvItemLocationOrderLevels.TabIndex = 0
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
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.Format = "N2"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.colLocationOrderLevel.DefaultCellStyle = DataGridViewCellStyle12
        Me.colLocationOrderLevel.HeaderText = "Order Level"
        Me.colLocationOrderLevel.MaxInputLength = 12
        Me.colLocationOrderLevel.Name = "colLocationOrderLevel"
        '
        'colItemLocationOrderLevelsSaved
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle13.NullValue = False
        Me.colItemLocationOrderLevelsSaved.DefaultCellStyle = DataGridViewCellStyle13
        Me.colItemLocationOrderLevelsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colItemLocationOrderLevelsSaved.HeaderText = "Saved"
        Me.colItemLocationOrderLevelsSaved.Name = "colItemLocationOrderLevelsSaved"
        Me.colItemLocationOrderLevelsSaved.ReadOnly = True
        Me.colItemLocationOrderLevelsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colItemLocationOrderLevelsSaved.Width = 50
        '
        'lblAlternateName
        '
        Me.lblAlternateName.Location = New System.Drawing.Point(12, 47)
        Me.lblAlternateName.Name = "lblAlternateName"
        Me.lblAlternateName.Size = New System.Drawing.Size(140, 20)
        Me.lblAlternateName.TabIndex = 4
        Me.lblAlternateName.Text = "Alternate Name"
        '
        'cboConsumableNo
        '
        Me.cboConsumableNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboConsumableNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboConsumableNo.DropDownWidth = 300
        Me.cboConsumableNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboConsumableNo.FormattingEnabled = True
        Me.cboConsumableNo.Location = New System.Drawing.Point(194, 3)
        Me.cboConsumableNo.MaxLength = 40
        Me.cboConsumableNo.Name = "cboConsumableNo"
        Me.cboConsumableNo.Size = New System.Drawing.Size(201, 21)
        Me.cboConsumableNo.TabIndex = 1
        '
        'pnlInventory
        '
        Me.pnlInventory.Controls.Add(Me.cboLocationID)
        Me.pnlInventory.Controls.Add(Me.lblLocationID)
        Me.pnlInventory.Controls.Add(Me.dtpExpiryDate)
        Me.pnlInventory.Controls.Add(Me.lblExpiryDate)
        Me.pnlInventory.Controls.Add(Me.stbBatchNo)
        Me.pnlInventory.Controls.Add(Me.lblBatchNo)
        Me.pnlInventory.Location = New System.Drawing.Point(5, 178)
        Me.pnlInventory.Name = "pnlInventory"
        Me.pnlInventory.Size = New System.Drawing.Size(404, 73)
        Me.pnlInventory.TabIndex = 16
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(189, 4)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(201, 21)
        Me.cboLocationID.TabIndex = 1
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(8, 5)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(140, 21)
        Me.lblLocationID.TabIndex = 0
        Me.lblLocationID.Text = "Location"
        '
        'dtpExpiryDate
        '
        Me.dtpExpiryDate.Checked = False
        Me.dtpExpiryDate.Location = New System.Drawing.Point(189, 48)
        Me.dtpExpiryDate.Name = "dtpExpiryDate"
        Me.dtpExpiryDate.ShowCheckBox = True
        Me.dtpExpiryDate.Size = New System.Drawing.Size(201, 20)
        Me.dtpExpiryDate.TabIndex = 5
        '
        'lblExpiryDate
        '
        Me.lblExpiryDate.Location = New System.Drawing.Point(8, 48)
        Me.lblExpiryDate.Name = "lblExpiryDate"
        Me.lblExpiryDate.Size = New System.Drawing.Size(140, 21)
        Me.lblExpiryDate.TabIndex = 4
        Me.lblExpiryDate.Text = "Expiry Date"
        '
        'stbBatchNo
        '
        Me.stbBatchNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBatchNo.CapitalizeFirstLetter = False
        Me.stbBatchNo.EntryErrorMSG = ""
        Me.stbBatchNo.Location = New System.Drawing.Point(189, 27)
        Me.stbBatchNo.MaxLength = 20
        Me.stbBatchNo.Name = "stbBatchNo"
        Me.stbBatchNo.RegularExpression = ""
        Me.stbBatchNo.Size = New System.Drawing.Size(201, 20)
        Me.stbBatchNo.TabIndex = 3
        '
        'lblBatchNo
        '
        Me.lblBatchNo.Location = New System.Drawing.Point(8, 28)
        Me.lblBatchNo.Name = "lblBatchNo"
        Me.lblBatchNo.Size = New System.Drawing.Size(140, 21)
        Me.lblBatchNo.TabIndex = 2
        Me.lblBatchNo.Text = "Batch No"
        '
        'lblVATPercentage
        '
        Me.lblVATPercentage.Location = New System.Drawing.Point(406, 47)
        Me.lblVATPercentage.Name = "lblVATPercentage"
        Me.lblVATPercentage.Size = New System.Drawing.Size(126, 20)
        Me.lblVATPercentage.TabIndex = 19
        Me.lblVATPercentage.Text = "VAT Percentage"
        '
        'lblCategoryNo
        '
        Me.lblCategoryNo.Location = New System.Drawing.Point(12, 68)
        Me.lblCategoryNo.Name = "lblCategoryNo"
        Me.lblCategoryNo.Size = New System.Drawing.Size(140, 21)
        Me.lblCategoryNo.TabIndex = 6
        Me.lblCategoryNo.Text = "Consumable Category"
        '
        'frmConsumableItems
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(769, 544)
        Me.Controls.Add(Me.cboCategoryNo)
        Me.Controls.Add(Me.lblCategoryNo)
        Me.Controls.Add(Me.nbxVATPercentage)
        Me.Controls.Add(Me.lblVATPercentage)
        Me.Controls.Add(Me.pnlInventory)
        Me.Controls.Add(Me.cboConsumableNo)
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
        Me.Controls.Add(Me.stbConsumableName)
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
        Me.Controls.Add(Me.lblConsumableName)
        Me.Controls.Add(Me.lblConsumableNo)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmConsumableItems"
        Me.Text = "Consumable Items"
        CType(Me.dgvBillCustomFee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcBillExcludedItems.ResumeLayout(False)
        Me.tpgBillCustomFee.ResumeLayout(False)
        Me.tpgInsuranceCustomFee.ResumeLayout(False)
        CType(Me.dgvInsuranceCustomFee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgItemLocationOrderLevels.ResumeLayout(False)
        CType(Me.dgvItemLocationOrderLevels, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlInventory.ResumeLayout(False)
        Me.pnlInventory.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbConsumableName As SyncSoft.Common.Win.Controls.SmartTextBox
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
    Friend WithEvents lblConsumableName As System.Windows.Forms.Label
    Friend WithEvents lblConsumableNo As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents dgvBillCustomFee As System.Windows.Forms.DataGridView
    Friend WithEvents nbxUnitCost As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUnitCost As System.Windows.Forms.Label
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents tbcBillExcludedItems As System.Windows.Forms.TabControl
    Friend WithEvents tpgBillCustomFee As System.Windows.Forms.TabPage
    Friend WithEvents tpgInsuranceCustomFee As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceCustomFee As System.Windows.Forms.DataGridView
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colAccountNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomFee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCurrenciesID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colBillCustomFeeSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colInsuranceName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInsuranceCustomFee As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInsuranceCurrenciesID As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceCustomFeeSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkHalted As System.Windows.Forms.CheckBox
    Friend WithEvents stbAlternateName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAlternateName As System.Windows.Forms.Label
    Friend WithEvents cboConsumableNo As System.Windows.Forms.ComboBox
    Friend WithEvents pnlInventory As System.Windows.Forms.Panel
    Friend WithEvents dtpExpiryDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblExpiryDate As System.Windows.Forms.Label
    Friend WithEvents stbBatchNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBatchNo As System.Windows.Forms.Label
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents tpgItemLocationOrderLevels As System.Windows.Forms.TabPage
    Friend WithEvents dgvItemLocationOrderLevels As System.Windows.Forms.DataGridView
    Friend WithEvents colLocation As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colLocationOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemLocationOrderLevelsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents nbxVATPercentage As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblVATPercentage As Label
    Friend WithEvents cboCategoryNo As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents lblCategoryNo As System.Windows.Forms.Label
End Class
