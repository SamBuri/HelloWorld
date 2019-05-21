<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOpenOptions : Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal patientNo As String)
        MyClass.New()
        Me.defaultPatientNo = patientNo
    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpenOptions))
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.fbnVisits = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnSelfRequests = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnAppointment = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnCancel = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.mainpnl = New System.Windows.Forms.Panel()
        Me.pbxWarning = New System.Windows.Forms.PictureBox()
        Me.fbnArt = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnManageAccount = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.mainpnl.SuspendLayout()
        CType(Me.pbxWarning, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'fbnVisits
        '
        Me.fbnVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnVisits.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnVisits.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnVisits.Location = New System.Drawing.Point(3, 81)
        Me.fbnVisits.Name = "fbnVisits"
        Me.fbnVisits.Size = New System.Drawing.Size(70, 27)
        Me.fbnVisits.TabIndex = 1
        Me.fbnVisits.Tag = "Visits"
        Me.fbnVisits.Text = "&Visits"
        '
        'fbnSelfRequests
        '
        Me.fbnSelfRequests.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnSelfRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnSelfRequests.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnSelfRequests.Location = New System.Drawing.Point(77, 82)
        Me.fbnSelfRequests.Name = "fbnSelfRequests"
        Me.fbnSelfRequests.Size = New System.Drawing.Size(91, 27)
        Me.fbnSelfRequests.TabIndex = 2
        Me.fbnSelfRequests.Tag = "SelfRequests"
        Me.fbnSelfRequests.Text = "&Self Request"
        '
        'fbnAppointment
        '
        Me.fbnAppointment.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnAppointment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnAppointment.Location = New System.Drawing.Point(172, 82)
        Me.fbnAppointment.Name = "fbnAppointment"
        Me.fbnAppointment.Size = New System.Drawing.Size(93, 27)
        Me.fbnAppointment.TabIndex = 3
        Me.fbnAppointment.Tag = "Appointments"
        Me.fbnAppointment.Text = "&Appointments"
        '
        'fbnCancel
        '
        Me.fbnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnCancel.Location = New System.Drawing.Point(440, 81)
        Me.fbnCancel.Name = "fbnCancel"
        Me.fbnCancel.Size = New System.Drawing.Size(64, 27)
        Me.fbnCancel.TabIndex = 5
        Me.fbnCancel.Text = "&Close"
        '
        'mainpnl
        '
        Me.mainpnl.BackColor = System.Drawing.Color.White
        Me.mainpnl.Controls.Add(Me.lblMessage)
        Me.mainpnl.Controls.Add(Me.pbxWarning)
        Me.mainpnl.Location = New System.Drawing.Point(-5, 0)
        Me.mainpnl.Name = "mainpnl"
        Me.mainpnl.Size = New System.Drawing.Size(514, 66)
        Me.mainpnl.TabIndex = 0
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
        'fbnArt
        '
        Me.fbnArt.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnArt.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnArt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnArt.Location = New System.Drawing.Point(364, 81)
        Me.fbnArt.Name = "fbnArt"
        Me.fbnArt.Size = New System.Drawing.Size(72, 27)
        Me.fbnArt.TabIndex = 4
        Me.fbnArt.Tag = "HIVCARE"
        Me.fbnArt.Text = "&HIV Care"
        '
        'fbnManageAccount
        '
        Me.fbnManageAccount.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnManageAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnManageAccount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fbnManageAccount.Location = New System.Drawing.Point(269, 82)
        Me.fbnManageAccount.Name = "fbnManageAccount"
        Me.fbnManageAccount.Size = New System.Drawing.Size(91, 27)
        Me.fbnManageAccount.TabIndex = 6
        Me.fbnManageAccount.Tag = "Accounts"
        Me.fbnManageAccount.Text = "&Manage A/C"
        '
        'frmOpenOptions
        '
        Me.AcceptButton = Me.fbnVisits
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnCancel
        Me.ClientSize = New System.Drawing.Size(509, 120)
        Me.Controls.Add(Me.fbnManageAccount)
        Me.Controls.Add(Me.fbnArt)
        Me.Controls.Add(Me.mainpnl)
        Me.Controls.Add(Me.fbnCancel)
        Me.Controls.Add(Me.fbnAppointment)
        Me.Controls.Add(Me.fbnSelfRequests)
        Me.Controls.Add(Me.fbnVisits)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmOpenOptions"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ClinicMaster"
        Me.mainpnl.ResumeLayout(False)
        Me.mainpnl.PerformLayout()
        CType(Me.pbxWarning, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents fbnVisits As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnSelfRequests As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnAppointment As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnCancel As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents mainpnl As System.Windows.Forms.Panel
    Friend WithEvents fbnArt As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents pbxWarning As System.Windows.Forms.PictureBox
    Friend WithEvents fbnManageAccount As SyncSoft.Common.Win.Controls.FlatButton
End Class
