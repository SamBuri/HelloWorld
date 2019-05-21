
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Imports System.Text
Imports System.Collections.Generic
Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona

Public Class frmHIVCARE

#Region " Fields "
    Private defaultKeyNo As String = String.Empty
    Private patientsKeyNo As ItemsKeyNo
    Private oCurrentPatient As CurrentPatient

    Private allergies As DataTable
    Private _MemberNameValue As String = String.Empty
    Private _InfantNameValue As String = String.Empty
    Private _PriorARTIDValue As String = String.Empty
    Private _AllergyNoValue As String = String.Empty
    Private tipOutstandingBalanceWords As New ToolTip()
    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()

    Private oVariousOptions As New VariousOptions()
#End Region


    Private Sub frmHIVCARE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()
            Me.ClearControls()

            Me.LoadStaff()
            Me.LoadDrugCombinations()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboDistrictsID, LookupObjects.Districts, False)
            LoadLookupDataCombo(Me.cboWHOStageID, LookupObjects.WHOStage, False)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.colPriorARTID, LookupObjects.PriorART, False)
            LoadLookupDataCombo(Me.colHIVStatusID, LookupObjects.HIVStatus, False)
            LoadLookupDataCombo(Me.colHIVCareID, LookupObjects.YesNo, False)

            LoadLookupDataCombo(Me.colTestResultsID, LookupObjects.TestResults, False)
            LoadLookupDataCombo(Me.colInfantFeedingID, LookupObjects.InfantFeeding, False)
            LoadLookupDataCombo(Me.colHIVTestTypeID, LookupObjects.HIVTestType, False)
            LoadLookupDataCombo(Me.colInfantStatusID, LookupObjects.InfantStatus, False)

            LoadLookupDataCombo(Me.cboStartARTWHOStageID, LookupObjects.WHOStage, False)
            LoadLookupDataCombo(Me.cboPregnancyStatusID, LookupObjects.PregnancyStatus, False)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
          If Not String.IsNullOrEmpty(defaultKeyNo) AndAlso patientsKeyNo = ItemsKeyNo.PatientNo Then
                Me.ShowPatientDetails(defaultKeyNo)
                Me.stbPatientNo.ReadOnly = True
                Security.Apply(Me.ebnSaveUpdate, AccessRights.Write)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmHIVCARE_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oHIVCARE As New SyncSoft.SQLDb.HIVCARE()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oHIVCARE.PatientNo = StringEnteredIn(Me.stbPatientNo, "Patient No!")

            DisplayMessage(oHIVCARE.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub btnLoad_Click(sender As System.Object, e As System.EventArgs) Handles btnLoad.Click
        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbPatientNo)
            fQuickSearch.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub btnFindPatientNo_Click(sender As System.Object, e As System.EventArgs) Handles btnFindPatientNo.Click

        Try


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim fFindObject As New frmFindObject(ObjectName.PatientNo)

            If fFindObject.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim patientNo As String = RevertText(fFindObject.GetPatientNo())
                Me.stbPatientNo.Text = patientNo
                Me.ShowPatientDetails(patientNo)
            End If

        Catch eX As Exception
            ErrorMessage(eX)
            Me.btnFindPatientNo.PerformClick()

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub ShowPatientDetails(ByVal patientNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()
        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()
        Dim oAccessCashServices As New SyncSoft.SQLDb.AccessedCashServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Dim birthDate As Date = DateMayBeEnteredIn(row, "BirthDate")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbPhone.Text = StringMayBeEnteredIn(row, "Phone")
            Me.stbReferenceNo.Text = StringMayBeEnteredIn(row, "ReferenceNo")
            Me.spbPhoto.Image = ImageMayBeEnteredIn(row, "Photo")
            Me.stbLastVisitDate.Text = FormatDate(DateMayBeEnteredIn(row, "LastVisitDate"))
            Me.stbTotalVisits.Text = StringEnteredIn(row, "TotalVisits")
            Me.stbInsuranceNo.Text = StringMayBeEnteredIn(row, "InsuranceNo")
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            Dim outstandingBalance As Decimal = DecimalMayBeEnteredIn(row, "OutstandingBalance")
            Me.nbxOutstandingBalance.Value = FormatNumber(outstandingBalance, AppData.DecimalPlaces)
            Me.tipOutstandingBalanceWords.SetToolTip(Me.nbxOutstandingBalance, NumberToWords(outstandingBalance))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbPhone.Clear()
        Me.stbLastVisitDate.Clear()
        Me.stbTotalVisits.Clear()
        Me.nbxOutstandingBalance.Value = String.Empty
        ErrProvider.SetError(Me.nbxOutstandingBalance, String.Empty)
        Me.spbPhoto.Image = Nothing
        Me.tipOutstandingBalanceWords.RemoveAll()
        Me.chkFingerprintCaptured.Checked = False
        Me.stbPtClinic.Clear()
        Me.stbLC1.Clear()
    End Sub

    Private Sub stbPatientNo_Leave(sender As Object, e As System.EventArgs) Handles stbPatientNo.Leave
        Try

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If String.IsNullOrEmpty(patientNo) Then Return
            Me.ShowPatientDetails(patientNo)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub stbPatientNo_TextChanged(sender As System.Object, e As System.EventArgs) Handles stbPatientNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()


    End Sub

    Private Sub cboDistrictsID_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboDistrictsID.SelectedIndexChanged
        Try

            If Me.cboDistrictsID.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboDistrictsID.SelectedValue.ToString()) Then Return

            Dim districtsID As String = StringValueEnteredIn(Me.cboDistrictsID, "District!")
            If String.IsNullOrEmpty(districtsID) Then Return

            Me.LoadHealthUnits(districtsID)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try
    End Sub

    Private Sub btnEnrollFingerprint_Click(sender As System.Object, e As System.EventArgs) Handles btnEnrollFingerprint.Click
        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientFingerprints As DataTable = GetPatientFingerprints()

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then

                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Verify, patientFingerprints, "PatientNo")
                fFingerprintCapture.ShowDialog()

                Dim patientNo As String = Me.oCrossMatchTemplate.ID
                If Me.oCrossMatchTemplate.Fingerprint Is Nothing OrElse String.IsNullOrEmpty(patientNo) Then Return
                Me.ShowPatientDetails(patientNo)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then

                Dim fVerification As New Verification(patientFingerprints, "PatientNo")
                fVerification.ShowDialog()

                If Not String.IsNullOrEmpty(Me.oDigitalPersonaTemplate.ID) Then Me.ShowPatientDetails(Me.oDigitalPersonaTemplate.ID)

            End If

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim patientNo As String

        Dim oHIVCARE As New SyncSoft.SQLDb.HIVCARE()

        Try
            Me.Cursor = Cursors.WaitCursor()

            patientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            Dim dataSource As DataTable = oHIVCARE.GetHIVCARE(patientNo).Tables("HIVCARE")
            Me.DisplayData(dataSource)
            Me.LoadFamilyMembers(patientNo)
            Me.LoadExposedInfants(patientNo)
            Me.LoadPriorARTDetails(patientNo)
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")


        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click
        Dim transactions As New List(Of TransactionList(Of DBConnect))
        Dim records As Integer
        Dim oHIVCARE As New SyncSoft.SQLDb.HIVCARE()
        Dim oPatients As New SyncSoft.SQLDb.Patients
        Dim lHIVCARE As New List(Of DBConnect)
        Try
            Me.Cursor = Cursors.WaitCursor()

            With oHIVCARE

                .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
                .HealthUnit = StringValueEnteredIn(Me.cboHealthUnitCode, "HealthUnit!")
                .TeamLeader = SubstringRight(Me.cboStaffNo.Text)
                .PtClinic = StringEnteredIn(Me.stbPtClinic, "Pt Clinic!")
                .LC1 = StringEnteredIn(Me.stbLC1, "LC1!")
                If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                    Me.tbcPatientsEXTRA.SelectTab(Me.tpgHIVCare.Name)
                End If
                .ConfirmedTestDate = DateMayBeEnteredIn(Me.dtpConfirmedTestDate)
                .HIVEnrolledDate = DateMayBeEnteredIn(Me.dtpHIVEnrolledDate)
                .EligibleARTDate = DateMayBeEnteredIn(Me.dtpEligibleARTDate)
                .EligibleReadyDate = DateMayBeEnteredIn(Me.dtpEligibleReadyDate)
                .Ab = Me.chkAb.Checked
                .PCR = Me.chkPCR.Checked
                .HIVCareWhere = StringMayBeEnteredIn(Me.stbHIVCareWhere)
                .HIVCareTransferIn = Me.chkHIVCareTransferIn.Checked
                .TransferInFrom = StringMayBeEnteredIn(Me.stbTransferInFrom)
                .WHOStageID = StringValueEnteredIn(Me.cboWHOStageID, "WHO Stage!")
                .CD4 = SingleMayBeEnteredIn(Me.nbxCD4, -1)
                .PresumptiveHIV = Me.chkPresumptiveHIV.Checked
                .PCRInfant = Me.chkPCRInfant.Checked
                .MedicalConditions = StringMayBeEnteredIn(Me.stbMedicalConditions)

                If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                    Me.tbcPatientsEXTRA.SelectTab(Me.tpgARTCare.Name)
                End If
                .COHORTMonth = GetMonthNumber(StringMayBeEnteredIn(Me.cboCOHORTMonth))
                .COHORTYear = IntegerMayBeEnteredIn(Me.cboCOHORTYear, -1)
                .ARTTransferInDate = DateMayBeEnteredIn(Me.dtpARTTransferInDate)
                .ARTTransferInFrom = StringMayBeEnteredIn(Me.stbARTTransferInFrom)
                .TransferInRegimen = StringMayBeEnteredIn(Me.cboTransferInRegimen)
                .StartARTDate = DateMayBeEnteredIn(Me.dtpStartARTDate)
                .StartARTRegimen = StringMayBeEnteredIn(Me.cboStartARTRegimen)
                .StartARTWeight = SingleMayBeEnteredIn(Me.nbxStartARTWeight, -1)
                .StartARTWHOStageID = StringValueEnteredIn(Me.cboStartARTWHOStageID, "Start ART WHO Stage!")
                .StartARTCD4 = SingleMayBeEnteredIn(Me.nbxStartARTCD4, -1)
                .PregnancyStatusID = StringValueEnteredIn(Me.cboPregnancyStatusID, "Pregnancy Status!")
                .LoginID = CurrentUser.LoginID
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lHIVCARE.Add(oHIVCARE)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lHIVCARE, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(FamilyMembersList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ExposedInfantsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PriorARTDetailsList, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)

                    Dim saveMSG As String = "Patient No : " + FormatText(stbPatientNo.Text, "Patients", "PatientNo") +
                                            " (" + stbFullName.Text + ")  was successfully enrolled to the ART Clinic "
                    MessageBox.Show(saveMSG, AppData.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ResetControlsIn(Me.tpgGeneral)
                    ResetControlsIn(Me.tpgFamilyMembers)
                    ResetControlsIn(Me.tpgExposedInfants)
                    ResetControlsIn(Me.tpgPriorARTDetails)
                    ResetControlsIn(Me.tpgHIVCare)
                    ResetControlsIn(Me.tpgMedicalConditions)
                    ResetControlsIn(Me.tpgARTCare)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To Me.dgvFamilyMembers.RowCount - 2
                        Me.dgvFamilyMembers.Item(Me.colFamilyMembersSaved.Name, rowNo).Value = True
                    Next

                    For rowNo As Integer = 0 To Me.dgvExposedInfants.RowCount - 2
                        Me.dgvExposedInfants.Item(Me.colExposedInfantsSaved.Name, rowNo).Value = True
                    Next

                    For rowNo As Integer = 0 To Me.dgvExposedInfants.RowCount - 2
                        Me.dgvExposedInfants.Item(Me.colExposedInfantsSaved.Name, rowNo).Value = True
                    Next

                    For rowNo As Integer = 0 To Me.dgvPriorARTDetails.RowCount - 2
                        Me.dgvPriorARTDetails.Item(Me.colPriorARTDetailsSaved.Name, rowNo).Value = True
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Case ButtonCaption.Update

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lHIVCARE, Action.Update))
                    transactions.Add(New TransactionList(Of DBConnect)(FamilyMembersList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ExposedInfantsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PriorARTDetailsList, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)

                    Dim saveMSG As String = "Patient No : " + FormatText(stbPatientNo.Text, "Patients", "PatientNo") +
                                            " (" + stbFullName.Text + ")  was successfully updated "
                    MessageBox.Show(saveMSG, AppData.AppTitle, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    ResetControlsIn(Me.tpgGeneral)
                    ResetControlsIn(Me.tpgFamilyMembers)
                    ResetControlsIn(Me.tpgExposedInfants)
                    ResetControlsIn(Me.tpgPriorARTDetails)
                    ResetControlsIn(Me.tpgHIVCare)
                    ResetControlsIn(Me.tpgMedicalConditions)
                    ResetControlsIn(Me.tpgARTCare)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    For rowNo As Integer = 0 To Me.dgvFamilyMembers.RowCount - 2
                        Me.dgvFamilyMembers.Item(Me.colFamilyMembersSaved.Name, rowNo).Value = True
                    Next

                    For rowNo As Integer = 0 To Me.dgvExposedInfants.RowCount - 2
                        Me.dgvExposedInfants.Item(Me.colExposedInfantsSaved.Name, rowNo).Value = True
                    Next

                    For rowNo As Integer = 0 To Me.dgvExposedInfants.RowCount - 2
                        Me.dgvExposedInfants.Item(Me.colExposedInfantsSaved.Name, rowNo).Value = True
                    Next

                    For rowNo As Integer = 0 To Me.dgvPriorARTDetails.RowCount - 2
                        Me.dgvPriorARTDetails.Item(Me.colPriorARTDetailsSaved.Name, rowNo).Value = True
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub LoadHealthUnits(ByVal districtsID As String)

        Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from HealthUnits
            Dim healthUnits As DataTable = oHealthUnits.GetHealthUnitsByDistrictsID(districtsID).Tables("HealthUnits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboHealthUnitCode.Sorted = False
            Me.cboHealthUnitCode.DataSource = healthUnits
            Me.cboHealthUnitCode.DisplayMember = "HealthUnitName"
            Me.cboHealthUnitCode.ValueMember = "HealthUnitCode"

            Me.cboHealthUnitCode.SelectedIndex = -1
            Me.cboHealthUnitCode.SelectedIndex = -1
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadStaff()

        Dim oStaff As New SyncSoft.SQLDb.Staff()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Staff
            Dim staff As DataTable = oStaff.GetStaff().Tables("Staff")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadDrugCombinations()

        Dim oDrugCombinations As New SyncSoft.SQLDb.DrugCombinations()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Drug Combinatios
            Dim drugCombinations As DataTable = oDrugCombinations.GetDrugCombinations().Tables("DrugCombinations")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colCombination, drugCombinations, "Combination")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboTransferInRegimen, drugCombinations, "Combination")
            Me.cboTransferInRegimen.Items.Insert(0, "")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStartARTRegimen, drugCombinations, "Combination")
            Me.cboStartARTRegimen.Items.Insert(0, "")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function FamilyMembersList() As List(Of DBConnect)

        Dim lFamilyMembers As New List(Of DBConnect)

        Try

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

            For rowNo As Integer = 0 To Me.dgvFamilyMembers.RowCount - 2

                Using oFamilyMembers As New SyncSoft.SQLDb.FamilyMembers()

                    Dim cells As DataGridViewCellCollection = Me.dgvFamilyMembers.Rows(rowNo).Cells

                    With oFamilyMembers

                        .PatientNo = patientNo
                        .MemberName = StringEnteredIn(cells, Me.colMemberName, "Member Name!")
                        .Age = ShortEnteredIn(cells, Me.colAge)
                        .HIVStatusID = StringEnteredIn(cells, Me.colHIVStatusID)
                        .HIVCareID = StringEnteredIn(cells, Me.colHIVCareID)
                        .UniqueNo = StringMayBeEnteredIn(cells, Me.colFamilyMembersUniqueNo)

                    End With

                    lFamilyMembers.Add(oFamilyMembers)

                End Using

            Next

            Return lFamilyMembers

        Catch ex As Exception
            Me.tbcPatientsEXTRA.SelectTab(Me.tpgFamilyMembers.Name)
            Throw ex

        End Try

    End Function

    Private Function ExposedInfantsList() As List(Of DBConnect)

        Dim lExposedInfants As New List(Of DBConnect)

        Try

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

            For rowNo As Integer = 0 To Me.dgvExposedInfants.RowCount - 2

                Using oExposedInfants As New SyncSoft.SQLDb.ExposedInfants()

                    Dim cells As DataGridViewCellCollection = Me.dgvExposedInfants.Rows(rowNo).Cells

                    With oExposedInfants

                        .PatientNo = patientNo
                        .InfantName = StringEnteredIn(cells, Me.colInfantName, "Infant Name!")
                        .BirthDate = DateEnteredIn(cells, Me.colBirthDate)
                        .InfantFeedingID = StringEnteredIn(cells, Me.colInfantFeedingID)
                        .CTXStarted = StringEnteredIn(cells, Me.colCTXStarted)
                        .HIVTestTypeID = StringEnteredIn(cells, Me.colHIVTestTypeID)
                        .TestResultsID = StringEnteredIn(cells, Me.colTestResultsID)
                        .InfantStatusID = StringEnteredIn(cells, Me.colInfantStatusID)
                        .UniqueNo = StringMayBeEnteredIn(cells, Me.colExposedInfantsUniqueNo)

                    End With

                    lExposedInfants.Add(oExposedInfants)

                End Using

            Next

            Return lExposedInfants

        Catch ex As Exception
            Me.tbcPatientsEXTRA.SelectTab(Me.tpgExposedInfants.Name)
            Throw ex

        End Try

    End Function

    Private Function PriorARTDetailsList() As List(Of DBConnect)

        Dim lPriorARTDetails As New List(Of DBConnect)

        Try

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

            For rowNo As Integer = 0 To Me.dgvPriorARTDetails.RowCount - 2
                Using oPriorARTDetails As New SyncSoft.SQLDb.PriorARTDetails()
                    Dim cells As DataGridViewCellCollection = Me.dgvPriorARTDetails.Rows(rowNo).Cells
                    With oPriorARTDetails
                        .PatientNo = patientNo
                        .PriorARTID = StringEnteredIn(cells, Me.colPriorARTID, "Prior ART!")
                        .ARTDate = DateEnteredIn(cells, Me.colARTDate)
                        .ARTWhere = StringEnteredIn(cells, Me.colARTWhere)
                        .Combination = StringEnteredIn(cells, Me.colCombination)
                    End With
                    lPriorARTDetails.Add(oPriorARTDetails)
                End Using
            Next

            Return lPriorARTDetails

        Catch ex As Exception
            Me.tbcPatientsEXTRA.SelectTab(Me.tpgPriorARTDetails.Name)
            Throw ex

        End Try

    End Function

