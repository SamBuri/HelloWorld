<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmIssueIPDProcedures : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal roundNo As String)
        MyClass.New()
        Me.defaultRoundNo = roundNo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIssueIPDProcedures))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmsProcedures = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsProceduresCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsProceduresSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsProceduresEditProcedures = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsProceduresRefresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadIPDDoctorProcedures = New System.Windows.Forms.Button()
        Me.btnFindRoundNo = New System.Windows.Forms.Button()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnView = New System.Windows.Forms.Button()
        Me.lblIPDAlerts = New System.Windows.Forms.Label()
        Me.lblBillForProcedures = New System.Windows.Forms.Label()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForProcedures = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.tmrIPDAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbRoundDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRoundDateTime = New System.Windows.Forms.Label()
        Me.stbAdmissionDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionDateTime = New System.Windows.Forms.Label()
        Me.stbAttendingDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAttendingDoctor = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.stbAdmissionStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionStatus = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnFindAdmissionNo = New System.Windows.Forms.Button()
        Me.lblAdmissionNo = New System.Windows.Forms.Label()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.pnlNavigateRounds = New System.Windows.Forms.Panel()
        Me.chkNavigateRounds = New System.Windows.Forms.CheckBox()
        Me.navRounds = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.dtpIssueDate = New System.Windows.Forms.DateTimePicker()
        Me.lblIssueDate = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.tpgIPDProcedures = New System.Windows.Forms.TabPage()
        Me.dgvIPDProcedures = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colProcedureCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedureName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colProcedureNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tbcIPDIssueProcedures = New System.Windows.Forms.TabControl()
        Me.btnSaveIPD = New System.Windows.Forms.Button()
        Me.pnlBill.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        Me.pnlNavigateRounds.SuspendLayout()
        Me.tpgIPDProcedures.SuspendLayout()
        CType(Me.dgvIPDProcedures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbcIPDIssueProcedures.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmsProcedures
        '
        Me.cmsProcedures.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsProcedures.Name = "cmsSearch"
        Me.cmsProcedures.Size = New System.Drawing.Size(61, 4)
        '
        'cmsProceduresCopy
        '
        Me.cmsProceduresCopy.Enabled = False
        Me.cmsProceduresCopy.Name = "cmsProceduresCopy"
        Me.cmsProceduresCopy.Size = New System.Drawing.Size(169, 22)
        Me.cmsProceduresCopy.Text = "Copy"
        Me.cmsProceduresCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsProceduresSelectAll
        '
        Me.cmsProceduresSelectAll.Enabled = False
        Me.cmsProceduresSelectAll.Name = "cmsProceduresSelectAll"
        Me.cmsProceduresSelectAll.Size = New System.Drawing.Size(169, 22)
        Me.cmsProceduresSelectAll.Text = "Select All"
        '
        'cmsProceduresEditProcedures
        '
        Me.cmsProceduresEditProcedures.Enabled = False
        Me.cmsProceduresEditProcedures.Name = "cmsProceduresEditProcedures"
        Me.cmsProceduresEditProcedures.Size = New System.Drawing.Size(169, 22)
        Me.cmsProceduresEditProcedures.Tag = "IPDProcedures"
        Me.cmsProceduresEditProcedures.Text = "Edit Procedures"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(166, 6)
        '
        'cmsProceduresRefresh
        '
        Me.cmsProceduresRefresh.Enabled = False
        Me.cmsProceduresRefresh.Name = "cmsProceduresRefresh"
        Me.cmsProceduresRefresh.Size = New System.Drawing.Size(169, 22)
        Me.cmsProceduresRefresh.Text = "Refresh"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(921, 440)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(81, 24)
        Me.btnClose.TabIndex = 51
        Me.btnClose.Text = "&Close"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(442, 31)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(113, 20)
        Me.stbBillNo.TabIndex = 18
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(314, 31)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(124, 20)
        Me.lblBillNo.TabIndex = 17
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'stbRoundNo
        '
        Me.stbRoundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundNo.CapitalizeFirstLetter = False
        Me.stbRoundNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbRoundNo.EntryErrorMSG = ""
        Me.stbRoundNo.Location = New System.Drawing.Point(146, 26)
        Me.stbRoundNo.MaxLength = 20
        Me.stbRoundNo.Name = "stbRoundNo"
        Me.stbRoundNo.RegularExpression = ""
        Me.stbRoundNo.Size = New System.Drawing.Size(103, 20)
        Me.stbRoundNo.TabIndex = 5
        '
        'btnLoadIPDDoctorProcedures
        '
        Me.btnLoadIPDDoctorProcedures.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadIPDDoctorProcedures.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadIPDDoctorProcedures.Location = New System.Drawing.Point(255, 24)
        Me.btnLoadIPDDoctorProcedures.Name = "btnLoadIPDDoctorProcedures"
        Me.btnLoadIPDDoctorProcedures.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadIPDDoctorProcedures.TabIndex = 6
        Me.btnLoadIPDDoctorProcedures.Tag = ""
        Me.btnLoadIPDDoctorProcedures.Text = "&Load"
        '
        'btnFindRoundNo
        '
        Me.btnFindRoundNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindRoundNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindRoundNo.Image = CType(resources.GetObject("btnFindRoundNo.Image"), System.Drawing.Image)
        Me.btnFindRoundNo.Location = New System.Drawing.Point(113, 25)
        Me.btnFindRoundNo.Name = "btnFindRoundNo"
        Me.btnFindRoundNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindRoundNo.TabIndex = 4
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(16, 25)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(89, 20)
        Me.lblRoundNo.TabIndex = 3
        Me.lblRoundNo.Text = "Round No"
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.pnlAlerts)
        Me.pnlBill.Controls.Add(Me.lblBillForProcedures)
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForProcedures)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Location = New System.Drawing.Point(6, 139)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(996, 66)
        Me.pnlBill.TabIndex = 47
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnView)
        Me.pnlAlerts.Controls.Add(Me.lblIPDAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(715, 5)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(274, 34)
        Me.pnlAlerts.TabIndex = 5
        '
        'btnView
        '
        Me.btnView.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnView.Location = New System.Drawing.Point(204, 4)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(63, 24)
        Me.btnView.TabIndex = 1
        Me.btnView.Tag = ""
        Me.btnView.Text = "&View List"
        '
        'lblIPDAlerts
        '
        Me.lblIPDAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIPDAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblIPDAlerts.Location = New System.Drawing.Point(7, 6)
        Me.lblIPDAlerts.Name = "lblIPDAlerts"
        Me.lblIPDAlerts.Size = New System.Drawing.Size(191, 20)
        Me.lblIPDAlerts.TabIndex = 0
        Me.lblIPDAlerts.Text = "Sent Procedure: 0"
        '
        'lblBillForProcedures
        '
        Me.lblBillForProcedures.Location = New System.Drawing.Point(10, 7)
        Me.lblBillForProcedures.Name = "lblBillForProcedures"
        Me.lblBillForProcedures.Size = New System.Drawing.Size(100, 18)
        Me.lblBillForProcedures.TabIndex = 2
        Me.lblBillForProcedures.Text = "Bill for Procedures"
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(10, 31)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(121, 18)
        Me.lblBillWords.TabIndex = 2
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForProcedures
        '
        Me.stbBillForProcedures.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForProcedures.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForProcedures.CapitalizeFirstLetter = False
        Me.stbBillForProcedures.Enabled = False
        Me.stbBillForProcedures.EntryErrorMSG = ""
        Me.stbBillForProcedures.Location = New System.Drawing.Point(140, 5)
        Me.stbBillForProcedures.MaxLength = 20
        Me.stbBillForProcedures.Name = "stbBillForProcedures"
        Me.stbBillForProcedures.RegularExpression = ""
        Me.stbBillForProcedures.Size = New System.Drawing.Size(158, 20)
        Me.stbBillForProcedures.TabIndex = 1
        Me.stbBillForProcedures.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(140, 27)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(556, 31)
        Me.stbBillWords.TabIndex = 3
        '
        'tmrIPDAlerts
        '
        Me.tmrIPDAlerts.Enabled = True
        Me.tmrIPDAlerts.Interval = 120000
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(146, 71)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitNo.TabIndex = 10
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(16, 73)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(123, 20)
        Me.lblVisitNo.TabIndex = 9
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbRoundDateTime
        '
        Me.stbRoundDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundDateTime.CapitalizeFirstLetter = False
        Me.stbRoundDateTime.Enabled = False
        Me.stbRoundDateTime.EntryErrorMSG = ""
        Me.stbRoundDateTime.Location = New System.Drawing.Point(442, 95)
        Me.stbRoundDateTime.MaxLength = 60
        Me.stbRoundDateTime.Name = "stbRoundDateTime"
        Me.stbRoundDateTime.RegularExpression = ""
        Me.stbRoundDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRoundDateTime.Size = New System.Drawing.Size(113, 20)
        Me.stbRoundDateTime.TabIndex = 24
        '
        'lblRoundDateTime
        '
        Me.lblRoundDateTime.Location = New System.Drawing.Point(314, 95)
        Me.lblRoundDateTime.Name = "lblRoundDateTime"
        Me.lblRoundDateTime.Size = New System.Drawing.Size(124, 20)
        Me.lblRoundDateTime.TabIndex = 23
        Me.lblRoundDateTime.Text = "Round Date and Time"
        '
        'stbAdmissionDateTime
        '
        Me.stbAdmissionDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionDateTime.CapitalizeFirstLetter = False
        Me.stbAdmissionDateTime.Enabled = False
        Me.stbAdmissionDateTime.EntryErrorMSG = ""
        Me.stbAdmissionDateTime.Location = New System.Drawing.Point(442, 74)
        Me.stbAdmissionDateTime.MaxLength = 60
        Me.stbAdmissionDateTime.Name = "stbAdmissionDateTime"
        Me.stbAdmissionDateTime.RegularExpression = ""
        Me.stbAdmissionDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionDateTime.Size = New System.Drawing.Size(113, 20)
        Me.stbAdmissionDateTime.TabIndex = 22
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(314, 76)
        Me.lblAdmissionDateTime.Name = "lblAdmissionDateTime"
        Me.lblAdmissionDateTime.Size = New System.Drawing.Size(124, 20)
        Me.lblAdmissionDateTime.TabIndex = 21
        Me.lblAdmissionDateTime.Text = "Admission Date Time"
        '
        'stbAttendingDoctor
        '
        Me.stbAttendingDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAttendingDoctor.CapitalizeFirstLetter = False
        Me.stbAttendingDoctor.Enabled = False
        Me.stbAttendingDoctor.EntryErrorMSG = ""
        Me.stbAttendingDoctor.Location = New System.Drawing.Point(442, 53)
        Me.stbAttendingDoctor.MaxLength = 60
        Me.stbAttendingDoctor.Name = "stbAttendingDoctor"
        Me.stbAttendingDoctor.RegularExpression = ""
        Me.stbAttendingDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAttendingDoctor.Size = New System.Drawing.Size(113, 20)
        Me.stbAttendingDoctor.TabIndex = 20
        '
        'lblAttendingDoctor
        '
        Me.lblAttendingDoctor.Location = New System.Drawing.Point(314, 54)
        Me.lblAttendingDoctor.Name = "lblAttendingDoctor"
        Me.lblAttendingDoctor.Size = New System.Drawing.Size(124, 20)
        Me.lblAttendingDoctor.TabIndex = 19
        Me.lblAttendingDoctor.Text = "Attending Doctor"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(146, 114)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(158, 20)
        Me.stbFullName.TabIndex = 14
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(16, 116)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(123, 20)
        Me.lblFullName.TabIndex = 13
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(442, 10)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(113, 20)
        Me.stbPatientNo.TabIndex = 16
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(314, 12)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(124, 20)
        Me.lblPatientsNo.TabIndex = 15
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(667, 8)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(128, 20)
        Me.stbBillMode.TabIndex = 28
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(667, 29)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(128, 20)
        Me.stbVisitCategory.TabIndex = 30
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(562, 8)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(99, 20)
        Me.lblBillMode.TabIndex = 27
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(562, 30)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(99, 20)
        Me.lblVisitCategory.TabIndex = 29
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbAdmissionStatus
        '
        Me.stbAdmissionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionStatus.CapitalizeFirstLetter = False
        Me.stbAdmissionStatus.Enabled = False
        Me.stbAdmissionStatus.EntryErrorMSG = ""
        Me.stbAdmissionStatus.Location = New System.Drawing.Point(893, 30)
        Me.stbAdmissionStatus.MaxLength = 60
        Me.stbAdmissionStatus.Name = "stbAdmissionStatus"
        Me.stbAdmissionStatus.RegularExpression = ""
        Me.stbAdmissionStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionStatus.Size = New System.Drawing.Size(105, 20)
        Me.stbAdmissionStatus.TabIndex = 38
        '
        'lblAdmissionStatus
        '
        Me.lblAdmissionStatus.Location = New System.Drawing.Point(801, 30)
        Me.lblAdmissionStatus.Name = "lblAdmissionStatus"
        Me.lblAdmissionStatus.Size = New System.Drawing.Size(86, 20)
        Me.lblAdmissionStatus.TabIndex = 37
        Me.lblAdmissionStatus.Text = "Status"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(893, 9)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(105, 20)
        Me.stbAge.TabIndex = 36
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(442, 116)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(113, 20)
        Me.stbJoinDate.TabIndex = 26
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(893, 51)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(105, 20)
        Me.stbGender.TabIndex = 40
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(314, 116)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(124, 20)
        Me.lblJoinDate.TabIndex = 25
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(801, 9)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(86, 20)
        Me.lblAge.TabIndex = 35
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(801, 51)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(86, 20)
        Me.lblGenderID.TabIndex = 39
        Me.lblGenderID.Text = "Gender"
        '
        'stbAdmissionNo
        '
        Me.stbAdmissionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionNo.CapitalizeFirstLetter = False
        Me.stbAdmissionNo.EntryErrorMSG = ""
        Me.stbAdmissionNo.Location = New System.Drawing.Point(146, 3)
        Me.stbAdmissionNo.MaxLength = 20
        Me.stbAdmissionNo.Name = "stbAdmissionNo"
        Me.stbAdmissionNo.ReadOnly = True
        Me.stbAdmissionNo.RegularExpression = ""
        Me.stbAdmissionNo.Size = New System.Drawing.Size(158, 20)
        Me.stbAdmissionNo.TabIndex = 2
        '
        'btnFindAdmissionNo
        '
        Me.btnFindAdmissionNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindAdmissionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindAdmissionNo.Image = CType(resources.GetObject("btnFindAdmissionNo.Image"), System.Drawing.Image)
        Me.btnFindAdmissionNo.Location = New System.Drawing.Point(113, 3)
        Me.btnFindAdmissionNo.Name = "btnFindAdmissionNo"
        Me.btnFindAdmissionNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindAdmissionNo.TabIndex = 1
        '
        'lblAdmissionNo
        '
        Me.lblAdmissionNo.AccessibleDescription = " "
        Me.lblAdmissionNo.Location = New System.Drawing.Point(16, 3)
        Me.lblAdmissionNo.Name = "lblAdmissionNo"
        Me.lblAdmissionNo.Size = New System.Drawing.Size(89, 20)
        Me.lblAdmissionNo.TabIndex = 0
        Me.lblAdmissionNo.Text = "Admission No"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(893, 114)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(105, 20)
        Me.nbxCoPayValue.TabIndex = 46
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(801, 115)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(86, 20)
        Me.lblCoPayValue.TabIndex = 45
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(893, 93)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(105, 20)
        Me.nbxCoPayPercent.TabIndex = 44
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(801, 94)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(86, 20)
        Me.lblCoPayPercent.TabIndex = 43
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(893, 72)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(105, 20)
        Me.stbCoPayType.TabIndex = 42
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(801, 72)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(86, 20)
        Me.lblCoPayType.TabIndex = 41
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(667, 94)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(128, 40)
        Me.stbInsuranceName.TabIndex = 34
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(562, 106)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(99, 20)
        Me.lblBillInsuranceName.TabIndex = 33
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(667, 50)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(128, 43)
        Me.stbBillCustomerName.TabIndex = 32
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(562, 61)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(99, 20)
        Me.lblBillCustomerName.TabIndex = 31
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'pnlNavigateRounds
        '
        Me.pnlNavigateRounds.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateRounds.Controls.Add(Me.chkNavigateRounds)
        Me.pnlNavigateRounds.Controls.Add(Me.navRounds)
        Me.pnlNavigateRounds.Location = New System.Drawing.Point(201, 431)
        Me.pnlNavigateRounds.Name = "pnlNavigateRounds"
        Me.pnlNavigateRounds.Size = New System.Drawing.Size(620, 33)
        Me.pnlNavigateRounds.TabIndex = 50
        '
        'chkNavigateRounds
        '
        Me.chkNavigateRounds.AccessibleDescription = ""
        Me.chkNavigateRounds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateRounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateRounds.Location = New System.Drawing.Point(8, 9)
        Me.chkNavigateRounds.Name = "chkNavigateRounds"
        Me.chkNavigateRounds.Size = New System.Drawing.Size(167, 20)
        Me.chkNavigateRounds.TabIndex = 0
        Me.chkNavigateRounds.Text = "Navigate Admission Rounds"
        '
        'navRounds
        '
        Me.navRounds.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navRounds.ColumnName = "RoundNo"
        Me.navRounds.DataSource = Nothing
        Me.navRounds.Location = New System.Drawing.Point(181, 2)
        Me.navRounds.Name = "navRounds"
        Me.navRounds.NavAllEnabled = False
        Me.navRounds.NavLeftEnabled = False
        Me.navRounds.NavRightEnabled = False
        Me.navRounds.Size = New System.Drawing.Size(413, 32)
        Me.navRounds.TabIndex = 1
        '
        'dtpIssueDate
        '
        Me.dtpIssueDate.Location = New System.Drawing.Point(146, 49)
        Me.dtpIssueDate.Name = "dtpIssueDate"
        Me.dtpIssueDate.ShowCheckBox = True
        Me.dtpIssueDate.Size = New System.Drawing.Size(158, 20)
        Me.dtpIssueDate.TabIndex = 53
        '
        'lblIssueDate
        '
        Me.lblIssueDate.Location = New System.Drawing.Point(16, 48)
        Me.lblIssueDate.Name = "lblIssueDate"
        Me.lblIssueDate.Size = New System.Drawing.Size(100, 20)
        Me.lblIssueDate.TabIndex = 52
        Me.lblIssueDate.Text = "Issue Date"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(146, 93)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitDate.TabIndex = 10
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(16, 93)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(103, 20)
        Me.lblVisitDate.TabIndex = 9
        Me.lblVisitDate.Text = "Visit Date"
        '
        'tpgIPDProcedures
        '
        Me.tpgIPDProcedures.Controls.Add(Me.dgvIPDProcedures)
        Me.tpgIPDProcedures.Location = New System.Drawing.Point(4, 22)
        Me.tpgIPDProcedures.Name = "tpgIPDProcedures"
        Me.tpgIPDProcedures.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgIPDProcedures.Size = New System.Drawing.Size(975, 187)
        Me.tpgIPDProcedures.TabIndex = 0
        Me.tpgIPDProcedures.Text = "Procedures"
        Me.tpgIPDProcedures.UseVisualStyleBackColor = True
        '
        'dgvIPDProcedures
        '
        Me.dgvIPDProcedures.AllowUserToAddRows = False
        Me.dgvIPDProcedures.AllowUserToDeleteRows = False
        Me.dgvIPDProcedures.AllowUserToOrderColumns = True
        Me.dgvIPDProcedures.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDProcedures.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDProcedures.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIPDProcedures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colProcedureCode, Me.colProcedureName, Me.colQuantity, Me.colUnitPrice, Me.colAmount, Me.colProcedureNotes})
        Me.dgvIPDProcedures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvIPDProcedures.EnableHeadersVisualStyles = False
        Me.dgvIPDProcedures.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDProcedures.Location = New System.Drawing.Point(3, 3)
        Me.dgvIPDProcedures.Name = "dgvIPDProcedures"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDProcedures.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvIPDProcedures.RowHeadersVisible = False
        Me.dgvIPDProcedures.Size = New System.Drawing.Size(969, 181)
        Me.dgvIPDProcedures.TabIndex = 1
        Me.dgvIPDProcedures.Text = "DataGridView1"
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
        'tbcIPDIssueProcedures
        '
        Me.tbcIPDIssueProcedures.Controls.Add(Me.tpgIPDProcedures)
        Me.tbcIPDIssueProcedures.Location = New System.Drawing.Point(19, 212)
        Me.tbcIPDIssueProcedures.Name = "tbcIPDIssueProcedures"
        Me.tbcIPDIssueProcedures.SelectedIndex = 0
        Me.tbcIPDIssueProcedures.Size = New System.Drawing.Size(983, 213)
        Me.tbcIPDIssueProcedures.TabIndex = 54
        '
        'btnSaveIPD
        '
        Me.btnSaveIPD.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSaveIPD.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSaveIPD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveIPD.Location = New System.Drawing.Point(23, 438)
        Me.btnSaveIPD.Name = "btnSaveIPD"
        Me.btnSaveIPD.Size = New System.Drawing.Size(79, 24)
        Me.btnSaveIPD.TabIndex = 55
        Me.btnSaveIPD.Tag = "IssueIPDConsumables"
        Me.btnSaveIPD.Text = "&Save"
        '
        'frmIssueIPDProcedures
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1020, 484)
        Me.Controls.Add(Me.btnSaveIPD)
        Me.Controls.Add(Me.tbcIPDIssueProcedures)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.dtpIssueDate)
        Me.Controls.Add(Me.lblIssueDate)
        Me.Controls.Add(Me.pnlNavigateRounds)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.stbRoundNo)
        Me.Controls.Add(Me.stbAdmissionNo)
        Me.Controls.Add(Me.btnLoadIPDDoctorProcedures)
        Me.Controls.Add(Me.btnFindRoundNo)
        Me.Controls.Add(Me.btnFindAdmissionNo)
        Me.Controls.Add(Me.lblRoundNo)
        Me.Controls.Add(Me.lblAdmissionNo)
        Me.Controls.Add(Me.stbRoundDateTime)
        Me.Controls.Add(Me.lblRoundDateTime)
        Me.Controls.Add(Me.stbAdmissionDateTime)
        Me.Controls.Add(Me.lblAdmissionDateTime)
        Me.Controls.Add(Me.stbAttendingDoctor)
        Me.Controls.Add(Me.lblAttendingDoctor)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.stbVisitCategory)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.lblVisitCategory)
        Me.Controls.Add(Me.stbAdmissionStatus)
        Me.Controls.Add(Me.lblAdmissionStatus)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmIssueIPDProcedures"
        Me.Text = "Issue IPD Procedures"
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.pnlAlerts.ResumeLayout(False)
        Me.pnlNavigateRounds.ResumeLayout(False)
        Me.tpgIPDProcedures.ResumeLayout(False)
        CType(Me.dgvIPDProcedures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbcIPDIssueProcedures.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents btnFindRoundNo As System.Windows.Forms.Button
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForProcedures As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents tmrIPDAlerts As System.Windows.Forms.Timer
    Friend WithEvents btnLoadIPDDoctorProcedures As System.Windows.Forms.Button
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbRoundDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoundDateTime As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionDateTime As System.Windows.Forms.Label
    Friend WithEvents stbAttendingDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAttendingDoctor As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitCategory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents lblVisitCategory As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionStatus As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindAdmissionNo As System.Windows.Forms.Button
    Friend WithEvents lblAdmissionNo As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents cmsProcedures As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsProceduresCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsProceduresSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents pnlNavigateRounds As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateRounds As System.Windows.Forms.CheckBox
    Friend WithEvents navRounds As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents cmsProceduresEditProcedures As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsProceduresRefresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpIssueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblIssueDate As System.Windows.Forms.Label
    Friend WithEvents lblBillForProcedures As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents tpgIPDProcedures As System.Windows.Forms.TabPage
    Friend WithEvents tbcIPDIssueProcedures As System.Windows.Forms.TabControl
    Friend WithEvents dgvIPDProcedures As System.Windows.Forms.DataGridView
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colProcedureCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedureName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colProcedureNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents lblIPDAlerts As System.Windows.Forms.Label
    Friend WithEvents btnSaveIPD As System.Windows.Forms.Button

End Class
