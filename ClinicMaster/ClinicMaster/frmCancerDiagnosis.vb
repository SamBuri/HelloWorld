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
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona

Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona

Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Drawing.Printing
Imports System.Collections.Generic


Public Class frmCancerDiagnosis

#Region " Fields "
    Private defaultVisitNo As String = String.Empty
    Private doctorFullName As String = String.Empty

    Private diseases As DataTable
    Private currentAllSaved As Boolean = True
    Private currentVisitNo As String = String.Empty

    Private visitStatus As String = String.Empty
    Private visitStandardFee As Decimal = 0
    Private visitServiceCode As String = String.Empty
    Private visitServiceName As String = String.Empty

    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

    Private doctorLoginID As String = String.Empty
    Private staffFullName As String = String.Empty
    Private _DiagnosisValue As String = String.Empty
    Private accessCashServices As Boolean = False
    Private servicePayStatusID As String = String.Empty
    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty
    Private oItemStatusID As New LookupDataID.ItemStatusID()
    Private oPayStatusID As New LookupDataID.PayStatusID()

    Private tipBillServiceFeeWords As New ToolTip()
    Private tipOutstandingBalanceWords As New ToolTip()
    Private tipCoPayValueWords As New ToolTip()
    Private WithEvents docDoctor As New PrintDocument()
    ' The paragraphs.
    Private padLineNo As Integer = 6
    Private padService As Integer = 44
    Private padNotes As Integer = 20

    Private title As String
    Private doctorParagraphs As Collection
    Private medicalReportParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private billCustomerName As String = String.Empty
#End Region

