Option Strict On

Imports SyncSoft.Common.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmDashboard

#Region "Fields"

    Private _PendingVisit As PendingVisit
    Private labResultsAlerts As DataTable
    Private RadiologyReportsAlerts As DataTable
    Private labRequestsAlerts As DataTable
    Private RadiologyRequestsAlerts As DataTable
    Private PathologyRequestsAlerts As DataTable
    Private PathologyReports As DataTable
    Private alertsStartDateTime As Date = Now
    Private alertCheckPeriod As Integer
    Private AlertsColor As Color = Color.Red
    Private NoAlertsColor As Color = Color.DarkBlue

#End Region

 

    Private Sub frmDashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        
        Try
            LoadAlerts()
        Catch
        End Try

    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadAlerts()
        Me.ShowTodayAppointmentsNo()
        Me.ShowLabRequestsAlertsNo()
        Me.ShowLabResultsAlertsNo()
        Me.ShowPendingRadiologyNo()
        Me.ShowRadiologyReportsAlertsNo()
        Me.ShowWaitingVisitsNo()
        Me.countTodaysVisits()
        Me.countTodayAdmissions()
        Me.GetcountOverStayedAdmission()
        Me.GetcountManualDebits()
        Me.ShowWaitingCashPayments()
        Me.GetCountPatientAccountBalances()
    End Sub

    Private Sub btnViewLabResultsList_Click(sender As System.Object, e As System.EventArgs)
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.LabResults)
        fAlerts.ShowDialog(Me)
    End Sub

    Private Sub btnLoadList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.LabRequests)
        fAlerts.ShowDialog(Me)
    End Sub

    Private Sub btnViewSelfRequestLabResults_Click(sender As Object, e As EventArgs)
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardLabSelfRequests()
        fAlerts.ShowDialog(Me)
    End Sub

    Private Sub btnViewSelfRequestRadiologyReports_Click(sender As Object, e As EventArgs)
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardRadiologySelfRequests()
        fAlerts.ShowDialog(Me)
    End Sub


