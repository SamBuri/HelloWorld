
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAntenatal : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAntenatal))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboInfection = New System.Windows.Forms.ComboBox()
        Me.stbInfectionDetails = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboAccidentDuringPregnancy = New System.Windows.Forms.ComboBox()
        Me.stbDetailsOfAccident = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboUseOfDrugsOrPrescription = New System.Windows.Forms.ComboBox()
        Me.stbDrugDetails = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboSmoking = New System.Windows.Forms.ComboBox()
        Me.cboChronicIllness = New System.Windows.Forms.ComboBox()
        Me.stbDetailsOfIllness = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblInfection = New System.Windows.Forms.Label()
        Me.lblInfectionDetails = New System.Windows.Forms.Label()
        Me.lblAccidentDuringPregnancy = New System.Windows.Forms.Label()
        Me.lblDetailsOfAccident = New System.Windows.Forms.Label()
        Me.lblUseOfDrugsOrPrescription = New System.Windows.Forms.Label()
        Me.lblDrugDetails = New System.Windows.Forms.Label()
        Me.lblSmoking = New System.Windows.Forms.Label()
        Me.lblChronicIllness = New System.Windows.Forms.Label()
        Me.lblDetailsOfIllness = New System.Windows.Forms.Label()
        Me.btnLoadPatients = New System.Windows.Forms.Button()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.SuspendLayout
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 272)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = true
        Me.fbnSearch.Visible = false
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(316, 272)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "Antenatal"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = false
        Me.fbnDelete.Visible = false
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 299)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "Antenatal"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = false
        '
        'cboInfection
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboInfection, "Infection")
        Me.cboInfection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboInfection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboInfection.Location = New System.Drawing.Point(218, 35)
        Me.cboInfection.Name = "cboInfection"
        Me.cboInfection.Size = New System.Drawing.Size(170, 21)
        Me.cboInfection.TabIndex = 6
        '
        'stbInfectionDetails
        '
        Me.stbInfectionDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInfectionDetails.CapitalizeFirstLetter = false
        Me.ebnSaveUpdate.SetDataMember(Me.stbInfectionDetails, "InfectionDetails")
        Me.stbInfectionDetails.EntryErrorMSG = ""
        Me.stbInfectionDetails.Location = New System.Drawing.Point(218, 58)
        Me.stbInfectionDetails.Name = "stbInfectionDetails"
        Me.stbInfectionDetails.RegularExpression = ""
        Me.stbInfectionDetails.Size = New System.Drawing.Size(170, 20)
        Me.stbInfectionDetails.TabIndex = 8
        '
        'cboAccidentDuringPregnancy
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboAccidentDuringPregnancy, "AccidentDuringPregnancy")
        Me.cboAccidentDuringPregnancy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccidentDuringPregnancy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccidentDuringPregnancy.Location = New System.Drawing.Point(218, 81)
        Me.cboAccidentDuringPregnancy.Name = "cboAccidentDuringPregnancy"
        Me.cboAccidentDuringPregnancy.Size = New System.Drawing.Size(170, 21)
        Me.cboAccidentDuringPregnancy.TabIndex = 10
        '
        'stbDetailsOfAccident
        '
        Me.stbDetailsOfAccident.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDetailsOfAccident.CapitalizeFirstLetter = false
        Me.ebnSaveUpdate.SetDataMember(Me.stbDetailsOfAccident, "DetailsOfAccident")
        Me.stbDetailsOfAccident.EntryErrorMSG = ""
        Me.stbDetailsOfAccident.Location = New System.Drawing.Point(218, 104)
        Me.stbDetailsOfAccident.Name = "stbDetailsOfAccident"
        Me.stbDetailsOfAccident.RegularExpression = ""
        Me.stbDetailsOfAccident.Size = New System.Drawing.Size(170, 20)
        Me.stbDetailsOfAccident.TabIndex = 12
        '
        'cboUseOfDrugsOrPrescription
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboUseOfDrugsOrPrescription, "UseOfDrugsOrPrescription")
        Me.cboUseOfDrugsOrPrescription.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUseOfDrugsOrPrescription.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboUseOfDrugsOrPrescription.Location = New System.Drawing.Point(218, 127)
        Me.cboUseOfDrugsOrPrescription.Name = "cboUseOfDrugsOrPrescription"
        Me.cboUseOfDrugsOrPrescription.Size = New System.Drawing.Size(170, 21)
        Me.cboUseOfDrugsOrPrescription.TabIndex = 14
        '
        'stbDrugDetails
        '
        Me.stbDrugDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDrugDetails.CapitalizeFirstLetter = false
        Me.ebnSaveUpdate.SetDataMember(Me.stbDrugDetails, "DrugDetails")
        Me.stbDrugDetails.EntryErrorMSG = ""
        Me.stbDrugDetails.Location = New System.Drawing.Point(218, 150)
        Me.stbDrugDetails.Name = "stbDrugDetails"
        Me.stbDrugDetails.RegularExpression = ""
        Me.stbDrugDetails.Size = New System.Drawing.Size(170, 20)
        Me.stbDrugDetails.TabIndex = 16
        '
        'cboSmoking
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboSmoking, "Smoking")
        Me.cboSmoking.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSmoking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboSmoking.Location = New System.Drawing.Point(218, 173)
        Me.cboSmoking.Name = "cboSmoking"
        Me.cboSmoking.Size = New System.Drawing.Size(170, 21)
        Me.cboSmoking.TabIndex = 18
        '
        'cboChronicIllness
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboChronicIllness, "ChronicIllness")
        Me.cboChronicIllness.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboChronicIllness.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboChronicIllness.Location = New System.Drawing.Point(218, 196)
        Me.cboChronicIllness.Name = "cboChronicIllness"
        Me.cboChronicIllness.Size = New System.Drawing.Size(170, 21)
        Me.cboChronicIllness.TabIndex = 20
        '
        'stbDetailsOfIllness
        '
        Me.stbDetailsOfIllness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDetailsOfIllness.CapitalizeFirstLetter = false
        Me.ebnSaveUpdate.SetDataMember(Me.stbDetailsOfIllness, "DetailsOfIllness")
        Me.stbDetailsOfIllness.EntryErrorMSG = ""
        Me.stbDetailsOfIllness.Location = New System.Drawing.Point(218, 219)
        Me.stbDetailsOfIllness.Name = "stbDetailsOfIllness"
        Me.stbDetailsOfIllness.RegularExpression = ""
        Me.stbDetailsOfIllness.Size = New System.Drawing.Size(170, 20)
        Me.stbDetailsOfIllness.TabIndex = 22
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 299)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = false
        '
        'lblInfection
        '
        Me.lblInfection.Location = New System.Drawing.Point(12, 35)
        Me.lblInfection.Name = "lblInfection"
        Me.lblInfection.Size = New System.Drawing.Size(200, 20)
        Me.lblInfection.TabIndex = 7
        Me.lblInfection.Text = "Infection"
        '
        'lblInfectionDetails
        '
        Me.lblInfectionDetails.Location = New System.Drawing.Point(12, 58)
        Me.lblInfectionDetails.Name = "lblInfectionDetails"
        Me.lblInfectionDetails.Size = New System.Drawing.Size(200, 20)
        Me.lblInfectionDetails.TabIndex = 9
        Me.lblInfectionDetails.Text = "Infection Details"
        '
        'lblAccidentDuringPregnancy
        '
        Me.lblAccidentDuringPregnancy.Location = New System.Drawing.Point(12, 81)
        Me.lblAccidentDuringPregnancy.Name = "lblAccidentDuringPregnancy"
        Me.lblAccidentDuringPregnancy.Size = New System.Drawing.Size(200, 20)
        Me.lblAccidentDuringPregnancy.TabIndex = 11
        Me.lblAccidentDuringPregnancy.Text = "Accident During Pregnancy"
        '
        'lblDetailsOfAccident
        '
        Me.lblDetailsOfAccident.Location = New System.Drawing.Point(12, 104)
        Me.lblDetailsOfAccident.Name = "lblDetailsOfAccident"
        Me.lblDetailsOfAccident.Size = New System.Drawing.Size(200, 20)
        Me.lblDetailsOfAccident.TabIndex = 13
        Me.lblDetailsOfAccident.Text = "Details Of Accident"
        '
        'lblUseOfDrugsOrPrescription
        '
        Me.lblUseOfDrugsOrPrescription.Location = New System.Drawing.Point(12, 127)
        Me.lblUseOfDrugsOrPrescription.Name = "lblUseOfDrugsOrPrescription"
        Me.lblUseOfDrugsOrPrescription.Size = New System.Drawing.Size(200, 20)
        Me.lblUseOfDrugsOrPrescription.TabIndex = 15
        Me.lblUseOfDrugsOrPrescription.Text = "Use Of Drugs Or Prescription"
        '
        'lblDrugDetails
        '
        Me.lblDrugDetails.Location = New System.Drawing.Point(12, 150)
        Me.lblDrugDetails.Name = "lblDrugDetails"
        Me.lblDrugDetails.Size = New System.Drawing.Size(200, 20)
        Me.lblDrugDetails.TabIndex = 17
        Me.lblDrugDetails.Text = "Drug Details"
        '
        'lblSmoking
        '
        Me.lblSmoking.Location = New System.Drawing.Point(12, 173)
        Me.lblSmoking.Name = "lblSmoking"
        Me.lblSmoking.Size = New System.Drawing.Size(200, 20)
        Me.lblSmoking.TabIndex = 19
        Me.lblSmoking.Text = "Smoking"
        '
        'lblChronicIllness
        '
        Me.lblChronicIllness.Location = New System.Drawing.Point(12, 196)
        Me.lblChronicIllness.Name = "lblChronicIllness"
        Me.lblChronicIllness.Size = New System.Drawing.Size(200, 20)
        Me.lblChronicIllness.TabIndex = 21
        Me.lblChronicIllness.Text = "Chronic Illness"
        '
        'lblDetailsOfIllness
        '
        Me.lblDetailsOfIllness.Location = New System.Drawing.Point(12, 219)
        Me.lblDetailsOfIllness.Name = "lblDetailsOfIllness"
        Me.lblDetailsOfIllness.Size = New System.Drawing.Size(200, 20)
        Me.lblDetailsOfIllness.TabIndex = 23
        Me.lblDetailsOfIllness.Text = "Details Of Illness"
        '
        'btnLoadPatients
        '
        Me.btnLoadPatients.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPatients.Location = New System.Drawing.Point(344, 5)
        Me.btnLoadPatients.Name = "btnLoadPatients"
        Me.btnLoadPatients.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPatients.TabIndex = 64
        Me.btnLoadPatients.Tag = ""
        Me.btnLoadPatients.Text = "&Load"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"),System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(185, 14)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 62
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = false
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(218, 11)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(119, 20)
        Me.stbVisitNo.TabIndex = 63
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(14, 15)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(140, 20)
        Me.lblVisitNo.TabIndex = 61
        Me.lblVisitNo.Text = "Visit No"
        '
        'frmAntenatal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(415, 349)
        Me.Controls.Add(Me.btnLoadPatients)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.cboInfection)
        Me.Controls.Add(Me.lblInfection)
        Me.Controls.Add(Me.stbInfectionDetails)
        Me.Controls.Add(Me.lblInfectionDetails)
        Me.Controls.Add(Me.cboAccidentDuringPregnancy)
        Me.Controls.Add(Me.lblAccidentDuringPregnancy)
        Me.Controls.Add(Me.stbDetailsOfAccident)
        Me.Controls.Add(Me.lblDetailsOfAccident)
        Me.Controls.Add(Me.cboUseOfDrugsOrPrescription)
        Me.Controls.Add(Me.lblUseOfDrugsOrPrescription)
        Me.Controls.Add(Me.stbDrugDetails)
        Me.Controls.Add(Me.lblDrugDetails)
        Me.Controls.Add(Me.cboSmoking)
        Me.Controls.Add(Me.lblSmoking)
        Me.Controls.Add(Me.cboChronicIllness)
        Me.Controls.Add(Me.lblChronicIllness)
        Me.Controls.Add(Me.stbDetailsOfIllness)
        Me.Controls.Add(Me.lblDetailsOfIllness)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = true
        Me.MaximizeBox = false
        Me.Name = "frmAntenatal"
        Me.Text = "Antenatal"
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboInfection As System.Windows.Forms.ComboBox
    Friend WithEvents lblInfection As System.Windows.Forms.Label
    Friend WithEvents stbInfectionDetails As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblInfectionDetails As System.Windows.Forms.Label
    Friend WithEvents cboAccidentDuringPregnancy As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccidentDuringPregnancy As System.Windows.Forms.Label
    Friend WithEvents stbDetailsOfAccident As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDetailsOfAccident As System.Windows.Forms.Label
    Friend WithEvents cboUseOfDrugsOrPrescription As System.Windows.Forms.ComboBox
    Friend WithEvents lblUseOfDrugsOrPrescription As System.Windows.Forms.Label
    Friend WithEvents stbDrugDetails As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDrugDetails As System.Windows.Forms.Label
    Friend WithEvents cboSmoking As System.Windows.Forms.ComboBox
    Friend WithEvents lblSmoking As System.Windows.Forms.Label
    Friend WithEvents cboChronicIllness As System.Windows.Forms.ComboBox
    Friend WithEvents lblChronicIllness As System.Windows.Forms.Label
    Friend WithEvents stbDetailsOfIllness As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDetailsOfIllness As System.Windows.Forms.Label
    Friend WithEvents btnLoadPatients As System.Windows.Forms.Button
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label

End Class