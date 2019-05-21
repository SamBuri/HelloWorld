<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStaffPaymentsApprovals
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStaffPaymentsApprovals))
        Me.stbStaffTitle = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStaffTitleID = New System.Windows.Forms.Label()
        Me.tbcVoucherDetails = New System.Windows.Forms.TabControl()
        Me.tpgVoucherDetails = New System.Windows.Forms.TabPage()
        Me.dgvVoucherDetails = New System.Windows.Forms.DataGridView()
        Me.colVoucherInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colVoucherVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVoucherPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVoucherExtraBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVoucherRoundNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVoucherFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVoucherItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVoucherItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVoucherItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVoucherItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVoucherAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVoucherApprovalStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colVoucherNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListIncludeAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListIncludeNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.chkPrintVoucherOnSaving = New System.Windows.Forms.CheckBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.btnExchangeRate = New System.Windows.Forms.Button()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnPendingApprovals = New System.Windows.Forms.Button()
        Me.lblPendingVouchers = New System.Windows.Forms.Label()
        Me.nbxExchangeRate = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblExchangeRate = New System.Windows.Forms.Label()
        Me.cboCurrenciesID = New System.Windows.Forms.ComboBox()
        Me.lblCurrenciesID = New System.Windows.Forms.Label()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbVoucherStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVoucherStatus = New System.Windows.Forms.Label()
        Me.lblApprovalDateTime = New System.Windows.Forms.Label()
        Me.SmartTextBox1 = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCBFPChequeNo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpApprovalDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblVisitType = New System.Windows.Forms.Label()
        Me.stbBillModes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSpeciality = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSpeciality = New System.Windows.Forms.Label()
        Me.stbDocumentNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbStaffNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbEndDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboPayModesID = New System.Windows.Forms.ComboBox()
        Me.lblPaymentVoucherNo = New System.Windows.Forms.Label()
        Me.stbStartDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblCBFPPayModes = New System.Windows.Forms.Label()
        Me.stbPaymentVoucherNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFristName = New System.Windows.Forms.Label()
        Me.lblLastName = New System.Windows.Forms.Label()
        Me.stbLastName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFirstName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStaff = New System.Windows.Forms.Label()
        Me.lblPayModes = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.lblAmountInWords = New System.Windows.Forms.Label()
        Me.stbAmountInWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblTotalAmount = New System.Windows.Forms.Label()
        Me.stbTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.tbcVoucherDetails.SuspendLayout()
        Me.tpgVoucherDetails.SuspendLayout()
        CType(Me.dgvVoucherDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        Me.grpSetParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbStaffTitle
        '
        Me.stbStaffTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStaffTitle.CapitalizeFirstLetter = True
        Me.stbStaffTitle.EntryErrorMSG = ""
        Me.stbStaffTitle.Location = New System.Drawing.Point(814, 52)
        Me.stbStaffTitle.MaxLength = 20
        Me.stbStaffTitle.Name = "stbStaffTitle"
        Me.stbStaffTitle.ReadOnly = True
        Me.stbStaffTitle.RegularExpression = ""
        Me.stbStaffTitle.Size = New System.Drawing.Size(191, 20)
        Me.stbStaffTitle.TabIndex = 129
        '
        'lblStaffTitleID
        '
        Me.lblStaffTitleID.Location = New System.Drawing.Point(694, 51)
        Me.lblStaffTitleID.Name = "lblStaffTitleID"
        Me.lblStaffTitleID.Size = New System.Drawing.Size(114, 21)
        Me.lblStaffTitleID.TabIndex = 124
        Me.lblStaffTitleID.Text = "Staff Title"
        '
        'tbcVoucherDetails
        '
        Me.tbcVoucherDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcVoucherDetails.Controls.Add(Me.tpgVoucherDetails)
        Me.tbcVoucherDetails.HotTrack = True
        Me.tbcVoucherDetails.Location = New System.Drawing.Point(12, 218)
        Me.tbcVoucherDetails.Name = "tbcVoucherDetails"
        Me.tbcVoucherDetails.SelectedIndex = 0
        Me.tbcVoucherDetails.Size = New System.Drawing.Size(1060, 246)
        Me.tbcVoucherDetails.TabIndex = 148
        '
        'tpgVoucherDetails
        '
        Me.tpgVoucherDetails.Controls.Add(Me.dgvVoucherDetails)
        Me.tpgVoucherDetails.Location = New System.Drawing.Point(4, 22)
        Me.tpgVoucherDetails.Name = "tpgVoucherDetails"
        Me.tpgVoucherDetails.Size = New System.Drawing.Size(1052, 220)
        Me.tpgVoucherDetails.TabIndex = 7
        Me.tpgVoucherDetails.Tag = "Voucher Details"
        Me.tpgVoucherDetails.Text = "Voucher Details"
        Me.tpgVoucherDetails.UseVisualStyleBackColor = True
        '
        'dgvVoucherDetails
        '
        Me.dgvVoucherDetails.AllowUserToAddRows = False
        Me.dgvVoucherDetails.AllowUserToDeleteRows = False
        Me.dgvVoucherDetails.AllowUserToOrderColumns = True
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle14.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvVoucherDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvVoucherDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvVoucherDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvVoucherDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvVoucherDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVoucherDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.dgvVoucherDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colVoucherInclude, Me.colVoucherVisitNo, Me.colVoucherPatientNo, Me.colVoucherExtraBillNo, Me.colVoucherRoundNo, Me.colVoucherFullName, Me.colVoucherItemCategory, Me.colVoucherItemCategoryID, Me.colVoucherItemCode, Me.colVoucherItemName, Me.colVoucherAmount, Me.colVoucherApprovalStatus, Me.colVoucherNotes})
        Me.dgvVoucherDetails.ContextMenuStrip = Me.cmsAlertList
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVoucherDetails.DefaultCellStyle = DataGridViewCellStyle25
        Me.dgvVoucherDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvVoucherDetails.EnableHeadersVisualStyles = False
        Me.dgvVoucherDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvVoucherDetails.Location = New System.Drawing.Point(0, 0)
        Me.dgvVoucherDetails.Name = "dgvVoucherDetails"
        Me.dgvVoucherDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVoucherDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.dgvVoucherDetails.RowHeadersVisible = False
        Me.dgvVoucherDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvVoucherDetails.Size = New System.Drawing.Size(1052, 220)
        Me.dgvVoucherDetails.TabIndex = 109
        Me.dgvVoucherDetails.Text = "DataGridView1"
        '
        'colVoucherInclude
        '
        Me.colVoucherInclude.HeaderText = "Include"
        Me.colVoucherInclude.Name = "colVoucherInclude"
        Me.colVoucherInclude.Width = 50
        '
        'colVoucherVisitNo
        '
        Me.colVoucherVisitNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colVoucherVisitNo.DataPropertyName = "VisitNo"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colVoucherVisitNo.DefaultCellStyle = DataGridViewCellStyle16
        Me.colVoucherVisitNo.HeaderText = "Visit No"
        Me.colVoucherVisitNo.Name = "colVoucherVisitNo"
        Me.colVoucherVisitNo.ReadOnly = True
        '
        'colVoucherPatientNo
        '
        Me.colVoucherPatientNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colVoucherPatientNo.DataPropertyName = "PatientNo"
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        Me.colVoucherPatientNo.DefaultCellStyle = DataGridViewCellStyle17
        Me.colVoucherPatientNo.HeaderText = "Patient No"
        Me.colVoucherPatientNo.Name = "colVoucherPatientNo"
        Me.colVoucherPatientNo.ReadOnly = True
        '
        'colVoucherExtraBillNo
        '
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        Me.colVoucherExtraBillNo.DefaultCellStyle = DataGridViewCellStyle18
        Me.colVoucherExtraBillNo.HeaderText = "ExtraBillNo"
        Me.colVoucherExtraBillNo.Name = "colVoucherExtraBillNo"
        Me.colVoucherExtraBillNo.ReadOnly = True
        '
        'colVoucherRoundNo
        '
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        Me.colVoucherRoundNo.DefaultCellStyle = DataGridViewCellStyle19
        Me.colVoucherRoundNo.HeaderText = "RoundNo"
        Me.colVoucherRoundNo.Name = "colVoucherRoundNo"
        Me.colVoucherRoundNo.ReadOnly = True
        '
        'colVoucherFullName
        '
        Me.colVoucherFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colVoucherFullName.DataPropertyName = "FullName"
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.colVoucherFullName.DefaultCellStyle = DataGridViewCellStyle20
        Me.colVoucherFullName.HeaderText = "Full Name"
        Me.colVoucherFullName.Name = "colVoucherFullName"
        Me.colVoucherFullName.ReadOnly = True
        Me.colVoucherFullName.Width = 150
        '
        'colVoucherItemCategory
        '
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        Me.colVoucherItemCategory.DefaultCellStyle = DataGridViewCellStyle21
        Me.colVoucherItemCategory.HeaderText = "Item Category"
        Me.colVoucherItemCategory.Name = "colVoucherItemCategory"
        Me.colVoucherItemCategory.ReadOnly = True
        '
        'colVoucherItemCategoryID
        '
        Me.colVoucherItemCategoryID.HeaderText = "Item CategoryID"
        Me.colVoucherItemCategoryID.Name = "colVoucherItemCategoryID"
        '
        'colVoucherItemCode
        '
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        Me.colVoucherItemCode.DefaultCellStyle = DataGridViewCellStyle22
        Me.colVoucherItemCode.HeaderText = "ItemCode"
        Me.colVoucherItemCode.Name = "colVoucherItemCode"
        Me.colVoucherItemCode.ReadOnly = True
        '
        'colVoucherItemName
        '
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        Me.colVoucherItemName.DefaultCellStyle = DataGridViewCellStyle23
        Me.colVoucherItemName.HeaderText = "Item Name"
        Me.colVoucherItemName.Name = "colVoucherItemName"
        Me.colVoucherItemName.ReadOnly = True
        '
        'colVoucherAmount
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        Me.colVoucherAmount.DefaultCellStyle = DataGridViewCellStyle24
        Me.colVoucherAmount.HeaderText = "Amount"
        Me.colVoucherAmount.Name = "colVoucherAmount"
        '
        'colVoucherApprovalStatus
        '
        Me.colVoucherApprovalStatus.HeaderText = "Approval Status"
        Me.colVoucherApprovalStatus.Name = "colVoucherApprovalStatus"
        '
        'colVoucherNotes
        '
        Me.colVoucherNotes.HeaderText = "Notes"
        Me.colVoucherNotes.Name = "colVoucherNotes"
        '
        'cmsAlertList
        '
        Me.cmsAlertList.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsAlertList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsAlertListCopy, Me.cmsAlertListSelectAll, Me.cmsAlertListIncludeAll, Me.cmsAlertListIncludeNone})
        Me.cmsAlertList.Name = "cmsSearch"
        Me.cmsAlertList.Size = New System.Drawing.Size(146, 92)
        '
        'cmsAlertListCopy
        '
        Me.cmsAlertListCopy.Enabled = False
        Me.cmsAlertListCopy.Image = CType(resources.GetObject("cmsAlertListCopy.Image"), System.Drawing.Image)
        Me.cmsAlertListCopy.Name = "cmsAlertListCopy"
        Me.cmsAlertListCopy.Size = New System.Drawing.Size(145, 22)
        Me.cmsAlertListCopy.Text = "Copy"
        Me.cmsAlertListCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsAlertListSelectAll
        '
        Me.cmsAlertListSelectAll.Enabled = False
        Me.cmsAlertListSelectAll.Name = "cmsAlertListSelectAll"
        Me.cmsAlertListSelectAll.Size = New System.Drawing.Size(145, 22)
        Me.cmsAlertListSelectAll.Text = "Select All"
        '
        'cmsAlertListIncludeAll
        '
        Me.cmsAlertListIncludeAll.Enabled = False
        Me.cmsAlertListIncludeAll.Name = "cmsAlertListIncludeAll"
        Me.cmsAlertListIncludeAll.Size = New System.Drawing.Size(145, 22)
        Me.cmsAlertListIncludeAll.Text = "Include All"
        '
        'cmsAlertListIncludeNone
        '
        Me.cmsAlertListIncludeNone.Enabled = False
        Me.cmsAlertListIncludeNone.Name = "cmsAlertListIncludeNone"
        Me.cmsAlertListIncludeNone.Size = New System.Drawing.Size(145, 22)
        Me.cmsAlertListIncludeNone.Text = "Include None"
        '
        'chkPrintVoucherOnSaving
        '
        Me.chkPrintVoucherOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintVoucherOnSaving.AutoSize = True
        Me.chkPrintVoucherOnSaving.Checked = True
        Me.chkPrintVoucherOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintVoucherOnSaving.Location = New System.Drawing.Point(22, 470)
        Me.chkPrintVoucherOnSaving.Name = "chkPrintVoucherOnSaving"
        Me.chkPrintVoucherOnSaving.Size = New System.Drawing.Size(146, 17)
        Me.chkPrintVoucherOnSaving.TabIndex = 143
        Me.chkPrintVoucherOnSaving.Text = " Print Voucher On Saving"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(990, 496)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 141
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(736, 10)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(206, 13)
        Me.lblRecordsNo.TabIndex = 3
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.btnExchangeRate)
        Me.pnlPeriod.Controls.Add(Me.pnlAlerts)
        Me.pnlPeriod.Controls.Add(Me.nbxExchangeRate)
        Me.pnlPeriod.Controls.Add(Me.lblExchangeRate)
        Me.pnlPeriod.Controls.Add(Me.cboCurrenciesID)
        Me.pnlPeriod.Controls.Add(Me.lblCurrenciesID)
        Me.pnlPeriod.Controls.Add(Me.stbGender)
        Me.pnlPeriod.Controls.Add(Me.lblGenderID)
        Me.pnlPeriod.Controls.Add(Me.stbVoucherStatus)
        Me.pnlPeriod.Controls.Add(Me.lblVoucherStatus)
        Me.pnlPeriod.Controls.Add(Me.lblApprovalDateTime)
        Me.pnlPeriod.Controls.Add(Me.SmartTextBox1)
        Me.pnlPeriod.Controls.Add(Me.stbVisitType)
        Me.pnlPeriod.Controls.Add(Me.lblCBFPChequeNo)
        Me.pnlPeriod.Controls.Add(Me.Label1)
        Me.pnlPeriod.Controls.Add(Me.dtpApprovalDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblVisitType)
        Me.pnlPeriod.Controls.Add(Me.stbBillModes)
        Me.pnlPeriod.Controls.Add(Me.stbSpeciality)
        Me.pnlPeriod.Controls.Add(Me.lblSpeciality)
        Me.pnlPeriod.Controls.Add(Me.stbDocumentNo)
        Me.pnlPeriod.Controls.Add(Me.lblStaffTitleID)
        Me.pnlPeriod.Controls.Add(Me.stbStaffNo)
        Me.pnlPeriod.Controls.Add(Me.stbStaffTitle)
        Me.pnlPeriod.Controls.Add(Me.stbEndDateTime)
        Me.pnlPeriod.Controls.Add(Me.cboPayModesID)
        Me.pnlPeriod.Controls.Add(Me.lblPaymentVoucherNo)
        Me.pnlPeriod.Controls.Add(Me.stbStartDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblCBFPPayModes)
        Me.pnlPeriod.Controls.Add(Me.stbPaymentVoucherNo)
        Me.pnlPeriod.Controls.Add(Me.lblFristName)
        Me.pnlPeriod.Controls.Add(Me.lblLastName)
        Me.pnlPeriod.Controls.Add(Me.stbLastName)
        Me.pnlPeriod.Controls.Add(Me.stbFirstName)
        Me.pnlPeriod.Controls.Add(Me.lblStaff)
        Me.pnlPeriod.Controls.Add(Me.lblPayModes)
        Me.pnlPeriod.Controls.Add(Me.fbnLoad)
        Me.pnlPeriod.Location = New System.Drawing.Point(6, 12)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(1044, 184)
        Me.pnlPeriod.TabIndex = 4
        '
        'btnExchangeRate
        '
        Me.btnExchangeRate.Enabled = False
        Me.btnExchangeRate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnExchangeRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExchangeRate.Image = CType(resources.GetObject("btnExchangeRate.Image"), System.Drawing.Image)
        Me.btnExchangeRate.Location = New System.Drawing.Point(452, 113)
        Me.btnExchangeRate.Name = "btnExchangeRate"
        Me.btnExchangeRate.Size = New System.Drawing.Size(27, 21)
        Me.btnExchangeRate.TabIndex = 154
        Me.btnExchangeRate.Tag = "ExchangeRates"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnPendingApprovals)
        Me.pnlAlerts.Controls.Add(Me.lblPendingVouchers)
        Me.pnlAlerts.Location = New System.Drawing.Point(742, 120)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(287, 39)
        Me.pnlAlerts.TabIndex = 149
        '
        'btnPendingApprovals
        '
        Me.btnPendingApprovals.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPendingApprovals.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPendingApprovals.Location = New System.Drawing.Point(194, 5)
        Me.btnPendingApprovals.Name = "btnPendingApprovals"
        Me.btnPendingApprovals.Size = New System.Drawing.Size(78, 24)
        Me.btnPendingApprovals.TabIndex = 1
        Me.btnPendingApprovals.Tag = ""
        Me.btnPendingApprovals.Text = "&View List"
        '
        'lblPendingVouchers
        '
        Me.lblPendingVouchers.Font = New System.Drawing.Font("Verdana", 11.25!)
        Me.lblPendingVouchers.ForeColor = System.Drawing.Color.Red
        Me.lblPendingVouchers.Location = New System.Drawing.Point(6, 7)
        Me.lblPendingVouchers.Name = "lblPendingVouchers"
        Me.lblPendingVouchers.Size = New System.Drawing.Size(182, 20)
        Me.lblPendingVouchers.TabIndex = 0
        Me.lblPendingVouchers.Text = "Pending Vouchers: 0"
        '
        'nbxExchangeRate
        '
        Me.nbxExchangeRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxExchangeRate.ControlCaption = "Exchange Rate"
        Me.nbxExchangeRate.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxExchangeRate.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxExchangeRate.DecimalPlaces = -1
        Me.nbxExchangeRate.DenyZeroEntryValue = True
        Me.nbxExchangeRate.Location = New System.Drawing.Point(487, 115)
        Me.nbxExchangeRate.MaxValue = 0.0R
        Me.nbxExchangeRate.MinValue = 0.0R
        Me.nbxExchangeRate.MustEnterNumeric = True
        Me.nbxExchangeRate.Name = "nbxExchangeRate"
        Me.nbxExchangeRate.Size = New System.Drawing.Size(191, 20)
        Me.nbxExchangeRate.TabIndex = 155
        Me.nbxExchangeRate.Value = ""
        '
        'lblExchangeRate
        '
        Me.lblExchangeRate.Location = New System.Drawing.Point(359, 116)
        Me.lblExchangeRate.Name = "lblExchangeRate"
        Me.lblExchangeRate.Size = New System.Drawing.Size(87, 20)
        Me.lblExchangeRate.TabIndex = 153
        Me.lblExchangeRate.Text = "Exchange Rate"
        '
        'cboCurrenciesID
        '
        Me.cboCurrenciesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCurrenciesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCurrenciesID.FormattingEnabled = True
        Me.cboCurrenciesID.ItemHeight = 13
        Me.cboCurrenciesID.Location = New System.Drawing.Point(134, 150)
        Me.cboCurrenciesID.Name = "cboCurrenciesID"
        Me.cboCurrenciesID.Size = New System.Drawing.Size(189, 21)
        Me.cboCurrenciesID.TabIndex = 152
        '
        'lblCurrenciesID
        '
        Me.lblCurrenciesID.Location = New System.Drawing.Point(4, 150)
        Me.lblCurrenciesID.Name = "lblCurrenciesID"
        Me.lblCurrenciesID.Size = New System.Drawing.Size(115, 20)
        Me.lblCurrenciesID.TabIndex = 151
        Me.lblCurrenciesID.Text = "Pay in Currency"
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = True
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(814, 10)
        Me.stbGender.MaxLength = 20
        Me.stbGender.Name = "stbGender"
        Me.stbGender.ReadOnly = True
        Me.stbGender.RegularExpression = ""
        Me.stbGender.Size = New System.Drawing.Size(191, 20)
        Me.stbGender.TabIndex = 150
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(694, 10)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(114, 21)
        Me.lblGenderID.TabIndex = 149
        Me.lblGenderID.Text = "Gender"
        '
        'stbVoucherStatus
        '
        Me.stbVoucherStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVoucherStatus.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVoucherStatus, "Voucher Status")
        Me.stbVoucherStatus.EntryErrorMSG = ""
        Me.stbVoucherStatus.Location = New System.Drawing.Point(134, 59)
        Me.stbVoucherStatus.MaxLength = 20
        Me.stbVoucherStatus.Name = "stbVoucherStatus"
        Me.stbVoucherStatus.ReadOnly = True
        Me.stbVoucherStatus.RegularExpression = ""
        Me.stbVoucherStatus.Size = New System.Drawing.Size(191, 20)
        Me.stbVoucherStatus.TabIndex = 139
        '
        'lblVoucherStatus
        '
        Me.lblVoucherStatus.Location = New System.Drawing.Point(6, 58)
        Me.lblVoucherStatus.Name = "lblVoucherStatus"
        Me.lblVoucherStatus.Size = New System.Drawing.Size(115, 21)
        Me.lblVoucherStatus.TabIndex = 138
        Me.lblVoucherStatus.Text = "Voucher Status"
        '
        'lblApprovalDateTime
        '
        Me.lblApprovalDateTime.Location = New System.Drawing.Point(6, 81)
        Me.lblApprovalDateTime.Name = "lblApprovalDateTime"
        Me.lblApprovalDateTime.Size = New System.Drawing.Size(115, 20)
        Me.lblApprovalDateTime.TabIndex = 118
        Me.lblApprovalDateTime.Text = "Approval DateTime"
        '
        'SmartTextBox1
        '
        Me.SmartTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SmartTextBox1.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.SmartTextBox1, "Visit Type")
        Me.SmartTextBox1.EntryErrorMSG = ""
        Me.SmartTextBox1.Location = New System.Drawing.Point(134, 38)
        Me.SmartTextBox1.MaxLength = 20
        Me.SmartTextBox1.Name = "SmartTextBox1"
        Me.SmartTextBox1.ReadOnly = True
        Me.SmartTextBox1.RegularExpression = ""
        Me.SmartTextBox1.Size = New System.Drawing.Size(191, 20)
        Me.SmartTextBox1.TabIndex = 137
        '
        'stbVisitType
        '
        Me.stbVisitType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitType.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitType, "Visit Type")
        Me.stbVisitType.EntryErrorMSG = ""
        Me.stbVisitType.Location = New System.Drawing.Point(134, 38)
        Me.stbVisitType.MaxLength = 20
        Me.stbVisitType.Name = "stbVisitType"
        Me.stbVisitType.ReadOnly = True
        Me.stbVisitType.RegularExpression = ""
        Me.stbVisitType.Size = New System.Drawing.Size(191, 20)
        Me.stbVisitType.TabIndex = 137
        '
        'lblCBFPChequeNo
        '
        Me.lblCBFPChequeNo.Location = New System.Drawing.Point(6, 128)
        Me.lblCBFPChequeNo.Name = "lblCBFPChequeNo"
        Me.lblCBFPChequeNo.Size = New System.Drawing.Size(115, 18)
        Me.lblCBFPChequeNo.TabIndex = 31
        Me.lblCBFPChequeNo.Text = "Document No."
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 21)
        Me.Label1.TabIndex = 136
        Me.Label1.Text = "Visit Type"
        '
        'dtpApprovalDateTime
        '
        Me.dtpApprovalDateTime.Checked = False
        Me.dtpApprovalDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpApprovalDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpApprovalDateTime.Location = New System.Drawing.Point(134, 81)
        Me.dtpApprovalDateTime.Name = "dtpApprovalDateTime"
        Me.dtpApprovalDateTime.ShowCheckBox = True
        Me.dtpApprovalDateTime.Size = New System.Drawing.Size(191, 20)
        Me.dtpApprovalDateTime.TabIndex = 119
        '
        'lblVisitType
        '
        Me.lblVisitType.Location = New System.Drawing.Point(6, 37)
        Me.lblVisitType.Name = "lblVisitType"
        Me.lblVisitType.Size = New System.Drawing.Size(115, 21)
        Me.lblVisitType.TabIndex = 136
        Me.lblVisitType.Text = "Visit Type"
        '
        'stbBillModes
        '
        Me.stbBillModes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillModes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillModes, "BillModes")
        Me.stbBillModes.EntryErrorMSG = ""
        Me.stbBillModes.Location = New System.Drawing.Point(487, 9)
        Me.stbBillModes.MaxLength = 20
        Me.stbBillModes.Name = "stbBillModes"
        Me.stbBillModes.ReadOnly = True
        Me.stbBillModes.RegularExpression = ""
        Me.stbBillModes.Size = New System.Drawing.Size(191, 20)
        Me.stbBillModes.TabIndex = 135
        '
        'stbSpeciality
        '
        Me.stbSpeciality.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSpeciality.CapitalizeFirstLetter = False
        Me.stbSpeciality.EntryErrorMSG = ""
        Me.stbSpeciality.Location = New System.Drawing.Point(814, 74)
        Me.stbSpeciality.MaxLength = 20
        Me.stbSpeciality.Name = "stbSpeciality"
        Me.stbSpeciality.ReadOnly = True
        Me.stbSpeciality.RegularExpression = ""
        Me.stbSpeciality.Size = New System.Drawing.Size(191, 20)
        Me.stbSpeciality.TabIndex = 127
        '
        'lblSpeciality
        '
        Me.lblSpeciality.Location = New System.Drawing.Point(694, 73)
        Me.lblSpeciality.Name = "lblSpeciality"
        Me.lblSpeciality.Size = New System.Drawing.Size(114, 21)
        Me.lblSpeciality.TabIndex = 126
        Me.lblSpeciality.Text = "Speciality"
        '
        'stbDocumentNo
        '
        Me.stbDocumentNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDocumentNo.CapitalizeFirstLetter = False
        Me.stbDocumentNo.EntryErrorMSG = ""
        Me.stbDocumentNo.Location = New System.Drawing.Point(134, 128)
        Me.stbDocumentNo.MaxLength = 12
        Me.stbDocumentNo.Name = "stbDocumentNo"
        Me.stbDocumentNo.RegularExpression = ""
        Me.stbDocumentNo.Size = New System.Drawing.Size(191, 20)
        Me.stbDocumentNo.TabIndex = 32
        '
        'stbStaffNo
        '
        Me.stbStaffNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStaffNo.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbStaffNo, "StaffFullName")
        Me.stbStaffNo.EntryErrorMSG = ""
        Me.stbStaffNo.Location = New System.Drawing.Point(814, 31)
        Me.stbStaffNo.MaxLength = 20
        Me.stbStaffNo.Name = "stbStaffNo"
        Me.stbStaffNo.ReadOnly = True
        Me.stbStaffNo.RegularExpression = ""
        Me.stbStaffNo.Size = New System.Drawing.Size(191, 20)
        Me.stbStaffNo.TabIndex = 134
        '
        'stbEndDateTime
        '
        Me.stbEndDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbEndDateTime.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbEndDateTime, "EndDateTime")
        Me.stbEndDateTime.EntryErrorMSG = ""
        Me.stbEndDateTime.Location = New System.Drawing.Point(487, 51)
        Me.stbEndDateTime.MaxLength = 20
        Me.stbEndDateTime.Name = "stbEndDateTime"
        Me.stbEndDateTime.ReadOnly = True
        Me.stbEndDateTime.RegularExpression = ""
        Me.stbEndDateTime.Size = New System.Drawing.Size(191, 20)
        Me.stbEndDateTime.TabIndex = 133
        '
        'cboPayModesID
        '
        Me.cboPayModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPayModesID.FormattingEnabled = True
        Me.cboPayModesID.ItemHeight = 13
        Me.cboPayModesID.Location = New System.Drawing.Point(134, 104)
        Me.cboPayModesID.Name = "cboPayModesID"
        Me.cboPayModesID.Size = New System.Drawing.Size(191, 21)
        Me.cboPayModesID.TabIndex = 20
        '
        'lblPaymentVoucherNo
        '
        Me.lblPaymentVoucherNo.Location = New System.Drawing.Point(6, 13)
        Me.lblPaymentVoucherNo.Name = "lblPaymentVoucherNo"
        Me.lblPaymentVoucherNo.Size = New System.Drawing.Size(115, 20)
        Me.lblPaymentVoucherNo.TabIndex = 130
        Me.lblPaymentVoucherNo.Text = "Payment Voucher No"
        '
        'stbStartDateTime
        '
        Me.stbStartDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStartDateTime.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbStartDateTime, "StartDateTime")
        Me.stbStartDateTime.EntryErrorMSG = ""
        Me.stbStartDateTime.Location = New System.Drawing.Point(487, 30)
        Me.stbStartDateTime.MaxLength = 20
        Me.stbStartDateTime.Name = "stbStartDateTime"
        Me.stbStartDateTime.ReadOnly = True
        Me.stbStartDateTime.RegularExpression = ""
        Me.stbStartDateTime.Size = New System.Drawing.Size(191, 20)
        Me.stbStartDateTime.TabIndex = 132
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(359, 50)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(114, 21)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(359, 29)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(114, 21)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCBFPPayModes
        '
        Me.lblCBFPPayModes.Location = New System.Drawing.Point(6, 105)
        Me.lblCBFPPayModes.Name = "lblCBFPPayModes"
        Me.lblCBFPPayModes.Size = New System.Drawing.Size(115, 18)
        Me.lblCBFPPayModes.TabIndex = 19
        Me.lblCBFPPayModes.Text = "Mode of Payment"
        '
        'stbPaymentVoucherNo
        '
        Me.stbPaymentVoucherNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPaymentVoucherNo.CapitalizeFirstLetter = False
        Me.stbPaymentVoucherNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPaymentVoucherNo.EntryErrorMSG = ""
        Me.stbPaymentVoucherNo.Location = New System.Drawing.Point(134, 12)
        Me.stbPaymentVoucherNo.MaxLength = 20
        Me.stbPaymentVoucherNo.Name = "stbPaymentVoucherNo"
        Me.stbPaymentVoucherNo.RegularExpression = ""
        Me.stbPaymentVoucherNo.Size = New System.Drawing.Size(129, 20)
        Me.stbPaymentVoucherNo.TabIndex = 131
        '
        'lblFristName
        '
        Me.lblFristName.Location = New System.Drawing.Point(359, 73)
        Me.lblFristName.Name = "lblFristName"
        Me.lblFristName.Size = New System.Drawing.Size(114, 21)
        Me.lblFristName.TabIndex = 118
        Me.lblFristName.Text = "First Name"
        '
        'lblLastName
        '
        Me.lblLastName.Location = New System.Drawing.Point(359, 93)
        Me.lblLastName.Name = "lblLastName"
        Me.lblLastName.Size = New System.Drawing.Size(114, 21)
        Me.lblLastName.TabIndex = 120
        Me.lblLastName.Text = "Last Name"
        '
        'stbLastName
        '
        Me.stbLastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastName.CapitalizeFirstLetter = True
        Me.stbLastName.EntryErrorMSG = ""
        Me.stbLastName.Location = New System.Drawing.Point(487, 93)
        Me.stbLastName.MaxLength = 20
        Me.stbLastName.Name = "stbLastName"
        Me.stbLastName.ReadOnly = True
        Me.stbLastName.RegularExpression = ""
        Me.stbLastName.Size = New System.Drawing.Size(191, 20)
        Me.stbLastName.TabIndex = 121
        '
        'stbFirstName
        '
        Me.stbFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFirstName.CapitalizeFirstLetter = True
        Me.stbFirstName.EntryErrorMSG = ""
        Me.stbFirstName.Location = New System.Drawing.Point(487, 72)
        Me.stbFirstName.MaxLength = 20
        Me.stbFirstName.Name = "stbFirstName"
        Me.stbFirstName.ReadOnly = True
        Me.stbFirstName.RegularExpression = ""
        Me.stbFirstName.Size = New System.Drawing.Size(191, 20)
        Me.stbFirstName.TabIndex = 119
        '
        'lblStaff
        '
        Me.lblStaff.Location = New System.Drawing.Point(694, 31)
        Me.lblStaff.Name = "lblStaff"
        Me.lblStaff.Size = New System.Drawing.Size(114, 21)
        Me.lblStaff.TabIndex = 6
        Me.lblStaff.Text = "Primary Dr. (Staff)"
        '
        'lblPayModes
        '
        Me.lblPayModes.Location = New System.Drawing.Point(359, 12)
        Me.lblPayModes.Name = "lblPayModes"
        Me.lblPayModes.Size = New System.Drawing.Size(114, 21)
        Me.lblPayModes.TabIndex = 10
        Me.lblPayModes.Text = "Bill Modes"
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(269, 10)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(56, 22)
        Me.fbnLoad.TabIndex = 5
        Me.fbnLoad.Text = "Load..."
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(22, 496)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 140
        Me.ebnSaveUpdate.Tag = "StaffPaymentsExt"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'lblAmountInWords
        '
        Me.lblAmountInWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblAmountInWords.Location = New System.Drawing.Point(475, 488)
        Me.lblAmountInWords.Name = "lblAmountInWords"
        Me.lblAmountInWords.Size = New System.Drawing.Size(96, 21)
        Me.lblAmountInWords.TabIndex = 146
        Me.lblAmountInWords.Text = "Amount in Words"
        '
        'stbAmountInWords
        '
        Me.stbAmountInWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbAmountInWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountInWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountInWords.CapitalizeFirstLetter = False
        Me.stbAmountInWords.EntryErrorMSG = ""
        Me.stbAmountInWords.Location = New System.Drawing.Point(577, 480)
        Me.stbAmountInWords.MaxLength = 100
        Me.stbAmountInWords.Multiline = True
        Me.stbAmountInWords.Name = "stbAmountInWords"
        Me.stbAmountInWords.ReadOnly = True
        Me.stbAmountInWords.RegularExpression = ""
        Me.stbAmountInWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountInWords.Size = New System.Drawing.Size(377, 39)
        Me.stbAmountInWords.TabIndex = 147
        '
        'lblTotalAmount
        '
        Me.lblTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblTotalAmount.Location = New System.Drawing.Point(178, 490)
        Me.lblTotalAmount.Name = "lblTotalAmount"
        Me.lblTotalAmount.Size = New System.Drawing.Size(96, 20)
        Me.lblTotalAmount.TabIndex = 144
        Me.lblTotalAmount.Text = "Total Amount"
        '
        'stbTotalAmount
        '
        Me.stbTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalAmount.CapitalizeFirstLetter = False
        Me.stbTotalAmount.Enabled = False
        Me.stbTotalAmount.EntryErrorMSG = ""
        Me.stbTotalAmount.Location = New System.Drawing.Point(280, 490)
        Me.stbTotalAmount.MaxLength = 20
        Me.stbTotalAmount.Name = "stbTotalAmount"
        Me.stbTotalAmount.RegularExpression = ""
        Me.stbTotalAmount.Size = New System.Drawing.Size(184, 20)
        Me.stbTotalAmount.TabIndex = 145
        Me.stbTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Location = New System.Drawing.Point(12, 12)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(1056, 203)
        Me.grpSetParameters.TabIndex = 142
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Staff Paymnet Voucher Details"
        '
        'FrmStaffPaymentsApprovals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1082, 540)
        Me.Controls.Add(Me.tbcVoucherDetails)
        Me.Controls.Add(Me.chkPrintVoucherOnSaving)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.lblAmountInWords)
        Me.Controls.Add(Me.stbAmountInWords)
        Me.Controls.Add(Me.lblTotalAmount)
        Me.Controls.Add(Me.stbTotalAmount)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmStaffPaymentsApprovals"
        Me.Text = "Staff Payments Approvals"
        Me.tbcVoucherDetails.ResumeLayout(False)
        Me.tpgVoucherDetails.ResumeLayout(False)
        CType(Me.dgvVoucherDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.pnlPeriod.PerformLayout()
        Me.pnlAlerts.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbStaffTitle As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStaffTitleID As System.Windows.Forms.Label
    Friend WithEvents tbcVoucherDetails As System.Windows.Forms.TabControl
    Friend WithEvents tpgVoucherDetails As System.Windows.Forms.TabPage
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListIncludeAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListIncludeNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents chkPrintVoucherOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents lblPaymentVoucherNo As System.Windows.Forms.Label
    Friend WithEvents stbPaymentVoucherNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents lblPayModes As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblStaff As System.Windows.Forms.Label
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents stbFirstName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountInWords As System.Windows.Forms.Label
    Friend WithEvents stbAmountInWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents stbTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbLastName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastName As System.Windows.Forms.Label
    Friend WithEvents lblFristName As System.Windows.Forms.Label
    Friend WithEvents lblSpeciality As System.Windows.Forms.Label
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents stbSpeciality As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitType As System.Windows.Forms.Label
    Friend WithEvents stbBillModes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbStaffNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbEndDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbStartDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboPayModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCBFPPayModes As System.Windows.Forms.Label
    Friend WithEvents lblCBFPChequeNo As System.Windows.Forms.Label
    Friend WithEvents stbDocumentNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblApprovalDateTime As System.Windows.Forms.Label
    Friend WithEvents dtpApprovalDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvVoucherDetails As System.Windows.Forms.DataGridView
    Friend WithEvents stbVoucherStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVoucherStatus As System.Windows.Forms.Label
    Friend WithEvents SmartTextBox1 As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents btnExchangeRate As System.Windows.Forms.Button
    Friend WithEvents nbxExchangeRate As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblExchangeRate As System.Windows.Forms.Label
    Friend WithEvents cboCurrenciesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCurrenciesID As System.Windows.Forms.Label
    Friend WithEvents colVoucherInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colVoucherVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVoucherPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVoucherExtraBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVoucherRoundNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVoucherFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVoucherItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVoucherItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVoucherItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVoucherItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVoucherAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVoucherApprovalStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colVoucherNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnPendingApprovals As System.Windows.Forms.Button
    Friend WithEvents lblPendingVouchers As System.Windows.Forms.Label
End Class
