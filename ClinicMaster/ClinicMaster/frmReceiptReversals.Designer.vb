
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReceiptReversals : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReceiptReversals))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblReceiptNo = New System.Windows.Forms.Label()
        Me.stbRefundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundNo = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.stbReceiptNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dgvPaymentRefunds = New System.Windows.Forms.DataGridView()
        Me.stbRefundPayDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundPayDate = New System.Windows.Forms.Label()
        Me.stbPayeeName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPayeeName = New System.Windows.Forms.Label()
        Me.ColVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colItemCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnItemCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReturnItemName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRefundReason = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSoldQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaidAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvPaymentRefunds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(12, 349)
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
        Me.fbnDelete.Location = New System.Drawing.Point(787, 348)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "ReceiptReversals"
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(12, 376)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "ReceiptReversals"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(126, 25)
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbNotes.Size = New System.Drawing.Size(211, 43)
        Me.stbNotes.TabIndex = 8
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(787, 375)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblReceiptNo
        '
        Me.lblReceiptNo.Location = New System.Drawing.Point(376, 6)
        Me.lblReceiptNo.Name = "lblReceiptNo"
        Me.lblReceiptNo.Size = New System.Drawing.Size(122, 20)
        Me.lblReceiptNo.TabIndex = 5
        Me.lblReceiptNo.Text = "Receipt No"
        '
        'stbRefundNo
        '
        Me.stbRefundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundNo.CapitalizeFirstLetter = False
        Me.stbRefundNo.EntryErrorMSG = ""
        Me.stbRefundNo.Location = New System.Drawing.Point(126, 4)
        Me.stbRefundNo.Name = "stbRefundNo"
        Me.stbRefundNo.RegularExpression = ""
        Me.stbRefundNo.Size = New System.Drawing.Size(211, 20)
        Me.stbRefundNo.TabIndex = 6
        '
        'lblRefundNo
        '
        Me.lblRefundNo.Location = New System.Drawing.Point(8, 4)
        Me.lblRefundNo.Name = "lblRefundNo"
        Me.lblRefundNo.Size = New System.Drawing.Size(100, 20)
        Me.lblRefundNo.TabIndex = 7
        Me.lblRefundNo.Text = "Refund No"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(8, 25)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(100, 20)
        Me.lblNotes.TabIndex = 9
        Me.lblNotes.Text = "Notes"
        '
        'stbReceiptNo
        '
        Me.stbReceiptNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbReceiptNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReceiptNo.CapitalizeFirstLetter = False
        Me.stbReceiptNo.Enabled = False
        Me.stbReceiptNo.EntryErrorMSG = ""
        Me.stbReceiptNo.Location = New System.Drawing.Point(501, 4)
        Me.stbReceiptNo.Name = "stbReceiptNo"
        Me.stbReceiptNo.RegularExpression = ""
        Me.stbReceiptNo.Size = New System.Drawing.Size(190, 20)
        Me.stbReceiptNo.TabIndex = 10
        '
        'dgvPaymentRefunds
        '
        Me.dgvPaymentRefunds.AllowUserToAddRows = False
        Me.dgvPaymentRefunds.AllowUserToDeleteRows = False
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
        Me.dgvPaymentRefunds.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColVisitNo, Me.ColReceiptNo, Me.colItemCategory, Me.colReturnItemCode, Me.colReturnItemName, Me.colRefundReason, Me.colSoldQuantity, Me.colPaidAmount})
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPaymentRefunds.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvPaymentRefunds.EnableHeadersVisualStyles = False
        Me.dgvPaymentRefunds.GridColor = System.Drawing.Color.Khaki
        Me.dgvPaymentRefunds.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.dgvPaymentRefunds.Location = New System.Drawing.Point(7, 74)
        Me.dgvPaymentRefunds.Name = "dgvPaymentRefunds"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPaymentRefunds.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.dgvPaymentRefunds.Size = New System.Drawing.Size(852, 258)
        Me.dgvPaymentRefunds.TabIndex = 90
        Me.dgvPaymentRefunds.Text = "DataGridView1"
        '
        'stbRefundPayDate
        '
        Me.stbRefundPayDate.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundPayDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundPayDate.CapitalizeFirstLetter = False
        Me.stbRefundPayDate.Enabled = False
        Me.stbRefundPayDate.EntryErrorMSG = ""
        Me.stbRefundPayDate.Location = New System.Drawing.Point(501, 46)
        Me.stbRefundPayDate.MaxLength = 60
        Me.stbRefundPayDate.Name = "stbRefundPayDate"
        Me.stbRefundPayDate.ReadOnly = True
        Me.stbRefundPayDate.RegularExpression = ""
        Me.stbRefundPayDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRefundPayDate.Size = New System.Drawing.Size(190, 20)
        Me.stbRefundPayDate.TabIndex = 94
        '
        'lblRefundPayDate
        '
        Me.lblRefundPayDate.Location = New System.Drawing.Point(376, 48)
        Me.lblRefundPayDate.Name = "lblRefundPayDate"
        Me.lblRefundPayDate.Size = New System.Drawing.Size(122, 20)
        Me.lblRefundPayDate.TabIndex = 93
        Me.lblRefundPayDate.Text = "Pay Date"
        '
        'stbPayeeName
        '
        Me.stbPayeeName.BackColor = System.Drawing.SystemColors.Info
        Me.stbPayeeName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPayeeName.CapitalizeFirstLetter = True
        Me.stbPayeeName.Enabled = False
        Me.stbPayeeName.EntryErrorMSG = ""
        Me.stbPayeeName.Location = New System.Drawing.Point(501, 25)
        Me.stbPayeeName.MaxLength = 60
        Me.stbPayeeName.Name = "stbPayeeName"
        Me.stbPayeeName.ReadOnly = True
        Me.stbPayeeName.RegularExpression = ""
        Me.stbPayeeName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPayeeName.Size = New System.Drawing.Size(190, 20)
        Me.stbPayeeName.TabIndex = 92
        '
        'lblPayeeName
        '
        Me.lblPayeeName.Location = New System.Drawing.Point(376, 28)
        Me.lblPayeeName.Name = "lblPayeeName"
        Me.lblPayeeName.Size = New System.Drawing.Size(122, 20)
        Me.lblPayeeName.TabIndex = 91
        Me.lblPayeeName.Text = "Payee Name"
        '
        'ColVisitNo
        '
        Me.ColVisitNo.DataPropertyName = "VisitNo"
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.ColVisitNo.DefaultCellStyle = DataGridViewCellStyle2
        Me.ColVisitNo.HeaderText = "Pay No"
        Me.ColVisitNo.Name = "ColVisitNo"
        Me.ColVisitNo.ReadOnly = True
        '
        'ColReceiptNo
        '
        Me.ColReceiptNo.DataPropertyName = "ReceiptNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.ColReceiptNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.ColReceiptNo.HeaderText = "Receipt No"
        Me.ColReceiptNo.Name = "ColReceiptNo"
        Me.ColReceiptNo.ReadOnly = True
        '
        'colItemCategory
        '
        Me.colItemCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colItemCategory.DataPropertyName = "ItemCategoryID"
        Me.colItemCategory.HeaderText = "Item Category"
        Me.colItemCategory.Name = "colItemCategory"
        Me.colItemCategory.ReadOnly = True
        Me.colItemCategory.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colItemCategory.Visible = False
        '
        'colReturnItemCode
        '
        Me.colReturnItemCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colReturnItemCode.DataPropertyName = "ItemCode"
        Me.colReturnItemCode.HeaderText = "Item Code"
        Me.colReturnItemCode.Name = "colReturnItemCode"
        Me.colReturnItemCode.ReadOnly = True
        Me.colReturnItemCode.Visible = False
        '
        'colReturnItemName
        '
        Me.colReturnItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colReturnItemName.DataPropertyName = "ItemName"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colReturnItemName.DefaultCellStyle = DataGridViewCellStyle4
        Me.colReturnItemName.HeaderText = "Item Name"
        Me.colReturnItemName.Name = "colReturnItemName"
        Me.colReturnItemName.ReadOnly = True
        '
        'colRefundReason
        '
        Me.colRefundReason.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colRefundReason.DataPropertyName = "ReturnReason"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colRefundReason.DefaultCellStyle = DataGridViewCellStyle5
        Me.colRefundReason.HeaderText = "Refund Reason"
        Me.colRefundReason.Name = "colRefundReason"
        Me.colRefundReason.ReadOnly = True
        Me.colRefundReason.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'colSoldQuantity
        '
        Me.colSoldQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSoldQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = Nothing
        Me.colSoldQuantity.DefaultCellStyle = DataGridViewCellStyle6
        Me.colSoldQuantity.HeaderText = "Sold Qty"
        Me.colSoldQuantity.Name = "colSoldQuantity"
        Me.colSoldQuantity.ReadOnly = True
        '
        'colPaidAmount
        '
        Me.colPaidAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPaidAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colPaidAmount.DefaultCellStyle = DataGridViewCellStyle7
        Me.colPaidAmount.HeaderText = "Paid Amount"
        Me.colPaidAmount.Name = "colPaidAmount"
        Me.colPaidAmount.ReadOnly = True
        '
        'frmReceiptReversals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(868, 406)
        Me.Controls.Add(Me.stbRefundPayDate)
        Me.Controls.Add(Me.lblRefundPayDate)
        Me.Controls.Add(Me.stbPayeeName)
        Me.Controls.Add(Me.lblPayeeName)
        Me.Controls.Add(Me.dgvPaymentRefunds)
        Me.Controls.Add(Me.stbReceiptNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblReceiptNo)
        Me.Controls.Add(Me.stbRefundNo)
        Me.Controls.Add(Me.lblRefundNo)
        Me.Controls.Add(Me.stbNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmReceiptReversals"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Receipt Reversals"
        CType(Me.dgvPaymentRefunds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

End Sub

Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblReceiptNo As System.Windows.Forms.Label
Friend WithEvents stbRefundNo As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblRefundNo As System.Windows.Forms.Label
Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents stbReceiptNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dgvPaymentRefunds As System.Windows.Forms.DataGridView
    Friend WithEvents stbRefundPayDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRefundPayDate As System.Windows.Forms.Label
    Friend WithEvents stbPayeeName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPayeeName As System.Windows.Forms.Label
    Friend WithEvents ColVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colItemCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnItemCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReturnItemName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRefundReason As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSoldQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaidAmount As System.Windows.Forms.DataGridViewTextBoxColumn

End Class