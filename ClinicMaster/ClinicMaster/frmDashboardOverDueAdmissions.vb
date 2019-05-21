Imports SyncSoft.Common.Methods

Public Class frmDashboardOverDueAdmissions

    Private Sub frmDashboardOverDueAdmissions_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ShowOverStayedAdmissions()
    End Sub

    Private Sub ShowOverStayedAdmissions()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Try
            Me.Cursor = Cursors.WaitCursor
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oGetOverStayedAdmissions As DataTable = oAdmissions.GetOverStayedAdmissions().Tables("Admissions")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOverDueAdmissions, oGetOverStayedAdmissions)
            FormatGridRow(Me.dgvOverDueAdmissions)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnExport_Click(sender As System.Object, e As System.EventArgs) Handles fbnExport.Click
        ExportToExcel(Me.dgvOverDueAdmissions, Me.Text)
    End Sub
End Class