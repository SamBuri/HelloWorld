
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIPDDentalReports : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIPDDentalReports))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.dtpReportDate = New System.Windows.Forms.DateTimePicker()
        Me.stbReport = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblDentalFullName = New System.Windows.Forms.Label()
        Me.lblReportDate = New System.Windows.Forms.Label()
        Me.lblReport = New System.Windows.Forms.Label()
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.chkPrintDentalReportOnSaving = New System.Windows.Forms.CheckBox()
        Me.cboDentalFullName = New System.Windows.Forms.ComboBox()
        Me.stbUnitPrice = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblUnitPrice = New System.Windows.Forms.Label()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.btnViewList = New System.Windows.Forms.Button()
        Me.lblIPDAlerts = New System.Windows.Forms.Label()
        Me.tmrIPDAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.pnlRoundNo = New System.Windows.Forms.Panel()
        Me.stbRoundNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbAdmissionNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.btnLoadPendingDental = New System.Windows.Forms.Button()
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
        Me.nbxCoPayValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayValue = New System.Windows.Forms.Label()
        Me.nbxCoPayPercent = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.lblCoPayPercent = New System.Windows.Forms.Label()
        Me.stbCoPayType = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblCoPayType = New System.Windows.Forms.Label()
        Me.pnlAlerts.SuspendLayout()
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
        Me.fbnSearch.TabIndex = 55
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
        Me.fbnDelete.TabIndex = 56
        Me.fbnDelete.Tag = "IPDDentalReports"
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
        Me.ebnSaveUpdate.TabIndex = 57
        Me.ebnSaveUpdate.Tag = "IPDDentalReports"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpReportDate
        '
        Me.dtpReportDate.Checked = False
        Me.dtpReportDate.CustomFormat = ""
        Me.ebnSaveUpdate.SetDataMember(Me.dtpReportDate, "ReportDate")
        Me.dtpReportDate.Location = New System.Drawing.Point(152, 107)
        Me.dtpReportDate.Name = "dtpReportDate"
        Me.dtpReportDate.ShowCheckBox = True
        Me.dtpReportDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpReportDate.TabIndex = 8
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
        Me.stbReport.Location = New System.Drawing.Point(152, 194)
        Me.stbReport.MaxLength = 4000
        Me.stbReport.Multiline = True
        Me.stbReport.Name = "stbReport"
        Me.stbReport.RegularExpression = ""
        Me.stbReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbReport.Size = New System.Drawing.Size(713, 209)
        Me.stbReport.TabIndex = 16
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
        Me.fbnClose.TabIndex = 60
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblDentalFullName
        '
        Me.lblDentalFullName.Location = New System.Drawing.Point(11, 64)
        Me.lblDentalFullName.Name = "lblDentalFullName"
        Me.lblDentalFullName.Size = New System.Drawing.Size(123, 20)
        Me.lblDentalFullName.TabIndex = 1
        Me.lblDentalFullName.Text = "Dental Service(s)"
        '
        'lblReportDate
        '
        Me.lblReportDate.Location = New System.Drawing.Point(11, 110)
        Me.lblReportDate.Name = "lblReportDate"
        Me.lblReportDate.Size = New System.Drawing.Size(123, 20)
        Me.lblReportDate.TabIndex = 7
        Me.lblReportDate.Text = "Report Date"
        '
        'lblReport
        '
        Me.lblReport.Location = New System.Drawing.Point(11, 257)
        Me.lblReport.Name = "lblReport"
        Me.lblReport.Size = New System.Drawing.Size(123, 20)
        Me.lblReport.TabIndex = 15
        Me.lblReport.Text = "Report"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.CapitalizeFirstLetter = False
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.EntryErrorMSG = ""
        Me.stbVisitDate.Location = New System.Drawing.Point(481, 3)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.RegularExpression = ""
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(110, 20)
        Me.stbVisitDate.TabIndex = 14
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(340, 3)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(133, 20)
        Me.lblVisitDate.TabIndex = 13
        Me.lblVisitDate.Text = "Visit Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(152, 128)
        Me.stbFullName.MaxLength = 60
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbFullName.Size = New System.Drawing.Size(170, 20)
        Me.stbFullName.TabIndex = 20
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(11, 130)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(123, 20)
        Me.lblFullName.TabIndex = 19
        Me.lblFullName.Text = "Patient's Name"
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(709, 436)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(78, 24)
        Me.btnPrint.TabIndex = 59
        Me.btnPrint.Text = "&Print"
        '
        'chkPrintDentalReportOnSaving
        '
        Me.chkPrintDentalReportOnSaving.AccessibleDescription = ""
        Me.chkPrintDentalReportOnSaving.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.chkPrintDentalReportOnSaving.AutoSize = True
        Me.chkPrintDentalReportOnSaving.Location = New System.Drawing.Point(94, 445)
        Me.chkPrintDentalReportOnSaving.Name = "chkPrintDentalReportOnSaving"
        Me.chkPrintDentalReportOnSaving.Size = New System.Drawing.Size(172, 17)
        Me.chkPrintDentalReportOnSaving.TabIndex = 58
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
        Me.cboDentalFullName.Location = New System.Drawing.Point(152, 64)
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
        Me.stbUnitPrice.Location = New System.Drawing.Point(152, 86)
        Me.stbUnitPrice.MaxLength = 20
        Me.stbUnitPrice.Name = "stbUnitPrice"
        Me.stbUnitPrice.RegularExpression = ""
        Me.stbUnitPrice.Size = New System.Drawing.Size(170, 20)
        Me.stbUnitPrice.TabIndex = 6
        Me.stbUnitPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblUnitPrice
        '
        Me.lblUnitPrice.Location = New System.Drawing.Point(11, 86)
        Me.lblUnitPrice.Name = "lblUnitPrice"
        Me.lblUnitPrice.Size = New System.Drawing.Size(123, 20)
        Me.lblUnitPrice.TabIndex = 5
        Me.lblUnitPrice.Text = "Unit Price"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.btnViewList)
        Me.pnlAlerts.Controls.Add(Me.lblIPDAlerts)
        Me.pnlAlerts.Location = New System.Drawing.Point(595, 137)
        Me.pnlAlerts.Name = "pnlAlerts"
        Me.pnlAlerts.Size = New System.Drawing.Size(278, 36)
        Me.pnlAlerts.TabIndex = 54
        '
        'btnViewList
        '
        Me.btnViewList.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnViewList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewList.Location = New System.Drawing.Point(207, 5)
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
        Me.lblIPDAlerts.Location = New System.Drawing.Point(9, 7)
        Me.lblIPDAlerts.Name = "lblIPDAlerts"
        Me.lblIPDAlerts.Size = New System.Drawing.Size(192, 20)
        Me.lblIPDAlerts.TabIndex = 0
        Me.lblIPDAlerts.Text = "Doctor Dental: 0"
        '
        'tmrIPDAlerts
        '
        Me.tmrIPDAlerts.Enabled = True
        Me.tmrIPDAlerts.Interval = 120000
        '
        'pnlRoundNo
        '
        Me.pnlRoundNo.Controls.Add(Me.stbRoundNo)
        Me.pnlRoundNo.Controls.Add(Me.stbAdmissionNo)
        Me.pnlRoundNo.Controls.Add(Me.btnLoadPendingDental)
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
        'btnLoadPendingDental
        '
        Me.btnLoadPendingDental.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPendingDental.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPendingDental.Location = New System.Drawing.Point(258, 26)
        Me.btnLoadPendingDental.Name = "btnLoadPendingDental"
        Me.btnLoadPendingDental.Size = New System.Drawing.Size(59, 24)
        Me.btnLoadPendingDental.TabIndex = 6
        Me.btnLoadPendingDental.Tag = ""
        Me.btnLoadPendingDental.Text = "&Load"
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
        Me.stbRoundDateTime.Location = New System.Drawing.Point(481, 87)
        Me.stbRoundDateTime.MaxLength = 60
        Me.stbRoundDateTime.Name = "stbRoundDateTime"
        Me.stbRoundDateTime.RegularExpression = ""
        Me.stbRoundDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbRoundDateTime.Size = New System.Drawing.Size(110, 20)
        Me.stbRoundDateTime.TabIndex = 32
        '
        'lblRoundDateTime
        '
        Me.lblRoundDateTime.Location = New System.Drawing.Point(342, 87)
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
        Me.stbAdmissionDateTime.Location = New System.Drawing.Point(481, 66)
        Me.stbAdmissionDateTime.MaxLength = 60
        Me.stbAdmissionDateTime.Name = "stbAdmissionDateTime"
        Me.stbAdmissionDateTime.RegularExpression = ""
        Me.stbAdmissionDateTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionDateTime.Size = New System.Drawing.Size(110, 20)
        Me.stbAdmissionDateTime.TabIndex = 30
        '
        'lblAdmissionDateTime
        '
        Me.lblAdmissionDateTime.Location = New System.Drawing.Point(342, 68)
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
        Me.stbAttendingDoctor.Location = New System.Drawing.Point(481, 45)
        Me.stbAttendingDoctor.MaxLength = 60
        Me.stbAttendingDoctor.Name = "stbAttendingDoctor"
        Me.stbAttendingDoctor.RegularExpression = ""
        Me.stbAttendingDoctor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAttendingDoctor.Size = New System.Drawing.Size(110, 20)
        Me.stbAttendingDoctor.TabIndex = 28
        '
        'lblAttendingDoctor
        '
        Me.lblAttendingDoctor.Location = New System.Drawing.Point(342, 46)
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
        Me.stbPatientNo.Location = New System.Drawing.Point(152, 170)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(170, 20)
        Me.stbPatientNo.TabIndex = 24
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(11, 173)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(123, 20)
        Me.lblPatientsNo.TabIndex = 23
        Me.lblPatientsNo.Text = "Patient's No."
        '
        'stbBillNo
        '
        Me.stbBillNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillNo.CapitalizeFirstLetter = False
        Me.stbBillNo.Enabled = False
        Me.stbBillNo.EntryErrorMSG = ""
        Me.stbBillNo.Location = New System.Drawing.Point(481, 24)
        Me.stbBillNo.MaxLength = 60
        Me.stbBillNo.Name = "stbBillNo"
        Me.stbBillNo.RegularExpression = ""
        Me.stbBillNo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillNo.Size = New System.Drawing.Size(110, 20)
        Me.stbBillNo.TabIndex = 26
        '
        'lblBillNo
        '
        Me.lblBillNo.Location = New System.Drawing.Point(342, 24)
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
        Me.stbBillMode.Location = New System.Drawing.Point(481, 171)
        Me.stbBillMode.MaxLength = 60
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        Me.stbBillMode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbBillMode.Size = New System.Drawing.Size(110, 20)
        Me.stbBillMode.TabIndex = 40
        '
        'stbVisitCategory
        '
        Me.stbVisitCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitCategory.CapitalizeFirstLetter = False
        Me.stbVisitCategory.Enabled = False
        Me.stbVisitCategory.EntryErrorMSG = ""
        Me.stbVisitCategory.Location = New System.Drawing.Point(737, 25)
        Me.stbVisitCategory.MaxLength = 60
        Me.stbVisitCategory.Name = "stbVisitCategory"
        Me.stbVisitCategory.RegularExpression = ""
        Me.stbVisitCategory.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitCategory.Size = New System.Drawing.Size(128, 20)
        Me.stbVisitCategory.TabIndex = 44
        '
        'lblBillMode
        '
        Me.lblBillMode.Location = New System.Drawing.Point(342, 171)
        Me.lblBillMode.Name = "lblBillMode"
        Me.lblBillMode.Size = New System.Drawing.Size(133, 20)
        Me.lblBillMode.TabIndex = 39
        Me.lblBillMode.Text = "Bill Mode"
        '
        'lblVisitCategory
        '
        Me.lblVisitCategory.Location = New System.Drawing.Point(598, 26)
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
        Me.stbAdmissionStatus.Location = New System.Drawing.Point(481, 129)
        Me.stbAdmissionStatus.MaxLength = 60
        Me.stbAdmissionStatus.Name = "stbAdmissionStatus"
        Me.stbAdmissionStatus.RegularExpression = ""
        Me.stbAdmissionStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbAdmissionStatus.Size = New System.Drawing.Size(110, 20)
        Me.stbAdmissionStatus.TabIndex = 36
        '
        'lblAdmissionStatus
        '
        Me.lblAdmissionStatus.Location = New System.Drawing.Point(342, 129)
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
        Me.stbAge.Location = New System.Drawing.Point(481, 108)
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
        Me.stbJoinDate.Location = New System.Drawing.Point(737, 4)
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
        Me.stbGender.Location = New System.Drawing.Point(481, 150)
        Me.stbGender.MaxLength = 60
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbGender.Size = New System.Drawing.Size(110, 20)
        Me.stbGender.TabIndex = 38
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(598, 4)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(133, 20)
        Me.lblJoinDate.TabIndex = 41
        Me.lblJoinDate.Text = "Join Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(342, 108)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(133, 20)
        Me.lblAge.TabIndex = 33
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(342, 150)
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
        Me.stbVisitNo.Location = New System.Drawing.Point(152, 149)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitNo.TabIndex = 22
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(11, 151)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(123, 20)
        Me.lblVisitNo.TabIndex = 21
        Me.lblVisitNo.Text = "Visit No"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        Me.stbBillCustomerName.Location = New System.Drawing.Point(737, 46)
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
        Me.lblBillCustomerName.Location = New System.Drawing.Point(598, 53)
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        Me.lblBillCustomerName.Size = New System.Drawing.Size(133, 20)
        Me.lblBillCustomerName.TabIndex = 45
        Me.lblBillCustomerName.Text = "To-Bill Customer"
        '
        'nbxCoPayValue
        '
        Me.nbxCoPayValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxCoPayValue.ControlCaption = "Co-Pay Value"
        Me.nbxCoPayValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.Standard
        Me.nbxCoPayValue.DataType = SyncSoft.Common.Win.Controls.Number.[Decimal]
        Me.nbxCoPayValue.DecimalPlaces = 2
        Me.nbxCoPayValue.Location = New System.Drawing.Point(737, 116)
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
        Me.lblCoPayValue.Location = New System.Drawing.Point(598, 117)
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
        Me.nbxCoPayPercent.Location = New System.Drawing.Point(737, 95)
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
        Me.lblCoPayPercent.Location = New System.Drawing.Point(598, 96)
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
        Me.stbCoPayType.Location = New System.Drawing.Point(737, 74)
        Me.stbCoPayType.MaxLength = 20
        Me.stbCoPayType.Name = "stbCoPayType"
        Me.stbCoPayType.RegularExpression = ""
        Me.stbCoPayType.Size = New System.Drawing.Size(128, 20)
        Me.stbCoPayType.TabIndex = 48
        '
        'lblCoPayType
        '
        Me.lblCoPayType.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblCoPayType.Location = New System.Drawing.Point(598, 74)
        Me.lblCoPayType.Name = "lblCoPayType"
        Me.lblCoPayType.Size = New System.Drawing.Size(133, 20)
        Me.lblCoPayType.TabIndex = 47
        Me.lblCoPayType.Text = "Co-Pay Type"
        '
        'frmIPDDentalReports
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
        Me.Controls.Add(Me.pnlRoundNo)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.stbUnitPrice)
        Me.Controls.Add(Me.lblUnitPrice)
        Me.Controls.Add(Me.cboDentalFullName)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.chkPrintDentalReportOnSaving)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblDentalFullName)
        Me.Controls.Add(Me.dtpReportDate)
        Me.Controls.Add(Me.lblReportDate)
        Me.Controls.Add(Me.stbReport)
        Me.Controls.Add(Me.lblReport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmIPDDentalReports"
        Me.Text = "IPD Dental Reports"
        Me.pnlAlerts.ResumeLayout(False)
        Me.pnlRoundNo.ResumeLayout(False)
        Me.pnlRoundNo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblDentalFullName As System.Windows.Forms.Label
    Friend WithEvents dtpReportDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblReportDate As System.Windows.Forms.Label
    Friend WithEvents stbReport As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReport As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents chkPrintDentalReportOnSaving As System.Windows.Forms.CheckBox
    Friend WithEvents cboDentalFullName As System.Windows.Forms.ComboBox
    Friend WithEvents stbUnitPrice As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblUnitPrice As System.Windows.Forms.Label
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnViewList As System.Windows.Forms.Button
    Friend WithEvents lblIPDAlerts As System.Windows.Forms.Label
    Friend WithEvents tmrIPDAlerts As System.Windows.Forms.Timer
    Friend WithEvents pnlRoundNo As System.Windows.Forms.Panel
    Friend WithEvents stbRoundNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbAdmissionNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents btnLoadPendingDental As System.Windows.Forms.Button
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
    Friend WithEvents nbxCoPayValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayValue As System.Windows.Forms.Label
    Friend WithEvents nbxCoPayPercent As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblCoPayPercent As System.Windows.Forms.Label
    Friend WithEvents stbCoPayType As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblCoPayType As System.Windows.Forms.Label

End Class