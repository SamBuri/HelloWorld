<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSagePastel
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSagePastel))
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvSagePastel = New System.Windows.Forms.DataGridView()
        Me.colline = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPeriod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAccountName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTaxType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTaxAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTaxAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColProject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcSage = New System.Windows.Forms.TabControl()
        Me.tpOpdItems = New System.Windows.Forms.TabPage()
        Me.tpIPDItems = New System.Windows.Forms.TabPage()
        Me.dgvIPDSagePastel = New System.Windows.Forms.DataGridView()
        Me.ColIPDline = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDPeriod = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDAccountName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDReference = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDDebit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDCredit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDTaxType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDTaxAccount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDTaxAmmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDProject = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbAmountWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblExpenditureTotalAmount = New System.Windows.Forms.Label()
        Me.lblExpenditureAmountWords = New System.Windows.Forms.Label()
        Me.stbTotalAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbOPDSageAmountInWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblOPDSageAmount = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.stbOPDSageAmount = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        CType(Me.dgvSagePastel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcSage.SuspendLayout()
        Me.tpOpdItems.SuspendLayout()
        Me.tpIPDItems.SuspendLayout()
        CType(Me.dgvIPDSagePastel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpSetParameters.Controls.Add(Me.fbnExport)
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(6, 12)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(1006, 59)
        Me.grpSetParameters.TabIndex = 1
        Me.grpSetParameters.TabStop = False
        '
        'fbnExport
        '
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(725, 18)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(74, 22)
        Me.fbnExport.TabIndex = 6
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblStartDateTime)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblEndDateTime)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 15)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(631, 31)
        Me.pnlPeriod.TabIndex = 0
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(457, 5)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(167, 20)
        Me.dtpEndDateTime.TabIndex = 3
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(10, 5)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(133, 20)
        Me.lblStartDateTime.TabIndex = 0
        Me.lblStartDateTime.Text = "Start Record Date && Time"
        Me.lblStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(147, 5)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(168, 20)
        Me.dtpStartDateTime.TabIndex = 1
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(321, 4)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(130, 20)
        Me.lblEndDateTime.TabIndex = 2
        Me.lblEndDateTime.Text = "End Record Date && Time"
        Me.lblEndDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(805, 19)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(185, 19)
        Me.lblRecordsNo.TabIndex = 1
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(645, 18)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(74, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "&Load"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(933, 458)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(79, 24)
        Me.fbnClose.TabIndex = 6
        Me.fbnClose.Text = "Close"
        '
        'dgvSagePastel
        '
        Me.dgvSagePastel.AllowUserToAddRows = False
        Me.dgvSagePastel.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvSagePastel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSagePastel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSagePastel.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvSagePastel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvSagePastel.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSagePastel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSagePastel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSagePastel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colline, Me.ColDate, Me.ColPeriod, Me.ColAccount, Me.ColAccountName, Me.ColReference, Me.ColDescription, Me.ColDebit, Me.ColCredit, Me.ColTaxType, Me.ColTaxAccount, Me.ColTaxAmount, Me.ColProject})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSagePastel.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSagePastel.GridColor = System.Drawing.Color.Khaki
        Me.dgvSagePastel.Location = New System.Drawing.Point(3, 3)
        Me.dgvSagePastel.Name = "dgvSagePastel"
        Me.dgvSagePastel.ReadOnly = True
        Me.dgvSagePastel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSagePastel.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvSagePastel.RowHeadersVisible = False
        Me.dgvSagePastel.Size = New System.Drawing.Size(992, 283)
        Me.dgvSagePastel.TabIndex = 22
        Me.dgvSagePastel.Text = "DataGridView1"
        '
        'colline
        '
        Me.colline.HeaderText = "Line"
        Me.colline.Name = "colline"
        Me.colline.ReadOnly = True
        '
        'ColDate
        '
        Me.ColDate.DataPropertyName = "Date"
        Me.ColDate.HeaderText = "Date"
        Me.ColDate.Name = "ColDate"
        Me.ColDate.ReadOnly = True
        '
        'ColPeriod
        '
        Me.ColPeriod.HeaderText = "Period"
        Me.ColPeriod.Name = "ColPeriod"
        Me.ColPeriod.ReadOnly = True
        Me.ColPeriod.Width = 150
        '
        'ColAccount
        '
        Me.ColAccount.DataPropertyName = "Account"
        Me.ColAccount.HeaderText = "Account"
        Me.ColAccount.Name = "ColAccount"
        Me.ColAccount.ReadOnly = True
        '
        'ColAccountName
        '
        Me.ColAccountName.HeaderText = "Account Name"
        Me.ColAccountName.Name = "ColAccountName"
        Me.ColAccountName.ReadOnly = True
        '
        'ColReference
        '
        Me.ColReference.DataPropertyName = "Reference"
        Me.ColReference.HeaderText = "Reference"
        Me.ColReference.Name = "ColReference"
        Me.ColReference.ReadOnly = True
        '
        'ColDescription
        '
        Me.ColDescription.DataPropertyName = "Description"
        Me.ColDescription.HeaderText = "Description"
        Me.ColDescription.Name = "ColDescription"
        Me.ColDescription.ReadOnly = True
        '
        'ColDebit
        '
        Me.ColDebit.DataPropertyName = "Debit"
        Me.ColDebit.HeaderText = "Debit"
        Me.ColDebit.Name = "ColDebit"
        Me.ColDebit.ReadOnly = True
        '
        'ColCredit
        '
        Me.ColCredit.HeaderText = "Credit"
        Me.ColCredit.Name = "ColCredit"
        Me.ColCredit.ReadOnly = True
        '
        'ColTaxType
        '
        Me.ColTaxType.HeaderText = "Tax Type"
        Me.ColTaxType.Name = "ColTaxType"
        Me.ColTaxType.ReadOnly = True
        '
        'ColTaxAccount
        '
        Me.ColTaxAccount.HeaderText = "Tax Account"
        Me.ColTaxAccount.Name = "ColTaxAccount"
        Me.ColTaxAccount.ReadOnly = True
        '
        'ColTaxAmount
        '
        Me.ColTaxAmount.HeaderText = "Tax Amount"
        Me.ColTaxAmount.Name = "ColTaxAmount"
        Me.ColTaxAmount.ReadOnly = True
        '
        'ColProject
        '
        Me.ColProject.DataPropertyName = "Project"
        Me.ColProject.HeaderText = "Project"
        Me.ColProject.Name = "ColProject"
        Me.ColProject.ReadOnly = True
        '
        'tbcSage
        '
        Me.tbcSage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcSage.Controls.Add(Me.tpOpdItems)
        Me.tbcSage.Controls.Add(Me.tpIPDItems)
        Me.tbcSage.Location = New System.Drawing.Point(6, 78)
        Me.tbcSage.Name = "tbcSage"
        Me.tbcSage.SelectedIndex = 0
        Me.tbcSage.Size = New System.Drawing.Size(1006, 362)
        Me.tbcSage.TabIndex = 23
        '
        'tpOpdItems
        '
        Me.tpOpdItems.Controls.Add(Me.stbOPDSageAmountInWords)
        Me.tpOpdItems.Controls.Add(Me.lblOPDSageAmount)
        Me.tpOpdItems.Controls.Add(Me.Label2)
        Me.tpOpdItems.Controls.Add(Me.stbOPDSageAmount)
        Me.tpOpdItems.Controls.Add(Me.dgvSagePastel)
        Me.tpOpdItems.Location = New System.Drawing.Point(4, 22)
        Me.tpOpdItems.Name = "tpOpdItems"
        Me.tpOpdItems.Padding = New System.Windows.Forms.Padding(3)
        Me.tpOpdItems.Size = New System.Drawing.Size(998, 336)
        Me.tpOpdItems.TabIndex = 0
        Me.tpOpdItems.Text = "OPD Items"
        Me.tpOpdItems.UseVisualStyleBackColor = True
        '
        'tpIPDItems
        '
        Me.tpIPDItems.Controls.Add(Me.stbAmountWords)
        Me.tpIPDItems.Controls.Add(Me.lblExpenditureTotalAmount)
        Me.tpIPDItems.Controls.Add(Me.lblExpenditureAmountWords)
        Me.tpIPDItems.Controls.Add(Me.stbTotalAmount)
        Me.tpIPDItems.Controls.Add(Me.dgvIPDSagePastel)
        Me.tpIPDItems.Location = New System.Drawing.Point(4, 22)
        Me.tpIPDItems.Name = "tpIPDItems"
        Me.tpIPDItems.Padding = New System.Windows.Forms.Padding(3)
        Me.tpIPDItems.Size = New System.Drawing.Size(998, 336)
        Me.tpIPDItems.TabIndex = 1
        Me.tpIPDItems.Text = "IPDI tems"
        Me.tpIPDItems.UseVisualStyleBackColor = True
        '
        'dgvIPDSagePastel
        '
        Me.dgvIPDSagePastel.AllowUserToAddRows = False
        Me.dgvIPDSagePastel.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIPDSagePastel.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvIPDSagePastel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvIPDSagePastel.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDSagePastel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvIPDSagePastel.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIPDSagePastel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDSagePastel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvIPDSagePastel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIPDline, Me.ColIPDDate, Me.ColIPDPeriod, Me.ColIPDAccount, Me.ColIPDAccountName, Me.ColIPDReference, Me.ColIPDDescription, Me.ColIPDDebit, Me.ColIPDCredit, Me.ColIPDTaxType, Me.ColIPDTaxAccount, Me.ColIPDTaxAmmount, Me.ColIPDProject})
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvIPDSagePastel.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvIPDSagePastel.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDSagePastel.Location = New System.Drawing.Point(3, 3)
        Me.dgvIPDSagePastel.Name = "dgvIPDSagePastel"
        Me.dgvIPDSagePastel.ReadOnly = True
        Me.dgvIPDSagePastel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDSagePastel.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvIPDSagePastel.RowHeadersVisible = False
        Me.dgvIPDSagePastel.Size = New System.Drawing.Size(992, 282)
        Me.dgvIPDSagePastel.TabIndex = 23
        Me.dgvIPDSagePastel.Text = "DataGridView1"
        '
        'ColIPDline
        '
        Me.ColIPDline.HeaderText = "Line"
        Me.ColIPDline.Name = "ColIPDline"
        Me.ColIPDline.ReadOnly = True
        '
        'ColIPDDate
        '
        Me.ColIPDDate.DataPropertyName = "Date"
        Me.ColIPDDate.HeaderText = "Date"
        Me.ColIPDDate.Name = "ColIPDDate"
        Me.ColIPDDate.ReadOnly = True
        '
        'ColIPDPeriod
        '
        Me.ColIPDPeriod.HeaderText = "Period"
        Me.ColIPDPeriod.Name = "ColIPDPeriod"
        Me.ColIPDPeriod.ReadOnly = True
        Me.ColIPDPeriod.Width = 150
        '
        'ColIPDAccount
        '
        Me.ColIPDAccount.DataPropertyName = "Account"
        Me.ColIPDAccount.HeaderText = "Account"
        Me.ColIPDAccount.Name = "ColIPDAccount"
        Me.ColIPDAccount.ReadOnly = True
        '
        'ColIPDAccountName
        '
        Me.ColIPDAccountName.HeaderText = "Account Name"
        Me.ColIPDAccountName.Name = "ColIPDAccountName"
        Me.ColIPDAccountName.ReadOnly = True
        '
        'ColIPDReference
        '
        Me.ColIPDReference.DataPropertyName = "Reference"
        Me.ColIPDReference.HeaderText = "Reference"
        Me.ColIPDReference.Name = "ColIPDReference"
        Me.ColIPDReference.ReadOnly = True
        '
        'ColIPDDescription
        '
        Me.ColIPDDescription.DataPropertyName = "Description"
        Me.ColIPDDescription.HeaderText = "Description"
        Me.ColIPDDescription.Name = "ColIPDDescription"
        Me.ColIPDDescription.ReadOnly = True
        '
        'ColIPDDebit
        '
        Me.ColIPDDebit.DataPropertyName = "Debit"
        Me.ColIPDDebit.HeaderText = "Debit"
        Me.ColIPDDebit.Name = "ColIPDDebit"
        Me.ColIPDDebit.ReadOnly = True
        '
        'ColIPDCredit
        '
        Me.ColIPDCredit.HeaderText = "Credit"
        Me.ColIPDCredit.Name = "ColIPDCredit"
        Me.ColIPDCredit.ReadOnly = True
        '
        'ColIPDTaxType
        '
        Me.ColIPDTaxType.HeaderText = "Tax Type"
        Me.ColIPDTaxType.Name = "ColIPDTaxType"
        Me.ColIPDTaxType.ReadOnly = True
        '
        'ColIPDTaxAccount
        '
        Me.ColIPDTaxAccount.HeaderText = "Tax Account"
        Me.ColIPDTaxAccount.Name = "ColIPDTaxAccount"
        Me.ColIPDTaxAccount.ReadOnly = True
        '
        'ColIPDTaxAmmount
        '
        Me.ColIPDTaxAmmount.HeaderText = "Tax Amount"
        Me.ColIPDTaxAmmount.Name = "ColIPDTaxAmmount"
        Me.ColIPDTaxAmmount.ReadOnly = True
        '
        'ColIPDProject
        '
        Me.ColIPDProject.DataPropertyName = "Project"
        Me.ColIPDProject.HeaderText = "Project"
        Me.ColIPDProject.Name = "ColIPDProject"
        Me.ColIPDProject.ReadOnly = True
        '
        'stbAmountWords
        '
        Me.stbAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbAmountWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountWords.CapitalizeFirstLetter = False
        Me.stbAmountWords.EntryErrorMSG = ""
        Me.stbAmountWords.Location = New System.Drawing.Point(570, 291)
        Me.stbAmountWords.MaxLength = 100
        Me.stbAmountWords.Multiline = True
        Me.stbAmountWords.Name = "stbAmountWords"
        Me.stbAmountWords.ReadOnly = True
        Me.stbAmountWords.RegularExpression = ""
        Me.stbAmountWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAmountWords.Size = New System.Drawing.Size(416, 39)
        Me.stbAmountWords.TabIndex = 27
        '
        'lblExpenditureTotalAmount
        '
        Me.lblExpenditureTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpenditureTotalAmount.Location = New System.Drawing.Point(8, 309)
        Me.lblExpenditureTotalAmount.Name = "lblExpenditureTotalAmount"
        Me.lblExpenditureTotalAmount.Size = New System.Drawing.Size(84, 20)
        Me.lblExpenditureTotalAmount.TabIndex = 24
        Me.lblExpenditureTotalAmount.Text = "Total Amount"
        '
        'lblExpenditureAmountWords
        '
        Me.lblExpenditureAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpenditureAmountWords.Location = New System.Drawing.Point(428, 309)
        Me.lblExpenditureAmountWords.Name = "lblExpenditureAmountWords"
        Me.lblExpenditureAmountWords.Size = New System.Drawing.Size(126, 21)
        Me.lblExpenditureAmountWords.TabIndex = 26
        Me.lblExpenditureAmountWords.Text = "Amount in Words"
        '
        'stbTotalAmount
        '
        Me.stbTotalAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbTotalAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbTotalAmount.CapitalizeFirstLetter = False
        Me.stbTotalAmount.Enabled = False
        Me.stbTotalAmount.EntryErrorMSG = ""
        Me.stbTotalAmount.Location = New System.Drawing.Point(98, 309)
        Me.stbTotalAmount.MaxLength = 20
        Me.stbTotalAmount.Name = "stbTotalAmount"
        Me.stbTotalAmount.RegularExpression = ""
        Me.stbTotalAmount.Size = New System.Drawing.Size(283, 20)
        Me.stbTotalAmount.TabIndex = 25
        Me.stbTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbOPDSageAmountInWords
        '
        Me.stbOPDSageAmountInWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbOPDSageAmountInWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbOPDSageAmountInWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOPDSageAmountInWords.CapitalizeFirstLetter = False
        Me.stbOPDSageAmountInWords.EntryErrorMSG = ""
        Me.stbOPDSageAmountInWords.Location = New System.Drawing.Point(570, 292)
        Me.stbOPDSageAmountInWords.MaxLength = 100
        Me.stbOPDSageAmountInWords.Multiline = True
        Me.stbOPDSageAmountInWords.Name = "stbOPDSageAmountInWords"
        Me.stbOPDSageAmountInWords.ReadOnly = True
        Me.stbOPDSageAmountInWords.RegularExpression = ""
        Me.stbOPDSageAmountInWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbOPDSageAmountInWords.Size = New System.Drawing.Size(416, 39)
        Me.stbOPDSageAmountInWords.TabIndex = 31
        '
        'lblOPDSageAmount
        '
        Me.lblOPDSageAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblOPDSageAmount.Location = New System.Drawing.Point(6, 309)
        Me.lblOPDSageAmount.Name = "lblOPDSageAmount"
        Me.lblOPDSageAmount.Size = New System.Drawing.Size(84, 20)
        Me.lblOPDSageAmount.TabIndex = 28
        Me.lblOPDSageAmount.Text = "Total Amount"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(438, 308)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 21)
        Me.Label2.TabIndex = 30
        Me.Label2.Text = "Amount in Words"
        '
        'stbOPDSageAmount
        '
        Me.stbOPDSageAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbOPDSageAmount.BackColor = System.Drawing.SystemColors.Info
        Me.stbOPDSageAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOPDSageAmount.CapitalizeFirstLetter = False
        Me.stbOPDSageAmount.Enabled = False
        Me.stbOPDSageAmount.EntryErrorMSG = ""
        Me.stbOPDSageAmount.Location = New System.Drawing.Point(107, 309)
        Me.stbOPDSageAmount.MaxLength = 20
        Me.stbOPDSageAmount.Name = "stbOPDSageAmount"
        Me.stbOPDSageAmount.RegularExpression = ""
        Me.stbOPDSageAmount.Size = New System.Drawing.Size(252, 20)
        Me.stbOPDSageAmount.TabIndex = 29
        Me.stbOPDSageAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'frmSagePastel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 492)
        Me.Controls.Add(Me.tbcSage)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSagePastel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Export to Sage Pastel"
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        CType(Me.dgvSagePastel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcSage.ResumeLayout(False)
        Me.tpOpdItems.ResumeLayout(False)
        Me.tpOpdItems.PerformLayout()
        Me.tpIPDItems.ResumeLayout(False)
        Me.tpIPDItems.PerformLayout()
        CType(Me.dgvIPDSagePastel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDateTime As System.Windows.Forms.Label
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDateTime As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvSagePastel As System.Windows.Forms.DataGridView
    Friend WithEvents colline As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPeriod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAccount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAccountName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColReference As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTaxType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTaxAccount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTaxAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColProject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tbcSage As System.Windows.Forms.TabControl
    Friend WithEvents tpOpdItems As System.Windows.Forms.TabPage
    Friend WithEvents tpIPDItems As System.Windows.Forms.TabPage
    Friend WithEvents dgvIPDSagePastel As System.Windows.Forms.DataGridView
    Friend WithEvents ColIPDline As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDPeriod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDAccount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDAccountName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDReference As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDDebit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDCredit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDTaxType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDTaxAccount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDTaxAmmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDProject As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stbAmountWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExpenditureTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblExpenditureAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbTotalAmount As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbOPDSageAmountInWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblOPDSageAmount As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents stbOPDSageAmount As SyncSoft.Common.Win.Controls.SmartTextBox
End Class
