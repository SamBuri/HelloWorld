
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmDoneIPDItems

#Region " Fields "
    Private alertNoControl As Control
    Private doneItemCategory As AlertItemCategory
#End Region

    Private Sub frmDoneIPDItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

            Me.ShowDoneIPDItems(Today.AddDays(-1), Today)

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
                    Me.ShowDoneIPDItems(startDate, endDate)

                Case Me.rdoGetAll.Checked

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim message As String = "This action may take awhile to complete if you have many done " + Me.Text + "." _
                                             + ControlChars.NewLine + "Are you sure you want to load all?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowDoneIPDItems(Nothing, Nothing)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowDoneIPDItems(ByVal startDate As Nullable(Of Date), ByVal endDate As Nullable(Of Date))

        Dim doneIPDItems As DataTable
        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID
        Dim oBillModesID As New LookupDataID.BillModesID

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim billAccount As String = GetLookupDataDes(oBillModesID.Cash)

            ' Load from IPDItems
            If (startDate IsNot Nothing) And (endDate IsNot Nothing) Then

                Select Case True

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Test)
                        doneIPDItems = oIPDItems.GetDoneIPDItems(oItemCategoryID.Test, startDate, endDate).Tables("IPDItems")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Drug)
                        doneIPDItems = oIPDItems.GetDoneIPDItems(oItemCategoryID.Drug, startDate, endDate).Tables("IPDItems")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Radiology)
                        doneIPDItems = oIPDItems.GetDoneIPDItems(oItemCategoryID.Radiology, startDate, endDate).Tables("IPDItems")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Procedure)
                        doneIPDItems = oIPDItems.GetDoneIPDItems(oItemCategoryID.Procedure, startDate, endDate).Tables("IPDItems")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.CashPayment)
                        doneIPDItems = oIPDItems.GetNotPaidIPDItems(billAccount, startDate, endDate).Tables("IPDItems")

                    Case Else : doneIPDItems = oIPDItems.GetDoneIPDItems(String.Empty, startDate, endDate).Tables("IPDItems")

                End Select

            Else
                Select Case True

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Test)
                        doneIPDItems = oIPDItems.GetDoneIPDItems(oItemCategoryID.Test).Tables("IPDItems")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Drug)
                        doneIPDItems = oIPDItems.GetDoneIPDItems(oItemCategoryID.Drug).Tables("IPDItems")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Radiology)
                        doneIPDItems = oIPDItems.GetDoneIPDItems(oItemCategoryID.Radiology).Tables("IPDItems")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.Procedure)
                        doneIPDItems = oIPDItems.GetDoneIPDItems(oItemCategoryID.Procedure).Tables("IPDItems")

                    Case Me.doneItemCategory.Equals(ClinicMaster.AlertItemCategory.CashPayment)
                        doneIPDItems = oIPDItems.GetNotPaidIPDItems(billAccount).Tables("IPDItems")

                    Case Else : doneIPDItems = oIPDItems.GetDoneIPDItems(String.Empty).Tables("IPDItems")

                End Select

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDoneIPDItems, doneIPDItems)
            Dim message As String

            Select Case True
                Case Me.rdoGetPeriod.Checked
                    message = "No done record(s) found for  " + Me.Text + " for period between " _
                                + FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                Case Me.rdoGetAll.Checked
                    message = "No done record(s) found for  " + Me.Text + " for all period!"
                Case Else : message = "No done record(s) found for  " + Me.Text + "!"
            End Select

            If doneIPDItems.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + doneIPDItems.Rows.Count.ToString()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDoneIPDItems_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDoneIPDItems.CellDoubleClick

        Try

            Dim roundNo As String = Me.dgvDoneIPDItems.Item(Me.colRoundNo.Name, e.RowIndex).Value.ToString()

            If TypeOf Me.alertNoControl Is TextBox Then
                CType(Me.alertNoControl, TextBox).Text = roundNo
                CType(Me.alertNoControl, TextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is SmartTextBox Then
                CType(Me.alertNoControl, SmartTextBox).Text = roundNo
                CType(Me.alertNoControl, SmartTextBox).Focus()

            ElseIf TypeOf Me.alertNoControl Is ComboBox Then
                CType(Me.alertNoControl, ComboBox).Text = roundNo
                CType(Me.alertNoControl, ComboBox).Focus()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.Close()

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub cmsAlertList_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsAlertList.Opening

        If Me.dgvDoneIPDItems.ColumnCount < 1 OrElse Me.dgvDoneIPDItems.RowCount < 1 Then
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

            If Me.dgvDoneIPDItems.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvDoneIPDItems))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvDoneIPDItems.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

End Class