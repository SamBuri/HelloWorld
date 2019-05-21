Imports SyncSoft.Common.Methods

Public Class frmDashboardLabSelfRequests
    Private Sub frmDashboardLabSelfRequests_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowSelfRequestLabResults()
    End Sub

    Private Sub ShowSelfRequestLabResults()
        Dim SelfRequestLabResults As DataTable
        Dim oLabResults As New SyncSoft.SQLDb.LabResults()
        Try
            Me.Cursor = Cursors.WaitCursor

            SelfRequestLabResults = oLabResults.GetDoneSelfRequestLabResults(String.Empty).Tables("LabResults")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvSelftRequestLabResults, SelfRequestLabResults)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

End Class