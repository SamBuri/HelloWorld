
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSmartBilling : Inherits System.Windows.Forms.Form

'Form overrides dispose to clean up the component list.
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
	If disposing AndAlso components IsNot Nothing Then
		components.Dispose()
	End If
	MyBase.Dispose(disposing)
    End Sub
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    Public Sub New(ByVal admissionNo As String)
        MyClass.New()
        Me.defaultAdmissionNo = admissionNo
    End Sub


'Required by the Windows Form Designer
Private components As System.ComponentModel.IContainer

'NOTE: The following procedure is required by the Windows Form Designer
'It can be modified using the Windows Form Designer.
'Do not modify it using the code editor.
<System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSmartBilling))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.nbxCashAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCashAccountBalance = New System.Windows.Forms.Label()
        Me.dgvSmartBills = New System.Windows.Forms.DataGridView()
        Me.colInclude = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.colExtraBillNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEntryMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.stbAdmissionDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.lblAdmissionDateTime = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnFindAdmissionNo = New System.Windows.Forms.Button()
        Me.lblAdmissionNo = New System.Windows.Forms.Label()
        Me.btnLoadAdmissions = New System.Windows.Forms.Button()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.lblAgeString = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.stbAdmissionStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionStatus = New System.Windows.Forms.Label()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbProvisionalLimit = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblProvisionalLimit = New System.Windows.Forms.Label()
        CType(Me.dgvSmartBills, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBill.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(1088, 560)
        Me.fbnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(96, 30)
        Me.fbnClose.TabIndex = 40
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BackColor = System.Drawing.SystemColors.Info
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        Me.stbInsuranceName.Location = New System.Drawing.Point(617, 64)
        Me.stbInsuranceName.Margin = New System.Windows.Forms.Padding(4)
        Me.stbInsuranceName.MaxLength = 41
        Me.stbInsuranceName.Multiline = True
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        Me.stbInsuranceName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbInsuranceName.Size = New System.Drawing.Size(185, 45)
        Me.stbInsuranceName.TabIndex = 21
        '
        'lblBillInsuranceName
        '
        Me.lblBillInsuranceName.Location = New System.Drawing.Point(426, 64)
        Me.lblBillInsuranceName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        Me.lblBillInsuranceName.Size = New System.Drawing.Size(128, 22)
        Me.lblBillInsuranceName.TabIndex = 20
        Me.lblBillInsuranceName.Text = "To-Bill Insurance"
        '
        'nbxCashAccountBalance
        '
        Me.nbxCashAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxCashAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCashAccountBalance.ControlCaption = "Cash Account Balance"
        Me.nbxCashAccountBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCashAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCashAccountBalance.DecimalPlaces = -1
        Me.nbxCashAccountBalance.Location = New System.Drawing.Point(618, 135)
        Me.nbxCashAccountBalance.Margin = New System.Windows.Forms.Padding(4)
        Me.nbxCashAccountBalance.MaxValue = 0.0R
        Me.nbxCashAccountBalance.MinValue = 0.0R
        Me.nbxCashAccountBalance.MustEnterNumeric = True
        Me.nbxCashAccountBalance.Name = "nbxCashAccountBalance"
        Me.nbxCashAccountBalance.ReadOnly = True
        Me.nbxCashAccountBalance.Size = New System.Drawing.Size(185, 22)
        Me.nbxCashAccountBalance.TabIndex = 25
        Me.nbxCashAccountBalance.Value = ""
        '
        'lblCashAccountBalance
        '
        Me.lblCashAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblCashAccountBalance.Location = New System.Drawing.Point(423, 137)
        Me.lblCashAccountBalance.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCashAccountBalance.Name = "lblCashAccountBalance"
        Me.lblCashAccountBalance.Size = New System.Drawing.Size(183, 25)
        Me.lblCashAccountBalance.TabIndex = 24
        Me.lblCashAccountBalance.Text = "Cash Account Balance"
        '
        'dgvSmartBills
        '
        Me.dgvSmartBills.AllowUserToAddRows = False
        Me.dgvSmartBills.AllowUserToDeleteRows = False
        Me.dgvSmartBills.AllowUserToOrderColumns = True
        Me.dgvSmartBills.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSmartBills.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSmartBills.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvSmartBills.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colExtraBillNo, Me.colItemCode, Me.colItemName, Me.colItemCategory, Me.colQuantity, Me.colUnitPrice, Me.colAmount, Me.colCashAmount, Me.colNotes, Me.colPayStatus, Me.colEntryMode, Me.colItemCategoryID})
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSmartBills.DefaultCellStyle = DataGridViewCellStyle25
        Me.dgvSmartBills.EnableHeadersVisualStyles = False
        Me.dgvSmartBills.GridColor = System.Drawing.Color.Khaki
        Me.dgvSmartBills.Location = New System.Drawing.Point(4, 249)
        Me.dgvSmartBills.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvSmartBills.Name = "dgvSmartBills"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSmartBills.RowHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.dgvSmartBills.Size = New System.Drawing.Size(1180, 303)
        Me.dgvSmartBills.TabIndex = 39
        Me.dgvSmartBills.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.ControlCaption = Nothing
        Me.colInclude.DataPropertyName = "AutoInclude"
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.SourceColumn = Nothing
        Me.colInclude.Width = 60
        '
        'colExtraBillNo
        '
        Me.colExtraBillNo.DataPropertyName = "ExtraBillNo"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colExtraBillNo.DefaultCellStyle = DataGridViewCellStyle15
        Me.colExtraBillNo.HeaderText = "Extra Bill No"
        Me.colExtraBillNo.Name = "colExtraBillNo"
        Me.colExtraBillNo.ReadOnly = True
        Me.colExtraBillNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colItemCode
        '
        Me.colItemCode.DataPropertyName = "ItemCode"
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        '
        'colItemName
        '
        Me.colItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle16
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 250
        '
        'colItemCategory
        '
        Me.colItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategory.DefaultCellStyle = DataGridViewCellStyle17
        Me.colItemCategory.HeaderText = "ItemCategory"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        '
        'colQuantity
        '
        Me.colQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle18.NullValue = Nothing
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle18
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        '
        'colUnitPrice
        '
        Me.colUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle19.Format = "N2"
        DataGridViewCellStyle19.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle19
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle20.Format = "N2"
        DataGridViewCellStyle20.NullValue = Nothing
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle20
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        '
        'colCashAmount
        '
        Me.colCashAmount.DataPropertyName = "CashAmount"
        Me.colCashAmount.HeaderText = "Cash Amount"
        Me.colCashAmount.Name = "colCashAmount"
        Me.colCashAmount.ReadOnly = True
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        Me.colNotes.DefaultCellStyle = DataGridViewCellStyle21
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 200
        Me.colNotes.Name = "colNotes"
        Me.colNotes.ReadOnly = True
        '
        'colPayStatus
        '
        Me.colPayStatus.DataPropertyName = "PayStatus"
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        Me.colPayStatus.DefaultCellStyle = DataGridViewCellStyle22
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 80
        '
        'colEntryMode
        '
        Me.colEntryMode.DataPropertyName = "EntryMode"
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        Me.colEntryMode.DefaultCellStyle = DataGridViewCellStyle23
        Me.colEntryMode.HeaderText = "Entry Mode"
        Me.colEntryMode.Name = "colEntryMode"
        Me.colEntryMode.ReadOnly = True
        '
        'colItemCategoryID
        '
        Me.colItemCategoryID.DataPropertyName = "ItemCategoryID"
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        Me.colItemCategoryID.DefaultCellStyle = DataGridViewCellStyle24
        Me.colItemCategoryID.HeaderText = "ItemCategoryID"
        Me.colItemCategoryID.Name = "colItemCategoryID"
        Me.colItemCategoryID.ReadOnly = True
        Me.colItemCategoryID.Visible = False
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForItem)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForItem)
        Me.pnlBill.Location = New System.Drawing.Point(4, 200)
        Me.pnlBill.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(1171, 50)
        Me.pnlBill.TabIndex = 106
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(417, 7)
        Me.lblBillWords.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(183, 25)
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
        Me.stbBillForItem.Location = New System.Drawing.Point(171, 10)
        Me.stbBillForItem.Margin = New System.Windows.Forms.Padding(4)
        Me.stbBillForItem.MaxLength = 20
        Me.stbBillForItem.Name = "stbBillForItem"
        Me.stbBillForItem.RegularExpression = ""
        Me.stbBillForItem.Size = New System.Drawing.Size(226, 22)
        Me.stbBillForItem.TabIndex = 1
        Me.stbBillForItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(601, 7)
        Me.stbBillWords.Margin = New System.Windows.Forms.Padding(4)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(546, 36)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForItem
        '
        Me.lblBillForItem.Location = New System.Drawing.Point(9, 7)
        Me.lblBillForItem.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBillForItem.Name = "lblBillForItem"
        Me.lblBillForItem.Size = New System.Drawing.Size(165, 25)
        Me.lblBillForItem.TabIndex = 0
        Me.lblBillForItem.Text = "Bill for Admission"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(617, 28)
        Me.stbBillCustomerName.Margin = New System.Windows.Forms.Padding(4)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(185, 34)
        Me.stbBillCustomerName.TabIndex = 19
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(426, 39)
        Me.lblBillCustomerName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(183, 25)
        Me.lblBillCustomerName.TabIndex = 18
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbBillNo
        '
        Me.stbBillNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(616, 4)
        Me.stbBillNo.Margin = New System.Windows.Forms.Padding(4)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(185, 22)
        Me.stbBillNo.TabIndex = 17
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(433, 6)
        Me.lblBillNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(183, 25)
        Me.lblBillNo.TabIndex = 16
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
        Me.nbxCoPayValue.Location = New System.Drawing.Point(186, 115)
        Me.nbxCoPayValue.Margin = New System.Windows.Forms.Padding(4)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(226, 22)
        Me.nbxCoPayValue.TabIndex = 13
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(13, 116)
        Me.lblCoPayValue.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(165, 25)
        Me.lblCoPayValue.TabIndex = 12
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
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(186, 89)
        Me.nbxCoPayPercent.Margin = New System.Windows.Forms.Padding(4)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(226, 22)
        Me.nbxCoPayPercent.TabIndex = 11
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(13, 91)
        Me.lblCoPayPercent.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(165, 25)
        Me.lblCoPayPercent.TabIndex = 10
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BackColor = System.Drawing.SystemColors.Info
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(186, 64)
        Me.stbCoPayType.Margin = New System.Windows.Forms.Padding(4)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(226, 22)
        Me.stbCoPayType.TabIndex = 9
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(13, 66)
        Me.lblCoPayType.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(165, 25)
        Me.lblCoPayType.TabIndex = 8
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'stbAdmissionDateTime
        '
        Me.stbAdmissionDateTime.BackColor = System.Drawing.SystemColors.Info
        Me.stbAdmissionDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionDateTime.CapitalizeFirstLetter = False
        Me.stbAdmissionDateTime.Enabled = False
        Me.stbAdmissionDateTime.EntryErrorMSG = ""
        Me.stbAdmissionDateTime.Location = New System.Drawing.Point(945, 130)
        Me.stbAdmissionDateTime.Margin = New System.Windows.Forms.Padding(4)
        Me.stbAdmissionDateTime.MaxLength = 60
        Me.stbAdmissionDateTime.Name = "stbAdmissionDateTime"
        Me.stbAdmissionDateTime.ReadOnly = True
        Me.stbAdmissionDateTime.RegularExpression = ""
        Me.stbAdmissionDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionDateTime.Size = New System.Drawing.Size(217, 22)
        Me.stbAdmissionDateTime.TabIndex = 38
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(945, 7)
        Me.stbPatientNo.Margin = New System.Windows.Forms.Padding(4)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(217, 22)
        Me.stbPatientNo.TabIndex = 27
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(809, 7)
        Me.lblPatientsNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(128, 25)
        Me.lblPatientsNo.TabIndex = 26
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(810, 133)
        Me.lblAdmissionDateTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdmissionDateTime.Name = "lblAdmissionDateTime"
        Me.lblAdmissionDateTime.Size = New System.Drawing.Size(128, 25)
        Me.lblAdmissionDateTime.TabIndex = 37
        Me.lblAdmissionDateTime.Text = "Admission Date"
        '
        'stbBillMode
        '
        Me.stbBillMode.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(187, 141)
        Me.stbBillMode.Margin = New System.Windows.Forms.Padding(4)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(225, 22)
        Me.stbBillMode.TabIndex = 15
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(13, 141)
        Me.lblBillMode.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(121, 22)
        Me.lblBillMode.TabIndex = 14
        Me.lblBillMode.Text = "Bill Mode"
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(946, 107)
        Me.stbJoinDate.Margin = New System.Windows.Forms.Padding(4)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.ReadOnly = True
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(217, 22)
        Me.stbJoinDate.TabIndex = 36
        '
        'stbGender
        '
        Me.stbGender.BackColor = System.Drawing.SystemColors.Info
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(945, 84)
        Me.stbGender.Margin = New System.Windows.Forms.Padding(4)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.ReadOnly = True
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(217, 22)
        Me.stbGender.TabIndex = 34
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(811, 109)
        Me.lblJoinDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(128, 22)
        Me.lblJoinDate.TabIndex = 35
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(810, 87)
        Me.lblGenderID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(128, 22)
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
        Me.stbFullName.Location = New System.Drawing.Point(945, 33)
        Me.stbFullName.Margin = New System.Windows.Forms.Padding(4)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.ReadOnly = True
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(217, 22)
        Me.stbFullName.TabIndex = 29
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(810, 35)
        Me.lblFullName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(127, 25)
        Me.lblFullName.TabIndex = 28
        Me.lblFullName.Text = "Full Name"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(186, 38)
        Me.stbVisitNo.Margin = New System.Windows.Forms.Padding(4)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(226, 22)
        Me.stbVisitNo.TabIndex = 6
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(13, 38)
        Me.lblVisitNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(121, 25)
        Me.lblVisitNo.TabIndex = 4
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbAdmissionNo
        '
        Me.stbAdmissionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionNo.CapitalizeFirstLetter = False
        Me.stbAdmissionNo.EntryErrorMSG = ""
        Me.stbAdmissionNo.Location = New System.Drawing.Point(186, 7)
        Me.stbAdmissionNo.Margin = New System.Windows.Forms.Padding(4)
        Me.stbAdmissionNo.MaxLength = 20
        Me.stbAdmissionNo.Name = "stbAdmissionNo"
        Me.stbAdmissionNo.RegularExpression = ""
        Me.stbAdmissionNo.Size = New System.Drawing.Size(160, 22)
        Me.stbAdmissionNo.TabIndex = 2
        '
        'btnFindAdmissionNo
        '
        Me.btnFindAdmissionNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindAdmissionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindAdmissionNo.Image = CType(resources.GetObject("btnFindAdmissionNo.Image"), System.Drawing.Image)
        Me.btnFindAdmissionNo.Location = New System.Drawing.Point(142, 8)
        Me.btnFindAdmissionNo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFindAdmissionNo.Name = "btnFindAdmissionNo"
        Me.btnFindAdmissionNo.Size = New System.Drawing.Size(36, 26)
        Me.btnFindAdmissionNo.TabIndex = 1
        '
        'lblAdmissionNo
        '
        Me.lblAdmissionNo.Location = New System.Drawing.Point(13, 8)
        Me.lblAdmissionNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdmissionNo.Name = "lblAdmissionNo"
        Me.lblAdmissionNo.Size = New System.Drawing.Size(112, 25)
        Me.lblAdmissionNo.TabIndex = 0
        Me.lblAdmissionNo.Text = "Admission No"
        '
        'btnLoadAdmissions
        '
        Me.btnLoadAdmissions.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadAdmissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadAdmissions.Location = New System.Drawing.Point(353, 6)
        Me.btnLoadAdmissions.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLoadAdmissions.Name = "btnLoadAdmissions"
        Me.btnLoadAdmissions.Size = New System.Drawing.Size(59, 30)
        Me.btnLoadAdmissions.TabIndex = 3
        Me.btnLoadAdmissions.Tag = ""
        Me.btnLoadAdmissions.Text = "&Load"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(142, 38)
        Me.btnFindVisitNo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(36, 26)
        Me.btnFindVisitNo.TabIndex = 5
        '
        'lblAgeString
        '
        Me.lblAgeString.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgeString.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAgeString.Location = New System.Drawing.Point(1029, 59)
        Me.lblAgeString.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAgeString.Name = "lblAgeString"
        Me.lblAgeString.Size = New System.Drawing.Size(134, 23)
        Me.lblAgeString.TabIndex = 32
        '
        'stbAge
        '
        Me.stbAge.BackColor = System.Drawing.SystemColors.Info
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(945, 59)
        Me.stbAge.Margin = New System.Windows.Forms.Padding(4)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(75, 22)
        Me.stbAge.TabIndex = 31
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(815, 58)
        Me.lblAge.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(95, 25)
        Me.lblAge.TabIndex = 30
        Me.lblAge.Text = "Age"
        '
        'stbAdmissionStatus
        '
        Me.stbAdmissionStatus.BackColor = System.Drawing.SystemColors.Info
        Me.stbAdmissionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionStatus.CapitalizeFirstLetter = False
        Me.stbAdmissionStatus.Enabled = False
        Me.stbAdmissionStatus.EntryErrorMSG = ""
        Me.stbAdmissionStatus.Location = New System.Drawing.Point(616, 111)
        Me.stbAdmissionStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.stbAdmissionStatus.MaxLength = 60
        Me.stbAdmissionStatus.Name = "stbAdmissionStatus"
        Me.stbAdmissionStatus.RegularExpression = ""
        Me.stbAdmissionStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionStatus.Size = New System.Drawing.Size(165, 22)
        Me.stbAdmissionStatus.TabIndex = 23
        '
        'lblAdmissionStatus
        '
        Me.lblAdmissionStatus.Location = New System.Drawing.Point(426, 109)
        Me.lblAdmissionStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblAdmissionStatus.Name = "lblAdmissionStatus"
        Me.lblAdmissionStatus.Size = New System.Drawing.Size(128, 25)
        Me.lblAdmissionStatus.TabIndex = 22
        Me.lblAdmissionStatus.Text = "Admission Status"
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(4, 560)
        Me.ebnSaveUpdate.Margin = New System.Windows.Forms.Padding(4)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(103, 28)
        Me.ebnSaveUpdate.TabIndex = 107
        Me.ebnSaveUpdate.Tag = "Discharges"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbProvisionalLimit
        '
        Me.stbProvisionalLimit.BackColor = System.Drawing.SystemColors.Info
        Me.stbProvisionalLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbProvisionalLimit.CapitalizeFirstLetter = False
        Me.stbProvisionalLimit.Enabled = False
        Me.stbProvisionalLimit.EntryErrorMSG = ""
        Me.stbProvisionalLimit.Location = New System.Drawing.Point(186, 170)
        Me.stbProvisionalLimit.Margin = New System.Windows.Forms.Padding(4)
        Me.stbProvisionalLimit.MaxLength = 60
        Me.stbProvisionalLimit.Name = "stbProvisionalLimit"
        Me.stbProvisionalLimit.RegularExpression = ""
        Me.stbProvisionalLimit.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbProvisionalLimit.Size = New System.Drawing.Size(225, 22)
        Me.stbProvisionalLimit.TabIndex = 109
        '
        'lblProvisionalLimit
        '
        Me.lblProvisionalLimit.Location = New System.Drawing.Point(12, 170)
        Me.lblProvisionalLimit.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProvisionalLimit.Name = "lblProvisionalLimit"
        Me.lblProvisionalLimit.Size = New System.Drawing.Size(166, 22)
        Me.lblProvisionalLimit.TabIndex = 108
        Me.lblProvisionalLimit.Text = "Provisional Limit"
        '
        'frmSmartBilling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1197, 603)
        Me.Controls.Add(Me.stbProvisionalLimit)
        Me.Controls.Add(Me.lblProvisionalLimit)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.stbAdmissionStatus)
        Me.Controls.Add(Me.lblAdmissionStatus)
        Me.Controls.Add(Me.lblAgeString)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.btnLoadAdmissions)
        Me.Controls.Add(Me.stbAdmissionNo)
        Me.Controls.Add(Me.btnFindAdmissionNo)
        Me.Controls.Add(Me.lblAdmissionNo)
        Me.Controls.Add(Me.dgvSmartBills)
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.nbxCashAccountBalance)
        Me.Controls.Add(Me.lblCashAccountBalance)
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
        Me.Controls.Add(Me.stbAdmissionDateTime)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.lblAdmissionDateTime)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmSmartBilling"
        Me.Tag = ""
        Me.Text = "Smart Billing"
        CType(Me.dgvSmartBills, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label
    Friend WithEvents nbxCashAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCashAccountBalance As System.Windows.Forms.Label
    Friend WithEvents dgvSmartBills As System.Windows.Forms.DataGridView
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
    Friend WithEvents stbAdmissionDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents lblAdmissionDateTime As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindAdmissionNo As System.Windows.Forms.Button
    Friend WithEvents lblAdmissionNo As System.Windows.Forms.Label
    Friend WithEvents btnLoadAdmissions As System.Windows.Forms.Button
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents lblAgeString As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionStatus As System.Windows.Forms.Label
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents stbProvisionalLimit As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblProvisionalLimit As System.Windows.Forms.Label
    Friend WithEvents colInclude As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents colExtraBillNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCashAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEntryMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn

End Class