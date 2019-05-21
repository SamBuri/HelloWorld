
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmLabResultsNotApproved

#Region " Fields "
    Private alertNoControl As Control
#End Region

    Private Sub frmLabResultsNotApproved_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpStartDate.MaxDate = Today
            Me.dtpStartDate.Value = Today.AddDays(-1)

            Me.dtpEndDate.MaxDate = Today
            Me.dtpEndDate.Value = Today

            Me.ShowDoneLabResults(Today.AddDays(-1), Today)

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
            Me.ShowDoneLabResults(startDate, endDate)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowDoneLabResults(ByVal startDate As Date, ByVal endDate As Date)

        Dim labResults As DataTable
        Dim oLabResults As New SyncSoft.SQLDb.LabResults()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from LabResults
            labResults = oLabResults.GetUnApprovedDoneLabResults(startDate, endDate).Tables("LabResults")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvUnApprovedLabResults, labResults)

            Dim message As String = "No " + Me.Text + " record(s) found for period between " _
                        + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

            If labResults.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblDoneLabResultsNo.Text = " Returned Record(s): " + labResults.Rows.Count.ToString()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDoneLabResults_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUnApprovedLabResults.CellDoubleClick

        Try

            Dim specimenNo As String = Me.dgvUnApprovedLabResults.Item(Me.colSpecimenNo.Name, e.RowIndex).Value.ToString()

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

        If Me.dgvUnApprovedLabResults.ColumnCount < 1 OrElse Me.dgvUnApprovedLabResults.RowCount < 1 Then
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

            If Me.dgvUnApprovedLabResults.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvUnApprovedLabResults))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvUnApprovedLabResults.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class