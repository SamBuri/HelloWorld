
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendingRefundRequests : Inherits System.Windows.Forms.Form

'Form overrides dispose to clean up the component list.
<System.Diagnostics.DebuggerNonUserCode()> _
Protected Overrides Sub Dispose(ByVal disposing As Boolean)
	If disposing AndAlso components IsNot Nothing Then
		components.Dispose()
	End If
	MyBase.Dispose(disposing)
End Sub


    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control, isFinalApproval As Boolean)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
        Me.isFinalAppoval = isFinalApproval
    End Sub

'Required by the Windows Form Designer
Private components As System.ComponentModel.IContainer

'NOTE: The following procedure is required by the Windows Form Designer
'It can be modified using the Windows Form Designer.
'Do not modify it using the code editor.
<System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPendingRefundRequests))
        Me.dgvPendingRefunds = New System.Windows.Forms.DataGridView()
        Me.coRefundRequestNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReceiptNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRequestStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colApprovalStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayeeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblReturnedRecords = New System.Windows.Forms.Label()
        CType(Me.dgvPendingRefunds, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvPendingRefunds
        '
        Me.dgvPendingRefunds.AllowUserToAddRows = False
        Me.dgvPendingRefunds.AllowUserToDeleteRows = False
        Me.dgvPendingRefunds.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPendingRefunds.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPendingRefunds.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPendingRefunds.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPendingRefunds.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPendingRefunds.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingRefunds.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPendingRefunds.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.coRefundRequestNo, Me.colReceiptNo, Me.colRequestStatus, Me.colApprovalStatus, Me.colPayType, Me.colPayeeName})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPendingRefunds.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvPendingRefunds.EnableHeadersVisualStyles = False
        Me.dgvPendingRefunds.GridColor = System.Drawing.Color.Khaki
        Me.dgvPendingRefunds.Location = New System.Drawing.Point(12, 2)
        Me.dgvPendingRefunds.Name = "dgvPendingRefunds"
        Me.dgvPendingRefunds.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingRefunds.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvPendingRefunds.RowHeadersVisible = False
        Me.dgvPendingRefunds.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPendingRefunds.Size = New System.Drawing.Size(803, 257)
        Me.dgvPendingRefunds.TabIndex = 111
        Me.dgvPendingRefunds.Text = "DataGridView1"
        '
        'coRefundRequestNo
        '
        Me.coRefundRequestNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.coRefundRequestNo.DataPropertyName = "RefundRequestNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.coRefundRequestNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.coRefundRequestNo.FillWeight = 130.0!
        Me.coRefundRequestNo.HeaderText = "Refund Request No"
        Me.coRefundRequestNo.Name = "coRefundRequestNo"
        Me.coRefundRequestNo.ReadOnly = True
        Me.coRefundRequestNo.Width = 120
        '
        'colReceiptNo
        '
        Me.colReceiptNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colReceiptNo.DataPropertyName = "ReceiptNo"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colReceiptNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.colReceiptNo.HeaderText = "Receipt No"
        Me.colReceiptNo.Name = "colReceiptNo"
        Me.colReceiptNo.ReadOnly = True
        '
        'colRequestStatus
        '
        Me.colRequestStatus.DataPropertyName = "RequestStatus"
        Me.colRequestStatus.HeaderText = "Request Status"
        Me.colRequestStatus.Name = "colRequestStatus"
        Me.colRequestStatus.ReadOnly = True
        '
        'colApprovalStatus
        '
        Me.colApprovalStatus.DataPropertyName = "ApprovalStatus"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colApprovalStatus.DefaultCellStyle = DataGridViewCellStyle5
        Me.colApprovalStatus.HeaderText = "Approval Status"
        Me.colApprovalStatus.Name = "colApprovalStatus"
        Me.colApprovalStatus.ReadOnly = True
        Me.colApprovalStatus.Width = 150
        '
        'colPayType
        '
        Me.colPayType.DataPropertyName = "PayType"
        Me.colPayType.HeaderText = "Pay Type"
        Me.colPayType.Name = "colPayType"
        Me.colPayType.ReadOnly = True
        '
        'colPayeeName
        '
        Me.colPayeeName.DataPropertyName = "PayeeName"
        Me.colPayeeName.HeaderText = "Payee Name"
        Me.colPayeeName.Name = "colPayeeName"
        Me.colPayeeName.ReadOnly = True
        Me.colPayeeName.Width = 250
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(285, 272)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 115
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(743, 265)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 114
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblReturnedRecords
        '
        Me.lblReturnedRecords.Location = New System.Drawing.Point(-1, 283)
        Me.lblReturnedRecords.Name = "lblReturnedRecords"
        Me.lblReturnedRecords.Size = New System.Drawing.Size(199, 14)
        Me.lblReturnedRecords.TabIndex = 116
        Me.lblReturnedRecords.Text = "Returned Records"
        '
        'frmPendingRefundRequests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(819, 301)
        Me.Controls.Add(Me.lblReturnedRecords)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dgvPendingRefunds)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPendingRefundRequests"
        Me.Text = "Pending Refund Requests"
        CType(Me.dgvPendingRefunds, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvPendingRefunds As System.Windows.Forms.DataGridView
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblReturnedRecords As System.Windows.Forms.Label
    Friend WithEvents coRefundRequestNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReceiptNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRequestStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colApprovalStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayeeName As System.Windows.Forms.DataGridViewTextBoxColumn



End Class