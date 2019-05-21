
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQueues : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmQueues))
        Me.stbCurrentPatient = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dgvQueues = New System.Windows.Forms.DataGridView()
        Me.colPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTokenNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colServicePoint = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tmrQueues = New System.Windows.Forms.Timer(Me.components)
        CType(Me.dgvQueues, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbCurrentPatient
        '
        Me.stbCurrentPatient.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stbCurrentPatient.BackColor = System.Drawing.Color.Peru
        Me.stbCurrentPatient.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCurrentPatient.CapitalizeFirstLetter = False
        Me.stbCurrentPatient.Enabled = False
        Me.stbCurrentPatient.EntryErrorMSG = ""
        Me.stbCurrentPatient.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbCurrentPatient.ForeColor = System.Drawing.Color.White
        Me.stbCurrentPatient.Location = New System.Drawing.Point(12, 2)
        Me.stbCurrentPatient.Multiline = True
        Me.stbCurrentPatient.Name = "stbCurrentPatient"
        Me.stbCurrentPatient.ReadOnly = True
        Me.stbCurrentPatient.RegularExpression = ""
        Me.stbCurrentPatient.Size = New System.Drawing.Size(919, 85)
        Me.stbCurrentPatient.TabIndex = 6
        Me.stbCurrentPatient.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvQueues
        '
        Me.dgvQueues.AllowUserToAddRows = False
        Me.dgvQueues.AllowUserToDeleteRows = False
        Me.dgvQueues.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvQueues.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvQueues.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvQueues.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvQueues.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvQueues.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvQueues.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQueues.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvQueues.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colPatientNo, Me.colTokenNo, Me.colVisitNo, Me.colFullName, Me.colServicePoint})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvQueues.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvQueues.EnableHeadersVisualStyles = False
        Me.dgvQueues.GridColor = System.Drawing.Color.Khaki
        Me.dgvQueues.Location = New System.Drawing.Point(12, 93)
        Me.dgvQueues.Name = "dgvQueues"
        Me.dgvQueues.ReadOnly = True
        Me.dgvQueues.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvQueues.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvQueues.RowHeadersVisible = False
        Me.dgvQueues.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvQueues.Size = New System.Drawing.Size(919, 350)
        Me.dgvQueues.TabIndex = 14
        Me.dgvQueues.Text = "DataGridView1"
        '
        'colPatientNo
        '
        Me.colPatientNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colPatientNo.DataPropertyName = "PatientNo"
        Me.colPatientNo.HeaderText = "Patient No"
        Me.colPatientNo.Name = "colPatientNo"
        Me.colPatientNo.ReadOnly = True
        '
        'colTokenNo
        '
        Me.colTokenNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colTokenNo.DataPropertyName = "TokenNo"
        Me.colTokenNo.HeaderText = "Token No"
        Me.colTokenNo.Name = "colTokenNo"
        Me.colTokenNo.ReadOnly = True
        '
        'colVisitNo
        '
        Me.colVisitNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colVisitNo.DataPropertyName = "VisitNo"
        Me.colVisitNo.HeaderText = "Visit No"
        Me.colVisitNo.Name = "colVisitNo"
        Me.colVisitNo.ReadOnly = True
        '
        'colFullName
        '
        Me.colFullName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colFullName.DataPropertyName = "FirstName"
        Me.colFullName.HeaderText = "First Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        '
        'colServicePoint
        '
        Me.colServicePoint.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.colServicePoint.DataPropertyName = "ServicePoint"
        Me.colServicePoint.HeaderText = "Service Point"
        Me.colServicePoint.Name = "colServicePoint"
        Me.colServicePoint.ReadOnly = True
        '
        'tmrQueues
        '
        Me.tmrQueues.Enabled = True
        Me.tmrQueues.Interval = 5000
        '
        'frmQueues
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.ClientSize = New System.Drawing.Size(933, 447)
        Me.Controls.Add(Me.dgvQueues)
        Me.Controls.Add(Me.stbCurrentPatient)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmQueues"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Queue"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.dgvQueues, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbCurrentPatient As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dgvQueues As DataGridView
    Friend WithEvents tmrQueues As Timer
    Friend WithEvents colPatientNo As DataGridViewTextBoxColumn
    Friend WithEvents colTokenNo As DataGridViewTextBoxColumn
    Friend WithEvents colVisitNo As DataGridViewTextBoxColumn
    Friend WithEvents colFullName As DataGridViewTextBoxColumn
    Friend WithEvents colServicePoint As DataGridViewTextBoxColumn
End Class