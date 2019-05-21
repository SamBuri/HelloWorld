
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDentalReports : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDentalReports))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbReport = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpReportDate = New System.Windows.Forms.DateTimePicker()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblDentalFullName = New System.Windows.Forms.Label()
        Me.lblReport = New System.Windows.Forms.Label()
        Me.stbPrimaryDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPrimaryDoctor = New System.Windows.Forms.Label()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
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
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintDentalReportOnSaving = New System.Windows.Forms.CheckBox()
        Me.cboDentalFullName = New System.Windows.Forms.ComboBox()
        Me.stbUnitPrice = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.btnLoadPendingDental = New System.Windows.Forms.Button()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnFindByFingerprint = New System.Windows.Forms.Button()
        Me.btnViewList = New System.Windows.Forms.Button()
        Me.lblAlerts = New System.Windows.Forms.Label()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.pnlVisitNo = New System.Windows.Forms.Panel()
        Me.lblReportDate = New System.Windows.Forms.Label()
        Me.chkSmartCardApplicable = New System.Windows.Forms.CheckBox()
        Me.stbMemberCardNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblMemberCardNo = New System.Windows.Forms.Label()
        Me.pnlAlerts.SuspendLayout()
        Me.pnlVisitNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(11, 272)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 37
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Enabled = False
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(376, 299)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 40
        Me.fbnDelete.Tag = "RadiologyReports"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.ButtonText = SyncSoft.Common.Win.Controls.ButtonCaption.Save
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(11, 299)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 38
        Me.ebnSaveUpdate.Tag = "RadiologyReports"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbReport
        '
        Me.stbReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReport.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReport, "Report")
        Me.stbReport.EntryErrorMSG = ""
        Me.stbReport.Location = New System.Drawing.Point(152, 103)
        Me.stbReport.MaxLength = 4000
        Me.stbReport.Multiline = True
        Me.stbReport.Name = "stbReport"
        Me.stbReport.RegularExpression = ""
        Me.stbReport.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbReport.Size = New System.Drawing.Size(170, 50)
        Me.stbReport.TabIndex = 8
        Me.stbReport.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbReport.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'dtpReportDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpReportDate, "ReportDate")
        Me.dtpReportDate.Location = New System.Drawing.Point(152, 81)
        Me.dtpReportDate.Name = "dtpReportDate"
        Me.dtpReportDate.ShowCheckBox = True
        Me.dtpReportDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpReportDate.TabIndex = 6
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(146, 7)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbVisitNo.Size = New System.Drawing.Size(115, 20)
        Me.stbVisitNo.TabIndex = 2
        Me.stbVisitNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbVisitNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(538, 299)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 42
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblDentalFullName
        '
        Me.lblDentalFullName.Location = New System.Drawing.Point(11, 36)
        Me.lblDentalFullName.Name = "lblDentalFullName"
        Me.lblDentalFullName.Size = New System.Drawing.Size(123, 20)
        Me.lblDentalFullName.TabIndex = 1
        Me.lblDentalFullName.Text = "Dental Service"
        '
        'lblReport
        '
        Me.lblReport.Location = New System.Drawing.Point(11, 125)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(123, 20)
        Me.lblReport.TabIndex = 7
        Me.lblReport.Text = "Report"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(451, 27)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(159, 20)
        Me.stbPrimaryDoctor.TabIndex = 20
        Me.stbPrimaryDoctor.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbPrimaryDoctor.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(337, 26)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(108, 20)
        Me.lblPrimaryDoctor.TabIndex = 19
        Me.lblPrimaryDoctor.Text = "Primary Doctor"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(113, 7)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(152, 154)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitDate.TabIndex = 10
        Me.stbVisitDate.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbVisitDate.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(11, 154)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(123, 20)
        Me.lblVisitDate.TabIndex = 9
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(152, 175)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(170, 20)
        Me.stbFullName.TabIndex = 12
        Me.stbFullName.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbFullName.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(11, 175)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(123, 20)
        Me.lblFullName.TabIndex = 11
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(152, 196)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbPatientNo.Size = New System.Drawing.Size(170, 20)
        Me.stbPatientNo.TabIndex = 14
        Me.stbPatientNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbPatientNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(11, 196)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(123, 20)
        Me.lblPatientsNo.TabIndex = 13
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(451, 111)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(159, 20)
        Me.stbBillMode.TabIndex = 28
        Me.stbBillMode.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillMode.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(451, 6)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(159, 20)
        Me.stbVisitCategory.TabIndex = 18
        Me.stbVisitCategory.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbVisitCategory.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(337, 111)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(108, 20)
        Me.lblBillMode.TabIndex = 27
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(337, 5)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitCategory.TabIndex = 17
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(451, 69)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(159, 20)
        Me.stbStatus.TabIndex = 24
        Me.stbStatus.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbStatus.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(337, 69)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(108, 20)
        Me.lblStatus.TabIndex = 23
        Me.lblStatus.Text = "Status"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(152, 217)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(170, 20)
        Me.stbBillNo.TabIndex = 16
        Me.stbBillNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(451, 48)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(159, 20)
        Me.stbAge.TabIndex = 22
        Me.stbAge.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbAge.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(451, 132)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(159, 20)
        Me.stbJoinDate.TabIndex = 30
        Me.stbJoinDate.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbJoinDate.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(451, 90)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(159, 20)
        Me.stbGender.TabIndex = 26
        Me.stbGender.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbGender.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(337, 132)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(108, 20)
        Me.lblJoinDate.TabIndex = 29
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(11, 217)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(123, 20)
        Me.lblBillNo.TabIndex = 15
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(337, 48)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(108, 20)
        Me.lblAge.TabIndex = 21
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(337, 90)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(108, 20)
        Me.lblGenderID.TabIndex = 25
        Me.lblGenderID.Text = "Gender"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(11, 7)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(89, 20)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit No."
        '
        'btnPrint
        '
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(454, 299)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(78, 24)
        Me.btnPrint.TabIndex = 41
        Me.btnPrint.Text = "&Print"
        '
        'chkPrintDentalReportOnSaving
        '
        Me.chkPrintDentalReportOnSaving.AccessibleDescription = ""
        Me.chkPrintDentalReportOnSaving.AutoSize = True
        Me.chkPrintDentalReportOnSaving.Location = New System.Drawing.Point(94, 307)
        Me.chkPrintDentalReportOnSaving.Name = "chkPrintDentalReportOnSaving"
        Me.chkPrintDentalReportOnSaving.Size = New System.Drawing.Size(172, 17)
        Me.chkPrintDentalReportOnSaving.TabIndex = 39
        Me.chkPrintDentalReportOnSaving.Text = " Print Dental Report On Saving"
        '
        'cboDentalFullName
        '
        Me.cboDentalFullName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboDentalFullName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboDentalFullName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDentalFullName.DropDownWidth = 214
        Me.cboDentalFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDentalFullName.FormattingEnabled = True
        Me.cboDentalFullName.Location = New System.Drawing.Point(152, 36)
        Me.cboDentalFullName.Name = "cboDentalFullName"
        Me.cboDentalFullName.Size = New System.Drawing.Size(170, 21)
        Me.cboDentalFullName.Sorted = True
        Me.cboDentalFullName.TabIndex = 2
        '
        'stbUnitPrice
        '
        Me.stbUnitPrice.BackColor = System.Drawing.SystemColors.Info
        Me.stbUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbUnitPrice.CapitalizeFirstLetter = False
        Me.stbUnitPrice.Enabled = False
        Me.stbUnitPrice.EntryErrorMSG = ""
        Me.stbUnitPrice.Location = New System.Drawing.Point(152, 59)
        Me.stbUnitPrice.MaxLength = 20
        Me.stbUnitPrice.Name = "stbUnitPrice"
        Me.stbUnitPrice.RegularExpression = ""
        Me.stbUnitPrice.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbUnitPrice.Size = New System.Drawing.Size(170, 20)
        Me.stbUnitPrice.TabIndex = 4
        Me.stbUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.stbUnitPrice.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbUnitPrice.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Location = New System.Drawing.Point(11, 59)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(123, 20)
        Me.lblUnitPrice.TabIndex = 3
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'btnLoadPendingDental
        '
        Me.btnLoadPendingDental.AccessibleDescription = ""
        Me.btnLoadPendingDental.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPendingDental.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPendingDental.Location = New System.Drawing.Point(267, 4)
        Me.btnLoadPendingDental.Name = "btnLoadPendingDental"
        Me.btnLoadPendingDental.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadPendingDental.TabIndex = 3
        Me.btnLoadPendingDental.Tag = ""
        Me.btnLoadPendingDental.Text = "&Load"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(451, 153)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(159, 29)
        Me.stbBillCustomerName.TabIndex = 32
        Me.stbBillCustomerName.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbBillCustomerName.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(337, 157)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(108, 20)
        Me.lblBillCustomerName.TabIndex = 31
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnFindByFingerprint)
        Me.pnlAlerts.Controls.Add(Me.btnViewList)
        Me.pnlAlerts.Controls.Add(Me.lblAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(340, 230)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(278, 63)
        Me.pnlAlerts.TabIndex = 36
        '
        'btnFindByFingerprint
        '
        Me.btnFindByFingerprint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindByFingerprint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindByFingerprint.Location = New System.Drawing.Point(143, 36)
        Me.btnFindByFingerprint.Name = "btnFindByFingerprint"
        Me.btnFindByFingerprint.Size = New System.Drawing.Size(127, 23)
        Me.btnFindByFingerprint.TabIndex = 2
        Me.btnFindByFingerprint.Text = "Find By Fingerprint"
        Me.btnFindByFingerprint.UseVisualStyleBackColor = True
        '
        'btnViewList
        '
        Me.btnViewList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewList.Location = New System.Drawing.Point(207, 7)
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
        Me.lblAlerts.Location = New System.Drawing.Point(9, 9)
        Me.lblAlerts.Name = "lblAlerts"
        Me.lblAlerts.Size = New System.Drawing.Size(192, 20)
        Me.lblAlerts.TabIndex = 0
        Me.lblAlerts.Text = "Doctor Dental: 0"
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'pnlVisitNo
        '
        Me.pnlVisitNo.Controls.Add(Me.btnLoadPendingDental)
        Me.pnlVisitNo.Controls.Add(Me.stbVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.lblVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.btnFindVisitNo)
        Me.pnlVisitNo.Location = New System.Drawing.Point(5, 1)
        Me.pnlVisitNo.Name = "pnlVisitNo"
        Me.pnlVisitNo.Size = New System.Drawing.Size(326, 31)
        Me.pnlVisitNo.TabIndex = 0
        '
        'lblReportDate
        '
        Me.lblReportDate.Location = New System.Drawing.Point(11, 81)
        Me.lblReportDate.Name = "lblReportDate"
        Me.lblReportDate.Size = New System.Drawing.Size(123, 20)
        Me.lblReportDate.TabIndex = 5
        Me.lblReportDate.Text = "Report Date"
        '
        'chkSmartCardApplicable
        '
        Me.chkSmartCardApplicable.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSmartCardApplicable.Enabled = False
        Me.chkSmartCardApplicable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSmartCardApplicable.Location = New System.Drawing.Point(335, 205)
        Me.chkSmartCardApplicable.Name = "chkSmartCardApplicable"
        Me.chkSmartCardApplicable.Size = New System.Drawing.Size(197, 20)
        Me.chkSmartCardApplicable.TabIndex = 35
        Me.chkSmartCardApplicable.Text = "Smart Card Applicable"
        '
        'stbMemberCardNo
        '
        Me.stbMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbMemberCardNo.CapitalizeFirstLetter = False
        Me.stbMemberCardNo.Enabled = False
        Me.stbMemberCardNo.EntryErrorMSG = ""
        Me.stbMemberCardNo.Location = New System.Drawing.Point(451, 183)
        Me.stbMemberCardNo.MaxLength = 20
        Me.stbMemberCardNo.Name = "stbMemberCardNo"
        Me.stbMemberCardNo.RegularExpression = ""
        Me.stbMemberCardNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbMemberCardNo.Size = New System.Drawing.Size(159, 20)
        Me.stbMemberCardNo.TabIndex = 34
        Me.stbMemberCardNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbMemberCardNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'lblMemberCardNo
        '
        Me.lblMemberCardNo.Location = New System.Drawing.Point(337, 183)
        Me.lblMemberCardNo.Name = "lblMemberCardNo"
        Me.lblMemberCardNo.Size = New System.Drawing.Size(108, 20)
        Me.lblMemberCardNo.TabIndex = 33
        Me.lblMemberCardNo.Text = "Member Card No"
        '
        'frmDentalReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(632, 339)
        Me.Controls.Add(Me.chkSmartCardApplicable)
        Me.Controls.Add(Me.stbMemberCardNo)
        Me.Controls.Add(Me.lblMemberCardNo)
        Me.Controls.Add(Me.dtpReportDate)
        Me.Controls.Add(Me.lblReportDate)
        Me.Controls.Add(Me.pnlVisitNo)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.cboDentalFullName)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.chkPrintDentalReportOnSaving)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
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
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblDentalFullName)
        Me.Controls.Add(Me.stbReport)
        Me.Controls.Add(Me.lblReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDentalReports"
        Me.Text = "Dental Reports"
        Me.pnlAlerts.ResumeLayout(False)
        Me.pnlVisitNo.ResumeLayout(False)
        Me.pnlVisitNo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblDentalFullName As System.Windows.Forms.Label
    Friend WithEvents stbReport As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReport As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
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
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintDentalReportOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents cboDentalFullName As System.Windows.Forms.ComboBox
    Friend WithEvents stbUnitPrice As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnViewList As System.Windows.Forms.Button
    Friend WithEvents lblAlerts As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents btnLoadPendingDental As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents pnlVisitNo As System.Windows.Forms.Panel
    Friend WithEvents dtpReportDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReportDate As System.Windows.Forms.Label
    Friend WithEvents btnFindByFingerprint As System.Windows.Forms.Button
    Friend WithEvents chkSmartCardApplicable As System.Windows.Forms.CheckBox
    Friend WithEvents stbMemberCardNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblMemberCardNo As System.Windows.Forms.Label

End Class