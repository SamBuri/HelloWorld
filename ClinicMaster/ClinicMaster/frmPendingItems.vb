
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmPendingItems

#Region " Fields "
    Private alertNoControl As Control
    Private pendingItemCategory As AlertItemCategory
    Private visitNo As String
    Private patientNo As String
    Private tokenNo As String
    Private firstName As String
    Private ServicePointID As String
    Private oServicePointID As New LookupDataID.ServicePointID
#End Region

    Private Sub frmPendingItems_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
   
      

        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.CheckQueueStatus()
          Select Case True

                Case Me.pendingItemCategory.Equals(AlertItemCategory.Test)
                    Me.Text = "Lab Requests"
                    Me.rdoGetPeriod.Text = "Get Pending Lab Requests for Set Period"
                    Me.rdoGetAll.Text = "Get All Pending Lab Requests"
                    Me.ServicePointID = oServicePointID.Laboratory()

                Case Me.pendingItemCategory.Equals(AlertItemCategory.Drug)
                    Me.Text = "Prescription"
                    Me.rdoGetPeriod.Text = "Get Pending Prescription for Set Period"
                    Me.rdoGetAll.Text = "Get All Pending Prescription"
                    Me.ServicePointID = oServicePointID.Pharmacy()
                Case Me.pendingItemCategory.Equals(AlertItemCategory.Consumable)
                    Me.Text = "Consumables"
                    Me.rdoGetPeriod.Text = "Get Pending Consumable for Set Period"
                    Me.rdoGetAll.Text = "Get All Pending Consumable"

                Case Me.pendingItemCategory.Equals(AlertItemCategory.Cardiology)
                    Me.Text = "Cardiology Examinations"
                    Me.rdoGetPeriod.Text = "Get Pending Cardiology for Set Period"
                    Me.rdoGetAll.Text = "Get All Pending Cardiology"
                    Me.ServicePointID = oServicePointID.Cardiology()

                Case Me.pendingItemCategory.Equals(AlertItemCategory.CardiologyProcessing)
                    Me.Text = "Cardiology Examinations"
                    Me.rdoGetPeriod.Text = "Get Processing Cardiology for Set Period"
                    Me.rdoGetAll.Text = "Get All Processing Cardiology"
                    Me.ServicePointID = oServicePointID.Cardiology()

                Case Me.pendingItemCategory.Equals(AlertItemCategory.Radiology)
                    Me.Text = "Radiology Examinations"
                    Me.rdoGetPeriod.Text = "Get Pending Radiology for Set Period"
                    Me.rdoGetAll.Text = "Get All Pending Radiology"
                    Me.ServicePointID = oServicePointID.Radiology()

                Case Me.pendingItemCategory.Equals(AlertItemCategory.RadiologyProcessing)
                    Me.Text = "Radiology Examinations"
                    Me.rdoGetPeriod.Text = "Get Processing Radiology for Set Period"
                    Me.rdoGetAll.Text = "Get All Processing Radiology"
                    Me.ServicePointID = oServicePointID.Radiology()

                Case Me.pendingItemCategory.Equals(AlertItemCategory.Pathology)
                    Me.Text = "Pathology Examinations"
                    Me.rdoGetPeriod.Text = "Get Pending Pathology for Set Period"
                    Me.rdoGetAll.Text = "Get All Pending Pathology"


                Case Me.pendingItemCategory.Equals(AlertItemCategory.PathologyProcessing)
                    Me.Text = "Pathology Examinations"
                    Me.rdoGetPeriod.Text = "Get Processing Pathology for Set Period"
                    Me.rdoGetAll.Text = "Get All Processing Pathology"

                Case Me.pendingItemCategory.Equals(AlertItemCategory.Procedure)
                    Me.Text = "Procedures"
                    Me.rdoGetPeriod.Text = "Get Pending Procedures for Set Period"
                    Me.rdoGetAll.Text = "Get All Pending Procedures"

                Case Me.pendingItemCategory.Equals(AlertItemCategory.Dental)
                    Me.Text = "Dental"
                    Me.rdoGetPeriod.Text = "Get Pending Dental for Set Period"
                    Me.rdoGetAll.Text = "Get All Pending Dental"

                Case Me.pendingItemCategory.Equals(AlertItemCategory.CashPayment)
                    Me.Text = "Cash Payment"
                    Me.rdoGetPeriod.Text = "Get Pending Cash Payment for Set Period"
                    Me.rdoGetAll.Text = "Get All Pending Cash Payment"
                    Me.ServicePointID = oServicePointID.Cashier()

                Case Else
                    Me.Text = "Pending Items"
                    Me.rdoGetPeriod.Text = "Get Pending Items for Set Period"
                    Me.rdoGetAll.Text = "Get All Pending Items"

            End Select

            Me.dtpStartDate.MaxDate = Today
            Me.dtpEndDate.MaxDate = Today

            Me.dtpStartDate.Value = Today.AddDays(-1)
            Me.dtpEndDate.Value = Today

            Me.ShowPendingItems(Today.AddDays(-1), Today)

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
                    Me.ShowPendingItems(startDate, endDate)

                Case Me.rdoGetAll.Checked

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim message As String = "This action may take awhile to complete if you have many pending or processing " + Me.Text + "." +
                                            ControlChars.NewLine + "Are you sure you want to load all?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ShowPendingItems(Nothing, Nothing)

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPendingItems(ByVal startDate As Nullable(Of Date), ByVal endDate As Nullable(Of Date))

        Dim pendingItems As DataTable
        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim billNo As String = GetLookupDataDes(oBillModesID.Cash)

            ' Load from Items
            If (startDate IsNot Nothing) And (endDate IsNot Nothing) Then

                Select Case True

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Test)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Test, startDate, endDate).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Drug)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Drug, startDate, endDate).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Consumable)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Consumable, startDate, endDate).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Cardiology)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Cardiology, startDate, endDate).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.CardiologyProcessing)
                        pendingItems = oItems.GetProcessingItems(oItemCategoryID.Cardiology, startDate, endDate).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Radiology)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Radiology, startDate, endDate).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.RadiologyProcessing)
                        pendingItems = oItems.GetProcessingItems(oItemCategoryID.Radiology, startDate, endDate).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Procedure)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Procedure, startDate, endDate).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Dental)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Dental, startDate, endDate).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.CashPayment)
                        pendingItems = oItems.GetPeriodicCashNotPaidItemsSummary(CDate(startDate), CDate(endDate)).Tables("Items")
                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Pathology)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Pathology, startDate, endDate).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.PathologyProcessing)
                        pendingItems = oItems.GetProcessingItems(oItemCategoryID.Pathology, startDate, endDate).Tables("Items")

                    Case Else : pendingItems = oItems.GetPendingItems(String.Empty, startDate, endDate).Tables("Items")

                End Select

            Else
                Select Case True

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Test)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Test).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Drug)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Drug).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Consumable)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Consumable).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Cardiology)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Cardiology).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.CardiologyProcessing)
                        pendingItems = oItems.GetProcessingItems(oItemCategoryID.Cardiology).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Radiology)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Radiology).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.RadiologyProcessing)
                        pendingItems = oItems.GetProcessingItems(oItemCategoryID.Radiology).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Procedure)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Procedure).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Dental)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Dental).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.CashPayment)
                        pendingItems = oItems.GetNotPaidItems(oBillModesID.Cash, billNo).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.Pathology)
                        pendingItems = oItems.GetPendingItems(oItemCategoryID.Pathology).Tables("Items")

                    Case Me.pendingItemCategory.Equals(AlertItemCategory.PathologyProcessing)
                        pendingItems = oItems.GetProcessingItems(oItemCategoryID.Pathology).Tables("Items")

                    Case Else : pendingItems = oItems.GetPendingItems(String.Empty).Tables("Items")

                End Select

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPendingItems, pendingItems)

            If Me.pendingItemCategory.Equals(AlertItemCategory.CashPayment) OrElse
               Me.pendingItemCategory.Equals(AlertItemCategory.Cardiology) OrElse Me.pendingItemCategory.Equals(AlertItemCategory.Test) OrElse
               Me.pendingItemCategory.Equals(AlertItemCategory.CardiologyProcessing) OrElse Me.pendingItemCategory.Equals(AlertItemCategory.Drug) Then
                Me.LoadTokenNos(pendingItems)
                Me.CheckQueueStatus()
            End If

            If Me.pendingItemCategory.Equals(AlertItemCategory.CashPayment) OrElse
                Me.pendingItemCategory.Equals(AlertItemCategory.Radiology) OrElse Me.pendingItemCategory.Equals(AlertItemCategory.Test) OrElse
                Me.pendingItemCategory.Equals(AlertItemCategory.RadiologyProcessing) OrElse Me.pendingItemCategory.Equals(AlertItemCategory.Drug) Then
                Me.LoadTokenNos(pendingItems)
                Me.CheckQueueStatus()
            End If

           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String

            Select Case True
                Case Me.rdoGetPeriod.Checked
                    message = "No pending record(s) found for  " + Me.Text + " for period between " +
                        FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"
                Case Me.rdoGetAll.Checked
                    message = "No pending record(s) found for  " + Me.Text + " for all period!"
                Case Else : message = "No pending record(s) found for  " + Me.Text + "!"
            End Select

            If pendingItems.Rows.Count < 1 Then DisplayMessage(message)
            Me.lblRecordsNo.Text = " Returned Record(s): " + pendingItems.Rows.Count.ToString()
            Me.fbnExportTo.Enabled = pendingItems.Rows.Count > 0
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnExportTo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnExportTo.Click

        Dim fStatus As New SyncSoft.Common.Win.Forms.Status()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Dim startDate As Date = DateEnteredIn(Me.dtpStartDate, "Start Date")
            Dim endDate As Date = DateEnteredIn(Me.dtpEndDate, "End Date")

            If endDate < startDate Then Throw New ArgumentException("End Date can't be before Start Date!")

            Dim _objectCaption As String = Me.Text.Trim()

            Dim documentTitle As String = _objectCaption + " for the period between " +
                FormatDate(CDate(startDate)) + " and " + FormatDate(CDate(endDate)) + "!"

            fStatus.Show("Exporting " + _objectCaption + " to Excel...", FormStartPosition.CenterScreen)

            ExportToExcel(Me.dgvPendingItems, _objectCaption, documentTitle)

        Catch ex As Exception
            fStatus.Close()
            ErrorMessage(ex)

        Finally
            fStatus.Close()
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPendingItems_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPendingItems.CellDoubleClick

        Try

            Dim visitNo As String = Me.dgvPendingItems.Item(Me.colVisitNo.Name, e.RowIndex).Value.ToString()

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

        If Me.dgvPendingItems.ColumnCount < 1 OrElse Me.dgvPendingItems.RowCount < 1 Then
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

            If Me.dgvPendingItems.SelectedCells.Count < 1 Then Return
            Clipboard.SetText(CopyFromControl(Me.dgvPendingItems))

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsAlertListSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsAlertListSelectAll.Click
        Try

            Me.Cursor = Cursors.WaitCursor
            Me.dgvPendingItems.SelectAll()

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub dgvPendingItems_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvPendingItems.CellClick
        Try

            If e.RowIndex < 0 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.visitNo = RevertText(StringMayBeEnteredIn(Me.dgvPendingItems.Rows(e.RowIndex).Cells, Me.colVisitNo))
            Me.patientNo = StringMayBeEnteredIn(Me.dgvPendingItems.Rows(e.RowIndex).Cells, Me.colPatientNo)
            Me.tokenNo = StringMayBeEnteredIn(Me.dgvPendingItems.Rows(e.RowIndex).Cells, Me.colTokenNo)
            Me.firstName = StringMayBeEnteredIn(Me.dgvPendingItems.Rows(e.RowIndex).Cells, Me.colFirstName)
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

            SaveQueuedMessage(visitNo, ServicePointID, tokenNo, 0)

        Catch ex As Exception
            ErrorMessage(ex)
            Return
        End Try
    End Sub




    Private Sub LoadTokenNos(dataTable As DataTable)

        If dataTable.Rows.Count() < 1 = True Then Return

        colTokenNo.Visible = True
        fbnCall.Visible = True

        For row As Integer = 0 To dataTable.Rows.Count() - 1
            Dim dataRow As DataRow = dataTable.Rows(row)
            Me.dgvPendingItems.Item(Me.colTokenNo.Name, row).Value = StringMayBeEnteredIn(dataRow, "TokenNo")
        Next
    End Sub


    Private Sub CheckQueueStatus()
        If IsQueueEnabled() = False Then
            Me.fbnCall.Visible = False
            Me.colTokenNo.Visible = False
            Me.colFirstName.Visible = False

        Else
            Me.fbnCall.Visible = True
            Me.colTokenNo.Visible = True
            Me.colFirstName.Visible = True

        End If
    End Sub
End Class