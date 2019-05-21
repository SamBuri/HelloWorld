
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Drawing.Printing
Imports System.Collections.Generic



Public Class frmExtraBills

#Region " Fields "

    Dim keyNo As String = String.Empty
    Private defaultVisitType As String = String.Empty
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
    Private tipCoPayValueWords As New ToolTip()
    Private tipCashAccountBalanceWords As New ToolTip()
    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty
    Private admissionNo As String = String.Empty
    Private finalVisitNo As String = String.Empty
    Private oEntryModeID As New LookupDataID.EntryModeID()
    Private oPayStatusID As New LookupDataID.PayStatusID()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private oBenefitCodes As New LookupDataID.BenefitCodes()
    Private oBillModesID As New LookupDataID.BillModesID()
    Private oCoPayTypeID As New LookupDataID.CoPayTypeID()

    Private services As DataTable
    Private labTests As DataTable
    Private drugs As DataTable
    Private radiologyExaminations As DataTable
    Private procedures As DataTable
    Private dentalServices As DataTable
    Private theatreServices As DataTable
    Private opticalServices As DataTable
    Private maternityServices As DataTable
    Private iCUServices As DataTable
    Private consumableItems As DataTable
    Private extraChargeItems As DataTable

    Private _ServiceNameValue As String = String.Empty
    Private _AdmissionNameValue As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty
    Private _ExamNameValue As String = String.Empty
    Private _TestValue As String = String.Empty
    Private _ProcedureNameValue As String = String.Empty
    Private _DentalNameValue As String = String.Empty
    Private _TheatreNameValue As String = String.Empty
    Private _OpticalNameValue As String = String.Empty
    Private _MaternityNameValue As String = String.Empty
    Private _ICUNameValue As String = String.Empty
    Private _ConsumableItemValue As String = String.Empty
    Private _ExtraItemValue As String = String.Empty

    Private padItemNo As Integer = 4
    Private padItemName As Integer = 20
    Private padNotes As Integer = 16
    Private padQuantity As Integer = 4
    Private padUnitPrice As Integer = 13
    Private padAmount As Integer = 14

    Private itemCount As Integer
    Private totalBillInvoice As Decimal

    Private hasPackage As Boolean = False
    Private patientpackageNo As String = String.Empty
    Private ExtraBillIPDStatus As Boolean = False
    Private WithEvents docBillInvoice As New PrintDocument()

    ' The paragraphs.
    Private invoiceParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private OpackagesEXT As New SyncSoft.SQLDb.PackagesEXT

#End Region

