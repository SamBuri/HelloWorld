<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDashboardLabSelfRequests
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboardLabSelfRequests))
        Me.dgvSelftRequestLabResults = New System.Windows.Forms.DataGridView()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNoText = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSentTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DrawnBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvSelftRequestLabResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvSelftRequestLabResults
        '
        Me.dgvSelftRequestLabResults.AllowUserToAddRows = False
        Me.dgvSelftRequestLabResults.AllowUserToDeleteRows = False
        Me.dgvSelftRequestLabResults.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvSelftRequestLabResults.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSelftRequestLabResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvSelftRequestLabResults.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvSelftRequestLabResults.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvSelftRequestLabResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvSelftRequestLabResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSelftRequestLabResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSelftRequestLabResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colVisitNoText, Me.colFullName, Me.colGender, Me.colAge, Me.colVisitDate, Me.colTestDate, Me.colSentTime, Me.DrawnBy})
        Me.dgvSelftRequestLabResults.EnableHeadersVisualStyles = False
        Me.dgvSelftRequestLabResults.GridColor = System.Drawing.Color.Khaki
        Me.dgvSelftRequestLabResults.Location = New System.Drawing.Point(4, 5)
        Me.dgvSelftRequestLabResults.Name = "dgvSelftRequestLabResults"
        Me.dgvSelftRequestLabResults.ReadOnly = True
        Me.dgvSelftRequestLabResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSelftRequestLabResults.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvSelftRequestLabResults.RowHeadersVisible = False
        Me.dgvSelftRequestLabResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvSelftRequestLabResults.Size = New System.Drawing.Size(774, 363)
        Me.dgvSelftRequestLabResults.TabIndex = 9
        Me.dgvSelftRequestLabResults.Text = "DataGridView1"
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
        'colTestDate
        '
        Me.colTestDate.DataPropertyName = "TestDate"
        Me.colTestDate.HeaderText = "Sent Date"
        Me.colTestDate.Name = "colTestDate"
        Me.colTestDate.ReadOnly = True
        Me.colTestDate.Width = 80
        '
        'colSentTime
        '
        Me.colSentTime.DataPropertyName = "SentTime"
        Me.colSentTime.HeaderText = "Sent Time"
        Me.colSentTime.Name = "colSentTime"
        Me.colSentTime.ReadOnly = True
        Me.colSentTime.Width = 75
        '
        'DrawnBy
        '
        Me.DrawnBy.DataPropertyName = "DrawnBy"
        Me.DrawnBy.HeaderText = "Drawn By"
        Me.DrawnBy.Name = "DrawnBy"
        Me.DrawnBy.ReadOnly = True
        Me.DrawnBy.Width = 150
        '
        'frmDashboardLabSelfRequests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(782, 404)
        Me.Controls.Add(Me.dgvSelftRequestLabResults)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDashboardLabSelfRequests"
        Me.Text = "Self Request Results"
        CType(Me.dgvSelftRequestLabResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvSelftRequestLabResults As DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colPatientNo As DataGridViewTextBoxColumn
    Friend WithEvents colVisitNoText As DataGridViewTextBoxColumn
    Friend WithEvents colFullName As DataGridViewTextBoxColumn
    Friend WithEvents colGender As DataGridViewTextBoxColumn
    Friend WithEvents colAge As DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As DataGridViewTextBoxColumn
    Friend WithEvents colTestDate As DataGridViewTextBoxColumn
    Friend WithEvents colSentTime As DataGridViewTextBoxColumn
    Friend WithEvents DrawnBy As DataGridViewTextBoxColumn
End Class
