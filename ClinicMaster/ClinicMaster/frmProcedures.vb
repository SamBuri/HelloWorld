
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Collections.Generic
Imports System.Drawing.Printing

Public Class frmProcedures

#Region " Fields "
    Private oVariousOptions As New VariousOptions()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID

    Private billCustomers As DataTable
    Private insurances As DataTable
    Private consumableItems As DataTable
    Private theatreServices As DataTable
    Private _AccountNoValue As String = String.Empty
    Private _insuranceNoValue As String = String.Empty
    Private _consumableValue As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty
    Private _TheatreNameValue As String = String.Empty

    Private WithEvents docProcedures As New PrintDocument()

    ' The paragraphs.
    Private orderParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

    Private padItemNo As Integer = 4
    Private padItemName As Integer = 20
    Private padQuantity As Integer = 10
    Private padUnitMeasure As Integer = 10
    Private padRate As Integer = 12

    Private padAmount As Integer = 15
    Private padTotalAmount As Integer = 58

    Private itemCount As Integer = 0
#End Region

    Private Sub frmProcedures_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.colBillCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.colInsuranceCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.cboCategoryID, LookupObjects.ProcedureType, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.LoadBillCustomers()
            Me.LoadInsurances()
            Me.LoadConsumableItems()
            Me.LoadDrugs()
            Me.LoadTheatreServices()
            Me.SetNextProcedureID()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbProcedureCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub LoadConsumableItems()

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ConsumableItems
            consumableItems = oConsumableItems.GetConsumableItems().Tables("ConsumableItems")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colConsumableName, consumableItems, "ConsumableFullName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDrugs()

        Dim drugs As DataTable
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from drugs
            If Not InitOptions.LoadDrugsAtStart Then
                drugs = oDrugs.GetDrugs().Tables("Drugs")
                oSetupData.Drugs = drugs
            Else : drugs = oSetupData.Drugs
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colDrug, drugs, "DrugFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadTheatreServices()

        Dim oTheatreServices As New SyncSoft.SQLDb.TheatreServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from TheatreServices

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            theatreServices = oTheatreServices.GetTheatreServices().Tables("TheatreServices")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colTheatreCode.Sorted = False
            LoadComboData(Me.colTheatreCode, theatreServices, "TheatreCode", "TheatreName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colInsuranceName.Sorted = False
            LoadComboData(Me.colInsuranceName, insurances, "InsuranceNo", "InsuranceName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oProcedures As New SyncSoft.SQLDb.Procedures()
        Dim oPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oProcedures.ProcedureCode = SubstringRight(RevertText(StringMayBeEnteredIn(cboProcedureCode)))
            '  oPossibleAttachedItems.AttachedItemCode = StringEnteredIn(Me.stbProcedureCode, "Procedure Code!")

            DisplayMessage(oProcedures.Delete())
            '  DisplayMessage(oPossibleAttachedItems.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.tpgBillCustomFee)
            ResetControlsIn(Me.tpgInsuranceCustomFee)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oProcedures As New SyncSoft.SQLDb.Procedures()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim procedureCode As String = SubstringRight(RevertText(StringEnteredIn(cboProcedureCode)))
            Dim dataSource As DataTable = oProcedures.GetProcedures(procedureCode).Tables("Procedures")
            Me.DisplayData(dataSource)

            Me.LoadBillCustomFee(procedureCode)
            Me.LoadInsuranceCustomFee(procedureCode)
            Me.LoadAttachedTheatreConsumableItems(procedureCode)
            Me.LoadAttachedTheatreDrugs(procedureCode)
            Me.LoadAttachedTheatreServices(procedureCode)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim itemCode As String = SubstringRight(RevertText(StringEnteredIn(Me.cboProcedureCode, "Procedure Code!"))).ToUpper()
        Dim itemCategoryID As String = oItemCategoryID.Procedure
        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oProcedures As New SyncSoft.SQLDb.Procedures()
            Dim lProcedures As New List(Of DBConnect)

            With oProcedures

                .ProcedureCode = itemCode
                .ProcedureName = StringEnteredIn(Me.stbProcedureName, "Procedure Name!")
                .ShortName = StringMayBeEnteredIn(Me.stbShortName)
                .ProcedureCategoryID = StringValueEnteredIn(Me.cboCategoryID, "Procedure Category!")
                .UnitCost = Me.nbxUnitCost.GetDecimal(False)
                .UnitPrice = Me.nbxUnitPrice.GetDecimal(False)
                .VATPercentage = DecimalMayBeEnteredIn(nbxVATPercentage, False)
                .Hidden = Me.chkHidden.Checked

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lProcedures.Add(oProcedures)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oProcedures.Hidden.Equals(True) Then
                Dim message As String = "You have chosen to hide this Procedure and won’t be presented for selection. " +
                                        ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.chkHidden.Focus() : Return
            End If

            OpenBillableMappings(ebnSaveUpdate.ButtonText, oItemCategoryID.Procedure, itemCode)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
                    
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lProcedures, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleCosumables, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleDrugs, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleTheatreServices, Action.Save))
                    records = DoTransactions(transactions)

                    If Not Me.chkPrintOnSaving.Checked Then
                        Dim Message As String = "You have not checked Print Procedure details On Saving. " + ControlChars.NewLine + "Would you want Procedure details printed?"
                        If WarningMessage(Message) = Windows.Forms.DialogResult.Yes Then Me.PrintProcedures()
                    Else : Me.PrintProcedures()
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgBillCustomFee)
                    ResetControlsIn(Me.tpgInsuranceCustomFee)
                    ResetControlsIn(Me.tpgPossibleConsumables)
                    ResetControlsIn(Me.tpgPossiblePrescription)
                    ResetControlsIn(Me.tpgPossibleTheatreServices)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetNextProcedureID()

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lProcedures, Action.Update, "Procedures"))
                    transactions.Add(New TransactionList(Of DBConnect)(BillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleCosumables, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleDrugs, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleTheatreServices, Action.Save))
                    records = DoTransactions(transactions)

                    DisplayMessage(records.ToString() + " record(s) updated!")

                    Me.CallOnKeyEdit()

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvBillCustomFee.RowCount - 2
                Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvInsuranceCustomFee.RowCount - 2
                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2
                Me.dgvConsumables.Item(Me.ColConsumableItemsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
                Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2
                Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function BillCustomFeeList() As List(Of DBConnect)

        Dim lBillCustomFee As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim itemCode As String = SubstringLeft(RevertText(StringMayBeEnteredIn(cboProcedureCode)))

            For rowNo As Integer = 0 To Me.dgvBillCustomFee.RowCount - 2

                Using oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillCustomFee.Rows(rowNo).Cells

                    With oBillCustomFee

                        .AccountNo = StringEnteredIn(cells, Me.colBillCustomerName, "To-Bill Account Name!")
                        .ItemCode = itemCode
                        .ItemCategoryID = oItemCategoryID.Procedure
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

            Dim itemCode As String = SubstringLeft(RevertText(StringMayBeEnteredIn(cboProcedureCode)))

            For rowNo As Integer = 0 To Me.dgvInsuranceCustomFee.RowCount - 2

                Using oInsuranceCustomFee As New SyncSoft.SQLDb.InsuranceCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceCustomFee.Rows(rowNo).Cells

                    With oInsuranceCustomFee

                        .InsuranceNo = StringEnteredIn(cells, Me.colInsuranceName, "Insurance Name!")
                        .ItemCode = itemCode
                        .ItemCategoryID = oItemCategoryID.Procedure
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

    Private Function PossibleCosumables() As List(Of DBConnect)

        Dim iPossibleAttachedItems As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Using oiPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems

                    Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                    With oiPossibleAttachedItems
                        .AttachedItemCode = SubstringLeft(RevertText(StringMayBeEnteredIn(cboProcedureCode)))
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colConsumableName))
                        .ItemCategoryID = oItemCategoryID.Consumable
                        .Quantity = IntegerEnteredIn(cells, Me.colConsumableQuantity)
                        .UnitCost = DecimalEnteredIn(cells, Me.ColConUnitCost, False)
                        .UnitPrice = DecimalEnteredIn(cells, Me.ColConsUnitPrice, False)
                        .Dosage = Nothing
                        .Duration = Nothing
                        .Notes = StringEnteredIn(cells, Me.colConsumableNotes, "Consumable Notes!")
                        .LoginID = CurrentUser.LoginID


                    End With

                    iPossibleAttachedItems.Add(oiPossibleAttachedItems)

                End Using

            Next
            Return iPossibleAttachedItems

        Catch ex As Exception
            Me.tbcBillExcludedItems.SelectTab(Me.tpgPossibleConsumables.Name)

            Throw ex

        End Try

    End Function

    Private Function PossibleDrugs() As List(Of DBConnect)

        Dim iPossibleAttachedItems As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Using oiPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    With oiPossibleAttachedItems
                        .AttachedItemCode = SubstringLeft(RevertText(StringMayBeEnteredIn(cboProcedureCode)))
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                        .ItemCategoryID = oItemCategoryID.Drug
                        .Quantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                        .UnitCost = DecimalEnteredIn(cells, Me.ColDrugUnitCost, False)
                        .UnitPrice = DecimalEnteredIn(cells, Me.ColDrugUnitPrice, False)
                        .Dosage = StringEnteredIn(cells, Me.ColDrugDosage, "Drug Notes!")
                        .Duration = StringEnteredIn(cells, Me.ColDuration, "Duration")
                        .Notes = StringEnteredIn(cells, Me.colDrugNotes, "Drug Notes!")
                        .LoginID = CurrentUser.LoginID


                    End With

                    iPossibleAttachedItems.Add(oiPossibleAttachedItems)

                End Using

            Next
            Return iPossibleAttachedItems

        Catch ex As Exception
            Me.tbcBillExcludedItems.SelectTab(Me.tpgPossiblePrescription.Name)

            Throw ex

        End Try

    End Function

    Private Function PossibleTheatreServices() As List(Of DBConnect)

        Dim iPossibleAttachedItems As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Using oiPossibleAttachedItems As New SyncSoft.SQLDb.PossibleAttachedItems

                    Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells

                    With oiPossibleAttachedItems
                        .AttachedItemCode = SubstringLeft(RevertText(StringMayBeEnteredIn(cboProcedureCode)))
                        .ItemCode = StringEnteredIn(cells, Me.colTheatreCode)
                        .ItemCategoryID = oItemCategoryID.Theatre
                        .Quantity = IntegerEnteredIn(cells, Me.colTheatreQuantity)
                        .UnitCost = DecimalEnteredIn(cells, Me.ColTheatreUnitCost, False)
                        .UnitPrice = DecimalEnteredIn(cells, Me.ColTheatreUnitPrice, False)
                        .Dosage = Nothing
                        .Duration = Nothing
                       .Notes = StringEnteredIn(cells, Me.colTheatreNotes, "Theatre Notes!")
                        .LoginID = CurrentUser.LoginID


                    End With

                    iPossibleAttachedItems.Add(oiPossibleAttachedItems)

                End Using

            Next
            Return iPossibleAttachedItems

        Catch ex As Exception
            Me.tbcBillExcludedItems.SelectTab(Me.tpgPossibleTheatreServices.Name)

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

            Dim itemCode As String = SubstringLeft(RevertText(StringMayBeEnteredIn(cboProcedureCode)))
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
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oBillCustomFee.Delete())
            Me.Procedurecalculation()
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

            Dim billCustomFee As DataTable = oBillCustomFee.GetBillCustomFee(itemCode, oItemCategoryID.Procedure).Tables("BillCustomFee")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillCustomFee, billCustomFee)

            For Each row As DataGridViewRow In Me.dgvBillCustomFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim itemCode As String = SubstringLeft(RevertText(StringMayBeEnteredIn(cboProcedureCode)))
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
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oInsuranceCustomFee.Delete())
            Me.Procedurecalculation()
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

            Dim insuranceCustomFee As DataTable = oInsuranceCustomFee.GetInsuranceCustomFee(itemCode, oItemCategoryID.Procedure).Tables("InsuranceCustomFee")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInsuranceCustomFee, insuranceCustomFee)

            For Each row As DataGridViewRow In Me.dgvInsuranceCustomFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " TheatrePossibleCosumables - Grid "

    Private Sub dgvConsumables_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvConsumables.CellBeginEdit

        If (e.ColumnIndex <> Me.colConsumableName.Index OrElse Me.dgvConsumables.Rows.Count <= 1) Then Return
        Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
        _consumableValue = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

    End Sub

    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        Try


            If e.ColumnIndex.Equals(Me.colConsumableName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvConsumables.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)
                    Me.Procedurecalculation()
                    If CBool(Me.dgvConsumables.Item(Me.ColConsumableItemsSaved.Name, selectedRow).Value).Equals(True) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Consumables As EnumerableRowCollection(Of DataRow) = consumableItems.AsEnumerable()
                        Dim consumableName As String = (From data In _Consumables
                                                        Where data.Field(Of String)("ConsumableNo").ToUpper().Equals(_consumableValue.ToUpper())
                                                        Select data.Field(Of String)("ConsumableFullName")).First()

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Consumable (" + consumableName + ")  can't be edited!")
                        Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Value = _consumableValue
                        Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = (StringMayBeEnteredIn(Me.dgvConsumables.Rows(rowNo).Cells, Me.colConsumableName))
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Consumables As EnumerableRowCollection(Of DataRow) = consumableItems.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Consumables
                                                                Where data.Field(Of String)("ConsumableFullName").ToUpper().Equals(enteredItem.ToUpper())
                                                                Select data.Field(Of String)("ConsumableFullName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Consumable Item (" + enteredDisplay + ") already entered!")
                                Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Value = _consumableValue
                                Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.DetailCosumableItems()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If
            Me.Procedurecalculation()
        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub DetailCosumableItems()

        Dim selectedRow As Integer
        Dim selectedItem As String = String.Empty

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.Rows.Count > 1 Then
                selectedRow = Me.dgvConsumables.CurrentCell.RowIndex
                selectedItem = SubstringRight(StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName))
            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvConsumables.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oConsumables As New SyncSoft.SQLDb.PossibleAttachedItems
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvConsumables.Item(Me.ColConsumableItemsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim itemCode As String = SubstringLeft(RevertText(StringMayBeEnteredIn(cboProcedureCode)))
            Dim consumableNo As String = SubstringRight(CStr(Me.dgvConsumables.Item(Me.colConsumableName.Name, toDeleteRowNo).Value))
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
            With oConsumables
                .AttachedItemCode = itemCode
                .ItemCode = consumableNo
                .ItemCategoryID = oItemCategoryID.Consumable
            End With

            DisplayMessage(oConsumables.Delete())
            Me.Procedurecalculation()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvConsumables_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvConsumables.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadAttachedTheatreConsumableItems(ByVal procedureCode As String)
        Dim oConsumableItem As New SyncSoft.SQLDb.PossibleAttachedItems
        Try
            Me.dgvConsumables.Rows.Clear()
            Dim theatrePossibleCosumables As DataTable = oConsumableItem.GetPossibleAttachedconsumables(procedureCode).Tables("PossibleAttachedItems")
            If theatrePossibleCosumables Is Nothing OrElse theatrePossibleCosumables.Rows.Count < 1 Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvConsumables, theatrePossibleCosumables)

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Me.dgvConsumables.Item(Me.ColConsumableItemsSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub LoadAttachedTheatreDrugs(ByVal procedureCode As String)
        Dim oConsumableItem As New SyncSoft.SQLDb.PossibleAttachedItems
        Try
            Me.dgvPrescription.Rows.Clear()
            Dim theatrePossibleDrugs As DataTable = oConsumableItem.GetPossibleAttachedDrugItems(procedureCode).Tables("PossibleAttachedItems")
            If theatrePossibleDrugs Is Nothing OrElse theatrePossibleDrugs.Rows.Count < 1 Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPrescription, theatrePossibleDrugs)

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub LoadAttachedTheatreServices(ByVal procedureCode As String)
        Dim oConsumableItem As New SyncSoft.SQLDb.PossibleAttachedItems
        Try
            Me.dgvTheatre.Rows.Clear()
            Dim theatrePossibleServices As DataTable = oConsumableItem.GetAttachedTheatreServices(procedureCode).Tables("PossibleAttachedItems")
            If theatrePossibleServices Is Nothing OrElse theatrePossibleServices.Rows.Count < 1 Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvTheatre, theatrePossibleServices)

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                Me.dgvTheatre.Item(Me.colTheatreSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub dgvConsumables_UserDeletedRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvConsumables.UserDeletedRow
        Me.Procedurecalculation()
    End Sub
#End Region

#Region " Prescription - Grid "

    Private Sub dgvPrescription_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrescription.CellBeginEdit

        If e.ColumnIndex <> Me.colDrug.Index OrElse Me.dgvPrescription.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
        _PrescriptionDrugValue = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Drug (" + _PrescriptionDrugValue + ") can't be edited!")
                Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Value = _PrescriptionDrugValue
                Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(rowNo).Cells, Me.colDrug)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Drug (" + enteredItem + ") already selected!")
                        Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Value = _PrescriptionDrugValue
                        Me.dgvPrescription.Item(Me.colDrug.Name, selectedRow).Selected = True
                    End If
                End If
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateQuantity(selectedRow, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvPrescription_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit

        
        Try

            If Me.colDrug.Items.Count < 1 Then Return
            Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colDrug.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvPrescription.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.ColDrugDosage.Index) Then
                Me.CalculateQuantity(selectedRow, True)


            ElseIf e.ColumnIndex.Equals(Me.ColDuration.Index) Then
                Me.CalculateQuantity(selectedRow, False)


            ElseIf e.ColumnIndex.Equals(Me.colDrugQuantity.Index) Then
                'Me.CalculateQuantity(selectedRow,False)

            End If
            Me.Procedurecalculation()
        Catch ex As Exception
            ErrorMessage(ex)

        End Try


    End Sub
    Private Sub dgvPrescription_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPrescription.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oItems As New SyncSoft.SQLDb.PossibleAttachedItems
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim itemCode As String = SubstringLeft(RevertText(StringMayBeEnteredIn(cboProcedureCode)))
            Dim drugNo As String = SubstringRight(CStr(Me.dgvPrescription.Item(Me.colDrug.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .AttachedItemCode = itemCode
                .ItemCode = drugNo
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oItems.Delete())
            Me.Procedurecalculation()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPrescription_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPrescription.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub



    Private Sub LoadPrescriptions(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvPrescription.Rows.Clear()

            ' Load items not yet paid for

            Dim drugs As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Drug).Tables("Items")
            If drugs Is Nothing OrElse drugs.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To drugs.Rows.Count - 1

                Dim row As DataRow = drugs.Rows(pos)
                Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                With Me.dgvPrescription
                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colDrugQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colPrescriptionSaved.Name, pos).Value = True
                End With

            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateQuantity(ByVal selectedRow As Integer, ByVal calculateDuration As Boolean)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oDosageCalculationID As New LookupDataID.DosageCalculationID()

        Try

            Dim quantity As Single = 0
            Dim drugNo As String = SubstringRight(StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug))

            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")

            If drugs Is Nothing OrElse drugs.Rows.Count < 1 OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)

            Dim dosage As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.ColDrugDosage)
            Dim duration As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDuration)

            Dim varyPrescribedQty As Boolean = BooleanEnteredIn(row, "VaryPrescribedQty")
            Dim defaultPrescribedQty As Integer = IntegerEnteredIn(row, "DefaultPrescribedQty")
            Dim dosageSeparator As Char = CChar(StringEnteredIn(row, "DosageSeparator").ToUpper())
            Dim dosageCalculationID As String = StringEnteredIn(row, "DosageCalculationID")
           
            If String.IsNullOrEmpty(dosage) Then Return

            If Not IsCharacterInString(dosage.Trim().ToUpper(), dosageSeparator) Then
                If dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Add.ToUpper()) Then
                    Select Case True
                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar(";".ToUpper()))
                            dosageSeparator = CChar(";".ToUpper())

                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar(":".ToUpper()))
                            dosageSeparator = CChar(":".ToUpper())

                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar("+".ToUpper()))
                            dosageSeparator = CChar("+".ToUpper())
                    End Select
                ElseIf dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Multiply.ToUpper()) Then
                    Select Case True
                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar("X".ToUpper()))
                            dosageSeparator = CChar("X".ToUpper())

                        Case IsCharacterInString(dosage.Trim().ToUpper(), CChar("*".ToUpper()))
                            dosageSeparator = CChar("*".ToUpper())
                    End Select
                End If
            End If

            Dim fullDosage() As String = dosage.Trim().ToUpper().Split(dosageSeparator)
            If fullDosage.Length < 2 Then Throw New ArgumentException("Dosage format incorrect!")

            If Not varyPrescribedQty Then
                If dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Add.ToUpper()) Then
                    For Each dose As String In fullDosage
                        Dim dailyDosage As Single
                        If IsNumeric(dose.Trim()) AndAlso Single.TryParse(dose.Trim(), dailyDosage) Then
                            quantity += dailyDosage
                        Else : Throw New ArgumentException("Dosage format incorrect at '" + dose + "', enter only as numeric separated with '" + dosageSeparator + "' character")
                        End If
                    Next

                ElseIf dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Multiply.ToUpper()) Then

                    If fullDosage.Length = 2 Then

                        Dim dailyDosage As Single
                        Dim dailyPeriod As Integer

                        Dim dose As String = fullDosage(fullDosage.GetLowerBound(0))
                        Dim period As String = fullDosage(fullDosage.GetUpperBound(0))

                        If IsNumeric(dose.Trim()) AndAlso Single.TryParse(dose.Trim(), dailyDosage) Then
                        Else : Throw New ArgumentException("Dosage format incorrect at '" + dose + "', enter only as numeric")
                        End If

                        If IsNumeric(period.Trim()) AndAlso Integer.TryParse(period.Trim(), dailyPeriod) Then
                        Else : Throw New ArgumentException("Dosage format incorrect at '" + period + "', enter only as numeric with no decimal places")
                        End If

                        quantity = dailyDosage * dailyPeriod * duration

                    Else : Throw New ArgumentException("Dosage format incorrect, enter only as numeric separated with '" + dosageSeparator + "' character e.g. 2" + dosageSeparator + "1")
                    End If

                Else : quantity = defaultPrescribedQty
                End If
            Else : quantity = defaultPrescribedQty
            End If

            If calculateDuration AndAlso dosageCalculationID.ToUpper().Equals(oDosageCalculationID.Add.ToUpper()) Then
                Me.dgvPrescription.Item(Me.colDuration.Name, selectedRow).Value = fullDosage.Length
            End If

            Me.dgvPrescription.Item(Me.colDrugQuantity.Name, selectedRow).Value = CInt(quantity)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

