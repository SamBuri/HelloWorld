Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmPendingStaffPayments

#Region " Fields "
    Private alertNoControl As Control
    Private _ApprovalState As Boolean
    Private _visitTypeID As String = String.Empty
    Private pendingItemCategory As AlertItemCategory
#End Region

    Private Sub frmPendingStaffPayments_Load(sender As Object, e As EventArgs) Handles MyBase.Load

  
        Try
            Me.Cursor = Cursors.Default
            Select Case _ApprovalState
                Case True
                    Me.ShowPendingStaffPayments()
                    Me.grpSetParameters.Visible = False
                Case False
                    Me.grpSetParameters.Visible = True
                   
            End Select

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowPendingStaffPayments()
       
        Dim PendingStaffPayments As DataTable
        Dim oStaffPayments As New SyncSoft.SQLDb.StaffPayments()

            Try
                Me.Cursor = Cursors.WaitCursor

            PendingStaffPayments = oStaffPayments.GetPendingStaffPayments().Tables("StaffPayments")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvVoucherDetails, PendingStaffPayments)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblRecordsNo.Text = " Returned Record(s): " + PendingStaffPayments.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Catch ex As Exception
                ErrorMessage(ex)
            Finally
                Me.Cursor = Cursors.Default

            End Try
    End Sub

    Private Sub fbnClose_Click(sender As Object, e As EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub dgvVoucherDetails_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvVoucherDetails.CellDoubleClick

        Try

            Dim visitNo As String = Me.dgvVoucherDetails.Item(Me.colPaymentVoucherNo.Name, e.RowIndex).Value.ToString()

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

    Private Sub fbnLoad_Click(sender As Object, e As EventArgs) Handles fbnLoad.Click

        Dim PeriodicPendingStaffPayments As DataTable
        Dim oStaffPayments As New SyncSoft.SQLDb.StaffPayments()
        Dim oVisitTypeID As New LookupDataID.VisitTypeID

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim startDateTime As Date = DateTimeEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDateTime As Date = DateTimeEnteredIn(Me.dtpEndDate, "End Date")


            If (_visitTypeID = oVisitTypeID.OutPatient) Then

                PeriodicPendingStaffPayments = oStaffPayments.GetPeriodicPendingStaffPayments(startDateTime, endDateTime, oVisitTypeID.OutPatient).Tables("StaffPayments")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                LoadGridData(Me.dgvVoucherDetails, PeriodicPendingStaffPayments)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.lblRecordsNo.Text = " Returned Record(s): " + PeriodicPendingStaffPayments.Rows.Count.ToString()
            ElseIf (_visitTypeID = oVisitTypeID.InPatient) Then

                PeriodicPendingStaffPayments = oStaffPayments.GetPeriodicPendingStaffPayments(startDateTime, endDateTime, oVisitTypeID.InPatient).Tables("StaffPayments")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                LoadGridData(Me.dgvVoucherDetails, PeriodicPendingStaffPayments)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.lblRecordsNo.Text = " Returned Record(s): " + PeriodicPendingStaffPayments.Rows.Count.ToString()
            End If



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try
      
    End Sub
End Class