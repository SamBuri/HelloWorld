
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintCardiologyReports : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal visitNo As String)
        MyClass.New()
        Me.defaultVisitNo = visitNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintCardiologyReports))
        Me.stbReport = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbConclusion = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbIndication = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblExamFullName = New System.Windows.Forms.Label()
        Me.lblExamDateTime = New System.Windows.Forms.Label()
        Me.lblReport = New System.Windows.Forms.Label()
        Me.lblConclusion = New System.Windows.Forms.Label()
        Me.lblCardiologist = New System.Windows.Forms.Label()
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
        Me.lblIndication = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cboExamFullName = New System.Windows.Forms.ComboBox()
        Me.btnLoadDoneCardiology = New System.Windows.Forms.Button()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.pnlVisitNo = New System.Windows.Forms.Panel()
        Me.stbExamDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.stbCardiologist = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbCardiologyTitle = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCardiologyTitle = New System.Windows.Forms.Label()
        Me.pnlVisitNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbReport
        '
        Me.stbReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReport.CapitalizeFirstLetter = True
        Me.stbReport.EntryErrorMSG = ""
        Me.stbReport.Location = New System.Drawing.Point(152, 109)
        Me.stbReport.MaxLength = 4000
        Me.stbReport.Multiline = True
        Me.stbReport.Name = "stbReport"
        Me.stbReport.ReadOnly = True
        Me.stbReport.RegularExpression = ""
        Me.stbReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbReport.Size = New System.Drawing.Size(170, 50)
        Me.stbReport.TabIndex = 8
        '
        'stbConclusion
        '
        Me.stbConclusion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbConclusion.CapitalizeFirstLetter = True
        Me.stbConclusion.EntryErrorMSG = ""
        Me.stbConclusion.Location = New System.Drawing.Point(152, 160)
        Me.stbConclusion.MaxLength = 4000
        Me.stbConclusion.Multiline = True
        Me.stbConclusion.Name = "stbConclusion"
        Me.stbConclusion.ReadOnly = True
        Me.stbConclusion.RegularExpression = ""
        Me.stbConclusion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbConclusion.Size = New System.Drawing.Size(170, 52)
        Me.stbConclusion.TabIndex = 10
        '
        'stbIndication
        '
        Me.stbIndication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbIndication.CapitalizeFirstLetter = True
        Me.stbIndication.EntryErrorMSG = ""
        Me.stbIndication.Location = New System.Drawing.Point(152, 59)
        Me.stbIndication.MaxLength = 4000
        Me.stbIndication.Multiline = True
        Me.stbIndication.Name = "stbIndication"
        Me.stbIndication.ReadOnly = True
        Me.stbIndication.RegularExpression = ""
        Me.stbIndication.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbIndication.Size = New System.Drawing.Size(170, 28)
        Me.stbIndication.TabIndex = 4
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
        Me.stbVisitNo.Size = New System.Drawing.Size(115, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(517, 277)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(93, 24)
        Me.fbnClose.TabIndex = 41
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblExamFullName
        '
        Me.lblExamFullName.Location = New System.Drawing.Point(11, 36)
        Me.lblExamFullName.Name = "lblExamFullName"
        Me.lblExamFullName.Size = New System.Drawing.Size(134, 20)
        Me.lblExamFullName.TabIndex = 1
        Me.lblExamFullName.Text = "Cardiology Examination"
        '
        'lblExamDateTime
        '
        Me.lblExamDateTime.Location = New System.Drawing.Point(11, 88)
        Me.lblExamDateTime.Name = "lblExamDateTime"
        Me.lblExamDateTime.Size = New System.Drawing.Size(123, 20)
        Me.lblExamDateTime.TabIndex = 5
        Me.lblExamDateTime.Text = "Exam Date Time"
        '
        'lblReport
        '
        Me.lblReport.Location = New System.Drawing.Point(11, 131)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(123, 20)
        Me.lblReport.TabIndex = 7
        Me.lblReport.Text = "Report"
        '
        'lblConclusion
        '
        Me.lblConclusion.Location = New System.Drawing.Point(11, 181)
        Me.lblConclusion.Name = "lblConclusion"
        Me.lblConclusion.Size = New System.Drawing.Size(123, 20)
        Me.lblConclusion.TabIndex = 9
        Me.lblConclusion.Text = "Conclusion"
        '
        'lblCardiologist
        '
        Me.lblCardiologist.Location = New System.Drawing.Point(11, 213)
        Me.lblCardiologist.Name = "lblCardiologist"
        Me.lblCardiologist.Size = New System.Drawing.Size(123, 20)
        Me.lblCardiologist.TabIndex = 11
        Me.lblCardiologist.Text = "Cardiologist"
        '
        'stbPrimaryDoctor
        '
        Me.stbPrimaryDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDoctor.CapitalizeFirstLetter = False
        Me.stbPrimaryDoctor.Enabled = False
        Me.stbPrimaryDoctor.EntryErrorMSG = ""
        Me.stbPrimaryDoctor.Location = New System.Drawing.Point(451, 110)
        Me.stbPrimaryDoctor.MaxLength = 60
        Me.stbPrimaryDoctor.Name = "stbPrimaryDoctor"
        Me.stbPrimaryDoctor.RegularExpression = ""
        Me.stbPrimaryDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDoctor.Size = New System.Drawing.Size(159, 20)
        Me.stbPrimaryDoctor.TabIndex = 26
        '
        'lblPrimaryDoctor
        '
        Me.lblPrimaryDoctor.Location = New System.Drawing.Point(337, 109)
        Me.lblPrimaryDoctor.Name = "lblPrimaryDoctor"
        Me.lblPrimaryDoctor.Size = New System.Drawing.Size(108, 20)
        Me.lblPrimaryDoctor.TabIndex = 25
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
        Me.stbVisitDate.Location = New System.Drawing.Point(451, 5)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(159, 20)
        Me.stbVisitDate.TabIndex = 16
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(337, 5)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitDate.TabIndex = 15
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(451, 26)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(159, 20)
        Me.stbFullName.TabIndex = 18
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(337, 26)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(108, 20)
        Me.lblFullName.TabIndex = 17
        Me.lblFullName.Text = "Patient's Name"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(451, 47)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(159, 20)
        Me.stbPatientNo.TabIndex = 20
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(337, 47)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(108, 20)
        Me.lblPatientsNo.TabIndex = 19
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(451, 194)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(159, 20)
        Me.stbBillMode.TabIndex = 34
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(451, 89)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(159, 20)
        Me.stbVisitCategory.TabIndex = 24
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(337, 194)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(108, 20)
        Me.lblBillMode.TabIndex = 33
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(337, 88)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(108, 20)
        Me.lblVisitCategory.TabIndex = 23
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(451, 152)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(159, 20)
        Me.stbStatus.TabIndex = 30
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(337, 152)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(108, 20)
        Me.lblStatus.TabIndex = 29
        Me.lblStatus.Text = "Status"
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(451, 68)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(159, 20)
        Me.stbBillNo.TabIndex = 22
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(451, 131)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(159, 20)
        Me.stbAge.TabIndex = 28
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(451, 215)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(159, 20)
        Me.stbJoinDate.TabIndex = 36
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(451, 173)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(159, 20)
        Me.stbGender.TabIndex = 32
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(337, 215)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(108, 20)
        Me.lblJoinDate.TabIndex = 35
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(337, 68)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(108, 20)
        Me.lblBillNo.TabIndex = 21
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(337, 131)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(108, 20)
        Me.lblAge.TabIndex = 27
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(337, 173)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(108, 20)
        Me.lblGenderID.TabIndex = 31
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
        'lblIndication
        '
        Me.lblIndication.Location = New System.Drawing.Point(11, 63)
        Me.lblIndication.Name = "lblIndication"
        Me.lblIndication.Size = New System.Drawing.Size(123, 20)
        Me.lblIndication.TabIndex = 3
        Me.lblIndication.Text = "Indication"
        '
        'btnPrint
        '
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(14, 277)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(89, 24)
        Me.btnPrint.TabIndex = 39
        Me.btnPrint.Text = "&Print"
        '
        'cboExamFullName
        '
        Me.cboExamFullName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboExamFullName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboExamFullName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboExamFullName.DropDownWidth = 214
        Me.cboExamFullName.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboExamFullName.FormattingEnabled = True
        Me.cboExamFullName.Location = New System.Drawing.Point(152, 36)
        Me.cboExamFullName.Name = "cboExamFullName"
        Me.cboExamFullName.Size = New System.Drawing.Size(170, 21)
        Me.cboExamFullName.Sorted = True
        Me.cboExamFullName.TabIndex = 2
        '
        'btnLoadDoneCardiology
        '
        Me.btnLoadDoneCardiology.AccessibleDescription = ""
        Me.btnLoadDoneCardiology.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadDoneCardiology.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadDoneCardiology.Location = New System.Drawing.Point(267, 4)
        Me.btnLoadDoneCardiology.Name = "btnLoadDoneCardiology"
        Me.btnLoadDoneCardiology.Size = New System.Drawing.Size(49, 24)
        Me.btnLoadDoneCardiology.TabIndex = 3
        Me.btnLoadDoneCardiology.Tag = ""
        Me.btnLoadDoneCardiology.Text = "&Load"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(451, 236)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(159, 29)
        Me.stbBillCustomerName.TabIndex = 38
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(337, 240)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(108, 20)
        Me.lblBillCustomerName.TabIndex = 37
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'pnlVisitNo
        '
        Me.pnlVisitNo.Controls.Add(Me.btnLoadDoneCardiology)
        Me.pnlVisitNo.Controls.Add(Me.stbVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.lblVisitNo)
        Me.pnlVisitNo.Controls.Add(Me.btnFindVisitNo)
        Me.pnlVisitNo.Location = New System.Drawing.Point(5, 1)
        Me.pnlVisitNo.Name = "pnlVisitNo"
        Me.pnlVisitNo.Size = New System.Drawing.Size(326, 31)
        Me.pnlVisitNo.TabIndex = 0
        '
        'stbExamDateTime
        '
        Me.stbExamDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExamDateTime.CapitalizeFirstLetter = False
        Me.stbExamDateTime.Enabled = False
        Me.stbExamDateTime.EntryErrorMSG = ""
        Me.stbExamDateTime.Location = New System.Drawing.Point(152, 88)
        Me.stbExamDateTime.MaxLength = 60
        Me.stbExamDateTime.Name = "stbExamDateTime"
        Me.stbExamDateTime.RegularExpression = ""
        Me.stbExamDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbExamDateTime.Size = New System.Drawing.Size(170, 20)
        Me.stbExamDateTime.TabIndex = 6
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(109, 277)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(87, 24)
        Me.btnPrintPreview.TabIndex = 40
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'stbCardiologist
        '
        Me.stbCardiologist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCardiologist.CapitalizeFirstLetter = False
        Me.stbCardiologist.Enabled = False
        Me.stbCardiologist.EntryErrorMSG = ""
        Me.stbCardiologist.Location = New System.Drawing.Point(152, 213)
        Me.stbCardiologist.MaxLength = 60
        Me.stbCardiologist.Name = "stbCardiologist"
        Me.stbCardiologist.RegularExpression = ""
        Me.stbCardiologist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCardiologist.Size = New System.Drawing.Size(170, 20)
        Me.stbCardiologist.TabIndex = 12
        '
        'stbCardiologyTitle
        '
        Me.stbCardiologyTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCardiologyTitle.CapitalizeFirstLetter = False
        Me.stbCardiologyTitle.Enabled = False
        Me.stbCardiologyTitle.EntryErrorMSG = ""
        Me.stbCardiologyTitle.Location = New System.Drawing.Point(152, 234)
        Me.stbCardiologyTitle.MaxLength = 60
        Me.stbCardiologyTitle.Name = "stbCardiologyTitle"
        Me.stbCardiologyTitle.RegularExpression = ""
        Me.stbCardiologyTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCardiologyTitle.Size = New System.Drawing.Size(170, 20)
        Me.stbCardiologyTitle.TabIndex = 14
        '
        'lblCardiologyTitle
        '
        Me.lblCardiologyTitle.Location = New System.Drawing.Point(11, 234)
        Me.lblCardiologyTitle.Name = "lblCardiologyTitle"
        Me.lblCardiologyTitle.Size = New System.Drawing.Size(123, 20)
        Me.lblCardiologyTitle.TabIndex = 13
        Me.lblCardiologyTitle.Text = "Cardiology Title"
        '
        'frmPrintCardiologyReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(626, 316)
        Me.Controls.Add(Me.stbCardiologyTitle)
        Me.Controls.Add(Me.lblCardiologyTitle)
        Me.Controls.Add(Me.stbCardiologist)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.stbExamDateTime)
        Me.Controls.Add(Me.pnlVisitNo)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.cboExamFullName)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.stbPrimaryDoctor)
        Me.Controls.Add(Me.lblPrimaryDoctor)
        Me.Controls.Add(Me.stbIndication)
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
        Me.Controls.Add(Me.lblIndication)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblExamFullName)
        Me.Controls.Add(Me.lblExamDateTime)
        Me.Controls.Add(Me.stbReport)
        Me.Controls.Add(Me.lblReport)
        Me.Controls.Add(Me.stbConclusion)
        Me.Controls.Add(Me.lblConclusion)
        Me.Controls.Add(Me.lblCardiologist)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPrintCardiologyReports"
        Me.Text = "Print Cardiology Reports"
        Me.pnlVisitNo.ResumeLayout(False)
        Me.pnlVisitNo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblExamFullName As System.Windows.Forms.Label
    Friend WithEvents lblExamDateTime As System.Windows.Forms.Label
    Friend WithEvents stbReport As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReport As System.Windows.Forms.Label
    Friend WithEvents stbConclusion As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblConclusion As System.Windows.Forms.Label
    Friend WithEvents lblCardiologist As System.Windows.Forms.Label
    Friend WithEvents stbPrimaryDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPrimaryDoctor As System.Windows.Forms.Label
    Friend WithEvents stbIndication As SyncSoft.Common.Win.Controls.SmartTextBox
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
    Friend WithEvents lblIndication As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cboExamFullName As System.Windows.Forms.ComboBox
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents btnLoadDoneCardiology As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents pnlVisitNo As System.Windows.Forms.Panel
    Friend WithEvents stbExamDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents stbCardiologist As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbCardiologyTitle As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCardiologyTitle As System.Windows.Forms.Label

End Class