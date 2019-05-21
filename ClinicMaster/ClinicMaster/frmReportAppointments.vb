
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmReportAppointments

    Private Sub frmReportAppointments_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpStartDateTime.MaxDate = Today.AddDays(1)
            Me.dtpEndDateTime.MinDate = Today.AddDays(1)

            Me.dtpStartDateTime.Value = Now
            ' Me.dtpEndDateTime.Value = Now

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub ShowAppointmentsReports(ByVal StartDateTime As Date, ByVal endDateTime As Date)

        Dim oAppointments As New SyncSoft.SQLDb.Appointments
        Dim appointments As DataTable

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from appointments
            appointments = oAppointments.GetAppointmentReports(StartDateTime, endDateTime).Tables("Appointments")


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvAppointmentsReports, appointments)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDateTime(StartDateTime) + " and " + FormatDateTime(endDateTime) + "!"

            If appointments.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + appointments.Rows.Count.ToString()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim StartDateTime As Date = DateEnteredIn(Me.dtpStartDateTime, "Start Date")
            Dim EndDateTime As Date = DateEnteredIn(Me.dtpEndDateTime, "End Date")

            If EndDateTime < StartDateTime Then Throw New ArgumentException("End Date can't be before Start Date!")
            Me.ShowAppointmentsReports(StartDateTime, EndDateTime)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnExport_Click(sender As System.Object, e As System.EventArgs) Handles fbnExport.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            ExportToExcel(Me.dgvAppointmentsReports, Me.Text)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

   
End Class