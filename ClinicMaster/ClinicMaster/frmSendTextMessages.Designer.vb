<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSendTextMessages
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSendTextMessages))
        Me.dgvUnSentTextMessages = New System.Windows.Forms.DataGridView()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.tmrSendMessages = New System.Windows.Forms.Timer(Me.components)
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.NtIClinicMaster = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.CMSSms = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuShow = New System.Windows.Forms.ToolStripMenuItem()
        Me.MnuClose = New System.Windows.Forms.ToolStripMenuItem()
        Me.ColMessageNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMessages = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvUnSentTextMessages, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMSSms.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvUnSentTextMessages
        '
        Me.dgvUnSentTextMessages.AllowUserToAddRows = False
        Me.dgvUnSentTextMessages.AllowUserToDeleteRows = False
        Me.dgvUnSentTextMessages.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvUnSentTextMessages.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvUnSentTextMessages.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvUnSentTextMessages.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvUnSentTextMessages.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvUnSentTextMessages.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvUnSentTextMessages.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUnSentTextMessages.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvUnSentTextMessages.ColumnHeadersHeight = 25
        Me.dgvUnSentTextMessages.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColMessageNo, Me.colPhone, Me.colMessages})
        Me.dgvUnSentTextMessages.EnableHeadersVisualStyles = False
        Me.dgvUnSentTextMessages.GridColor = System.Drawing.Color.Khaki
        Me.dgvUnSentTextMessages.Location = New System.Drawing.Point(7, 2)
        Me.dgvUnSentTextMessages.Name = "dgvUnSentTextMessages"
        Me.dgvUnSentTextMessages.ReadOnly = True
        Me.dgvUnSentTextMessages.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvUnSentTextMessages.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvUnSentTextMessages.RowHeadersVisible = False
        Me.dgvUnSentTextMessages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvUnSentTextMessages.Size = New System.Drawing.Size(683, 417)
        Me.dgvUnSentTextMessages.TabIndex = 6
        Me.dgvUnSentTextMessages.Text = "DataGridView1"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.fbnClose.Location = New System.Drawing.Point(620, 425)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(66, 24)
        Me.fbnClose.TabIndex = 7
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'tmrSendMessages
        '
        Me.tmrSendMessages.Enabled = True
        Me.tmrSendMessages.Interval = 20000
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(12, 426)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(290, 19)
        Me.lblRecordsNo.TabIndex = 8
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NtIClinicMaster
        '
        Me.NtIClinicMaster.Text = "ClinicMaster"
        Me.NtIClinicMaster.Visible = True
        '
        'CMSSms
        '
        Me.CMSSms.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuShow, Me.MnuClose})
        Me.CMSSms.Name = "CMSSms"
        Me.CMSSms.Size = New System.Drawing.Size(104, 48)
        '
        'mnuShow
        '
        Me.mnuShow.Name = "mnuShow"
        Me.mnuShow.Size = New System.Drawing.Size(103, 22)
        Me.mnuShow.Text = "Show"
        '
        'MnuClose
        '
        Me.MnuClose.Name = "MnuClose"
        Me.MnuClose.Size = New System.Drawing.Size(103, 22)
        Me.MnuClose.Text = "Close"
        '
        'ColMessageNo
        '
        Me.ColMessageNo.DataPropertyName = "MessageNo"
        Me.ColMessageNo.HeaderText = "Message No"
        Me.ColMessageNo.Name = "ColMessageNo"
        Me.ColMessageNo.ReadOnly = True
        '
        'colPhone
        '
        Me.colPhone.DataPropertyName = "Phone"
        Me.colPhone.HeaderText = "Phone No"
        Me.colPhone.Name = "colPhone"
        Me.colPhone.ReadOnly = True
        Me.colPhone.Width = 200
        '
        'colMessages
        '
        Me.colMessages.DataPropertyName = "Message"
        Me.colMessages.HeaderText = "Message"
        Me.colMessages.Name = "colMessages"
        Me.colMessages.ReadOnly = True
        Me.colMessages.Width = 200
        '
        'frmSendTextMessages
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSize = True
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(698, 454)
        Me.Controls.Add(Me.lblRecordsNo)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dgvUnSentTextMessages)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmSendTextMessages"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Send Text Messages"
        CType(Me.dgvUnSentTextMessages, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMSSms.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvUnSentTextMessages As System.Windows.Forms.DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents tmrSendMessages As System.Windows.Forms.Timer
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents NtIClinicMaster As System.Windows.Forms.NotifyIcon
    Friend WithEvents CMSSms As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuShow As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ColMessageNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMessages As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
