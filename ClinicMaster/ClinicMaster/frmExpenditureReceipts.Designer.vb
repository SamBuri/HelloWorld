
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpenditureReceipts : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExpenditureReceipts))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvExpenditureReceipts = New System.Windows.Forms.DataGridView()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.grpPeriod = New System.Windows.Forms.GroupBox()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.colExpenditureNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSpentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGivenTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExpenditureCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvExpenditureReceipts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.grpPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(871, 295)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 2
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvExpenditureReceipts
        '
        Me.dgvExpenditureReceipts.AllowUserToAddRows = False
        Me.dgvExpenditureReceipts.AllowUserToDeleteRows = False
        Me.dgvExpenditureReceipts.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvExpenditureReceipts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExpenditureReceipts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvExpenditureReceipts.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvExpenditureReceipts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvExpenditureReceipts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvExpenditureReceipts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExpenditureReceipts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvExpenditureReceipts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colExpenditureNo, Me.colSpentDate, Me.colGivenTo, Me.colExpenditureCategory, Me.colAmount, Me.colRecordDate, Me.colRecordTime})
        Me.dgvExpenditureReceipts.ContextMenuStrip = Me.cmsAlertList
        Me.dgvExpenditureReceipts.EnableHeadersVisualStyles = False
        Me.dgvExpenditureReceipts.GridColor = System.Drawing.Color.Khaki
        Me.dgvExpenditureReceipts.Location = New System.Drawing.Point(8, 57)
        Me.dgvExpenditureReceipts.Name = "dgvExpenditureReceipts"
        Me.dgvExpenditureReceipts.ReadOnly = True
        Me.dgvExpenditureReceipts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExpenditureReceipts.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvExpenditureReceipts.RowHeadersVisible = False
        Me.dgvExpenditureReceipts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvExpenditureReceipts.Size = New System.Drawing.Size(935, 229)
        Me.dgvExpenditureReceipts.TabIndex = 0
        Me.dgvExpenditureReceipts.Text = "DataGridView1"
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
        Me.lblMessage.Location = New System.Drawing.Point(308, 299)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpPeriod
        '
        Me.grpPeriod.Controls.Add(Me.lblRecordsNo)
        Me.grpPeriod.Controls.Add(Me.dtpEndDateTime)
        Me.grpPeriod.Controls.Add(Me.lblEndDateTime)
        Me.grpPeriod.Controls.Add(Me.fbnLoad)
        Me.grpPeriod.Controls.Add(Me.dtpStartDateTime)
        Me.grpPeriod.Controls.Add(Me.lblStartDateTime)
        Me.grpPeriod.Location = New System.Drawing.Point(7, 5)
        Me.grpPeriod.Name = "grpPeriod"
        Me.grpPeriod.Size = New System.Drawing.Size(937, 46)
        Me.grpPeriod.TabIndex = 3
        Me.grpPeriod.TabStop = False
        Me.grpPeriod.Text = "Collection Period"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(759, 17)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(153, 13)
        Me.lblRecordsNo.TabIndex = 6
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(492, 15)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpEndDateTime.TabIndex = 3
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(352, 15)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(134, 20)
        Me.lblEndDateTime.TabIndex = 2
        Me.lblEndDateTime.Text = "End Record Date && Time"
        Me.lblEndDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(691, 13)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(62, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "Load..."
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(157, 15)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(189, 20)
        Me.dtpStartDateTime.TabIndex = 1
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(7, 15)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(144, 20)
        Me.lblStartDateTime.TabIndex = 0
        Me.lblStartDateTime.Text = "Start Record Date && Time"
        Me.lblStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'colExpenditureNo
        '
        Me.colExpenditureNo.DataPropertyName = "ExpenditureNo"
        Me.colExpenditureNo.HeaderText = "Expenditure No"
        Me.colExpenditureNo.Name = "colExpenditureNo"
        Me.colExpenditureNo.ReadOnly = True
        '
        'colSpentDate
        '
        Me.colSpentDate.DataPropertyName = "SpentDate"
        Me.colSpentDate.HeaderText = "Spent Date"
        Me.colSpentDate.Name = "colSpentDate"
        Me.colSpentDate.ReadOnly = True
        '
        'colGivenTo
        '
        Me.colGivenTo.DataPropertyName = "GivenTo"
        Me.colGivenTo.HeaderText = "Given To"
        Me.colGivenTo.Name = "colGivenTo"
        Me.colGivenTo.ReadOnly = True
        Me.colGivenTo.Width = 160
        '
        'colExpenditureCategory
        '
        Me.colExpenditureCategory.DataPropertyName = "ExpenditureCategory"
        Me.colExpenditureCategory.HeaderText = "Expenditure Category"
        Me.colExpenditureCategory.Name = "colExpenditureCategory"
        Me.colExpenditureCategory.ReadOnly = True
        Me.colExpenditureCategory.Width = 120
        '
        'colAmount
        '
        Me.colAmount.DataPropertyName = "Amount"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 120
        '
        'colRecordDate
        '
        Me.colRecordDate.DataPropertyName = "RecordDate"
        Me.colRecordDate.HeaderText = "Record Date"
        Me.colRecordDate.Name = "colRecordDate"
        Me.colRecordDate.ReadOnly = True
        Me.colRecordDate.Width = 80
        '
        'colRecordTime
        '
        Me.colRecordTime.DataPropertyName = "RecordTime"
        Me.colRecordTime.HeaderText = "Record Time"
        Me.colRecordTime.Name = "colRecordTime"
        Me.colRecordTime.ReadOnly = True
        Me.colRecordTime.Width = 80
        '
        'frmExpenditureReceipts
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(953, 331)
        Me.Controls.Add(Me.grpPeriod)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvExpenditureReceipts)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmExpenditureReceipts"
        Me.Tag = ""
        Me.Text = "Expenditure Receipts"
        CType(Me.dgvExpenditureReceipts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.grpPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvExpenditureReceipts As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents grpPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDateTime As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDateTime As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents colExpenditureNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSpentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGivenTo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colExpenditureCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn

End Class