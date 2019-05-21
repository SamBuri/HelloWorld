
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBillCustomerMembers : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBillCustomerMembers))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbSurname = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbFirstName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbMiddleName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpPolicyStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpPolicyEndDate = New System.Windows.Forms.DateTimePicker()
        Me.fcbStatusID = New SyncSoft.Common.Win.Controls.FlatComboBox()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.nbxCreditLimit = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblMedicalCardNo = New System.Windows.Forms.Label()
        Me.lblSurname = New System.Windows.Forms.Label()
        Me.lblFirstName = New System.Windows.Forms.Label()
        Me.lblMiddleName = New System.Windows.Forms.Label()
        Me.lblPolicyStartDate = New System.Windows.Forms.Label()
        Me.lblPolicyEndDate = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.lblStatusID = New System.Windows.Forms.Label()
        Me.cboAccountNo = New System.Windows.Forms.ComboBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.lblCreditLimit = New System.Windows.Forms.Label()
        Me.tbcBillCustomerMemberLimits = New System.Windows.Forms.TabControl()
        Me.tpgMemberLimits = New System.Windows.Forms.TabPage()
        Me.dgvMemberLimits = New System.Windows.Forms.DataGridView()
        Me.colBenefitCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colMemberLimit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colMemberLimitsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.cboMedicalCardNo = New System.Windows.Forms.ComboBox()
        Me.tbcBillCustomerMemberLimits.SuspendLayout()
        Me.tpgMemberLimits.SuspendLayout()
        CType(Me.dgvMemberLimits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 428)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 20
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(341, 428)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 21
        Me.fbnDelete.Tag = "BillCustomerMembers"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 455)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 22
        Me.ebnSaveUpdate.Tag = "BillCustomerMembers"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbSurname
        '
        Me.stbSurname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSurname.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbSurname, "Surname")
        Me.stbSurname.EntryErrorMSG = ""
        Me.stbSurname.Location = New System.Drawing.Point(164, 85)
        Me.stbSurname.MaxLength = 20
        Me.stbSurname.Name = "stbSurname"
        Me.stbSurname.RegularExpression = ""
        Me.stbSurname.Size = New System.Drawing.Size(170, 20)
        Me.stbSurname.TabIndex = 7
        '
        'stbFirstName
        '
        Me.stbFirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFirstName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbFirstName, "FirstName")
        Me.stbFirstName.EntryErrorMSG = ""
        Me.stbFirstName.Location = New System.Drawing.Point(164, 106)
        Me.stbFirstName.MaxLength = 20
        Me.stbFirstName.Name = "stbFirstName"
        Me.stbFirstName.RegularExpression = ""
        Me.stbFirstName.Size = New System.Drawing.Size(170, 20)
        Me.stbFirstName.TabIndex = 9
        '
        'stbMiddleName
        '
        Me.stbMiddleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMiddleName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbMiddleName, "MiddleName")
        Me.stbMiddleName.EntryErrorMSG = ""
        Me.stbMiddleName.Location = New System.Drawing.Point(164, 127)
        Me.stbMiddleName.MaxLength = 20
        Me.stbMiddleName.Name = "stbMiddleName"
        Me.stbMiddleName.RegularExpression = ""
        Me.stbMiddleName.Size = New System.Drawing.Size(170, 20)
        Me.stbMiddleName.TabIndex = 11
        '
        'dtpPolicyStartDate
        '
        Me.dtpPolicyStartDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpPolicyStartDate, "PolicyStartDate")
        Me.dtpPolicyStartDate.Location = New System.Drawing.Point(164, 148)
        Me.dtpPolicyStartDate.Name = "dtpPolicyStartDate"
        Me.dtpPolicyStartDate.ShowCheckBox = True
        Me.dtpPolicyStartDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpPolicyStartDate.TabIndex = 13
        '
        'dtpPolicyEndDate
        '
        Me.dtpPolicyEndDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpPolicyEndDate, "PolicyEndDate")
        Me.dtpPolicyEndDate.Location = New System.Drawing.Point(164, 169)
        Me.dtpPolicyEndDate.Name = "dtpPolicyEndDate"
        Me.dtpPolicyEndDate.ShowCheckBox = True
        Me.dtpPolicyEndDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpPolicyEndDate.TabIndex = 15
        '
        'fcbStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.fcbStatusID, "MemberStatus,MemberStatusID")
        Me.fcbStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.fcbStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fcbStatusID.FormattingEnabled = True
        Me.fcbStatusID.Location = New System.Drawing.Point(164, 212)
        Me.fcbStatusID.Name = "fcbStatusID"
        Me.fcbStatusID.ReadOnly = True
        Me.fcbStatusID.Size = New System.Drawing.Size(170, 21)
        Me.fcbStatusID.TabIndex = 19
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbBillCustomerName, "BillCustomerName")
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(164, 48)
        Me.stbBillCustomerName.MaxLength = 40
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(170, 36)
        Me.stbBillCustomerName.TabIndex = 5
        '
        'nbxCreditLimit
        '
        Me.nbxCreditLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCreditLimit.ControlCaption = "Credit Limit"
        Me.nbxCreditLimit.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCreditLimit, "CreditLimit")
        Me.nbxCreditLimit.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCreditLimit.DecimalPlaces = 2
        Me.nbxCreditLimit.Location = New System.Drawing.Point(164, 190)
        Me.nbxCreditLimit.MaxLength = 12
        Me.nbxCreditLimit.MaxValue = 0.0R
        Me.nbxCreditLimit.MinValue = 0.0R
        Me.nbxCreditLimit.MustEnterNumeric = True
        Me.nbxCreditLimit.Name = "nbxCreditLimit"
        Me.nbxCreditLimit.Size = New System.Drawing.Size(170, 20)
        Me.nbxCreditLimit.TabIndex = 17
        Me.nbxCreditLimit.Value = ""
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(341, 455)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 23
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblMedicalCardNo
        '
        Me.lblMedicalCardNo.Location = New System.Drawing.Point(12, 5)
        Me.lblMedicalCardNo.Name = "lblMedicalCardNo"
        Me.lblMedicalCardNo.Size = New System.Drawing.Size(146, 20)
        Me.lblMedicalCardNo.TabIndex = 0
        Me.lblMedicalCardNo.Text = "Medical Card No"
        '
        'lblSurname
        '
        Me.lblSurname.Location = New System.Drawing.Point(12, 85)
        Me.lblSurname.Name = "lblSurname"
        Me.lblSurname.Size = New System.Drawing.Size(146, 20)
        Me.lblSurname.TabIndex = 6
        Me.lblSurname.Text = "Surname"
        '
        'lblFirstName
        '
        Me.lblFirstName.Location = New System.Drawing.Point(12, 106)
        Me.lblFirstName.Name = "lblFirstName"
        Me.lblFirstName.Size = New System.Drawing.Size(146, 20)
        Me.lblFirstName.TabIndex = 8
        Me.lblFirstName.Text = "First Name"
        '
        'lblMiddleName
        '
        Me.lblMiddleName.Location = New System.Drawing.Point(12, 127)
        Me.lblMiddleName.Name = "lblMiddleName"
        Me.lblMiddleName.Size = New System.Drawing.Size(146, 20)
        Me.lblMiddleName.TabIndex = 10
        Me.lblMiddleName.Text = "Middle Name"
        '
        'lblPolicyStartDate
        '
        Me.lblPolicyStartDate.Location = New System.Drawing.Point(12, 148)
        Me.lblPolicyStartDate.Name = "lblPolicyStartDate"
        Me.lblPolicyStartDate.Size = New System.Drawing.Size(146, 20)
        Me.lblPolicyStartDate.TabIndex = 12
        Me.lblPolicyStartDate.Text = "Policy Start Date"
        '
        'lblPolicyEndDate
        '
        Me.lblPolicyEndDate.Location = New System.Drawing.Point(12, 169)
        Me.lblPolicyEndDate.Name = "lblPolicyEndDate"
        Me.lblPolicyEndDate.Size = New System.Drawing.Size(146, 20)
        Me.lblPolicyEndDate.TabIndex = 14
        Me.lblPolicyEndDate.Text = "Policy End Date"
        '
        'cboLoginID
        '
        Me.cboLoginID.Location = New System.Drawing.Point(0, 0)
        Me.cboLoginID.Name = "cboLoginID"
        Me.cboLoginID.Size = New System.Drawing.Size(121, 21)
        Me.cboLoginID.TabIndex = 0
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(0, 0)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(100, 23)
        Me.lblLoginID.TabIndex = 0
        '
        'lblStatusID
        '
        Me.lblStatusID.Location = New System.Drawing.Point(12, 211)
        Me.lblStatusID.Name = "lblStatusID"
        Me.lblStatusID.Size = New System.Drawing.Size(146, 20)
        Me.lblStatusID.TabIndex = 18
        Me.lblStatusID.Text = "Member Status"
        '
        'cboAccountNo
        '
        Me.cboAccountNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboAccountNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboAccountNo.DropDownWidth = 300
        Me.cboAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountNo.FormattingEnabled = True
        Me.cboAccountNo.Location = New System.Drawing.Point(164, 26)
        Me.cboAccountNo.MaxLength = 40
        Me.cboAccountNo.Name = "cboAccountNo"
        Me.cboAccountNo.Size = New System.Drawing.Size(170, 21)
        Me.cboAccountNo.TabIndex = 3
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(12, 54)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(146, 20)
        Me.lblBillCustomerName.TabIndex = 4
        Me.lblBillCustomerName.Text = "To-Bill Customer Name"
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(12, 28)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(146, 20)
        Me.lblAccountNo.TabIndex = 2
        Me.lblAccountNo.Text = "To-Bill Account No"
        '
        'lblCreditLimit
        '
        Me.lblCreditLimit.Location = New System.Drawing.Point(12, 191)
        Me.lblCreditLimit.Name = "lblCreditLimit"
        Me.lblCreditLimit.Size = New System.Drawing.Size(146, 20)
        Me.lblCreditLimit.TabIndex = 16
        Me.lblCreditLimit.Text = "Credit Limit"
        '
        'tbcBillCustomerMemberLimits
        '
        Me.tbcBillCustomerMemberLimits.Controls.Add(Me.tpgMemberLimits)
        Me.tbcBillCustomerMemberLimits.HotTrack = True
        Me.tbcBillCustomerMemberLimits.Location = New System.Drawing.Point(12, 239)
        Me.tbcBillCustomerMemberLimits.Name = "tbcBillCustomerMemberLimits"
        Me.tbcBillCustomerMemberLimits.SelectedIndex = 0
        Me.tbcBillCustomerMemberLimits.Size = New System.Drawing.Size(401, 183)
        Me.tbcBillCustomerMemberLimits.TabIndex = 26
        '
        'tpgMemberLimits
        '
        Me.tpgMemberLimits.Controls.Add(Me.dgvMemberLimits)
        Me.tpgMemberLimits.Location = New System.Drawing.Point(4, 22)
        Me.tpgMemberLimits.Name = "tpgMemberLimits"
        Me.tpgMemberLimits.Size = New System.Drawing.Size(393, 157)
        Me.tpgMemberLimits.TabIndex = 6
        Me.tpgMemberLimits.Tag = "MemberLimits"
        Me.tpgMemberLimits.Text = "Member Limits"
        Me.tpgMemberLimits.UseVisualStyleBackColor = True
        '
        'dgvMemberLimits
        '
        Me.dgvMemberLimits.AllowUserToOrderColumns = True
        Me.dgvMemberLimits.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMemberLimits.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMemberLimits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBenefitCode, Me.colMemberLimit, Me.colMemberLimitsSaved})
        Me.dgvMemberLimits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvMemberLimits.EnableHeadersVisualStyles = False
        Me.dgvMemberLimits.GridColor = System.Drawing.Color.Khaki
        Me.dgvMemberLimits.Location = New System.Drawing.Point(0, 0)
        Me.dgvMemberLimits.Name = "dgvMemberLimits"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMemberLimits.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMemberLimits.Size = New System.Drawing.Size(393, 157)
        Me.dgvMemberLimits.TabIndex = 0
        Me.dgvMemberLimits.Text = "DataGridView1"
        '
        'colBenefitCode
        '
        Me.colBenefitCode.DataPropertyName = "BenefitCode"
        Me.colBenefitCode.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox
        Me.colBenefitCode.DisplayStyleForCurrentCellOnly = True
        Me.colBenefitCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colBenefitCode.HeaderText = "Benefit Name"
        Me.colBenefitCode.Name = "colBenefitCode"
        Me.colBenefitCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colBenefitCode.Width = 180
        '
        'colMemberLimit
        '
        Me.colMemberLimit.DataPropertyName = "MemberLimit"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colMemberLimit.DefaultCellStyle = DataGridViewCellStyle2
        Me.colMemberLimit.HeaderText = "Member Limit"
        Me.colMemberLimit.Name = "colMemberLimit"
        Me.colMemberLimit.Width = 90
        '
        'colMemberLimitsSaved
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.NullValue = False
        Me.colMemberLimitsSaved.DefaultCellStyle = DataGridViewCellStyle3
        Me.colMemberLimitsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colMemberLimitsSaved.HeaderText = "Saved"
        Me.colMemberLimitsSaved.Name = "colMemberLimitsSaved"
        Me.colMemberLimitsSaved.ReadOnly = True
        Me.colMemberLimitsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colMemberLimitsSaved.Width = 50
        '
        'cboMedicalCardNo
        '
        Me.cboMedicalCardNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMedicalCardNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMedicalCardNo.DropDownWidth = 300
        Me.cboMedicalCardNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMedicalCardNo.FormattingEnabled = True
        Me.cboMedicalCardNo.Location = New System.Drawing.Point(164, 4)
        Me.cboMedicalCardNo.MaxLength = 40
        Me.cboMedicalCardNo.Name = "cboMedicalCardNo"
        Me.cboMedicalCardNo.Size = New System.Drawing.Size(170, 21)
        Me.cboMedicalCardNo.TabIndex = 1
        '
        'frmBillCustomerMembers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(425, 492)
        Me.Controls.Add(Me.cboMedicalCardNo)
        Me.Controls.Add(Me.tbcBillCustomerMemberLimits)
        Me.Controls.Add(Me.nbxCreditLimit)
        Me.Controls.Add(Me.lblCreditLimit)
        Me.Controls.Add(Me.cboAccountNo)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.lblAccountNo)
        Me.Controls.Add(Me.lblStatusID)
        Me.Controls.Add(Me.fcbStatusID)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblMedicalCardNo)
        Me.Controls.Add(Me.stbSurname)
        Me.Controls.Add(Me.lblSurname)
        Me.Controls.Add(Me.stbFirstName)
        Me.Controls.Add(Me.lblFirstName)
        Me.Controls.Add(Me.stbMiddleName)
        Me.Controls.Add(Me.lblMiddleName)
        Me.Controls.Add(Me.dtpPolicyStartDate)
        Me.Controls.Add(Me.lblPolicyStartDate)
        Me.Controls.Add(Me.dtpPolicyEndDate)
        Me.Controls.Add(Me.lblPolicyEndDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmBillCustomerMembers"
        Me.Text = "To-Bill Customer Members"
        Me.tbcBillCustomerMemberLimits.ResumeLayout(False)
        Me.tpgMemberLimits.ResumeLayout(False)
        CType(Me.dgvMemberLimits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblMedicalCardNo As System.Windows.Forms.Label
    Friend WithEvents stbSurname As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSurname As System.Windows.Forms.Label
    Friend WithEvents stbFirstName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFirstName As System.Windows.Forms.Label
    Friend WithEvents stbMiddleName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMiddleName As System.Windows.Forms.Label
    Friend WithEvents dtpPolicyStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPolicyStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpPolicyEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblPolicyEndDate As System.Windows.Forms.Label
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents fcbStatusID As SyncSoft.Common.Win.Controls.FlatComboBox
    Friend WithEvents lblStatusID As System.Windows.Forms.Label
    Friend WithEvents cboAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Friend WithEvents nbxCreditLimit As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCreditLimit As System.Windows.Forms.Label
    Friend WithEvents tbcBillCustomerMemberLimits As System.Windows.Forms.TabControl
    Friend WithEvents tpgMemberLimits As System.Windows.Forms.TabPage
    Friend WithEvents dgvMemberLimits As System.Windows.Forms.DataGridView
    Friend WithEvents colBenefitCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colMemberLimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMemberLimitsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents cboMedicalCardNo As ComboBox
End Class