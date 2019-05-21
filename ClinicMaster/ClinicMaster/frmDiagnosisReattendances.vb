Option Strict On

Imports SyncSoft.Common.Methods

Public Class frmDiagnosisReattendances

    Private Sub frmDiagnosisReattendances_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.dtpStartDate.MaxDate = Today()
            Me.dtpEndDate.MaxDate = Today()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oReports As New SyncSoft.SQLDb.Reports()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim startDate As Date = DateMayBeEnteredIn(Me.dtpStartDate)
            Dim endDate As Date = DateMayBeEnteredIn(Me.dtpEndDate)

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            Dim reports As DataTable = oReports.GetDiagnosisReoccurances(startDate, endDate).Tables("Reports")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim rowCount As Integer = Me.dgvOPDReattendances.RowCount

            LoadGridData(Me.dgvOPDReattendances, reports)
            FormatGridRow(Me.dgvOPDReattendances)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvOPDReattendances.RowCount <= 0 Then

                Dim Message As String = "No " + Me.tpgReattendances.Text + " record(s) found !"

                DisplayMessage(Message)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            FormatGridRow(Me.dgvOPDReattendances, Nothing, 3)
            Me.fbnExportTo.Enabled = reports.Rows.Count > 0
            Me.lblRecordsNo.Text = "Returned Reoccurance(s): " + reports.Rows.Count.ToString()

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