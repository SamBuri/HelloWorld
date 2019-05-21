
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFindObject
    Inherits System.Windows.Forms.Form

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal objectName As ObjectName)
        MyClass.New()
        Me._ObjectName = objectName
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFindObject))
        Me.stbFindNo = New SyncSoft.Common.Win.Controls.SmartTextBox()
        Me.lblFindNo = New System.Windows.Forms.Label()
        Me.fbnCancel = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnFindNow = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.cboBillModesID = New System.Windows.Forms.ComboBox()
        Me.lblBillModesID = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'stbFindNo
        '
        Me.stbFindNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.stbFindNo.CapitalizeFirstLetter = False
        Me.stbFindNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.stbFindNo.EntryErrorMSG = ""
        Me.stbFindNo.Location = New System.Drawing.Point(163, 34)
        Me.stbFindNo.MaxLength = 30
        Me.stbFindNo.Name = "stbFindNo"
        Me.stbFindNo.RegularExpression = ""
        Me.stbFindNo.Size = New System.Drawing.Size(155, 20)
        Me.stbFindNo.TabIndex = 3
        '
        'lblFindNo
        '
        Me.lblFindNo.Location = New System.Drawing.Point(12, 36)
        Me.lblFindNo.Name = "lblFindNo"
        Me.lblFindNo.Size = New System.Drawing.Size(145, 18)
        Me.lblFindNo.TabIndex = 2
        Me.lblFindNo.Text = "Default Medical Card No"
        '
        'fbnCancel
        '
        Me.fbnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnCancel.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnCancel.Location = New System.Drawing.Point(246, 75)
        Me.fbnCancel.Name = "fbnCancel"
        Me.fbnCancel.Size = New System.Drawing.Size(72, 24)
        Me.fbnCancel.TabIndex = 5
        Me.fbnCancel.Text = "&Cancel"
        Me.fbnCancel.UseVisualStyleBackColor = False
        '
        'fbnFindNow
        '
        Me.fbnFindNow.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.fbnFindNow.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnFindNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnFindNow.Location = New System.Drawing.Point(12, 75)
        Me.fbnFindNow.Name = "fbnFindNow"
        Me.fbnFindNow.Size = New System.Drawing.Size(72, 24)
        Me.fbnFindNow.TabIndex = 4
        Me.fbnFindNow.Text = "&Find Now"
        Me.fbnFindNow.UseVisualStyleBackColor = False
        '
        'cboBillModesID
        '
        Me.cboBillModesID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cboBillModesID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cboBillModesID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBillModesID.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboBillModesID.FormattingEnabled = True
        Me.cboBillModesID.ItemHeight = 13
        Me.cboBillModesID.Location = New System.Drawing.Point(163, 10)
        Me.cboBillModesID.Name = "cboBillModesID"
        Me.cboBillModesID.Size = New System.Drawing.Size(155, 21)
        Me.cboBillModesID.TabIndex = 1
        '
        'lblBillModesID
        '
        Me.lblBillModesID.Location = New System.Drawing.Point(12, 13)
        Me.lblBillModesID.Name = "lblBillModesID"
        Me.lblBillModesID.Size = New System.Drawing.Size(145, 18)
        Me.lblBillModesID.TabIndex = 0
        Me.lblBillModesID.Text = "Default Bill Mode"
        '
        'frmFindObject
        '
        Me.AcceptButton = Me.fbnFindNow
        Me.AccessibleName = ""
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.fbnCancel
        Me.ClientSize = New System.Drawing.Size(334, 119)
        Me.Controls.Add(Me.cboBillModesID)
        Me.Controls.Add(Me.lblBillModesID)
        Me.Controls.Add(Me.fbnFindNow)
        Me.Controls.Add(Me.fbnCancel)
        Me.Controls.Add(Me.stbFindNo)
        Me.Controls.Add(Me.lblFindNo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFindObject"
        Me.Opacity = 0.9R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Find Scheme Member"
        Me.TransparencyKey = System.Drawing.Color.DarkBlue
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents stbFindNo As SyncSoft.Common.Win.Controls.SmartTextBox
    Friend WithEvents lblFindNo As System.Windows.Forms.Label
    Friend WithEvents fbnCancel As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnFindNow As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents cboBillModesID As System.Windows.Forms.ComboBox
    Friend WithEvents lblBillModesID As System.Windows.Forms.Label
End Class
