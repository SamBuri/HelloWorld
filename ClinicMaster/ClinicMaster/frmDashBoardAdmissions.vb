Imports SyncSoft.Common.Methods
Public Class frmDashBoardAdmissions

    Private Sub frmDashBoardAdmissions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowtodaysAdmissions()
    End Sub

    Private Sub ShowtodaysAdmissions()
        Dim todaysVisits As DataTable
        Dim oVisits As New SyncSoft.SQLDb.Admissions()
        Try
            Me.Cursor = Cursors.WaitCursor

            todaysVisits = oVisits.GetTodaysAdmissions.Tables("Admissions")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInWardAdmissions, todaysVisits)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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