<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAcknowledgeBillReturns
    Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal visitState As Boolean)
        MyClass.New()
        Me._VisitState = visitState
    End Sub

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAcknowledgeBillReturns))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbExtraBillDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbStaffNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStaffNo = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
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
        Me.lblExtraBillNo = New System.Windows.Forms.Label()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.BtnLoad = New System.Windows.Forms.Button()
        Me.lblPendingIventoryAcknowledgements = New System.Windows.Forms.Label()
        Me.dgvReturnedItems = New System.Windows.Forms.DataGridView()
        Me.colAdjustmentNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugBatchNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDrugExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugReturnedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fbnSave = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.pnlAcknowledgeBiiFormReturnsDetails = New System.Windows.Forms.Panel()
        Me.stbExtraBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.pnlAlerts.SuspendLayout()
        CType(Me.dgvReturnedItems, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAcknowledgeBiiFormReturnsDetails.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(759, 57)
        Me.stbVisitNo.MaxLength = 7
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.ReadOnly = True
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(180, 20)
        Me.stbVisitNo.TabIndex = 47
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(650, 59)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(103, 20)
        Me.lblVisitNo.TabIndex = 46
        Me.lblVisitNo.Text = "Visit's No"
        '
        'stbExtraBillDate
        '
        Me.stbExtraBillDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExtraBillDate.CapitalizeFirstLetter = False
        Me.stbExtraBillDate.Enabled = False
        Me.stbExtraBillDate.EntryErrorMSG = ""
        Me.stbExtraBillDate.Location = New System.Drawing.Point(759, 79)
        Me.stbExtraBillDate.MaxLength = 60
        Me.stbExtraBillDate.Name = "stbExtraBillDate"
        Me.stbExtraBillDate.RegularExpression = ""
        Me.stbExtraBillDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbExtraBillDate.Size = New System.Drawing.Size(180, 20)
        Me.stbExtraBillDate.TabIndex = 43
        '
        'stbStaffNo
        '
        Me.stbStaffNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStaffNo.CapitalizeFirstLetter = False
        Me.stbStaffNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbStaffNo.EntryErrorMSG = ""
        Me.stbStaffNo.Location = New System.Drawing.Point(425, 112)
        Me.stbStaffNo.MaxLength = 7
        Me.stbStaffNo.Name = "stbStaffNo"
        Me.stbStaffNo.ReadOnly = True
        Me.stbStaffNo.RegularExpression = ""
        Me.stbStaffNo.Size = New System.Drawing.Size(207, 20)
        Me.stbStaffNo.TabIndex = 45
        '
        'lblStaffNo
        '
        Me.lblStaffNo.Location = New System.Drawing.Point(329, 116)
        Me.lblStaffNo.Name = "lblStaffNo"
        Me.lblStaffNo.Size = New System.Drawing.Size(90, 20)
        Me.lblStaffNo.TabIndex = 44
        Me.lblStaffNo.Text = "Attending Doctor"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(425, 61)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(207, 29)
        Me.stbInsuranceName.TabIndex = 77
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(329, 67)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(90, 18)
        Me.lblBillInsuranceName.TabIndex = 76
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'stbRoundNo
        '
        Me.stbRoundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundNo.CapitalizeFirstLetter = False
        Me.stbRoundNo.EntryErrorMSG = ""
        Me.stbRoundNo.Location = New System.Drawing.Point(759, 102)
        Me.stbRoundNo.MaxLength = 20
        Me.stbRoundNo.Name = "stbRoundNo"
        Me.stbRoundNo.ReadOnly = True
        Me.stbRoundNo.RegularExpression = ""
        Me.stbRoundNo.Size = New System.Drawing.Size(180, 20)
        Me.stbRoundNo.TabIndex = 65
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(650, 98)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(103, 20)
        Me.lblRoundNo.TabIndex = 64
        Me.lblRoundNo.Text = "Round No"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(425, 32)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(207, 28)
        Me.stbBillCustomerName.TabIndex = 63
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(329, 39)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(90, 20)
        Me.lblBillCustomerName.TabIndex = 62
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(759, 34)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(180, 20)
        Me.stbVisitDate.TabIndex = 55
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(136, 32)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(180, 20)
        Me.stbPatientNo.TabIndex = 57
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(6, 33)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(124, 20)
        Me.lblPatientsNo.TabIndex = 56
        Me.lblPatientsNo.Text = "Patient's No"
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(650, 35)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(103, 20)
        Me.lblVisitDate.TabIndex = 54
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(425, 11)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(207, 20)
        Me.stbBillMode.TabIndex = 75
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(329, 13)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(90, 18)
        Me.lblBillMode.TabIndex = 74
        Me.lblBillMode.Text = "Bill Mode"
        '
        'stbVisitStatus
        '
        Me.stbVisitStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitStatus.CapitalizeFirstLetter = False
        Me.stbVisitStatus.Enabled = False
        Me.stbVisitStatus.EntryErrorMSG = ""
        Me.stbVisitStatus.Location = New System.Drawing.Point(425, 91)
        Me.stbVisitStatus.MaxLength = 60
        Me.stbVisitStatus.Name = "stbVisitStatus"
        Me.stbVisitStatus.RegularExpression = ""
        Me.stbVisitStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitStatus.Size = New System.Drawing.Size(207, 20)
        Me.stbVisitStatus.TabIndex = 71
        '
        'lblVisitStatus
        '
        Me.lblVisitStatus.Location = New System.Drawing.Point(329, 93)
        Me.lblVisitStatus.Name = "lblVisitStatus"
        Me.lblVisitStatus.Size = New System.Drawing.Size(90, 18)
        Me.lblVisitStatus.TabIndex = 70
        Me.lblVisitStatus.Text = "Visit Status"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(136, 74)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(180, 20)
        Me.stbAge.TabIndex = 69
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(759, 11)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(180, 20)
        Me.stbJoinDate.TabIndex = 67
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(136, 95)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(180, 20)
        Me.stbGender.TabIndex = 73
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(650, 12)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(100, 18)
        Me.lblJoinDate.TabIndex = 66
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(6, 75)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(124, 20)
        Me.lblAge.TabIndex = 68
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(6, 96)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(124, 20)
        Me.lblGenderID.TabIndex = 72
        Me.lblGenderID.Text = "Gender"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(136, 53)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(180, 20)
        Me.stbFullName.TabIndex = 59
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(6, 54)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(124, 20)
        Me.lblFullName.TabIndex = 58
        Me.lblFullName.Text = "Full Name"
        '
        'lblExtraBillDate
        '
        Me.lblExtraBillDate.Location = New System.Drawing.Point(650, 79)
        Me.lblExtraBillDate.Name = "lblExtraBillDate"
        Me.lblExtraBillDate.Size = New System.Drawing.Size(103, 20)
        Me.lblExtraBillDate.TabIndex = 42
        Me.lblExtraBillDate.Text = "Extra Bill Date"
        '
        'btnFindExtraBillNo
        '
        Me.btnFindExtraBillNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindExtraBillNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindExtraBillNo.Image = CType(resources.GetObject("btnFindExtraBillNo.Image"), System.Drawing.Image)
        Me.btnFindExtraBillNo.Location = New System.Drawing.Point(108, 12)
        Me.btnFindExtraBillNo.Name = "btnFindExtraBillNo"
        Me.btnFindExtraBillNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindExtraBillNo.TabIndex = 40
        '
        'lblExtraBillNo
        '
        Me.lblExtraBillNo.Location = New System.Drawing.Point(6, 12)
        Me.lblExtraBillNo.Name = "lblExtraBillNo"
        Me.lblExtraBillNo.Size = New System.Drawing.Size(91, 20)
        Me.lblExtraBillNo.TabIndex = 39
        Me.lblExtraBillNo.Text = "Extra Bill No"
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(136, 116)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(180, 21)
        Me.cboLocationID.TabIndex = 92
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(6, 117)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(124, 20)
        Me.lblLocationID.TabIndex = 91
        Me.lblLocationID.Text = "Location"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.BtnLoad)
        Me.pnlAlerts.Controls.Add(Me.lblPendingIventoryAcknowledgements)
        Me.pnlAlerts.Location = New System.Drawing.Point(12, 164)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(348, 31)
        Me.pnlAlerts.TabIndex = 93
        '
        'BtnLoad
        '
        Me.BtnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLoad.Location = New System.Drawing.Point(276, 3)
        Me.BtnLoad.Name = "BtnLoad"
        Me.BtnLoad.Size = New System.Drawing.Size(52, 24)
        Me.BtnLoad.TabIndex = 100
        Me.BtnLoad.Tag = ""
        Me.BtnLoad.Text = "&Load"
        '
        'lblPendingIventoryAcknowledgements
        '
        Me.lblPendingIventoryAcknowledgements.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingIventoryAcknowledgements.ForeColor = System.Drawing.Color.Red
        Me.lblPendingIventoryAcknowledgements.Location = New System.Drawing.Point(6, 6)
        Me.lblPendingIventoryAcknowledgements.Name = "lblPendingIventoryAcknowledgements"
        Me.lblPendingIventoryAcknowledgements.Size = New System.Drawing.Size(245, 20)
        Me.lblPendingIventoryAcknowledgements.TabIndex = 4
        Me.lblPendingIventoryAcknowledgements.Text = "Returns Acknowledgements: 0"
        '
        'dgvReturnedItems
        '
        Me.dgvReturnedItems.AllowUserToOrderColumns = True
        Me.dgvReturnedItems.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvReturnedItems.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReturnedItems.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvReturnedItems.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colAdjustmentNo, Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colDrugBatchNo, Me.ColDrugExpiryDate, Me.colDrugReturnedQuantity, Me.colDrugUnitPrice, Me.colDrugPayStatus, Me.colItemCategoryID})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvReturnedItems.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvReturnedItems.EnableHeadersVisualStyles = False
        Me.dgvReturnedItems.GridColor = System.Drawing.Color.Khaki
        Me.dgvReturnedItems.Location = New System.Drawing.Point(12, 201)
        Me.dgvReturnedItems.Name = "dgvReturnedItems"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvReturnedItems.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvReturnedItems.Size = New System.Drawing.Size(960, 330)
        Me.dgvReturnedItems.TabIndex = 0
        Me.dgvReturnedItems.Text = "DataGridView1"
        '
        'colAdjustmentNo
        '
        Me.colAdjustmentNo.DataPropertyName = "AdjustmentNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colAdjustmentNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.colAdjustmentNo.HeaderText = "Adjustment No"
        Me.colAdjustmentNo.Name = "colAdjustmentNo"
        Me.colAdjustmentNo.ReadOnly = True
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle3
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemFullName"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle4
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colItemName.Width = 200
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        Me.colItemCategory.HeaderText = "Item Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        '
        'colDrugBatchNo
        '
        Me.colDrugBatchNo.DataPropertyName = "InventoryBatchNo"
        Me.colDrugBatchNo.HeaderText = "Batch No"
        Me.colDrugBatchNo.Name = "colDrugBatchNo"
        '
        'ColDrugExpiryDate
        '
        Me.ColDrugExpiryDate.DataPropertyName = "InventoryExpiryDate"
        Me.ColDrugExpiryDate.HeaderText = "Expiry Date"
        Me.ColDrugExpiryDate.Name = "ColDrugExpiryDate"
        '
        'colDrugReturnedQuantity
        '
        Me.colDrugReturnedQuantity.DataPropertyName = "ReturnedQuantity"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugReturnedQuantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.colDrugReturnedQuantity.HeaderText = "Returned Quantity"
        Me.colDrugReturnedQuantity.Name = "colDrugReturnedQuantity"
        Me.colDrugReturnedQuantity.ReadOnly = True
        '
        'colDrugUnitPrice
        '
        Me.colDrugUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colDrugUnitPrice.DefaultCellStyle = DataGridViewCellStyle6
        Me.colDrugUnitPrice.HeaderText = "Unit Price"
        Me.colDrugUnitPrice.Name = "colDrugUnitPrice"
        Me.colDrugUnitPrice.ReadOnly = True
        Me.colDrugUnitPrice.Width = 80
        '
        'colDrugPayStatus
        '
        Me.colDrugPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugPayStatus.DefaultCellStyle = DataGridViewCellStyle7
        Me.colDrugPayStatus.HeaderText = "Pay Status"
        Me.colDrugPayStatus.Name = "colDrugPayStatus"
        Me.colDrugPayStatus.ReadOnly = True
        Me.colDrugPayStatus.Width = 80
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.DataPropertyName = "ItemCategoryID"
        Me.colItemCategoryID.HeaderText = "ItemCategoryID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        '
        'fbnSave
        '
        Me.fbnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSave.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.fbnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSave.Location = New System.Drawing.Point(11, 537)
        Me.fbnSave.Name = "fbnSave"
        Me.fbnSave.Size = New System.Drawing.Size(72, 24)
        Me.fbnSave.TabIndex = 95
        Me.fbnSave.Tag = "BillAdjustments"
        Me.fbnSave.Text = "&Save"
        Me.fbnSave.UseVisualStyleBackColor = False
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(896, 537)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 96
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'pnlAcknowledgeBiiFormReturnsDetails
        '
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbExtraBillNo)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblExtraBillNo)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.btnFindExtraBillNo)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblExtraBillDate)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblFullName)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbJoinDate)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblJoinDate)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbVisitNo)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.cboLocationID)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbExtraBillDate)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbVisitDate)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblRoundNo)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblVisitDate)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbFullName)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbRoundNo)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblLocationID)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblVisitNo)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblGenderID)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblAge)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbGender)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbAge)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbStaffNo)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblVisitStatus)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblStaffNo)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbVisitStatus)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbInsuranceName)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblBillMode)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblBillInsuranceName)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbBillMode)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblPatientsNo)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbBillCustomerName)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.stbPatientNo)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Controls.Add(Me.lblBillCustomerName)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Location = New System.Drawing.Point(14, 3)
        Me.pnlAcknowledgeBiiFormReturnsDetails.Name = "pnlAcknowledgeBiiFormReturnsDetails"
        Me.pnlAcknowledgeBiiFormReturnsDetails.Size = New System.Drawing.Size(959, 156)
        Me.pnlAcknowledgeBiiFormReturnsDetails.TabIndex = 97
        '
        'stbExtraBillNo
        '
        Me.stbExtraBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExtraBillNo.CapitalizeFirstLetter = False
        Me.stbExtraBillNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbExtraBillNo.EntryErrorMSG = ""
        Me.stbExtraBillNo.Location = New System.Drawing.Point(136, 11)
        Me.stbExtraBillNo.MaxLength = 20
        Me.stbExtraBillNo.Name = "stbExtraBillNo"
        Me.stbExtraBillNo.RegularExpression = ""
        Me.stbExtraBillNo.Size = New System.Drawing.Size(180, 20)
        Me.stbExtraBillNo.TabIndex = 98
        '
        'frmAcknowledgeBillReturns
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 573)
        Me.Controls.Add(Me.dgvReturnedItems)
        Me.Controls.Add(Me.pnlAcknowledgeBiiFormReturnsDetails)
        Me.Controls.Add(Me.fbnSave)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAcknowledgeBillReturns"
        Me.Text = "Acknowledge Bill Form Returns"
        Me.pnlAlerts.ResumeLayout(False)
        CType(Me.dgvReturnedItems, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAcknowledgeBiiFormReturnsDetails.ResumeLayout(False)
        Me.pnlAcknowledgeBiiFormReturnsDetails.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbExtraBillDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbStaffNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStaffNo As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
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
    Friend WithEvents lblExtraBillNo As System.Windows.Forms.Label
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents lblPendingIventoryAcknowledgements As System.Windows.Forms.Label
    Friend WithEvents dgvReturnedItems As System.Windows.Forms.DataGridView
    Friend WithEvents fbnSave As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents pnlAcknowledgeBiiFormReturnsDetails As System.Windows.Forms.Panel
    Friend WithEvents stbExtraBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents BtnLoad As System.Windows.Forms.Button
    Friend WithEvents colAdjustmentNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugBatchNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDrugExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugReturnedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
