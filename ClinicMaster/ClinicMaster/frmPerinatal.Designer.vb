
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPerinatal : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPerinatal))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.cboModeOfDelivery = New System.Windows.Forms.ComboBox()
        Me.stbDurationOfLabour = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboDeliveryComplications = New System.Windows.Forms.ComboBox()
        Me.nbxAmountOfBloodLoss = New SyncSoft.Common.Win.Controls.NumericBox()
        Me.cboMothersCondition = New System.Windows.Forms.ComboBox()
        Me.stbDetailsOfCondition = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboBabyAlive = New System.Windows.Forms.ComboBox()
        Me.cboCauseOfDeath = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblModeOfDelivery = New System.Windows.Forms.Label()
        Me.lblDurationOfLabour = New System.Windows.Forms.Label()
        Me.lblDeliveryComplications = New System.Windows.Forms.Label()
        Me.lblAmountOfBloodLoss = New System.Windows.Forms.Label()
        Me.lblMothersCondition = New System.Windows.Forms.Label()
        Me.lblDetailsOfCondition = New System.Windows.Forms.Label()
        Me.lblBabyAlive = New System.Windows.Forms.Label()
        Me.lblCauseOfDeath = New System.Windows.Forms.Label()
        Me.btnLoadPatients = New System.Windows.Forms.Button()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 249)
        Me.fbnSearch.Name = "fbnSearch"
        Me.fbnSearch.Size = New System.Drawing.Size(77, 23)
        Me.fbnSearch.TabIndex = 0
        Me.fbnSearch.Text = "S&earch"
        Me.fbnSearch.UseVisualStyleBackColor = True
        Me.fbnSearch.Visible = False
        '
        'fbnDelete
        '
        Me.fbnDelete.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnDelete.Location = New System.Drawing.Point(316, 249)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "Perinatal"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 276)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "Perinatal"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'cboModeOfDelivery
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboModeOfDelivery, "ModeOfDelivery")
        Me.cboModeOfDelivery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboModeOfDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboModeOfDelivery.Location = New System.Drawing.Point(218, 35)
        Me.cboModeOfDelivery.Name = "cboModeOfDelivery"
        Me.cboModeOfDelivery.Size = New System.Drawing.Size(170, 21)
        Me.cboModeOfDelivery.TabIndex = 6
        '
        'stbDurationOfLabour
        '
        Me.stbDurationOfLabour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDurationOfLabour.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDurationOfLabour, "DurationOfLabour   ")
        Me.stbDurationOfLabour.EntryErrorMSG = ""
        Me.stbDurationOfLabour.Location = New System.Drawing.Point(218, 58)
        Me.stbDurationOfLabour.Name = "stbDurationOfLabour"
        Me.stbDurationOfLabour.RegularExpression = ""
        Me.stbDurationOfLabour.Size = New System.Drawing.Size(170, 20)
        Me.stbDurationOfLabour.TabIndex = 8
        '
        'cboDeliveryComplications
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboDeliveryComplications, "DeliveryComplications")
        Me.cboDeliveryComplications.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDeliveryComplications.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboDeliveryComplications.Location = New System.Drawing.Point(218, 81)
        Me.cboDeliveryComplications.Name = "cboDeliveryComplications"
        Me.cboDeliveryComplications.Size = New System.Drawing.Size(170, 21)
        Me.cboDeliveryComplications.TabIndex = 10
        '
        'nbxAmountOfBloodLoss
        '
        Me.nbxAmountOfBloodLoss.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.nbxAmountOfBloodLoss.ControlCaption = "Amount Of Blood Loss"
        Me.ebnSaveUpdate.SetDataMember(Me.nbxAmountOfBloodLoss, "AmountOfBloodLoss")
        Me.nbxAmountOfBloodLoss.DataType = SyncSoft.Common.Win.Controls.Number.[Single]
        Me.nbxAmountOfBloodLoss.DecimalPlaces = -1
        Me.nbxAmountOfBloodLoss.Location = New System.Drawing.Point(218, 104)
        Me.nbxAmountOfBloodLoss.MaxValue = 0.0R
        Me.nbxAmountOfBloodLoss.MinValue = 0.0R
        Me.nbxAmountOfBloodLoss.MustEnterNumeric = True
        Me.nbxAmountOfBloodLoss.Name = "nbxAmountOfBloodLoss"
        Me.nbxAmountOfBloodLoss.Size = New System.Drawing.Size(170, 20)
        Me.nbxAmountOfBloodLoss.TabIndex = 12
        Me.nbxAmountOfBloodLoss.Value = ""
        '
        'cboMothersCondition
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboMothersCondition, "MothersCondition")
        Me.cboMothersCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMothersCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboMothersCondition.Location = New System.Drawing.Point(218, 127)
        Me.cboMothersCondition.Name = "cboMothersCondition"
        Me.cboMothersCondition.Size = New System.Drawing.Size(170, 21)
        Me.cboMothersCondition.TabIndex = 14
        '
        'stbDetailsOfCondition
        '
        Me.stbDetailsOfCondition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbDetailsOfCondition.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbDetailsOfCondition, "DetailsOfCondition")
        Me.stbDetailsOfCondition.EntryErrorMSG = ""
        Me.stbDetailsOfCondition.Location = New System.Drawing.Point(218, 150)
        Me.stbDetailsOfCondition.Name = "stbDetailsOfCondition"
        Me.stbDetailsOfCondition.RegularExpression = ""
        Me.stbDetailsOfCondition.Size = New System.Drawing.Size(170, 20)
        Me.stbDetailsOfCondition.TabIndex = 16
        '
        'cboBabyAlive
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboBabyAlive, "BabyAlive")
        Me.cboBabyAlive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBabyAlive.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBabyAlive.Location = New System.Drawing.Point(218, 173)
        Me.cboBabyAlive.Name = "cboBabyAlive"
        Me.cboBabyAlive.Size = New System.Drawing.Size(170, 21)
        Me.cboBabyAlive.TabIndex = 18
        '
        'cboCauseOfDeath
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboCauseOfDeath, "CauseOfDeath")
        Me.cboCauseOfDeath.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCauseOfDeath.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboCauseOfDeath.Location = New System.Drawing.Point(218, 196)
        Me.cboCauseOfDeath.Name = "cboCauseOfDeath"
        Me.cboCauseOfDeath.Size = New System.Drawing.Size(170, 21)
        Me.cboCauseOfDeath.TabIndex = 20
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 276)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(12, 12)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(200, 20)
        Me.lblVisitNo.TabIndex = 5
        Me.lblVisitNo.Text = "Visit No"
        '
        'lblModeOfDelivery
        '
        Me.lblModeOfDelivery.Location = New System.Drawing.Point(12, 35)
        Me.lblModeOfDelivery.Name = "lblModeOfDelivery"
        Me.lblModeOfDelivery.Size = New System.Drawing.Size(200, 20)
        Me.lblModeOfDelivery.TabIndex = 7
        Me.lblModeOfDelivery.Text = "Mode Of Delivery"
        '
        'lblDurationOfLabour
        '
        Me.lblDurationOfLabour.Location = New System.Drawing.Point(12, 58)
        Me.lblDurationOfLabour.Name = "lblDurationOfLabour"
        Me.lblDurationOfLabour.Size = New System.Drawing.Size(200, 20)
        Me.lblDurationOfLabour.TabIndex = 9
        Me.lblDurationOfLabour.Text = "Duration Of Labour"
        '
        'lblDeliveryComplications
        '
        Me.lblDeliveryComplications.Location = New System.Drawing.Point(12, 81)
        Me.lblDeliveryComplications.Name = "lblDeliveryComplications"
        Me.lblDeliveryComplications.Size = New System.Drawing.Size(200, 20)
        Me.lblDeliveryComplications.TabIndex = 11
        Me.lblDeliveryComplications.Text = "Delivery Complications"
        '
        'lblAmountOfBloodLoss
        '
        Me.lblAmountOfBloodLoss.Location = New System.Drawing.Point(12, 104)
        Me.lblAmountOfBloodLoss.Name = "lblAmountOfBloodLoss"
        Me.lblAmountOfBloodLoss.Size = New System.Drawing.Size(200, 20)
        Me.lblAmountOfBloodLoss.TabIndex = 13
        Me.lblAmountOfBloodLoss.Text = "Amount Of Blood Loss"
        '
        'lblMothersCondition
        '
        Me.lblMothersCondition.Location = New System.Drawing.Point(12, 127)
        Me.lblMothersCondition.Name = "lblMothersCondition"
        Me.lblMothersCondition.Size = New System.Drawing.Size(200, 20)
        Me.lblMothersCondition.TabIndex = 15
        Me.lblMothersCondition.Text = "Mothers Condition"
        '
        'lblDetailsOfCondition
        '
        Me.lblDetailsOfCondition.Location = New System.Drawing.Point(12, 150)
        Me.lblDetailsOfCondition.Name = "lblDetailsOfCondition"
        Me.lblDetailsOfCondition.Size = New System.Drawing.Size(200, 20)
        Me.lblDetailsOfCondition.TabIndex = 17
        Me.lblDetailsOfCondition.Text = "Details Of Condition"
        '
        'lblBabyAlive
        '
        Me.lblBabyAlive.Location = New System.Drawing.Point(12, 173)
        Me.lblBabyAlive.Name = "lblBabyAlive"
        Me.lblBabyAlive.Size = New System.Drawing.Size(200, 20)
        Me.lblBabyAlive.TabIndex = 19
        Me.lblBabyAlive.Text = "Baby Alive"
        '
        'lblCauseOfDeath
        '
        Me.lblCauseOfDeath.Location = New System.Drawing.Point(12, 196)
        Me.lblCauseOfDeath.Name = "lblCauseOfDeath"
        Me.lblCauseOfDeath.Size = New System.Drawing.Size(200, 20)
        Me.lblCauseOfDeath.TabIndex = 21
        Me.lblCauseOfDeath.Text = "CauseOfDeath"
        '
        'btnLoadPatients
        '
        Me.btnLoadPatients.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPatients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPatients.Location = New System.Drawing.Point(343, 8)
        Me.btnLoadPatients.Name = "btnLoadPatients"
        Me.btnLoadPatients.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPatients.TabIndex = 60
        Me.btnLoadPatients.Tag = ""
        Me.btnLoadPatients.Text = "&Load"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(174, 12)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 58
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(218, 8)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(119, 20)
        Me.stbVisitNo.TabIndex = 59
        '
        'frmPerinatal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(415, 326)
        Me.Controls.Add(Me.btnLoadPatients)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.cboModeOfDelivery)
        Me.Controls.Add(Me.lblModeOfDelivery)
        Me.Controls.Add(Me.stbDurationOfLabour)
        Me.Controls.Add(Me.lblDurationOfLabour)
        Me.Controls.Add(Me.cboDeliveryComplications)
        Me.Controls.Add(Me.lblDeliveryComplications)
        Me.Controls.Add(Me.nbxAmountOfBloodLoss)
        Me.Controls.Add(Me.lblAmountOfBloodLoss)
        Me.Controls.Add(Me.cboMothersCondition)
        Me.Controls.Add(Me.lblMothersCondition)
        Me.Controls.Add(Me.stbDetailsOfCondition)
        Me.Controls.Add(Me.lblDetailsOfCondition)
        Me.Controls.Add(Me.cboBabyAlive)
        Me.Controls.Add(Me.lblBabyAlive)
        Me.Controls.Add(Me.cboCauseOfDeath)
        Me.Controls.Add(Me.lblCauseOfDeath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmPerinatal"
        Me.Text = "Perinatal"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents cboModeOfDelivery As System.Windows.Forms.ComboBox
    Friend WithEvents lblModeOfDelivery As System.Windows.Forms.Label
    Friend WithEvents stbDurationOfLabour As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDurationOfLabour As System.Windows.Forms.Label
    Friend WithEvents cboDeliveryComplications As System.Windows.Forms.ComboBox
    Friend WithEvents lblDeliveryComplications As System.Windows.Forms.Label
    Friend WithEvents nbxAmountOfBloodLoss As SyncSoft.Common.Win.Controls.NumericBox
    Friend WithEvents lblAmountOfBloodLoss As System.Windows.Forms.Label
    Friend WithEvents cboMothersCondition As System.Windows.Forms.ComboBox
    Friend WithEvents lblMothersCondition As System.Windows.Forms.Label
    Friend WithEvents stbDetailsOfCondition As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblDetailsOfCondition As System.Windows.Forms.Label
    Friend WithEvents cboBabyAlive As System.Windows.Forms.ComboBox
    Friend WithEvents lblBabyAlive As System.Windows.Forms.Label
    Friend WithEvents cboCauseOfDeath As System.Windows.Forms.ComboBox
    Friend WithEvents lblCauseOfDeath As System.Windows.Forms.Label
    Friend WithEvents btnLoadPatients As System.Windows.Forms.Button
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox

End Class