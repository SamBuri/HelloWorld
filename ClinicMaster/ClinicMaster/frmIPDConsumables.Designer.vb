<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmIPDConsumables : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIPDConsumables))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnFindRoundNo = New System.Windows.Forms.Button()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForConsumables = New System.Windows.Forms.Label()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbRoundDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRoundDateTime = New System.Windows.Forms.Label()
        Me.stbAdmissionDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionDateTime = New System.Windows.Forms.Label()
        Me.stbAttendingDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAttendingDoctor = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
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
        Me.btnLoadRounds = New System.Windows.Forms.Button()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.colConsumableName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colConsumableNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colConsumableOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAlternateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableHalted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsConsumables = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsConsumablesQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnlBill.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsConsumables.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(19, 442)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(79, 24)
        Me.btnSave.TabIndex = 47
        Me.btnSave.Text = "&Save"
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(876, 449)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(84, 24)
        Me.btnClose.TabIndex = 48
        Me.btnClose.Text = "&Close"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(438, 22)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(113, 20)
        Me.stbBillNo.TabIndex = 18
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(310, 22)
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
        Me.stbRoundNo.Location = New System.Drawing.Point(146, 27)
        Me.stbRoundNo.MaxLength = 20
        Me.stbRoundNo.Name = "stbRoundNo"
        Me.stbRoundNo.RegularExpression = ""
        Me.stbRoundNo.Size = New System.Drawing.Size(103, 20)
        Me.stbRoundNo.TabIndex = 5
        '
        'btnFindRoundNo
        '
        Me.btnFindRoundNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindRoundNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindRoundNo.Image = CType(resources.GetObject("btnFindRoundNo.Image"), System.Drawing.Image)
        Me.btnFindRoundNo.Location = New System.Drawing.Point(113, 26)
        Me.btnFindRoundNo.Name = "btnFindRoundNo"
        Me.btnFindRoundNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindRoundNo.TabIndex = 4
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(16, 26)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(89, 20)
        Me.lblRoundNo.TabIndex = 3
        Me.lblRoundNo.Text = "Round No"
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForConsumables)
        Me.pnlBill.Location = New System.Drawing.Point(6, 136)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(961, 37)
        Me.pnlBill.TabIndex = 45
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(307, 6)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(121, 18)
        Me.lblBillWords.TabIndex = 2
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForItem
        '
        Me.stbBillForItem.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForItem.CapitalizeFirstLetter = False
        Me.stbBillForItem.Enabled = False
        Me.stbBillForItem.EntryErrorMSG = ""
        Me.stbBillForItem.Location = New System.Drawing.Point(140, 4)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(158, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(432, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(522, 31)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForConsumables
        '
        Me.lblBillForConsumables.Location = New System.Drawing.Point(13, 6)
        Me.lblBillForConsumables.Name = "lblBillForConsumables"
        Me.lblBillForConsumables.Size = New System.Drawing.Size(121, 18)
        Me.lblBillForConsumables.TabIndex = 0
        Me.lblBillForConsumables.Text = "Bill for Consumables"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(146, 49)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitNo.TabIndex = 8
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(16, 49)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitNo.TabIndex = 7
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbRoundDateTime
        '
        Me.stbRoundDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundDateTime.CapitalizeFirstLetter = False
        Me.stbRoundDateTime.Enabled = False
        Me.stbRoundDateTime.EntryErrorMSG = ""
        Me.stbRoundDateTime.Location = New System.Drawing.Point(438, 85)
        Me.stbRoundDateTime.MaxLength = 60
        Me.stbRoundDateTime.Name = "stbRoundDateTime"
        Me.stbRoundDateTime.RegularExpression = ""
        Me.stbRoundDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRoundDateTime.Size = New System.Drawing.Size(113, 20)
        Me.stbRoundDateTime.TabIndex = 24
        '
        'lblRoundDateTime
        '
        Me.lblRoundDateTime.Location = New System.Drawing.Point(310, 85)
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
        Me.stbAdmissionDateTime.Location = New System.Drawing.Point(438, 64)
        Me.stbAdmissionDateTime.MaxLength = 60
        Me.stbAdmissionDateTime.Name = "stbAdmissionDateTime"
        Me.stbAdmissionDateTime.RegularExpression = ""
        Me.stbAdmissionDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionDateTime.Size = New System.Drawing.Size(113, 20)
        Me.stbAdmissionDateTime.TabIndex = 22
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(310, 66)
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
        Me.stbAttendingDoctor.Location = New System.Drawing.Point(438, 43)
        Me.stbAttendingDoctor.MaxLength = 60
        Me.stbAttendingDoctor.Name = "stbAttendingDoctor"
        Me.stbAttendingDoctor.RegularExpression = ""
        Me.stbAttendingDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAttendingDoctor.Size = New System.Drawing.Size(113, 20)
        Me.stbAttendingDoctor.TabIndex = 20
        '
        'lblAttendingDoctor
        '
        Me.lblAttendingDoctor.Location = New System.Drawing.Point(310, 44)
        Me.lblAttendingDoctor.Name = "lblAttendingDoctor"
        Me.lblAttendingDoctor.Size = New System.Drawing.Size(124, 20)
        Me.lblAttendingDoctor.TabIndex = 19
        Me.lblAttendingDoctor.Text = "Attending Doctor"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(146, 70)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(158, 20)
        Me.stbVisitDate.TabIndex = 10
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(16, 72)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitDate.TabIndex = 9
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(146, 91)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(158, 20)
        Me.stbFullName.TabIndex = 12
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(16, 93)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(124, 20)
        Me.lblFullName.TabIndex = 11
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(146, 112)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(158, 20)
        Me.stbPatientNo.TabIndex = 14
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(16, 114)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(124, 20)
        Me.lblPatientsNo.TabIndex = 13
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(663, 3)
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
        Me.stbVisitCategory.Location = New System.Drawing.Point(438, 1)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(113, 20)
        Me.stbVisitCategory.TabIndex = 16
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(558, 3)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(99, 20)
        Me.lblBillMode.TabIndex = 27
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(310, 2)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(124, 20)
        Me.lblVisitCategory.TabIndex = 15
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbAdmissionStatus
        '
        Me.stbAdmissionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionStatus.CapitalizeFirstLetter = False
        Me.stbAdmissionStatus.Enabled = False
        Me.stbAdmissionStatus.EntryErrorMSG = ""
        Me.stbAdmissionStatus.Location = New System.Drawing.Point(893, 24)
        Me.stbAdmissionStatus.MaxLength = 60
        Me.stbAdmissionStatus.Name = "stbAdmissionStatus"
        Me.stbAdmissionStatus.RegularExpression = ""
        Me.stbAdmissionStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionStatus.Size = New System.Drawing.Size(71, 20)
        Me.stbAdmissionStatus.TabIndex = 36
        '
        'lblAdmissionStatus
        '
        Me.lblAdmissionStatus.Location = New System.Drawing.Point(801, 24)
        Me.lblAdmissionStatus.Name = "lblAdmissionStatus"
        Me.lblAdmissionStatus.Size = New System.Drawing.Size(86, 20)
        Me.lblAdmissionStatus.TabIndex = 35
        Me.lblAdmissionStatus.Text = "Status"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(893, 3)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(71, 20)
        Me.stbAge.TabIndex = 34
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(438, 106)
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
        Me.stbGender.Location = New System.Drawing.Point(893, 45)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(71, 20)
        Me.stbGender.TabIndex = 38
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(310, 106)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(124, 20)
        Me.lblJoinDate.TabIndex = 25
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(801, 3)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(86, 20)
        Me.lblAge.TabIndex = 33
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(801, 45)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(86, 20)
        Me.lblGenderID.TabIndex = 37
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
        Me.nbxCoPayValue.Location = New System.Drawing.Point(893, 108)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(71, 20)
        Me.nbxCoPayValue.TabIndex = 44
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(801, 109)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(86, 20)
        Me.lblCoPayValue.TabIndex = 43
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(893, 87)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(71, 20)
        Me.nbxCoPayPercent.TabIndex = 42
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(801, 88)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(86, 20)
        Me.lblCoPayPercent.TabIndex = 41
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(893, 66)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(71, 20)
        Me.stbCoPayType.TabIndex = 40
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(801, 66)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(86, 20)
        Me.lblCoPayType.TabIndex = 39
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(663, 75)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(128, 51)
        Me.stbInsuranceName.TabIndex = 32
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(558, 87)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(99, 20)
        Me.lblBillInsuranceName.TabIndex = 31
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(663, 24)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(128, 50)
        Me.stbBillCustomerName.TabIndex = 30
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(558, 35)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(99, 20)
        Me.lblBillCustomerName.TabIndex = 29
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'btnLoadRounds
        '
        Me.btnLoadRounds.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadRounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadRounds.Location = New System.Drawing.Point(255, 24)
        Me.btnLoadRounds.Name = "btnLoadRounds"
        Me.btnLoadRounds.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadRounds.TabIndex = 6
        Me.btnLoadRounds.Tag = ""
        Me.btnLoadRounds.Text = "&Load"
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToOrderColumns = True
        Me.dgvConsumables.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumableName, Me.colConsumableNotes, Me.colConsumableQuantity, Me.colConsumableUnitsInStock, Me.colConsumableUnitMeasure, Me.colConsumableUnitPrice, Me.colConsumableAmount, Me.colConsumableExpiryDate, Me.colConsumablesSaved, Me.colConsumableOrderLevel, Me.colConsumableAlternateName, Me.colConsumableItemStatus, Me.colConsumablePayStatus, Me.colConsumableHalted})
        Me.dgvConsumables.ContextMenuStrip = Me.cmsConsumables
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(19, 176)
        Me.dgvConsumables.Name = "dgvConsumables"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvConsumables.Size = New System.Drawing.Size(948, 256)
        Me.dgvConsumables.TabIndex = 46
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'colConsumableName
        '
        Me.colConsumableName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colConsumableName.DisplayStyleForCurrentCellOnly = True
        Me.colConsumableName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumableName.HeaderText = "Consumable Name"
        Me.colConsumableName.Name = "colConsumableName"
        Me.colConsumableName.Sorted = True
        Me.colConsumableName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colConsumableName.Width = 200
        '
        'colConsumableNotes
        '
        Me.colConsumableNotes.HeaderText = "Notes"
        Me.colConsumableNotes.MaxInputLength = 40
        Me.colConsumableNotes.Name = "colConsumableNotes"
        '
        'colConsumableQuantity
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.Width = 60
        '
        'colConsumableUnitsInStock
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableUnitsInStock.DefaultCellStyle = DataGridViewCellStyle3
        Me.colConsumableUnitsInStock.HeaderText = "Units In Stock"
        Me.colConsumableUnitsInStock.Name = "colConsumableUnitsInStock"
        Me.colConsumableUnitsInStock.ReadOnly = True
        Me.colConsumableUnitsInStock.Width = 80
        '
        'colConsumableUnitMeasure
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableUnitMeasure.DefaultCellStyle = DataGridViewCellStyle4
        Me.colConsumableUnitMeasure.HeaderText = "Unit Measure"
        Me.colConsumableUnitMeasure.Name = "colConsumableUnitMeasure"
        Me.colConsumableUnitMeasure.ReadOnly = True
        Me.colConsumableUnitMeasure.Width = 80
        '
        'colConsumableUnitPrice
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colConsumableUnitPrice.DefaultCellStyle = DataGridViewCellStyle5
        Me.colConsumableUnitPrice.HeaderText = "Unit Price"
        Me.colConsumableUnitPrice.MaxInputLength = 12
        Me.colConsumableUnitPrice.Name = "colConsumableUnitPrice"
        Me.colConsumableUnitPrice.ReadOnly = True
        Me.colConsumableUnitPrice.Width = 80
        '
        'colConsumableAmount
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colConsumableAmount.DefaultCellStyle = DataGridViewCellStyle6
        Me.colConsumableAmount.HeaderText = "Amount"
        Me.colConsumableAmount.MaxInputLength = 12
        Me.colConsumableAmount.Name = "colConsumableAmount"
        Me.colConsumableAmount.ReadOnly = True
        Me.colConsumableAmount.Width = 80
        '
        'colConsumableExpiryDate
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableExpiryDate.DefaultCellStyle = DataGridViewCellStyle7
        Me.colConsumableExpiryDate.HeaderText = "Expiry Date"
        Me.colConsumableExpiryDate.Name = "colConsumableExpiryDate"
        Me.colConsumableExpiryDate.ReadOnly = True
        Me.colConsumableExpiryDate.Width = 80
        '
        'colConsumablesSaved
        '
        Me.colConsumablesSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = False
        Me.colConsumablesSaved.DefaultCellStyle = DataGridViewCellStyle8
        Me.colConsumablesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumablesSaved.HeaderText = "Saved"
        Me.colConsumablesSaved.Name = "colConsumablesSaved"
        Me.colConsumablesSaved.ReadOnly = True
        Me.colConsumablesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colConsumablesSaved.Width = 50
        '
        'colConsumableOrderLevel
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableOrderLevel.DefaultCellStyle = DataGridViewCellStyle9
        Me.colConsumableOrderLevel.HeaderText = "Order Level"
        Me.colConsumableOrderLevel.Name = "colConsumableOrderLevel"
        Me.colConsumableOrderLevel.ReadOnly = True
        Me.colConsumableOrderLevel.Width = 70
        '
        'colConsumableAlternateName
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableAlternateName.DefaultCellStyle = DataGridViewCellStyle10
        Me.colConsumableAlternateName.HeaderText = "Alternate Name"
        Me.colConsumableAlternateName.Name = "colConsumableAlternateName"
        Me.colConsumableAlternateName.ReadOnly = True
        Me.colConsumableAlternateName.Width = 90
        '
        'colConsumableItemStatus
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableItemStatus.DefaultCellStyle = DataGridViewCellStyle11
        Me.colConsumableItemStatus.HeaderText = "Item Status"
        Me.colConsumableItemStatus.Name = "colConsumableItemStatus"
        Me.colConsumableItemStatus.ReadOnly = True
        Me.colConsumableItemStatus.Width = 80
        '
        'colConsumablePayStatus
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumablePayStatus.DefaultCellStyle = DataGridViewCellStyle12
        Me.colConsumablePayStatus.HeaderText = "Pay Status"
        Me.colConsumablePayStatus.Name = "colConsumablePayStatus"
        Me.colConsumablePayStatus.ReadOnly = True
        Me.colConsumablePayStatus.Width = 70
        '
        'colConsumableHalted
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle13.NullValue = False
        Me.colConsumableHalted.DefaultCellStyle = DataGridViewCellStyle13
        Me.colConsumableHalted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colConsumableHalted.HeaderText = "Halted"
        Me.colConsumableHalted.Name = "colConsumableHalted"
        Me.colConsumableHalted.ReadOnly = True
        Me.colConsumableHalted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colConsumableHalted.Width = 50
        '
        'cmsConsumables
        '
        Me.cmsConsumables.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsConsumables.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsConsumablesQuickSearch})
        Me.cmsConsumables.Name = "cmsSearch"
        Me.cmsConsumables.Size = New System.Drawing.Size(144, 26)
        '
        'cmsConsumablesQuickSearch
        '
        Me.cmsConsumablesQuickSearch.Image = CType(resources.GetObject("cmsConsumablesQuickSearch.Image"), System.Drawing.Image)
        Me.cmsConsumablesQuickSearch.Name = "cmsConsumablesQuickSearch"
        Me.cmsConsumablesQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsConsumablesQuickSearch.Text = "Quick Search"
        '
        'frmIPDConsumables
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(975, 485)
        Me.Controls.Add(Me.dgvConsumables)
        Me.Controls.Add(Me.btnLoadRounds)
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
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
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
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmIPDConsumables"
        Me.Text = "IPD Consumables"
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsConsumables.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents btnFindRoundNo As System.Windows.Forms.Button
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForConsumables As System.Windows.Forms.Label
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbRoundDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoundDateTime As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionDateTime As System.Windows.Forms.Label
    Friend WithEvents stbAttendingDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAttendingDoctor As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
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
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents btnLoadRounds As System.Windows.Forms.Button
    Friend WithEvents dgvConsumables As System.Windows.Forms.DataGridView
    Friend WithEvents cmsConsumables As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsConsumablesQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colConsumableName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colConsumableNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colConsumableOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAlternateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableHalted As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
