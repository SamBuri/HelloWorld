
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Collections.Generic
Imports System.Drawing.Printing
Imports SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmDischarges

#Region " Fields "

    Private billModesID As String = String.Empty
    Private associatedBillNo As String = String.Empty

    Private oItemStatusID As New LookupDataID.ItemStatusID()
    Private oPayStatusID As New LookupDataID.PayStatusID()

    Private _PrescriptionDrugValue As String = String.Empty

    Private WithEvents docDischarge As New PrintDocument()

    ' The paragraphs.
    Private padLineNo As Integer = 6
    Private padService As Integer = 44
    Private padNotes As Integer = 20
    Dim oDischargeStatus As New LookupDataID.DischargeStatus

    Private title As String
    Private dischargeParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private oIntegrationAgent As New IntegrationAgents()
#End Region

#Region " Validations "

    Private Sub dtpDischargeDateTime_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpDischargeDateTime.Validating

        Dim errorMSG As String = String.Empty

        Try

            Dim dischargeDateTime As Date = DateTimeMayBeEnteredIn(Me.dtpDischargeDateTime)
            Dim admissionDateTime As Date = DateTimeMayBeEnteredIn(Me.stbAdmissionDateTime)
            Dim lastRoundDateTime As Date = DateTimeMayBeEnteredIn(Me.stbLastRoundDateTime)

            If GetShortDate(dischargeDateTime) = AppData.NullDateValue Then Return

            If dischargeDateTime < admissionDateTime Then
                errorMSG = "Discharge date time can't be before admission date time!"
                ErrProvider.SetError(Me.dtpDischargeDateTime, errorMSG)
                Me.dtpDischargeDateTime.Focus()
                e.Cancel = True

            ElseIf dischargeDateTime < lastRoundDateTime Then
                errorMSG = "Discharge date time can't be before last round date time!"
                ErrProvider.SetError(Me.dtpDischargeDateTime, errorMSG)
                Me.dtpDischargeDateTime.Focus()
                e.Cancel = True

            Else : ErrProvider.SetError(Me.dtpDischargeDateTime, String.Empty)
            End If

        Catch ex As Exception
            Return

        End Try

    End Sub

