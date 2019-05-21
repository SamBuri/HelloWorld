<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmIssueProcedures
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIssueProcedures))
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.stbStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.dgvProcedures = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colProcedureCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedureName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedureNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtpIssueDate = New System.Windows.Forms.DateTimePicker()
        Me.lblIssueDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.grpIPDProcedures = New System.Windows.Forms.GroupBox()
        Me.btnLoadPendingProcedures = New System.Windows.Forms.Button()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForProcedures = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForProcedures = New System.Windows.Forms.Label()
        Me.pnlVisitNo = New System.Windows.Forms.Panel()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnViewList = New System.Windows.Forms.Button()
        Me.lblAlerts = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        CType(Me.dgvProcedures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpIPDProcedures.SuspendLayout()
        Me.pnlBill.SuspendLayout()
        Me.pnlVisitNo.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(694, 68)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(98, 20)
        Me.stbBillMode.TabIndex = 26
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(438, 25)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(148, 20)
        Me.stbVisitCategory.TabIndex = 14
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(604, 71)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(84, 18)
        Me.lblBillMode.TabIndex = 25
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(333, 28)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(95, 18)
        Me.lblVisitCategory.TabIndex = 13
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(126, 56)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(184, 20)
        Me.stbBillNo.TabIndex = 6
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(17, 56)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(103, 20)
        Me.lblBillNo.TabIndex = 5
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(694, 26)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(98, 20)
        Me.stbStatus.TabIndex = 22
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(604, 25)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(84, 18)
        Me.lblStatus.TabIndex = 21
        Me.lblStatus.Text = "Status"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(694, 5)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(98, 20)
        Me.stbAge.TabIndex = 20
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(438, 46)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(148, 20)
        Me.stbJoinDate.TabIndex = 16
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(694, 47)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(98, 20)
        Me.stbGender.TabIndex = 24
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(333, 48)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(95, 18)
        Me.lblJoinDate.TabIndex = 15
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(604, 4)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(84, 18)
        Me.lblAge.TabIndex = 19
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(604, 47)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(84, 18)
        Me.lblGenderID.TabIndex = 23
        Me.lblGenderID.Text = "Gender"
        '
        'dgvProcedures
        '
        Me.dgvProcedures.AllowUserToAddRows = False
        Me.dgvProcedures.AllowUserToDeleteRows = False
        Me.dgvProcedures.AllowUserToOrderColumns = True
        Me.dgvProcedures.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvProcedures.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProcedures.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvProcedures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colProcedureCode, Me.colProcedureName, Me.colQuantity, Me.colUnitPrice, Me.colAmount, Me.colProcedureNotes})
        Me.dgvProcedures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvProcedures.EnableHeadersVisualStyles = False
        Me.dgvProcedures.GridColor = System.Drawing.Color.Khaki
        Me.dgvProcedures.Location = New System.Drawing.Point(3, 16)
        Me.dgvProcedures.Name = "dgvProcedures"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvProcedures.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvProcedures.RowHeadersVisible = False
        Me.dgvProcedures.Size = New System.Drawing.Size(772, 227)
        Me.dgvProcedures.TabIndex = 0
        Me.dgvProcedures.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colInclude.Width = 50
        '
        'colProcedureCode
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colProcedureCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colProcedureCode.HeaderText = "Procedure Code"
        Me.colProcedureCode.Name = "colProcedureCode"
        Me.colProcedureCode.ReadOnly = True
        Me.colProcedureCode.Width = 90
        '
        'colProcedureName
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colProcedureName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colProcedureName.HeaderText = "ProcedureName"
        Me.colProcedureName.Name = "colProcedureName"
        Me.colProcedureName.ReadOnly = True
        Me.colProcedureName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colProcedureName.Width = 250
        '
        'colQuantity
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle4
        Me.colQuantity.FillWeight = 150.0!
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 60
        '
        'colUnitPrice
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle5
        Me.colUnitPrice.FillWeight = 150.0!
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 80
        '
        'colAmount
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle6
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 80
        '
        'colProcedureNotes
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colProcedureNotes.DefaultCellStyle = DataGridViewCellStyle7
        Me.colProcedureNotes.FillWeight = 150.0!
        Me.colProcedureNotes.HeaderText = "Notes"
        Me.colProcedureNotes.MaxInputLength = 40
        Me.colProcedureNotes.Name = "colProcedureNotes"
        Me.colProcedureNotes.ReadOnly = True
        Me.colProcedureNotes.Width = 150
        '
        'dtpIssueDate
        '
        Me.dtpIssueDate.Location = New System.Drawing.Point(126, 35)
        Me.dtpIssueDate.Name = "dtpIssueDate"
        Me.dtpIssueDate.ShowCheckBox = True
        Me.dtpIssueDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpIssueDate.TabIndex = 4
        '
        'lblIssueDate
        '
        Me.lblIssueDate.Location = New System.Drawing.Point(17, 35)
        Me.lblIssueDate.Name = "lblIssueDate"
        Me.lblIssueDate.Size = New System.Drawing.Size(100, 20)
        Me.lblIssueDate.TabIndex = 3
        Me.lblIssueDate.Text = "Issue Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(126, 98)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(184, 20)
        Me.stbFullName.TabIndex = 10
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(17, 98)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(103, 20)
        Me.lblFullName.TabIndex = 9
        Me.lblFullName.Text = "Full Name"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(12, 430)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(104, 24)
        Me.btnSave.TabIndex = 30
        Me.btnSave.Text = "&Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(688, 430)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(104, 24)
        Me.btnClose.TabIndex = 31
        Me.btnClose.Text = "&Close"
        '
        'grpIPDProcedures
        '
        Me.grpIPDProcedures.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpIPDProcedures.Controls.Add(Me.dgvProcedures)
        Me.grpIPDProcedures.Location = New System.Drawing.Point(13, 178)
        Me.grpIPDProcedures.Name = "grpIPDProcedures"
        Me.grpIPDProcedures.Size = New System.Drawing.Size(778, 246)
        Me.grpIPDProcedures.TabIndex = 29
        Me.grpIPDProcedures.TabStop = False
        Me.grpIPDProcedures.Text = "Offer Procedure"
        '
        'btnLoadPendingProcedures
        '
        Me.btnLoadPendingProcedures.AccessibleDescription = ""
        Me.btnLoadPendingProcedures.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPendingProcedures.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPendingProcedures.Location = New System.Drawing.Point(141, 4)
        Me.btnLoadPendingProcedures.Name = "btnLoadPendingProcedures"
        Me.btnLoadPendingProcedures.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadPendingProcedures.TabIndex = 1
        Me.btnLoadPendingProcedures.Tag = ""
        Me.btnLoadPendingProcedures.Text = "&Load"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(90, 10)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(18, 9)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(65, 21)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No."
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(126, 77)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(184, 20)
        Me.stbVisitDate.TabIndex = 8
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(438, 4)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(148, 20)
        Me.stbPatientNo.TabIndex = 12
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(333, 4)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(95, 18)
        Me.lblPatientsNo.TabIndex = 11
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(17, 77)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(103, 20)
        Me.lblVisitDate.TabIndex = 7
        Me.lblVisitDate.Text = "Visit Date"
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForProcedures)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForProcedures)
        Me.pnlBill.Location = New System.Drawing.Point(12, 131)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(791, 41)
        Me.pnlBill.TabIndex = 28
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(324, 6)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(92, 18)
        Me.lblBillWords.TabIndex = 3
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForProcedures
        '
        Me.stbBillForProcedures.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForProcedures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForProcedures.CapitalizeFirstLetter = False
        Me.stbBillForProcedures.Enabled = False
        Me.stbBillForProcedures.EntryErrorMSG = ""
        Me.stbBillForProcedures.Location = New System.Drawing.Point(114, 4)
        Me.stbBillForProcedures.MaxLength = 20
        Me.stbBillForProcedures.Name = "stbBillForProcedures"
        Me.stbBillForProcedures.RegularExpression = ""
        Me.stbBillForProcedures.Size = New System.Drawing.Size(184, 20)
        Me.stbBillForProcedures.TabIndex = 2
        Me.stbBillForProcedures.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(426, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(354, 35)
        Me.stbBillWords.TabIndex = 0
        '
        'lblBillForProcedures
        '
        Me.lblBillForProcedures.Location = New System.Drawing.Point(8, 6)
        Me.lblBillForProcedures.Name = "lblBillForProcedures"
        Me.lblBillForProcedures.Size = New System.Drawing.Size(100, 18)
        Me.lblBillForProcedures.TabIndex = 0
        Me.lblBillForProcedures.Text = "Bill for Procedures"
        '
        'pnlVisitNo
        '
        Me.pnlVisitNo.Controls.Add(Me.stbVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.btnLoadPendingProcedures)
        Me.pnlVisitNo.Location = New System.Drawing.Point(122, 2)
        Me.pnlVisitNo.Name = "pnlVisitNo"
        Me.pnlVisitNo.Size = New System.Drawing.Size(197, 30)
        Me.pnlVisitNo.TabIndex = 2
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(4, 6)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(131, 20)
        Me.stbVisitNo.TabIndex = 0
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnViewList)
        Me.pnlAlerts.Controls.Add(Me.lblAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(521, 92)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(278, 36)
        Me.pnlAlerts.TabIndex = 27
        '
        'btnViewList
        '
        Me.btnViewList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewList.Location = New System.Drawing.Point(207, 5)
        Me.btnViewList.Name = "btnViewList"
        Me.btnViewList.Size = New System.Drawing.Size(63, 24)
        Me.btnViewList.TabIndex = 1
        Me.btnViewList.Tag = ""
        Me.btnViewList.Text = "&View List"
        '
        'lblAlerts
        '
        Me.lblAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblAlerts.Location = New System.Drawing.Point(9, 7)
        Me.lblAlerts.Name = "lblAlerts"
        Me.lblAlerts.Size = New System.Drawing.Size(192, 20)
        Me.lblAlerts.TabIndex = 0
        Me.lblAlerts.Text = "Doctor Procedure(s): 0"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(438, 67)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(148, 20)
        Me.stbPrimaryDoctor.TabIndex = 18
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(333, 68)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(95, 18)
        Me.lblPrimaryDoctor.TabIndex = 17
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'frmIssueProcedures
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(808, 466)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.pnlVisitNo)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.stbVisitCategory)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.lblVisitCategory)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.stbStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.dtpIssueDate)
        Me.Controls.Add(Me.lblIssueDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.grpIPDProcedures)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmIssueProcedures"
        Me.Text = "Issue Procedures"
        CType(Me.dgvProcedures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpIPDProcedures.ResumeLayout(False)
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.pnlVisitNo.ResumeLayout(False)
        Me.pnlVisitNo.PerformLayout()
        Me.pnlAlerts.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitCategory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents lblVisitCategory As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents stbStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents dgvProcedures As System.Windows.Forms.DataGridView
    Friend WithEvents dtpIssueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblIssueDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents grpIPDProcedures As System.Windows.Forms.GroupBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForProcedures As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForProcedures As System.Windows.Forms.Label
    Friend WithEvents btnLoadPendingProcedures As System.Windows.Forms.Button
    Friend WithEvents pnlVisitNo As System.Windows.Forms.Panel
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnViewList As System.Windows.Forms.Button
    Friend WithEvents lblAlerts As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colProcedureCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedureName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedureNotes As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
