<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSMSScheduling
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSMSScheduling))
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.fbnLoadIncomeItems = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.grpLabResultsEXT = New System.Windows.Forms.GroupBox()
        Me.dgvSMSReminders = New System.Windows.Forms.DataGridView()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.colReason = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colDateandTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grpLabResultsEXT.SuspendLayout()
        CType(Me.dgvSMSReminders, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(138, 12)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(174, 20)
        Me.stbFullName.TabIndex = 16
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(10, 12)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(120, 20)
        Me.lblFullName.TabIndex = 15
        Me.lblFullName.Text = "Patient's First Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(138, 33)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(174, 20)
        Me.stbPatientNo.TabIndex = 18
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(10, 33)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(120, 20)
        Me.lblPatientsNo.TabIndex = 17
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'fbnLoadIncomeItems
        '
        Me.fbnLoadIncomeItems.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.fbnLoadIncomeItems.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnLoadIncomeItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnLoadIncomeItems.Location = New System.Drawing.Point(318, 8)
        Me.fbnLoadIncomeItems.Name = "fbnLoadIncomeItems"
        Me.fbnLoadIncomeItems.Size = New System.Drawing.Size(70, 24)
        Me.fbnLoadIncomeItems.TabIndex = 19
        Me.fbnLoadIncomeItems.Text = "Load"
        '
        'grpLabResultsEXT
        '
        Me.grpLabResultsEXT.Controls.Add(Me.dgvSMSReminders)
        Me.grpLabResultsEXT.Location = New System.Drawing.Point(10, 62)
        Me.grpLabResultsEXT.Name = "grpLabResultsEXT"
        Me.grpLabResultsEXT.Size = New System.Drawing.Size(608, 235)
        Me.grpLabResultsEXT.TabIndex = 39
        Me.grpLabResultsEXT.TabStop = False
        Me.grpLabResultsEXT.Text = "SMS Reminders"
        '
        'dgvSMSReminders
        '
        Me.dgvSMSReminders.AllowUserToOrderColumns = True
        Me.dgvSMSReminders.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSMSReminders.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSMSReminders.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colReason, Me.colDateandTime, Me.ColTime})
        Me.dgvSMSReminders.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSMSReminders.EnableHeadersVisualStyles = False
        Me.dgvSMSReminders.GridColor = System.Drawing.Color.Khaki
        Me.dgvSMSReminders.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvSMSReminders.Location = New System.Drawing.Point(3, 16)
        Me.dgvSMSReminders.Name = "dgvSMSReminders"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvSMSReminders.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSMSReminders.Size = New System.Drawing.Size(602, 216)
        Me.dgvSMSReminders.TabIndex = 0
        Me.dgvSMSReminders.Text = "DataGridView1"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(12, 305)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 42
        Me.btnSearch.Text = "Sc&hedule"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(537, 305)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 43
        Me.ebnSaveUpdate.Tag = ""
        Me.ebnSaveUpdate.Text = "&Close"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'colReason
        '
        Me.colReason.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colReason.DisplayStyleForCurrentCellOnly = True
        Me.colReason.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colReason.HeaderText = "Reason"
        Me.colReason.Name = "colReason"
        Me.colReason.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colReason.Width = 250
        '
        'colDateandTime
        '
        Me.colDateandTime.HeaderText = "Date"
        Me.colDateandTime.MaxInputLength = 200
        Me.colDateandTime.Name = "colDateandTime"
        Me.colDateandTime.Width = 200
        '
        'ColTime
        '
        Me.ColTime.HeaderText = "Time"
        Me.ColTime.Name = "ColTime"
        '
        'frmSMSScheduling
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(626, 340)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.grpLabResultsEXT)
        Me.Controls.Add(Me.fbnLoadIncomeItems)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSMSScheduling"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SMS Reminders"
        Me.grpLabResultsEXT.ResumeLayout(False)
        CType(Me.dgvSMSReminders, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents fbnLoadIncomeItems As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents grpLabResultsEXT As System.Windows.Forms.GroupBox
    Friend WithEvents dgvSMSReminders As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents colReason As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colDateandTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