#End Region

    Private Sub frmDischarges_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpDischargeDateTime.MaxDate = Today.AddDays(1)
            Me.dtpDischargeDateTime.Value = Now

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboDischargeStatusID, LookupObjects.DischargeStatus, True)

            Me.LoadStaff()
            Me.LoadDrugs()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmDischarges_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim message As String = "Current discharge record is not saved." + ControlChars.NewLine + "Just close anyway?"
        If Not Me.RecordSaved(True) Then
            If WarningMessage(message) = Windows.Forms.DialogResult.No Then e.Cancel = True
        End If
    End Sub

    Private Sub frmDischarges_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbAdmissionNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbAdmissionNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()
        Dim oStaffTitleID As New LookupDataID.StaffTitleID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaffByStaffTitle(oStaffTitleID.Doctor).Tables("Staff")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub btnFindAdmissionNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindAdmissionNo.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindAdmissionNo As New frmFindAutoNo(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
        fFindAdmissionNo.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
        If String.IsNullOrEmpty(admissionNo) Then Return
        Me.LoadAdmissionsData(admissionNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fInWardAdmissions As New frmInWardAdmissions(Me.stbAdmissionNo, AutoNumber.AdmissionNo)
        fInWardAdmissions.ShowDialog(Me)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
        If String.IsNullOrEmpty(admissionNo) Then Return
        Me.LoadAdmissionsData(admissionNo)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub stbAdmissionNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbAdmissionNo.TextChanged
        Me.CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub ClearControls()

        Me.stbAdmissionDateTime.Clear()
        Me.stbLastRoundDateTime.Clear()
        Me.stbPatientNo.Clear()
        Me.stbVisitNo.Clear()
        Me.stbVisitDate.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbAge.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        billModesID = String.Empty
        associatedBillNo = String.Empty
        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceName.Clear()
        Me.stbServiceName.Clear()
        Me.chkSmartCardApplicable.Checked = False
        Me.stbMemberCardNo.Clear()
        Me.stbWard.Clear()
        Me.stbRoomNo.Clear()
        Me.stbBedNo.Clear()
        Me.btnPrintPreview.Enabled = False
        Me.btnPrint.Enabled = False
        Me.chkReconciliationRequired.Checked = False

    End Sub

    Private Sub stbAdmissionNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbAdmissionNo.Leave

        Try

            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            If String.IsNullOrEmpty(admissionNo) Then Return
            Me.LoadAdmissionsData(admissionNo)

        Catch eX As Exception
            ErrorMessage(eX)

        End Try

    End Sub

    Private Sub LoadAdmissionsData(ByVal admissionNo As String)

        Dim oVariousOptions As New VariousOptions()
        Dim oAdmissions As New SyncSoft.SQLDb.Admissions()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()
            If String.IsNullOrEmpty(admissionNo) Then Return

            Dim admissions As DataTable = oAdmissions.GetAdmissions(admissionNo).Tables("Admissions")
            Dim row As DataRow = admissions.Rows(0)

            Dim patientNo As String = StringEnteredIn(row, "PatientNo")
            Dim visitNo As String = StringEnteredIn(row, "VisitNo")

            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbAdmissionDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "AdmissionDateTime"))
            Me.stbLastRoundDateTime.Text = FormatDateTime(DateTimeEnteredIn(row, "LastRoundDateTime"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            billModesID = StringMayBeEnteredIn(row, "BillModesID")
            associatedBillNo = StringMayBeEnteredIn(row, "AssociatedBillNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Dim associatedBillCustomer As String = StringMayBeEnteredIn(row, "AssociatedBillCustomer")
            Dim billCustomerName As String = StringMayBeEnteredIn(row, "BillCustomerName")
            If Not String.IsNullOrEmpty(associatedBillCustomer) Then billCustomerName += " (" + associatedBillCustomer + ")"
            Me.stbBillCustomerName.Text = billCustomerName
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            Me.stbServiceName.Text = StringMayBeEnteredIn(row, "ServiceName")
            Me.stbMemberCardNo.Text = StringMayBeEnteredIn(row, "MemberCardNo")
            Me.chkSmartCardApplicable.Checked = BooleanMayBeEnteredIn(row, "SmartCardApplicable")
            Me.stbWard.Text = StringMayBeEnteredIn(row, "Ward")
            Me.stbRoomNo.Text = StringMayBeEnteredIn(row, "RoomNo")
            Me.stbBedNo.Text = StringMayBeEnteredIn(row, "BedNo")
            Me.chkReconciliationRequired.Checked = BooleanMayBeEnteredIn(row, "BillReconciled")
            Dim accessCashServices As Boolean = BooleanMayBeEnteredIn(row, "AccessCashServices")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.SetNextRoundNo(admissionNo)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim lastRoundDateTime As Date = DateTimeMayBeEnteredIn(row, "LastRoundDateTime")
                If Not GetShortDate(lastRoundDateTime).Equals(Today) AndAlso
                    Not GetShortDate(lastRoundDateTime) = AppData.NullDateValue Then
                    Me.dtpDischargeDateTime.Value = lastRoundDateTime
                    Me.dtpDischargeDateTime.Checked = False
                Else : Me.dtpDischargeDateTime.Value = Now
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim billAccount As String = GetLookupDataDes(oBillModesID.Cash)
                Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)

                Dim extraBillItems As DataTable = oExtraBillItems.GetExtraBillItems(visitNo, oPayStatusID.NotPaid, billAccount).Tables("ExtraBillItems")

                If oVariousOptions.AllowAccessCashDischarges.Equals(False) AndAlso oVariousOptions.AllowAccessCashServices.Equals(False) AndAlso
                    accessCashServices.Equals(False) AndAlso extraBillItems IsNot Nothing AndAlso extraBillItems.Rows.Count > 0 Then

                    Dim message As String = "The Visit No: " + FormatText(visitNo, "Visits", "VisitNo") + " has unpaid for bill form items. " +
                                            ControlChars.NewLine + "The system is set not to allow discharging such an admission!"
                    DisplayMessage(message)
                    Me.stbAdmissionNo.Clear()
                    Me.stbRoundNo.Clear()

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.btnPrintPreview.Enabled = True
            Me.btnPrint.Enabled = True
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub SetNextRoundNo(ByVal admissionNo As String)

        Try

            Dim oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("IPDDoctor", "RoundNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim roundID As String = oIPDDoctor.GetNextRoundID(admissionNo).ToString()
            roundID = roundID.PadLeft(paddingLEN, paddingCHAR)

            Me.stbRoundNo.Text = FormatText(admissionNo + roundID.Trim(), "IPDDoctor", "RoundNo")

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub tbcDrRoles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcDrRoles.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgDischargeNotes.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgDischargeNotes.Text
                    Me.pnlBill.Visible = False
                    ResetControlsIn(Me.pnlBill)

                Case Me.tpgPrescriptions.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgPrescriptions.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForPrescriptions()

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

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oDischarges As New SyncSoft.SQLDb.Discharges()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            'oDischarges.AdmissionNo = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))

            'DisplayMessage(oDischarges.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'ResetControlsIn(Me)
            'ResetControlsIn(Me.tpgDischargeNotes)
            'ResetControlsIn(Me.tpgPrescriptions)
            'ResetControlsIn(Me.pnlBill)
            'Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oDischarges As New SyncSoft.SQLDb.Discharges()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
            Dim dataSource As DataTable = oDischarges.GetDischarges(admissionNo).Tables("Discharges")
            Me.DisplayData(dataSource)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            Me.dgvPrescription.Rows.Clear()
            If Not String.IsNullOrEmpty(roundNo) Then Me.LoadPrescriptions(roundNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dtpReviewDate.Checked = True
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim records As Integer
        Dim smartAgentNo As String = oIntegrationAgent.SMART
        Dim visitNo As String = RevertText(StringEnteredIn(stbVisitNo, "Visit No"))
        Dim admissionNo As String = RevertText(StringEnteredIn(Me.stbAdmissionNo, "Admission No!"))
        Dim oVariousOption As New VariousOptions()
        Try

            Me.Cursor = Cursors.WaitCursor

            If chkSmartCardApplicable.Checked AndAlso oVariousOption.ForceSmartCardProcessing Then

                Dim oINTExtraBillItems As New INTExtraBillItems()
                Dim _INTExtraBillItems As DataTable = oINTExtraBillItems.GetINTExtraBillItemsBySyncStatus(smartAgentNo, visitNo, False).Tables("INTExtraBillItems")
                If _INTExtraBillItems.Rows.Count > 0 Then
                    DisplayMessage("The Patient: " + stbFullName.Text + " bills to be billed on smart. Please bill them to to continue")
                    Dim fSmartBilling As New frmSmartBilling(admissionNo)
                    fSmartBilling.ShowDialog()
                    If Not fSmartBilling.GetSaveApproved() Then
                        _INTExtraBillItems = oINTExtraBillItems.GetINTExtraBillItemsBySyncStatus(smartAgentNo, visitNo, False).Tables("INTExtraBillItems")
                        If _INTExtraBillItems.Rows.Count > 0 Then
                            Throw New ArgumentException("Please ensure that all the pending bills are billed on smart to continue")
                        End If
                    End If
                End If
            End If
            Dim lDischarges As New List(Of DBConnect)
            Dim lIPDDoctor As New List(Of DBConnect)
            Dim transactions As New List(Of TransactionList(Of DBConnect))
            Dim staffNo As String = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
            Dim roundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRoundNo))
            Dim dischargeDateTime As Date = DateTimeEnteredIn(Me.dtpDischargeDateTime, "Discharge Date Time!")
            Dim dischargeStatusID As String = StringValueEnteredIn(Me.cboDischargeStatusID, "Discharge Status!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using oIPDDoctor As New SyncSoft.SQLDb.IPDDoctor()

                With oIPDDoctor

                    .RoundNo = roundNo
                    .AdmissionNo = admissionNo
                    .StaffNo = staffNo
                    .RoundDateTime = dischargeDateTime
                    .LoginID = CurrentUser.LoginID

                End With

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lIPDDoctor.Add(oIPDDoctor)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Using

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Using oDischarges As New SyncSoft.SQLDb.Discharges()

                With oDischarges

                    .AdmissionNo = admissionNo
                    .StaffNo = staffNo
                    .RoundNo = roundNo
                    .DischargeDateTime = dischargeDateTime
                    .DischargeNotes = StringMayBeEnteredIn(Me.stbDischargeNotes)
                    .DischargeStatusID = StringValueEnteredIn(Me.cboDischargeStatusID, "Discharge Status!")
                    If dischargeStatusID.ToUpper().Equals(oDischargeStatus.Deceased().ToUpper()) Then
                        .ReviewDate = DateMayBeEnteredIn(Me.dtpReviewDate)
                    Else : .ReviewDate = DateEnteredIn(Me.dtpReviewDate, "Review Date!")
                    End If

                    .History = StringMayBeEnteredIn(Me.stbHistory)
                    .Examination = StringMayBeEnteredIn(Me.stbExamination)
                    .KeyFindingsInvestigation = StringMayBeEnteredIn(Me.stbKeyFindInvestigation)
                    .TreatmentOnWard = StringMayBeEnteredIn(Me.stbTreatmentOnWard)
                    .OutcomeOfTreatment = StringEnteredIn(Me.stbTreatmentOutcome, "Outcome Of Treatment")
                    .KeyRecommendations = StringEnteredIn(Me.stbKeyRecommendations, "Key Recommendations")
                    .LoginID = CurrentUser.LoginID

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ValidateEntriesIn(Me)
                    ValidateEntriesIn(Me, ErrProvider)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End With

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                lDischarges.Add(oDischarges)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Using

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyPrescriptionsEntries()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If dischargeStatusID.ToUpper().Equals(oDischargeStatus.Deceased.ToUpper()) Then
                Dim fDeath As New frmDeaths(Me.stbPatientNo.Text)

                If WarningMessage("The " + stbFullName.Text + " is Deceased. Do you want to open the death form? ") = Windows.Forms.DialogResult.No Then Return
                fDeath.ShowDialog()
            End If



            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If GetShortDate(dischargeDateTime) < Today Then
                        message = "You have selected a discharge date that is before today. " + ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(roundNo) AndAlso Me.dgvPrescription.RowCount <= 1 Then
                        message = "No discharge prescription(s) registered. " + ControlChars.NewLine + "Are you sure you want to save?"
                        If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    message = "You are about to perform an irreversible action that closes this admission. " +
                                            ControlChars.NewLine + "Are you sure you want to save?"

                    If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(roundNo) Then transactions.Add(New TransactionList(Of DBConnect)(lIPDDoctor, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lDischarges, Action.Save))
                    DoTransactions(transactions)

                    Me.SavePrescriptions()
                    Me.SaveNextAppointment()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.chkGenerateInvoiceOnSaving.Checked Then Me.btnGenerateInvoice.PerformClick()
                    If Not Me.chkPrintDischargeReportOnSaving.Checked Then
                        message = "You have not checked Print Discharge Report On Saving. " + ControlChars.NewLine + "Would you want a report printed?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.PrintDischarge()
                    Else : Me.PrintDischarge()
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgDischargeNotes)
                    ResetControlsIn(Me.tpgPrescriptions)
                    ResetControlsIn(Me.pnlBill)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case ButtonCaption.Update

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lDischarges, Action.Update, "Discharges"))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)

                    Me.SavePrescriptions()

                    DisplayMessage(records.ToString() + " record(s) updated!")
                    Me.CallOnKeyEdit()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select



        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function VerifyPrescriptionsEntries() As Boolean

        Dim message As String

        Try

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For

                Dim oVariousOptions As New VariousOptions()
                Dim drugNo As String = SubstringRight(StringEnteredIn(row.Cells, Me.colDrug, "drug!"))
                Dim drugName As String = SubstringLeft(StringEnteredIn(row.Cells, Me.colDrug))

                StringEnteredIn(row.Cells, Me.colDosage, "dosage!")
                IntegerEnteredIn(row.Cells, Me.colDuration, "duration!")
                Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colDrugQuantity, "quantity!")
                DecimalEnteredIn(row.Cells, Me.colDrugUnitPrice, False, "unit price!")
                StringMayBeEnteredIn(row.Cells, Me.colDrugFormula)

                Dim availableStock As Integer = GetAvailableStock(drugNo)
                Dim orderLevel As Integer = IntegerMayBeEnteredIn(row.Cells, Me.colOrderLevel)
                Dim halted As Boolean = BooleanMayBeEnteredIn(row.Cells, Me.colHalted)
                Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(row.Cells, Me.colHasAlternateDrugs)
                Dim expiryDate As Date = DateMayBeEnteredIn(row.Cells, Me.colExpiryDate)
                Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If BooleanMayBeEnteredIn(row.Cells, Me.colPrescriptionSaved).Equals(False) Then

                    'If halted Then
                    '    If hasAlternateDrugs Then
                    '        message = "Drug: " + drugName + " is currently on halt and has registered alternatives. " + 
                    '                        "The system does not allow prescription of a drug on halt. " + 
                    '                        ControlChars.NewLine + "Would you like to look at its alternatives? "
                    '        If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)
                    '    Else
                    '        message = "Drug: " + drugName + " is currently on halt and has no registered alternatives. " + 
                    '                    "The system does not allow prescription of a drug on halt!"
                    '        DisplayMessage(message)
                    '    End If
                    'End If

                    If availableStock < quantity Then
                        If Not oVariousOptions.AllowPrescriptionToNegative() Then
                            If hasAlternateDrugs Then
                                message = "Insufficient stock to dispense for " + drugName + " with a deficit of " +
                                  (quantity - availableStock).ToString() + " and has registered alternatives. " +
                                  "The system does not allow a prescription of a drug that is out of stock. " +
                                  "Please notify Pharmacy to re-stock appropriately. " +
                                   ControlChars.NewLine + "Would you like to look at its alternatives? "
                                If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)
                            Else
                                message = "Insufficient stock to dispense for " + drugName + " with a deficit of " +
                                    (quantity - availableStock).ToString() + " and has no registered alternatives. " +
                                    "The system does not allow a prescription of a drug that is out of stock. " +
                                    "Please notify Pharmacy to re-stock appropriately!"
                                DisplayMessage(message)
                            End If
                            Continue For
                        Else
                            message = "Insufficient stock to dispense for " + drugName +
                                      " with a deficit of " + (quantity - availableStock).ToString() +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then
                                If hasAlternateDrugs Then
                                    message = "Would you like to look at " + drugName + " alternatives? "
                                    If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)
                                End If
                                Continue For
                            End If
                        End If

                    ElseIf orderLevel >= availableStock - quantity Then
                        message = "Stock level for " + drugName + " is running low. Please notify Pharmacy to re-stock appropriately!"
                        DisplayMessage(message)
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                        If Not oVariousOptions.AllowPrescriptionExpiredDrugs() Then
                            message = "Expiry date for " + drugName + " had reached. " +
                                "The system does not allow to prescribe a drug that is expired. Please notify Pharmacy to re-stock appropriately! "
                            DisplayMessage(message)
                            Continue For
                        Else
                            message = "Expiry date for " + drugName + " had reached. " + ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Continue For
                        End If

                    ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                        message = "Drug: " + drugName + " has " + remainingDaysExpiryDate.ToString() +
                            " remaining day(s) to expire. Please notify Pharmacy to re-stock appropriately!"
                        DisplayMessage(message)

                    ElseIf expiryDate = AppData.NullDateValue Then
                        message = "Expiry date for " + drugName + " is not set. The system can not verify when this drug will expire!"
                        DisplayMessage(message)
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgPrescriptions.Name)
            VerifyPrescriptionsEntries = False
            Throw ex

        End Try

    End Function

    Private Sub SavePrescriptions()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            If Me.dgvPrescription.RowCount <= 1 Then Return
            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim transactions As New List(Of TransactionList(Of DBConnect))
                Dim lIPDItems As New List(Of DBConnect)
                Dim lIPDItemsEXT As New List(Of DBConnect)

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                Try
                    Using oIPDItems As New SyncSoft.SQLDb.IPDItems()
                        With oIPDItems
                            .RoundNo = roundNo
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                            .Quantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                            .UnitPrice = DecimalEnteredIn(cells, Me.colDrugUnitPrice, False)
                            .ItemDetails = StringMayBeEnteredIn(cells, Me.colDrugFormula)
                            .LastUpdate = DateTimeEnteredIn(Me.dtpDischargeDateTime, "Discharge Date Time!")
                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID

                        End With

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lIPDItems.Add(oIPDItems)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    Using oIPDItemsEXT As New SyncSoft.SQLDb.IPDItemsEXT()
                        With oIPDItemsEXT
                            .RoundNo = roundNo
                            .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colDrug))
                            .ItemCategoryID = oItemCategoryID.Drug
                            .Dosage = StringEnteredIn(cells, Me.colDosage)
                            .Duration = IntegerEnteredIn(cells, Me.colDuration)
                            .DrQuantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                        End With
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lIPDItemsEXT.Add(oIPDItemsEXT)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItems, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(lIPDItemsEXT, Action.Save))

                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.dtpDischargeDateTime)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oIPDAlerts As New SyncSoft.SQLDb.IPDAlerts()
                                    With oIPDAlerts

                                        .AlertTypeID = oAlertTypeID.Prescription
                                        .RoundNo = roundNo
                                        .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff!")
                                        .Notes = (rowNo + 1).ToString() + " Prescription(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvPrescription.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SaveNextAppointment()

        Dim oNextAppointment As New NextAppointment()
        Dim oAppointmentPrecisionID As New LookupDataID.AppointmentPrecisionID()

        Try

            Dim appointmentMSG As String = "It’s recommended that you schedule an appointment for the next review date." +
                                            ControlChars.NewLine + "Would you like to schedule next review appointment now?"
            Dim reviewDate As Date = DateEnteredIn(Me.dtpReviewDate)
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim primaryDoctor As String = SubstringLeft(StringMayBeEnteredIn(Me.cboStaffNo))

            If WarningMessage(appointmentMSG) = DialogResult.No Then Return

            With oNextAppointment
                .PatientNo = StringMayBeEnteredIn(Me.stbPatientNo)
                .FullName = StringMayBeEnteredIn(Me.stbFullName)
                .StartDate = reviewDate
                .AppointmentPrecisionID = oAppointmentPrecisionID.Range
                .StartTime = String.Empty
                .Duration = 0
                .EndDate = reviewDate
                .StaffFullName = primaryDoctor
                .AppointmentDes = "Review after discharge"
            End With

            Dim fAppointments As frmAppointments = New frmAppointments(oNextAppointment)
            fAppointments.NextAppointment()
            fAppointments.ShowDialog(Me)

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function RecordSaved(ByVal hideMessage As Boolean) As Boolean

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return True

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim admissionNo As String = StringMayBeEnteredIn(Me.stbAdmissionNo)
            Dim staffNo As String = StringMayBeEnteredIn(Me.cboStaffNo)
            Dim hasDischargeDateTime As Boolean = Me.dtpDischargeDateTime.Checked
            Dim dischargeStatusID As String = StringMayBeEnteredIn(Me.cboDischargeStatusID)
            Dim hasReviewDate As Boolean = Me.dtpReviewDate.Checked
            Dim dischargeNotes As String = StringMayBeEnteredIn(Me.stbDischargeNotes)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(admissionNo) AndAlso (Not String.IsNullOrEmpty(staffNo) OrElse hasDischargeDateTime OrElse
                                                              Not String.IsNullOrEmpty(dischargeStatusID) OrElse hasReviewDate OrElse
                                                              Not String.IsNullOrEmpty(dischargeNotes)) Then
                If Not hideMessage Then DisplayMessage("Please ensure that current discharge record is saved!")
                Me.ebnSaveUpdate.Focus()
                Me.BringToFront()
                If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
                Return False
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return True

        Catch ex As Exception
            Return True

        End Try

    End Function

    Private Sub btnGenerateInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerateInvoice.Click

        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim billMode As String = StringMayBeEnteredIn(Me.stbBillMode)
            Dim cashBillMode As String = GetLookupDataDes(oBillModesID.Cash)

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim fIPDInvoices As New frmIPDInvoices(visitNo)

            If Not billMode.ToUpper().Equals(cashBillMode.ToUpper()) Then fIPDInvoices.ShowDialog()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

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

            ElseIf e.ColumnIndex.Equals(Me.colDosage.Index) Then
                Me.CalculateDrugQuantity(selectedRow, True)
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            ElseIf e.ColumnIndex.Equals(Me.colDuration.Index) Then
                Me.CalculateDrugQuantity(selectedRow, False)
                Me.CalculateDrugAmount(selectedRow)
                Me.CalculateBillForPrescriptions()

            ElseIf e.ColumnIndex.Equals(Me.colDrugQuantity.Index) Then
                'Me.CalculateQuantity()
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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailPrescribedDrug(selectedRow)
            Me.CalculateDrugQuantity(selectedRow, False)
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
            Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim roundNo As String = RevertText(StringEnteredIn(Me.stbRoundNo, "Round No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvPrescription.Item(Me.colDrug.Name, toDeleteRowNo).Value))

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
            With oIPDItems
                .RoundNo = roundNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oIPDItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub DetailPrescribedDrug(ByVal selectedRow As Integer)

        Dim message As String
        Dim drugSelected As String = String.Empty
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            If Me.dgvPrescription.Rows.Count > 1 Then drugSelected = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

            Dim drugNo As String = SubstringRight(drugSelected)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.stbBillNo))

            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
            If drugs Is Nothing OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)

            Dim availableStock As Integer = GetAvailableStock(drugNo)
            Dim unitPrice As Decimal = GetCustomFee(drugNo, oItemCategoryID.Drug, billNo, billModesID, associatedBillNo)
            Dim halted As Boolean = BooleanMayBeEnteredIn(row, "Halted")
            Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(row, "HasAlternateDrugs")

            With Me.dgvPrescription
                .Item(Me.colAvailableStock.Name, selectedRow).Value = availableStock
                .Item(Me.colOrderLevel.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colPrescriptionUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colDrugUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colExpiryDate.Name, selectedRow).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colUnitsInStock.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colPrescriptionGroup.Name, selectedRow).Value = StringMayBeEnteredIn(row, "Group")
                .Item(Me.colAlternateName.Name, selectedRow).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colDrugItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                .Item(Me.colDrugPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                .Item(Me.colHalted.Name, selectedRow).Value = halted
                .Item(Me.colHasAlternateDrugs.Name, selectedRow).Value = hasAlternateDrugs
            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If halted AndAlso hasAlternateDrugs Then
                message = "You have selected a drug that is on halt and has alternatives. " +
                           ControlChars.NewLine + "Would you like to look at its alternatives?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)

            ElseIf availableStock <= 0 AndAlso hasAlternateDrugs Then
                message = "You have selected a drug that is out of stock and has alternatives. " +
                           ControlChars.NewLine + "Would you like to look at its alternatives?"
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculateBillForPrescriptions()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 1

            If IsNumeric(Me.dgvPrescription.Item(Me.colAmount.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvPrescription.Item(Me.colAmount.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub CalculateDrugAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugUnitPrice)

        Me.dgvPrescription.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateDrugQuantity(ByVal selectedRow As Integer, ByVal calculateDuration As Boolean)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oDosageCalculationID As New LookupDataID.DosageCalculationID()

        Try

            Dim quantity As Single = 0
            Dim drugNo As String = SubstringRight(StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug))
            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")

            If drugs Is Nothing OrElse drugs.Rows.Count < 1 OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)

            Dim dosage As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDosage)
            Dim duration As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDuration)

            Dim varyPrescribedQty As Boolean = BooleanEnteredIn(row, "VaryPrescribedQty")
            Dim defaultPrescribedQty As Integer = IntegerEnteredIn(row, "DefaultPrescribedQty")
            Dim dosageSeparator As Char = CChar(StringEnteredIn(row, "DosageSeparator").ToUpper())
            Dim dosageCalculationID As String = StringEnteredIn(row, "DosageCalculationID")
            'Dim dosageFormat As String = StringMayBeEnteredIn(row, "DosageFormat")

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

    Private Sub ShowDrugDetails(ByVal drugNo As String, ByVal pos As Integer)

        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try

            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")

            If drugs Is Nothing OrElse drugNo Is Nothing Then Return
            Dim row As DataRow = drugs.Rows(0)

            With Me.dgvPrescription
                .Item(Me.colAvailableStock.Name, pos).Value = GetAvailableStock(drugNo)
                .Item(Me.colExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colPrescriptionGroup.Name, pos).Value = StringMayBeEnteredIn(row, "Group")
                .Item(Me.colAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colHalted.Name, pos).Value = BooleanMayBeEnteredIn(row, "Halted")
                .Item(Me.colHasAlternateDrugs.Name, pos).Value = BooleanMayBeEnteredIn(row, "HasAlternateDrugs")
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPrescriptions(ByVal roundNo As String)

        Dim oIPDItems As New SyncSoft.SQLDb.IPDItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvPrescription.Rows.Clear()

            ' Load items not yet paid for

            Dim drugs As DataTable = oIPDItems.GetIPDItems(roundNo, oItemCategoryID.Drug).Tables("IPDItems")
            If drugs Is Nothing OrElse drugs.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To drugs.Rows.Count - 1

                Dim row As DataRow = drugs.Rows(pos)
                Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                With Me.dgvPrescription
                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colDosage.Name, pos).Value = StringMayBeEnteredIn(row, "Dosage")
                    .Item(Me.colDuration.Name, pos).Value = IntegerMayBeEnteredIn(row, "Duration")
                    .Item(Me.colDrugQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colPrescriptionUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colDrugUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDrugFormula.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colDrugItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colDrugPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colPrescriptionSaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForPrescriptions()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

    '#Region " Diagnosis - Grid "

    '    Private Sub dgvDiagnosis_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDiagnosis.CellBeginEdit

    '        If e.ColumnIndex <> Me.colDiseaseCode.Index OrElse Me.dgvDiagnosis.Rows.Count <= 1 Then Return
    '        Dim selectedRow As Integer = Me.dgvDiagnosis.CurrentCell.RowIndex
    '        _DiagnosisValue = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

    '    End Sub

    '    Private Sub dgvDiagnosis_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDiagnosis.CellEndEdit

    '        Try

    '            If e.ColumnIndex.Equals(Me.colDiseaseCode.Index) Then

    '                ' Ensure unique entry in the combo column

    '                If Me.dgvDiagnosis.Rows.Count > 1 Then

    '                    Dim selectedRow As Integer = Me.dgvDiagnosis.CurrentCell.RowIndex
    '                    Me.SetDiagnosisEntries(selectedRow)

    '                End If

    '            End If

    '        Catch ex As Exception
    '            ErrorMessage(ex)

    '        End Try

    '    End Sub

    '    Private Sub SetDiagnosisEntries(ByVal selectedRow As Integer)

    '        Try

    '            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

    '            If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, selectedRow).Value).Equals(True) Then
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
    '                Dim diagnosisDisplay As String = (From data In diagnosis
    '                                                  Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(_DiagnosisValue.ToUpper())
    '                                                  Select data.Field(Of String)("DiseaseName")).First()
    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                DisplayMessage("Diagnosis (" + diagnosisDisplay + ") can't be edited!")
    '                Me.dgvDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Value = _DiagnosisValue
    '                Me.dgvDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Selected = True
    '                Return
    '            End If

    '            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 2

    '                If Not rowNo.Equals(selectedRow) Then
    '                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(rowNo).Cells, Me.colDiseaseCode)
    '                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
    '                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                        Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
    '                        Dim enteredDisplay As String = (From data In diagnosis
    '                                                        Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(enteredItem.ToUpper())
    '                                                        Select data.Field(Of String)("DiseaseName")).First()
    '                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                        DisplayMessage("Diagnosis (" + enteredDisplay + ") already entered!")
    '                        Me.dgvDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Value = _DiagnosisValue
    '                        Me.dgvDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Selected = True
    '                        Return
    '                    End If
    '                End If

    '            Next


    '        Catch ex As Exception
    '            Throw ex
    '        End Try

    '    End Sub

    '    Private Sub dgvDiagnosis_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDiagnosis.UserDeletingRow

    '        Try

    '            Me.Cursor = Cursors.WaitCursor

    '            Dim oDiagnosis As New SyncSoft.SQLDb.Diagnosis()
    '            Dim toDeleteRowNo As Integer = e.Row.Index

    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, toDeleteRowNo).Value) = False Then Return

    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''           
    '            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
    '            Dim diagnosis As String = CStr(Me.dgvDiagnosis.Item(Me.colDiseaseCode.Name, toDeleteRowNo).Value)

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            If DeleteMessage() = Windows.Forms.DialogResult.No Then
    '                e.Cancel = True
    '                Return
    '            End If

    '                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '            With oDiagnosis
    '                .VisitNo = visitNo
    '                .DiseaseCode = diagnosis
    '                DisplayMessage(.Delete())
    '            End With

    '            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Catch ex As Exception
    '            ErrorMessage(ex)
    '            e.Cancel = True

    '        Finally
    '            Me.Cursor = Cursors.Default

    '        End Try

    '    End Sub

    '    Private Sub dgvDiagnosis_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDiagnosis.DataError
    '        ErrorMessage(e.Exception)
    '        e.Cancel = True
    '    End Sub

    '    Private Sub LoadDiagnosis(ByVal visitNo As String)

    '        Dim oDiagnosis As New SyncSoft.SQLDb.Diagnosis()

    '        Try

    '            Me.dgvDiagnosis.Rows.Clear()

    '            ' Load items not yet paid for

    '            Dim diagnosis As DataTable = oDiagnosis.GetDiagnosis(RevertText(visitNo)).Tables("Diagnosis")
    '            If diagnosis Is Nothing OrElse diagnosis.Rows.Count < 1 Then Return

    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '            For pos As Integer = 0 To diagnosis.Rows.Count - 1

    '                Dim row As DataRow = diagnosis.Rows(pos)

    '                With Me.dgvDiagnosis
    '                    ' Ensure that you add a new row
    '                    .Rows.Add()
    '                    .Item(Me.colDiseaseCode.Name, pos).Value = StringEnteredIn(row, "DiseaseCode")
    '                    .Item(Me.colICDDiagnosisCode.Name, pos).Value = StringEnteredIn(row, "DiseaseCode")
    '                    .Item(Me.colDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategories")
    '                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
    '                    .Item(Me.colDiagnosisSaved.Name, pos).Value = True
    '                End With
    '            Next

    '            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    '        Catch ex As Exception
    '            Throw ex

    '        End Try

    '    End Sub

    '#End Region

