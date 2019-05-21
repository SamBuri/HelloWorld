
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRefundApprovals : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRefundApprovals))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAttendingPersonel = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboReceiptNo = New System.Windows.Forms.ComboBox()
        Me.stbPayeeName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbRefudNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboApprovalStatusID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbRefundRequestNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundRequestNo = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblAttendingPersonel = New System.Windows.Forms.Label()
        Me.lblPendingRefundRequests = New System.Windows.Forms.Label()
        Me.btnLoadRefundRequests = New System.Windows.Forms.Button()
        Me.lblReceiptNo = New System.Windows.Forms.Label()
        Me.stbRefundAmountPaid = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundAmountPaid = New System.Windows.Forms.Label()
        Me.stbRefundPayDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundPayDate = New System.Windows.Forms.Label()
        Me.lblPayName = New System.Windows.Forms.Label()
        Me.lblRefundDate = New System.Windows.Forms.Label()
        Me.lblRefundReceiptNo = New System.Windows.Forms.Label()
        Me.stbRefundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblToRefundAmount = New System.Windows.Forms.Label()
        Me.stbAmountRefunded = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblRefundAmount = New System.Windows.Forms.Label()
        Me.nbxTotalRefundAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxRefundOutstandingBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblRefundOutstandingBalance = New System.Windows.Forms.Label()
        Me.nbxRefundAccountBalance = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblRefundAccountBalance = New System.Windows.Forms.Label()
        Me.stbRefundDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundNotes = New System.Windows.Forms.Label()
        Me.dgvPaymentRefunds = New System.Windows.Forms.DataGridView()
        Me.colRefItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefSoldQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefPaidAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.coReflItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefundReason = New SyncSoft.Common.Win.Controls.GridComboBoxColumn()
        Me.colRefQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefNewPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefDiscount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrevRefundedQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefSalesUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAcknowledgeable = New SyncSoft.Common.Win.Controls.GridCheckBoxColumn()
        Me.colPrevRefundedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefInvoiceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemStatusID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefItemCategoryID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblApprovalStatusID = New System.Windows.Forms.Label()
        CType(Me.dgvPaymentRefunds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(15, 438)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(838, 438)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "RefundApprovals"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(15, 465)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "RefundApprovals"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(218, 30)
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbNotes.Size = New System.Drawing.Size(203, 48)
        Me.stbNotes.TabIndex = 6
        '
        'stbAttendingPersonel
        '
        Me.stbAttendingPersonel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAttendingPersonel.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbAttendingPersonel, "AttendingPersonel")
        Me.stbAttendingPersonel.EntryErrorMSG = ""
        Me.stbAttendingPersonel.Location = New System.Drawing.Point(218, 82)
        Me.stbAttendingPersonel.Name = "stbAttendingPersonel"
        Me.stbAttendingPersonel.RegularExpression = ""
        Me.stbAttendingPersonel.Size = New System.Drawing.Size(203, 20)
        Me.stbAttendingPersonel.TabIndex = 8
        '
        'cboReceiptNo
        '
        Me.cboReceiptNo.BackColor = System.Drawing.SystemColors.Info
        Me.ebnSaveUpdate.SetDataMember(Me.cboReceiptNo, "ReceiptNo")
        Me.cboReceiptNo.Enabled = False
        Me.cboReceiptNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboReceiptNo.Location = New System.Drawing.Point(218, 106)
        Me.cboReceiptNo.Name = "cboReceiptNo"
        Me.cboReceiptNo.Size = New System.Drawing.Size(203, 21)
        Me.cboReceiptNo.TabIndex = 61
        '
        'stbPayeeName
        '
        Me.stbPayeeName.BackColor = System.Drawing.SystemColors.Info
        Me.stbPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPayeeName.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbPayeeName, "PayeeName")
        Me.stbPayeeName.EntryErrorMSG = ""
        Me.stbPayeeName.Location = New System.Drawing.Point(218, 131)
        Me.stbPayeeName.Name = "stbPayeeName"
        Me.stbPayeeName.ReadOnly = True
        Me.stbPayeeName.RegularExpression = ""
        Me.stbPayeeName.Size = New System.Drawing.Size(203, 20)
        Me.stbPayeeName.TabIndex = 71
        '
        'stbRefudNotes
        '
        Me.stbRefudNotes.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefudNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefudNotes.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbRefudNotes, "Notes")
        Me.stbRefudNotes.EntryErrorMSG = ""
        Me.stbRefudNotes.Location = New System.Drawing.Point(697, 132)
        Me.stbRefudNotes.Multiline = True
        Me.stbRefudNotes.Name = "stbRefudNotes"
        Me.stbRefudNotes.RegularExpression = ""
        Me.stbRefudNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbRefudNotes.Size = New System.Drawing.Size(200, 88)
        Me.stbRefudNotes.TabIndex = 85
        '
        'cboApprovalStatusID
        '
        Me.cboApprovalStatusID.BackColor = System.Drawing.SystemColors.Info
        Me.ebnSaveUpdate.SetDataMember(Me.cboApprovalStatusID, "ApprovalStatus")
        Me.cboApprovalStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboApprovalStatusID.Location = New System.Drawing.Point(218, 200)
        Me.cboApprovalStatusID.Name = "cboApprovalStatusID"
        Me.cboApprovalStatusID.Size = New System.Drawing.Size(203, 21)
        Me.cboApprovalStatusID.TabIndex = 101
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(838, 465)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbRefundRequestNo
        '
        Me.stbRefundRequestNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundRequestNo.CapitalizeFirstLetter = False
        Me.stbRefundRequestNo.EntryErrorMSG = ""
        Me.stbRefundRequestNo.Location = New System.Drawing.Point(218, 6)
        Me.stbRefundRequestNo.Name = "stbRefundRequestNo"
        Me.stbRefundRequestNo.RegularExpression = ""
        Me.stbRefundRequestNo.Size = New System.Drawing.Size(148, 20)
        Me.stbRefundRequestNo.TabIndex = 4
        '
        'lblRefundRequestNo
        '
        Me.lblRefundRequestNo.Location = New System.Drawing.Point(12, 8)
        Me.lblRefundRequestNo.Name = "lblRefundRequestNo"
        Me.lblRefundRequestNo.Size = New System.Drawing.Size(198, 20)
        Me.lblRefundRequestNo.TabIndex = 5
        Me.lblRefundRequestNo.Text = "Refund Request No"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(12, 35)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(198, 20)
        Me.lblNotes.TabIndex = 7
        Me.lblNotes.Text = "Approval Notes"
        '
        'lblAttendingPersonel
        '
        Me.lblAttendingPersonel.Location = New System.Drawing.Point(12, 89)
        Me.lblAttendingPersonel.Name = "lblAttendingPersonel"
        Me.lblAttendingPersonel.Size = New System.Drawing.Size(198, 20)
        Me.lblAttendingPersonel.TabIndex = 9
        Me.lblAttendingPersonel.Text = "Attending Person"
        '
        'lblPendingRefundRequests
        '
        Me.lblPendingRefundRequests.ForeColor = System.Drawing.Color.Red
        Me.lblPendingRefundRequests.Location = New System.Drawing.Point(491, 203)
        Me.lblPendingRefundRequests.Name = "lblPendingRefundRequests"
        Me.lblPendingRefundRequests.Size = New System.Drawing.Size(166, 18)
        Me.lblPendingRefundRequests.TabIndex = 60
        Me.lblPendingRefundRequests.Text = "Pending Requests"
        '
        'btnLoadRefundRequests
        '
        Me.btnLoadRefundRequests.AccessibleDescription = ""
        Me.btnLoadRefundRequests.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadRefundRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadRefundRequests.Location = New System.Drawing.Point(372, 4)
        Me.btnLoadRefundRequests.Name = "btnLoadRefundRequests"
        Me.btnLoadRefundRequests.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadRefundRequests.TabIndex = 59
        Me.btnLoadRefundRequests.Tag = ""
        Me.btnLoadRefundRequests.Text = "&Load"
        '
        'lblReceiptNo
        '
        Me.lblReceiptNo.Location = New System.Drawing.Point(12, 117)
        Me.lblReceiptNo.Name = "lblReceiptNo"
        Me.lblReceiptNo.Size = New System.Drawing.Size(198, 20)
        Me.lblReceiptNo.TabIndex = 62
        Me.lblReceiptNo.Text = "Receipt No"
        '
        'stbRefundAmountPaid
        '
        Me.stbRefundAmountPaid.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundAmountPaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundAmountPaid.CapitalizeFirstLetter = False
        Me.stbRefundAmountPaid.Enabled = False
        Me.stbRefundAmountPaid.EntryErrorMSG = ""
        Me.stbRefundAmountPaid.Location = New System.Drawing.Point(218, 178)
        Me.stbRefundAmountPaid.MaxLength = 20
        Me.stbRefundAmountPaid.Name = "stbRefundAmountPaid"
        Me.stbRefundAmountPaid.RegularExpression = ""
        Me.stbRefundAmountPaid.Size = New System.Drawing.Size(203, 20)
        Me.stbRefundAmountPaid.TabIndex = 70
        '
        'lblRefundAmountPaid
        '
        Me.lblRefundAmountPaid.Location = New System.Drawing.Point(12, 181)
        Me.lblRefundAmountPaid.Name = "lblRefundAmountPaid"
        Me.lblRefundAmountPaid.Size = New System.Drawing.Size(198, 20)
        Me.lblRefundAmountPaid.TabIndex = 69
        Me.lblRefundAmountPaid.Text = "Amount Paid"
        '
        'stbRefundPayDate
        '
        Me.stbRefundPayDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundPayDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundPayDate.CapitalizeFirstLetter = False
        Me.stbRefundPayDate.Enabled = False
        Me.stbRefundPayDate.EntryErrorMSG = ""
        Me.stbRefundPayDate.Location = New System.Drawing.Point(218, 156)
        Me.stbRefundPayDate.MaxLength = 60
        Me.stbRefundPayDate.Name = "stbRefundPayDate"
        Me.stbRefundPayDate.ReadOnly = True
        Me.stbRefundPayDate.RegularExpression = ""
        Me.stbRefundPayDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRefundPayDate.Size = New System.Drawing.Size(203, 20)
        Me.stbRefundPayDate.TabIndex = 68
        '
        'lblRefundPayDate
        '
        Me.lblRefundPayDate.Location = New System.Drawing.Point(12, 157)
        Me.lblRefundPayDate.Name = "lblRefundPayDate"
        Me.lblRefundPayDate.Size = New System.Drawing.Size(198, 20)
        Me.lblRefundPayDate.TabIndex = 67
        Me.lblRefundPayDate.Text = "Pay Date"
        '
        'lblPayName
        '
        Me.lblPayName.Location = New System.Drawing.Point(12, 137)
        Me.lblPayName.Name = "lblPayName"
        Me.lblPayName.Size = New System.Drawing.Size(198, 20)
        Me.lblPayName.TabIndex = 66
        Me.lblPayName.Text = "Payee Name"
        '
        'lblRefundDate
        '
        Me.lblRefundDate.Location = New System.Drawing.Point(491, 70)
        Me.lblRefundDate.Name = "lblRefundDate"
        Me.lblRefundDate.Size = New System.Drawing.Size(200, 20)
        Me.lblRefundDate.TabIndex = 72
        Me.lblRefundDate.Text = "Refund Date"
        '
        'lblRefundReceiptNo
        '
        Me.lblRefundReceiptNo.Location = New System.Drawing.Point(491, 46)
        Me.lblRefundReceiptNo.Name = "lblRefundReceiptNo"
        Me.lblRefundReceiptNo.Size = New System.Drawing.Size(200, 20)
        Me.lblRefundReceiptNo.TabIndex = 74
        Me.lblRefundReceiptNo.Text = "Refund  No"
        '
        'stbRefundNo
        '
        Me.stbRefundNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundNo.CapitalizeFirstLetter = False
        Me.stbRefundNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbRefundNo.EntryErrorMSG = ""
        Me.stbRefundNo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.stbRefundNo.Location = New System.Drawing.Point(697, 47)
        Me.stbRefundNo.MaxLength = 20
        Me.stbRefundNo.Name = "stbRefundNo"
        Me.stbRefundNo.ReadOnly = True
        Me.stbRefundNo.RegularExpression = ""
        Me.stbRefundNo.Size = New System.Drawing.Size(190, 20)
        Me.stbRefundNo.TabIndex = 75
        '
        'lblToRefundAmount
        '
        Me.lblToRefundAmount.Location = New System.Drawing.Point(491, 93)
        Me.lblToRefundAmount.Name = "lblToRefundAmount"
        Me.lblToRefundAmount.Size = New System.Drawing.Size(200, 20)
        Me.lblToRefundAmount.TabIndex = 79
        Me.lblToRefundAmount.Text = "Amount Refunded"
        '
        'stbAmountRefunded
        '
        Me.stbAmountRefunded.BackColor = System.Drawing.SystemColors.Info
        Me.stbAmountRefunded.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAmountRefunded.ControlCaption = "To-Refund Amount"
        Me.stbAmountRefunded.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.stbAmountRefunded.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.stbAmountRefunded.DecimalPlaces = -1
        Me.stbAmountRefunded.DenyNegativeEntryValue = True
        Me.stbAmountRefunded.Location = New System.Drawing.Point(697, 89)
        Me.stbAmountRefunded.MaxValue = 0.0R
        Me.stbAmountRefunded.MinValue = 0.0R
        Me.stbAmountRefunded.MustEnterNumeric = True
        Me.stbAmountRefunded.Name = "stbAmountRefunded"
        Me.stbAmountRefunded.ReadOnly = True
        Me.stbAmountRefunded.Size = New System.Drawing.Size(190, 20)
        Me.stbAmountRefunded.TabIndex = 77
        Me.stbAmountRefunded.Value = ""
        '
        'lblRefundAmount
        '
        Me.lblRefundAmount.Location = New System.Drawing.Point(491, 112)
        Me.lblRefundAmount.Name = "lblRefundAmount"
        Me.lblRefundAmount.Size = New System.Drawing.Size(200, 20)
        Me.lblRefundAmount.TabIndex = 76
        Me.lblRefundAmount.Text = "Total Refunded Amount"
        '
        'nbxTotalRefundAmount
        '
        Me.nbxTotalRefundAmount.BackColor = System.Drawing.SystemColors.Info
        Me.nbxTotalRefundAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxTotalRefundAmount.ControlCaption = "To-Refund Amount"
        Me.nbxTotalRefundAmount.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxTotalRefundAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxTotalRefundAmount.DecimalPlaces = -1
        Me.nbxTotalRefundAmount.DenyNegativeEntryValue = True
        Me.nbxTotalRefundAmount.Location = New System.Drawing.Point(697, 110)
        Me.nbxTotalRefundAmount.MaxValue = 0.0R
        Me.nbxTotalRefundAmount.MinValue = 0.0R
        Me.nbxTotalRefundAmount.MustEnterNumeric = True
        Me.nbxTotalRefundAmount.Name = "nbxTotalRefundAmount"
        Me.nbxTotalRefundAmount.ReadOnly = True
        Me.nbxTotalRefundAmount.Size = New System.Drawing.Size(190, 20)
        Me.nbxTotalRefundAmount.TabIndex = 78
        Me.nbxTotalRefundAmount.Value = ""
        '
        'nbxRefundOutstandingBalance
        '
        Me.nbxRefundOutstandingBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxRefundOutstandingBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxRefundOutstandingBalance.ControlCaption = "Outstanding Balance"
        Me.nbxRefundOutstandingBalance.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxRefundOutstandingBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxRefundOutstandingBalance.DecimalPlaces = -1
        Me.nbxRefundOutstandingBalance.Location = New System.Drawing.Point(697, 5)
        Me.nbxRefundOutstandingBalance.MaxValue = 0.0R
        Me.nbxRefundOutstandingBalance.MinValue = 0.0R
        Me.nbxRefundOutstandingBalance.MustEnterNumeric = True
        Me.nbxRefundOutstandingBalance.Name = "nbxRefundOutstandingBalance"
        Me.nbxRefundOutstandingBalance.ReadOnly = True
        Me.nbxRefundOutstandingBalance.Size = New System.Drawing.Size(190, 20)
        Me.nbxRefundOutstandingBalance.TabIndex = 81
        Me.nbxRefundOutstandingBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbxRefundOutstandingBalance.Value = ""
        '
        'lblRefundOutstandingBalance
        '
        Me.lblRefundOutstandingBalance.ForeColor = System.Drawing.Color.Red
        Me.lblRefundOutstandingBalance.Location = New System.Drawing.Point(491, 8)
        Me.lblRefundOutstandingBalance.Name = "lblRefundOutstandingBalance"
        Me.lblRefundOutstandingBalance.Size = New System.Drawing.Size(200, 16)
        Me.lblRefundOutstandingBalance.TabIndex = 80
        Me.lblRefundOutstandingBalance.Text = "Outstanding Balance"
        '
        'nbxRefundAccountBalance
        '
        Me.nbxRefundAccountBalance.BackColor = System.Drawing.SystemColors.Info
        Me.nbxRefundAccountBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxRefundAccountBalance.ControlCaption = "Balance"
        Me.nbxRefundAccountBalance.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxRefundAccountBalance.DecimalPlaces = -1
        Me.nbxRefundAccountBalance.Enabled = False
        Me.nbxRefundAccountBalance.Location = New System.Drawing.Point(697, 26)
        Me.nbxRefundAccountBalance.MaxValue = 0.0R
        Me.nbxRefundAccountBalance.MinValue = 0.0R
        Me.nbxRefundAccountBalance.MustEnterNumeric = True
        Me.nbxRefundAccountBalance.Name = "nbxRefundAccountBalance"
        Me.nbxRefundAccountBalance.Size = New System.Drawing.Size(190, 20)
        Me.nbxRefundAccountBalance.TabIndex = 83
        Me.nbxRefundAccountBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbxRefundAccountBalance.Value = ""
        '
        'lblRefundAccountBalance
        '
        Me.lblRefundAccountBalance.ForeColor = System.Drawing.Color.Red
        Me.lblRefundAccountBalance.Location = New System.Drawing.Point(491, 28)
        Me.lblRefundAccountBalance.Name = "lblRefundAccountBalance"
        Me.lblRefundAccountBalance.Size = New System.Drawing.Size(200, 16)
        Me.lblRefundAccountBalance.TabIndex = 82
        Me.lblRefundAccountBalance.Text = "Account Balance"
        '
        'stbRefundDate
        '
        Me.stbRefundDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundDate.CapitalizeFirstLetter = False
        Me.stbRefundDate.Enabled = False
        Me.stbRefundDate.EntryErrorMSG = ""
        Me.stbRefundDate.Location = New System.Drawing.Point(697, 68)
        Me.stbRefundDate.MaxLength = 60
        Me.stbRefundDate.Name = "stbRefundDate"
        Me.stbRefundDate.ReadOnly = True
        Me.stbRefundDate.RegularExpression = ""
        Me.stbRefundDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRefundDate.Size = New System.Drawing.Size(190, 20)
        Me.stbRefundDate.TabIndex = 84
        '
        'lblRefundNotes
        '
        Me.lblRefundNotes.Location = New System.Drawing.Point(491, 136)
        Me.lblRefundNotes.Name = "lblRefundNotes"
        Me.lblRefundNotes.Size = New System.Drawing.Size(200, 20)
        Me.lblRefundNotes.TabIndex = 86
        Me.lblRefundNotes.Text = "Notes"
        '
        'dgvPaymentRefunds
        '
        Me.dgvPaymentRefunds.AllowUserToAddRows = False
        Me.dgvPaymentRefunds.AllowUserToOrderColumns = True
        Me.dgvPaymentRefunds.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPaymentRefunds.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentRefunds.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPaymentRefunds.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colRefItemCode, Me.colVisitNo, Me.colRefItemName, Me.colRefSoldQuantity, Me.colRefPaidAmount, Me.coReflItemCategory, Me.colRefundReason, Me.colRefQuantity, Me.colRefNewPrice, Me.colRefAmount, Me.colRefDiscount, Me.colPrevRefundedQuantity, Me.colRefSalesUnitPrice, Me.colAcknowledgeable, Me.colPrevRefundedAmount, Me.colRefInvoiceNo, Me.colItemStatusID, Me.colItemStatus, Me.colRefItemCategoryID})
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPaymentRefunds.DefaultCellStyle = DataGridViewCellStyle19
        Me.dgvPaymentRefunds.EnableHeadersVisualStyles = False
        Me.dgvPaymentRefunds.GridColor = System.Drawing.Color.Khaki
        Me.dgvPaymentRefunds.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.dgvPaymentRefunds.Location = New System.Drawing.Point(11, 230)
        Me.dgvPaymentRefunds.Name = "dgvPaymentRefunds"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentRefunds.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dgvPaymentRefunds.Size = New System.Drawing.Size(886, 202)
        Me.dgvPaymentRefunds.TabIndex = 100
        Me.dgvPaymentRefunds.Text = "DataGridView1"
        '
        'colRefItemCode
        '
        Me.colRefItemCode.DataPropertyName = "ItemCode"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colRefItemCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colRefItemCode.HeaderText = "Item Code"
        Me.colRefItemCode.Name = "colRefItemCode"
        Me.colRefItemCode.ReadOnly = True
        Me.colRefItemCode.Visible = False
        Me.colRefItemCode.Width = 80
        '
        'colVisitNo
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colVisitNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        '
        'colRefItemName
        '
        Me.colRefItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colRefItemName.DefaultCellStyle = DataGridViewCellStyle4
        Me.colRefItemName.HeaderText = "Item Name"
        Me.colRefItemName.Name = "colRefItemName"
        '
        'colRefSoldQuantity
        '
        Me.colRefSoldQuantity.DataPropertyName = "SoldQuantity"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.NullValue = Nothing
        Me.colRefSoldQuantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.colRefSoldQuantity.HeaderText = "Sold Qty"
        Me.colRefSoldQuantity.Name = "colRefSoldQuantity"
        Me.colRefSoldQuantity.ReadOnly = True
        Me.colRefSoldQuantity.Width = 80
        '
        'colRefPaidAmount
        '
        Me.colRefPaidAmount.DataPropertyName = "AmountPaid"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colRefPaidAmount.DefaultCellStyle = DataGridViewCellStyle6
        Me.colRefPaidAmount.HeaderText = "Paid Amount"
        Me.colRefPaidAmount.Name = "colRefPaidAmount"
        Me.colRefPaidAmount.ReadOnly = True
        Me.colRefPaidAmount.Width = 80
        '
        'coReflItemCategory
        '
        Me.coReflItemCategory.DataPropertyName = "ItemCategory"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.coReflItemCategory.DefaultCellStyle = DataGridViewCellStyle7
        Me.coReflItemCategory.HeaderText = "Item Category"
        Me.coReflItemCategory.Name = "coReflItemCategory"
        Me.coReflItemCategory.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colRefundReason
        '
        Me.colRefundReason.ControlCaption = Nothing
        Me.colRefundReason.DataPropertyName = "ReturnReasonID"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colRefundReason.DefaultCellStyle = DataGridViewCellStyle8
        Me.colRefundReason.DisplayStyleForCurrentCellOnly = True
        Me.colRefundReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colRefundReason.HeaderText = "Refund Reason"
        Me.colRefundReason.Name = "colRefundReason"
        Me.colRefundReason.ReadOnly = True
        Me.colRefundReason.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colRefundReason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colRefundReason.SourceColumn = Nothing
        Me.colRefundReason.Width = 120
        '
        'colRefQuantity
        '
        Me.colRefQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.colRefQuantity.DefaultCellStyle = DataGridViewCellStyle9
        Me.colRefQuantity.HeaderText = "Return Qty"
        Me.colRefQuantity.Name = "colRefQuantity"
        Me.colRefQuantity.ReadOnly = True
        Me.colRefQuantity.Width = 90
        '
        'colRefNewPrice
        '
        Me.colRefNewPrice.DataPropertyName = "NewPrice"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colRefNewPrice.DefaultCellStyle = DataGridViewCellStyle10
        Me.colRefNewPrice.HeaderText = "New Price"
        Me.colRefNewPrice.Name = "colRefNewPrice"
        Me.colRefNewPrice.ReadOnly = True
        '
        'colRefAmount
        '
        Me.colRefAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colRefAmount.DefaultCellStyle = DataGridViewCellStyle11
        Me.colRefAmount.HeaderText = "Refund Amount"
        Me.colRefAmount.Name = "colRefAmount"
        Me.colRefAmount.ReadOnly = True
        Me.colRefAmount.Width = 90
        '
        'colRefDiscount
        '
        Me.colRefDiscount.DataPropertyName = "Discount"
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        Me.colRefDiscount.DefaultCellStyle = DataGridViewCellStyle12
        Me.colRefDiscount.HeaderText = "Discount"
        Me.colRefDiscount.Name = "colRefDiscount"
        Me.colRefDiscount.ReadOnly = True
        Me.colRefDiscount.Visible = False
        Me.colRefDiscount.Width = 80
        '
        'colPrevRefundedQuantity
        '
        Me.colPrevRefundedQuantity.DataPropertyName = "RefundedQuantity"
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colPrevRefundedQuantity.DefaultCellStyle = DataGridViewCellStyle13
        Me.colPrevRefundedQuantity.FillWeight = 120.0!
        Me.colPrevRefundedQuantity.HeaderText = "Prev Refund Qty"
        Me.colPrevRefundedQuantity.Name = "colPrevRefundedQuantity"
        Me.colPrevRefundedQuantity.ReadOnly = True
        '
        'colRefSalesUnitPrice
        '
        Me.colRefSalesUnitPrice.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle14.NullValue = Nothing
        Me.colRefSalesUnitPrice.DefaultCellStyle = DataGridViewCellStyle14
        Me.colRefSalesUnitPrice.HeaderText = "Unit Price"
        Me.colRefSalesUnitPrice.Name = "colRefSalesUnitPrice"
        Me.colRefSalesUnitPrice.ReadOnly = True
        Me.colRefSalesUnitPrice.Width = 80
        '
        'colAcknowledgeable
        '
        Me.colAcknowledgeable.ControlCaption = Nothing
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle15.NullValue = False
        Me.colAcknowledgeable.DefaultCellStyle = DataGridViewCellStyle15
        Me.colAcknowledgeable.HeaderText = "Acknowledgeable"
        Me.colAcknowledgeable.Name = "colAcknowledgeable"
        Me.colAcknowledgeable.ReadOnly = True
        Me.colAcknowledgeable.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colAcknowledgeable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colAcknowledgeable.SourceColumn = Nothing
        Me.colAcknowledgeable.Width = 60
        '
        'colPrevRefundedAmount
        '
        Me.colPrevRefundedAmount.DataPropertyName = "RefundedAmount"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colPrevRefundedAmount.DefaultCellStyle = DataGridViewCellStyle16
        Me.colPrevRefundedAmount.FillWeight = 120.0!
        Me.colPrevRefundedAmount.HeaderText = "Prev Refund Amt"
        Me.colPrevRefundedAmount.Name = "colPrevRefundedAmount"
        Me.colPrevRefundedAmount.ReadOnly = True
        '
        'colRefInvoiceNo
        '
        Me.colRefInvoiceNo.DataPropertyName = "InvoiceNo"
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        Me.colRefInvoiceNo.DefaultCellStyle = DataGridViewCellStyle17
        Me.colRefInvoiceNo.HeaderText = "Invoice No"
        Me.colRefInvoiceNo.Name = "colRefInvoiceNo"
        Me.colRefInvoiceNo.ReadOnly = True
        '
        'colItemStatusID
        '
        Me.colItemStatusID.HeaderText = "Item Status ID"
        Me.colItemStatusID.Name = "colItemStatusID"
        Me.colItemStatusID.ReadOnly = True
        Me.colItemStatusID.Visible = False
        '
        'colItemStatus
        '
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        Me.colItemStatus.DefaultCellStyle = DataGridViewCellStyle18
        Me.colItemStatus.HeaderText = "Item Status"
        Me.colItemStatus.Name = "colItemStatus"
        Me.colItemStatus.ReadOnly = True
        '
        'colRefItemCategoryID
        '
        Me.colRefItemCategoryID.DataPropertyName = "ItemCategoryID"
        Me.colRefItemCategoryID.HeaderText = "Item Category ID"
        Me.colRefItemCategoryID.Name = "colRefItemCategoryID"
        Me.colRefItemCategoryID.ReadOnly = True
        Me.colRefItemCategoryID.Visible = False
        '
        'lblApprovalStatusID
        '
        Me.lblApprovalStatusID.Location = New System.Drawing.Point(12, 202)
        Me.lblApprovalStatusID.Name = "lblApprovalStatusID"
        Me.lblApprovalStatusID.Size = New System.Drawing.Size(198, 20)
        Me.lblApprovalStatusID.TabIndex = 102
        Me.lblApprovalStatusID.Text = "Approval Status"
        '
        'frmRefundApprovals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(918, 494)
        Me.Controls.Add(Me.lblApprovalStatusID)
        Me.Controls.Add(Me.cboApprovalStatusID)
        Me.Controls.Add(Me.dgvPaymentRefunds)
        Me.Controls.Add(Me.stbRefudNotes)
        Me.Controls.Add(Me.lblRefundNotes)
        Me.Controls.Add(Me.stbRefundDate)
        Me.Controls.Add(Me.nbxRefundOutstandingBalance)
        Me.Controls.Add(Me.lblRefundOutstandingBalance)
        Me.Controls.Add(Me.nbxRefundAccountBalance)
        Me.Controls.Add(Me.lblRefundAccountBalance)
        Me.Controls.Add(Me.lblToRefundAmount)
        Me.Controls.Add(Me.stbAmountRefunded)
        Me.Controls.Add(Me.lblRefundAmount)
        Me.Controls.Add(Me.nbxTotalRefundAmount)
        Me.Controls.Add(Me.lblRefundReceiptNo)
        Me.Controls.Add(Me.stbRefundNo)
        Me.Controls.Add(Me.lblRefundDate)
        Me.Controls.Add(Me.stbPayeeName)
        Me.Controls.Add(Me.stbRefundAmountPaid)
        Me.Controls.Add(Me.lblRefundAmountPaid)
        Me.Controls.Add(Me.stbRefundPayDate)
        Me.Controls.Add(Me.lblRefundPayDate)
        Me.Controls.Add(Me.lblPayName)
        Me.Controls.Add(Me.cboReceiptNo)
        Me.Controls.Add(Me.lblReceiptNo)
        Me.Controls.Add(Me.lblPendingRefundRequests)
        Me.Controls.Add(Me.btnLoadRefundRequests)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbRefundRequestNo)
        Me.Controls.Add(Me.lblRefundRequestNo)
        Me.Controls.Add(Me.stbNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.stbAttendingPersonel)
        Me.Controls.Add(Me.lblAttendingPersonel)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.Name = "frmRefundApprovals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Refund Approvals"
        CType(Me.dgvPaymentRefunds,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbRefundRequestNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundRequestNo As System.Windows.Forms.Label
    Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents stbAttendingPersonel As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAttendingPersonel As System.Windows.Forms.Label
    Friend WithEvents lblPendingRefundRequests As System.Windows.Forms.Label
    Friend WithEvents btnLoadRefundRequests As System.Windows.Forms.Button
    Friend WithEvents cboReceiptNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblReceiptNo As System.Windows.Forms.Label
    Friend WithEvents stbPayeeName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbRefundAmountPaid As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundAmountPaid As System.Windows.Forms.Label
    Friend WithEvents stbRefundPayDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundPayDate As System.Windows.Forms.Label
    Friend WithEvents lblPayName As System.Windows.Forms.Label
    Friend WithEvents lblRefundDate As System.Windows.Forms.Label
    Friend WithEvents lblRefundReceiptNo As System.Windows.Forms.Label
    Friend WithEvents stbRefundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblToRefundAmount As System.Windows.Forms.Label
    Friend WithEvents stbAmountRefunded As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRefundAmount As System.Windows.Forms.Label
    Friend WithEvents nbxTotalRefundAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxRefundOutstandingBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRefundOutstandingBalance As System.Windows.Forms.Label
    Friend WithEvents nbxRefundAccountBalance As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblRefundAccountBalance As System.Windows.Forms.Label
    Friend WithEvents stbRefundDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbRefudNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundNotes As System.Windows.Forms.Label
    Friend WithEvents dgvPaymentRefunds As System.Windows.Forms.DataGridView
    Friend WithEvents colRefItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefSoldQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefPaidAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coReflItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefundReason As SyncSoft.Common.Win.Controls.GridComboBoxColumn
    Friend WithEvents colRefQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefNewPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefDiscount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrevRefundedQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefSalesUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAcknowledgeable As SyncSoft.Common.Win.Controls.GridCheckBoxColumn
    Friend WithEvents colPrevRefundedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefInvoiceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemStatusID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefItemCategoryID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboApprovalStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblApprovalStatusID As System.Windows.Forms.Label

End Class