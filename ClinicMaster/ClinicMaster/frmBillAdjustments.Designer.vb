
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillAdjustments : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal extraBillNo As String)
        MyClass.New()
        Me._ExtraBillNo = extraBillNo
    End Sub

    Public Sub New(ByVal extraBillNo As String, ByVal visitState As Boolean)
        MyClass.New()
        Me._ExtraBillNo = extraBillNo
        Me._VisitState = visitState
    End Sub


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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillAdjustments))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.stbClientMachine = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblClientMachine = New System.Windows.Forms.Label()
        Me.fbnSave = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblStaffNo = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.stbVisitStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitStatus = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblExtraBillDate = New System.Windows.Forms.Label()
        Me.btnFindExtraBillNo = New System.Windows.Forms.Button()
        Me.stbExtraBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblExtraBillNo = New System.Windows.Forms.Label()
        Me.stbExtraBillDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbStaffNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.dgvReturnedPrescriptions = New System.Windows.Forms.DataGridView()
        Me.colItemFullName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNewPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAcknowledgable = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colTotalReturnQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalReturnAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPreviousReturnedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPreviousReturnedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRetutnable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pnlNavigateExtraBills = New System.Windows.Forms.Panel()
        Me.navExtraBills = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.chkNavigateExtraBills = New System.Windows.Forms.CheckBox()
        Me.fbnViewFullInvoice = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpReturnDate = New System.Windows.Forms.DateTimePicker()
        Me.lblReturnDate = New System.Windows.Forms.Label()
        Me.rdoModifyQuantity = New System.Windows.Forms.RadioButton()
        Me.rdoModifyPrice = New System.Windows.Forms.RadioButton()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.cboAdjustmentTypeID = New System.Windows.Forms.ComboBox()
        Me.lblAdjustmentTypeID = New System.Windows.Forms.Label()
        CType(Me.dgvReturnedPrescriptions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigateExtraBills.SuspendLayout()
        Me.grpSetParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(883, 449)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 43
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'cboLoginID
        '
        Me.cboLoginID.Location = New System.Drawing.Point(0, 0)
        Me.cboLoginID.Name = "cboLoginID"
        Me.cboLoginID.Size = New System.Drawing.Size(121, 21)
        Me.cboLoginID.TabIndex = 0
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(0, 0)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(100, 23)
        Me.lblLoginID.TabIndex = 0
        '
        'stbClientMachine
        '
        Me.stbClientMachine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbClientMachine.CapitalizeFirstLetter = False
        Me.stbClientMachine.EntryErrorMSG = ""
        Me.stbClientMachine.Location = New System.Drawing.Point(0, 0)
        Me.stbClientMachine.Name = "stbClientMachine"
        Me.stbClientMachine.RegularExpression = ""
        Me.stbClientMachine.Size = New System.Drawing.Size(100, 20)
        Me.stbClientMachine.TabIndex = 0
        '
        'lblClientMachine
        '
        Me.lblClientMachine.Location = New System.Drawing.Point(0, 0)
        Me.lblClientMachine.Name = "lblClientMachine"
        Me.lblClientMachine.Size = New System.Drawing.Size(100, 23)
        Me.lblClientMachine.TabIndex = 0
        '
        'fbnSave
        '
        Me.fbnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.fbnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSave.Location = New System.Drawing.Point(15, 449)
        Me.fbnSave.Name = "fbnSave"
        Me.fbnSave.Size = New System.Drawing.Size(72, 24)
        Me.fbnSave.TabIndex = 40
        Me.fbnSave.Tag = "ReturnedExtraBillItems"
        Me.fbnSave.Text = "&Save"
        Me.fbnSave.UseVisualStyleBackColor = False
        '
        'lblStaffNo
        '
        Me.lblStaffNo.Location = New System.Drawing.Point(13, 71)
        Me.lblStaffNo.Name = "lblStaffNo"
        Me.lblStaffNo.Size = New System.Drawing.Size(120, 20)
        Me.lblStaffNo.TabIndex = 5
        Me.lblStaffNo.Text = "Attending Doctor"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BackColor = System.Drawing.SystemColors.Info
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.stbInsuranceName.Location = New System.Drawing.Point(505, 95)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(136, 29)
        Me.stbInsuranceName.TabIndex = 38
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(371, 93)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(96, 18)
        Me.lblBillInsuranceName.TabIndex = 37
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'stbRoundNo
        '
        Me.stbRoundNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbRoundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundNo.CapitalizeFirstLetter = False
        Me.stbRoundNo.EntryErrorMSG = ""
        Me.stbRoundNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.stbRoundNo.Location = New System.Drawing.Point(502, 130)
        Me.stbRoundNo.MaxLength = 20
        Me.stbRoundNo.Name = "stbRoundNo"
        Me.stbRoundNo.ReadOnly = True
        Me.stbRoundNo.RegularExpression = ""
        Me.stbRoundNo.Size = New System.Drawing.Size(139, 20)
        Me.stbRoundNo.TabIndex = 26
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(374, 130)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(93, 20)
        Me.lblRoundNo.TabIndex = 25
        Me.lblRoundNo.Text = "Round No"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.stbBillCustomerName.Location = New System.Drawing.Point(505, 66)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(139, 28)
        Me.stbBillCustomerName.TabIndex = 24
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(371, 64)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(103, 20)
        Me.lblBillCustomerName.TabIndex = 23
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbBillNo
        '
        Me.stbBillNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.stbBillNo.Location = New System.Drawing.Point(505, 43)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(139, 20)
        Me.stbBillNo.TabIndex = 22
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(371, 44)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(100, 20)
        Me.lblBillNo.TabIndex = 21
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BackColor = System.Drawing.SystemColors.Info
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(791, 132)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(143, 20)
        Me.nbxCoPayValue.TabIndex = 14
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(671, 133)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(114, 20)
        Me.lblCoPayValue.TabIndex = 13
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BackColor = System.Drawing.SystemColors.Info
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(791, 111)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(143, 20)
        Me.nbxCoPayPercent.TabIndex = 12
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(671, 112)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(114, 20)
        Me.lblCoPayPercent.TabIndex = 11
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BackColor = System.Drawing.SystemColors.Info
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(791, 90)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(143, 20)
        Me.stbCoPayType.TabIndex = 10
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(671, 90)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(114, 20)
        Me.lblCoPayType.TabIndex = 9
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.stbVisitDate.Location = New System.Drawing.Point(505, 22)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(139, 20)
        Me.stbVisitDate.TabIndex = 16
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(151, 90)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(201, 20)
        Me.stbPatientNo.TabIndex = 18
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(13, 95)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(103, 20)
        Me.lblPatientsNo.TabIndex = 17
        Me.lblPatientsNo.Text = "Patient's No"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(371, 22)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(103, 20)
        Me.lblVisitDate.TabIndex = 15
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbBillMode
        '
        Me.stbBillMode.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(151, 134)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(201, 20)
        Me.stbBillMode.TabIndex = 36
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(13, 134)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(96, 18)
        Me.lblBillMode.TabIndex = 35
        Me.lblBillMode.Text = "Bill Mode"
        '
        'stbVisitStatus
        '
        Me.stbVisitStatus.BackColor = System.Drawing.SystemColors.Info
        Me.stbVisitStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitStatus.CapitalizeFirstLetter = False
        Me.stbVisitStatus.Enabled = False
        Me.stbVisitStatus.EntryErrorMSG = ""
        Me.stbVisitStatus.Location = New System.Drawing.Point(791, 48)
        Me.stbVisitStatus.MaxLength = 60
        Me.stbVisitStatus.Name = "stbVisitStatus"
        Me.stbVisitStatus.RegularExpression = ""
        Me.stbVisitStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitStatus.Size = New System.Drawing.Size(143, 20)
        Me.stbVisitStatus.TabIndex = 32
        '
        'lblVisitStatus
        '
        Me.lblVisitStatus.Location = New System.Drawing.Point(671, 48)
        Me.lblVisitStatus.Name = "lblVisitStatus"
        Me.lblVisitStatus.Size = New System.Drawing.Size(114, 18)
        Me.lblVisitStatus.TabIndex = 31
        Me.lblVisitStatus.Text = "Visit Status"
        '
        'stbAge
        '
        Me.stbAge.BackColor = System.Drawing.SystemColors.Info
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(791, 27)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(143, 20)
        Me.stbAge.TabIndex = 30
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(791, 6)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(143, 20)
        Me.stbJoinDate.TabIndex = 28
        '
        'stbGender
        '
        Me.stbGender.BackColor = System.Drawing.SystemColors.Info
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(791, 69)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(143, 20)
        Me.stbGender.TabIndex = 34
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(671, 4)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(114, 18)
        Me.lblJoinDate.TabIndex = 27
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(671, 24)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(114, 18)
        Me.lblAge.TabIndex = 29
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(671, 68)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(114, 18)
        Me.lblGenderID.TabIndex = 33
        Me.lblGenderID.Text = "Gender"
        '
        'stbFullName
        '
        Me.stbFullName.BackColor = System.Drawing.SystemColors.Info
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(151, 112)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(201, 20)
        Me.stbFullName.TabIndex = 20
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(13, 116)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(103, 20)
        Me.lblFullName.TabIndex = 19
        Me.lblFullName.Text = "Full Name"
        '
        'lblExtraBillDate
        '
        Me.lblExtraBillDate.Location = New System.Drawing.Point(10, 47)
        Me.lblExtraBillDate.Name = "lblExtraBillDate"
        Me.lblExtraBillDate.Size = New System.Drawing.Size(120, 20)
        Me.lblExtraBillDate.TabIndex = 3
        Me.lblExtraBillDate.Text = "Extra Bill Date"
        '
        'btnFindExtraBillNo
        '
        Me.btnFindExtraBillNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindExtraBillNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindExtraBillNo.Image = CType(resources.GetObject("btnFindExtraBillNo.Image"), System.Drawing.Image)
        Me.btnFindExtraBillNo.Location = New System.Drawing.Point(123, 4)
        Me.btnFindExtraBillNo.Name = "btnFindExtraBillNo"
        Me.btnFindExtraBillNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindExtraBillNo.TabIndex = 1
        '
        'stbExtraBillNo
        '
        Me.stbExtraBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExtraBillNo.CapitalizeFirstLetter = False
        Me.stbExtraBillNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbExtraBillNo.EntryErrorMSG = ""
        Me.stbExtraBillNo.Location = New System.Drawing.Point(151, 4)
        Me.stbExtraBillNo.MaxLength = 20
        Me.stbExtraBillNo.Name = "stbExtraBillNo"
        Me.stbExtraBillNo.RegularExpression = ""
        Me.stbExtraBillNo.Size = New System.Drawing.Size(201, 20)
        Me.stbExtraBillNo.TabIndex = 2
        '
        'lblExtraBillNo
        '
        Me.lblExtraBillNo.Location = New System.Drawing.Point(9, 4)
        Me.lblExtraBillNo.Name = "lblExtraBillNo"
        Me.lblExtraBillNo.Size = New System.Drawing.Size(91, 20)
        Me.lblExtraBillNo.TabIndex = 0
        Me.lblExtraBillNo.Text = "Extra Bill No"
        '
        'stbExtraBillDate
        '
        Me.stbExtraBillDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbExtraBillDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExtraBillDate.CapitalizeFirstLetter = False
        Me.stbExtraBillDate.Enabled = False
        Me.stbExtraBillDate.EntryErrorMSG = ""
        Me.stbExtraBillDate.Location = New System.Drawing.Point(151, 47)
        Me.stbExtraBillDate.MaxLength = 60
        Me.stbExtraBillDate.Name = "stbExtraBillDate"
        Me.stbExtraBillDate.RegularExpression = ""
        Me.stbExtraBillDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbExtraBillDate.Size = New System.Drawing.Size(201, 20)
        Me.stbExtraBillDate.TabIndex = 4
        '
        'stbStaffNo
        '
        Me.stbStaffNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbStaffNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStaffNo.CapitalizeFirstLetter = False
        Me.stbStaffNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbStaffNo.EntryErrorMSG = ""
        Me.stbStaffNo.Location = New System.Drawing.Point(151, 69)
        Me.stbStaffNo.MaxLength = 7
        Me.stbStaffNo.Name = "stbStaffNo"
        Me.stbStaffNo.ReadOnly = True
        Me.stbStaffNo.RegularExpression = ""
        Me.stbStaffNo.Size = New System.Drawing.Size(201, 20)
        Me.stbStaffNo.TabIndex = 6
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.stbVisitNo.Location = New System.Drawing.Point(505, 0)
        Me.stbVisitNo.MaxLength = 7
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.ReadOnly = True
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(139, 20)
        Me.stbVisitNo.TabIndex = 8
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(371, 2)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(100, 20)
        Me.lblVisitNo.TabIndex = 7
        Me.lblVisitNo.Text = "Visit's No"
        '
        'dgvReturnedPrescriptions
        '
        Me.dgvReturnedPrescriptions.AllowUserToOrderColumns = True
        Me.dgvReturnedPrescriptions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReturnedPrescriptions.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReturnedPrescriptions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReturnedPrescriptions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colItemFullName, Me.colItemCategory, Me.colBillQuantity, Me.colBillAmount, Me.colReturnQuantity, Me.colNewPrice, Me.colAmount, Me.colNotes, Me.colAcknowledgable, Me.colTotalReturnQuantity, Me.colTotalReturnAmount, Me.colUnitPrice, Me.colPayStatus, Me.colEntryMode, Me.colPreviousReturnedQuantity, Me.colPreviousReturnedAmount, Me.colRetutnable, Me.colItemCategoryID})
        Me.dgvReturnedPrescriptions.EnableHeadersVisualStyles = False
        Me.dgvReturnedPrescriptions.GridColor = System.Drawing.Color.Khaki
        Me.dgvReturnedPrescriptions.Location = New System.Drawing.Point(12, 234)
        Me.dgvReturnedPrescriptions.Name = "dgvReturnedPrescriptions"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReturnedPrescriptions.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvReturnedPrescriptions.Size = New System.Drawing.Size(944, 171)
        Me.dgvReturnedPrescriptions.TabIndex = 0
        Me.dgvReturnedPrescriptions.Text = "DataGridView1"
        '
        'colItemFullName
        '
        Me.colItemFullName.DataPropertyName = "ItemFullName"
        Me.colItemFullName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colItemFullName.DisplayStyleForCurrentCellOnly = True
        Me.colItemFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colItemFullName.HeaderText = "Item"
        Me.colItemFullName.Name = "colItemFullName"
        Me.colItemFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colItemFullName.Width = 150
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        Me.colItemCategory.HeaderText = "Item Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        '
        'colBillQuantity
        '
        Me.colBillQuantity.HeaderText = "Bill Quantity"
        Me.colBillQuantity.Name = "colBillQuantity"
        Me.colBillQuantity.ReadOnly = True
        Me.colBillQuantity.Width = 80
        '
        'colBillAmount
        '
        Me.colBillAmount.HeaderText = "Bill Amount"
        Me.colBillAmount.Name = "colBillAmount"
        Me.colBillAmount.ReadOnly = True
        Me.colBillAmount.Width = 80
        '
        'colReturnQuantity
        '
        Me.colReturnQuantity.DataPropertyName = "ReturnQuantity"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colReturnQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colReturnQuantity.HeaderText = "Return Qty"
        Me.colReturnQuantity.Name = "colReturnQuantity"
        Me.colReturnQuantity.ReadOnly = True
        Me.colReturnQuantity.Width = 80
        '
        'colNewPrice
        '
        Me.colNewPrice.HeaderText = "New Price"
        Me.colNewPrice.Name = "colNewPrice"
        '
        'colAmount
        '
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.Width = 90
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 200
        Me.colNotes.Name = "colNotes"
        '
        'colAcknowledgable
        '
        Me.colAcknowledgable.HeaderText = "Acknowledgeable"
        Me.colAcknowledgable.Name = "colAcknowledgable"
        '
        'colTotalReturnQuantity
        '
        Me.colTotalReturnQuantity.DataPropertyName = "ReturnQuantity"
        Me.colTotalReturnQuantity.HeaderText = "Total Return Qty"
        Me.colTotalReturnQuantity.Name = "colTotalReturnQuantity"
        Me.colTotalReturnQuantity.ReadOnly = True
        '
        'colTotalReturnAmount
        '
        Me.colTotalReturnAmount.DataPropertyName = "RerturnAmount"
        Me.colTotalReturnAmount.HeaderText = "Total Return Amt"
        Me.colTotalReturnAmount.Name = "colTotalReturnAmount"
        Me.colTotalReturnAmount.ReadOnly = True
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle3
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 80
        '
        'colPayStatus
        '
        Me.colPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colPayStatus.DefaultCellStyle = DataGridViewCellStyle4
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 80
        '
        'colEntryMode
        '
        Me.colEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colEntryMode.DefaultCellStyle = DataGridViewCellStyle5
        Me.colEntryMode.HeaderText = "Entry Mode"
        Me.colEntryMode.Name = "colEntryMode"
        Me.colEntryMode.ReadOnly = True
        Me.colEntryMode.Width = 80
        '
        'colPreviousReturnedQuantity
        '
        Me.colPreviousReturnedQuantity.DataPropertyName = "RefundedQuantity"
        Me.colPreviousReturnedQuantity.HeaderText = "Previous Returned Quantity"
        Me.colPreviousReturnedQuantity.Name = "colPreviousReturnedQuantity"
        Me.colPreviousReturnedQuantity.Visible = False
        '
        'colPreviousReturnedAmount
        '
        Me.colPreviousReturnedAmount.DataPropertyName = "RefundedAmount"
        Me.colPreviousReturnedAmount.HeaderText = "Previous Returned Amount"
        Me.colPreviousReturnedAmount.Name = "colPreviousReturnedAmount"
        Me.colPreviousReturnedAmount.ReadOnly = True
        Me.colPreviousReturnedAmount.Visible = False
        '
        'colRetutnable
        '
        Me.colRetutnable.HeaderText = "Returnable"
        Me.colRetutnable.Name = "colRetutnable"
        Me.colRetutnable.ReadOnly = True
        Me.colRetutnable.Visible = False
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.HeaderText = "Item CategoryID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        '
        'pnlNavigateExtraBills
        '
        Me.pnlNavigateExtraBills.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateExtraBills.Controls.Add(Me.navExtraBills)
        Me.pnlNavigateExtraBills.Controls.Add(Me.chkNavigateExtraBills)
        Me.pnlNavigateExtraBills.Location = New System.Drawing.Point(259, 411)
        Me.pnlNavigateExtraBills.Name = "pnlNavigateExtraBills"
        Me.pnlNavigateExtraBills.Size = New System.Drawing.Size(443, 64)
        Me.pnlNavigateExtraBills.TabIndex = 42
        '
        'navExtraBills
        '
        Me.navExtraBills.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navExtraBills.ColumnName = "ExtraBillNo"
        Me.navExtraBills.DataSource = Nothing
        Me.navExtraBills.Location = New System.Drawing.Point(15, 28)
        Me.navExtraBills.Name = "navExtraBills"
        Me.navExtraBills.NavAllEnabled = False
        Me.navExtraBills.NavLeftEnabled = False
        Me.navExtraBills.NavRightEnabled = False
        Me.navExtraBills.Size = New System.Drawing.Size(413, 32)
        Me.navExtraBills.TabIndex = 1
        '
        'chkNavigateExtraBills
        '
        Me.chkNavigateExtraBills.AccessibleDescription = ""
        Me.chkNavigateExtraBills.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateExtraBills.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateExtraBills.Location = New System.Drawing.Point(154, 3)
        Me.chkNavigateExtraBills.Name = "chkNavigateExtraBills"
        Me.chkNavigateExtraBills.Size = New System.Drawing.Size(161, 20)
        Me.chkNavigateExtraBills.TabIndex = 0
        Me.chkNavigateExtraBills.Text = "Navigate Extra Bills"
        '
        'fbnViewFullInvoice
        '
        Me.fbnViewFullInvoice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnViewFullInvoice.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnViewFullInvoice.Enabled = False
        Me.fbnViewFullInvoice.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnViewFullInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnViewFullInvoice.Location = New System.Drawing.Point(111, 449)
        Me.fbnViewFullInvoice.Name = "fbnViewFullInvoice"
        Me.fbnViewFullInvoice.Size = New System.Drawing.Size(141, 24)
        Me.fbnViewFullInvoice.TabIndex = 41
        Me.fbnViewFullInvoice.Tag = "ExtraBills"
        Me.fbnViewFullInvoice.Text = "&View Full Invoice"
        Me.fbnViewFullInvoice.UseVisualStyleBackColor = False
        '
        'dtpReturnDate
        '
        Me.dtpReturnDate.Location = New System.Drawing.Point(151, 26)
        Me.dtpReturnDate.Name = "dtpReturnDate"
        Me.dtpReturnDate.ShowCheckBox = True
        Me.dtpReturnDate.Size = New System.Drawing.Size(201, 20)
        Me.dtpReturnDate.TabIndex = 45
        '
        'lblReturnDate
        '
        Me.lblReturnDate.Location = New System.Drawing.Point(10, 25)
        Me.lblReturnDate.Name = "lblReturnDate"
        Me.lblReturnDate.Size = New System.Drawing.Size(124, 20)
        Me.lblReturnDate.TabIndex = 44
        Me.lblReturnDate.Text = "Adjustment Date"
        '
        'rdoModifyQuantity
        '
        Me.rdoModifyQuantity.Checked = True
        Me.rdoModifyQuantity.Location = New System.Drawing.Point(6, 19)
        Me.rdoModifyQuantity.Name = "rdoModifyQuantity"
        Me.rdoModifyQuantity.Size = New System.Drawing.Size(211, 20)
        Me.rdoModifyQuantity.TabIndex = 1
        Me.rdoModifyQuantity.TabStop = True
        Me.rdoModifyQuantity.Text = "Modify Quantity"
        '
        'rdoModifyPrice
        '
        Me.rdoModifyPrice.Location = New System.Drawing.Point(367, 18)
        Me.rdoModifyPrice.Name = "rdoModifyPrice"
        Me.rdoModifyPrice.Size = New System.Drawing.Size(264, 20)
        Me.rdoModifyPrice.TabIndex = 2
        Me.rdoModifyPrice.Text = "Modify Price"
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.rdoModifyPrice)
        Me.grpSetParameters.Controls.Add(Me.rdoModifyQuantity)
        Me.grpSetParameters.Location = New System.Drawing.Point(13, 181)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(942, 48)
        Me.grpSetParameters.TabIndex = 47
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Return Category"
        '
        'cboAdjustmentTypeID
        '
        Me.cboAdjustmentTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAdjustmentTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAdjustmentTypeID.FormattingEnabled = True
        Me.cboAdjustmentTypeID.ItemHeight = 13
        Me.cboAdjustmentTypeID.Location = New System.Drawing.Point(151, 157)
        Me.cboAdjustmentTypeID.Name = "cboAdjustmentTypeID"
        Me.cboAdjustmentTypeID.Size = New System.Drawing.Size(202, 21)
        Me.cboAdjustmentTypeID.TabIndex = 49
        '
        'lblAdjustmentTypeID
        '
        Me.lblAdjustmentTypeID.Location = New System.Drawing.Point(12, 158)
        Me.lblAdjustmentTypeID.Name = "lblAdjustmentTypeID"
        Me.lblAdjustmentTypeID.Size = New System.Drawing.Size(118, 20)
        Me.lblAdjustmentTypeID.TabIndex = 48
        Me.lblAdjustmentTypeID.Text = "Adjustment Type"
        '
        'frmBillAdjustments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(968, 487)
        Me.Controls.Add(Me.cboAdjustmentTypeID)
        Me.Controls.Add(Me.lblAdjustmentTypeID)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.dgvReturnedPrescriptions)
        Me.Controls.Add(Me.dtpReturnDate)
        Me.Controls.Add(Me.lblReturnDate)
        Me.Controls.Add(Me.fbnViewFullInvoice)
        Me.Controls.Add(Me.pnlNavigateExtraBills)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbExtraBillDate)
        Me.Controls.Add(Me.stbStaffNo)
        Me.Controls.Add(Me.lblStaffNo)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.stbRoundNo)
        Me.Controls.Add(Me.lblRoundNo)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbVisitStatus)
        Me.Controls.Add(Me.lblVisitStatus)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblExtraBillDate)
        Me.Controls.Add(Me.btnFindExtraBillNo)
        Me.Controls.Add(Me.stbExtraBillNo)
        Me.Controls.Add(Me.lblExtraBillNo)
        Me.Controls.Add(Me.fbnSave)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmBillAdjustments"
        Me.Tag = "Bill Adjustments"
        Me.Text = "Bill Adjustments"
        CType(Me.dgvReturnedPrescriptions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigateExtraBills.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents stbClientMachine As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblClientMachine As System.Windows.Forms.Label
    Friend WithEvents fbnSave As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblStaffNo As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbVisitStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitStatus As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblExtraBillDate As System.Windows.Forms.Label
    Friend WithEvents btnFindExtraBillNo As System.Windows.Forms.Button
    Friend WithEvents stbExtraBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExtraBillNo As System.Windows.Forms.Label
    Friend WithEvents stbExtraBillDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbStaffNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents dgvReturnedPrescriptions As System.Windows.Forms.DataGridView
    Friend WithEvents pnlNavigateExtraBills As System.Windows.Forms.Panel
    Friend WithEvents navExtraBills As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents chkNavigateExtraBills As System.Windows.Forms.CheckBox
    Friend WithEvents fbnViewFullInvoice As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpReturnDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReturnDate As System.Windows.Forms.Label
    Friend WithEvents rdoModifyQuantity As System.Windows.Forms.RadioButton
    Friend WithEvents rdoModifyPrice As System.Windows.Forms.RadioButton
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents cboAdjustmentTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblAdjustmentTypeID As System.Windows.Forms.Label
    Friend WithEvents colItemFullName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNewPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAcknowledgable As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTotalReturnQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalReturnAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPreviousReturnedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPreviousReturnedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRetutnable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn

End Class