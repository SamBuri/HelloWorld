
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmPayingVisits

#Region " Fields "
    Private alertNoControl As Control
#End Region

    Private Sub frmPayingVisits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.Text = "Paying Visits"

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today

            Me.ShowPayingVisits(Today, Today)

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
            Me.ShowPayingVisits(startDate, endDate)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPayingVisits(ByVal startDate As Date, ByVal endDate As Date)

        Dim visits As DataTable
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Visits
            visits = oVisits.GetPayingVisits(startDate, endDate).Tables("Visits")
           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPayingVisits, visits)

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

    Private Sub dgvPayingVisits_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPayingVisits.CellDoubleClick

        Try

            Dim visitNo As String = Me.dgvPayingVisits.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

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

        If Me.dgvPayingVisits.ColumnCount < 1 OrElse Me.dgvPayingVisits.RowCount < 1 Then
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

            If Me.dgvPayingVisits.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvPayingVisits))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvPayingVisits.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class