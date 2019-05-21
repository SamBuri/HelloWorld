
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPeriodicClaims : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
    End Sub

    Public Sub New(ByVal controlAlertNo As Control, ByVal showPeriodPanel As Boolean, ByVal showIncludeColumn As Boolean)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
        Me._showPeriodPanel = showPeriodPanel
        Me._showIncludeColumn = showIncludeColumn

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPeriodicClaims))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvPeriodicClaims = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colMedicalCardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClaimNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHealthUnitName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMainMemberName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPrimaryDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsItems = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsItemsCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsItemsSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmsItemsIncludeAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsItemsIncludeNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnOk = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvPeriodicClaims, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsItems.SuspendLayout()
        Me.grpSetParameters.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(817, 347)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
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
        Me.dgvPeriodicClaims.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colMedicalCardNo, Me.colClaimNo, Me.colVisitDate, Me.colFullName, Me.colGender, Me.colAge, Me.colCompanyName, Me.colHealthUnitName, Me.colMainMemberName, Me.colPrimaryDoctor, Me.colRecordDate, Me.colRecordTime})
        Me.dgvPeriodicClaims.ContextMenuStrip = Me.cmsItems
        Me.dgvPeriodicClaims.EnableHeadersVisualStyles = False
        Me.dgvPeriodicClaims.GridColor = System.Drawing.Color.Khaki
        Me.dgvPeriodicClaims.Location = New System.Drawing.Point(8, 86)
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
        Me.dgvPeriodicClaims.Size = New System.Drawing.Size(881, 252)
        Me.dgvPeriodicClaims.TabIndex = 1
        Me.dgvPeriodicClaims.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.ReadOnly = True
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colInclude.Width = 50
        '
        'colMedicalCardNo
        '
        Me.colMedicalCardNo.DataPropertyName = "MedicalCardNo"
        Me.colMedicalCardNo.HeaderText = "Medical Card No"
        Me.colMedicalCardNo.Name = "colMedicalCardNo"
        Me.colMedicalCardNo.ReadOnly = True
        '
        'colClaimNo
        '
        Me.colClaimNo.DataPropertyName = "ClaimNo"
        Me.colClaimNo.HeaderText = "Claim No"
        Me.colClaimNo.Name = "colClaimNo"
        Me.colClaimNo.ReadOnly = True
        Me.colClaimNo.Width = 80
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 80
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
        Me.colGender.Width = 65
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        Me.colAge.HeaderText = "Age"
        Me.colAge.Name = "colAge"
        Me.colAge.ReadOnly = True
        Me.colAge.Width = 45
        '
        'colCompanyName
        '
        Me.colCompanyName.DataPropertyName = "CompanyName"
        Me.colCompanyName.HeaderText = "Company Name"
        Me.colCompanyName.Name = "colCompanyName"
        Me.colCompanyName.ReadOnly = True
        '
        'colHealthUnitName
        '
        Me.colHealthUnitName.DataPropertyName = "HealthUnitName"
        Me.colHealthUnitName.HeaderText = "Health Unit Name"
        Me.colHealthUnitName.Name = "colHealthUnitName"
        Me.colHealthUnitName.ReadOnly = True
        Me.colHealthUnitName.Width = 120
        '
        'colMainMemberName
        '
        Me.colMainMemberName.DataPropertyName = "MainMemberName"
        Me.colMainMemberName.HeaderText = "Main Member Name"
        Me.colMainMemberName.Name = "colMainMemberName"
        Me.colMainMemberName.ReadOnly = True
        Me.colMainMemberName.Width = 120
        '
        'colPrimaryDoctor
        '
        Me.colPrimaryDoctor.DataPropertyName = "PrimaryDoctor"
        Me.colPrimaryDoctor.HeaderText = "Primary Doctor"
        Me.colPrimaryDoctor.Name = "colPrimaryDoctor"
        Me.colPrimaryDoctor.ReadOnly = True
        Me.colPrimaryDoctor.Width = 120
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
        Me.colRecordTime.Width = 75
        '
        'cmsItems
        '
        Me.cmsItems.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsItems.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsItemsCopy, Me.cmsItemsSelectAll, Me.ToolStripMenuItem1, Me.cmsItemsIncludeAll, Me.cmsItemsIncludeNone})
        Me.cmsItems.Name = "cmsSearch"
        Me.cmsItems.Size = New System.Drawing.Size(146, 98)
        '
        'cmsItemsCopy
        '
        Me.cmsItemsCopy.Image = CType(resources.GetObject("cmsItemsCopy.Image"), System.Drawing.Image)
        Me.cmsItemsCopy.Name = "cmsItemsCopy"
        Me.cmsItemsCopy.Size = New System.Drawing.Size(145, 22)
        Me.cmsItemsCopy.Text = "Copy"
        Me.cmsItemsCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsItemsSelectAll
        '
        Me.cmsItemsSelectAll.Name = "cmsItemsSelectAll"
        Me.cmsItemsSelectAll.Size = New System.Drawing.Size(145, 22)
        Me.cmsItemsSelectAll.Text = "Select All"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(142, 6)
        '
        'cmsItemsIncludeAll
        '
        Me.cmsItemsIncludeAll.Name = "cmsItemsIncludeAll"
        Me.cmsItemsIncludeAll.Size = New System.Drawing.Size(145, 22)
        Me.cmsItemsIncludeAll.Text = "Include All"
        '
        'cmsItemsIncludeNone
        '
        Me.cmsItemsIncludeNone.Name = "cmsItemsIncludeNone"
        Me.cmsItemsIncludeNone.Size = New System.Drawing.Size(145, 22)
        Me.cmsItemsIncludeNone.Text = "Include None"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(281, 351)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(7, 4)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Size = New System.Drawing.Size(855, 63)
        Me.grpSetParameters.TabIndex = 0
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Visit Period"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 17)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(684, 31)
        Me.pnlPeriod.TabIndex = 4
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(449, 5)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(225, 20)
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
        Me.dtpStartDate.Location = New System.Drawing.Point(103, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(230, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(348, 5)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(89, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(665, 13)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(178, 13)
        Me.lblRecordsNo.TabIndex = 3
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(737, 29)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(106, 28)
        Me.fbnLoad.TabIndex = 5
        Me.fbnLoad.Text = "Load..."
        '
        'fbnOk
        '
        Me.fbnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnOk.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnOk.Location = New System.Drawing.Point(7, 349)
        Me.fbnOk.Name = "fbnOk"
        Me.fbnOk.Size = New System.Drawing.Size(83, 22)
        Me.fbnOk.TabIndex = 15
        Me.fbnOk.Tag = ""
        Me.fbnOk.Text = "Ok"
        '
        'frmPeriodicClaims
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(899, 383)
        Me.Controls.Add(Me.fbnOk)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvPeriodicClaims)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmPeriodicClaims"
        Me.Tag = ""
        Me.Text = "Periodic Claims"
        CType(Me.dgvPeriodicClaims, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsItems.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvPeriodicClaims As System.Windows.Forms.DataGridView
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colMedicalCardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClaimNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCompanyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHealthUnitName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMainMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrimaryDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cmsItems As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsItemsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsItemsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsItemsIncludeAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsItemsIncludeNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents fbnOk As SyncSoft.Common.Win.Controls.FlatButton

End Class