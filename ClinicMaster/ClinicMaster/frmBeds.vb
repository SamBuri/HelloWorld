
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Collections.Generic

Public Class frmBeds

#Region " Fields "

    Private beds As DataTable

    Private billCustomers As DataTable
    Private insurances As DataTable

    Private _AccountNoValue As String = String.Empty
    Private _insuranceNoValue As String = String.Empty
    Private oVariousOptions As New VariousOptions()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID

#End Region

    Private Sub frmBeds_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboWardsID, LookupObjects.Wards, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadBeds()
            Me.LoadBillCustomers()
            Me.LoadInsurances()
            Me.SetNextBedID()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.colBillCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.colInsuranceCurrenciesID, LookupObjects.Currencies, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmBeds_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadBeds()

        Dim oBeds As New SyncSoft.SQLDb.Beds()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Beds

            ''''''''''''''''''''''''''''''''''''''
            beds = oBeds.GetBeds().Tables("Beds")
            ''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBeds(ByVal populate As Boolean)

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''
            If populate Then
                LoadComboData(Me.cboBedNo, beds, "BedFullName")
            Else : Me.cboBedNo.Items.Clear()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBillCustomers()

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Bill Customers
            If Not InitOptions.LoadBillCustomersAtStart Then
                billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                oSetupData.BillCustomers = billCustomers
            Else : billCustomers = oSetupData.BillCustomers
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colBillCustomerName.Sorted = False
            LoadComboData(Me.colBillCustomerName, billCustomers, "AccountNo", "BillCustomerName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadInsurances()

        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Insurances

            insurances = oInsurances.GetInsurances().Tables("Insurances")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colInsuranceName.Sorted = False
            LoadComboData(Me.colInsuranceName, insurances, "InsuranceNo", "InsuranceName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBedNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBedNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub cboBedNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBedNo.Leave

        Try

            Dim bedNo As String = SubstringRight(StringMayBeEnteredIn(Me.cboBedNo)).ToUpper()
            Me.cboBedNo.Text = BedNo.ToUpper()

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Return

            For Each row As DataRow In beds.Select("BedNo = '" + bedNo + "'")
                Me.stbBedName.Text = StringMayBeEnteredIn(row, "BedName")
            Next

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oBeds As New SyncSoft.SQLDb.Beds()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oBeds.BedNo = SubstringRight(RevertText(StringEnteredIn(Me.cboBedNo, "Bed No!")))
            DisplayMessage(oBeds.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            ResetControlsIn(Me.grpLocation)
            ResetControlsIn(Me.tpgBillCustomFee)
            ResetControlsIn(Me.tpgInsuranceCustomFee)
            Me.CallOnKeyEdit()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oBeds As New SyncSoft.SQLDb.Beds()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim bedNo As String = SubstringRight(RevertText(StringEnteredIn(Me.cboBedNo, "Bed No!")))
            Dim dataSource As DataTable = oBeds.GetBeds(bedNo).Tables("Beds")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim beds As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()
            Dim wardsID As String = (From data In beds Select data.Field(Of String)("WardsID")).First()
            Dim roomNo As String = (From data In beds Select data.Field(Of String)("RoomNo")).First()

            If Not String.IsNullOrEmpty(wardsID) Then Me.LoadRooms(wardsID)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboWardsID.SelectedValue = wardsID
            Me.cboRoomNo.SelectedValue = roomNo

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DisplayData(dataSource)

            Me.LoadBillCustomFee(bedNo)
            Me.LoadInsuranceCustomFee(bedNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim itemCode As String = SubstringRight(RevertText(StringEnteredIn(Me.cboBedNo, "Bed No!"))).ToUpper()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oBeds As New SyncSoft.SQLDb.Beds()
            Dim lBeds As New List(Of DBConnect)

            With oBeds

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                StringValueEnteredIn(Me.cboWardsID, "Ward!")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .RoomNo = StringValueEnteredIn(Me.cboRoomNo, "Room No!")
                .BedNo = itemCode
                .BedName = StringEnteredIn(Me.stbBedName, "Bed Name!")
                .UnitCost = Me.nbxUnitCost.GetDecimal(False)
                .UnitPrice = Me.nbxUnitPrice.GetDecimal(False)
                .VATPercentage = DecimalMayBeEnteredIn(Me.nbxVATPercentage, False)
                .Hidden = Me.chkHidden.Checked

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lBeds.Add(oBeds)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oBeds.UnitCost >= oBeds.UnitPrice Then

                If oBeds.UnitCost = oBeds.UnitPrice Then
                    message = "Unit Cost equals Unit Price. "
                Else : message = "Unit Cost is more than Unit Price. "
                End If
                message += ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.nbxUnitCost.Focus() : Return

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oBeds.Hidden.Equals(True) Then
                message = "You have chosen to hide this Bed and won�t be presented for selection. " +
                            ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.chkHidden.Focus() : Return
            End If
            OpenBillableMappings(ebnSaveUpdate.ButtonText, oItemCategoryID.Admission, itemCode)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
           
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lBeds, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(Me.BillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(Me.InsuranceCustomFeeList, Action.Save))

                    records = DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgBillCustomFee)
                    ResetControlsIn(Me.tpgInsuranceCustomFee)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetNextBedID()

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lBeds, Action.Update, "Beds"))
                    transactions.Add(New TransactionList(Of DBConnect)(BillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceCustomFeeList, Action.Save))

                    records = DoTransactions(transactions)

                    DisplayMessage(records.ToString() + " record(s) updated!")

                    Me.CallOnKeyEdit()

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvBillCustomFee.RowCount - 2
                Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvInsuranceCustomFee.RowCount - 2
                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, rowNo).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Location "

    Private Sub cboWardsID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboWardsID.SelectedIndexChanged

        Try
            Dim wardsID As String
            If Me.cboWardsID.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboWardsID.SelectedValue.ToString()) Then
                wardsID = String.Empty
            Else : wardsID = StringValueEnteredIn(Me.cboWardsID, "Ward!")
            End If

            Me.LoadRooms(wardsID)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadRooms(ByVal WardsID As String)

        Dim oRooms As New SyncSoft.SQLDb.Rooms()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboRoomNo.DataSource = Nothing
            If String.IsNullOrEmpty(WardsID) Then Return

            ' Load all from Rooms
            Dim rooms As DataTable = oRooms.GetRoomsBywardsID(WardsID).Tables("Rooms")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboRoomNo.Sorted = False
            Me.cboRoomNo.DataSource = rooms
            Me.cboRoomNo.DisplayMember = "RoomName"
            Me.cboRoomNo.ValueMember = "RoomNo"

            Me.cboRoomNo.SelectedIndex = -1
            Me.cboRoomNo.SelectedIndex = -1
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Function BillCustomFeeList() As List(Of DBConnect)

        Dim lBillCustomFee As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboBedNo, "Bed No!"))

            For rowNo As Integer = 0 To Me.dgvBillCustomFee.RowCount - 2

                Using oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillCustomFee.Rows(rowNo).Cells

                    With oBillCustomFee

                        .AccountNo = StringEnteredIn(cells, Me.colBillCustomerName, "To-Bill Account Name!")
                        .ItemCode = itemCode
                        .ItemCategoryID = oItemCategoryID.Admission
                        .CustomFee = DecimalEnteredIn(cells, Me.colBillCustomFee, False, "Custom Fee!")
                        .CurrenciesID = StringEnteredIn(cells, Me.colBillCurrenciesID, "Currency!")

                    End With

                    lBillCustomFee.Add(oBillCustomFee)

                End Using

            Next

            Return lBillCustomFee

        Catch ex As Exception
            Me.tbcBillExcludedItems.SelectTab(Me.tpgBillCustomFee)
            Throw ex

        End Try

    End Function

    Private Function InsuranceCustomFeeList() As List(Of DBConnect)

        Dim lInsuranceCustomFee As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboBedNo, "Bed No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceCustomFee.RowCount - 2

                Using oInsuranceCustomFee As New SyncSoft.SQLDb.InsuranceCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceCustomFee.Rows(rowNo).Cells

                    With oInsuranceCustomFee

                        .InsuranceNo = StringEnteredIn(cells, Me.colInsuranceName, "Insurance Name!")
                        .ItemCode = itemCode
                        .ItemCategoryID = oItemCategoryID.Admission
                        .CustomFee = DecimalEnteredIn(cells, Me.colInsuranceCustomFee, False, "Custom Fee!")
                        .CurrenciesID = StringEnteredIn(cells, Me.colInsuranceCurrenciesID, "Currency!")

                    End With

                    lInsuranceCustomFee.Add(oInsuranceCustomFee)

                End Using

            Next

            Return lInsuranceCustomFee

        Catch ex As Exception
            Me.tbcBillExcludedItems.SelectTab(Me.tpgInsuranceCustomFee)
            Throw ex

        End Try

    End Function

