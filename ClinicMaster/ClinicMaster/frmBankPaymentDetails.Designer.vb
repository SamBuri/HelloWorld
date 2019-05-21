
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankPaymentDetails : Inherits System.Windows.Forms.Form


    Private Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal peyModeID As String)
        MyClass.New()
        Me.payModeID = peyModeID

    End Sub



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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBankPaymentDetails))
        Me.cboBankNamesID = New System.Windows.Forms.ComboBox()
        Me.cboAccountNo = New System.Windows.Forms.ComboBox()
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblBankNamesID = New System.Windows.Forms.Label()
        Me.lblAccountNo = New System.Windows.Forms.Label()
        Me.btnDone = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cboBankNamesID
        '
        Me.cboBankNamesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBankNamesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBankNamesID.Location = New System.Drawing.Point(218, 20)
        Me.cboBankNamesID.Name = "cboBankNamesID"
        Me.cboBankNamesID.Size = New System.Drawing.Size(170, 21)
        Me.cboBankNamesID.TabIndex = 1
        '
        'cboAccountNo
        '
        Me.cboAccountNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccountNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboAccountNo.Location = New System.Drawing.Point(218, 47)
        Me.cboAccountNo.Name = "cboAccountNo"
        Me.cboAccountNo.Size = New System.Drawing.Size(170, 21)
        Me.cboAccountNo.TabIndex = 3
        '
        'fbnClose
        '
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(316, 74)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 6
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblBankNamesID
        '
        Me.lblBankNamesID.Location = New System.Drawing.Point(12, 20)
        Me.lblBankNamesID.Name = "lblBankNamesID"
        Me.lblBankNamesID.Size = New System.Drawing.Size(200, 20)
        Me.lblBankNamesID.TabIndex = 0
        Me.lblBankNamesID.Text = "Bank Name"
        '
        'lblAccountNo
        '
        Me.lblAccountNo.Location = New System.Drawing.Point(12, 47)
        Me.lblAccountNo.Name = "lblAccountNo"
        Me.lblAccountNo.Size = New System.Drawing.Size(200, 20)
        Me.lblAccountNo.TabIndex = 2
        Me.lblAccountNo.Text = "Account No"
        '
        'btnDone
        '
        Me.btnDone.AccessibleDescription = ""
        Me.btnDone.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDone.Location = New System.Drawing.Point(12, 74)
        Me.btnDone.Name = "btnDone"
        Me.btnDone.Size = New System.Drawing.Size(49, 24)
        Me.btnDone.TabIndex = 5
        Me.btnDone.Tag = ""
        Me.btnDone.Text = "&Done"
        '
        'frmBankPaymentDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(415, 116)
        Me.Controls.Add(Me.btnDone)
        Me.Controls.Add(Me.fbnClose)
        Me.Controls.Add(Me.cboBankNamesID)
        Me.Controls.Add(Me.lblBankNamesID)
        Me.Controls.Add(Me.cboAccountNo)
        Me.Controls.Add(Me.lblAccountNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmBankPaymentDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Bank Payment Details"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboBankNamesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBankNamesID As System.Windows.Forms.Label
    Friend WithEvents cboAccountNo As System.Windows.Forms.ComboBox
    Friend WithEvents lblAccountNo As System.Windows.Forms.Label
    Private payModeID As String
    Friend WithEvents btnDone As Button
End Class