#Region " Visits Navigate "

    Private Sub EnableNavigateVisitsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                Dim visits As DataTable = oVisits.GetVisitsByPatientNo(patientNo).Tables("Visits")

                For pos As Integer = 0 To visits.Rows.Count - 1
                    If visitNo.ToUpper().Equals(visits.Rows(pos).Item("VisitNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navVisits.DataSource = visits
                Me.navVisits.Navigate(startPosition)

            Else : Me.navVisits.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateVisits.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateVisits_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateVisits.Click
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.AllSaved() Then
            Me.chkNavigateVisits.Checked = Not Me.chkNavigateVisits.Checked
            Return
        End If

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateVisitsCTLS(Me.chkNavigateVisits.Checked)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navVisits.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadVisitsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub frmCancerDiagnosis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.ClearControls()
            Me.LoadStaff()
            Me.LoadTopologySites()
            Me.LoadCancerDiseases()
            Me.LoadServices()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.ColBasisOfDiagnosis, LookupObjects.BasisOfDiagnosis, False)
            LoadLookupDataCombo(Me.ColCancerStage, LookupObjects.StageOfCancer, True)
            'LoadLookupDataCombo(Me.Colt, LookupObjects.StageOfCancer, True)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultVisitNo) Then

                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.stbVisitNo.ReadOnly = True
                Me.cboStaffNo.Text = doctorFullName
                Me.ProcessTabKey(True)
                Me.LoadVisitsData(defaultVisitNo)

            Else : Me.stbVisitNo.ReadOnly = False
            End If
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub LoadCancerDiseases()

        Dim oDiseases As New SyncSoft.SQLDb.CancerDiseases()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Diseases
            diseases = oDiseases.GetCancerDiseases().Tables("CancerDiseases")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDiseaseCode.Sorted = False
            LoadComboData(Me.colDiseaseCode, diseases, "DiseaseNo", "DiseaseName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function AllSaved() As Boolean

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim message As String = "Please ensure that all items are saved on "
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return True

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           

            For Each row As DataGridViewRow In Me.dgvCancerDiagnosis.Rows
                If row.IsNewRow Then Exit For
                If Not BooleanMayBeEnteredIn(row.Cells, Me.colDiagnosisSaved) Then
                    DisplayMessage(message + Me.tpgDiagnosis.Text)
                    If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                    Return False
                End If
            Next


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return True

        End Try

    End Function

    Private Sub LoadDoctorVisit(ByVal visitNo As String)

        Dim oVariousOptions As New VariousOptions()
        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Dim oServiceBillAtID As New LookupDataID.ServiceBillAtID()

        Try

            Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()

            If oDoctorVisits.GetDoctorVisit(visitNo) Then
                Me.cboStaffNo.Text = oDoctorVisits.StaffFullName
                Me.cboStaffNo.Enabled = False
                If Not String.IsNullOrEmpty(oDoctorVisits.ServiceCode) Then
                    Me.cboServiceCode.SelectedValue = oDoctorVisits.ServiceCode
                    Me.cboServiceCode.Enabled = False
                Else : Me.cboServiceCode.Enabled = True
                End If
                   Else
                Me.cboStaffNo.SelectedIndex = -1
                Me.cboStaffNo.SelectedIndex = -1
                Me.cboStaffNo.Text = staffFullName
                Me.cboStaffNo.Enabled = True

                Me.cboServiceCode.SelectedIndex = -1
                Me.cboServiceCode.SelectedIndex = -1
                Me.cboServiceCode.SelectedValue = visitServiceCode
                Me.cboServiceCode.Enabled = True

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim cashAccountNo As String = GetLookupDataDes(oBillModesID.Cash)
                Dim services As DataTable = oServices.GetServices(visitServiceCode).Tables("Services")
                Dim serviceName As String = services.Rows(0).Item("ServiceName").ToString()
                Dim serviceBillAtID As String = services.Rows(0).Item("ServiceBillAtID").ToString()

                If serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Doctor.ToUpper()) AndAlso
                    Not visitServiceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) AndAlso
                    Me.stbBillMode.Text.ToUpper().Equals(cashAccountNo.ToUpper()) AndAlso
                    servicePayStatusID.ToUpper().Equals(oPayStatusID.NotPaid.ToUpper()) AndAlso
                    oVariousOptions.AllowAccessCashServices.Equals(False) AndAlso
                    accessCashServices.Equals(False) AndAlso visitStandardFee > 0 Then
                    Throw New ArgumentException("This visit is set not to access cash service before payment. Please check with cashier.")
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Function SaveDoctorVisits() As Boolean

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim message As String

        Dim oDoctorVisits As New SyncSoft.SQLDb.DoctorVisits()
        Dim oServices As New SyncSoft.SQLDb.Services()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()

        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Dim oServiceBillAtID As New LookupDataID.ServiceBillAtID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oVisitStatusID As New LookupDataID.VisitStatusID()

        Dim lDoctorVisits As New List(Of DBConnect)
        Dim lItems As New List(Of DBConnect)
        Dim lAccounts As New List(Of DBConnect)

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim accountBillMode As String = GetLookupDataDes(oBillModesID.Account)
            Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

            Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
            Dim serviceCode As String = StringValueEnteredIn(Me.cboServiceCode, "To-Bill Service!")
            Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))

            Dim standardFee As Decimal = GetServicesStaffFee(serviceCode, staffNo, billNo, billModesID, associatedBillNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim staff As DataTable = oStaff.GetStaff(staffNo).Tables("Staff")
            Dim miniStaff As EnumerableRowCollection(Of DataRow) = staff.AsEnumerable()
            doctorLoginID = (From data In miniStaff Select data.Field(Of String)("LoginID")).First()

            If String.IsNullOrEmpty(doctorLoginID) Then
                message = "The primary doctor you have selected does not have an associated login ID we recommend " +
               "that you contact the administrator to have this fixed. Else you won’t get system alerts." +
                                       ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")

            ElseIf Not doctorLoginID.Trim().ToUpper().Equals(CurrentUser.LoginID.Trim().ToUpper()) Then
                message = "The primary doctor you have selected has a different associated login ID from that " +
                "of the current user. If this is a referral, make sure that the visit is referred appropriately; " +
                "otherwise alerts for this visit won’t be forwarded to you. " +
                                     ControlChars.NewLine + "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim services As DataTable = oServices.GetServices(serviceCode).Tables("Services")
            Dim serviceName As String = services.Rows(0).Item("ServiceName").ToString()
            Dim serviceBillAtID As String = services.Rows(0).Item("ServiceBillAtID").ToString()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oDoctorVisits

                .VisitNo = visitNo
                .StaffNo = staffNo
                .ServiceCode = serviceCode
                .LoginID = CurrentUser.LoginID

                ' Because the header (Doctor Visits) will be part of many activities of the doctor,
                ' save it only if not yet saved

                If .DoctorVisitSaved = False Then

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If serviceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then
                        message = "The system has detected that this visit was originally registered as self request with no consultation bill. " +
                        "It's advised that you edit To-Bill Service to forward consultation bill. " +
                                             ControlChars.NewLine + "Are you sure you want to continue? "
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then
                            Me.cboServiceCode.Focus()
                            Throw New ArgumentException("Action Cancelled!")
                        End If
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    lDoctorVisits.Add(oDoctorVisits)
                    transactions.Add(New TransactionList(Of DBConnect)(lDoctorVisits, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If visitServiceCode.ToUpper().Equals(serviceCode.ToUpper()) AndAlso
                    Not serviceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) AndAlso
                    Not visitStandardFee.Equals(standardFee) Then

                        Dim lServiceItems As New List(Of DBConnect)
                        Dim lItemsCASH As New List(Of DBConnect)

                        Dim miniTransactions As New List(Of TransactionList(Of DBConnect))

                        message = "The system has detected that a " + visitServiceName + " fee of " + FormatNumber(visitStandardFee, AppData.DecimalPlaces) +
                                  " was register for this visit. However, " + SubstringLeft(Me.cboStaffNo.Text) + " is set to charge " +
                                  FormatNumber(standardFee, AppData.DecimalPlaces) + ControlChars.NewLine + "Would you like to change to a correct fee?"

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Try

                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Exit Try
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            DoTransactions(miniTransactions)
                            Me.ShowPatientDetails(visitNo)
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        Catch eX As Exception
                            message = eX.Message + ControlChars.NewLine + "Would you like to continue with this visit?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Save action aborted!")
                        End Try

                    ElseIf Not visitServiceCode.ToUpper().Equals(serviceCode.ToUpper()) Then

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        message = "The system has detected that a " + visitServiceName + " service " +
                                  " was register for this visit. However, " + SubstringLeft(Me.cboStaffNo.Text) + " is set to charge for " +
                                  Me.cboServiceCode.Text + ControlChars.NewLine + "Would you like to change to a correct service?"

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Try

                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then
                                serviceCode = visitServiceCode
                                Me.ShowPatientDetails(visitNo)
                                Exit Try
                            End If

                            If Not visitServiceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then

                                Try

                                    Using oItems As New SyncSoft.SQLDb.Items()
                                        With oItems
                                            .VisitNo = visitNo
                                            .ItemCode = visitServiceCode
                                            .ItemCategoryID = oItemCategoryID.Service

                                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                            .Delete()
                                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                        End With
                                    End Using

                                Catch eX As Exception
                                    message = eX.Message + ControlChars.NewLine + "Would you like to continue with this visit?"
                                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Save action aborted!")
                                End Try

                            End If

                            If Not serviceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then

                                Using oItems As New SyncSoft.SQLDb.Items()

                                    With oItems

                                        .VisitNo = visitNo
                                        .ItemCode = serviceCode
                                        .ItemCategoryID = oItemCategoryID.Service
                                        .Quantity = 1
                                        .UnitPrice = standardFee
                                        .ItemDetails = serviceName + " Service"
                                        .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                        If serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Visit.ToUpper()) Then
                                            .ItemStatusID = oItemStatusID.Offered
                                        Else : .ItemStatusID = oItemStatusID.Pending
                                        End If
                                        .PayStatusID = oPayStatusID.NotPaid
                                        .LoginID = CurrentUser.LoginID

                                    End With

                                    Try

                                        oItems.Save()

                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        Me.tipBillServiceFeeWords.RemoveAll()
                                        Me.stbBillServiceFee.Text = FormatNumber(standardFee, AppData.DecimalPlaces)
                                        Me.tipBillServiceFeeWords.SetToolTip(Me.stbBillServiceFee, NumberToWords(standardFee))
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                    Catch eX As Exception
                                        Throw eX

                                    End Try

                                End Using
                            Else : Me.stbBillServiceFee.Text = String.Empty
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not serviceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper()) Then

                        ''This allows billing or services select at Visits, irrespective of where service bill at is
                        ''as long as its not at Visits
                        If serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Doctor.ToUpper()) OrElse
                               Not serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Visit.ToUpper()) OrElse
                               (serviceBillAtID.ToUpper().Equals(oServiceBillAtID.Visit.ToUpper()) And
                                Not serviceCode.ToUpper().Equals(visitServiceCode.ToUpper())) Then

                            Using oItems As New SyncSoft.SQLDb.Items()
                                With oItems
                                    .VisitNo = visitNo
                                    .ItemCode = serviceCode
                                    .ItemCategoryID = oItemCategoryID.Service
                                    .LastUpdate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                    .PayStatusID = String.Empty
                                    .LoginID = CurrentUser.LoginID
                                    .ItemStatusID = oItemStatusID.Offered
                                End With
                                lItems.Add(oItems)
                            End Using

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Update))
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                            If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                                Dim oEntryModeID As New LookupDataID.EntryModeID()

                                Dim lClaims As New List(Of DBConnect)

                                Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
                                Dim lClaimsEXT As New List(Of DBConnect)
                                Dim lClaimDetails As New List(Of DBConnect)

                                Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)
                                Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

                                Using oClaims As New SyncSoft.SQLDb.Claims()

                                    With oClaims

                                        .MedicalCardNo = billNo
                                        .ClaimNo = GetNextClaimNo(.MedicalCardNo)
                                        .PatientNo = patientNo
                                        .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                        .VisitTime = GetTime(Now)
                                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                                        .PrimaryDoctor = SubstringLeft(StringMayBeEnteredIn(Me.cboStaffNo))
                                        .ClaimStatusID = oClaimStatusID.Pending
                                        .ClaimEntryID = oEntryModeID.System
                                        .LoginID = CurrentUser.LoginID

                                    End With

                                    lClaims.Add(oClaims)

                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    If String.IsNullOrEmpty(claimNo) Then

                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        transactions.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        With oClaimsEXT
                                            .ClaimNo = oClaims.ClaimNo
                                            .VisitNo = visitNo
                                        End With

                                        lClaimsEXT.Add(oClaimsEXT)

                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        transactions.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                        claimNo = oClaims.ClaimNo
                                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    End If
                                End Using

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim limitBalance As Decimal
                                Dim limitAmount As Decimal = GetPolicyLimit(billNo, oBenefitCodes.Service)
                                Dim consumedAmount As Decimal = GetPolicyConsumedAmount(billNo, oBenefitCodes.Service)
                                If limitAmount > 0 Then
                                    limitBalance = limitAmount - consumedAmount
                                Else : limitBalance = 0
                                End If

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                                    With oClaimDetails

                                        .ClaimNo = claimNo
                                        .ItemName = serviceName
                                        .BenefitCode = oBenefitCodes.Service
                                        .Quantity = 1
                                        .UnitPrice = visitStandardFee
                                        .Adjustment = 0
                                        .Amount = .Quantity * .UnitPrice
                                        .Notes = serviceName + " offered to Visit No: " + visitNo
                                        .LimitAmount = limitAmount
                                        .ConsumedAmount = consumedAmount
                                        .LimitBalance = limitBalance

                                    End With

                                    lClaimDetails.Add(oClaimDetails)

                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                    transactions.Add(New TransactionList(Of DBConnect)(lClaimDetails, Action.Save))
                                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                                End Using

                            End If
                        End If
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboStaffNo.Enabled = False
                    Me.cboServiceCode.Enabled = False

                    
                End If
            End With

            Return True

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Sub LoadServices()

        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oServicePointID As New LookupDataID.ServicePointID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from services
            Dim services As DataTable = oServices.GetServicesAtServicePoint(oServicePointID.Visit).Tables("Services")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboServiceCode.Sorted = False
            Me.cboServiceCode.DataSource = services
            Me.cboServiceCode.DisplayMember = "ServiceName"
            Me.cboServiceCode.ValueMember = "ServiceCode"

            Me.cboServiceCode.SelectedIndex = -1
            Me.cboServiceCode.SelectedIndex = -1

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveCancerDiagnosis()

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim lDiagnosis As New List(Of DBConnect)
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            If Me.dgvCancerDiagnosis.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one entry for diagnosis!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvCancerDiagnosis.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvCancerDiagnosis.Rows(rowNo).Cells

                Try

                    Using oDiagnosis As New SyncSoft.SQLDb.CancerDiagnosis
                        With oDiagnosis

                            .VisitNo = visitNo
                            .DiseaseNo = StringEnteredIn(cells, Me.colDiseaseCode)
                            .TopographicalNo = StringEnteredIn(cells, Me.ColTopology)
                            .BasisOfDiagnosisID = StringEnteredIn(cells, Me.ColBasisOfDiagnosis)
                            .CancerStageID = StringEnteredIn(cells, Me.ColCancerStage)
                            .Notes = StringEnteredIn(cells, Me.colNotes)
                            .LoginID = CurrentUser.LoginID
                        End With

                        lDiagnosis.Add(oDiagnosis)

                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lDiagnosis, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Dim oBillModesID As New LookupDataID.BillModesID()
                    Dim insuranceBillMode As String = GetLookupDataDes(oBillModesID.Insurance)

                    If Me.stbBillMode.Text.ToUpper().Equals(insuranceBillMode.ToUpper()) Then

                        Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                        Dim oEntryModeID As New LookupDataID.EntryModeID()

                        Dim lClaims As New List(Of DBConnect)

                        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
                        Dim lClaimsEXT As New List(Of DBConnect)
                        Dim lClaimDiagnosis As New List(Of DBConnect)

                        Dim billNo As String = RevertText(StringEnteredIn(Me.stbBillNo, "To-Bill Account No!"))
                        Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)
                        Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

                        Using oClaims As New SyncSoft.SQLDb.Claims()

                            With oClaims

                                .MedicalCardNo = billNo
                                .ClaimNo = GetNextClaimNo(.MedicalCardNo)
                                .PatientNo = patientNo
                                .VisitDate = DateEnteredIn(Me.stbVisitDate, "Visit Date!")
                                .VisitTime = GetTime(Now)
                                .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                                .PrimaryDoctor = SubstringLeft(StringMayBeEnteredIn(Me.cboStaffNo))
                                .ClaimStatusID = oClaimStatusID.Pending
                                .ClaimEntryID = oEntryModeID.System
                                .LoginID = CurrentUser.LoginID

                            End With

                            lClaims.Add(oClaims)

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            If String.IsNullOrEmpty(claimNo) Then

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                transactions.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                With oClaimsEXT
                                    .ClaimNo = oClaims.ClaimNo
                                    .VisitNo = visitNo
                                End With

                                lClaimsEXT.Add(oClaimsEXT)

                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                transactions.Add(New TransactionList(Of DBConnect)(lClaimsEXT, Action.Save))
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                claimNo = oClaims.ClaimNo
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            End If
                        End Using

                        Using oClaimDiagnosis As New SyncSoft.SQLDb.ClaimDiagnosis()

                            With oClaimDiagnosis
                                .ClaimNo = claimNo
                                .DiseaseCode = StringEnteredIn(cells, Me.colDiseaseCode, "Disease Code!")
                            End With

                            lClaimDiagnosis.Add(oClaimDiagnosis)

                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            transactions.Add(New TransactionList(Of DBConnect)(lClaimDiagnosis, Action.Save))
                            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        End Using

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvCancerDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value = True

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvDiagnosis.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbVisitDate.Clear()
        Me.stbPatientNo.Clear()
        Me.stbBillServiceFee.Clear()
        Me.tipBillServiceFeeWords.RemoveAll()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbTotalVisits.Clear()
        visitStatus = String.Empty
        Me.stbBillNo.Clear()
        Me.stbBillCustomerName.Clear()
        Me.nbxOutstandingBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
        Me.tipOutstandingBalanceWords.RemoveAll()
        Me.stbCombination.Clear()
        billCustomerName = String.Empty
        doctorLoginID = String.Empty
        billModesID = String.Empty
        associatedBillNo = String.Empty
        Me.stbBillMode.Clear()
        Me.cboServiceCode.SelectedIndex = -1
        Me.cboServiceCode.SelectedIndex = -1
        Me.stbVisitServiceName.Clear()
        Me.lblServicePayStatusID.Text = String.Empty
        Me.spbPhoto.Image = Nothing
     
    End Sub

    Private Sub ResetControls()

        '''''''''''''''''''''''''''''''''''''''
        staffFullName = String.Empty

        '''''''''''''''''''''''''''''''''''''''
        ResetControlsIn(Me)

    End Sub

    Private Sub LoadTopologySites()

        Dim oTopologySites As New SyncSoft.SQLDb.TopologySites()

        Try
            Me.Cursor = Cursors.WaitCursor
            ' Load all from TopologySites
            Dim topologySites As DataTable = oTopologySites.GetTopologySites.Tables("TopologySites")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.ColTopology, topologySites, "TopographicalNo", "TopologyFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oVariousOptions As New VariousOptions()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim outstandingBalanceErrorMSG As String = "This patient has offered/done service(s) with pending payment. " +
                                                    ControlChars.NewLine + "Please advice accordingly!"

        Try

            Me.tipBillServiceFeeWords.RemoveAll()
            Me.tipOutstandingBalanceWords.RemoveAll()

            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)

            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")

            Dim visitDate As Date = DateEnteredIn(row, "VisitDate")
            Me.stbVisitDate.Text = FormatDate(visitDate)
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.stbAge.Text = GetAgeString(birthDate)
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")
            visitStatus = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            billCustomerName = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
            Me.tipOutstandingBalanceWords.SetToolTip(Me.nbxOutstandingBalance, NumberToWords(outstandingBalance))
            Me.stbCombination.Text = StringMayBeEnteredIn(row, "Combination")
            Dim billMode As String = StringEnteredIn(row, "BillMode")
            Me.stbBillMode.Text = billMode
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")
            doctorLoginID = StringMayBeEnteredIn(row, "DoctorLoginID")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If outstandingBalance > 0 Then
                ErrProvider.SetError(Me.nbxOutstandingBalance, outstandingBalanceErrorMSG)
            Else : ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            visitServiceCode = StringMayBeEnteredIn(row, "ServiceCode")
            visitServiceName = StringMayBeEnteredIn(row, "ServiceName")
            accessCashServices = BooleanMayBeEnteredIn(row, "AccessCashServices")
            servicePayStatusID = StringMayBeEnteredIn(row, "ServicePayStatusID")
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")

            Me.stbVisitServiceName.Text = visitServiceName
            Me.lblServicePayStatusID.Text = GetLookupDataDes(servicePayStatusID)

            Dim doctorServiceCode As String = StringMayBeEnteredIn(row, "DoctorServiceCode")
            Dim serviceCode As String

            If Not String.IsNullOrEmpty(doctorServiceCode) Then
                Me.cboServiceCode.SelectedValue = doctorServiceCode
                serviceCode = doctorServiceCode
            Else
                Me.cboServiceCode.SelectedValue = visitServiceCode
                serviceCode = visitServiceCode
            End If

            If Not String.IsNullOrEmpty(serviceCode) Then
                Try
                    Dim items As DataTable = oItems.GetItem(visitNo, serviceCode, oItemCategoryID.Service).Tables("Items")
                    Dim itemsRow As DataRow = items.Rows(0)
                    visitStandardFee = DecimalMayBeEnteredIn(itemsRow, "UnitPrice")
                    Me.stbBillServiceFee.Text = FormatNumber(visitStandardFee, AppData.DecimalPlaces)
                    If Not oVariousOptions.HideDoctorBillServiceFee Then
                        Me.tipBillServiceFeeWords.SetToolTip(Me.stbBillServiceFee, NumberToWords(visitStandardFee))
                    End If

                Catch ex As Exception
                    Exit Try
                End Try
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            staffFullName = StringMayBeEnteredIn(row, "StaffFullName")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadVisitsData(ByVal visitNo As String)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(visitNo)
            Me.LoadDoctorVisit(visitNo)
            Me.LoadCancerDiagnosis(visitNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub frmCancerDiagnosis_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Dim oCancerDiagnosis As New SyncSoft.SQLDb.CancerDiagnosis()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oCancerDiagnosis.VisitNo = StringEnteredIn(Me.stbVisitNo, "Visit No!")

            DisplayMessage(oCancerDiagnosis.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            'Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

   Private Sub btnLoadSeeDrVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadSeeDrVisits.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSeeDoctorVisits As New frmSeeDoctorVisits(Me.stbVisitNo)
            fSeeDoctorVisits.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowVisitsHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Enter

        Try
            currentAllSaved = Me.AllSaved()
            If Not currentAllSaved Then
                currentVisitNo = StringMayBeEnteredIn(Me.stbVisitNo)
                ProcessTabKey(True)
            Else : currentVisitNo = String.Empty
            End If

        Catch ex As Exception
            currentVisitNo = String.Empty
        End Try

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not currentAllSaved AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
            Me.stbVisitNo.Text = currentVisitNo
            Return
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.ClearControls()
        Me.ResetControls()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() AndAlso Not String.IsNullOrEmpty(currentVisitNo) Then
                Me.stbVisitNo.Text = currentVisitNo
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowVisitsHeaderData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()
            ResetControlsIn(Me.pnlNavigateVisits)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowVisitsHeaderData()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()
            ResetControlsIn(Me.pnlNavigateVisits)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Me.LoadVisitsData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearControls()
            Me.ResetControls()
            ResetControlsIn(Me.pnlNavigateVisits)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub SetDiagnosisEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvCancerDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

            If CBool(Me.dgvCancerDiagnosis.Item(Me.colDiagnosisSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                Dim diagnosisDisplay As String = (From data In diagnosis
                                    Where data.Field(Of String)("DiseaseNo").ToUpper().Equals(_DiagnosisValue.ToUpper())
                                    Select data.Field(Of String)("DiseaseName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Diagnosis (" + diagnosisDisplay + ") can't be edited!")
                Me.dgvCancerDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Value = _DiagnosisValue
                Me.dgvCancerDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvCancerDiagnosis.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvCancerDiagnosis.Rows(rowNo).Cells, Me.colDiseaseCode)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                        Dim enteredDisplay As String = (From data In diagnosis
                                            Where data.Field(Of String)("DiseaseNo").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("DiseaseName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Diagnosis (" + enteredDisplay + ") already entered!")
                        Me.dgvCancerDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Value = _DiagnosisValue
                        Me.dgvCancerDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If diseases Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

            For Each row As DataRow In diseases.Select("DiseaseNo = '" + selectedItem + "'")
                Me.dgvCancerDiagnosis.Item(Me.colCancerDiagnosisCode.Name, selectedRow).Value = StringEnteredIn(row, "DiseaseNo")
                Me.dgvCancerDiagnosis.Item(Me.colDiseaseCategory.Name, selectedRow).Value = StringEnteredIn(row, "CancerDiseaseCategory")
                '  Me.dgvCancerDiagnosis.Item(Me.colCancerDiagnosisCode.Name, selectedRow).Value = selectedItem
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvCancerDiagnosis_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvCancerDiagnosis.CellBeginEdit
        If e.ColumnIndex <> Me.colDiseaseCode.Index OrElse Me.dgvCancerDiagnosis.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvCancerDiagnosis.CurrentCell.RowIndex
        _DiagnosisValue = StringMayBeEnteredIn(Me.dgvCancerDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)
    End Sub

    Private Sub dgvCancerDiagnosis_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCancerDiagnosis.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colDiseaseCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvCancerDiagnosis.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvCancerDiagnosis.CurrentCell.RowIndex
                    Me.SetDiagnosisEntries(selectedRow)

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvCancerDiagnosis_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvCancerDiagnosis.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oDiagnosis As New SyncSoft.SQLDb.CancerDiagnosis()
            Dim toDeleteRowNo As Integer = e.Row.Index

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If CBool(Me.dgvCancerDiagnosis.Item(Me.colDiagnosisSaved.Name, toDeleteRowNo).Value) = False Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim diagnosis As String = CStr(Me.dgvCancerDiagnosis.Item(Me.colDiseaseCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oDiagnosis
                .VisitNo = visitNo
                .DiseaseNo = diagnosis
                DisplayMessage(.Delete())
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCancerDiagnosis(ByVal visitNo As String)

        Dim oCancerDiagnosis As New SyncSoft.SQLDb.CancerDiagnosis()

        Try

            Me.dgvCancerDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            Dim cancerDiagnosis As DataTable = oCancerDiagnosis.GetCancerDiagnosis(RevertText(visitNo)).Tables("CancerDiagnosis")
            If cancerDiagnosis Is Nothing OrElse cancerDiagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To cancerDiagnosis.Rows.Count - 1

                Dim row As DataRow = cancerDiagnosis.Rows(pos)

                With Me.dgvCancerDiagnosis
                    ' Ensure that you add a new row

                    .Rows.Add()
                    .Item(Me.colDiseaseCode.Name, pos).Value = StringEnteredIn(row, "DiseaseNo")
                    .Item(Me.colCancerDiagnosisCode.Name, pos).Value = StringEnteredIn(row, "DiseaseNo")
                    .Item(Me.ColTopology.Name, pos).Value = StringEnteredIn(row, "TopographicalNo")
                    .Item(Me.ColBasisOfDiagnosis.Name, pos).Value = StringEnteredIn(row, "BasisOfDiagnosisID")
                    .Item(Me.colDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "CancerDiseaseCategories")
                    .Item(Me.ColCancerStage.Name, pos).Value = StringEnteredIn(row, "CancerStageID")
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colDiagnosisSaved.Name, pos).Value = True

                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Try
            Dim message As String
            Dim oVisitStatusID As New LookupDataID.VisitStatusID()
            Dim oVariousOptions As New VariousOptions()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Remember to save header if not yet saved
            Me.SaveDoctorVisits()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' If Me.DoctorVisitClosed() Then Return
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)

            If Not visitDate.Equals(AppData.NullDateValue) AndAlso Not String.IsNullOrEmpty(visitStatus) AndAlso
               Not visitStatus.ToUpper().Equals(GetLookupDataDes(oVisitStatusID.Doctor).ToUpper()) AndAlso
               visitDate < GetShortDate(Today) Then

                Dim remainingUpdateDays As Integer = (Today - visitDate).Days

                If remainingUpdateDays > oVariousOptions.DoctorVisitUpdateDays Then
                    message = "The visit that you want to update is a past visit that is known to have been completed." +
                                ControlChars.NewLine + "The system is set not to allow changes to a completed visit after " +
                                oVariousOptions.DoctorVisitUpdateDays.ToString() + " day(s)."
                    Throw New ArgumentException(message)
                Else
                    message = "The visit that you want to update is a past visit that is known to have been completed." +
                                ControlChars.NewLine + "Are you sure you want to save?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                End If

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SaveCancerDiagnosis()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

#Region " Cancer - Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcDrCancerRoles.SelectedTab.Name

                Case Me.tpgDiagnosis.Name
                    title = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Cancer Diagnosis Request".ToUpper()
                    Me.PrintCancerDiagnosis()
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub PrintCancerDiagnosis()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvCancerDiagnosis.RowCount <= 1 Then Throw New ArgumentException("Must include at least one cancer diagnosis!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

            For Each row As DataGridViewRow In Me.dgvCancerDiagnosis.Rows
                If row.IsNewRow Then Exit For
                If CBool(Me.dgvCancerDiagnosis.Item(Me.colDiagnosisSaved.Name, row.Index).Value) = True Then
                    nonSelected = False
                    Exit For
                End If
                nonSelected = True
            Next

            If nonSelected Then Throw New ArgumentException("Must have saved at least one entry for Cancer Diagnosis!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetCancerDianosisPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDoctor
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDoctor.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub SetCancerDianosisPrintData()
        Dim padTopology As Integer = 20
        Dim padDiagnosis As Integer = 20
        Dim padBasisOfDiagnosis As Integer = 20
        Dim padStage As Integer = 8
        Dim padNotes As Integer = 20

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        doctorParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("Site: ".PadRight(padTopology))
            tableHeader.Append("Diagnosis: ".PadRight(padDiagnosis))
            tableHeader.Append("Basis Of Diagnosis: ".PadLeft(padBasisOfDiagnosis))
            tableHeader.Append("Stage: ".PadLeft(padStage))
            tableHeader.Append("Notes: ".PadLeft(padNotes))
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvCancerDiagnosis.RowCount - 1

                If CBool(Me.dgvCancerDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvCancerDiagnosis.Rows(rowNo).Cells

                    count += 1

                    Dim topology As String = SubstringLeft(cells.Item(Me.ColTopology.Name).Value.ToString())
                    Dim diagnosis As String = cells.Item(Me.colCancerDiagnosisCode.Name).Value.ToString()
                    Dim basisofdiagnosis As String = cells.Item(Me.ColBasisOfDiagnosis.Name).Value.ToString()
                    Dim stage As String = cells.Item(Me.ColCancerStage.Name).Value.ToString()
                    Dim notes As String = cells.Item(Me.colNotes.Name).Value.ToString()

                    If topology.Length > 20 Then
                        tableData.Append(topology.Substring(0, 20).PadRight(padTopology))
                    Else : tableData.Append(topology.PadRight(padTopology))
                    End If
                    If diagnosis.Length > 20 Then
                        tableData.Append(diagnosis.Substring(0, 20).PadRight(padDiagnosis))
                    Else : tableData.Append(diagnosis.PadRight(padDiagnosis))
                    End If
                    If basisofdiagnosis.Length > 20 Then
                        tableData.Append(basisofdiagnosis.Substring(0, 20).PadRight(padBasisOfDiagnosis))
                    Else : tableData.Append(basisofdiagnosis.PadRight(padBasisOfDiagnosis))
                    End If
                    If stage.Length > 20 Then
                        tableData.Append(stage.Substring(0, 20).PadRight(padStage))
                    Else : tableData.Append(stage.PadRight(padStage))
                    End If
                    If notes.Length > 20 Then
                        tableData.Append(notes.Substring(0, 20).PadRight(padNotes))
                    Else : tableData.Append(notes.PadRight(padNotes))
                    End If


                    tableData.Append(ControlChars.NewLine)

                End If
            Next

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") + _
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            doctorParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Fingerprint  "

    Private Sub btnFindByFingerprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindByFingerprint.Click

        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.AllSaved() Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitFingerprints As DataTable = GetVisitFingerprints()

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, visitFingerprints, "VisitNo")
                fFingerprintCapture.ShowDialog()

                Dim visitNo As String = Me.oCrossMatchTemplate.ID
                If Me.oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(visitNo) Then Return

                Me.LoadVisitsData(visitNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(visitFingerprints, "VisitNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.LoadVisitsData(Me.oDigitalPersonaTemplate.ID)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

#Region " Popup Menu "

    Private Sub cmsDoctor_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsDoctor.Opening

        Select Case Me.tbcDrCancerRoles.SelectedTab.Name

            Case Me.tpgDiagnosis.Name

                Me.cmsDoctorCopy.Visible = False
                Me.cmsDoctorSelectAll.Visible = False
                Me.cmsDoctorQuickSearch.Visible = True

        End Select

    End Sub

  Private Sub cmsDoctorQuickSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsDoctorQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rowIndex As Integer

            Select Case Me.tbcDrCancerRoles.SelectedTab.Name

                Case Me.tpgDiagnosis.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("CancerDiseases", Me.dgvCancerDiagnosis, Me.colDiseaseCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvCancerDiagnosis.NewRowIndex
                    If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub btnFindVisitNo_Click(sender As System.Object, e As System.EventArgs) Handles btnFindVisitNo.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return

        Me.ShowPatientDetails(visitNo)
        stbVisitNo_Leave(Me, System.EventArgs.Empty)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

End Class