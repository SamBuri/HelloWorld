
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb.Lookup
Imports SyncSoft.SQLDb
Imports System.Collections.Generic
Imports SyncSoft.Common.SQL.Classes

Public Class frmMappedCodesFinance

#Region " Fields "
    Private _ItemCode As String
#End Region

    Private Sub frmMappedCodesFinance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboItemCategoryEXT, LookupObjects.ItemCategoryEXT, False)
            LoadLookupDataCombo(Me.cboAccountTypeID, LookupObjects.AccountType, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmMappedCodesFinance_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click


        Try
            Me.Cursor = Cursors.WaitCursor()



            Dim lMappedCodesFinance As New List(Of DBConnect)
            Dim transactions As New List(Of TransactionList(Of DBConnect))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False
            For Each row As DataGridViewRow In Me.dgvMappedCodes.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvMappedCodes.Item(Me.colInclude.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If Me.dgvMappedCodes.RowCount < 1 OrElse nonSelected Then Throw New ArgumentException("Must include at least one item to map!")

           
            Dim itemCategoryID As String = StringValueEnteredIn(Me.cboItemCategoryEXT, "Item Category!")
            Dim accountTypeID As String = StringValueEnteredIn(Me.cboAccountTypeID, "Account Type!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvMappedCodes.Rows.Count - 2

                Using oMappedCodesFinance As New SyncSoft.SQLDb.MappedCodesFinance()

                    Dim cells As DataGridViewCellCollection = Me.dgvMappedCodes.Rows(rowNo).Cells

                    Dim include As Boolean = CBool(BooleanMayBeEnteredIn(cells, colInclude))


                    If include Then

                        Dim itemCode As String = StringEnteredIn(cells, Me.colItemCode, "Item Code!")
                        Dim accountNo As String = StringEnteredIn(cells, Me.colAccountNo, "Account No!")
                        Dim itemName As String = StringEnteredIn(cells, Me.colItemName, "Item Name!")

                        With oMappedCodesFinance

                            .ItemCode = itemCode
                            .ItemCategoryID = itemCategoryID
                            .AccountTypeID = accountTypeID
                            .AccountNo = accountNo
                            .ItemName = itemName
                            .LoginID = CurrentUser.LoginID
                            .UserName = CurrentUser.FullName


                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            ValidateEntriesIn(Me)
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End With


                        lMappedCodesFinance.Add(oMappedCodesFinance)
                    End If
                End Using

            Next



            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    transactions.Add(New TransactionList(Of DBConnect)(lMappedCodesFinance, Action.Save))
                    Dim records As Integer = DoTransactions(transactions)
                    CheckSaved()
                    DisplayMessage(records.ToString + " record(s) edited successfull")
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update
                    transactions.Add(New TransactionList(Of DBConnect)(lMappedCodesFinance, Action.Update))
                    Dim records As Integer = DoTransactions(transactions)
                    DisplayMessage(records.ToString + " record(s) updated successfull")


            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = False
        Me.colSelect.Visible = True
        Me.colInclude.Visible = False
        Me.chkLoadAll.Visible = True
        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False
        Me.colSelect.Visible = False
        Me.colInclude.Visible = True
        Me.chkLoadAll.Visible = False
        ResetControlsIn(Me)

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

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

    Private Sub LoadItems()
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim accountCategoryID As String = StringValueMayBeEnteredIn(cboItemCategoryEXT)
            Dim oItemCategoryEXTID As New LookupDataID.ItemCategoryEXTID()

            Me.dgvMappedCodes.Rows.Clear()

            If String.IsNullOrEmpty(accountCategoryID) Then Return

            Dim dataSource As New DataTable
            Dim itemCode As String = String.Empty
            Dim itemName As String = String.Empty

            Dim itemCodeColumn As String = String.Empty
            Dim itemNameColumn As String = String.Empty

            Select Case accountCategoryID

                Case oItemCategoryEXTID.Service
                    Dim oServices As New SyncSoft.SQLDb.Services()
                    dataSource = oServices.GetServices().Tables("Services")

                    itemCodeColumn = "ServiceCode"
                    itemNameColumn = "ServiceName"
                    

                Case oItemCategoryEXTID.Test
                    Dim oLabTests As New SyncSoft.SQLDb.LabTests()
                    dataSource = oLabTests.GetLabTests().Tables("LabTests")
                    itemCodeColumn = "TestCode"
                    itemNameColumn = "TestName"

                    

                Case oItemCategoryEXTID.Drug
                    Dim oDrugs As New SyncSoft.SQLDb.Drugs()
                    dataSource = oDrugs.GetDrugs().Tables("Drugs")

                    itemCodeColumn = "DrugNo"
                    itemNameColumn = "DrugName"


                Case oItemCategoryEXTID.Consumable
                    Dim oConsumableItem As New SyncSoft.SQLDb.ConsumableItems()
                    dataSource = oConsumableItem.GetConsumableItems().Tables("ConsumableItems")

                    itemCodeColumn = "ConsumableNo"
                    itemNameColumn = "ConsumableName"
                   

                Case oItemCategoryEXTID.Admission
                    Dim oBed As New SyncSoft.SQLDb.Beds()
                    itemCodeColumn = "BedNo"
                    itemNameColumn = "BedName"

                Case oItemCategoryEXTID.Cardiology
                    Dim oCardiologyExamination As New SyncSoft.SQLDb.CardiologyExaminations()
                    dataSource = oCardiologyExamination.GetCardiologyExaminations().Tables("CardiologyExaminations")
                    itemCodeColumn = "ExamCode"
                    itemNameColumn = "ExamName"
                    

                Case oItemCategoryEXTID.Dental
                    Dim oDentalService As New SyncSoft.SQLDb.DentalServices()
                    dataSource = oDentalService.GetDentalServices.Tables("DentalServices")
                    itemCodeColumn = "DentalCode"
                    itemNameColumn = "DentalName"

                   

                Case oItemCategoryEXTID.Optical
                    Dim oOpticalService As New SyncSoft.SQLDb.OpticalServices()
                    dataSource = oOpticalService.GetOpticalServices.Tables("OpticalServices")

                    itemCodeColumn = "OpticalCode"
                    itemNameColumn = "OpticalName"
                    

                Case oItemCategoryEXTID.Maternity
                    Dim oMaternityService As New SyncSoft.SQLDb.MaternityServices()
                    dataSource = oMaternityService.GetMaternityServices.Tables("MaternityServices")

                    itemCodeColumn = "MaternityCode"
                    itemNameColumn = "MaternityName"
                   

                Case oItemCategoryEXTID.Radiology
                    Dim oRadiologyExamination As New SyncSoft.SQLDb.RadiologyExaminations()
                    dataSource = oRadiologyExamination.GetRadiologyExaminations().Tables("RadiologyExaminations")
                   
                    itemCodeColumn = "ExamCode"
                    itemNameColumn = "ExamName"

                Case oItemCategoryEXTID.Pathology
                    Dim oPathologyExamination As New SyncSoft.SQLDb.PathologyExaminations()
                    dataSource = oPathologyExamination.GetPathologyExaminations().Tables("PathologyExaminations")
                    itemCodeColumn = "ExamCode"
                    itemNameColumn = "ExamName"

                Case oItemCategoryEXTID.Theatre
                    Dim oTheatreService As New SyncSoft.SQLDb.TheatreServices()
                    dataSource = oTheatreService.GetTheatreServices().Tables("TheatreServices")

                    itemCodeColumn = "TheatreCode"
                    itemNameColumn = "TheatreName"

                Case oItemCategoryEXTID.ICU
                    Dim oICUServices As New SyncSoft.SQLDb.ICUServices()
                    dataSource = oICUServices.GetICUServices().Tables("ICUServices")

                    itemCodeColumn = "ICUCode"
                    itemNameColumn = "ICUName"

                Case oItemCategoryEXTID.Extras
                    Dim oExtraChargeItems As New SyncSoft.SQLDb.ExtraChargeItems()
                    dataSource = oExtraChargeItems.GetExtraChargeItems().Tables("ExtraChargeItems")

                    itemCodeColumn = "ExtraItemCode"
                    itemNameColumn = "ExtraItemName"

                Case oItemCategoryEXTID.Eye
                    Dim oEyeServices As New SyncSoft.SQLDb.EyeServices()
                    dataSource = oEyeServices.GetEyeServices().Tables("EyeServices")

                    itemCodeColumn = "EyeCode"
                    itemNameColumn = "EyeName"

                Case oItemCategoryEXTID.Procedure
                    Dim oProcedure As New SyncSoft.SQLDb.Procedures()
                    dataSource = oProcedure.GetProcedures().Tables("Procedures")

                    itemCodeColumn = "ProcedureCode"
                    itemNameColumn = "ProcedureName"

                Case oItemCategoryEXTID.Packages
                    Dim oPackage As New SyncSoft.SQLDb.Packages()
                    dataSource = oPackage.GetPackages().Tables("Packages")

                    itemCodeColumn = "PackageCode"
                    itemNameColumn = "PackageName"

                Case oItemCategoryEXTID.NonMedical
                    Dim oOtherItem As New SyncSoft.SQLDb.OtherItems()
                    dataSource = oOtherItem.GetOtherItems().Tables("OtherItems")

                    itemCodeColumn = "ItemCode"
                    itemNameColumn = "ItemName"

                Case oItemCategoryEXTID.Bank
                    Dim oBankAccount As New SyncSoft.SQLDb.BankAccounts()
                    dataSource = oBankAccount.GetBankAccounts().Tables("BankAccounts")

                    itemCodeColumn = "AccountNo"
                    itemNameColumn = "AccountName"

                Case oItemCategoryEXTID.BillCustomer
                    Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
                    dataSource = oBillCustomers.GetBillCustomers().Tables("BillCustomers")

                    itemCodeColumn = "AccountNo"
                    itemNameColumn = "BillCustomerName"

                Case oItemCategoryEXTID.Supplier
                    Dim oSupplier As New SyncSoft.SQLDb.Suppliers()
                    dataSource = oSupplier.GetSuppliers().Tables("Suppliers")

                    itemCodeColumn = "SUpplierNo"
                    itemNameColumn = "SupplierName"



            End Select
            Dim rowCount As Integer = dataSource.Rows.Count()
            lblRecordsNo.Text = rowCount.ToString() + " row(s) returned"
            For row As Integer = 0 To rowCount - 2
                Me.dgvMappedCodes.Rows.Add()
                Dim rowIndex As DataRow = dataSource.Rows(row)
                itemCode = StringEnteredIn(rowIndex, itemCodeColumn)
                itemName = StringEnteredIn(rowIndex, itemNameColumn)
                Me.dgvMappedCodes.Item(Me.colItemCode.Name, row).Value = itemCode
                Me.dgvMappedCodes.Item(Me.colItemName.Name, row).Value = itemName
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboItemCategoryEXT_Leave(sender As Object, e As System.EventArgs) Handles cboItemCategoryEXT.Leave
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then LoadItems()
    End Sub


    Private Sub chkApplyAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkApplyAll.CheckedChanged

        Me.cboAccountNo.SelectedIndex = -1

        If Me.chkApplyAll.Checked Then
            Me.cboAccountNo.Enabled = True
        Else
            Me.cboAccountNo.Text = String.Empty
            Me.cboAccountNo.Enabled = False
            LoadItems()
        End If


    End Sub

   

    Private Sub cboAccountTypeID_Leave(sender As Object, e As System.EventArgs) Handles cboAccountTypeID.Leave
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim accountTypeID As String = StringValueMayBeEnteredIn(cboAccountTypeID)
            If String.IsNullOrEmpty(accountTypeID) Then Return
            LoadchartOfAccountsType(cboAccountNo, accountTypeID)

            If chkLoadAll.Checked Then
                If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Me.LoadAllMappedCode()
            End If

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub SetAccountName(accountNo As String, accountName As String)
        Try
            Me.Cursor = Cursors.WaitCursor
            
            For row As Integer = 0 To dgvMappedCodes.Rows.Count() - 2
                Me.dgvMappedCodes.Item(Me.colInclude.Name, row).Value = True
                Me.dgvMappedCodes.Item(Me.colAccountNo.Name, row).Value = accountNo
                Me.dgvMappedCodes.Item(Me.colAccountName.Name, row).Value = accountName
            Next


        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboAccountNo_Leave(sender As Object, e As System.EventArgs) Handles cboAccountNo.Leave
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim oChartAccount As New ChartAccounts()
            Dim accountNo As String = StringValueMayBeEnteredIn(cboAccountNo)

            If String.IsNullOrEmpty(accountNo) Then Return

            Dim chartAccounts As DataTable = oChartAccount.GetChartAccounts(accountNo).Tables("ChartAccounts")
            Dim row As DataRow = chartAccounts.Rows(0)
            Dim accountName As String = StringEnteredIn(row, "AccountName")

            Me.SetAccountName(accountNo, accountName)

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub dgvMappedCodes_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMappedCodes.CellClick
        Me.Cursor = Cursors.WaitCursor

        If e.RowIndex < 0 Then Return

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Mapped Items", "Item Code", "Item Name", Me.GetMappedCode(),
                                                                     "ItemFullName", "ItemCode", "ItemName", Me.dgvMappedCodes, Me.colItemCode, e.RowIndex)

        _ItemCode = StringMayBeEnteredIn(Me.dgvMappedCodes.Rows(e.RowIndex).Cells, Me.colItemCode)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Me.colSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvMappedCodes.Rows(e.RowIndex).IsNewRow Then

            Me.dgvMappedCodes.Rows.Add()

            fSelectItem.ShowDialog(Me)
            Me.SetMappedEntries(e.RowIndex)

        ElseIf Me.colSelect.Index.Equals(e.ColumnIndex) Then

            fSelectItem.ShowDialog(Me)
            Me.SetMappedEntries(e.RowIndex)

        End If
        Me.Cursor = Cursors.Default

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 

    End Sub



    Private Sub dgvMappedCodes_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMappedCodes.CellEndEdit

        Dim selectedRow As Integer = Me.dgvMappedCodes.CurrentCell.RowIndex
        Try
            Me.Cursor = Cursors.WaitCursor

            If e.ColumnIndex.Equals(Me.colAccountNo.Index) Then

                Dim oChartAccount As New ChartAccounts()

                Dim accountNo As String = StringMayBeEnteredIn(Me.dgvMappedCodes.Rows(selectedRow).Cells, Me.colAccountNo)
                Dim accountTypeID As String = StringValueMayBeEnteredIn(Me.cboAccountTypeID, "Account Type ID")

                Dim chartAccounts As DataTable = oChartAccount.GetChartAccountsByType(accountTypeID, accountNo).Tables("ChartAccounts")

                If chartAccounts.Rows.Count < 1 Then
                    DisplayMessage("No record found for object Name " + cboItemCategoryEXT.Text + " and Account No " + accountNo)
                    Me.dgvMappedCodes.Item(Me.colAccountNo.Name, selectedRow).Value = String.Empty
                    Me.dgvMappedCodes.Item(Me.colAccountName.Name, selectedRow).Value = String.Empty
                Else
                    Dim row As DataRow = chartAccounts.Rows(0)
                    Dim accountName As String = StringEnteredIn(row, "AccountName")

                    Me.dgvMappedCodes.Item(Me.colInclude.Name, selectedRow).Value = True
                    Me.dgvMappedCodes.Item(Me.colAccountNo.Name, selectedRow).Value = accountNo
                    Me.dgvMappedCodes.Item(Me.colAccountName.Name, selectedRow).Value = accountName

                End If

            End If



        Catch ex As Exception
            ErrorMessage(ex)
            Me.dgvMappedCodes.Item(Me.colAccountNo.Name, selectedRow).Value = String.Empty
            Me.dgvMappedCodes.Item(Me.colAccountName.Name, selectedRow).Value = String.Empty
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CheckSaved()
        Try
            Me.Cursor = Cursors.WaitCursor

            For row As Integer = 0 To dgvMappedCodes.Rows.Count() - 2
                Me.dgvMappedCodes.Item(Me.colSaved.Name, row).Value = True
            Next


        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function GetMappedAccountNo(itemCode As String, itemCategoryID As String, accountTypeID As String) As String
        Try

            Dim oMappedCodesFinance As New SyncSoft.SQLDb.MappedCodesFinance()
            Dim dataSource As DataTable = oMappedCodesFinance.GetMappedCodesFinance(itemCode, itemCategoryID, accountTypeID).Tables("MappedCodesFinance")
            Dim row As DataRow = dataSource.Rows(0)
            Return StringEnteredIn(row, "AccountNo")
        Catch ex As Exception

            Return String.empty
        Finally

        End Try

    End Function

    Private Function GetAccountName(accountNo As String) As String
        Try
            Dim oChartAccount As New ChartAccounts()
            Dim chartAccounts As DataTable = oChartAccount.GetChartAccounts(accountNo).Tables("ChartAccounts")
            Dim row As DataRow = chartAccounts.Rows(0)
            Return StringEnteredIn(row, "AccountName")
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function



    Private Function GetMappedCode() As DataTable
        Dim dataSource As New DataTable
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim oMappedCodesFinance As New SyncSoft.SQLDb.MappedCodesFinance()
            Dim itemCategoryID As String = StringValueEnteredIn(cboItemCategoryEXT, "Item Category EXT")
            Dim accountTypeID As String = StringValueEnteredIn(cboAccountTypeID, "Account Type")
            dataSource = oMappedCodesFinance.GetMappedCodesFinance(itemCategoryID, accountTypeID).Tables("MappedCodesFinance")

        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
        Return dataSource
    End Function

    Private Sub SetMappedEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvMappedCodes.Rows(selectedRow).Cells, Me.colItemCode))
            Me.SetMappedEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Sub SetMappedEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try

            For rowNo As Integer = 0 To Me.dgvMappedCodes.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvMappedCodes.Rows(rowNo).Cells, Me.colItemCode)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Item Code (" + enteredItem + ") already selected!")
                        Me.dgvMappedCodes.Rows.RemoveAt(selectedRow)
                        Me.dgvMappedCodes.Item(Me.colItemCode.Name, selectedRow).Value = _ItemCode
                        Me.dgvMappedCodes.Item(Me.colItemCode.Name, selectedRow).Selected = True
                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailMappedCode(selectedRow)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub DetailMappedCode(ByVal selectedRow As Integer)

        Try

            Dim oMappedCodesFinance As New SyncSoft.SQLDb.MappedCodesFinance()
            Dim itemCode As String = String.Empty
            Dim itemCategoryEXTID As String = StringValueEnteredIn(cboItemCategoryEXT, "Item Category EXT!")
            Dim accountTypeID As String = StringValueEnteredIn(cboAccountTypeID, "Account Type!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvMappedCodes.Rows.Count > 1 Then
                itemCode = SubstringRight(StringMayBeEnteredIn(Me.dgvMappedCodes.Rows(selectedRow).Cells, Me.colItemCode))
            End If

            If String.IsNullOrEmpty(itemCode) Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim returnedItems As DataTable = oMappedCodesFinance.GetMappedCodesFinance(itemCode, itemCategoryEXTID, accountTypeID).Tables("MappedCodesFinance")


            Dim row As DataRow = returnedItems.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim itemName As String = StringEnteredIn(row, "ItemName", "Item Name!")
            Dim ItemCategoryID As String = StringMayBeEnteredIn(row, "ItemCategoryID")
            Dim accountNo As String = StringMayBeEnteredIn(row, "AccountNo")
            Dim AccountName As String = StringMayBeEnteredIn(row, "AccountName")


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.dgvMappedCodes

                .Item(Me.colItemCode.Name, selectedRow).Value = itemCode
                .Item(Me.colItemName.Name, selectedRow).Value = itemName
                .Item(Me.colAccountNo.Name, selectedRow).Value = accountNo
                .Item(Me.colAccountName.Name, selectedRow).Value = AccountName
                .Item(Me.colInclude.Name, selectedRow).Value = True
            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvMappedCodes.Item(Me.colItemCode.Name, selectedRow).Value = Me._ItemCode.ToUpper()
            Throw ex

        End Try

    End Sub

    Private Function GetChartAccountByType(accountTypeID As String) As DataTable
        Dim oChartAccounts As New ChartAccounts
        Dim chartAccounts As New DataTable()
        Try
            Me.Cursor = Cursors.WaitCursor
            chartAccounts = oChartAccounts.GetChartAccountsByType(accountTypeID).Tables("ChartAccounts")
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
        Return chartAccounts
    End Function

    Private Sub LoadAllMappedCode()

        Try

            Dim oMappedCodesFinance As New SyncSoft.SQLDb.MappedCodesFinance()

            Dim itemCategoryEXTID As String = StringValueEnteredIn(cboItemCategoryEXT, "Item Category EXT!")
            Dim accountTypeID As String = StringValueEnteredIn(cboAccountTypeID, "Account Type!")
            Me.dgvMappedCodes.Rows.Clear()
           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim mappedCodesFinance As DataTable = oMappedCodesFinance.GetMappedCodesFinance(itemCategoryEXTID, accountTypeID).Tables("MappedCodesFinance")

            For rowNo As Integer = 0 To mappedCodesFinance.Rows.Count() - 1

                Dim row As DataRow = mappedCodesFinance.Rows(rowNo)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim itemCode As String = StringEnteredIn(row, "ItemCode", "Item Code!")
                Dim itemName As String = StringEnteredIn(row, "ItemName", "Item Name!")
                Dim accountNo As String = StringMayBeEnteredIn(row, "AccountNo")
                Dim AccountName As String = StringMayBeEnteredIn(row, "AccountName")


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                With Me.dgvMappedCodes
                    .Rows.Add()
                    .Item(Me.colItemCode.Name, rowNo).Value = itemCode
                    .Item(Me.colItemName.Name, rowNo).Value = itemName
                    .Item(Me.colAccountNo.Name, rowNo).Value = accountNo
                    .Item(Me.colAccountName.Name, rowNo).Value = AccountName
                    .Item(Me.colInclude.Name, rowNo).Value = True
                    .Item(Me.colSaved.Name, rowNo).Value = True

                End With

            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception

            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub chkLoadAll_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkLoadAll.CheckedChanged
        If chkLoadAll.Checked Then
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Me.LoadAllMappedCode()
        Else
            Me.dgvMappedCodes.Rows.Clear()
        End If
    End Sub


    Private Sub cmsCopy_Opening(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles cmsCopy.Opening
        If Me.dgvMappedCodes.ColumnCount < 2 Then
            Me.cmsInvoiceDetailsCopy.Enabled = False
            Me.cmsInvoiceDetailsSelectAll.Enabled = False
        Else
            Me.cmsInvoiceDetailsCopy.Enabled = True
            Me.cmsInvoiceDetailsSelectAll.Enabled = True
        End If
        Me.cmsQuickSearch.Enabled = (Me.dgvMappedCodes.SelectedRows.Count < 2 AndAlso Me.dgvMappedCodes.Rows.Count > 2)
    End Sub

    Private Sub cmsInvoiceDetailsCopy_Click(sender As System.Object, e As System.EventArgs) Handles cmsInvoiceDetailsCopy.Click
        If dgvMappedCodes.SelectedCells.Count < 1 Then Return
        Clipboard.SetText(CopyFromControl(dgvMappedCodes))
    End Sub

    Private Sub cmsInvoiceDetailsSelectAll_Click(sender As System.Object, e As System.EventArgs) Handles cmsInvoiceDetailsSelectAll.Click
        Me.dgvMappedCodes.SelectAll()
    End Sub

    Private Sub cmsQuickSearch_Click(sender As System.Object, e As System.EventArgs) Handles cmsQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.dgvMappedCodes.Rows.Count < 2 Then Return
            Dim rowIndex As Integer = Me.dgvMappedCodes.CurrentCell.RowIndex
            If rowIndex < 0 Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim itemCategoryID As String = StringValueMayBeEnteredIn(Me.cboAccountTypeID)
            If String.IsNullOrEmpty(itemCategoryID) Then Return
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("ChartAccounts", "Account No", "ChartAccounts", Me.GetChartAccountByType(itemCategoryID), "AccountFullName",
                                                                     "AccountNo", "AccountName", Me.dgvMappedCodes, Me.colAccountNo, rowIndex)

            fSelectItem.ShowDialog(Me)

            Dim accountNo As String = StringMayBeEnteredIn(Me.dgvMappedCodes.Rows(rowIndex).Cells, Me.colAccountNo)

            Dim oChartAccount As New ChartAccounts()

             Dim chartAccounts As DataTable = oChartAccount.GetChartAccounts(accountNo).Tables("ChartAccounts")

            If chartAccounts.Rows.Count < 1 Then
                DisplayMessage("No record found for object Name " + cboItemCategoryEXT.Text + " and Account No " + accountNo)
                Me.dgvMappedCodes.Item(Me.colAccountNo.Name, rowIndex).Value = String.Empty
                Me.dgvMappedCodes.Item(Me.colAccountName.Name, rowIndex).Value = String.Empty
            Else
                Dim row As DataRow = chartAccounts.Rows(0)
                Dim accountName As String = StringEnteredIn(row, "AccountName")

                Me.dgvMappedCodes.Item(Me.colInclude.Name, rowIndex).Value = True
                Me.dgvMappedCodes.Item(Me.colAccountNo.Name, rowIndex).Value = accountNo
                Me.dgvMappedCodes.Item(Me.colAccountName.Name, rowIndex).Value = accountName
                
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    
End Class