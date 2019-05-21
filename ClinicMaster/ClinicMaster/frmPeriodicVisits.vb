
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmPeriodicVisits

#Region " Fields "
    Private alertNoControl As Control
    Private visitNo As String
    Private patientNo As String
    Private tokenNo As String
    Private firstName As String
#End Region

    Private Sub frmPeriodicVisits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Periodic Visits"

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today

            Me.ShowPeriodicVisits(Today, Today)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnCall.Visible = IsQueueEnabled()
            Me.colTokenNo.Visible = IsQueueEnabled()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
            Me.ShowPeriodicVisits(startDate, endDate)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPeriodicVisits(ByVal startDate As Date, ByVal endDate As Date)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Visits
            Dim visits As DataTable = oVisits.GetPeriodicVisits(startDate, endDate).Tables("Visits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPeriodicVisits, visits)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " _
                                    + FormatDate(startDate) + " and " + FormatDate(endDate) + "!"

            If visits.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + visits.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPeriodicVisits_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodicVisits.CellDoubleClick

        Try

            Dim visitNo As String = Me.dgvPeriodicVisits.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = visitNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = visitNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = visitNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvPeriodicVisits.ColumnCount < 1 OrElse Me.dgvPeriodicVisits.RowCount < 1 Then
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

            If Me.dgvPeriodicVisits.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvPeriodicVisits))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvPeriodicVisits.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub dgvPeriodicVisits_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPeriodicVisits.CellClick
        Try
            If e.RowIndex < 0 Then Return
            Me.visitNo = RevertText(StringMayBeEnteredIn(Me.dgvPeriodicVisits.Rows(e.RowIndex).Cells, Me.colVisitNo))
            Me.patientNo = StringMayBeEnteredIn(Me.dgvPeriodicVisits.Rows(e.RowIndex).Cells, Me.colPatientNo)
            Me.tokenNo = StringMayBeEnteredIn(Me.dgvPeriodicVisits.Rows(e.RowIndex).Cells, Me.colTokenNo)
            Me.firstName = StringMayBeEnteredIn(Me.dgvPeriodicVisits.Rows(e.RowIndex).Cells, Me.colFirstName)
            fbnCall.Enabled = e.RowIndex >= 0 AndAlso Not String.IsNullOrEmpty(tokenNo)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub fbnCall_Click(sender As Object, e As EventArgs) Handles fbnCall.Click
        Try

            If (String.IsNullOrEmpty(visitNo) OrElse String.IsNullOrEmpty(tokenNo)) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oServicePointID As New LookupDataID.ServicePointID()

            SaveQueuedMessage(visitNo, oServicePointID.Triage(), tokenNo, 0)

        Catch ex As Exception
            Return
        End Try
    End Sub

   
    Private Sub lblMessage_Click(sender As System.Object, e As System.EventArgs) Handles lblMessage.Click

    End Sub
    Private Sub grpSetParameters_Enter(sender As System.Object, e As System.EventArgs) Handles grpSetParameters.Enter

    End Sub
    Private Sub dgvPeriodicVisits_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPeriodicVisits.CellContentClick

    End Sub
End Class