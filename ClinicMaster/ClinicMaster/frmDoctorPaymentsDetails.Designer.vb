
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDoctorPaymentsDetails : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDoctorPaymentsDetails))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.cboPayMode = New System.Windows.Forms.ComboBox()
        Me.nbxAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.stbAmountInWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDoctorSpecialtyID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbPayNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPayNo = New System.Windows.Forms.Label()
        Me.lblStaffNo = New System.Windows.Forms.Label()
        Me.dtpPayDate = New System.Windows.Forms.DateTimePicker()
        Me.lblPayDate = New System.Windows.Forms.Label()
        Me.lblPayMode = New System.Windows.Forms.Label()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblAmountInWords = New System.Windows.Forms.Label()
        Me.dgvPaymentDetails = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.lblDoctorSpecialtyID = New System.Windows.Forms.Label()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.btnLoadPendingBillsPayment = New System.Windows.Forms.Button()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        CType(Me.dgvPaymentDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 406)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(780, 405)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "DoctorPaymentsDetails"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 433)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "DoctorPaymentsDetails"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboStaffNo
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffNo")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.Location = New System.Drawing.Point(176, 55)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(170, 21)
        Me.cboStaffNo.TabIndex = 8
        '
        'cboPayMode
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboPayMode, "PayMode")
        Me.cboPayMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayMode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPayMode.Location = New System.Drawing.Point(176, 100)
        Me.cboPayMode.Name = "cboPayMode"
        Me.cboPayMode.Size = New System.Drawing.Size(170, 21)
        Me.cboPayMode.TabIndex = 16
        '
        'nbxAmount
        '
        Me.nbxAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAmount.ControlCaption = "Amount"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAmount, "Amount")
        Me.nbxAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAmount.DecimalPlaces = -1
        Me.nbxAmount.Location = New System.Drawing.Point(176, 124)
        Me.nbxAmount.MaxValue = 0.0R
        Me.nbxAmount.MinValue = 0.0R
        Me.nbxAmount.MustEnterNumeric = True
        Me.nbxAmount.Name = "nbxAmount"
        Me.nbxAmount.ReadOnly = True
        Me.nbxAmount.Size = New System.Drawing.Size(170, 20)
        Me.nbxAmount.TabIndex = 22
        Me.nbxAmount.Value = ""
        '
        'stbAmountInWords
        '
        Me.stbAmountInWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountInWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountInWords.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAmountInWords, "AmountInWords")
        Me.stbAmountInWords.EntryErrorMSG = ""
        Me.stbAmountInWords.Location = New System.Drawing.Point(502, 92)
        Me.stbAmountInWords.Multiline = True
        Me.stbAmountInWords.Name = "stbAmountInWords"
        Me.stbAmountInWords.ReadOnly = True
        Me.stbAmountInWords.RegularExpression = ""
        Me.stbAmountInWords.Size = New System.Drawing.Size(350, 52)
        Me.stbAmountInWords.TabIndex = 24
        '
        'cboDoctorSpecialtyID
        '
        Me.cboDoctorSpecialtyID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDoctorSpecialtyID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboDoctorSpecialtyID, "DoctorSpecialty,DoctorSpecialtyID")
        Me.cboDoctorSpecialtyID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDoctorSpecialtyID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDoctorSpecialtyID.FormattingEnabled = True
        Me.cboDoctorSpecialtyID.ItemHeight = 13
        Me.cboDoctorSpecialtyID.Location = New System.Drawing.Point(176, 32)
        Me.cboDoctorSpecialtyID.Name = "cboDoctorSpecialtyID"
        Me.cboDoctorSpecialtyID.Size = New System.Drawing.Size(170, 21)
        Me.cboDoctorSpecialtyID.TabIndex = 33
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(780, 432)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbPayNo
        '
        Me.stbPayNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPayNo.CapitalizeFirstLetter = False
        Me.stbPayNo.EntryErrorMSG = ""
        Me.stbPayNo.Location = New System.Drawing.Point(176, 10)
        Me.stbPayNo.Name = "stbPayNo"
        Me.stbPayNo.RegularExpression = ""
        Me.stbPayNo.Size = New System.Drawing.Size(170, 20)
        Me.stbPayNo.TabIndex = 4
        '
        'lblPayNo
        '
        Me.lblPayNo.Location = New System.Drawing.Point(12, 12)
        Me.lblPayNo.Name = "lblPayNo"
        Me.lblPayNo.Size = New System.Drawing.Size(200, 20)
        Me.lblPayNo.TabIndex = 5
        Me.lblPayNo.Text = "PayNo"
        '
        'lblStaffNo
        '
        Me.lblStaffNo.Location = New System.Drawing.Point(12, 55)
        Me.lblStaffNo.Name = "lblStaffNo"
        Me.lblStaffNo.Size = New System.Drawing.Size(151, 20)
        Me.lblStaffNo.TabIndex = 9
        Me.lblStaffNo.Text = "Doctor Full Name"
        '
        'dtpPayDate
        '
        Me.dtpPayDate.Checked = False
        Me.dtpPayDate.Location = New System.Drawing.Point(176, 78)
        Me.dtpPayDate.Name = "dtpPayDate"
        Me.dtpPayDate.ShowCheckBox = True
        Me.dtpPayDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpPayDate.TabIndex = 14
        '
        'lblPayDate
        '
        Me.lblPayDate.Location = New System.Drawing.Point(12, 78)
        Me.lblPayDate.Name = "lblPayDate"
        Me.lblPayDate.Size = New System.Drawing.Size(151, 20)
        Me.lblPayDate.TabIndex = 15
        Me.lblPayDate.Text = "Pay Date"
        '
        'lblPayMode
        '
        Me.lblPayMode.Location = New System.Drawing.Point(12, 103)
        Me.lblPayMode.Name = "lblPayMode"
        Me.lblPayMode.Size = New System.Drawing.Size(117, 20)
        Me.lblPayMode.TabIndex = 17
        Me.lblPayMode.Text = "Pay Mode"
        '
        'lblAmount
        '
        Me.lblAmount.Location = New System.Drawing.Point(12, 126)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(126, 20)
        Me.lblAmount.TabIndex = 23
        Me.lblAmount.Text = "Amount"
        '
        'lblAmountInWords
        '
        Me.lblAmountInWords.Location = New System.Drawing.Point(367, 94)
        Me.lblAmountInWords.Name = "lblAmountInWords"
        Me.lblAmountInWords.Size = New System.Drawing.Size(118, 20)
        Me.lblAmountInWords.TabIndex = 25
        Me.lblAmountInWords.Text = "Amount In Words"
        '
        'dgvPaymentDetails
        '
        Me.dgvPaymentDetails.AllowUserToAddRows = False
        Me.dgvPaymentDetails.AllowUserToDeleteRows = False
        Me.dgvPaymentDetails.AllowUserToOrderColumns = True
        Me.dgvPaymentDetails.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPaymentDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPaymentDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPaymentDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPaymentDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.ColVisitNo, Me.colItemCode, Me.colItemName, Me.colCategory, Me.colQuantity, Me.colUnitPrice, Me.colAmount, Me.colPayStatus})
        Me.dgvPaymentDetails.EnableHeadersVisualStyles = False
        Me.dgvPaymentDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvPaymentDetails.Location = New System.Drawing.Point(12, 164)
        Me.dgvPaymentDetails.Name = "dgvPaymentDetails"
        Me.dgvPaymentDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPaymentDetails.RowHeadersVisible = False
        Me.dgvPaymentDetails.Size = New System.Drawing.Size(840, 228)
        Me.dgvPaymentDetails.TabIndex = 26
        Me.dgvPaymentDetails.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'ColVisitNo
        '
        Me.ColVisitNo.HeaderText = "Visit No"
        Me.ColVisitNo.Name = "ColVisitNo"
        '
        'colItemCode
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colItemCode.HeaderText = "Item Code"
        Me.colItemCode.Name = "colItemCode"
        Me.colItemCode.ReadOnly = True
        Me.colItemCode.Width = 70
        '
        'colItemName
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colItemName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colItemName.HeaderText = "Item Name"
        Me.colItemName.Name = "colItemName"
        Me.colItemName.ReadOnly = True
        Me.colItemName.Width = 180
        '
        'colCategory
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colCategory.DefaultCellStyle = DataGridViewCellStyle4
        Me.colCategory.HeaderText = "Category"
        Me.colCategory.Name = "colCategory"
        Me.colCategory.ReadOnly = True
        '
        'colQuantity
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.Format = "N0"
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 60
        '
        'colUnitPrice
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle6
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 80
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
        '
        'colPayStatus
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colPayStatus.DefaultCellStyle = DataGridViewCellStyle8
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colPayStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colPayStatus.Width = 70
        '
        'lblDoctorSpecialtyID
        '
        Me.lblDoctorSpecialtyID.Location = New System.Drawing.Point(12, 35)
        Me.lblDoctorSpecialtyID.Name = "lblDoctorSpecialtyID"
        Me.lblDoctorSpecialtyID.Size = New System.Drawing.Size(151, 20)
        Me.lblDoctorSpecialtyID.TabIndex = 32
        Me.lblDoctorSpecialtyID.Text = "To-See Doctor Specialty"
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.btnLoadPendingBillsPayment)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Location = New System.Drawing.Point(367, 10)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(485, 80)
        Me.grpSetParameters.TabIndex = 34
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Visit Period"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.DateTimePicker1)
        Me.pnlPeriod.Controls.Add(Me.dtpEndDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(6, 16)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(359, 53)
        Me.pnlPeriod.TabIndex = 0
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(10, 6)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(70, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(10, 29)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(70, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLoadPendingBillsPayment
        '
        Me.btnLoadPendingBillsPayment.AccessibleDescription = ""
        Me.btnLoadPendingBillsPayment.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPendingBillsPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPendingBillsPayment.Location = New System.Drawing.Point(385, 42)
        Me.btnLoadPendingBillsPayment.Name = "btnLoadPendingBillsPayment"
        Me.btnLoadPendingBillsPayment.Size = New System.Drawing.Size(78, 24)
        Me.btnLoadPendingBillsPayment.TabIndex = 2
        Me.btnLoadPendingBillsPayment.Tag = ""
        Me.btnLoadPendingBillsPayment.Text = "Load &Bill"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(280, 17)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(180, 13)
        Me.lblRecordsNo.TabIndex = 1
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(86, 27)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDateTime.TabIndex = 4
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(86, 4)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.ShowCheckBox = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(189, 20)
        Me.DateTimePicker1.TabIndex = 5
        '
        'frmDoctorPaymentsDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(866, 463)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.cboDoctorSpecialtyID)
        Me.Controls.Add(Me.lblDoctorSpecialtyID)
        Me.Controls.Add(Me.dgvPaymentDetails)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbPayNo)
        Me.Controls.Add(Me.lblPayNo)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.lblStaffNo)
        Me.Controls.Add(Me.dtpPayDate)
        Me.Controls.Add(Me.lblPayDate)
        Me.Controls.Add(Me.cboPayMode)
        Me.Controls.Add(Me.lblPayMode)
        Me.Controls.Add(Me.nbxAmount)
        Me.Controls.Add(Me.lblAmount)
        Me.Controls.Add(Me.stbAmountInWords)
        Me.Controls.Add(Me.lblAmountInWords)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDoctorPaymentsDetails"
        Me.Text = "Doctor Payments"
        CType(Me.dgvPaymentDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbPayNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPayNo As System.Windows.Forms.Label
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaffNo As System.Windows.Forms.Label
    Friend WithEvents dtpPayDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPayDate As System.Windows.Forms.Label
    Friend WithEvents cboPayMode As System.Windows.Forms.ComboBox
    Friend WithEvents lblPayMode As System.Windows.Forms.Label
    Friend WithEvents nbxAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents stbAmountInWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAmountInWords As System.Windows.Forms.Label
    Friend WithEvents dgvPaymentDetails As System.Windows.Forms.DataGridView
    Friend WithEvents cboDoctorSpecialtyID As System.Windows.Forms.ComboBox
    Friend WithEvents lblDoctorSpecialtyID As System.Windows.Forms.Label
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents btnLoadPendingBillsPayment As System.Windows.Forms.Button
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker

End Class