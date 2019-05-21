<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAccountsBalances
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAccountsBalances))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.nbxAmount = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblAmount = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvAccountsBalance = New System.Windows.Forms.DataGridView()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNOK = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColNOKPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAccountBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLastVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.grpSetParameters.SuspendLayout()
        CType(Me.dgvAccountsBalance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(844, 396)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 11
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.nbxAmount)
        Me.grpSetParameters.Controls.Add(Me.lblAmount)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(8, 8)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(896, 57)
        Me.grpSetParameters.TabIndex = 9
        Me.grpSetParameters.TabStop = False
        '
        'nbxAmount
        '
        Me.nbxAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAmount.ControlCaption = "Amount"
        Me.nbxAmount.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxAmount.DecimalPlaces = 2
        Me.nbxAmount.Location = New System.Drawing.Point(420, 31)
        Me.nbxAmount.MaxLength = 5
        Me.nbxAmount.MaxValue = 45.0R
        Me.nbxAmount.MinValue = 10000000000.0R
        Me.nbxAmount.MustEnterNumeric = True
        Me.nbxAmount.Name = "nbxAmount"
        Me.nbxAmount.Size = New System.Drawing.Size(211, 20)
        Me.nbxAmount.TabIndex = 12
        Me.nbxAmount.Value = ""
        '
        'lblAmount
        '
        Me.lblAmount.AutoSize = True
        Me.lblAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAmount.Location = New System.Drawing.Point(349, 31)
        Me.lblAmount.Name = "lblAmount"
        Me.lblAmount.Size = New System.Drawing.Size(65, 20)
        Me.lblAmount.TabIndex = 6
        Me.lblAmount.Text = "Amount"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(637, 13)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(206, 13)
        Me.lblRecordsNo.TabIndex = 3
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(637, 31)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(106, 22)
        Me.fbnLoad.TabIndex = 5
        Me.fbnLoad.Text = "Load..."
        '
        'dgvAccountsBalance
        '
        Me.dgvAccountsBalance.AllowUserToAddRows = False
        Me.dgvAccountsBalance.AllowUserToDeleteRows = False
        Me.dgvAccountsBalance.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvAccountsBalance.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAccountsBalance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAccountsBalance.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvAccountsBalance.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAccountsBalance.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvAccountsBalance.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountsBalance.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAccountsBalance.ColumnHeadersHeight = 25
        Me.dgvAccountsBalance.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colFullName, Me.colPhone, Me.ColNOK, Me.ColNOKPhone, Me.colAccountBalance, Me.ColLastVisitDate})
        Me.dgvAccountsBalance.ContextMenuStrip = Me.cmsAlertList
        Me.dgvAccountsBalance.EnableHeadersVisualStyles = False
        Me.dgvAccountsBalance.GridColor = System.Drawing.Color.Khaki
        Me.dgvAccountsBalance.Location = New System.Drawing.Point(5, 71)
        Me.dgvAccountsBalance.Name = "dgvAccountsBalance"
        Me.dgvAccountsBalance.ReadOnly = True
        Me.dgvAccountsBalance.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvAccountsBalance.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvAccountsBalance.RowHeadersVisible = False
        Me.dgvAccountsBalance.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvAccountsBalance.Size = New System.Drawing.Size(911, 319)
        Me.dgvAccountsBalance.TabIndex = 10
        Me.dgvAccountsBalance.Text = "DataGridView1"
        '
        'colPatientNo
        '
        Me.colPatientNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        '
        'colFullName
        '
        Me.colFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFullName.DataPropertyName = "FullName"
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        '
        'colPhone
        '
        Me.colPhone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPhone.DataPropertyName = "Phone"
        Me.colPhone.HeaderText = "Phone"
        Me.colPhone.Name = "colPhone"
        Me.colPhone.ReadOnly = True
        '
        'ColNOK
        '
        Me.ColNOK.DataPropertyName = "NOKName"
        Me.ColNOK.HeaderText = "NOK Name"
        Me.ColNOK.Name = "ColNOK"
        Me.ColNOK.ReadOnly = True
        '
        'ColNOKPhone
        '
        Me.ColNOKPhone.DataPropertyName = "NOKPhone"
        Me.ColNOKPhone.HeaderText = "NOK Phone"
        Me.ColNOKPhone.Name = "ColNOKPhone"
        Me.ColNOKPhone.ReadOnly = True
        '
        'colAccountBalance
        '
        Me.colAccountBalance.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colAccountBalance.DataPropertyName = "AccountBalance"
        Me.colAccountBalance.HeaderText = "Account Balance"
        Me.colAccountBalance.Name = "colAccountBalance"
        Me.colAccountBalance.ReadOnly = True
        '
        'ColLastVisitDate
        '
        Me.ColLastVisitDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColLastVisitDate.DataPropertyName = "LastVisitDate"
        Me.ColLastVisitDate.HeaderText = "Last Visit Date"
        Me.ColLastVisitDate.Name = "ColLastVisitDate"
        Me.ColLastVisitDate.ReadOnly = True
        '
        'cmsAlertList
        '
        Me.cmsAlertList.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsAlertList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsAlertListCopy, Me.cmsAlertListSelectAll})
        Me.cmsAlertList.Name = "cmsSearch"
        Me.cmsAlertList.Size = New System.Drawing.Size(123, 48)
        '
        'cmsAlertListCopy
        '
        Me.cmsAlertListCopy.Enabled = False
        Me.cmsAlertListCopy.Image = CType(resources.GetObject("cmsAlertListCopy.Image"), System.Drawing.Image)
        Me.cmsAlertListCopy.Name = "cmsAlertListCopy"
        Me.cmsAlertListCopy.Size = New System.Drawing.Size(122, 22)
        Me.cmsAlertListCopy.Text = "Copy"
        Me.cmsAlertListCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsAlertListSelectAll
        '
        Me.cmsAlertListSelectAll.Enabled = False
        Me.cmsAlertListSelectAll.Name = "cmsAlertListSelectAll"
        Me.cmsAlertListSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsAlertListSelectAll.Text = "Select All"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(294, 400)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(395, 20)
        Me.lblMessage.TabIndex = 12
        Me.lblMessage.Text = "Hint: Enter Amount to start from and Load"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmAccountsBalances
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 427)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.dgvAccountsBalance)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAccountsBalances"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Account Balances"
        Me.grpSetParameters.ResumeLayout(False)
        Me.grpSetParameters.PerformLayout()
        CType(Me.dgvAccountsBalance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents lblAmount As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvAccountsBalance As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents nbxAmount As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNOK As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColNOKPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAccountBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLastVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lblMessage As System.Windows.Forms.Label
End Class
