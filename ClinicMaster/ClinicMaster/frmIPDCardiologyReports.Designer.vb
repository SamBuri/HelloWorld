
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIPDCardiologyReports : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIPDCardiologyReports))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpExamDateTime = New System.Windows.Forms.DateTimePicker()
        Me.stbReport = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbConclusion = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboCardiologist = New System.Windows.Forms.ComboBox()
        Me.stbIndication = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboCardiologyTitleID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblExamFullName = New System.Windows.Forms.Label()
        Me.lblExamDateTime = New System.Windows.Forms.Label()
        Me.lblReport = New System.Windows.Forms.Label()
        Me.lblConclusion = New System.Windows.Forms.Label()
        Me.lblCardiologist = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblIndication = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintExamReportOnSaving = New System.Windows.Forms.CheckBox()
        Me.cboExamFullName = New System.Windows.Forms.ComboBox()
        Me.stbUnitPrice = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.pnlRoundNo = New System.Windows.Forms.Panel()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadPendingCardiology = New System.Windows.Forms.Button()
        Me.btnFindRoundNo = New System.Windows.Forms.Button()
        Me.btnFindAdmissionNo = New System.Windows.Forms.Button()
        Me.lblRoundNo = New System.Windows.Forms.Label()
        Me.lblAdmissionNo = New System.Windows.Forms.Label()
        Me.btnViewTemplates = New System.Windows.Forms.Button()
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
        Me.stbAdmissionStatus = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAdmissionStatus = New System.Windows.Forms.Label()
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
        Me.lblCardiologyTitleID = New System.Windows.Forms.Label()
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.pnlRoundNo.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(11, 410)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 54
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnDelete.Enabled = False
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(793, 409)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 55
        Me.fbnDelete.Tag = "IPDCardiologyReports"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(11, 437)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 56
        Me.ebnSaveUpdate.Tag = "IPDCardiologyReports"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpExamDateTime
        '
        Me.dtpExamDateTime.Checked = False
        Me.dtpExamDateTime.CustomFormat = "dd MMM yyyy hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.dtpExamDateTime, "ExamDateTime")
        Me.dtpExamDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpExamDateTime.Location = New System.Drawing.Point(152, 137)
        Me.dtpExamDateTime.Name = "dtpExamDateTime"
        Me.dtpExamDateTime.ShowCheckBox = True
        Me.dtpExamDateTime.Size = New System.Drawing.Size(170, 20)
        Me.dtpExamDateTime.TabIndex = 8
        '
        'stbReport
        '
        Me.stbReport.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stbReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReport.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbReport, "Report")
        Me.stbReport.EntryErrorMSG = ""
        Me.stbReport.Location = New System.Drawing.Point(152, 230)
        Me.stbReport.MaxLength = 4000
        Me.stbReport.Multiline = True
        Me.stbReport.Name = "stbReport"
        Me.stbReport.RegularExpression = ""
        Me.stbReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbReport.Size = New System.Drawing.Size(713, 113)
        Me.stbReport.TabIndex = 16
        '
        'stbConclusion
        '
        Me.stbConclusion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.stbConclusion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbConclusion.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbConclusion, "Conclusion")
        Me.stbConclusion.EntryErrorMSG = ""
        Me.stbConclusion.Location = New System.Drawing.Point(152, 344)
        Me.stbConclusion.MaxLength = 4000
        Me.stbConclusion.Multiline = True
        Me.stbConclusion.Name = "stbConclusion"
        Me.stbConclusion.RegularExpression = ""
        Me.stbConclusion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbConclusion.Size = New System.Drawing.Size(713, 60)
        Me.stbConclusion.TabIndex = 18
        '
        'cboCardiologist
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCardiologist, "CardiologistFullName")
        Me.cboCardiologist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCardiologist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCardiologist.Location = New System.Drawing.Point(152, 158)
        Me.cboCardiologist.Name = "cboCardiologist"
        Me.cboCardiologist.Size = New System.Drawing.Size(170, 21)
        Me.cboCardiologist.TabIndex = 10
        '
        'stbIndication
        '
        Me.stbIndication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbIndication.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbIndication, "Indication")
        Me.stbIndication.EntryErrorMSG = ""
        Me.stbIndication.Location = New System.Drawing.Point(152, 87)
        Me.stbIndication.MaxLength = 4000
        Me.stbIndication.Multiline = True
        Me.stbIndication.Name = "stbIndication"
        Me.stbIndication.RegularExpression = ""
        Me.stbIndication.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbIndication.Size = New System.Drawing.Size(170, 28)
        Me.stbIndication.TabIndex = 4
        '
        'cboCardiologyTitleID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCardiologyTitleID, "CardiologyTitle,CardiologyTitleID")
        Me.cboCardiologyTitleID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCardiologyTitleID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCardiologyTitleID.Location = New System.Drawing.Point(152, 181)
        Me.cboCardiologyTitleID.Name = "cboCardiologyTitleID"
        Me.cboCardiologyTitleID.Size = New System.Drawing.Size(170, 21)
        Me.cboCardiologyTitleID.TabIndex = 12
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(793, 436)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 59
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblExamFullName
        '
        Me.lblExamFullName.Location = New System.Drawing.Point(11, 64)
        Me.lblExamFullName.Name = "lblExamFullName"
        Me.lblExamFullName.Size = New System.Drawing.Size(123, 20)
        Me.lblExamFullName.TabIndex = 1
        Me.lblExamFullName.Text = "Cardiology Examination"
        '
        'lblExamDateTime
        '
        Me.lblExamDateTime.Location = New System.Drawing.Point(11, 140)
        Me.lblExamDateTime.Name = "lblExamDateTime"
        Me.lblExamDateTime.Size = New System.Drawing.Size(123, 20)
        Me.lblExamDateTime.TabIndex = 7
        Me.lblExamDateTime.Text = "Exam Date Time"
        '
        'lblReport
        '
        Me.lblReport.Location = New System.Drawing.Point(11, 257)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(123, 20)
        Me.lblReport.TabIndex = 15
        Me.lblReport.Text = "Report"
        '
        'lblConclusion
        '
        Me.lblConclusion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblConclusion.Location = New System.Drawing.Point(11, 367)
        Me.lblConclusion.Name = "lblConclusion"
        Me.lblConclusion.Size = New System.Drawing.Size(123, 20)
        Me.lblConclusion.TabIndex = 17
        Me.lblConclusion.Text = "Conclusion"
        '
        'lblCardiologist
        '
        Me.lblCardiologist.Location = New System.Drawing.Point(11, 160)
        Me.lblCardiologist.Name = "lblCardiologist"
        Me.lblCardiologist.Size = New System.Drawing.Size(123, 20)
        Me.lblCardiologist.TabIndex = 9
        Me.lblCardiologist.Text = "Cardiologist"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(152, 204)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitDate.TabIndex = 14
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(11, 204)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(123, 20)
        Me.lblVisitDate.TabIndex = 13
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(482, 3)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(110, 20)
        Me.stbFullName.TabIndex = 20
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(343, 3)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(133, 20)
        Me.lblFullName.TabIndex = 19
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
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(709, 436)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(78, 24)
        Me.btnPrint.TabIndex = 58
        Me.btnPrint.Text = "&Print"
        '
        'chkPrintExamReportOnSaving
        '
        Me.chkPrintExamReportOnSaving.AccessibleDescription = ""
        Me.chkPrintExamReportOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintExamReportOnSaving.AutoSize = True
        Me.chkPrintExamReportOnSaving.Location = New System.Drawing.Point(94, 445)
        Me.chkPrintExamReportOnSaving.Name = "chkPrintExamReportOnSaving"
        Me.chkPrintExamReportOnSaving.Size = New System.Drawing.Size(167, 17)
        Me.chkPrintExamReportOnSaving.TabIndex = 57
        Me.chkPrintExamReportOnSaving.Text = " Print Exam Report On Saving"
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
        'stbUnitPrice
        '
        Me.stbUnitPrice.BackColor = System.Drawing.SystemColors.Info
        Me.stbUnitPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbUnitPrice.CapitalizeFirstLetter = False
        Me.stbUnitPrice.Enabled = False
        Me.stbUnitPrice.EntryErrorMSG = ""
        Me.stbUnitPrice.Location = New System.Drawing.Point(152, 116)
        Me.stbUnitPrice.MaxLength = 20
        Me.stbUnitPrice.Name = "stbUnitPrice"
        Me.stbUnitPrice.RegularExpression = ""
        Me.stbUnitPrice.Size = New System.Drawing.Size(170, 20)
        Me.stbUnitPrice.TabIndex = 6
        Me.stbUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Location = New System.Drawing.Point(11, 116)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(123, 20)
        Me.lblUnitPrice.TabIndex = 5
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'pnlRoundNo
        '
        Me.pnlRoundNo.Controls.Add(Me.stbRoundNo)
        Me.pnlRoundNo.Controls.Add(Me.stbAdmissionNo)
        Me.pnlRoundNo.Controls.Add(Me.btnLoadPendingCardiology)
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
        'btnLoadPendingCardiology
        '
        Me.btnLoadPendingCardiology.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPendingCardiology.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPendingCardiology.Location = New System.Drawing.Point(258, 26)
        Me.btnLoadPendingCardiology.Name = "btnLoadPendingCardiology"
        Me.btnLoadPendingCardiology.Size = New System.Drawing.Size(59, 24)
        Me.btnLoadPendingCardiology.TabIndex = 6
        Me.btnLoadPendingCardiology.Tag = ""
        Me.btnLoadPendingCardiology.Text = "&Load"
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
        'btnViewTemplates
        '
        Me.btnViewTemplates.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewTemplates.Location = New System.Drawing.Point(737, 190)
        Me.btnViewTemplates.Name = "btnViewTemplates"
        Me.btnViewTemplates.Size = New System.Drawing.Size(128, 24)
        Me.btnViewTemplates.TabIndex = 53
        Me.btnViewTemplates.Tag = ""
        Me.btnViewTemplates.Text = "&View Templates"
        '
        'stbRoundDateTime
        '
        Me.stbRoundDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRoundDateTime.CapitalizeFirstLetter = False
        Me.stbRoundDateTime.Enabled = False
        Me.stbRoundDateTime.EntryErrorMSG = ""
        Me.stbRoundDateTime.Location = New System.Drawing.Point(482, 129)
        Me.stbRoundDateTime.MaxLength = 60
        Me.stbRoundDateTime.Name = "stbRoundDateTime"
        Me.stbRoundDateTime.RegularExpression = ""
        Me.stbRoundDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRoundDateTime.Size = New System.Drawing.Size(110, 20)
        Me.stbRoundDateTime.TabIndex = 32
        '
        'lblRoundDateTime
        '
        Me.lblRoundDateTime.Location = New System.Drawing.Point(343, 129)
        Me.lblRoundDateTime.Name = "lblRoundDateTime"
        Me.lblRoundDateTime.Size = New System.Drawing.Size(133, 20)
        Me.lblRoundDateTime.TabIndex = 31
        Me.lblRoundDateTime.Text = "Round Date and Time"
        '
        'stbAdmissionDateTime
        '
        Me.stbAdmissionDateTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionDateTime.CapitalizeFirstLetter = False
        Me.stbAdmissionDateTime.Enabled = False
        Me.stbAdmissionDateTime.EntryErrorMSG = ""
        Me.stbAdmissionDateTime.Location = New System.Drawing.Point(482, 108)
        Me.stbAdmissionDateTime.MaxLength = 60
        Me.stbAdmissionDateTime.Name = "stbAdmissionDateTime"
        Me.stbAdmissionDateTime.RegularExpression = ""
        Me.stbAdmissionDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionDateTime.Size = New System.Drawing.Size(110, 20)
        Me.stbAdmissionDateTime.TabIndex = 30
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(343, 110)
        Me.lblAdmissionDateTime.Name = "lblAdmissionDateTime"
        Me.lblAdmissionDateTime.Size = New System.Drawing.Size(133, 20)
        Me.lblAdmissionDateTime.TabIndex = 29
        Me.lblAdmissionDateTime.Text = "Admission Date Time"
        '
        'stbAttendingDoctor
        '
        Me.stbAttendingDoctor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAttendingDoctor.CapitalizeFirstLetter = False
        Me.stbAttendingDoctor.Enabled = False
        Me.stbAttendingDoctor.EntryErrorMSG = ""
        Me.stbAttendingDoctor.Location = New System.Drawing.Point(482, 87)
        Me.stbAttendingDoctor.MaxLength = 60
        Me.stbAttendingDoctor.Name = "stbAttendingDoctor"
        Me.stbAttendingDoctor.RegularExpression = ""
        Me.stbAttendingDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAttendingDoctor.Size = New System.Drawing.Size(110, 20)
        Me.stbAttendingDoctor.TabIndex = 28
        '
        'lblAttendingDoctor
        '
        Me.lblAttendingDoctor.Location = New System.Drawing.Point(343, 88)
        Me.lblAttendingDoctor.Name = "lblAttendingDoctor"
        Me.lblAttendingDoctor.Size = New System.Drawing.Size(133, 20)
        Me.lblAttendingDoctor.TabIndex = 27
        Me.lblAttendingDoctor.Text = "Attending Doctor"
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(482, 45)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(110, 20)
        Me.stbPatientNo.TabIndex = 24
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(343, 46)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(133, 20)
        Me.lblPatientsNo.TabIndex = 23
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(482, 66)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(110, 20)
        Me.stbBillNo.TabIndex = 26
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(343, 66)
        Me.lblBillNo.Name = "lblBillNo"
        Me.lblBillNo.Size = New System.Drawing.Size(133, 20)
        Me.lblBillNo.TabIndex = 25
        Me.lblBillNo.Text = "To-Bill Number"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        Me.stbBillMode.Enabled = False
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Location = New System.Drawing.Point(737, 4)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(128, 20)
        Me.stbBillMode.TabIndex = 40
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(737, 46)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(128, 20)
        Me.stbVisitCategory.TabIndex = 44
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(598, 4)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(133, 20)
        Me.lblBillMode.TabIndex = 39
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(598, 47)
        Me.lblVisitCategory.Name = "lblVisitCategory"
        Me.lblVisitCategory.Size = New System.Drawing.Size(133, 20)
        Me.lblVisitCategory.TabIndex = 43
        Me.lblVisitCategory.Text = "Visit Category"
        '
        'stbAdmissionStatus
        '
        Me.stbAdmissionStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAdmissionStatus.CapitalizeFirstLetter = False
        Me.stbAdmissionStatus.Enabled = False
        Me.stbAdmissionStatus.EntryErrorMSG = ""
        Me.stbAdmissionStatus.Location = New System.Drawing.Point(482, 171)
        Me.stbAdmissionStatus.MaxLength = 60
        Me.stbAdmissionStatus.Name = "stbAdmissionStatus"
        Me.stbAdmissionStatus.RegularExpression = ""
        Me.stbAdmissionStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionStatus.Size = New System.Drawing.Size(110, 20)
        Me.stbAdmissionStatus.TabIndex = 36
        '
        'lblAdmissionStatus
        '
        Me.lblAdmissionStatus.Location = New System.Drawing.Point(343, 171)
        Me.lblAdmissionStatus.Name = "lblAdmissionStatus"
        Me.lblAdmissionStatus.Size = New System.Drawing.Size(133, 20)
        Me.lblAdmissionStatus.TabIndex = 35
        Me.lblAdmissionStatus.Text = "Status"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(482, 150)
        Me.stbAge.MaxLength = 60
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAge.Size = New System.Drawing.Size(110, 20)
        Me.stbAge.TabIndex = 34
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(737, 25)
        Me.stbJoinDate.MaxLength = 60
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbJoinDate.Size = New System.Drawing.Size(128, 20)
        Me.stbJoinDate.TabIndex = 42
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(482, 192)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(110, 20)
        Me.stbGender.TabIndex = 38
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(598, 25)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(133, 20)
        Me.lblJoinDate.TabIndex = 41
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(343, 150)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(133, 20)
        Me.lblAge.TabIndex = 33
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(343, 192)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(133, 20)
        Me.lblGenderID.TabIndex = 37
        Me.lblGenderID.Text = "Gender"
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.Enabled = False
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(482, 24)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(110, 20)
        Me.stbVisitNo.TabIndex = 22
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(343, 24)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(133, 20)
        Me.lblVisitNo.TabIndex = 21
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(737, 67)
        Me.stbBillCustomerName.MaxLength = 41
        Me.stbBillCustomerName.Multiline = True
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        Me.stbBillCustomerName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillCustomerName.Size = New System.Drawing.Size(128, 27)
        Me.stbBillCustomerName.TabIndex = 46
        '
        'lblBillCustomerName
        '
        Me.lblBillCustomerName.Location = New System.Drawing.Point(598, 74)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(133, 20)
        Me.lblBillCustomerName.TabIndex = 45
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'lblCardiologyTitleID
        '
        Me.lblCardiologyTitleID.Location = New System.Drawing.Point(11, 183)
        Me.lblCardiologyTitleID.Name = "lblCardiologyTitleID"
        Me.lblCardiologyTitleID.Size = New System.Drawing.Size(123, 20)
        Me.lblCardiologyTitleID.TabIndex = 11
        Me.lblCardiologyTitleID.Text = "Cardiology Title"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(737, 137)
        Me.nbxCoPayValue.MaxLength = 12
        Me.nbxCoPayValue.MaxValue = 0.0R
        Me.nbxCoPayValue.MinValue = 0.0R
        Me.nbxCoPayValue.MustEnterNumeric = True
        Me.nbxCoPayValue.Name = "nbxCoPayValue"
        Me.nbxCoPayValue.ReadOnly = True
        Me.nbxCoPayValue.Size = New System.Drawing.Size(128, 20)
        Me.nbxCoPayValue.TabIndex = 52
        Me.nbxCoPayValue.Value = ""
        '
        'lblCoPayValue
        '
        Me.lblCoPayValue.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayValue.Location = New System.Drawing.Point(598, 138)
        Me.lblCoPayValue.Name = "lblCoPayValue"
        Me.lblCoPayValue.Size = New System.Drawing.Size(133, 20)
        Me.lblCoPayValue.TabIndex = 51
        Me.lblCoPayValue.Text = "Co-Pay Value"
        '
        'nbxCoPayPercent
        '
        Me.nbxCoPayPercent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayPercent.ControlCaption = "Co-Pay Percent"
        Me.nbxCoPayPercent.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxCoPayPercent.DecimalPlaces = 2
        Me.nbxCoPayPercent.Enabled = False
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(737, 116)
        Me.nbxCoPayPercent.MaxLength = 3
        Me.nbxCoPayPercent.MaxValue = 100.0R
        Me.nbxCoPayPercent.MinValue = 0.0R
        Me.nbxCoPayPercent.MustEnterNumeric = True
        Me.nbxCoPayPercent.Name = "nbxCoPayPercent"
        Me.nbxCoPayPercent.Size = New System.Drawing.Size(128, 20)
        Me.nbxCoPayPercent.TabIndex = 50
        Me.nbxCoPayPercent.Value = ""
        '
        'lblCoPayPercent
        '
        Me.lblCoPayPercent.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayPercent.Location = New System.Drawing.Point(598, 117)
        Me.lblCoPayPercent.Name = "lblCoPayPercent"
        Me.lblCoPayPercent.Size = New System.Drawing.Size(133, 20)
        Me.lblCoPayPercent.TabIndex = 49
        Me.lblCoPayPercent.Text = "Co-Pay Percent"
        '
        'stbCoPayType
        '
        Me.stbCoPayType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCoPayType.CapitalizeFirstLetter = False
        Me.stbCoPayType.Enabled = False
        Me.stbCoPayType.EntryErrorMSG = ""
        Me.stbCoPayType.Location = New System.Drawing.Point(737, 95)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(128, 20)
        Me.stbCoPayType.TabIndex = 48
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(598, 95)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(133, 20)
        Me.lblCoPayType.TabIndex = 47
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'frmIPDCardiologyReports
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(882, 479)
        Me.Controls.Add(Me.nbxCoPayValue)
        Me.Controls.Add(Me.lblCoPayValue)
        Me.Controls.Add(Me.nbxCoPayPercent)
        Me.Controls.Add(Me.lblCoPayPercent)
        Me.Controls.Add(Me.stbCoPayType)
        Me.Controls.Add(Me.lblCoPayType)
        Me.Controls.Add(Me.cboCardiologyTitleID)
        Me.Controls.Add(Me.lblCardiologyTitleID)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.stbVisitCategory)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.lblVisitCategory)
        Me.Controls.Add(Me.stbAdmissionStatus)
        Me.Controls.Add(Me.lblAdmissionStatus)
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
        Me.Controls.Add(Me.btnViewTemplates)
        Me.Controls.Add(Me.pnlRoundNo)
        Me.Controls.Add(Me.stbUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.cboExamFullName)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.chkPrintExamReportOnSaving)
        Me.Controls.Add(Me.stbIndication)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblIndication)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblExamFullName)
        Me.Controls.Add(Me.dtpExamDateTime)
        Me.Controls.Add(Me.lblExamDateTime)
        Me.Controls.Add(Me.stbReport)
        Me.Controls.Add(Me.lblReport)
        Me.Controls.Add(Me.stbConclusion)
        Me.Controls.Add(Me.lblConclusion)
        Me.Controls.Add(Me.cboCardiologist)
        Me.Controls.Add(Me.lblCardiologist)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmIPDCardiologyReports"
        Me.Text = "IPD Cardiology Reports"
        Me.pnlRoundNo.ResumeLayout(False)
        Me.pnlRoundNo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblExamFullName As System.Windows.Forms.Label
    Friend WithEvents dtpExamDateTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblExamDateTime As System.Windows.Forms.Label
    Friend WithEvents stbReport As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReport As System.Windows.Forms.Label
    Friend WithEvents stbConclusion As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblConclusion As System.Windows.Forms.Label
    Friend WithEvents cboCardiologist As System.Windows.Forms.ComboBox
    Friend WithEvents lblCardiologist As System.Windows.Forms.Label
    Friend WithEvents stbIndication As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblIndication As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintExamReportOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents cboExamFullName As System.Windows.Forms.ComboBox
    Friend WithEvents stbUnitPrice As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents pnlRoundNo As System.Windows.Forms.Panel
    Friend WithEvents btnViewTemplates As System.Windows.Forms.Button
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadPendingCardiology As System.Windows.Forms.Button
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
    Friend WithEvents stbAdmissionStatus As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAdmissionStatus As System.Windows.Forms.Label
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
    Friend WithEvents cboCardiologyTitleID As System.Windows.Forms.ComboBox
    Friend WithEvents lblCardiologyTitleID As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label

End Class