<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBirthdays
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBirthdays))
        Me.dgvBirthdays = New System.Windows.Forms.DataGridView()
        Me.ColInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ColPatientNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFirstName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPhone = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colBirthDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.dgvBirthdays, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvBirthdays
        '
        Me.dgvBirthdays.AllowUserToAddRows = False
        Me.dgvBirthdays.AllowUserToDeleteRows = False
        Me.dgvBirthdays.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvBirthdays.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvBirthdays.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvBirthdays.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvBirthdays.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvBirthdays.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvBirthdays.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBirthdays.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvBirthdays.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColInclude, Me.ColPatientNo, Me.colFirstName, Me.colPhone, Me.colBirthDate})
        Me.dgvBirthdays.EnableHeadersVisualStyles = False
        Me.dgvBirthdays.GridColor = System.Drawing.Color.Khaki
        Me.dgvBirthdays.Location = New System.Drawing.Point(3, 12)
        Me.dgvBirthdays.Name = "dgvBirthdays"
        Me.dgvBirthdays.ReadOnly = True
        Me.dgvBirthdays.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvBirthdays.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvBirthdays.RowHeadersVisible = False
        Me.dgvBirthdays.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvBirthdays.Size = New System.Drawing.Size(623, 287)
        Me.dgvBirthdays.TabIndex = 5
        Me.dgvBirthdays.Text = "DataGridView1"
        '
        'ColInclude
        '
        Me.ColInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColInclude.HeaderText = "sms"
        Me.ColInclude.Name = "ColInclude"
        Me.ColInclude.ReadOnly = True
        Me.ColInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColInclude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.ColInclude.TrueValue = ""
        Me.ColInclude.Width = 50
        '
        'ColPatientNo
        '
        Me.ColPatientNo.DataPropertyName = "PatientNo"
        Me.ColPatientNo.HeaderText = "Patient No"
        Me.ColPatientNo.Name = "ColPatientNo"
        Me.ColPatientNo.ReadOnly = True
        '
        'colFirstName
        '
        Me.colFirstName.DataPropertyName = "FirstName"
        Me.colFirstName.HeaderText = "First Name"
        Me.colFirstName.Name = "colFirstName"
        Me.colFirstName.ReadOnly = True
        Me.colFirstName.Width = 150
        '
        'colPhone
        '
        Me.colPhone.DataPropertyName = "Phone"
        Me.colPhone.HeaderText = "Phone Number"
        Me.colPhone.Name = "colPhone"
        Me.colPhone.ReadOnly = True
        '
        'colBirthDate
        '
        Me.colBirthDate.DataPropertyName = "dob"
        Me.colBirthDate.HeaderText = "Birth Date"
        Me.colBirthDate.Name = "colBirthDate"
        Me.colBirthDate.ReadOnly = True
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(547, 315)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 6
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'frmBirthdays
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(638, 354)
        Me.Controls.Add(Me.dgvBirthdays)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmBirthdays"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Birthdays"
        CType(Me.dgvBirthdays, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvBirthdays As System.Windows.Forms.DataGridView
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ColInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents ColPatientNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFirstName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPhone As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colBirthDate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
