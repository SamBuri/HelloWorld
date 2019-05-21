<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIPDExtraCharge : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal keyNo As String)
        MyClass.New()
        Me.keyNo = keyNo
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIPDExtraCharge))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.cmsExtraBills = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsExtraBillsQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblStaffNo = New System.Windows.Forms.Label()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.lblCashAccountBalance = New System.Windows.Forms.Label()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxCashAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForItem = New System.Windows.Forms.Label()
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
        Me.dtpExtraBillDate = New System.Windows.Forms.DateTimePicker()
        Me.lblExtraBillDate = New System.Windows.Forms.Label()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.btnFindExtraBillNo = New System.Windows.Forms.Button()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbExtraBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblExtraBillNo = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvExtraCharge = New System.Windows.Forms.DataGridView()
        Me.colExtraItemFullName = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colExtraChargeQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargePayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExtraChargeSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsExtraBills.SuspendLayout()
        Me.pnlBill.SuspendLayout()
        CType(Me.dgvExtraCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(-9, 5)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(100, 23)
        Me.lblLoginID.TabIndex = 118
        '
        'cmsExtraBills
        '
        Me.cmsExtraBills.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsExtraBills.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsExtraBillsQuickSearch})
        Me.cmsExtraBills.Name = "cmsSearch"
        Me.cmsExtraBills.Size = New System.Drawing.Size(144, 26)
        '
        'cmsExtraBillsQuickSearch
        '
        Me.cmsExtraBillsQuickSearch.Image = CType(resources.GetObject("cmsExtraBillsQuickSearch.Image"), System.Drawing.Image)
        Me.cmsExtraBillsQuickSearch.Name = "cmsExtraBillsQuickSearch"
        Me.cmsExtraBillsQuickSearch.Size = New System.Drawing.Size(143, 22)
        Me.cmsExtraBillsQuickSearch.Text = "Quick Search"
        '
        'lblStaffNo
        '
        Me.lblStaffNo.Location = New System.Drawing.Point(12, 74)
        Me.lblStaffNo.Name = "lblStaffNo"
        Me.lblStaffNo.Size = New System.Drawing.Size(124, 20)
        Me.lblStaffNo.TabIndex = 131
        Me.lblStaffNo.Text = "Attending Doctor"
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(322, 76)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(96, 18)
        Me.lblBillInsuranceName.TabIndex = 163
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(318, 116)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(137, 20)
        Me.lblRoundNo.TabIndex = 149
        Me.lblRoundNo.Text = "Round No"
        '
        'lblCashAccountBalance
        '
        Me.lblCashAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblCashAccountBalance.Location = New System.Drawing.Point(318, 136)
        Me.lblCashAccountBalance.Name = "lblCashAccountBalance"
        Me.lblCashAccountBalance.Size = New System.Drawing.Size(137, 20)
        Me.lblCashAccountBalance.TabIndex = 151
        Me.lblCashAccountBalance.Text = "Cash Account Balance"
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.Location = New System.Drawing.Point(142, 71)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(170, 21)
        Me.cboStaffNo.TabIndex = 132
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbInsuranceName, "InsuranceName")
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(464, 76)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(139, 37)
        Me.stbInsuranceName.TabIndex = 164
        '
        'stbRoundNo
        '
        Me.stbRoundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbRoundNo, "RoundNo")
        Me.stbRoundNo.EntryErrorMSG = ""
        Me.stbRoundNo.Location = New System.Drawing.Point(464, 114)
        Me.stbRoundNo.MaxLength = 20
        Me.stbRoundNo.Name = "stbRoundNo"
        Me.stbRoundNo.ReadOnly = True
        Me.stbRoundNo.RegularExpression = ""
        Me.stbRoundNo.Size = New System.Drawing.Size(139, 20)
        Me.stbRoundNo.TabIndex = 150
        '
        'nbxCashAccountBalance
        '
        Me.nbxCashAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCashAccountBalance.ControlCaption = "Cash Account Balance"
        Me.nbxCashAccountBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCashAccountBalance, "CashAccountBalance")
        Me.nbxCashAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCashAccountBalance.DecimalPlaces = -1
        Me.nbxCashAccountBalance.Location = New System.Drawing.Point(464, 135)
        Me.nbxCashAccountBalance.MaxValue = 0.0R
        Me.nbxCashAccountBalance.MinValue = 0.0R
        Me.nbxCashAccountBalance.MustEnterNumeric = True
        Me.nbxCashAccountBalance.Name = "nbxCashAccountBalance"
        Me.nbxCashAccountBalance.ReadOnly = True
        Me.nbxCashAccountBalance.Size = New System.Drawing.Size(139, 20)
        Me.nbxCashAccountBalance.TabIndex = 152
        Me.nbxCashAccountBalance.Value = ""
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(5, 160)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(878, 41)
        Me.pnlBill.TabIndex = 165
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(313, 6)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(137, 20)
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
        Me.stbBillForItem.Location = New System.Drawing.Point(137, 4)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(170, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(459, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(410, 34)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(7, 6)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(124, 20)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Bill for Admission"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillCustomerName, "BillCustomerName")
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(464, 47)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(139, 28)
        Me.stbBillCustomerName.TabIndex = 148
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(318, 54)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(137, 20)
        Me.lblBillCustomerName.TabIndex = 147
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillNo, "BillNo")
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(464, 5)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(139, 20)
        Me.stbBillNo.TabIndex = 146
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(318, 7)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(137, 20)
        Me.lblBillNo.TabIndex = 145
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayValue, "CoPayValue")
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(142, 137)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(170, 20)
        Me.nbxCoPayValue.TabIndex = 138
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(12, 138)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(124, 20)
        Me.lblCoPayValue.TabIndex = 137
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayPercent, "CoPayPercent")
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(142, 116)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(170, 20)
        Me.nbxCoPayPercent.TabIndex = 136
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(12, 117)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(124, 20)
        Me.lblCoPayPercent.TabIndex = 135
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbCoPayType, "CoPayType")
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(142, 95)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(170, 20)
        Me.stbCoPayType.TabIndex = 134
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(12, 95)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(124, 20)
        Me.lblCoPayType.TabIndex = 133
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitDate, "VisitDate")
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(711, 112)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(163, 20)
        Me.stbVisitDate.TabIndex = 140
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbPatientNo, "PatientNo")
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(711, 7)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(163, 20)
        Me.stbPatientNo.TabIndex = 142
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(609, 7)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(96, 20)
        Me.lblPatientsNo.TabIndex = 141
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(610, 114)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(96, 20)
        Me.lblVisitDate.TabIndex = 139
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillMode, "BillMode")
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(464, 26)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(139, 20)
        Me.stbBillMode.TabIndex = 162
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(318, 32)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(96, 18)
        Me.lblBillMode.TabIndex = 161
        Me.lblBillMode.Text = "Bill Mode"
        '
        'stbVisitStatus
        '
        Me.stbVisitStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitStatus.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitStatus, "VisitStatus")
        Me.stbVisitStatus.Enabled = False
        Me.stbVisitStatus.EntryErrorMSG = ""
        Me.stbVisitStatus.Location = New System.Drawing.Point(711, 91)
        Me.stbVisitStatus.MaxLength = 60
        Me.stbVisitStatus.Name = "stbVisitStatus"
        Me.stbVisitStatus.RegularExpression = ""
        Me.stbVisitStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitStatus.Size = New System.Drawing.Size(163, 20)
        Me.stbVisitStatus.TabIndex = 158
        '
        'lblVisitStatus
        '
        Me.lblVisitStatus.Location = New System.Drawing.Point(609, 93)
        Me.lblVisitStatus.Name = "lblVisitStatus"
        Me.lblVisitStatus.Size = New System.Drawing.Size(96, 18)
        Me.lblVisitStatus.TabIndex = 157
        Me.lblVisitStatus.Text = "Visit Status"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAge, "Age")
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(711, 49)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(163, 20)
        Me.stbAge.TabIndex = 156
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbJoinDate, "JoinDate")
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(711, 133)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(163, 20)
        Me.stbJoinDate.TabIndex = 154
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbGender, "Gender")
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(711, 70)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(163, 20)
        Me.stbGender.TabIndex = 160
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(610, 135)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(96, 18)
        Me.lblJoinDate.TabIndex = 153
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(610, 51)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(96, 18)
        Me.lblAge.TabIndex = 155
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(610, 72)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(96, 18)
        Me.lblGenderID.TabIndex = 159
        Me.lblGenderID.Text = "Gender"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbFullName, "FullName")
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(711, 28)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(163, 20)
        Me.stbFullName.TabIndex = 144
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(610, 30)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(95, 20)
        Me.lblFullName.TabIndex = 143
        Me.lblFullName.Text = "Full Name"
        '
        'dtpExtraBillDate
        '
        Me.dtpExtraBillDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpExtraBillDate, "ExtraBillDate")
        Me.dtpExtraBillDate.Location = New System.Drawing.Point(142, 51)
        Me.dtpExtraBillDate.Name = "dtpExtraBillDate"
        Me.dtpExtraBillDate.ShowCheckBox = True
        Me.dtpExtraBillDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpExtraBillDate.TabIndex = 130
        '
        'lblExtraBillDate
        '
        Me.lblExtraBillDate.Location = New System.Drawing.Point(12, 51)
        Me.lblExtraBillDate.Name = "lblExtraBillDate"
        Me.lblExtraBillDate.Size = New System.Drawing.Size(124, 20)
        Me.lblExtraBillDate.TabIndex = 129
        Me.lblExtraBillDate.Text = "Extra Bill Date"
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(268, 5)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 125
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(114, 8)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 123
        '
        'btnFindExtraBillNo
        '
        Me.btnFindExtraBillNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindExtraBillNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindExtraBillNo.Image = CType(resources.GetObject("btnFindExtraBillNo.Image"), System.Drawing.Image)
        Me.btnFindExtraBillNo.Location = New System.Drawing.Point(114, 30)
        Me.btnFindExtraBillNo.Name = "btnFindExtraBillNo"
        Me.btnFindExtraBillNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindExtraBillNo.TabIndex = 127
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitNo, "VisitNo")
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(142, 9)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.ReadOnly = True
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(120, 20)
        Me.stbVisitNo.TabIndex = 124
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(13, 452)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 171
        Me.ebnSaveUpdate.Tag = "ExtraBills"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(804, 452)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 174
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbExtraBillNo
        '
        Me.stbExtraBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExtraBillNo.CapitalizeFirstLetter = False
        Me.stbExtraBillNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbExtraBillNo.EntryErrorMSG = ""
        Me.stbExtraBillNo.Location = New System.Drawing.Point(142, 30)
        Me.stbExtraBillNo.MaxLength = 20
        Me.stbExtraBillNo.Name = "stbExtraBillNo"
        Me.stbExtraBillNo.ReadOnly = True
        Me.stbExtraBillNo.RegularExpression = ""
        Me.stbExtraBillNo.Size = New System.Drawing.Size(170, 20)
        Me.stbExtraBillNo.TabIndex = 128
        '
        'lblExtraBillNo
        '
        Me.lblExtraBillNo.Location = New System.Drawing.Point(12, 30)
        Me.lblExtraBillNo.Name = "lblExtraBillNo"
        Me.lblExtraBillNo.Size = New System.Drawing.Size(91, 20)
        Me.lblExtraBillNo.TabIndex = 126
        Me.lblExtraBillNo.Text = "Extra Bill No"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(12, 9)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(91, 20)
        Me.lblVisitNo.TabIndex = 120
        Me.lblVisitNo.Text = "Visit No"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(0, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 23)
        Me.Label1.TabIndex = 121
        '
        'dgvExtraCharge
        '
        Me.dgvExtraCharge.AllowUserToOrderColumns = True
        Me.dgvExtraCharge.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraCharge.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExtraCharge.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colExtraItemFullName, Me.colExtraChargeQuantity, Me.colExtraChargeUnitPrice, Me.colExtraChargeAmount, Me.colExtraChargeNotes, Me.colExtraChargePayStatus, Me.colExtraChargeEntryMode, Me.colExtraChargeSaved})
        Me.dgvExtraCharge.ContextMenuStrip = Me.cmsExtraBills
        Me.dgvExtraCharge.EnableHeadersVisualStyles = False
        Me.dgvExtraCharge.GridColor = System.Drawing.Color.Khaki
        Me.dgvExtraCharge.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvExtraCharge.Location = New System.Drawing.Point(9, 207)
        Me.dgvExtraCharge.Name = "dgvExtraCharge"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExtraCharge.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvExtraCharge.Size = New System.Drawing.Size(874, 239)
        Me.dgvExtraCharge.TabIndex = 177
        Me.dgvExtraCharge.Text = "DataGridView1"
        '
        'colExtraItemFullName
        '
        Me.colExtraItemFullName.DataPropertyName = "ItemFullName"
        Me.colExtraItemFullName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colExtraItemFullName.DisplayStyleForCurrentCellOnly = True
        Me.colExtraItemFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExtraItemFullName.HeaderText = "Item Name"
        Me.colExtraItemFullName.Name = "colExtraItemFullName"
        Me.colExtraItemFullName.Sorted = True
        Me.colExtraItemFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colExtraItemFullName.Width = 260
        '
        'colExtraChargeQuantity
        '
        Me.colExtraChargeQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colExtraChargeQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colExtraChargeQuantity.HeaderText = "Quantity"
        Me.colExtraChargeQuantity.MaxInputLength = 12
        Me.colExtraChargeQuantity.Name = "colExtraChargeQuantity"
        Me.colExtraChargeQuantity.Width = 50
        '
        'colExtraChargeUnitPrice
        '
        Me.colExtraChargeUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colExtraChargeUnitPrice.DefaultCellStyle = DataGridViewCellStyle3
        Me.colExtraChargeUnitPrice.HeaderText = "Unit Price"
        Me.colExtraChargeUnitPrice.Name = "colExtraChargeUnitPrice"
        Me.colExtraChargeUnitPrice.Width = 65
        '
        'colExtraChargeAmount
        '
        Me.colExtraChargeAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.colExtraChargeAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.colExtraChargeAmount.HeaderText = "Amount"
        Me.colExtraChargeAmount.Name = "colExtraChargeAmount"
        Me.colExtraChargeAmount.ReadOnly = True
        Me.colExtraChargeAmount.Width = 65
        '
        'colExtraChargeNotes
        '
        Me.colExtraChargeNotes.DataPropertyName = "Notes"
        Me.colExtraChargeNotes.HeaderText = "Notes"
        Me.colExtraChargeNotes.MaxInputLength = 200
        Me.colExtraChargeNotes.Name = "colExtraChargeNotes"
        '
        'colExtraChargePayStatus
        '
        Me.colExtraChargePayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colExtraChargePayStatus.DefaultCellStyle = DataGridViewCellStyle5
        Me.colExtraChargePayStatus.HeaderText = "Pay Status"
        Me.colExtraChargePayStatus.Name = "colExtraChargePayStatus"
        Me.colExtraChargePayStatus.ReadOnly = True
        Me.colExtraChargePayStatus.Width = 80
        '
        'colExtraChargeEntryMode
        '
        Me.colExtraChargeEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colExtraChargeEntryMode.DefaultCellStyle = DataGridViewCellStyle6
        Me.colExtraChargeEntryMode.HeaderText = "Entry Mode"
        Me.colExtraChargeEntryMode.Name = "colExtraChargeEntryMode"
        Me.colExtraChargeEntryMode.ReadOnly = True
        Me.colExtraChargeEntryMode.Width = 80
        '
        'colExtraChargeSaved
        '
        Me.colExtraChargeSaved.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = False
        Me.colExtraChargeSaved.DefaultCellStyle = DataGridViewCellStyle7
        Me.colExtraChargeSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExtraChargeSaved.HeaderText = "Saved"
        Me.colExtraChargeSaved.Name = "colExtraChargeSaved"
        Me.colExtraChargeSaved.ReadOnly = True
        Me.colExtraChargeSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colExtraChargeSaved.Width = 50
        '
        'frmIPDExtraCharge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(892, 483)
        Me.Controls.Add(Me.dgvExtraCharge)
        Me.Controls.Add(Me.lblStaffNo)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.lblRoundNo)
        Me.Controls.Add(Me.lblCashAccountBalance)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.stbRoundNo)
        Me.Controls.Add(Me.nbxCashAccountBalance)
        Me.Controls.Add(Me.pnlBill)
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
        Me.Controls.Add(Me.dtpExtraBillDate)
        Me.Controls.Add(Me.lblExtraBillDate)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.btnFindExtraBillNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbExtraBillNo)
        Me.Controls.Add(Me.lblExtraBillNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblLoginID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIPDExtraCharge"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IPD ExtraCharge"
        Me.cmsExtraBills.ResumeLayout(False)
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        CType(Me.dgvExtraCharge, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents cmsExtraBills As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsExtraBillsQuickSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblStaffNo As System.Windows.Forms.Label
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents lblCashAccountBalance As System.Windows.Forms.Label
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents nbxCashAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForItem As System.Windows.Forms.Label
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
    Friend WithEvents dtpExtraBillDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblExtraBillDate As System.Windows.Forms.Label
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents btnFindExtraBillNo As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbExtraBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblExtraBillNo As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvExtraCharge As System.Windows.Forms.DataGridView
    Friend WithEvents colExtraItemFullName As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colExtraChargeQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargePayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExtraChargeSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