#Region " BillCustomFee - Grid "

    Private Sub dgvBillCustomFee_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBillCustomFee.CellBeginEdit

        If e.ColumnIndex <> Me.colBillCustomerName.Index OrElse Me.dgvBillCustomFee.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvBillCustomFee.CurrentCell.RowIndex
        _AccountNoValue = StringMayBeEnteredIn(Me.dgvBillCustomFee.Rows(selectedRow).Cells, Me.colBillCustomerName)

    End Sub

    Private Sub dgvBillCustomFee_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillCustomFee.CellEndEdit

        Try

            If Me.colBillCustomerName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colBillCustomerName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvBillCustomFee.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvBillCustomFee.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvBillCustomFee.Rows(selectedRow).Cells, Me.colBillCustomerName)

                    If CBool(Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                        Dim billCustomerName As String = (From data In _BillCustomers
                                            Where data.Field(Of String)("AccountNo").ToUpper().Equals(_AccountNoValue.ToUpper())
                                            Select data.Field(Of String)("BillCustomerName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("To-Bill Account (" + billCustomerName + ") can't be edited!")
                        Me.dgvBillCustomFee.Item(Me.colBillCustomerName.Name, selectedRow).Value = _AccountNoValue
                        Me.dgvBillCustomFee.Item(Me.colBillCustomerName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvBillCustomFee.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillCustomFee.Rows(rowNo).Cells, Me.colBillCustomerName)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _BillCustomers
                                                    Where data.Field(Of String)("AccountNo").ToUpper().Equals(enteredItem.ToUpper())
                                                    Select data.Field(Of String)("BillCustomerName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("To-Bill Account (" + enteredDisplay + ") already entered!")
                                Me.dgvBillCustomFee.Item(Me.colBillCustomerName.Name, selectedRow).Value = _AccountNoValue
                                Me.dgvBillCustomFee.Item(Me.colBillCustomerName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.DetailBillCustomFee()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub DetailBillCustomFee()

        Dim selectedRow As Integer
        Dim selectedItem As String = String.Empty

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvBillCustomFee.Rows.Count > 1 Then
                selectedRow = Me.dgvBillCustomFee.CurrentCell.RowIndex
                selectedItem = StringMayBeEnteredIn(Me.dgvBillCustomFee.Rows(selectedRow).Cells, Me.colBillCustomerName)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(selectedItem) Then
                Me.dgvBillCustomFee.Item(Me.colAccountNo.Name, selectedRow).Value = selectedItem
            Else : Me.dgvBillCustomFee.Item(Me.colAccountNo.Name, selectedRow).Value = String.Empty
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvBillCustomFee_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillCustomFee.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboBedNo, "Bed No!"))
            Dim accountNo As String = CStr(Me.dgvBillCustomFee.Item(Me.colBillCustomerName.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oBillCustomFee
                .AccountNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Admission
            End With

            DisplayMessage(oBillCustomFee.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvBillCustomFee_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillCustomFee.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadBillCustomFee(ByVal itemCode As String)

        Dim oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim billCustomFee As DataTable = oBillCustomFee.GetBillCustomFee(itemCode, oItemCategoryID.Admission).Tables("BillCustomFee")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillCustomFee, billCustomFee)

            For Each row As DataGridViewRow In Me.dgvBillCustomFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " InsuranceCustomFee - Grid "

    Private Sub dgvInsuranceCustomFee_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvInsuranceCustomFee.CellBeginEdit

        If (e.ColumnIndex <> Me.colInsuranceName.Index OrElse Me.dgvInsuranceCustomFee.Rows.Count <= 1) Then Return
        Dim selectedRow As Integer = Me.dgvInsuranceCustomFee.CurrentCell.RowIndex
        _insuranceNoValue = StringMayBeEnteredIn(Me.dgvInsuranceCustomFee.Rows(selectedRow).Cells, Me.colInsuranceName)

    End Sub

    Private Sub dgvInsuranceCustomFee_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInsuranceCustomFee.CellEndEdit

        Try

            If Me.colInsuranceName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colInsuranceName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvInsuranceCustomFee.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvInsuranceCustomFee.CurrentCell.RowIndex
                    Dim selectedInsuranceNo As String = StringMayBeEnteredIn(Me.dgvInsuranceCustomFee.Rows(selectedRow).Cells, Me.colInsuranceName)

                    If CBool(Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, selectedRow).Value).Equals(True) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Insurances As EnumerableRowCollection(Of DataRow) = insurances.AsEnumerable()
                        Dim insuranceName As String = (From data In _Insurances
                                            Where data.Field(Of String)("InsuranceNo").ToUpper().Equals(_insuranceNoValue.ToUpper())
                                            Select data.Field(Of String)("InsuranceName")).First()

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Insurance (" + insuranceName + ")  can't be edited!")
                        Me.dgvInsuranceCustomFee.Item(Me.colInsuranceName.Name, selectedRow).Value = _insuranceNoValue
                        Me.dgvInsuranceCustomFee.Item(Me.colInsuranceName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvInsuranceCustomFee.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredInsuranceNo As String = StringMayBeEnteredIn(Me.dgvInsuranceCustomFee.Rows(rowNo).Cells, Me.colInsuranceName)
                            If enteredInsuranceNo.Trim().ToUpper().Equals(selectedInsuranceNo.Trim().ToUpper()) Then

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Insurances As EnumerableRowCollection(Of DataRow) = insurances.AsEnumerable()
                                Dim insuranceName As String = (From data In _Insurances
                                                    Where data.Field(Of String)("InsuranceNo").ToUpper().Equals(enteredInsuranceNo.ToUpper())
                                                    Select data.Field(Of String)("InsuranceName")).First()

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Insurance (" + insuranceName + ") already entered!")
                                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceName.Name, selectedRow).Value = _insuranceNoValue
                                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.DetailInsuranceCustomFee()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub DetailInsuranceCustomFee()

        Dim selectedRow As Integer
        Dim selectedItem As String = String.Empty

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvInsuranceCustomFee.Rows.Count > 1 Then
                selectedRow = Me.dgvInsuranceCustomFee.CurrentCell.RowIndex
                selectedItem = StringMayBeEnteredIn(Me.dgvInsuranceCustomFee.Rows(selectedRow).Cells, Me.colInsuranceName)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(selectedItem) Then
                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceNo.Name, selectedRow).Value = selectedItem
            Else : Me.dgvInsuranceCustomFee.Item(Me.colInsuranceNo.Name, selectedRow).Value = String.Empty
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvInsuranceCustomFee_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvInsuranceCustomFee.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oInsuranceCustomFee As New SyncSoft.SQLDb.InsuranceCustomFee()
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboBedNo, "Bed No!"))
            Dim insuranceNo As String = CStr(Me.dgvInsuranceCustomFee.Item(Me.colInsuranceName.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oInsuranceCustomFee
                .InsuranceNo = insuranceNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Admission
            End With

            DisplayMessage(oInsuranceCustomFee.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvInsuranceCustomFee_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvInsuranceCustomFee.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadInsuranceCustomFee(ByVal itemCode As String)

        Dim oInsuranceCustomFee As New SyncSoft.SQLDb.InsuranceCustomFee()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim insuranceCustomFee As DataTable = oInsuranceCustomFee.GetInsuranceCustomFee(itemCode, oItemCategoryID.Admission).Tables("InsuranceCustomFee")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInsuranceCustomFee, insuranceCustomFee)

            For Each row As DataGridViewRow In Me.dgvInsuranceCustomFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, row.Index).Value = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.cboBedNo.MaxLength = 64
        Me.LoadBeds(True)

        Me.chkHidden.Enabled = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.grpLocation)
        ResetControlsIn(Me.tpgBillCustomFee)
        ResetControlsIn(Me.tpgInsuranceCustomFee)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.cboBedNo.MaxLength = 20
        Me.LoadBeds(False)

        Me.chkHidden.Enabled = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.grpLocation)
        ResetControlsIn(Me.tpgBillCustomFee)
        ResetControlsIn(Me.tpgInsuranceCustomFee)
        Me.SetNextBedID()
        Me.cboBedNo.Enabled = Not InitOptions.BedNoLocked

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.nbxUnitPrice, AccessRights.Update)
            Security.Apply(Me.nbxUnitCost, AccessRights.Update)
            Security.Apply(Me.nbxVATPercentage, AccessRights.Update)

            Security.Apply(Me.dgvBillCustomFee, AccessRights.Write)
            Security.Apply(Me.dgvInsuranceCustomFee, AccessRights.Write)

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.fbnDelete.Enabled = False
        End If
    End Sub


#End Region


#Region " SET AUTONUMBERS"

    Private Sub SetNextBedID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oBeds As New SyncSoft.SQLDb.Beds()
            Dim oVariousOption As New VariousOptions()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Beds", "BedNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim BedNoPrefix As String = oVariousOption.BedNoPrefix
            Dim nextBedNo As String = CStr(oBeds.GetNextBedID).PadLeft(paddingLEN, paddingCHAR)
            Me.cboBedNo.Text = FormatText((BedNoPrefix + nextBedNo).Trim(), "Beds", "BedNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

End Class