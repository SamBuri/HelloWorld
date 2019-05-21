
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIPDAlerts : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal alertTypeID As String)
        MyClass.New()
        Me.alertTypeID = alertTypeID
    End Sub

    Public Sub New(ByVal alertTypeID As String, ByVal controlAlertNo As Control)
        MyClass.New(alertTypeID)
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIPDAlerts))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvIPDAlerts = New System.Windows.Forms.DataGridView()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoundNoText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoundDateTimeText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAttendingDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDoctorContact = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSentTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvIPDAlerts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(845, 271)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvIPDAlerts
        '
        Me.dgvIPDAlerts.AllowUserToAddRows = False
        Me.dgvIPDAlerts.AllowUserToDeleteRows = False
        Me.dgvIPDAlerts.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvIPDAlerts.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvIPDAlerts.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvIPDAlerts.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvIPDAlerts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvIPDAlerts.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvIPDAlerts.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDAlerts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvIPDAlerts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colRoundNoText, Me.colNotes, Me.colFullName, Me.colGender, Me.colAge, Me.colRoundDateTimeText, Me.colBillCustomerName, Me.colAttendingDoctor, Me.ColDoctorContact, Me.colSentDate, Me.colSentTime})
        Me.dgvIPDAlerts.ContextMenuStrip = Me.cmsAlertList
        Me.dgvIPDAlerts.EnableHeadersVisualStyles = False
        Me.dgvIPDAlerts.GridColor = System.Drawing.Color.Khaki
        Me.dgvIPDAlerts.Location = New System.Drawing.Point(8, 8)
        Me.dgvIPDAlerts.Name = "dgvIPDAlerts"
        Me.dgvIPDAlerts.ReadOnly = True
        Me.dgvIPDAlerts.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvIPDAlerts.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvIPDAlerts.RowHeadersVisible = False
        Me.dgvIPDAlerts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvIPDAlerts.Size = New System.Drawing.Size(909, 256)
        Me.dgvIPDAlerts.TabIndex = 4
        Me.dgvIPDAlerts.Text = "DataGridView1"
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
        Me.lblMessage.Location = New System.Drawing.Point(287, 278)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(314, 20)
        Me.lblMessage.TabIndex = 5
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        Me.colPatientNo.Width = 75
        '
        'colRoundNoText
        '
        Me.colRoundNoText.DataPropertyName = "RoundNoText"
        Me.colRoundNoText.HeaderText = "Round No"
        Me.colRoundNoText.Name = "colRoundNoText"
        Me.colRoundNoText.ReadOnly = True
        Me.colRoundNoText.Width = 80
        '
        'colNotes
        '
        Me.colNotes.DataPropertyName = "Notes"
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.Name = "colNotes"
        Me.colNotes.ReadOnly = True
        '
        'colFullName
        '
        Me.colFullName.DataPropertyName = "FullName"
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        Me.colFullName.Width = 120
        '
        'colGender
        '
        Me.colGender.DataPropertyName = "Gender"
        Me.colGender.HeaderText = "Gender"
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 50
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        Me.colAge.HeaderText = "Age"
        Me.colAge.Name = "colAge"
        Me.colAge.ReadOnly = True
        Me.colAge.Width = 30
        '
        'colRoundDateTimeText
        '
        Me.colRoundDateTimeText.DataPropertyName = "RoundDateTimeText"
        Me.colRoundDateTimeText.HeaderText = "Round Date & Time"
        Me.colRoundDateTimeText.Name = "colRoundDateTimeText"
        Me.colRoundDateTimeText.ReadOnly = True
        Me.colRoundDateTimeText.Width = 120
        '
        'colBillCustomerName
        '
        Me.colBillCustomerName.DataPropertyName = "BillCustomerName"
        Me.colBillCustomerName.HeaderText = "To-Bill Customer"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.ReadOnly = True
        '
        'colAttendingDoctor
        '
        Me.colAttendingDoctor.DataPropertyName = "AttendingDoctor"
        Me.colAttendingDoctor.HeaderText = "Attending Doctor"
        Me.colAttendingDoctor.Name = "colAttendingDoctor"
        Me.colAttendingDoctor.ReadOnly = True
        '
        'ColDoctorContact
        '
        Me.ColDoctorContact.DataPropertyName = "DoctorContact"
        Me.ColDoctorContact.HeaderText = "Doctor Contact"
        Me.ColDoctorContact.Name = "ColDoctorContact"
        Me.ColDoctorContact.ReadOnly = True
        '
        'colSentDate
        '
        Me.colSentDate.DataPropertyName = "SentDateText"
        Me.colSentDate.HeaderText = "Sent Date"
        Me.colSentDate.Name = "colSentDate"
        Me.colSentDate.ReadOnly = True
        Me.colSentDate.Width = 80
        '
        'colSentTime
        '
        Me.colSentTime.DataPropertyName = "SentTime"
        Me.colSentTime.HeaderText = "Sent Time"
        Me.colSentTime.Name = "colSentTime"
        Me.colSentTime.ReadOnly = True
        Me.colSentTime.Width = 75
        '
        'frmIPDAlerts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(927, 307)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvIPDAlerts)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmIPDAlerts"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Alert List"
        CType(Me.dgvIPDAlerts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvIPDAlerts As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRoundNoText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRoundDateTimeText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAttendingDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDoctorContact As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSentTime As System.Windows.Forms.DataGridViewTextBoxColumn

End Class