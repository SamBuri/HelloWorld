Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmPendingAllLabResults

#Region " Fields "
    Private alertNoControl As Control
    Private visitNo As String
    Private tokenNo As String
    Private patientNo As String
    Private firstName As String
#End Region

    Private Sub frmPendingAllLabResults_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Pending Laboratory Results"


            Me.dtpStartDateTime.Value = Today
            Me.dtpEndDateTime.Value = Now

            Me.fbnLoad.PerformClick()
            fbnCall.Visible = IsQueueEnabled()
            colTokenNo.Visible = IsQueueEnabled()
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub
    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDate As Date = DateTimeEnteredIn(Me.dtpStartDateTime, "Start Date")
            Dim endDate As Date = DateTimeEnteredIn(Me.dtpEndDateTime, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            Me.ShowPendingLabResults(startDate, endDate)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPendingLabResults(ByVal startDate As Date, ByVal endDate As Date)

        Dim oLabRequestDetails As New SyncSoft.SQLDb.LabRequestDetails()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from LabRequestDetails
            Dim labRequestDetails As DataTable = oLabRequestDetails.GetAllPendingLabResults(startDate, endDate).Tables("LabRequestDetails")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPendingLabResults, labRequestDetails)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " +
                FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

            If labRequestDetails.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + labRequestDetails.Rows.Count.ToString()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPendingLabResults_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendingLabResults.CellDoubleClick

        Try

            Dim specimenNo As String = Me.dgvPendingLabResults.Item(Me.colSpecimenNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = specimenNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = specimenNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = specimenNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvPendingLabResults.ColumnCount < 1 OrElse Me.dgvPendingLabResults.RowCount < 1 Then
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

            If Me.dgvPendingLabResults.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvPendingLabResults))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvPendingLabResults.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub dgvPendingLabResults_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPendingLabResults.CellClick



        Try
            If e.RowIndex > 0 Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.visitNo = StringMayBeEnteredIn(Me.dgvPendingLabResults.Rows(e.RowIndex).Cells, Me.colVisitNo)
            Me.patientNo = StringMayBeEnteredIn(Me.dgvPendingLabResults.Rows(e.RowIndex).Cells, Me.colPatientNo)
            Me.tokenNo = StringMayBeEnteredIn(Me.dgvPendingLabResults.Rows(e.RowIndex).Cells, Me.colTokenNo)
            Me.firstName = StringMayBeEnteredIn(Me.dgvPendingLabResults.Rows(e.RowIndex).Cells, Me.colFirstName)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            fbnCall.Enabled = e.RowIndex >= 0 AndAlso Not String.IsNullOrEmpty(tokenNo)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fbnCall_Click(sender As Object, e As EventArgs) Handles fbnCall.Click
        Try

            If (String.IsNullOrEmpty(visitNo) OrElse String.IsNullOrEmpty(tokenNo)) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oServicePointID As New LookupDataID.ServicePointID()


            SaveQueuedMessage(visitNo, oServicePointID.Laboratory, tokenNo, 0)

        Catch ex As Exception
            ErrorMessage(ex)
            Return
        End Try
    End Sub

End Class