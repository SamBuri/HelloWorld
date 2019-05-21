<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendingStaffPayments
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


    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control, ByVal ApprovalState As Boolean)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
        Me._ApprovalState = ApprovalState
    End Sub

    Public Sub New(ByVal controlAlertNo As Control, ByVal ApprovalState As Boolean, ByVal visitTypeID As String)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
        Me._ApprovalState = ApprovalState
        Me._visitTypeID = visitTypeID
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPendingStaffPayments))
        Me.dgvVoucherDetails = New System.Windows.Forms.DataGridView()
        Me.colPaymentVoucherNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStartDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colEndDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillModes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStaffNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStaffFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvVoucherDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvVoucherDetails
        '
        Me.dgvVoucherDetails.AllowUserToAddRows = False
        Me.dgvVoucherDetails.AllowUserToDeleteRows = False
        Me.dgvVoucherDetails.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvVoucherDetails.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvVoucherDetails.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvVoucherDetails.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvVoucherDetails.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvVoucherDetails.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVoucherDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvVoucherDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPaymentVoucherNo, Me.colVisitType, Me.colStartDateTime, Me.colEndDateTime, Me.colBillModes, Me.colStaffNo, Me.colStaffFullName})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvVoucherDetails.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvVoucherDetails.EnableHeadersVisualStyles = False
        Me.dgvVoucherDetails.GridColor = System.Drawing.Color.Khaki
        Me.dgvVoucherDetails.Location = New System.Drawing.Point(12, 72)
        Me.dgvVoucherDetails.Name = "dgvVoucherDetails"
        Me.dgvVoucherDetails.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvVoucherDetails.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvVoucherDetails.RowHeadersVisible = False
        Me.dgvVoucherDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvVoucherDetails.Size = New System.Drawing.Size(909, 274)
        Me.dgvVoucherDetails.TabIndex = 110
        Me.dgvVoucherDetails.Text = "DataGridView1"
        '
        'colPaymentVoucherNo
        '
        Me.colPaymentVoucherNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colPaymentVoucherNo.DataPropertyName = "PaymentVoucherNo"
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colPaymentVoucherNo.DefaultCellStyle = DataGridViewCellStyle3
        Me.colPaymentVoucherNo.FillWeight = 130.0!
        Me.colPaymentVoucherNo.HeaderText = "voucher No"
        Me.colPaymentVoucherNo.Name = "colPaymentVoucherNo"
        Me.colPaymentVoucherNo.ReadOnly = True
        '
        'colVisitType
        '
        Me.colVisitType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colVisitType.DataPropertyName = "VisitType"
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colVisitType.DefaultCellStyle = DataGridViewCellStyle4
        Me.colVisitType.HeaderText = "Visit Type"
        Me.colVisitType.Name = "colVisitType"
        Me.colVisitType.ReadOnly = True
        '
        'colStartDateTime
        '
        Me.colStartDateTime.DataPropertyName = "StartDateTime"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colStartDateTime.DefaultCellStyle = DataGridViewCellStyle5
        Me.colStartDateTime.HeaderText = "Start Date Time"
        Me.colStartDateTime.Name = "colStartDateTime"
        Me.colStartDateTime.ReadOnly = True
        Me.colStartDateTime.Width = 150
        '
        'colEndDateTime
        '
        Me.colEndDateTime.DataPropertyName = "EndDateTime"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colEndDateTime.DefaultCellStyle = DataGridViewCellStyle6
        Me.colEndDateTime.HeaderText = "End Date Time"
        Me.colEndDateTime.Name = "colEndDateTime"
        Me.colEndDateTime.ReadOnly = True
        Me.colEndDateTime.Width = 150
        '
        'colBillModes
        '
        Me.colBillModes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.colBillModes.DataPropertyName = "BillModes"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colBillModes.DefaultCellStyle = DataGridViewCellStyle7
        Me.colBillModes.HeaderText = "Bill Modes"
        Me.colBillModes.Name = "colBillModes"
        Me.colBillModes.ReadOnly = True
        Me.colBillModes.Width = 150
        '
        'colStaffNo
        '
        Me.colStaffNo.DataPropertyName = "StaffNo"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colStaffNo.DefaultCellStyle = DataGridViewCellStyle8
        Me.colStaffNo.HeaderText = "Staff No"
        Me.colStaffNo.Name = "colStaffNo"
        Me.colStaffNo.ReadOnly = True
        '
        'colStaffFullName
        '
        Me.colStaffFullName.DataPropertyName = "StaffFullName"
        Me.colStaffFullName.HeaderText = "Staff Full Name"
        Me.colStaffFullName.Name = "colStaffFullName"
        Me.colStaffFullName.Width = 150
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(849, 352)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 112
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(310, 356)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 113
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(563, 9)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(253, 13)
        Me.lblRecordsNo.TabIndex = 114
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.Label1)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(12, 1)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(909, 65)
        Me.grpSetParameters.TabIndex = 115
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Payment Period"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 20)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(594, 31)
        Me.pnlPeriod.TabIndex = 3
        '
        'dtpEndDate
        '
        Me.dtpEndDate.CustomFormat = "yyyy MMM dd hh:mm tt"
        Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDate.Location = New System.Drawing.Point(397, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(10, 5)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(83, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.dtpStartDate.CustomFormat = "yyyy MMM dd hh:mm tt"
        Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDate.Location = New System.Drawing.Point(103, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(184, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(296, 5)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(89, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(637, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(253, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(605, 29)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(106, 22)
        Me.fbnLoad.TabIndex = 4
        Me.fbnLoad.Text = "Load..."
        '
        'frmPendingStaffPayments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(933, 388)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.lblRecordsNo)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dgvVoucherDetails)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPendingStaffPayments"
        Me.Text = "Pending Staff Payments"
        CType(Me.dgvVoucherDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvVoucherDetails As System.Windows.Forms.DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents colPaymentVoucherNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStartDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colEndDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillModes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStaffNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStaffFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
End Class
