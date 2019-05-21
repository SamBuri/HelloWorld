
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGetExternalLabResults : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal itemCode As String, ByVal importDataInfo As DataTable, ByVal specimenNo As String)
        MyClass.New()
        Me._ItemCode = itemCode
        Me._ImportDataInfo = importDataInfo
        Me._SpecimenNo = specimenNo
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGetExternalLabResults))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dgvExternalLabResults = New System.Windows.Forms.DataGridView()
        Me.cmsAlertList = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsAlertListCopy = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsAlertListSelectAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.grpSetParameters = New System.Windows.Forms.GroupBox()
        Me.cboImportSource = New System.Windows.Forms.ComboBox()
        Me.lblImportSource = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDateTime = New System.Windows.Forms.Label()
        Me.dtpStartDateTime = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDateTime = New System.Windows.Forms.Label()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.fbnLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.colTestDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSpecimenNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colResults = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stbSpecimenNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSpecimenNo = New System.Windows.Forms.Label()
        CType(Me.dgvExternalLabResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsAlertList.SuspendLayout()
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
        Me.fbnClose.Location = New System.Drawing.Point(1068, 614)
        Me.fbnClose.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(96, 30)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'dgvExternalLabResults
        '
        Me.dgvExternalLabResults.AllowUserToAddRows = False
        Me.dgvExternalLabResults.AllowUserToDeleteRows = False
        Me.dgvExternalLabResults.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvExternalLabResults.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvExternalLabResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvExternalLabResults.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvExternalLabResults.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvExternalLabResults.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvExternalLabResults.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExternalLabResults.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvExternalLabResults.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTestDate, Me.colTestTime, Me.colSpecimenNo, Me.colPatientNo, Me.colFullName, Me.colResults})
        Me.dgvExternalLabResults.ContextMenuStrip = Me.cmsAlertList
        Me.dgvExternalLabResults.EnableHeadersVisualStyles = False
        Me.dgvExternalLabResults.GridColor = System.Drawing.Color.Khaki
        Me.dgvExternalLabResults.Location = New System.Drawing.Point(11, 131)
        Me.dgvExternalLabResults.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dgvExternalLabResults.Name = "dgvExternalLabResults"
        Me.dgvExternalLabResults.ReadOnly = True
        Me.dgvExternalLabResults.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvExternalLabResults.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvExternalLabResults.RowHeadersVisible = False
        Me.dgvExternalLabResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvExternalLabResults.Size = New System.Drawing.Size(1153, 472)
        Me.dgvExternalLabResults.TabIndex = 1
        Me.dgvExternalLabResults.Text = "DataGridView1"
        '
        'cmsAlertList
        '
        Me.cmsAlertList.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsAlertList.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsAlertListCopy, Me.cmsAlertListSelectAll})
        Me.cmsAlertList.Name = "cmsSearch"
        Me.cmsAlertList.Size = New System.Drawing.Size(141, 52)
        '
        'cmsAlertListCopy
        '
        Me.cmsAlertListCopy.Enabled = False
        Me.cmsAlertListCopy.Image = CType(resources.GetObject("cmsAlertListCopy.Image"), System.Drawing.Image)
        Me.cmsAlertListCopy.Name = "cmsAlertListCopy"
        Me.cmsAlertListCopy.Size = New System.Drawing.Size(140, 24)
        Me.cmsAlertListCopy.Text = "Copy"
        Me.cmsAlertListCopy.ToolTipText = "To copy with column headings, use Ctrl+C key combination"
        '
        'cmsAlertListSelectAll
        '
        Me.cmsAlertListSelectAll.Enabled = False
        Me.cmsAlertListSelectAll.Name = "cmsAlertListSelectAll"
        Me.cmsAlertListSelectAll.Size = New System.Drawing.Size(140, 24)
        Me.cmsAlertListSelectAll.Text = "Select All"
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblMessage.Location = New System.Drawing.Point(364, 619)
        Me.lblMessage.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(401, 25)
        Me.lblMessage.TabIndex = 2
        Me.lblMessage.Text = "Hint: double click to quickly select"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grpSetParameters
        '
        Me.grpSetParameters.Controls.Add(Me.stbSpecimenNo)
        Me.grpSetParameters.Controls.Add(Me.lblSpecimenNo)
        Me.grpSetParameters.Controls.Add(Me.cboImportSource)
        Me.grpSetParameters.Controls.Add(Me.lblImportSource)
        Me.grpSetParameters.Controls.Add(Me.pnlPeriod)
        Me.grpSetParameters.Controls.Add(Me.lblRecordsNo)
        Me.grpSetParameters.Controls.Add(Me.fbnLoad)
        Me.grpSetParameters.Location = New System.Drawing.Point(9, 5)
        Me.grpSetParameters.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpSetParameters.Name = "grpSetParameters"
        Me.grpSetParameters.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.grpSetParameters.Size = New System.Drawing.Size(1109, 118)
        Me.grpSetParameters.TabIndex = 0
        Me.grpSetParameters.TabStop = False
        Me.grpSetParameters.Text = "Result Date and Time Period"
        '
        'cboImportSource
        '
        Me.cboImportSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboImportSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboImportSource.Location = New System.Drawing.Point(276, 18)
        Me.cboImportSource.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cboImportSource.Name = "cboImportSource"
        Me.cboImportSource.Size = New System.Drawing.Size(292, 24)
        Me.cboImportSource.TabIndex = 1
        '
        'lblImportSource
        '
        Me.lblImportSource.Location = New System.Drawing.Point(29, 21)
        Me.lblImportSource.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblImportSource.Name = "lblImportSource"
        Me.lblImportSource.Size = New System.Drawing.Size(239, 25)
        Me.lblImportSource.TabIndex = 0
        Me.lblImportSource.Text = "Import Source"
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblStartDateTime)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDateTime)
        Me.pnlPeriod.Controls.Add(Me.lblEndDateTime)
        Me.pnlPeriod.Location = New System.Drawing.Point(12, 74)
        Me.pnlPeriod.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(933, 38)
        Me.pnlPeriod.TabIndex = 5
        '
        'dtpEndDateTime
        '
        Me.dtpEndDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpEndDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpEndDateTime.Location = New System.Drawing.Point(669, 6)
        Me.dtpEndDateTime.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpEndDateTime.Name = "dtpEndDateTime"
        Me.dtpEndDateTime.ShowCheckBox = True
        Me.dtpEndDateTime.Size = New System.Drawing.Size(251, 22)
        Me.dtpEndDateTime.TabIndex = 3
        '
        'lblStartDateTime
        '
        Me.lblStartDateTime.Location = New System.Drawing.Point(13, 6)
        Me.lblStartDateTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStartDateTime.Name = "lblStartDateTime"
        Me.lblStartDateTime.Size = New System.Drawing.Size(183, 25)
        Me.lblStartDateTime.TabIndex = 0
        Me.lblStartDateTime.Text = "Start Record Date && Time"
        Me.lblStartDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDateTime
        '
        Me.dtpStartDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.dtpStartDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpStartDateTime.Location = New System.Drawing.Point(204, 6)
        Me.dtpStartDateTime.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dtpStartDateTime.Name = "dtpStartDateTime"
        Me.dtpStartDateTime.ShowCheckBox = True
        Me.dtpStartDateTime.Size = New System.Drawing.Size(251, 22)
        Me.dtpStartDateTime.TabIndex = 1
        '
        'lblEndDateTime
        '
        Me.lblEndDateTime.Location = New System.Drawing.Point(476, 6)
        Me.lblEndDateTime.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEndDateTime.Name = "lblEndDateTime"
        Me.lblEndDateTime.Size = New System.Drawing.Size(185, 25)
        Me.lblEndDateTime.TabIndex = 2
        Me.lblEndDateTime.Text = "End Record Date && Time"
        Me.lblEndDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(577, 23)
        Me.lblRecordsNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(364, 16)
        Me.lblRecordsNo.TabIndex = 2
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'fbnLoad
        '
        Me.fbnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoad.Location = New System.Drawing.Point(953, 76)
        Me.fbnLoad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.fbnLoad.Name = "fbnLoad"
        Me.fbnLoad.Size = New System.Drawing.Size(141, 34)
        Me.fbnLoad.TabIndex = 6
        Me.fbnLoad.Text = "Load..."
        '
        'colTestDate
        '
        Me.colTestDate.DataPropertyName = "TestDate"
        Me.colTestDate.HeaderText = "Test Date"
        Me.colTestDate.Name = "colTestDate"
        Me.colTestDate.ReadOnly = True
        Me.colTestDate.Width = 90
        '
        'colTestTime
        '
        Me.colTestTime.DataPropertyName = "TestTime"
        Me.colTestTime.HeaderText = "Test Time"
        Me.colTestTime.Name = "colTestTime"
        Me.colTestTime.ReadOnly = True
        Me.colTestTime.Width = 80
        '
        'colSpecimenNo
        '
        Me.colSpecimenNo.DataPropertyName = "SpecimenNo"
        Me.colSpecimenNo.HeaderText = "Specimen No"
        Me.colSpecimenNo.Name = "colSpecimenNo"
        Me.colSpecimenNo.ReadOnly = True
        Me.colSpecimenNo.Width = 110
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
        Me.colFullName.Width = 150
        '
        'colResults
        '
        Me.colResults.DataPropertyName = "Results"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.colResults.DefaultCellStyle = DataGridViewCellStyle3
        Me.colResults.HeaderText = "Results"
        Me.colResults.Name = "colResults"
        Me.colResults.ReadOnly = True
        Me.colResults.Width = 400
        '
        'stbSpecimenNo
        '
        Me.stbSpecimenNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSpecimenNo.CapitalizeFirstLetter = False
        Me.stbSpecimenNo.EntryErrorMSG = ""
        Me.stbSpecimenNo.Location = New System.Drawing.Point(411, 46)
        Me.stbSpecimenNo.Margin = New System.Windows.Forms.Padding(4)
        Me.stbSpecimenNo.MaxLength = 20
        Me.stbSpecimenNo.Name = "stbSpecimenNo"
        Me.stbSpecimenNo.RegularExpression = ""
        Me.stbSpecimenNo.Size = New System.Drawing.Size(157, 22)
        Me.stbSpecimenNo.TabIndex = 4
        '
        'lblSpecimenNo
        '
        Me.lblSpecimenNo.Location = New System.Drawing.Point(29, 48)
        Me.lblSpecimenNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSpecimenNo.Name = "lblSpecimenNo"
        Me.lblSpecimenNo.Size = New System.Drawing.Size(374, 25)
        Me.lblSpecimenNo.TabIndex = 3
        Me.lblSpecimenNo.Text = "Specimen No Contains (Leave blank or use ‘*’ for all)"
        '
        'frmGetExternalLabResults
        '
        Me.AcceptButton = Me.fbnLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(1177, 659)
        Me.Controls.Add(Me.grpSetParameters)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.dgvExternalLabResults)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmGetExternalLabResults"
        Me.Tag = ""
        Me.Text = "External Lab Results"
        CType(Me.dgvExternalLabResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsAlertList.ResumeLayout(False)
        Me.grpSetParameters.ResumeLayout(False)
        Me.grpSetParameters.PerformLayout()
        Me.pnlPeriod.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dgvExternalLabResults As System.Windows.Forms.DataGridView
    Friend WithEvents cmsAlertList As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsAlertListCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsAlertListSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents grpSetParameters As System.Windows.Forms.GroupBox
    Friend WithEvents fbnLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dtpEndDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDateTime As System.Windows.Forms.Label
    Friend WithEvents dtpStartDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDateTime As System.Windows.Forms.Label
    Friend WithEvents cboImportSource As System.Windows.Forms.ComboBox
    Friend WithEvents lblImportSource As System.Windows.Forms.Label
    Friend WithEvents colTestDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSpecimenNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colResults As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stbSpecimenNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSpecimenNo As System.Windows.Forms.Label

End Class