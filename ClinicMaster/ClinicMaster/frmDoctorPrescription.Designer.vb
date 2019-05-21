
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDoctorPrescription : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal visitNo As String)
        MyClass.New()
        Me.defaultVisitNo = visitNo
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDoctorPrescription))
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForItem = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForItem = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.fbnSave = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvPrescription = New System.Windows.Forms.DataGridView()
        Me.colDrug = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDosage = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDuration = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugFormula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAvailableStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitsInStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrescriptionGroup = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAlternateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colDrugPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHalted = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colHasAlternateDrugs = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cmsPrescription = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsPrescriptionQuickSearch = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpCoPay = New System.Windows.Forms.Panel()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.pnlBill.SuspendLayout()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsPrescription.SuspendLayout()
        Me.grpCoPay.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(736, 451)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(77, 23)
        Me.fbnDelete.TabIndex = 23
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = True
        Me.fbnDelete.Visible = False
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(136, 47)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(162, 20)
        Me.stbPatientNo.TabIndex = 5
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(693, 45)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(112, 20)
        Me.stbBillMode.TabIndex = 19
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(136, 89)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(162, 20)
        Me.stbBillNo.TabIndex = 9
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(693, 24)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(112, 20)
        Me.stbAge.TabIndex = 17
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(693, 3)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(112, 20)
        Me.stbGender.TabIndex = 15
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(136, 26)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(162, 20)
        Me.stbFullName.TabIndex = 3
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(819, 450)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 24
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(16, 48)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(114, 18)
        Me.lblPatientsNo.TabIndex = 4
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(593, 45)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(94, 18)
        Me.lblBillMode.TabIndex = 18
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(16, 87)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(114, 18)
        Me.lblBillNo.TabIndex = 8
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(593, 24)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(94, 18)
        Me.lblAge.TabIndex = 16
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(593, 3)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(94, 18)
        Me.lblGenderID.TabIndex = 14
        Me.lblGenderID.Text = "Gender"
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(16, 27)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(114, 18)
        Me.lblFullName.TabIndex = 2
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(136, 68)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(162, 20)
        Me.stbVisitDate.TabIndex = 7
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(16, 68)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(114, 18)
        Me.lblVisitDate.TabIndex = 6
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(136, 5)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.ReadOnly = True
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(162, 20)
        Me.stbVisitNo.TabIndex = 1
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(16, 5)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(114, 18)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No"
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(10, 116)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(808, 38)
        Me.pnlBill.TabIndex = 20
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(299, 8)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(94, 18)
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
        Me.stbBillForItem.Location = New System.Drawing.Point(126, 5)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(162, 20)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(419, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(376, 31)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(3, 7)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(117, 18)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Bill for Prescription"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(429, 5)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(158, 41)
        Me.stbBillCustomerName.TabIndex = 11
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(304, 15)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(106, 18)
        Me.lblBillCustomerName.TabIndex = 10
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(429, 47)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(158, 40)
        Me.stbInsuranceName.TabIndex = 13
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(304, 55)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(106, 18)
        Me.lblBillInsuranceName.TabIndex = 12
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'fbnSave
        '
        Me.fbnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSave.Location = New System.Drawing.Point(16, 455)
        Me.fbnSave.Name = "fbnSave"
        Me.fbnSave.Size = New System.Drawing.Size(77, 23)
        Me.fbnSave.TabIndex = 22
        Me.fbnSave.Text = "&Save"
        Me.fbnSave.UseVisualStyleBackColor = True
        '
        'dgvPrescription
        '
        Me.dgvPrescription.AllowUserToOrderColumns = True
        Me.dgvPrescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPrescription.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPrescription.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrug, Me.colDosage, Me.colDuration, Me.colDrugQuantity, Me.colDrugFormula, Me.colAvailableStock, Me.colOrderLevel, Me.colPrescriptionUnitMeasure, Me.colDrugUnitPrice, Me.colAmount, Me.colPrescriptionSaved, Me.colExpiryDate, Me.colUnitsInStock, Me.colPrescriptionGroup, Me.colAlternateName, Me.colDrugItemStatus, Me.colDrugPayStatus, Me.colHalted, Me.colHasAlternateDrugs})
        Me.dgvPrescription.ContextMenuStrip = Me.cmsPrescription
        Me.dgvPrescription.EnableHeadersVisualStyles = False
        Me.dgvPrescription.GridColor = System.Drawing.Color.Khaki
        Me.dgvPrescription.Location = New System.Drawing.Point(16, 160)
        Me.dgvPrescription.Name = "dgvPrescription"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPrescription.RowHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvPrescription.Size = New System.Drawing.Size(875, 284)
        Me.dgvPrescription.TabIndex = 21
        Me.dgvPrescription.Text = "DataGridView1"
        '
        'colDrug
        '
        Me.colDrug.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colDrug.DisplayStyleForCurrentCellOnly = True
        Me.colDrug.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrug.HeaderText = "Drug"
        Me.colDrug.Name = "colDrug"
        Me.colDrug.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDrug.Width = 240
        '
        'colDosage
        '
        Me.colDosage.HeaderText = "Dosage"
        Me.colDosage.MaxInputLength = 100
        Me.colDosage.Name = "colDosage"
        Me.colDosage.ToolTipText = "Enter dosage in a format as set in drug categories"
        Me.colDosage.Width = 50
        '
        'colDuration
        '
        Me.colDuration.HeaderText = "Duration"
        Me.colDuration.Name = "colDuration"
        Me.colDuration.ToolTipText = "Duration in Days"
        Me.colDuration.Width = 50
        '
        'colDrugQuantity
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colDrugQuantity.DefaultCellStyle = DataGridViewCellStyle2
        Me.colDrugQuantity.HeaderText = "Quantity"
        Me.colDrugQuantity.Name = "colDrugQuantity"
        Me.colDrugQuantity.Width = 50
        '
        'colDrugFormula
        '
        Me.colDrugFormula.HeaderText = "Notes"
        Me.colDrugFormula.MaxInputLength = 100
        Me.colDrugFormula.Name = "colDrugFormula"
        Me.colDrugFormula.Width = 70
        '
        'colAvailableStock
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colAvailableStock.DefaultCellStyle = DataGridViewCellStyle3
        Me.colAvailableStock.HeaderText = "Available Stock"
        Me.colAvailableStock.Name = "colAvailableStock"
        Me.colAvailableStock.ReadOnly = True
        Me.colAvailableStock.Width = 90
        '
        'colOrderLevel
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colOrderLevel.DefaultCellStyle = DataGridViewCellStyle4
        Me.colOrderLevel.HeaderText = "Order Level"
        Me.colOrderLevel.Name = "colOrderLevel"
        Me.colOrderLevel.ReadOnly = True
        Me.colOrderLevel.Visible = False
        Me.colOrderLevel.Width = 70
        '
        'colPrescriptionUnitMeasure
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colPrescriptionUnitMeasure.DefaultCellStyle = DataGridViewCellStyle5
        Me.colPrescriptionUnitMeasure.HeaderText = "Unit Measure"
        Me.colPrescriptionUnitMeasure.Name = "colPrescriptionUnitMeasure"
        Me.colPrescriptionUnitMeasure.ReadOnly = True
        Me.colPrescriptionUnitMeasure.Width = 80
        '
        'colDrugUnitPrice
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colDrugUnitPrice.DefaultCellStyle = DataGridViewCellStyle6
        Me.colDrugUnitPrice.HeaderText = "Unit Price"
        Me.colDrugUnitPrice.Name = "colDrugUnitPrice"
        Me.colDrugUnitPrice.ReadOnly = True
        Me.colDrugUnitPrice.Width = 65
        '
        'colAmount
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 65
        '
        'colPrescriptionSaved
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle8.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle8.NullValue = False
        Me.colPrescriptionSaved.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPrescriptionSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPrescriptionSaved.HeaderText = "Saved"
        Me.colPrescriptionSaved.Name = "colPrescriptionSaved"
        Me.colPrescriptionSaved.ReadOnly = True
        Me.colPrescriptionSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPrescriptionSaved.Width = 50
        '
        'colExpiryDate
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colExpiryDate.DefaultCellStyle = DataGridViewCellStyle9
        Me.colExpiryDate.HeaderText = "Expiry Date"
        Me.colExpiryDate.Name = "colExpiryDate"
        Me.colExpiryDate.ReadOnly = True
        Me.colExpiryDate.Width = 80
        '
        'colUnitsInStock
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitsInStock.DefaultCellStyle = DataGridViewCellStyle10
        Me.colUnitsInStock.HeaderText = "Units In Stock"
        Me.colUnitsInStock.Name = "colUnitsInStock"
        Me.colUnitsInStock.ReadOnly = True
        Me.colUnitsInStock.Width = 80
        '
        'colPrescriptionGroup
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colPrescriptionGroup.DefaultCellStyle = DataGridViewCellStyle11
        Me.colPrescriptionGroup.HeaderText = "Group"
        Me.colPrescriptionGroup.Name = "colPrescriptionGroup"
        Me.colPrescriptionGroup.ReadOnly = True
        Me.colPrescriptionGroup.Width = 80
        '
        'colAlternateName
        '
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colAlternateName.DefaultCellStyle = DataGridViewCellStyle12
        Me.colAlternateName.HeaderText = "Alternate Name"
        Me.colAlternateName.Name = "colAlternateName"
        Me.colAlternateName.ReadOnly = True
        Me.colAlternateName.Width = 90
        '
        'colDrugItemStatus
        '
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugItemStatus.DefaultCellStyle = DataGridViewCellStyle13
        Me.colDrugItemStatus.HeaderText = "Item Status"
        Me.colDrugItemStatus.Name = "colDrugItemStatus"
        Me.colDrugItemStatus.ReadOnly = True
        Me.colDrugItemStatus.Width = 80
        '
        'colDrugPayStatus
        '
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colDrugPayStatus.DefaultCellStyle = DataGridViewCellStyle14
        Me.colDrugPayStatus.HeaderText = "Pay Status"
        Me.colDrugPayStatus.Name = "colDrugPayStatus"
        Me.colDrugPayStatus.ReadOnly = True
        Me.colDrugPayStatus.Width = 80
        '
        'colHalted
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle15.NullValue = False
        Me.colHalted.DefaultCellStyle = DataGridViewCellStyle15
        Me.colHalted.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colHalted.HeaderText = "Halted"
        Me.colHalted.Name = "colHalted"
        Me.colHalted.ReadOnly = True
        Me.colHalted.Width = 50
        '
        'colHasAlternateDrugs
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle16.NullValue = False
        Me.colHasAlternateDrugs.DefaultCellStyle = DataGridViewCellStyle16
        Me.colHasAlternateDrugs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colHasAlternateDrugs.HeaderText = "Has Alternate Drugs"
        Me.colHasAlternateDrugs.Name = "colHasAlternateDrugs"
        Me.colHasAlternateDrugs.ReadOnly = True
        Me.colHasAlternateDrugs.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colHasAlternateDrugs.Width = 110
        '
        'cmsPrescription
        '
        Me.cmsPrescription.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsPrescription.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsPrescriptionQuickSearch})
        Me.cmsPrescription.Name = "cmsSearch"
        Me.cmsPrescription.Size = New System.Drawing.Size(153, 48)
        Me.cmsPrescription.Tag = ""
        '
        'cmsPrescriptionQuickSearch
        '
        Me.cmsPrescriptionQuickSearch.Image = CType(resources.GetObject("cmsPrescriptionQuickSearch.Image"), System.Drawing.Image)
        Me.cmsPrescriptionQuickSearch.Name = "cmsPrescriptionQuickSearch"
        Me.cmsPrescriptionQuickSearch.Size = New System.Drawing.Size(152, 22)
        Me.cmsPrescriptionQuickSearch.Text = "Quick Search"
        '
        'grpCoPay
        '
        Me.grpCoPay.Controls.Add(Me.nbxCoPayValue)
        Me.grpCoPay.Controls.Add(Me.lblCoPayValue)
        Me.grpCoPay.Controls.Add(Me.nbxCoPayPercent)
        Me.grpCoPay.Controls.Add(Me.lblCoPayPercent)
        Me.grpCoPay.Controls.Add(Me.stbCoPayType)
        Me.grpCoPay.Controls.Add(Me.lblCoPayType)
        Me.grpCoPay.Location = New System.Drawing.Point(304, 88)
        Me.grpCoPay.Name = "grpCoPay"
        Me.grpCoPay.Size = New System.Drawing.Size(514, 26)
        Me.grpCoPay.TabIndex = 25
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(415, 3)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(86, 20)
        Me.nbxCoPayValue.TabIndex = 5
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(330, 4)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(79, 19)
        Me.lblCoPayValue.TabIndex = 4
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(269, 3)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(55, 20)
        Me.nbxCoPayPercent.TabIndex = 3
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(175, 4)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(88, 19)
        Me.lblCoPayPercent.TabIndex = 2
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(89, 3)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(80, 20)
        Me.stbCoPayType.TabIndex = 1
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(4, 3)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(76, 20)
        Me.lblCoPayType.TabIndex = 0
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'frmDoctorPrescription
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(907, 490)
        Me.Controls.Add(Me.grpCoPay)
        Me.Controls.Add(Me.dgvPrescription)
        Me.Controls.Add(Me.fbnSave)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDoctorPrescription"
        Me.Text = "Doctor Prescription"
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        CType(Me.dgvPrescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsPrescription.ResumeLayout(False)
        Me.grpCoPay.ResumeLayout(False)
        Me.grpCoPay.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForItem As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForItem As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents fbnSave As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvPrescription As System.Windows.Forms.DataGridView
    Friend WithEvents colDrug As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDosage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDuration As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugFormula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAvailableStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitsInStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrescriptionGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAlternateName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colDrugPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHalted As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colHasAlternateDrugs As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents grpCoPay As System.Windows.Forms.Panel
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents cmsPrescription As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsPrescriptionQuickSearch As System.Windows.Forms.ToolStripMenuItem

End Class