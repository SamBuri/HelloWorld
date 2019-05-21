
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMessenger : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMessenger))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbMessage = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblReceiverLoginID = New System.Windows.Forms.Label()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.tbcMessenger = New System.Windows.Forms.TabControl()
        Me.tpgCompose = New System.Windows.Forms.TabPage()
        Me.tpgInbox = New System.Windows.Forms.TabPage()
        Me.dgvInbox = New System.Windows.Forms.DataGridView()
        Me.colFromFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMessageInfo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tpgOutbox = New System.Windows.Forms.TabPage()
        Me.dgvOutbox = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblUnreadMessageAlerts = New System.Windows.Forms.Label()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.tbcMessenger.SuspendLayout()
        Me.tpgCompose.SuspendLayout()
        Me.tpgInbox.SuspendLayout()
        CType(Me.dgvInbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgOutbox.SuspendLayout()
        CType(Me.dgvOutbox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(19, 287)
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
        Me.fbnDelete.Location = New System.Drawing.Point(595, 283)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "Messenger"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(19, 314)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "Messenger"
        Me.ebnSaveUpdate.Text = "&Send"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbMessage
        '
        Me.stbMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMessage.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMessage, "Message")
        Me.stbMessage.EntryErrorMSG = ""
        Me.stbMessage.Location = New System.Drawing.Point(94, 38)
        Me.stbMessage.MaxLength = 2000
        Me.stbMessage.Multiline = True
        Me.stbMessage.Name = "stbMessage"
        Me.stbMessage.RegularExpression = ""
        Me.stbMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbMessage.Size = New System.Drawing.Size(541, 160)
        Me.stbMessage.TabIndex = 8
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.DropDownWidth = 230
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.FormattingEnabled = True
        Me.cboStaffNo.Location = New System.Drawing.Point(97, 10)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(228, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 16
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(595, 310)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblReceiverLoginID
        '
        Me.lblReceiverLoginID.Location = New System.Drawing.Point(14, 9)
        Me.lblReceiverLoginID.Name = "lblReceiverLoginID"
        Me.lblReceiverLoginID.Size = New System.Drawing.Size(59, 20)
        Me.lblReceiverLoginID.TabIndex = 7
        Me.lblReceiverLoginID.Text = "Receiver"
        '
        'lblMessage
        '
        Me.lblMessage.Location = New System.Drawing.Point(14, 38)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(74, 20)
        Me.lblMessage.TabIndex = 9
        Me.lblMessage.Text = "Message"
        '
        'tbcMessenger
        '
        Me.tbcMessenger.Controls.Add(Me.tpgCompose)
        Me.tbcMessenger.Controls.Add(Me.tpgInbox)
        Me.tbcMessenger.Controls.Add(Me.tpgOutbox)
        Me.tbcMessenger.Location = New System.Drawing.Point(6, 33)
        Me.tbcMessenger.Name = "tbcMessenger"
        Me.tbcMessenger.SelectedIndex = 0
        Me.tbcMessenger.Size = New System.Drawing.Size(665, 248)
        Me.tbcMessenger.TabIndex = 17
        '
        'tpgCompose
        '
        Me.tpgCompose.Controls.Add(Me.stbMessage)
        Me.tpgCompose.Controls.Add(Me.cboStaffNo)
        Me.tpgCompose.Controls.Add(Me.lblMessage)
        Me.tpgCompose.Controls.Add(Me.lblReceiverLoginID)
        Me.tpgCompose.Location = New System.Drawing.Point(4, 22)
        Me.tpgCompose.Name = "tpgCompose"
        Me.tpgCompose.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgCompose.Size = New System.Drawing.Size(657, 222)
        Me.tpgCompose.TabIndex = 0
        Me.tpgCompose.Text = "Compose"
        Me.tpgCompose.UseVisualStyleBackColor = True
        '
        'tpgInbox
        '
        Me.tpgInbox.Controls.Add(Me.dgvInbox)
        Me.tpgInbox.Location = New System.Drawing.Point(4, 22)
        Me.tpgInbox.Name = "tpgInbox"
        Me.tpgInbox.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgInbox.Size = New System.Drawing.Size(657, 222)
        Me.tpgInbox.TabIndex = 1
        Me.tpgInbox.Text = "Received"
        Me.tpgInbox.UseVisualStyleBackColor = True
        '
        'dgvInbox
        '
        Me.dgvInbox.AllowUserToAddRows = False
        Me.dgvInbox.AllowUserToDeleteRows = False
        Me.dgvInbox.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvInbox.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInbox.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInbox.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInbox.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInbox.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInbox.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colFromFullName, Me.colRecordDate, Me.colMessageInfo})
        Me.dgvInbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInbox.EnableHeadersVisualStyles = False
        Me.dgvInbox.GridColor = System.Drawing.Color.Khaki
        Me.dgvInbox.Location = New System.Drawing.Point(3, 3)
        Me.dgvInbox.Name = "dgvInbox"
        Me.dgvInbox.ReadOnly = True
        Me.dgvInbox.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInbox.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInbox.RowHeadersVisible = False
        Me.dgvInbox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvInbox.Size = New System.Drawing.Size(651, 216)
        Me.dgvInbox.TabIndex = 3
        Me.dgvInbox.Text = "DataGridView1"
        '
        'colFromFullName
        '
        Me.colFromFullName.DataPropertyName = "FromFullName"
        Me.colFromFullName.HeaderText = "From"
        Me.colFromFullName.Name = "colFromFullName"
        Me.colFromFullName.ReadOnly = True
        Me.colFromFullName.Width = 120
        '
        'colRecordDate
        '
        Me.colRecordDate.DataPropertyName = "RecordDate"
        Me.colRecordDate.HeaderText = "Date & Time"
        Me.colRecordDate.Name = "colRecordDate"
        Me.colRecordDate.ReadOnly = True
        '
        'colMessageInfo
        '
        Me.colMessageInfo.DataPropertyName = "MessageInfo"
        Me.colMessageInfo.HeaderText = "Message"
        Me.colMessageInfo.Name = "colMessageInfo"
        Me.colMessageInfo.ReadOnly = True
        Me.colMessageInfo.Width = 350
        '
        'tpgOutbox
        '
        Me.tpgOutbox.Controls.Add(Me.dgvOutbox)
        Me.tpgOutbox.Location = New System.Drawing.Point(4, 22)
        Me.tpgOutbox.Name = "tpgOutbox"
        Me.tpgOutbox.Size = New System.Drawing.Size(657, 222)
        Me.tpgOutbox.TabIndex = 2
        Me.tpgOutbox.Text = "Sent"
        Me.tpgOutbox.UseVisualStyleBackColor = True
        '
        'dgvOutbox
        '
        Me.dgvOutbox.AllowUserToAddRows = False
        Me.dgvOutbox.AllowUserToDeleteRows = False
        Me.dgvOutbox.AllowUserToOrderColumns = True
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvOutbox.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvOutbox.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOutbox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOutbox.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOutbox.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOutbox.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvOutbox.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        Me.dgvOutbox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvOutbox.EnableHeadersVisualStyles = False
        Me.dgvOutbox.GridColor = System.Drawing.Color.Khaki
        Me.dgvOutbox.Location = New System.Drawing.Point(0, 0)
        Me.dgvOutbox.Name = "dgvOutbox"
        Me.dgvOutbox.ReadOnly = True
        Me.dgvOutbox.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOutbox.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvOutbox.RowHeadersVisible = False
        Me.dgvOutbox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOutbox.Size = New System.Drawing.Size(657, 222)
        Me.dgvOutbox.TabIndex = 4
        Me.dgvOutbox.Text = "DataGridView1"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ReceiverFullName"
        Me.DataGridViewTextBoxColumn1.HeaderText = "To"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "RecordDate"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Date & Time"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "MessageInfo"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Message"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 350
        '
        'lblUnreadMessageAlerts
        '
        Me.lblUnreadMessageAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUnreadMessageAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblUnreadMessageAlerts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblUnreadMessageAlerts.Location = New System.Drawing.Point(8, 4)
        Me.lblUnreadMessageAlerts.Name = "lblUnreadMessageAlerts"
        Me.lblUnreadMessageAlerts.Size = New System.Drawing.Size(176, 20)
        Me.lblUnreadMessageAlerts.TabIndex = 17
        Me.lblUnreadMessageAlerts.Text = "Unread Messages : 0"
        Me.lblUnreadMessageAlerts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'frmMessenger
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(677, 341)
        Me.Controls.Add(Me.lblUnreadMessageAlerts)
        Me.Controls.Add(Me.tbcMessenger)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.fbnDelete)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmMessenger"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Chat"
        Me.tbcMessenger.ResumeLayout(False)
        Me.tpgCompose.ResumeLayout(False)
        Me.tpgCompose.PerformLayout()
        Me.tpgInbox.ResumeLayout(False)
        CType(Me.dgvInbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgOutbox.ResumeLayout(False)
        CType(Me.dgvOutbox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblReceiverLoginID As System.Windows.Forms.Label
    Friend WithEvents stbMessage As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents tbcMessenger As System.Windows.Forms.TabControl
    Friend WithEvents tpgCompose As System.Windows.Forms.TabPage
    Friend WithEvents tpgInbox As System.Windows.Forms.TabPage
    Friend WithEvents dgvInbox As System.Windows.Forms.DataGridView
    Friend WithEvents tpgOutbox As System.Windows.Forms.TabPage
    Friend WithEvents dgvOutbox As System.Windows.Forms.DataGridView
    Friend WithEvents lblUnreadMessageAlerts As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents colFromFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMessageInfo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn

End Class