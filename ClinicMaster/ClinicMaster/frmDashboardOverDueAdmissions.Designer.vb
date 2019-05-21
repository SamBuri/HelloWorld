<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboardOverDueAdmissions
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboardOverDueAdmissions))
        Me.dgvOverDueAdmissions = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAdmissions = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBedNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColBed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColWard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAdmissionDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDaysOnWard = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAdmissionNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnExport = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvOverDueAdmissions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvOverDueAdmissions
        '
        Me.dgvOverDueAdmissions.AllowUserToAddRows = False
        Me.dgvOverDueAdmissions.AllowUserToDeleteRows = False
        Me.dgvOverDueAdmissions.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvOverDueAdmissions.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOverDueAdmissions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvOverDueAdmissions.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvOverDueAdmissions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvOverDueAdmissions.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvOverDueAdmissions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOverDueAdmissions.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOverDueAdmissions.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn24, Me.DataGridViewTextBoxColumn26, Me.ColAdmissions, Me.ColBedNo, Me.ColBed, Me.ColWard, Me.ColVisitDate, Me.ColAdmissionDate, Me.ColDaysOnWard, Me.ColAdmissionNotes})
        Me.dgvOverDueAdmissions.EnableHeadersVisualStyles = False
        Me.dgvOverDueAdmissions.GridColor = System.Drawing.Color.Khaki
        Me.dgvOverDueAdmissions.Location = New System.Drawing.Point(0, 0)
        Me.dgvOverDueAdmissions.Name = "dgvOverDueAdmissions"
        Me.dgvOverDueAdmissions.ReadOnly = True
        Me.dgvOverDueAdmissions.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOverDueAdmissions.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOverDueAdmissions.RowHeadersVisible = False
        Me.dgvOverDueAdmissions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvOverDueAdmissions.Size = New System.Drawing.Size(940, 379)
        Me.dgvOverDueAdmissions.TabIndex = 6
        Me.dgvOverDueAdmissions.Text = "DataGridView1"
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "VisitNo"
        Me.DataGridViewTextBoxColumn25.HeaderText = "Visit No"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        Me.DataGridViewTextBoxColumn25.ReadOnly = True
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "FullName"
        Me.DataGridViewTextBoxColumn24.HeaderText = "Full Name"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        Me.DataGridViewTextBoxColumn24.ReadOnly = True
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "Phone"
        Me.DataGridViewTextBoxColumn26.HeaderText = "Phone No"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        Me.DataGridViewTextBoxColumn26.ReadOnly = True
        '
        'ColAdmissions
        '
        Me.ColAdmissions.DataPropertyName = "AdmissionNo"
        Me.ColAdmissions.HeaderText = "Admission No"
        Me.ColAdmissions.Name = "ColAdmissions"
        Me.ColAdmissions.ReadOnly = True
        '
        'ColBedNo
        '
        Me.ColBedNo.DataPropertyName = "BedNo"
        Me.ColBedNo.HeaderText = "Bed No"
        Me.ColBedNo.Name = "ColBedNo"
        Me.ColBedNo.ReadOnly = True
        '
        'ColBed
        '
        Me.ColBed.DataPropertyName = "BedName"
        Me.ColBed.HeaderText = "Bed"
        Me.ColBed.Name = "ColBed"
        Me.ColBed.ReadOnly = True
        '
        'ColWard
        '
        Me.ColWard.DataPropertyName = "RoomName"
        Me.ColWard.HeaderText = "Ward"
        Me.ColWard.Name = "ColWard"
        Me.ColWard.ReadOnly = True
        '
        'ColVisitDate
        '
        Me.ColVisitDate.DataPropertyName = "VisitDate"
        Me.ColVisitDate.HeaderText = "Visit Date"
        Me.ColVisitDate.Name = "ColVisitDate"
        Me.ColVisitDate.ReadOnly = True
        '
        'ColAdmissionDate
        '
        Me.ColAdmissionDate.DataPropertyName = "AdmissionDate"
        Me.ColAdmissionDate.HeaderText = "Admission Date"
        Me.ColAdmissionDate.Name = "ColAdmissionDate"
        Me.ColAdmissionDate.ReadOnly = True
        '
        'ColDaysOnWard
        '
        Me.ColDaysOnWard.DataPropertyName = "DaysOnWard"
        Me.ColDaysOnWard.HeaderText = "Days On Ward"
        Me.ColDaysOnWard.Name = "ColDaysOnWard"
        Me.ColDaysOnWard.ReadOnly = True
        '
        'ColAdmissionNotes
        '
        Me.ColAdmissionNotes.DataPropertyName = "AdmissionNotes"
        Me.ColAdmissionNotes.HeaderText = "Admission Notes"
        Me.ColAdmissionNotes.Name = "ColAdmissionNotes"
        Me.ColAdmissionNotes.ReadOnly = True
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(860, 385)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 7
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'fbnExport
        '
        Me.fbnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnExport.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExport.Location = New System.Drawing.Point(780, 387)
        Me.fbnExport.Name = "fbnExport"
        Me.fbnExport.Size = New System.Drawing.Size(74, 22)
        Me.fbnExport.TabIndex = 8
        Me.fbnExport.Text = "&Export"
        Me.fbnExport.UseVisualStyleBackColor = False
        '
        'frmDashboardOverDueAdmissions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(940, 416)
        Me.Controls.Add(Me.fbnExport)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dgvOverDueAdmissions)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDashboardOverDueAdmissions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard Over Due Admissions"
        CType(Me.dgvOverDueAdmissions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvOverDueAdmissions As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAdmissions As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBedNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColBed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColWard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAdmissionDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDaysOnWard As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColAdmissionNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnExport As SyncSoft.Common.Win.Controls.FlatButton
End Class
