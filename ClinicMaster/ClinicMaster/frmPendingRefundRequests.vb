
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls

Public Class frmPendingRefundRequests

#Region " Fields "
    Dim alertNoControl As Control
    Dim isFinalAppoval As Boolean
#End Region



    Private Sub frmPendingRefundRequests_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            ShowPendingRefundRequest()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmPendingRefundRequests_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub


    Private Sub fbnClose_Click(sender As System.Object, e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ShowPendingRefundRequest()


        Dim oRefundRequests As New SyncSoft.SQLDb.RefundRequests()
        Dim oItemStatusID As New SyncSoft.SQLDb.Lookup.LookupDataID.ItemStatusID()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim pendingRefundRequests As DataTable = New DataTable

            If Me.isFinalAppoval Then
                pendingRefundRequests = oRefundRequests.GetToApproveRefundRequests(String.Empty).Tables("RefundRequests")


            Else
                pendingRefundRequests = oRefundRequests.GetToRefundRequests(String.Empty).Tables("RefundRequests")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPendingRefunds, pendingRefundRequests)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblReturnedRecords.Text = " Returned Record(s): " + pendingRefundRequests.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub dgvPendingRefunds_CellDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendingRefunds.CellDoubleClick
        Try

            Dim receiptRequestNo As String = Me.dgvPendingRefunds.Item(Me.coRefundRequestNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = receiptRequestNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = receiptRequestNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = receiptRequestNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try
    End Sub
End Class