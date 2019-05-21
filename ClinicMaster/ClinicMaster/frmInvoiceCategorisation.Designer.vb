<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInvoiceCategorisation
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInvoiceCategorisation))
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.cboAccountNo = New System.Windows.Forms.ComboBox()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.fbnRefresh = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.cboBillMode = New System.Windows.Forms.ComboBox()
        Me.tbcInvoiceCategorisation = New System.Windows.Forms.TabControl()
        Me.tpgOutpatient = New System.Windows.Forms.TabPage()
        Me.dgvOutPatientInvoiceCategorisation = New System.Windows.Forms.DataGridView()
        Me.tpgInPatient = New System.Windows.Forms.TabPage()
        Me.dgvInPatientInvoiceCategorisation = New System.Windows.Forms.DataGridView()
        Me.stbPatientChequePaymentsWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblExpenditureTotalAmount = New System.Windows.Forms.Label()
        Me.lblExpenditureAmountWords = New System.Windows.Forms.Label()
        Me.stbPatientChequePayments = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.stbAccountName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAccountName = New System.Windows.Forms.Label()
        Me.nbxAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAccountBalance = New System.Windows.Forms.Label()
        Me.nbxOutstandingBill = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblOutstandingBill = New System.Windows.Forms.Label()
        Me.chkExcludePendingItems = New System.Windows.Forms.CheckBox()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.ColInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMainMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColClaimReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colvisitdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMemberCardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colservices = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDrug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColConsumable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLaboratory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRadiology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPathology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDental = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTheatre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColOptical = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColProcedureID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColExtras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColMaternity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColICUID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColEye = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAdmission = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPackages = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDMainMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDClaimReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDvisitdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDMemberCardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDservices = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDDrug = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDConsumable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDLaboratory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDRadiology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDPathology = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colIPDDental = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDTheatre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDOptical = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDProcedureID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDExtras = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDMaternity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDICUID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDEye = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDAdmission = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDPackages = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColIPDTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcInvoiceCategorisation.SuspendLayout()
        Me.tpgOutpatient.SuspendLayout()
        CType(Me.dgvOutPatientInvoiceCategorisation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInPatient.SuspendLayout()
        CType(Me.dgvInPatientInvoiceCategorisation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(391, 33)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 43
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        Me.btnLoad.Visible = False
        '
        'cboAccountNo
        '
        Me.cboAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboAccountNo.DropDownWidth = 256
        Me.cboAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountNo.FormattingEnabled = True
        Me.cboAccountNo.ItemHeight = 13
        Me.cboAccountNo.Location = New System.Drawing.Point(202, 33)
        Me.cboAccountNo.Name = "cboAccountNo"
        Me.cboAccountNo.Size = New System.Drawing.Size(183, 21)
        Me.cboAccountNo.TabIndex = 42
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(6, 33)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(154, 18)
        Me.lblAccountNo.TabIndex = 41
        Me.lblAccountNo.Text = "Account No"
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(202, 77)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(183, 20)
        Me.dtpEndDateTime.TabIndex = 32
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(6, 79)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(154, 20)
        Me.lblEndDateTime.TabIndex = 31
        Me.lblEndDateTime.Text = "End Record Date Time"
        Me.lblEndDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(202, 55)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(183, 20)
        Me.dtpStartDateTime.TabIndex = 30
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(6, 55)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(154, 20)
        Me.lblStartDateTime.TabIndex = 29
        Me.lblStartDateTime.Text = "Start Record Date Time"
        Me.lblStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnRefresh
        '
        Me.fbnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnRefresh.Location = New System.Drawing.Point(693, 99)
        Me.fbnRefresh.Name = "fbnRefresh"
        Me.fbnRefresh.Size = New System.Drawing.Size(74, 22)
        Me.fbnRefresh.TabIndex = 40
        Me.fbnRefresh.Text = "&Refresh"
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(613, 99)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(74, 22)
        Me.fbnLoad.TabIndex = 39
        Me.fbnLoad.Text = "&Load"
        '
        'cboBillMode
        '
        Me.cboBillMode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillMode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillMode.DropDownWidth = 300
        Me.cboBillMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillMode.FormattingEnabled = True
        Me.cboBillMode.Location = New System.Drawing.Point(202, 8)
        Me.cboBillMode.MaxLength = 20
        Me.cboBillMode.Name = "cboBillMode"
        Me.cboBillMode.Size = New System.Drawing.Size(183, 21)
        Me.cboBillMode.TabIndex = 27
        '
        'tbcInvoiceCategorisation
        '
        Me.tbcInvoiceCategorisation.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcInvoiceCategorisation.Controls.Add(Me.tpgOutpatient)
        Me.tbcInvoiceCategorisation.Controls.Add(Me.tpgInPatient)
        Me.tbcInvoiceCategorisation.HotTrack = True
        Me.tbcInvoiceCategorisation.Location = New System.Drawing.Point(9, 127)
        Me.tbcInvoiceCategorisation.Name = "tbcInvoiceCategorisation"
        Me.tbcInvoiceCategorisation.SelectedIndex = 0
        Me.tbcInvoiceCategorisation.Size = New System.Drawing.Size(895, 339)
        Me.tbcInvoiceCategorisation.TabIndex = 23
        '
        'tpgOutpatient
        '
        Me.tpgOutpatient.Controls.Add(Me.dgvOutPatientInvoiceCategorisation)
        Me.tpgOutpatient.Location = New System.Drawing.Point(4, 22)
        Me.tpgOutpatient.Name = "tpgOutpatient"
        Me.tpgOutpatient.Size = New System.Drawing.Size(887, 313)
        Me.tpgOutpatient.TabIndex = 8
        Me.tpgOutpatient.Tag = ""
        Me.tpgOutpatient.Text = "Out patient"
        Me.tpgOutpatient.UseVisualStyleBackColor = True
        '
        'dgvOutPatientInvoiceCategorisation
        '
        Me.dgvOutPatientInvoiceCategorisation.AllowUserToAddRows = False
        Me.dgvOutPatientInvoiceCategorisation.AllowUserToDeleteRows = False
        Me.dgvOutPatientInvoiceCategorisation.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvOutPatientInvoiceCategorisation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOutPatientInvoiceCategorisation.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOutPatientInvoiceCategorisation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOutPatientInvoiceCategorisation.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOutPatientInvoiceCategorisation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOutPatientInvoiceCategorisation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOutPatientInvoiceCategorisation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColInvoiceNo, Me.ColMainMemberName, Me.colFullName, Me.ColClaimReferenceNo, Me.colvisitdate, Me.colVisitNo, Me.colMemberCardNo, Me.colBillCustomerName, Me.colservices, Me.ColDrug, Me.ColConsumable, Me.ColLaboratory, Me.ColRadiology, Me.ColPathology, Me.colDental, Me.ColTheatre, Me.ColOptical, Me.ColProcedureID, Me.ColExtras, Me.ColMaternity, Me.ColICUID, Me.ColEye, Me.ColAdmission, Me.ColPackages, Me.ColTotal})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOutPatientInvoiceCategorisation.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvOutPatientInvoiceCategorisation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOutPatientInvoiceCategorisation.EnableHeadersVisualStyles = False
        Me.dgvOutPatientInvoiceCategorisation.GridColor = System.Drawing.Color.Khaki
        Me.dgvOutPatientInvoiceCategorisation.Location = New System.Drawing.Point(0, 0)
        Me.dgvOutPatientInvoiceCategorisation.Name = "dgvOutPatientInvoiceCategorisation"
        Me.dgvOutPatientInvoiceCategorisation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOutPatientInvoiceCategorisation.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvOutPatientInvoiceCategorisation.RowHeadersVisible = False
        Me.dgvOutPatientInvoiceCategorisation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOutPatientInvoiceCategorisation.Size = New System.Drawing.Size(887, 313)
        Me.dgvOutPatientInvoiceCategorisation.TabIndex = 0
        Me.dgvOutPatientInvoiceCategorisation.Text = "DataGridView1"
        '
        'tpgInPatient
        '
        Me.tpgInPatient.Controls.Add(Me.dgvInPatientInvoiceCategorisation)
        Me.tpgInPatient.Controls.Add(Me.stbPatientChequePaymentsWords)
        Me.tpgInPatient.Controls.Add(Me.lblExpenditureTotalAmount)
        Me.tpgInPatient.Controls.Add(Me.lblExpenditureAmountWords)
        Me.tpgInPatient.Controls.Add(Me.stbPatientChequePayments)
        Me.tpgInPatient.Location = New System.Drawing.Point(4, 22)
        Me.tpgInPatient.Name = "tpgInPatient"
        Me.tpgInPatient.Size = New System.Drawing.Size(887, 313)
        Me.tpgInPatient.TabIndex = 7
        Me.tpgInPatient.Tag = ""
        Me.tpgInPatient.Text = "In Patient"
        Me.tpgInPatient.UseVisualStyleBackColor = True
        '
        'dgvInPatientInvoiceCategorisation
        '
        Me.dgvInPatientInvoiceCategorisation.AllowUserToAddRows = False
        Me.dgvInPatientInvoiceCategorisation.AllowUserToDeleteRows = False
        Me.dgvInPatientInvoiceCategorisation.AllowUserToOrderColumns = True
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvInPatientInvoiceCategorisation.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvInPatientInvoiceCategorisation.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInPatientInvoiceCategorisation.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInPatientInvoiceCategorisation.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInPatientInvoiceCategorisation.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInPatientInvoiceCategorisation.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvInPatientInvoiceCategorisation.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColIPDInvoiceNo, Me.ColIPDMainMemberName, Me.colIPDFullName, Me.ColIPDClaimReferenceNo, Me.colIPDvisitdate, Me.colIPDVisitNo, Me.colIPDMemberCardNo, Me.colIPDBillCustomerName, Me.colIPDservices, Me.ColIPDDrug, Me.ColIPDConsumable, Me.ColIPDLaboratory, Me.ColIPDRadiology, Me.ColIPDPathology, Me.colIPDDental, Me.ColIPDTheatre, Me.ColIPDOptical, Me.ColIPDProcedureID, Me.ColIPDExtras, Me.ColIPDMaternity, Me.ColIPDICUID, Me.ColIPDEye, Me.ColIPDAdmission, Me.ColIPDPackages, Me.ColIPDTotal})
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvInPatientInvoiceCategorisation.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgvInPatientInvoiceCategorisation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInPatientInvoiceCategorisation.EnableHeadersVisualStyles = False
        Me.dgvInPatientInvoiceCategorisation.GridColor = System.Drawing.Color.Khaki
        Me.dgvInPatientInvoiceCategorisation.Location = New System.Drawing.Point(0, 0)
        Me.dgvInPatientInvoiceCategorisation.Name = "dgvInPatientInvoiceCategorisation"
        Me.dgvInPatientInvoiceCategorisation.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInPatientInvoiceCategorisation.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvInPatientInvoiceCategorisation.RowHeadersVisible = False
        Me.dgvInPatientInvoiceCategorisation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvInPatientInvoiceCategorisation.Size = New System.Drawing.Size(887, 313)
        Me.dgvInPatientInvoiceCategorisation.TabIndex = 13
        Me.dgvInPatientInvoiceCategorisation.Text = "DataGridView1"
        '
        'stbPatientChequePaymentsWords
        '
        Me.stbPatientChequePaymentsWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.stbPatientChequePaymentsWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientChequePaymentsWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientChequePaymentsWords.CapitalizeFirstLetter = False
        Me.stbPatientChequePaymentsWords.EntryErrorMSG = ""
        Me.stbPatientChequePaymentsWords.Location = New System.Drawing.Point(419, 345)
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
        Me.lblExpenditureTotalAmount.Location = New System.Drawing.Point(7, 358)
        Me.lblExpenditureTotalAmount.Name = "lblExpenditureTotalAmount"
        Me.lblExpenditureTotalAmount.Size = New System.Drawing.Size(84, 20)
        Me.lblExpenditureTotalAmount.TabIndex = 9
        Me.lblExpenditureTotalAmount.Text = "Total Amount"
        '
        'lblExpenditureAmountWords
        '
        Me.lblExpenditureAmountWords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblExpenditureAmountWords.Location = New System.Drawing.Point(287, 358)
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
        Me.stbPatientChequePayments.Location = New System.Drawing.Point(97, 356)
        Me.stbPatientChequePayments.MaxLength = 20
        Me.stbPatientChequePayments.Name = "stbPatientChequePayments"
        Me.stbPatientChequePayments.RegularExpression = ""
        Me.stbPatientChequePayments.Size = New System.Drawing.Size(184, 20)
        Me.stbPatientChequePayments.TabIndex = 10
        Me.stbPatientChequePayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(832, 472)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 28
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(8, 11)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(188, 20)
        Me.lblBillMode.TabIndex = 24
        Me.lblBillMode.Text = "Account Category"
        '
        'stbAccountName
        '
        Me.stbAccountName.AllowDrop = True
        Me.stbAccountName.BackColor = System.Drawing.SystemColors.Info
        Me.stbAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAccountName.CapitalizeFirstLetter = False
        Me.stbAccountName.EntryErrorMSG = ""
        Me.stbAccountName.Location = New System.Drawing.Point(677, 13)
        Me.stbAccountName.Name = "stbAccountName"
        Me.stbAccountName.ReadOnly = True
        Me.stbAccountName.RegularExpression = ""
        Me.stbAccountName.Size = New System.Drawing.Size(170, 20)
        Me.stbAccountName.TabIndex = 34
        '
        'lblAccountName
        '
        Me.lblAccountName.Location = New System.Drawing.Point(471, 13)
        Me.lblAccountName.Name = "lblAccountName"
        Me.lblAccountName.Size = New System.Drawing.Size(200, 20)
        Me.lblAccountName.TabIndex = 33
        Me.lblAccountName.Text = "Account Name"
        '
        'nbxAccountBalance
        '
        Me.nbxAccountBalance.AllowDrop = True
        Me.nbxAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAccountBalance.ControlCaption = "Account Balance"
        Me.nbxAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAccountBalance.DecimalPlaces = -1
        Me.nbxAccountBalance.Location = New System.Drawing.Point(677, 34)
        Me.nbxAccountBalance.MaxValue = 0.0R
        Me.nbxAccountBalance.MinValue = 0.0R
        Me.nbxAccountBalance.MustEnterNumeric = True
        Me.nbxAccountBalance.Name = "nbxAccountBalance"
        Me.nbxAccountBalance.ReadOnly = True
        Me.nbxAccountBalance.Size = New System.Drawing.Size(170, 20)
        Me.nbxAccountBalance.TabIndex = 36
        Me.nbxAccountBalance.Value = ""
        '
        'lblAccountBalance
        '
        Me.lblAccountBalance.Location = New System.Drawing.Point(471, 33)
        Me.lblAccountBalance.Name = "lblAccountBalance"
        Me.lblAccountBalance.Size = New System.Drawing.Size(200, 20)
        Me.lblAccountBalance.TabIndex = 35
        Me.lblAccountBalance.Text = "Account Balance"
        '
        'nbxOutstandingBill
        '
        Me.nbxOutstandingBill.AllowDrop = True
        Me.nbxOutstandingBill.BackColor = System.Drawing.SystemColors.Info
        Me.nbxOutstandingBill.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxOutstandingBill.ControlCaption = "Outstanding Bill"
        Me.nbxOutstandingBill.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxOutstandingBill.DecimalPlaces = -1
        Me.nbxOutstandingBill.Location = New System.Drawing.Point(677, 55)
        Me.nbxOutstandingBill.MaxValue = 0.0R
        Me.nbxOutstandingBill.MinValue = 0.0R
        Me.nbxOutstandingBill.MustEnterNumeric = True
        Me.nbxOutstandingBill.Name = "nbxOutstandingBill"
        Me.nbxOutstandingBill.ReadOnly = True
        Me.nbxOutstandingBill.Size = New System.Drawing.Size(170, 20)
        Me.nbxOutstandingBill.TabIndex = 38
        Me.nbxOutstandingBill.Value = ""
        '
        'lblOutstandingBill
        '
        Me.lblOutstandingBill.Location = New System.Drawing.Point(471, 55)
        Me.lblOutstandingBill.Name = "lblOutstandingBill"
        Me.lblOutstandingBill.Size = New System.Drawing.Size(200, 20)
        Me.lblOutstandingBill.TabIndex = 37
        Me.lblOutstandingBill.Text = "Outstanding Bill"
        '
        'chkExcludePendingItems
        '
        Me.chkExcludePendingItems.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkExcludePendingItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkExcludePendingItems.Location = New System.Drawing.Point(391, 79)
        Me.chkExcludePendingItems.Name = "chkExcludePendingItems"
        Me.chkExcludePendingItems.Size = New System.Drawing.Size(183, 20)
        Me.chkExcludePendingItems.TabIndex = 44
        Me.chkExcludePendingItems.Text = "Exclude Pending Items"
        Me.chkExcludePendingItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnExport
        '
        Me.fbnExport.Enabled = False
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(773, 99)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(74, 22)
        Me.fbnExport.TabIndex = 45
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(590, 83)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(283, 13)
        Me.lblRecordsNo.TabIndex = 46
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ColInvoiceNo
        '
        Me.ColInvoiceNo.DataPropertyName = "InvoiceNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.ColInvoiceNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColInvoiceNo.HeaderText = "Invoice No"
        Me.ColInvoiceNo.Name = "ColInvoiceNo"
        '
        'ColMainMemberName
        '
        Me.ColMainMemberName.DataPropertyName = "MainMemberName"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.ColMainMemberName.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColMainMemberName.HeaderText = "Main Member Name"
        Me.ColMainMemberName.Name = "ColMainMemberName"
        Me.ColMainMemberName.Width = 150
        '
        'colFullName
        '
        Me.colFullName.DataPropertyName = "FullName"
        Me.colFullName.HeaderText = "Patient  Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.Width = 150
        '
        'ColClaimReferenceNo
        '
        Me.ColClaimReferenceNo.DataPropertyName = "ClaimReferenceNo"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.ColClaimReferenceNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColClaimReferenceNo.HeaderText = "Claim Reference No"
        Me.ColClaimReferenceNo.Name = "ColClaimReferenceNo"
        Me.ColClaimReferenceNo.Width = 150
        '
        'colvisitdate
        '
        Me.colvisitdate.DataPropertyName = "visitdate"
        DataGridViewCellStyle6.Format = "d"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colvisitdate.DefaultCellStyle = DataGridViewCellStyle6
        Me.colvisitdate.HeaderText = "Visit Date"
        Me.colvisitdate.Name = "colvisitdate"
        Me.colvisitdate.Width = 70
        '
        'colVisitNo
        '
        Me.colVisitNo.DataPropertyName = "VisitNo"
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        '
        'colMemberCardNo
        '
        Me.colMemberCardNo.DataPropertyName = "MemberCardNo"
        Me.colMemberCardNo.HeaderText = "Card No"
        Me.colMemberCardNo.Name = "colMemberCardNo"
        Me.colMemberCardNo.ReadOnly = True
        Me.colMemberCardNo.Width = 70
        '
        'colBillCustomerName
        '
        Me.colBillCustomerName.DataPropertyName = "BillCustomerName"
        Me.colBillCustomerName.HeaderText = "Bill Customer Name"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.ReadOnly = True
        Me.colBillCustomerName.Width = 120
        '
        'colservices
        '
        Me.colservices.DataPropertyName = "services"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colservices.DefaultCellStyle = DataGridViewCellStyle7
        Me.colservices.HeaderText = "Services"
        Me.colservices.Name = "colservices"
        '
        'ColDrug
        '
        Me.ColDrug.DataPropertyName = "Drug"
        Me.ColDrug.HeaderText = "Drug"
        Me.ColDrug.Name = "ColDrug"
        '
        'ColConsumable
        '
        Me.ColConsumable.DataPropertyName = "Consumable"
        Me.ColConsumable.HeaderText = "Consumables"
        Me.ColConsumable.Name = "ColConsumable"
        '
        'ColLaboratory
        '
        Me.ColLaboratory.DataPropertyName = "Laboratory"
        Me.ColLaboratory.HeaderText = "Laboratory"
        Me.ColLaboratory.Name = "ColLaboratory"
        '
        'ColRadiology
        '
        Me.ColRadiology.DataPropertyName = "Radiology"
        Me.ColRadiology.HeaderText = "Radiology"
        Me.ColRadiology.Name = "ColRadiology"
        '
        'ColPathology
        '
        Me.ColPathology.DataPropertyName = "Pathology"
        Me.ColPathology.HeaderText = "Pathology"
        Me.ColPathology.Name = "ColPathology"
        '
        'colDental
        '
        Me.colDental.DataPropertyName = "Dental"
        Me.colDental.HeaderText = "Dental"
        Me.colDental.Name = "colDental"
        '
        'ColTheatre
        '
        Me.ColTheatre.DataPropertyName = "Theatre"
        Me.ColTheatre.HeaderText = "Theatre"
        Me.ColTheatre.Name = "ColTheatre"
        '
        'ColOptical
        '
        Me.ColOptical.DataPropertyName = "Optical"
        Me.ColOptical.HeaderText = "Optical"
        Me.ColOptical.Name = "ColOptical"
        '
        'ColProcedureID
        '
        Me.ColProcedureID.DataPropertyName = "ProcedureID"
        Me.ColProcedureID.HeaderText = "Procedure"
        Me.ColProcedureID.Name = "ColProcedureID"
        '
        'ColExtras
        '
        Me.ColExtras.DataPropertyName = "Extras"
        Me.ColExtras.HeaderText = "Extras"
        Me.ColExtras.Name = "ColExtras"
        '
        'ColMaternity
        '
        Me.ColMaternity.DataPropertyName = "Maternity"
        Me.ColMaternity.HeaderText = "Maternity"
        Me.ColMaternity.Name = "ColMaternity"
        '
        'ColICUID
        '
        Me.ColICUID.DataPropertyName = "ICUID"
        Me.ColICUID.HeaderText = "ICU"
        Me.ColICUID.Name = "ColICUID"
        '
        'ColEye
        '
        Me.ColEye.DataPropertyName = "Eye"
        Me.ColEye.HeaderText = "Eye"
        Me.ColEye.Name = "ColEye"
        '
        'ColAdmission
        '
        Me.ColAdmission.DataPropertyName = "Admission"
        Me.ColAdmission.HeaderText = "Admission"
        Me.ColAdmission.Name = "ColAdmission"
        '
        'ColPackages
        '
        Me.ColPackages.DataPropertyName = "Packages"
        Me.ColPackages.HeaderText = "Packages"
        Me.ColPackages.Name = "ColPackages"
        '
        'ColTotal
        '
        Me.ColTotal.DataPropertyName = "Total"
        Me.ColTotal.HeaderText = "Total"
        Me.ColTotal.Name = "ColTotal"
        '
        'ColIPDInvoiceNo
        '
        Me.ColIPDInvoiceNo.DataPropertyName = "InvoiceNo"
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.ColIPDInvoiceNo.DefaultCellStyle = DataGridViewCellStyle12
        Me.ColIPDInvoiceNo.HeaderText = "Invoice No"
        Me.ColIPDInvoiceNo.Name = "ColIPDInvoiceNo"
        '
        'ColIPDMainMemberName
        '
        Me.ColIPDMainMemberName.DataPropertyName = "MainMemberName"
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.ColIPDMainMemberName.DefaultCellStyle = DataGridViewCellStyle13
        Me.ColIPDMainMemberName.HeaderText = "Main Member Name"
        Me.ColIPDMainMemberName.Name = "ColIPDMainMemberName"
        Me.ColIPDMainMemberName.Width = 150
        '
        'colIPDFullName
        '
        Me.colIPDFullName.DataPropertyName = "FullName"
        Me.colIPDFullName.HeaderText = "Patient Name"
        Me.colIPDFullName.Name = "colIPDFullName"
        Me.colIPDFullName.Width = 150
        '
        'ColIPDClaimReferenceNo
        '
        Me.ColIPDClaimReferenceNo.DataPropertyName = "ClaimReferenceNo"
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.ColIPDClaimReferenceNo.DefaultCellStyle = DataGridViewCellStyle14
        Me.ColIPDClaimReferenceNo.HeaderText = "Claim Reference No"
        Me.ColIPDClaimReferenceNo.Name = "ColIPDClaimReferenceNo"
        Me.ColIPDClaimReferenceNo.Width = 150
        '
        'colIPDvisitdate
        '
        Me.colIPDvisitdate.DataPropertyName = "visitdate"
        DataGridViewCellStyle15.Format = "d"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.colIPDvisitdate.DefaultCellStyle = DataGridViewCellStyle15
        Me.colIPDvisitdate.HeaderText = "Visit date"
        Me.colIPDvisitdate.Name = "colIPDvisitdate"
        Me.colIPDvisitdate.Width = 70
        '
        'colIPDVisitNo
        '
        Me.colIPDVisitNo.DataPropertyName = "VisitNo"
        Me.colIPDVisitNo.HeaderText = "Visit No"
        Me.colIPDVisitNo.Name = "colIPDVisitNo"
        '
        'colIPDMemberCardNo
        '
        Me.colIPDMemberCardNo.DataPropertyName = "MemberCardNo"
        Me.colIPDMemberCardNo.HeaderText = "Card No"
        Me.colIPDMemberCardNo.Name = "colIPDMemberCardNo"
        Me.colIPDMemberCardNo.ReadOnly = True
        Me.colIPDMemberCardNo.Width = 70
        '
        'colIPDBillCustomerName
        '
        Me.colIPDBillCustomerName.DataPropertyName = "BillCustomerName"
        Me.colIPDBillCustomerName.HeaderText = "Bill Customer Name"
        Me.colIPDBillCustomerName.Name = "colIPDBillCustomerName"
        Me.colIPDBillCustomerName.ReadOnly = True
        Me.colIPDBillCustomerName.Width = 120
        '
        'colIPDservices
        '
        Me.colIPDservices.DataPropertyName = "services"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.colIPDservices.DefaultCellStyle = DataGridViewCellStyle16
        Me.colIPDservices.HeaderText = "services"
        Me.colIPDservices.Name = "colIPDservices"
        '
        'ColIPDDrug
        '
        Me.ColIPDDrug.DataPropertyName = "Drug"
        Me.ColIPDDrug.HeaderText = "Drug"
        Me.ColIPDDrug.Name = "ColIPDDrug"
        '
        'ColIPDConsumable
        '
        Me.ColIPDConsumable.DataPropertyName = "Consumable"
        Me.ColIPDConsumable.HeaderText = "Consumables"
        Me.ColIPDConsumable.Name = "ColIPDConsumable"
        '
        'ColIPDLaboratory
        '
        Me.ColIPDLaboratory.DataPropertyName = "Laboratory"
        Me.ColIPDLaboratory.HeaderText = "Laboratory"
        Me.ColIPDLaboratory.Name = "ColIPDLaboratory"
        '
        'ColIPDRadiology
        '
        Me.ColIPDRadiology.DataPropertyName = "Radiology"
        Me.ColIPDRadiology.HeaderText = "Radiology"
        Me.ColIPDRadiology.Name = "ColIPDRadiology"
        '
        'ColIPDPathology
        '
        Me.ColIPDPathology.DataPropertyName = "Pathology"
        Me.ColIPDPathology.HeaderText = "Pathology"
        Me.ColIPDPathology.Name = "ColIPDPathology"
        '
        'colIPDDental
        '
        Me.colIPDDental.DataPropertyName = "Dental"
        Me.colIPDDental.HeaderText = "Dental"
        Me.colIPDDental.Name = "colIPDDental"
        '
        'ColIPDTheatre
        '
        Me.ColIPDTheatre.DataPropertyName = "Theatre"
        Me.ColIPDTheatre.HeaderText = "Theatre"
        Me.ColIPDTheatre.Name = "ColIPDTheatre"
        '
        'ColIPDOptical
        '
        Me.ColIPDOptical.DataPropertyName = "Optical"
        Me.ColIPDOptical.HeaderText = "Optical"
        Me.ColIPDOptical.Name = "ColIPDOptical"
        '
        'ColIPDProcedureID
        '
        Me.ColIPDProcedureID.DataPropertyName = "ProcedureID"
        Me.ColIPDProcedureID.HeaderText = "Procedure"
        Me.ColIPDProcedureID.Name = "ColIPDProcedureID"
        '
        'ColIPDExtras
        '
        Me.ColIPDExtras.DataPropertyName = "Extras"
        Me.ColIPDExtras.HeaderText = "Extras"
        Me.ColIPDExtras.Name = "ColIPDExtras"
        '
        'ColIPDMaternity
        '
        Me.ColIPDMaternity.DataPropertyName = "Maternity"
        Me.ColIPDMaternity.HeaderText = "Maternity"
        Me.ColIPDMaternity.Name = "ColIPDMaternity"
        '
        'ColIPDICUID
        '
        Me.ColIPDICUID.DataPropertyName = "ICUID"
        Me.ColIPDICUID.HeaderText = "ICU"
        Me.ColIPDICUID.Name = "ColIPDICUID"
        '
        'ColIPDEye
        '
        Me.ColIPDEye.DataPropertyName = "Eye"
        Me.ColIPDEye.HeaderText = "Eye"
        Me.ColIPDEye.Name = "ColIPDEye"
        '
        'ColIPDAdmission
        '
        Me.ColIPDAdmission.DataPropertyName = "Admission"
        Me.ColIPDAdmission.HeaderText = "Admission"
        Me.ColIPDAdmission.Name = "ColIPDAdmission"
        '
        'ColIPDPackages
        '
        Me.ColIPDPackages.DataPropertyName = "Packages"
        Me.ColIPDPackages.HeaderText = "Packages"
        Me.ColIPDPackages.Name = "ColIPDPackages"
        '
        'ColIPDTotal
        '
        Me.ColIPDTotal.DataPropertyName = "Total"
        Me.ColIPDTotal.HeaderText = "Total"
        Me.ColIPDTotal.Name = "ColIPDTotal"
        '
        'frmInvoiceCategorisation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(916, 504)
        Me.Controls.Add(Me.lblRecordsNo)
        Me.Controls.Add(Me.fbnExport)
        Me.Controls.Add(Me.chkExcludePendingItems)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.cboAccountNo)
        Me.Controls.Add(Me.lblAccountNo)
        Me.Controls.Add(Me.dtpEndDateTime)
        Me.Controls.Add(Me.lblEndDateTime)
        Me.Controls.Add(Me.dtpStartDateTime)
        Me.Controls.Add(Me.lblStartDateTime)
        Me.Controls.Add(Me.fbnRefresh)
        Me.Controls.Add(Me.fbnLoad)
        Me.Controls.Add(Me.cboBillMode)
        Me.Controls.Add(Me.tbcInvoiceCategorisation)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbAccountName)
        Me.Controls.Add(Me.lblAccountName)
        Me.Controls.Add(Me.nbxAccountBalance)
        Me.Controls.Add(Me.lblAccountBalance)
        Me.Controls.Add(Me.nbxOutstandingBill)
        Me.Controls.Add(Me.lblOutstandingBill)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInvoiceCategorisation"
        Me.Text = "Invoice Categorisation"
        Me.tbcInvoiceCategorisation.ResumeLayout(False)
        Me.tpgOutpatient.ResumeLayout(False)
        CType(Me.dgvOutPatientInvoiceCategorisation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInPatient.ResumeLayout(False)
        Me.tpgInPatient.PerformLayout()
        CType(Me.dgvInPatientInvoiceCategorisation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents cboAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDateTime As System.Windows.Forms.Label
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDateTime As System.Windows.Forms.Label
    Friend WithEvents fbnRefresh As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboBillMode As System.Windows.Forms.ComboBox
    Friend WithEvents tbcInvoiceCategorisation As System.Windows.Forms.TabControl
    Friend WithEvents tpgOutpatient As System.Windows.Forms.TabPage
    Friend WithEvents dgvOutPatientInvoiceCategorisation As System.Windows.Forms.DataGridView
    Friend WithEvents tpgInPatient As System.Windows.Forms.TabPage
    Friend WithEvents stbPatientChequePaymentsWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExpenditureTotalAmount As System.Windows.Forms.Label
    Friend WithEvents lblExpenditureAmountWords As System.Windows.Forms.Label
    Friend WithEvents stbPatientChequePayments As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbAccountName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAccountName As System.Windows.Forms.Label
    Friend WithEvents nbxAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAccountBalance As System.Windows.Forms.Label
    Friend WithEvents nbxOutstandingBill As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblOutstandingBill As System.Windows.Forms.Label
    Friend WithEvents chkExcludePendingItems As System.Windows.Forms.CheckBox
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvInPatientInvoiceCategorisation As System.Windows.Forms.DataGridView
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents ColInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMainMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColClaimReferenceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colvisitdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberCardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colservices As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDrug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColConsumable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLaboratory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRadiology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPathology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDental As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTheatre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColOptical As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColProcedureID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColExtras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColMaternity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColICUID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColEye As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAdmission As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPackages As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDMainMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDClaimReferenceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDvisitdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDMemberCardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDservices As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDDrug As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDConsumable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDLaboratory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDRadiology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDPathology As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colIPDDental As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDTheatre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDOptical As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDProcedureID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDExtras As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDMaternity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDICUID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDEye As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDAdmission As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDPackages As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColIPDTotal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
