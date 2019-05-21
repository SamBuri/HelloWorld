
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInsuranceSchemes : Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInsuranceSchemes))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpSchemeJoinDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpSchemeStartDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpSchemeEndDate = New System.Windows.Forms.DateTimePicker()
        Me.cboSchemeStatusID = New System.Windows.Forms.ComboBox()
        Me.stbCompanyName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboCompanyNo = New System.Windows.Forms.ComboBox()
        Me.cboCoPayTypeID = New System.Windows.Forms.ComboBox()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.chkSmartCardApplicable = New System.Windows.Forms.CheckBox()
        Me.nbxAnnualPremium = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxMemberPremium = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblSchemeJoinDate = New System.Windows.Forms.Label()
        Me.lblSchemeStartDate = New System.Windows.Forms.Label()
        Me.lblSchemeEndDate = New System.Windows.Forms.Label()
        Me.lblSchemeStatusID = New System.Windows.Forms.Label()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.lblCompanyNo = New System.Windows.Forms.Label()
        Me.pnlStatusID = New System.Windows.Forms.Panel()
        Me.cboInsuranceNo = New System.Windows.Forms.ComboBox()
        Me.lblInsuranceNo = New System.Windows.Forms.Label()
        Me.cboPolicyNo = New System.Windows.Forms.ComboBox()
        Me.lblPolicyNo = New System.Windows.Forms.Label()
        Me.tbcInsuranceExcludedItems = New System.Windows.Forms.TabControl()
        Me.tpgPolicyLimits = New System.Windows.Forms.TabPage()
        Me.dgvPolicyLimits = New System.Windows.Forms.DataGridView()
        Me.colBenefitCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colPolicyLimit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPolicyLimitsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgInsuranceExcludedServices = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceExcludedServices = New System.Windows.Forms.DataGridView()
        Me.colServiceCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceExcludedServicesSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgInsuranceExcludedDrugs = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceExcludedDrugs = New System.Windows.Forms.DataGridView()
        Me.colDrugNo = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceExcludedDrugsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgInsuranceExcludedLabTests = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceExcludedLabTests = New System.Windows.Forms.DataGridView()
        Me.colTestCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceExcludedLabTestsSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgInsuranceExcludedRadiology = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceExcludedRadiology = New System.Windows.Forms.DataGridView()
        Me.colExamCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceExcludedRadiologySaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tpgInsuranceExcludedProcedures = New System.Windows.Forms.TabPage()
        Me.dgvInsuranceExcludedProcedures = New System.Windows.Forms.DataGridView()
        Me.colProcedureCode = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.colInsuranceExcludedProceduresSaved = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.lblCoPayTypeID = New System.Windows.Forms.Label()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.pnlCoPayTypeID = New System.Windows.Forms.Panel()
        Me.lblAnnualPremium = New System.Windows.Forms.Label()
        Me.lblMemberPremium = New System.Windows.Forms.Label()
        Me.pnlStatusID.SuspendLayout()
        Me.tbcInsuranceExcludedItems.SuspendLayout()
        Me.tpgPolicyLimits.SuspendLayout()
        CType(Me.dgvPolicyLimits, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInsuranceExcludedServices.SuspendLayout()
        CType(Me.dgvInsuranceExcludedServices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInsuranceExcludedDrugs.SuspendLayout()
        CType(Me.dgvInsuranceExcludedDrugs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInsuranceExcludedLabTests.SuspendLayout()
        CType(Me.dgvInsuranceExcludedLabTests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInsuranceExcludedRadiology.SuspendLayout()
        CType(Me.dgvInsuranceExcludedRadiology, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpgInsuranceExcludedProcedures.SuspendLayout()
        CType(Me.dgvInsuranceExcludedProcedures, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlCoPayTypeID.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 430)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 26
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(639, 430)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 27
        Me.fbnDelete.Tag = "InsuranceSchemes"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 457)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 28
        Me.ebnSaveUpdate.Tag = "InsuranceSchemes"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpSchemeJoinDate
        '
        Me.dtpSchemeJoinDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpSchemeJoinDate, "SchemeJoinDate")
        Me.dtpSchemeJoinDate.Location = New System.Drawing.Point(143, 115)
        Me.dtpSchemeJoinDate.Name = "dtpSchemeJoinDate"
        Me.dtpSchemeJoinDate.ShowCheckBox = True
        Me.dtpSchemeJoinDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpSchemeJoinDate.TabIndex = 9
        '
        'dtpSchemeStartDate
        '
        Me.dtpSchemeStartDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpSchemeStartDate, "SchemeStartDate")
        Me.dtpSchemeStartDate.Location = New System.Drawing.Point(143, 136)
        Me.dtpSchemeStartDate.Name = "dtpSchemeStartDate"
        Me.dtpSchemeStartDate.ShowCheckBox = True
        Me.dtpSchemeStartDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpSchemeStartDate.TabIndex = 11
        '
        'dtpSchemeEndDate
        '
        Me.dtpSchemeEndDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpSchemeEndDate, "SchemeEndDate")
        Me.dtpSchemeEndDate.Location = New System.Drawing.Point(143, 157)
        Me.dtpSchemeEndDate.Name = "dtpSchemeEndDate"
        Me.dtpSchemeEndDate.ShowCheckBox = True
        Me.dtpSchemeEndDate.Size = New System.Drawing.Size(179, 20)
        Me.dtpSchemeEndDate.TabIndex = 13
        '
        'cboSchemeStatusID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSchemeStatusID, "SchemeStatus,SchemeStatusID")
        Me.cboSchemeStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSchemeStatusID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSchemeStatusID.Location = New System.Drawing.Point(131, 4)
        Me.cboSchemeStatusID.Name = "cboSchemeStatusID"
        Me.cboSchemeStatusID.Size = New System.Drawing.Size(188, 21)
        Me.cboSchemeStatusID.TabIndex = 1
        '
        'stbCompanyName
        '
        Me.stbCompanyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCompanyName.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbCompanyName, "CompanyName")
        Me.stbCompanyName.EntryErrorMSG = ""
        Me.stbCompanyName.Location = New System.Drawing.Point(143, 31)
        Me.stbCompanyName.MaxLength = 60
        Me.stbCompanyName.Multiline = True
        Me.stbCompanyName.Name = "stbCompanyName"
        Me.stbCompanyName.ReadOnly = True
        Me.stbCompanyName.RegularExpression = ""
        Me.stbCompanyName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCompanyName.Size = New System.Drawing.Size(179, 35)
        Me.stbCompanyName.TabIndex = 3
        '
        'cboCompanyNo
        '
        Me.cboCompanyNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboCompanyNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboCompanyNo.BackColor = System.Drawing.SystemColors.Window
        Me.ebnSaveUpdate.SetDataMember(Me.cboCompanyNo, "CompanyNo")
        Me.cboCompanyNo.DropDownWidth = 256
        Me.cboCompanyNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCompanyNo.FormattingEnabled = True
        Me.cboCompanyNo.ItemHeight = 13
        Me.cboCompanyNo.Location = New System.Drawing.Point(143, 7)
        Me.cboCompanyNo.Name = "cboCompanyNo"
        Me.cboCompanyNo.Size = New System.Drawing.Size(179, 21)
        Me.cboCompanyNo.TabIndex = 1
        '
        'cboCoPayTypeID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCoPayTypeID, "CoPayType,CoPayTypeID")
        Me.cboCoPayTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCoPayTypeID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCoPayTypeID.Location = New System.Drawing.Point(131, 4)
        Me.cboCoPayTypeID.Name = "cboCoPayTypeID"
        Me.cboCoPayTypeID.Size = New System.Drawing.Size(188, 21)
        Me.cboCoPayTypeID.TabIndex = 1
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayPercent, "CoPayPercent")
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(471, 32)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(188, 20)
        Me.nbxCoPayPercent.TabIndex = 16
        Me.nbxCoPayPercent.Value = ""
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxCoPayValue, "CoPayValue")
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(471, 53)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.Size = New System.Drawing.Size(188, 20)
        Me.nbxCoPayValue.TabIndex = 18
        Me.nbxCoPayValue.Value = ""
        '
        'chkSmartCardApplicable
        '
        Me.chkSmartCardApplicable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ebnSaveUpdate.SetDataMember(Me.chkSmartCardApplicable, "SmartCardApplicable")
        Me.chkSmartCardApplicable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSmartCardApplicable.Location = New System.Drawing.Point(342, 118)
        Me.chkSmartCardApplicable.Name = "chkSmartCardApplicable"
        Me.chkSmartCardApplicable.Size = New System.Drawing.Size(144, 20)
        Me.chkSmartCardApplicable.TabIndex = 23
        Me.chkSmartCardApplicable.Text = "Smart Card Applicable"
        '
        'nbxAnnualPremium
        '
        Me.nbxAnnualPremium.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAnnualPremium.ControlCaption = "Annual Premium"
        Me.nbxAnnualPremium.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAnnualPremium, "AnnualPremium")
        Me.nbxAnnualPremium.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxAnnualPremium.DecimalPlaces = 2
        Me.nbxAnnualPremium.Location = New System.Drawing.Point(471, 74)
        Me.nbxAnnualPremium.MaxLength = 12
        Me.nbxAnnualPremium.MaxValue = 0.0R
        Me.nbxAnnualPremium.MinValue = 0.0R
        Me.nbxAnnualPremium.MustEnterNumeric = True
        Me.nbxAnnualPremium.Name = "nbxAnnualPremium"
        Me.nbxAnnualPremium.Size = New System.Drawing.Size(188, 20)
        Me.nbxAnnualPremium.TabIndex = 20
        Me.nbxAnnualPremium.Value = ""
        '
        'nbxMemberPremium
        '
        Me.nbxMemberPremium.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxMemberPremium.ControlCaption = "Member Premium"
        Me.nbxMemberPremium.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.ebnSaveUpdate.SetDataMember(Me.nbxMemberPremium, "MemberPremium")
        Me.nbxMemberPremium.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxMemberPremium.DecimalPlaces = 2
        Me.nbxMemberPremium.Location = New System.Drawing.Point(471, 95)
        Me.nbxMemberPremium.MaxLength = 12
        Me.nbxMemberPremium.MaxValue = 0.0R
        Me.nbxMemberPremium.MinValue = 0.0R
        Me.nbxMemberPremium.MustEnterNumeric = True
        Me.nbxMemberPremium.Name = "nbxMemberPremium"
        Me.nbxMemberPremium.Size = New System.Drawing.Size(188, 20)
        Me.nbxMemberPremium.TabIndex = 22
        Me.nbxMemberPremium.Value = ""
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(639, 457)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 29
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblSchemeJoinDate
        '
        Me.lblSchemeJoinDate.Location = New System.Drawing.Point(17, 115)
        Me.lblSchemeJoinDate.Name = "lblSchemeJoinDate"
        Me.lblSchemeJoinDate.Size = New System.Drawing.Size(120, 20)
        Me.lblSchemeJoinDate.TabIndex = 8
        Me.lblSchemeJoinDate.Text = "Scheme Join Date"
        '
        'lblSchemeStartDate
        '
        Me.lblSchemeStartDate.Location = New System.Drawing.Point(17, 136)
        Me.lblSchemeStartDate.Name = "lblSchemeStartDate"
        Me.lblSchemeStartDate.Size = New System.Drawing.Size(120, 20)
        Me.lblSchemeStartDate.TabIndex = 10
        Me.lblSchemeStartDate.Text = "Scheme Start Date"
        '
        'lblSchemeEndDate
        '
        Me.lblSchemeEndDate.Location = New System.Drawing.Point(17, 157)
        Me.lblSchemeEndDate.Name = "lblSchemeEndDate"
        Me.lblSchemeEndDate.Size = New System.Drawing.Size(120, 20)
        Me.lblSchemeEndDate.TabIndex = 12
        Me.lblSchemeEndDate.Text = "Scheme End Date"
        '
        'lblSchemeStatusID
        '
        Me.lblSchemeStatusID.Location = New System.Drawing.Point(5, 4)
        Me.lblSchemeStatusID.Name = "lblSchemeStatusID"
        Me.lblSchemeStatusID.Size = New System.Drawing.Size(117, 20)
        Me.lblSchemeStatusID.TabIndex = 0
        Me.lblSchemeStatusID.Text = "Scheme Status"
        '
        'lblLoginID
        '
        Me.lblLoginID.Location = New System.Drawing.Point(0, 0)
        Me.lblLoginID.Name = "lblLoginID"
        Me.lblLoginID.Size = New System.Drawing.Size(100, 23)
        Me.lblLoginID.TabIndex = 0
        '
        'lblCompanyName
        '
        Me.lblCompanyName.Location = New System.Drawing.Point(17, 38)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(120, 20)
        Me.lblCompanyName.TabIndex = 2
        Me.lblCompanyName.Text = "Company Name"
        '
        'lblCompanyNo
        '
        Me.lblCompanyNo.Location = New System.Drawing.Point(17, 8)
        Me.lblCompanyNo.Name = "lblCompanyNo"
        Me.lblCompanyNo.Size = New System.Drawing.Size(120, 20)
        Me.lblCompanyNo.TabIndex = 0
        Me.lblCompanyNo.Text = "Company Number"
        '
        'pnlStatusID
        '
        Me.pnlStatusID.Controls.Add(Me.cboSchemeStatusID)
        Me.pnlStatusID.Controls.Add(Me.lblSchemeStatusID)
        Me.pnlStatusID.Location = New System.Drawing.Point(338, 142)
        Me.pnlStatusID.Name = "pnlStatusID"
        Me.pnlStatusID.Size = New System.Drawing.Size(328, 29)
        Me.pnlStatusID.TabIndex = 24
        '
        'cboInsuranceNo
        '
        Me.cboInsuranceNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInsuranceNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboInsuranceNo.Location = New System.Drawing.Point(143, 69)
        Me.cboInsuranceNo.Name = "cboInsuranceNo"
        Me.cboInsuranceNo.Size = New System.Drawing.Size(179, 21)
        Me.cboInsuranceNo.TabIndex = 5
        '
        'lblInsuranceNo
        '
        Me.lblInsuranceNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInsuranceNo.Location = New System.Drawing.Point(17, 67)
        Me.lblInsuranceNo.Name = "lblInsuranceNo"
        Me.lblInsuranceNo.Size = New System.Drawing.Size(120, 20)
        Me.lblInsuranceNo.TabIndex = 4
        Me.lblInsuranceNo.Text = "Insurance Name"
        '
        'cboPolicyNo
        '
        Me.cboPolicyNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPolicyNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboPolicyNo.Location = New System.Drawing.Point(143, 92)
        Me.cboPolicyNo.Name = "cboPolicyNo"
        Me.cboPolicyNo.Size = New System.Drawing.Size(179, 21)
        Me.cboPolicyNo.TabIndex = 7
        '
        'lblPolicyNo
        '
        Me.lblPolicyNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPolicyNo.Location = New System.Drawing.Point(17, 92)
        Me.lblPolicyNo.Name = "lblPolicyNo"
        Me.lblPolicyNo.Size = New System.Drawing.Size(120, 20)
        Me.lblPolicyNo.TabIndex = 6
        Me.lblPolicyNo.Text = "Policy Name"
        '
        'tbcInsuranceExcludedItems
        '
        Me.tbcInsuranceExcludedItems.Controls.Add(Me.tpgPolicyLimits)
        Me.tbcInsuranceExcludedItems.Controls.Add(Me.tpgInsuranceExcludedServices)
        Me.tbcInsuranceExcludedItems.Controls.Add(Me.tpgInsuranceExcludedDrugs)
        Me.tbcInsuranceExcludedItems.Controls.Add(Me.tpgInsuranceExcludedLabTests)
        Me.tbcInsuranceExcludedItems.Controls.Add(Me.tpgInsuranceExcludedRadiology)
        Me.tbcInsuranceExcludedItems.Controls.Add(Me.tpgInsuranceExcludedProcedures)
        Me.tbcInsuranceExcludedItems.HotTrack = True
        Me.tbcInsuranceExcludedItems.Location = New System.Drawing.Point(17, 202)
        Me.tbcInsuranceExcludedItems.Name = "tbcInsuranceExcludedItems"
        Me.tbcInsuranceExcludedItems.SelectedIndex = 0
        Me.tbcInsuranceExcludedItems.Size = New System.Drawing.Size(698, 222)
        Me.tbcInsuranceExcludedItems.TabIndex = 25
        '
        'tpgPolicyLimits
        '
        Me.tpgPolicyLimits.Controls.Add(Me.dgvPolicyLimits)
        Me.tpgPolicyLimits.Location = New System.Drawing.Point(4, 22)
        Me.tpgPolicyLimits.Name = "tpgPolicyLimits"
        Me.tpgPolicyLimits.Size = New System.Drawing.Size(690, 196)
        Me.tpgPolicyLimits.TabIndex = 6
        Me.tpgPolicyLimits.Tag = "PolicyLimits"
        Me.tpgPolicyLimits.Text = "Policy Limits"
        Me.tpgPolicyLimits.UseVisualStyleBackColor = True
        '
        'dgvPolicyLimits
        '
        Me.dgvPolicyLimits.AllowUserToOrderColumns = True
        Me.dgvPolicyLimits.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPolicyLimits.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPolicyLimits.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colBenefitCode, Me.colPolicyLimit, Me.colPolicyLimitsSaved})
        Me.dgvPolicyLimits.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPolicyLimits.EnableHeadersVisualStyles = False
        Me.dgvPolicyLimits.GridColor = System.Drawing.Color.Khaki
        Me.dgvPolicyLimits.Location = New System.Drawing.Point(0, 0)
        Me.dgvPolicyLimits.Name = "dgvPolicyLimits"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPolicyLimits.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvPolicyLimits.Size = New System.Drawing.Size(690, 196)
        Me.dgvPolicyLimits.TabIndex = 0
        Me.dgvPolicyLimits.Text = "DataGridView1"
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
        'colPolicyLimit
        '
        Me.colPolicyLimit.DataPropertyName = "PolicyLimit"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle2.NullValue = Nothing
        Me.colPolicyLimit.DefaultCellStyle = DataGridViewCellStyle2
        Me.colPolicyLimit.HeaderText = "Policy Limit"
        Me.colPolicyLimit.Name = "colPolicyLimit"
        Me.colPolicyLimit.Width = 90
        '
        'colPolicyLimitsSaved
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle3.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle3.NullValue = False
        Me.colPolicyLimitsSaved.DefaultCellStyle = DataGridViewCellStyle3
        Me.colPolicyLimitsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colPolicyLimitsSaved.HeaderText = "Saved"
        Me.colPolicyLimitsSaved.Name = "colPolicyLimitsSaved"
        Me.colPolicyLimitsSaved.ReadOnly = True
        Me.colPolicyLimitsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPolicyLimitsSaved.Width = 50
        '
        'tpgInsuranceExcludedServices
        '
        Me.tpgInsuranceExcludedServices.Controls.Add(Me.dgvInsuranceExcludedServices)
        Me.tpgInsuranceExcludedServices.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceExcludedServices.Name = "tpgInsuranceExcludedServices"
        Me.tpgInsuranceExcludedServices.Size = New System.Drawing.Size(690, 196)
        Me.tpgInsuranceExcludedServices.TabIndex = 2
        Me.tpgInsuranceExcludedServices.Tag = "InsuranceExcludedItems"
        Me.tpgInsuranceExcludedServices.Text = "Excluded Services"
        Me.tpgInsuranceExcludedServices.UseVisualStyleBackColor = True
        '
        'dgvInsuranceExcludedServices
        '
        Me.dgvInsuranceExcludedServices.AllowUserToOrderColumns = True
        Me.dgvInsuranceExcludedServices.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedServices.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvInsuranceExcludedServices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colServiceCode, Me.colInsuranceExcludedServicesSaved})
        Me.dgvInsuranceExcludedServices.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceExcludedServices.EnableHeadersVisualStyles = False
        Me.dgvInsuranceExcludedServices.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceExcludedServices.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceExcludedServices.Name = "dgvInsuranceExcludedServices"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedServices.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvInsuranceExcludedServices.Size = New System.Drawing.Size(690, 196)
        Me.dgvInsuranceExcludedServices.TabIndex = 0
        Me.dgvInsuranceExcludedServices.Text = "DataGridView1"
        '
        'colServiceCode
        '
        Me.colServiceCode.DataPropertyName = "ItemCode"
        Me.colServiceCode.DisplayStyleForCurrentCellOnly = True
        Me.colServiceCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colServiceCode.HeaderText = "Service"
        Me.colServiceCode.Name = "colServiceCode"
        Me.colServiceCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colServiceCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colServiceCode.Width = 400
        '
        'colInsuranceExcludedServicesSaved
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle6.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle6.NullValue = False
        Me.colInsuranceExcludedServicesSaved.DefaultCellStyle = DataGridViewCellStyle6
        Me.colInsuranceExcludedServicesSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceExcludedServicesSaved.HeaderText = "Saved"
        Me.colInsuranceExcludedServicesSaved.Name = "colInsuranceExcludedServicesSaved"
        Me.colInsuranceExcludedServicesSaved.ReadOnly = True
        Me.colInsuranceExcludedServicesSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceExcludedServicesSaved.Width = 50
        '
        'tpgInsuranceExcludedDrugs
        '
        Me.tpgInsuranceExcludedDrugs.Controls.Add(Me.dgvInsuranceExcludedDrugs)
        Me.tpgInsuranceExcludedDrugs.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceExcludedDrugs.Name = "tpgInsuranceExcludedDrugs"
        Me.tpgInsuranceExcludedDrugs.Size = New System.Drawing.Size(690, 196)
        Me.tpgInsuranceExcludedDrugs.TabIndex = 1
        Me.tpgInsuranceExcludedDrugs.Tag = "InsuranceExcludedItems"
        Me.tpgInsuranceExcludedDrugs.Text = "Excluded Drugs"
        Me.tpgInsuranceExcludedDrugs.UseVisualStyleBackColor = True
        '
        'dgvInsuranceExcludedDrugs
        '
        Me.dgvInsuranceExcludedDrugs.AllowUserToOrderColumns = True
        Me.dgvInsuranceExcludedDrugs.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedDrugs.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvInsuranceExcludedDrugs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colDrugNo, Me.colInsuranceExcludedDrugsSaved})
        Me.dgvInsuranceExcludedDrugs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceExcludedDrugs.EnableHeadersVisualStyles = False
        Me.dgvInsuranceExcludedDrugs.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceExcludedDrugs.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceExcludedDrugs.Name = "dgvInsuranceExcludedDrugs"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedDrugs.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvInsuranceExcludedDrugs.Size = New System.Drawing.Size(690, 196)
        Me.dgvInsuranceExcludedDrugs.TabIndex = 19
        Me.dgvInsuranceExcludedDrugs.Text = "DataGridView1"
        '
        'colDrugNo
        '
        Me.colDrugNo.DataPropertyName = "ItemCode"
        Me.colDrugNo.DisplayStyleForCurrentCellOnly = True
        Me.colDrugNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colDrugNo.HeaderText = "Drug"
        Me.colDrugNo.Name = "colDrugNo"
        Me.colDrugNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colDrugNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colDrugNo.Width = 400
        '
        'colInsuranceExcludedDrugsSaved
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle9.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle9.NullValue = False
        Me.colInsuranceExcludedDrugsSaved.DefaultCellStyle = DataGridViewCellStyle9
        Me.colInsuranceExcludedDrugsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceExcludedDrugsSaved.HeaderText = "Saved"
        Me.colInsuranceExcludedDrugsSaved.Name = "colInsuranceExcludedDrugsSaved"
        Me.colInsuranceExcludedDrugsSaved.ReadOnly = True
        Me.colInsuranceExcludedDrugsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceExcludedDrugsSaved.Width = 50
        '
        'tpgInsuranceExcludedLabTests
        '
        Me.tpgInsuranceExcludedLabTests.Controls.Add(Me.dgvInsuranceExcludedLabTests)
        Me.tpgInsuranceExcludedLabTests.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceExcludedLabTests.Name = "tpgInsuranceExcludedLabTests"
        Me.tpgInsuranceExcludedLabTests.Size = New System.Drawing.Size(690, 196)
        Me.tpgInsuranceExcludedLabTests.TabIndex = 3
        Me.tpgInsuranceExcludedLabTests.Tag = "InsuranceExcludedItems"
        Me.tpgInsuranceExcludedLabTests.Text = "Excluded Lab Tests"
        Me.tpgInsuranceExcludedLabTests.UseVisualStyleBackColor = True
        '
        'dgvInsuranceExcludedLabTests
        '
        Me.dgvInsuranceExcludedLabTests.AllowUserToOrderColumns = True
        Me.dgvInsuranceExcludedLabTests.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedLabTests.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.dgvInsuranceExcludedLabTests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colTestCode, Me.colInsuranceExcludedLabTestsSaved})
        Me.dgvInsuranceExcludedLabTests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceExcludedLabTests.EnableHeadersVisualStyles = False
        Me.dgvInsuranceExcludedLabTests.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceExcludedLabTests.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceExcludedLabTests.Name = "dgvInsuranceExcludedLabTests"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedLabTests.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvInsuranceExcludedLabTests.Size = New System.Drawing.Size(690, 196)
        Me.dgvInsuranceExcludedLabTests.TabIndex = 16
        Me.dgvInsuranceExcludedLabTests.Text = "DataGridView1"
        '
        'colTestCode
        '
        Me.colTestCode.DataPropertyName = "ItemCode"
        Me.colTestCode.DisplayStyleForCurrentCellOnly = True
        Me.colTestCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colTestCode.HeaderText = "Lab Test"
        Me.colTestCode.Name = "colTestCode"
        Me.colTestCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTestCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colTestCode.Width = 400
        '
        'colInsuranceExcludedLabTestsSaved
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle12.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle12.NullValue = False
        Me.colInsuranceExcludedLabTestsSaved.DefaultCellStyle = DataGridViewCellStyle12
        Me.colInsuranceExcludedLabTestsSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceExcludedLabTestsSaved.HeaderText = "Saved"
        Me.colInsuranceExcludedLabTestsSaved.Name = "colInsuranceExcludedLabTestsSaved"
        Me.colInsuranceExcludedLabTestsSaved.ReadOnly = True
        Me.colInsuranceExcludedLabTestsSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceExcludedLabTestsSaved.Width = 50
        '
        'tpgInsuranceExcludedRadiology
        '
        Me.tpgInsuranceExcludedRadiology.Controls.Add(Me.dgvInsuranceExcludedRadiology)
        Me.tpgInsuranceExcludedRadiology.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceExcludedRadiology.Name = "tpgInsuranceExcludedRadiology"
        Me.tpgInsuranceExcludedRadiology.Size = New System.Drawing.Size(690, 196)
        Me.tpgInsuranceExcludedRadiology.TabIndex = 4
        Me.tpgInsuranceExcludedRadiology.Tag = "InsuranceExcludedItems"
        Me.tpgInsuranceExcludedRadiology.Text = "Excluded Radiology Examinations"
        Me.tpgInsuranceExcludedRadiology.UseVisualStyleBackColor = True
        '
        'dgvInsuranceExcludedRadiology
        '
        Me.dgvInsuranceExcludedRadiology.AllowUserToOrderColumns = True
        Me.dgvInsuranceExcludedRadiology.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedRadiology.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle14
        Me.dgvInsuranceExcludedRadiology.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colExamCode, Me.colInsuranceExcludedRadiologySaved})
        Me.dgvInsuranceExcludedRadiology.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceExcludedRadiology.EnableHeadersVisualStyles = False
        Me.dgvInsuranceExcludedRadiology.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceExcludedRadiology.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceExcludedRadiology.Name = "dgvInsuranceExcludedRadiology"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedRadiology.RowHeadersDefaultCellStyle = DataGridViewCellStyle16
        Me.dgvInsuranceExcludedRadiology.Size = New System.Drawing.Size(690, 196)
        Me.dgvInsuranceExcludedRadiology.TabIndex = 21
        Me.dgvInsuranceExcludedRadiology.Text = "DataGridView1"
        '
        'colExamCode
        '
        Me.colExamCode.DataPropertyName = "ItemCode"
        Me.colExamCode.DisplayStyleForCurrentCellOnly = True
        Me.colExamCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colExamCode.HeaderText = "Radiology Examination"
        Me.colExamCode.Name = "colExamCode"
        Me.colExamCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colExamCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colExamCode.Width = 400
        '
        'colInsuranceExcludedRadiologySaved
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle15.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle15.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle15.NullValue = False
        Me.colInsuranceExcludedRadiologySaved.DefaultCellStyle = DataGridViewCellStyle15
        Me.colInsuranceExcludedRadiologySaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceExcludedRadiologySaved.HeaderText = "Saved"
        Me.colInsuranceExcludedRadiologySaved.Name = "colInsuranceExcludedRadiologySaved"
        Me.colInsuranceExcludedRadiologySaved.ReadOnly = True
        Me.colInsuranceExcludedRadiologySaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceExcludedRadiologySaved.Width = 50
        '
        'tpgInsuranceExcludedProcedures
        '
        Me.tpgInsuranceExcludedProcedures.Controls.Add(Me.dgvInsuranceExcludedProcedures)
        Me.tpgInsuranceExcludedProcedures.Location = New System.Drawing.Point(4, 22)
        Me.tpgInsuranceExcludedProcedures.Name = "tpgInsuranceExcludedProcedures"
        Me.tpgInsuranceExcludedProcedures.Size = New System.Drawing.Size(690, 196)
        Me.tpgInsuranceExcludedProcedures.TabIndex = 5
        Me.tpgInsuranceExcludedProcedures.Tag = "InsuranceExcludedItems"
        Me.tpgInsuranceExcludedProcedures.Text = "Excluded Procedures"
        Me.tpgInsuranceExcludedProcedures.UseVisualStyleBackColor = True
        '
        'dgvInsuranceExcludedProcedures
        '
        Me.dgvInsuranceExcludedProcedures.AllowUserToOrderColumns = True
        Me.dgvInsuranceExcludedProcedures.BackgroundColor = System.Drawing.Color.GhostWhite
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedProcedures.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle17
        Me.dgvInsuranceExcludedProcedures.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colProcedureCode, Me.colInsuranceExcludedProceduresSaved})
        Me.dgvInsuranceExcludedProcedures.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvInsuranceExcludedProcedures.EnableHeadersVisualStyles = False
        Me.dgvInsuranceExcludedProcedures.GridColor = System.Drawing.Color.Khaki
        Me.dgvInsuranceExcludedProcedures.Location = New System.Drawing.Point(0, 0)
        Me.dgvInsuranceExcludedProcedures.Name = "dgvInsuranceExcludedProcedures"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvInsuranceExcludedProcedures.RowHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvInsuranceExcludedProcedures.Size = New System.Drawing.Size(690, 196)
        Me.dgvInsuranceExcludedProcedures.TabIndex = 23
        Me.dgvInsuranceExcludedProcedures.Text = "DataGridView1"
        '
        'colProcedureCode
        '
        Me.colProcedureCode.DataPropertyName = "ItemCode"
        Me.colProcedureCode.DisplayStyleForCurrentCellOnly = True
        Me.colProcedureCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colProcedureCode.HeaderText = "Procedure"
        Me.colProcedureCode.Name = "colProcedureCode"
        Me.colProcedureCode.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colProcedureCode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.colProcedureCode.Width = 400
        '
        'colInsuranceExcludedProceduresSaved
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.DarkGray
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle18.NullValue = False
        Me.colInsuranceExcludedProceduresSaved.DefaultCellStyle = DataGridViewCellStyle18
        Me.colInsuranceExcludedProceduresSaved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInsuranceExcludedProceduresSaved.HeaderText = "Saved"
        Me.colInsuranceExcludedProceduresSaved.Name = "colInsuranceExcludedProceduresSaved"
        Me.colInsuranceExcludedProceduresSaved.ReadOnly = True
        Me.colInsuranceExcludedProceduresSaved.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInsuranceExcludedProceduresSaved.Width = 50
        '
        'lblCoPayTypeID
        '
        Me.lblCoPayTypeID.Location = New System.Drawing.Point(3, 5)
        Me.lblCoPayTypeID.Name = "lblCoPayTypeID"
        Me.lblCoPayTypeID.Size = New System.Drawing.Size(107, 20)
        Me.lblCoPayTypeID.TabIndex = 0
        Me.lblCoPayTypeID.Text = "Co-Pay Type"
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.Location = New System.Drawing.Point(343, 33)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(110, 20)
        Me.lblCoPayPercent.TabIndex = 15
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.Location = New System.Drawing.Point(343, 54)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(110, 20)
        Me.lblCoPayValue.TabIndex = 17
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'pnlCoPayTypeID
        '
        Me.pnlCoPayTypeID.Controls.Add(Me.cboCoPayTypeID)
        Me.pnlCoPayTypeID.Controls.Add(Me.lblCoPayTypeID)
        Me.pnlCoPayTypeID.Location = New System.Drawing.Point(340, 2)
        Me.pnlCoPayTypeID.Name = "pnlCoPayTypeID"
        Me.pnlCoPayTypeID.Size = New System.Drawing.Size(328, 29)
        Me.pnlCoPayTypeID.TabIndex = 14
        '
        'lblAnnualPremium
        '
        Me.lblAnnualPremium.Location = New System.Drawing.Point(343, 75)
        Me.lblAnnualPremium.Name = "lblAnnualPremium"
        Me.lblAnnualPremium.Size = New System.Drawing.Size(110, 20)
        Me.lblAnnualPremium.TabIndex = 19
        Me.lblAnnualPremium.Text = "Annual Premium"
        '
        'lblMemberPremium
        '
        Me.lblMemberPremium.Location = New System.Drawing.Point(343, 96)
        Me.lblMemberPremium.Name = "lblMemberPremium"
        Me.lblMemberPremium.Size = New System.Drawing.Size(110, 20)
        Me.lblMemberPremium.TabIndex = 21
        Me.lblMemberPremium.Text = "Member Premium"
        '
        'frmInsuranceSchemes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(731, 498)
        Me.Controls.Add(Me.nbxMemberPremium)
        Me.Controls.Add(Me.lblMemberPremium)
        Me.Controls.Add(Me.nbxAnnualPremium)
        Me.Controls.Add(Me.lblAnnualPremium)
        Me.Controls.Add(Me.pnlCoPayTypeID)
        Me.Controls.Add(Me.chkSmartCardApplicable)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.tbcInsuranceExcludedItems)
        Me.Controls.Add(Me.cboInsuranceNo)
        Me.Controls.Add(Me.lblInsuranceNo)
        Me.Controls.Add(Me.cboPolicyNo)
        Me.Controls.Add(Me.lblPolicyNo)
        Me.Controls.Add(Me.pnlStatusID)
        Me.Controls.Add(Me.stbCompanyName)
        Me.Controls.Add(Me.cboCompanyNo)
        Me.Controls.Add(Me.lblCompanyName)
        Me.Controls.Add(Me.lblCompanyNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.dtpSchemeJoinDate)
        Me.Controls.Add(Me.lblSchemeJoinDate)
        Me.Controls.Add(Me.dtpSchemeStartDate)
        Me.Controls.Add(Me.lblSchemeStartDate)
        Me.Controls.Add(Me.dtpSchemeEndDate)
        Me.Controls.Add(Me.lblSchemeEndDate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmInsuranceSchemes"
        Me.Text = "Insurance Schemes"
        Me.pnlStatusID.ResumeLayout(False)
        Me.tbcInsuranceExcludedItems.ResumeLayout(False)
        Me.tpgPolicyLimits.ResumeLayout(False)
        CType(Me.dgvPolicyLimits, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInsuranceExcludedServices.ResumeLayout(False)
        CType(Me.dgvInsuranceExcludedServices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInsuranceExcludedDrugs.ResumeLayout(False)
        CType(Me.dgvInsuranceExcludedDrugs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInsuranceExcludedLabTests.ResumeLayout(False)
        CType(Me.dgvInsuranceExcludedLabTests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInsuranceExcludedRadiology.ResumeLayout(False)
        CType(Me.dgvInsuranceExcludedRadiology, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpgInsuranceExcludedProcedures.ResumeLayout(False)
        CType(Me.dgvInsuranceExcludedProcedures, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlCoPayTypeID.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents dtpSchemeJoinDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSchemeJoinDate As System.Windows.Forms.Label
    Friend WithEvents dtpSchemeStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSchemeStartDate As System.Windows.Forms.Label
    Friend WithEvents dtpSchemeEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSchemeEndDate As System.Windows.Forms.Label
    Friend WithEvents cboSchemeStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblSchemeStatusID As System.Windows.Forms.Label
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents stbCompanyName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboCompanyNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblCompanyName As System.Windows.Forms.Label
    Friend WithEvents lblCompanyNo As System.Windows.Forms.Label
    Friend WithEvents pnlStatusID As System.Windows.Forms.Panel
    Friend WithEvents cboInsuranceNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblInsuranceNo As System.Windows.Forms.Label
    Friend WithEvents cboPolicyNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblPolicyNo As System.Windows.Forms.Label
    Friend WithEvents tbcInsuranceExcludedItems As System.Windows.Forms.TabControl
    Friend WithEvents tpgInsuranceExcludedServices As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceExcludedServices As System.Windows.Forms.DataGridView
    Friend WithEvents tpgInsuranceExcludedDrugs As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceExcludedDrugs As System.Windows.Forms.DataGridView
    Friend WithEvents tpgInsuranceExcludedLabTests As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceExcludedLabTests As System.Windows.Forms.DataGridView
    Friend WithEvents tpgInsuranceExcludedRadiology As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceExcludedRadiology As System.Windows.Forms.DataGridView
    Friend WithEvents cboCoPayTypeID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCoPayTypeID As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents chkSmartCardApplicable As System.Windows.Forms.CheckBox
    Friend WithEvents pnlCoPayTypeID As System.Windows.Forms.Panel
    Friend WithEvents tpgInsuranceExcludedProcedures As System.Windows.Forms.TabPage
    Friend WithEvents dgvInsuranceExcludedProcedures As System.Windows.Forms.DataGridView
    Friend WithEvents colProcedureCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceExcludedProceduresSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colServiceCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceExcludedServicesSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colDrugNo As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceExcludedDrugsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTestCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceExcludedLabTestsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colExamCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colInsuranceExcludedRadiologySaved As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tpgPolicyLimits As System.Windows.Forms.TabPage
    Friend WithEvents dgvPolicyLimits As System.Windows.Forms.DataGridView
    Friend WithEvents nbxAnnualPremium As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAnnualPremium As System.Windows.Forms.Label
    Friend WithEvents nbxMemberPremium As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblMemberPremium As System.Windows.Forms.Label
    Friend WithEvents colBenefitCode As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents colPolicyLimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPolicyLimitsSaved As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class