Imports SyncSoft.Common.Methods
Public Class frmDashboardVisits

    Private Sub frmDashboardVisits_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowtodaysVisits()
    End Sub


    Private Sub ShowtodaysVisits()
        Dim todaysVisits As DataTable
        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Try
            Me.Cursor = Cursors.WaitCursor

            todaysVisits = oVisits.GetTodaysVisits().Tables("Visits")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDashBoardVisits, todaysVisits)

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