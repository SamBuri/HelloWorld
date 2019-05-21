
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMappedCodesFinance : Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMappedCodesFinance))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboAccountTypeID = New System.Windows.Forms.ComboBox()
        Me.chkApplyAll = New System.Windows.Forms.CheckBox()
        Me.cboAccountNo = New System.Windows.Forms.ComboBox()
        Me.chkLoadAll = New System.Windows.Forms.CheckBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblItemCategoryID = New System.Windows.Forms.Label()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.lblAccountTypeID = New System.Windows.Forms.Label()
        Me.dgvMappedCodes = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colSelect = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsCopy = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsInvoiceDetailsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsInvoiceDetailsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.cboItemCategoryEXT = New System.Windows.Forms.ComboBox()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        CType(Me.dgvMappedCodes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsCopy.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 353)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(718, 353)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "MappedCodesFinance"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 380)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "MappedCodesFinance"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboAccountTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAccountTypeID, "AccountType,AccountTypeID")
        Me.cboAccountTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountTypeID.Location = New System.Drawing.Point(183, 36)
        Me.cboAccountTypeID.Name = "cboAccountTypeID"
        Me.cboAccountTypeID.Size = New System.Drawing.Size(172, 21)
        Me.cboAccountTypeID.TabIndex = 10
        '
        'chkApplyAll
        '
        Me.chkApplyAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkApplyAll, "UseCustomFee")
        Me.chkApplyAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkApplyAll.Location = New System.Drawing.Point(361, 12)
        Me.chkApplyAll.Name = "chkApplyAll"
        Me.chkApplyAll.Size = New System.Drawing.Size(205, 20)
        Me.chkApplyAll.TabIndex = 23
        Me.chkApplyAll.Text = "Apply to all"
        '
        'cboAccountNo
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAccountNo, "AccountName,AccountNo")
        Me.cboAccountNo.Enabled = False
        Me.cboAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountNo.Location = New System.Drawing.Point(555, 36)
        Me.cboAccountNo.Name = "cboAccountNo"
        Me.cboAccountNo.Size = New System.Drawing.Size(196, 21)
        Me.cboAccountNo.TabIndex = 24
        '
        'chkLoadAll
        '
        Me.chkLoadAll.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkLoadAll, "UseCustomFee")
        Me.chkLoadAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkLoadAll.Location = New System.Drawing.Point(12, 58)
        Me.chkLoadAll.Name = "chkLoadAll"
        Me.chkLoadAll.Size = New System.Drawing.Size(182, 20)
        Me.chkLoadAll.TabIndex = 26
        Me.chkLoadAll.Text = "Load All"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(718, 380)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblItemCategoryID
        '
        Me.lblItemCategoryID.Location = New System.Drawing.Point(12, 12)
        Me.lblItemCategoryID.Name = "lblItemCategoryID"
        Me.lblItemCategoryID.Size = New System.Drawing.Size(152, 20)
        Me.lblItemCategoryID.TabIndex = 7
        Me.lblItemCategoryID.Text = "Item Category EXT"
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(361, 37)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(170, 20)
        Me.lblAccountNo.TabIndex = 9
        Me.lblAccountNo.Text = "Account No"
        '
        'lblAccountTypeID
        '
        Me.lblAccountTypeID.Location = New System.Drawing.Point(12, 34)
        Me.lblAccountTypeID.Name = "lblAccountTypeID"
        Me.lblAccountTypeID.Size = New System.Drawing.Size(152, 20)
        Me.lblAccountTypeID.TabIndex = 11
        Me.lblAccountTypeID.Text = "Account Type"
        '
        'dgvMappedCodes
        '
        Me.dgvMappedCodes.AllowUserToDeleteRows = False
        Me.dgvMappedCodes.AllowUserToOrderColumns = True
        Me.dgvMappedCodes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvMappedCodes.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMappedCodes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvMappedCodes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colSelect, Me.colItemCode, Me.colItemName, Me.colAccountNo, Me.colAccountName, Me.colSaved})
        Me.dgvMappedCodes.ContextMenuStrip = Me.cmsCopy
        Me.dgvMappedCodes.EnableHeadersVisualStyles = False
        Me.dgvMappedCodes.GridColor = System.Drawing.Color.Khaki
        Me.dgvMappedCodes.Location = New System.Drawing.Point(17, 83)
        Me.dgvMappedCodes.Name = "dgvMappedCodes"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMappedCodes.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvMappedCodes.Size = New System.Drawing.Size(774, 264)
        Me.dgvMappedCodes.TabIndex = 12
        Me.dgvMappedCodes.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colInclude.Width = 60
        '
        'colSelect
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.Firebrick
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Khaki
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.DarkBlue
        Me.colSelect.DefaultCellStyle = DataGridViewCellStyle8
        Me.colSelect.HeaderText = "Select"
        Me.colSelect.Name = "colSelect"
        Me.colSelect.Text = "..."
        Me.colSelect.Width = 50
        '
        'colItemCode
        '
        Me.colItemCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle9
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        '
        'colItemName
        '
        Me.colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colAccountNo
        '
        Me.colAccountNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAccountNo.DataPropertyName = "AccountNo"
        Me.colAccountNo.HeaderText = "Account No"
        Me.colAccountNo.Name = "colAccountNo"
        Me.colAccountNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colAccountName
        '
        Me.colAccountName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAccountName.DataPropertyName = "AccountName"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colAccountName.DefaultCellStyle = DataGridViewCellStyle10
        Me.colAccountName.HeaderText = "Account Name"
        Me.colAccountName.Name = "colAccountName"
        Me.colAccountName.ReadOnly = True
        '
        'colSaved
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle11.NullValue = False
        Me.colSaved.DefaultCellStyle = DataGridViewCellStyle11
        Me.colSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colSaved.HeaderText = "Saved"
        Me.colSaved.Name = "colSaved"
        Me.colSaved.ReadOnly = True
        Me.colSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colSaved.Width = 50
        '
        'cmsCopy
        '
        Me.cmsCopy.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsCopy.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsInvoiceDetailsCopy, Me.cmsInvoiceDetailsSelectAll, Me.cmsQuickSearch})
        Me.cmsCopy.Name = "cmsSearch"
        Me.cmsCopy.Size = New System.Drawing.Size(144, 70)
        '
        'cmsInvoiceDetailsCopy
        '
        Me.cmsInvoiceDetailsCopy.Enabled = False
        Me.cmsInvoiceDetailsCopy.Image = CType(resources.GetObject("cmsInvoiceDetailsCopy.Image"), System.Drawing.Image)
        Me.cmsInvoiceDetailsCopy.Name = "cmsInvoiceDetailsCopy"
        Me.cmsInvoiceDetailsCopy.Size = New System.Drawing.Size(143, 22)
        Me.cmsInvoiceDetailsCopy.Text = "Copy"
        Me.cmsInvoiceDetailsCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsInvoiceDetailsSelectAll
        '
        Me.cmsInvoiceDetailsSelectAll.Enabled = False
        Me.cmsInvoiceDetailsSelectAll.Name = "cmsInvoiceDetailsSelectAll"
        Me.cmsInvoiceDetailsSelectAll.Size = New System.Drawing.Size(143, 22)
        Me.cmsInvoiceDetailsSelectAll.Text = "Select All"
        '
        'cmsQuickSearch
        '
        Me.cmsQuickSearch.Enabled = False
        Me.cmsQuickSearch.Name = "cmsQuickSearch"
        Me.cmsQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsQuickSearch.Text = "Quick Search"
        '
        'cboItemCategoryEXT
        '
        Me.cboItemCategoryEXT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboItemCategoryEXT.Location = New System.Drawing.Point(183, 11)
        Me.cboItemCategoryEXT.Name = "cboItemCategoryEXT"
        Me.cboItemCategoryEXT.Size = New System.Drawing.Size(172, 21)
        Me.cboItemCategoryEXT.TabIndex = 13
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(576, 16)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(175, 13)
        Me.lblRecordsNo.TabIndex = 25
        '
        'frmMappedCodesFinance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(802, 407)
        Me.Controls.Add(Me.chkLoadAll)
        Me.Controls.Add(Me.lblRecordsNo)
        Me.Controls.Add(Me.cboAccountNo)
        Me.Controls.Add(Me.chkApplyAll)
        Me.Controls.Add(Me.cboItemCategoryEXT)
        Me.Controls.Add(Me.dgvMappedCodes)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblItemCategoryID)
        Me.Controls.Add(Me.lblAccountNo)
        Me.Controls.Add(Me.cboAccountTypeID)
        Me.Controls.Add(Me.lblAccountTypeID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmMappedCodesFinance"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mapped Codes Finance"
        CType(Me.dgvMappedCodes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsCopy.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblItemCategoryID As System.Windows.Forms.Label
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents cboAccountTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountTypeID As System.Windows.Forms.Label
    Friend WithEvents dgvMappedCodes As System.Windows.Forms.DataGridView
    Friend WithEvents cboItemCategoryEXT As System.Windows.Forms.ComboBox
    Friend WithEvents chkApplyAll As System.Windows.Forms.CheckBox
    Friend WithEvents cboAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents chkLoadAll As System.Windows.Forms.CheckBox
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colSelect As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccountNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccountName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cmsCopy As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsInvoiceDetailsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsInvoiceDetailsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsQuickSearch As System.Windows.Forms.ToolStripMenuItem

End Class