
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Lookup
Imports SyncSoft.Common.Classes
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects

Imports System.IO
Imports System.Collections.Generic

Public Class frmOptions

#Region " Fields "

    Private _Enable As String = "Enable"
    Private _Disable As String = "Disable"
    Private _OptionNameValue As String = String.Empty

#End Region

    Private Sub frmOptions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''
            LoadSpeaches()
            Me.LoadLookupData()
            Me.LoadAssociatedBillCustomers()
            Me.LoadAutoNumbers()
            Me.GetOptions()

            '''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnOK, AccessRights.Write)
            Security.Apply(Me.btnApply, AccessRights.Write)
            '''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoadLookupData()

        Dim oLookupData As New LookupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboLocation.Items.Clear()
            Me.cboVisitCategory.Items.Clear()
            Me.cboPharmacyPrinterPaperSize.Items.Clear()
            Me.cboCashierPrinterPaperSize.Items.Clear()
            Me.cboDefaultSelfRequestNo.Items.Clear()
            Me.clbIssueLocations.Items.Clear()
            Me.cboBranch.Items.Clear()
            Me.cboSMSNotificationPoint.Items.Clear()
            cboRoomID.Items.Clear()
            cboCommunityID.Items.Clear()
            cboServicePointQueue.Items.Clear()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load all from location lookupData
            Dim locationLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.Location).Tables("LookupData")

            If locationLookupData IsNot Nothing AndAlso locationLookupData.Rows.Count > 0 Then
                LoadComboData(Me.cboLocation, locationLookupData, "DataDes")
                Me.cboLocation.Items.Insert(0, String.Empty)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load all from Default PatientNos lookupData
            Dim defaultSelfRequestNo As DataTable = oLookupData.GetLookupData(LookupObjects.DefaultPatientNo).Tables("LookupData")

            If defaultSelfRequestNo IsNot Nothing AndAlso defaultSelfRequestNo.Rows.Count > 0 Then
                LoadComboData(Me.cboDefaultSelfRequestNo, defaultSelfRequestNo, "DataDes")
                Me.cboDefaultSelfRequestNo.Items.Insert(0, String.Empty)
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load all from visit category lookupData
            Dim visitCategoryLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.VisitCategory).Tables("LookupData")

            If visitCategoryLookupData IsNot Nothing AndAlso visitCategoryLookupData.Rows.Count > 0 Then
                LoadComboData(Me.cboVisitCategory, visitCategoryLookupData, "DataDes")
                Me.cboVisitCategory.Items.Insert(0, String.Empty)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load all from Printer Paper Size lookupData
            Dim printerPaperSizeLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.PrinterPaperSize).Tables("LookupData")

            If printerPaperSizeLookupData IsNot Nothing AndAlso printerPaperSizeLookupData.Rows.Count > 0 Then
                LoadComboData(Me.cboPharmacyPrinterPaperSize, printerPaperSizeLookupData, "DataDes")
                Me.cboPharmacyPrinterPaperSize.Items.Insert(0, String.Empty)
            End If
            If printerPaperSizeLookupData IsNot Nothing AndAlso printerPaperSizeLookupData.Rows.Count > 0 Then
                LoadComboData(Me.cboCashierPrinterPaperSize, printerPaperSizeLookupData, "DataDes")
                Me.cboCashierPrinterPaperSize.Items.Insert(0, String.Empty)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboPrintHeaderAlignmentID, LookupCommObjects.PrintHeaderAlignment, True)
            LoadLookupDataCombo(Me.cboPasswordComplexityID, LookupCommObjects.PasswordComplexity, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Load Locations for doctor issueing
           
            LoadLookupDataCombo(Me.clbIssueLocations, LookupObjects.Location, False)


            ' Load all from Branches lookupData
            Dim BranchLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.BranchID).Tables("LookupData")

            If BranchLookupData IsNot Nothing AndAlso BranchLookupData.Rows.Count > 0 Then
                LoadComboData(Me.cboBranch, BranchLookupData, "DataDes")
                Me.cboBranch.Items.Insert(0, String.Empty)
            End If

            ' Load all from YesNo lookupData
            Dim YesNoLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.YesNo).Tables("LookupData")

            If YesNoLookupData IsNot Nothing AndAlso YesNoLookupData.Rows.Count > 0 Then
                LoadComboData(Me.cboSMSNotificationPoint, YesNoLookupData, "DataDes")
                Me.cboSMSNotificationPoint.Items.Insert(0, String.Empty)
            End If

            ' Load all from Room Numbers lookupData
            Dim RoomNameLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.RoomName).Tables("LookupData")

            If RoomNameLookupData IsNot Nothing AndAlso RoomNameLookupData.Rows.Count > 0 Then
                LoadComboData(Me.cboRoomID, RoomNameLookupData, "DataDes")
                Me.cboRoomID.Items.Insert(0, String.Empty)
            End If

            ' Load all from ServicePoint lookupData
            Dim ServicePointLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.ServicePoint).Tables("LookupData")

            If ServicePointLookupData IsNot Nothing AndAlso ServicePointLookupData.Rows.Count > 0 Then
                LoadComboData(Me.cboServicePointQueue, ServicePointLookupData, "DataDes")
                Me.cboServicePointQueue.Items.Insert(0, String.Empty)
            End If

            ' Load Community
            Dim CommunityLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.Community).Tables("LookupData")
            If CommunityLookupData IsNot Nothing AndAlso CommunityLookupData.Rows.Count > 0 Then
                LoadComboData(Me.cboCommunityID, CommunityLookupData, "DataDes")
                Me.cboCommunityID.Items.Insert(0, String.Empty)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAssociatedBillCustomers()

        Dim oAssociatedBillCustomers As New SyncSoft.SQLDb.AssociatedBillCustomers()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim accountNo As String = GetLookupDataDes(oBillModesID.Cash).ToUpper()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboAssociatedBillNo.Items.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load all from AssociatedBillCustomers
            Dim associatedBillCustomers As DataTable = oAssociatedBillCustomers.GetAssociatedBillCustomers(accountNo).Tables("AssociatedBillCustomers")

            If associatedBillCustomers IsNot Nothing AndAlso associatedBillCustomers.Rows.Count > 0 Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                LoadComboData(Me.cboAssociatedBillNo, associatedBillCustomers, "AssociatedFullBillCustomer")
                Me.cboAssociatedBillNo.Items.Insert(0, String.Empty)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAutoNumbers()

        Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load items not yet paid for

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers().Tables("AutoNumbers")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvAutoNumbers, autoNumbers)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub UpdateAutoNumbers()

        Dim lAutoNumbers As New List(Of SyncSoft.Options.SQL.AutoNumbers)

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvAutoNumbers.RowCount < 1 Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvAutoNumbers.Rows.Count - 1

                Using oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

                    Dim cells As DataGridViewCellCollection = Me.dgvAutoNumbers.Rows(rowNo).Cells

                    With oAutoNumbers

                        .ObjectName = StringEnteredIn(cells, Me.colObjectName)
                        .AutoColumnName = StringEnteredIn(cells, Me.colAutoColumnName)
                        .AutoColumnLEN = IntegerEnteredIn(cells, Me.colAutoColumnLEN, "auto column lenght!")
                        .PaddingCHAR = StringEnteredIn(cells, Me.colPaddingCHAR, "padding character!")
                        .PaddingLEN = IntegerEnteredIn(cells, Me.colPaddingLEN, "padding lenght!")
                        .SeparatorCHAR = StringMayBeEnteredIn(cells, Me.colSeparatorCHAR)
                        .SeparatorPositions = StringMayBeEnteredIn(cells, Me.colSeparatorPositions)
                        .StartValue = IntegerEnteredIn(cells, Me.colStartValue, "start value!")
                        .Increment = IntegerEnteredIn(cells, Me.colIncrement, "increment!")
                        .AllowJumpTo = BooleanEnteredIn(cells, Me.colAllowJumpTo)
                        .JumpToValue = IntegerEnteredIn(cells, Me.colJumpToValue, "jump to value!")

                    End With

                    lAutoNumbers.Add(oAutoNumbers)

                End Using

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            UpdateAll(lAutoNumbers, True)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub GetOptions()

        Dim oVariousOptions As New VariousOptions()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(InitOptions.StartUpWindow) Then
                Me.cboStartUpWindow.Text = "Search"
            Else : Me.cboStartUpWindow.Text = InitOptions.StartUpWindow
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.GetCommVariousOptions()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If String.IsNullOrEmpty(InitOptions.BackupFolder) Then
                Me.lblBackup.Text = BackupFolder
            Else : Me.lblBackup.Text = InitOptions.BackupFolder.ToString()
            End If

            If String.IsNullOrEmpty(InitOptions.RestoreFolder) Then
                Me.lblRestore.Text = BackupFolder
            Else : Me.lblRestore.Text = InitOptions.RestoreFolder.ToString()
            End If

            If String.IsNullOrEmpty(InitOptions.SmartCardFolder) Then
                Me.lblSmartCardData.Text = "C:\TransferFiles"
            Else : Me.lblSmartCardData.Text = InitOptions.SmartCardFolder.ToString()
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With InitOptions

                Me.chkLoadBillCustomersAtStart.Checked = .LoadBillCustomersAtStart
                Me.chkLoadLabTestsAtStart.Checked = .LoadLabTestsAtStart
                Me.chkLoadRadiologyExaminationsAtStart.Checked = .LoadRadiologyExaminationsAtStart
                Me.chkLoadDrugsAtStart.Checked = .LoadDrugsAtStart
                Me.chkLoadConsumableItemsAtStart.Checked = .LoadConsumableItemsAtStart
                Me.chkLoadProceduresAtStart.Checked = .LoadProceduresAtStart
                Me.chkLoadDentalServicesAtStart.Checked = .LoadDentalServicesAtStart
                Me.chkLoadDiseasesAtStart.Checked = .LoadDiseasesAtStart
                Me.chkLoadPatientFingerprintsAtStart.Checked = .LoadPatientFingerprintsAtStart
                Me.chkForceVisitBillConfirmation.Checked = .ForceVisitBillConfirmation
                Me.chkPromptForExtraChargeRegistration.Checked = .PromptForExtraChargeRegistration
                Me.chkOpenPharmacyAfterCashier.Checked = .OpenPharmacyAfterCashier
                Me.chkOpenCashierAfterSelfRequest.Checked = .OpenCashierAfterSelfRequest
                Me.chkEnableChatNotification.Checked = .EnableChatNotification
                Me.chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest.Checked = .EnableOnlyPrescExtrasConsAtSelfRequest
                Me.ChkEnableViewCashCollections.Checked = .EnableViewCashCollections
                Me.chkForceFingerprintCapture.Checked = .ForceFingerprintCapture
                Me.cboVisitCategory.Text = .VisitCategory
                Me.cboLocation.Text = .Location
                Me.cboBranch.Text = .BranchName
                Me.cboSMSNotificationPoint.Text = .SMSNotificationPoint
                Me.cboAssociatedBillNo.Text = .AssociatedBillCustomer
                Me.cboPharmacyPrinterPaperSize.Text = .PharmacyPrinterPaperSize
                Me.cboCashierPrinterPaperSize.Text = .CashierPrinterPaperSize
                Me.cboDefaultSelfRequestNo.Text = .DefaultSelfRequestNo
                Me.clbIssueLocations.SelectedValue = .Location
                If oVariousOptions.DisableConstraints Then
                    Me.cboDisableConstraints.Text = Me._Disable
                Else : Me.cboDisableConstraints.Text = Me._Enable
                End If
                Me.lblDisableConstraints.Visible = oVariousOptions.DisableConstraints

                Me.nbxAlertCheckPeriod.Value = .AlertCheckPeriod.ToString()
                Me.chkAlertSoundOn.Checked = .AlertSoundOn
                Me.nbxUserIdleDuration.Value = .UserIdleDuration.ToString()

                Me.stbSearchCustomInsertCharacter.Text = .SearchCustomInsertCharacter
                Me.nbxSearchCustomInsertLength.Value = .SearchCustomInsertLength.ToString()
                Me.nbxSearchCustomInsertPosition.Value = .SearchCustomInsertPosition.ToString()

                Me.chkReceiptNoLocked.Checked = .ReceiptNoLocked
                Me.chkRefundNoLocked.Checked = .RefundNoLocked
                Me.chkQuotationNoLocked.Checked = .QuotationNoLocked
                Me.chkInvoiceNoLocked.Checked = .InvoiceNoLocked
                Me.chkTranNoLocked.Checked = .TranNoLocked
                Me.chkPatientNoLocked.Checked = .PatientNoLocked
                Me.chkAccountNoLocked.Checked = .AccountNoLocked
                Me.chkVisitNoLocked.Checked = .VisitNoLocked
                Me.chkSpecimenNoLocked.Checked = .SpecimenNoLocked
                Me.chkAdmissionNoLocked.Checked = .AdmissionNoLocked
                Me.chkRoundNoLocked.Checked = .RoundNoLocked
                Me.chkExpenditureNoLocked.Checked = .ExpenditureNoLocked
                Me.chkIncomeNoLocked.Checked = .IncomeNoLocked
                Me.chkInsuranceNoLocked.Checked = .InsuranceNoLocked
                Me.chkPolicyNoLocked.Checked = .PolicyNoLocked
                Me.chkCompanyNoLocked.Checked = .CompanyNoLocked
                Me.chkSupplierNoLocked.Checked = .SupplierNoLocked
                Me.chkClaimNoLocked.Checked = .ClaimNoLocked
                Me.chkExtraBillNoLocked.Checked = .ExtraBillNoLocked
                Me.chkOutwardNoLocked.Checked = .OutwardNoLocked
                Me.chkMedicalCardNoLocked.Checked = .MedicalCardNoLocked
                Me.chkMainMemberNoLocked.Checked = .MainMemberNoLocked
                Me.chkPurchaseOrderNoLocked.Checked = .PurchaseOrderNoLocked
                Me.chkGRNNoLocked.Checked = .GRNNoLocked
                Me.chkOrderNoLocked.Checked = .OrderNoLocked
                Me.chkTransferNoLocked.Checked = .TransferNoLocked
                Me.chkStaffNoLocked.Checked = .StaffNoLocked
                Me.chkDrugNoLocked.Checked = .DrugNoLocked
                Me.chkConsumableNoLocked.Checked = .ConsumableNoLocked

                Me.chkBedNoLocked.Checked = .BedNoLocked
                Me.chkExtraChargeItemCodeLocked.Checked = .ExtraChargeItemCodeLocked
                Me.chkPackageNoLocked.Checked = .PackageNoLocked
                Me.chkICUCodeLocked.Checked = .ICUCodeLocked
                Me.chkPathologyExamCodeLocked.Checked = .PathologyExamCodeLocked
                Me.chkMaternityCodeLocked.Checked = .MaternityCodeLocked
                Me.chkDentalCodeLocked.Checked = .DentalCodeLocked
                Me.chkNonMedicalItemCodeLocked.Checked = .NonMedicalItemCodeLocked
                Me.chkOpticalCodeLocked.Checked = .OpticalCodeLocked
                Me.chkProcedureCodeLocked.Checked = .ProcedureCodeLocked
                Me.chkRadiologyExamNoLocked.Checked = .RadiologyExamNoLocked
                Me.chkServiceCodeLocked.Checked = .ServiceCodeLocked
                Me.chkTestCodeLocked.Checked = .TestCodeLocked
                Me.chkEyeCodeLocked.Checked = .EyeCodeLocked
                Me.chkServiceCodeLocked.Checked = .ServiceCodeLocked
                Me.chkTheatreCodeLocked.Checked = .TheatreCodeLocked
                Me.chkCardiologyExamCode.Checked = .CardiologyExamCodeLocked
                Me.chkToBillServiceFeeLocked.Checked = .ToBillServiceFeeLocked
                Me.cboVoices.SelectedIndex = .Voice
                Me.cboRoomID.Text = .RoomName
                cboCommunityID.Text = .Community
                Me.cboServicePointQueue.Text = .ServicePointQueue

            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub GetCommVariousOptions()

        Dim oAppData As New AppData()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If IsDate(oAppData.NullDateValue) Then
                Dim _Day As String = CStr(oAppData.NullDateValue.Day).PadLeft(2, CChar("0"))
                Dim _Month As String = CStr(oAppData.NullDateValue.Month).PadLeft(2, CChar("0"))
                Dim _Year As String = CStr(oAppData.NullDateValue.Year)
                Me.mtbNullDateValue.Text = _Day + "/" + _Month + "/" + _Year
            Else : Me.mtbNullDateValue.Text = CStr(#1/1/1900#)
            End If

            Me.nudDecimalPlaces.Value = oAppData.DecimalPlaces
            Me.cboCurrency.Text = oAppData.Currency
            Me.cboPasswordComplexityID.SelectedValue = oAppData.PasswordComplexity
            Me.chkEnableAuditTrail.Checked = oAppData.EnableAuditTrail

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetOptions()

        Dim startUpWindow As String
        Dim _BackupFolder As String
        Dim _RestoreFolder As String
        Dim _SmartCardFolder As String

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.cboStartUpWindow.Text.Trim().Length = 0 Then
                startUpWindow = "Search"
            Else : startUpWindow = Me.cboStartUpWindow.Text.Trim()
            End If

            If Me.lblBackup.Text.Trim().Length = 0 Then
                _BackupFolder = BackupFolder
            Else : _BackupFolder = Me.lblBackup.Text.Trim()
            End If

            If Me.lblRestore.Text.Trim().Length = 0 Then
                _RestoreFolder = BackupFolder
            Else : _RestoreFolder = Me.lblRestore.Text.Trim()
            End If

            If Me.lblSmartCardData.Text.Trim().Length = 0 Then
                _SmartCardFolder = "C:\TransferFiles"
            Else : _SmartCardFolder = Me.lblSmartCardData.Text.Trim()
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ValidateEntriesIn(Me.tpgGeneral)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With InitOptions

                .StartUpWindow = startUpWindow
                .AlertCheckPeriod = IntegerEnteredIn(Me.nbxAlertCheckPeriod, "Alert Check Period!")
                .AlertSoundOn = Me.chkAlertSoundOn.Checked
                .UserIdleDuration = IntegerEnteredIn(Me.nbxUserIdleDuration, "User Idle Duration!")
                If String.IsNullOrEmpty(Me.stbSearchCustomInsertCharacter.Text) Then
                    .SearchCustomInsertCharacter = " "c
                Else : .SearchCustomInsertCharacter = CChar(Me.stbSearchCustomInsertCharacter.Text)
                End If
                .SearchCustomInsertLength = IntegerEnteredIn(Me.nbxSearchCustomInsertLength, "Search Custom Insert Length!")
                .SearchCustomInsertPosition = IntegerEnteredIn(Me.nbxSearchCustomInsertPosition, "Search Custom Insert Position!")

                .LoadBillCustomersAtStart = Me.chkLoadBillCustomersAtStart.Checked
                .LoadLabTestsAtStart = Me.chkLoadLabTestsAtStart.Checked
                .LoadRadiologyExaminationsAtStart = Me.chkLoadRadiologyExaminationsAtStart.Checked
                .LoadDrugsAtStart = Me.chkLoadDrugsAtStart.Checked
                .LoadConsumableItemsAtStart = Me.chkLoadConsumableItemsAtStart.Checked
                .LoadProceduresAtStart = Me.chkLoadProceduresAtStart.Checked
                .LoadDentalServicesAtStart = Me.chkLoadDentalServicesAtStart.Checked
                .LoadDiseasesAtStart = Me.chkLoadDiseasesAtStart.Checked
                .LoadPatientFingerprintsAtStart = Me.chkLoadPatientFingerprintsAtStart.Checked
                .ForceVisitBillConfirmation = Me.chkForceVisitBillConfirmation.Checked
                .PromptForExtraChargeRegistration = Me.chkPromptForExtraChargeRegistration.Checked
                .OpenPharmacyAfterCashier = Me.chkOpenPharmacyAfterCashier.Checked
                .EnableChatNotification = Me.chkEnableChatNotification.Checked
                .EnableViewCashCollections = Me.ChkEnableViewCashCollections.Checked
                .EnableOnlyPrescExtrasConsAtSelfRequest = Me.chkEnableOnlyPrescriptionExtrasConsumablesAtSelfRequest.Checked
                .OpenCashierAfterSelfRequest = Me.chkOpenCashierAfterSelfRequest.Checked
                .ForceFingerprintCapture = Me.chkForceFingerprintCapture.Checked
                .VisitCategory = StringMayBeEnteredIn(Me.cboVisitCategory)
                .Location = StringMayBeEnteredIn(Me.cboLocation)
                .BranchName = StringMayBeEnteredIn(Me.cboBranch)
                .SMSNotificationPoint = StringMayBeEnteredIn(cboSMSNotificationPoint)
                .DefaultSelfRequestNo = StringMayBeEnteredIn(Me.cboDefaultSelfRequestNo)
                .DoctorIssueLocations = StringToSplitSelectedIn(Me.clbIssueLocations, LookupObjects.Location)
                .AssociatedBillCustomer = StringMayBeEnteredIn(Me.cboAssociatedBillNo)
                .PharmacyPrinterPaperSize = StringMayBeEnteredIn(Me.cboPharmacyPrinterPaperSize)
                .CashierPrinterPaperSize = StringMayBeEnteredIn(Me.cboCashierPrinterPaperSize)
                .BackupFolder = _BackupFolder
                .RestoreFolder = _RestoreFolder
                .SmartCardFolder = _SmartCardFolder

                .ReceiptNoLocked = Me.chkReceiptNoLocked.Checked
                .RefundNoLocked = Me.chkRefundNoLocked.Checked
                .QuotationNoLocked = Me.chkQuotationNoLocked.Checked
                .InvoiceNoLocked = Me.chkInvoiceNoLocked.Checked
                .TranNoLocked = Me.chkTranNoLocked.Checked
                .PatientNoLocked = Me.chkPatientNoLocked.Checked
                .AccountNoLocked = Me.chkAccountNoLocked.Checked
                .VisitNoLocked = Me.chkVisitNoLocked.Checked
                .SpecimenNoLocked = Me.chkSpecimenNoLocked.Checked
                .AdmissionNoLocked = Me.chkAdmissionNoLocked.Checked
                .RoundNoLocked = Me.chkRoundNoLocked.Checked
                .ExpenditureNoLocked = Me.chkExpenditureNoLocked.Checked
                .IncomeNoLocked = Me.chkIncomeNoLocked.Checked
                .InsuranceNoLocked = Me.chkInsuranceNoLocked.Checked
                .PolicyNoLocked = Me.chkPolicyNoLocked.Checked
                .CompanyNoLocked = Me.chkCompanyNoLocked.Checked
                .SupplierNoLocked = Me.chkSupplierNoLocked.Checked
                .ClaimNoLocked = Me.chkClaimNoLocked.Checked
                .ExtraBillNoLocked = Me.chkExtraBillNoLocked.Checked
                .OutwardNoLocked = Me.chkOutwardNoLocked.Checked
                .MedicalCardNoLocked = Me.chkMedicalCardNoLocked.Checked
                .MainMemberNoLocked = Me.chkMainMemberNoLocked.Checked
                .PurchaseOrderNoLocked = Me.chkPurchaseOrderNoLocked.Checked
                .GRNNoLocked = Me.chkGRNNoLocked.Checked
                .OrderNoLocked = Me.chkOrderNoLocked.Checked
                .TransferNoLocked = Me.chkTransferNoLocked.Checked
                .StaffNoLocked = Me.chkStaffNoLocked.Checked
                .DrugNoLocked = Me.chkDrugNoLocked.Checked
                .ConsumableNoLocked = Me.chkConsumableNoLocked.Checked

                .BedNoLocked = Me.chkBedNoLocked.Checked
                .ExtraChargeItemCodeLocked = Me.chkExtraChargeItemCodeLocked.Checked
                .PackageNoLocked = Me.chkPackageNoLocked.Checked
                .ICUCodeLocked = chkICUCodeLocked.Checked
                .PathologyExamCodeLocked = chkPathologyExamCodeLocked.Checked
                .MaternityCodeLocked = chkMaternityCodeLocked.Checked
                .DentalCodeLocked = chkDentalCodeLocked.Checked
                .NonMedicalItemCodeLocked = chkNonMedicalItemCodeLocked.Checked
                .OpticalCodeLocked = chkOpticalCodeLocked.Checked
                .ProcedureCodeLocked = chkProcedureCodeLocked.Checked
                .RadiologyExamNoLocked = chkRadiologyExamNoLocked.Checked
                .ServiceCodeLocked = chkServiceCodeLocked.Checked
                .TestCodeLocked = chkTestCodeLocked.Checked
                .EyeCodeLocked = chkEyeCodeLocked.Checked
                .ServiceCodeLocked = chkServiceCodeLocked.Checked
                .TheatreCodeLocked = chkTheatreCodeLocked.Checked
                .CardiologyExamCodeLocked = Me.chkCardiologyExamCode.Checked
                .ToBillServiceFeeLocked = Me.chkToBillServiceFeeLocked.Checked
                .Voice = Me.cboVoices.SelectedIndex
                .RoomName = StringMayBeEnteredIn(Me.cboRoomID)
                .ServicePointQueue = StringMayBeEnteredIn(Me.cboServicePointQueue)
                .Community = StringMayBeEnteredIn(Me.cboCommunityID)


            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetAppData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.EditOptions()

            Me.UpdateAutoNumbers()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetAppData()

        Dim oAppData As New AppData()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With InitOptions
                AppData.SearchCustomInsertCharacter = .SearchCustomInsertCharacter
                AppData.SearchCustomInsertLength = .SearchCustomInsertLength
                AppData.SearchCustomInsertPosition = .SearchCustomInsertPosition

            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try


    End Sub


    Private Sub EditOptions()

        Dim oSearchDataTypeID As New LookupCommDataID.SearchDataTypeID()
        Dim oAppData As New AppData()

        Try
            Me.Cursor = Cursors.WaitCursor

            Using oOptions As New SyncSoft.Options.SQL.Options()

                Dim optionName As String = "PasswordComplexity"
                Dim optionValue As String = StringValueEnteredIn(Me.cboPasswordComplexityID, "Password Complexity!")
                Dim dataTypeID As String = oSearchDataTypeID.String.ToString()
                Dim maxLength As Short = 10

                With oOptions
                    .OptionName = optionName
                    .OptionValue = optionValue
                    .DataTypeID = dataTypeID
                    .MaxLength = maxLength
                    .Hidden = True
                End With

                oOptions.Save()

            End Using

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With AppData

                .NullDateValue = GetNullDateValue()
                .DecimalPlaces = GetDecimalPlaces()
                .Currency = GetCurrency()
                .PasswordComplexity = GetPasswordComplexity()
                .EnableAuditTrail = GetEnableAuditTrail()

            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.SetOptions()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcOptions.SelectedTab.Name

                Case Me.tpgGeneral.Name, Me.tpgSetupData.Name, Me.tpgAutoNumbers.Name, Me.tpgAutoNumberControls.Name
                    Me.SetOptions()
                    Me.Close()

                Case Me.tpgProductOwnerInfo.Name
                    Me.SaveProductOwnerInfo()

                Case Me.tpgOtherVariousOptions.Name
                    Me.SaveOptions()

                Case Me.tpgSearchObjects.Name
                    Me.SaveSearchObjects()

                Case Else
                    Me.SetOptions()
                    Me.Close()

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnChangeBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeBackup.Click

        Dim dlgFolder As New FolderBrowserDialog()

        Try
            Me.Cursor = Cursors.WaitCursor

            dlgFolder.ShowNewFolderButton = True

            If dlgFolder.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Me.lblBackup.Text = dlgFolder.SelectedPath.ToString()
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnChangeRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeRestore.Click

        Dim dlgFolder As New FolderBrowserDialog()

        Try
            Me.Cursor = Cursors.WaitCursor

            dlgFolder.ShowNewFolderButton = False

            If dlgFolder.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Me.lblRestore.Text = dlgFolder.SelectedPath.ToString()
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim constraints As String = StringEnteredIn(Me.cboDisableConstraints, "Constraints!")

            If Me.cboDisableConstraints.Text.ToString().Equals(Me._Disable) Then
                Dim message As String = "Disabling data rules will make your data vulnerable to accidental deletions/updates." + ControlChars.NewLine +
                                        "It’s recommended that you enable these rules after you’re done with deletions/updates." +
                                         ControlChars.NewLine + "Are you sure you want to disable data rules?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oSearchDataTypeID As New LookupCommDataID.SearchDataTypeID()
            Dim optionValue As String

            If constraints.Equals(Me._Disable) Then
                optionValue = (1).ToString()
            Else : optionValue = (0).ToString()
            End If

            Me.lblDisableConstraints.Visible = constraints.Equals(Me._Disable)

            Using oOptions As New SyncSoft.Options.SQL.Options()

                With oOptions
                    .OptionName = "DisableConstraints"
                    .OptionValue = optionValue
                    .DataTypeID = oSearchDataTypeID.Boolean
                    .MaxLength = 1
                    .Hidden = True
                End With

                oOptions.Save()

            End Using

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim scriptList As New List(Of String)
            Dim oTasks As New SyncSoft.Common.SQL.Classes.Tasks()

            If constraints.Equals(Me._Enable) Then
                With scriptList
                    .Add(My.Resources.EnableConstraints.ToString() + ControlChars.NewLine)
                    .Add(My.Resources.Utilities.ToString() + ControlChars.NewLine)
                End With
            ElseIf constraints.Equals(Me._Disable) Then
                With scriptList
                    .Add(My.Resources.DisableConstraints.ToString() + ControlChars.NewLine)
                End With
            End If

            Dim errorLog As String = oTasks.RunScripts(scriptList)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If errorLog.Trim().Length > 0 Then

                If WarningMessage("Would you like to open manage constraints log") = DialogResult.No Then Return

                Dim processLogFile As String = My.Computer.FileSystem.SpecialDirectories.Temp + "\Manage Constraints Log.txt"
                File.WriteAllText(processLogFile, errorLog)

                If File.Exists(processLogFile) Then
                    Process.Start(processLogFile)
                Else : DisplayMessage("No Manage Constraints Message Logged!")
                End If

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSmartCardData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSmartCardData.Click

        Dim dlgFolder As New FolderBrowserDialog()

        Try
            Me.Cursor = Cursors.WaitCursor

            dlgFolder.ShowNewFolderButton = False

            If dlgFolder.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Me.lblSmartCardData.Text = dlgFolder.SelectedPath.ToString()
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tbcOptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcOptions.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcOptions.SelectedTab.Name

                Case Me.tpgGeneral.Name, Me.tpgSetupData.Name
                    Me.btnOK.Text = "&OK"
                    Me.btnApply.Visible = True

                    ''''''''''''''''''''''''''''''''''''''''''
                    Me.GetCommVariousOptions()
                    ''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgAutoNumbers.Name, Me.tpgAutoNumberControls.Name
                    Me.btnOK.Text = "&OK"
                    Me.btnApply.Visible = True

                Case Me.tpgProductOwnerInfo.Name
                    Me.LoadProductOwnerInfo()
                    Me.btnOK.Text = "&Save"
                    Me.btnApply.Visible = False

                Case Me.tpgOtherVariousOptions.Name
                    Me.LoadOptions()
                    Me.btnOK.Text = "&Save"
                    Me.btnApply.Visible = False

                Case Me.tpgSearchObjects.Name
                    Me.LoadSearchObjects()
                    Me.btnOK.Text = "&Save"
                    Me.btnApply.Visible = False

                Case Else
                    Me.btnOK.Text = "&OK"
                    Me.btnApply.Visible = True

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPhoto.Click
        Me.spbPhoto.LoadPhoto(Me.spbPhoto.ImageSizeLimit)
    End Sub

    Private Sub btnClearPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPhoto.Click
        Me.spbPhoto.DeletePhoto()
    End Sub

    Private Sub btnLoadAlternatePhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadAlternatePhoto.Click
        Me.spbAlternatePhoto.LoadPhoto(Me.spbAlternatePhoto.ImageSizeLimit)
    End Sub

    Private Sub btnClearAlternatePhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearAlternatePhoto.Click
        Me.spbAlternatePhoto.DeletePhoto()
    End Sub

    Private Sub cboPrintHeaderAlignmentID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPrintHeaderAlignmentID.SelectedIndexChanged

        Try

            Dim oPrintHeaderAlignmentID As New LookupCommDataID.PrintHeaderAlignmentID()
            Dim printHeaderAlignmentID As String = StringValueMayBeEnteredIn(Me.cboPrintHeaderAlignmentID, "Print Header Alignment!")

            If String.IsNullOrEmpty(printHeaderAlignmentID) Then Return

            If printHeaderAlignmentID.ToUpper().Equals(oPrintHeaderAlignmentID.LogoLeftTextRight.ToUpper()) Then
                Me.nudLogoLeftMargin.Value = 4
                Me.nudTextLeftMargin.Value = 14

            ElseIf printHeaderAlignmentID.ToUpper().Equals(oPrintHeaderAlignmentID.LogoRightTextLeft.ToUpper()) Then
                Me.nudLogoLeftMargin.Value = 18
                Me.nudTextLeftMargin.Value = 4

            Else
                Me.nudLogoLeftMargin.Value = 1
                Me.nudTextLeftMargin.Value = 1

            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub SaveProductOwnerInfo()

        Dim oProductOwnerInfo As New SyncSoft.Options.SQL.ProductOwnerInfo()

        Try
            Me.Cursor = Cursors.WaitCursor

            With oProductOwnerInfo

                .ProductOwner = StringEnteredIn(Me.stbProductOwner, "Product Owner!")
                .Address = StringMayBeEnteredIn(Me.stbAddress)
                .Phone = StringMayBeEnteredIn(Me.stbPhone)
                .AlternatePhone = StringMayBeEnteredIn(Me.stbAlternatePhone)
                .Fax = StringMayBeEnteredIn(Me.stbFax)
                .Email = StringMayBeEnteredIn(Me.stbEmail)
                .AlternateEmail = StringMayBeEnteredIn(Me.stbAlternateEmail)
                .Website = StringMayBeEnteredIn(Me.stbWebsite)
                .Photo = BytesMayBeEnteredIn(Me.spbPhoto)
                .AlternatePhoto = BytesMayBeEnteredIn(Me.spbAlternatePhoto)
                .TINNo = StringMayBeEnteredIn(Me.stbTINNo)
                .VATNo = StringMayBeEnteredIn(Me.stbVATNo)
                .PrintHeaderAlignmentID = StringValueEnteredIn(Me.cboPrintHeaderAlignmentID, "Print Header Alignment!")
                .LogoTopMargin = CInt(Me.nudLogoTopMargin.Value)
                .TextTopMargin = CInt(Me.nudTextTopMargin.Value)
                .LogoLeftMargin = CInt(Me.nudLogoLeftMargin.Value)
                .TextLeftMargin = CInt(Me.nudTextLeftMargin.Value)
                .ProductVersion = AppData.Version
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me.tpgProductOwnerInfo)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .Save()

                Dim saveMSG As String = "Product owner info successfully saved!"
                MessageBox.Show(saveMSG, AppData.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadProductOwnerInfo()

        Dim oProductOwnerInfo As New SyncSoft.Options.SQL.ProductOwnerInfo()

        Try

            Me.Cursor = Cursors.WaitCursor()

            Me.stbProductOwner.Text = AppData.ProductOwner

            Dim productOwner As String = StringEnteredIn(Me.stbProductOwner, "Product Owner!")
            Dim productOwnerInfo As DataTable = oProductOwnerInfo.GetProductOwnerInfo(productOwner).Tables("ProductOwnerInfo")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim ownerInfo As EnumerableRowCollection(Of DataRow) = productOwnerInfo.AsEnumerable()

            Me.stbAddress.Text = (From owner In ownerInfo Select owner.Field(Of String)("Address")).First()
            Me.stbPhone.Text = (From owner In ownerInfo Select owner.Field(Of String)("Phone")).First()
            Me.stbAlternatePhone.Text = (From owner In ownerInfo Select owner.Field(Of String)("AlternatePhone")).First()
            Me.stbFax.Text = (From owner In ownerInfo Select owner.Field(Of String)("Fax")).First()
            Me.stbEmail.Text = (From owner In ownerInfo Select owner.Field(Of String)("Email")).First()
            Me.stbAlternateEmail.Text = (From owner In ownerInfo Select owner.Field(Of String)("AlternateEmail")).First()
            Me.stbWebsite.Text = (From owner In ownerInfo Select owner.Field(Of String)("Website")).First()
            Me.spbPhoto.Image = GetImage((From owner In ownerInfo Select owner.Field(Of Byte())("Photo")).First())
            Me.spbAlternatePhoto.Image = GetImage((From owner In ownerInfo Select owner.Field(Of Byte())("AlternatePhoto")).First())
            Me.stbTINNo.Text = (From owner In ownerInfo Select owner.Field(Of String)("TINNo")).First()
            Me.stbVATNo.Text = (From owner In ownerInfo Select owner.Field(Of String)("VATNo")).First()
            Me.cboPrintHeaderAlignmentID.SelectedValue = (From owner In ownerInfo Select owner.Field(Of String)("PrintHeaderAlignmentID")).First()
            Me.nudLogoTopMargin.Value = (From owner In ownerInfo Select owner.Field(Of Byte)("LogoTopMargin")).First()
            Me.nudTextTopMargin.Value = (From owner In ownerInfo Select owner.Field(Of Byte)("TextTopMargin")).First()
            Me.nudLogoLeftMargin.Value = (From owner In ownerInfo Select owner.Field(Of Byte)("LogoLeftMargin")).First()
            Me.nudTextLeftMargin.Value = (From owner In ownerInfo Select owner.Field(Of Byte)("TextLeftMargin")).First()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub SaveOptions()

        Dim oSearchDataTypeID As New LookupCommDataID.SearchDataTypeID()
        Dim lOptions As New List(Of DBConnect)
        Dim oAppData As New AppData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvOptions.RowCount < 1 Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvOptions.RowCount - 1

                Using oOptions As New SyncSoft.Options.SQL.Options()

                    Dim cells As DataGridViewCellCollection = Me.dgvOptions.Rows(rowNo).Cells

                    Dim optionName As String = StringEnteredIn(cells, Me.colOptionName, "Option Name!")
                    Dim optionValue As String = StringEnteredIn(cells, Me.colOptionValue, "Option Value!")
                    Dim dataTypeID As String = StringEnteredIn(cells, Me.colDataTypeID, "Data Type!")
                    Dim maxLength As Short = ShortEnteredIn(cells, Me.colMaxLength)

                    Select Case dataTypeID
                        Case oSearchDataTypeID.DateTime
                            If Not IsDate(optionValue) Then
                                Throw New ArgumentException(optionName + " value's data type is invalid!")
                            End If

                        Case oSearchDataTypeID.Number, oSearchDataTypeID.Money, oSearchDataTypeID.Decimal, oSearchDataTypeID.Boolean
                            If Not IsNumeric(optionValue) Then
                                Throw New ArgumentException(optionName + " value's data type is invalid!")
                            End If
                        Case Else
                    End Select

                    If optionValue.Length > maxLength Then
                        Throw New ArgumentException(optionName + " value's length is more than maximum allowed length!")
                    End If

                    With oOptions
                        .OptionName = optionName
                        .OptionValue = optionValue
                        .DataTypeID = dataTypeID
                        .MaxLength = maxLength
                    End With

                    lOptions.Add(oOptions)


                End Using

            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            SaveAll(lOptions, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With AppData

                .NullDateValue = GetNullDateValue()
                .DecimalPlaces = GetDecimalPlaces()
                .Currency = GetCurrency()
                .PasswordComplexity = GetPasswordComplexity()
                .EnableAuditTrail = GetEnableAuditTrail()

            End With
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadSearchObjects()

        Dim oSearchObjects As New SyncSoft.Search.SQL.SearchObjects()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load items not yet paid for

            Dim searchObjects As DataTable = oSearchObjects.GetSearchObjects().Tables("SearchObjects")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvSearchObjects, searchObjects)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveSearchObjects()

        Dim lSearchObjects As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvSearchObjects.RowCount < 1 Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvSearchObjects.RowCount - 1

                Using oSearchObjects As New SyncSoft.Search.SQL.SearchObjects()

                    Dim cells As DataGridViewCellCollection = Me.dgvSearchObjects.Rows(rowNo).Cells

                    With oSearchObjects
                        .ObjectName = StringEnteredIn(cells, Me.colSearchObjectsObjectName, "Object Name!")
                        .SearhInclude = BooleanEnteredIn(cells, Me.colSearhInclude, "Searh Include!")
                    End With

                    lSearchObjects.Add(oSearchObjects)

                End Using

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            UpdateAll(lSearchObjects, True)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Options - Grid "

    Private Sub dgvOptions_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvOptions.CellBeginEdit

        If e.ColumnIndex <> Me.colOptionName.Index OrElse Me.dgvOptions.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvOptions.CurrentCell.RowIndex
        _OptionNameValue = StringMayBeEnteredIn(Me.dgvOptions.Rows(selectedRow).Cells, Me.colOptionName)

    End Sub

    Private Sub dgvOptions_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOptions.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colOptionName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvOptions.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvOptions.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvOptions.Rows(selectedRow).Cells, Me.colOptionName)

                    If CBool(Me.dgvOptions.Item(Me.colOptionsSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Option Name (" + _OptionNameValue + ") can't be edited!")
                        Me.dgvOptions.Item(Me.colOptionName.Name, selectedRow).Value = _OptionNameValue
                        Me.dgvOptions.Item(Me.colOptionName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvOptions.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvOptions.Rows(rowNo).Cells, Me.colOptionName)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                DisplayMessage("Option Name (" + enteredItem + ") already entered!")
                                Me.dgvOptions.Item(Me.colOptionName.Name, selectedRow).Value = _OptionNameValue
                                Me.dgvOptions.Item(Me.colOptionName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub LoadOptions()

        Dim oOptions As New SyncSoft.Options.SQL.Options()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.colDataTypeID, LookupCommObjects.SearchDataType, False)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load Options
            Dim options As DataTable = oOptions.GetOptions().Tables("Options")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOptions, options)

            For Each row As DataGridViewRow In Me.dgvOptions.Rows
                If row.IsNewRow Then Exit For
                Me.dgvOptions.Item(Me.colOptionsSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region


    Private Sub LoadSpeaches()

        Dim speachVoices As New SpeechLib.SpVoice
        Dim arrVoices As SpeechLib.ISpeechObjectTokens = speachVoices.GetVoices
        Dim arrLst As New ArrayList
        For i As Integer = 0 To arrVoices.Count - 1
            arrLst.Add(arrVoices.Item(i).GetDescription)
        Next
        cboVoices.DataSource = arrLst
    End Sub

End Class