#Region " Discharge Printing "

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()

            Me.SetDischargePrintData()

            With dlgPrintPreview
                .Document = docDischarge
                .Document.PrinterSettings.Collate = True
                .ShowIcon = False
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintDischarge()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintDischarge()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetDischargePrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docDischarge
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docDischarge.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docDischarge_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docDischarge.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Discharge Form".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim gender As String = StringMayBeEnteredIn(Me.stbGender)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim age As String = StringMayBeEnteredIn(Me.stbAge)
            Dim admissionNo As String = StringMayBeEnteredIn(Me.stbAdmissionNo)
            Dim admissionDate As String = FormatDate(DateMayBeEnteredIn(Me.stbAdmissionDateTime))
            Dim dischargeDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpDischargeDateTime))
            Dim reviewDate As String = FormatDate(DateMayBeEnteredIn(Me.dtpReviewDate))
            Dim primaryDoctor As String = SubstringLeft(StringMayBeEnteredIn(Me.cboStaffNo))

            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            Dim insuranceName As String = StringMayBeEnteredIn(Me.stbInsuranceName)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 28 * widthTopFirst

                If pageNo < 2 Then

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Gender/Age: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(gender + "/" + age, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Admission No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(admissionNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Admission Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(admissionDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Discharge Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(dischargeDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Review Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(reviewDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Discharge Doctor: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(primaryDoctor, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)

                    If Not String.IsNullOrEmpty(insuranceName) Then
                        yPos += lineHeight

                        .DrawString("Bill Insurance Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(insuranceName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)

                    End If

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

                If dischargeParagraphs Is Nothing Then Return

                Do While dischargeParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(dischargeParagraphs(1), PrintParagraps)
                    dischargeParagraphs.Remove(1)

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
                        dischargeParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (dischargeParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDischargePrintData()

        Dim footerLEN As Integer = 20
        Dim footerFont As New Font(printFontName, 9)

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oIPDDiagnosis As New SyncSoft.SQLDb.IPDDiagnosis()
        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()

        Try

            pageNo = 0
            dischargeParagraphs = New Collection()

            Dim admissionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAdmissionNo))
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))

            ''''''''''''''''DIAGNOSIS'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim diagnosis As DataTable = oIPDDiagnosis.GetIPDUniqueDiagnosis(admissionNo).Tables("IPDDiagnosis")

            Dim diagnosisTitle As New System.Text.StringBuilder(String.Empty)
            diagnosisTitle.Append(ControlChars.NewLine)
            diagnosisTitle.Append("DIAGNOSIS: ".ToUpper())
            diagnosisTitle.Append(ControlChars.NewLine)
            diagnosisTitle.Append(ControlChars.NewLine)

            Dim tableDiagnosis As New System.Text.StringBuilder(String.Empty)
            tableDiagnosis.Append("No: ".PadRight(padLineNo))
            tableDiagnosis.Append("Diagnosis: ".PadRight(padService))
            tableDiagnosis.Append(ControlChars.NewLine)
            tableDiagnosis.Append(ControlChars.NewLine)

            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, diagnosisTitle.ToString()))
            If diagnosis.Rows.Count > 0 Then
                dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, tableDiagnosis.ToString()))
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.DiagnosisData(diagnosis)))
            Else
                Dim diagnosisEmptyData As New System.Text.StringBuilder(String.Empty)
                diagnosisEmptyData.Append(GetSpaces(10))
                diagnosisEmptyData.Append(GetCharacters("."c, 62))
                diagnosisEmptyData.Append(ControlChars.NewLine)
                dischargeParagraphs.Add(New PrintParagraps(footerFont, diagnosisEmptyData.ToString()))
            End If

            ''''''''''''''''Laboratory'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim laboratory As DataTable = oExtraBillItems.GetUniqueExtraBillItems(visitNo, oItemCategoryID.Test).Tables("ExtraBillItems")

            Dim laboratoryTitle As New System.Text.StringBuilder(String.Empty)
            laboratoryTitle.Append(ControlChars.NewLine)
            laboratoryTitle.Append("LABORATORY: ".ToUpper())
            laboratoryTitle.Append(ControlChars.NewLine)
            laboratoryTitle.Append(ControlChars.NewLine)

            Dim tableLaboratory As New System.Text.StringBuilder(String.Empty)
            tableLaboratory.Append("No: ".PadRight(padLineNo))
            tableLaboratory.Append("Test Name: ".PadRight(padService + padNotes))
            tableLaboratory.Append(ControlChars.NewLine)
            tableLaboratory.Append(ControlChars.NewLine)

            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, laboratoryTitle.ToString()))
            If laboratory.Rows.Count > 0 Then
                dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, tableLaboratory.ToString()))
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.LaboratoryData(laboratory)))
            Else
                Dim laboratoryEmptyData As New System.Text.StringBuilder(String.Empty)
                laboratoryEmptyData.Append(GetSpaces(10))
                laboratoryEmptyData.Append(GetCharacters("."c, 62))
                laboratoryEmptyData.Append(ControlChars.NewLine)
                dischargeParagraphs.Add(New PrintParagraps(footerFont, laboratoryEmptyData.ToString()))
            End If

            ''''''''''''''''Radiology'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim radiology As DataTable = oExtraBillItems.GetUniqueExtraBillItems(visitNo, oItemCategoryID.Radiology).Tables("ExtraBillItems")

            Dim radiologyTitle As New System.Text.StringBuilder(String.Empty)
            radiologyTitle.Append(ControlChars.NewLine)
            radiologyTitle.Append("RADIOLOGY: ".ToUpper())
            radiologyTitle.Append(ControlChars.NewLine)
            radiologyTitle.Append(ControlChars.NewLine)

            Dim tableRadiology As New System.Text.StringBuilder(String.Empty)
            tableRadiology.Append("No: ".PadRight(padLineNo))
            tableRadiology.Append("Radiology Examination: ".PadRight(padService + padNotes))
            tableRadiology.Append(ControlChars.NewLine)
            tableRadiology.Append(ControlChars.NewLine)

            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, radiologyTitle.ToString()))
            If radiology.Rows.Count > 0 Then
                dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, tableRadiology.ToString()))
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.RadiologyData(radiology)))
            Else
                Dim radiologyEmptyData As New System.Text.StringBuilder(String.Empty)
                radiologyEmptyData.Append(GetSpaces(10))
                radiologyEmptyData.Append(GetCharacters("."c, 62))
                radiologyEmptyData.Append(ControlChars.NewLine)
                dischargeParagraphs.Add(New PrintParagraps(footerFont, radiologyEmptyData.ToString()))
            End If

            ''''''''''''''''Medication'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim medication As DataTable = oExtraBillItems.GetUniqueDrugExtraBillItems(visitNo).Tables("ExtraBillItems")

            Dim medicationTitle As New System.Text.StringBuilder(String.Empty)
            medicationTitle.Append(ControlChars.NewLine)
            medicationTitle.Append("MEDICATION: ".ToUpper())
            medicationTitle.Append(ControlChars.NewLine)
            medicationTitle.Append(ControlChars.NewLine)

            Dim tableMedication As New System.Text.StringBuilder(String.Empty)
            tableMedication.Append("No: ".PadRight(padLineNo))
            tableMedication.Append("Drug Name: ".PadRight(padService + padNotes))
            tableMedication.Append(ControlChars.NewLine)
            tableMedication.Append(ControlChars.NewLine)

            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, medicationTitle.ToString()))
            If medication.Rows.Count > 0 Then
                dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, tableMedication.ToString()))
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.MedicationData(medication)))
            Else
                Dim medicationEmptyData As New System.Text.StringBuilder(String.Empty)
                medicationEmptyData.Append(GetSpaces(10))
                medicationEmptyData.Append(GetCharacters("."c, 62))
                medicationEmptyData.Append(ControlChars.NewLine)
                dischargeParagraphs.Add(New PrintParagraps(footerFont, medicationEmptyData.ToString()))
            End If

            ''''''''''''''''Prescription'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim prescriptionTitle As New System.Text.StringBuilder(String.Empty)
            prescriptionTitle.Append(ControlChars.NewLine)
            prescriptionTitle.Append("DISCHARGE PRESCRIPTION: ".ToUpper())
            prescriptionTitle.Append(ControlChars.NewLine)
            prescriptionTitle.Append(ControlChars.NewLine)

            Dim tablePrescription As New System.Text.StringBuilder(String.Empty)
            tablePrescription.Append("No: ".PadRight(padLineNo))
            tablePrescription.Append("Drug Name: ".PadRight(padService))
            tablePrescription.Append("Dosage: ".PadRight(padNotes))
            tablePrescription.Append(ControlChars.NewLine)
            tablePrescription.Append(ControlChars.NewLine)

            If Not String.IsNullOrEmpty(Me.PrescriptionData()) Then
                dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, prescriptionTitle.ToString()))
                If Me.dgvPrescription.RowCount > 1 Then
                    dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, tablePrescription.ToString()))
                End If
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.PrescriptionData()))
            End If

            '''''''''''''''DISCHARGE NOTES'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dischargeNotesTitle As New System.Text.StringBuilder(String.Empty)

            Dim historyTitle As New System.Text.StringBuilder(String.Empty)
            Dim examinationTitle As New System.Text.StringBuilder(String.Empty)
            Dim silentFeaturesTitle As New System.Text.StringBuilder(String.Empty)
            Dim keyFindingsTitle As New System.Text.StringBuilder(String.Empty)
            Dim treamentOnWardTitle As New System.Text.StringBuilder(String.Empty)
            Dim treamentOutComeTitle As New System.Text.StringBuilder(String.Empty)
            Dim keyRecommendationsTitle As New System.Text.StringBuilder(String.Empty)
            Dim otherNotesTitle As New System.Text.StringBuilder(String.Empty)
            Dim notesEmptyData As New System.Text.StringBuilder(String.Empty)
            notesEmptyData.Append(ControlChars.NewLine)
            notesEmptyData.Append(GetCharacters("."c, 65))

            Dim dischargeNotes As String = StringMayBeEnteredIn(Me.stbDischargeNotes)

            Dim history As String = StringMayBeEnteredIn(Me.stbHistory)
            Dim examination As String = StringMayBeEnteredIn(Me.stbExamination)
            Dim keyfindings As String = StringMayBeEnteredIn(Me.stbKeyFindInvestigation)
            Dim treatmentOnWard As String = StringMayBeEnteredIn(Me.stbTreatmentOnWard)
            Dim outComeOfTreatment As String = StringMayBeEnteredIn(Me.stbTreatmentOutcome)
            Dim keyRecommendations As String = StringMayBeEnteredIn(Me.stbKeyRecommendations)

            dischargeNotesTitle.Append(ControlChars.NewLine)
            dischargeNotesTitle.Append("DISCHARGE NOTES: ".ToUpper())
            dischargeNotesTitle.Append(ControlChars.NewLine)
            'dischargeNotesTitle.Append(ControlChars.NewLine)
            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, dischargeNotesTitle.ToString()))

            silentFeaturesTitle.Append(ControlChars.NewLine)
            silentFeaturesTitle.Append("Silent Features at Investigation: ")
            silentFeaturesTitle.Append(ControlChars.NewLine)
            'silentFeaturesTitle.Append(ControlChars.NewLine)
            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, silentFeaturesTitle.ToString()))

            historyTitle.Append("History: ")
            historyTitle.Append(ControlChars.NewLine)
            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, historyTitle.ToString()))
            If Not (String.IsNullOrEmpty(history) Or String.IsNullOrWhiteSpace(history)) Then
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, history))
            Else
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, notesEmptyData.ToString()))
            End If
            dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))

            examinationTitle.Append("Examination: ")
            examinationTitle.Append(ControlChars.NewLine)
            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, examinationTitle.ToString()))
            If Not (String.IsNullOrEmpty(examination) Or String.IsNullOrWhiteSpace(examination)) Then
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, examination))
            Else
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, notesEmptyData.ToString()))
            End If

            dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))

            keyFindingsTitle.Append("Key Findings at Investigation: ")
            keyFindingsTitle.Append(ControlChars.NewLine)
            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, keyFindingsTitle.ToString()))
            If Not (String.IsNullOrEmpty(keyfindings) Or String.IsNullOrWhiteSpace(keyfindings)) Then
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, keyfindings))
            Else
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, notesEmptyData.ToString()))
            End If

            dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))

            treamentOnWardTitle.Append("Treatment While on Ward: ")
            treamentOnWardTitle.Append(ControlChars.NewLine)
            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, treamentOnWardTitle.ToString()))
            If Not (String.IsNullOrEmpty(treatmentOnWard) Or String.IsNullOrWhiteSpace(treatmentOnWard)) Then
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, treatmentOnWard))
            Else
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, notesEmptyData.ToString()))
            End If

            dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))

            treamentOutComeTitle.Append("Out come of Treatment: ")
            treamentOutComeTitle.Append(ControlChars.NewLine)
            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, treamentOutComeTitle.ToString()))
            If Not (String.IsNullOrEmpty(outComeOfTreatment) Or String.IsNullOrWhiteSpace(outComeOfTreatment)) Then
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, outComeOfTreatment))
            Else
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, notesEmptyData.ToString()))
            End If

            dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))

            keyRecommendationsTitle.Append("Key Recommendations: ")
            keyRecommendationsTitle.Append(ControlChars.NewLine)
            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, keyRecommendationsTitle.ToString()))
            If Not (String.IsNullOrEmpty(keyRecommendations) Or String.IsNullOrWhiteSpace(keyRecommendations)) Then
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, keyRecommendations))
            Else
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, notesEmptyData.ToString()))
            End If

            dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))

            otherNotesTitle.Append("Other Notes: ")
            otherNotesTitle.Append(ControlChars.NewLine)
            dischargeParagraphs.Add(New PrintParagraps(bodyBoldFont, otherNotesTitle.ToString()))
            If Not (String.IsNullOrEmpty(dischargeNotes) Or String.IsNullOrWhiteSpace(dischargeNotes)) Then
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, dischargeNotes))
            Else
                dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, notesEmptyData.ToString()))
            End If

            dischargeParagraphs.Add(New PrintParagraps(bodyNormalFont, ControlChars.NewLine))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim doctorSignData As New System.Text.StringBuilder(String.Empty)
            doctorSignData.Append(ControlChars.NewLine)
            doctorSignData.Append(ControlChars.NewLine)

            doctorSignData.Append("Doctor's Sign:   " + GetCharacters("."c, 22))
            doctorSignData.Append(GetSpaces(4))
            doctorSignData.Append("Date:  " + GetCharacters("."c, 22))
            doctorSignData.Append(ControlChars.NewLine)
            dischargeParagraphs.Add(New PrintParagraps(footerFont, doctorSignData.ToString()))

            ''''''''''''''''FOOTER DATA''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                                Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            dischargeParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Public Function DiagnosisData(ByVal diagnosis As DataTable) As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer
            Dim padDiagnosis As Integer = padService + padNotes

            For Each row As DataRow In diagnosis.Rows

                line += 1

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim lineNo As String = (line).ToString()
                Dim diseaseName As String = StringEnteredIn(row, "DiseaseName")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(lineNo.PadRight(padLineNo))

                Dim wrappedDiagnosisDisplay As List(Of String) = WrapText(diseaseName, padDiagnosis)
                If wrappedDiagnosisDisplay.Count > 1 Then

                    For pos As Integer = 0 To wrappedDiagnosisDisplay.Count - 1
                        tableData.Append(FixDataLength(wrappedDiagnosisDisplay(pos).Trim(), padDiagnosis))
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(GetSpaces(padLineNo))
                    Next
                Else : tableData.Append(FixDataLength(diseaseName, padDiagnosis))
                End If

                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function LaboratoryData(ByVal laboratory As DataTable) As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer
            Dim padLabTest As Integer

            padLabTest = padService + padNotes

            For Each row As DataRow In laboratory.Rows

                line += 1

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim lineNo As String = (line).ToString()
                Dim itemName As String = StringEnteredIn(row, "ItemName")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(lineNo.PadRight(padLineNo))

                Dim wrappedItemName As List(Of String) = WrapText(itemName, padLabTest)

                If wrappedItemName.Count > 1 Then
                    For pos As Integer = 0 To wrappedItemName.Count - 1
                        tableData.Append(FixDataLength(wrappedItemName(pos).Trim(), padLabTest))
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(GetSpaces(padLineNo))
                    Next
                Else : tableData.Append(FixDataLength(itemName, padLabTest))
                End If

                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function RadiologyData(ByVal radiology As DataTable) As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer
            Dim padRadiology As Integer

            padRadiology = padService + padNotes

            For Each row As DataRow In radiology.Rows

                line += 1

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim lineNo As String = (line).ToString()
                Dim itemName As String = StringEnteredIn(row, "ItemName")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(lineNo.PadRight(padLineNo))

                Dim wrappedItemName As List(Of String) = WrapText(itemName, padRadiology)

                If wrappedItemName.Count > 1 Then
                    For pos As Integer = 0 To wrappedItemName.Count - 1
                        tableData.Append(FixDataLength(wrappedItemName(pos).Trim(), padRadiology))
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(GetSpaces(padLineNo))
                    Next
                Else : tableData.Append(FixDataLength(itemName, padRadiology))
                End If

                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function MedicationData(ByVal medication As DataTable) As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer
            Dim padMedication As Integer

            padMedication = padService + padNotes

            For Each row As DataRow In medication.Rows

                line += 1

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim lineNo As String = (line).ToString()
                Dim itemName As String = StringEnteredIn(row, "ItemName")

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(lineNo.PadRight(padLineNo))

                Dim wrappedItemName As List(Of String) = WrapText(itemName, padMedication)

                If wrappedItemName.Count > 1 Then
                    For pos As Integer = 0 To wrappedItemName.Count - 1
                        tableData.Append(FixDataLength(wrappedItemName(pos).Trim(), padMedication))
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(GetSpaces(padLineNo))
                    Next
                Else : tableData.Append(FixDataLength(itemName, padMedication))
                End If

                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function PrescriptionData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim line As Integer

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                line += 1

                Dim lineNo As String = (line).ToString()
                Dim itemName As String = SubstringLeft(StringMayBeEnteredIn(cells, Me.colDrug))
                Dim dosage As String = StringMayBeEnteredIn(cells, Me.colDosage)
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colDrugFormula)
                Dim duration As String = StringMayBeEnteredIn(cells, Me.colDuration)

                Dim fullDosage As String
                If String.IsNullOrEmpty(notes) Then
                    If duration.Trim().Equals("0") Then
                        fullDosage = dosage
                    ElseIf duration.Trim().Equals("1") Then
                        fullDosage = dosage + " for " + duration + " day"
                    Else : fullDosage = dosage + " for " + duration + " days"
                    End If
                Else
                    If duration.Trim().Equals("0") Then
                        fullDosage = dosage + " (" + notes + ")"
                    ElseIf duration.Trim().Equals("1") Then
                        fullDosage = dosage + " (" + notes + ")" + " for " + duration + " day"
                    Else : fullDosage = dosage + " (" + notes + ")" + " for " + duration + " days"
                    End If
                End If

                tableData.Append(lineNo.PadRight(padLineNo))
                tableData.Append(itemName.PadRight(padService))

                Dim wrappedfullDosage As List(Of String) = WrapText(fullDosage, padNotes)
                If wrappedfullDosage.Count > 1 Then
                    For pos As Integer = 0 To wrappedfullDosage.Count - 1
                        tableData.Append(FixDataLength(wrappedfullDosage(pos).Trim(), padNotes))
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(GetSpaces(padLineNo + padService))
                    Next
                Else : tableData.Append(FixDataLength(fullDosage, padNotes))
                End If
                tableData.Append(ControlChars.NewLine)

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region " Popup Menu "

    Private Sub cmsDischarges_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsDischarges.Opening

        Select Case Me.tbcDrRoles.SelectedTab.Name

            Case Me.tpgPrescriptions.Name
                Me.cmsDischargesQuickSearch.Visible = True

            Case Else : Me.cmsDischargesQuickSearch.Visible = False

        End Select

    End Sub

    Private Sub cmsDischargesQuickSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsDischargesQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rowIndex As Integer

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgPrescriptions.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Drugs", Me.dgvPrescription, Me.colDrug)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvPrescription.NewRowIndex
                    If rowIndex > 0 Then Me.SetDrugsEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return
        ''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        Me.ebnSaveUpdate.Enabled = False
        'Me.fbnDelete.Visible = True
        'Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.stbRoundNo.ReadOnly = True

        Me.dtpDischargeDateTime.Enabled = False
        Me.dtpReviewDate.Enabled = False
        Me.dtpReviewDate.MinDate = AppData.NullDateValue
        Me.btnLoad.Enabled = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgDischargeNotes)
        ResetControlsIn(Me.tpgPrescriptions)
        ResetControlsIn(Me.pnlBill)

        Me.chkPrintDischargeReportOnSaving.Visible = False
        Me.chkPrintDischargeReportOnSaving.Checked = False

        Me.btnPrintPreview.Enabled = False
        Me.btnPrint.Enabled = False

    End Sub

    Public Sub Save()

        ''''''''''''''''''''''''''''''''''''''''''''''''''''
        If Not Me.RecordSaved(False) Then Return
        ''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        'Me.fbnDelete.Visible = False
        'Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.stbRoundNo.ReadOnly = InitOptions.RoundNoLocked

        Me.dtpDischargeDateTime.Enabled = True
        Me.dtpReviewDate.Enabled = True
        Me.dtpReviewDate.MinDate = Today
        Me.btnLoad.Enabled = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgDischargeNotes)
        ResetControlsIn(Me.tpgPrescriptions)
        ResetControlsIn(Me.pnlBill)

        Me.chkPrintDischargeReportOnSaving.Visible = True
        Me.chkPrintDischargeReportOnSaving.Checked = True

        Me.btnPrintPreview.Enabled = False
        Me.btnPrint.Enabled = False

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



    Private Sub cboDischargeStatusID_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboDischargeStatusID.SelectedIndexChanged
        Dim dischargeStatusID As String = StringValueMayBeEnteredIn(cboDischargeStatusID)

        If dischargeStatusID.ToUpper().Equals(oDischargeStatus.Deceased.ToUpper()) Then
            Me.dtpReviewDate.Checked = False
            Me.dtpReviewDate.Enabled = False

        Else
            Me.dtpReviewDate.Enabled = True
            Me.dtpReviewDate.Checked = False
        End If
    End Sub
End Class