#Region "Alerts"

    Private Function ShowLabRequestsAlertsNo() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            labRequestsAlerts = oAlerts.GetAlerts(oAlertTypeID.LabRequests).Tables("Alerts")

            Dim alertsNo As Integer = labRequestsAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''*************
            If alertsNo > 0 Then
                Me.lblPendingResults.ForeColor = AlertsColor
            Else
                Me.lblPendingResults.ForeColor = NoAlertsColor
            End If
            ''*************
            Me.lblPendingResults.Text = "Pending Lab Results: " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowLabResultsAlertsNo() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Alerts
            labResultsAlerts = oAlerts.GetAlerts(oAlertTypeID.LabResults).Tables("Alerts")

            Dim alertsNo As Integer = labResultsAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''*************
            If alertsNo > 0 Then
                Me.lblLabResultsAlerts.ForeColor = AlertsColor
            Else
                Me.lblLabResultsAlerts.ForeColor = NoAlertsColor
            End If
            ''*************
            Me.lblLabResultsAlerts.Text = "Ready Lab Results: " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowTodayAppointmentsNo() As Integer

        Dim oAppointments As New SyncSoft.SQLDb.Appointments()
        Dim dataSource As New DataTable()

        Try

            Me.Cursor = Cursors.WaitCursor

            dataSource = oAppointments.GetTodayAppointments().Tables("Appointments")

            Dim alertsNo As Integer = dataSource.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If alertsNo > 0 Then
                Me.lblTodayAppointments.ForeColor = AlertsColor
            Else
                Me.lblTodayAppointments.ForeColor = NoAlertsColor
            End If

            Me.lblTodayAppointments.Text = "Today's Appointments: " + alertsNo.ToString()
            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Function

    Private Function ShowPendingRadiologyNo() As Integer
        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            RadiologyRequestsAlerts = oAlerts.GetAlerts(oAlertTypeID.Radiology).Tables("Alerts")

            Dim alertsNo As Integer = RadiologyRequestsAlerts.Rows.Count
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If alertsNo > 0 Then
                Me.lblPendingRadiology.ForeColor = AlertsColor
            Else
                Me.lblPendingRadiology.ForeColor = NoAlertsColor
            End If

            Me.lblPendingRadiology.Text = "Pending Radiology Reports: " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Function

    Private Function ShowRadiologyReportsAlertsNo() As Integer

        Dim oAlerts As New SyncSoft.SQLDb.Alerts()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Alerts
            RadiologyReportsAlerts = oAlerts.GetAlerts(oAlertTypeID.RadiologyReports).Tables("Alerts")

            Dim alertsNo As Integer = RadiologyReportsAlerts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''*************
            If alertsNo > 0 Then
                Me.lblReadyRadiologyReports.ForeColor = AlertsColor
            Else
                Me.lblReadyRadiologyReports.ForeColor = NoAlertsColor
            End If
            ''*************
            Me.lblReadyRadiologyReports.Text = "Ready Radiology Reports: " + alertsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return alertsNo

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function ShowWaitingVisitsNo() As Integer

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from visits
            Dim visits As DataTable = oVisits.GetWaitingVisits().Tables("Visits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim waitingNo As Integer = visits.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''*************
            If waitingNo > 0 Then
                Me.lblWaitingVisits.ForeColor = AlertsColor
            Else
                Me.lblWaitingVisits.ForeColor = NoAlertsColor
            End If
            ''*************
            Me.lblWaitingVisits.Text = "Waiting Visits: " + waitingNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return waitingNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function countTodaysVisits() As Integer

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from visits
            Dim visits As DataTable = oVisits.GetCountTodaysVisits().Tables("Visits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim waitingNo As Integer = visits.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If waitingNo > 0 Then
                Me.lblWaitingVisits.ForeColor = AlertsColor
            Else
                Me.lblWaitingVisits.ForeColor = NoAlertsColor
            End If

            Me.lblcountTodaysVisits.Text = "Today's Visits: " + waitingNo.ToString()

              Return waitingNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function countTodayAdmissions() As Integer

        Dim oVisits As New SyncSoft.SQLDb.Admissions()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from visits
            Dim admissions As DataTable = oVisits.GetTodaysAdmissions().Tables("Admissions")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim waitingNo As Integer = admissions.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If waitingNo > 0 Then
                Me.lblTodayAdmissions.ForeColor = AlertsColor
            Else
                Me.lblTodayAdmissions.ForeColor = NoAlertsColor
            End If

            Me.lblTodayAdmissions.Text = "Today's Admissions: " + waitingNo.ToString()

            Return waitingNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function GetcountOverStayedAdmission() As Integer

        Dim oVisits As New SyncSoft.SQLDb.Admissions()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from visits
            Dim admissions As DataTable = oVisits.GetcountOverStayedAdmission().Tables("Admissions")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim waitingNo As Integer = admissions.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If waitingNo > 0 Then
                Me.lblOverDueAdmissions.ForeColor = AlertsColor
            Else
                Me.lblOverDueAdmissions.ForeColor = NoAlertsColor
            End If

            Me.lblOverDueAdmissions.Text = "Over Due Admissions : " + waitingNo.ToString()

            Return waitingNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function GetcountManualDebits() As Integer


        Dim oAccounts As New SyncSoft.SQLDb.Accounts()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = Today.AddDays(-1)
            Dim endDate As Date = Today.AddDays(+1)


            ' Load from Accounts

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim waitingNo As Integer = oAccounts.GetCountDashboardManualDebits(startDate, endDate)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If waitingNo > 0 Then
                Me.lblManualDebits.ForeColor = AlertsColor
            Else
                Me.lblManualDebits.ForeColor = NoAlertsColor
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblManualDebits.Text = "Manual Debits : " + waitingNo.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return waitingNo
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function


    Private Function ShowWaitingCashPayments() As Integer

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = Today.AddDays(-1)
            Dim endDate As Date = Today.AddDays(+1)


            ' Load from Items

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim waitingNo As Integer = oItems.GetCountBillsExceedingAllocatedValue(startDate, endDate)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If waitingNo > 0 Then
                Me.lblOPDNotPaidItems.ForeColor = AlertsColor
            Else
                Me.lblOPDNotPaidItems.ForeColor = NoAlertsColor
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblOPDNotPaidItems.Text = "OPD Unpaid Items: " + waitingNo.ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            alertsStartDateTime = Now

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return waitingNo
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

#End Region



    Private Sub btnLoadRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.RadiologyReports)
        fAlerts.ShowDialog(Me)
    End Sub

    Private Sub btnPendingRadiologyReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.Radiology)
        fAlerts.ShowDialog(Me)
    End Sub

    Private Sub tmrAlerts_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrAlerts.Tick
        Try
            Me.ShowTodayAppointmentsNo()
            Me.ShowLabRequestsAlertsNo()
            Me.ShowLabResultsAlertsNo()
            Me.ShowPendingRadiologyNo()
            Me.ShowRadiologyReportsAlertsNo()
            Me.ShowWaitingVisitsNo()
            Me.countTodaysVisits()
            Me.countTodayAdmissions()
            Me.GetcountOverStayedAdmission()
        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Sub frmDashboard_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            Me.tmrAlerts.Stop()
        Catch
        End Try
    End Sub



    Private Sub lblTodayAdmissions_Click(sender As System.Object, e As System.EventArgs) Handles lblTodayAdmissions.Click
        Try
            Dim fWaitingAdmissions As New frmDashBoardAdmissions()
            fWaitingAdmissions.ShowDialog(Me)
        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub


    Private Sub lblWaitingVisits_Click(sender As System.Object, e As System.EventArgs) Handles lblWaitingVisits.Click

        Try
            Dim fWaitingVisits As New frmDashboardWaitingVisits()
            fWaitingVisits.ShowDialog(Me)
        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub


    Private Sub lblTodayAppointments_Click(sender As System.Object, e As System.EventArgs) Handles lblTodayAppointments.Click
        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fTodayAppointments As New frmTodayAppointments(False)
            fTodayAppointments.ShowDialog(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub lblPendingResults_Click(sender As System.Object, e As System.EventArgs) Handles lblPendingResults.Click
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.LabRequests)
        fAlerts.ShowDialog(Me)
    End Sub




    Private Sub lblLabResultsAlerts_Click(sender As System.Object, e As System.EventArgs) Handles lblLabResultsAlerts.Click
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.LabResults)
        fAlerts.ShowDialog(Me)
    End Sub

    Private Sub lblPendingRadiology_Click(sender As System.Object, e As System.EventArgs) Handles lblPendingRadiology.Click
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.Radiology)
        fAlerts.ShowDialog(Me)
    End Sub


    Private Sub lblReadyRadiologyReports_Click(sender As System.Object, e As System.EventArgs) Handles lblReadyRadiologyReports.Click
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.RadiologyReports)
        fAlerts.ShowDialog(Me)
    End Sub



    Private Sub btnManualDebits_Click(sender As System.Object, e As System.EventArgs) Handles btnManualDebits.Click
        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fDashboardManualDeposits As New frmDashboardManualDeposits
            fDashboardManualDeposits.ShowDialog(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub btnOverDueAdmissions_Click(sender As System.Object, e As System.EventArgs) Handles btnOverDueAdmissions.Click
        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fDashboardOverDueAdmissions As New frmDashboardOverDueAdmissions
            fDashboardOverDueAdmissions.ShowDialog(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub btnTodaysVisit_Click(sender As System.Object, e As System.EventArgs) Handles btnTodaysVisit.Click
        Try
            Dim fWaitingVisits As New frmDashboardVisits()
            fWaitingVisits.ShowDialog(Me)
        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub btnTodayAdmissions_Click(sender As System.Object, e As System.EventArgs) Handles btnTodayAdmissions.Click
        Try
            Dim fWaitingAdmissions As New frmDashBoardAdmissions()
            fWaitingAdmissions.ShowDialog(Me)
        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub btnReadyRadiology_Click(sender As System.Object, e As System.EventArgs) Handles btnReadyRadiology.Click
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.RadiologyReports)
        fAlerts.ShowDialog(Me)
    End Sub

    Private Sub btnPendingRadiology_Click(sender As System.Object, e As System.EventArgs) Handles btnPendingRadiology.Click
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.Radiology)
        fAlerts.ShowDialog(Me)
    End Sub

    Private Sub btnReadyLabResults_Click(sender As System.Object, e As System.EventArgs) Handles btnReadyLabResults.Click
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.LabResults)
        fAlerts.ShowDialog(Me)
    End Sub

    Private Sub btnPendingLabResults_Click(sender As System.Object, e As System.EventArgs) Handles btnPendingLabResults.Click
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim fAlerts As New frmDashboardAlerts(oAlertTypeID.LabRequests)
        fAlerts.ShowDialog(Me)
    End Sub

    Private Sub btnTodaysAppointment_Click(sender As System.Object, e As System.EventArgs) Handles btnTodaysAppointment.Click
        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fTodayAppointments As New frmTodayAppointments(False)
            fTodayAppointments.ShowDialog(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub btnWaitingVisits_Click(sender As System.Object, e As System.EventArgs) Handles btnWaitingVisits.Click
        Try
            Dim fWaitingVisits As New frmDashboardWaitingVisits()
            fWaitingVisits.ShowDialog(Me)
        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

    Private Sub btnReload_Click(sender As System.Object, e As System.EventArgs) Handles btnReload.Click
        Try
            LoadAlerts()
        Catch
        End Try
    End Sub


    Private Sub fbnOPDUnpaidItems_Click(sender As System.Object, e As System.EventArgs) Handles fbnOPDUnpaidItems.Click
        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fBillsExceedingAllocatedValue As New frmBillsExceedingAllocatedValue()
            fBillsExceedingAllocatedValue.ShowDialog(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub fbnAccountBalances_Click(sender As System.Object, e As System.EventArgs) Handles fbnAccountBalances.Click
        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fBillsExceedingAllocatedValue As New frmAccountsBalances()
            fBillsExceedingAllocatedValue.ShowDialog(Me)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub


    Private Function GetCountPatientAccountBalances() As Integer

        Dim oAccounts As New SyncSoft.SQLDb.Accounts()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Patients
            Dim accounts As DataTable = oAccounts.GetCountPatientAccountBalances().Tables("Patients")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim waitingNo As Integer = accounts.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If waitingNo > 0 Then
                Me.lblAccountBalances.ForeColor = AlertsColor
            Else
                Me.lblAccountBalances.ForeColor = NoAlertsColor
            End If

            Me.lblAccountBalances.Text = "Account Balances : " + waitingNo.ToString()

            Return waitingNo
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function
End Class