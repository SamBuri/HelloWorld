
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPendingVisitFiles : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAlertNo As Control, ByVal hideSelfRequest As Boolean, ByVal pendingVisit As PendingVisit)
        MyClass.New()
        Me.alertNoControl = controlAlertNo
        Me._HideSelfRequest = hideSelfRequest
        Me._PendingVisit = pendingVisit
    End Sub

    'Public Sub New(ByVal controlAlertNo As Control, ByVal hideSelfRequest As Boolean, ByVal pendingVisit As PendingVisit, ByVal triageObject As Boolean)
    '    MyClass.New()
    '    Me.alertNoControl = controlAlertNo
    '    Me._HideSelfRequest = hideSelfRequest
    '    Me._PendingVisit = pendingVisit
    '    Me._TriageObject = triageObject
    'End Sub

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPendingVisitFiles))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvPendingVisitFiles = New System.Windows.Forms.DataGridView()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPriority = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colReferenceNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColReturnedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colToSeeSpecialty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colToSeeDoctor = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillMode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBillCustomerName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colInsuranceName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLoginID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitCategory = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colRecordTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.fbnCall = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvPendingVisitFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(891, 279)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 2
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvPendingVisitFiles
        '
        Me.dgvPendingVisitFiles.AllowUserToAddRows = False
        Me.dgvPendingVisitFiles.AllowUserToDeleteRows = False
        Me.dgvPendingVisitFiles.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvPendingVisitFiles.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPendingVisitFiles.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPendingVisitFiles.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvPendingVisitFiles.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvPendingVisitFiles.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvPendingVisitFiles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingVisitFiles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPendingVisitFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colFirstName, Me.colPriority, Me.colVisitNo, Me.colReferenceNo, Me.colFullName, Me.colGender, Me.colAge, Me.colStatus, Me.ColReturnedBy, Me.colVisitDate, Me.colToSeeSpecialty, Me.colToSeeDoctor, Me.colBillMode, Me.colBillCustomerName, Me.colInsuranceName, Me.colLoginID, Me.colVisitCategory, Me.colRecordDate, Me.colRecordTime})
        Me.dgvPendingVisitFiles.ContextMenuStrip = Me.cmsAlertList
        Me.dgvPendingVisitFiles.EnableHeadersVisualStyles = False
        Me.dgvPendingVisitFiles.GridColor = System.Drawing.Color.Khaki
        Me.dgvPendingVisitFiles.Location = New System.Drawing.Point(8, 32)
        Me.dgvPendingVisitFiles.Name = "dgvPendingVisitFiles"
        Me.dgvPendingVisitFiles.ReadOnly = True
        Me.dgvPendingVisitFiles.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPendingVisitFiles.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvPendingVisitFiles.RowHeadersVisible = False
        Me.dgvPendingVisitFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvPendingVisitFiles.Size = New System.Drawing.Size(955, 240)
        Me.dgvPendingVisitFiles.TabIndex = 0
        Me.dgvPendingVisitFiles.Text = "DataGridView1"
        '
        'colPatientNo
        '
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        Me.colPatientNo.Width = 75
        '
        'colFirstName
        '
        Me.colFirstName.DataPropertyName = "FirstName"
        Me.colFirstName.HeaderText = "First Name"
        Me.colFirstName.Name = "colFirstName"
        Me.colFirstName.ReadOnly = True
        Me.colFirstName.Visible = False
        '
        'colPriority
        '
        Me.colPriority.DataPropertyName = "Priority"
        Me.colPriority.HeaderText = "Priority"
        Me.colPriority.Name = "colPriority"
        Me.colPriority.ReadOnly = True
        '
        'colVisitNo
        '
        Me.colVisitNo.DataPropertyName = "VisitNo"
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        Me.colVisitNo.Width = 80
        '
        'colReferenceNo
        '
        Me.colReferenceNo.DataPropertyName = "ReferenceNo"
        Me.colReferenceNo.HeaderText = "Reference No"
        Me.colReferenceNo.Name = "colReferenceNo"
        Me.colReferenceNo.ReadOnly = True
        Me.colReferenceNo.Width = 80
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
        'colStatus
        '
        Me.colStatus.DataPropertyName = "ReturnStatus"
        Me.colStatus.HeaderText = "Archived"
        Me.colStatus.Name = "colStatus"
        Me.colStatus.ReadOnly = True
        Me.colStatus.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'ColReturnedBy
        '
        Me.ColReturnedBy.DataPropertyName = "ReturnedbyName"
        Me.ColReturnedBy.HeaderText = "Location"
        Me.ColReturnedBy.Name = "ColReturnedBy"
        Me.ColReturnedBy.ReadOnly = True
        Me.ColReturnedBy.Width = 150
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 80
        '
        'colToSeeSpecialty
        '
        Me.colToSeeSpecialty.DataPropertyName = "ToSeeSpecialty"
        Me.colToSeeSpecialty.HeaderText = "To-See Specialty"
        Me.colToSeeSpecialty.Name = "colToSeeSpecialty"
        Me.colToSeeSpecialty.ReadOnly = True
        '
        'colToSeeDoctor
        '
        Me.colToSeeDoctor.DataPropertyName = "ToSeeDoctor"
        Me.colToSeeDoctor.HeaderText = "To-See Doctor"
        Me.colToSeeDoctor.Name = "colToSeeDoctor"
        Me.colToSeeDoctor.ReadOnly = True
        '
        'colBillMode
        '
        Me.colBillMode.DataPropertyName = "BillMode"
        Me.colBillMode.HeaderText = "To-Bill Mode"
        Me.colBillMode.Name = "colBillMode"
        Me.colBillMode.ReadOnly = True
        Me.colBillMode.Width = 80
        '
        'colBillCustomerName
        '
        Me.colBillCustomerName.DataPropertyName = "BillCustomerName"
        Me.colBillCustomerName.HeaderText = "To-Bill Customer Name"
        Me.colBillCustomerName.Name = "colBillCustomerName"
        Me.colBillCustomerName.ReadOnly = True
        Me.colBillCustomerName.Width = 120
        '
        'colInsuranceName
        '
        Me.colInsuranceName.DataPropertyName = "InsuranceName"
        Me.colInsuranceName.HeaderText = "To-Bill Insurance Name"
        Me.colInsuranceName.Name = "colInsuranceName"
        Me.colInsuranceName.ReadOnly = True
        '
        'colLoginID
        '
        Me.colLoginID.DataPropertyName = "LoginID"
        Me.colLoginID.HeaderText = "Login ID"
        Me.colLoginID.Name = "colLoginID"
        Me.colLoginID.ReadOnly = True
        Me.colLoginID.Width = 80
        '
        'colVisitCategory
        '
        Me.colVisitCategory.DataPropertyName = "VisitCategory"
        Me.colVisitCategory.HeaderText = "Visit Category"
        Me.colVisitCategory.Name = "colVisitCategory"
        Me.colVisitCategory.ReadOnly = True
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
        Me.lblMessage.Location = New System.Drawing.Point(318, 283)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(301, 20)
        Me.lblMessage.TabIndex = 1
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRefresh
        '
        Me.btnRefresh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRefresh.Location = New System.Drawing.Point(8, 279)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(80, 24)
        Me.btnRefresh.TabIndex = 22
        Me.btnRefresh.Tag = ""
        Me.btnRefresh.Text = "&Refresh"
        '
        'fbnCall
        '
        Me.fbnCall.Enabled = False
        Me.fbnCall.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnCall.Location = New System.Drawing.Point(885, 4)
        Me.fbnCall.Name = "fbnCall"
        Me.fbnCall.Size = New System.Drawing.Size(76, 22)
        Me.fbnCall.TabIndex = 23
        Me.fbnCall.Text = "Enqueue"
        Me.fbnCall.Visible = False
        '
        'frmPendingVisitFiles
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(973, 315)
        Me.Controls.Add(Me.fbnCall)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvPendingVisitFiles)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.KeyPreview = true
        Me.MinimizeBox = false
        Me.Name = "frmPendingVisitFiles"
        Me.Text = "Pending Visit Files List"
        CType(Me.dgvPendingVisitFiles,System.ComponentModel.ISupportInitialize).EndInit
        Me.cmsAlertList.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvPendingVisitFiles As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents fbnCall As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFirstName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPriority As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colReferenceNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColReturnedBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colToSeeSpecialty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colToSeeDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillMode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBillCustomerName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colInsuranceName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLoginID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitCategory As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn

End Class