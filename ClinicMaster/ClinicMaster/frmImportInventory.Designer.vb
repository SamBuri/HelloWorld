<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImportInventory : Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImportInventory))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvImportedData = New System.Windows.Forms.DataGridView()
        Me.colSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSystemQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVariance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStockType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fbnSaveAll = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbWorksheetName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblWorksheetName = New System.Windows.Forms.Label()
        Me.fbnImport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbFileName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnBrowse = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblSaveReport = New System.Windows.Forms.Label()
        Me.fbnErrorLog = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.grpImportNotes = New System.Windows.Forms.GroupBox()
        Me.chkIncludeAll = New System.Windows.Forms.CheckBox()
        Me.lblItemCategoryID = New System.Windows.Forms.Label()
        Me.cboItemCategoryID = New System.Windows.Forms.ComboBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.cboImportLocation = New System.Windows.Forms.ComboBox()
        Me.stbPSCNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPSCNo = New System.Windows.Forms.Label()
        Me.lblRecordsImported = New System.Windows.Forms.Label()
        Me.stbGeneralNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGeneralComment = New System.Windows.Forms.Label()
        Me.lblmportType = New System.Windows.Forms.Label()
        Me.cbImportTypeID = New System.Windows.Forms.ComboBox()
        CType(Me.dgvImportedData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpImportNotes.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(917, 504)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 5
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvImportedData
        '
        Me.dgvImportedData.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvImportedData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvImportedData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvImportedData.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvImportedData.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvImportedData.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvImportedData.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImportedData.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvImportedData.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colSelect, Me.colID, Me.colLocation, Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colBatchNo, Me.colExpiryDate, Me.colQuantity, Me.colNotes, Me.colSystemQuantity, Me.colVariance, Me.colStockType})
        Me.dgvImportedData.EnableHeadersVisualStyles = False
        Me.dgvImportedData.GridColor = System.Drawing.Color.Khaki
        Me.dgvImportedData.Location = New System.Drawing.Point(5, 123)
        Me.dgvImportedData.Name = "dgvImportedData"
        Me.dgvImportedData.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImportedData.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvImportedData.Size = New System.Drawing.Size(984, 370)
        Me.dgvImportedData.TabIndex = 1
        Me.dgvImportedData.Text = "DataGridView1"
        '
        'colSelect
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.colSelect.DefaultCellStyle = DataGridViewCellStyle3
        Me.colSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSelect.HeaderText = "Select"
        Me.colSelect.Name = "colSelect"
        Me.colSelect.ReadOnly = True
        Me.colSelect.Text = "•••"
        Me.colSelect.UseColumnTextForButtonValue = True
        Me.colSelect.Visible = False
        Me.colSelect.Width = 50
        '
        'colID
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.Format = "N0"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colID.DefaultCellStyle = DataGridViewCellStyle4
        Me.colID.HeaderText = "ID"
        Me.colID.Name = "colID"
        Me.colID.Width = 50
        '
        'colLocation
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.colLocation.DefaultCellStyle = DataGridViewCellStyle5
        Me.colLocation.HeaderText = "Location"
        Me.colLocation.Name = "colLocation"
        '
        'colItemCode
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle6
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        '
        'colItemName
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle7
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.Width = 150
        '
        'colItemCategory
        '
        Me.colItemCategory.HeaderText = "Item Category"
        Me.colItemCategory.Name = "colItemCategory"
        '
        'colBatchNo
        '
        Me.colBatchNo.HeaderText = "Batch No"
        Me.colBatchNo.Name = "colBatchNo"
        '
        'colExpiryDate
        '
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        '
        'colQuantity
        '
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        '
        'colNotes
        '
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Width = 300
        '
        'colSystemQuantity
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colSystemQuantity.DefaultCellStyle = DataGridViewCellStyle8
        Me.colSystemQuantity.HeaderText = "System Quantity"
        Me.colSystemQuantity.Name = "colSystemQuantity"
        Me.colSystemQuantity.ReadOnly = True
        '
        'colVariance
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colVariance.DefaultCellStyle = DataGridViewCellStyle9
        Me.colVariance.HeaderText = "Variance"
        Me.colVariance.Name = "colVariance"
        Me.colVariance.ReadOnly = True
        '
        'colStockType
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colStockType.DefaultCellStyle = DataGridViewCellStyle10
        Me.colStockType.HeaderText = "StockType"
        Me.colStockType.Name = "colStockType"
        Me.colStockType.ReadOnly = True
        '
        'fbnSaveAll
        '
        Me.fbnSaveAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSaveAll.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSaveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSaveAll.Location = New System.Drawing.Point(9, 499)
        Me.fbnSaveAll.Name = "fbnSaveAll"
        Me.fbnSaveAll.Size = New System.Drawing.Size(72, 24)
        Me.fbnSaveAll.TabIndex = 2
        Me.fbnSaveAll.Text = "&Save All"
        Me.fbnSaveAll.UseVisualStyleBackColor = False
        '
        'fbnExport
        '
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(896, 81)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(72, 24)
        Me.fbnExport.TabIndex = 6
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        Me.fbnExport.Visible = False
        '
        'stbWorksheetName
        '
        Me.stbWorksheetName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbWorksheetName.CapitalizeFirstLetter = False
        Me.stbWorksheetName.EntryErrorMSG = ""
        Me.stbWorksheetName.Location = New System.Drawing.Point(777, 15)
        Me.stbWorksheetName.MaxLength = 40
        Me.stbWorksheetName.Name = "stbWorksheetName"
        Me.stbWorksheetName.RegularExpression = ""
        Me.stbWorksheetName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbWorksheetName.Size = New System.Drawing.Size(102, 20)
        Me.stbWorksheetName.TabIndex = 3
        Me.stbWorksheetName.Text = "Inventory"
        '
        'lblWorksheetName
        '
        Me.lblWorksheetName.Location = New System.Drawing.Point(665, 16)
        Me.lblWorksheetName.Name = "lblWorksheetName"
        Me.lblWorksheetName.Size = New System.Drawing.Size(106, 20)
        Me.lblWorksheetName.TabIndex = 2
        Me.lblWorksheetName.Text = "Worksheet Name"
        '
        'fbnImport
        '
        Me.fbnImport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnImport.Location = New System.Drawing.Point(889, 15)
        Me.fbnImport.Name = "fbnImport"
        Me.fbnImport.Size = New System.Drawing.Size(72, 24)
        Me.fbnImport.TabIndex = 4
        Me.fbnImport.Text = "&Import"
        Me.fbnImport.UseVisualStyleBackColor = False
        '
        'stbFileName
        '
        Me.stbFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFileName.CapitalizeFirstLetter = False
        Me.stbFileName.EntryErrorMSG = ""
        Me.stbFileName.Location = New System.Drawing.Point(7, 17)
        Me.stbFileName.Name = "stbFileName"
        Me.stbFileName.RegularExpression = ""
        Me.stbFileName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFileName.Size = New System.Drawing.Size(502, 20)
        Me.stbFileName.TabIndex = 0
        '
        'fbnBrowse
        '
        Me.fbnBrowse.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnBrowse.Location = New System.Drawing.Point(581, 13)
        Me.fbnBrowse.Name = "fbnBrowse"
        Me.fbnBrowse.Size = New System.Drawing.Size(72, 24)
        Me.fbnBrowse.TabIndex = 1
        Me.fbnBrowse.Text = "&Browse..."
        Me.fbnBrowse.UseVisualStyleBackColor = False
        '
        'lblSaveReport
        '
        Me.lblSaveReport.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblSaveReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSaveReport.ForeColor = System.Drawing.Color.Blue
        Me.lblSaveReport.Location = New System.Drawing.Point(183, 510)
        Me.lblSaveReport.Name = "lblSaveReport"
        Me.lblSaveReport.Size = New System.Drawing.Size(710, 13)
        Me.lblSaveReport.TabIndex = 4
        '
        'fbnErrorLog
        '
        Me.fbnErrorLog.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnErrorLog.Enabled = False
        Me.fbnErrorLog.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnErrorLog.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnErrorLog.Location = New System.Drawing.Point(87, 499)
        Me.fbnErrorLog.Name = "fbnErrorLog"
        Me.fbnErrorLog.Size = New System.Drawing.Size(90, 24)
        Me.fbnErrorLog.TabIndex = 3
        Me.fbnErrorLog.Text = "&View Error Log"
        Me.fbnErrorLog.UseVisualStyleBackColor = False
        '
        'grpImportNotes
        '
        Me.grpImportNotes.BackColor = System.Drawing.Color.Transparent
        Me.grpImportNotes.Controls.Add(Me.chkIncludeAll)
        Me.grpImportNotes.Controls.Add(Me.lblItemCategoryID)
        Me.grpImportNotes.Controls.Add(Me.cboItemCategoryID)
        Me.grpImportNotes.Controls.Add(Me.lblLocation)
        Me.grpImportNotes.Controls.Add(Me.cboImportLocation)
        Me.grpImportNotes.Controls.Add(Me.stbPSCNo)
        Me.grpImportNotes.Controls.Add(Me.lblPSCNo)
        Me.grpImportNotes.Controls.Add(Me.lblRecordsImported)
        Me.grpImportNotes.Controls.Add(Me.fbnExport)
        Me.grpImportNotes.Controls.Add(Me.stbWorksheetName)
        Me.grpImportNotes.Controls.Add(Me.stbGeneralNotes)
        Me.grpImportNotes.Controls.Add(Me.lblWorksheetName)
        Me.grpImportNotes.Controls.Add(Me.lblGeneralComment)
        Me.grpImportNotes.Controls.Add(Me.lblmportType)
        Me.grpImportNotes.Controls.Add(Me.fbnImport)
        Me.grpImportNotes.Controls.Add(Me.cbImportTypeID)
        Me.grpImportNotes.Controls.Add(Me.stbFileName)
        Me.grpImportNotes.Controls.Add(Me.fbnBrowse)
        Me.grpImportNotes.Location = New System.Drawing.Point(12, 1)
        Me.grpImportNotes.Name = "grpImportNotes"
        Me.grpImportNotes.Size = New System.Drawing.Size(977, 111)
        Me.grpImportNotes.TabIndex = 6
        Me.grpImportNotes.TabStop = False
        Me.grpImportNotes.Text = "File Location"
        '
        'chkIncludeAll
        '
        Me.chkIncludeAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkIncludeAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkIncludeAll.Location = New System.Drawing.Point(513, 78)
        Me.chkIncludeAll.Name = "chkIncludeAll"
        Me.chkIncludeAll.Size = New System.Drawing.Size(102, 20)
        Me.chkIncludeAll.TabIndex = 24
        Me.chkIncludeAll.Text = "Include all"
        '
        'lblItemCategoryID
        '
        Me.lblItemCategoryID.Location = New System.Drawing.Point(259, 78)
        Me.lblItemCategoryID.Name = "lblItemCategoryID"
        Me.lblItemCategoryID.Size = New System.Drawing.Size(119, 20)
        Me.lblItemCategoryID.TabIndex = 22
        Me.lblItemCategoryID.Text = "Item Category ID"
        '
        'cboItemCategoryID
        '
        Me.cboItemCategoryID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemCategoryID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCategoryID.Location = New System.Drawing.Point(384, 75)
        Me.cboItemCategoryID.Name = "cboItemCategoryID"
        Me.cboItemCategoryID.Size = New System.Drawing.Size(123, 21)
        Me.cboItemCategoryID.TabIndex = 21
        '
        'lblLocation
        '
        Me.lblLocation.Location = New System.Drawing.Point(8, 79)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(95, 20)
        Me.lblLocation.TabIndex = 20
        Me.lblLocation.Text = "Location"
        '
        'cboImportLocation
        '
        Me.cboImportLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImportLocation.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboImportLocation.Location = New System.Drawing.Point(109, 76)
        Me.cboImportLocation.Name = "cboImportLocation"
        Me.cboImportLocation.Size = New System.Drawing.Size(145, 21)
        Me.cboImportLocation.TabIndex = 19
        '
        'stbPSCNo
        '
        Me.stbPSCNo.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.stbPSCNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPSCNo.CapitalizeFirstLetter = False
        Me.stbPSCNo.EntryErrorMSG = ""
        Me.stbPSCNo.Location = New System.Drawing.Point(400, 50)
        Me.stbPSCNo.MaxLength = 30
        Me.stbPSCNo.Name = "stbPSCNo"
        Me.stbPSCNo.RegularExpression = ""
        Me.stbPSCNo.Size = New System.Drawing.Size(123, 20)
        Me.stbPSCNo.TabIndex = 15
        Me.stbPSCNo.Visible = False
        '
        'lblPSCNo
        '
        Me.lblPSCNo.Location = New System.Drawing.Point(259, 51)
        Me.lblPSCNo.Name = "lblPSCNo"
        Me.lblPSCNo.Size = New System.Drawing.Size(135, 20)
        Me.lblPSCNo.TabIndex = 14
        Me.lblPSCNo.Text = "Physical Stock Count No"
        Me.lblPSCNo.Visible = False
        '
        'lblRecordsImported
        '
        Me.lblRecordsImported.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsImported.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsImported.Location = New System.Drawing.Point(621, 79)
        Me.lblRecordsImported.Name = "lblRecordsImported"
        Me.lblRecordsImported.Size = New System.Drawing.Size(269, 18)
        Me.lblRecordsImported.TabIndex = 5
        '
        'stbGeneralNotes
        '
        Me.stbGeneralNotes.BackColor = System.Drawing.SystemColors.HighlightText
        Me.stbGeneralNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGeneralNotes.CapitalizeFirstLetter = True
        Me.stbGeneralNotes.EntryErrorMSG = ""
        Me.stbGeneralNotes.Location = New System.Drawing.Point(714, 41)
        Me.stbGeneralNotes.MaxLength = 0
        Me.stbGeneralNotes.Multiline = True
        Me.stbGeneralNotes.Name = "stbGeneralNotes"
        Me.stbGeneralNotes.RegularExpression = ""
        Me.stbGeneralNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGeneralNotes.Size = New System.Drawing.Size(208, 29)
        Me.stbGeneralNotes.TabIndex = 18
        Me.stbGeneralNotes.Visible = False
        '
        'lblGeneralComment
        '
        Me.lblGeneralComment.Location = New System.Drawing.Point(580, 46)
        Me.lblGeneralComment.Name = "lblGeneralComment"
        Me.lblGeneralComment.Size = New System.Drawing.Size(111, 20)
        Me.lblGeneralComment.TabIndex = 17
        Me.lblGeneralComment.Text = "General Notes"
        Me.lblGeneralComment.Visible = False
        '
        'lblmportType
        '
        Me.lblmportType.Location = New System.Drawing.Point(8, 52)
        Me.lblmportType.Name = "lblmportType"
        Me.lblmportType.Size = New System.Drawing.Size(91, 20)
        Me.lblmportType.TabIndex = 16
        Me.lblmportType.Text = "Import Type"
        '
        'cbImportTypeID
        '
        Me.cbImportTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbImportTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cbImportTypeID.Location = New System.Drawing.Point(109, 50)
        Me.cbImportTypeID.Name = "cbImportTypeID"
        Me.cbImportTypeID.Size = New System.Drawing.Size(145, 21)
        Me.cbImportTypeID.TabIndex = 11
        '
        'frmImportInventory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 532)
        Me.Controls.Add(Me.grpImportNotes)
        Me.Controls.Add(Me.fbnErrorLog)
        Me.Controls.Add(Me.lblSaveReport)
        Me.Controls.Add(Me.fbnSaveAll)
        Me.Controls.Add(Me.dgvImportedData)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmImportInventory"
        Me.Tag = "Inventory"
        Me.Text = "Import Inventory Received"
        CType(Me.dgvImportedData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpImportNotes.ResumeLayout(False)
        Me.grpImportNotes.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvImportedData As System.Windows.Forms.DataGridView
    Friend WithEvents fbnSaveAll As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnBrowse As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbFileName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents fbnImport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblSaveReport As System.Windows.Forms.Label
    Friend WithEvents stbWorksheetName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblWorksheetName As System.Windows.Forms.Label
    Friend WithEvents fbnErrorLog As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents grpImportNotes As GroupBox
    Friend WithEvents cbImportTypeID As ComboBox
    Friend WithEvents lblGeneralComment As Label
    Friend WithEvents lblmportType As Label
    Friend WithEvents stbGeneralNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRecordsImported As Label
    Friend WithEvents stbPSCNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPSCNo As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents cboImportLocation As ComboBox
    Friend WithEvents lblItemCategoryID As Label
    Friend WithEvents cboItemCategoryID As ComboBox
    Friend WithEvents colSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSystemQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVariance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStockType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkIncludeAll As System.Windows.Forms.CheckBox
End Class
