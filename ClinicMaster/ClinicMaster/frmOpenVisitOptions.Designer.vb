<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpenVisitOptions : Inherits System.Windows.Forms.Form

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpenVisitOptions))
        Me.pbxWarning = New System.Windows.Forms.PictureBox()
        Me.mainpnl = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.fbnCancel = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnAdmission = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnTriage = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnExtraCharge = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnVisionAssessment = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnCashier = New SyncSoft.Common.Win.Controls.FlatButton()
        CType(Me.pbxWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mainpnl.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbxWarning
        '
        Me.pbxWarning.Image = CType(resources.GetObject("pbxWarning.Image"), System.Drawing.Image)
        Me.pbxWarning.Location = New System.Drawing.Point(34, 17)
        Me.pbxWarning.Name = "pbxWarning"
        Me.pbxWarning.Size = New System.Drawing.Size(41, 36)
        Me.pbxWarning.TabIndex = 1
        Me.pbxWarning.TabStop = False
        '
        'mainpnl
        '
        Me.mainpnl.BackColor = System.Drawing.Color.White
        Me.mainpnl.Controls.Add(Me.lblMessage)
        Me.mainpnl.Controls.Add(Me.pbxWarning)
        Me.mainpnl.Location = New System.Drawing.Point(-2, 1)
        Me.mainpnl.Name = "mainpnl"
        Me.mainpnl.Size = New System.Drawing.Size(574, 66)
        Me.mainpnl.TabIndex = 7
        '
        'lblMessage
        '
        Me.lblMessage.AutoSize = True
        Me.lblMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.Location = New System.Drawing.Point(75, 29)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(0, 16)
        Me.lblMessage.TabIndex = 0
        '
        'fbnCancel
        '
        Me.fbnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnCancel.Location = New System.Drawing.Point(504, 77)
        Me.fbnCancel.Name = "fbnCancel"
        Me.fbnCancel.Size = New System.Drawing.Size(64, 27)
        Me.fbnCancel.TabIndex = 12
        Me.fbnCancel.Text = "&Close"
        '
        'fbnAdmission
        '
        Me.fbnAdmission.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnAdmission.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnAdmission.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnAdmission.Location = New System.Drawing.Point(305, 77)
        Me.fbnAdmission.Name = "fbnAdmission"
        Me.fbnAdmission.Size = New System.Drawing.Size(91, 27)
        Me.fbnAdmission.TabIndex = 9
        Me.fbnAdmission.Tag = "Admissions"
        Me.fbnAdmission.Text = "&Admission"
        '
        'fbnTriage
        '
        Me.fbnTriage.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnTriage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnTriage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnTriage.Location = New System.Drawing.Point(5, 77)
        Me.fbnTriage.Name = "fbnTriage"
        Me.fbnTriage.Size = New System.Drawing.Size(70, 27)
        Me.fbnTriage.TabIndex = 8
        Me.fbnTriage.Tag = "Triage"
        Me.fbnTriage.Text = "&Triage"
        '
        'fbnExtraCharge
        '
        Me.fbnExtraCharge.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnExtraCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnExtraCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnExtraCharge.Location = New System.Drawing.Point(401, 78)
        Me.fbnExtraCharge.Name = "fbnExtraCharge"
        Me.fbnExtraCharge.Size = New System.Drawing.Size(91, 27)
        Me.fbnExtraCharge.TabIndex = 13
        Me.fbnExtraCharge.Tag = "ExtraCharge"
        Me.fbnExtraCharge.Text = "&Extra Charge"
        '
        'fbnVisionAssessment
        '
        Me.fbnVisionAssessment.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnVisionAssessment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnVisionAssessment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnVisionAssessment.Location = New System.Drawing.Point(161, 77)
        Me.fbnVisionAssessment.Name = "fbnVisionAssessment"
        Me.fbnVisionAssessment.Size = New System.Drawing.Size(140, 27)
        Me.fbnVisionAssessment.TabIndex = 14
        Me.fbnVisionAssessment.Tag = "VisionAssessment"
        Me.fbnVisionAssessment.Text = "&Vision Assessment"
        '
        'fbnCashier
        '
        Me.fbnCashier.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnCashier.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnCashier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnCashier.Location = New System.Drawing.Point(79, 77)
        Me.fbnCashier.Name = "fbnCashier"
        Me.fbnCashier.Size = New System.Drawing.Size(78, 27)
        Me.fbnCashier.TabIndex = 15
        Me.fbnCashier.Tag = "Payments"
        Me.fbnCashier.Text = "&Cashier"
        '
        'frmOpenVisitOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(570, 110)
        Me.Controls.Add(Me.fbnCashier)
        Me.Controls.Add(Me.fbnVisionAssessment)
        Me.Controls.Add(Me.fbnExtraCharge)
        Me.Controls.Add(Me.mainpnl)
        Me.Controls.Add(Me.fbnCancel)
        Me.Controls.Add(Me.fbnAdmission)
        Me.Controls.Add(Me.fbnTriage)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOpenVisitOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClinicMaster"
        CType(Me.pbxWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mainpnl.ResumeLayout(False)
        Me.mainpnl.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbxWarning As System.Windows.Forms.PictureBox
    Friend WithEvents mainpnl As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents fbnCancel As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnAdmission As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnTriage As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnExtraCharge As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnVisionAssessment As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnCashier As SyncSoft.Common.Win.Controls.FlatButton
End Class
