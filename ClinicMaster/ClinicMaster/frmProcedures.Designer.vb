
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcedures : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcedures))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbProcedureName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxUnitPrice = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.stbShortName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxVATPercentage = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxUnitCost = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboCategoryID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblProcedureCode = New System.Windows.Forms.Label()
        Me.lblProcedureName = New System.Windows.Forms.Label()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.lblShortName = New System.Windows.Forms.Label()
        Me.tbcBillExcludedItems = New System.Windows.Forms.TabControl()
        Me.tpgBillCustomFee = New System.Windows.Forms.TabPage()
        Me.dgvBillCustomFee = New System.Windows.Forms.DataGridView()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colAccountNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomFee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCurrenciesID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colBillCustomFeeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgInsuranceCustomFee = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceCustomFee = New System.Windows.Forms.DataGridView()
        Me.colInsuranceName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInsuranceCustomFee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInsuranceCurrenciesID = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceCustomFeeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgPossiblePrescription = New System.Windows.Forms.TabPage()
        Me.dgvPrescription = New System.Windows.Forms.DataGridView()
        Me.colDrug = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.ColDrugDosage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDrugUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDrugUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgPossibleConsumables = New System.Windows.Forms.TabPage()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColConUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColConsUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColConsumableItemsSaved = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.tpgPossibleTheatreServices = New System.Windows.Forms.TabPage()
        Me.dgvTheatre = New System.Windows.Forms.DataGridView()
        Me.colTheatreCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colTheatreQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTheatreUnitCost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTheatreUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTheatreSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cboProcedureCode = New System.Windows.Forms.ComboBox()
        Me.lblVATPercentage = New System.Windows.Forms.Label()
        Me.LabelUnitCost = New System.Windows.Forms.Label()
        Me.lblProcedureCategoryID = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintOnSaving = New System.Windows.Forms.CheckBox()
        Me.tbcBillExcludedItems.SuspendLayout()
        Me.tpgBillCustomFee.SuspendLayout()
        CType(Me.dgvBillCustomFee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInsuranceCustomFee.SuspendLayout()
        CType(Me.dgvInsuranceCustomFee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPossiblePrescription.SuspendLayout()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPossibleConsumables.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgPossibleTheatreServices.SuspendLayout()
        CType(Me.dgvTheatre, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(2, 497)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 16
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(643, 496)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 18
        Me.fbnDelete.Tag = "Procedures"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(2, 524)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 17
        Me.ebnSaveUpdate.Tag = "Procedures"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbProcedureName
        '
        Me.stbProcedureName.AcceptsReturn = True
        Me.stbProcedureName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbProcedureName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbProcedureName, "ProcedureName")
        Me.stbProcedureName.EntryErrorMSG = ""
        Me.stbProcedureName.Location = New System.Drawing.Point(176, 35)
        Me.stbProcedureName.MaxLength = 800
        Me.stbProcedureName.Multiline = True
        Me.stbProcedureName.Name = "stbProcedureName"
        Me.stbProcedureName.RegularExpression = ""
        Me.stbProcedureName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbProcedureName.Size = New System.Drawing.Size(272, 51)
        Me.stbProcedureName.TabIndex = 3
        Me.stbProcedureName.Tag = "ProcedureName"
        '
        'nbxUnitPrice
        '
        Me.nbxUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitPrice.ControlCaption = "Unit Price"
        Me.nbxUnitPrice.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxUnitPrice, "UnitPrice")
        Me.nbxUnitPrice.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxUnitPrice.DecimalPlaces = 2
        Me.nbxUnitPrice.Location = New System.Drawing.Point(176, 175)
        Me.nbxUnitPrice.MaxLength = 12
        Me.nbxUnitPrice.MaxValue = 0.0R
        Me.nbxUnitPrice.MinValue = 0.0R
        Me.nbxUnitPrice.MustEnterNumeric = True
        Me.nbxUnitPrice.Name = "nbxUnitPrice"
        Me.nbxUnitPrice.Size = New System.Drawing.Size(272, 20)
        Me.nbxUnitPrice.TabIndex = 11
        Me.nbxUnitPrice.Tag = "ProceduresPrices"
        Me.nbxUnitPrice.Value = ""
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHidden, "Hidden")
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(19, 221)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(168, 20)
        Me.chkHidden.TabIndex = 14
        Me.chkHidden.Text = "Hidden"
        '
        'stbShortName
        '
        Me.stbShortName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbShortName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbShortName, "ShortName")
        Me.stbShortName.EntryErrorMSG = ""
        Me.stbShortName.Location = New System.Drawing.Point(176, 89)
        Me.stbShortName.Multiline = True
        Me.stbShortName.Name = "stbShortName"
        Me.stbShortName.RegularExpression = ""
        Me.stbShortName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbShortName.Size = New System.Drawing.Size(272, 37)
        Me.stbShortName.TabIndex = 5
        Me.stbShortName.Tag = "ProcedureName"
        '
        'nbxVATPercentage
        '
        Me.nbxVATPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxVATPercentage.ControlCaption = "VATPercentage"
        Me.nbxVATPercentage.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxVATPercentage, "VATPercentage")
        Me.nbxVATPercentage.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxVATPercentage.DecimalPlaces = -1
        Me.nbxVATPercentage.Location = New System.Drawing.Point(176, 197)
        Me.nbxVATPercentage.MaxValue = 0.0R
        Me.nbxVATPercentage.MinValue = 0.0R
        Me.nbxVATPercentage.MustEnterNumeric = True
        Me.nbxVATPercentage.Name = "nbxVATPercentage"
        Me.nbxVATPercentage.Size = New System.Drawing.Size(272, 20)
        Me.nbxVATPercentage.TabIndex = 13
        Me.nbxVATPercentage.Tag = "ProceduresPrices"
        Me.nbxVATPercentage.Value = ""
        '
        'nbxUnitCost
        '
        Me.nbxUnitCost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitCost.ControlCaption = "Unit Cost"
        Me.nbxUnitCost.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxUnitCost, "UnitCost")
        Me.nbxUnitCost.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxUnitCost.DecimalPlaces = -1
        Me.nbxUnitCost.Location = New System.Drawing.Point(176, 153)
        Me.nbxUnitCost.MaxLength = 12
        Me.nbxUnitCost.MaxValue = 0.0R
        Me.nbxUnitCost.MinValue = 0.0R
        Me.nbxUnitCost.MustEnterNumeric = True
        Me.nbxUnitCost.Name = "nbxUnitCost"
        Me.nbxUnitCost.Size = New System.Drawing.Size(272, 20)
        Me.nbxUnitCost.TabIndex = 9
        Me.nbxUnitCost.Tag = "LabPrices"
        Me.nbxUnitCost.Value = ""
        '
        'cboCategoryID
        '
        Me.cboCategoryID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCategoryID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboCategoryID, "ProcedureCategory,ProcedureCategoryID")
        Me.cboCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCategoryID.FormattingEnabled = True
        Me.cboCategoryID.Location = New System.Drawing.Point(176, 128)
        Me.cboCategoryID.Name = "cboCategoryID"
        Me.cboCategoryID.Size = New System.Drawing.Size(272, 21)
        Me.cboCategoryID.TabIndex = 7
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(643, 523)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 19
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblProcedureCode
        '
        Me.lblProcedureCode.Location = New System.Drawing.Point(19, 12)
        Me.lblProcedureCode.Name = "lblProcedureCode"
        Me.lblProcedureCode.Size = New System.Drawing.Size(147, 20)
        Me.lblProcedureCode.TabIndex = 0
        Me.lblProcedureCode.Text = "Procedure Code"
        '
        'lblProcedureName
        '
        Me.lblProcedureName.Location = New System.Drawing.Point(19, 52)
        Me.lblProcedureName.Name = "lblProcedureName"
        Me.lblProcedureName.Size = New System.Drawing.Size(147, 20)
        Me.lblProcedureName.TabIndex = 2
        Me.lblProcedureName.Text = "Procedure Name"
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Location = New System.Drawing.Point(19, 175)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(147, 20)
        Me.lblUnitPrice.TabIndex = 10
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'lblShortName
        '
        Me.lblShortName.Location = New System.Drawing.Point(19, 94)
        Me.lblShortName.Name = "lblShortName"
        Me.lblShortName.Size = New System.Drawing.Size(147, 20)
        Me.lblShortName.TabIndex = 4
        Me.lblShortName.Text = "Short Name"
        '
        'tbcBillExcludedItems
        '
        Me.tbcBillExcludedItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgBillCustomFee)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgInsuranceCustomFee)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgPossiblePrescription)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgPossibleConsumables)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgPossibleTheatreServices)
        Me.tbcBillExcludedItems.HotTrack = True
        Me.tbcBillExcludedItems.Location = New System.Drawing.Point(2, 247)
        Me.tbcBillExcludedItems.Name = "tbcBillExcludedItems"
        Me.tbcBillExcludedItems.SelectedIndex = 0
        Me.tbcBillExcludedItems.Size = New System.Drawing.Size(717, 243)
        Me.tbcBillExcludedItems.TabIndex = 15
        '
        'tpgBillCustomFee
        '
        Me.tpgBillCustomFee.Controls.Add(Me.dgvBillCustomFee)
        Me.tpgBillCustomFee.Location = New System.Drawing.Point(4, 22)
        Me.tpgBillCustomFee.Name = "tpgBillCustomFee"
        Me.tpgBillCustomFee.Size = New System.Drawing.Size(709, 217)
        Me.tpgBillCustomFee.TabIndex = 2
        Me.tpgBillCustomFee.Tag = "BillCustomFee"
        Me.tpgBillCustomFee.Text = "Bill Custom Fee"
        Me.tpgBillCustomFee.UseVisualStyleBackColor = True
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
        Me.dgvBillCustomFee.Size = New System.Drawing.Size(709, 217)
        Me.dgvBillCustomFee.TabIndex = 0
        Me.dgvBillCustomFee.Tag = "ProceduresPrices"
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
        'tpgInsuranceCustomFee
        '
        Me.tpgInsuranceCustomFee.Controls.Add(Me.dgvInsuranceCustomFee)
        Me.tpgInsuranceCustomFee.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceCustomFee.Name = "tpgInsuranceCustomFee"
        Me.tpgInsuranceCustomFee.Size = New System.Drawing.Size(709, 217)
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
        Me.dgvInsuranceCustomFee.Size = New System.Drawing.Size(709, 217)
        Me.dgvInsuranceCustomFee.TabIndex = 0
        Me.dgvInsuranceCustomFee.Tag = "ProceduresPrices"
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
        'tpgPossiblePrescription
        '
        Me.tpgPossiblePrescription.Controls.Add(Me.dgvPrescription)
        Me.tpgPossiblePrescription.Location = New System.Drawing.Point(4, 22)
        Me.tpgPossiblePrescription.Name = "tpgPossiblePrescription"
        Me.tpgPossiblePrescription.Size = New System.Drawing.Size(709, 217)
        Me.tpgPossiblePrescription.TabIndex = 4
        Me.tpgPossiblePrescription.Text = "Possible Prescription"
        Me.tpgPossiblePrescription.UseVisualStyleBackColor = True
        '
        'dgvPrescription
        '
        Me.dgvPrescription.AllowUserToOrderColumns = True
        Me.dgvPrescription.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvPrescription.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrug, Me.ColDrugDosage, Me.ColDuration, Me.colDrugQuantity, Me.ColDrugUnitCost, Me.ColDrugUnitPrice, Me.colDrugNotes, Me.colPrescriptionSaved})
        Me.dgvPrescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPrescription.EnableHeadersVisualStyles = False
        Me.dgvPrescription.GridColor = System.Drawing.Color.Khaki
        Me.dgvPrescription.Location = New System.Drawing.Point(0, 0)
        Me.dgvPrescription.Name = "dgvPrescription"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvPrescription.Size = New System.Drawing.Size(709, 217)
        Me.dgvPrescription.TabIndex = 0
        Me.dgvPrescription.Text = "DataGridView1"
        '
        'colDrug
        '
        Me.colDrug.DataPropertyName = "DrugFullName"
        Me.colDrug.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDrug.DisplayStyleForCurrentCellOnly = True
        Me.colDrug.DropDownWidth = 10
        Me.colDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrug.HeaderText = "Drug"
        Me.colDrug.Name = "colDrug"
        Me.colDrug.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDrug.Width = 150
        '
        'ColDrugDosage
        '
        Me.ColDrugDosage.DataPropertyName = "Dosage"
        Me.ColDrugDosage.HeaderText = "Dosage"
        Me.ColDrugDosage.Name = "ColDrugDosage"
        Me.ColDrugDosage.Width = 65
        '
        'ColDuration
        '
        Me.ColDuration.DataPropertyName = "Duration"
        Me.ColDuration.HeaderText = "Duration"
        Me.ColDuration.Name = "ColDuration"
        Me.ColDuration.Width = 65
        '
        'colDrugQuantity
        '
        Me.colDrugQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle12
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.Width = 65
        '
        'ColDrugUnitCost
        '
        Me.ColDrugUnitCost.DataPropertyName = "UnitCost"
        Me.ColDrugUnitCost.HeaderText = "Unit Cost"
        Me.ColDrugUnitCost.Name = "ColDrugUnitCost"
        Me.ColDrugUnitCost.Width = 70
        '
        'ColDrugUnitPrice
        '
        Me.ColDrugUnitPrice.DataPropertyName = "UnitPrice"
        Me.ColDrugUnitPrice.HeaderText = "Unit Price"
        Me.ColDrugUnitPrice.Name = "ColDrugUnitPrice"
        Me.ColDrugUnitPrice.Width = 70
        '
        'colDrugNotes
        '
        Me.colDrugNotes.DataPropertyName = "Notes"
        Me.colDrugNotes.HeaderText = "Notes"
        Me.colDrugNotes.MaxInputLength = 100
        Me.colDrugNotes.Name = "colDrugNotes"
        Me.colDrugNotes.Width = 140
        '
        'colPrescriptionSaved
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle13.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle13.NullValue = False
        Me.colPrescriptionSaved.DefaultCellStyle = DataGridViewCellStyle13
        Me.colPrescriptionSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPrescriptionSaved.HeaderText = "Saved"
        Me.colPrescriptionSaved.Name = "colPrescriptionSaved"
        Me.colPrescriptionSaved.ReadOnly = True
        Me.colPrescriptionSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPrescriptionSaved.Width = 50
        '
        'tpgPossibleConsumables
        '
        Me.tpgPossibleConsumables.Controls.Add(Me.dgvConsumables)
        Me.tpgPossibleConsumables.Location = New System.Drawing.Point(4, 22)
        Me.tpgPossibleConsumables.Name = "tpgPossibleConsumables"
        Me.tpgPossibleConsumables.Size = New System.Drawing.Size(709, 217)
        Me.tpgPossibleConsumables.TabIndex = 3
        Me.tpgPossibleConsumables.Text = "Possible Consumables"
        Me.tpgPossibleConsumables.UseVisualStyleBackColor = True
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToOrderColumns = True
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumableName, Me.colConsumableQuantity, Me.ColConUnitCost, Me.ColConsUnitPrice, Me.colConsumableNotes, Me.ColConsumableItemsSaved})
        Me.dgvConsumables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(0, 0)
        Me.dgvConsumables.Name = "dgvConsumables"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvConsumables.Size = New System.Drawing.Size(709, 217)
        Me.dgvConsumables.TabIndex = 41
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
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle16.Format = "N0"
        DataGridViewCellStyle16.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle16.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle16
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        '
        'ColConUnitCost
        '
        Me.ColConUnitCost.DataPropertyName = "UnitCost"
        Me.ColConUnitCost.HeaderText = "Unit Cost"
        Me.ColConUnitCost.Name = "ColConUnitCost"
        '
        'ColConsUnitPrice
        '
        Me.ColConsUnitPrice.DataPropertyName = "UnitPrice"
        Me.ColConsUnitPrice.HeaderText = "Unit Price"
        Me.ColConsUnitPrice.Name = "ColConsUnitPrice"
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
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle17.NullValue = False
        Me.ColConsumableItemsSaved.DefaultCellStyle = DataGridViewCellStyle17
        Me.ColConsumableItemsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColConsumableItemsSaved.HeaderText = "Saved"
        Me.ColConsumableItemsSaved.Name = "ColConsumableItemsSaved"
        Me.ColConsumableItemsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColConsumableItemsSaved.SourceColumn = Nothing
        Me.ColConsumableItemsSaved.Width = 50
        '
        'tpgPossibleTheatreServices
        '
        Me.tpgPossibleTheatreServices.Controls.Add(Me.dgvTheatre)
        Me.tpgPossibleTheatreServices.Location = New System.Drawing.Point(4, 22)
        Me.tpgPossibleTheatreServices.Name = "tpgPossibleTheatreServices"
        Me.tpgPossibleTheatreServices.Size = New System.Drawing.Size(709, 217)
        Me.tpgPossibleTheatreServices.TabIndex = 5
        Me.tpgPossibleTheatreServices.Text = "Possible Theatre Services"
        Me.tpgPossibleTheatreServices.UseVisualStyleBackColor = True
        '
        'dgvTheatre
        '
        Me.dgvTheatre.AllowUserToOrderColumns = True
        Me.dgvTheatre.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTheatre.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvTheatre.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTheatreCode, Me.colTheatreQuantity, Me.ColTheatreUnitCost, Me.ColTheatreUnitPrice, Me.colTheatreNotes, Me.colTheatreSaved})
        Me.dgvTheatre.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTheatre.EnableHeadersVisualStyles = False
        Me.dgvTheatre.GridColor = System.Drawing.Color.Khaki
        Me.dgvTheatre.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvTheatre.Location = New System.Drawing.Point(0, 0)
        Me.dgvTheatre.Name = "dgvTheatre"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle22.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTheatre.RowHeadersDefaultCellStyle = DataGridViewCellStyle22
        Me.dgvTheatre.Size = New System.Drawing.Size(709, 217)
        Me.dgvTheatre.TabIndex = 24
        Me.dgvTheatre.Text = "DataGridView1"
        '
        'colTheatreCode
        '
        Me.colTheatreCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTheatreCode.DataPropertyName = "ItemCode"
        Me.colTheatreCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colTheatreCode.DisplayStyleForCurrentCellOnly = True
        Me.colTheatreCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTheatreCode.HeaderText = "Theatre Service"
        Me.colTheatreCode.Name = "colTheatreCode"
        Me.colTheatreCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'colTheatreQuantity
        '
        Me.colTheatreQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTheatreQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.Format = "N0"
        DataGridViewCellStyle20.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle20.NullValue = Nothing
        Me.colTheatreQuantity.DefaultCellStyle = DataGridViewCellStyle20
        Me.colTheatreQuantity.HeaderText = "Quantity"
        Me.colTheatreQuantity.MaxInputLength = 12
        Me.colTheatreQuantity.Name = "colTheatreQuantity"
        '
        'ColTheatreUnitCost
        '
        Me.ColTheatreUnitCost.DataPropertyName = "UnitCost"
        Me.ColTheatreUnitCost.HeaderText = "Unit Cost"
        Me.ColTheatreUnitCost.Name = "ColTheatreUnitCost"
        '
        'ColTheatreUnitPrice
        '
        Me.ColTheatreUnitPrice.DataPropertyName = "UnitPrice"
        Me.ColTheatreUnitPrice.HeaderText = "Unit Price"
        Me.ColTheatreUnitPrice.Name = "ColTheatreUnitPrice"
        '
        'colTheatreNotes
        '
        Me.colTheatreNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTheatreNotes.DataPropertyName = "Notes"
        Me.colTheatreNotes.HeaderText = "Notes"
        Me.colTheatreNotes.MaxInputLength = 200
        Me.colTheatreNotes.Name = "colTheatreNotes"
        '
        'colTheatreSaved
        '
        Me.colTheatreSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle21.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle21.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle21.NullValue = False
        Me.colTheatreSaved.DefaultCellStyle = DataGridViewCellStyle21
        Me.colTheatreSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTheatreSaved.HeaderText = "Saved"
        Me.colTheatreSaved.Name = "colTheatreSaved"
        Me.colTheatreSaved.ReadOnly = True
        Me.colTheatreSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colTheatreSaved.Width = 50
        '
        'cboProcedureCode
        '
        Me.cboProcedureCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboProcedureCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboProcedureCode.DropDownWidth = 300
        Me.cboProcedureCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboProcedureCode.FormattingEnabled = True
        Me.cboProcedureCode.Location = New System.Drawing.Point(176, 11)
        Me.cboProcedureCode.MaxLength = 20
        Me.cboProcedureCode.Name = "cboProcedureCode"
        Me.cboProcedureCode.Size = New System.Drawing.Size(272, 21)
        Me.cboProcedureCode.TabIndex = 1
        '
        'lblVATPercentage
        '
        Me.lblVATPercentage.Location = New System.Drawing.Point(19, 199)
        Me.lblVATPercentage.Name = "lblVATPercentage"
        Me.lblVATPercentage.Size = New System.Drawing.Size(147, 20)
        Me.lblVATPercentage.TabIndex = 12
        Me.lblVATPercentage.Text = "VATPercentage"
        '
        'LabelUnitCost
        '
        Me.LabelUnitCost.Location = New System.Drawing.Point(19, 155)
        Me.LabelUnitCost.Name = "LabelUnitCost"
        Me.LabelUnitCost.Size = New System.Drawing.Size(147, 15)
        Me.LabelUnitCost.TabIndex = 8
        Me.LabelUnitCost.Text = "Unit Cost"
        '
        'lblProcedureCategoryID
        '
        Me.lblProcedureCategoryID.Location = New System.Drawing.Point(19, 128)
        Me.lblProcedureCategoryID.Name = "lblProcedureCategoryID"
        Me.lblProcedureCategoryID.Size = New System.Drawing.Size(147, 21)
        Me.lblProcedureCategoryID.TabIndex = 6
        Me.lblProcedureCategoryID.Text = "Category"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(565, 524)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 20
        Me.btnPrint.Text = "&Print"
        '
        'chkPrintOnSaving
        '
        Me.chkPrintOnSaving.AccessibleDescription = ""
        Me.chkPrintOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintOnSaving.AutoSize = True
        Me.chkPrintOnSaving.Checked = True
        Me.chkPrintOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintOnSaving.Location = New System.Drawing.Point(85, 525)
        Me.chkPrintOnSaving.Name = "chkPrintOnSaving"
        Me.chkPrintOnSaving.Size = New System.Drawing.Size(138, 17)
        Me.chkPrintOnSaving.TabIndex = 21
        Me.chkPrintOnSaving.Text = " Print Details On Saving"
        '
        'frmProcedures
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(723, 564)
        Me.Controls.Add(Me.chkPrintOnSaving)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.cboCategoryID)
        Me.Controls.Add(Me.lblProcedureCategoryID)
        Me.Controls.Add(Me.nbxUnitCost)
        Me.Controls.Add(Me.LabelUnitCost)
        Me.Controls.Add(Me.nbxVATPercentage)
        Me.Controls.Add(Me.lblVATPercentage)
        Me.Controls.Add(Me.cboProcedureCode)
        Me.Controls.Add(Me.tbcBillExcludedItems)
        Me.Controls.Add(Me.stbShortName)
        Me.Controls.Add(Me.lblShortName)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblProcedureCode)
        Me.Controls.Add(Me.stbProcedureName)
        Me.Controls.Add(Me.lblProcedureName)
        Me.Controls.Add(Me.nbxUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.chkHidden)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmProcedures"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Procedures"
        Me.tbcBillExcludedItems.ResumeLayout(False)
        Me.tpgBillCustomFee.ResumeLayout(False)
        CType(Me.dgvBillCustomFee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInsuranceCustomFee.ResumeLayout(False)
        CType(Me.dgvInsuranceCustomFee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPossiblePrescription.ResumeLayout(False)
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPossibleConsumables.ResumeLayout(False)
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgPossibleTheatreServices.ResumeLayout(False)
        CType(Me.dgvTheatre, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblProcedureCode As System.Windows.Forms.Label
    Friend WithEvents stbProcedureName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblProcedureName As System.Windows.Forms.Label
    Friend WithEvents nbxUnitPrice As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
    Friend WithEvents stbShortName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblShortName As System.Windows.Forms.Label
    Friend WithEvents tbcBillExcludedItems As System.Windows.Forms.TabControl
    Friend WithEvents tpgBillCustomFee As System.Windows.Forms.TabPage
    Friend WithEvents dgvBillCustomFee As System.Windows.Forms.DataGridView
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
    Friend WithEvents tpgPossibleConsumables As TabPage
    Friend WithEvents dgvConsumables As DataGridView
    Friend WithEvents tpgPossiblePrescription As TabPage
    Friend WithEvents dgvPrescription As DataGridView
    Friend WithEvents tpgPossibleTheatreServices As TabPage
    Friend WithEvents dgvTheatre As DataGridView
    Friend WithEvents cboProcedureCode As System.Windows.Forms.ComboBox
    Friend WithEvents nbxVATPercentage As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblVATPercentage As Label
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColConUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColConsUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColConsumableItemsSaved As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents colTheatreCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colTheatreQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTheatreUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTheatreUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTheatreSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents nbxUnitCost As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents LabelUnitCost As System.Windows.Forms.Label
    Friend WithEvents cboCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblProcedureCategoryID As System.Windows.Forms.Label
    Friend WithEvents colDrug As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ColDrugDosage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDrugUnitCost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDrugUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintOnSaving As System.Windows.Forms.CheckBox
End Class