
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpticalServices : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpticalServices))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbOpticalName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxUnitPrice = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.chkHidden = New System.Windows.Forms.CheckBox()
        Me.cboOpticalCategoryID = New System.Windows.Forms.ComboBox()
        Me.nbxVATPercentage = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxUnitCost = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblOpticalCode = New System.Windows.Forms.Label()
        Me.lblOpticalName = New System.Windows.Forms.Label()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
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
        Me.cboOpticalCode = New System.Windows.Forms.ComboBox()
        Me.lblOpticalCategoryID = New System.Windows.Forms.Label()
        Me.lblVATPercentage = New System.Windows.Forms.Label()
        Me.lblUnitCost = New System.Windows.Forms.Label()
        Me.tbcBillExcludedItems.SuspendLayout()
        Me.tpgBillCustomFee.SuspendLayout()
        CType(Me.dgvBillCustomFee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInsuranceCustomFee.SuspendLayout()
        CType(Me.dgvInsuranceCustomFee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(13, 448)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 14
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(550, 448)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 16
        Me.fbnDelete.Tag = "OpticalServices"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(13, 475)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 15
        Me.ebnSaveUpdate.Tag = "OpticalServices"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbOpticalName
        '
        Me.stbOpticalName.AcceptsReturn = True
        Me.stbOpticalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOpticalName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbOpticalName, "OpticalName")
        Me.stbOpticalName.EntryErrorMSG = ""
        Me.stbOpticalName.Location = New System.Drawing.Point(152, 27)
        Me.stbOpticalName.MaxLength = 200
        Me.stbOpticalName.Multiline = True
        Me.stbOpticalName.Name = "stbOpticalName"
        Me.stbOpticalName.RegularExpression = ""
        Me.stbOpticalName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbOpticalName.Size = New System.Drawing.Size(206, 39)
        Me.stbOpticalName.TabIndex = 3
        '
        'nbxUnitPrice
        '
        Me.nbxUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxUnitPrice.ControlCaption = "Unit Price"
        Me.nbxUnitPrice.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxUnitPrice, "UnitPrice")
        Me.nbxUnitPrice.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxUnitPrice.DecimalPlaces = -1
        Me.nbxUnitPrice.Location = New System.Drawing.Point(152, 118)
        Me.nbxUnitPrice.MaxLength = 12
        Me.nbxUnitPrice.MaxValue = 0.0R
        Me.nbxUnitPrice.MinValue = 0.0R
        Me.nbxUnitPrice.MustEnterNumeric = True
        Me.nbxUnitPrice.Name = "nbxUnitPrice"
        Me.nbxUnitPrice.Size = New System.Drawing.Size(206, 20)
        Me.nbxUnitPrice.TabIndex = 9
        Me.nbxUnitPrice.Tag = "OpticalPrices"
        Me.nbxUnitPrice.Value = ""
        '
        'chkHidden
        '
        Me.chkHidden.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkHidden, "Hidden")
        Me.chkHidden.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkHidden.Location = New System.Drawing.Point(12, 166)
        Me.chkHidden.Name = "chkHidden"
        Me.chkHidden.Size = New System.Drawing.Size(150, 20)
        Me.chkHidden.TabIndex = 12
        Me.chkHidden.Text = "Hidden"
        '
        'cboOpticalCategoryID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboOpticalCategoryID, "OpticalCategory,OpticalCategoryID")
        Me.cboOpticalCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOpticalCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboOpticalCategoryID.Location = New System.Drawing.Point(152, 69)
        Me.cboOpticalCategoryID.Name = "cboOpticalCategoryID"
        Me.cboOpticalCategoryID.Size = New System.Drawing.Size(206, 21)
        Me.cboOpticalCategoryID.TabIndex = 5
        '
        'nbxVATPercentage
        '
        Me.nbxVATPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxVATPercentage.ControlCaption = "VATPercentage"
        Me.nbxVATPercentage.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxVATPercentage, "VATPercentage")
        Me.nbxVATPercentage.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxVATPercentage.DecimalPlaces = -1
        Me.nbxVATPercentage.Location = New System.Drawing.Point(152, 140)
        Me.nbxVATPercentage.MaxValue = 0.0R
        Me.nbxVATPercentage.MinValue = 0.0R
        Me.nbxVATPercentage.MustEnterNumeric = True
        Me.nbxVATPercentage.Name = "nbxVATPercentage"
        Me.nbxVATPercentage.Size = New System.Drawing.Size(206, 20)
        Me.nbxVATPercentage.TabIndex = 11
        Me.nbxVATPercentage.Tag = "OpticalPrices"
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
        Me.nbxUnitCost.Location = New System.Drawing.Point(152, 96)
        Me.nbxUnitCost.MaxLength = 12
        Me.nbxUnitCost.MaxValue = 0.0R
        Me.nbxUnitCost.MinValue = 0.0R
        Me.nbxUnitCost.MustEnterNumeric = True
        Me.nbxUnitCost.Name = "nbxUnitCost"
        Me.nbxUnitCost.Size = New System.Drawing.Size(206, 20)
        Me.nbxUnitCost.TabIndex = 7
        Me.nbxUnitCost.Tag = "OpticalPrices"
        Me.nbxUnitCost.Value = ""
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(550, 475)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 17
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblOpticalCode
        '
        Me.lblOpticalCode.Location = New System.Drawing.Point(12, 4)
        Me.lblOpticalCode.Name = "lblOpticalCode"
        Me.lblOpticalCode.Size = New System.Drawing.Size(134, 20)
        Me.lblOpticalCode.TabIndex = 0
        Me.lblOpticalCode.Text = "Optical Code"
        '
        'lblOpticalName
        '
        Me.lblOpticalName.Location = New System.Drawing.Point(12, 29)
        Me.lblOpticalName.Name = "lblOpticalName"
        Me.lblOpticalName.Size = New System.Drawing.Size(134, 20)
        Me.lblOpticalName.TabIndex = 2
        Me.lblOpticalName.Text = "Optical Service Name"
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Location = New System.Drawing.Point(12, 118)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(134, 20)
        Me.lblUnitPrice.TabIndex = 8
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'tbcBillExcludedItems
        '
        Me.tbcBillExcludedItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgBillCustomFee)
        Me.tbcBillExcludedItems.Controls.Add(Me.tpgInsuranceCustomFee)
        Me.tbcBillExcludedItems.HotTrack = True
        Me.tbcBillExcludedItems.Location = New System.Drawing.Point(11, 204)
        Me.tbcBillExcludedItems.Name = "tbcBillExcludedItems"
        Me.tbcBillExcludedItems.SelectedIndex = 0
        Me.tbcBillExcludedItems.Size = New System.Drawing.Size(615, 226)
        Me.tbcBillExcludedItems.TabIndex = 13
        '
        'tpgBillCustomFee
        '
        Me.tpgBillCustomFee.Controls.Add(Me.dgvBillCustomFee)
        Me.tpgBillCustomFee.Location = New System.Drawing.Point(4, 22)
        Me.tpgBillCustomFee.Name = "tpgBillCustomFee"
        Me.tpgBillCustomFee.Size = New System.Drawing.Size(607, 200)
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
        Me.dgvBillCustomFee.Size = New System.Drawing.Size(607, 200)
        Me.dgvBillCustomFee.TabIndex = 0
        Me.dgvBillCustomFee.Tag = "OpticalPrices"
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
        Me.tpgInsuranceCustomFee.Size = New System.Drawing.Size(607, 141)
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
        Me.dgvInsuranceCustomFee.Size = New System.Drawing.Size(607, 141)
        Me.dgvInsuranceCustomFee.TabIndex = 0
        Me.dgvInsuranceCustomFee.Tag = "OpticalPrices"
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
        'cboOpticalCode
        '
        Me.cboOpticalCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboOpticalCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboOpticalCode.DropDownWidth = 300
        Me.cboOpticalCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboOpticalCode.FormattingEnabled = True
        Me.cboOpticalCode.Location = New System.Drawing.Point(152, 3)
        Me.cboOpticalCode.MaxLength = 224
        Me.cboOpticalCode.Name = "cboOpticalCode"
        Me.cboOpticalCode.Size = New System.Drawing.Size(206, 21)
        Me.cboOpticalCode.TabIndex = 1
        '
        'lblOpticalCategoryID
        '
        Me.lblOpticalCategoryID.Location = New System.Drawing.Point(12, 68)
        Me.lblOpticalCategoryID.Name = "lblOpticalCategoryID"
        Me.lblOpticalCategoryID.Size = New System.Drawing.Size(134, 20)
        Me.lblOpticalCategoryID.TabIndex = 4
        Me.lblOpticalCategoryID.Text = "Optical Category"
        '
        'lblVATPercentage
        '
        Me.lblVATPercentage.Location = New System.Drawing.Point(12, 142)
        Me.lblVATPercentage.Name = "lblVATPercentage"
        Me.lblVATPercentage.Size = New System.Drawing.Size(134, 20)
        Me.lblVATPercentage.TabIndex = 10
        Me.lblVATPercentage.Text = "VATPercentage"
        '
        'lblUnitCost
        '
        Me.lblUnitCost.Location = New System.Drawing.Point(12, 96)
        Me.lblUnitCost.Name = "lblUnitCost"
        Me.lblUnitCost.Size = New System.Drawing.Size(134, 20)
        Me.lblUnitCost.TabIndex = 6
        Me.lblUnitCost.Text = "Unit Cost"
        '
        'frmOpticalServices
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(648, 508)
        Me.Controls.Add(Me.nbxUnitCost)
        Me.Controls.Add(Me.lblUnitCost)
        Me.Controls.Add(Me.nbxVATPercentage)
        Me.Controls.Add(Me.lblVATPercentage)
        Me.Controls.Add(Me.cboOpticalCategoryID)
        Me.Controls.Add(Me.lblOpticalCategoryID)
        Me.Controls.Add(Me.cboOpticalCode)
        Me.Controls.Add(Me.tbcBillExcludedItems)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblOpticalCode)
        Me.Controls.Add(Me.stbOpticalName)
        Me.Controls.Add(Me.lblOpticalName)
        Me.Controls.Add(Me.nbxUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.chkHidden)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmOpticalServices"
        Me.Text = "Optical Services"
        Me.tbcBillExcludedItems.ResumeLayout(False)
        Me.tpgBillCustomFee.ResumeLayout(False)
        CType(Me.dgvBillCustomFee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInsuranceCustomFee.ResumeLayout(False)
        CType(Me.dgvInsuranceCustomFee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblOpticalCode As System.Windows.Forms.Label
    Friend WithEvents stbOpticalName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOpticalName As System.Windows.Forms.Label
    Friend WithEvents nbxUnitPrice As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents chkHidden As System.Windows.Forms.CheckBox
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
    Friend WithEvents cboOpticalCode As System.Windows.Forms.ComboBox
    Friend WithEvents cboOpticalCategoryID As System.Windows.Forms.ComboBox
    Friend WithEvents lblOpticalCategoryID As System.Windows.Forms.Label
    Friend WithEvents nbxVATPercentage As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblVATPercentage As Label
    Friend WithEvents nbxUnitCost As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblUnitCost As System.Windows.Forms.Label
End Class