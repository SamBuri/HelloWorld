
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRefundRejects : Inherits System.Windows.Forms.Form


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

    Public Sub New(refundRequestNo As String, receiptNo As String, rejectedAt As String)
        MyClass.New()
        Me.refundRequestNo = refundRequestNo
        Me.receiptNo = receiptNo
        Me.rejectedAt = rejectedAt

    End Sub


'Required by the Windows Form Designer
Private components As System.ComponentModel.IContainer

'NOTE: The following procedure is required by the Windows Form Designer
'It can be modified using the Windows Form Designer.
'Do not modify it using the code editor.
<System.Diagnostics.DebuggerStepThrough()> _
Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRefundRejects))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboReceiptNo = New System.Windows.Forms.ComboBox()
        Me.cboRejectedAt = New System.Windows.Forms.ComboBox()
        Me.dtpRejectionDate = New System.Windows.Forms.DateTimePicker()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbRefundRequestNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRefundRequestNo = New System.Windows.Forms.Label()
        Me.lblReceiptNo = New System.Windows.Forms.Label()
        Me.lblRejectedAt = New System.Windows.Forms.Label()
        Me.lblRejectionDate = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 182)
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
        Me.fbnDelete.Location = New System.Drawing.Point(316, 182)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "RefundRejects"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 209)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "RefundRejects"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboReceiptNo
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboReceiptNo, "ReceiptNo")
        Me.cboReceiptNo.Enabled = False
        Me.cboReceiptNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboReceiptNo.Location = New System.Drawing.Point(218, 35)
        Me.cboReceiptNo.Name = "cboReceiptNo"
        Me.cboReceiptNo.Size = New System.Drawing.Size(170, 21)
        Me.cboReceiptNo.TabIndex = 6
        '
        'cboRejectedAt
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboRejectedAt, "RejectedAt")
        Me.cboRejectedAt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRejectedAt.Enabled = False
        Me.cboRejectedAt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRejectedAt.Location = New System.Drawing.Point(218, 58)
        Me.cboRejectedAt.Name = "cboRejectedAt"
        Me.cboRejectedAt.Size = New System.Drawing.Size(170, 21)
        Me.cboRejectedAt.TabIndex = 8
        '
        'dtpRejectionDate
        '
        Me.dtpRejectionDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpRejectionDate, "RejectionDate")
        Me.dtpRejectionDate.Location = New System.Drawing.Point(218, 81)
        Me.dtpRejectionDate.Name = "dtpRejectionDate"
        Me.dtpRejectionDate.ShowCheckBox = True
        Me.dtpRejectionDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpRejectionDate.TabIndex = 10
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(218, 104)
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.stbNotes.Size = New System.Drawing.Size(170, 72)
        Me.stbNotes.TabIndex = 12
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 209)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbRefundRequestNo
        '
        Me.stbRefundRequestNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbRefundRequestNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRefundRequestNo.CapitalizeFirstLetter = False
        Me.stbRefundRequestNo.EntryErrorMSG = ""
        Me.stbRefundRequestNo.Location = New System.Drawing.Point(218, 12)
        Me.stbRefundRequestNo.Name = "stbRefundRequestNo"
        Me.stbRefundRequestNo.ReadOnly = True
        Me.stbRefundRequestNo.RegularExpression = ""
        Me.stbRefundRequestNo.Size = New System.Drawing.Size(170, 20)
        Me.stbRefundRequestNo.TabIndex = 4
        '
        'lblRefundRequestNo
        '
        Me.lblRefundRequestNo.Location = New System.Drawing.Point(12, 12)
        Me.lblRefundRequestNo.Name = "lblRefundRequestNo"
        Me.lblRefundRequestNo.Size = New System.Drawing.Size(200, 20)
        Me.lblRefundRequestNo.TabIndex = 5
        Me.lblRefundRequestNo.Text = "Refund Request No"
        '
        'lblReceiptNo
        '
        Me.lblReceiptNo.Location = New System.Drawing.Point(12, 35)
        Me.lblReceiptNo.Name = "lblReceiptNo"
        Me.lblReceiptNo.Size = New System.Drawing.Size(200, 20)
        Me.lblReceiptNo.TabIndex = 7
        Me.lblReceiptNo.Text = "Receipt No"
        '
        'lblRejectedAt
        '
        Me.lblRejectedAt.Location = New System.Drawing.Point(12, 58)
        Me.lblRejectedAt.Name = "lblRejectedAt"
        Me.lblRejectedAt.Size = New System.Drawing.Size(200, 20)
        Me.lblRejectedAt.TabIndex = 9
        Me.lblRejectedAt.Text = "Rejected At"
        '
        'lblRejectionDate
        '
        Me.lblRejectionDate.Location = New System.Drawing.Point(12, 81)
        Me.lblRejectionDate.Name = "lblRejectionDate"
        Me.lblRejectionDate.Size = New System.Drawing.Size(200, 20)
        Me.lblRejectionDate.TabIndex = 11
        Me.lblRejectionDate.Text = "Rejection Date"
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(12, 104)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(200, 20)
        Me.lblNotes.TabIndex = 13
        Me.lblNotes.Text = "Notes"
        '
        'frmRefundRejects
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(402, 243)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbRefundRequestNo)
        Me.Controls.Add(Me.lblRefundRequestNo)
        Me.Controls.Add(Me.cboReceiptNo)
        Me.Controls.Add(Me.lblReceiptNo)
        Me.Controls.Add(Me.cboRejectedAt)
        Me.Controls.Add(Me.lblRejectedAt)
        Me.Controls.Add(Me.dtpRejectionDate)
        Me.Controls.Add(Me.lblRejectionDate)
        Me.Controls.Add(Me.stbNotes)
        Me.Controls.Add(Me.lblNotes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRefundRejects"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Refund Rejects"
        Me.ResumeLayout(False)
        Me.PerformLayout()

End Sub

Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
Friend WithEvents stbRefundRequestNo As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblRefundRequestNo As System.Windows.Forms.Label
Friend WithEvents cboReceiptNo As System.Windows.Forms.ComboBox
Friend WithEvents lblReceiptNo As System.Windows.Forms.Label
Friend WithEvents cboRejectedAt As System.Windows.Forms.ComboBox
Friend WithEvents lblRejectedAt As System.Windows.Forms.Label
Friend WithEvents dtpRejectionDate As System.Windows.Forms.DateTimePicker
Friend WithEvents lblRejectionDate As System.Windows.Forms.Label
Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
Friend WithEvents lblNotes As System.Windows.Forms.Label

End Class