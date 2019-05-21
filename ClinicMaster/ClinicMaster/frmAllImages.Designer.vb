<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAllImages : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal visitNo As String)
        MyClass.New()
        Me.defaultVisitNo = visitNo
    End Sub





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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAllImages))
        Me.stbProvisionalDiagnosis = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblProvisionalDiagnosis = New System.Windows.Forms.Label()
        Me.spImage = New System.Windows.Forms.PictureBox()
        Me.pnlNavigateAllImages = New System.Windows.Forms.Panel()
        Me.navExtraBills = New SyncSoft.Common.Win.Controls.DataNavigator()
        Me.chkNavigateImages = New System.Windows.Forms.CheckBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnLoadPeriodicVisits = New System.Windows.Forms.Button()
        Me.btnFindVisitNo = New System.Windows.Forms.Button()
        Me.stbVisitNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblVisitNo = New System.Windows.Forms.Label()
        Me.btnZoomOut = New SyncSoft.Common.Win.Controls.EditButton()
        Me.btnZoomIn = New SyncSoft.Common.Win.Controls.EditButton()
        Me.stbPatientNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblPatientsNo = New System.Windows.Forms.Label()
        CType(Me.spImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlNavigateAllImages.SuspendLayout()
        Me.SuspendLayout()
        '
        'stbProvisionalDiagnosis
        '
        Me.stbProvisionalDiagnosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbProvisionalDiagnosis.CapitalizeFirstLetter = True
        Me.stbProvisionalDiagnosis.Enabled = False
        Me.stbProvisionalDiagnosis.EntryErrorMSG = ""
        Me.stbProvisionalDiagnosis.Location = New System.Drawing.Point(87, 66)
        Me.stbProvisionalDiagnosis.MaxLength = 3000
        Me.stbProvisionalDiagnosis.Multiline = True
        Me.stbProvisionalDiagnosis.Name = "stbProvisionalDiagnosis"
        Me.stbProvisionalDiagnosis.ReadOnly = True
        Me.stbProvisionalDiagnosis.RegularExpression = ""
        Me.stbProvisionalDiagnosis.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.stbProvisionalDiagnosis.Size = New System.Drawing.Size(764, 38)
        Me.stbProvisionalDiagnosis.TabIndex = 63
        '
        'lblProvisionalDiagnosis
        '
        Me.lblProvisionalDiagnosis.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblProvisionalDiagnosis.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblProvisionalDiagnosis.Location = New System.Drawing.Point(8, 77)
        Me.lblProvisionalDiagnosis.Name = "lblProvisionalDiagnosis"
        Me.lblProvisionalDiagnosis.Size = New System.Drawing.Size(73, 20)
        Me.lblProvisionalDiagnosis.TabIndex = 62
        Me.lblProvisionalDiagnosis.Text = "Details"
        '
        'spImage
        '
        Me.spImage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.spImage.Location = New System.Drawing.Point(12, 109)
        Me.spImage.Name = "spImage"
        Me.spImage.Size = New System.Drawing.Size(910, 320)
        Me.spImage.TabIndex = 64
        Me.spImage.TabStop = False
        '
        'pnlNavigateAllImages
        '
        Me.pnlNavigateAllImages.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.pnlNavigateAllImages.Controls.Add(Me.navExtraBills)
        Me.pnlNavigateAllImages.Controls.Add(Me.chkNavigateImages)
        Me.pnlNavigateAllImages.Location = New System.Drawing.Point(87, 435)
        Me.pnlNavigateAllImages.Name = "pnlNavigateAllImages"
        Me.pnlNavigateAllImages.Size = New System.Drawing.Size(761, 43)
        Me.pnlNavigateAllImages.TabIndex = 65
        '
        'navExtraBills
        '
        Me.navExtraBills.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.navExtraBills.ColumnName = "ExtraBillNo"
        Me.navExtraBills.DataSource = Nothing
        Me.navExtraBills.Location = New System.Drawing.Point(239, 6)
        Me.navExtraBills.Name = "navExtraBills"
        Me.navExtraBills.NavAllEnabled = False
        Me.navExtraBills.NavLeftEnabled = False
        Me.navExtraBills.NavRightEnabled = False
        Me.navExtraBills.Size = New System.Drawing.Size(413, 32)
        Me.navExtraBills.TabIndex = 1
        '
        'chkNavigateImages
        '
        Me.chkNavigateImages.AccessibleDescription = ""
        Me.chkNavigateImages.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNavigateImages.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkNavigateImages.Location = New System.Drawing.Point(72, 12)
        Me.chkNavigateImages.Name = "chkNavigateImages"
        Me.chkNavigateImages.Size = New System.Drawing.Size(161, 20)
        Me.chkNavigateImages.TabIndex = 0
        Me.chkNavigateImages.Text = "Navigate Images"
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(853, 445)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 66
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'btnLoadPeriodicVisits
        '
        Me.btnLoadPeriodicVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnLoadPeriodicVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadPeriodicVisits.Location = New System.Drawing.Point(228, 18)
        Me.btnLoadPeriodicVisits.Name = "btnLoadPeriodicVisits"
        Me.btnLoadPeriodicVisits.Size = New System.Drawing.Size(44, 24)
        Me.btnLoadPeriodicVisits.TabIndex = 70
        Me.btnLoadPeriodicVisits.Tag = ""
        Me.btnLoadPeriodicVisits.Text = "&Load"
        '
        'btnFindVisitNo
        '
        Me.btnFindVisitNo.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnFindVisitNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFindVisitNo.Image = CType(resources.GetObject("btnFindVisitNo.Image"), System.Drawing.Image)
        Me.btnFindVisitNo.Location = New System.Drawing.Point(87, 20)
        Me.btnFindVisitNo.Name = "btnFindVisitNo"
        Me.btnFindVisitNo.Size = New System.Drawing.Size(27, 21)
        Me.btnFindVisitNo.TabIndex = 68
        '
        'stbVisitNo
        '
        Me.stbVisitNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbVisitNo.CapitalizeFirstLetter = False
        Me.stbVisitNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbVisitNo.EntryErrorMSG = ""
        Me.stbVisitNo.Location = New System.Drawing.Point(120, 20)
        Me.stbVisitNo.MaxLength = 20
        Me.stbVisitNo.Name = "stbVisitNo"
        Me.stbVisitNo.RegularExpression = ""
        Me.stbVisitNo.Size = New System.Drawing.Size(102, 20)
        Me.stbVisitNo.TabIndex = 69
        '
        'lblVisitNo
        '
        Me.lblVisitNo.Location = New System.Drawing.Point(8, 24)
        Me.lblVisitNo.Name = "lblVisitNo"
        Me.lblVisitNo.Size = New System.Drawing.Size(70, 21)
        Me.lblVisitNo.TabIndex = 67
        Me.lblVisitNo.Text = "Visit No"
        '
        'btnZoomOut
        '
        Me.btnZoomOut.DataSource = Nothing
        Me.btnZoomOut.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZoomOut.Location = New System.Drawing.Point(853, 77)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(34, 23)
        Me.btnZoomOut.TabIndex = 71
        Me.btnZoomOut.Tag = ""
        Me.btnZoomOut.Text = "+"
        Me.btnZoomOut.UseVisualStyleBackColor = False
        '
        'btnZoomIn
        '
        Me.btnZoomIn.DataSource = Nothing
        Me.btnZoomIn.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZoomIn.Location = New System.Drawing.Point(893, 77)
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(33, 23)
        Me.btnZoomIn.TabIndex = 72
        Me.btnZoomIn.Tag = "AccessedCashServices"
        Me.btnZoomIn.Text = "-"
        Me.btnZoomIn.UseVisualStyleBackColor = False
        '
        'stbPatientNo
        '
        Me.stbPatientNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbPatientNo.CapitalizeFirstLetter = False
        Me.stbPatientNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbPatientNo.EntryErrorMSG = ""
        Me.stbPatientNo.Location = New System.Drawing.Point(87, 45)
        Me.stbPatientNo.MaxLength = 7
        Me.stbPatientNo.Name = "stbPatientNo"
        Me.stbPatientNo.ReadOnly = True
        Me.stbPatientNo.RegularExpression = ""
        Me.stbPatientNo.Size = New System.Drawing.Size(185, 20)
        Me.stbPatientNo.TabIndex = 74
        '
        'lblPatientsNo
        '
        Me.lblPatientsNo.Location = New System.Drawing.Point(7, 46)
        Me.lblPatientsNo.Name = "lblPatientsNo"
        Me.lblPatientsNo.Size = New System.Drawing.Size(74, 20)
        Me.lblPatientsNo.TabIndex = 73
        Me.lblPatientsNo.Text = "Patient's No"
        '
        'frmAllImages
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(938, 482)
        Me.Controls.Add(Me.stbPatientNo)
        Me.Controls.Add(Me.lblPatientsNo)
        Me.Controls.Add(Me.btnZoomIn)
        Me.Controls.Add(Me.btnZoomOut)
        Me.Controls.Add(Me.btnLoadPeriodicVisits)
        Me.Controls.Add(Me.btnFindVisitNo)
        Me.Controls.Add(Me.stbVisitNo)
        Me.Controls.Add(Me.lblVisitNo)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.pnlNavigateAllImages)
        Me.Controls.Add(Me.spImage)
        Me.Controls.Add(Me.stbProvisionalDiagnosis)
        Me.Controls.Add(Me.lblProvisionalDiagnosis)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAllImages"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "All Images"
        CType(Me.spImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlNavigateAllImages.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbProvisionalDiagnosis As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblProvisionalDiagnosis As System.Windows.Forms.Label
    Friend WithEvents spImage As System.Windows.Forms.PictureBox
    Friend WithEvents pnlNavigateAllImages As System.Windows.Forms.Panel
    Friend WithEvents navExtraBills As SyncSoft.Common.Win.Controls.DataNavigator
    Friend WithEvents chkNavigateImages As System.Windows.Forms.CheckBox
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnLoadPeriodicVisits As System.Windows.Forms.Button
    Friend WithEvents btnFindVisitNo As System.Windows.Forms.Button
    Friend WithEvents stbVisitNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblVisitNo As System.Windows.Forms.Label
    Friend WithEvents btnZoomOut As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents btnZoomIn As SyncSoft.Common.Win.Controls.EditButton
    Friend WithEvents stbPatientNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblPatientsNo As System.Windows.Forms.Label
End Class
