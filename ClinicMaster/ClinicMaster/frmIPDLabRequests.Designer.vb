<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmIPDLabRequests
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIPDLabRequests))
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvTests = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colTestCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDrNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTubeType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSpecimen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblSpecimenDes = New System.Windows.Forms.Label()
        Me.cboRoundNo = New System.Windows.Forms.ComboBox()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.stbSpecimenNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSpecimenNo = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpDrawnDateTime = New System.Windows.Forms.DateTimePicker()
        Me.cboDrawnBy = New System.Windows.Forms.ComboBox()
        Me.clbSpecimenPrescription = New System.Windows.Forms.CheckedListBox()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblDrawnDateTime = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.stbAdmissionStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionStatus = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.lblDrawnBy = New System.Windows.Forms.Label()
        Me.btnFindRoundNo = New System.Windows.Forms.Button()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.btnViewList = New System.Windows.Forms.Button()
        Me.lblIPDAlerts = New System.Windows.Forms.Label()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForLaboratory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForLaboratory = New System.Windows.Forms.Label()
        Me.btnFindSpecimenNo = New System.Windows.Forms.Button()
        Me.chkPrintLabRequestOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.stbAttendingDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAttendingDoctor = New System.Windows.Forms.Label()
        Me.tmrIPDAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.btnLoadToLabAdmissions = New System.Windows.Forms.Button()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbAdmissionDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionDateTime = New System.Windows.Forms.Label()
        Me.btnFindAdmissionNo = New System.Windows.Forms.Button()
        Me.lblAdmissionNo = New System.Windows.Forms.Label()
        Me.stbRoundDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRoundDateTime = New System.Windows.Forms.Label()
        Me.tbcIPDLabRequests = New System.Windows.Forms.TabControl()
        Me.tpgTests = New System.Windows.Forms.TabPage()
        Me.tpgPossibleConsumables = New System.Windows.Forms.TabPage()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
        Me.pnlNavigateRounds = New System.Windows.Forms.Panel()
        Me.chkNavigateRounds = New System.Windows.Forms.CheckBox()
        Me.navRounds = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.btnPrintBarcode = New System.Windows.Forms.Button()
        Me.imgIDAutomation = New System.Windows.Forms.PictureBox()
        Me.stbDoctorContact = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDoctorContact = New System.Windows.Forms.Label()
        Me.lblAgeString = New System.Windows.Forms.Label()
        Me.chkPrintLabBarcode = New System.Windows.Forms.CheckBox()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.cmsLab = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsLabIncludeAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsLabIncludeNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.colConsumablesTestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColConsumableInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colConsumableNo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumablesConsumableName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColConUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColLocationBalance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColUnitsinstock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableExpiryDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableOrderLevel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colConsumableAlternateName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.dgvTests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBill.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        Me.tbcIPDLabRequests.SuspendLayout()
        Me.tpgTests.SuspendLayout()
        Me.tpgPossibleConsumables.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigateRounds.SuspendLayout()
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsLab.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvTests
        '
        Me.dgvTests.AllowUserToAddRows = False
        Me.dgvTests.AllowUserToDeleteRows = False
        Me.dgvTests.AllowUserToOrderColumns = True
        Me.dgvTests.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvTests.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvTests.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTests.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvTests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colTestCode, Me.colTestName, Me.ColDrNotes, Me.ColTubeType, Me.colQuantity, Me.colUnitMeasure, Me.colUnitPrice, Me.colAmount, Me.colSpecimen, Me.colLab, Me.colPayStatus, Me.colNotes})
        Me.dgvTests.ContextMenuStrip = Me.cmsLab
        Me.dgvTests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTests.EnableHeadersVisualStyles = False
        Me.dgvTests.GridColor = System.Drawing.Color.Khaki
        Me.dgvTests.Location = New System.Drawing.Point(3, 3)
        Me.dgvTests.Name = "dgvTests"
        Me.dgvTests.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTests.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dgvTests.RowHeadersVisible = False
        Me.dgvTests.Size = New System.Drawing.Size(821, 186)
        Me.dgvTests.TabIndex = 45
        Me.dgvTests.Text = "DataGridView1"
        '
        'colInclude
        '
        Me.colInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.colInclude.HeaderText = "Include"
        Me.colInclude.Name = "colInclude"
        Me.colInclude.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colInclude.Width = 50
        '
        'colTestCode
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
        Me.colTestCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.colTestCode.HeaderText = "Test Code"
        Me.colTestCode.Name = "colTestCode"
        Me.colTestCode.ReadOnly = True
        Me.colTestCode.Width = 70
        '
        'colTestName
        '
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info
        Me.colTestName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colTestName.HeaderText = "Test Name"
        Me.colTestName.Name = "colTestName"
        Me.colTestName.ReadOnly = True
        Me.colTestName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTestName.Width = 130
        '
        'ColDrNotes
        '
        Me.ColDrNotes.HeaderText = "Dr. Notes"
        Me.ColDrNotes.Name = "ColDrNotes"
        Me.ColDrNotes.Width = 130
        '
        'ColTubeType
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        Me.ColTubeType.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColTubeType.HeaderText = "Tube Type"
        Me.ColTubeType.Name = "ColTubeType"
        Me.ColTubeType.ReadOnly = True
        '
        'colQuantity
        '
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle5
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 50
        '
        'colUnitMeasure
        '
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitMeasure.DefaultCellStyle = DataGridViewCellStyle6
        Me.colUnitMeasure.HeaderText = "Unit Measure"
        Me.colUnitMeasure.Name = "colUnitMeasure"
        Me.colUnitMeasure.ReadOnly = True
        Me.colUnitMeasure.Width = 75
        '
        'colUnitPrice
        '
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle7
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 60
        '
        'colAmount
        '
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle8
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 60
        '
        'colSpecimen
        '
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        Me.colSpecimen.DefaultCellStyle = DataGridViewCellStyle9
        Me.colSpecimen.HeaderText = "Specimen"
        Me.colSpecimen.Name = "colSpecimen"
        Me.colSpecimen.ReadOnly = True
        Me.colSpecimen.Width = 60
        '
        'colLab
        '
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        Me.colLab.DefaultCellStyle = DataGridViewCellStyle10
        Me.colLab.HeaderText = "Lab"
        Me.colLab.Name = "colLab"
        Me.colLab.ReadOnly = True
        Me.colLab.Width = 75
        '
        'colPayStatus
        '
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        Me.colPayStatus.DefaultCellStyle = DataGridViewCellStyle11
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 70
        '
        'colNotes
        '
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 200
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Width = 60
        '
        'lblSpecimenDes
        '
        Me.lblSpecimenDes.Location = New System.Drawing.Point(13, 82)
        Me.lblSpecimenDes.Name = "lblSpecimenDes"
        Me.lblSpecimenDes.Size = New System.Drawing.Size(123, 20)
        Me.lblSpecimenDes.TabIndex = 10
        Me.lblSpecimenDes.Text = "Specimen Description"
        '
        'cboRoundNo
        '
        Me.cboRoundNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboRoundNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboRoundNo, "RoundNo")
        Me.cboRoundNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRoundNo.FormattingEnabled = True
        Me.cboRoundNo.Location = New System.Drawing.Point(150, 29)
        Me.cboRoundNo.MaxLength = 20
        Me.cboRoundNo.Name = "cboRoundNo"
        Me.cboRoundNo.Size = New System.Drawing.Size(115, 21)
        Me.cboRoundNo.TabIndex = 5
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(13, 29)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(89, 20)
        Me.lblRoundNo.TabIndex = 3
        Me.lblRoundNo.Text = "Round No."
        '
        'stbSpecimenNo
        '
        Me.stbSpecimenNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSpecimenNo.CapitalizeFirstLetter = False
        Me.stbSpecimenNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbSpecimenNo.EntryErrorMSG = ""
        Me.stbSpecimenNo.Location = New System.Drawing.Point(150, 53)
        Me.stbSpecimenNo.MaxLength = 20
        Me.stbSpecimenNo.Name = "stbSpecimenNo"
        Me.stbSpecimenNo.RegularExpression = ""
        Me.stbSpecimenNo.Size = New System.Drawing.Size(170, 20)
        Me.stbSpecimenNo.TabIndex = 9
        '
        'lblSpecimenNo
        '
        Me.lblSpecimenNo.Location = New System.Drawing.Point(13, 53)
        Me.lblSpecimenNo.Name = "lblSpecimenNo"
        Me.lblSpecimenNo.Size = New System.Drawing.Size(89, 20)
        Me.lblSpecimenNo.TabIndex = 7
        Me.lblSpecimenNo.Text = "Specimen No."
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(10, 499)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 46
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(769, 499)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 47
        Me.btnDelete.Tag = "LabRequests"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(10, 525)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 48
        Me.ebnSaveUpdate.Tag = "LabRequests"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpDrawnDateTime
        '
        Me.dtpDrawnDateTime.Checked = False
        Me.dtpDrawnDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpDrawnDateTime, "DrawnDateTime")
        Me.dtpDrawnDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDrawnDateTime.Location = New System.Drawing.Point(150, 147)
        Me.dtpDrawnDateTime.Name = "dtpDrawnDateTime"
        Me.dtpDrawnDateTime.ShowCheckBox = True
        Me.dtpDrawnDateTime.Size = New System.Drawing.Size(170, 20)
        Me.dtpDrawnDateTime.TabIndex = 15
        '
        'cboDrawnBy
        '
        Me.cboDrawnBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDrawnBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboDrawnBy, "DrawnByFullName")
        Me.cboDrawnBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDrawnBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDrawnBy.FormattingEnabled = True
        Me.cboDrawnBy.Location = New System.Drawing.Point(150, 123)
        Me.cboDrawnBy.Name = "cboDrawnBy"
        Me.cboDrawnBy.Size = New System.Drawing.Size(170, 21)
        Me.cboDrawnBy.TabIndex = 13
        '
        'clbSpecimenPrescription
        '
        Me.clbSpecimenPrescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbSpecimenPrescription, "SpecimenDes")
        Me.clbSpecimenPrescription.FormattingEnabled = True
        Me.clbSpecimenPrescription.Location = New System.Drawing.Point(150, 75)
        Me.clbSpecimenPrescription.Name = "clbSpecimenPrescription"
        Me.clbSpecimenPrescription.Size = New System.Drawing.Size(169, 45)
        Me.clbSpecimenPrescription.TabIndex = 119
        '
        'stbAdmissionNo
        '
        Me.stbAdmissionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionNo.CapitalizeFirstLetter = False
        Me.stbAdmissionNo.EntryErrorMSG = ""
        Me.stbAdmissionNo.Location = New System.Drawing.Point(150, 5)
        Me.stbAdmissionNo.MaxLength = 20
        Me.stbAdmissionNo.Name = "stbAdmissionNo"
        Me.stbAdmissionNo.ReadOnly = True
        Me.stbAdmissionNo.RegularExpression = ""
        Me.stbAdmissionNo.Size = New System.Drawing.Size(170, 20)
        Me.stbAdmissionNo.TabIndex = 2
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(769, 525)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 51
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblDrawnDateTime
        '
        Me.lblDrawnDateTime.Location = New System.Drawing.Point(13, 147)
        Me.lblDrawnDateTime.Name = "lblDrawnDateTime"
        Me.lblDrawnDateTime.Size = New System.Drawing.Size(123, 20)
        Me.lblDrawnDateTime.TabIndex = 14
        Me.lblDrawnDateTime.Text = "Drawn Date and Time"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(468, 43)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(126, 20)
        Me.stbPatientNo.TabIndex = 23
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(340, 45)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(124, 20)
        Me.lblPatientsNo.TabIndex = 22
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(690, 66)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(126, 20)
        Me.stbBillMode.TabIndex = 39
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(690, 130)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(126, 20)
        Me.stbVisitCategory.TabIndex = 43
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(598, 66)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(86, 20)
        Me.lblBillMode.TabIndex = 38
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(601, 131)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(83, 20)
        Me.lblVisitCategory.TabIndex = 42
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbAdmissionStatus
        '
        Me.stbAdmissionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionStatus.CapitalizeFirstLetter = False
        Me.stbAdmissionStatus.Enabled = False
        Me.stbAdmissionStatus.EntryErrorMSG = ""
        Me.stbAdmissionStatus.Location = New System.Drawing.Point(690, 24)
        Me.stbAdmissionStatus.MaxLength = 60
        Me.stbAdmissionStatus.Name = "stbAdmissionStatus"
        Me.stbAdmissionStatus.RegularExpression = ""
        Me.stbAdmissionStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionStatus.Size = New System.Drawing.Size(126, 20)
        Me.stbAdmissionStatus.TabIndex = 35
        '
        'lblAdmissionStatus
        '
        Me.lblAdmissionStatus.Location = New System.Drawing.Point(598, 24)
        Me.lblAdmissionStatus.Name = "lblAdmissionStatus"
        Me.lblAdmissionStatus.Size = New System.Drawing.Size(86, 20)
        Me.lblAdmissionStatus.TabIndex = 34
        Me.lblAdmissionStatus.Text = "Status"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(468, 64)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(126, 20)
        Me.stbBillNo.TabIndex = 25
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(690, 3)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(51, 20)
        Me.stbAge.TabIndex = 33
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(691, 108)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(124, 20)
        Me.stbJoinDate.TabIndex = 41
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(690, 45)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(126, 20)
        Me.stbGender.TabIndex = 37
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(600, 109)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(86, 20)
        Me.lblJoinDate.TabIndex = 40
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(340, 66)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(124, 20)
        Me.lblBillNo.TabIndex = 24
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(598, 3)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(86, 20)
        Me.lblAge.TabIndex = 32
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(598, 45)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(86, 20)
        Me.lblGenderID.TabIndex = 36
        Me.lblGenderID.Text = "Gender"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(468, 22)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(126, 20)
        Me.stbFullName.TabIndex = 21
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(340, 24)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(124, 20)
        Me.lblFullName.TabIndex = 20
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(690, 87)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(126, 20)
        Me.stbVisitDate.TabIndex = 19
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(598, 89)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(88, 20)
        Me.lblVisitDate.TabIndex = 18
        Me.lblVisitDate.Text = "Visit Date"
        '
        'lblDrawnBy
        '
        Me.lblDrawnBy.Location = New System.Drawing.Point(13, 126)
        Me.lblDrawnBy.Name = "lblDrawnBy"
        Me.lblDrawnBy.Size = New System.Drawing.Size(123, 20)
        Me.lblDrawnBy.TabIndex = 12
        Me.lblDrawnBy.Text = "Drawn By (Staff)"
        '
        'btnFindRoundNo
        '
        Me.btnFindRoundNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindRoundNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindRoundNo.Image = CType(resources.GetObject("btnFindRoundNo.Image"), System.Drawing.Image)
        Me.btnFindRoundNo.Location = New System.Drawing.Point(117, 29)
        Me.btnFindRoundNo.Name = "btnFindRoundNo"
        Me.btnFindRoundNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindRoundNo.TabIndex = 4
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.pnlAlerts)
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForLaboratory)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForLaboratory)
        Me.pnlBill.Location = New System.Drawing.Point(10, 193)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(838, 64)
        Me.pnlBill.TabIndex = 44
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnReject)
        Me.pnlAlerts.Controls.Add(Me.btnViewList)
        Me.pnlAlerts.Controls.Add(Me.lblIPDAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(3, 27)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(434, 33)
        Me.pnlAlerts.TabIndex = 4
        '
        'btnReject
        '
        Me.btnReject.AccessibleDescription = ""
        Me.btnReject.Enabled = False
        Me.btnReject.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReject.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReject.Location = New System.Drawing.Point(340, 5)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(87, 24)
        Me.btnReject.TabIndex = 7
        Me.btnReject.Tag = ""
        Me.btnReject.Text = "&Reject"
        '
        'btnViewList
        '
        Me.btnViewList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewList.Location = New System.Drawing.Point(247, 6)
        Me.btnViewList.Name = "btnViewList"
        Me.btnViewList.Size = New System.Drawing.Size(63, 24)
        Me.btnViewList.TabIndex = 1
        Me.btnViewList.Tag = ""
        Me.btnViewList.Text = "&View List"
        '
        'lblIPDAlerts
        '
        Me.lblIPDAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIPDAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblIPDAlerts.Location = New System.Drawing.Point(6, 8)
        Me.lblIPDAlerts.Name = "lblIPDAlerts"
        Me.lblIPDAlerts.Size = New System.Drawing.Size(210, 20)
        Me.lblIPDAlerts.TabIndex = 0
        Me.lblIPDAlerts.Text = "Doctor Lab Requests: 0"
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(334, 6)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(103, 18)
        Me.lblBillWords.TabIndex = 2
        Me.lblBillWords.Text = "Bill in Words"
        '
        'stbBillForLaboratory
        '
        Me.stbBillForLaboratory.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillForLaboratory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillForLaboratory.CapitalizeFirstLetter = False
        Me.stbBillForLaboratory.Enabled = False
        Me.stbBillForLaboratory.EntryErrorMSG = ""
        Me.stbBillForLaboratory.Location = New System.Drawing.Point(140, 4)
        Me.stbBillForLaboratory.MaxLength = 20
        Me.stbBillForLaboratory.Name = "stbBillForLaboratory"
        Me.stbBillForLaboratory.RegularExpression = ""
        Me.stbBillForLaboratory.Size = New System.Drawing.Size(169, 20)
        Me.stbBillForLaboratory.TabIndex = 1
        Me.stbBillForLaboratory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(443, 3)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(363, 35)
        Me.stbBillWords.TabIndex = 3
        '
        'lblBillForLaboratory
        '
        Me.lblBillForLaboratory.Location = New System.Drawing.Point(8, 6)
        Me.lblBillForLaboratory.Name = "lblBillForLaboratory"
        Me.lblBillForLaboratory.Size = New System.Drawing.Size(121, 18)
        Me.lblBillForLaboratory.TabIndex = 0
        Me.lblBillForLaboratory.Text = "Bill for Laboratory"
        '
        'btnFindSpecimenNo
        '
        Me.btnFindSpecimenNo.Enabled = False
        Me.btnFindSpecimenNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindSpecimenNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindSpecimenNo.Image = CType(resources.GetObject("btnFindSpecimenNo.Image"), System.Drawing.Image)
        Me.btnFindSpecimenNo.Location = New System.Drawing.Point(117, 51)
        Me.btnFindSpecimenNo.Name = "btnFindSpecimenNo"
        Me.btnFindSpecimenNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindSpecimenNo.TabIndex = 8
        '
        'chkPrintLabRequestOnSaving
        '
        Me.chkPrintLabRequestOnSaving.AccessibleDescription = ""
        Me.chkPrintLabRequestOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintLabRequestOnSaving.AutoSize = True
        Me.chkPrintLabRequestOnSaving.Checked = True
        Me.chkPrintLabRequestOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintLabRequestOnSaving.Location = New System.Drawing.Point(99, 529)
        Me.chkPrintLabRequestOnSaving.Name = "chkPrintLabRequestOnSaving"
        Me.chkPrintLabRequestOnSaving.Size = New System.Drawing.Size(167, 17)
        Me.chkPrintLabRequestOnSaving.TabIndex = 49
        Me.chkPrintLabRequestOnSaving.Text = " Print Lab Request On Saving"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(682, 524)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(78, 24)
        Me.btnPrint.TabIndex = 50
        Me.btnPrint.Text = "&Print"
        '
        'stbAttendingDoctor
        '
        Me.stbAttendingDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAttendingDoctor.CapitalizeFirstLetter = False
        Me.stbAttendingDoctor.Enabled = False
        Me.stbAttendingDoctor.EntryErrorMSG = ""
        Me.stbAttendingDoctor.Location = New System.Drawing.Point(468, 85)
        Me.stbAttendingDoctor.MaxLength = 60
        Me.stbAttendingDoctor.Name = "stbAttendingDoctor"
        Me.stbAttendingDoctor.RegularExpression = ""
        Me.stbAttendingDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAttendingDoctor.Size = New System.Drawing.Size(126, 20)
        Me.stbAttendingDoctor.TabIndex = 27
        '
        'lblAttendingDoctor
        '
        Me.lblAttendingDoctor.Location = New System.Drawing.Point(340, 86)
        Me.lblAttendingDoctor.Name = "lblAttendingDoctor"
        Me.lblAttendingDoctor.Size = New System.Drawing.Size(124, 20)
        Me.lblAttendingDoctor.TabIndex = 26
        Me.lblAttendingDoctor.Text = "Attending Doctor"
        '
        'tmrIPDAlerts
        '
        Me.tmrIPDAlerts.Enabled = True
        Me.tmrIPDAlerts.Interval = 120000
        '
        'btnLoadToLabAdmissions
        '
        Me.btnLoadToLabAdmissions.AccessibleDescription = ""
        Me.btnLoadToLabAdmissions.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadToLabAdmissions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadToLabAdmissions.Location = New System.Drawing.Point(271, 26)
        Me.btnLoadToLabAdmissions.Name = "btnLoadToLabAdmissions"
        Me.btnLoadToLabAdmissions.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadToLabAdmissions.TabIndex = 6
        Me.btnLoadToLabAdmissions.Tag = ""
        Me.btnLoadToLabAdmissions.Text = "&Load"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(468, 3)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(126, 20)
        Me.stbVisitNo.TabIndex = 17
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(341, 5)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(123, 20)
        Me.lblVisitNo.TabIndex = 16
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbAdmissionDateTime
        '
        Me.stbAdmissionDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionDateTime.CapitalizeFirstLetter = False
        Me.stbAdmissionDateTime.Enabled = False
        Me.stbAdmissionDateTime.EntryErrorMSG = ""
        Me.stbAdmissionDateTime.Location = New System.Drawing.Point(468, 128)
        Me.stbAdmissionDateTime.MaxLength = 60
        Me.stbAdmissionDateTime.Name = "stbAdmissionDateTime"
        Me.stbAdmissionDateTime.RegularExpression = ""
        Me.stbAdmissionDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionDateTime.Size = New System.Drawing.Size(126, 20)
        Me.stbAdmissionDateTime.TabIndex = 29
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(340, 130)
        Me.lblAdmissionDateTime.Name = "lblAdmissionDateTime"
        Me.lblAdmissionDateTime.Size = New System.Drawing.Size(124, 20)
        Me.lblAdmissionDateTime.TabIndex = 28
        Me.lblAdmissionDateTime.Text = "Admission Date Time"
        '
        'btnFindAdmissionNo
        '
        Me.btnFindAdmissionNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindAdmissionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindAdmissionNo.Image = CType(resources.GetObject("btnFindAdmissionNo.Image"), System.Drawing.Image)
        Me.btnFindAdmissionNo.Location = New System.Drawing.Point(117, 6)
        Me.btnFindAdmissionNo.Name = "btnFindAdmissionNo"
        Me.btnFindAdmissionNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindAdmissionNo.TabIndex = 1
        '
        'lblAdmissionNo
        '
        Me.lblAdmissionNo.AccessibleDescription = " "
        Me.lblAdmissionNo.Location = New System.Drawing.Point(13, 5)
        Me.lblAdmissionNo.Name = "lblAdmissionNo"
        Me.lblAdmissionNo.Size = New System.Drawing.Size(89, 20)
        Me.lblAdmissionNo.TabIndex = 0
        Me.lblAdmissionNo.Text = "Admission No"
        '
        'stbRoundDateTime
        '
        Me.stbRoundDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundDateTime.CapitalizeFirstLetter = False
        Me.stbRoundDateTime.Enabled = False
        Me.stbRoundDateTime.EntryErrorMSG = ""
        Me.stbRoundDateTime.Location = New System.Drawing.Point(468, 150)
        Me.stbRoundDateTime.MaxLength = 60
        Me.stbRoundDateTime.Name = "stbRoundDateTime"
        Me.stbRoundDateTime.RegularExpression = ""
        Me.stbRoundDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRoundDateTime.Size = New System.Drawing.Size(126, 20)
        Me.stbRoundDateTime.TabIndex = 31
        '
        'lblRoundDateTime
        '
        Me.lblRoundDateTime.Location = New System.Drawing.Point(340, 150)
        Me.lblRoundDateTime.Name = "lblRoundDateTime"
        Me.lblRoundDateTime.Size = New System.Drawing.Size(124, 20)
        Me.lblRoundDateTime.TabIndex = 30
        Me.lblRoundDateTime.Text = "Round Date and Time"
        '
        'tbcIPDLabRequests
        '
        Me.tbcIPDLabRequests.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcIPDLabRequests.Controls.Add(Me.tpgTests)
        Me.tbcIPDLabRequests.Controls.Add(Me.tpgPossibleConsumables)
        Me.tbcIPDLabRequests.Location = New System.Drawing.Point(6, 263)
        Me.tbcIPDLabRequests.Name = "tbcIPDLabRequests"
        Me.tbcIPDLabRequests.SelectedIndex = 0
        Me.tbcIPDLabRequests.Size = New System.Drawing.Size(835, 218)
        Me.tbcIPDLabRequests.TabIndex = 5
        '
        'tpgTests
        '
        Me.tpgTests.Controls.Add(Me.dgvTests)
        Me.tpgTests.Location = New System.Drawing.Point(4, 22)
        Me.tpgTests.Name = "tpgTests"
        Me.tpgTests.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgTests.Size = New System.Drawing.Size(827, 192)
        Me.tpgTests.TabIndex = 0
        Me.tpgTests.Text = "Tests"
        Me.tpgTests.UseVisualStyleBackColor = True
        '
        'tpgPossibleConsumables
        '
        Me.tpgPossibleConsumables.Controls.Add(Me.dgvConsumables)
        Me.tpgPossibleConsumables.Location = New System.Drawing.Point(4, 22)
        Me.tpgPossibleConsumables.Name = "tpgPossibleConsumables"
        Me.tpgPossibleConsumables.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgPossibleConsumables.Size = New System.Drawing.Size(827, 192)
        Me.tpgPossibleConsumables.TabIndex = 1
        Me.tpgPossibleConsumables.Text = "Possible Consumables"
        Me.tpgPossibleConsumables.UseVisualStyleBackColor = True
        '
        'dgvConsumables
        '
        Me.dgvConsumables.AllowUserToAddRows = False
        Me.dgvConsumables.AllowUserToDeleteRows = False
        Me.dgvConsumables.AllowUserToOrderColumns = True
        Me.dgvConsumables.BackgroundColor = System.Drawing.Color.GhostWhite
        Me.dgvConsumables.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvConsumables.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumablesTestName, Me.ColConsumableInclude, Me.colConsumableNo, Me.colConsumablesConsumableName, Me.ColConUnitMeasure, Me.colConsumableQuantity, Me.colConsumableNotes, Me.ColLocationBalance, Me.ColUnitsinstock, Me.colConsumableExpiryDate, Me.colConsumableOrderLevel, Me.colConsumableAlternateName})
        Me.dgvConsumables.ContextMenuStrip = Me.cmsLab
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.DefaultCellStyle = DataGridViewCellStyle25
        Me.dgvConsumables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(3, 3)
        Me.dgvConsumables.Name = "dgvConsumables"
        Me.dgvConsumables.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle26.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle26
        Me.dgvConsumables.RowHeadersVisible = False
        Me.dgvConsumables.Size = New System.Drawing.Size(821, 186)
        Me.dgvConsumables.TabIndex = 44
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'pnlNavigateRounds
        '
        Me.pnlNavigateRounds.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateRounds.Controls.Add(Me.chkNavigateRounds)
        Me.pnlNavigateRounds.Controls.Add(Me.navRounds)
        Me.pnlNavigateRounds.Location = New System.Drawing.Point(105, 487)
        Me.pnlNavigateRounds.Name = "pnlNavigateRounds"
        Me.pnlNavigateRounds.Size = New System.Drawing.Size(619, 35)
        Me.pnlNavigateRounds.TabIndex = 118
        '
        'chkNavigateRounds
        '
        Me.chkNavigateRounds.AccessibleDescription = ""
        Me.chkNavigateRounds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateRounds.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateRounds.Location = New System.Drawing.Point(3, 7)
        Me.chkNavigateRounds.Name = "chkNavigateRounds"
        Me.chkNavigateRounds.Size = New System.Drawing.Size(181, 20)
        Me.chkNavigateRounds.TabIndex = 0
        Me.chkNavigateRounds.Text = "Navigate Admission Rounds"
        '
        'navRounds
        '
        Me.navRounds.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navRounds.ColumnName = "RoundNo"
        Me.navRounds.DataSource = Nothing
        Me.navRounds.Location = New System.Drawing.Point(190, 1)
        Me.navRounds.Name = "navRounds"
        Me.navRounds.NavAllEnabled = False
        Me.navRounds.NavLeftEnabled = False
        Me.navRounds.NavRightEnabled = False
        Me.navRounds.Size = New System.Drawing.Size(423, 32)
        Me.navRounds.TabIndex = 1
        '
        'btnPrintBarcode
        '
        Me.btnPrintBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintBarcode.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintBarcode.Location = New System.Drawing.Point(569, 525)
        Me.btnPrintBarcode.Name = "btnPrintBarcode"
        Me.btnPrintBarcode.Size = New System.Drawing.Size(109, 24)
        Me.btnPrintBarcode.TabIndex = 121
        Me.btnPrintBarcode.Text = "&Print Barcode"
        '
        'imgIDAutomation
        '
        Me.imgIDAutomation.Location = New System.Drawing.Point(149, 193)
        Me.imgIDAutomation.Name = "imgIDAutomation"
        Me.imgIDAutomation.Size = New System.Drawing.Size(200, 50)
        Me.imgIDAutomation.TabIndex = 122
        Me.imgIDAutomation.TabStop = False
        '
        'stbDoctorContact
        '
        Me.stbDoctorContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDoctorContact.CapitalizeFirstLetter = False
        Me.stbDoctorContact.Enabled = False
        Me.stbDoctorContact.EntryErrorMSG = ""
        Me.stbDoctorContact.Location = New System.Drawing.Point(468, 106)
        Me.stbDoctorContact.MaxLength = 60
        Me.stbDoctorContact.Name = "stbDoctorContact"
        Me.stbDoctorContact.RegularExpression = ""
        Me.stbDoctorContact.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDoctorContact.Size = New System.Drawing.Size(126, 20)
        Me.stbDoctorContact.TabIndex = 124
        '
        'lblDoctorContact
        '
        Me.lblDoctorContact.Location = New System.Drawing.Point(340, 107)
        Me.lblDoctorContact.Name = "lblDoctorContact"
        Me.lblDoctorContact.Size = New System.Drawing.Size(124, 20)
        Me.lblDoctorContact.TabIndex = 123
        Me.lblDoctorContact.Text = "Doctor Contact"
        '
        'lblAgeString
        '
        Me.lblAgeString.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgeString.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAgeString.Location = New System.Drawing.Point(747, 3)
        Me.lblAgeString.Name = "lblAgeString"
        Me.lblAgeString.Size = New System.Drawing.Size(101, 19)
        Me.lblAgeString.TabIndex = 125
        '
        'chkPrintLabBarcode
        '
        Me.chkPrintLabBarcode.AccessibleDescription = ""
        Me.chkPrintLabBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintLabBarcode.AutoSize = True
        Me.chkPrintLabBarcode.Location = New System.Drawing.Point(278, 528)
        Me.chkPrintLabBarcode.Name = "chkPrintLabBarcode"
        Me.chkPrintLabBarcode.Size = New System.Drawing.Size(114, 17)
        Me.chkPrintLabBarcode.TabIndex = 126
        Me.chkPrintLabBarcode.Text = " Print Lab Barcode"
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(150, 168)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(170, 21)
        Me.cboLocationID.TabIndex = 128
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(13, 171)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(106, 20)
        Me.lblLocationID.TabIndex = 127
        Me.lblLocationID.Text = "Location"
        '
        'cmsLab
        '
        Me.cmsLab.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsLab.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsLabIncludeAll, Me.cmsLabIncludeNone})
        Me.cmsLab.Name = "cmsSearch"
        Me.cmsLab.Size = New System.Drawing.Size(146, 48)
        '
        'cmsLabIncludeAll
        '
        Me.cmsLabIncludeAll.Name = "cmsLabIncludeAll"
        Me.cmsLabIncludeAll.Size = New System.Drawing.Size(145, 22)
        Me.cmsLabIncludeAll.Text = "Include All"
        '
        'cmsLabIncludeNone
        '
        Me.cmsLabIncludeNone.Name = "cmsLabIncludeNone"
        Me.cmsLabIncludeNone.Size = New System.Drawing.Size(145, 22)
        Me.cmsLabIncludeNone.Text = "Include None"
        '
        'colConsumablesTestName
        '
        Me.colConsumablesTestName.DataPropertyName = "TestName"
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumablesTestName.DefaultCellStyle = DataGridViewCellStyle14
        Me.colConsumablesTestName.HeaderText = "Test Name"
        Me.colConsumablesTestName.Name = "colConsumablesTestName"
        Me.colConsumablesTestName.ReadOnly = True
        Me.colConsumablesTestName.Visible = False
        Me.colConsumablesTestName.Width = 150
        '
        'ColConsumableInclude
        '
        Me.ColConsumableInclude.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ColConsumableInclude.HeaderText = "Include"
        Me.ColConsumableInclude.Name = "ColConsumableInclude"
        Me.ColConsumableInclude.Width = 50
        '
        'colConsumableNo
        '
        Me.colConsumableNo.DataPropertyName = "ItemCode"
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableNo.DefaultCellStyle = DataGridViewCellStyle15
        Me.colConsumableNo.HeaderText = "Consumable No"
        Me.colConsumableNo.Name = "colConsumableNo"
        Me.colConsumableNo.ReadOnly = True
        '
        'colConsumablesConsumableName
        '
        Me.colConsumablesConsumableName.DataPropertyName = "ConsumableName"
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumablesConsumableName.DefaultCellStyle = DataGridViewCellStyle16
        Me.colConsumablesConsumableName.HeaderText = "Consumable Name"
        Me.colConsumablesConsumableName.Name = "colConsumablesConsumableName"
        Me.colConsumablesConsumableName.ReadOnly = True
        Me.colConsumablesConsumableName.Width = 150
        '
        'ColConUnitMeasure
        '
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        Me.ColConUnitMeasure.DefaultCellStyle = DataGridViewCellStyle17
        Me.ColConUnitMeasure.HeaderText = "Unit Measure"
        Me.ColConUnitMeasure.Name = "ColConUnitMeasure"
        Me.ColConUnitMeasure.ReadOnly = True
        Me.ColConUnitMeasure.Width = 90
        '
        'colConsumableQuantity
        '
        Me.colConsumableQuantity.DataPropertyName = "Quantity"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle18.Format = "N0"
        DataGridViewCellStyle18.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle18.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle18
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.ReadOnly = True
        Me.colConsumableQuantity.Width = 80
        '
        'colConsumableNotes
        '
        Me.colConsumableNotes.DataPropertyName = "Notes"
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableNotes.DefaultCellStyle = DataGridViewCellStyle19
        Me.colConsumableNotes.FillWeight = 4.566049!
        Me.colConsumableNotes.HeaderText = "Notes"
        Me.colConsumableNotes.MaxInputLength = 40
        Me.colConsumableNotes.Name = "colConsumableNotes"
        Me.colConsumableNotes.ReadOnly = True
        Me.colConsumableNotes.Width = 150
        '
        'ColLocationBalance
        '
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.ColLocationBalance.DefaultCellStyle = DataGridViewCellStyle20
        Me.ColLocationBalance.HeaderText = "Location Balance"
        Me.ColLocationBalance.Name = "ColLocationBalance"
        Me.ColLocationBalance.ReadOnly = True
        '
        'ColUnitsinstock
        '
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        Me.ColUnitsinstock.DefaultCellStyle = DataGridViewCellStyle21
        Me.ColUnitsinstock.HeaderText = "Units In Stock"
        Me.ColUnitsinstock.Name = "ColUnitsinstock"
        Me.ColUnitsinstock.ReadOnly = True
        Me.ColUnitsinstock.Width = 120
        '
        'colConsumableExpiryDate
        '
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableExpiryDate.DefaultCellStyle = DataGridViewCellStyle22
        Me.colConsumableExpiryDate.HeaderText = "Expiry Date"
        Me.colConsumableExpiryDate.Name = "colConsumableExpiryDate"
        Me.colConsumableExpiryDate.ReadOnly = True
        '
        'colConsumableOrderLevel
        '
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableOrderLevel.DefaultCellStyle = DataGridViewCellStyle23
        Me.colConsumableOrderLevel.HeaderText = "Order Level"
        Me.colConsumableOrderLevel.Name = "colConsumableOrderLevel"
        Me.colConsumableOrderLevel.ReadOnly = True
        '
        'colConsumableAlternateName
        '
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableAlternateName.DefaultCellStyle = DataGridViewCellStyle24
        Me.colConsumableAlternateName.HeaderText = "Consumable Alternate Name"
        Me.colConsumableAlternateName.Name = "colConsumableAlternateName"
        Me.colConsumableAlternateName.ReadOnly = True
        Me.colConsumableAlternateName.Width = 150
        '
        'frmIPDLabRequests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(848, 552)
        Me.Controls.Add(Me.cboLocationID)
        Me.Controls.Add(Me.lblLocationID)
        Me.Controls.Add(Me.chkPrintLabBarcode)
        Me.Controls.Add(Me.lblAgeString)
        Me.Controls.Add(Me.stbDoctorContact)
        Me.Controls.Add(Me.lblDoctorContact)
        Me.Controls.Add(Me.btnPrintBarcode)
        Me.Controls.Add(Me.clbSpecimenPrescription)
        Me.Controls.Add(Me.pnlNavigateRounds)
        Me.Controls.Add(Me.tbcIPDLabRequests)
        Me.Controls.Add(Me.stbRoundDateTime)
        Me.Controls.Add(Me.lblRoundDateTime)
        Me.Controls.Add(Me.stbAdmissionNo)
        Me.Controls.Add(Me.btnFindAdmissionNo)
        Me.Controls.Add(Me.lblAdmissionNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbAdmissionDateTime)
        Me.Controls.Add(Me.lblAdmissionDateTime)
        Me.Controls.Add(Me.btnLoadToLabAdmissions)
        Me.Controls.Add(Me.stbAttendingDoctor)
        Me.Controls.Add(Me.lblAttendingDoctor)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.chkPrintLabRequestOnSaving)
        Me.Controls.Add(Me.btnFindSpecimenNo)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.btnFindRoundNo)
        Me.Controls.Add(Me.cboDrawnBy)
        Me.Controls.Add(Me.lblDrawnBy)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.stbVisitCategory)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.lblVisitCategory)
        Me.Controls.Add(Me.stbAdmissionStatus)
        Me.Controls.Add(Me.lblAdmissionStatus)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.lblDrawnDateTime)
        Me.Controls.Add(Me.dtpDrawnDateTime)
        Me.Controls.Add(Me.cboRoundNo)
        Me.Controls.Add(Me.lblRoundNo)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblSpecimenDes)
        Me.Controls.Add(Me.stbSpecimenNo)
        Me.Controls.Add(Me.lblSpecimenNo)
        Me.Controls.Add(Me.imgIDAutomation)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmIPDLabRequests"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "IPD Lab Requests"
        CType(Me.dgvTests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.pnlAlerts.ResumeLayout(False)
        Me.tbcIPDLabRequests.ResumeLayout(False)
        Me.tpgTests.ResumeLayout(False)
        Me.tpgPossibleConsumables.ResumeLayout(False)
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigateRounds.ResumeLayout(False)
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsLab.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvTests As System.Windows.Forms.DataGridView
    Friend WithEvents lblSpecimenDes As System.Windows.Forms.Label
    Friend WithEvents cboRoundNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents stbSpecimenNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSpecimenNo As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblDrawnDateTime As System.Windows.Forms.Label
    Friend WithEvents dtpDrawnDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitCategory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents lblVisitCategory As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionStatus As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents cboDrawnBy As System.Windows.Forms.ComboBox
    Friend WithEvents lblDrawnBy As System.Windows.Forms.Label
    Friend WithEvents btnFindRoundNo As System.Windows.Forms.Button
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForLaboratory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForLaboratory As System.Windows.Forms.Label
    Friend WithEvents btnFindSpecimenNo As System.Windows.Forms.Button
    Friend WithEvents chkPrintLabRequestOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents stbAttendingDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAttendingDoctor As System.Windows.Forms.Label
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnViewList As System.Windows.Forms.Button
    Friend WithEvents lblIPDAlerts As System.Windows.Forms.Label
    Friend WithEvents tmrIPDAlerts As System.Windows.Forms.Timer
    Friend WithEvents btnLoadToLabAdmissions As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionDateTime As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindAdmissionNo As System.Windows.Forms.Button
    Friend WithEvents lblAdmissionNo As System.Windows.Forms.Label
    Friend WithEvents stbRoundDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoundDateTime As System.Windows.Forms.Label
    Friend WithEvents tbcIPDLabRequests As System.Windows.Forms.TabControl
    Friend WithEvents tpgTests As System.Windows.Forms.TabPage
    Friend WithEvents tpgPossibleConsumables As System.Windows.Forms.TabPage
    Friend WithEvents pnlNavigateRounds As System.Windows.Forms.Panel
    Friend WithEvents chkNavigateRounds As System.Windows.Forms.CheckBox
    Friend WithEvents navRounds As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents clbSpecimenPrescription As System.Windows.Forms.CheckedListBox
    Friend WithEvents btnReject As System.Windows.Forms.Button
    Friend WithEvents btnPrintBarcode As System.Windows.Forms.Button
    Friend WithEvents imgIDAutomation As System.Windows.Forms.PictureBox
    Friend WithEvents stbDoctorContact As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDoctorContact As System.Windows.Forms.Label
    Friend WithEvents lblAgeString As System.Windows.Forms.Label
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTestCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDrNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTubeType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSpecimen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents chkPrintLabBarcode As System.Windows.Forms.CheckBox
    Friend WithEvents dgvConsumables As System.Windows.Forms.DataGridView
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents cmsLab As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents cmsLabIncludeAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmsLabIncludeNone As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents colConsumablesTestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColConsumableInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colConsumableNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumablesConsumableName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColConUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColLocationBalance As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColUnitsinstock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableExpiryDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableOrderLevel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colConsumableAlternateName As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
