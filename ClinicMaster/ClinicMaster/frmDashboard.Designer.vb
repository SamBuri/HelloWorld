<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDashboard
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDashboard))
        Me.fbnClose = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblTodayAppointments = New System.Windows.Forms.Label()
        Me.lblPendingResults = New System.Windows.Forms.Label()
        Me.lblLabResultsAlerts = New System.Windows.Forms.Label()
        Me.tmrAlerts = New System.Windows.Forms.Timer(Me.components)
        Me.lblReadyRadiologyReports = New System.Windows.Forms.Label()
        Me.lblPendingRadiology = New System.Windows.Forms.Label()
        Me.lblWaitingVisits = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.lblTodayAdmissions = New System.Windows.Forms.Label()
        Me.lblcountTodaysVisits = New System.Windows.Forms.Label()
        Me.lblOverDueAdmissions = New System.Windows.Forms.Label()
        Me.lblManualDebits = New System.Windows.Forms.Label()
        Me.btnReload = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnManualDebits = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnOverDueAdmissions = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnTodaysVisit = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnTodayAdmissions = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnReadyRadiology = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnPendingRadiology = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnReadyLabResults = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnPendingLabResults = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnTodaysAppointment = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.btnWaitingVisits = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.fbnOPDUnpaidItems = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblOPDNotPaidItems = New System.Windows.Forms.Label()
        Me.fbnAccountBalances = New SyncSoft.Common.Win.Controls.FlatButton()
        Me.lblAccountBalances = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'fbnClose
        '
        Me.fbnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.fbnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.fbnClose.Location = New System.Drawing.Point(674, 277)
        Me.fbnClose.Name = "fbnClose"
        Me.fbnClose.Size = New System.Drawing.Size(72, 24)
        Me.fbnClose.TabIndex = 21
        Me.fbnClose.Text = "&Close"
        Me.fbnClose.UseVisualStyleBackColor = False
        '
        'lblTodayAppointments
        '
        Me.lblTodayAppointments.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTodayAppointments.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTodayAppointments.Location = New System.Drawing.Point(12, 53)
        Me.lblTodayAppointments.Name = "lblTodayAppointments"
        Me.lblTodayAppointments.Size = New System.Drawing.Size(237, 26)
        Me.lblTodayAppointments.TabIndex = 2
        Me.lblTodayAppointments.Text = "Today's Appointments: 0"
        Me.lblTodayAppointments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPendingResults
        '
        Me.lblPendingResults.AccessibleDescription = ""
        Me.lblPendingResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingResults.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPendingResults.Location = New System.Drawing.Point(12, 83)
        Me.lblPendingResults.Name = "lblPendingResults"
        Me.lblPendingResults.Size = New System.Drawing.Size(237, 22)
        Me.lblPendingResults.TabIndex = 4
        Me.lblPendingResults.Text = "Pending Lab Results: 0"
        Me.lblPendingResults.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLabResultsAlerts
        '
        Me.lblLabResultsAlerts.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLabResultsAlerts.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblLabResultsAlerts.Location = New System.Drawing.Point(12, 112)
        Me.lblLabResultsAlerts.Name = "lblLabResultsAlerts"
        Me.lblLabResultsAlerts.Size = New System.Drawing.Size(214, 24)
        Me.lblLabResultsAlerts.TabIndex = 6
        Me.lblLabResultsAlerts.Text = "Ready Lab Results: 0"
        Me.lblLabResultsAlerts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrAlerts
        '
        Me.tmrAlerts.Interval = 30000
        '
        'lblReadyRadiologyReports
        '
        Me.lblReadyRadiologyReports.AccessibleDescription = ""
        Me.lblReadyRadiologyReports.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReadyRadiologyReports.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblReadyRadiologyReports.Location = New System.Drawing.Point(12, 168)
        Me.lblReadyRadiologyReports.Name = "lblReadyRadiologyReports"
        Me.lblReadyRadiologyReports.Size = New System.Drawing.Size(250, 24)
        Me.lblReadyRadiologyReports.TabIndex = 10
        Me.lblReadyRadiologyReports.Text = "Ready Radiology Reports: 0"
        Me.lblReadyRadiologyReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPendingRadiology
        '
        Me.lblPendingRadiology.AccessibleDescription = ""
        Me.lblPendingRadiology.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPendingRadiology.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPendingRadiology.Location = New System.Drawing.Point(12, 143)
        Me.lblPendingRadiology.Name = "lblPendingRadiology"
        Me.lblPendingRadiology.Size = New System.Drawing.Size(280, 21)
        Me.lblPendingRadiology.TabIndex = 8
        Me.lblPendingRadiology.Text = "Pending Radiology Reports: 0"
        Me.lblPendingRadiology.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWaitingVisits
        '
        Me.lblWaitingVisits.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWaitingVisits.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblWaitingVisits.Location = New System.Drawing.Point(12, 24)
        Me.lblWaitingVisits.Name = "lblWaitingVisits"
        Me.lblWaitingVisits.Size = New System.Drawing.Size(183, 27)
        Me.lblWaitingVisits.TabIndex = 0
        Me.lblWaitingVisits.Text = "Waiting Visits: 0"
        Me.lblWaitingVisits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel5
        '
        Me.Panel5.Location = New System.Drawing.Point(154, 575)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(338, 38)
        Me.Panel5.TabIndex = 72
        '
        'lblTodayAdmissions
        '
        Me.lblTodayAdmissions.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTodayAdmissions.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblTodayAdmissions.Location = New System.Drawing.Point(447, 20)
        Me.lblTodayAdmissions.Name = "lblTodayAdmissions"
        Me.lblTodayAdmissions.Size = New System.Drawing.Size(191, 35)
        Me.lblTodayAdmissions.TabIndex = 12
        Me.lblTodayAdmissions.Text = "Today's Admissions: 0"
        Me.lblTodayAdmissions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblcountTodaysVisits
        '
        Me.lblcountTodaysVisits.AccessibleDescription = ""
        Me.lblcountTodaysVisits.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblcountTodaysVisits.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblcountTodaysVisits.Location = New System.Drawing.Point(447, 58)
        Me.lblcountTodaysVisits.Name = "lblcountTodaysVisits"
        Me.lblcountTodaysVisits.Size = New System.Drawing.Size(150, 25)
        Me.lblcountTodaysVisits.TabIndex = 14
        Me.lblcountTodaysVisits.Text = "Today's Visits: 0"
        Me.lblcountTodaysVisits.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOverDueAdmissions
        '
        Me.lblOverDueAdmissions.AutoSize = True
        Me.lblOverDueAdmissions.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOverDueAdmissions.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblOverDueAdmissions.Location = New System.Drawing.Point(447, 91)
        Me.lblOverDueAdmissions.Name = "lblOverDueAdmissions"
        Me.lblOverDueAdmissions.Size = New System.Drawing.Size(172, 18)
        Me.lblOverDueAdmissions.TabIndex = 16
        Me.lblOverDueAdmissions.Text = "Over Due Admissions : 0"
        Me.lblOverDueAdmissions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblManualDebits
        '
        Me.lblManualDebits.AutoSize = True
        Me.lblManualDebits.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblManualDebits.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblManualDebits.Location = New System.Drawing.Point(447, 119)
        Me.lblManualDebits.Name = "lblManualDebits"
        Me.lblManualDebits.Size = New System.Drawing.Size(122, 18)
        Me.lblManualDebits.TabIndex = 18
        Me.lblManualDebits.Text = "Manual Debits : 0"
        '
        'btnReload
        '
        Me.btnReload.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReload.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnReload.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReload.Location = New System.Drawing.Point(15, 277)
        Me.btnReload.Name = "btnReload"
        Me.btnReload.Size = New System.Drawing.Size(72, 24)
        Me.btnReload.TabIndex = 20
        Me.btnReload.Text = "&Reload"
        Me.btnReload.UseVisualStyleBackColor = False
        '
        'btnManualDebits
        '
        Me.btnManualDebits.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnManualDebits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnManualDebits.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnManualDebits.Location = New System.Drawing.Point(657, 115)
        Me.btnManualDebits.Name = "btnManualDebits"
        Me.btnManualDebits.Size = New System.Drawing.Size(89, 24)
        Me.btnManualDebits.TabIndex = 19
        Me.btnManualDebits.Text = "&View More..."
        Me.btnManualDebits.UseVisualStyleBackColor = False
        '
        'btnOverDueAdmissions
        '
        Me.btnOverDueAdmissions.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOverDueAdmissions.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnOverDueAdmissions.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnOverDueAdmissions.Location = New System.Drawing.Point(657, 85)
        Me.btnOverDueAdmissions.Name = "btnOverDueAdmissions"
        Me.btnOverDueAdmissions.Size = New System.Drawing.Size(89, 24)
        Me.btnOverDueAdmissions.TabIndex = 17
        Me.btnOverDueAdmissions.Text = "&View More..."
        Me.btnOverDueAdmissions.UseVisualStyleBackColor = False
        '
        'btnTodaysVisit
        '
        Me.btnTodaysVisit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTodaysVisit.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnTodaysVisit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTodaysVisit.Location = New System.Drawing.Point(657, 55)
        Me.btnTodaysVisit.Name = "btnTodaysVisit"
        Me.btnTodaysVisit.Size = New System.Drawing.Size(89, 24)
        Me.btnTodaysVisit.TabIndex = 15
        Me.btnTodaysVisit.Text = "&View More..."
        Me.btnTodaysVisit.UseVisualStyleBackColor = False
        '
        'btnTodayAdmissions
        '
        Me.btnTodayAdmissions.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTodayAdmissions.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnTodayAdmissions.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTodayAdmissions.Location = New System.Drawing.Point(657, 26)
        Me.btnTodayAdmissions.Name = "btnTodayAdmissions"
        Me.btnTodayAdmissions.Size = New System.Drawing.Size(89, 24)
        Me.btnTodayAdmissions.TabIndex = 13
        Me.btnTodayAdmissions.Text = "&View More..."
        Me.btnTodayAdmissions.UseVisualStyleBackColor = False
        '
        'btnReadyRadiology
        '
        Me.btnReadyRadiology.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnReadyRadiology.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnReadyRadiology.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReadyRadiology.Location = New System.Drawing.Point(295, 168)
        Me.btnReadyRadiology.Name = "btnReadyRadiology"
        Me.btnReadyRadiology.Size = New System.Drawing.Size(89, 24)
        Me.btnReadyRadiology.TabIndex = 11
        Me.btnReadyRadiology.Text = "&View More..."
        Me.btnReadyRadiology.UseVisualStyleBackColor = False
        '
        'btnPendingRadiology
        '
        Me.btnPendingRadiology.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPendingRadiology.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPendingRadiology.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPendingRadiology.Location = New System.Drawing.Point(295, 140)
        Me.btnPendingRadiology.Name = "btnPendingRadiology"
        Me.btnPendingRadiology.Size = New System.Drawing.Size(89, 24)
        Me.btnPendingRadiology.TabIndex = 9
        Me.btnPendingRadiology.Text = "&View More..."
        Me.btnPendingRadiology.UseVisualStyleBackColor = False
        '
        'btnReadyLabResults
        '
        Me.btnReadyLabResults.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnReadyLabResults.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnReadyLabResults.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReadyLabResults.Location = New System.Drawing.Point(295, 112)
        Me.btnReadyLabResults.Name = "btnReadyLabResults"
        Me.btnReadyLabResults.Size = New System.Drawing.Size(89, 24)
        Me.btnReadyLabResults.TabIndex = 7
        Me.btnReadyLabResults.Text = "&View More..."
        Me.btnReadyLabResults.UseVisualStyleBackColor = False
        '
        'btnPendingLabResults
        '
        Me.btnPendingLabResults.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPendingLabResults.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnPendingLabResults.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPendingLabResults.Location = New System.Drawing.Point(295, 84)
        Me.btnPendingLabResults.Name = "btnPendingLabResults"
        Me.btnPendingLabResults.Size = New System.Drawing.Size(89, 24)
        Me.btnPendingLabResults.TabIndex = 5
        Me.btnPendingLabResults.Text = "&View More..."
        Me.btnPendingLabResults.UseVisualStyleBackColor = False
        '
        'btnTodaysAppointment
        '
        Me.btnTodaysAppointment.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTodaysAppointment.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnTodaysAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnTodaysAppointment.Location = New System.Drawing.Point(295, 53)
        Me.btnTodaysAppointment.Name = "btnTodaysAppointment"
        Me.btnTodaysAppointment.Size = New System.Drawing.Size(89, 24)
        Me.btnTodaysAppointment.TabIndex = 3
        Me.btnTodaysAppointment.Text = "&View More..."
        Me.btnTodaysAppointment.UseVisualStyleBackColor = False
        '
        'btnWaitingVisits
        '
        Me.btnWaitingVisits.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnWaitingVisits.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.btnWaitingVisits.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnWaitingVisits.Location = New System.Drawing.Point(295, 24)
        Me.btnWaitingVisits.Name = "btnWaitingVisits"
        Me.btnWaitingVisits.Size = New System.Drawing.Size(89, 24)
        Me.btnWaitingVisits.TabIndex = 1
        Me.btnWaitingVisits.Text = "&View More..."
        Me.btnWaitingVisits.UseVisualStyleBackColor = False
        '
        'fbnOPDUnpaidItems
        '
        Me.fbnOPDUnpaidItems.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnOPDUnpaidItems.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnOPDUnpaidItems.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.fbnOPDUnpaidItems.Location = New System.Drawing.Point(657, 145)
        Me.fbnOPDUnpaidItems.Name = "fbnOPDUnpaidItems"
        Me.fbnOPDUnpaidItems.Size = New System.Drawing.Size(89, 24)
        Me.fbnOPDUnpaidItems.TabIndex = 74
        Me.fbnOPDUnpaidItems.Text = "&View More..."
        Me.fbnOPDUnpaidItems.UseVisualStyleBackColor = False
        '
        'lblOPDNotPaidItems
        '
        Me.lblOPDNotPaidItems.AutoSize = True
        Me.lblOPDNotPaidItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOPDNotPaidItems.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblOPDNotPaidItems.Location = New System.Drawing.Point(447, 149)
        Me.lblOPDNotPaidItems.Name = "lblOPDNotPaidItems"
        Me.lblOPDNotPaidItems.Size = New System.Drawing.Size(151, 18)
        Me.lblOPDNotPaidItems.TabIndex = 73
        Me.lblOPDNotPaidItems.Text = "OPD Unpaid Items : 0"
        '
        'fbnAccountBalances
        '
        Me.fbnAccountBalances.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.fbnAccountBalances.FlatAppearance.BorderColor = System.Drawing.Color.DarkBlue
        Me.fbnAccountBalances.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.fbnAccountBalances.Location = New System.Drawing.Point(657, 175)
        Me.fbnAccountBalances.Name = "fbnAccountBalances"
        Me.fbnAccountBalances.Size = New System.Drawing.Size(89, 24)
        Me.fbnAccountBalances.TabIndex = 76
        Me.fbnAccountBalances.Text = "&View More..."
        Me.fbnAccountBalances.UseVisualStyleBackColor = False
        '
        'lblAccountBalances
        '
        Me.lblAccountBalances.AutoSize = True
        Me.lblAccountBalances.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccountBalances.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblAccountBalances.Location = New System.Drawing.Point(447, 179)
        Me.lblAccountBalances.Name = "lblAccountBalances"
        Me.lblAccountBalances.Size = New System.Drawing.Size(143, 18)
        Me.lblAccountBalances.TabIndex = 75
        Me.lblAccountBalances.Text = "Account Balances: 0"
        '
        'frmDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.fbnClose
        Me.ClientSize = New System.Drawing.Size(758, 313)
        Me.Controls.Add(Me.fbnAccountBalances)
        Me.Controls.Add(Me.lblAccountBalances)
        Me.Controls.Add(Me.fbnOPDUnpaidItems)
        Me.Controls.Add(Me.lblOPDNotPaidItems)
        Me.Controls.Add(Me.btnWaitingVisits)
        Me.Controls.Add(Me.btnTodaysAppointment)
        Me.Controls.Add(Me.btnPendingLabResults)
        Me.Controls.Add(Me.btnReadyLabResults)
        Me.Controls.Add(Me.btnPendingRadiology)
        Me.Controls.Add(Me.btnReadyRadiology)
        Me.Controls.Add(Me.btnTodayAdmissions)
        Me.Controls.Add(Me.btnTodaysVisit)
        Me.Controls.Add(Me.btnOverDueAdmissions)
        Me.Controls.Add(Me.btnManualDebits)
        Me.Controls.Add(Me.btnReload)
        Me.Controls.Add(Me.lblManualDebits)
        Me.Controls.Add(Me.lblOverDueAdmissions)
        Me.Controls.Add(Me.lblWaitingVisits)
        Me.Controls.Add(Me.lblTodayAppointments)
        Me.Controls.Add(Me.lblPendingResults)
        Me.Controls.Add(Me.lblLabResultsAlerts)
        Me.Controls.Add(Me.lblPendingRadiology)
        Me.Controls.Add(Me.lblReadyRadiologyReports)
        Me.Controls.Add(Me.lblTodayAdmissions)
        Me.Controls.Add(Me.lblcountTodaysVisits)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.fbnClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dashboard"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents fbnClose As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblTodayAppointments As System.Windows.Forms.Label
    Friend WithEvents lblPendingResults As System.Windows.Forms.Label
    Friend WithEvents lblLabResultsAlerts As System.Windows.Forms.Label
    Friend WithEvents tmrAlerts As System.Windows.Forms.Timer
    Friend WithEvents lblReadyRadiologyReports As System.Windows.Forms.Label
    Friend WithEvents lblPendingRadiology As System.Windows.Forms.Label
    Friend WithEvents lblWaitingVisits As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents lblTodayAdmissions As System.Windows.Forms.Label
    Friend WithEvents lblcountTodaysVisits As System.Windows.Forms.Label
    Friend WithEvents lblOverDueAdmissions As System.Windows.Forms.Label
    Friend WithEvents lblManualDebits As System.Windows.Forms.Label
    Friend WithEvents btnReload As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnManualDebits As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnOverDueAdmissions As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnTodaysVisit As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnTodayAdmissions As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnReadyRadiology As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnPendingRadiology As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnReadyLabResults As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnPendingLabResults As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnTodaysAppointment As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents btnWaitingVisits As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents fbnOPDUnpaidItems As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblOPDNotPaidItems As System.Windows.Forms.Label
    Friend WithEvents fbnAccountBalances As SyncSoft.Common.Win.Controls.FlatButton
    Friend WithEvents lblAccountBalances As System.Windows.Forms.Label
End Class
