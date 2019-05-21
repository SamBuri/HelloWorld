<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboardRadiologySelfRequests
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboardRadiologySelfRequests))
        Me.dgvSelftRequestRadReports = New System.Windows.Forms.DataGridView()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNoText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colExamDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSentTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRadiologist = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvSelftRequestRadReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSelftRequestRadReports
        '
        Me.dgvSelftRequestRadReports.AllowUserToAddRows = False
        Me.dgvSelftRequestRadReports.AllowUserToDeleteRows = False
        Me.dgvSelftRequestRadReports.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvSelftRequestRadReports.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSelftRequestRadReports.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSelftRequestRadReports.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvSelftRequestRadReports.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSelftRequestRadReports.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSelftRequestRadReports.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSelftRequestRadReports.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSelftRequestRadReports.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colVisitNoText, Me.colFullName, Me.colGender, Me.colAge, Me.colVisitDate, Me.colExamDate, Me.colSentTime, Me.colRadiologist})
        Me.dgvSelftRequestRadReports.EnableHeadersVisualStyles = False
        Me.dgvSelftRequestRadReports.GridColor = System.Drawing.Color.Khaki
        Me.dgvSelftRequestRadReports.Location = New System.Drawing.Point(4, 5)
        Me.dgvSelftRequestRadReports.Name = "dgvSelftRequestRadReports"
        Me.dgvSelftRequestRadReports.ReadOnly = True
        Me.dgvSelftRequestRadReports.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSelftRequestRadReports.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSelftRequestRadReports.RowHeadersVisible = False
        Me.dgvSelftRequestRadReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSelftRequestRadReports.Size = New System.Drawing.Size(774, 363)
        Me.dgvSelftRequestRadReports.TabIndex = 9
        Me.dgvSelftRequestRadReports.Text = "DataGridView1"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(706, 375)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 8
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        Me.colPatientNo.Width = 75
        '
        'colVisitNoText
        '
        Me.colVisitNoText.DataPropertyName = "VisitNo"
        Me.colVisitNoText.HeaderText = "Visit No"
        Me.colVisitNoText.Name = "colVisitNoText"
        Me.colVisitNoText.ReadOnly = True
        Me.colVisitNoText.Width = 80
        '
        'colFullName
        '
        Me.colFullName.DataPropertyName = "FullName"
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        Me.colFullName.Width = 150
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
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 80
        '
        'colExamDate
        '
        Me.colExamDate.DataPropertyName = "ExamDate"
        Me.colExamDate.HeaderText = "Exam Date"
        Me.colExamDate.Name = "colExamDate"
        Me.colExamDate.ReadOnly = True
        Me.colExamDate.Width = 80
        '
        'colSentTime
        '
        Me.colSentTime.DataPropertyName = "SentTime"
        Me.colSentTime.HeaderText = "Sent Time"
        Me.colSentTime.Name = "colSentTime"
        Me.colSentTime.ReadOnly = True
        Me.colSentTime.Width = 75
        '
        'colRadiologist
        '
        Me.colRadiologist.DataPropertyName = "Radiologist"
        Me.colRadiologist.HeaderText = "Radiologist"
        Me.colRadiologist.Name = "colRadiologist"
        Me.colRadiologist.ReadOnly = True
        Me.colRadiologist.Width = 150
        '
        'frmDashboardRadiologySelfRequests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 404)
        Me.Controls.Add(Me.dgvSelftRequestRadReports)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDashboardRadiologySelfRequests"
        Me.Text = "Self Request Reports"
        CType(Me.dgvSelftRequestRadReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvSelftRequestRadReports As DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colPatientNo As DataGridViewTextBoxColumn
    Friend WithEvents colVisitNoText As DataGridViewTextBoxColumn
    Friend WithEvents colFullName As DataGridViewTextBoxColumn
    Friend WithEvents colGender As DataGridViewTextBoxColumn
    Friend WithEvents colAge As DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As DataGridViewTextBoxColumn
    Friend WithEvents colExamDate As DataGridViewTextBoxColumn
    Friend WithEvents colSentTime As DataGridViewTextBoxColumn
    Friend WithEvents colRadiologist As DataGridViewTextBoxColumn
End Class
