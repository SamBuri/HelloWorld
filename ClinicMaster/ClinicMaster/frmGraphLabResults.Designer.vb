<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGraphLabResults
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGraphLabResults))
        Me.btnDrawChart = New System.Windows.Forms.Button()
        Me.lblVerticalInterval = New System.Windows.Forms.Label()
        Me.lblVerticalStartValue = New System.Windows.Forms.Label()
        Me.spbGraphLabResults = New SyncSoft.Common.Win.Controls.SmartPictureBox()
        Me.nbxVerticalInterval = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.nbxVerticalStartValue = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtTotalVisits = New System.Windows.Forms.TextBox()
        Me.lblTotalVisits = New System.Windows.Forms.Label()
        Me.txtLastVisitDate = New System.Windows.Forms.TextBox()
        Me.lblLastVisitDate = New System.Windows.Forms.Label()
        Me.txtAge = New System.Windows.Forms.TextBox()
        Me.txtFirstVisitDate = New System.Windows.Forms.TextBox()
        Me.txtGender = New System.Windows.Forms.TextBox()
        Me.lblFirstVisitDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.txtFullName = New System.Windows.Forms.TextBox()
        Me.txtPatientNo = New System.Windows.Forms.TextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblPatientNo = New System.Windows.Forms.Label()
        Me.grpPeriod = New System.Windows.Forms.GroupBox()
        Me.cboLabSubTest = New System.Windows.Forms.ComboBox()
        Me.lblLabSubTest = New System.Windows.Forms.Label()
        Me.cboLabTest = New System.Windows.Forms.ComboBox()
        Me.lblLabTest = New System.Windows.Forms.Label()
        Me.fbnResultsLoad = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.lblEndDate = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.lblStartDate = New System.Windows.Forms.Label()
        CType(Me.spbGraphLabResults, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpPeriod.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDrawChart
        '
        Me.btnDrawChart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDrawChart.Location = New System.Drawing.Point(515, 41)
        Me.btnDrawChart.Name = "btnDrawChart"
        Me.btnDrawChart.Size = New System.Drawing.Size(109, 24)
        Me.btnDrawChart.TabIndex = 4
        Me.btnDrawChart.Text = "Draw Chart"
        Me.btnDrawChart.UseVisualStyleBackColor = True
        '
        'lblVerticalInterval
        '
        Me.lblVerticalInterval.Location = New System.Drawing.Point(139, 44)
        Me.lblVerticalInterval.Name = "lblVerticalInterval"
        Me.lblVerticalInterval.Size = New System.Drawing.Size(112, 19)
        Me.lblVerticalInterval.TabIndex = 0
        Me.lblVerticalInterval.Text = "Vertical Interval"
        '
        'lblVerticalStartValue
        '
        Me.lblVerticalStartValue.Location = New System.Drawing.Point(320, 44)
        Me.lblVerticalStartValue.Name = "lblVerticalStartValue"
        Me.lblVerticalStartValue.Size = New System.Drawing.Size(105, 19)
        Me.lblVerticalStartValue.TabIndex = 2
        Me.lblVerticalStartValue.Text = "Vertical Start Value"
        '
        'spbGraphLabResults
        '
        Me.spbGraphLabResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spbGraphLabResults.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.spbGraphLabResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.spbGraphLabResults.ImageSizeLimit = CType(200000, Long)
        Me.spbGraphLabResults.Location = New System.Drawing.Point(12, 130)
        Me.spbGraphLabResults.Name = "spbGraphLabResults"
        Me.spbGraphLabResults.ReadOnly = False
        Me.spbGraphLabResults.Size = New System.Drawing.Size(955, 347)
        Me.spbGraphLabResults.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.spbGraphLabResults.TabIndex = 42
        Me.spbGraphLabResults.TabStop = False
        '
        'nbxVerticalInterval
        '
        Me.nbxVerticalInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxVerticalInterval.ControlCaption = "Vertical Interval"
        Me.nbxVerticalInterval.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.General
        Me.nbxVerticalInterval.DataType = SyncSoft.Common.Win.Controls.Number.[Integer]
        Me.nbxVerticalInterval.DecimalPlaces = -1
        Me.nbxVerticalInterval.Location = New System.Drawing.Point(257, 42)
        Me.nbxVerticalInterval.MaxValue = 0.0R
        Me.nbxVerticalInterval.MinValue = 0.0R
        Me.nbxVerticalInterval.MustEnterNumeric = True
        Me.nbxVerticalInterval.Name = "nbxVerticalInterval"
        Me.nbxVerticalInterval.Size = New System.Drawing.Size(57, 20)
        Me.nbxVerticalInterval.TabIndex = 1
        Me.nbxVerticalInterval.Text = "10"
        Me.nbxVerticalInterval.Value = "10"
        Me.nbxVerticalInterval.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        '
        'nbxVerticalStartValue
        '
        Me.nbxVerticalStartValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxVerticalStartValue.ControlCaption = "Vertical Start Value"
        Me.nbxVerticalStartValue.DataFormat = SyncSoft.Common.Win.Controls.DisplayFormat.General
        Me.nbxVerticalStartValue.DataType = SyncSoft.Common.Win.Controls.Number.[Integer]
        Me.nbxVerticalStartValue.DecimalPlaces = -1
        Me.nbxVerticalStartValue.Location = New System.Drawing.Point(431, 42)
        Me.nbxVerticalStartValue.MaxValue = 0.0R
        Me.nbxVerticalStartValue.MinValue = 0.0R
        Me.nbxVerticalStartValue.MustEnterNumeric = True
        Me.nbxVerticalStartValue.Name = "nbxVerticalStartValue"
        Me.nbxVerticalStartValue.Size = New System.Drawing.Size(57, 20)
        Me.nbxVerticalStartValue.TabIndex = 3
        Me.nbxVerticalStartValue.Text = "100"
        Me.nbxVerticalStartValue.Value = "100"
        Me.nbxVerticalStartValue.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Location = New System.Drawing.Point(864, 483)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(103, 24)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'txtTotalVisits
        '
        Me.txtTotalVisits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalVisits.Enabled = False
        Me.txtTotalVisits.Location = New System.Drawing.Point(724, 4)
        Me.txtTotalVisits.MaxLength = 60
        Me.txtTotalVisits.Name = "txtTotalVisits"
        Me.txtTotalVisits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTotalVisits.Size = New System.Drawing.Size(101, 20)
        Me.txtTotalVisits.TabIndex = 56
        '
        'lblTotalVisits
        '
        Me.lblTotalVisits.Location = New System.Drawing.Point(627, 5)
        Me.lblTotalVisits.Name = "lblTotalVisits"
        Me.lblTotalVisits.Size = New System.Drawing.Size(91, 20)
        Me.lblTotalVisits.TabIndex = 55
        Me.lblTotalVisits.Text = "Total Visits"
        '
        'txtLastVisitDate
        '
        Me.txtLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLastVisitDate.Enabled = False
        Me.txtLastVisitDate.Location = New System.Drawing.Point(520, 26)
        Me.txtLastVisitDate.MaxLength = 20
        Me.txtLastVisitDate.Name = "txtLastVisitDate"
        Me.txtLastVisitDate.Size = New System.Drawing.Size(101, 20)
        Me.txtLastVisitDate.TabIndex = 54
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(423, 28)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(91, 20)
        Me.lblLastVisitDate.TabIndex = 53
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'txtAge
        '
        Me.txtAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAge.Enabled = False
        Me.txtAge.Location = New System.Drawing.Point(332, 6)
        Me.txtAge.MaxLength = 60
        Me.txtAge.Name = "txtAge"
        Me.txtAge.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAge.Size = New System.Drawing.Size(85, 20)
        Me.txtAge.TabIndex = 48
        '
        'txtFirstVisitDate
        '
        Me.txtFirstVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFirstVisitDate.Enabled = False
        Me.txtFirstVisitDate.Location = New System.Drawing.Point(520, 4)
        Me.txtFirstVisitDate.MaxLength = 60
        Me.txtFirstVisitDate.Name = "txtFirstVisitDate"
        Me.txtFirstVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtFirstVisitDate.Size = New System.Drawing.Size(101, 20)
        Me.txtFirstVisitDate.TabIndex = 52
        '
        'txtGender
        '
        Me.txtGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGender.Enabled = False
        Me.txtGender.Location = New System.Drawing.Point(332, 28)
        Me.txtGender.MaxLength = 60
        Me.txtGender.Name = "txtGender"
        Me.txtGender.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtGender.Size = New System.Drawing.Size(85, 20)
        Me.txtGender.TabIndex = 50
        '
        'lblFirstVisitDate
        '
        Me.lblFirstVisitDate.Location = New System.Drawing.Point(423, 6)
        Me.lblFirstVisitDate.Name = "lblFirstVisitDate"
        Me.lblFirstVisitDate.Size = New System.Drawing.Size(91, 20)
        Me.lblFirstVisitDate.TabIndex = 51
        Me.lblFirstVisitDate.Text = "First Visit Date"
        '
        'lblAge
        '
        Me.lblAge.Location = New System.Drawing.Point(260, 6)
        Me.lblAge.Name = "lblAge"
        Me.lblAge.Size = New System.Drawing.Size(66, 20)
        Me.lblAge.TabIndex = 47
        Me.lblAge.Text = "Age"
        '
        'lblGenderID
        '
        Me.lblGenderID.Location = New System.Drawing.Point(260, 28)
        Me.lblGenderID.Name = "lblGenderID"
        Me.lblGenderID.Size = New System.Drawing.Size(66, 20)
        Me.lblGenderID.TabIndex = 49
        Me.lblGenderID.Text = "Gender"
        '
        'txtFullName
        '
        Me.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFullName.Enabled = False
        Me.txtFullName.Location = New System.Drawing.Point(119, 29)
        Me.txtFullName.MaxLength = 41
        Me.txtFullName.Name = "txtFullName"
        Me.txtFullName.Size = New System.Drawing.Size(136, 20)
        Me.txtFullName.TabIndex = 46
        '
        'txtPatientNo
        '
        Me.txtPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPatientNo.Location = New System.Drawing.Point(119, 7)
        Me.txtPatientNo.MaxLength = 20
        Me.txtPatientNo.Name = "txtPatientNo"
        Me.txtPatientNo.Size = New System.Drawing.Size(136, 20)
        Me.txtPatientNo.TabIndex = 44
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(6, 31)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(107, 20)
        Me.lblName.TabIndex = 45
        Me.lblName.Text = "Patient's Name"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(6, 7)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(107, 20)
        Me.lblPatientNo.TabIndex = 43
        Me.lblPatientNo.Text = "Patient's Number"
        '
        'grpPeriod
        '
        Me.grpPeriod.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPeriod.Controls.Add(Me.cboLabSubTest)
        Me.grpPeriod.Controls.Add(Me.lblLabSubTest)
        Me.grpPeriod.Controls.Add(Me.cboLabTest)
        Me.grpPeriod.Controls.Add(Me.lblLabTest)
        Me.grpPeriod.Controls.Add(Me.fbnResultsLoad)
        Me.grpPeriod.Controls.Add(Me.dtpEndDate)
        Me.grpPeriod.Controls.Add(Me.lblEndDate)
        Me.grpPeriod.Controls.Add(Me.dtpStartDate)
        Me.grpPeriod.Controls.Add(Me.lblStartDate)
        Me.grpPeriod.Controls.Add(Me.lblVerticalInterval)
        Me.grpPeriod.Controls.Add(Me.btnDrawChart)
        Me.grpPeriod.Controls.Add(Me.lblVerticalStartValue)
        Me.grpPeriod.Controls.Add(Me.nbxVerticalInterval)
        Me.grpPeriod.Controls.Add(Me.nbxVerticalStartValue)
        Me.grpPeriod.Location = New System.Drawing.Point(4, 53)
        Me.grpPeriod.Name = "grpPeriod"
        Me.grpPeriod.Size = New System.Drawing.Size(963, 71)
        Me.grpPeriod.TabIndex = 57
        Me.grpPeriod.TabStop = False
        Me.grpPeriod.Text = "Period"
        '
        'cboLabSubTest
        '
        Me.cboLabSubTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLabSubTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLabSubTest.Location = New System.Drawing.Point(346, 13)
        Me.cboLabSubTest.Name = "cboLabSubTest"
        Me.cboLabSubTest.Size = New System.Drawing.Size(142, 21)
        Me.cboLabSubTest.TabIndex = 46
        '
        'lblLabSubTest
        '
        Me.lblLabSubTest.Location = New System.Drawing.Point(259, 14)
        Me.lblLabSubTest.Name = "lblLabSubTest"
        Me.lblLabSubTest.Size = New System.Drawing.Size(81, 20)
        Me.lblLabSubTest.TabIndex = 45
        Me.lblLabSubTest.Text = "Lab Sub Test"
        '
        'cboLabTest
        '
        Me.cboLabTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboLabTest.DropDownWidth = 214
        Me.cboLabTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboLabTest.Location = New System.Drawing.Point(85, 13)
        Me.cboLabTest.Name = "cboLabTest"
        Me.cboLabTest.Size = New System.Drawing.Size(136, 21)
        Me.cboLabTest.TabIndex = 42
        '
        'lblLabTest
        '
        Me.lblLabTest.Location = New System.Drawing.Point(10, 14)
        Me.lblLabTest.Name = "lblLabTest"
        Me.lblLabTest.Size = New System.Drawing.Size(66, 20)
        Me.lblLabTest.TabIndex = 41
        Me.lblLabTest.Text = "Lab Test"
        '
        'fbnResultsLoad
        '
        Me.fbnResultsLoad.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnResultsLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnResultsLoad.Location = New System.Drawing.Point(13, 39)
        Me.fbnResultsLoad.Name = "fbnResultsLoad"
        Me.fbnResultsLoad.Size = New System.Drawing.Size(101, 22)
        Me.fbnResultsLoad.TabIndex = 33
        Me.fbnResultsLoad.Text = "Load..."
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Checked = False
        Me.dtpEndDate.Location = New System.Drawing.Point(809, 15)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.ShowCheckBox = True
        Me.dtpEndDate.Size = New System.Drawing.Size(140, 20)
        Me.dtpEndDate.TabIndex = 3
        '
        'lblEndDate
        '
        Me.lblEndDate.Location = New System.Drawing.Point(742, 15)
        Me.lblEndDate.Name = "lblEndDate"
        Me.lblEndDate.Size = New System.Drawing.Size(61, 20)
        Me.lblEndDate.TabIndex = 2
        Me.lblEndDate.Text = "End Date"
        Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Checked = False
        Me.dtpStartDate.Location = New System.Drawing.Point(600, 15)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.ShowCheckBox = True
        Me.dtpStartDate.Size = New System.Drawing.Size(136, 20)
        Me.dtpStartDate.TabIndex = 1
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(518, 15)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(76, 20)
        Me.lblStartDate.TabIndex = 0
        Me.lblStartDate.Text = "Start Date"
        Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmGraphLabResults
        '
        Me.AcceptButton = Me.fbnResultsLoad
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(980, 519)
        Me.Controls.Add(Me.grpPeriod)
        Me.Controls.Add(Me.txtTotalVisits)
        Me.Controls.Add(Me.lblTotalVisits)
        Me.Controls.Add(Me.txtLastVisitDate)
        Me.Controls.Add(Me.lblLastVisitDate)
        Me.Controls.Add(Me.txtAge)
        Me.Controls.Add(Me.txtFirstVisitDate)
        Me.Controls.Add(Me.txtGender)
        Me.Controls.Add(Me.lblFirstVisitDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.txtFullName)
        Me.Controls.Add(Me.txtPatientNo)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.spbGraphLabResults)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmGraphLabResults"
        Me.Text = "Graph Lab Results"
        CType(Me.spbGraphLabResults, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpPeriod.ResumeLayout(False)
        Me.grpPeriod.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDrawChart As System.Windows.Forms.Button
    Friend WithEvents lblVerticalInterval As System.Windows.Forms.Label
    Friend WithEvents lblVerticalStartValue As System.Windows.Forms.Label
    Protected WithEvents spbGraphLabResults As SyncSoft.Common.Win.Controls.SmartPictureBox
    Friend WithEvents nbxVerticalInterval As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents nbxVerticalStartValue As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents txtTotalVisits As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalVisits As System.Windows.Forms.Label
    Friend WithEvents txtLastVisitDate As System.Windows.Forms.TextBox
    Friend WithEvents lblLastVisitDate As System.Windows.Forms.Label
    Friend WithEvents txtAge As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstVisitDate As System.Windows.Forms.TextBox
    Friend WithEvents txtGender As System.Windows.Forms.TextBox
    Friend WithEvents lblFirstVisitDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents txtFullName As System.Windows.Forms.TextBox
    Friend WithEvents txtPatientNo As System.Windows.Forms.TextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents grpPeriod As System.Windows.Forms.GroupBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents fbnResultsLoad As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboLabTest As System.Windows.Forms.ComboBox
    Friend WithEvents lblLabTest As System.Windows.Forms.Label
    Friend WithEvents cboLabSubTest As System.Windows.Forms.ComboBox
    Friend WithEvents lblLabSubTest As System.Windows.Forms.Label
End Class
