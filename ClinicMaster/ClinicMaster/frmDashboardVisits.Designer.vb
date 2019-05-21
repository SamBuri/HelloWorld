<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboardVisits
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboardVisits))
        Me.dgvDashBoardVisits = New System.Windows.Forms.DataGridView()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNoText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColPhoneNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrimaryDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDoctorSeenTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSentTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvDashBoardVisits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvDashBoardVisits
        '
        Me.dgvDashBoardVisits.AllowUserToAddRows = False
        Me.dgvDashBoardVisits.AllowUserToDeleteRows = False
        Me.dgvDashBoardVisits.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvDashBoardVisits.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDashBoardVisits.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDashBoardVisits.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvDashBoardVisits.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvDashBoardVisits.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvDashBoardVisits.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDashBoardVisits.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDashBoardVisits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colVisitNoText, Me.ColPhoneNo, Me.colFullName, Me.colBillCustomerName, Me.ColRecordTime, Me.colPrimaryDoctor, Me.ColDoctorSeenTime, Me.colSentTime})
        Me.dgvDashBoardVisits.EnableHeadersVisualStyles = False
        Me.dgvDashBoardVisits.GridColor = System.Drawing.Color.Khaki
        Me.dgvDashBoardVisits.Location = New System.Drawing.Point(2, 3)
        Me.dgvDashBoardVisits.Name = "dgvDashBoardVisits"
        Me.dgvDashBoardVisits.ReadOnly = True
        Me.dgvDashBoardVisits.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDashBoardVisits.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDashBoardVisits.RowHeadersVisible = False
        Me.dgvDashBoardVisits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvDashBoardVisits.Size = New System.Drawing.Size(968, 378)
        Me.dgvDashBoardVisits.TabIndex = 8
        Me.dgvDashBoardVisits.Text = "DataGridView1"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(895, 387)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 9
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'colPatientNo
        '
        Me.colPatientNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        '
        'colVisitNoText
        '
        Me.colVisitNoText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colVisitNoText.DataPropertyName = "VisitNo"
        Me.colVisitNoText.HeaderText = "Visit No"
        Me.colVisitNoText.Name = "colVisitNoText"
        Me.colVisitNoText.ReadOnly = True
        '
        'ColPhoneNo
        '
        Me.ColPhoneNo.DataPropertyName = "Phone"
        Me.ColPhoneNo.HeaderText = "Phone No"
        Me.ColPhoneNo.Name = "ColPhoneNo"
        Me.ColPhoneNo.ReadOnly = True
        '
        'colFullName
        '
        Me.colFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFullName.DataPropertyName = "FullName"
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        '
        'colBillCustomerName
        '
        Me.colBillCustomerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colBillCustomerName.DataPropertyName = "BillMode"
        Me.colBillCustomerName.HeaderText = "Bill Mode"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.ReadOnly = True
        '
        'ColRecordTime
        '
        Me.ColRecordTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColRecordTime.DataPropertyName = "RecordTime"
        Me.ColRecordTime.HeaderText = "Visit Time"
        Me.ColRecordTime.Name = "ColRecordTime"
        Me.ColRecordTime.ReadOnly = True
        '
        'colPrimaryDoctor
        '
        Me.colPrimaryDoctor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPrimaryDoctor.DataPropertyName = "SeenDoctor"
        Me.colPrimaryDoctor.HeaderText = "Seen Doctor"
        Me.colPrimaryDoctor.Name = "colPrimaryDoctor"
        Me.colPrimaryDoctor.ReadOnly = True
        '
        'ColDoctorSeenTime
        '
        Me.ColDoctorSeenTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.ColDoctorSeenTime.DataPropertyName = "DoctorTime"
        Me.ColDoctorSeenTime.HeaderText = "Time Seen"
        Me.ColDoctorSeenTime.Name = "ColDoctorSeenTime"
        Me.ColDoctorSeenTime.ReadOnly = True
        '
        'colSentTime
        '
        Me.colSentTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colSentTime.DataPropertyName = "WaitingTime"
        Me.colSentTime.HeaderText = "Waiting Time (Mins)"
        Me.colSentTime.Name = "colSentTime"
        Me.colSentTime.ReadOnly = True
        '
        'frmDashboardVisits
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(975, 420)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dgvDashBoardVisits)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDashboardVisits"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard Visits"
        CType(Me.dgvDashBoardVisits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvDashBoardVisits As System.Windows.Forms.DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitNoText As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColPhoneNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrimaryDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDoctorSeenTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSentTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
