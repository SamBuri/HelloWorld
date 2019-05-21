<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPeriodicWaitingClaims
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPeriodicWaitingClaims))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrimaryDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMainMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHealthUnitName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClaimNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMedicalCardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvPeriodicClaims = New System.Windows.Forms.DataGridView()
        Me.cmsAlertList.SuspendLayout()
        CType(Me.dgvPeriodicClaims, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(330, 329)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 6
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmsAlertListSelectAll
        '
        Me.cmsAlertListSelectAll.Enabled = False
        Me.cmsAlertListSelectAll.Name = "cmsAlertListSelectAll"
        Me.cmsAlertListSelectAll.Size = New System.Drawing.Size(122, 22)
        Me.cmsAlertListSelectAll.Text = "Select All"
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
        'cmsAlertList
        '
        Me.cmsAlertList.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsAlertList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsAlertListCopy, Me.cmsAlertListSelectAll})
        Me.cmsAlertList.Name = "cmsSearch"
        Me.cmsAlertList.Size = New System.Drawing.Size(123, 48)
        '
        'colRecordTime
        '
        Me.colRecordTime.DataPropertyName = "RecordTime"
        Me.colRecordTime.HeaderText = "Record Time"
        Me.colRecordTime.Name = "colRecordTime"
        Me.colRecordTime.ReadOnly = True
        Me.colRecordTime.Width = 75
        '
        'colRecordDate
        '
        Me.colRecordDate.DataPropertyName = "RecordDate"
        Me.colRecordDate.HeaderText = "Record Date"
        Me.colRecordDate.Name = "colRecordDate"
        Me.colRecordDate.ReadOnly = True
        Me.colRecordDate.Width = 80
        '
        'colPrimaryDoctor
        '
        Me.colPrimaryDoctor.DataPropertyName = "PrimaryDoctor"
        Me.colPrimaryDoctor.HeaderText = "Primary Doctor"
        Me.colPrimaryDoctor.Name = "colPrimaryDoctor"
        Me.colPrimaryDoctor.ReadOnly = True
        Me.colPrimaryDoctor.Width = 120
        '
        'colMainMemberName
        '
        Me.colMainMemberName.DataPropertyName = "MainMemberName"
        Me.colMainMemberName.HeaderText = "Main Member Name"
        Me.colMainMemberName.Name = "colMainMemberName"
        Me.colMainMemberName.ReadOnly = True
        Me.colMainMemberName.Width = 120
        '
        'colHealthUnitName
        '
        Me.colHealthUnitName.DataPropertyName = "HealthUnitName"
        Me.colHealthUnitName.HeaderText = "Health Unit Name"
        Me.colHealthUnitName.Name = "colHealthUnitName"
        Me.colHealthUnitName.ReadOnly = True
        Me.colHealthUnitName.Width = 120
        '
        'colCompanyName
        '
        Me.colCompanyName.DataPropertyName = "CompanyName"
        Me.colCompanyName.HeaderText = "Company Name"
        Me.colCompanyName.Name = "colCompanyName"
        Me.colCompanyName.ReadOnly = True
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        Me.colAge.HeaderText = "Age"
        Me.colAge.Name = "colAge"
        Me.colAge.ReadOnly = True
        Me.colAge.Width = 45
        '
        'colGender
        '
        Me.colGender.DataPropertyName = "Gender"
        Me.colGender.HeaderText = "Gender"
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 65
        '
        'colFullName
        '
        Me.colFullName.DataPropertyName = "FullName"
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        Me.colFullName.Width = 150
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 80
        '
        'colClaimNo
        '
        Me.colClaimNo.DataPropertyName = "ClaimNo"
        Me.colClaimNo.HeaderText = "Claim No"
        Me.colClaimNo.Name = "colClaimNo"
        Me.colClaimNo.ReadOnly = True
        Me.colClaimNo.Width = 80
        '
        'colMedicalCardNo
        '
        Me.colMedicalCardNo.DataPropertyName = "MedicalCardNo"
        Me.colMedicalCardNo.HeaderText = "Medical Card No"
        Me.colMedicalCardNo.Name = "colMedicalCardNo"
        Me.colMedicalCardNo.ReadOnly = True
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(923, 329)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 7
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvPeriodicClaims
        '
        Me.dgvPeriodicClaims.AllowUserToAddRows = False
        Me.dgvPeriodicClaims.AllowUserToDeleteRows = False
        Me.dgvPeriodicClaims.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPeriodicClaims.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPeriodicClaims.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPeriodicClaims.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPeriodicClaims.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPeriodicClaims.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPeriodicClaims.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPeriodicClaims.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPeriodicClaims.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colMedicalCardNo, Me.colClaimNo, Me.colVisitDate, Me.colFullName, Me.colGender, Me.colAge, Me.colCompanyName, Me.colHealthUnitName, Me.colMainMemberName, Me.colPrimaryDoctor, Me.colRecordDate, Me.colRecordTime})
        Me.dgvPeriodicClaims.ContextMenuStrip = Me.cmsAlertList
        Me.dgvPeriodicClaims.EnableHeadersVisualStyles = False
        Me.dgvPeriodicClaims.GridColor = System.Drawing.Color.Khaki
        Me.dgvPeriodicClaims.Location = New System.Drawing.Point(12, 12)
        Me.dgvPeriodicClaims.Name = "dgvPeriodicClaims"
        Me.dgvPeriodicClaims.ReadOnly = True
        Me.dgvPeriodicClaims.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPeriodicClaims.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPeriodicClaims.RowHeadersVisible = False
        Me.dgvPeriodicClaims.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPeriodicClaims.Size = New System.Drawing.Size(983, 292)
        Me.dgvPeriodicClaims.TabIndex = 5
        Me.dgvPeriodicClaims.Text = "DataGridView1"
        '
        'frmPeriodicWaitingClaims
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1007, 365)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dgvPeriodicClaims)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPeriodicWaitingClaims"
        Me.Text = "Periodic Waiting Claims"
        Me.cmsAlertList.ResumeLayout(False)
        CType(Me.dgvPeriodicClaims, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrimaryDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMainMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHealthUnitName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCompanyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClaimNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMedicalCardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvPeriodicClaims As System.Windows.Forms.DataGridView
End Class
