
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports System.Collections.Generic

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Public Class frmServices

#Region " Fields "

    Private services As DataTable
    Private billCustomers As DataTable
    Private insurances As DataTable

    Private _AccountNoValue As String = String.Empty
    Private _insuranceNoValue As String = String.Empty

    Private _DoctorSpecialtyIDValue As String = String.Empty
    Private _StaffNoValue As String = String.Empty

    Private _DoctorSpecialtyBillIDValue As String = String.Empty
    Private _SpecialtyBillAccountNoValue As String = String.Empty

    Private _DoctorStaffBillIDValue As String = String.Empty
    Private _StaffBillAccountNoValue As String = String.Empty
    Private _DoctorSpecialtyCustomCodeIDValue As String = String.Empty
    Private oVariousOptions As New VariousOptions()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID

#End Region

    Private Sub frmServiceCodes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.fcbServicePointID, LookupObjects.ServicePoint, False)
            LoadLookupDataCombo(Me.fcbServiceBillAtID, LookupObjects.ServiceBillAt, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.LoadServices()
            Me.LoadBillCustomers()
            Me.LoadInsurances()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.colBillCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.colInsuranceCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.colDoctorSpecialtyID, LookupObjects.DoctorSpecialty)
            LoadLookupDataCombo(Me.colDrSpecialtyFeeCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.colStaffFeeCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.colDoctorSpecialtyBillID, LookupObjects.DoctorSpecialty)
            LoadLookupDataCombo(Me.colSpecialtyBillCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.colStaffBillCurrenciesID, LookupObjects.Currencies, False)
            LoadLookupDataCombo(Me.colDoctorSpecialtyCustomCodeID, LookupObjects.DoctorSpecialty)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadStaff()

            'getting Revenue Stream for NAV Integration
            LoadRevenueStreams()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmServices_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub cboServiceCode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboServiceCode.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub cboServiceCode_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboServiceCode.Leave

        Try

            Dim serviceCode As String = SubstringRight(StringMayBeEnteredIn(Me.cboServiceCode)).ToUpper()
            Me.cboServiceCode.Text = serviceCode.ToUpper()

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Return

            For Each row As DataRow In services.Select("ServiceCode = '" + serviceCode + "'")
                Me.stbServiceName.Text = StringMayBeEnteredIn(row, "ServiceName")
            Next

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadServices()

        Dim oServices As New SyncSoft.SQLDb.Services()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Services

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''
            services = oServices.GetServices().Tables("Services")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadServices(ByVal populate As Boolean)

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If populate Then
                LoadComboData(Me.cboServiceCode, services, "ServiceFullName")
            Else : Me.cboServiceCode.Items.Clear()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colBillCustomerName.Sorted = False
            Me.colSpecialtyBillCustomerName.Sorted = False
            LoadComboData(Me.colBillCustomerName, billCustomers, "AccountNo", "BillCustomerName")
            LoadComboData(Me.colSpecialtyBillCustomerName, billCustomers, "AccountNo", "BillCustomerName")
            LoadComboData(Me.colStaffBillCustomerName, billCustomers, "AccountNo", "BillCustomerName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colStaffNo, staff, "StaffFullName")
            LoadComboData(Me.colStaffBillID, staff, "StaffFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oServices As New SyncSoft.SQLDb.Services()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oServices.ServiceCode = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))
            DisplayMessage(oServices.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.tpgBillCustomFee)
            ResetControlsIn(Me.tpgInsuranceCustomFee)
            ResetControlsIn(Me.tpgServicesDrSpecialtyFee)
            ResetControlsIn(Me.tpgServicesStaffFee)
            ResetControlsIn(Me.tpgServicesSpecialtyBillCustomFee)
            ResetControlsIn(Me.tpgServicesStaffBillCustomFee)
            ResetControlsIn(Me.tpgServicesSpecialtyCustomCode)

            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim oServices As New SyncSoft.SQLDb.Services()

        Try

            Dim serviceCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code"))

            Me.Cursor = Cursors.WaitCursor

            Dim dataSource As DataTable = oServices.GetServices(serviceCode).Tables("Services")
            Me.DisplayData(dataSource)

            Me.LoadBillCustomFee(serviceCode)
            Me.LoadInsuranceCustomFee(serviceCode)
            Me.LoadServicesDrSpecialtyFee(serviceCode)
            Me.LoadServicesStaffFee(serviceCode)
            Me.LoadServicesSpecialtyBillCustomFee(serviceCode)
            Me.LoadServicesStaffBillCustomFee(serviceCode)
            Me.LoadServicesSpecialtyCustomCode(serviceCode)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim serviceCode As String = SubstringRight(RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))).ToUpper()
        Dim itemCategoryID As String = oItemCategoryID.Service
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim message As String
            Dim oServices As New SyncSoft.SQLDb.Services()
            Dim lServices As New List(Of DBConnect)

            With oServices

                .ServiceCode = serviceCode
                .ServiceName = StringEnteredIn(Me.stbServiceName, "Service Name!")
                .ServicePointID = StringValueEnteredIn(Me.fcbServicePointID, "Service Point!")
                .ServiceBillAtID = StringValueEnteredIn(Me.fcbServiceBillAtID, "Service Bill At!")
                .UnitCost = Me.nbxUnitCost.GetDecimal(False)
                .VATPercentage = DecimalMayBeEnteredIn(Me.nbxVATPercentage)
                .StandardFee = Me.nbxStandardFee.GetDecimal(False)
                .RevenueStream = StringValueMayBeEnteredIn(Me.cboRevenueStream, "Revenue Stream!")
                .Hidden = Me.chkHidden.Checked

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lServices.Add(oServices)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oServices.UnitCost >= oServices.StandardFee Then

                If oServices.UnitCost = oServices.StandardFee Then
                    message = "Unit Cost equals Standard Fee. "
                Else : message = "Unit Cost is more than Standard Fee. "
                End If
                message += ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.nbxUnitCost.Focus() : Return

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oServices.Hidden.Equals(True) Then
                message = "You have chosen to hide this service and won’t be presented for selection. " +
                                        ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.chkHidden.Focus() : Return
            End If
            OpenBillableMappings(ebnSaveUpdate.ButtonText, oItemCategoryID.Service, serviceCode)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                
                    transactions.Add(New TransactionList(Of DBConnect)(lServices, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ServicesDrSpecialtyFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ServicesStaffFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ServicesSpecialtyBillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ServicesStaffBillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ServicesSpecialtyCustomCodeList, Action.Save))

                    records = DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgBillCustomFee)
                    ResetControlsIn(Me.tpgInsuranceCustomFee)
                    ResetControlsIn(Me.tpgServicesDrSpecialtyFee)
                    ResetControlsIn(Me.tpgServicesStaffFee)
                    ResetControlsIn(Me.tpgServicesSpecialtyBillCustomFee)
                    ResetControlsIn(Me.tpgServicesStaffBillCustomFee)
                    ResetControlsIn(Me.tpgServicesSpecialtyCustomCode)
                    SetNextServiceCode()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lServices, Action.Update, "Services"))
                    transactions.Add(New TransactionList(Of DBConnect)(BillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ServicesDrSpecialtyFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ServicesStaffFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ServicesSpecialtyBillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ServicesStaffBillCustomFeeList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ServicesSpecialtyCustomCodeList, Action.Save))

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

            For rowNo As Integer = 0 To Me.dgvServicesDrSpecialtyFee.RowCount - 2
                Me.dgvServicesDrSpecialtyFee.Item(Me.colServicesDrSpecialtyFeeSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvServicesStaffFee.RowCount - 2
                Me.dgvServicesStaffFee.Item(Me.colServicesStaffFeeSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvServicesSpecialtyBillCustomFee.RowCount - 2
                Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillCustomFeeSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvServicesStaffBillCustomFee.RowCount - 2
                Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillCustomFeeSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvServicesSpecialtyCustomCode.RowCount - 2
                Me.dgvServicesSpecialtyCustomCode.Item(Me.colServicesSpecialtyCustomCodeSaved.Name, rowNo).Value = True
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

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))

            For rowNo As Integer = 0 To Me.dgvBillCustomFee.RowCount - 2

                Using oBillCustomFee As New SyncSoft.SQLDb.BillCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillCustomFee.Rows(rowNo).Cells

                    With oBillCustomFee

                        .AccountNo = StringEnteredIn(cells, Me.colBillCustomerName, "To-Bill Account Name!")
                        .ItemCode = itemCode
                        .ItemCategoryID = oItemCategoryID.Service
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

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceCustomFee.RowCount - 2

                Using oInsuranceCustomFee As New SyncSoft.SQLDb.InsuranceCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceCustomFee.Rows(rowNo).Cells

                    With oInsuranceCustomFee

                        .InsuranceNo = StringEnteredIn(cells, Me.colInsuranceName, "Insurance Name!")
                        .ItemCode = itemCode
                        .ItemCategoryID = oItemCategoryID.Service
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

    Private Function ServicesDrSpecialtyFeeList() As List(Of DBConnect)

        Dim lServicesDrSpecialtyFee As New List(Of DBConnect)

        Try

            Dim serviceCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))

            For rowNo As Integer = 0 To Me.dgvServicesDrSpecialtyFee.RowCount - 2

                Using oServicesDrSpecialtyFee As New SyncSoft.SQLDb.ServicesDrSpecialtyFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvServicesDrSpecialtyFee.Rows(rowNo).Cells

                    With oServicesDrSpecialtyFee

                        .ServiceCode = serviceCode
                        .DoctorSpecialtyID = StringEnteredIn(cells, Me.colDoctorSpecialtyID, "Doctor Specialty!")
                        .SpecialtyFee = DecimalEnteredIn(cells, Me.colSpecialtyFee, False, "Specialty Fee!")
                        .CurrenciesID = StringEnteredIn(cells, Me.colDrSpecialtyFeeCurrenciesID, "Currency!")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lServicesDrSpecialtyFee.Add(oServicesDrSpecialtyFee)

                End Using

            Next

            Return lServicesDrSpecialtyFee

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function ServicesStaffFeeList() As List(Of DBConnect)

        Dim lServicesStaffFee As New List(Of DBConnect)

        Try

            Dim serviceCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))

            For rowNo As Integer = 0 To Me.dgvServicesStaffFee.RowCount - 2

                Using oServicesStaffFee As New SyncSoft.SQLDb.ServicesStaffFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvServicesStaffFee.Rows(rowNo).Cells

                    With oServicesStaffFee

                        .ServiceCode = serviceCode
                        .StaffNo = SubstringRight(StringEnteredIn(cells, Me.colStaffNo, "Staff No!"))
                        .StaffFee = DecimalEnteredIn(cells, Me.colStaffFee, False, "Staff Fee!")
                        .CurrenciesID = StringEnteredIn(cells, Me.colStaffFeeCurrenciesID, "Currency!")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lServicesStaffFee.Add(oServicesStaffFee)

                End Using

            Next

            Return lServicesStaffFee

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function ServicesSpecialtyBillCustomFeeList() As List(Of DBConnect)

        Dim lServicesSpecialtyBillCustomFee As New List(Of DBConnect)

        Try

            Dim serviceCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))

            For rowNo As Integer = 0 To Me.dgvServicesSpecialtyBillCustomFee.RowCount - 2

                Using oServicesSpecialtyBillCustomFee As New SyncSoft.SQLDb.ServicesSpecialtyBillCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvServicesSpecialtyBillCustomFee.Rows(rowNo).Cells

                    With oServicesSpecialtyBillCustomFee

                        .ServiceCode = serviceCode
                        .DoctorSpecialtyID = StringEnteredIn(cells, Me.colDoctorSpecialtyBillID, "Doctor Specialty!")
                        .AccountNo = StringEnteredIn(cells, Me.colSpecialtyBillCustomerName, "To-Bill Account Name!")
                        .CustomFee = DecimalEnteredIn(cells, Me.colSpecialtyBillCustomFee, False, "Custom Fee!")
                        .CurrenciesID = StringEnteredIn(cells, Me.colSpecialtyBillCurrenciesID, "Currency!")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lServicesSpecialtyBillCustomFee.Add(oServicesSpecialtyBillCustomFee)

                End Using

            Next

            Return lServicesSpecialtyBillCustomFee

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function ServicesStaffBillCustomFeeList() As List(Of DBConnect)

        Dim lServicesStaffBillCustomFee As New List(Of DBConnect)

        Try

            Dim serviceCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))

            For rowNo As Integer = 0 To Me.dgvServicesStaffBillCustomFee.RowCount - 2

                Using oServicesStaffBillCustomFee As New SyncSoft.SQLDb.ServicesStaffBillCustomFee()

                    Dim cells As DataGridViewCellCollection = Me.dgvServicesStaffBillCustomFee.Rows(rowNo).Cells

                    With oServicesStaffBillCustomFee

                        .ServiceCode = serviceCode
                        .StaffNo = SubstringRight(StringEnteredIn(cells, Me.colStaffBillID, "Staff No!"))
                        .AccountNo = StringEnteredIn(cells, Me.colStaffBillCustomerName, "To-Bill Account Name!")
                        .CustomFee = DecimalEnteredIn(cells, Me.colStaffBillCustomFee, False, "Custom Fee!")
                        .CurrenciesID = StringEnteredIn(cells, Me.colStaffBillCurrenciesID, "Currency!")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lServicesStaffBillCustomFee.Add(oServicesStaffBillCustomFee)

                End Using

            Next

            Return lServicesStaffBillCustomFee

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function ServicesSpecialtyCustomCodeList() As List(Of DBConnect)

        Dim lServicesSpecialtyCustomCode As New List(Of DBConnect)

        Try

            Dim serviceCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))

            For rowNo As Integer = 0 To Me.dgvServicesSpecialtyCustomCode.RowCount - 2

                Using oServicesSpecialtyCustomCode As New SyncSoft.SQLDb.ServicesSpecialtyCustomCode()

                    Dim cells As DataGridViewCellCollection = Me.dgvServicesSpecialtyCustomCode.Rows(rowNo).Cells

                    With oServicesSpecialtyCustomCode

                        .ServiceCode = serviceCode
                        .DoctorSpecialtyID = StringEnteredIn(cells, Me.colDoctorSpecialtyCustomCodeID, "Doctor Specialty!")
                        .CustomCode = StringEnteredIn(cells, Me.colSpecialtyCustomCode, "Custom Code!")
                        .LoginID = CurrentUser.LoginID

                    End With

                    lServicesSpecialtyCustomCode.Add(oServicesSpecialtyCustomCode)

                End Using

            Next

            Return lServicesSpecialtyCustomCode

        Catch ex As Exception
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

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))
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
                .ItemCategoryID = oItemCategoryID.Service
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billCustomFee As DataTable = oBillCustomFee.GetBillCustomFee(itemCode, oItemCategoryID.Service).Tables("BillCustomFee")

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

            Dim itemCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))
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
                .ItemCategoryID = oItemCategoryID.Service
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

            Dim insuranceCustomFee As DataTable = oInsuranceCustomFee.GetInsuranceCustomFee(itemCode, oItemCategoryID.Service).Tables("InsuranceCustomFee")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInsuranceCustomFee, insuranceCustomFee)

            For Each row As DataGridViewRow In Me.dgvInsuranceCustomFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvInsuranceCustomFee.Item(Me.colInsuranceCustomFeeSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " ServicesDrSpecialtyFee - Grid "

    Private Sub dgvServicesDrSpecialtyFee_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvServicesDrSpecialtyFee.CellBeginEdit

        If e.ColumnIndex <> Me.colDoctorSpecialtyID.Index OrElse Me.dgvServicesDrSpecialtyFee.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvServicesDrSpecialtyFee.CurrentCell.RowIndex
        _DoctorSpecialtyIDValue = StringMayBeEnteredIn(Me.dgvServicesDrSpecialtyFee.Rows(selectedRow).Cells, Me.colDoctorSpecialtyID)

    End Sub

    Private Sub dgvServicesDrSpecialtyFee_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServicesDrSpecialtyFee.CellEndEdit

        Try

            If Me.colDoctorSpecialtyID.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colDoctorSpecialtyID.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvServicesDrSpecialtyFee.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvServicesDrSpecialtyFee.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvServicesDrSpecialtyFee.Rows(selectedRow).Cells, Me.colDoctorSpecialtyID)

                    If CBool(Me.dgvServicesDrSpecialtyFee.Item(Me.colServicesDrSpecialtyFeeSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Doctor Specialty (" + GetLookupDataDes(_DoctorSpecialtyIDValue) + ") can't be edited!")
                        Me.dgvServicesDrSpecialtyFee.Item(Me.colDoctorSpecialtyID.Name, selectedRow).Value = _DoctorSpecialtyIDValue
                        Me.dgvServicesDrSpecialtyFee.Item(Me.colDoctorSpecialtyID.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvServicesDrSpecialtyFee.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvServicesDrSpecialtyFee.Rows(rowNo).Cells, Me.colDoctorSpecialtyID)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Doctor Specialty (" + GetLookupDataDes(enteredItem) + ") already entered!")
                                Me.dgvServicesDrSpecialtyFee.Item(Me.colDoctorSpecialtyID.Name, selectedRow).Value = _DoctorSpecialtyIDValue
                                Me.dgvServicesDrSpecialtyFee.Item(Me.colDoctorSpecialtyID.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvServicesDrSpecialtyFee_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvServicesDrSpecialtyFee.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oServicesDrSpecialtyFee As New SyncSoft.SQLDb.ServicesDrSpecialtyFee()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvServicesDrSpecialtyFee.Item(Me.colServicesDrSpecialtyFeeSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim serviceCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))
            Dim doctorSpecialtyID As String = CStr(Me.dgvServicesDrSpecialtyFee.Item(Me.colDoctorSpecialtyID.Name, toDeleteRowNo).Value)

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
            With oServicesDrSpecialtyFee
                .ServiceCode = serviceCode
                .DoctorSpecialtyID = doctorSpecialtyID
            End With

            DisplayMessage(oServicesDrSpecialtyFee.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadServicesDrSpecialtyFee(ByVal serviceCode As String)

        Dim oServicesDrSpecialtyFee As New SyncSoft.SQLDb.ServicesDrSpecialtyFee()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim servicesDrSpecialtyFee As DataTable = oServicesDrSpecialtyFee.GetServicesDrSpecialtyFee(serviceCode).Tables("ServicesDrSpecialtyFee")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvServicesDrSpecialtyFee, servicesDrSpecialtyFee)

            For Each row As DataGridViewRow In Me.dgvServicesDrSpecialtyFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvServicesDrSpecialtyFee.Item(Me.colServicesDrSpecialtyFeeSaved.Name, row.Index).Value = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " ServicesStaffFee - Grid "

    Private Sub dgvServicesStaffFee_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvServicesStaffFee.CellBeginEdit

        If e.ColumnIndex <> Me.colStaffNo.Index OrElse Me.dgvServicesStaffFee.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvServicesStaffFee.CurrentCell.RowIndex
        _StaffNoValue = StringMayBeEnteredIn(Me.dgvServicesStaffFee.Rows(selectedRow).Cells, Me.colStaffNo)

    End Sub

    Private Sub dgvServicesStaffFee_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServicesStaffFee.CellEndEdit

        Try

            If Me.colStaffNo.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colStaffNo.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvServicesStaffFee.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvServicesStaffFee.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvServicesStaffFee.Rows(selectedRow).Cells, Me.colStaffNo)

                    If CBool(Me.dgvServicesStaffFee.Item(Me.colServicesStaffFeeSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Staff (" + _StaffNoValue + ") can't be edited!")
                        Me.dgvServicesStaffFee.Item(Me.colStaffNo.Name, selectedRow).Value = _StaffNoValue
                        Me.dgvServicesStaffFee.Item(Me.colStaffNo.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvServicesStaffFee.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvServicesStaffFee.Rows(rowNo).Cells, Me.colStaffNo)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Staff (" + enteredItem + ") already entered!")
                                Me.dgvServicesStaffFee.Item(Me.colStaffNo.Name, selectedRow).Value = _StaffNoValue
                                Me.dgvServicesStaffFee.Item(Me.colStaffNo.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvServicesStaffFee_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvServicesStaffFee.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oServicesStaffFee As New SyncSoft.SQLDb.ServicesStaffFee()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvServicesStaffFee.Item(Me.colServicesStaffFeeSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim serviceCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))
            Dim staffNo As String = SubstringRight(CStr(Me.dgvServicesStaffFee.Item(Me.colStaffNo.Name, toDeleteRowNo).Value))

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
            With oServicesStaffFee
                .ServiceCode = serviceCode
                .StaffNo = staffNo
            End With

            DisplayMessage(oServicesStaffFee.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvServicesStaffFee_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvServicesStaffFee.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadServicesStaffFee(ByVal serviceCode As String)

        Dim oServicesStaffFee As New SyncSoft.SQLDb.ServicesStaffFee()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim servicesStaffFee As DataTable = oServicesStaffFee.GetServicesStaffFee(serviceCode).Tables("ServicesStaffFee")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvServicesStaffFee, servicesStaffFee)

            For Each row As DataGridViewRow In Me.dgvServicesStaffFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvServicesStaffFee.Item(Me.colServicesStaffFeeSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " ServicesSpecialtyBillCustomFee - Grid "

    Private Sub dgvServicesSpecialtyBillCustomFee_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvServicesSpecialtyBillCustomFee.CellBeginEdit

        If Me.dgvServicesSpecialtyBillCustomFee.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvServicesSpecialtyBillCustomFee.CurrentCell.RowIndex

        If e.ColumnIndex = Me.colDoctorSpecialtyBillID.Index Then
            _DoctorSpecialtyBillIDValue = StringMayBeEnteredIn(Me.dgvServicesSpecialtyBillCustomFee.Rows(selectedRow).Cells, Me.colDoctorSpecialtyBillID)

        ElseIf e.ColumnIndex = Me.colSpecialtyBillCustomerName.Index Then
            _SpecialtyBillAccountNoValue = StringMayBeEnteredIn(Me.dgvServicesSpecialtyBillCustomFee.Rows(selectedRow).Cells, Me.colSpecialtyBillCustomerName)

        End If

    End Sub

    Private Sub dgvServicesSpecialtyBillCustomFee_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServicesSpecialtyBillCustomFee.CellEndEdit

        Try


            If e.ColumnIndex.Equals(Me.colDoctorSpecialtyBillID.Index) Then

                ' Ensure unique entry in the combo column

                If Me.colDoctorSpecialtyBillID.Items.Count < 1 Then Return

                If Me.dgvServicesSpecialtyBillCustomFee.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvServicesSpecialtyBillCustomFee.CurrentCell.RowIndex
                    Dim selectedDoctorSpecialty As String = StringMayBeEnteredIn(Me.dgvServicesSpecialtyBillCustomFee.Rows(selectedRow).Cells, Me.colDoctorSpecialtyBillID)
                    Dim selectedBillCustomerName As String = StringMayBeEnteredIn(Me.dgvServicesSpecialtyBillCustomFee.Rows(selectedRow).Cells, Me.colSpecialtyBillCustomerName)

                    If CBool(Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillCustomFeeSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Doctor Specialty (" + GetLookupDataDes(_DoctorSpecialtyBillIDValue) + ") can't be edited!")
                        Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colDoctorSpecialtyBillID.Name, selectedRow).Value = _DoctorSpecialtyBillIDValue
                        Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colDoctorSpecialtyBillID.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvServicesSpecialtyBillCustomFee.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then

                            Dim enteredDoctorSpecialty As String = StringMayBeEnteredIn(Me.dgvServicesSpecialtyBillCustomFee.Rows(rowNo).Cells, Me.colDoctorSpecialtyBillID)
                            Dim enteredBillCustomerName As String = StringMayBeEnteredIn(Me.dgvServicesSpecialtyBillCustomFee.Rows(rowNo).Cells, Me.colSpecialtyBillCustomerName)

                            If enteredDoctorSpecialty.Equals(selectedDoctorSpecialty) AndAlso enteredBillCustomerName.Trim().ToUpper().Equals(selectedBillCustomerName.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim enteredDisplay As String = String.Empty
                                If Not String.IsNullOrEmpty(enteredBillCustomerName) Then
                                    Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                                    enteredDisplay = (From data In _BillCustomers
                                                    Where data.Field(Of String)("AccountNo").ToUpper().Equals(enteredBillCustomerName.ToUpper())
                                                    Select data.Field(Of String)("BillCustomerName")).First()
                                Else : enteredDisplay = enteredBillCustomerName
                                End If
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Doctor Specialty (" + GetLookupDataDes(enteredDoctorSpecialty) + ") and To-Bill Account (" + enteredDisplay + ") already entered!")
                                Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colDoctorSpecialtyBillID.Name, selectedRow).Value = _DoctorSpecialtyBillIDValue
                                Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colDoctorSpecialtyBillID.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            ElseIf e.ColumnIndex.Equals(Me.colSpecialtyBillCustomerName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.colSpecialtyBillCustomerName.Items.Count < 1 Then Return

                If Me.dgvServicesSpecialtyBillCustomFee.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvServicesSpecialtyBillCustomFee.CurrentCell.RowIndex
                    Dim selectedDoctorSpecialty As String = StringMayBeEnteredIn(Me.dgvServicesSpecialtyBillCustomFee.Rows(selectedRow).Cells, Me.colDoctorSpecialtyBillID)
                    Dim selectedBillCustomerName As String = StringMayBeEnteredIn(Me.dgvServicesSpecialtyBillCustomFee.Rows(selectedRow).Cells, Me.colSpecialtyBillCustomerName)

                    If CBool(Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillCustomFeeSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                        Dim billCustomerName As String = (From data In _BillCustomers
                                            Where data.Field(Of String)("AccountNo").ToUpper().Equals(_SpecialtyBillAccountNoValue.ToUpper())
                                            Select data.Field(Of String)("BillCustomerName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("To-Bill Account (" + billCustomerName + ") can't be edited!")
                        Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillCustomerName.Name, selectedRow).Value = _SpecialtyBillAccountNoValue
                        Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillCustomerName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvServicesSpecialtyBillCustomFee.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then

                            Dim enteredDoctorSpecialty As String = StringMayBeEnteredIn(Me.dgvServicesSpecialtyBillCustomFee.Rows(rowNo).Cells, Me.colDoctorSpecialtyBillID)
                            Dim enteredBillCustomerName As String = StringMayBeEnteredIn(Me.dgvServicesSpecialtyBillCustomFee.Rows(rowNo).Cells, Me.colSpecialtyBillCustomerName)

                            If enteredDoctorSpecialty.Equals(selectedDoctorSpecialty) AndAlso enteredBillCustomerName.Trim().ToUpper().Equals(selectedBillCustomerName.Trim().ToUpper()) Then
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _BillCustomers
                                                    Where data.Field(Of String)("AccountNo").ToUpper().Equals(enteredBillCustomerName.ToUpper())
                                                    Select data.Field(Of String)("BillCustomerName")).First()
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Doctor Specialty (" + GetLookupDataDes(enteredDoctorSpecialty) + ") and To-Bill Account (" + enteredDisplay + ") already entered!")
                                Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillCustomerName.Name, selectedRow).Value = _SpecialtyBillAccountNoValue
                                Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillCustomerName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.DetailServicesSpecialtyBillCustomFee()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub DetailServicesSpecialtyBillCustomFee()

        Dim selectedRow As Integer
        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvServicesSpecialtyBillCustomFee.Rows.Count > 1 Then
                selectedRow = Me.dgvServicesSpecialtyBillCustomFee.CurrentCell.RowIndex
                selectedItem = StringMayBeEnteredIn(Me.dgvServicesSpecialtyBillCustomFee.Rows(selectedRow).Cells, Me.colSpecialtyBillCustomerName)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(selectedItem) Then
                Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillAccountNo.Name, selectedRow).Value = selectedItem
            Else : Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillAccountNo.Name, selectedRow).Value = String.Empty
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvServicesSpecialtyBillCustomFee_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvServicesSpecialtyBillCustomFee.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oServicesSpecialtyBillCustomFee As New SyncSoft.SQLDb.ServicesSpecialtyBillCustomFee()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillCustomFeeSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim serviceCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))
            Dim doctorSpecialtyID As String = CStr(Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colDoctorSpecialtyBillID.Name, toDeleteRowNo).Value)
            Dim accountNo As String = CStr(Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillCustomerName.Name, toDeleteRowNo).Value)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oServicesSpecialtyBillCustomFee
                .ServiceCode = serviceCode
                .DoctorSpecialtyID = doctorSpecialtyID
                .AccountNo = accountNo
            End With

            DisplayMessage(oServicesSpecialtyBillCustomFee.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadServicesSpecialtyBillCustomFee(ByVal serviceCode As String)

        Dim oServicesSpecialtyBillCustomFee As New SyncSoft.SQLDb.ServicesSpecialtyBillCustomFee()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim servicesSpecialtyBillCustomFee As DataTable = oServicesSpecialtyBillCustomFee.GetServicesSpecialtyBillCustomFee(serviceCode).Tables("ServicesSpecialtyBillCustomFee")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvServicesSpecialtyBillCustomFee, servicesSpecialtyBillCustomFee)

            For Each row As DataGridViewRow In Me.dgvServicesSpecialtyBillCustomFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvServicesSpecialtyBillCustomFee.Item(Me.colSpecialtyBillCustomFeeSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " ServicesStaffBillCustomFee - Grid "

    Private Sub dgvServicesStaffBillCustomFee_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvServicesStaffBillCustomFee.CellBeginEdit

        If Me.dgvServicesStaffBillCustomFee.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvServicesStaffBillCustomFee.CurrentCell.RowIndex

        If e.ColumnIndex = Me.colStaffBillID.Index Then
            _DoctorStaffBillIDValue = StringMayBeEnteredIn(Me.dgvServicesStaffBillCustomFee.Rows(selectedRow).Cells, Me.colStaffBillID)

        ElseIf e.ColumnIndex = Me.colStaffBillCustomerName.Index Then
            _StaffBillAccountNoValue = StringMayBeEnteredIn(Me.dgvServicesStaffBillCustomFee.Rows(selectedRow).Cells, Me.colStaffBillCustomerName)

        End If

    End Sub

    Private Sub dgvServicesStaffBillCustomFee_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServicesStaffBillCustomFee.CellEndEdit

        Try


            If e.ColumnIndex.Equals(Me.colStaffBillID.Index) Then

                ' Ensure unique entry in the combo column

                If Me.colStaffBillID.Items.Count < 1 Then Return

                If Me.dgvServicesStaffBillCustomFee.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvServicesStaffBillCustomFee.CurrentCell.RowIndex
                    Dim selectedDoctorStaff As String = StringMayBeEnteredIn(Me.dgvServicesStaffBillCustomFee.Rows(selectedRow).Cells, Me.colStaffBillID)
                    Dim selectedBillCustomerName As String = StringMayBeEnteredIn(Me.dgvServicesStaffBillCustomFee.Rows(selectedRow).Cells, Me.colStaffBillCustomerName)

                    If CBool(Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillCustomFeeSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Doctor Staff (" + SubstringLeft(_DoctorStaffBillIDValue) + ") can't be edited!")
                        Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillID.Name, selectedRow).Value = _DoctorStaffBillIDValue
                        Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillID.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvServicesStaffBillCustomFee.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then

                            Dim enteredDoctorStaff As String = StringMayBeEnteredIn(Me.dgvServicesStaffBillCustomFee.Rows(rowNo).Cells, Me.colStaffBillID)
                            Dim enteredBillCustomerName As String = StringMayBeEnteredIn(Me.dgvServicesStaffBillCustomFee.Rows(rowNo).Cells, Me.colStaffBillCustomerName)

                            If enteredDoctorStaff.Equals(selectedDoctorStaff) AndAlso enteredBillCustomerName.Trim().ToUpper().Equals(selectedBillCustomerName.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim enteredDisplay As String = String.Empty
                                If Not String.IsNullOrEmpty(enteredBillCustomerName) Then
                                    Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                                    enteredDisplay = (From data In _BillCustomers
                                                    Where data.Field(Of String)("AccountNo").ToUpper().Equals(enteredBillCustomerName.ToUpper())
                                                    Select data.Field(Of String)("BillCustomerName")).First()
                                Else : enteredDisplay = enteredBillCustomerName
                                End If
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Doctor Staff (" + SubstringLeft(enteredDoctorStaff) + ") and To-Bill Account (" + enteredDisplay + ") already entered!")
                                Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillID.Name, selectedRow).Value = _DoctorStaffBillIDValue
                                Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillID.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            ElseIf e.ColumnIndex.Equals(Me.colStaffBillCustomerName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.colStaffBillCustomerName.Items.Count < 1 Then Return

                If Me.dgvServicesStaffBillCustomFee.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvServicesStaffBillCustomFee.CurrentCell.RowIndex
                    Dim selectedDoctorStaff As String = StringMayBeEnteredIn(Me.dgvServicesStaffBillCustomFee.Rows(selectedRow).Cells, Me.colStaffBillID)
                    Dim selectedBillCustomerName As String = StringMayBeEnteredIn(Me.dgvServicesStaffBillCustomFee.Rows(selectedRow).Cells, Me.colStaffBillCustomerName)

                    If CBool(Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillCustomFeeSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                        Dim billCustomerName As String = (From data In _BillCustomers
                                            Where data.Field(Of String)("AccountNo").ToUpper().Equals(_StaffBillAccountNoValue.ToUpper())
                                            Select data.Field(Of String)("BillCustomerName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("To-Bill Account (" + billCustomerName + ") can't be edited!")
                        Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillCustomerName.Name, selectedRow).Value = _StaffBillAccountNoValue
                        Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillCustomerName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvServicesStaffBillCustomFee.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then

                            Dim enteredDoctorStaff As String = StringMayBeEnteredIn(Me.dgvServicesStaffBillCustomFee.Rows(rowNo).Cells, Me.colStaffBillID)
                            Dim enteredBillCustomerName As String = StringMayBeEnteredIn(Me.dgvServicesStaffBillCustomFee.Rows(rowNo).Cells, Me.colStaffBillCustomerName)

                            If enteredDoctorStaff.Equals(selectedDoctorStaff) AndAlso enteredBillCustomerName.Trim().ToUpper().Equals(selectedBillCustomerName.Trim().ToUpper()) Then
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _BillCustomers
                                                    Where data.Field(Of String)("AccountNo").ToUpper().Equals(enteredBillCustomerName.ToUpper())
                                                    Select data.Field(Of String)("BillCustomerName")).First()
                                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Doctor Staff (" + SubstringLeft(enteredDoctorStaff) + ") and To-Bill Account (" + enteredDisplay + ") already entered!")
                                Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillCustomerName.Name, selectedRow).Value = _StaffBillAccountNoValue
                                Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillCustomerName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.DetailServicesStaffBillCustomFee()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub DetailServicesStaffBillCustomFee()

        Dim selectedRow As Integer
        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvServicesStaffBillCustomFee.Rows.Count > 1 Then
                selectedRow = Me.dgvServicesStaffBillCustomFee.CurrentCell.RowIndex
                selectedItem = StringMayBeEnteredIn(Me.dgvServicesStaffBillCustomFee.Rows(selectedRow).Cells, Me.colStaffBillCustomerName)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(selectedItem) Then
                Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillAccountNo.Name, selectedRow).Value = selectedItem
            Else : Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillAccountNo.Name, selectedRow).Value = String.Empty
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvServicesStaffBillCustomFee_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvServicesStaffBillCustomFee.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oServicesStaffBillCustomFee As New SyncSoft.SQLDb.ServicesStaffBillCustomFee()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillCustomFeeSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim serviceCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))
            Dim doctorStaffID As String = SubstringRight(CStr(Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillID.Name, toDeleteRowNo).Value))
            Dim accountNo As String = CStr(Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillCustomerName.Name, toDeleteRowNo).Value)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oServicesStaffBillCustomFee
                .ServiceCode = serviceCode
                .StaffNo = doctorStaffID
                .AccountNo = accountNo
            End With

            DisplayMessage(oServicesStaffBillCustomFee.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadServicesStaffBillCustomFee(ByVal serviceCode As String)

        Dim oServicesStaffBillCustomFee As New SyncSoft.SQLDb.ServicesStaffBillCustomFee()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim servicesStaffBillCustomFee As DataTable = oServicesStaffBillCustomFee.GetServicesStaffBillCustomFee(serviceCode).Tables("ServicesStaffBillCustomFee")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvServicesStaffBillCustomFee, servicesStaffBillCustomFee)

            For Each row As DataGridViewRow In Me.dgvServicesStaffBillCustomFee.Rows
                If row.IsNewRow Then Exit For
                Me.dgvServicesStaffBillCustomFee.Item(Me.colStaffBillCustomFeeSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " ServicesSpecialtyCustomCode - Grid "

    Private Sub dgvServicesSpecialtyCustomCode_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvServicesSpecialtyCustomCode.CellBeginEdit

        If e.ColumnIndex <> Me.colDoctorSpecialtyCustomCodeID.Index OrElse Me.dgvServicesSpecialtyCustomCode.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvServicesSpecialtyCustomCode.CurrentCell.RowIndex
        _DoctorSpecialtyCustomCodeIDValue = StringMayBeEnteredIn(Me.dgvServicesSpecialtyCustomCode.Rows(selectedRow).Cells, Me.colDoctorSpecialtyCustomCodeID)

    End Sub

    Private Sub dgvServicesSpecialtyCustomCode_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServicesSpecialtyCustomCode.CellEndEdit

        Try

            If Me.colDoctorSpecialtyCustomCodeID.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colDoctorSpecialtyCustomCodeID.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvServicesSpecialtyCustomCode.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvServicesSpecialtyCustomCode.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvServicesSpecialtyCustomCode.Rows(selectedRow).Cells, Me.colDoctorSpecialtyCustomCodeID)

                    If CBool(Me.dgvServicesSpecialtyCustomCode.Item(Me.colServicesSpecialtyCustomCodeSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Doctor Specialty (" + GetLookupDataDes(_DoctorSpecialtyCustomCodeIDValue) + ") can't be edited!")
                        Me.dgvServicesSpecialtyCustomCode.Item(Me.colDoctorSpecialtyCustomCodeID.Name, selectedRow).Value = _DoctorSpecialtyCustomCodeIDValue
                        Me.dgvServicesSpecialtyCustomCode.Item(Me.colDoctorSpecialtyCustomCodeID.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvServicesSpecialtyCustomCode.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvServicesSpecialtyCustomCode.Rows(rowNo).Cells, Me.colDoctorSpecialtyCustomCodeID)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Doctor Specialty (" + GetLookupDataDes(enteredItem) + ") already entered!")
                                Me.dgvServicesSpecialtyCustomCode.Item(Me.colDoctorSpecialtyCustomCodeID.Name, selectedRow).Value = _DoctorSpecialtyCustomCodeIDValue
                                Me.dgvServicesSpecialtyCustomCode.Item(Me.colDoctorSpecialtyCustomCodeID.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvServicesSpecialtyCustomCode_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvServicesSpecialtyCustomCode.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oServicesSpecialtyCustomCode As New SyncSoft.SQLDb.ServicesSpecialtyCustomCode()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvServicesSpecialtyCustomCode.Item(Me.colServicesSpecialtyCustomCodeSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim serviceCode As String = RevertText(StringEnteredIn(Me.cboServiceCode, "Service Code!"))
            Dim doctorSpecialtyID As String = CStr(Me.dgvServicesSpecialtyCustomCode.Item(Me.colDoctorSpecialtyCustomCodeID.Name, toDeleteRowNo).Value)

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
            With oServicesSpecialtyCustomCode
                .ServiceCode = serviceCode
                .DoctorSpecialtyID = doctorSpecialtyID
            End With

            DisplayMessage(oServicesSpecialtyCustomCode.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadServicesSpecialtyCustomCode(ByVal serviceCode As String)

        Dim oServicesSpecialtyCustomCode As New SyncSoft.SQLDb.ServicesSpecialtyCustomCode()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim servicesSpecialtyCustomCode As DataTable = oServicesSpecialtyCustomCode.GetServicesSpecialtyCustomCode(serviceCode).Tables("ServicesSpecialtyCustomCode")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvServicesSpecialtyCustomCode, ServicesSpecialtyCustomCode)

            For Each row As DataGridViewRow In Me.dgvServicesSpecialtyCustomCode.Rows
                If row.IsNewRow Then Exit For
                Me.dgvServicesSpecialtyCustomCode.Item(Me.colServicesSpecialtyCustomCodeSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
        Me.btnSearch.Visible = True

        Me.cboServiceCode.MaxLength = 34
        Me.LoadServices(True)

        Me.chkHidden.Enabled = True
        Me.fcbServiceBillAtID.Enabled = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgBillCustomFee)
        ResetControlsIn(Me.tpgInsuranceCustomFee)
        ResetControlsIn(Me.tpgServicesDrSpecialtyFee)
        ResetControlsIn(Me.tpgServicesStaffFee)
        ResetControlsIn(Me.tpgServicesSpecialtyBillCustomFee)
        ResetControlsIn(Me.tpgServicesStaffBillCustomFee)
        ResetControlsIn(Me.tpgServicesSpecialtyCustomCode)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.btnSearch.Visible = False

        Me.cboServiceCode.MaxLength = 10
        Me.LoadServices(False)

        Me.chkHidden.Enabled = False
        Me.fcbServiceBillAtID.Enabled = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgBillCustomFee)
        ResetControlsIn(Me.tpgInsuranceCustomFee)
        ResetControlsIn(Me.tpgServicesDrSpecialtyFee)
        ResetControlsIn(Me.tpgServicesStaffFee)
        ResetControlsIn(Me.tpgServicesSpecialtyBillCustomFee)
        ResetControlsIn(Me.tpgServicesStaffBillCustomFee)
        ResetControlsIn(Me.tpgServicesSpecialtyCustomCode)
        SetNextServiceCode()
        Me.cboServiceCode.Enabled = Not InitOptions.ServiceCodeLocked

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.fbnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.nbxStandardFee, AccessRights.Update)
            Security.Apply(Me.nbxUnitCost, AccessRights.Update)
            Security.Apply(Me.nbxVATPercentage, AccessRights.Update)

            Security.Apply(Me.dgvBillCustomFee, AccessRights.Write)
            Security.Apply(Me.dgvInsuranceCustomFee, AccessRights.Write)
            Security.Apply(Me.dgvServicesDrSpecialtyFee, AccessRights.Write)
            Security.Apply(Me.dgvServicesStaffBillCustomFee, AccessRights.Write)
            Security.Apply(Me.dgvServicesStaffFee, AccessRights.Write)
            Security.Apply(Me.dgvServicesSpecialtyBillCustomFee, AccessRights.Write)

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

    Private Sub LoadRevenueStreams()
        Dim oRevenueStream As New SyncSoft.SQLDb.RevenueStreams()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from RevenueStream
            cboRevenueStream.DataSource = Nothing
            Dim revenueStream As DataTable = oRevenueStream.GetRevenueStreams().Tables("RevenueStreams")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            cboRevenueStream.DataSource = revenueStream
            cboRevenueStream.ValueMember = "RevenueStreamCode"
            cboRevenueStream.DisplayMember = "Name"
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SetNextServiceCode()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oServices As New SyncSoft.SQLDb.Services()
            Dim oVariousOption As New VariousOptions()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Services", "ServiceCode").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim ServiceCodePrefix As String = oVariousOption.ServiceCodePrefix()
            Dim nextServiceCode As String = CStr(oServices.GetNextServiceID).PadLeft(paddingLEN, paddingCHAR)
            Me.cboServiceCode.Text = FormatText((ServiceCodePrefix + nextServiceCode).Trim(), "Services", "ServiceCode")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#End Region

End Class