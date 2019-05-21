
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintIPDRadiologyReports : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal roundNo As String)
        MyClass.New()
        Me.defaultRoundNo = roundNo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrintIPDRadiologyReports))
        Me.stbReport = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbConclusion = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbIndication = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblExamFullName = New System.Windows.Forms.Label()
        Me.lblExamDateTime = New System.Windows.Forms.Label()
        Me.lblReport = New System.Windows.Forms.Label()
        Me.lblConclusion = New System.Windows.Forms.Label()
        Me.lblRadiologist = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblIndication = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.cboExamFullName = New System.Windows.Forms.ComboBox()
        Me.pnlRoundNo = New System.Windows.Forms.Panel()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadDoneRadiology = New System.Windows.Forms.Button()
        Me.btnFindRoundNo = New System.Windows.Forms.Button()
        Me.btnFindAdmissionNo = New System.Windows.Forms.Button()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.lblAdmissionNo = New System.Windows.Forms.Label()
        Me.stbRoundDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRoundDateTime = New System.Windows.Forms.Label()
        Me.stbAdmissionDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionDateTime = New System.Windows.Forms.Label()
        Me.stbAttendingDoctor = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAttendingDoctor = New System.Windows.Forms.Label()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbBillNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillNo = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbVisitCategory = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.lblVisitCategory = New System.Windows.Forms.Label()
        Me.stbStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbExamDateTime = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbRadiologist = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnPrintPreview = New System.Windows.Forms.Button()
        Me.stbRadiologyTitle = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblRadiologyTitle = New System.Windows.Forms.Label()
        Me.pnlRoundNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbReport
        '
        Me.stbReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReport.CapitalizeFirstLetter = True
        Me.stbReport.EntryErrorMSG = ""
        Me.stbReport.Location = New System.Drawing.Point(152, 137)
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
        Me.stbConclusion.Location = New System.Drawing.Point(152, 188)
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
        Me.stbIndication.Location = New System.Drawing.Point(152, 87)
        Me.stbIndication.MaxLength = 4000
        Me.stbIndication.Multiline = True
        Me.stbIndication.Name = "stbIndication"
        Me.stbIndication.ReadOnly = True
        Me.stbIndication.RegularExpression = ""
        Me.stbIndication.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbIndication.Size = New System.Drawing.Size(170, 28)
        Me.stbIndication.TabIndex = 4
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(525, 326)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(85, 24)
        Me.fbnClose.TabIndex = 47
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblExamFullName
        '
        Me.lblExamFullName.Location = New System.Drawing.Point(11, 64)
        Me.lblExamFullName.Name = "lblExamFullName"
        Me.lblExamFullName.Size = New System.Drawing.Size(123, 20)
        Me.lblExamFullName.TabIndex = 1
        Me.lblExamFullName.Text = "Radiology Examination"
        '
        'lblExamDateTime
        '
        Me.lblExamDateTime.Location = New System.Drawing.Point(11, 116)
        Me.lblExamDateTime.Name = "lblExamDateTime"
        Me.lblExamDateTime.Size = New System.Drawing.Size(123, 20)
        Me.lblExamDateTime.TabIndex = 5
        Me.lblExamDateTime.Text = "Exam Date Time"
        '
        'lblReport
        '
        Me.lblReport.Location = New System.Drawing.Point(11, 159)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(123, 20)
        Me.lblReport.TabIndex = 7
        Me.lblReport.Text = "Report"
        '
        'lblConclusion
        '
        Me.lblConclusion.Location = New System.Drawing.Point(11, 209)
        Me.lblConclusion.Name = "lblConclusion"
        Me.lblConclusion.Size = New System.Drawing.Size(123, 20)
        Me.lblConclusion.TabIndex = 9
        Me.lblConclusion.Text = "Conclusion"
        '
        'lblRadiologist
        '
        Me.lblRadiologist.Location = New System.Drawing.Point(11, 241)
        Me.lblRadiologist.Name = "lblRadiologist"
        Me.lblRadiologist.Size = New System.Drawing.Size(123, 20)
        Me.lblRadiologist.TabIndex = 11
        Me.lblRadiologist.Text = "Radiologist"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(152, 283)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitDate.TabIndex = 16
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(11, 283)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(123, 20)
        Me.lblVisitDate.TabIndex = 15
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(482, 6)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(128, 20)
        Me.stbFullName.TabIndex = 18
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(343, 6)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(133, 20)
        Me.lblFullName.TabIndex = 17
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblIndication
        '
        Me.lblIndication.Location = New System.Drawing.Point(11, 91)
        Me.lblIndication.Name = "lblIndication"
        Me.lblIndication.Size = New System.Drawing.Size(123, 20)
        Me.lblIndication.TabIndex = 3
        Me.lblIndication.Text = "Indication"
        '
        'btnPrint
        '
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(14, 326)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 24)
        Me.btnPrint.TabIndex = 45
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
        Me.cboExamFullName.Location = New System.Drawing.Point(152, 64)
        Me.cboExamFullName.Name = "cboExamFullName"
        Me.cboExamFullName.Size = New System.Drawing.Size(170, 21)
        Me.cboExamFullName.Sorted = True
        Me.cboExamFullName.TabIndex = 2
        '
        'pnlRoundNo
        '
        Me.pnlRoundNo.Controls.Add(Me.stbRoundNo)
        Me.pnlRoundNo.Controls.Add(Me.stbAdmissionNo)
        Me.pnlRoundNo.Controls.Add(Me.btnLoadDoneRadiology)
        Me.pnlRoundNo.Controls.Add(Me.btnFindRoundNo)
        Me.pnlRoundNo.Controls.Add(Me.btnFindAdmissionNo)
        Me.pnlRoundNo.Controls.Add(Me.lblRoundNo)
        Me.pnlRoundNo.Controls.Add(Me.lblAdmissionNo)
        Me.pnlRoundNo.Location = New System.Drawing.Point(5, 3)
        Me.pnlRoundNo.Name = "pnlRoundNo"
        Me.pnlRoundNo.Size = New System.Drawing.Size(326, 58)
        Me.pnlRoundNo.TabIndex = 0
        '
        'stbRoundNo
        '
        Me.stbRoundNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundNo.CapitalizeFirstLetter = False
        Me.stbRoundNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbRoundNo.EntryErrorMSG = ""
        Me.stbRoundNo.Location = New System.Drawing.Point(147, 28)
        Me.stbRoundNo.MaxLength = 20
        Me.stbRoundNo.Name = "stbRoundNo"
        Me.stbRoundNo.RegularExpression = ""
        Me.stbRoundNo.Size = New System.Drawing.Size(105, 20)
        Me.stbRoundNo.TabIndex = 5
        '
        'stbAdmissionNo
        '
        Me.stbAdmissionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionNo.CapitalizeFirstLetter = False
        Me.stbAdmissionNo.EntryErrorMSG = ""
        Me.stbAdmissionNo.Location = New System.Drawing.Point(147, 5)
        Me.stbAdmissionNo.MaxLength = 20
        Me.stbAdmissionNo.Name = "stbAdmissionNo"
        Me.stbAdmissionNo.ReadOnly = True
        Me.stbAdmissionNo.RegularExpression = ""
        Me.stbAdmissionNo.Size = New System.Drawing.Size(170, 20)
        Me.stbAdmissionNo.TabIndex = 2
        '
        'btnLoadDoneRadiology
        '
        Me.btnLoadDoneRadiology.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadDoneRadiology.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadDoneRadiology.Location = New System.Drawing.Point(258, 26)
        Me.btnLoadDoneRadiology.Name = "btnLoadDoneRadiology"
        Me.btnLoadDoneRadiology.Size = New System.Drawing.Size(59, 24)
        Me.btnLoadDoneRadiology.TabIndex = 6
        Me.btnLoadDoneRadiology.Tag = ""
        Me.btnLoadDoneRadiology.Text = "&Load"
        '
        'btnFindRoundNo
        '
        Me.btnFindRoundNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindRoundNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindRoundNo.Image = CType(resources.GetObject("btnFindRoundNo.Image"), System.Drawing.Image)
        Me.btnFindRoundNo.Location = New System.Drawing.Point(116, 27)
        Me.btnFindRoundNo.Name = "btnFindRoundNo"
        Me.btnFindRoundNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindRoundNo.TabIndex = 4
        '
        'btnFindAdmissionNo
        '
        Me.btnFindAdmissionNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindAdmissionNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindAdmissionNo.Image = CType(resources.GetObject("btnFindAdmissionNo.Image"), System.Drawing.Image)
        Me.btnFindAdmissionNo.Location = New System.Drawing.Point(116, 5)
        Me.btnFindAdmissionNo.Name = "btnFindAdmissionNo"
        Me.btnFindAdmissionNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindAdmissionNo.TabIndex = 1
        '
        'lblRoundNo
        '
        Me.lblRoundNo.Location = New System.Drawing.Point(11, 27)
        Me.lblRoundNo.Name = "lblRoundNo"
        Me.lblRoundNo.Size = New System.Drawing.Size(89, 20)
        Me.lblRoundNo.TabIndex = 3
        Me.lblRoundNo.Text = "Round No"
        '
        'lblAdmissionNo
        '
        Me.lblAdmissionNo.AccessibleDescription = " "
        Me.lblAdmissionNo.Location = New System.Drawing.Point(11, 5)
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
        Me.stbRoundDateTime.Location = New System.Drawing.Point(482, 132)
        Me.stbRoundDateTime.MaxLength = 60
        Me.stbRoundDateTime.Name = "stbRoundDateTime"
        Me.stbRoundDateTime.RegularExpression = ""
        Me.stbRoundDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRoundDateTime.Size = New System.Drawing.Size(128, 20)
        Me.stbRoundDateTime.TabIndex = 30
        '
        'lblRoundDateTime
        '
        Me.lblRoundDateTime.Location = New System.Drawing.Point(343, 132)
        Me.lblRoundDateTime.Name = "lblRoundDateTime"
        Me.lblRoundDateTime.Size = New System.Drawing.Size(133, 20)
        Me.lblRoundDateTime.TabIndex = 29
        Me.lblRoundDateTime.Text = "Round Date and Time"
        '
        'stbAdmissionDateTime
        '
        Me.stbAdmissionDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionDateTime.CapitalizeFirstLetter = False
        Me.stbAdmissionDateTime.Enabled = False
        Me.stbAdmissionDateTime.EntryErrorMSG = ""
        Me.stbAdmissionDateTime.Location = New System.Drawing.Point(482, 111)
        Me.stbAdmissionDateTime.MaxLength = 60
        Me.stbAdmissionDateTime.Name = "stbAdmissionDateTime"
        Me.stbAdmissionDateTime.RegularExpression = ""
        Me.stbAdmissionDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionDateTime.Size = New System.Drawing.Size(128, 20)
        Me.stbAdmissionDateTime.TabIndex = 28
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(343, 113)
        Me.lblAdmissionDateTime.Name = "lblAdmissionDateTime"
        Me.lblAdmissionDateTime.Size = New System.Drawing.Size(133, 20)
        Me.lblAdmissionDateTime.TabIndex = 27
        Me.lblAdmissionDateTime.Text = "Admission Date Time"
        '
        'stbAttendingDoctor
        '
        Me.stbAttendingDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAttendingDoctor.CapitalizeFirstLetter = False
        Me.stbAttendingDoctor.Enabled = False
        Me.stbAttendingDoctor.EntryErrorMSG = ""
        Me.stbAttendingDoctor.Location = New System.Drawing.Point(482, 90)
        Me.stbAttendingDoctor.MaxLength = 60
        Me.stbAttendingDoctor.Name = "stbAttendingDoctor"
        Me.stbAttendingDoctor.RegularExpression = ""
        Me.stbAttendingDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAttendingDoctor.Size = New System.Drawing.Size(128, 20)
        Me.stbAttendingDoctor.TabIndex = 26
        '
        'lblAttendingDoctor
        '
        Me.lblAttendingDoctor.Location = New System.Drawing.Point(343, 91)
        Me.lblAttendingDoctor.Name = "lblAttendingDoctor"
        Me.lblAttendingDoctor.Size = New System.Drawing.Size(133, 20)
        Me.lblAttendingDoctor.TabIndex = 25
        Me.lblAttendingDoctor.Text = "Attending Doctor"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(482, 48)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(128, 20)
        Me.stbPatientNo.TabIndex = 22
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(343, 49)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(133, 20)
        Me.lblPatientsNo.TabIndex = 21
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(482, 69)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(128, 20)
        Me.stbBillNo.TabIndex = 24
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(343, 69)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(133, 20)
        Me.lblBillNo.TabIndex = 23
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(482, 216)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(128, 20)
        Me.stbBillMode.TabIndex = 38
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(482, 258)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(128, 20)
        Me.stbVisitCategory.TabIndex = 42
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(343, 216)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(133, 20)
        Me.lblBillMode.TabIndex = 37
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(343, 259)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(133, 20)
        Me.lblVisitCategory.TabIndex = 41
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbStatus
        '
        Me.stbStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStatus.CapitalizeFirstLetter = False
        Me.stbStatus.Enabled = False
        Me.stbStatus.EntryErrorMSG = ""
        Me.stbStatus.Location = New System.Drawing.Point(482, 174)
        Me.stbStatus.MaxLength = 60
        Me.stbStatus.Name = "stbStatus"
        Me.stbStatus.RegularExpression = ""
        Me.stbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStatus.Size = New System.Drawing.Size(128, 20)
        Me.stbStatus.TabIndex = 34
        '
        'lblStatus
        '
        Me.lblStatus.Location = New System.Drawing.Point(343, 174)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(133, 20)
        Me.lblStatus.TabIndex = 33
        Me.lblStatus.Text = "Status"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(482, 153)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(128, 20)
        Me.stbAge.TabIndex = 32
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(482, 237)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(128, 20)
        Me.stbJoinDate.TabIndex = 40
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(482, 195)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(128, 20)
        Me.stbGender.TabIndex = 36
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(343, 237)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(133, 20)
        Me.lblJoinDate.TabIndex = 39
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(343, 153)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(133, 20)
        Me.lblAge.TabIndex = 31
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(343, 195)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(133, 20)
        Me.lblGenderID.TabIndex = 35
        Me.lblGenderID.Text = "Gender"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(482, 27)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(128, 20)
        Me.stbVisitNo.TabIndex = 20
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(343, 27)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(133, 20)
        Me.lblVisitNo.TabIndex = 19
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(482, 280)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(128, 36)
        Me.stbBillCustomerName.TabIndex = 44
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(346, 287)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(130, 20)
        Me.lblBillCustomerName.TabIndex = 43
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'stbExamDateTime
        '
        Me.stbExamDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbExamDateTime.CapitalizeFirstLetter = False
        Me.stbExamDateTime.Enabled = False
        Me.stbExamDateTime.EntryErrorMSG = ""
        Me.stbExamDateTime.Location = New System.Drawing.Point(152, 116)
        Me.stbExamDateTime.MaxLength = 60
        Me.stbExamDateTime.Name = "stbExamDateTime"
        Me.stbExamDateTime.RegularExpression = ""
        Me.stbExamDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbExamDateTime.Size = New System.Drawing.Size(170, 20)
        Me.stbExamDateTime.TabIndex = 6
        '
        'stbRadiologist
        '
        Me.stbRadiologist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRadiologist.CapitalizeFirstLetter = False
        Me.stbRadiologist.Enabled = False
        Me.stbRadiologist.EntryErrorMSG = ""
        Me.stbRadiologist.Location = New System.Drawing.Point(152, 241)
        Me.stbRadiologist.MaxLength = 60
        Me.stbRadiologist.Name = "stbRadiologist"
        Me.stbRadiologist.RegularExpression = ""
        Me.stbRadiologist.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRadiologist.Size = New System.Drawing.Size(170, 20)
        Me.stbRadiologist.TabIndex = 12
        '
        'btnPrintPreview
        '
        Me.btnPrintPreview.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintPreview.Location = New System.Drawing.Point(108, 326)
        Me.btnPrintPreview.Name = "btnPrintPreview"
        Me.btnPrintPreview.Size = New System.Drawing.Size(87, 24)
        Me.btnPrintPreview.TabIndex = 46
        Me.btnPrintPreview.Text = "Print Pre&view"
        '
        'stbRadiologyTitle
        '
        Me.stbRadiologyTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRadiologyTitle.CapitalizeFirstLetter = False
        Me.stbRadiologyTitle.Enabled = False
        Me.stbRadiologyTitle.EntryErrorMSG = ""
        Me.stbRadiologyTitle.Location = New System.Drawing.Point(152, 262)
        Me.stbRadiologyTitle.MaxLength = 60
        Me.stbRadiologyTitle.Name = "stbRadiologyTitle"
        Me.stbRadiologyTitle.RegularExpression = ""
        Me.stbRadiologyTitle.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRadiologyTitle.Size = New System.Drawing.Size(170, 20)
        Me.stbRadiologyTitle.TabIndex = 14
        '
        'lblRadiologyTitle
        '
        Me.lblRadiologyTitle.Location = New System.Drawing.Point(11, 262)
        Me.lblRadiologyTitle.Name = "lblRadiologyTitle"
        Me.lblRadiologyTitle.Size = New System.Drawing.Size(123, 20)
        Me.lblRadiologyTitle.TabIndex = 13
        Me.lblRadiologyTitle.Text = "Radiology Title"
        '
        'frmPrintIPDRadiologyReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(632, 364)
        Me.Controls.Add(Me.stbRadiologyTitle)
        Me.Controls.Add(Me.lblRadiologyTitle)
        Me.Controls.Add(Me.btnPrintPreview)
        Me.Controls.Add(Me.stbRadiologist)
        Me.Controls.Add(Me.stbExamDateTime)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.stbVisitCategory)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.lblVisitCategory)
        Me.Controls.Add(Me.stbStatus)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbRoundDateTime)
        Me.Controls.Add(Me.lblRoundDateTime)
        Me.Controls.Add(Me.stbAdmissionDateTime)
        Me.Controls.Add(Me.lblAdmissionDateTime)
        Me.Controls.Add(Me.stbAttendingDoctor)
        Me.Controls.Add(Me.lblAttendingDoctor)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.stbBillNo)
        Me.Controls.Add(Me.lblBillNo)
        Me.Controls.Add(Me.pnlRoundNo)
        Me.Controls.Add(Me.cboExamFullName)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.stbIndication)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblIndication)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblExamFullName)
        Me.Controls.Add(Me.lblExamDateTime)
        Me.Controls.Add(Me.stbReport)
        Me.Controls.Add(Me.lblReport)
        Me.Controls.Add(Me.stbConclusion)
        Me.Controls.Add(Me.lblConclusion)
        Me.Controls.Add(Me.lblRadiologist)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPrintIPDRadiologyReports"
        Me.Text = "Print IPD Radiology Reports"
        Me.pnlRoundNo.ResumeLayout(False)
        Me.pnlRoundNo.PerformLayout()
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
    Friend WithEvents lblRadiologist As System.Windows.Forms.Label
    Friend WithEvents stbIndication As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblIndication As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cboExamFullName As System.Windows.Forms.ComboBox
    Friend WithEvents pnlRoundNo As System.Windows.Forms.Panel
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadDoneRadiology As System.Windows.Forms.Button
    Friend WithEvents btnFindRoundNo As System.Windows.Forms.Button
    Friend WithEvents btnFindAdmissionNo As System.Windows.Forms.Button
    Friend WithEvents lblRoundNo As System.Windows.Forms.Label
    Friend WithEvents lblAdmissionNo As System.Windows.Forms.Label
    Friend WithEvents stbRoundDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRoundDateTime As System.Windows.Forms.Label
    Friend WithEvents stbAdmissionDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionDateTime As System.Windows.Forms.Label
    Friend WithEvents stbAttendingDoctor As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAttendingDoctor As System.Windows.Forms.Label
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbBillNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillNo As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitCategory As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents lblVisitCategory As System.Windows.Forms.Label
    Friend WithEvents stbStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents stbExamDateTime As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbRadiologist As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnPrintPreview As System.Windows.Forms.Button
    Friend WithEvents stbRadiologyTitle As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRadiologyTitle As System.Windows.Forms.Label

End Class