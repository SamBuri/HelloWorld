Imports SyncSoft.Common.Methods

Public Class frmDashboardRadiologySelfRequests
    Private Sub frmDashboardLabSelfRequests_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowSelfRequestRadReports()
    End Sub

    Private Sub ShowSelfRequestRadReports()
        Dim SelfRequestRadReports As DataTable
        Dim oRadiologyReports As New SyncSoft.SQLDb.RadiologyReports()
        Try
            Me.Cursor = Cursors.WaitCursor

            SelfRequestRadReports = oRadiologyReports.GetSelfRequestRadiologyReports(String.Empty).Tables("RadiologyReports")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvSelftRequestRadReports, SelfRequestRadReports)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class