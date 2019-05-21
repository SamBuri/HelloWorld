
Option Strict On
Imports SyncSoft.Common.Methods

Public Class frmToSeeVisitsPerDoctor

#Region " Fields "
    Private _staffNo As String
    Private _startDateTime As Nullable(Of DateTime)
    Private _endDateTime As Nullable(Of DateTime)
#End Region

    Private Sub frmToSeeVisitsPerDoctor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "To See Visits Per Doctor."

            Me.ShowVisitsPerDoctor(_staffNo, _startDateTime, _endDateTime)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub ShowVisitsPerDoctor(ByVal staffNo As String, ByVal startDateTime As Nullable(Of DateTime), ByVal endDateTime As Nullable(Of DateTime))

        Dim visits As DataTable
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Visits
            If (startDateTime IsNot Nothing) And (endDateTime IsNot Nothing) Then
                visits = oVisits.GetDoctorVisitsPerDoctor(staffNo, startDateTime, endDateTime).Tables("Visits")
            Else : visits = oVisits.GetDoctorVisitsPerDoctor(staffNo, Nothing, Nothing).Tables("Visits")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgDoctorVisitsPerDoctor, visits)

            Dim message As String

            Select Case True
                Case (startDateTime IsNot Nothing) And (endDateTime IsNot Nothing)
                    visits = oVisits.GetDoctorVisitsPerDoctor(staffNo, startDateTime, endDateTime).Tables("Visits")
                    message = "No " + Me.Text + " record(s) found for period between " _
                                + FormatDate(CDate(startDateTime)) + " and " + FormatDate(CDate(endDateTime)) + "!"
                Case (startDateTime IsNot Nothing) And (endDateTime IsNot Nothing)
                    visits = oVisits.GetDoctorVisitsPerDoctor(staffNo, startDateTime, endDateTime).Tables("Visits")
                    message = "No " + Me.Text + " record(s) found for all period!"
                Case Else : message = "No " + Me.Text + " record(s) found!"
            End Select

            If visits.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + visits.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub fbnClose_Click(sender As Object, e As EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgDoctorVisitsPerDoctor.ColumnCount < 1 OrElse Me.dgDoctorVisitsPerDoctor.RowCount < 1 Then
            Me.cmsAlertListCopy.Enabled = False
            Me.cmsAlertListSelectAll.Enabled = False
        Else
            Me.cmsAlertListCopy.Enabled = True
            Me.cmsAlertListSelectAll.Enabled = True
        End If

    End Sub

    Private Sub cmsAlertListCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListCopy.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgDoctorVisitsPerDoctor.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgDoctorVisitsPerDoctor))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgDoctorVisitsPerDoctor.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub





End Class