#Region " Validations "

    Private Sub dtpExtraBillDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpExtraBillDate.Validating

        Dim errorMSG As String = "Extra bill date can't be before visit date!"

        Try

            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)
            Dim extraBillDate As Date = DateMayBeEnteredIn(Me.dtpExtraBillDate)

            If extraBillDate = AppData.NullDateValue Then Return

            If extraBillDate < visitDate Then
                ErrProvider.SetError(Me.dtpExtraBillDate, errorMSG)
                Me.dtpExtraBillDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpExtraBillDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmExtraBills_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpExtraBillDate.MaxDate = Today
            Me.lblBillForItem.Text = "Bill for " + Me.tbcExtraBills.SelectedTab.Text
            Me.ResetControls()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LockItemsUnitPrices()
            Me.HidesomeTabpages()
            Me.LoadStaff()
            Me.LoadServices()
            Me.LoadLabTests()
            Me.LoadRadiologyExaminations()
            Me.LoadDrugs()
            Me.LoadProcedures()
            Me.LoadDentalServices()
            Me.LoadTheatreServices()
            Me.LoadOpticalServices()
            Me.LoadMaternityServices()
            Me.LoadICUServices()
            Me.LoadConsumableItems()
            Me.LoadExtraChargeItems()
            Me.LocationVisibility()
              ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If defaultVisitType.Equals(oVisitTypeID.OutPatient) AndAlso Not String.IsNullOrEmpty(keyNo) Then
                Me.tbcExtraBills.TabPages.Remove(tpgAdmission)
                Me.Text = "OPD Extra Bills"
                Me.lblVisitNo.Text = "Visit No"
                ExtraBillIPDStatus = False
                If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
                    Me.stbExtraBillNo.Text = FormatText(keyNo, "ExtraBills", "ExtraBillNo")
                    Me.Search(keyNo)
                Else : Me.ShowOPDPatientDetails(keyNo)
                End If
            ElseIf defaultVisitType.Equals(oVisitTypeID.OutPatient) AndAlso String.IsNullOrEmpty(keyNo) Then
                Me.tbcExtraBills.TabPages.Remove(tpgAdmission)
                Me.Text = "OPD Extra Bills"
                Me.lblVisitNo.Text = "Visit No"
                ExtraBillIPDStatus = False
            End If

            If defaultVisitType.Equals(oVisitTypeID.InPatient) AndAlso Not String.IsNullOrEmpty(keyNo) Then
                Me.Text = "IPD Extra Bills"
                Me.lblVisitNo.Text = "Admission No"
                ExtraBillIPDStatus = True
                If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
                    Me.stbExtraBillNo.Text = FormatText(keyNo, "ExtraBills", "ExtraBillNo")
                    Me.Search(keyNo)
                Else : Me.ShowIPDPatientDetails(keyNo)
                End If
            ElseIf defaultVisitType.Equals(oVisitTypeID.InPatient) AndAlso String.IsNullOrEmpty(keyNo) Then
                Me.Text = "IPD Extra Bills"
                Me.lblVisitNo.Text = "Admission No"
                ExtraBillIPDStatus = True
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmExtraBills_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub HidesomeTabpages()
        Dim oVariousOptions As New VariousOptions()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Cursor = Cursors.WaitCursor()
            If oVariousOptions.HideBillFormItemsPresentAtIPDDoctor Then
                Me.tbcExtraBills.TabPages.Remove(tpgConsumables)
                Me.tbcExtraBills.TabPages.Remove(tpgDental)
                Me.tbcExtraBills.TabPages.Remove(tpgLaboratory)
                Me.tbcExtraBills.TabPages.Remove(tpgPrescriptions)
                Me.tbcExtraBills.TabPages.Remove(tpgTheatre)
                Me.tbcExtraBills.TabPages.Remove(tpgRadiology)
                Me.tbcExtraBills.TabPages.Remove(tpgProcedures)
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadServices()
        Dim oVariousOptions As New VariousOptions()
        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oServicePointID As New LookupDataID.ServicePointID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Services at Extra Bills

            If oVariousOptions.InheritOPDServicesAtIPD Then
                services = oServices.GetServicesAtServicePoint(oServicePointID.Visit).Tables("Services")
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.colServiceCode.Sorted = False
                LoadComboData(Me.colServiceCode, services, "ServiceCode", "ServiceName")

            ElseIf Not oVariousOptions.InheritOPDServicesAtIPD Then
                services = oServices.GetServicesAtServicePoint(oServicePointID.ExtraBills).Tables("Services")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.colServiceCode.Sorted = False
                LoadComboData(Me.colServiceCode, services, "ServiceCode", "ServiceName")
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    
    Private Sub LoadLabTests()

        Dim oLabTests As New SyncSoft.SQLDb.LabTests()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from LabTests
            If Not InitOptions.LoadLabTestsAtStart Then
                labTests = oLabTests.GetLabTests().Tables("LabTests")
                oSetupData.LabTests = labTests
            Else : labTests = oSetupData.LabTests
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colTest, labTests, "TestFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadRadiologyExaminations()

        Dim oRadiologyExaminations As New SyncSoft.SQLDb.RadiologyExaminations()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from RadiologyExaminations
            If Not InitOptions.LoadRadiologyExaminationsAtStart Then
                radiologyExaminations = oRadiologyExaminations.GetRadiologyExaminations().Tables("RadiologyExaminations")
                oSetupData.RadiologyExaminations = radiologyExaminations
            Else : radiologyExaminations = oSetupData.RadiologyExaminations
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colExamFullName, radiologyExaminations, "ExamFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDrugs()

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

    Private Sub DetailDrugLocationBalance()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try

            Dim locationID As String = StringValueMayBeEnteredIn(Me.cboLocationID, "Location!")
            If String.IsNullOrEmpty(locationID) Then Return

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For

                Dim drugNo As String = SubstringRight(StringMayBeEnteredIn(row.Cells, Me.colDrug))
                If String.IsNullOrEmpty(drugNo) Then Continue For

                Me.dgvPrescription.Item(Me.colDrugLocationBalance.Name, row.Index).Value = String.Empty
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(locationID, oItemCategoryID.Drug, drugNo).Tables("InventoryLocation")
                If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Continue For
                Dim inventoryRow As DataRow = inventoryLocation.Rows(0)

                Me.dgvPrescription.Item(Me.colDrugLocationBalance.Name, row.Index).Value = IntegerMayBeEnteredIn(inventoryRow, "UnitsAtHand")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub IssueConsumabes()
        Dim oVariousOptions As New VariousOptions()
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim oEntryModeID As New LookupDataID.EntryModeID()
          Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
       
         Dim lInventory As New List(Of DBConnect)
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim message As String
           
           '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim lExtraBillsEXT As New List(Of DBConnect)
            Dim oExtraBillsEXT As New SyncSoft.SQLDb.ExtraBillsEXT()
            

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim extraBillNo As String = StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No")
            Dim location As String = StringMayBeEnteredIn(Me.cboLocationID)
            Dim locationID As String = StringValueEnteredIn(Me.cboLocationID, "Location!")
            If Not String.IsNullOrEmpty(InitOptions.Location) AndAlso
               Not InitOptions.Location.ToUpper().Equals(GetLookupDataDes(locationID).ToUpper()) Then

                message = "Selected location " + location + " is not the same as " + InitOptions.Location +
                         " set for this point. " + ControlChars.NewLine + "Are you sure you want to continue?"

                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.cboLocationID.Focus() : Return

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1

                        Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                Dim consumableNo As String = SubstringRight(StringEnteredIn(cells, Me.colConsumableName, "Consumable Number!"))
                    Dim consumableName As String = StringEnteredIn(cells, Me.colConsumableName, "Consumable name!")
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colConsumableQuantity, "quantity!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colConsumableAmount, True, "amount!")

                Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.colUnitsInStock)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colOrderLevel)
                    Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days
                    Dim deficit As Integer = quantity - unitsInStock

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If quantity > 0 AndAlso unitsInStock < quantity Then
                        If Not oVariousOptions.AllowDispensingToNegative() Then

                            message = "Insufficient stock to give for " + consumableName + " with a deficit of " + deficit.ToString() +
                               ControlChars.NewLine + "The system does not allow to give a consumable that is out of stock. " +
                               "Please re-stock appropriately! "

                            Throw New ArgumentException(message)
                        Else
                            message = "Insufficient stock to give for " + consumableName + " with a deficit of " + deficit.ToString() +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If

                    ElseIf orderLevel >= unitsInStock - quantity Then

                        message = "Stock level for " + consumableName + " is running low. Please re-stock appropriately!"
                        DisplayMessage(message)

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim locationBalance As Integer = GetInventoryBalance(locationID, oItemCategoryID.Consumable, consumableNo)
                    If quantity > 0 AndAlso locationBalance < quantity Then
                        If Not oVariousOptions.AllowLocationIssuingToNegative() Then
                            message = "The system does not allow issuing of Consumable: " + consumableName + ", with unit(s) not present at " + location + "!"
                            Throw New ArgumentException(message)
                        Else
                            message = "You are about to issue Consumable: " + consumableName + ", with unit(s) not present at " + location + ". " +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                        If Not oVariousOptions.AllowDispensingExpiredConsumables() Then
                            message = "Expiry date for " + consumableName + " had reached. " +
                                "The system does not allow to dispence a Consumable that is expired. Please re-stock appropriately! "
                            Throw New ArgumentException(message)
                        Else
                            message = "Expiry date for " + consumableName + " had reached. " + ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If

                    ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                        message = "Consumable: " + consumableName + " has " + remainingDaysExpiryDate.ToString() +
                            " remaining day(s) to expire. Please re-stock appropriately!"
                        DisplayMessage(message)

                    ElseIf expiryDate = AppData.NullDateValue Then
                        message = "Expiry date for " + consumableName + " is not set. The system can not verify when this Consumable will expire!"
                        DisplayMessage(message)

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oInventory As New SyncSoft.SQLDb.Inventory()
                        With oInventory
                            .LocationID = locationID
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .ItemCode = consumableNo
                            .TranDate = Today
                            .StockTypeID = oStockTypeID.Issued
                            .Quantity = quantity
                            .Details = "Consumable(s) Issued to ExtraBillNo: " + extraBillNo
                            .EntryModeID = oEntryModeID.System
                            .LoginID = CurrentUser.LoginID
                            .BatchNo = String.Empty
                            .ExpiryDate = AppData.NullDateValue
                        End With
                        lInventory.Add(oInventory)
                    End Using
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            DoTransactions(transactions)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub LoadProcedures()

        Dim oProcedures As New SyncSoft.SQLDb.Procedures()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Procedures
            If Not InitOptions.LoadProceduresAtStart Then
                procedures = oProcedures.GetProcedures().Tables("Procedures")
                oSetupData.Procedures = procedures
            Else : procedures = oSetupData.Procedures
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colProcedureCode.Sorted = False
            LoadComboData(Me.colProcedureCode, procedures, "ProcedureCode", "ProcedureName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDentalServices()

        Dim oDentalServices As New SyncSoft.SQLDb.DentalServices()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from DentalServices
            If Not InitOptions.LoadDentalServicesAtStart Then
                dentalServices = oDentalServices.GetDentalServices().Tables("DentalServices")
                oSetupData.DentalServices = dentalServices
            Else : dentalServices = oSetupData.DentalServices
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDentalCode.Sorted = False
            LoadComboData(Me.colDentalCode, dentalServices, "DentalCode", "DentalName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            theatreServices = oTheatreServices.GetTheatreServices().Tables("TheatreServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colTheatreCode.Sorted = False
            LoadComboData(Me.colTheatreCode, theatreServices, "TheatreCode", "TheatreName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadOpticalServices()

        Dim oOpticalServices As New SyncSoft.SQLDb.OpticalServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from OpticalServices

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            opticalServices = oOpticalServices.GetOpticalServices().Tables("OpticalServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colOpticalCode.Sorted = False
            LoadComboData(Me.colOpticalCode, OpticalServices, "OpticalCode", "OpticalName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadMaternityServices()

        Dim oMaternityServices As New SyncSoft.SQLDb.MaternityServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from MaternityServices

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            maternityServices = oMaternityServices.GetMaternityServices().Tables("MaternityServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colMaternityCode.Sorted = False
            LoadComboData(Me.colMaternityCode, MaternityServices, "MaternityCode", "MaternityName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadICUServices()

        Dim oICUServices As New SyncSoft.SQLDb.ICUServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ICUServices

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            iCUServices = oICUServices.GetICUServices().Tables("ICUServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colICUCode.Sorted = False
            LoadComboData(Me.colICUCode, ICUServices, "ICUCode", "ICUName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadConsumableItems()

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ConsumableItems

            If Not InitOptions.LoadConsumableItemsAtStart Then
                consumableItems = oConsumableItems.GetConsumableItems().Tables("ConsumableItems")
                oSetupData.ConsumableItems = consumableItems
            Else : consumableItems = oSetupData.ConsumableItems
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colConsumableName, consumableItems, "ConsumableFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub DetailConsumableLocationBalance()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oInventoryLocation As New SyncSoft.SQLDb.InventoryLocation()

        Try

            Dim locationID As String = StringValueMayBeEnteredIn(Me.cboLocationID, "Location!")
            If String.IsNullOrEmpty(locationID) Then Return

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For

                Dim ConsumableNo As String = SubstringRight(StringMayBeEnteredIn(row.Cells, Me.colConsumableName))
                If String.IsNullOrEmpty(ConsumableNo) Then Continue For

                Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, row.Index).Value = String.Empty
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim inventoryLocation As DataTable = oInventoryLocation.GetInventoryLocation(locationID, oItemCategoryID.Consumable, ConsumableNo).Tables("InventoryLocation")
                If inventoryLocation Is Nothing OrElse inventoryLocation.Rows.Count < 1 Then Continue For
                Dim inventoryRow As DataRow = inventoryLocation.Rows(0)

                Me.dgvConsumables.Item(Me.colConsumableLocationBalance.Name, row.Index).Value = IntegerMayBeEnteredIn(inventoryRow, "UnitsAtHand")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadExtraChargeItems()

        Dim oExtraChargeItems As New SyncSoft.SQLDb.ExtraChargeItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ExtraChargeItems
            extraChargeItems = oExtraChargeItems.GetExtraChargeItems().Tables("ExtraChargeItems")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colExtraItemFullName, extraChargeItems, "ExtraItemFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

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

    Private Sub SetDefaultLocation()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboLocationID, LookupObjects.Location, True)
            If Not String.IsNullOrEmpty(InitOptions.Location) Then
                Me.cboLocationID.SelectedValue = GetLookupDataID(LookupObjects.Location, InitOptions.Location)
                Me.EnableSetInventoryLocation()
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowConsumableDetails(ByVal consumableNo As String, ByVal pos As Integer)

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try

            Dim consumables As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")

            If consumables Is Nothing OrElse consumableNo Is Nothing Then Return
            Dim row As DataRow = consumables.Rows(0)

            With Me.dgvConsumables
                .Item(Me.colUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
                Me.DetailConsumableLocationBalance()
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ShowDrugDetails(ByVal drugNo As String, ByVal pos As Integer)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try

            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")

            If drugs Is Nothing OrElse drugNo Is Nothing Then Return
            Dim row As DataRow = drugs.Rows(0)

            With Me.dgvPrescription

                .Item(Me.colDrugUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colDrugExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colDrugOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colHasAlternateDrugs.Name, pos).Value = BooleanMayBeEnteredIn(row, "HasAlternateDrugs")
                Me.DetailDrugLocationBalance()
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub stbExtraBillNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbExtraBillNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub SetNextExtraBillNo(ByVal visitNo As String, ByVal patientNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.stbExtraBillNo.Clear()
            Me.stbExtraBillNo.Text = FormatText(GetNextExtraBillNo(visitNo, patientNo), "ExtraBills", "ExtraBillNo")

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbVisitDate.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbPatientNo.Clear()
        Me.stbVisitStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceName.Clear()
        billModesID = String.Empty
        associatedBillNo = String.Empty
        admissionNo = String.Empty
        finalVisitNo = String.Empty
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.nbxCashAccountBalance.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.tipCashAccountBalanceWords.RemoveAll()
        ResetControlsIn(Me.pnlBill)
        Me.dgvAdmission.Rows.Clear()
        Me.fbnViewFullInvoice.Enabled = False
        hasPackage = False
        patientpackageNo = String.Empty

    End Sub

    Private Sub ResetTabControls()

        ResetControlsIn(Me.tpgAdmission)
        ResetControlsIn(Me.tpgServices)
        ResetControlsIn(Me.tpgLaboratory)
        ResetControlsIn(Me.tpgRadiology)
        ResetControlsIn(Me.tpgPrescriptions)
        ResetControlsIn(Me.tpgProcedures)
        ResetControlsIn(Me.tpgDental)
        ResetControlsIn(Me.tpgTheatre)
        ResetControlsIn(Me.tpgOptical)
        ResetControlsIn(Me.tpgMaternity)
        ResetControlsIn(Me.tpgICU)
        ResetControlsIn(Me.tpgConsumables)
        ResetControlsIn(Me.tpgExtraCharge)

    End Sub

    Private Sub ResetControls()

        ResetControlsIn(Me.pnlBill)
        Me.ResetTabControls()
        ResetControlsIn(Me.pnlNavigateExtraBills)

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ExtraBillIPDStatus = False Then
                Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                Me.ShowOPDPatientDetails(visitNo)
            ElseIf ExtraBillIPDStatus = True Then
                Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                Me.ShowIPDPatientDetails(visitNo)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If ExtraBillIPDStatus = False Then
            Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
            fFindVisitNo.ShowDialog(Me)
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.ShowOPDPatientDetails(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ElseIf ExtraBillIPDStatus = True Then
            Dim fFindAdmissionNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.AdmissionNo)
            fFindAdmissionNo.ShowDialog(Me)
            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(admissionNo) Then Return
            Me.ShowIPDPatientDetails(admissionNo)

        End If

    End Sub

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If ExtraBillIPDStatus = True Then
                Dim fInWardAdmissions As New frmInWardAdmissions(Me.stbVisitNo, AutoNumber.AdmissionNo)
                fInWardAdmissions.ShowDialog(Me)

                Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                Me.ShowIPDPatientDetails(visitNo)

            ElseIf ExtraBillIPDStatus = False Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
                fPeriodicVisits.ShowDialog(Me)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
                If String.IsNullOrEmpty(visitNo) Then Return
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Me.ShowOPDPatientDetails(visitNo)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub btnFindExtraBillNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindExtraBillNo.Click
        Dim fFindExtraBillNo As New frmFindAutoNo(Me.stbExtraBillNo, AutoNumber.ExtraBillNo)
        fFindExtraBillNo.ShowDialog(Me)
        Me.stbExtraBillNo.Focus()
    End Sub

    Private Sub LoadExtraBillsData(ByVal extraBillNo As String)

        Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()

        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim extraBills As DataTable = oExtraBills.GetExtraBills(extraBillNo).Tables("ExtraBills")
            Me.DisplayData(extraBills)

            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            Me.cboStaffNo.Enabled = String.IsNullOrEmpty(roundNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadAdmission(extraBillNo)
            Me.LoadServices(extraBillNo)
            Me.LoadPrescriptions(extraBillNo)
            Me.LoadLaboratory(extraBillNo)
            Me.LoadRadiology(extraBillNo)
            Me.LoadProcedures(extraBillNo)
            Me.LoadDental(extraBillNo)
            Me.LoadTheatre(extraBillNo)
            Me.LoadOptical(extraBillNo)
            Me.LoadMaternity(extraBillNo)
            Me.LoadICU(extraBillNo)
            Me.LoadConsumables(extraBillNo)
            Me.LoadExtraCharge(extraBillNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.tbcExtraBills.SelectedTab.Name

                Case Me.tpgAdmission.Name
                    Me.CalculateBillForAdmission()

                Case Me.tpgServices.Name
                    Me.CalculateBillForServices()

                Case Me.tpgLaboratory.Name
                    Me.CalculateBillForLaboratory()

                Case Me.tpgRadiology.Name
                    Me.CalculateBillForRadiology()

                Case Me.tpgPrescriptions.Name
                    Me.CalculateBillForPrescriptions()

                Case Me.tpgProcedures.Name
                    Me.CalculateBillForProcedures()

                Case Me.tpgDental.Name
                    Me.CalculateBillForDental()

                Case Me.tpgTheatre.Name
                    Me.CalculateBillForTheatre()

                Case Me.tpgOptical.Name
                    Me.CalculateBillForOptical()

                Case Me.tpgMaternity.Name
                    Me.CalculateBillForMaternity()

                Case Me.tpgICU.Name
                    Me.CalculateBillForICU()

                Case Me.tpgConsumables.Name
                    Me.CalculateBillForConsumables()

                Case Me.tpgExtraCharge.Name
                    Me.CalculateBillForExtraCharge()

                Case Else : ResetControlsIn(Me.pnlBill)

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnViewFullInvoice.Enabled = True
            Security.Apply(Me.fbnViewFullInvoice, AccessRights.Read)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub ShowOPDPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)
            Dim patientNo As String = StringEnteredIn(row, "PatientNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbVisitStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
            admissionNo = StringMayBeEnteredIn(row, "AdmissionNo")
            finalVisitNo = StringEnteredIn(row, "VisitNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Me.nbxCashAccountBalance.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashAccountBalance"), AppData.DecimalPlaces)
            Me.tipCashAccountBalanceWords.SetToolTip(Me.nbxCashAccountBalance, NumberToWords(DecimalMayBeEnteredIn(row, "CashAccountBalance")))
            hasPackage = BooleanMayBeEnteredIn(row, "HasPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextExtraBillNo(visitNo, patientNo)
            Me.DetailAdmission(admissionNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnViewFullInvoice.Enabled = True
            Security.Apply(Me.fbnViewFullInvoice, AccessRights.Read)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowIPDPatientDetails(ByVal admissionNo As String)

        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(admissionNo) Then Return

            Dim visits As DataTable = oAdmissions.GetAdmissions(admissionNo).Tables("Admissions")
            Dim row As DataRow = visits.Rows(0)
            Dim patientNo As String = StringEnteredIn(row, "PatientNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(admissionNo, "Admissions", "AdmissionNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbVisitStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
            admissionNo = StringMayBeEnteredIn(row, "AdmissionNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Me.nbxCashAccountBalance.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashAccountBalance"), AppData.DecimalPlaces)
            Me.tipCashAccountBalanceWords.SetToolTip(Me.nbxCashAccountBalance, NumberToWords(DecimalMayBeEnteredIn(row, "CashAccountBalance")))
            hasPackage = BooleanMayBeEnteredIn(row, "HasPackage")
            patientpackageNo = StringMayBeEnteredIn(row, "PackageNo")
            finalVisitNo = StringEnteredIn(row, "VisitNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextExtraBillNo(finalVisitNo, patientNo)
            Me.DetailAdmission(admissionNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnViewFullInvoice.Enabled = True
            Security.Apply(Me.fbnViewFullInvoice, AccessRights.Read)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oExtraBills.ExtraBillNo = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            DisplayMessage(oExtraBills.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.pnlBill)
            Me.ResetTabControls()
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            If String.IsNullOrEmpty(extraBillNo) Then Return

            Me.Search(extraBillNo)
            Me.dtpExtraBillDate.Checked = True

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Public Sub Search(ByVal extraBillNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor()

            Me.LoadExtraBillsData(extraBillNo)
            ResetControlsIn(Me.pnlNavigateExtraBills)

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateExtraBills)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Save Methods "

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()
            Dim lExtraBills As New List(Of DBConnect)
            Dim oVariousOptions As New VariousOptions()

            With oExtraBills

                .VisitNo = RevertText(finalVisitNo)
                .ExtraBillNo = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
                .ExtraBillDate = DateEnteredIn(Me.dtpExtraBillDate, "Extra Bill Date!")
                If ExtraBillIPDStatus = False Then
                    .VisitTypeID = oVisitTypeID.OutPatient
                ElseIf ExtraBillIPDStatus = True Then
                    .VisitTypeID = oVisitTypeID.InPatient
                End If
                .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Attending Doctor!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lExtraBills.Add(oExtraBills)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvAdmission.RowCount < 1 AndAlso Me.dgvServices.RowCount <= 1 AndAlso Me.dgvLabTests.RowCount <= 1 AndAlso
                Me.dgvRadiology.RowCount <= 1 AndAlso Me.dgvPrescription.RowCount <= 1 AndAlso Me.dgvProcedures.RowCount <= 1 AndAlso
                Me.dgvDental.RowCount <= 1 AndAlso Me.dgvTheatre.RowCount <= 1 AndAlso Me.dgvOptical.RowCount <= 1 AndAlso
                Me.dgvMaternity.RowCount <= 1 AndAlso Me.dgvICU.RowCount <= 1 AndAlso Me.dgvConsumables.RowCount <= 1 AndAlso
                Me.dgvExtraCharge.RowCount <= 1 Then
                message = "Must register at least one item for admission or services or laboratory or radiology or prescription " +
                          "or procedure or dental or theatre or optical or maternity or ICU or consumables or extra charge!"
                Throw New ArgumentException(message)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyAdmissionEntries(True)
            Me.VerifyServicesEntries()
            Me.VerifyLaboratoryEntries()
            Me.VerifyRadiologyEntries()
            Me.VerifyPrescriptionsEntries()
            Me.VerifyProceduresEntries()
            Me.VerifyDentalEntries()
            Me.VerifyTheatreEntries()
            Me.VerifyOpticalEntries()
            Me.VerifyMaternityEntries()
            Me.VerifyICUEntries()
            Me.VerifyConsumablesEntries()
            Me.VerifyExtraChargeEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oExtraBills.IsBillsExtraBillDateSaved(oExtraBills.VisitNo, oExtraBills.ExtraBillDate) Then

                        If oVariousOptions.AllowCreateMultipleExtraBills Then
                            message = "You already have an extra bill on " + FormatDate(oExtraBills.ExtraBillDate) + ". " +
                                      "If you want to add services to previous bill, it can be done via in patients edit sub menu. " +
                                       ControlChars.NewLine + "Are you sure you want to save?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                        Else
                            message = "You already have an extra bill on " + FormatDate(oExtraBills.ExtraBillDate) + ". " +
                                      "If you want to add services to previous bill, it can be done via in patients edit sub menu. " +
                                      "The system is set not to allow multiple extra bills on the same date. " +
                                      "Please contact the administrator if you still need to create this bill."
                            Throw New ArgumentException(message)
                        End If

                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBills, Action.Save))
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If ExtraBillIPDStatus = True Then
                        Me.SaveAdmission()
                    End If
                    Me.SaveServices()
                    Me.SaveLaboratory()
                    Me.SaveRadiology()
                    Me.SavePrescriptions()
                    Me.SaveProcedures()
                    Me.SaveDental()
                    Me.SaveTheatre()
                    Me.SaveOptical()
                    Me.SaveMaternity()
                    Me.SaveICU()
                    Me.SaveConsumables()
                    Me.SaveExtraCharge()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.chkPrintInvoiceOnSaving.Checked Then Me.PrintBillInvoice()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If oVariousOptions.AllowOpenCashierAtBillingForm Then

                        Dim billMode As String = billModesID
                        Dim cashBillMode As String = oBillModesID.Cash
                        Dim fCashier As New frmCashier(finalVisitNo, oVisitTypeID.InPatient)
                        If Not billMode.ToUpper().Equals(cashBillMode.ToUpper()) Then
                            PrintBillInvoice()
                        Else

                            fCashier.ShowDialog()
                        End If

                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.pnlBill)
                    Me.ResetTabControls()
                    Me.SetDefaultLocation()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.chkPrintInvoiceOnSaving.Checked = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBills, Action.Update, "ExtraBills"))
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If ExtraBillIPDStatus = True Then
                        Me.SaveAdmission()
                    End If
                    Me.SaveServices()
                    Me.SaveLaboratory()
                    Me.SaveRadiology()
                    Me.SavePrescriptions()
                    Me.SaveProcedures()
                    Me.SaveDental()
                    Me.SaveTheatre()
                    Me.SaveOptical()
                    Me.SaveMaternity()
                    Me.SaveICU()
                    Me.SaveConsumables()
                    Me.SaveExtraCharge()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DisplayMessage("record(s) updated successfully!")
                    Me.CallOnKeyEdit()

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function SaveAdmission() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyAdmissionEntries(True)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvAdmission.RowCount - 1

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvAdmission.Rows(rowNo).Cells

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = StringEnteredIn(cells, Me.colAdmissionBedNo, "Bed No!")
                    Dim itemName As String = StringEnteredIn(cells, Me.colAdmissionBedName, "Bed Name!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colAdmissionQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colAdmissionUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colAdmissionNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Admission
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Admission).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If

                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Admission
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Admission).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Admission)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Admission)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Admission
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvAdmission.Item(Me.colAdmissionSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgAdmission.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgAdmission.Name)
            SaveAdmission = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyAdmissionEntries(ByVal checkAdmissionSaved As Boolean) As Boolean

        Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()

        Try


            Dim visitNo As String = RevertText(finalVisitNo)
            Dim extraBillDate As Date = DateEnteredIn(Me.dtpExtraBillDate, "Extra Bill Date!")

            For Each row As DataGridViewRow In Me.dgvAdmission.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colAdmissionBedNo, "Bed No!")
                SingleEnteredIn(row.Cells, Me.colAdmissionQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colAdmissionUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colAdmissionAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colAdmissionPayStatus, "Pay Status!")
            Next

            If Not checkAdmissionSaved OrElse Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return True

            If Me.dgvAdmission.Rows.Count > 0 AndAlso oExtraBills.IsAdmissionBillDateSaved(visitNo, extraBillDate) Then

                Dim message As String = "You already have an admission on " + FormatDate(extraBillDate) + ". " +
                              "If you want to alter previous admission, it can be done via in bill form edit sub menu. " +
                              "The system does not allow multiple admissions on the same date. "

                Throw New ArgumentException(message)

            End If

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgAdmission.Name)
            VerifyAdmissionEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveServices() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyServicesEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvServices.RowCount - 2

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvServices.Rows(rowNo).Cells

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = StringEnteredIn(cells, Me.colServiceCode, "Service!")
                    Dim _Services As EnumerableRowCollection(Of DataRow) = services.AsEnumerable()
                    Dim itemName As String = (From data In _Services
                                              Where data.Field(Of String)("ServiceCode").ToUpper().Equals(itemCode.ToUpper())
                                              Select data.Field(Of String)("ServiceName")).First()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colServiceQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colServiceUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colServiceNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Service
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Service).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Service
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Service).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If
                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Service)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Service)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Service
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvServices.Item(Me.colServicesSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgServices.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgServices.Name)
            SaveServices = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyServicesEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvServices.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colServiceCode, "Service!")
                SingleEnteredIn(row.Cells, Me.colServiceQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colServiceUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colServiceAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colServicePayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgServices.Name)
            VerifyServicesEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveLaboratory() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyLaboratoryEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells

                    Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colTest, "lab test!"))
                    Dim itemName As String = SubstringLeft(StringEnteredIn(cells, Me.colTest, "lab test!"))
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colLTQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colLTUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colLTNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Test
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Test).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Test
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Test).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If
                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Test)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Test)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Test
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgLaboratory.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgLaboratory.Name)
            SaveLaboratory = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyLaboratoryEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTest, "Lab Test!")
                SingleEnteredIn(row.Cells, Me.colLTQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colLTUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colLTAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colLTPayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgLaboratory.Name)
            VerifyLaboratoryEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveRadiology() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyRadiologyEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells

                    Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colExamFullName, "Radiology!"))
                    Dim itemName As String = SubstringLeft(StringEnteredIn(cells, Me.colExamFullName, "Radiology!"))
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colRadiologyQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colRadiologyUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colRadiologyNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Radiology
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Radiology).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If

                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Radiology
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Radiology).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Radiology)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Radiology)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Radiology
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgRadiology.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgRadiology.Name)
            SaveRadiology = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyRadiologyEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExamFullName, "Radiology!")
                SingleEnteredIn(row.Cells, Me.colRadiologyQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colRadiologyUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colRadiologyAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colRadiologyPayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgRadiology.Name)
            VerifyRadiologyEntries = False
            Throw ex

        End Try

    End Function

    Private Function SavePrescriptions() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)
        Dim oVariousOptions As New VariousOptions()
        Dim oStockTypeID As New LookupDataID.StockTypeID()
        Dim Message As String
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyPrescriptionsEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Try
                    Dim lInventory As New List(Of DBConnect)
                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))


                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colDrug, "Drug!"))
                    Dim itemName As String = SubstringLeft(StringEnteredIn(cells, Me.colDrug, "Drug!"))
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDrugQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDrugUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colDrugNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.colDrugUnitsInStock)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colDrugOrderLevel)
                    Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(cells, Me.colHasAlternateDrugs)
                    Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colDrugExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oVariousOptions.AllowExtraBillInventoryIssuing Then
                        Dim locationID As String = StringValueEnteredIn(Me.cboLocationID, "Location!")
                        If Not String.IsNullOrEmpty(InitOptions.Location) AndAlso
                             Not InitOptions.Location.ToUpper().Equals(GetLookupDataDes(locationID).ToUpper()) Then

                            Message = "Selected location " + cboLocationID.Text + " is not the same as " + InitOptions.Location +
                                " set for this point. " + ControlChars.NewLine + "Are you sure you want to continue?"

                            If WarningMessage(Message) = Windows.Forms.DialogResult.No Then Me.cboLocationID.Focus() : Return True

                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If quantity > 0 AndAlso unitsInStock < quantity Then
                            If Not oVariousOptions.AllowDispensingToNegative() Then
                                If hasAlternateDrugs Then
                                    Message = "Insufficient stock to dispense for " + itemName + " with a deficit of " +
                                      (quantity - unitsInStock).ToString() + " and has registered alternatives that shows at doctor. " +
                                      "The system does not allow to dispense a drug that is out of stock. Please re-stock appropriately! "
                                Else
                                    Message = "Insufficient stock to dispense for " + itemName + " with a deficit of " +
                                        (quantity - unitsInStock).ToString() + " and has no registered alternatives to show at doctor. " +
                                        "The system does not allow to dispence a drug that is out of stock. Please re-stock appropriately! "
                                End If
                                Throw New ArgumentException(Message)
                            Else
                                Message = "Insufficient stock to dispense for " + itemName +
                                          " with a deficit of " + (quantity - unitsInStock).ToString() +
                                          ControlChars.NewLine + "Are you sure you want to continue?"
                                If DeleteMessage(Message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                            End If

                        ElseIf orderLevel >= unitsInStock - quantity Then

                            If Not hasAlternateDrugs Then
                                Message = "Stock level for " + itemName + " is running low with no registered alternatives to show at doctor. " +
                                      "Please re-stock appropriately!"
                            Else : Message = "Stock level for " + itemName + " is running low. Please re-stock appropriately!"
                            End If
                            DisplayMessage(Message)

                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Dim locationBalance As Integer = GetInventoryBalance(locationID, oItemCategoryID.Drug, itemCode)
                        If quantity > 0 AndAlso locationBalance < quantity Then
                            If Not oVariousOptions.AllowLocationIssuingToNegative() Then
                                Message = "The system does not allow issuing of drug: " + itemName + ", with unit(s) not present at " + cboLocationID.Text + "!"
                                Throw New ArgumentException(Message)
                            Else
                                Message = "You are about to issue drug: " + itemName + ", with unit(s) not present at " + cboLocationID.Text + ". " +
                                          ControlChars.NewLine + "Are you sure you want to continue?"
                                If DeleteMessage(Message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                            End If
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                            If Not oVariousOptions.AllowDispensingExpiredDrugs() Then
                                Message = "Expiry date for " + itemName + " had reached. " +
                                    "The system does not allow to dispence a drug that is expired. Please re-stock appropriately! "
                                Throw New ArgumentException(Message)
                            Else
                                Message = "Expiry date for " + itemName + " had reached. " +
                                          ControlChars.NewLine + "Are you sure you want to continue?"
                                If DeleteMessage(Message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                            End If

                        ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                            Message = "Drug: " + itemName + " has " + remainingDaysExpiryDate.ToString() +
                                " remaining day(s) to expire. Please re-stock appropriately!"
                            DisplayMessage(Message)

                        ElseIf expiryDate = AppData.NullDateValue Then
                            Message = "Expiry date for " + itemName + " is not set. The system can not verify when this drug will expire!"
                            DisplayMessage(Message)

                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oInventory As New SyncSoft.SQLDb.Inventory()
                            With oInventory
                                .LocationID = locationID
                                .ItemCategoryID = oItemCategoryID.Drug
                                .ItemCode = itemCode
                                .TranDate = Today
                                .StockTypeID = oStockTypeID.Issued
                                .Quantity = quantity
                                .Details = "Drugs(s) Issued to ExtraBillNo: " + extraBillNo
                                .EntryModeID = oEntryModeID.System
                                .LoginID = CurrentUser.LoginID
                                .BatchNo = String.Empty
                                .ExpiryDate = AppData.NullDateValue
                            End With
                            lInventory.Add(oInventory)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Drug
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Drug).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If

                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))


                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Drug
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Drug).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Drug)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Drug)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Drug
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgPrescriptions.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgPrescriptions.Name)
            SavePrescriptions = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyPrescriptionsEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDrug, "Drug!")
                SingleEnteredIn(row.Cells, Me.colDrugQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colDrugUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colDrugAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colDrugPayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgPrescriptions.Name)
            VerifyPrescriptionsEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveProcedures() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyProceduresEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = StringEnteredIn(cells, Me.colProcedureCode, "Procedure!")
                    Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                    Dim itemName As String = (From data In _Procedures
                                              Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(itemCode.ToUpper())
                                              Select data.Field(Of String)("ProcedureName")).First()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colProcedureQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colProcedureUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colProcedureNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Procedure
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Procedure).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If

                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Procedure
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Procedure).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Procedure)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Procedure)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Procedure
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgProcedures.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgProcedures.Name)
            SaveProcedures = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyProceduresEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colProcedureCode, "Procedure!")
                SingleEnteredIn(row.Cells, Me.colProcedureQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colProcedureUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colProcedureAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colProcedurePayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgProcedures.Name)
            VerifyProceduresEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveDental() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyDentalEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 2

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = StringEnteredIn(cells, Me.colDentalCode, "Dental!")
                    Dim _DentalServices As EnumerableRowCollection(Of DataRow) = dentalServices.AsEnumerable()
                    Dim itemName As String = (From data In _DentalServices
                                              Where data.Field(Of String)("DentalCode").ToUpper().Equals(itemCode.ToUpper())
                                              Select data.Field(Of String)("DentalName")).First()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDentalQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDentalUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colDentalNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Dental
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Dental).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If

                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Dental
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Dental).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Dental)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Dental)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Dental
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDental.Item(Me.colDentalSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgDental.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgDental.Name)
            SaveDental = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyDentalEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colDentalCode, "Dental!")
                SingleEnteredIn(row.Cells, Me.colDentalQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colDentalUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colDentalAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colDentalPayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgDental.Name)
            VerifyDentalEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveTheatre() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyTheatreEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = StringEnteredIn(cells, Me.colTheatreCode, "Theatre!")
                    Dim _TheatreServices As EnumerableRowCollection(Of DataRow) = TheatreServices.AsEnumerable()
                    Dim itemName As String = (From data In _TheatreServices
                                              Where data.Field(Of String)("TheatreCode").ToUpper().Equals(itemCode.ToUpper())
                                              Select data.Field(Of String)("TheatreName")).First()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colTheatreQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colTheatreUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colTheatreNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Theatre
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Theatre).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If

                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Theatre
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Theatre).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Theatre)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Theatre)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Theatre
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgTheatre.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgTheatre.Name)
            SaveTheatre = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyTheatreEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colTheatreCode, "Theatre!")
                SingleEnteredIn(row.Cells, Me.colTheatreQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colTheatreUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colTheatreAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colTheatrePayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgTheatre.Name)
            VerifyTheatreEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveOptical() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyOpticalEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 2

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvOptical.Rows(rowNo).Cells

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = StringEnteredIn(cells, Me.colOpticalCode, "Optical!")
                    Dim _OpticalServices As EnumerableRowCollection(Of DataRow) = OpticalServices.AsEnumerable()
                    Dim itemName As String = (From data In _OpticalServices
                                              Where data.Field(Of String)("OpticalCode").ToUpper().Equals(itemCode.ToUpper())
                                              Select data.Field(Of String)("OpticalName")).First()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colOpticalQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colOpticalUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colOpticalNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Optical
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Optical).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If
                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Optical
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Optical).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Optical)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Optical)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Optical
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvOptical.Item(Me.colOpticalSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgOptical.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgOptical.Name)
            SaveOptical = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyOpticalEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvOptical.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colOpticalCode, "Optical!")
                SingleEnteredIn(row.Cells, Me.colOpticalQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colOpticalUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colOpticalAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colOpticalPayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgOptical.Name)
            VerifyOpticalEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveMaternity() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyMaternityEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvMaternity.RowCount - 2

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvMaternity.Rows(rowNo).Cells

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = StringEnteredIn(cells, Me.colMaternityCode, "Maternity!")
                    Dim _MaternityServices As EnumerableRowCollection(Of DataRow) = MaternityServices.AsEnumerable()
                    Dim itemName As String = (From data In _MaternityServices
                                              Where data.Field(Of String)("MaternityCode").ToUpper().Equals(itemCode.ToUpper())
                                              Select data.Field(Of String)("MaternityName")).First()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colMaternityQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colMaternityUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colMaternityNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Maternity
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Maternity).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If


                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Maternity
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Maternity).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If


                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Maternity)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Maternity)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Maternity
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvMaternity.Item(Me.colMaternitySaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgMaternity.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgMaternity.Name)
            SaveMaternity = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyMaternityEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvMaternity.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colMaternityCode, "Maternity!")
                SingleEnteredIn(row.Cells, Me.colMaternityQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colMaternityUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colMaternityAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colMaternityPayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgMaternity.Name)
            VerifyMaternityEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveICU() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyICUEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvICU.RowCount - 2

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvICU.Rows(rowNo).Cells

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim itemCode As String = StringEnteredIn(cells, Me.colICUCode, "ICU!")
                    Dim _ICUServices As EnumerableRowCollection(Of DataRow) = ICUServices.AsEnumerable()
                    Dim itemName As String = (From data In _ICUServices
                                              Where data.Field(Of String)("ICUCode").ToUpper().Equals(itemCode.ToUpper())
                                              Select data.Field(Of String)("ICUName")).First()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colICUQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colICUUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colICUNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.ICU
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.ICU).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If


                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.ICU
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.ICU).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.ICU)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.ICU)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.ICU
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvICU.Item(Me.colICUSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgICU.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgICU.Name)
            SaveICU = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyICUEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvICU.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colICUCode, "ICU!")
                SingleEnteredIn(row.Cells, Me.colICUQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colICUUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colICUAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colICUPayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgICU.Name)
            VerifyICUEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveConsumables() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)
        Dim oVariousOptions As New VariousOptions()
        Dim Message As String
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyConsumablesEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Try
                    Dim oStockTypeID As New LookupDataID.StockTypeID()
                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim lInventory As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                    Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colConsumableName, "consumable No!"))
                    Dim itemName As String = SubstringLeft(StringEnteredIn(cells, Me.colConsumableName, "consumable name!"))
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colConsumableQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colConsumableUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colConsumableNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100
                    Dim unitsInStock As Integer = IntegerMayBeEnteredIn(cells, Me.colUnitsInStock)
                    Dim expiryDate As Date = DateMayBeEnteredIn(cells, Me.colExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days
                    Dim deficit As Integer = quantity - unitsInStock
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(cells, Me.colOrderLevel)

                    If oVariousOptions.AllowExtraBillInventoryIssuing Then
                        Dim locationID As String = StringValueEnteredIn(Me.cboLocationID, "Location!")
                        If Not String.IsNullOrEmpty(InitOptions.Location) AndAlso
                   Not InitOptions.Location.ToUpper().Equals(GetLookupDataDes(locationID).ToUpper()) Then

                            Message = "Selected location " + cboLocationID.Text + " is not the same as " + InitOptions.Location +
                                     " set for this point. " + ControlChars.NewLine + "Are you sure you want to continue?"

                            If WarningMessage(Message) = Windows.Forms.DialogResult.No Then Me.cboLocationID.Focus() : Return True

                        End If
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        If quantity > 0 AndAlso unitsInStock < quantity Then
                            If Not oVariousOptions.AllowDispensingToNegative() Then

                                Message = "Insufficient stock to give for " + itemName + " with a deficit of " + deficit.ToString() +
                                   ControlChars.NewLine + "The system does not allow to give a consumable that is out of stock. " +
                                   "Please re-stock appropriately! "

                                Throw New ArgumentException(Message)
                            Else
                                Message = "Insufficient stock to give for " + itemName + " with a deficit of " + deficit.ToString() +
                                          ControlChars.NewLine + "Are you sure you want to continue?"
                                If DeleteMessage(Message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                            End If

                        ElseIf orderLevel >= unitsInStock - quantity Then

                            Message = "Stock level for " + itemName + " is running low. Please re-stock appropriately!"
                            DisplayMessage(Message)

                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim locationBalance As Integer = GetInventoryBalance(locationID, oItemCategoryID.Consumable, itemCode)
                        If quantity > 0 AndAlso locationBalance < quantity Then
                            If Not oVariousOptions.AllowLocationIssuingToNegative() Then
                                Message = "The system does not allow issuing of Consumable: " + itemName + ", with unit(s) not present at " + cboLocationID.Text + "!"
                                Throw New ArgumentException(Message)
                            Else
                                Message = "You are about to issue Consumable: " + itemName + ", with unit(s) not present at " + cboLocationID.Text + ". " +
                                          ControlChars.NewLine + "Are you sure you want to continue?"
                                If DeleteMessage(Message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                            End If
                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                            If Not oVariousOptions.AllowDispensingExpiredConsumables() Then
                                Message = "Expiry date for " + itemName + " had reached. " +
                                    "The system does not allow to dispence a Consumable that is expired. Please re-stock appropriately! "
                                Throw New ArgumentException(Message)
                            Else
                                Message = "Expiry date for " + itemName + " had reached. " + ControlChars.NewLine + "Are you sure you want to continue?"
                                If DeleteMessage(Message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                            End If

                        ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                            Message = "Consumable: " + itemName + " has " + remainingDaysExpiryDate.ToString() +
                                " remaining day(s) to expire. Please re-stock appropriately!"
                            DisplayMessage(Message)

                        ElseIf expiryDate = AppData.NullDateValue Then
                            Message = "Expiry date for " + itemName + " is not set. The system can not verify when this Consumable will expire!"
                            DisplayMessage(Message)

                        End If

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        'For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                        '    If row.IsNewRow Then Exit For
                        '    If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, row.Index).Value) = False Then

                        Using oInventory As New SyncSoft.SQLDb.Inventory()
                            With oInventory
                                .LocationID = locationID
                                .ItemCategoryID = oItemCategoryID.Consumable
                                .ItemCode = itemCode
                                .TranDate = Today
                                .StockTypeID = oStockTypeID.Issued
                                .Quantity = quantity
                                .Details = "Consumable(s) Issued to ExtraBillNo: " + extraBillNo
                                .EntryModeID = oEntryModeID.System
                                .LoginID = CurrentUser.LoginID
                                .BatchNo = String.Empty
                                .ExpiryDate = AppData.NullDateValue
                            End With
                            lInventory.Add(oInventory)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lInventory, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Consumable).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If


                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Consumable
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Consumable).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Consumable)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Consumable)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Consumable
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'If oVariousOptions.IssueExtraBillConsumables Then
                    '    Dim fIssueExtraBillConsumables As New frmIssueExtraBillConsumables(extraBillNo)
                    '    fIssueExtraBillConsumables.ShowDialog()
                    'End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgConsumables.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgConsumables.Name)
            SaveConsumables = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyConsumablesEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colConsumableName, "consumable name!")
                SingleEnteredIn(row.Cells, Me.colConsumableQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colConsumableUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colConsumableAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colConsumablePayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgConsumables.Name)
            VerifyConsumablesEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveExtraCharge() As Boolean

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim visitNo As String = RevertText(finalVisitNo)
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyExtraChargeEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()

                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims
                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID
                    End With
                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If String.IsNullOrEmpty(claimNo) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        With oClaimsEXT
                            .ClaimNo = oClaims.ClaimNo
                            .VisitNo = visitNo
                        End With

                        lClaimsEXT.Add(oClaimsEXT)

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        minTran.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DoTransactions(minTran)
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        claimNo = oClaims.ClaimNo
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If
                End Using
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayType As String = StringMayBeEnteredIn(Me.stbCoPayType)
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                Try

                    Dim lExtraBillItems As New List(Of DBConnect)
                    Dim lExtraBillItemsCASH As New List(Of DBConnect)
                    Dim transactions As New List(Of TransactionList(Of DBConnect))

                    Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells

                    Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colExtraItemFullName, "Extra Charge!"))
                    Dim itemName As String = SubstringLeft(StringEnteredIn(cells, Me.colExtraItemFullName, "Extra Charge!"))
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colExtraChargeQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colExtraChargeUnitPrice, False, "unit price!")
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colExtraChargeNotes)
                    Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Using oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
                        With oExtraBillItems
                            .ExtraBillNo = extraBillNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Extras
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .Notes = notes
                            .LastUpdate = DateEnteredIn(Me.dtpExtraBillDate, "Bill Date!")
                            If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Extras).Equals(True) Then
                                .PayStatusID = oPayStatusID.NA
                            Else
                                .PayStatusID = oPayStatusID.NotPaid
                            End If


                            .EntryModeID = oEntryModeID.Manual
                            .LoginID = CurrentUser.LoginID
                        End With
                        lExtraBillItems.Add(oExtraBillItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayType.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oExtraBillItemsCASH As New SyncSoft.SQLDb.ExtraBillItemsCASH()
                            With oExtraBillItemsCASH
                                .ExtraBillNo = extraBillNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Extras
                                .CashAmount = cashAmount
                                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, itemCode, oItemCategoryID.Extras).Equals(True) Then
                                    .CashPayStatusID = oPayStatusID.NA
                                Else
                                    .CashPayStatusID = oPayStatusID.NotPaid
                                End If

                            End With
                            lExtraBillItemsCASH.Add(oExtraBillItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lExtraBillItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim limitBalance As Decimal
                        Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Extras)
                        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Extras)
                        If limitAmount > 0 Then
                            limitBalance = limitAmount - consumedAmount
                        Else : limitBalance = 0
                        End If

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()
                            With oClaimDetails
                                .ClaimNo = claimNo
                                .ItemName = "Bill No: " + extraBillNo + " - " + itemName
                                .BenefitCode = oBenefitCodes.Extras
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = .Quantity * .UnitPrice
                                .Notes = notes
                                .LimitAmount = limitAmount
                                .ConsumedAmount = consumedAmount
                                .LimitBalance = limitBalance
                            End With
                            lClaimDetails.Add(oClaimDetails)
                        End Using

                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcExtraBills.SelectTab(Me.tpgExtraCharge.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgExtraCharge.Name)
            SaveExtraCharge = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyExtraChargeEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvExtraCharge.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExtraItemFullName, "Extra Charge!")
                SingleEnteredIn(row.Cells, Me.colExtraChargeQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colExtraChargeUnitPrice, False, "Unit Price!")
                DecimalEnteredIn(row.Cells, Me.colExtraChargeAmount, False, "Amount!")
                StringEnteredIn(row.Cells, Me.colExtraChargePayStatus, "Pay Status!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcExtraBills.SelectTab(Me.tpgExtraCharge.Name)
            VerifyExtraChargeEntries = False
            Throw ex

        End Try

    End Function

#End Region

    Private Sub fbnViewFullInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnViewFullInvoice.Click

        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(finalVisitNo)
            If String.IsNullOrEmpty(visitNo) Then Return

            Dim fPrintExtraBillsInvoice As New frmPrintExtraBillsInvoice(visitNo)
            fPrintExtraBillsInvoice.ShowDialog()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub tbcExtraBills_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcExtraBills.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor
            Me.LocationVisibility()
            Select Case Me.tbcExtraBills.SelectedTab.Name

                Case Me.tpgAdmission.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgAdmission.Text
                    Me.CalculateBillForAdmission()

                Case Me.tpgServices.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgServices.Text
                    Me.CalculateBillForServices()

                Case Me.tpgLaboratory.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgLaboratory.Text
                    Me.CalculateBillForLaboratory()

                Case Me.tpgRadiology.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgRadiology.Text
                    Me.CalculateBillForRadiology()

                Case Me.tpgPrescriptions.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgPrescriptions.Text
                    Me.CalculateBillForPrescriptions()

                Case Me.tpgProcedures.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgProcedures.Text
                    Me.CalculateBillForProcedures()

                Case Me.tpgDental.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgDental.Text
                    Me.CalculateBillForDental()

                Case Me.tpgTheatre.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgTheatre.Text
                    Me.CalculateBillForTheatre()

                Case Me.tpgOptical.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgOptical.Text
                    Me.CalculateBillForOptical()

                Case Me.tpgMaternity.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgMaternity.Text
                    Me.CalculateBillForMaternity()

                Case Me.tpgICU.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgICU.Text
                    Me.CalculateBillForICU()

                Case Me.tpgConsumables.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgConsumables.Text
                    Me.CalculateBillForConsumables()

                Case Me.tpgExtraCharge.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgExtraCharge.Text
                    Me.CalculateBillForExtraCharge()

                Case Else
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    ResetControlsIn(Me.pnlBill)

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Admission - Grid "

    Private Sub dgvAdmission_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvAdmission.CellBeginEdit

        If e.ColumnIndex <> Me.colAdmissionBedNo.Index OrElse Me.dgvAdmission.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvAdmission.CurrentCell.RowIndex
        _AdmissionNameValue = StringMayBeEnteredIn(Me.dgvAdmission.Rows(selectedRow).Cells, Me.colAdmissionBedNo)

    End Sub

    Private Sub dgvAdmission_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAdmission.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colAdmissionBedNo.Index) Then
                Me.CalculateAdmissionAmount()
                Me.CalculateBillForAdmission()

            ElseIf e.ColumnIndex.Equals(Me.colAdmissionQuantity.Index) Then
                Me.CalculateAdmissionAmount()
                Me.CalculateBillForAdmission()

            ElseIf e.ColumnIndex.Equals(Me.colAdmissionUnitPrice.Index) Then
                Me.CalculateAdmissionAmount()
                Me.CalculateBillForAdmission()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvAdmission_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvAdmission.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvAdmission.Item(Me.colAdmissionSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = CStr(Me.dgvAdmission.Item(Me.colAdmissionBedNo.Name, toDeleteRowNo).Value)

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
            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Admission
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvAdmission_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvAdmission.UserDeletedRow
        Me.CalculateBillForAdmission()
    End Sub

    Private Sub dgvAdmission_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvAdmission.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailAdmission(ByVal admissionNo As String)

        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()
        Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()

        Try

            If String.IsNullOrEmpty(admissionNo) Then Return

            Dim visitNo As String = RevertText(finalVisitNo)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim admissions As DataTable = oAdmissions.GetAdmissions(admissionNo).Tables("Admissions")

            If admissions Is Nothing OrElse admissions.Rows.Count < 1 Then Return
            If oExtraBills.IsAdmissionBillDateSaved(visitNo, Today) Then Return

            Me.dgvAdmission.Rows.Clear()

            For rowNo As Integer = 0 To admissions.Rows.Count - 1

                Dim row As DataRow = admissions.Rows(rowNo)

                With Me.dgvAdmission

                    .Rows.Add()

                    Dim bedNo As String = StringEnteredIn(row, "BedNo")
                    Dim quantity As Integer = 1
                    Dim unitPrice As Decimal = GetCustomFee(bedNo, oItemCategoryID.Admission, billNo, billModesID, associatedBillNo)

                    .Item(Me.colAdmissionBedNo.Name, rowNo).Value = StringEnteredIn(row, "BedNo")
                    .Item(Me.colAdmissionBedName.Name, rowNo).Value = StringEnteredIn(row, "BedName")
                    .Item(Me.colAdmissionQuantity.Name, rowNo).Value = quantity
                    .Item(Me.colAdmissionUnitPrice.Name, rowNo).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, bedNo, oItemCategoryID.Admission).Equals(True) Then
                        .Item(Me.colAdmissionPayStatus.Name, rowNo).Value = GetLookupDataDes(oPayStatusID.NA)
                    Else
                        .Item(Me.colAdmissionPayStatus.Name, rowNo).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                    End If

                    .Item(Me.colAdmissionEntryMode.Name, rowNo).Value = GetLookupDataDes(oEntryModeID.Manual)
                End With

                Me.CalculateAdmissionAmount()
            Next

            Me.CalculateBillForAdmission()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForAdmission()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvAdmission.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvAdmission.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colAdmissionAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateAdmissionAmount()

        Dim selectedRow As Integer = Me.dgvAdmission.CurrentCell.RowIndex
        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvAdmission.Rows(selectedRow).Cells, Me.colAdmissionQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvAdmission.Rows(selectedRow).Cells, Me.colAdmissionUnitPrice)

        Me.dgvAdmission.Item(Me.colAdmissionAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadAdmission(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvAdmission.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Admission).Tables("ExtraBillItems")

            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvAdmission, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvAdmission.Rows
                If row.IsNewRow Then Exit For
                Me.dgvAdmission.Item(Me.colAdmissionSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Services - Grid "

    Private Sub dgvServices_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvServices.CellBeginEdit

        If e.ColumnIndex <> Me.colServiceCode.Index OrElse Me.dgvServices.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvServices.CurrentCell.RowIndex
        _ServiceNameValue = StringMayBeEnteredIn(Me.dgvServices.Rows(selectedRow).Cells, Me.colServiceCode)

    End Sub

    Private Sub dgvServices_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvServices.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvServices.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colServiceCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvServices.Rows.Count > 1 Then Me.SetServicesEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colServiceQuantity.Index) Then
            Me.CalculateServicesAmount(selectedRow)
            Me.CalculateBillForServices()

            ElseIf e.ColumnIndex.Equals(Me.colServiceUnitPrice.Index) Then
            Me.CalculateServicesAmount(selectedRow)
            Me.CalculateBillForServices()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetServicesEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvServices.Rows(selectedRow).Cells, Me.colServiceCode)

            If CBool(Me.dgvServices.Item(Me.colServicesSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _Services As EnumerableRowCollection(Of DataRow) = services.AsEnumerable()
                Dim serviceDisplay As String = (From data In _Services
                                    Where data.Field(Of String)("ServiceCode").ToUpper().Equals(_ServiceNameValue.ToUpper())
                                    Select data.Field(Of String)("ServiceName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Service (" + serviceDisplay + ") can't be edited!")
                Me.dgvServices.Item(Me.colServiceCode.Name, selectedRow).Value = _ServiceNameValue
                Me.dgvServices.Item(Me.colServiceCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvServices.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvServices.Rows(rowNo).Cells, Me.colServiceCode)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Services As EnumerableRowCollection(Of DataRow) = services.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _Services
                                            Where data.Field(Of String)("ServiceCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("ServiceName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Service (" + enteredDisplay + ") already entered!")
                        Me.dgvServices.Item(Me.colServiceCode.Name, selectedRow).Value = _ServiceNameValue
                        Me.dgvServices.Item(Me.colServiceCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailServices(selectedRow)
            Me.CalculateServicesAmount(selectedRow)
            Me.CalculateBillForServices()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvServices_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvServices.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvServices.Item(Me.colServicesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = CStr(Me.dgvServices.Item(Me.colServiceCode.Name, toDeleteRowNo).Value)

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
            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Service
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvServices_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvServices.UserDeletedRow
        Me.CalculateBillForServices()
    End Sub

    Private Sub dgvServices_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvServices.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailServices(ByVal selectedRow As Integer)
        Dim oVariousOptions As New VariousOptions()
        Dim selectedItem As String = String.Empty
        Dim unitPrice As Decimal

        
        Try

            If Me.dgvServices.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvServices.Rows(selectedRow).Cells, Me.colServiceCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Attending Doctor!")
            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            If oVariousOptions.InheritOPDServicesAtIPD Then
                unitPrice = GetServicesStaffFee(selectedItem, staffNo, billNo, billModesID, associatedBillNo)

            ElseIf Not oVariousOptions.InheritOPDServicesAtIPD Then
                unitPrice = GetCustomFee(selectedItem, oItemCategoryID.Service, billNo, billModesID, associatedBillNo)
            End If

            With Me.dgvServices
                .Item(Me.colServiceQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colServiceUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)

                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Service).Equals(True) Then
                    .Item(Me.colServicePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else : .Item(Me.colServicePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If

                .Item(Me.colServiceEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForServices()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvServices.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvServices.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colServiceAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateServicesAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvServices.Rows(selectedRow).Cells, Me.colServiceQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvServices.Rows(selectedRow).Cells, Me.colServiceUnitPrice)

        Me.dgvServices.Item(Me.colServiceAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadServices(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvServices.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Service).Tables("ExtraBillItems")

            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvServices, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvServices.Rows
                If row.IsNewRow Then Exit For
                Me.dgvServices.Item(Me.colServicesSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Lab Tests - Grid "

    Private Sub dgvLabTests_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvLabTests.CellBeginEdit

        If e.ColumnIndex <> Me.colTest.Index OrElse Me.dgvLabTests.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvLabTests.CurrentCell.RowIndex
        _TestValue = StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colTest)

    End Sub

    Private Sub dgvLabTests_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvLabTests.CellEndEdit

        Try

            If Me.colTest.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvLabTests.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colTest.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvLabTests.Rows.Count > 1 Then Me.SetLabTestsEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colLTQuantity.Index) Then
            Me.CalculateLaboratoryAmount(selectedRow)
            Me.CalculateBillForLaboratory()

            ElseIf e.ColumnIndex.Equals(Me.colLTUnitPrice.Index) Then
            Me.CalculateLaboratoryAmount(selectedRow)
            Me.CalculateBillForLaboratory()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetLabTestsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colTest)

            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Test (" + _TestValue + ") can't be edited!")
                Me.dgvLabTests.Item(Me.colTest.Name, selectedRow).Value = _TestValue
                Me.dgvLabTests.Item(Me.colTest.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvLabTests.Rows(rowNo).Cells, Me.colTest)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Test (" + enteredItem + ") already selected!")
                        Me.dgvLabTests.Item(Me.colTest.Name, selectedRow).Value = _TestValue
                        Me.dgvLabTests.Item(Me.colTest.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailLaboratory(selectedRow)
            Me.CalculateLaboratoryAmount(selectedRow)
            Me.CalculateBillForLaboratory()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvLabTests_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLabTests.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvLabTests.Item(Me.colTest.Name, toDeleteRowNo).Value))

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
            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Test
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvLabTests_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvLabTests.UserDeletedRow
        Me.CalculateBillForLaboratory()
    End Sub

    Private Sub dgvLabTests_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvLabTests.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailLaboratory(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvLabTests.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colTest)

            Dim testCode As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(testCode) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(testCode, oItemCategoryID.Test, billNo, billModesID, associatedBillNo)

            With Me.dgvLabTests
                .Item(Me.colLTQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colLTUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Test).Equals(True) Then
                    .Item(Me.colLTPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colLTPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If


                .Item(Me.colLTEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForLaboratory()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colLTAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateLaboratoryAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colLTQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvLabTests.Rows(selectedRow).Cells, Me.colLTUnitPrice)

        Me.dgvLabTests.Item(Me.colLTAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadLaboratory(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvLabTests.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Test).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvLabTests, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvLabTests.Rows
                If row.IsNewRow Then Exit For
                Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Radiology - Grid "

    Private Sub dgvRadiology_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvRadiology.CellBeginEdit

        If e.ColumnIndex <> Me.colExamFullName.Index OrElse Me.dgvRadiology.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvRadiology.CurrentCell.RowIndex
        _ExamNameValue = StringMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colExamFullName)

    End Sub

    Private Sub dgvRadiology_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRadiology.CellEndEdit

        Try

            If Me.colExamFullName.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvRadiology.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colExamFullName.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvRadiology.Rows.Count > 1 Then Me.SetRadiologyExaminationsEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colRadiologyQuantity.Index) Then
            Me.CalculateRadiologyAmount(selectedRow)
            Me.CalculateBillForRadiology()

            ElseIf e.ColumnIndex.Equals(Me.colRadiologyUnitPrice.Index) Then
            Me.CalculateRadiologyAmount(selectedRow)
            Me.CalculateBillForRadiology()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetRadiologyExaminationsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colExamFullName)

            If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Examination (" + _ExamNameValue + ") can't be edited!")
                Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Value = _ExamNameValue
                Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvRadiology.Rows(rowNo).Cells, Me.colExamFullName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Examination (" + enteredItem + ") already selected!")
                        Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Value = _ExamNameValue
                        Me.dgvRadiology.Item(Me.colExamFullName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailRadiology(selectedRow)
            Me.CalculateRadiologyAmount(selectedRow)
            Me.CalculateBillForRadiology()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''          

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvRadiology_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvRadiology.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvRadiology.Item(Me.colExamFullName.Name, toDeleteRowNo).Value))

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
            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Radiology
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvRadiology_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvRadiology.UserDeletedRow
        Me.CalculateBillForRadiology()
    End Sub

    Private Sub dgvRadiology_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvRadiology.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailRadiology(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvRadiology.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colExamFullName)

            Dim examCode As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(examCode) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(examCode, oItemCategoryID.Radiology, billNo, billModesID, associatedBillNo)

            With Me.dgvRadiology
                .Item(Me.colRadiologyQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colRadiologyUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, examCode, oItemCategoryID.Radiology).Equals(True) Then
                    .Item(Me.colRadiologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colRadiologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If


                .Item(Me.colRadiologyEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForRadiology()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colRadiologyAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateRadiologyAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colRadiologyQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvRadiology.Rows(selectedRow).Cells, Me.colRadiologyUnitPrice)

        Me.dgvRadiology.Item(Me.colRadiologyAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadRadiology(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvRadiology.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Radiology).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvRadiology, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                Me.dgvRadiology.Item(Me.colRadiologySaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Prescription - Grid "

    Private Sub dgvPrescription_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrescription.CellBeginEdit

        If e.ColumnIndex <> Me.colDrug.Index OrElse Me.dgvPrescription.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
        _PrescriptionDrugValue = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

    End Sub

    Private Sub dgvPrescription_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit

        Try

            If Me.colDrug.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colDrug.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvPrescription.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colDrugQuantity.Index) Then
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            ElseIf e.ColumnIndex.Equals(Me.colDrugUnitPrice.Index) Then
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailDrug(selectedRow)
            Me.CalculateDrugAmount(selectedRow)
            Me.CalculateBillForPrescriptions()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvPrescription_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPrescription.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvPrescription.Item(Me.colDrug.Name, toDeleteRowNo).Value))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oExtraBillItems.Delete())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPrescription_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvPrescription.UserDeletedRow
        Me.CalculateBillForPrescriptions()
    End Sub

    Private Sub dgvPrescription_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPrescription.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailDrug(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvPrescription.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            Dim drugNo As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(drugNo) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(drugNo, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)

            With Me.dgvPrescription
                .Item(Me.colDrugQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colDrugUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, drugNo, oItemCategoryID.Drug).Equals(True) Then
                    .Item(Me.colDrugPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colDrugPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If



                .Item(Me.colDrugEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
                ShowDrugDetails(drugNo, selectedRow)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForPrescriptions()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colDrugAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateDrugAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugUnitPrice)

        Me.dgvPrescription.Item(Me.colDrugAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadPrescriptions(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvPrescription.Rows.Clear()

            ' Load ExtraBillItems not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Drug).Tables("ExtraBillItems")

            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPrescription, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Procedures - Grid "

    Private Sub dgvProcedures_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvProcedures.CellBeginEdit

        If e.ColumnIndex <> Me.colProcedureCode.Index OrElse Me.dgvProcedures.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvProcedures.CurrentCell.RowIndex
        _ProcedureNameValue = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

    End Sub

    Private Sub dgvProcedures_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvProcedures.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvProcedures.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colProcedureCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvProcedures.Rows.Count > 1 Then Me.SetProceduresEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colProcedureQuantity.Index) Then
            Me.CalculateProceduresAmount(selectedRow)
            Me.CalculateBillForProcedures()

            ElseIf e.ColumnIndex.Equals(Me.colProcedureUnitPrice.Index) Then
            Me.CalculateProceduresAmount(selectedRow)
            Me.CalculateBillForProcedures()

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetProceduresEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                Dim procedureDisplay As String = (From data In _Procedures
                                    Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(_ProcedureNameValue.ToUpper())
                                    Select data.Field(Of String)("ProcedureName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Procedure (" + procedureDisplay + ") can't be edited!")
                Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvProcedures.Rows(rowNo).Cells, Me.colProcedureCode)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _Procedures
                                            Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("ProcedureName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Procedure (" + enteredDisplay + ") already entered!")
                        Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                        Me.dgvProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailProcedures(selectedRow)
            Me.CalculateProceduresAmount(selectedRow)
            Me.CalculateBillForProcedures()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvProcedures_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvProcedures.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvProcedures.Item(Me.colProcedureCode.Name, toDeleteRowNo).Value))

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
            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvProcedures_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvProcedures.UserDeletedRow
        Me.CalculateBillForProcedures()
    End Sub

    Private Sub dgvProcedures_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvProcedures.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailProcedures(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvProcedures.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Procedure, billNo, billModesID, associatedBillNo)

            With Me.dgvProcedures
                .Item(Me.colProcedureQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colProcedureUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)

                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Procedure).Equals(True) Then
                    .Item(Me.colProcedurePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colProcedurePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If


                .Item(Me.colProcedureEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForProcedures()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colProcedureAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateProceduresAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvProcedures.Rows(selectedRow).Cells, Me.colProcedureUnitPrice)

        Me.dgvProcedures.Item(Me.colProcedureAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadProcedures(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvProcedures.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Procedure).Tables("ExtraBillItems")

            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvProcedures, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvProcedures.Rows
                If row.IsNewRow Then Exit For
                Me.dgvProcedures.Item(Me.colProceduresSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Dental - Grid "

    Private Sub dgvDental_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDental.CellBeginEdit

        If e.ColumnIndex <> Me.colDentalCode.Index OrElse Me.dgvDental.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDental.CurrentCell.RowIndex
        _DentalNameValue = StringMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalCode)

    End Sub

    Private Sub dgvDental_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDental.CellEndEdit

        Try

            If Me.colDentalCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvDental.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colDentalCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvDental.Rows.Count > 1 Then Me.SetDentalServiceEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colDentalQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateDentalAmount(selectedRow)
                Me.CalculateBillForDental()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colDentalUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateDentalAmount(selectedRow)
                Me.CalculateBillForDental()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDentalServiceEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalCode)

            If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _DentalServices As EnumerableRowCollection(Of DataRow) = dentalServices.AsEnumerable()
                Dim dentalDisplay As String = (From data In _DentalServices
                                    Where data.Field(Of String)("DentalCode").ToUpper().Equals(_DentalNameValue.ToUpper())
                                    Select data.Field(Of String)("DentalName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Dental (" + dentalDisplay + ") can't be edited!")
                Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Value = _DentalNameValue
                Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDental.Rows(rowNo).Cells, Me.colDentalCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _DentalServices As EnumerableRowCollection(Of DataRow) = dentalServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _DentalServices
                                            Where data.Field(Of String)("DentalCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("DentalName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Dental (" + enteredDisplay + ") already selected!")
                        Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Value = _DentalNameValue
                        Me.dgvDental.Item(Me.colDentalCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailDental(selectedRow)
            Me.CalculateDentalAmount(selectedRow)
            Me.CalculateBillForDental()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvDental_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDental.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = CStr(Me.dgvDental.Item(Me.colDentalCode.Name, toDeleteRowNo).Value)

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
            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Dental
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDental_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvDental.UserDeletedRow
        Me.CalculateBillForDental()
    End Sub

    Private Sub dgvDental_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDental.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailDental(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvDental.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Dental, billNo, billModesID, associatedBillNo)

            With Me.dgvDental
                .Item(Me.colDentalQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colDentalUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Dental).Equals(True) Then
                    .Item(Me.colDentalPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colDentalPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If


                .Item(Me.colDentalEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForDental()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvDental.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colDentalAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateDentalAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalUnitPrice)

        Me.dgvDental.Item(Me.colDentalAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadDental(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvDental.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Dental).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvDental, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvDental.Rows
                If row.IsNewRow Then Exit For
                Me.dgvDental.Item(Me.colDentalSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

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

            ElseIf e.ColumnIndex.Equals(Me.colTheatreQuantity.Index) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colTheatreUnitPrice.Index) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateTheatreAmount(selectedRow)
                Me.CalculateBillForTheatre()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailTheatre(selectedRow)
            Me.CalculateTheatreAmount(selectedRow)
            Me.CalculateBillForTheatre()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvTheatre_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvTheatre.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = CStr(Me.dgvTheatre.Item(Me.colTheatreCode.Name, toDeleteRowNo).Value)

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
            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Theatre
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvTheatre_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvTheatre.UserDeletedRow
        Me.CalculateBillForTheatre()
    End Sub

    Private Sub dgvTheatre_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvTheatre.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailTheatre(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvTheatre.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Theatre, billNo, billModesID, associatedBillNo)

            With Me.dgvTheatre
                .Item(Me.colTheatreQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colTheatreUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Theatre).Equals(True) Then

                    .Item(Me.colTheatrePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colTheatrePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If


                .Item(Me.colTheatreEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForTheatre()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colTheatreAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateTheatreAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreUnitPrice)

        Me.dgvTheatre.Item(Me.colTheatreAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadTheatre(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvTheatre.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Theatre).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvTheatre, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvTheatre.Rows
                If row.IsNewRow Then Exit For
                Me.dgvTheatre.Item(Me.colTheatreSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Optical - Grid "

    Private Sub dgvOptical_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvOptical.CellBeginEdit

        If e.ColumnIndex <> Me.colOpticalCode.Index OrElse Me.dgvOptical.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvOptical.CurrentCell.RowIndex
        _OpticalNameValue = StringMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalCode)

    End Sub

    Private Sub dgvOptical_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOptical.CellEndEdit

        Try

            If Me.colOpticalCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvOptical.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colOpticalCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvOptical.Rows.Count > 1 Then Me.SetOpticalServiceEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colOpticalQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateOpticalAmount(selectedRow)
                Me.CalculateBillForOptical()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colOpticalUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateOpticalAmount(selectedRow)
                Me.CalculateBillForOptical()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetOpticalServiceEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalCode)

            If CBool(Me.dgvOptical.Item(Me.colOpticalSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _OpticalServices As EnumerableRowCollection(Of DataRow) = opticalServices.AsEnumerable()
                Dim OpticalDisplay As String = (From data In _OpticalServices
                                    Where data.Field(Of String)("OpticalCode").ToUpper().Equals(_OpticalNameValue.ToUpper())
                                    Select data.Field(Of String)("OpticalName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Optical (" + OpticalDisplay + ") can't be edited!")
                Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Value = _OpticalNameValue
                Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvOptical.Rows(rowNo).Cells, Me.colOpticalCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _OpticalServices As EnumerableRowCollection(Of DataRow) = opticalServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _OpticalServices
                                            Where data.Field(Of String)("OpticalCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("OpticalName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Optical (" + enteredDisplay + ") already selected!")
                        Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Value = _OpticalNameValue
                        Me.dgvOptical.Item(Me.colOpticalCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailOptical(selectedRow)
            Me.CalculateOpticalAmount(selectedRow)
            Me.CalculateBillForOptical()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvOptical_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvOptical.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvOptical.Item(Me.colOpticalSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = CStr(Me.dgvOptical.Item(Me.colOpticalCode.Name, toDeleteRowNo).Value)

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
            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Optical
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvOptical_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvOptical.UserDeletedRow
        Me.CalculateBillForOptical()
    End Sub

    Private Sub dgvOptical_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvOptical.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailOptical(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvOptical.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Optical, billNo, billModesID, associatedBillNo)

            With Me.dgvOptical
                .Item(Me.colOpticalQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colOpticalUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Optical).Equals(True) Then
                    .Item(Me.colOpticalPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colOpticalPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If


                .Item(Me.colOpticalEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForOptical()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvOptical.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colOpticalAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateOpticalAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalUnitPrice)

        Me.dgvOptical.Item(Me.colOpticalAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadOptical(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvOptical.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Optical).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOptical, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvOptical.Rows
                If row.IsNewRow Then Exit For
                Me.dgvOptical.Item(Me.colOpticalSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Maternity - Grid "

    Private Sub dgvMaternity_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvMaternity.CellBeginEdit

        If e.ColumnIndex <> Me.colMaternityCode.Index OrElse Me.dgvMaternity.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvMaternity.CurrentCell.RowIndex
        _MaternityNameValue = StringMayBeEnteredIn(Me.dgvMaternity.Rows(selectedRow).Cells, Me.colMaternityCode)

    End Sub

    Private Sub dgvMaternity_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMaternity.CellEndEdit

        Try

            If Me.colMaternityCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvMaternity.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colMaternityCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvMaternity.Rows.Count > 1 Then Me.SetMaternityServiceEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colMaternityQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateMaternityAmount(selectedRow)
            Me.CalculateBillForMaternity()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colMaternityUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateMaternityAmount(selectedRow)
            Me.CalculateBillForMaternity()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetMaternityServiceEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvMaternity.Rows(selectedRow).Cells, Me.colMaternityCode)

            If CBool(Me.dgvMaternity.Item(Me.colMaternitySaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _MaternityServices As EnumerableRowCollection(Of DataRow) = maternityServices.AsEnumerable()
                Dim MaternityDisplay As String = (From data In _MaternityServices
                                    Where data.Field(Of String)("MaternityCode").ToUpper().Equals(_MaternityNameValue.ToUpper())
                                    Select data.Field(Of String)("MaternityName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Maternity (" + MaternityDisplay + ") can't be edited!")
                Me.dgvMaternity.Item(Me.colMaternityCode.Name, selectedRow).Value = _MaternityNameValue
                Me.dgvMaternity.Item(Me.colMaternityCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvMaternity.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvMaternity.Rows(rowNo).Cells, Me.colMaternityCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _MaternityServices As EnumerableRowCollection(Of DataRow) = maternityServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _MaternityServices
                                            Where data.Field(Of String)("MaternityCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("MaternityName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Maternity (" + enteredDisplay + ") already selected!")
                        Me.dgvMaternity.Item(Me.colMaternityCode.Name, selectedRow).Value = _MaternityNameValue
                        Me.dgvMaternity.Item(Me.colMaternityCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailMaternity(selectedRow)
            Me.CalculateMaternityAmount(selectedRow)
            Me.CalculateBillForMaternity()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvMaternity_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvMaternity.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvMaternity.Item(Me.colMaternitySaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = CStr(Me.dgvMaternity.Item(Me.colMaternityCode.Name, toDeleteRowNo).Value)

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
            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Maternity
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvMaternity_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvMaternity.UserDeletedRow
        Me.CalculateBillForMaternity()
    End Sub

    Private Sub dgvMaternity_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvMaternity.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailMaternity(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvMaternity.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvMaternity.Rows(selectedRow).Cells, Me.colMaternityCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Maternity, billNo, billModesID, associatedBillNo)

            With Me.dgvMaternity
                .Item(Me.colMaternityQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colMaternityUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colMaternityPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                .Item(Me.colMaternityEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForMaternity()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvMaternity.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvMaternity.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colMaternityAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateMaternityAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvMaternity.Rows(selectedRow).Cells, Me.colMaternityQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvMaternity.Rows(selectedRow).Cells, Me.colMaternityUnitPrice)

        Me.dgvMaternity.Item(Me.colMaternityAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadMaternity(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvMaternity.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Maternity).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvMaternity, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvMaternity.Rows
                If row.IsNewRow Then Exit For
                Me.dgvMaternity.Item(Me.colMaternitySaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " ICU - Grid "

    Private Sub dgvICU_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvICU.CellBeginEdit

        If e.ColumnIndex <> Me.colICUCode.Index OrElse Me.dgvICU.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvICU.CurrentCell.RowIndex
        _ICUNameValue = StringMayBeEnteredIn(Me.dgvICU.Rows(selectedRow).Cells, Me.colICUCode)

    End Sub

    Private Sub dgvICU_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvICU.CellEndEdit

        Try

            If Me.colICUCode.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvICU.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colICUCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvICU.Rows.Count > 1 Then Me.SetICUServiceEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colICUQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateICUAmount(selectedRow)
                Me.CalculateBillForICU()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colICUUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.CalculateICUAmount(selectedRow)
                Me.CalculateBillForICU()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetICUServiceEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvICU.Rows(selectedRow).Cells, Me.colICUCode)

            If CBool(Me.dgvICU.Item(Me.colICUSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _ICUServices As EnumerableRowCollection(Of DataRow) = iCUServices.AsEnumerable()
                Dim ICUDisplay As String = (From data In _ICUServices
                                    Where data.Field(Of String)("ICUCode").ToUpper().Equals(_ICUNameValue.ToUpper())
                                    Select data.Field(Of String)("ICUName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("ICU (" + ICUDisplay + ") can't be edited!")
                Me.dgvICU.Item(Me.colICUCode.Name, selectedRow).Value = _ICUNameValue
                Me.dgvICU.Item(Me.colICUCode.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvICU.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvICU.Rows(rowNo).Cells, Me.colICUCode)
                    If enteredItem.Equals(selectedItem) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _ICUServices As EnumerableRowCollection(Of DataRow) = iCUServices.AsEnumerable()
                        Dim enteredDisplay As String = (From data In _ICUServices
                                            Where data.Field(Of String)("ICUCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("ICUName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("ICU (" + enteredDisplay + ") already selected!")
                        Me.dgvICU.Item(Me.colICUCode.Name, selectedRow).Value = _ICUNameValue
                        Me.dgvICU.Item(Me.colICUCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailICU(selectedRow)
            Me.CalculateICUAmount(selectedRow)
            Me.CalculateBillForICU()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvICU_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvICU.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvICU.Item(Me.colICUSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
            Dim itemCode As String = CStr(Me.dgvICU.Item(Me.colICUCode.Name, toDeleteRowNo).Value)

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
            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.ICU
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvICU_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvICU.UserDeletedRow
        Me.CalculateBillForICU()
    End Sub

    Private Sub dgvICU_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvICU.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailICU(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvICU.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvICU.Rows(selectedRow).Cells, Me.colICUCode)

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(selectedItem) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.ICU, billNo, billModesID, associatedBillNo)

            With Me.dgvICU
                .Item(Me.colICUQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colICUUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.ICU).Equals(True) Then
                    .Item(Me.colICUPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colICUPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If



                .Item(Me.colICUEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForICU()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvICU.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvICU.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colICUAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateICUAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvICU.Rows(selectedRow).Cells, Me.colICUQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvICU.Rows(selectedRow).Cells, Me.colICUUnitPrice)

        Me.dgvICU.Item(Me.colICUAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadICU(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvICU.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.ICU).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvICU, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvICU.Rows
                If row.IsNewRow Then Exit For
                Me.dgvICU.Item(Me.colICUSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Consumables - Grid "

    Private Sub dgvConsumables_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvConsumables.CellBeginEdit

        If e.ColumnIndex <> Me.colConsumableName.Index OrElse Me.dgvConsumables.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
        _ConsumableItemValue = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

    End Sub

    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        Try

            If Me.colConsumableName.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colConsumableName.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvConsumables.Rows.Count > 1 Then Me.SetConsumableEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colConsumableQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateConsumablesAmount(selectedRow)
            Me.CalculateBillForConsumables()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colConsumableUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateConsumablesAmount(selectedRow)
            Me.CalculateBillForConsumables()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetConsumableEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Consumable Item Name (" + _ConsumableItemValue + ") can't be edited!")
                Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Value = _ConsumableItemValue
                Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(rowNo).Cells, Me.colConsumableName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Consumable Item Name (" + enteredItem + ") already selected!")
                        Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Value = _ConsumableItemValue
                        Me.dgvConsumables.Item(Me.colConsumableName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.DetailConsumableItem(selectedRow)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateConsumablesAmount(selectedRow)
            Me.CalculateBillForConsumables()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvConsumables.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvConsumables.Item(Me.colConsumableName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oExtraBillItems
                .extraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Consumable
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvConsumables_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvConsumables.UserDeletedRow
        Me.CalculateBillForConsumables()
    End Sub

    Private Sub dgvConsumables_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvConsumables.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailConsumableItem(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty
        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableName)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim consumableNo As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))
            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")
            If consumableItems Is Nothing OrElse String.IsNullOrEmpty(consumableNo) Then Return
            Dim row As DataRow = consumableItems.Rows(0)

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(consumableNo, oItemCategoryID.Consumable, billNo, billModesID, associatedBillNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.dgvConsumables
                .Item(Me.colConsumableQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colConsumableUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, selectedItem, oItemCategoryID.Consumable).Equals(True) Then
                    .Item(Me.colConsumablePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colConsumablePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If

                .Item(Me.colConsumableEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
                Me.ShowConsumableDetails(consumableNo, selectedRow)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateConsumablesAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.colConsumableUnitPrice)

        Me.dgvConsumables.Item(Me.colConsumableAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateBillForConsumables()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colConsumableAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub LoadConsumables(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items not yet paid for

            Dim consumableBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Consumable).Tables("ExtraBillItems")
            If consumableBillItems Is Nothing OrElse consumableBillItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvConsumables, consumableBillItems)

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For
                Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " ExtraCharge - Grid "

    Private Sub dgvExtraCharge_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvExtraCharge.CellBeginEdit

        If e.ColumnIndex <> Me.colExtraItemFullName.Index OrElse Me.dgvExtraCharge.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvExtraCharge.CurrentCell.RowIndex
        _ExtraItemValue = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraItemFullName)

    End Sub

    Private Sub dgvExtraCharge_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExtraCharge.CellEndEdit

        Try

            If Me.colExtraItemFullName.Items.Count < 1 Then Return

            Dim selectedRow As Integer = Me.dgvExtraCharge.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colExtraItemFullName.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvExtraCharge.Rows.Count > 1 Then Me.SetExtraChargeEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colExtraChargeQuantity.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateExtraChargeAmount(selectedRow)
            Me.CalculateBillForExtraCharge()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colExtraChargeUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateExtraChargeAmount(selectedRow)
            Me.CalculateBillForExtraCharge()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetExtraChargeEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraItemFullName)

            If CBool(Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Extra Item Name (" + _ExtraItemValue + ") can't be edited!")
                Me.dgvExtraCharge.Item(Me.colExtraItemFullName.Name, selectedRow).Value = _ExtraItemValue
                Me.dgvExtraCharge.Item(Me.colExtraItemFullName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(rowNo).Cells, Me.colExtraItemFullName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Extra Item Name (" + enteredItem + ") already selected!")
                        Me.dgvExtraCharge.Item(Me.colExtraItemFullName.Name, selectedRow).Value = _ExtraItemValue
                        Me.dgvExtraCharge.Item(Me.colExtraItemFullName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DetailExtraCharge(selectedRow)
            Me.CalculateExtraChargeAmount(selectedRow)
            Me.CalculateBillForExtraCharge()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvExtraCharge_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvExtraCharge.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvExtraCharge.Item(Me.colExtraItemFullName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oExtraBillItems
                .ExtraBillNo = extraBillNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Extras
            End With

            DisplayMessage(oExtraBillItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvExtraCharge_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvExtraCharge.UserDeletedRow
        Me.CalculateBillForExtraCharge()
    End Sub

    Private Sub dgvExtraCharge_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvExtraCharge.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub DetailExtraCharge(ByVal selectedRow As Integer)

        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvExtraCharge.Rows.Count > 1 Then selectedItem = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraItemFullName)

            Dim extraItemCode As String = SubstringRight(selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            If String.IsNullOrEmpty(extraItemCode) Then Return

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(extraItemCode, oItemCategoryID.Extras, billNo, billModesID, associatedBillNo)

            With Me.dgvExtraCharge
                .Item(Me.colExtraChargeQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colExtraChargeUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                If hasPackage.Equals(True) And OpackagesEXT.IsPackageItem(patientpackageNo, extraItemCode, oItemCategoryID.Extras).Equals(True) Then
                    .Item(Me.colExtraChargePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NA)
                Else
                    .Item(Me.colExtraChargePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                End If

                .Item(Me.colExtraChargeEntryMode.Name, selectedRow).Value = GetLookupDataDes(oEntryModeID.Manual)
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForExtraCharge()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 1
            Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells
            Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colExtraChargeAmount)
            totalBill += amount
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateExtraChargeAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraChargeQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraChargeUnitPrice)

        Me.dgvExtraCharge.Item(Me.colExtraChargeAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub LoadExtraCharge(ByVal extraBillNo As String)

        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            Me.dgvExtraCharge.Rows.Clear()

            ' Load items not yet paid for

            Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(extraBillNo, oItemCategoryID.Extras).Tables("ExtraBillItems")
            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvExtraCharge, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvExtraCharge.Rows
                If row.IsNewRow Then Exit For
                Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Extra Bills Navigate "

    Private Sub EnableNavigateExtraBillsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oExtraBills As New SyncSoft.SQLDb.ExtraBills()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim extraBillNo As String = RevertText(StringEnteredIn(Me.stbExtraBillNo, "Extra Bill No!"))
                Dim visitNo As String = RevertText(finalVisitNo)
                Dim extraBills As DataTable = oExtraBills.GetExtraBillsByVisitNo(visitNo).Tables("ExtraBills")

                For pos As Integer = 0 To extraBills.Rows.Count - 1
                    If extraBillNo.ToUpper().Equals(extraBills.Rows(pos).Item("ExtraBillNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navExtraBills.DataSource = extraBills
                Me.navExtraBills.Navigate(startPosition)

            Else : Me.navExtraBills.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateExtraBills.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateExtraBills_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateExtraBills.Click
        Me.EnableNavigateExtraBillsCTLS(Me.chkNavigateExtraBills.Checked)
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navExtraBills.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim extraBillNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(extraBillNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbExtraBillNo.Text = FormatText(extraBillNo, "ExtraBills", "ExtraBillNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadExtraBillsData(extraBillNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Invoice Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintBillInvoice()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintBillInvoice()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetInvoicePrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docBillInvoice
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docBillInvoice.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docBillInvoice_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBillInvoice.PrintPage

        Try
            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Invoice".ToUpper()
            Dim patientName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim invoiceNo As String = StringMayBeEnteredIn(Me.stbExtraBillNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim invoiceDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpExtraBillDate))
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim attendingDoctor As String = SubstringLeft(Me.cboStaffNo.Text)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 27 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not oVariousOptions.HideInvoiceHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Patient's Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Invoice No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(invoiceNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Invoice Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(invoiceDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Attending Doctor: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(attendingDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
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

                If invoiceParagraphs Is Nothing Then Return

                Do While invoiceParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(invoiceParagraphs(1), PrintParagraps)
                    invoiceParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont, _
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
                        invoiceParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (invoiceParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetInvoicePrintData()

        Dim padTotalAmount As Integer = 44
        Dim footerFont As New Font(printFontName, 9)

        itemCount = 0
        totalBillInvoice = 0
        pageNo = 0
        invoiceParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Notes: ".PadRight(padNotes))
            tableHeader.Append("Qty: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.AdmissionData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ServicesData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.LaboratoryData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.RadiologyData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.PrescriptionsData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ProceduresData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DentalData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.TheatreData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OpticalData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.MaternityData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ICUData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ConsumablesData()))
            invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ExtraChargeData()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Invoice Amount: " + GetSpaces(5))
            totalAmount.Append(FormatNumber(totalBillInvoice).PadLeft(padTotalAmount))
            totalAmount.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = NumberToWords(totalBillInvoice)
            amountWordsData.Append("(" + amountWords.Trim() + " ONLY)")
            amountWordsData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, amountWordsData.ToString()))

            Dim cashAccountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True)
            Dim cashAccountBalanceData As New System.Text.StringBuilder(String.Empty)
            cashAccountBalanceData.Append(ControlChars.NewLine)
            If cashAccountBalance < 0 Then
                cashAccountBalanceData.Append("Cash Account Balance (DR): ")
            Else : cashAccountBalanceData.Append("Cash Account Balance (CR): ")
            End If
            cashAccountBalanceData.Append(FormatNumber(cashAccountBalance, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            cashAccountBalanceData.Append(ControlChars.NewLine)

            Dim balanceDue As Decimal = totalBillInvoice - cashAccountBalance
            cashAccountBalanceData.Append("Balance Due: " + GetSpaces(14))
            cashAccountBalanceData.Append(FormatNumber(balanceDue, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            cashAccountBalanceData.Append(ControlChars.NewLine)

            If Not cashAccountBalance = 0 Then invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, cashAccountBalanceData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Patient's Sign:   " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:  " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function AdmissionData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyAdmissionEntries(False)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvAdmission.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvAdmission.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colAdmissionBedNo)
                Dim itemName As String = StringMayBeEnteredIn(cells, Me.colAdmissionBedName)
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colAdmissionQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colAdmissionUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colAdmissionAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colAdmissionEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colAdmissionNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ServicesData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyServicesEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvServices.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvServices.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colServiceCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _Services As EnumerableRowCollection(Of DataRow) = services.AsEnumerable()
                Dim itemName As String = (From data In _Services _
                                    Where data.Field(Of String)("ServiceCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("ServiceName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colServiceQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colServiceUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colServiceAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colServiceEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colServiceNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function LaboratoryData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyLaboratoryEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()

                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colTest))
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colLTQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colLTUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colLTAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colLTEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colLTNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RadiologyData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyRadiologyEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()

                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colExamFullName))
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colRadiologyQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colRadiologyUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colRadiologyAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colRadiologyEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colRadiologyNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function PrescriptionsData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim oVariousOptions As New VariousOptions()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyPrescriptionsEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oVariousOptions.HideBillFormDrugDetails AndAlso Me.dgvPrescription.RowCount > 1 Then

                Dim totalDrugAmount As Decimal = CalculateGridAmount(Me.dgvPrescription, Me.colDrugAmount)

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()

                Dim itemName As String = "Drug(s) "
                Dim quantity As String = (1).ToString()
                Dim unitPrice As String = FormatNumber(totalDrugAmount, AppData.DecimalPlaces)
                Dim amount As String = FormatNumber(totalDrugAmount, AppData.DecimalPlaces)
                Dim notes As String = String.Empty

                tableData.Append(itemNo.PadRight(padItemNo))
                tableData.Append(itemName.PadRight(padItemName))
                tableData.Append(notes.PadRight(padNotes))
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                totalBillInvoice += totalDrugAmount
            Else

                For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    itemCount += 1

                    Dim itemNo As String = (itemCount).ToString()

                    Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colDrug))
                    Dim quantity As String = StringMayBeEnteredIn(cells, Me.colDrugQuantity)
                    Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colDrugUnitPrice)
                    Dim amount As String = StringMayBeEnteredIn(cells, Me.colDrugAmount)
                    Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colDrugEntryMode)
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colDrugNotes)

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 19 Then
                        tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                        If notes.Length > 16 Then
                            tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                        Else : tableData.Append(notes.PadRight(padNotes))
                        End If
                    Else : tableData.Append(String.Empty.PadRight(padNotes))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                    If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

                Next

            End If

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ProceduresData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyProceduresEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colProcedureCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                Dim itemName As String = (From data In _Procedures _
                                    Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("ProcedureName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colProcedureQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colProcedureUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colProcedureAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colProcedureEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colProcedureNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function DentalData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyDentalEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colDentalCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _DentalServices As EnumerableRowCollection(Of DataRow) = dentalServices.AsEnumerable()
                Dim itemName As String = (From data In _DentalServices _
                                    Where data.Field(Of String)("DentalCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("DentalName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colDentalQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colDentalUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colDentalAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colDentalEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colDentalNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function TheatreData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyTheatreEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colTheatreCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _TheatreServices As EnumerableRowCollection(Of DataRow) = TheatreServices.AsEnumerable()
                Dim itemName As String = (From data In _TheatreServices _
                                    Where data.Field(Of String)("TheatreCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("TheatreName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colTheatreQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colTheatreUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colTheatreAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colTheatreEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colTheatreNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function OpticalData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyOpticalEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvOptical.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colOpticalCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _OpticalServices As EnumerableRowCollection(Of DataRow) = OpticalServices.AsEnumerable()
                Dim itemName As String = (From data In _OpticalServices _
                                    Where data.Field(Of String)("OpticalCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("OpticalName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colOpticalQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colOpticalUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colOpticalAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colOpticalEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colOpticalNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function MaternityData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyMaternityEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvMaternity.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvMaternity.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colMaternityCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _MaternityServices As EnumerableRowCollection(Of DataRow) = MaternityServices.AsEnumerable()
                Dim itemName As String = (From data In _MaternityServices _
                                    Where data.Field(Of String)("MaternityCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("MaternityName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colMaternityQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colMaternityUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colMaternityAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colMaternityEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colMaternityNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ICUData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyICUEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvICU.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvICU.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()
                Dim itemCode As String = StringMayBeEnteredIn(cells, Me.colICUCode)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim _ICUServices As EnumerableRowCollection(Of DataRow) = ICUServices.AsEnumerable()
                Dim itemName As String = (From data In _ICUServices _
                                    Where data.Field(Of String)("ICUCode").ToUpper().Equals(itemCode.ToUpper()) _
                                    Select data.Field(Of String)("ICUName")).First()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colICUQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colICUUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colICUAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colICUEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colICUNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ConsumablesData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyConsumablesEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()

                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colConsumableName))
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colConsumableQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colConsumableUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colConsumableAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colConsumableEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colConsumableNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ExtraChargeData() As String

        Try

            Dim result As Decimal
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyExtraChargeEntries()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells

                itemCount += 1

                Dim itemNo As String = (itemCount).ToString()

                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colExtraItemFullName))
                Dim quantity As String = StringMayBeEnteredIn(cells, Me.colExtraChargeQuantity)
                Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colExtraChargeUnitPrice)
                Dim amount As String = StringMayBeEnteredIn(cells, Me.colExtraChargeAmount)
                Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colExtraChargeEntryMode)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colExtraChargeNotes)

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 19 Then
                    tableData.Append(itemName.Substring(0, 19).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                    If notes.Length > 16 Then
                        tableData.Append(notes.Substring(0, 16).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If
                Else : tableData.Append(String.Empty.PadRight(padNotes))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

                If IsNumeric(amount) AndAlso Decimal.TryParse(amount, result) Then totalBillInvoice += result

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region " Popup Menu "

    Private Sub cmsExtraBills_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsExtraBills.Opening

        Select Case Me.tbcExtraBills.SelectedTab.Name

            Case Me.tpgServices.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Me.tpgLaboratory.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Me.tpgRadiology.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Me.tpgPrescriptions.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Me.tpgProcedures.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Me.tpgDental.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Me.tpgTheatre.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Me.tpgOptical.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Me.tpgMaternity.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Me.tpgICU.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Me.tpgConsumables.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Me.tpgExtraCharge.Name
                Me.cmsExtraBillsQuickSearch.Visible = True

            Case Else
                Me.cmsExtraBillsQuickSearch.Visible = False

        End Select

    End Sub

    Private Sub cmsExtraBillsQuickSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsExtraBillsQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rowIndex As Integer

            Select Case Me.tbcExtraBills.SelectedTab.Name

                Case Me.tpgServices.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("ExtraBillServices", Me.dgvServices, Me.colServiceCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvServices.NewRowIndex
                    If rowIndex > 0 Then Me.SetServicesEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgLaboratory.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("LabTests", Me.dgvLabTests, Me.colTest)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvLabTests.NewRowIndex
                    If rowIndex > 0 Then Me.SetLabTestsEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgRadiology.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("RadiologyExaminations", Me.dgvRadiology, Me.colExamFullName)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvRadiology.NewRowIndex
                    If rowIndex > 0 Then Me.SetRadiologyExaminationsEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgPrescriptions.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Drugs", Me.dgvPrescription, Me.colDrug)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvPrescription.NewRowIndex
                    If rowIndex > 0 Then Me.SetDrugsEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgProcedures.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Procedures", Me.dgvProcedures, Me.colProcedureCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvProcedures.NewRowIndex
                    If rowIndex > 0 Then Me.SetProceduresEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgDental.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("DentalServices", Me.dgvDental, Me.colDentalCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvDental.NewRowIndex
                    If rowIndex > 0 Then Me.SetDentalServiceEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgTheatre.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("TheatreServices", Me.dgvTheatre, Me.colTheatreCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvTheatre.NewRowIndex
                    If rowIndex > 0 Then Me.SetTheatreEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgOptical.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("OpticalServices", Me.dgvOptical, Me.colOpticalCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvOptical.NewRowIndex
                    If rowIndex > 0 Then Me.SetOpticalServiceEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgMaternity.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("MaternityServices", Me.dgvMaternity, Me.colMaternityCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvMaternity.NewRowIndex
                    If rowIndex > 0 Then Me.SetMaternityServiceEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgICU.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("ICUServices", Me.dgvICU, Me.colICUCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvICU.NewRowIndex
                    If rowIndex > 0 Then Me.SetICUServiceEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgConsumables.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("ConsumableItems", Me.dgvConsumables, Me.colConsumableName)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvConsumables.NewRowIndex
                    If rowIndex > 0 Then Me.SetConsumableEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgExtraCharge.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("ExtraChargeItems", Me.dgvExtraCharge, Me.colExtraItemFullName)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvExtraCharge.NewRowIndex
                    If rowIndex > 0 Then Me.SetExtraChargeEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

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

        Me.stbExtraBillNo.ReadOnly = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlBill)
        Me.ResetTabControls()
        ResetControlsIn(Me.pnlNavigateExtraBills)
        Me.EnableExtraBillsCTLS(False)
        Me.fbnViewFullInvoice.Enabled = False

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.stbExtraBillNo.ReadOnly = InitOptions.ExtraBillNoLocked

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlBill)
        Me.ResetTabControls()
        ResetControlsIn(Me.pnlNavigateExtraBills)
        Me.EnableExtraBillsCTLS(True)
        Me.fbnViewFullInvoice.Enabled = False
        Me.SetDefaultLocation()

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

    Private Sub EnableExtraBillsCTLS(ByVal state As Boolean)

        Me.stbVisitNo.Enabled = state
        Me.btnFindVisitNo.Enabled = state
        Me.btnLoadPeriodicVisits.Enabled = state
        Me.dtpExtraBillDate.Enabled = state
        ' Me.cboStaffNo.Enabled = state
        Me.chkPrintInvoiceOnSaving.Enabled = state
        Me.chkPrintInvoiceOnSaving.Checked = state
        Me.btnFindExtraBillNo.Enabled = Not state
        Me.pnlNavigateExtraBills.Enabled = Not state

    End Sub

#End Region

    Private Sub cboLocationID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboLocationID.SelectedIndexChanged
        Try

            Me.Cursor = Cursors.WaitCursor
             Select Me.tbcExtraBills.SelectedTab.Name
                Case Me.tpgConsumables.Name
                    Me.DetailConsumableLocationBalance()
                Case tpgPrescriptions.Name
                    Me.DetailDrugLocationBalance()
                Case tpgDental.Name
                    cboLocationID.Visible = False
                    cboLocationID.Enabled = False

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Public Sub LocationVisibility()
        Select Case Me.tbcExtraBills.SelectedTab.Name
            Case Me.tpgConsumables.Name
                cboLocationID.Visible = True
                lblLocationID.Visible = True
            Case tpgPrescriptions.Name
                cboLocationID.Visible = True
                lblLocationID.Visible = True
            Case Else
                cboLocationID.Visible = False
                lblLocationID.Visible = False


        End Select

    End Sub

    Private Sub LockItemsUnitPrices()
        Dim oVariousOptions As New VariousOptions()
        Dim unitPrice As DataGridViewColumn() = {colExtraChargeUnitPrice, colOpticalUnitPrice, colMaternityUnitPrice, colICUAmount, colConsumableUnitPrice, colServiceUnitPrice, colLTUnitPrice, colDrugUnitPrice, colRadiologyUnitPrice, colProcedureUnitPrice, colDentalUnitPrice, colTheatreUnitPrice}
        DisableGridComponets(unitPrice, oVariousOptions.LockItemsUnitPrices)

    End Sub
End Class