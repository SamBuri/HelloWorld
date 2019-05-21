
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
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Collections.Generic

Public Class frmLabTests

#Region " Fields "

    Private labTests As DataTable
    Private billCustomers As DataTable
    Private insurances As DataTable
    Private consumableItems As DataTable

    Private _AccountNoValue As String = String.Empty
    Private _insuranceNoValue As String = String.Empty

    Private _PossibleResultValue As String = String.Empty
    Private _SubTestCodeValue As String = String.Empty
    Private _SubTestNameValue As String = String.Empty
    Private oVariousOptions As New VariousOptions()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID
#End Region

    Private Sub frmLabTests_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboSpecimenTypeID, LookupObjects.SpecimenType, False)
            LoadLookupDataCombo(Me.cboLabsID, LookupObjects.Labs, False)
            LoadLookupDataCombo(Me.cboUnitMeasureID, LookupObjects.UnitMeasure, False)
            LoadLookupDataCombo(Me.colUnitMeasureID, LookupObjects.UnitMeasure, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.colBillCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.colInsuranceCurrenciesID, LookupObjects.Currencies, False)

            LoadLookupDataCombo(Me.clbTubeTypes, LookupObjects.TubeType, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' LoadchartOfAccountsCategory(Me.CboRevenueStream, oVariousOptions.GetBusinessIncomeAccountCategoryNo)



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ResultDataType()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadLabTests()
            Me.LoadBillCustomers()
            Me.LoadInsurances()
            Me.LoadConsumableItems()


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmLabTests_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
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


    Private Sub ResultDataType()

        Dim oLookupData As New LookupData()
        Dim oDataTypeID As New LookupCommDataID.SearchDataTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lookupData As DataTable = oLookupData.GetLookupData(LookupCommObjects.SearchDataType).Tables("LookupData")
            If lookupData Is Nothing Then Return

            For Each dr As DataRow In lookupData.Rows
                If oDataTypeID.Boolean.ToUpper().Equals(dr.Item("DataID").ToString().ToUpper()) OrElse
                    oDataTypeID.DateTime.ToUpper().Equals(dr.Item("DataID").ToString().ToUpper()) OrElse
                    oDataTypeID.Money.ToUpper().Equals(dr.Item("DataID").ToString().ToUpper()) Then
                    dr.Delete()
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fcbResultDataTypeID.Sorted = False
            Me.fcbResultDataTypeID.DataSource = lookupData
            Me.fcbResultDataTypeID.DisplayMember = "DataDes"
            Me.fcbResultDataTypeID.ValueMember = "DataID"
            Me.fcbResultDataTypeID.SelectedValue = oDataTypeID.String

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colResultDataTypeID.Sorted = False
            Me.colResultDataTypeID.DataSource = lookupData
            Me.colResultDataTypeID.DisplayMember = "DataDes"
            Me.colResultDataTypeID.ValueMember = "DataID"

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub cboTestCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTestCode.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub cboTestCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTestCode.Leave

        Try

            Dim testCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboTestCode)).ToUpper()
            Me.cboTestCode.Text = testCode.ToUpper()

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Return

            For Each row As DataRow In labTests.Select("TestCode = '" + testCode + "'")
                Me.stbTestName.Text = StringMayBeEnteredIn(row, "TestName")
            Next

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadLabTests()

        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from LabTests

            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            labTests = oLabTests.GetLabTests().Tables("LabTests")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadLabTests(ByVal populate As Boolean)

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If populate Then
                LoadComboData(Me.cboTestCode, labTests, "TestFullName")
            Else : Me.cboTestCode.Items.Clear()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oLabTests.TestCode = SubstringRight(RevertText(StringEnteredIn(Me.cboTestCode, "Test Code!")))
            DisplayMessage(oLabTests.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me.tpgGeneral)
            ResetControlsIn(Me.tpgBillCustomFee)
            ResetControlsIn(Me.tpgInsuranceCustomFee)
            ResetControlsIn(Me.tpgLabPossibleResults)
            ResetControlsIn(Me.tpgLabTestsEXT)
            ResetControlsIn(Me.pnlResultDataTypeID)
            Me.CallOnKeyEdit()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim testCode As String = SubstringRight(RevertText(StringEnteredIn(Me.cboTestCode, "Test Code")))
            Dim dataSource As DataTable = oLabTests.GetLabTests(testCode).Tables("LabTests")
            Me.DisplayData(dataSource)

            Me.LoadBillCustomFee(testCode)
            Me.LoadInsuranceCustomFee(testCode)
            Me.LoadLabPossibleResults(testCode)
            Me.LoadLabTestsEXT(testCode)
            Me.LoadAttachedTestConsumableItems(testCode)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim records As Integer
        Dim testCode As String = SubstringRight(RevertText(StringEnteredIn(Me.cboTestCode, "Test Code!"))).ToUpper()
        Dim itemCategoryID As String = oItemCategoryID.Test

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oLabTests As New SyncSoft.SQLDb.LabTests()

            Dim lLabTests As New List(Of DBConnect)
            Dim transactions As New List(Of TransactionList(Of DBConnect))

            With oLabTests

                .TestCode = testCode
                .TestName = StringEnteredIn(Me.stbTestName, "Test Name!")
                .SpecimenTypeID = StringValueEnteredIn(cboSpecimenTypeID, "Specimen Type")
                .LabsID = StringValueEnteredIn(Me.cboLabsID, "Lab!")
                .NormalRange = StringMayBeEnteredIn(Me.stbNormalRange)
                .UnitMeasureID = StringValueEnteredIn(Me.cboUnitMeasureID, "Unit Measure!")
                .UnitCost = Me.nbxUnitCost.GetDecimal(False)
                .VATPercentage = DecimalMayBeEnteredIn(nbxVATPercentage, False)
                .TestFee = Me.nbxTestFee.GetDecimal(False)
                .ResultDataTypeID = StringValueEnteredIn(Me.fcbResultDataTypeID, "Result data type!")
                .TubeType = StringToSplitSelectedIn(Me.clbTubeTypes, LookupObjects.TubeType)
                .TestDescription = StringMayBeEnteredIn(stbBriefTestDescription)
                '.RevenueStream = SubstringRight(StringEnteredIn(Me.CboRevenueStream, "Revenue Stream!"))
                .Hidden = Me.chkHidden.Checked
                .RequiresResultsApproval = Me.chkRequiresResultsApproval.Checked
                .LoginID = CurrentUser.LoginID
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me.tpgGeneral)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lLabTests.Add(oLabTests)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oLabTests.UnitCost >= oLabTests.TestFee Then

                If oLabTests.UnitCost = oLabTests.TestFee Then
                    message = "Unit Cost equals Test Fee. "
                Else : message = "Unit Cost is more than Test Fee. "
                End If
                message += ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.nbxUnitCost.Focus() : Return

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oLabTests.Hidden.Equals(True) Then
                message = "You have chosen to hide this lab test and won’t be presented for selection. " +
                                        ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.chkHidden.Focus() : Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            OpenBillableMappings(ebnSaveUpdate.ButtonText, oItemCategoryID.Test, testCode)
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save


                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lLabTests, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(LabPossibleResultsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(LabTestsEXTList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleCosumables, Action.Save))

                    records = DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me.tpgGeneral)
                    ResetControlsIn(Me.tpgBillCustomFee)
                    ResetControlsIn(Me.tpgInsuranceCustomFee)
                    ResetControlsIn(Me.tpgLabPossibleResults)
                    ResetControlsIn(Me.tpgLabTestsEXT)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetNextTestID()

                Case ButtonCaption.Update

                    'Security.Apply(Me.btnDelete, AccessRights.Delete)
                    'If Me.btnDelete.Enabled = False Then
                    '    DisplayMessage("You do not have permission to delete this record!")
                    '    e.Cancel = True
                    '    Return
                    'End If

                    transactions.Add(New TransactionList(Of DBConnect)(lLabTests, Action.Update, "LabTests"))
                    transactions.Add(New TransactionList(Of DBConnect)(BillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(LabPossibleResultsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(LabTestsEXTList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PossibleCosumables, Action.Save))

                    records = DoTransactions(transactions)

                    DisplayMessage(records.ToString() + " record(s) updated!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.CallOnKeyEdit()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvBillCustomFee.RowCount - 2
                Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, rowNo).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvInsuranceCustomFee.RowCount - 2
                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, rowNo).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvLabPossibleResults.RowCount - 2
                Me.dgvLabPossibleResults.Item(Me.colPossibleResultSaved.Name, rowNo).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvLabTestsEXT.RowCount - 2
                Me.dgvLabTestsEXT.Item(Me.colSaved.Name, rowNo).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2
                Me.dgvConsumables.Item(Me.ColConsumableItemsSaved.Name, rowNo).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function BillCustomFeeList() As List(Of DBConnect)

        Dim lBillCustomFee As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboTestCode, "Test Code!"))

            For rowNo As Integer = 0 To Me.dgvBillCustomFee.RowCount - 2

                Using oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillCustomFee.Rows(rowNo).Cells

                    With oBillCustomFee

                        .AccountNo = StringEnteredIn(cells, Me.colBillCustomerName, "To-Bill Account Name!")
                        .ItemCode = itemCode
                        .ItemCategoryID = oItemCategoryID.Test
                        .CustomFee = DecimalEnteredIn(cells, Me.colBillCustomFee, False, "Custom Fee!")
                        .CurrenciesID = StringEnteredIn(cells, Me.colBillCurrenciesID, "Currency!")

                    End With

                    lBillCustomFee.Add(oBillCustomFee)

                End Using

            Next

            Return lBillCustomFee

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function InsuranceCustomFeeList() As List(Of DBConnect)

        Dim lInsuranceCustomFee As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboTestCode, "Test Code!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceCustomFee.RowCount - 2

                Using oInsuranceCustomFee As New SyncSoft.SQLDb.InsuranceCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceCustomFee.Rows(rowNo).Cells

                    With oInsuranceCustomFee

                        .InsuranceNo = StringEnteredIn(cells, Me.colInsuranceName, "Insurance Name!")
                        .ItemCode = itemCode
                        .ItemCategoryID = oItemCategoryID.Test
                        .CustomFee = DecimalEnteredIn(cells, Me.colInsuranceCustomFee, False, "Custom Fee!")
                        .CurrenciesID = StringEnteredIn(cells, Me.colInsuranceCurrenciesID, "Currency!")

                    End With

                    lInsuranceCustomFee.Add(oInsuranceCustomFee)

                End Using

            Next

            Return lInsuranceCustomFee

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function LabPossibleResultsList() As List(Of DBConnect)

        Dim oDataTypeID As New LookupCommDataID.SearchDataTypeID()
        Dim lLabPossibleResults As New List(Of DBConnect)

        Try

            Dim testCode As String = RevertText(StringEnteredIn(Me.cboTestCode, "Test Code!"))
            Dim resultDataTypeID As String = StringValueEnteredIn(Me.fcbResultDataTypeID)

            For rowNo As Integer = 0 To Me.dgvLabPossibleResults.RowCount - 2

                Using oLabPossibleResults As New SyncSoft.SQLDb.LabPossibleResults()

                    Dim cells As DataGridViewCellCollection = Me.dgvLabPossibleResults.Rows(rowNo).Cells
                    Dim possibleResult As String = StringEnteredIn(cells, Me.colPossibleResult, "Possible Result!")

                    Select Case resultDataTypeID
                        Case oDataTypeID.Decimal, oDataTypeID.Number
                            If Not IsNumeric(possibleResult) Then
                                Throw New ArgumentException("All Possible Result for Test Code: " + testCode + " should be numeric!")
                            End If
                        Case Else
                    End Select

                    With oLabPossibleResults
                        .TestCode = testCode
                        .PossibleResult = possibleResult
                    End With

                    lLabPossibleResults.Add(oLabPossibleResults)

                End Using

            Next

            Return lLabPossibleResults

        Catch ex As Exception
            Me.tbcLabTestsMORE.SelectTab(Me.tpgLabPossibleResults)
            Throw ex

        End Try

    End Function

    Private Function LabTestsEXTList() As List(Of DBConnect)

        Dim lLabTestsEXT As New List(Of DBConnect)

        Try

            Dim testCode As String = StringEnteredIn(Me.cboTestCode, "Test Code!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvLabTestsEXT.RowCount - 2

                Using oLabTestsEXT As New SyncSoft.SQLDb.LabTestsEXT()

                    Dim cells As DataGridViewCellCollection = Me.dgvLabTestsEXT.Rows(rowNo).Cells

                    With oLabTestsEXT
                        .TestCode = testCode
                        .SubTestCode = StringEnteredIn(cells, Me.colSubTestCode, "sub test code!")
                        .SubTestName = StringEnteredIn(cells, Me.colSubTestName, "sub test name!")
                        .NormalRange = StringMayBeEnteredIn(cells, Me.colNormalRange)
                        .UnitMeasureID = StringEnteredIn(cells, Me.colUnitMeasureID, "unit measure!")
                        .ResultDataTypeID = StringEnteredIn(cells, Me.colResultDataTypeID, "result type of data!")
                        .Hidden = BooleanEnteredIn(cells, Me.colHidden, "hidden!")

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If oLabTestsEXT.Hidden.Equals(True) Then
                            Dim message As String = "You have chosen to hide " + .SubTestName + " and won’t be presented for selection. " +
                                                    ControlChars.NewLine + "Are you sure you want to continue?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action cancelled!")

                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    End With

                    lLabTestsEXT.Add(oLabTestsEXT)

                End Using

            Next

            Return lLabTestsEXT

        Catch ex As Exception
            Me.tbcLabTests.SelectTab(Me.tpgLabTestsEXT.Name)
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
                        .AttachedItemCode = SubstringLeft(RevertText(StringMayBeEnteredIn(Me.cboTestCode)))
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colConsumableName))
                        .ItemCategoryID = oItemCategoryID.Consumable
                        .Quantity = IntegerEnteredIn(cells, Me.colConsumableQuantity)
                        .UnitCost = DecimalEnteredIn(cells, Me.ColUnitCost, False, "Unit Cost!")
                        .UnitPrice = DecimalEnteredIn(cells, Me.ColUnitPrice, False, "Unit Price!")
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
            Me.tbcLabTestsMORE.SelectTab(Me.tpgPossibleConsumables.Name)

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(selectedItem) Then
                Me.dgvBillCustomFee.Item(Me.colAccountNo.Name, selectedRow).Value = selectedItem
            Else : Me.dgvBillCustomFee.Item(Me.colAccountNo.Name, selectedRow).Value = String.Empty
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboTestCode, "Test Code!"))
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
                .ItemCategoryID = oItemCategoryID.Test
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

            Dim billCustomFee As DataTable = oBillCustomFee.GetBillCustomFee(itemCode, oItemCategoryID.Test).Tables("BillCustomFee")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillCustomFee, billCustomFee)

            For Each row As DataGridViewRow In Me.dgvBillCustomFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillCustomFee.Item(Me.colBillCustomFeeSaved.Name, row.Index).Value = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboTestCode, "Test Code!"))
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
                .ItemCategoryID = oItemCategoryID.Test
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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim insuranceCustomFee As DataTable = oInsuranceCustomFee.GetInsuranceCustomFee(itemCode, oItemCategoryID.Test).Tables("InsuranceCustomFee")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInsuranceCustomFee, insuranceCustomFee)

            For Each row As DataGridViewRow In Me.dgvInsuranceCustomFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, row.Index).Value = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " LabPossibleResults - Grid "

    Private Sub dgvLabPossibleResults_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvLabPossibleResults.CellBeginEdit

        If e.ColumnIndex <> Me.colPossibleResult.Index OrElse Me.dgvLabPossibleResults.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvLabPossibleResults.CurrentCell.RowIndex
        _PossibleResultValue = StringMayBeEnteredIn(Me.dgvLabPossibleResults.Rows(selectedRow).Cells, Me.colPossibleResult)

    End Sub

    Private Sub dgvLabPossibleResults_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabPossibleResults.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colPossibleResult.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvLabPossibleResults.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvLabPossibleResults.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvLabPossibleResults.Rows(selectedRow).Cells, Me.colPossibleResult)

                    If CBool(Me.dgvLabPossibleResults.Item(Me.colPossibleResultSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Possible Result (" + _PossibleResultValue + ") can't be edited!")
                        Me.dgvLabPossibleResults.Item(Me.colPossibleResult.Name, selectedRow).Value = _PossibleResultValue
                        Me.dgvLabPossibleResults.Item(Me.colPossibleResult.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvLabPossibleResults.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvLabPossibleResults.Rows(rowNo).Cells, Me.colPossibleResult)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Possible Result (" + enteredItem + ") already entered!")
                                Me.dgvLabPossibleResults.Item(Me.colPossibleResult.Name, selectedRow).Value = _PossibleResultValue
                                Me.dgvLabPossibleResults.Item(Me.colPossibleResult.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvLabPossibleResults_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLabPossibleResults.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oLabPossibleResults As New SyncSoft.SQLDb.LabPossibleResults()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvLabPossibleResults.Item(Me.colPossibleResultSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim testCode As String = RevertText(StringEnteredIn(Me.cboTestCode, "Test Code!"))
            Dim possibleResult As String = CStr(Me.dgvLabPossibleResults.Item(Me.colPossibleResult.Name, toDeleteRowNo).Value)

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

            With oLabPossibleResults
                .TestCode = testCode
                .PossibleResult = possibleResult
            End With

            DisplayMessage(oLabPossibleResults.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadLabPossibleResults(ByVal testCode As String)

        Dim oLabPossibleResults As New SyncSoft.SQLDb.LabPossibleResults()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load items not yet paid for

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim labPossibleResults As DataTable = oLabPossibleResults.GetLabPossibleResults(RevertText(testCode)).Tables("LabPossibleResults")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvLabPossibleResults, labPossibleResults)

            For Each row As DataGridViewRow In Me.dgvLabPossibleResults.Rows
                If row.IsNewRow Then Exit For
                Me.dgvLabPossibleResults.Item(Me.colPossibleResultSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " LabTestsEXT - Grid "

    Private Sub dgvLabTestsEXT_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvLabTestsEXT.CellBeginEdit

        Dim selectedRow As Integer

        Try
            If Me.dgvLabTestsEXT.Rows.Count <= 1 Then Return

            If e.ColumnIndex = Me.colSubTestCode.Index Then
                selectedRow = Me.dgvLabTestsEXT.CurrentCell.RowIndex
                _SubTestCodeValue = StringMayBeEnteredIn(Me.dgvLabTestsEXT.Rows(selectedRow).Cells, Me.colSubTestCode)

            ElseIf e.ColumnIndex = Me.colSubTestName.Index Then
                selectedRow = Me.dgvLabTestsEXT.CurrentCell.RowIndex
                _SubTestNameValue = StringMayBeEnteredIn(Me.dgvLabTestsEXT.Rows(selectedRow).Cells, Me.colSubTestName)

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvLabTestsEXT_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabTestsEXT.CellEndEdit

        Dim selectedRow As Integer
        Dim selectedItem As String
        Dim enteredItem As String

        Try

            If e.ColumnIndex.Equals(Me.dgvLabTestsEXT.Columns(Me.colSubTestCode.Name).Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvLabTestsEXT.Rows.Count > 1 Then

                    selectedRow = Me.dgvLabTestsEXT.CurrentCell.RowIndex
                    selectedItem = StringMayBeEnteredIn(Me.dgvLabTestsEXT.Rows(selectedRow).Cells, Me.colSubTestCode)

                    If CBool(Me.dgvLabTestsEXT.Item(Me.colSaved.Name, selectedRow).Value).Equals(True) Then
                        MessageBox.Show("Sub Test Code (" + _SubTestCodeValue + ") can't be edited!", AppData.AppTitle)
                        Me.dgvLabTestsEXT.Item(Me.colSubTestCode.Name, selectedRow).Value = _SubTestCodeValue
                        Me.dgvLabTestsEXT.Item(Me.colSubTestCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvLabTestsEXT.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            enteredItem = StringMayBeEnteredIn(Me.dgvLabTestsEXT.Rows(rowNo).Cells, Me.colSubTestCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                MessageBox.Show("Sub Test Code (" + enteredItem + ") already entered!", AppData.AppTitle)
                                Me.dgvLabTestsEXT.Item(Me.colSubTestCode.Name, selectedRow).Value = _SubTestCodeValue
                                Me.dgvLabTestsEXT.Item(Me.colSubTestCode.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next
                End If

            ElseIf e.ColumnIndex.Equals(Me.dgvLabTestsEXT.Columns(Me.colSubTestName.Name).Index) Then

                If Me.dgvLabTestsEXT.Rows.Count > 1 Then
                    selectedRow = Me.dgvLabTestsEXT.CurrentCell.RowIndex
                    selectedItem = StringMayBeEnteredIn(Me.dgvLabTestsEXT.Rows(selectedRow).Cells, Me.colSubTestName)
                    For rowNo As Integer = 0 To Me.dgvLabTestsEXT.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            enteredItem = StringMayBeEnteredIn(Me.dgvLabTestsEXT.Rows(rowNo).Cells, Me.colSubTestName)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                MessageBox.Show("Sub Test Name (" + enteredItem + ") already entered!", AppData.AppTitle)
                                Me.dgvLabTestsEXT.Item(Me.colSubTestName.Name, selectedRow).Value = _SubTestNameValue
                                Me.dgvLabTestsEXT.Item(Me.colSubTestName.Name, selectedRow).Selected = True
                                Return
                            End If
                        End If
                    Next
                End If
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvLabTestsEXT_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLabTestsEXT.UserDeletingRow

        Dim recordDeleted As String

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oLabTestsEXT As New SyncSoft.SQLDb.LabTestsEXT()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvLabTestsEXT.Item(Me.colSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim testCode As String = StringEnteredIn(Me.cboTestCode, "Test Code!")
            Dim subTestCode As String = CStr(Me.dgvLabTestsEXT.Item(Me.colSubTestCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim deleteMSG As String = "You do not have permission to delete this record!"
            If Me.fbnDelete.Enabled = False Then
                MessageBox.Show(deleteMSG, AppData.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                e.Cancel = True
                Return
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oLabTestsEXT
                .TestCode = testCode
                .SubTestCode = subTestCode
                recordDeleted = .Delete()
            End With

            MessageBox.Show(recordDeleted, AppData.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadLabTestsEXT(ByVal testCode As String)

        Dim oLabTestsEXT As New SyncSoft.SQLDb.LabTestsEXT()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.dgvLabTestsEXT.Rows.Clear()

            ' Load items not yet paid for

            Dim labTestsEXT As DataTable = oLabTestsEXT.GetLabTestsEXT(testCode).Tables("LabTestsEXT")

            If labTestsEXT Is Nothing OrElse labTestsEXT.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To labTestsEXT.Rows.Count - 1

                Dim row As DataRow = labTestsEXT.Rows(pos)

                With Me.dgvLabTestsEXT
                    ' Ensure that you add a new row first
                    .Rows.Add()

                    .Item(Me.colSubTestCode.Name, pos).Value = StringEnteredIn(row, "SubTestCode")
                    .Item(Me.colSubTestName.Name, pos).Value = StringEnteredIn(row, "SubTestName")
                    .Item(Me.colNormalRange.Name, pos).Value = StringMayBeEnteredIn(row, "NormalRange")
                    .Item(Me.colUnitMeasureID.Name, pos).Value = StringEnteredIn(row, "UnitMeasureID")
                    .Item(Me.colResultDataTypeID.Name, pos).Value = StringEnteredIn(row, "ResultDataTypeID")
                    .Item(Me.colHidden.Name, pos).Value = BooleanEnteredIn(row, "Hidden")
                    .Item(Me.colSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAttachedTestConsumableItems(ByVal testCode As String)
        Dim oConsumableItem As New SyncSoft.SQLDb.PossibleAttachedItems
        Try
            Me.dgvConsumables.Rows.Clear()
            Dim testPossibleCosumables As DataTable = oConsumableItem.GetPossibleAttachedconsumables(testCode).Tables("PossibleAttachedItems")
            If testPossibleCosumables Is Nothing OrElse testPossibleCosumables.Rows.Count < 1 Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvConsumables, testPossibleCosumables)

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Me.dgvConsumables.Item(Me.ColConsumableItemsSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub


    Private Sub dgvConsumables_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvConsumables.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oLabtests As New SyncSoft.SQLDb.PossibleAttachedItems
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvConsumables.Item(Me.ColConsumableItemsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim itemCode As String = SubstringLeft(RevertText(StringMayBeEnteredIn(cboTestCode)))
            Dim consumable As String = CStr(Me.dgvConsumables.Item(Me.colConsumableName.Name, toDeleteRowNo).Value)
            Dim consumableNo As String = SubstringRight(consumable)
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
            With oLabtests
                .AttachedItemCode = itemCode
                .ItemCode = consumableNo
                .ItemCategoryID = oItemCategoryID.Consumable
            End With

            DisplayMessage(oLabtests.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

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
        Me.btnSearch.Visible = True
        Me.cboTestCode.MaxLength = 124
        Me.LoadLabTests(True)
        Me.chkHidden.Enabled = True
        Me.colHidden.Visible = True

        ResetControlsIn(Me.tpgGeneral)
        ResetControlsIn(Me.tpgBillCustomFee)
        ResetControlsIn(Me.tpgInsuranceCustomFee)
        ResetControlsIn(Me.tpgLabPossibleResults)
        ResetControlsIn(Me.tpgLabTestsEXT)
        ResetControlsIn(Me.pnlResultDataTypeID)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.btnSearch.Visible = False

        Me.cboTestCode.MaxLength = 20
        Me.LoadLabTests(False)

        Me.chkHidden.Enabled = False
        Me.colHidden.Visible = False

        ResetControlsIn(Me.tpgGeneral)
        ResetControlsIn(Me.tpgBillCustomFee)
        ResetControlsIn(Me.tpgInsuranceCustomFee)
        ResetControlsIn(Me.tpgLabPossibleResults)
        ResetControlsIn(Me.tpgLabTestsEXT)
        Me.SetNextTestID()
        Me.cboTestCode.Enabled = Not InitOptions.TestCodeLocked

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            Security.Apply(Me.stbTestName, AccessRights.Update)
            Security.Apply(Me.nbxTestFee, AccessRights.Update)
            Security.Apply(Me.nbxUnitCost, AccessRights.Update)
            Security.Apply(Me.nbxVATPercentage, AccessRights.Update)

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



#End Region

#Region " SET AUTONUMBERS"

    Private Sub SetNextTestID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oLabTests As New SyncSoft.SQLDb.LabTests()
            Dim oVariousOption As New VariousOptions()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("LabTests", "TestCode").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim TestCodePrefix As String = oVariousOption.TestCodePrefix
            Dim nextTestCode As String = CStr(oLabTests.GetNextTestID).PadLeft(paddingLEN, paddingCHAR)
            Me.cboTestCode.Text = FormatText((TestCodePrefix + nextTestCode).Trim(), "LabTests", "TestCode")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region


End Class