#Region " Theatre - Grid "

    Private Sub dgvTheatre_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvTheatre.CellBeginEdit

        If e.ColumnIndex <> Me.colTheatreCode.Index OrElse Me.dgvTheatre.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex
        _TheatreNameValue = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

    End Sub

    Private Sub dgvTheatre_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTheatre.CellEndEdit

        Try

            If Me.colTheatreCode.Items.Count < 1 Then Return
            Dim selectedRow As Integer = Me.dgvTheatre.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colTheatreCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvTheatre.Rows.Count > 1 Then Me.SetTheatreEntries(selectedRow)

            End If
            Me.Procedurecalculation()
        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetTheatreEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _TheatreServices As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                Dim TheatreDisplay As String = (From data In _TheatreServices
                                                Where data.Field(Of String)("TheatreCode").ToUpper().Equals(_TheatreNameValue.ToUpper())
                                                Select data.Field(Of String)("TheatreName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Theatre (" + TheatreDisplay + ") can't be edited!")
                Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Value = _TheatreNameValue
                Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvTheatre.Rows(rowNo).Cells, Me.colTheatreCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _TheatreServices As EnumerableRowCollection(Of DataRow) = theatreServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _TheatreServices
                                                        Where data.Field(Of String)("TheatreCode").ToUpper().Equals(enteredItem.ToUpper())
                                                        Select data.Field(Of String)("TheatreName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Theatre (" + enteredDisplay + ") already selected!")
                        Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Value = _TheatreNameValue
                        Me.dgvTheatre.Item(Me.colTheatreCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next


        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvTheatre_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvTheatre.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oItems As New SyncSoft.SQLDb.PossibleAttachedItems
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim itemCode As String = SubstringLeft(RevertText(StringMayBeEnteredIn(cboProcedureCode)))
            Dim theatreCode As String = SubstringRight(CStr(Me.dgvTheatre.Item(Me.colTheatreCode.Name, toDeleteRowNo).Value))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .AttachedItemCode = itemCode
                .ItemCode = theatreCode
                .ItemCategoryID = oItemCategoryID.Theatre
            End With
            Me.Procedurecalculation()
            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvTheatre_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvTheatre.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub dgvTheatre_UserDeletedRow(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvTheatre.UserDeletedRow
        Me.Procedurecalculation()
    End Sub

    Private Sub LoadTheatre(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvTheatre.Rows.Clear()

            ' Load items not yet paid for

            Dim theatre As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Theatre).Tables("Items")
            If theatre Is Nothing OrElse theatre.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvTheatre, theatre)

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                Me.dgvTheatre.Item(Me.colTheatreSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update

        Me.cboProcedureCode.MaxLength = 34
        Me.LoadProcedures(True)
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True
        Me.chkHidden.Enabled = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgBillCustomFee)
        ResetControlsIn(Me.tpgInsuranceCustomFee)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.cboProcedureCode.MaxLength = 10
        Me.LoadProcedures(False)
        Me.chkHidden.Enabled = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgBillCustomFee)
        ResetControlsIn(Me.tpgInsuranceCustomFee)
        Me.SetNextProcedureID()

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0
            Security.Apply(Me.stbProcedureName, AccessRights.Update)
            Security.Apply(Me.nbxUnitPrice, AccessRights.Update)
            Security.Apply(Me.nbxVATPercentage, AccessRights.Update)
            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            Security.Apply(Me.dgvBillCustomFee, AccessRights.Write)
            Security.Apply(Me.dgvInsuranceCustomFee, AccessRights.Write)

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

  

    Private Sub cboProcedureCode_Leave(sender As Object, e As EventArgs) Handles cboProcedureCode.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.stbProcedureName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboProcedureCode)))
            Me.cboProcedureCode.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboProcedureCode)))
        End If
    End Sub


    Private Sub LoadProcedures(ByVal populate As Boolean)

        Dim oProcedure As New SyncSoft.SQLDb.Procedures()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim procedure As DataTable = oProcedure.GetProcedures().Tables("Procedures")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If populate Then
                LoadComboData(Me.cboProcedureCode, procedure, "ProcedureFullName")
            Else : Me.cboProcedureCode.Items.Clear()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " SET AUTONUMBERS"

    Private Sub SetNextProcedureID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oProcedures As New SyncSoft.SQLDb.Procedures()
            Dim oVariousOption As New VariousOptions()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Procedures", "ProcedureCode").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim ProcedureCodePrefix As String = oVariousOption.ProcedureCodePrefix
            Dim nextProcedureCode As String = CStr(oProcedures.GetNextProcedureID).PadLeft(paddingLEN, paddingCHAR)
            Me.cboProcedureCode.Text = FormatText((ProcedureCodePrefix + nextProcedureCode).Trim(), "Procedures", "ProcedureCode")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region "Calculations"

    Private Sub CalculateProcedureUnitCost()

        Dim totalBill, totalDrugCost, totalConsumablecost, totaTheatreServices As Decimal


        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
            Dim amount As Decimal = (DecimalMayBeEnteredIn(cells, Me.ColDrugUnitCost) * DecimalMayBeEnteredIn(cells, Me.colDrugQuantity))
            totalDrugCost += amount
        Next

        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
            Dim amount As Decimal = (DecimalMayBeEnteredIn(cells, Me.ColConUnitCost) * DecimalMayBeEnteredIn(cells, Me.colConsumableQuantity))
            totalConsumablecost += amount
        Next


        For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
            Dim amount As Decimal = (DecimalMayBeEnteredIn(cells, Me.ColTheatreUnitCost) * DecimalMayBeEnteredIn(cells, Me.colTheatreQuantity))
            totaTheatreServices += amount
        Next


        totalBill = (totalDrugCost + totalConsumablecost + totaTheatreServices)

        Me.nbxUnitCost.Text = FormatNumber(totalBill, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateProcedureUnitPrice()

        Dim totalBill, totalDrugUnitprice, totalConsumableUnitprice, totalTheatreServicesunitprice As Decimal


        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
            Dim amount As Decimal = (DecimalMayBeEnteredIn(cells, Me.ColDrugUnitPrice) * DecimalMayBeEnteredIn(cells, Me.colDrugQuantity))
            totalDrugUnitprice += amount
        Next

        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
            Dim amount As Decimal = (DecimalMayBeEnteredIn(cells, Me.ColConsUnitPrice) * DecimalMayBeEnteredIn(cells, Me.colConsumableQuantity))
            totalConsumableUnitprice += amount
        Next


        For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
            Dim amount As Decimal = (DecimalMayBeEnteredIn(cells, Me.ColTheatreUnitPrice) * DecimalMayBeEnteredIn(cells, Me.colTheatreQuantity))
            totalTheatreServicesunitprice += amount
        Next


        totalBill = (totalDrugUnitprice + totalConsumableUnitprice + totalTheatreServicesunitprice)

        Me.nbxUnitPrice.Text = FormatNumber(totalBill, AppData.DecimalPlaces)

    End Sub

    Private Sub Procedurecalculation()
        Me.CalculateProcedureUnitCost()
        Me.CalculateProcedureUnitPrice()
    End Sub
#End Region

#Region " Procedures Printing "



    Private Sub PrintProcedures()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount < 1 OrElse Me.dgvConsumables.RowCount < 1 OrElse Me.dgvTheatre.RowCount < 1 Then
                Throw New ArgumentException("Must set at least one entry on Order details!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetProceduresPrintData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docProcedures
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docProcedures.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docProcedures_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docProcedures.PrintPage

        Try
            Dim m_PagesPrinted As Integer
            m_PagesPrinted = 0
            'Const gutter As Integer = 100
            '
            Dim string_format As New StringFormat
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Procedures".ToUpper()

            Dim procNo As String = StringMayBeEnteredIn(Me.cboProcedureCode)
            Dim procName As String = StringMayBeEnteredIn(Me.stbProcedureName)
            Dim unitPrice As String = StringMayBeEnteredIn(Me.nbxUnitPrice)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 11 * widthTopFirst
                Dim widthTopThird As Single = 20 * widthTopFirst
                Dim widthTopFourth As Single = 29 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    Dim oProductOwner As ProductOwner = GetProductOwnerInfo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Procedure Code: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(procNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += 2 * lineHeight

                    .DrawString("Procedure Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(procName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += 2 * lineHeight

                    .DrawString("Unit Price: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(unitPrice, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    yPos += 2 * lineHeight

                End If

                Dim _StringFormat As New StringFormat()

                ' Draw the rest of the text left justified,
                ' wrap at words, and don't draw partial lines.

                With _StringFormat
                    .Alignment = StringAlignment.Near
                    .FormatFlags = StringFormatFlags.LineLimit
                    .Trimming = StringTrimming.Word
                End With

                Dim charactersFitted As Integer
                Dim linesFilled As Integer

                If orderParagraphs Is Nothing Then Return

                Do While orderParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(orderParagraphs(1), PrintParagraps)
                    orderParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
                        New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

                    ' See if any characters will fit.
                    If charactersFitted > 0 Then
                        ' Draw the text.
                        .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
                        ' Increase the location where we can start, add a little interparagraph spacing.
                        yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

                    End If

                    ' See if some of the paragraph didn't fit on the page.
                    If charactersFitted < oPrintParagraps.Text.Length Then
                        ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
                        oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
                        orderParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (orderParagraphs.Count > 0)


                Dim x As Integer = (e.MarginBounds.Right + e.PageBounds.Right) \ 2
                string_format.Alignment = StringAlignment.Far

                e.Graphics.DrawString(m_PagesPrinted.ToString, bodyNormalFont, Brushes.Black, x,
                (e.MarginBounds.Top + e.PageBounds.Top) \ 2, string_format)



            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetProceduresPrintData()

        Dim footerFont As New Font(printFontName, 9)

        itemCount = 0
        pageNo = 0
        orderParagraphs = New Collection()

        Try

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Qty: ".PadLeft(padQuantity))
            'tableHeader.Append("Rate: ".PadLeft(padRate))
            'tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DrugsData().ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ConsumablesData().ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            orderParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.theatreData().ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim totalDrugUnitprice, totalConsumableUnitprice, totalTheatreServicesunitprice As Decimal


            'For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1
            '    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
            '    Dim amount As Decimal = (DecimalMayBeEnteredIn(cells, Me.ColDrugUnitPrice) * DecimalMayBeEnteredIn(cells, Me.colDrugQuantity))
            '    totalDrugUnitprice += amount
            'Next

            'For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1
            '    Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
            '    Dim amount As Decimal = (DecimalMayBeEnteredIn(cells, Me.ColConsUnitPrice) * DecimalMayBeEnteredIn(cells, Me.colConsumableQuantity))
            '    totalConsumableUnitprice += amount
            'Next


            'For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1
            '    Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
            '    Dim amount As Decimal = (DecimalMayBeEnteredIn(cells, Me.ColTheatreUnitPrice) * DecimalMayBeEnteredIn(cells, Me.colTheatreQuantity))
            '    totalTheatreServicesunitprice += amount
            'Next


            'Dim totalAmountData As New System.Text.StringBuilder(String.Empty)
            'Dim totalAmount As Decimal = totalDrugUnitprice + totalConsumableUnitprice + totalTheatreServicesunitprice

            'totalAmountData.Append(ControlChars.NewLine)
            'totalAmountData.Append("Total Amount: ")
            'totalAmountData.Append(FormatNumber(totalAmount, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            'totalAmountData.Append(ControlChars.NewLine)
            'orderParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmountData.ToString()))

            ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            'Dim amountWords As String = NumberToWords(totalAmount)
            'totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            'totalAmountWords.Append(ControlChars.NewLine)
            'orderParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)



            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            orderParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function DrugsData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemName As String = SubstringLeft(cells.Item(Me.colDrug.Name).Value.ToString())
                Dim quantity As String = cells.Item(Me.colDrugQuantity.Name).Value.ToString()
                'Dim rate As String = cells.Item(Me.ColDrugUnitPrice.Name).Value.ToString()
                'Dim amount As String = (DecimalMayBeEnteredIn(cells, Me.ColDrugUnitPrice) * DecimalMayBeEnteredIn(cells, Me.colDrugQuantity)).ToString

                tableData.Append(itemNo.PadRight(padItemNo))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                If wrappeditemName.Count > 1 Then
                    For pos As Integer = 0 To wrappeditemName.Count - 1
                        tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                        If Not pos = wrappeditemName.Count - 1 Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padItemNo))
                        Else
                            tableData.Append(quantity.PadLeft(padQuantity))

                            'tableData.Append(rate.PadLeft(padRate))
                            'tableData.Append(amount.PadLeft(padAmount))
                        End If
                    Next

                Else
                    tableData.Append(FixDataLength(itemName, padItemName))
                    tableData.Append(quantity.PadLeft(padQuantity))

                    'tableData.Append(rate.PadLeft(padRate))
                    'tableData.Append(amount.PadLeft(padAmount))

                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(ControlChars.NewLine)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function ConsumablesData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemName As String = SubstringLeft(cells.Item(Me.colConsumableName.Name).Value.ToString())
                Dim quantity As String = cells.Item(Me.colConsumableQuantity.Name).Value.ToString()
                'Dim rate As String = cells.Item(Me.ColConsUnitPrice.Name).Value.ToString()
                'Dim amount As String = (DecimalMayBeEnteredIn(cells, Me.ColConsUnitPrice) * DecimalMayBeEnteredIn(cells, Me.colConsumableQuantity)).ToString

                tableData.Append(itemNo.PadRight(padItemNo))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                If wrappeditemName.Count > 1 Then
                    For pos As Integer = 0 To wrappeditemName.Count - 1
                        tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                        If Not pos = wrappeditemName.Count - 1 Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padItemNo))
                        Else
                            tableData.Append(quantity.PadLeft(padQuantity))

                            'tableData.Append(rate.PadLeft(padRate))
                            'tableData.Append(amount.PadLeft(padAmount))
                        End If
                    Next

                Else
                    tableData.Append(FixDataLength(itemName, padItemName))
                    tableData.Append(quantity.PadLeft(padQuantity))

                    'tableData.Append(rate.PadLeft(padRate))
                    'tableData.Append(amount.PadLeft(padAmount))
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(ControlChars.NewLine)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function theatreData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemName As String = cells.Item(Me.colTheatreCode.Name).FormattedValue.ToString
                Dim quantity As String = cells.Item(Me.colTheatreQuantity.Name).Value.ToString()
                'Dim rate As String = cells.Item(Me.ColTheatreUnitCost.Name).Value.ToString()
                'Dim amount As String = (DecimalMayBeEnteredIn(cells, Me.ColTheatreUnitPrice) * DecimalMayBeEnteredIn(cells, Me.colTheatreQuantity)).ToString

                tableData.Append(itemNo.PadRight(padItemNo))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                If wrappeditemName.Count > 1 Then
                    For pos As Integer = 0 To wrappeditemName.Count - 1
                        tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                        If Not pos = wrappeditemName.Count - 1 Then
                            tableData.Append(ControlChars.NewLine)
                            tableData.Append(GetSpaces(padItemNo))
                        Else
                            tableData.Append(quantity.PadLeft(padQuantity))

                            'tableData.Append(rate.PadLeft(padRate))
                            'tableData.Append(amount.PadLeft(padAmount))
                        End If
                    Next

                Else
                    tableData.Append(FixDataLength(itemName, padItemName))
                    tableData.Append(quantity.PadLeft(padQuantity))

                    'tableData.Append(rate.PadLeft(padRate))
                    'tableData.Append(amount.PadLeft(padAmount))

                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(ControlChars.NewLine)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function



#End Region

  
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintProcedures()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub
End Class