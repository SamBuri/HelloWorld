<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmLabRequests
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
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLabRequests))
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvTests = New System.Windows.Forms.DataGridView()
        Me.colInclude = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.colTestCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colTestName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDrNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColclinicalNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColProvisionalDiagnosis = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColTubeType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colQuantity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitMeasure = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colUnitPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colSpecimen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colLab = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colNotes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.colCashPayStatus = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cmsLab = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.cmsLabIncludeAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmsLabIncludeNone = New System.Windows.Forms.ToolStripMenuItem()
        Me.lblSpecimenDes = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbSpecimenNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSpecimenNo = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpDrawnDateTime = New System.Windows.Forms.DateTimePicker()
        Me.cboDrawnBy = New System.Windows.Forms.ComboBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.clbSpecimenPrescription = New System.Windows.Forms.CheckedListBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblDrawnDateTime = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.stbStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
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
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.pnlBill = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnViewIPDLabRequests = New System.Windows.Forms.Button()
        Me.lblIPDAlerts = New System.Windows.Forms.Label()
        Me.btnReject = New System.Windows.Forms.Button()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnViewList = New System.Windows.Forms.Button()
        Me.lblAlerts = New System.Windows.Forms.Label()
        Me.lblBillWords = New System.Windows.Forms.Label()
        Me.stbBillForLaboratory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbBillWords = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillForLaboratory = New System.Windows.Forms.Label()
        Me.btnFindSpecimenNo = New System.Windows.Forms.Button()
        Me.chkPrintLabRequestOnSaving = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.btnLoadToLabVisits = New System.Windows.Forms.Button()
        Me.chkSmartCardApplicable = New System.Windows.Forms.CheckBox()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.tbcLabRequests = New System.Windows.Forms.TabControl()
        Me.tpgTests = New System.Windows.Forms.TabPage()
        Me.tpgPossibleConsumables = New System.Windows.Forms.TabPage()
        Me.dgvConsumables = New System.Windows.Forms.DataGridView()
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
        Me.lblLocationID = New System.Windows.Forms.Label()
        Me.stbPackage = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPackageName = New System.Windows.Forms.Label()
        Me.imgIDAutomation = New System.Windows.Forms.PictureBox()
        Me.btnPrintBarcode = New System.Windows.Forms.Button()
        Me.cboLocationID = New System.Windows.Forms.ComboBox()
        Me.stbDoctorContact = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblDoctorContact = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.lblAgeString = New System.Windows.Forms.Label()
        Me.chkPrintLabBarcode = New System.Windows.Forms.CheckBox()
        CType(Me.dgvTests, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.cmsLab.SuspendLayout()
        Me.pnlBill.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnlAlerts.SuspendLayout()
        Me.tbcLabRequests.SuspendLayout()
        Me.tpgTests.SuspendLayout()
        Me.tpgPossibleConsumables.SuspendLayout()
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.dgvTests.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colInclude, Me.colTestCode, Me.colTestName, Me.ColDrNotes, Me.ColclinicalNotes, Me.ColProvisionalDiagnosis, Me.ColTubeType, Me.colQuantity, Me.colUnitMeasure, Me.colUnitPrice, Me.colAmount, Me.colSpecimen, Me.colLab, Me.colPayStatus, Me.colNotes, Me.colCashAmount, Me.colCashPayStatus})
        Me.dgvTests.ContextMenuStrip = Me.cmsLab
        Me.dgvTests.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvTests.EnableHeadersVisualStyles = False
        Me.dgvTests.GridColor = System.Drawing.Color.Khaki
        Me.dgvTests.Location = New System.Drawing.Point(3, 3)
        Me.dgvTests.Name = "dgvTests"
        Me.dgvTests.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle18.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvTests.RowHeadersDefaultCellStyle = DataGridViewCellStyle18
        Me.dgvTests.RowHeadersVisible = False
        Me.dgvTests.Size = New System.Drawing.Size(895, 208)
        Me.dgvTests.TabIndex = 0
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
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colTestName.DefaultCellStyle = DataGridViewCellStyle3
        Me.colTestName.HeaderText = "Test Name"
        Me.colTestName.Name = "colTestName"
        Me.colTestName.ReadOnly = True
        Me.colTestName.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.colTestName.Width = 130
        '
        'ColDrNotes
        '
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColDrNotes.DefaultCellStyle = DataGridViewCellStyle4
        Me.ColDrNotes.HeaderText = "Dr.  Notes"
        Me.ColDrNotes.Name = "ColDrNotes"
        Me.ColDrNotes.ReadOnly = True
        Me.ColDrNotes.Width = 120
        '
        'ColclinicalNotes
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColclinicalNotes.DefaultCellStyle = DataGridViewCellStyle5
        Me.ColclinicalNotes.HeaderText = "Clinical Notes"
        Me.ColclinicalNotes.Name = "ColclinicalNotes"
        Me.ColclinicalNotes.ReadOnly = True
        Me.ColclinicalNotes.Width = 120
        '
        'ColProvisionalDiagnosis
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColProvisionalDiagnosis.DefaultCellStyle = DataGridViewCellStyle6
        Me.ColProvisionalDiagnosis.HeaderText = "Provisional Diagnosis"
        Me.ColProvisionalDiagnosis.Name = "ColProvisionalDiagnosis"
        Me.ColProvisionalDiagnosis.ReadOnly = True
        Me.ColProvisionalDiagnosis.Width = 150
        '
        'ColTubeType
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ColTubeType.DefaultCellStyle = DataGridViewCellStyle7
        Me.ColTubeType.HeaderText = "Tube Type"
        Me.ColTubeType.Name = "ColTubeType"
        Me.ColTubeType.ReadOnly = True
        '
        'colQuantity
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Info
        Me.colQuantity.DefaultCellStyle = DataGridViewCellStyle8
        Me.colQuantity.HeaderText = "Quantity"
        Me.colQuantity.Name = "colQuantity"
        Me.colQuantity.ReadOnly = True
        Me.colQuantity.Width = 50
        '
        'colUnitMeasure
        '
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colUnitMeasure.DefaultCellStyle = DataGridViewCellStyle9
        Me.colUnitMeasure.HeaderText = "Unit Measure"
        Me.colUnitMeasure.Name = "colUnitMeasure"
        Me.colUnitMeasure.ReadOnly = True
        Me.colUnitMeasure.Width = 75
        '
        'colUnitPrice
        '
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colUnitPrice.DefaultCellStyle = DataGridViewCellStyle10
        Me.colUnitPrice.HeaderText = "Unit Price"
        Me.colUnitPrice.Name = "colUnitPrice"
        Me.colUnitPrice.ReadOnly = True
        Me.colUnitPrice.Width = 60
        '
        'colAmount
        '
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colAmount.DefaultCellStyle = DataGridViewCellStyle11
        Me.colAmount.HeaderText = "Amount"
        Me.colAmount.Name = "colAmount"
        Me.colAmount.ReadOnly = True
        Me.colAmount.Width = 60
        '
        'colSpecimen
        '
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colSpecimen.DefaultCellStyle = DataGridViewCellStyle12
        Me.colSpecimen.HeaderText = "Specimen"
        Me.colSpecimen.Name = "colSpecimen"
        Me.colSpecimen.ReadOnly = True
        Me.colSpecimen.Width = 60
        '
        'colLab
        '
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colLab.DefaultCellStyle = DataGridViewCellStyle13
        Me.colLab.HeaderText = "Lab"
        Me.colLab.Name = "colLab"
        Me.colLab.ReadOnly = True
        Me.colLab.Width = 75
        '
        'colPayStatus
        '
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colPayStatus.DefaultCellStyle = DataGridViewCellStyle14
        Me.colPayStatus.HeaderText = "Pay Status"
        Me.colPayStatus.Name = "colPayStatus"
        Me.colPayStatus.ReadOnly = True
        Me.colPayStatus.Width = 70
        '
        'colNotes
        '
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colNotes.DefaultCellStyle = DataGridViewCellStyle15
        Me.colNotes.HeaderText = "Notes"
        Me.colNotes.MaxInputLength = 200
        Me.colNotes.Name = "colNotes"
        Me.colNotes.Width = 60
        '
        'colCashAmount
        '
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colCashAmount.DefaultCellStyle = DataGridViewCellStyle16
        Me.colCashAmount.HeaderText = "Cash Co-Pay Amount"
        Me.colCashAmount.Name = "colCashAmount"
        Me.colCashAmount.ReadOnly = True
        Me.colCashAmount.Width = 130
        '
        'colCashPayStatus
        '
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.colCashPayStatus.DefaultCellStyle = DataGridViewCellStyle17
        Me.colCashPayStatus.HeaderText = "Cash Co-Pay Status"
        Me.colCashPayStatus.Name = "colCashPayStatus"
        Me.colCashPayStatus.ReadOnly = True
        Me.colCashPayStatus.Width = 130
        '
        'cmsLab
        '
        Me.cmsLab.BackColor = System.Drawing.Color.GhostWhite
        Me.cmsLab.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmsLabIncludeAll, Me.cmsLabIncludeNone})
        Me.cmsLab.Name = "cmsSearch"
        Me.cmsLab.Size = New System.Drawing.Size(153, 70)
        '
        'cmsLabIncludeAll
        '
        Me.cmsLabIncludeAll.Name = "cmsLabIncludeAll"
        Me.cmsLabIncludeAll.Size = New System.Drawing.Size(152, 22)
        Me.cmsLabIncludeAll.Text = "Include All"
        '
        'cmsLabIncludeNone
        '
        Me.cmsLabIncludeNone.Name = "cmsLabIncludeNone"
        Me.cmsLabIncludeNone.Size = New System.Drawing.Size(152, 22)
        Me.cmsLabIncludeNone.Text = "Include None"
        '
        'lblSpecimenDes
        '
        Me.lblSpecimenDes.Location = New System.Drawing.Point(10, 63)
        Me.lblSpecimenDes.Name = "lblSpecimenDes"
        Me.lblSpecimenDes.Size = New System.Drawing.Size(123, 20)
        Me.lblSpecimenDes.TabIndex = 7
        Me.lblSpecimenDes.Text = "Specimen Description"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(10, 12)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(89, 20)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No."
        '
        'stbSpecimenNo
        '
        Me.stbSpecimenNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSpecimenNo.CapitalizeFirstLetter = False
        Me.stbSpecimenNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbSpecimenNo.EntryErrorMSG = ""
        Me.stbSpecimenNo.Location = New System.Drawing.Point(146, 34)
        Me.stbSpecimenNo.MaxLength = 20
        Me.stbSpecimenNo.Name = "stbSpecimenNo"
        Me.stbSpecimenNo.RegularExpression = ""
        Me.stbSpecimenNo.Size = New System.Drawing.Size(170, 20)
        Me.stbSpecimenNo.TabIndex = 6
        '
        'lblSpecimenNo
        '
        Me.lblSpecimenNo.Location = New System.Drawing.Point(10, 35)
        Me.lblSpecimenNo.Name = "lblSpecimenNo"
        Me.lblSpecimenNo.Size = New System.Drawing.Size(89, 20)
        Me.lblSpecimenNo.TabIndex = 4
        Me.lblSpecimenNo.Text = "Specimen No."
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(11, 494)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 49
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(844, 493)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 55
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
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(11, 520)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 50
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
        Me.dtpDrawnDateTime.Location = New System.Drawing.Point(146, 127)
        Me.dtpDrawnDateTime.Name = "dtpDrawnDateTime"
        Me.dtpDrawnDateTime.ShowCheckBox = True
        Me.dtpDrawnDateTime.Size = New System.Drawing.Size(170, 20)
        Me.dtpDrawnDateTime.TabIndex = 12
        '
        'cboDrawnBy
        '
        Me.cboDrawnBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDrawnBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboDrawnBy, "DrawnByFullName")
        Me.cboDrawnBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDrawnBy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDrawnBy.FormattingEnabled = True
        Me.cboDrawnBy.Location = New System.Drawing.Point(146, 104)
        Me.cboDrawnBy.Name = "cboDrawnBy"
        Me.cboDrawnBy.Size = New System.Drawing.Size(170, 21)
        Me.cboDrawnBy.TabIndex = 10
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitNo, "VisitNo")
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(146, 12)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(115, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'clbSpecimenPrescription
        '
        Me.clbSpecimenPrescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbSpecimenPrescription, "SpecimenDes")
        Me.clbSpecimenPrescription.FormattingEnabled = True
        Me.clbSpecimenPrescription.Location = New System.Drawing.Point(146, 57)
        Me.clbSpecimenPrescription.Name = "clbSpecimenPrescription"
        Me.clbSpecimenPrescription.Size = New System.Drawing.Size(172, 45)
        Me.clbSpecimenPrescription.TabIndex = 8
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(844, 520)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 56
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblDrawnDateTime
        '
        Me.lblDrawnDateTime.Location = New System.Drawing.Point(10, 129)
        Me.lblDrawnDateTime.Name = "lblDrawnDateTime"
        Me.lblDrawnDateTime.Size = New System.Drawing.Size(123, 20)
        Me.lblDrawnDateTime.TabIndex = 11
        Me.lblDrawnDateTime.Text = "Drawn Date and Time"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(433, 50)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(139, 20)
        Me.stbPatientNo.TabIndex = 20
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(329, 51)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(95, 20)
        Me.lblPatientsNo.TabIndex = 19
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(684, 89)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(139, 20)
        Me.stbBillMode.TabIndex = 40
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(684, 24)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(139, 20)
        Me.stbVisitCategory.TabIndex = 34
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(582, 93)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(95, 20)
        Me.lblBillMode.TabIndex = 39
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(582, 24)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(95, 20)
        Me.lblVisitCategory.TabIndex = 33
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(433, 93)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(139, 20)
        Me.stbStatus.TabIndex = 25
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(329, 96)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(73, 20)
        Me.lblStatus.TabIndex = 24
        Me.lblStatus.Text = "Status"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(684, 3)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(139, 20)
        Me.stbBillNo.TabIndex = 32
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(433, 72)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(40, 20)
        Me.stbAge.TabIndex = 22
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(433, 135)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(139, 20)
        Me.stbJoinDate.TabIndex = 29
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(433, 114)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(139, 20)
        Me.stbGender.TabIndex = 27
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(329, 135)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(73, 20)
        Me.lblJoinDate.TabIndex = 28
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(582, 4)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(95, 20)
        Me.lblBillNo.TabIndex = 31
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(329, 74)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(73, 20)
        Me.lblAge.TabIndex = 21
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(329, 117)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(73, 20)
        Me.lblGenderID.TabIndex = 26
        Me.lblGenderID.Text = "Gender"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(433, 29)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(139, 20)
        Me.stbFullName.TabIndex = 18
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(329, 30)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(95, 20)
        Me.lblFullName.TabIndex = 17
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(433, 7)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(139, 20)
        Me.stbVisitDate.TabIndex = 16
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(329, 5)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(76, 20)
        Me.lblVisitDate.TabIndex = 15
        Me.lblVisitDate.Text = "Visit Date"
        '
        'lblDrawnBy
        '
        Me.lblDrawnBy.Location = New System.Drawing.Point(10, 109)
        Me.lblDrawnBy.Name = "lblDrawnBy"
        Me.lblDrawnBy.Size = New System.Drawing.Size(123, 20)
        Me.lblDrawnBy.TabIndex = 9
        Me.lblDrawnBy.Text = "Drawn By (Staff)"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(113, 12)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'pnlBill
        '
        Me.pnlBill.Controls.Add(Me.Panel1)
        Me.pnlBill.Controls.Add(Me.btnReject)
        Me.pnlBill.Controls.Add(Me.btnFindByFingerprint)
        Me.pnlBill.Controls.Add(Me.pnlAlerts)
        Me.pnlBill.Controls.Add(Me.lblBillWords)
        Me.pnlBill.Controls.Add(Me.stbBillForLaboratory)
        Me.pnlBill.Controls.Add(Me.stbBillWords)
        Me.pnlBill.Controls.Add(Me.lblBillForLaboratory)
        Me.pnlBill.Location = New System.Drawing.Point(7, 176)
        Me.pnlBill.Name = "pnlBill"
        Me.pnlBill.Size = New System.Drawing.Size(909, 71)
        Me.pnlBill.TabIndex = 47
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.BtnViewIPDLabRequests)
        Me.Panel1.Controls.Add(Me.lblIPDAlerts)
        Me.Panel1.Location = New System.Drawing.Point(334, 38)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(325, 33)
        Me.Panel1.TabIndex = 5
        '
        'BtnViewIPDLabRequests
        '
        Me.BtnViewIPDLabRequests.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.BtnViewIPDLabRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnViewIPDLabRequests.Location = New System.Drawing.Point(255, 5)
        Me.BtnViewIPDLabRequests.Name = "BtnViewIPDLabRequests"
        Me.BtnViewIPDLabRequests.Size = New System.Drawing.Size(63, 24)
        Me.BtnViewIPDLabRequests.TabIndex = 1
        Me.BtnViewIPDLabRequests.Tag = ""
        Me.BtnViewIPDLabRequests.Text = "&View List"
        '
        'lblIPDAlerts
        '
        Me.lblIPDAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIPDAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblIPDAlerts.Location = New System.Drawing.Point(8, 7)
        Me.lblIPDAlerts.Name = "lblIPDAlerts"
        Me.lblIPDAlerts.Size = New System.Drawing.Size(233, 20)
        Me.lblIPDAlerts.TabIndex = 0
        Me.lblIPDAlerts.Text = "IPD Doctor Lab Requests: 0"
        '
        'btnReject
        '
        Me.btnReject.AccessibleDescription = ""
        Me.btnReject.Enabled = False
        Me.btnReject.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReject.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnReject.Location = New System.Drawing.Point(664, 42)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(112, 24)
        Me.btnReject.TabIndex = 6
        Me.btnReject.Tag = ""
        Me.btnReject.Text = "&Reject Request"
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(782, 43)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(121, 23)
        Me.btnFindByFingerprint.TabIndex = 7
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnViewList)
        Me.pnlAlerts.Controls.Add(Me.lblAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(5, 37)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(325, 34)
        Me.pnlAlerts.TabIndex = 4
        '
        'btnViewList
        '
        Me.btnViewList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewList.Location = New System.Drawing.Point(255, 6)
        Me.btnViewList.Name = "btnViewList"
        Me.btnViewList.Size = New System.Drawing.Size(63, 24)
        Me.btnViewList.TabIndex = 1
        Me.btnViewList.Tag = ""
        Me.btnViewList.Text = "&View List"
        '
        'lblAlerts
        '
        Me.lblAlerts.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlerts.ForeColor = System.Drawing.Color.Red
        Me.lblAlerts.Location = New System.Drawing.Point(6, 8)
        Me.lblAlerts.Name = "lblAlerts"
        Me.lblAlerts.Size = New System.Drawing.Size(243, 20)
        Me.lblAlerts.TabIndex = 0
        Me.lblAlerts.Text = "Doctor Lab Requests: 0"
        '
        'lblBillWords
        '
        Me.lblBillWords.Location = New System.Drawing.Point(317, 8)
        Me.lblBillWords.Name = "lblBillWords"
        Me.lblBillWords.Size = New System.Drawing.Size(96, 18)
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
        Me.stbBillForLaboratory.Location = New System.Drawing.Point(139, 6)
        Me.stbBillForLaboratory.MaxLength = 20
        Me.stbBillForLaboratory.Name = "stbBillForLaboratory"
        Me.stbBillForLaboratory.RegularExpression = ""
        Me.stbBillForLaboratory.Size = New System.Drawing.Size(172, 20)
        Me.stbBillForLaboratory.TabIndex = 1
        Me.stbBillForLaboratory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'stbBillWords
        '
        Me.stbBillWords.BackColor = System.Drawing.SystemColors.Info
        Me.stbBillWords.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillWords.CapitalizeFirstLetter = False
        Me.stbBillWords.EntryErrorMSG = ""
        Me.stbBillWords.Location = New System.Drawing.Point(421, 4)
        Me.stbBillWords.MaxLength = 0
        Me.stbBillWords.Multiline = True
        Me.stbBillWords.Name = "stbBillWords"
        Me.stbBillWords.ReadOnly = True
        Me.stbBillWords.RegularExpression = ""
        Me.stbBillWords.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillWords.Size = New System.Drawing.Size(425, 32)
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
        Me.btnFindSpecimenNo.Location = New System.Drawing.Point(113, 34)
        Me.btnFindSpecimenNo.Name = "btnFindSpecimenNo"
        Me.btnFindSpecimenNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindSpecimenNo.TabIndex = 5
        '
        'chkPrintLabRequestOnSaving
        '
        Me.chkPrintLabRequestOnSaving.AccessibleDescription = ""
        Me.chkPrintLabRequestOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintLabRequestOnSaving.AutoSize = True
        Me.chkPrintLabRequestOnSaving.Checked = True
        Me.chkPrintLabRequestOnSaving.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintLabRequestOnSaving.Location = New System.Drawing.Point(94, 526)
        Me.chkPrintLabRequestOnSaving.Name = "chkPrintLabRequestOnSaving"
        Me.chkPrintLabRequestOnSaving.Size = New System.Drawing.Size(167, 17)
        Me.chkPrintLabRequestOnSaving.TabIndex = 52
        Me.chkPrintLabRequestOnSaving.Text = " Print Lab Request On Saving"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(760, 520)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(78, 24)
        Me.btnPrint.TabIndex = 54
        Me.btnPrint.Text = "&Print"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(684, 45)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(139, 20)
        Me.stbPrimaryDoctor.TabIndex = 36
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(582, 45)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(95, 20)
        Me.lblPrimaryDoctor.TabIndex = 35
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'btnLoadToLabVisits
        '
        Me.btnLoadToLabVisits.AccessibleDescription = ""
        Me.btnLoadToLabVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadToLabVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadToLabVisits.Location = New System.Drawing.Point(267, 9)
        Me.btnLoadToLabVisits.Name = "btnLoadToLabVisits"
        Me.btnLoadToLabVisits.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadToLabVisits.TabIndex = 3
        Me.btnLoadToLabVisits.Tag = ""
        Me.btnLoadToLabVisits.Text = "&Load"
        '
        'chkSmartCardApplicable
        '
        Me.chkSmartCardApplicable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSmartCardApplicable.Enabled = False
        Me.chkSmartCardApplicable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSmartCardApplicable.Location = New System.Drawing.Point(329, 156)
        Me.chkSmartCardApplicable.Name = "chkSmartCardApplicable"
        Me.chkSmartCardApplicable.Size = New System.Drawing.Size(180, 20)
        Me.chkSmartCardApplicable.TabIndex = 30
        Me.chkSmartCardApplicable.Text = "Smart Card Applicable"
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.Enabled = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(684, 111)
        Me.stbMemberCardNo.MaxLength = 20
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.Size = New System.Drawing.Size(139, 20)
        Me.stbMemberCardNo.TabIndex = 42
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(585, 112)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(95, 20)
        Me.lblMemberCardNo.TabIndex = 41
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'tbcLabRequests
        '
        Me.tbcLabRequests.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbcLabRequests.Controls.Add(Me.tpgTests)
        Me.tbcLabRequests.Controls.Add(Me.tpgPossibleConsumables)
        Me.tbcLabRequests.Location = New System.Drawing.Point(7, 248)
        Me.tbcLabRequests.Name = "tbcLabRequests"
        Me.tbcLabRequests.SelectedIndex = 0
        Me.tbcLabRequests.Size = New System.Drawing.Size(909, 240)
        Me.tbcLabRequests.TabIndex = 48
        '
        'tpgTests
        '
        Me.tpgTests.Controls.Add(Me.dgvTests)
        Me.tpgTests.Location = New System.Drawing.Point(4, 22)
        Me.tpgTests.Name = "tpgTests"
        Me.tpgTests.Padding = New System.Windows.Forms.Padding(3)
        Me.tpgTests.Size = New System.Drawing.Size(901, 214)
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
        Me.tpgPossibleConsumables.Size = New System.Drawing.Size(901, 214)
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
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle19
        Me.dgvConsumables.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.colConsumablesTestName, Me.ColConsumableInclude, Me.colConsumableNo, Me.colConsumablesConsumableName, Me.ColConUnitMeasure, Me.colConsumableQuantity, Me.colConsumableNotes, Me.ColLocationBalance, Me.ColUnitsinstock, Me.colConsumableExpiryDate, Me.colConsumableOrderLevel, Me.colConsumableAlternateName})
        Me.dgvConsumables.ContextMenuStrip = Me.cmsLab
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.DefaultCellStyle = DataGridViewCellStyle31
        Me.dgvConsumables.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvConsumables.EnableHeadersVisualStyles = False
        Me.dgvConsumables.GridColor = System.Drawing.Color.Khaki
        Me.dgvConsumables.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.dgvConsumables.Location = New System.Drawing.Point(3, 3)
        Me.dgvConsumables.Name = "dgvConsumables"
        Me.dgvConsumables.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle32.BackColor = System.Drawing.Color.LightSteelBlue
        DataGridViewCellStyle32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsumables.RowHeadersDefaultCellStyle = DataGridViewCellStyle32
        Me.dgvConsumables.RowHeadersVisible = False
        Me.dgvConsumables.Size = New System.Drawing.Size(895, 208)
        Me.dgvConsumables.TabIndex = 43
        Me.dgvConsumables.Text = "DataGridView1"
        '
        'colConsumablesTestName
        '
        DataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumablesTestName.DefaultCellStyle = DataGridViewCellStyle20
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
        DataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableNo.DefaultCellStyle = DataGridViewCellStyle21
        Me.colConsumableNo.HeaderText = "Consumable No"
        Me.colConsumableNo.Name = "colConsumableNo"
        Me.colConsumableNo.ReadOnly = True
        '
        'colConsumablesConsumableName
        '
        DataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumablesConsumableName.DefaultCellStyle = DataGridViewCellStyle22
        Me.colConsumablesConsumableName.HeaderText = "Consumable Name"
        Me.colConsumablesConsumableName.Name = "colConsumablesConsumableName"
        Me.colConsumablesConsumableName.ReadOnly = True
        Me.colConsumablesConsumableName.Width = 150
        '
        'ColConUnitMeasure
        '
        DataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Info
        Me.ColConUnitMeasure.DefaultCellStyle = DataGridViewCellStyle23
        Me.ColConUnitMeasure.HeaderText = "Unit Measure"
        Me.ColConUnitMeasure.Name = "ColConUnitMeasure"
        Me.ColConUnitMeasure.ReadOnly = True
        Me.ColConUnitMeasure.Width = 90
        '
        'colConsumableQuantity
        '
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Info
        DataGridViewCellStyle24.Format = "N0"
        DataGridViewCellStyle24.FormatProvider = New System.Globalization.CultureInfo("en-GB")
        DataGridViewCellStyle24.NullValue = Nothing
        Me.colConsumableQuantity.DefaultCellStyle = DataGridViewCellStyle24
        Me.colConsumableQuantity.HeaderText = "Quantity"
        Me.colConsumableQuantity.MaxInputLength = 12
        Me.colConsumableQuantity.Name = "colConsumableQuantity"
        Me.colConsumableQuantity.ReadOnly = True
        Me.colConsumableQuantity.Width = 80
        '
        'colConsumableNotes
        '
        DataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableNotes.DefaultCellStyle = DataGridViewCellStyle25
        Me.colConsumableNotes.FillWeight = 4.566049!
        Me.colConsumableNotes.HeaderText = "Notes"
        Me.colConsumableNotes.MaxInputLength = 40
        Me.colConsumableNotes.Name = "colConsumableNotes"
        Me.colConsumableNotes.ReadOnly = True
        Me.colConsumableNotes.Width = 150
        '
        'ColLocationBalance
        '
        DataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Info
        Me.ColLocationBalance.DefaultCellStyle = DataGridViewCellStyle26
        Me.ColLocationBalance.HeaderText = "Location Balance"
        Me.ColLocationBalance.Name = "ColLocationBalance"
        Me.ColLocationBalance.ReadOnly = True
        '
        'ColUnitsinstock
        '
        DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Info
        Me.ColUnitsinstock.DefaultCellStyle = DataGridViewCellStyle27
        Me.ColUnitsinstock.HeaderText = "Units In Stock"
        Me.ColUnitsinstock.Name = "ColUnitsinstock"
        Me.ColUnitsinstock.ReadOnly = True
        Me.ColUnitsinstock.Width = 120
        '
        'colConsumableExpiryDate
        '
        DataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableExpiryDate.DefaultCellStyle = DataGridViewCellStyle28
        Me.colConsumableExpiryDate.HeaderText = "Expiry Date"
        Me.colConsumableExpiryDate.Name = "colConsumableExpiryDate"
        Me.colConsumableExpiryDate.ReadOnly = True
        '
        'colConsumableOrderLevel
        '
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableOrderLevel.DefaultCellStyle = DataGridViewCellStyle29
        Me.colConsumableOrderLevel.HeaderText = "Order Level"
        Me.colConsumableOrderLevel.Name = "colConsumableOrderLevel"
        Me.colConsumableOrderLevel.ReadOnly = True
        '
        'colConsumableAlternateName
        '
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Info
        Me.colConsumableAlternateName.DefaultCellStyle = DataGridViewCellStyle30
        Me.colConsumableAlternateName.HeaderText = "Consumable Alternate Name"
        Me.colConsumableAlternateName.Name = "colConsumableAlternateName"
        Me.colConsumableAlternateName.ReadOnly = True
        Me.colConsumableAlternateName.Width = 150
        '
        'lblLocationID
        '
        Me.lblLocationID.Location = New System.Drawing.Point(10, 152)
        Me.lblLocationID.Name = "lblLocationID"
        Me.lblLocationID.Size = New System.Drawing.Size(106, 20)
        Me.lblLocationID.TabIndex = 13
        Me.lblLocationID.Text = "Location"
        '
        'stbPackage
        '
        Me.stbPackage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPackage.CapitalizeFirstLetter = False
        Me.stbPackage.Enabled = False
        Me.stbPackage.EntryErrorMSG = ""
        Me.stbPackage.Location = New System.Drawing.Point(684, 132)
        Me.stbPackage.MaxLength = 60
        Me.stbPackage.Name = "stbPackage"
        Me.stbPackage.RegularExpression = ""
        Me.stbPackage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPackage.Size = New System.Drawing.Size(139, 20)
        Me.stbPackage.TabIndex = 44
        '
        'lblPackageName
        '
        Me.lblPackageName.Location = New System.Drawing.Point(585, 133)
        Me.lblPackageName.Name = "lblPackageName"
        Me.lblPackageName.Size = New System.Drawing.Size(95, 20)
        Me.lblPackageName.TabIndex = 43
        Me.lblPackageName.Text = "Package"
        '
        'imgIDAutomation
        '
        Me.imgIDAutomation.Location = New System.Drawing.Point(426, 181)
        Me.imgIDAutomation.Name = "imgIDAutomation"
        Me.imgIDAutomation.Size = New System.Drawing.Size(200, 40)
        Me.imgIDAutomation.TabIndex = 57
        Me.imgIDAutomation.TabStop = False
        '
        'btnPrintBarcode
        '
        Me.btnPrintBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrintBarcode.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintBarcode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintBarcode.Location = New System.Drawing.Point(625, 520)
        Me.btnPrintBarcode.Name = "btnPrintBarcode"
        Me.btnPrintBarcode.Size = New System.Drawing.Size(129, 24)
        Me.btnPrintBarcode.TabIndex = 53
        Me.btnPrintBarcode.Text = "&Print Barcode"
        '
        'cboLocationID
        '
        Me.cboLocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboLocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboLocationID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLocationID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLocationID.FormattingEnabled = True
        Me.cboLocationID.Location = New System.Drawing.Point(146, 150)
        Me.cboLocationID.Name = "cboLocationID"
        Me.cboLocationID.Size = New System.Drawing.Size(170, 21)
        Me.cboLocationID.TabIndex = 14
        '
        'stbDoctorContact
        '
        Me.stbDoctorContact.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDoctorContact.CapitalizeFirstLetter = False
        Me.stbDoctorContact.Enabled = False
        Me.stbDoctorContact.EntryErrorMSG = ""
        Me.stbDoctorContact.Location = New System.Drawing.Point(684, 67)
        Me.stbDoctorContact.MaxLength = 60
        Me.stbDoctorContact.Name = "stbDoctorContact"
        Me.stbDoctorContact.RegularExpression = ""
        Me.stbDoctorContact.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbDoctorContact.Size = New System.Drawing.Size(139, 20)
        Me.stbDoctorContact.TabIndex = 38
        '
        'lblDoctorContact
        '
        Me.lblDoctorContact.Location = New System.Drawing.Point(582, 67)
        Me.lblDoctorContact.Name = "lblDoctorContact"
        Me.lblDoctorContact.Size = New System.Drawing.Size(95, 20)
        Me.lblDoctorContact.TabIndex = 37
        Me.lblDoctorContact.Text = "Doctor Contact"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(684, 153)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(139, 20)
        Me.stbCoPayType.TabIndex = 46
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(585, 155)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(78, 20)
        Me.lblCoPayType.TabIndex = 45
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'lblAgeString
        '
        Me.lblAgeString.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgeString.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAgeString.Location = New System.Drawing.Point(478, 72)
        Me.lblAgeString.Name = "lblAgeString"
        Me.lblAgeString.Size = New System.Drawing.Size(93, 19)
        Me.lblAgeString.TabIndex = 23
        '
        'chkPrintLabBarcode
        '
        Me.chkPrintLabBarcode.AccessibleDescription = ""
        Me.chkPrintLabBarcode.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintLabBarcode.AutoSize = True
        Me.chkPrintLabBarcode.Location = New System.Drawing.Point(94, 503)
        Me.chkPrintLabBarcode.Name = "chkPrintLabBarcode"
        Me.chkPrintLabBarcode.Size = New System.Drawing.Size(114, 17)
        Me.chkPrintLabBarcode.TabIndex = 51
        Me.chkPrintLabBarcode.Text = " Print Lab Barcode"
        '
        'frmLabRequests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(924, 551)
        Me.Controls.Add(Me.chkPrintLabBarcode)
        Me.Controls.Add(Me.lblAgeString)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.stbDoctorContact)
        Me.Controls.Add(Me.lblDoctorContact)
        Me.Controls.Add(Me.cboLocationID)
        Me.Controls.Add(Me.btnPrintBarcode)
        Me.Controls.Add(Me.stbPackage)
        Me.Controls.Add(Me.lblPackageName)
        Me.Controls.Add(Me.clbSpecimenPrescription)
        Me.Controls.Add(Me.lblLocationID)
        Me.Controls.Add(Me.tbcLabRequests)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.chkSmartCardApplicable)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.btnLoadToLabVisits)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.chkPrintLabRequestOnSaving)
        Me.Controls.Add(Me.btnFindSpecimenNo)
        Me.Controls.Add(Me.pnlBill)
        Me.Controls.Add(Me.btnFindVisitNo)
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
        Me.Controls.Add(Me.stbStatus)
        Me.Controls.Add(Me.lblStatus)
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
        Me.Controls.Add(Me.lblVisitNo)
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
        Me.Name = "frmLabRequests"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lab Requests"
        CType(Me.dgvTests, System.ComponentModel.ISupportInitialize).EndInit()
        Me.cmsLab.ResumeLayout(False)
        Me.pnlBill.ResumeLayout(False)
        Me.pnlBill.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnlAlerts.ResumeLayout(False)
        Me.tbcLabRequests.ResumeLayout(False)
        Me.tpgTests.ResumeLayout(False)
        Me.tpgPossibleConsumables.ResumeLayout(False)
        CType(Me.dgvConsumables, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgIDAutomation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout

End Sub
    Friend WithEvents dgvTests As System.Windows.Forms.DataGridView
    Friend WithEvents lblSpecimenDes As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
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
    Friend WithEvents stbStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
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
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents pnlBill As System.Windows.Forms.Panel
    Friend WithEvents lblBillWords As System.Windows.Forms.Label
    Friend WithEvents stbBillForLaboratory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbBillWords As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillForLaboratory As System.Windows.Forms.Label
    Friend WithEvents btnFindSpecimenNo As System.Windows.Forms.Button
    Friend WithEvents chkPrintLabRequestOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnViewList As System.Windows.Forms.Button
    Friend WithEvents lblAlerts As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents btnLoadToLabVisits As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents chkSmartCardApplicable As System.Windows.Forms.CheckBox
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label
    Friend WithEvents tbcLabRequests As System.Windows.Forms.TabControl
    Friend WithEvents tpgTests As System.Windows.Forms.TabPage
    Friend WithEvents tpgPossibleConsumables As System.Windows.Forms.TabPage
    Friend WithEvents dgvConsumables As System.Windows.Forms.DataGridView
    Friend WithEvents lblLocationID As System.Windows.Forms.Label
    Friend WithEvents btnReject As Button
    Friend WithEvents clbSpecimenPrescription As CheckedListBox
    Friend WithEvents stbPackage As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPackageName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BtnViewIPDLabRequests As System.Windows.Forms.Button
    Friend WithEvents lblIPDAlerts As System.Windows.Forms.Label
    Friend WithEvents imgIDAutomation As System.Windows.Forms.PictureBox
    Friend WithEvents btnPrintBarcode As System.Windows.Forms.Button
    Friend WithEvents cboLocationID As System.Windows.Forms.ComboBox
    Friend WithEvents stbDoctorContact As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDoctorContact As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label
    Friend WithEvents lblAgeString As System.Windows.Forms.Label
    Friend WithEvents chkPrintLabBarcode As System.Windows.Forms.CheckBox
    Friend WithEvents colInclude As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents colTestCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colTestName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColDrNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColclinicalNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColProvisionalDiagnosis As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColTubeType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colQuantity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitMeasure As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colUnitPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colSpecimen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colLab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colNotes As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCashAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents colCashPayStatus As System.Windows.Forms.DataGridViewTextBoxColumn
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
