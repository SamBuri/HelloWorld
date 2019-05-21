
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisitFiles : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVisitFiles))
        Me.cboFileStatusID = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblFileStatusID = New System.Windows.Forms.Label()
        Me.cboLoginID = New System.Windows.Forms.ComboBox()
        Me.lblLoginID = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlAlerts = New System.Windows.Forms.Panel()
        Me.chkHideSelfRequest = New System.Windows.Forms.CheckBox()
        Me.btnPendingVisitFiles = New System.Windows.Forms.Button()
        Me.lblAlertMessage = New System.Windows.Forms.Label()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        Me.stbAge = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbJoinDate = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbGender = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblJoinDate = New System.Windows.Forms.Label()
        Me.lblAge = New System.Windows.Forms.Label()
        Me.lblGenderID = New System.Windows.Forms.Label()
        Me.stbFullName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.stbReferenceNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblReferenceNo = New System.Windows.Forms.Label()
        Me.stbBillMode = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillMode = New System.Windows.Forms.Label()
        Me.stbBillCustomerName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillCustomerName = New System.Windows.Forms.Label()
        Me.stbInsuranceName = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblBillInsuranceName = New System.Windows.Forms.Label()
        Me.pnlAlerts.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboFileStatusID
        '
        Me.cboFileStatusID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboFileStatusID, "cboFileStatusID")
        Me.cboFileStatusID.Name = "cboFileStatusID"
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.fbnClose, "fbnClose")
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbVisitNo, "stbVisitNo")
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.ReadOnly = True
        Me.stbVisitNo.RegularExpression = ""
        '
        'lblVisitNo
        '
        resources.ApplyResources(Me.lblVisitNo, "lblVisitNo")
        Me.lblVisitNo.Name = "lblVisitNo"
        '
        'lblFileStatusID
        '
        resources.ApplyResources(Me.lblFileStatusID, "lblFileStatusID")
        Me.lblFileStatusID.Name = "lblFileStatusID"
        '
        'cboLoginID
        '
        resources.ApplyResources(Me.cboLoginID, "cboLoginID")
        Me.cboLoginID.Name = "cboLoginID"
        '
        'lblLoginID
        '
        resources.ApplyResources(Me.lblLoginID, "lblLoginID")
        Me.lblLoginID.Name = "lblLoginID"
        '
        'btnSave
        '
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Tag = "ClinicalFindings"
        '
        'pnlAlerts
        '
        Me.pnlAlerts.Controls.Add(Me.chkHideSelfRequest)
        Me.pnlAlerts.Controls.Add(Me.btnPendingVisitFiles)
        Me.pnlAlerts.Controls.Add(Me.lblAlertMessage)
        resources.ApplyResources(Me.pnlAlerts, "pnlAlerts")
        Me.pnlAlerts.Name = "pnlAlerts"
        '
        'chkHideSelfRequest
        '
        resources.ApplyResources(Me.chkHideSelfRequest, "chkHideSelfRequest")
        Me.chkHideSelfRequest.Checked = True
        Me.chkHideSelfRequest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkHideSelfRequest.ForeColor = System.Drawing.Color.DarkBlue
        Me.chkHideSelfRequest.Name = "chkHideSelfRequest"
        '
        'btnPendingVisitFiles
        '
        Me.btnPendingVisitFiles.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        resources.ApplyResources(Me.btnPendingVisitFiles, "btnPendingVisitFiles")
        Me.btnPendingVisitFiles.Name = "btnPendingVisitFiles"
        Me.btnPendingVisitFiles.Tag = ""
        '
        'lblAlertMessage
        '
        resources.ApplyResources(Me.lblAlertMessage, "lblAlertMessage")
        Me.lblAlertMessage.ForeColor = System.Drawing.Color.Red
        Me.lblAlertMessage.Name = "lblAlertMessage"
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Enabled = True
        Me.tmrAlerts.Interval = 120000
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        resources.ApplyResources(Me.stbPatientNo, "stbPatientNo")
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.RegularExpression = ""
        '
        'lblPatientsNo
        '
        resources.ApplyResources(Me.lblPatientsNo, "lblPatientsNo")
        Me.lblPatientsNo.Name = "lblPatientsNo"
        '
        'stbAge
        '
        Me.stbAge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbAge.CapitalizeFirstLetter = False
        resources.ApplyResources(Me.stbAge, "stbAge")
        Me.stbAge.EntryErrorMSG = ""
        Me.stbAge.Name = "stbAge"
        Me.stbAge.RegularExpression = ""
        '
        'stbJoinDate
        '
        Me.stbJoinDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbJoinDate.CapitalizeFirstLetter = False
        resources.ApplyResources(Me.stbJoinDate, "stbJoinDate")
        Me.stbJoinDate.EntryErrorMSG = ""
        Me.stbJoinDate.Name = "stbJoinDate"
        Me.stbJoinDate.RegularExpression = ""
        '
        'stbGender
        '
        Me.stbGender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbGender.CapitalizeFirstLetter = False
        resources.ApplyResources(Me.stbGender, "stbGender")
        Me.stbGender.EntryErrorMSG = ""
        Me.stbGender.Name = "stbGender"
        Me.stbGender.RegularExpression = ""
        '
        'lblJoinDate
        '
        resources.ApplyResources(Me.lblJoinDate, "lblJoinDate")
        Me.lblJoinDate.Name = "lblJoinDate"
        '
        'lblAge
        '
        resources.ApplyResources(Me.lblAge, "lblAge")
        Me.lblAge.Name = "lblAge"
        '
        'lblGenderID
        '
        resources.ApplyResources(Me.lblGenderID, "lblGenderID")
        Me.lblGenderID.Name = "lblGenderID"
        '
        'stbFullName
        '
        Me.stbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFullName.CapitalizeFirstLetter = False
        resources.ApplyResources(Me.stbFullName, "stbFullName")
        Me.stbFullName.EntryErrorMSG = ""
        Me.stbFullName.Name = "stbFullName"
        Me.stbFullName.RegularExpression = ""
        '
        'lblName
        '
        resources.ApplyResources(Me.lblName, "lblName")
        Me.lblName.Name = "lblName"
        '
        'stbReferenceNo
        '
        Me.stbReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbReferenceNo.CapitalizeFirstLetter = False
        resources.ApplyResources(Me.stbReferenceNo, "stbReferenceNo")
        Me.stbReferenceNo.EntryErrorMSG = ""
        Me.stbReferenceNo.Name = "stbReferenceNo"
        Me.stbReferenceNo.RegularExpression = ""
        '
        'lblReferenceNo
        '
        resources.ApplyResources(Me.lblReferenceNo, "lblReferenceNo")
        Me.lblReferenceNo.Name = "lblReferenceNo"
        '
        'stbBillMode
        '
        Me.stbBillMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillMode.CapitalizeFirstLetter = False
        resources.ApplyResources(Me.stbBillMode, "stbBillMode")
        Me.stbBillMode.EntryErrorMSG = ""
        Me.stbBillMode.Name = "stbBillMode"
        Me.stbBillMode.RegularExpression = ""
        '
        'lblBillMode
        '
        resources.ApplyResources(Me.lblBillMode, "lblBillMode")
        Me.lblBillMode.Name = "lblBillMode"
        '
        'stbBillCustomerName
        '
        Me.stbBillCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbBillCustomerName.CapitalizeFirstLetter = False
        Me.stbBillCustomerName.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbBillCustomerName, "stbBillCustomerName")
        Me.stbBillCustomerName.Name = "stbBillCustomerName"
        Me.stbBillCustomerName.ReadOnly = True
        Me.stbBillCustomerName.RegularExpression = ""
        '
        'lblBillCustomerName
        '
        resources.ApplyResources(Me.lblBillCustomerName, "lblBillCustomerName")
        Me.lblBillCustomerName.Name = "lblBillCustomerName"
        '
        'stbInsuranceName
        '
        Me.stbInsuranceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbInsuranceName.CapitalizeFirstLetter = False
        Me.stbInsuranceName.EntryErrorMSG = ""
        resources.ApplyResources(Me.stbInsuranceName, "stbInsuranceName")
        Me.stbInsuranceName.Name = "stbInsuranceName"
        Me.stbInsuranceName.ReadOnly = True
        Me.stbInsuranceName.RegularExpression = ""
        '
        'lblBillInsuranceName
        '
        resources.ApplyResources(Me.lblBillInsuranceName, "lblBillInsuranceName")
        Me.lblBillInsuranceName.Name = "lblBillInsuranceName"
        '
        'frmVisitFiles
        '
        Me.AcceptButton = Me.btnSave
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.Controls.Add(Me.stbInsuranceName)
        Me.Controls.Add(Me.lblBillInsuranceName)
        Me.Controls.Add(Me.stbBillCustomerName)
        Me.Controls.Add(Me.lblBillCustomerName)
        Me.Controls.Add(Me.stbBillMode)
        Me.Controls.Add(Me.lblBillMode)
        Me.Controls.Add(Me.stbReferenceNo)
        Me.Controls.Add(Me.lblReferenceNo)
        Me.Controls.Add(Me.stbAge)
        Me.Controls.Add(Me.stbJoinDate)
        Me.Controls.Add(Me.stbGender)
        Me.Controls.Add(Me.lblJoinDate)
        Me.Controls.Add(Me.lblAge)
        Me.Controls.Add(Me.lblGenderID)
        Me.Controls.Add(Me.stbFullName)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.pnlAlerts)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.cboFileStatusID)
        Me.Controls.Add(Me.lblFileStatusID)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmVisitFiles"
        Me.pnlAlerts.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents cboFileStatusID As System.Windows.Forms.ComboBox
    Friend WithEvents lblFileStatusID As System.Windows.Forms.Label
    Friend WithEvents cboLoginID As System.Windows.Forms.ComboBox
    Friend WithEvents lblLoginID As System.Windows.Forms.Label
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents pnlAlerts As System.Windows.Forms.Panel
    Friend WithEvents btnPendingVisitFiles As System.Windows.Forms.Button
    Friend WithEvents lblAlertMessage As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
    Friend WithEvents stbAge As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbJoinDate As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents stbGender As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblJoinDate As System.Windows.Forms.Label
    Friend WithEvents lblAge As System.Windows.Forms.Label
    Friend WithEvents lblGenderID As System.Windows.Forms.Label
    Friend WithEvents stbFullName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents stbReferenceNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblReferenceNo As System.Windows.Forms.Label
    Friend WithEvents stbBillMode As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillMode As System.Windows.Forms.Label
    Friend WithEvents stbBillCustomerName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillCustomerName As System.Windows.Forms.Label
    Friend WithEvents chkHideSelfRequest As System.Windows.Forms.CheckBox
    Friend WithEvents stbInsuranceName As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblBillInsuranceName As System.Windows.Forms.Label

End Class