#Region " FamilyMembers - Grid "

    Private Sub dgvFamilyMembers_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvFamilyMembers.CellBeginEdit
        If e.ColumnIndex <> Me.colMemberName.Index OrElse Me.dgvFamilyMembers.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvFamilyMembers.CurrentCell.RowIndex
        _MemberNameValue = StringMayBeEnteredIn(Me.dgvFamilyMembers.Rows(selectedRow).Cells, Me.colMemberName)
    End Sub

    Private Sub dgvFamilyMembers_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvFamilyMembers.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colMemberName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvFamilyMembers.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvFamilyMembers.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvFamilyMembers.Rows(selectedRow).Cells, Me.colMemberName)

                    If CBool(Me.dgvFamilyMembers.Item(Me.colFamilyMembersSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Member Name (" + _MemberNameValue + ") can't be edited!")
                        Me.dgvFamilyMembers.Item(Me.colMemberName.Name, selectedRow).Value = _MemberNameValue
                        Me.dgvFamilyMembers.Item(Me.colMemberName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvFamilyMembers.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvFamilyMembers.Rows(rowNo).Cells, Me.colMemberName)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Member Name (" + enteredItem + ") already entered!")
                                Me.dgvFamilyMembers.Item(Me.colMemberName.Name, selectedRow).Value = _MemberNameValue
                                Me.dgvFamilyMembers.Item(Me.colMemberName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvFamilyMembers_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvFamilyMembers.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oFamilyMembers As New SyncSoft.SQLDb.FamilyMembers()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvFamilyMembers.Item(Me.colFamilyMembersSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            Dim memberName As String = CStr(Me.dgvFamilyMembers.Item(Me.colMemberName.Name, toDeleteRowNo).Value)

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
            With oFamilyMembers
                .PatientNo = patientNo
                .MemberName = memberName
            End With

            DisplayMessage(oFamilyMembers.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadFamilyMembers(ByVal PatientNo As String)

        Dim familyMembers As New DataTable()
        Dim oFamilyMembers As New SyncSoft.SQLDb.FamilyMembers()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load items not yet paid for

            familyMembers = oFamilyMembers.GetFamilyMembers(RevertText(PatientNo)).Tables("FamilyMembers")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvFamilyMembers, familyMembers)

            For Each row As DataGridViewRow In Me.dgvFamilyMembers.Rows
                If row.IsNewRow Then Exit For
                Me.dgvFamilyMembers.Item(Me.colFamilyMembersSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " ExposedInfants - Grid "

    Private Sub dgvExposedInfants_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvExposedInfants.CellBeginEdit
        If e.ColumnIndex <> Me.colInfantName.Index OrElse Me.dgvExposedInfants.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvExposedInfants.CurrentCell.RowIndex
        _InfantNameValue = StringMayBeEnteredIn(Me.dgvExposedInfants.Rows(selectedRow).Cells, Me.colInfantName)
    End Sub

    Private Sub dgvExposedInfants_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExposedInfants.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colInfantName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvExposedInfants.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvExposedInfants.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvExposedInfants.Rows(selectedRow).Cells, Me.colInfantName)

                    If CBool(Me.dgvExposedInfants.Item(Me.colExposedInfantsSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Infant Name (" + _InfantNameValue + ") can't be edited!")
                        Me.dgvExposedInfants.Item(Me.colInfantName.Name, selectedRow).Value = _InfantNameValue
                        Me.dgvExposedInfants.Item(Me.colInfantName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvExposedInfants.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvExposedInfants.Rows(rowNo).Cells, Me.colInfantName)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Infant Name (" + enteredItem + ") already entered!")
                                Me.dgvExposedInfants.Item(Me.colInfantName.Name, selectedRow).Value = _InfantNameValue
                                Me.dgvExposedInfants.Item(Me.colInfantName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvExposedInfants_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvExposedInfants.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oExposedInfants As New SyncSoft.SQLDb.ExposedInfants()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvExposedInfants.Item(Me.colExposedInfantsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            Dim InfantName As String = CStr(Me.dgvExposedInfants.Item(Me.colInfantName.Name, toDeleteRowNo).Value)

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
            With oExposedInfants
                .PatientNo = patientNo
                .InfantName = InfantName
            End With

            DisplayMessage(oExposedInfants.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadExposedInfants(ByVal PatientNo As String)

        Dim oExposedInfants As New SyncSoft.SQLDb.ExposedInfants()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load items not yet paid for

            Dim exposedInfants As DataTable = oExposedInfants.GetExposedInfants(RevertText(PatientNo)).Tables("ExposedInfants")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvExposedInfants, exposedInfants)

            For Each row As DataGridViewRow In Me.dgvExposedInfants.Rows
                If row.IsNewRow Then Exit For
                Me.dgvExposedInfants.Item(Me.colExposedInfantsSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " PriorARTDetails - Grid "

    Private Sub dgvPriorARTDetails_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPriorARTDetails.CellBeginEdit
        If e.ColumnIndex <> Me.colPriorARTID.Index OrElse Me.dgvPriorARTDetails.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPriorARTDetails.CurrentCell.RowIndex
        _PriorARTIDValue = StringMayBeEnteredIn(Me.dgvPriorARTDetails.Rows(selectedRow).Cells, Me.colPriorARTID)
    End Sub

    Private Sub dgvPriorARTDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPriorARTDetails.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colPriorARTID.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvPriorARTDetails.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvPriorARTDetails.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPriorARTDetails.Rows(selectedRow).Cells, Me.colPriorARTID)

                    If CBool(Me.dgvPriorARTDetails.Item(Me.colPriorARTDetailsSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Infant Name (" + _PriorARTIDValue + ") can't be edited!")
                        Me.dgvPriorARTDetails.Item(Me.colPriorARTID.Name, selectedRow).Value = _PriorARTIDValue
                        Me.dgvPriorARTDetails.Item(Me.colPriorARTID.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvPriorARTDetails.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPriorARTDetails.Rows(rowNo).Cells, Me.colPriorARTID)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Infant Name (" + enteredItem + ") already entered!")
                                Me.dgvPriorARTDetails.Item(Me.colPriorARTID.Name, selectedRow).Value = _PriorARTIDValue
                                Me.dgvPriorARTDetails.Item(Me.colPriorARTID.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvPriorARTDetails_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPriorARTDetails.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPriorARTDetails As New SyncSoft.SQLDb.PriorARTDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPriorARTDetails.Item(Me.colPriorARTDetailsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))
            Dim priorARTID As String = CStr(Me.dgvPriorARTDetails.Item(Me.colPriorARTID.Name, toDeleteRowNo).Value)

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
            With oPriorARTDetails
                .PatientNo = patientNo
                .PriorARTID = priorARTID
            End With

            DisplayMessage(oPriorARTDetails.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPriorARTDetails(ByVal PatientNo As String)

        Dim oPriorARTDetails As New SyncSoft.SQLDb.PriorARTDetails()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load items not yet paid for

            Dim priorARTDetails As DataTable = oPriorARTDetails.GetPriorARTDetails(RevertText(PatientNo)).Tables("PriorARTDetails")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPriorARTDetails, priorARTDetails)

            For Each row As DataGridViewRow In Me.dgvPriorARTDetails.Rows
                If row.IsNewRow Then Exit For
                Me.dgvPriorARTDetails.Item(Me.colPriorARTDetailsSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

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


End Class