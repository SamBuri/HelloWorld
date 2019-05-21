Option Strict On

Imports SyncSoft.Common.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmBillsExceedingAllocatedValue

    Private Sub frmBillsExceedingAllocatedValue_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.ShowPendingPayments(Today.AddDays(-1), Today.AddDays(+1))


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub


    Private Sub ShowPendingPayments(ByVal startDateTime As Nullable(Of DateTime), ByVal endDateTime As Nullable(Of DateTime))

        Dim billsExceeding As DataTable
        Dim obillsExceeding As New SyncSoft.SQLDb.Items()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from billsExceeding

            If (startDateTime IsNot Nothing) And (endDateTime IsNot Nothing) Then
                billsExceeding = obillsExceeding.GetBillsExceedingAllocatedValue(startDateTime, endDateTime).Tables("Items")
            Else : billsExceeding = obillsExceeding.GetBillsExceedingAllocatedValue().Tables("Items")
            End If




            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillsPendingPayments, billsExceeding)

            Dim message As String

            Select Case True
                Case Me.dtpStartDate.Checked = True And Me.dtpStartDate.Checked = True
                    message = "No " + Me.Text + " record(s) found for period between " _
                                + FormatDateTime(CDate(startDateTime)) + " and " + FormatDateTime(CDate(endDateTime)) + "!"
                Case Me.dtpStartDate.Checked = False And Me.dtpStartDate.Checked = False
                    message = "No " + Me.Text + " record(s) found for all period!"
                Case Else : message = "No " + Me.Text + " record(s) found!"
            End Select

            If billsExceeding.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + billsExceeding.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnLoad_Click(sender As System.Object, e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case True

                Case Me.dtpStartDate.Checked = True And Me.dtpStartDate.Checked = True
                    Dim startDate As Date = DateTimeEnteredIn(Me.dtpStartDate, "Start Date")
                    Dim endDate As Date = DateTimeEnteredIn(Me.dtpEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
                    Me.ShowPendingPayments(startDate, endDate)


                Case Me.dtpStartDate.Checked = False And Me.dtpStartDate.Checked = False

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim message As String = "This action may take awhile to complete if you have many " + Me.Text + "." _
                                            + ControlChars.NewLine + "Are you sure you want to load all?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowPendingPayments(Nothing, Nothing)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

  
    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvBillsPendingPayments.ColumnCount < 1 OrElse Me.dgvBillsPendingPayments.RowCount < 1 Then
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

            If Me.dgvBillsPendingPayments.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvBillsPendingPayments))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvBillsPendingPayments.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class