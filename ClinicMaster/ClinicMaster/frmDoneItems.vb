
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmDoneItems

#Region " Fields "
    Private alertNoControl As Control
    Private doneItemCategory As AlertItemCategory
#End Region

    Private Sub frmDoneItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Select Case True

                Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Test)
                    Me.Text = "Lab Requests"
                    Me.rdoGetPeriod.Text = "Get Done Lab Requests for Set Period"
                    Me.rdoGetAll.Text = "Get All Done Lab Requests"

                Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Drug)
                    Me.Text = "Prescription"
                    Me.rdoGetPeriod.Text = "Get Done Prescription for Set Period"
                    Me.rdoGetAll.Text = "Get All Done Prescription"

                Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Radiology)
                    Me.Text = "Radiology Examinations"
                    Me.rdoGetPeriod.Text = "Get Done Radiology for Set Period"
                    Me.rdoGetAll.Text = "Get All Done Radiology"

                Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Procedure)
                    Me.Text = "Procedures"
                    Me.rdoGetPeriod.Text = "Get Done Procedures for Set Period"
                    Me.rdoGetAll.Text = "Get All Done Procedures"

                Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.CashPayment)
                    Me.Text = "Cash Payment"
                    Me.rdoGetPeriod.Text = "Get Done Cash Payment for Set Period"
                    Me.rdoGetAll.Text = "Get All Done Cash Payment"

                Case Else
                    Me.Text = "Done Items"
                    Me.rdoGetPeriod.Text = "Get Done Items for Set Period"
                    Me.rdoGetAll.Text = "Get All Done Items"

            End Select

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today

            Me.ShowDoneItems(Today.AddDays(-1), Today)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub rdoGetPeriod_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGetPeriod.CheckedChanged
        If Me.rdoGetPeriod.Checked Then EnablePeriodCTLS(True)
    End Sub

    Private Sub rdoGetAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoGetAll.CheckedChanged
        If Me.rdoGetAll.Checked Then EnablePeriodCTLS(False)
    End Sub

    Private Sub EnablePeriodCTLS(ByVal state As Boolean)

        Me.pnlPeriod.Enabled = state
        If state Then
            Me.dtpStartDate.Value = Today.AddDays(-1)
            Me.dtpEndDate.Value = Today
            Me.dtpStartDate.Checked = True
            Me.dtpEndDate.Checked = True
        Else : ResetControlsIn(Me.pnlPeriod)
        End If

    End Sub

    Private Sub fbnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnLoad.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case True

                Case Me.rdoGetPeriod.Checked
                    Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
                    Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

                    If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")
                    Me.ShowDoneItems(startDate, endDate)

                Case Me.rdoGetAll.Checked

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim message As String = "This action may take awhile to complete if you have many done " + Me.Text + "." _
                                             + ControlChars.NewLine + "Are you sure you want to load all?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowDoneItems(Nothing, Nothing)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowDoneItems(ByVal startDate As Nullable(Of Date), ByVal endDate As Nullable(Of Date))

        Dim doneItems As DataTable
        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim billNo As String = GetLookupDataDes(oBillModesID.Cash)

            ' Load from Items
            If (startDate IsNot Nothing) And (endDate IsNot Nothing) Then

                Select Case True

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Test)
                        doneItems = oItems.GetDoneItems(oItemCategoryID.Test, startDate, endDate).Tables("Items")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Drug)
                        doneItems = oItems.GetDoneItems(oItemCategoryID.Drug, startDate, endDate).Tables("Items")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Radiology)
                        doneItems = oItems.GetDoneItems(oItemCategoryID.Radiology, startDate, endDate).Tables("Items")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Procedure)
                        doneItems = oItems.GetDoneItems(oItemCategoryID.Procedure, startDate, endDate).Tables("Items")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.CashPayment)
                        doneItems = oItems.GetNotPaidItems(oBillModesID.Cash, billNo, startDate, endDate).Tables("Items")

                    Case Else : doneItems = oItems.GetDoneItems(String.Empty, startDate, endDate).Tables("Items")

                End Select

            Else
                Select Case True

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Test)
                        doneItems = oItems.GetDoneItems(oItemCategoryID.Test).Tables("Items")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Drug)
                        doneItems = oItems.GetDoneItems(oItemCategoryID.Drug).Tables("Items")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Radiology)
                        doneItems = oItems.GetDoneItems(oItemCategoryID.Radiology).Tables("Items")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Procedure)
                        doneItems = oItems.GetDoneItems(oItemCategoryID.Procedure).Tables("Items")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.CashPayment)
                        doneItems = oItems.GetNotPaidItems(oBillModesID.Cash, billNo).Tables("Items")

                    Case Else : doneItems = oItems.GetDoneItems(String.Empty).Tables("Items")

                End Select

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDoneItems, doneItems)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String

            Select Case True
                Case Me.rdoGetPeriod.Checked
                    message = "No done record(s) found for  " + Me.Text + " for period between " _
                                + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                Case Me.rdoGetAll.Checked
                    message = "No done record(s) found for  " + Me.Text + " for all period!"
                Case Else : message = "No done record(s) found for  " + Me.Text + "!"
            End Select

            If doneItems.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + doneItems.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDoneItems_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDoneItems.CellDoubleClick

        Try

            Dim visitNo As String = Me.dgvDoneItems.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

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

        If Me.dgvDoneItems.ColumnCount < 1 OrElse Me.dgvDoneItems.RowCount < 1 Then
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

            If Me.dgvDoneItems.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvDoneItems))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvDoneItems.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class