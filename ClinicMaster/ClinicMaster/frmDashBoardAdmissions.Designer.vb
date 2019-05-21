<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashBoardAdmissions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashBoardAdmissions))
        Me.dgvInWardAdmissions = New System.Windows.Forms.DataGridView()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAdmissionDateTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colWard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBedNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBedName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoomNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRoomName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvInWardAdmissions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvInWardAdmissions
        '
        Me.dgvInWardAdmissions.AllowUserToAddRows = False
        Me.dgvInWardAdmissions.AllowUserToDeleteRows = False
        Me.dgvInWardAdmissions.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvInWardAdmissions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvInWardAdmissions.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvInWardAdmissions.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvInWardAdmissions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvInWardAdmissions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvInWardAdmissions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInWardAdmissions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvInWardAdmissions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colVisitNo, Me.colAdmissionNo, Me.colAdmissionDateTime, Me.colFullName, Me.colGender, Me.colAge, Me.colVisitDate, Me.colBillCustomerName, Me.colWard, Me.colBedNo, Me.colBedName, Me.colRoomNo, Me.colRoomName})
        Me.dgvInWardAdmissions.EnableHeadersVisualStyles = False
        Me.dgvInWardAdmissions.GridColor = System.Drawing.Color.Khaki
        Me.dgvInWardAdmissions.Location = New System.Drawing.Point(7, 4)
        Me.dgvInWardAdmissions.Name = "dgvInWardAdmissions"
        Me.dgvInWardAdmissions.ReadOnly = True
        Me.dgvInWardAdmissions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInWardAdmissions.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvInWardAdmissions.RowHeadersVisible = False
        Me.dgvInWardAdmissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvInWardAdmissions.Size = New System.Drawing.Size(944, 371)
        Me.dgvInWardAdmissions.TabIndex = 1
        Me.dgvInWardAdmissions.Text = "DataGridView1"
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        Me.colPatientNo.Width = 75
        '
        'colVisitNo
        '
        Me.colVisitNo.DataPropertyName = "VisitNo"
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        Me.colVisitNo.Width = 80
        '
        'colAdmissionNo
        '
        Me.colAdmissionNo.DataPropertyName = "AdmissionNo"
        Me.colAdmissionNo.HeaderText = "Admission No"
        Me.colAdmissionNo.Name = "colAdmissionNo"
        Me.colAdmissionNo.ReadOnly = True
        Me.colAdmissionNo.Width = 80
        '
        'colAdmissionDateTime
        '
        Me.colAdmissionDateTime.DataPropertyName = "AdmissionDateTime"
        Me.colAdmissionDateTime.HeaderText = "Admission Date & Time"
        Me.colAdmissionDateTime.Name = "colAdmissionDateTime"
        Me.colAdmissionDateTime.ReadOnly = True
        Me.colAdmissionDateTime.Width = 120
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
        Me.colGender.Width = 60
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        Me.colAge.HeaderText = "Age"
        Me.colAge.Name = "colAge"
        Me.colAge.ReadOnly = True
        Me.colAge.Width = 40
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 80
        '
        'colBillCustomerName
        '
        Me.colBillCustomerName.DataPropertyName = "BillCustomerName"
        Me.colBillCustomerName.HeaderText = "To-Bill Customer"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.ReadOnly = True
        '
        'colWard
        '
        Me.colWard.DataPropertyName = "Ward"
        Me.colWard.HeaderText = "Ward"
        Me.colWard.Name = "colWard"
        Me.colWard.ReadOnly = True
        Me.colWard.Width = 80
        '
        'colBedNo
        '
        Me.colBedNo.DataPropertyName = "BedNo"
        Me.colBedNo.HeaderText = "Bed No"
        Me.colBedNo.Name = "colBedNo"
        Me.colBedNo.ReadOnly = True
        Me.colBedNo.Width = 60
        '
        'colBedName
        '
        Me.colBedName.DataPropertyName = "BedName"
        Me.colBedName.HeaderText = "Bed Name"
        Me.colBedName.Name = "colBedName"
        Me.colBedName.ReadOnly = True
        Me.colBedName.Width = 80
        '
        'colRoomNo
        '
        Me.colRoomNo.DataPropertyName = "RoomNo"
        Me.colRoomNo.HeaderText = "Room No"
        Me.colRoomNo.Name = "colRoomNo"
        Me.colRoomNo.ReadOnly = True
        Me.colRoomNo.Width = 60
        '
        'colRoomName
        '
        Me.colRoomName.DataPropertyName = "RoomName"
        Me.colRoomName.HeaderText = "Room Name"
        Me.colRoomName.Name = "colRoomName"
        Me.colRoomName.ReadOnly = True
        Me.colRoomName.Width = 80
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(878, 383)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 10
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'frmDashBoardAdmissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(960, 413)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dgvInWardAdmissions)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDashBoardAdmissions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DashBoard Admissions"
        CType(Me.dgvInWardAdmissions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvInWardAdmissions As System.Windows.Forms.DataGridView
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAdmissionDateTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colWard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBedNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBedName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRoomNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRoomName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
End Class
