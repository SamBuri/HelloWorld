<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmARTStopped
    Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmARTStopped))
        Me.btnSearch = New System.Windows.Forms.Button
        Me.btnDelete = New SyncSoft.Common.Win.Controls.FlatButton
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton
        Me.dtpStopDate = New System.Windows.Forms.DateTimePicker
        Me.cboStaffNo = New System.Windows.Forms.ComboBox
        Me.clbARTStopReasons = New System.Windows.Forms.CheckedListBox
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox
        Me.lblName = New System.Windows.Forms.Label
        Me.lblVisitNo = New System.Windows.Forms.Label
        Me.lblPatientNo = New System.Windows.Forms.Label
        Me.lblStopDate = New System.Windows.Forms.Label
        Me.lblStaff = New System.Windows.Forms.Label
        Me.lblCombination = New System.Windows.Forms.Label
        Me.stbCombination = New SyncSoft.Common.Win.Controls.SmartTextBox
        Me.stbStartDate = New SyncSoft.Common.Win.Controls.SmartTextBox
        Me.lblStartDate = New System.Windows.Forms.Label
        Me.btnFindVisitNo = New System.Windows.Forms.Button
        Me.lblARTStopReasons = New System.Windows.Forms.Label
        Me.stbLastVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox
        Me.lblLastVisitDate = New System.Windows.Forms.Label
        Me.stbVisitDate = New SyncSoft.Common.Win.Controls.SmartTextBox
        Me.lblVisitDate = New System.Windows.Forms.Label
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Location = New System.Drawing.Point(20, 284)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(77, 23)
        Me.btnSearch.TabIndex = 22
        Me.btnSearch.Text = "S&earch"
        Me.btnSearch.UseVisualStyleBackColor = False
        Me.btnSearch.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(306, 283)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(72, 24)
        Me.btnDelete.TabIndex = 23
        Me.btnDelete.Tag = "ARTStopped"
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        Me.btnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.ButtonText = SyncSoft.Common.Win.Controls.ButtonCaption.Save
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(20, 313)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 24
        Me.ebnSaveUpdate.Tag = "ARTStopped"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'dtpStopDate
        '
        Me.ebnSaveUpdate.SetDataMember(Me.dtpStopDate, "StopDate")
        Me.dtpStopDate.Location = New System.Drawing.Point(181, 152)
        Me.dtpStopDate.Name = "dtpStopDate"
        Me.dtpStopDate.ShowCheckBox = True
        Me.dtpStopDate.Size = New System.Drawing.Size(197, 20)
        Me.dtpStopDate.TabIndex = 17
        '
        'cboStaffNo
        '
        Me.cboStaffNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboStaffNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ebnSaveUpdate.SetDataMember(Me.cboStaffNo, "StaffFullName")
        Me.cboStaffNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStaffNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboStaffNo.FormattingEnabled = True
        Me.cboStaffNo.Location = New System.Drawing.Point(181, 251)
        Me.cboStaffNo.Name = "cboStaffNo"
        Me.cboStaffNo.Size = New System.Drawing.Size(197, 21)
        Me.cboStaffNo.Sorted = True
        Me.cboStaffNo.TabIndex = 21
        '
        'clbARTStopReasons
        '
        Me.clbARTStopReasons.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ebnSaveUpdate.SetDataMember(Me.clbARTStopReasons, "ARTStopReasons")
        Me.clbARTStopReasons.FormattingEnabled = True
        Me.clbARTStopReasons.Location = New System.Drawing.Point(181, 174)
        Me.clbARTStopReasons.Name = "clbARTStopReasons"
        Me.clbARTStopReasons.Size = New System.Drawing.Size(197, 75)
        Me.clbARTStopReasons.TabIndex = 19
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(306, 313)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 25
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.Location = New System.Drawing.Point(181, 5)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.Size = New System.Drawing.Size(147, 20)
        Me.stbVisitNo.TabIndex = 2
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.Enabled = False
        Me.stbFullName.Location = New System.Drawing.Point(181, 89)
        Me.stbFullName.MaxLength = 41
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.Size = New System.Drawing.Size(197, 20)
        Me.stbFullName.TabIndex = 11
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.Enabled = False
        Me.stbPatientNo.Location = New System.Drawing.Point(181, 68)
        Me.stbPatientNo.MaxLength = 20
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.Size = New System.Drawing.Size(197, 20)
        Me.stbPatientNo.TabIndex = 9
        '
        'lblName
        '
        Me.lblName.Location = New System.Drawing.Point(17, 90)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(143, 21)
        Me.lblName.TabIndex = 10
        Me.lblName.Text = "Patient's Name"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(17, 5)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(125, 21)
        Me.lblVisitNo.TabIndex = 0
        Me.lblVisitNo.Text = "Visit Number"
        '
        'lblPatientNo
        '
        Me.lblPatientNo.Location = New System.Drawing.Point(17, 69)
        Me.lblPatientNo.Name = "lblPatientNo"
        Me.lblPatientNo.Size = New System.Drawing.Size(143, 21)
        Me.lblPatientNo.TabIndex = 8
        Me.lblPatientNo.Text = "Patient's Number"
        '
        'lblStopDate
        '
        Me.lblStopDate.Location = New System.Drawing.Point(17, 153)
        Me.lblStopDate.Name = "lblStopDate"
        Me.lblStopDate.Size = New System.Drawing.Size(143, 21)
        Me.lblStopDate.TabIndex = 16
        Me.lblStopDate.Text = "Stop Date"
        '
        'lblStaff
        '
        Me.lblStaff.Location = New System.Drawing.Point(17, 251)
        Me.lblStaff.Name = "lblStaff"
        Me.lblStaff.Size = New System.Drawing.Size(143, 21)
        Me.lblStaff.TabIndex = 20
        Me.lblStaff.Text = "Doctor (Staff)"
        '
        'lblCombination
        '
        Me.lblCombination.Location = New System.Drawing.Point(17, 111)
        Me.lblCombination.Name = "lblCombination"
        Me.lblCombination.Size = New System.Drawing.Size(143, 21)
        Me.lblCombination.TabIndex = 12
        Me.lblCombination.Text = "Combination"
        '
        'stbCombination
        '
        Me.stbCombination.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbCombination.Enabled = False
        Me.stbCombination.Location = New System.Drawing.Point(181, 110)
        Me.stbCombination.MaxLength = 30
        Me.stbCombination.Name = "stbCombination"
        Me.stbCombination.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbCombination.Size = New System.Drawing.Size(197, 20)
        Me.stbCombination.TabIndex = 13
        '
        'stbStartDate
        '
        Me.stbStartDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbStartDate.Enabled = False
        Me.stbStartDate.Location = New System.Drawing.Point(181, 131)
        Me.stbStartDate.MaxLength = 60
        Me.stbStartDate.Name = "stbStartDate"
        Me.stbStartDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbStartDate.Size = New System.Drawing.Size(197, 20)
        Me.stbStartDate.TabIndex = 15
        '
        'lblStartDate
        '
        Me.lblStartDate.Location = New System.Drawing.Point(17, 132)
        Me.lblStartDate.Name = "lblStartDate"
        Me.lblStartDate.Size = New System.Drawing.Size(143, 21)
        Me.lblStartDate.TabIndex = 14
        Me.lblStartDate.Text = "Start Date"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(148, 5)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 1
        '
        'lblARTStopReasons
        '
        Me.lblARTStopReasons.Location = New System.Drawing.Point(17, 199)
        Me.lblARTStopReasons.Name = "lblARTStopReasons"
        Me.lblARTStopReasons.Size = New System.Drawing.Size(143, 21)
        Me.lblARTStopReasons.TabIndex = 18
        Me.lblARTStopReasons.Text = "ART Stop Reason(s)"
        '
        'stbLastVisitDate
        '
        Me.stbLastVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbLastVisitDate.Enabled = False
        Me.stbLastVisitDate.Location = New System.Drawing.Point(181, 47)
        Me.stbLastVisitDate.MaxLength = 20
        Me.stbLastVisitDate.Name = "stbLastVisitDate"
        Me.stbLastVisitDate.Size = New System.Drawing.Size(197, 20)
        Me.stbLastVisitDate.TabIndex = 7
        '
        'lblLastVisitDate
        '
        Me.lblLastVisitDate.Location = New System.Drawing.Point(17, 47)
        Me.lblLastVisitDate.Name = "lblLastVisitDate"
        Me.lblLastVisitDate.Size = New System.Drawing.Size(143, 21)
        Me.lblLastVisitDate.TabIndex = 6
        Me.lblLastVisitDate.Text = "Last Visit Date"
        '
        'stbVisitDate
        '
        Me.stbVisitDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitDate.Enabled = False
        Me.stbVisitDate.Location = New System.Drawing.Point(181, 26)
        Me.stbVisitDate.MaxLength = 60
        Me.stbVisitDate.Name = "stbVisitDate"
        Me.stbVisitDate.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbVisitDate.Size = New System.Drawing.Size(197, 20)
        Me.stbVisitDate.TabIndex = 5
        '
        'lblVisitDate
        '
        Me.lblVisitDate.Location = New System.Drawing.Point(17, 26)
        Me.lblVisitDate.Name = "lblVisitDate"
        Me.lblVisitDate.Size = New System.Drawing.Size(143, 21)
        Me.lblVisitDate.TabIndex = 4
        Me.lblVisitDate.Text = "Visit Date"
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(334, 1)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 3
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'frmARTStopped
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(401, 353)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.stbVisitDate)
        Me.Controls.Add(Me.lblVisitDate)
        Me.Controls.Add(Me.stbLastVisitDate)
        Me.Controls.Add(Me.lblLastVisitDate)
        Me.Controls.Add(Me.clbARTStopReasons)
        Me.Controls.Add(Me.lblARTStopReasons)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.stbStartDate)
        Me.Controls.Add(Me.lblStartDate)
        Me.Controls.Add(Me.lblCombination)
        Me.Controls.Add(Me.stbCombination)
        Me.Controls.Add(Me.cboStaffNo)
        Me.Controls.Add(Me.lblStaff)
        Me.Controls.Add(Me.dtpStopDate)
        Me.Controls.Add(Me.lblStopDate)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.lblPatientNo)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmARTStopped"
        Me.Text = "ART Stopped"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents lblPatientNo As System.Windows.Forms.Label
    Friend WithEvents dtpStopDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblStopDate As System.Windows.Forms.Label
    Friend WithEvents cboStaffNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblStaff As System.Windows.Forms.Label
    Friend WithEvents lblCombination As System.Windows.Forms.Label
    Friend WithEvents stbCombination As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbStartDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents clbARTStopReasons As System.Windows.Forms.CheckedListBox
    Friend WithEvents lblARTStopReasons As System.Windows.Forms.Label
    Friend WithEvents stbLastVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblLastVisitDate As System.Windows.Forms.Label
    Friend WithEvents stbVisitDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitDate As System.Windows.Forms.Label
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
End Class
