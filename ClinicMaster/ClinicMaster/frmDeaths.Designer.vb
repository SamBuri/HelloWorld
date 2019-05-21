<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeaths : Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Private Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(deafaultPatientNo As String)
        MyClass.New()
        Me.defaultPatientNo = deafaultPatientNo


    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDeaths))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbNotes = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.dtpDeathDate = New System.Windows.Forms.DateTimePicker()
        Me.stpDeathTime = New SyncSoft.Common.Win.Controls.SmartTimePicker()
        Me.stbOtherDeathCause = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbSecondaryDeathCause = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPrimaryDeathCause = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboStaffNo = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.lblDeathDate = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.fbnShowDiagnosis = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblDeathTime = New System.Windows.Forms.Label()
        Me.lblPrimaryDeathCause = New System.Windows.Forms.Label()
        Me.lblOtherDeathCause = New System.Windows.Forms.Label()
        Me.lblSecondaryDeathCause = New System.Windows.Forms.Label()
        Me.lblDoctorName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkPrintDeathForm = New System.Windows.Forms.CheckBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(16, 434)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 30
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = True
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(679, 429)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 35
        Me.btnDelete.Tag = "Deaths"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(16, 463)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 31
        Me.ebnSaveUpdate.Tag = "Deaths"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbNotes
        '
        Me.stbNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbNotes.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbNotes, "Notes")
        Me.stbNotes.EntryErrorMSG = ""
        Me.stbNotes.Location = New System.Drawing.Point(184, 338)
        Me.stbNotes.MaxLength = 200
        Me.stbNotes.Multiline = True
        Me.stbNotes.Name = "stbNotes"
        Me.stbNotes.RegularExpression = ""
        Me.stbNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbNotes.Size = New System.Drawing.Size(567, 46)
        Me.stbNotes.TabIndex = 27
        '
        'dtpDeathDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpDeathDate, "DeathDate")
        Me.dtpDeathDate.Location = New System.Drawing.Point(184, 82)
        Me.dtpDeathDate.Name = "dtpDeathDate"
        Me.dtpDeathDate.ShowCheckBox = True
        Me.dtpDeathDate.Size = New System.Drawing.Size(178, 20)
        Me.dtpDeathDate.TabIndex = 14
        '
        'stpDeathTime
        '
        Me.stpDeathTime.Checked = False
        Me.stpDeathTime.CustomFormat = "hh:mm tt"
        Me.ebnSaveUpdate.SetDataMember(Me.stpDeathTime, "TimeOfDeath")
        Me.stpDeathTime.Location = New System.Drawing.Point(184, 106)
        Me.stpDeathTime.Name = "stpDeathTime"
        Me.stpDeathTime.ShowCheckBox = True
        Me.stpDeathTime.ShowUpDown = True
        Me.stpDeathTime.Size = New System.Drawing.Size(90, 20)
        Me.stpDeathTime.TabIndex = 16
        Me.stpDeathTime.Value = New Date(2011, 9, 19, 13, 49, 25, 18)
        '
        'stbOtherDeathCause
        '
        Me.stbOtherDeathCause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbOtherDeathCause.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbOtherDeathCause, "OtherCauseOfDeath")
        Me.stbOtherDeathCause.EntryErrorMSG = ""
        Me.stbOtherDeathCause.Location = New System.Drawing.Point(186, 270)
        Me.stbOtherDeathCause.MaxLength = 200
        Me.stbOtherDeathCause.Multiline = True
        Me.stbOtherDeathCause.Name = "stbOtherDeathCause"
        Me.stbOtherDeathCause.RegularExpression = ""
        Me.stbOtherDeathCause.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbOtherDeathCause.Size = New System.Drawing.Size(567, 46)
        Me.stbOtherDeathCause.TabIndex = 24
        '
        'stbSecondaryDeathCause
        '
        Me.stbSecondaryDeathCause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSecondaryDeathCause.CapitalizeFirstLetter = True
        Me.ebnSaveUpdate.SetDataMember(Me.stbSecondaryDeathCause, "SecondaryCauseOfDeath")
        Me.stbSecondaryDeathCause.EntryErrorMSG = ""
        Me.stbSecondaryDeathCause.Location = New System.Drawing.Point(184, 201)
        Me.stbSecondaryDeathCause.MaxLength = 200
        Me.stbSecondaryDeathCause.Multiline = True
        Me.stbSecondaryDeathCause.Name = "stbSecondaryDeathCause"
        Me.stbSecondaryDeathCause.RegularExpression = ""
        Me.stbSecondaryDeathCause.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbSecondaryDeathCause.Size = New System.Drawing.Size(567, 46)
        Me.stbSecondaryDeathCause.TabIndex = 21
        '
        'stbPrimaryDeathCause
        '
        Me.stbPrimaryDeathCause.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPrimaryDeathCause.CapitalizeFirstLetter = True
        Me.stbPrimaryDeathCause.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.ebnSaveUpdate.SetDataMember(Me.stbPrimaryDeathCause, "PrimaryCauseOfDeath")
        Me.stbPrimaryDeathCause.EntryErrorMSG = ""
        Me.stbPrimaryDeathCause.Location = New System.Drawing.Point(184, 132)
        Me.stbPrimaryDeathCause.MaxLength = 200
        Me.stbPrimaryDeathCause.Multiline = True
        Me.stbPrimaryDeathCause.Name = "stbPrimaryDeathCause"
        Me.stbPrimaryDeathCause.RegularExpression = ""
        Me.stbPrimaryDeathCause.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbPrimaryDeathCause.Size = New System.Drawing.Size(567, 46)
        Me.stbPrimaryDeathCause.TabIndex = 18
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.FormattingEnabled = True
        Me.cboStaffNo.Location = New System.Drawing.Point(184, 389)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(268, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 29
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(679, 459)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 36
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblNotes
        '
        Me.lblNotes.Location = New System.Drawing.Point(15, 350)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(102, 20)
        Me.lblNotes.TabIndex = 25
        Me.lblNotes.Text = "Notes"
        '
        'lblDeathDate
        '
        Me.lblDeathDate.Location = New System.Drawing.Point(13, 82)
        Me.lblDeathDate.Name = "lblDeathDate"
        Me.lblDeathDate.Size = New System.Drawing.Size(102, 20)
        Me.lblDeathDate.TabIndex = 13
        Me.lblDeathDate.Text = "Death Date"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        Me.stbFullName.Enabled = False
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Location = New System.Drawing.Point(184, 33)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        Me.stbFullName.Size = New System.Drawing.Size(268, 20)
        Me.stbFullName.TabIndex = 4
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(184, 12)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(219, 20)
        Me.stbPatientNo.TabIndex = 1
        '
        'lblFullName
        '
        Me.lblFullName.Location = New System.Drawing.Point(15, 32)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(102, 20)
        Me.lblFullName.TabIndex = 3
        Me.lblFullName.Text = "Patient's Name"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(15, 10)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(102, 20)
        Me.lblPatientNo.TabIndex = 0
        Me.lblPatientNo.Text = "Patient's Number"
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        Me.stbGender.Enabled = False
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Location = New System.Drawing.Point(184, 54)
        Me.stbGender.MaxLength = 20
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        Me.stbGender.Size = New System.Drawing.Size(92, 20)
        Me.stbGender.TabIndex = 6
        '
        'lblGender
        '
        Me.lblGender.Location = New System.Drawing.Point(15, 54)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(102, 20)
        Me.lblGender.TabIndex = 5
        Me.lblGender.Text = "Gender"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        Me.stbAge.Enabled = False
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Location = New System.Drawing.Point(566, 8)
        Me.stbAge.MaxLength = 20
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        Me.stbAge.Size = New System.Drawing.Size(92, 20)
        Me.stbAge.TabIndex = 8
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(462, 7)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(102, 20)
        Me.lblAge.TabIndex = 7
        Me.lblAge.Text = "Age"
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.CapitalizeFirstLetter = False
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.EntryErrorMSG = ""
        Me.stbLastVisitDate.Location = New System.Drawing.Point(566, 50)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.RegularExpression = ""
        Me.stbLastVisitDate.Size = New System.Drawing.Size(178, 20)
        Me.stbLastVisitDate.TabIndex = 12
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(462, 50)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(102, 20)
        Me.lblLastVisitDate.TabIndex = 11
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        Me.stbJoinDate.Enabled = False
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Location = New System.Drawing.Point(566, 29)
        Me.stbJoinDate.MaxLength = 20
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        Me.stbJoinDate.Size = New System.Drawing.Size(178, 20)
        Me.stbJoinDate.TabIndex = 10
        '
        'lblJoinDate
        '
        Me.lblJoinDate.Location = New System.Drawing.Point(462, 29)
        Me.lblJoinDate.Name = "lblJoinDate"
        Me.lblJoinDate.Size = New System.Drawing.Size(102, 20)
        Me.lblJoinDate.TabIndex = 9
        Me.lblJoinDate.Text = "Join Date"
        '
        'btnLoad
        '
        Me.btnLoad.AccessibleDescription = ""
        Me.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoad.Location = New System.Drawing.Point(406, 8)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(46, 24)
        Me.btnLoad.TabIndex = 2
        Me.btnLoad.Tag = ""
        Me.btnLoad.Text = "&Load"
        '
        'fbnShowDiagnosis
        '
        Me.fbnShowDiagnosis.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnShowDiagnosis.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnShowDiagnosis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnShowDiagnosis.Location = New System.Drawing.Point(289, 459)
        Me.fbnShowDiagnosis.Name = "fbnShowDiagnosis"
        Me.fbnShowDiagnosis.Size = New System.Drawing.Size(114, 24)
        Me.fbnShowDiagnosis.TabIndex = 33
        Me.fbnShowDiagnosis.Text = "Previous Diagnosis"
        Me.fbnShowDiagnosis.UseVisualStyleBackColor = False
        '
        'lblDeathTime
        '
        Me.lblDeathTime.Location = New System.Drawing.Point(15, 106)
        Me.lblDeathTime.Name = "lblDeathTime"
        Me.lblDeathTime.Size = New System.Drawing.Size(102, 20)
        Me.lblDeathTime.TabIndex = 15
        Me.lblDeathTime.Text = "Death Time"
        '
        'lblPrimaryDeathCause
        '
        Me.lblPrimaryDeathCause.Location = New System.Drawing.Point(13, 133)
        Me.lblPrimaryDeathCause.Name = "lblPrimaryDeathCause"
        Me.lblPrimaryDeathCause.Size = New System.Drawing.Size(166, 38)
        Me.lblPrimaryDeathCause.TabIndex = 17
        Me.lblPrimaryDeathCause.Text = "Disease or condition directly leading to death (b)"
        '
        'lblOtherDeathCause
        '
        Me.lblOtherDeathCause.Location = New System.Drawing.Point(14, 267)
        Me.lblOtherDeathCause.Name = "lblOtherDeathCause"
        Me.lblOtherDeathCause.Size = New System.Drawing.Size(166, 63)
        Me.lblOtherDeathCause.TabIndex = 22
        Me.lblOtherDeathCause.Text = "Other significant conditions contributing to the death, but not related to the di" & _
    "sease or condition causing it."
        '
        'lblSecondaryDeathCause
        '
        Me.lblSecondaryDeathCause.Location = New System.Drawing.Point(13, 197)
        Me.lblSecondaryDeathCause.Name = "lblSecondaryDeathCause"
        Me.lblSecondaryDeathCause.Size = New System.Drawing.Size(166, 68)
        Me.lblSecondaryDeathCause.TabIndex = 19
        Me.lblSecondaryDeathCause.Text = "Antecedent causes " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Morbid conditions, if any, giving rise to the above cause, st" & _
    "ating the underlying condition last."
        '
        'lblDoctorName
        '
        Me.lblDoctorName.Location = New System.Drawing.Point(15, 394)
        Me.lblDoctorName.Name = "lblDoctorName"
        Me.lblDoctorName.Size = New System.Drawing.Size(102, 20)
        Me.lblDoctorName.TabIndex = 28
        Me.lblDoctorName.Text = "Doctor's Name"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(181, 181)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(201, 17)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "(a) due to (or as a consequence of)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(185, 250)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(201, 17)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "(b) due to (or as a consequence of)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(183, 319)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 17)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "(c)"
        '
        'chkPrintDeathForm
        '
        Me.chkPrintDeathForm.AutoSize = True
        Me.chkPrintDeathForm.Checked = True
        Me.chkPrintDeathForm.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkPrintDeathForm.Location = New System.Drawing.Point(110, 466)
        Me.chkPrintDeathForm.Name = "chkPrintDeathForm"
        Me.chkPrintDeathForm.Size = New System.Drawing.Size(105, 17)
        Me.chkPrintDeathForm.TabIndex = 32
        Me.chkPrintDeathForm.Text = "Print Death Form"
        Me.chkPrintDeathForm.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrint.Location = New System.Drawing.Point(601, 459)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(72, 24)
        Me.btnPrint.TabIndex = 34
        Me.btnPrint.Text = "&Print"
        '
        'frmDeaths
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(766, 495)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.chkPrintDeathForm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.stbPrimaryDeathCause)
        Me.Controls.Add(Me.stbSecondaryDeathCause)
        Me.Controls.Add(Me.stbOtherDeathCause)
        Me.Controls.Add(Me.lblSecondaryDeathCause)
        Me.Controls.Add(Me.lblOtherDeathCause)
        Me.Controls.Add(Me.lblPrimaryDeathCause)
        Me.Controls.Add(Me.stpDeathTime)
        Me.Controls.Add(Me.fbnShowDiagnosis)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblGender)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.stbLastVisitDate)
        Me.Controls.Add(Me.lblLastVisitDate)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.dtpDeathDate)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblFullName)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.stbNotes)
        Me.Controls.Add(Me.lblDoctorName)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.lblDeathTime)
        Me.Controls.Add(Me.lblDeathDate)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmDeaths"
        Me.Text = "Deaths"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbNotes As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents lblDeathDate As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFullName As System.Windows.Forms.Label
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents dtpDeathDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblGender As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents stbLastVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents fbnShowDiagnosis As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblDeathTime As System.Windows.Forms.Label
    Friend WithEvents stpDeathTime As SyncSoft.Common.Win.Controls.SmartTimePicker
    Friend WithEvents lblPrimaryDeathCause As System.Windows.Forms.Label
    Friend WithEvents lblOtherDeathCause As System.Windows.Forms.Label
    Friend WithEvents lblSecondaryDeathCause As System.Windows.Forms.Label
    Friend WithEvents stbOtherDeathCause As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbSecondaryDeathCause As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPrimaryDeathCause As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblDoctorName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkPrintDeathForm As CheckBox
    Friend WithEvents btnPrint As Button
End Class
