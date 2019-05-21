
Option Strict On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Win.Controls


Public Class frmPeriodicReturnedExtraBillItems


#Region " Fields "
    Private _VisitState As Boolean = True
    Private alertNoControl As Control
    Private oVariousOptions As New VariousOptions()
#End Region

    Private Sub frmPeriodicReturnedExtraBillItems_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor()
            Dim InventoryAlertDays As Integer = oVariousOptions.InventoryAlertDays
            Select Case _VisitState
                Case True
                    Me.colExtraBillNo.HeaderText = "ExtraBill No"
                    Me.colExtraBillNo.DataPropertyName = "ExtraBillNo"
                    Me.Text = "Periodic Returned Extra Bill Items"

                Case False

                    Me.colExtraBillNo.HeaderText = "Visit No"
                    Me.colExtraBillNo.DataPropertyName = "VisitNo"
                    Me.colDrugEntryMode.DataPropertyName = Nothing
                    Me.colDrugEntryMode.Visible = False
                    Me.Text = "Periodic Returned Items"
            End Select



            Me.dtpStartDate.MaxDate = Today
            Me.dtpStartDate.Value = Today.AddDays(-InventoryAlertDays)

            Me.dtpEndDate.MaxDate = Today
            'Me.dtpEndDate.Value = Today.AddDays(1)

            Me.ShowPeriodicReturnedExtraBillItems(Today.AddDays(-InventoryAlertDays), Today)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

        
    End Sub

    Private Sub fbnClose_Click(sender As Object, e As EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnLoad_Click(sender As Object, e As EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor
            Me.lblRecordsNo.Text = Nothing
            ResetControlsIn(pnlReturnedExtraBillItems)

            Select Case True

                Case Me.rdoGetPeriod.Checked
                    Dim startDate As DateTime = DateEnteredIn(Me.dtpStartDate, "Start Date")
                    Dim endDate As DateTime = DateEnteredIn(Me.dtpEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
                    'Me.ShowPendingItems(startDate, endDate)
                    'Dim startDate As Date = DateTimeEnteredIn(Me.dtpStartDate, "Start Date")
                    'Dim endDate As Date = DateTimeEnteredIn(Me.dtpEndDate, "End Date")

                        If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
                        Me.ShowPeriodicReturnedExtraBillItems(startDate, endDate)


                Case Me.rdoGetAll.Checked

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim message As String = "This action may take awhile to complete if you have many pending or processing " + Me.Text + "." +
                                            ControlChars.NewLine + "Are you sure you want to load all?"

                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Me.ShowPendingItems(Nothing, Nothing)
                    Me.ShowPeriodicReturnedExtraBillItems(Nothing, Nothing)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub rdoGetPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGetPeriod.CheckedChanged
        If Me.rdoGetPeriod.Checked Then EnablePeriodCTLS(True)
    End Sub

    Private Sub rdoGetAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGetAll.CheckedChanged
        If Me.rdoGetAll.Checked Then EnablePeriodCTLS(False)
    End Sub

    Private Sub EnablePeriodCTLS(ByVal state As Boolean)
        Try
            Me.Cursor = Cursors.WaitCursor
            Me.pnlPeriod.Enabled = state
            If state Then
                Me.dtpStartDate.Value = Today.AddDays(-1)
                Me.dtpEndDate.Value = Today
                Me.dtpStartDate.Checked = True
                Me.dtpEndDate.Checked = True
            Else : ResetControlsIn(Me.pnlPeriod)
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub



    Private Sub ShowPeriodicReturnedExtraBillItems(ByVal startDate As Nullable(Of Date), ByVal endDate As Nullable(Of Date))

        Dim oExtraBillItemAdjustments As New SyncSoft.SQLDb.ExtraBillItemAdjustments()
        Dim oItemAdjustments As New SyncSoft.SQLDb.ItemAdjustments()

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case _VisitState
                Case True
                    If (startDate IsNot Nothing) And (endDate IsNot Nothing) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Dim pendingReturnedExtraBillItems As DataTable = oExtraBillItemAdjustments.GetPeriodicToAckwnoledgeExtraBillItems(startDate, endDate).Tables("ExtraBillItemAdjustments")

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If pendingReturnedExtraBillItems Is Nothing OrElse pendingReturnedExtraBillItems.Rows.Count < 1 Then Return

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        LoadGridData(Me.dgvReturnedExtraBillItems, pendingReturnedExtraBillItems)
                        Dim message As String = "No " + Me.Text + " record(s) found for period between " + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

                        If pendingReturnedExtraBillItems.Rows.Count < 1 Then DisplayMessage(message)
                        Me.lblRecordsNo.Text = " Returned Record(s): " + pendingReturnedExtraBillItems.Rows.Count.ToString()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else
                        Dim pendingReturnedExtraBillItems As DataTable = oExtraBillItemAdjustments.GetPeriodicToAckwnoledgeExtraBillItems().Tables("ExtraBillItemAdjustments")

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If pendingReturnedExtraBillItems Is Nothing OrElse pendingReturnedExtraBillItems.Rows.Count < 1 Then Return

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        LoadGridData(Me.dgvReturnedExtraBillItems, pendingReturnedExtraBillItems)

                        Me.lblRecordsNo.Text = " Returned Record(s): " + pendingReturnedExtraBillItems.Rows.Count.ToString()
                    End If

                Case False
                    If (startDate IsNot Nothing) And (endDate IsNot Nothing) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim pendingReturnedItems As DataTable = oItemAdjustments.GetPeriodicToAcknowledgeItemAdjustments(startDate, endDate).Tables("ItemAdjustments")

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If pendingReturnedItems Is Nothing OrElse pendingReturnedItems.Rows.Count < 1 Then Return
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        LoadGridData(Me.dgvReturnedExtraBillItems, pendingReturnedItems)
                        Dim message As String = "No " + Me.Text + " record(s) found for period between " + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

                        If pendingReturnedItems.Rows.Count < 1 Then DisplayMessage(message)
                        Me.lblRecordsNo.Text = " Returned Record(s): " + pendingReturnedItems.Rows.Count.ToString()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Else
                        Dim pendingReturnedItems As DataTable = oItemAdjustments.GetPeriodicToAcknowledgeItemAdjustments(Nothing, Nothing).Tables("ItemAdjustments")

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If pendingReturnedItems Is Nothing OrElse pendingReturnedItems.Rows.Count < 1 Then Return
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        LoadGridData(Me.dgvReturnedExtraBillItems, pendingReturnedItems)

                        Me.lblRecordsNo.Text = " Returned Record(s): " + pendingReturnedItems.Rows.Count.ToString()

                    End If

            End Select

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvReturnedExtraBillItems_DoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReturnedExtraBillItems.CellDoubleClick

        Try

            Dim visitNo As String = Me.dgvReturnedExtraBillItems.Item(Me.colExtraBillNo.Name, e.RowIndex).Value.ToString()

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

End Class