Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Collections.Generic
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmAcknowledgeBillReturns

#Region "Fields"
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private _VisitState As Boolean = True
#End Region

    Private Sub frmAcknowledgeFormReturns_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.SetDefaultLocation()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case _VisitState
                Case True
                    Me.Text = "Acknowledge IPD Returns"
                    Me.lblRoundNo.Visible = True
                    Me.lblVisitNo.Visible = True
                    Me.stbRoundNo.Visible = True
                    Me.stbVisitNo.Visible = True
                    Me.lblExtraBillDate.Visible = True
                    Me.stbExtraBillDate.Visible = True


                Case False
                    Me.Text = "Acknowledge OPD Returns"
                    Me.lblRoundNo.Visible = False
                    Me.lblVisitNo.Visible = False
                    Me.stbRoundNo.Visible = False
                    Me.stbVisitNo.Visible = False
                    Me.lblExtraBillDate.Visible = False
                    Me.lblExtraBillNo.Text = "Visit No"
                    Me.stbExtraBillDate.Visible = False


            End Select
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowUnProcessedExtraBillItemAdjustments()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default()
        End Try

    End Sub

    Private Sub SetDefaultLocation()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboLocationID, LookupObjects.Location, False)

            If Not String.IsNullOrEmpty(InitOptions.Location) Then
                Me.cboLocationID.SelectedValue = GetLookupDataID(LookupObjects.Location, InitOptions.Location)
                Me.EnableSetInventoryLocation()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
        'Try
        '    Me.Cursor = Cursors.WaitCursor

        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    LoadLookupDataCombo(Me.cboLocationID, LookupObjects.Location, True)
        '    If Not String.IsNullOrEmpty(InitOptions.Location) Then
        '        Me.cboLocationID.SelectedValue = GetLookupDataID(LookupObjects.Location, InitOptions.Location)
        '        Me.EnableSetInventoryLocation()
        '    End If
        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Catch ex As Exception
        '    ErrorMessage(ex)

        'Finally
        '    Me.Cursor = Cursors.Default

        'End Try


    End Sub

    Private Sub EnableSetInventoryLocation()

        Dim oVariousOptions As New VariousOptions()

        Try

            Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
            If Not oVariousOptions.EnableSetInventoryLocation AndAlso Not String.IsNullOrEmpty(location) Then
                Me.cboLocationID.Enabled = False
            Else : Me.cboLocationID.Enabled = True
            End If

        Catch ex As Exception
            Me.cboLocationID.Enabled = True

        End Try

    End Sub

    Private Sub stbExtraBillNo_TextChanged(sender As Object, e As EventArgs) Handles stbExtraBillNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub ClearControls()

        ' Me.stbExtraBillNo.Clear()
        Me.stbExtraBillDate.Clear()
        Me.stbStaffNo.Clear()
        Me.stbVisitNo.Clear()

        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()

        Me.stbBillCustomerName.Clear()
        Me.stbRoundNo.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbVisitStatus.Clear()
        Me.stbGender.Clear()
        Me.stbBillMode.Clear()
        Me.stbInsuranceName.Clear()

        Me.dgvReturnedItems.Rows.Clear()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' ResetControlsIn(Me.pnlAcknowledgeBiiFormReturnsDetails)

    End Sub

    Private Sub stbExtraBillNo_Leave(sender As Object, e As EventArgs) Handles stbExtraBillNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case _VisitState
                Case True
                    Dim extraBillNo As String = RevertText(StringMayBeEnteredIn(Me.stbExtraBillNo))
                    Me.ShowExtraBillDetails(extraBillNo)
                Case False
                    Dim VisitNo As String = RevertText(StringMayBeEnteredIn(Me.stbExtraBillNo))
                    Me.ShowExtraBillDetails(VisitNo)
            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.ClearControls()
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub

    Private Sub ShowExtraBillDetails(ByVal extraBillNo As String)

        Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(extraBillNo) Then Return

            Select Case _VisitState
                Case True
                    Dim ExtraBillsDetails As DataTable = oExtraBills.GetExtraBills(extraBillNo).Tables("ExtraBills")
                    Dim row As DataRow = ExtraBillsDetails.Rows(0)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.stbExtraBillNo.Text = FormatText(extraBillNo, "ExtraBills", "ExtraBillNo")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim patientNo As String = StringEnteredIn(row, "PatientNo")
                    Dim visitNo As String = StringEnteredIn(row, "VisitNo")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.stbExtraBillDate.Text = FormatDate(DateEnteredIn(row, "ExtraBillDate"))

                    Me.stbStaffNo.Text = StringMayBeEnteredIn(row, "StaffName")


                    Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")

                    Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
                    Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
                    Me.stbFullName.Text = StringEnteredIn(row, "FullName")

                    Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
                    Me.stbRoundNo.Text = StringMayBeEnteredIn(row, "RoundNo")
                    Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
                    Me.stbAge.Text = StringEnteredIn(row, "Age")
                    Me.stbVisitStatus.Text = StringEnteredIn(row, "VisitStatus")
                    Me.stbGender.Text = StringEnteredIn(row, "Gender")
                    Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
                    Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.LoadReturnedItems(extraBillNo)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case False
                    Dim visits As DataTable = oVisits.GetVisits(extraBillNo).Tables("Visits")
                    Dim row As DataRow = visits.Rows(0)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Me.stbExtraBillNo.Text = FormatText(extraBillNo, "ExtraBills", "ExtraBillNo")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim patientNo As String = StringEnteredIn(row, "PatientNo")
                    'Dim visitNo As String = StringEnteredIn(row, "VisitNo")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    'Me.stbExtraBillDate.Text = FormatDate(DateEnteredIn(row, "ExtraBillDate"))
                    'Me.stbStaffNo.Text = StringMayBeEnteredIn(row, "StaffName")
                    Me.stbStaffNo.Text = StringMayBeEnteredIn(row, "DoctorStaffNo")
                    'Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")

                    Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
                    Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
                    Me.stbFullName.Text = StringEnteredIn(row, "FullName")

                    Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
                    'Me.stbRoundNo.Text = StringMayBeEnteredIn(row, "RoundNo")
                    Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
                    Me.stbAge.Text = StringEnteredIn(row, "Age")
                    Me.stbVisitStatus.Text = StringEnteredIn(row, "VisitStatus")
                    Me.stbGender.Text = StringEnteredIn(row, "Gender")
                    Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
                    Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.LoadReturnedItems(extraBillNo)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select
        Catch eX As Exception
            ErrorMessage(eX)
            Me.ClearControls()
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnClose_Click(sender As Object, e As EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindExtraBillNo_Click(sender As Object, e As EventArgs) Handles btnFindExtraBillNo.Click
        Select Case _VisitState
            Case True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim fFindExtraBillNo As New frmFindAutoNo(Me.stbExtraBillNo, AutoNumber.ExtraBillNo)
                fFindExtraBillNo.ShowDialog(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "ExtraBillNo!"))
                Me.ShowExtraBillDetails(extraBillNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Case False
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim fFindVisitNo As New frmFindAutoNo(Me.stbExtraBillNo, AutoNumber.VisitNo)
                fFindVisitNo.ShowDialog(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim visitNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "visitNo!"))
                Me.ShowExtraBillDetails(visitNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Select
    End Sub

    Private Sub ShowUnProcessedExtraBillItemAdjustments()

        Dim oVariousOptions As New VariousOptions()
        Dim InventoryAlertDays As Integer = oVariousOptions.InventoryAlertDays
        Dim oExtraBillItemAdjustments As New SyncSoft.SQLDb.ExtraBillItemAdjustments()
        Dim oItemAdjustments As New SyncSoft.SQLDb.ItemAdjustments()

        Dim recordsNo As Integer
        Try
            Dim startDate As Date = Today.AddDays(-InventoryAlertDays)
            Dim endDate As Date = Today
            Me.Cursor = Cursors.WaitCursor

            Dim pendingBillAdjustments As New DataTable


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case _VisitState
                Case True
                  
                    pendingBillAdjustments = oExtraBillItemAdjustments.GetPeriodicToAckwnoledgeExtraBillItems(startDate, endDate).Tables("ExtraBillItemAdjustments")
                    
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    
                Case False

                    pendingBillAdjustments = oItemAdjustments.GetPeriodicToAcknowledgeItemAdjustments(startDate, endDate).Tables("ItemAdjustments")
                   
            End Select

            recordsNo = pendingBillAdjustments.Rows.Count

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.lblPendingIventoryAcknowledgements.Text = Me.Text + " " + recordsNo.ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmAcknowledgeBillFormReturns_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ShowUnProcessedExtraBillItemAdjustments()
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub tbcExtraBillItemAdjustments_SelectedIndexChanged(sender As Object, e As EventArgs)
        Try
            Me.Cursor = Cursors.WaitCursor
            ' Me.lblPendingIventoryAcknowledgements.Text = "Returns Acknowledgements: " + Me.ShowUnProcessedExtraBillItemAdjustments.ToString()
            Me.ShowUnProcessedExtraBillItemAdjustments()
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub



#Region "Drug Grid"

    Private Sub dgvReturnedDrugs_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvReturnedItems.CellClick

        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim expiryDate As Date = DateMayBeEnteredIn(Me.dgvReturnedItems.Rows(e.RowIndex).Cells, Me.ColDrugExpiryDate)

            Dim fSelectDateTime As New SyncSoft.SQL.Win.Forms.SelectDateTime(expiryDate, "Expiry Date", Today, AppData.MaximumDate,
                                                                             Me.dgvReturnedItems, Me.ColDrugExpiryDate, e.RowIndex)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColDrugExpiryDate.Index.Equals(e.ColumnIndex) AndAlso Me.dgvReturnedItems.Rows(e.RowIndex).IsNewRow Then

                Me.dgvReturnedItems.Rows.Add()
                fSelectDateTime.ShowDialog(Me)

                Dim enteredDate As Date = DateMayBeEnteredIn(Me.dgvReturnedItems.Rows(e.RowIndex).Cells, Me.ColDrugExpiryDate)
                If enteredDate = AppData.NullDateValue Then Me.dgvReturnedItems.Rows.RemoveAt(e.RowIndex)

            ElseIf Me.ColDrugExpiryDate.Index.Equals(e.ColumnIndex) Then

                fSelectDateTime.ShowDialog(Me)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub LoadReturnedItems(ByVal extraBillNo As String)

        Dim oExtraBillItemAdjustments As New SyncSoft.SQLDb.ExtraBillItemAdjustments()
        Dim oItemAdjustments As New SyncSoft.SQLDb.ItemAdjustments
        Dim dataTable As New DataTable()

        Try
            Select Case _VisitState
                Case True
                    dataTable = oExtraBillItemAdjustments.GetExtraBillToAckwnoledgeExtraBillItems(extraBillNo).Tables("ExtraBillItemAdjustments")

                Case False
                    dataTable = oItemAdjustments.GetVisitToAcknowkedgeItemAdjustments(extraBillNo).Tables("ItemAdjustments")


            End Select

            LoadGridData(Me.dgvReturnedItems, dataTable)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

    Private Sub fbnSave_Click(sender As Object, e As EventArgs) Handles fbnSave.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim LocationID As String = StringValueEnteredIn(Me.cboLocationID, "Location!")
            If Not (String.IsNullOrEmpty(LocationID)) Then
                If Me.dgvReturnedItems.RowCount > 1 Then Me.SaveReturnedPrescriptions(LocationID)

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally

            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveReturnedPrescriptions(ByVal LocationID As String)
        
        Dim oStockTypeID As New StockTypeID()
        Dim oEntryModeID As New EntryModeID
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim lToAcknowledgeTeturns As New List(Of DBConnect)
        Dim lInventory As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oItemTransferStatusID As New LookupDataID.ItemStatusID

            Dim ItemTransferStatus As String = oItemTransferStatusID.Pending
            Dim extraBillDate As Date = DateMayBeEnteredIn(Me.stbExtraBillDate)


            If Me.dgvReturnedItems.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for returned drug!")

            For Each row As DataGridViewRow In Me.dgvReturnedItems.Rows

                If row.IsNewRow Then Exit For

                Dim expiryDate As Date = DateEnteredIn(row.Cells, Me.ColDrugExpiryDate, "Expiry Date!")
                Dim returnedQuantity As Integer = IntegerEnteredIn(row.Cells, Me.colDrugReturnedQuantity, "Returned Quantity!")
                Dim batchNo As String = StringEnteredIn(row.Cells, Me.colDrugBatchNo, "BatchNo")

                If expiryDate < extraBillDate Then Throw New ArgumentException("Expiry date can’t be before extra bill date!")
                If returnedQuantity < 1 Then Throw New ArgumentException("Returned quantity can’t be less than one!")

            Next
            Select Case _VisitState
                Case True

                    Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No"))
                    For Each row As DataGridViewRow In Me.dgvReturnedItems.Rows
                        If row.IsNewRow Then Exit For

                        Dim cells As DataGridViewCellCollection = Me.dgvReturnedItems.Rows(row.Index).Cells
                        Dim adjustmentNo As String = RevertText(StringEnteredIn(cells, Me.colAdjustmentNo))
                        Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode)
                        Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID)
                        Dim expiryDate As Date = DateEnteredIn(cells, Me.ColDrugExpiryDate)
                        Dim batchNo As String = StringEnteredIn(cells, Me.colDrugBatchNo)
                        Dim Quantity As Integer = IntegerEnteredIn(cells, Me.colDrugReturnedQuantity)

                        Using oExtraBillItemAdjustments As New ExtraBillItemAdjustments
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            With oExtraBillItemAdjustments
                                .AdjustmentNo = adjustmentNo
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID

                            End With
                            lToAcknowledgeTeturns.Add(oExtraBillItemAdjustments)


                        End Using

                        Using oInventory As New Inventory
                            With oInventory

                                .LocationID = LocationID
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                                .TranDate = Today
                                .StockTypeID = oStockTypeID.Received
                                .Quantity = Quantity
                                .EntryModeID = oEntryModeID.Returned
                                .LoginID = CurrentUser.LoginID
                                .BatchNo = batchNo
                                .ExpiryDate = expiryDate
                                .Details = GetLookupDataDes(itemCategoryID) + "(s) Returned from Extra Bill No: " + extraBillNo
                            End With
                            lInventory.Add(oInventory)
                        End Using

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Next

                    transactions.Add(New TransactionList(Of DBConnect)(lToAcknowledgeTeturns, Action.Update))
                    transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))
                    DoTransactions(transactions)

                Case False
                    Dim visitNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Visit No!"))
                    For Each row As DataGridViewRow In Me.dgvReturnedItems.Rows
                        If row.IsNewRow Then Exit For

                        Dim lReturnedItems As New List(Of DBConnect)

                        Dim cells As DataGridViewCellCollection = Me.dgvReturnedItems.Rows(row.Index).Cells
                        Dim adjustmentNo As String = RevertText(StringEnteredIn(cells, Me.colAdjustmentNo))
                        Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode)
                        Dim itemCategoryID As String = StringEnteredIn(cells, Me.colItemCategoryID)
                        Dim expiryDate As Date = DateEnteredIn(cells, Me.ColDrugExpiryDate)
                        Dim batchNo As String = StringEnteredIn(cells, Me.colDrugBatchNo)
                        Dim Quantity As Integer = IntegerEnteredIn(cells, Me.colDrugReturnedQuantity)


                        Using oInventory As New Inventory
                            With oInventory

                                .LocationID = LocationID
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID
                                .TranDate = Today
                                .StockTypeID = oStockTypeID.Received
                                .Quantity = Quantity
                                .EntryModeID = oEntryModeID.Returned
                                .LoginID = CurrentUser.LoginID
                                .BatchNo = batchNo
                                .ExpiryDate = expiryDate
                                .Details = GetLookupDataDes(itemCategoryID) + "(s) Returned from Visit No: " + visitNo
                            End With
                            lInventory.Add(oInventory)
                        End Using

                        Using oItemAdjustments As New ItemAdjustments
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            With oItemAdjustments
                                .AdjustmentNo = adjustmentNo
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = itemCategoryID

                            End With
                            lToAcknowledgeTeturns.Add(oItemAdjustments)
                        End Using


                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Next

                    transactions.Add(New TransactionList(Of DBConnect)(lToAcknowledgeTeturns, Action.Update))
                    transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))
                    DoTransactions(transactions)
            End Select

            ResetControlsIn(Me)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
            Me.ShowUnProcessedExtraBillItemAdjustments()
        End Try

    End Sub


    Private Sub cboLocationID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboLocationID.SelectedIndexChanged
        Try
            Cursor.Current = Cursors.WaitCursor
            If String.IsNullOrEmpty(cboLocationID.Text) Then Return
            Me.batchNoExpiryDateLoader()
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try


    End Sub

    Private Sub batchNoExpiryDateLoader()

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim ExtraBillNo As String = StringMayBeEnteredIn(Me.stbVisitNo)

            For rowNo As Integer = 0 To Me.dgvReturnedItems.RowCount - 1
                'DrugsDetails(rowNo)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Dim itemCode As String = String.Empty
                Dim itemCategoryID As String = String.Empty
                Dim locationID As String = StringValueEnteredIn(Me.cboLocationID)

                If Me.dgvReturnedItems.Rows.Count > 1 Then

                    itemCode = StringMayBeEnteredIn(Me.dgvReturnedItems.Rows(rowNo).Cells, Me.colItemCode)
                    itemCategoryID = StringMayBeEnteredIn(Me.dgvReturnedItems.Rows(rowNo).Cells, Me.colItemCategoryID)
                Else
                    Return
                End If

                If (String.IsNullOrEmpty(itemCode) Or String.IsNullOrEmpty(ExtraBillNo)) Then Return

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                With Me.dgvReturnedItems
                    .Item(Me.colDrugBatchNo.Name, rowNo).Value = Me.GetInventoryBatchNo(locationID, itemCategoryID, itemCode)

                    .Item(Me.ColDrugExpiryDate.Name, rowNo).Value = Me.GetInventoryExpiryDate(locationID, itemCategoryID, itemCode).Date.ToString("dd MMMM yyyy")

                End With

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Friend Function GetInventoryExpiryDate(locationID As String, itemCategoryID As String, itemCode As String) As Date

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oInventory As New SyncSoft.SQLDb.Inventory()
            Return oInventory.GetInventoryExpiryDate(locationID, itemCategoryID, itemCode)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function

    Friend Function GetInventoryBatchNo(locationID As String, itemCategoryID As String, itemCode As String) As String

        Try
            Cursor.Current = Cursors.WaitCursor

            Dim oInventory As New SyncSoft.SQLDb.Inventory()
            Return oInventory.GetInventoryBatchNo(locationID, itemCategoryID, itemCode)

        Catch ex As Exception
            Throw ex

        Finally
            Cursor.Current = Cursors.Default

        End Try

    End Function




    Private Sub BtnLoad_Click(sender As System.Object, e As System.EventArgs) Handles BtnLoad.Click

        Select Case _VisitState

            Case True
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim fPeriodicExtraBillItemAdjustments As New frmPeriodicReturnedExtraBillItems(True, Me.stbExtraBillNo)
                fPeriodicExtraBillItemAdjustments.ShowDialog(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim extraBillNo As String = RevertText(StringMayBeEnteredIn(Me.stbExtraBillNo))
                Me.ShowExtraBillDetails(extraBillNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Case False
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim fPeriodicExtraBillItemAdjustments As New frmPeriodicReturnedExtraBillItems(False, Me.stbExtraBillNo)
                fPeriodicExtraBillItemAdjustments.ShowDialog(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim VisitNo As String = RevertText(StringMayBeEnteredIn(Me.stbExtraBillNo))
                Me.ShowExtraBillDetails(VisitNo)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Select
    End Sub
End Class