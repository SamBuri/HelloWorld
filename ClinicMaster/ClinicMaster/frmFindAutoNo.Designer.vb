
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindAutoNo
    Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal controlAutoNo As Control, ByVal autoNumber As AutoNumber)
        MyClass.New()
        Me.autoNoControl = controlAutoNo
        Me._AutoNumber = autoNumber
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFindAutoNo))
        Me.stbFindNo = New SyncSoft.Common.Win.Controls.SmartTextBox
        Me.dtpFindDate = New System.Windows.Forms.DateTimePicker
        Me.lblFindDate = New System.Windows.Forms.Label
        Me.lblFindNo = New System.Windows.Forms.Label
        Me.fbnCancel = New SyncSoft.Common.Win.Controls.FlatButton
        Me.fbnFindNow = New SyncSoft.Common.Win.Controls.FlatButton
        Me.lblMessage = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'stbFindNo
        '
        Me.stbFindNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFindNo.CapitalizeFirstLetter = False
        Me.stbFindNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbFindNo.EntryErrorMSG = ""
        Me.stbFindNo.Location = New System.Drawing.Point(131, 12)
        Me.stbFindNo.MaxLength = 20
        Me.stbFindNo.Name = "stbFindNo"
        Me.stbFindNo.RegularExpression = ""
        Me.stbFindNo.RegularExpressionFormat = SyncSoft.Common.Win.Controls.SetRegularExpressionFormat.Custom
        Me.stbFindNo.Size = New System.Drawing.Size(180, 20)
        Me.stbFindNo.TabIndex = 1
        Me.stbFindNo.VisualStyle = SyncSoft.Common.Win.Controls.Style.None
        Me.stbFindNo.WordFormat = SyncSoft.Common.Win.Controls.SetWordFormat.Normal
        '
        'dtpFindDate
        '
        Me.dtpFindDate.Location = New System.Drawing.Point(131, 33)
        Me.dtpFindDate.Name = "dtpFindDate"
        Me.dtpFindDate.ShowCheckBox = True
        Me.dtpFindDate.Size = New System.Drawing.Size(180, 20)
        Me.dtpFindDate.TabIndex = 3
        '
        'lblFindDate
        '
        Me.lblFindDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFindDate.Location = New System.Drawing.Point(17, 33)
        Me.lblFindDate.Name = "lblFindDate"
        Me.lblFindDate.Size = New System.Drawing.Size(108, 20)
        Me.lblFindDate.TabIndex = 2
        Me.lblFindDate.Text = "Visit Date"
        '
        'lblFindNo
        '
        Me.lblFindNo.Location = New System.Drawing.Point(17, 12)
        Me.lblFindNo.Name = "lblFindNo"
        Me.lblFindNo.Size = New System.Drawing.Size(108, 20)
        Me.lblFindNo.TabIndex = 0
        Me.lblFindNo.Text = "Patient's No"
        '
        'fbnCancel
        '
        Me.fbnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnCancel.Location = New System.Drawing.Point(239, 97)
        Me.fbnCancel.Name = "fbnCancel"
        Me.fbnCancel.Size = New System.Drawing.Size(72, 24)
        Me.fbnCancel.TabIndex = 6
        Me.fbnCancel.Text = "&Cancel"
        Me.fbnCancel.UseVisualStyleBackColor = False
        '
        'fbnFindNow
        '
        Me.fbnFindNow.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnFindNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnFindNow.Location = New System.Drawing.Point(20, 97)
        Me.fbnFindNow.Name = "fbnFindNow"
        Me.fbnFindNow.Size = New System.Drawing.Size(72, 24)
        Me.fbnFindNow.TabIndex = 5
        Me.fbnFindNow.Text = "&Find Now"
        Me.fbnFindNow.UseVisualStyleBackColor = False
        '
        'lblMessage
        '
        Me.lblMessage.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMessage.ForeColor = System.Drawing.Color.Blue
        Me.lblMessage.Location = New System.Drawing.Point(20, 61)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(291, 20)
        Me.lblMessage.TabIndex = 4
        Me.lblMessage.Text = "Hint: Uncheck visit date to get the latest"
        Me.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmFindAutoNo
        '
        Me.AcceptButton = Me.fbnFindNow
        Me.AccessibleName = ""
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.fbnCancel
        Me.ClientSize = New System.Drawing.Size(335, 144)
        Me.Controls.Add(Me.lblMessage)
        Me.Controls.Add(Me.fbnFindNow)
        Me.Controls.Add(Me.fbnCancel)
        Me.Controls.Add(Me.stbFindNo)
        Me.Controls.Add(Me.dtpFindDate)
        Me.Controls.Add(Me.lblFindDate)
        Me.Controls.Add(Me.lblFindNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFindAutoNo"
        Me.Opacity = 0.9
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Find Auto No"
        Me.TransparencyKey = System.Drawing.Color.DarkBlue
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbFindNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents dtpFindDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFindDate As System.Windows.Forms.Label
    Friend WithEvents lblFindNo As System.Windows.Forms.Label
    Friend WithEvents fbnCancel As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnFindNow As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblMessage As System.Windows.Forms.Label
End Class
