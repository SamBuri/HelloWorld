
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRejectedSpecimens : Inherits System.Windows.Forms.Form

    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(speciminenNo As String, visitNo As String, rejectedAt As String)
        MyClass.New
        Me.specimenNo = speciminenNo
        Me.visitNo = visitNo
        Me.rejectedAt = rejectedAt

    End Sub


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRejectedSpecimens))
        Me.fbnSearch = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnDelete = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.ebnSaveUpdate = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.cboRejectectionReasonID = New System.Windows.Forms.ComboBox()
        Me.dtpRejectionDate = New System.Windows.Forms.DateTimePicker()
        Me.stbRejectedAt = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.stbRejectedBy = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.stbSpecimenNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblSpecimenNo = New System.Windows.Forms.Label()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.lblRejectectionReasonID = New System.Windows.Forms.Label()
        Me.lblRejectionDate = New System.Windows.Forms.Label()
        Me.lblRejectedAt = New System.Windows.Forms.Label()
        Me.lblRejectedBy = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnSearch
        '
        Me.fbnSearch.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSearch.Location = New System.Drawing.Point(17, 162)
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
        Me.fbnDelete.Location = New System.Drawing.Point(316, 162)
        Me.fbnDelete.Name = "fbnDelete"
        Me.fbnDelete.Size = New System.Drawing.Size(72, 24)
        Me.fbnDelete.TabIndex = 1
        Me.fbnDelete.Tag = "RejectedSpecimens"
        Me.fbnDelete.Text = "&Delete"
        Me.fbnDelete.UseVisualStyleBackColor = False
        Me.fbnDelete.Visible = False
        '
        'ebnSaveUpdate
        '
        Me.ebnSaveUpdate.BackColor = System.Drawing.SystemColors.Control
        Me.ebnSaveUpdate.DataSource = Nothing
        Me.ebnSaveUpdate.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.ebnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ebnSaveUpdate.Location = New System.Drawing.Point(17, 189)
        Me.ebnSaveUpdate.Name = "ebnSaveUpdate"
        Me.ebnSaveUpdate.Size = New System.Drawing.Size(77, 23)
        Me.ebnSaveUpdate.TabIndex = 2
        Me.ebnSaveUpdate.Tag = "RejectedSpecimens"
        Me.ebnSaveUpdate.Text = "&Save"
        Me.ebnSaveUpdate.UseVisualStyleBackColor = False
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbVisitNo, "VisitNo")
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(218, 35)
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.ReadOnly = True
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(170, 20)
        Me.stbVisitNo.TabIndex = 6
        '
        'cboRejectectionReasonID
        '
        Me.ebnSaveUpdate.SetDataMember(Me.cboRejectectionReasonID, "RejectectionReason,RejectectionReasonID")
        Me.cboRejectectionReasonID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRejectectionReasonID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboRejectectionReasonID.Location = New System.Drawing.Point(218, 58)
        Me.cboRejectectionReasonID.Name = "cboRejectectionReasonID"
        Me.cboRejectectionReasonID.Size = New System.Drawing.Size(170, 21)
        Me.cboRejectectionReasonID.TabIndex = 8
        '
        'dtpRejectionDate
        '
        Me.dtpRejectionDate.Checked = False
        Me.ebnSaveUpdate.SetDataMember(Me.dtpRejectionDate, "RejectionDate")
        Me.dtpRejectionDate.Location = New System.Drawing.Point(218, 81)
        Me.dtpRejectionDate.Name = "dtpRejectionDate"
        Me.dtpRejectionDate.ShowCheckBox = True
        Me.dtpRejectionDate.Size = New System.Drawing.Size(170, 20)
        Me.dtpRejectionDate.TabIndex = 10
        '
        'stbRejectedAt
        '
        Me.stbRejectedAt.BackColor = System.Drawing.SystemColors.Info
        Me.stbRejectedAt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRejectedAt.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbRejectedAt, "RejectedAt")
        Me.stbRejectedAt.EntryErrorMSG = ""
        Me.stbRejectedAt.Location = New System.Drawing.Point(218, 104)
        Me.stbRejectedAt.Name = "stbRejectedAt"
        Me.stbRejectedAt.ReadOnly = True
        Me.stbRejectedAt.RegularExpression = ""
        Me.stbRejectedAt.Size = New System.Drawing.Size(170, 20)
        Me.stbRejectedAt.TabIndex = 12
        '
        'stbRejectedBy
        '
        Me.stbRejectedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbRejectedBy.CapitalizeFirstLetter = False
        Me.ebnSaveUpdate.SetDataMember(Me.stbRejectedBy, "RejectedBy")
        Me.stbRejectedBy.EntryErrorMSG = ""
        Me.stbRejectedBy.Location = New System.Drawing.Point(218, 127)
        Me.stbRejectedBy.Name = "stbRejectedBy"
        Me.stbRejectedBy.RegularExpression = ""
        Me.stbRejectedBy.Size = New System.Drawing.Size(170, 20)
        Me.stbRejectedBy.TabIndex = 14
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 189)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 3
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'stbSpecimenNo
        '
        Me.stbSpecimenNo.BackColor = System.Drawing.SystemColors.Info
        Me.stbSpecimenNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbSpecimenNo.CapitalizeFirstLetter = False
        Me.stbSpecimenNo.EntryErrorMSG = ""
        Me.stbSpecimenNo.Location = New System.Drawing.Point(218, 12)
        Me.stbSpecimenNo.Name = "stbSpecimenNo"
        Me.stbSpecimenNo.ReadOnly = True
        Me.stbSpecimenNo.RegularExpression = ""
        Me.stbSpecimenNo.Size = New System.Drawing.Size(170, 20)
        Me.stbSpecimenNo.TabIndex = 4
        '
        'lblSpecimenNo
        '
        Me.lblSpecimenNo.Location = New System.Drawing.Point(12, 12)
        Me.lblSpecimenNo.Name = "lblSpecimenNo"
        Me.lblSpecimenNo.Size = New System.Drawing.Size(200, 20)
        Me.lblSpecimenNo.TabIndex = 5
        Me.lblSpecimenNo.Text = "Specimen No"
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(12, 35)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(200, 20)
        Me.lblVisitNo.TabIndex = 7
        Me.lblVisitNo.Text = "Visit No"
        '
        'lblRejectectionReasonID
        '
        Me.lblRejectectionReasonID.Location = New System.Drawing.Point(12, 58)
        Me.lblRejectectionReasonID.Name = "lblRejectectionReasonID"
        Me.lblRejectectionReasonID.Size = New System.Drawing.Size(200, 20)
        Me.lblRejectectionReasonID.TabIndex = 9
        Me.lblRejectectionReasonID.Text = "Rejectection Reason"
        '
        'lblRejectionDate
        '
        Me.lblRejectionDate.Location = New System.Drawing.Point(12, 81)
        Me.lblRejectionDate.Name = "lblRejectionDate"
        Me.lblRejectionDate.Size = New System.Drawing.Size(200, 20)
        Me.lblRejectionDate.TabIndex = 11
        Me.lblRejectionDate.Text = "Rejection Date"
        '
        'lblRejectedAt
        '
        Me.lblRejectedAt.Location = New System.Drawing.Point(12, 104)
        Me.lblRejectedAt.Name = "lblRejectedAt"
        Me.lblRejectedAt.Size = New System.Drawing.Size(200, 20)
        Me.lblRejectedAt.TabIndex = 13
        Me.lblRejectedAt.Text = "Rejected At"
        '
        'lblRejectedBy
        '
        Me.lblRejectedBy.Location = New System.Drawing.Point(12, 127)
        Me.lblRejectedBy.Name = "lblRejectedBy"
        Me.lblRejectedBy.Size = New System.Drawing.Size(200, 20)
        Me.lblRejectedBy.TabIndex = 15
        Me.lblRejectedBy.Text = "Rejected By"
        '
        'frmRejectedSpecimens
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(415, 228)
        Me.Controls.Add(Me.fbnSearch)
        Me.Controls.Add(Me.fbnDelete)
        Me.Controls.Add(Me.ebnSaveUpdate)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.stbSpecimenNo)
        Me.Controls.Add(Me.lblSpecimenNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.cboRejectectionReasonID)
        Me.Controls.Add(Me.lblRejectectionReasonID)
        Me.Controls.Add(Me.dtpRejectionDate)
        Me.Controls.Add(Me.lblRejectionDate)
        Me.Controls.Add(Me.stbRejectedAt)
        Me.Controls.Add(Me.lblRejectedAt)
        Me.Controls.Add(Me.stbRejectedBy)
        Me.Controls.Add(Me.lblRejectedBy)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmRejectedSpecimens"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reject Specimen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents fbnSearch As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnDelete As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents ebnSaveUpdate As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents stbSpecimenNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblSpecimenNo As System.Windows.Forms.Label
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents cboRejectectionReasonID As System.Windows.Forms.ComboBox
    Friend WithEvents lblRejectectionReasonID As System.Windows.Forms.Label
    Friend WithEvents dtpRejectionDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblRejectionDate As System.Windows.Forms.Label
    Friend WithEvents stbRejectedAt As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRejectedAt As System.Windows.Forms.Label
    Friend WithEvents stbRejectedBy As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblRejectedBy As System.Windows.Forms.Label
    Private specimenNo As String
    Private visitNo As String
    Private rejectedAt As String
End Class