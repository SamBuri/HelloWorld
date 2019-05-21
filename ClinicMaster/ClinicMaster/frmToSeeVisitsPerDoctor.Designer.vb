<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmToSeeVisitsPerDoctor
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

    Public Sub New(ByVal staffNo As String, ByVal startDateTime As Nullable(Of DateTime), ByVal endDateTime As Nullable(Of DateTime))
        MyClass.New()
        Me._staffNo = staffNo
        Me._startDateTime = startDateTime
        Me._endDateTime = endDateTime
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmToSeeVisitsPerDoctor))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgDoctorVisitsPerDoctor = New System.Windows.Forms.DataGridView()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStaffNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colstaffName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colServiceCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colServiceName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colServiceFee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        CType(Me.dgDoctorVisitsPerDoctor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(885, 340)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 11
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgDoctorVisitsPerDoctor
        '
        Me.dgDoctorVisitsPerDoctor.AllowUserToAddRows = False
        Me.dgDoctorVisitsPerDoctor.AllowUserToDeleteRows = False
        Me.dgDoctorVisitsPerDoctor.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgDoctorVisitsPerDoctor.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDoctorVisitsPerDoctor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDoctorVisitsPerDoctor.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgDoctorVisitsPerDoctor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgDoctorVisitsPerDoctor.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgDoctorVisitsPerDoctor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDoctorVisitsPerDoctor.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgDoctorVisitsPerDoctor.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colFullName, Me.colGender, Me.colVisitNo, Me.colVisitDate, Me.colVisitStatus, Me.colVisitCategory, Me.colStaffNo, Me.colstaffName, Me.colServiceCode, Me.colServiceName, Me.colServiceFee})
        Me.dgDoctorVisitsPerDoctor.ContextMenuStrip = Me.cmsAlertList
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDoctorVisitsPerDoctor.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgDoctorVisitsPerDoctor.EnableHeadersVisualStyles = False
        Me.dgDoctorVisitsPerDoctor.GridColor = System.Drawing.Color.Khaki
        Me.dgDoctorVisitsPerDoctor.Location = New System.Drawing.Point(12, 33)
        Me.dgDoctorVisitsPerDoctor.Name = "dgDoctorVisitsPerDoctor"
        Me.dgDoctorVisitsPerDoctor.ReadOnly = True
        Me.dgDoctorVisitsPerDoctor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDoctorVisitsPerDoctor.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgDoctorVisitsPerDoctor.RowHeadersVisible = False
        Me.dgDoctorVisitsPerDoctor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgDoctorVisitsPerDoctor.Size = New System.Drawing.Size(945, 302)
        Me.dgDoctorVisitsPerDoctor.TabIndex = 9
        Me.dgDoctorVisitsPerDoctor.Text = "DataGridView1"
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        '
        'colFullName
        '
        Me.colFullName.DataPropertyName = "FullName"
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        Me.colFullName.Width = 180
        '
        'colGender
        '
        Me.colGender.DataPropertyName = "Gender"
        Me.colGender.HeaderText = "Gender"
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 70
        '
        'colVisitNo
        '
        Me.colVisitNo.DataPropertyName = "VisitNo"
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        '
        'colVisitStatus
        '
        Me.colVisitStatus.DataPropertyName = "VisitStatus"
        Me.colVisitStatus.HeaderText = "Visit Status"
        Me.colVisitStatus.Name = "colVisitStatus"
        Me.colVisitStatus.ReadOnly = True
        Me.colVisitStatus.Width = 80
        '
        'colVisitCategory
        '
        Me.colVisitCategory.DataPropertyName = "VisitCategory"
        Me.colVisitCategory.HeaderText = "Visit Category"
        Me.colVisitCategory.Name = "colVisitCategory"
        Me.colVisitCategory.ReadOnly = True
        '
        'colStaffNo
        '
        Me.colStaffNo.DataPropertyName = "StaffNo"
        Me.colStaffNo.HeaderText = "Staff No"
        Me.colStaffNo.Name = "colStaffNo"
        Me.colStaffNo.ReadOnly = True
        Me.colStaffNo.Width = 70
        '
        'colstaffName
        '
        Me.colstaffName.DataPropertyName = "staffName"
        Me.colstaffName.HeaderText = "staff Name"
        Me.colstaffName.Name = "colstaffName"
        Me.colstaffName.ReadOnly = True
        Me.colstaffName.Width = 150
        '
        'colServiceCode
        '
        Me.colServiceCode.DataPropertyName = "ServiceCode"
        Me.colServiceCode.HeaderText = "Service Code"
        Me.colServiceCode.Name = "colServiceCode"
        Me.colServiceCode.ReadOnly = True
        Me.colServiceCode.Width = 80
        '
        'colServiceName
        '
        Me.colServiceName.DataPropertyName = "ServiceName"
        Me.colServiceName.HeaderText = "Service Name"
        Me.colServiceName.Name = "colServiceName"
        Me.colServiceName.ReadOnly = True
        Me.colServiceName.Width = 150
        '
        'colServiceFee
        '
        Me.colServiceFee.DataPropertyName = "ServiceFee"
        Me.colServiceFee.HeaderText = "Service Fee"
        Me.colServiceFee.Name = "colServiceFee"
        Me.colServiceFee.ReadOnly = True
        Me.colServiceFee.Width = 150
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
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(751, 9)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(206, 13)
        Me.lblRecordsNo.TabIndex = 3
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmToSeeVisitsPerDoctor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(969, 376)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblRecordsNo)
        Me.Controls.Add(Me.dgDoctorVisitsPerDoctor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmToSeeVisitsPerDoctor"
        Me.Text = "To See Visits Per Doctor."
        CType(Me.dgDoctorVisitsPerDoctor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgDoctorVisitsPerDoctor As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStaffNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colstaffName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colServiceCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colServiceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colServiceFee As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
