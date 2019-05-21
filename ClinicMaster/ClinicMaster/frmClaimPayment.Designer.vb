<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmClaimPayment
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClaimPayment))
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnLoadList = New System.Windows.Forms.Button()
        Me.lblWaitingToPayForClaims = New System.Windows.Forms.Label()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboHealthUnit = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.cboInsurance = New System.Windows.Forms.ComboBox()
        Me.lblInsurance = New System.Windows.Forms.Label()
        Me.grpClaimPeriod = New System.Windows.Forms.GroupBox()
        Me.lblRecordsNo = New System.Windows.Forms.Label()
        Me.pnlPeriod = New System.Windows.Forms.Panel()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.btnLoadClaims = New System.Windows.Forms.Button()
        Me.lblCBFPRecordsNo = New System.Windows.Forms.Label()
        Me.lblHealthUnit = New System.Windows.Forms.Label()
        Me.cboCompany = New System.Windows.Forms.ComboBox()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.cboMedicalCardNo = New System.Windows.Forms.ComboBox()
        Me.lblMedicalCardNo = New System.Windows.Forms.Label()
        Me.dgvClaimPayment = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colMedicalCardNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colClaimNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colVisitDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colFullName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colGender = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAge = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCompanyName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colHealthUnitName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTotalConsumedAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPaymentDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.pnlAlerts.SuspendLayout()
        Me.grpClaimPeriod.SuspendLayout()
        Me.pnlPeriod.SuspendLayout()
        CType(Me.dgvClaimPayment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsItems.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnLoadList)
        Me.pnlAlerts.Controls.Add(Me.lblWaitingToPayForClaims)
        Me.pnlAlerts.Location = New System.Drawing.Point(684, 103)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(345, 42)
        Me.pnlAlerts.TabIndex = 165
        '
        'btnLoadList
        '
        Me.btnLoadList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadList.Location = New System.Drawing.Point(272, 6)
        Me.btnLoadList.Name = "btnLoadList"
        Me.btnLoadList.Size = New System.Drawing.Size(66, 24)
        Me.btnLoadList.TabIndex = 1
        Me.btnLoadList.Tag = ""
        Me.btnLoadList.Text = "&Load List"
        '
        'lblWaitingToPayForClaims
        '
        Me.lblWaitingToPayForClaims.AccessibleDescription = ""
        Me.lblWaitingToPayForClaims.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaitingToPayForClaims.ForeColor = System.Drawing.Color.Red
        Me.lblWaitingToPayForClaims.Location = New System.Drawing.Point(3, 9)
        Me.lblWaitingToPayForClaims.Name = "lblWaitingToPayForClaims"
        Me.lblWaitingToPayForClaims.Size = New System.Drawing.Size(258, 20)
        Me.lblWaitingToPayForClaims.TabIndex = 0
        Me.lblWaitingToPayForClaims.Text = "Waiting To Pay For Claims:"
        Me.lblWaitingToPayForClaims.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(917, 579)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 170
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(16, 407)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 160
        Me.ebnSaveUpdate.Tag = "Claims"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboHealthUnit
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboHealthUnit, "HealthUnitName,HealthUnitCode")
        Me.cboHealthUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHealthUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboHealthUnit.Location = New System.Drawing.Point(114, 45)
        Me.cboHealthUnit.Name = "cboHealthUnit"
        Me.cboHealthUnit.Size = New System.Drawing.Size(242, 21)
        Me.cboHealthUnit.TabIndex = 181
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(957, 406)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 161
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'cboInsurance
        '
        Me.cboInsurance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboInsurance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboInsurance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInsurance.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboInsurance.FormattingEnabled = True
        Me.cboInsurance.ItemHeight = 13
        Me.cboInsurance.Location = New System.Drawing.Point(114, 22)
        Me.cboInsurance.Name = "cboInsurance"
        Me.cboInsurance.Size = New System.Drawing.Size(242, 21)
        Me.cboInsurance.TabIndex = 172
        '
        'lblInsurance
        '
        Me.lblInsurance.Location = New System.Drawing.Point(15, 25)
        Me.lblInsurance.Name = "lblInsurance"
        Me.lblInsurance.Size = New System.Drawing.Size(93, 18)
        Me.lblInsurance.TabIndex = 171
        Me.lblInsurance.Text = "Insurance"
        '
        'grpClaimPeriod
        '
        Me.grpClaimPeriod.Controls.Add(Me.lblRecordsNo)
        Me.grpClaimPeriod.Controls.Add(Me.pnlPeriod)
        Me.grpClaimPeriod.Controls.Add(Me.btnLoadClaims)
        Me.grpClaimPeriod.Controls.Add(Me.lblCBFPRecordsNo)
        Me.grpClaimPeriod.Location = New System.Drawing.Point(372, 21)
        Me.grpClaimPeriod.Name = "grpClaimPeriod"
        Me.grpClaimPeriod.Size = New System.Drawing.Size(535, 76)
        Me.grpClaimPeriod.TabIndex = 175
        Me.grpClaimPeriod.TabStop = False
        Me.grpClaimPeriod.Text = "Claim Period"
        '
        'lblRecordsNo
        '
        Me.lblRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblRecordsNo.Location = New System.Drawing.Point(323, 14)
        Me.lblRecordsNo.Name = "lblRecordsNo"
        Me.lblRecordsNo.Size = New System.Drawing.Size(206, 13)
        Me.lblRecordsNo.TabIndex = 6
        Me.lblRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlPeriod
        '
        Me.pnlPeriod.Controls.Add(Me.dtpEndDate)
        Me.pnlPeriod.Controls.Add(Me.lblStartDate)
        Me.pnlPeriod.Controls.Add(Me.dtpStartDate)
        Me.pnlPeriod.Controls.Add(Me.lblEndDate)
        Me.pnlPeriod.Location = New System.Drawing.Point(5, 14)
        Me.pnlPeriod.Name = "pnlPeriod"
        Me.pnlPeriod.Size = New System.Drawing.Size(314, 53)
        Me.pnlPeriod.TabIndex = 3
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(121, 28)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(166, 20)
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
        Me.dtpStartDate.Location = New System.Drawing.Point(121, 5)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(166, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(10, 28)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(83, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnLoadClaims
        '
        Me.btnLoadClaims.AccessibleDescription = ""
        Me.btnLoadClaims.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadClaims.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadClaims.Location = New System.Drawing.Point(337, 40)
        Me.btnLoadClaims.Name = "btnLoadClaims"
        Me.btnLoadClaims.Size = New System.Drawing.Size(80, 24)
        Me.btnLoadClaims.TabIndex = 5
        Me.btnLoadClaims.Tag = ""
        Me.btnLoadClaims.Text = "&Load"
        '
        'lblCBFPRecordsNo
        '
        Me.lblCBFPRecordsNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCBFPRecordsNo.ForeColor = System.Drawing.Color.Blue
        Me.lblCBFPRecordsNo.Location = New System.Drawing.Point(337, 43)
        Me.lblCBFPRecordsNo.Name = "lblCBFPRecordsNo"
        Me.lblCBFPRecordsNo.Size = New System.Drawing.Size(192, 13)
        Me.lblCBFPRecordsNo.TabIndex = 4
        Me.lblCBFPRecordsNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHealthUnit
        '
        Me.lblHealthUnit.Location = New System.Drawing.Point(15, 48)
        Me.lblHealthUnit.Name = "lblHealthUnit"
        Me.lblHealthUnit.Size = New System.Drawing.Size(93, 18)
        Me.lblHealthUnit.TabIndex = 173
        Me.lblHealthUnit.Text = "Health Unit"
        '
        'cboCompany
        '
        Me.cboCompany.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCompany.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCompany.BackColor = System.Drawing.SystemColors.Window
        Me.cboCompany.DropDownWidth = 276
        Me.cboCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCompany.FormattingEnabled = True
        Me.cboCompany.ItemHeight = 13
        Me.cboCompany.Location = New System.Drawing.Point(114, 68)
        Me.cboCompany.Name = "cboCompany"
        Me.cboCompany.Size = New System.Drawing.Size(242, 21)
        Me.cboCompany.TabIndex = 177
        '
        'lblCompany
        '
        Me.lblCompany.Location = New System.Drawing.Point(15, 71)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(93, 18)
        Me.lblCompany.TabIndex = 176
        Me.lblCompany.Text = "Company"
        '
        'cboMedicalCardNo
        '
        Me.cboMedicalCardNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboMedicalCardNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboMedicalCardNo.BackColor = System.Drawing.SystemColors.Window
        Me.cboMedicalCardNo.DropDownWidth = 276
        Me.cboMedicalCardNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMedicalCardNo.FormattingEnabled = True
        Me.cboMedicalCardNo.ItemHeight = 13
        Me.cboMedicalCardNo.Location = New System.Drawing.Point(114, 91)
        Me.cboMedicalCardNo.Name = "cboMedicalCardNo"
        Me.cboMedicalCardNo.Size = New System.Drawing.Size(242, 21)
        Me.cboMedicalCardNo.TabIndex = 179
        '
        'lblMedicalCardNo
        '
        Me.lblMedicalCardNo.Location = New System.Drawing.Point(15, 94)
        Me.lblMedicalCardNo.Name = "lblMedicalCardNo"
        Me.lblMedicalCardNo.Size = New System.Drawing.Size(93, 18)
        Me.lblMedicalCardNo.TabIndex = 178
        Me.lblMedicalCardNo.Text = "Medical CardNo"
        '
        'dgvClaimPayment
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        Me.dgvClaimPayment.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvClaimPayment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvClaimPayment.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvClaimPayment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvClaimPayment.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
        Me.dgvClaimPayment.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClaimPayment.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvClaimPayment.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colMedicalCardNo, Me.colClaimNo, Me.colVisitDate, Me.colFullName, Me.colGender, Me.colAge, Me.colCompanyName, Me.colHealthUnitName, Me.colTotalConsumedAmount, Me.colPaymentDate, Me.colMainMemberName, Me.colPrimaryDoctor, Me.colRecordDate, Me.colRecordTime})
        Me.dgvClaimPayment.ContextMenuStrip = Me.cmsItems
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvClaimPayment.DefaultCellStyle = DataGridViewCellStyle17
        Me.dgvClaimPayment.EnableHeadersVisualStyles = False
        Me.dgvClaimPayment.GridColor = System.Drawing.Color.Khaki
        Me.dgvClaimPayment.Location = New System.Drawing.Point(18, 151)
        Me.dgvClaimPayment.Name = "dgvClaimPayment"
        Me.dgvClaimPayment.ReadOnly = True
        Me.dgvClaimPayment.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvClaimPayment.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvClaimPayment.RowHeadersVisible = False
        Me.dgvClaimPayment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.dgvClaimPayment.Size = New System.Drawing.Size(1011, 240)
        Me.dgvClaimPayment.TabIndex = 180
        Me.dgvClaimPayment.Text = "DataGridView1"
        '
        'colInclude
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle3.NullValue = False
        Me.colInclude.DefaultCellStyle = DataGridViewCellStyle3
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
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.colMedicalCardNo.DefaultCellStyle = DataGridViewCellStyle4
        Me.colMedicalCardNo.HeaderText = "Medical Card No"
        Me.colMedicalCardNo.Name = "colMedicalCardNo"
        Me.colMedicalCardNo.ReadOnly = True
        '
        'colClaimNo
        '
        Me.colClaimNo.DataPropertyName = "ClaimNo"
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colClaimNo.DefaultCellStyle = DataGridViewCellStyle5
        Me.colClaimNo.HeaderText = "Claim No"
        Me.colClaimNo.Name = "colClaimNo"
        Me.colClaimNo.ReadOnly = True
        Me.colClaimNo.Width = 80
        '
        'colVisitDate
        '
        Me.colVisitDate.DataPropertyName = "VisitDate"
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colVisitDate.DefaultCellStyle = DataGridViewCellStyle6
        Me.colVisitDate.HeaderText = "Visit Date"
        Me.colVisitDate.Name = "colVisitDate"
        Me.colVisitDate.ReadOnly = True
        Me.colVisitDate.Width = 80
        '
        'colFullName
        '
        Me.colFullName.DataPropertyName = "FullName"
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colFullName.DefaultCellStyle = DataGridViewCellStyle7
        Me.colFullName.HeaderText = "Full Name"
        Me.colFullName.Name = "colFullName"
        Me.colFullName.ReadOnly = True
        Me.colFullName.Width = 150
        '
        'colGender
        '
        Me.colGender.DataPropertyName = "Gender"
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colGender.DefaultCellStyle = DataGridViewCellStyle8
        Me.colGender.HeaderText = "Gender"
        Me.colGender.Name = "colGender"
        Me.colGender.ReadOnly = True
        Me.colGender.Width = 65
        '
        'colAge
        '
        Me.colAge.DataPropertyName = "Age"
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colAge.DefaultCellStyle = DataGridViewCellStyle9
        Me.colAge.HeaderText = "Age"
        Me.colAge.Name = "colAge"
        Me.colAge.ReadOnly = True
        Me.colAge.Width = 45
        '
        'colCompanyName
        '
        Me.colCompanyName.DataPropertyName = "CompanyName"
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colCompanyName.DefaultCellStyle = DataGridViewCellStyle10
        Me.colCompanyName.HeaderText = "Company Name"
        Me.colCompanyName.Name = "colCompanyName"
        Me.colCompanyName.ReadOnly = True
        '
        'colHealthUnitName
        '
        Me.colHealthUnitName.DataPropertyName = "HealthUnitName"
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colHealthUnitName.DefaultCellStyle = DataGridViewCellStyle11
        Me.colHealthUnitName.HeaderText = "Health Unit Name"
        Me.colHealthUnitName.Name = "colHealthUnitName"
        Me.colHealthUnitName.ReadOnly = True
        Me.colHealthUnitName.Width = 120
        '
        'colTotalConsumedAmount
        '
        Me.colTotalConsumedAmount.DataPropertyName = "TotalConsumedAmount"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle12.NullValue = Nothing
        Me.colTotalConsumedAmount.DefaultCellStyle = DataGridViewCellStyle12
        Me.colTotalConsumedAmount.HeaderText = "Consumed Amount"
        Me.colTotalConsumedAmount.Name = "colTotalConsumedAmount"
        Me.colTotalConsumedAmount.ReadOnly = True
        Me.colTotalConsumedAmount.Width = 120
        '
        'colPaymentDate
        '
        Me.colPaymentDate.HeaderText = "Payment Date"
        Me.colPaymentDate.Name = "colPaymentDate"
        Me.colPaymentDate.ReadOnly = True
        '
        'colMainMemberName
        '
        Me.colMainMemberName.DataPropertyName = "MainMemberName"
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        Me.colMainMemberName.DefaultCellStyle = DataGridViewCellStyle13
        Me.colMainMemberName.HeaderText = "Main Member Name"
        Me.colMainMemberName.Name = "colMainMemberName"
        Me.colMainMemberName.ReadOnly = True
        Me.colMainMemberName.Width = 120
        '
        'colPrimaryDoctor
        '
        Me.colPrimaryDoctor.DataPropertyName = "PrimaryDoctor"
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colPrimaryDoctor.DefaultCellStyle = DataGridViewCellStyle14
        Me.colPrimaryDoctor.HeaderText = "Primary Doctor"
        Me.colPrimaryDoctor.Name = "colPrimaryDoctor"
        Me.colPrimaryDoctor.ReadOnly = True
        Me.colPrimaryDoctor.Width = 120
        '
        'colRecordDate
        '
        Me.colRecordDate.DataPropertyName = "RecordDate"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colRecordDate.DefaultCellStyle = DataGridViewCellStyle15
        Me.colRecordDate.HeaderText = "Record Date"
        Me.colRecordDate.Name = "colRecordDate"
        Me.colRecordDate.ReadOnly = True
        Me.colRecordDate.Width = 80
        '
        'colRecordTime
        '
        Me.colRecordTime.DataPropertyName = "RecordTime"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colRecordTime.DefaultCellStyle = DataGridViewCellStyle16
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
        Me.lblMessage.Location = New System.Drawing.Point(323, 406)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(368, 20)
        Me.lblMessage.TabIndex = 182
        Me.lblMessage.Text = "Hint: double click for claim payment details"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmClaimPayment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1041, 442)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.cboHealthUnit)
        Me.Controls.Add(Me.dgvClaimPayment)
        Me.Controls.Add(Me.cboMedicalCardNo)
        Me.Controls.Add(Me.lblMedicalCardNo)
        Me.Controls.Add(Me.cboCompany)
        Me.Controls.Add(Me.lblCompany)
        Me.Controls.Add(Me.cboInsurance)
        Me.Controls.Add(Me.lblInsurance)
        Me.Controls.Add(Me.grpClaimPeriod)
        Me.Controls.Add(Me.lblHealthUnit)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmClaimPayment"
        Me.Text = "Claim Payment"
        Me.pnlAlerts.ResumeLayout(False)
        Me.grpClaimPeriod.ResumeLayout(False)
        Me.pnlPeriod.ResumeLayout(False)
        CType(Me.dgvClaimPayment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsItems.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnLoadList As System.Windows.Forms.Button
    Friend WithEvents lblWaitingToPayForClaims As System.Windows.Forms.Label
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboInsurance As System.Windows.Forms.ComboBox
    Friend WithEvents lblInsurance As System.Windows.Forms.Label
    Friend WithEvents grpClaimPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents pnlPeriod As System.Windows.Forms.Panel
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents btnLoadClaims As System.Windows.Forms.Button
    Friend WithEvents lblCBFPRecordsNo As System.Windows.Forms.Label
    Friend WithEvents lblHealthUnit As System.Windows.Forms.Label
    Friend WithEvents cboCompany As System.Windows.Forms.ComboBox
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents cboMedicalCardNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblMedicalCardNo As System.Windows.Forms.Label
    Friend WithEvents dgvClaimPayment As System.Windows.Forms.DataGridView
    Friend WithEvents cboHealthUnit As System.Windows.Forms.ComboBox
    Friend WithEvents lblRecordsNo As System.Windows.Forms.Label
    Friend WithEvents cmsItems As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsItemsCopy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsItemsSelectAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmsItemsIncludeAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsItemsIncludeNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colMedicalCardNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colClaimNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colVisitDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colFullName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colGender As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAge As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCompanyName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colHealthUnitName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTotalConsumedAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPaymentDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colMainMemberName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPrimaryDoctor As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colRecordTime As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
