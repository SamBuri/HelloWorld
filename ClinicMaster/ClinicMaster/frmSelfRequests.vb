
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID
Imports SyncSoft.Common.Win.Forms.CrossMatch
Imports SyncSoft.Common.Win.Forms.DigitalPersona
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports SyncSoft.Common.Utilities.Fingerprint.CrossMatch
Imports SyncSoft.Common.Utilities.Fingerprint.DigitalPersona

Public Class frmSelfRequests

#Region " Fields "

    Private _SetCurrentPatient As Boolean = False
    Private _ExistingPatientNo As String = String.Empty
    Private existingVisitNo As String = String.Empty


    Private defaultVisitNo As String = String.Empty

    Private oBillModesID As New LookupDataID.BillModesID()
    Private Const _CashCustomer As String = "Cash Customer"
    Private tipCoPayValueWords As New ToolTip()
    Private billCustomers As DataTable

    Private captureMemberCardNo As Boolean

    Private labTests As DataTable
    Private radiologyExaminations As DataTable
    Private cardiologyExaminations As DataTable
    Private pathologyExaminations As DataTable
    Private procedures As DataTable
    Private theatreServices As DataTable
    Private dentalServices As DataTable
    Private opticalServices As DataTable
    Private extraChargeItems As DataTable
    Private consumableItems As DataTable

    Private oItemStatusID As New LookupDataID.ItemStatusID()
    Private oPayStatusID As New LookupDataID.PayStatusID()
    Private _DrugNo As String = String.Empty
    Private _ConsumableNo As String = String.Empty
    Private _BarCode As String = String.Empty
    Private _PrescriptionDrugValue As String = String.Empty
    Private _ExamNameValue As String = String.Empty
    Private _TestValue As String = String.Empty
    Private _ProcedureNameValue As String = String.Empty
    Private _TheatreNameValue As String = String.Empty
    Private _DentalNameValue As String = String.Empty
    Private _OpticalNameValue As String = String.Empty
    Private _ExtraItemValue As String = String.Empty
    Private _ConsumableItemValue As String = String.Empty

    Private WithEvents docSelfRequests As New PrintDocument()
    ' The paragraphs.
    Private paragraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)


    Private oCrossMatchTemplate As New CrossMatchFingerTemplate()
    Private oDigitalPersonaTemplate As New DigitalPersonaFingerTemplate()
    Private oItemCategoryID As New LookupDataID.ItemCategoryID()
    Private oVisitTypeID As New LookupDataID.VisitTypeID()

#End Region

#Region " Validations "

    Private Sub ndpBirthDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpBirthDate.Leave

        Try
            SetBirthDateAge(BirthDateAge.SetAge, Me.dtpBirthDate, Me.nbxAge)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub nbxAge_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbxAge.Leave

        Try
            SetBirthDateAge(BirthDateAge.SetBirthDate, Me.dtpBirthDate, Me.nbxAge)
        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

#End Region

    Private Sub frmSelfRequests_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
                Try
            Me.Cursor = Cursors.WaitCursor
            Dim oVariousOptions As New VariousOptions()

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dtpBirthDate.Value = Today
                    Me.dtpBirthDate.Checked = False
                    Me.dtpBirthDate.MaxDate = Today

                    Me.dtpVisitDate.MaxDate = Today
            Me.lblBillForItem.Text = "Bill for " + Me.tbcDrRoles.SelectedTab.Text

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadFormData()
            Me.SetDefaultPatientNo()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.EnableOnlyPrescExtrasConsAtSelfRequest()
                    Me.LoadLabTests()
                    Me.LoadRadiologyExaminations()
                    Me.LoadPathologyExaminations()
                    Me.LoadProcedures()
                    Me.LoadTheatreServices()
                    Me.LoadDentalServices()
                    Me.LoadOpticalServices()
                    Me.LoadExtraChargeItems()
            Me.LoadCardiologyExaminations()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                Me.stbVisitNo.Text = FormatText(defaultVisitNo, "Visits", "VisitNo")
                Me.Search(defaultVisitNo)

            ElseIf Not String.IsNullOrEmpty(_ExistingPatientNo) Then
                Me.chkUseExistingPatient.Checked = True
                Me.ManagePatientStatus(True)
                Me.stbPatientNo.Text = FormatText(_ExistingPatientNo, "Patients", "PatientNo")
                Me.ShowPatientDetails(_ExistingPatientNo)

            Else
                Me.chkUseExistingPatient.Checked = Not oVariousOptions.AllowGenerateSelfRequestsNo
                Me.ManagePatientStatus(Not oVariousOptions.AllowGenerateSelfRequestsNo)

            End If

            If oVariousOptions.DisableDosageAndDuration Then
               Me.colDuration.Visible = False
                Me.colDosage.Visible = False
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ApplySecurity()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub EnableOnlyPrescExtrasConsAtSelfRequest()

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.Cursor = Cursors.WaitCursor()
            If InitOptions.EnableOnlyPrescExtrasConsAtSelfRequest Then

                Me.tbcDrRoles.TabPages.Remove(tpgDental)
                Me.tbcDrRoles.TabPages.Remove(tpgLaboratory)
                Me.tbcDrRoles.TabPages.Remove(tpgTheatre)
                Me.tbcDrRoles.TabPages.Remove(tpgRadiology)
                Me.tbcDrRoles.TabPages.Remove(tpgProcedures)
                Me.tbcDrRoles.TabPages.Remove(tpgPathology)
                Me.tbcDrRoles.TabPages.Remove(tpgOptical)
                Me.tbcDrRoles.SelectTab(Me.tpgPrescriptions)


            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()


    End Sub

    Private Sub LoadFormData()

        Dim oLookupData As New LookupData()
        Dim oGenderID As New LookupDataID.GenderID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboBillModesID, LookupObjects.BillModes, False)
            LoadLookupDataCombo(Me.cboCoPayTypeID, LookupObjects.CoPayType, False)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim genderLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.Gender).Tables("LookupData")

            If genderLookupData IsNot Nothing Then

                For Each row As DataRow In genderLookupData.Rows
                    If Not (oGenderID.Male.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
                            oGenderID.Female.ToUpper().Equals(row.Item("DataID").ToString().ToUpper())) Then
                        row.Delete()
                    End If
                Next

                Me.fcbGenderID.DataSource = genderLookupData

                Me.fcbGenderID.DisplayMember = "DataDes"
                Me.fcbGenderID.ValueMember = "DataID"

                Me.fcbGenderID.SelectedIndex = -1
                Me.fcbGenderID.SelectedIndex = -1

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboBillModesID.SelectedValue = oBillModesID.Cash
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadLabTests()

        Dim oSetupData As New SetupData()
        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colExamFullName, radiologyExaminations, "ExamFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPathologyExaminations()

        Dim oPathologyExaminations As New SyncSoft.SQLDb.PathologyExaminations()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor
            pathologyExaminations = oPathologyExaminations.GetPathologyExaminations().Tables("PathologyExaminations")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colPathologyExamFullName, pathologyExaminations, "ExamFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colProcedureCode.Sorted = False
            LoadComboData(Me.colProcedureCode, procedures, "ProcedureCode", "ProcedureName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            theatreServices = oTheatreServices.GetTheatreServices().Tables("TheatreServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colTheatreCode.Sorted = False
            LoadComboData(Me.colTheatreCode, theatreServices, "TheatreCode", "TheatreName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub LoadOpticalServices()

        Dim oOpticalServices As New SyncSoft.SQLDb.OpticalServices()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from OpticalServices

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            opticalServices = oOpticalServices.GetOpticalServices().Tables("OpticalServices")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colOpticalCode.Sorted = False
            LoadComboData(Me.colOpticalCode, opticalServices, "OpticalCode", "OpticalName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadExtraChargeItems()

        Dim oExtraChargeItems As New SyncSoft.SQLDb.ExtraChargeItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ExtraChargeItems
            extraChargeItems = oExtraChargeItems.GetExtraChargeItems().Tables("ExtraChargeItems")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colItemName, extraChargeItems, "ExtraItemFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetDefaultPatientNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(InitOptions.DefaultSelfRequestNo) Then
                Dim exitingPatientNumber As String = Me.stbPatientNo.Text
                Me.stbPatientNo.Text = GetLookupDataDes(GetLookupDataID(LookupObjects.DefaultPatientNo, InitOptions.DefaultSelfRequestNo))
                stbPatientNo_Leave(stbPatientNo, New EventArgs())
                
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkUseExistingPatient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseExistingPatient.CheckedChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ManagePatientStatus(Me.chkUseExistingPatient.Checked)


        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ManagePatientStatus(ByVal useExistingPatient As Boolean)

        Try

            If useExistingPatient Then
                ResetControlsIn(Me.pnlPatients)
                Me.btnLoad.Enabled = True
                Me.pnlPatients.Enabled = False
                Me.stbPatientNo.Clear()
                Me.stbPatientNo.ReadOnly = False
                Me.SetDefaultPatientNo()
                Me.btnEnrollFingerprint.Enabled = False
            Else
                Me.pnlPatients.Enabled = True
                Me.btnLoad.Enabled = False
                Me.stbPatientNo.ReadOnly = InitOptions.PatientNoLocked
                Me.btnEnrollFingerprint.Enabled = True
                Me.SetNextSelfRequestPatientNo()
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Patients", Me.stbPatientNo)
            fQuickSearch.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Not String.IsNullOrEmpty(patientNo) Then Me.ShowPatientDetails(patientNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)
        Me.stbVisitNo.Focus()
    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub SetNextSelfRequestPatientNo()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oVariousOptions As New VariousOptions()

            Dim oPatients As New SyncSoft.SQLDb.Patients()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim selfRequestNoPrefix As String = oVariousOptions.SelfRequestNoPrefix + Today.Year.ToString().Substring(2)

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Patients", "PatientNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextPatientNo As String = CStr(oPatients.GetNextSelfRequestPatientID).PadLeft(paddingLEN, paddingCHAR)
            Dim patientNo As String = FormatText((selfRequestNoPrefix + nextPatientNo).Trim(), "Patients", "PatientNo")

            Me.stbPatientNo.Text = patientNo
            Me.SetNextVisitNo(patientNo)

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextVisitNo(ByVal patientNo As String)
        Select Case String.IsNullOrEmpty(existingVisitNo)
            Case True
                Try

                    Dim oVisits As New SyncSoft.SQLDb.Visits()
                    Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

                    Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Visits", "VisitNo").Tables("AutoNumbers")
                    Dim row As DataRow = autoNumbers.Rows(0)

                    Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
                    Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

                    If String.IsNullOrEmpty(patientNo) Then Return
                    Dim visitID As String = oVisits.GetNextVisitID(patientNo).ToString()
                    'Dim visitID As String = (oVisits.GetNextVisitID(patientNo) - 1).ToString()
                    visitID = visitID.PadLeft(paddingLEN, paddingCHAR)

                    Me.stbVisitNo.Text = FormatText(patientNo + visitID.Trim(), "Visits", "VisitNo")

                Catch ex As Exception
                    Return
                End Try
            Case False
                Try

                    Dim oVisits As New SyncSoft.SQLDb.Visits()
                    Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

                    Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Visits", "VisitNo").Tables("AutoNumbers")
                    Dim row As DataRow = autoNumbers.Rows(0)

                    Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
                    Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

                    If String.IsNullOrEmpty(patientNo) Then Return
                    Dim visitID As String = oVisits.GetNextVisitID(patientNo).ToString()
                    'Dim visitID As String = (oVisits.GetNextVisitID(patientNo) - 1).ToString()
                    visitID = visitID.PadLeft(paddingLEN, paddingCHAR)

                    Me.stbVisitNo.Text = FormatText(patientNo + visitID.Trim(), "Visits", "VisitNo")
                    'MessageBox.Show(existingVisitNo)
                    ' Dim visitNo As String = RevertText(existingVisitNo)
                    LoadPrescriptions(RevertText(existingVisitNo), True)
                Catch ex As Exception
                    Return
                End Try
        End Select


    End Sub

    Private Sub frmSelfRequests_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub ClearControls()
        ResetControlsIn(Me.pnlPatients)
        Me.stbVisitNo.Clear()
    End Sub

    Private Sub ResetControls()

        '''''''''''''''''''''''''''''''''''''
        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgExtraCharge)
        ResetControlsIn(Me.pnlPatients)
        ResetControlsIn(Me.pnlBill)
        ResetControlsIn(Me.tpgLaboratory)
        ResetControlsIn(Me.tpgRadiology)
        ResetControlsIn(Me.tpgPathology)
        ResetControlsIn(Me.tpgPrescriptions)
        ResetControlsIn(Me.tpgProcedures)
        ResetControlsIn(Me.tpgTheatre)
        ResetControlsIn(Me.tpgDental)
        ResetControlsIn(Me.tpgOptical)
        ResetControlsIn(Me.tpgConsumables)
        ResetControlsIn(Me.tpgcardiology)

        '''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub stbPatientNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbPatientNo.Leave

        'xxx()
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            If Me.chkUseExistingPatient.Checked Then
                Me.ShowPatientDetails(patientNo)
            Else : SetNextVisitNo(patientNo)
            End If

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub ShowPatientDetails(ByVal patientNo As String)

        Dim oPatients As New SyncSoft.SQLDb.Patients()

        Try
            Me.Cursor = Cursors.WaitCursor

            If String.IsNullOrEmpty(patientNo) Then Return

            Me.ClearControls()

            Dim patients As DataTable = oPatients.GetPatients(patientNo).Tables("Patients")
            Dim row As DataRow = patients.Rows(0)

            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")

            Me.stbLastName.Text = StringEnteredIn(row, "LastName")
            Me.stbFirstName.Text = StringEnteredIn(row, "FirstName")
            Me.stbMiddleName.Text = StringMayBeEnteredIn(row, "MiddleName")
            Me.dtpBirthDate.Value = DateEnteredIn(row, "BirthDate")
            Me.nbxAge.Value = StringEnteredIn(row, "Age")
            Me.fcbGenderID.SelectedValue = StringEnteredIn(row, "GenderID")
            Me.stbPhone.Text = StringMayBeEnteredIn(row, "Phone")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextVisitNo(patientNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbPatientNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbPatientNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        If Me.chkUseExistingPatient.Checked Then Me.ClearControls()
    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave
        Me.stbVisitNo.Text = FormatText(Me.stbVisitNo.Text.Trim(), "Visits", "VisitNo")
    End Sub

    Private Sub cboBillModesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillModesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            If String.IsNullOrEmpty(billModesID) Then Return
            Me.LoadBillClients(billModesID)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearBillControls()

        Me.cboBillNo.DataSource = Nothing
        Me.cboBillNo.Items.Clear()
        Me.cboBillNo.Text = String.Empty
        Me.ResetBillControls()

    End Sub

    Private Sub ResetBillControls()

        captureMemberCardNo = False

        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
            Me.stbMemberCardNo.Clear()
            Me.stbMainMemberName.Clear()
        End If

        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceName.Clear()
        Me.ResetAssociatedBillControls(False)
        Me.cboCoPayTypeID.SelectedIndex = -1
        Me.cboCoPayTypeID.SelectedIndex = -1
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
    End Sub

    Private Sub EnableSetAssociatedBillCustomer()

        Dim oVariousOptions As New VariousOptions()

        Try

            Dim associatedBillCustomer As String = StringMayBeEnteredIn(Me.cboAssociatedBillNo)
            If Not oVariousOptions.EnableSetAssociatedBillCustomer AndAlso Not String.IsNullOrEmpty(associatedBillCustomer) Then
                Me.cboAssociatedBillNo.Enabled = False
            Else : Me.cboAssociatedBillNo.Enabled = True
            End If

        Catch ex As Exception
            Me.cboAssociatedBillNo.Enabled = True
        End Try

    End Sub

    Private Sub ResetAssociatedBillControls(ByVal state As Boolean)

        If Not state Then Me.cboAssociatedBillNo.Items.Clear()
        Me.lblAssociatedBillNo.Enabled = state
        Me.cboAssociatedBillNo.Enabled = state

    End Sub

    Private Sub ResetCashControls()
        Me.cboBillNo.Enabled = False
        Me.lblBillNo.Text = "To-Bill Number"
        Me.stbMemberCardNo.Enabled = False
        Me.stbMainMemberName.Enabled = False
    End Sub

    Private Sub LoadBillClients(ByVal billModesID As String)

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ClearBillControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.LoadCASHCustomer()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Load all from Bill Customers

                    If Not InitOptions.LoadBillCustomersAtStart Then
                        billCustomers = oBillCustomers.GetBillCustomers().Tables("BillCustomers")
                        oSetupData.BillCustomers = billCustomers
                    Else : billCustomers = oSetupData.BillCustomers
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    LoadComboData(Me.cboBillNo, billCustomers, "BillCustomerFullName")
                    Me.cboBillNo.Enabled = True
                    Me.lblBillNo.Text = "To-Bill Number"
                    Me.stbMemberCardNo.Enabled = True
                    Me.stbMainMemberName.Enabled = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Enabled = True
                    Me.lblBillNo.Text = "To-Bill Medical Card No"
                    Me.stbMemberCardNo.Enabled = False
                    Me.stbMainMemberName.Enabled = False
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCASHCustomer()

        Try

            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim accountNo As String = GetLookupDataDes(oBillModesID.Cash).ToUpper()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboBillModesID.SelectedValue = oBillModesID.Cash
            Me.cboBillNo.Text = accountNo
            Me.stbBillCustomerName.Text = _CashCustomer
            Me.stbInsuranceName.Clear()
            Me.stbMemberCardNo.Clear()
            Me.stbMainMemberName.Clear()
            captureMemberCardNo = False

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadAssociatedBillCustomers(accountNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
            Me.cboCoPayTypeID.SelectedValue = oCoPayTypeID.NA
            Me.nbxCoPayPercent.Value = "0".ToString()
            Me.nbxCoPayValue.Value = "0.00".ToString()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ResetCashControls()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadAssociatedBillCustomers(ByVal accountNo As String)

        Dim oAssociatedBillCustomers As New SyncSoft.SQLDb.AssociatedBillCustomers()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboAssociatedBillNo.Items.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ' Load all from AssociatedBillCustomers
            Dim associatedBillCustomers As DataTable = oAssociatedBillCustomers.GetAssociatedBillCustomers(accountNo).Tables("AssociatedBillCustomers")

            If associatedBillCustomers IsNot Nothing AndAlso associatedBillCustomers.Rows.Count > 0 Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.ResetAssociatedBillControls(True)
                LoadComboData(Me.cboAssociatedBillNo, associatedBillCustomers, "AssociatedFullBillCustomer")
                Me.cboAssociatedBillNo.Items.Insert(0, String.Empty)

                Me.cboAssociatedBillNo.Text = InitOptions.AssociatedBillCustomer
                Me.EnableSetAssociatedBillCustomer()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else : Me.ResetAssociatedBillControls(False)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearBillCustomerName(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillNo.SelectedIndexChanged, cboBillNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ResetBillControls()
    End Sub

    Private Sub cboBillAccountNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboBillNo.Leave
        Me.DetailBillClient()
    End Sub

    Private Sub DetailBillClient()

        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()

        Try

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            If String.IsNullOrEmpty(billModesID) Then Return

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    Return

                Case oBillModesID.Account.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim accountNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboBillNo)))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo").ToUpper()
                    Me.ResetBillControls()

                    For Each row As DataRow In billCustomers.Select("AccountNo = '" + accountNo + "'")
                        captureMemberCardNo = BooleanMayBeEnteredIn(row, "CaptureMemberCardNo")
                        Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
                        Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "BillCustomerInsurance")
                        Me.cboCoPayTypeID.SelectedValue = StringMayBeEnteredIn(row, "CoPayTypeID")
                        Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
                        Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
                        Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
                    Next

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case oBillModesID.Insurance.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ResetBillControls()

                    Dim medicalCardNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
                    If String.IsNullOrEmpty(medicalCardNo) Then Return

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.cboBillNo.Text = FormatText(medicalCardNo.ToUpper(), "SchemeMembers", "MedicalCardNo")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim row As DataRow = oSchemeMembers.GetSchemeMembers(medicalCardNo).Tables("SchemeMembers").Rows(0)
                    Me.stbMemberCardNo.Text = medicalCardNo.ToUpper()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.stbMainMemberName.Text = StringMayBeEnteredIn(row, "MainMemberName")
                    Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "CompanyName")
                    Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
                    Me.cboCoPayTypeID.SelectedValue = StringMayBeEnteredIn(row, "CoPayTypeID")
                    Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
                    Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
                    Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oVisits.VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            DisplayMessage(oVisits.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.ResetControls()
            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub tbcDrRoles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcDrRoles.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgLaboratory.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgLaboratory.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForLaboratory()

                Case Me.tpgRadiology.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgRadiology.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForRadiology()
                Case Me.tpgPathology.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgPathology.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForPathology()
                Case Me.tpgPrescriptions.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgPrescriptions.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForPrescriptions()

                Case Me.tpgProcedures.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgProcedures.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForProcedures()

                Case Me.tpgTheatre.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgTheatre.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForTheatre()

                Case Me.tpgDental.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgDental.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForDental()

                Case Me.tpgOptical.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgOptical.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForOptical()

                Case Me.tpgExtraCharge.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgExtraCharge.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForExtraCharge()

                Case Me.tpgConsumables.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgConsumables.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForConsumables()

                Case Me.tpgcardiology.Name
                    Me.lblBillForItem.Text = "Bill for " + Me.tpgcardiology.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForCardiology()

                Case Else
                    Me.lblBillForItem.Text = "Bill for "
                    Me.pnlBill.Visible = False
                    Me.btnDelete.Visible = False
                    ResetControlsIn(Me.pnlBill)

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ApplySecurity()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Me.Search(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Sub Search(ByVal visitNo As String)

        Dim message As String
        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()

        Try

            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim dataSource As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim row As DataRow = dataSource.Rows(0)

            Dim visitCategoryID As String = StringMayBeEnteredIn(row, "VisitCategoryID")
            Dim serviceCode As String = StringMayBeEnteredIn(row, "ServiceCode")

            If Not (visitCategoryID.ToUpper().Equals(oVisitCategoryID.SelfRequest.ToUpper()) AndAlso
                    serviceCode.ToUpper().Equals(oServiceCodes.NA.ToUpper())) Then
                message = "The visit you are searching for is not a self request visit. " + ControlChars.NewLine +
                          "Are you sure you want to continue?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DisplayData(dataSource)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            Dim accountNo As String = GetLookupDataDes(oBillModesID.Cash).ToUpper()
            If billModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then
                Me.LoadAssociatedBillCustomers(accountNo)
                Me.cboAssociatedBillNo.Text = StringMayBeEnteredIn(row, "AssociatedFullBillCustomer")
                Me.lblAssociatedBillNo.Enabled = False
                Me.cboAssociatedBillNo.Enabled = False
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadLaboratory(visitNo)
            Me.LoadPathology(visitNo)
            Me.LoadRadiology(visitNo)
            Me.LoadPrescriptions(visitNo, False)
            Me.LoadProcedures(visitNo)
            Me.LoadTheatre(visitNo)
            Me.LoadDental(visitNo)
            Me.LoadOptical(visitNo)
            Me.LoadExtraCharge(visitNo)
            Me.LoadConsumables(visitNo)
            Me.LoadCardiology(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgLaboratory.Name
                    Me.CalculateBillForLaboratory()

                Case Me.tpgRadiology.Name
                    Me.CalculateBillForRadiology()
                Case Me.tpgPathology.Name
                    Me.CalculateBillForPathology()

                Case Me.tpgPrescriptions.Name
                    Me.CalculateBillForPrescriptions()

                Case Me.tpgProcedures.Name
                    Me.CalculateBillForProcedures()

                Case Me.tpgTheatre.Name
                    Me.CalculateBillForTheatre()

                Case Me.tpgDental.Name
                    Me.CalculateBillForDental()

                Case Me.tpgOptical.Name
                    Me.CalculateBillForOptical()

                Case Me.tpgExtraCharge.Name
                    Me.CalculateBillForExtraCharge()

                Case Me.tpgConsumables.Name
                    Me.CalculateBillForConsumables()

                Case Else : ResetControlsIn(Me.pnlBill)

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ApplySecurity()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim message As String
        Dim oStatusID As New LookupCommDataID.StatusID()

        Dim oDoctorSpecialtyID As New LookupDataID.DoctorSpecialtyID()
        Dim oVisitStatusID As New LookupDataID.VisitStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oPriorityID As New LookupDataID.PriorityID()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPatients As New SyncSoft.SQLDb.Patients()
            Dim oVisits As New SyncSoft.SQLDb.Visits()
            Dim oVariousOptions As New VariousOptions()
            Dim oCurrentPatient As New CurrentPatient()
            ' Dim oItemBalanceDetails As New SyncSoft.SQLDb.ItemsBalanceDetails()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not Me.chkUseExistingPatient.Checked Then

                With oPatients

                    .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient's Number!"))
                    .ReferenceNo = String.Empty
                    .LastName = StringEnteredIn(Me.stbLastName, "Surname!")
                    .FirstName = StringEnteredIn(Me.stbFirstName, "First Name!")
                    .MiddleName = StringMayBeEnteredIn(Me.stbMiddleName)
                    .BirthDate = DateEnteredIn(Me.dtpBirthDate, "Birth Date!")
                    .GenderID = StringValueEnteredIn(Me.fcbGenderID, "Gender!")
                    .Fingerprint = Nothing
                    .JoinDate = DateMayBeEnteredIn(Me.dtpVisitDate)
                    .Address = String.Empty
                    .Phone = StringMayBeEnteredIn(Me.stbPhone)
                    .BirthPlace = String.Empty
                    .Email = String.Empty
                    .NOKName = String.Empty
                    .NOKRelationship = String.Empty
                    .NOKPhone = String.Empty
                    .Occupation = String.Empty
                    .Location = String.Empty

                    If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) AndAlso
                     oCrossMatchTemplate.Fingerprint IsNot Nothing Then
                        .Fingerprint = oCrossMatchTemplate.Fingerprint

                    ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) AndAlso
                        (oDigitalPersonaTemplate.Template IsNot Nothing) Then
                        .Fingerprint = oDigitalPersonaTemplate.Template.Bytes

                    Else : .Fingerprint = Nothing
                    End If


                    .DefaultBillModesID = StringValueEnteredIn(Me.cboBillModesID, "To-Bill Mode!")
                    .DefaultBillNo = RevertText(StringEnteredIn(Me.cboBillNo, "To-Bill Customer's No!"))

                    If .DefaultBillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso captureMemberCardNo Then
                        .DefaultMemberCardNo = StringEnteredIn(Me.stbMemberCardNo, "Member Card No!")
                    Else : .DefaultMemberCardNo = StringMayBeEnteredIn(Me.stbMemberCardNo)
                    End If

                    If .DefaultBillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso oVariousOptions.ForceAccountMainMemberName Then
                        .DefaultMainMemberName = StringEnteredIn(Me.stbMainMemberName, "Main Member Name!")
                    Else : .DefaultMainMemberName = StringMayBeEnteredIn(Me.stbMainMemberName)
                    End If

                    .EnforceDefaultBillNo = True

                    .HideDetails = False
                    .StatusID = oStatusID.Active
                    .LoginID = CurrentUser.LoginID
                End With

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If oPatients.DefaultBillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then ValidateBillCustomerInsuranceDirect(oPatients.DefaultBillNo)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If String.IsNullOrEmpty(oPatients.Phone.Trim()) Then
                    message = "You have not entered a phone number for this Patient. " +
                              "It’s recommended that you enter at least one phone number for contact purposes. " +
                               ControlChars.NewLine + "Are you sure you want to save?"
                    If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.stbPhone.Focus() : Return
                End If

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oVisits

                .PatientNo = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient's No!"))
                .VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                .VisitDate = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
                .DoctorSpecialtyID = oDoctorSpecialtyID.General
                .StaffNo = String.Empty
                .VisitCategoryID = Me.GetVisitCategoryID()
                If (String.IsNullOrEmpty(existingVisitNo)) Then
                    .ReferredBy = String.Empty
                ElseIf Not (String.IsNullOrEmpty(existingVisitNo)) Then
                    .ReferredBy = existingVisitNo
                End If
                .ServiceCode = oServiceCodes.NA
                .BillModesID = StringValueEnteredIn(Me.cboBillModesID, "Bill Mode!")
                .BillNo = RevertText(StringEnteredIn(Me.cboBillNo, "To-Bill No!"))
                .InsuranceNo = String.Empty
                .AssociatedBillNo = Me.GetAssociatedBillNo()
                If .BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso captureMemberCardNo Then
                    .MemberCardNo = StringEnteredIn(Me.stbMemberCardNo, "Member Card No!")
                Else : .MemberCardNo = StringMayBeEnteredIn(Me.stbMemberCardNo)
                End If
                If .BillModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) AndAlso oVariousOptions.ForceAccountMainMemberName Then
                    .MainMemberName = StringEnteredIn(Me.stbMainMemberName, "Main Member Name!")
                Else : .MainMemberName = StringMayBeEnteredIn(Me.stbMainMemberName)
                End If
                .ClaimReferenceNo = String.Empty
                .VisitStatusID = oVisitStatusID.Completed
                .AccessCashServices = False
                .FingerprintVerified = False
                .CoPayTypeID = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
                .CoPayPercent = Me.nbxCoPayPercent.GetSingle()
                .CoPayValue = Me.nbxCoPayValue.GetDecimal(False)
                .SmartCardApplicable = False
                .VisitsPriorityID = oPriorityID.Normal
                .LoginID = CurrentUser.LoginID

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvLabTests.RowCount <= 1 AndAlso Me.dgvRadiology.RowCount <= 1 AndAlso Me.dgvPrescription.RowCount <= 1 AndAlso
                Me.dgvProcedures.RowCount <= 1 AndAlso Me.dgvTheatre.RowCount <= 1 AndAlso Me.dgvDental.RowCount <= 1 AndAlso
                Me.dgvCardiology.RowCount <= 1 AndAlso
                Me.dgvOptical.RowCount <= 1 AndAlso Me.dgvExtraCharge.RowCount <= 1 AndAlso Me.dgvConsumables.RowCount <= 1 AndAlso
                Me.dgvHistopathologyRequisition.RowCount <= 1 Then
                message = "Must register at least one item for extra charge or laboratory or radiology or pathology or cardiology" +
                            "or prescription or procedure or theatre or dental or optical or consumable!"
                Throw New ArgumentException(message)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.VerifyExtraChargeEntries()
            Me.VerifyLaboratoryEntries()
            Me.VerifyRadiologyEntries()
            Me.VerifyPathologyEntries()
            Me.VerifyPrescriptionsEntries()
            Me.VerifyProceduresEntries()
            Me.VerifyTheatreEntries()
            Me.VerifyDentalEntries()
            Me.VerifyOpticalEntries()
            Me.VerifyConsumablesEntries()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not Me.chkUseExistingPatient.Checked Then oPatients.Save()

                  
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oVisits.IsVisitDateSaved(oVisits.PatientNo, oVisits.VisitDate) Then
                        If oVariousOptions.AllowCreateMultipleVisits Then
                            message = "You already have a visit on " + FormatDate(oVisits.VisitDate) + ". " +
                                      "If the previous visit is no longer needed, it can be deleted via visits edit sub menu." +
                                       ControlChars.NewLine + "Are you sure you want to save?"
                            If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return
                        Else
                            message = "You already have a visit on " + FormatDate(oVisits.VisitDate) + ". " +
                                      "If the previous visit is no longer needed, it can be deleted via visits edit sub menu. " +
                                      "The system is set not to allow multiple visits on the same date. " +
                                      "Please contact the administrator if you still need to create this visit."
                            Throw New ArgumentException(message)
                        End If
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not oVisits.BillModesID.ToUpper().Equals(oBillModesID.Cash.ToUpper()) Then

                        Dim oCurrentVisit As New CurrentVisit()

                        With oCurrentVisit

                            .PatientNo = oVisits.PatientNo
                            .VisitNo = oVisits.VisitNo
                            .VisitDate = oVisits.VisitDate
                            .DoctorSpecialtyID = oVisits.DoctorSpecialtyID
                            .StaffNo = oVisits.StaffNo
                            .VisitCategoryID = oVisits.VisitCategoryID
                            .ReferredBy = oVisits.ReferredBy
                            .ServiceCode = oVisits.ServiceCode
                            .BillModesID = oVisits.BillModesID
                            .BillNo = oVisits.BillNo
                            .MemberCardNo = oVisits.MemberCardNo
                            .MainMemberName = oVisits.MainMemberName

                        End With

                        Dim fVisits As New frmVisits(oCurrentVisit)
                        fVisits.Save()
                        fVisits.ShowDialog()

                        Me.UpdateVisitStatus(oVisits.VisitNo, oVisitStatusID.Completed)

                    Else : oVisits.Save()
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If InitOptions.EnableOnlyPrescExtrasConsAtSelfRequest Then
                        Me.SaveExtraCharge()
                        Me.SavePrescriptions()
                        Me.SaveConsumables()
                    Else
                        Me.SaveExtraCharge()
                        Me.SaveLaboratory()
                        Me.SaveRadiology()
                        Me.SavePathology()
                        Me.SavePrescriptions()
                        Me.SaveProcedures()
                        Me.SaveTheatre()
                        Me.SaveDental()
                        Me.SaveOptical()
                        Me.SaveConsumables()
                        Me.SaveCardiology()
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me._SetCurrentPatient Then
                        oCurrentPatient.PatientNo = oVisits.PatientNo
                        oCurrentPatient.VisitNo = oVisits.VisitNo
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.chkPrintVisitOnSaving.Checked Then Me.PrintSelfRequests()
                    Dim fCashier As New frmCashier(oVisits.VisitNo, oVisitTypeID.OutPatient)
                    Dim billMode As String = StringValueMayBeEnteredIn(Me.cboBillModesID)
                    Dim cashBillMode As String = oBillModesID.Cash
                    Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
                    Dim fInvoices As New frmInvoices(visitNo)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If InitOptions.OpenCashierAfterSelfRequest Then
                      
                        If Not billMode.ToUpper().Equals(cashBillMode.ToUpper()) Then
                            fInvoices.ShowDialog()
                        ElseIf billMode.ToUpper().Equals(cashBillMode.ToUpper()) Then
                            fCashier.ShowDialog()
                        End If
                    End If
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.ResetControls()
                    Me.dtpVisitDate.Value = Today
                    Me.dtpVisitDate.Checked = True

                    If oVariousOptions.AllowGenerateSelfRequestsNo Then
                        Me.chkUseExistingPatient.Checked = False
                        Me.SetNextSelfRequestPatientNo()
                    Else
                        Me.chkUseExistingPatient.Checked = Not oVariousOptions.AllowGenerateSelfRequestsNo
                        Me.ManagePatientStatus(Not oVariousOptions.AllowGenerateSelfRequestsNo)
                        Me.SetDefaultPatientNo()
                    End If

                    Me.LoadCASHCustomer()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If InitOptions.EnableOnlyPrescExtrasConsAtSelfRequest Then
                        Me.SaveExtraCharge()
                        Me.SavePrescriptions()
                        Me.SaveConsumables()
                    Else
                        Me.SaveExtraCharge()
                        Me.SaveLaboratory()
                        Me.SaveRadiology()
                        Me.SavePathology()
                        Me.SavePrescriptions()
                        Me.SaveProcedures()
                        Me.SaveTheatre()
                        Me.SaveDental()
                        Me.SaveOptical()
                        Me.SaveConsumables()
                        Me.SaveCardiology()
                    End If



                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DisplayMessage("Record(s) successfully updated!")
                    ' Me.SetStaticPatientNo()
                    Me.CallOnKeyEdit()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

        Catch eX As Exception

            If eX.Message.Contains("The Patient No:") OrElse eX.Message.EndsWith("already exists") Then
                message = "The Patient No: " + Me.stbPatientNo.Text + ", you are trying to enter already exists" + ControlChars.NewLine +
                          "If you are using the system generated number, probably another user has already taken it. " + ControlChars.NewLine +
                          "Would you like the system to generate another one?."
                If WarningMessage(message) = Windows.Forms.DialogResult.Yes Then Me.SetNextSelfRequestPatientNo()
            Else : ErrorMessage(eX)
            End If

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function GetVisitCategoryID() As String

        Dim oVisitCategoryID As New LookupDataID.VisitCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(InitOptions.VisitCategory) Then
                Return GetLookupDataID(LookupObjects.VisitCategory, InitOptions.VisitCategory)

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return oVisitCategoryID.SelfRequest
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Return oVisitCategoryID.SelfRequest

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

   

    Private Function GetAssociatedBillNo() As String

        Try

            Dim associatedBillNo As String

            If (Me.cboAssociatedBillNo.Text IsNot Nothing AndAlso
                Not String.IsNullOrEmpty(Me.cboAssociatedBillNo.Text)) OrElse Me.cboAssociatedBillNo.Items.Count > 0 Then
                associatedBillNo = RevertText(SubstringEnteredIn(Me.cboAssociatedBillNo, "Associated Bill Customer!"))
            Else : associatedBillNo = String.Empty
            End If

            Return associatedBillNo

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub UpdateVisitStatus(ByVal visitNo As String, ByVal visitStatusID As String)

        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Dim oVisits As New SyncSoft.SQLDb.Visits()
            Dim lVisits As New List(Of DBConnect)

            If String.IsNullOrEmpty(visitNo) Then Return

            With oVisits

                .VisitNo = visitNo
                .VisitStatusID = visitStatusID
                .VisitDate = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
                .AccessCashServices = False
                .LoginID = String.Empty

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lVisits.Add(oVisits)
            transactions.Add(New TransactionList(Of DBConnect)(lVisits, Action.Update))

            DoTransactions(transactions)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Function SaveExtraCharge() As Boolean

        Dim message As String
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oBenefitCodes As New LookupDataID.BenefitCodes()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oBillModesID As New LookupDataID.BillModesID()
        Dim oPayModesID As New LookupDataID.PayModesID()
        Dim oAccountActionID As New LookupDataID.AccountActionID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()

        Dim oClaimsEXT As New SyncSoft.SQLDb.ClaimsEXT()
        Dim lClaims As New List(Of DBConnect)
        Dim lClaimsEXT As New List(Of DBConnect)
        Dim lClaimDetails As New List(Of DBConnect)

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim minTran As New List(Of TransactionList(Of DBConnect))
            Dim billModesID As String = StringValueEnteredIn(Me.cboBillModesID, "To-Bill Mode!")
            Dim billNo As String = RevertText(StringEnteredIn(Me.cboBillNo, "To-Bill Account No!"))

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim claimNo As String = oClaimsEXT.GetClaimsEXTClaimNo(visitNo)

            If billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then

                Dim oClaimStatusID As New LookupDataID.ClaimStatusID()
                Dim oEntryModeID As New LookupDataID.EntryModeID()
                Using oClaims As New SyncSoft.SQLDb.Claims()

                    With oClaims

                        .MedicalCardNo = billNo
                        .ClaimNo = GetNextClaimNo(billNo)
                        .PatientNo = patientNo
                        .VisitDate = visitDate
                        .VisitTime = GetTime(Now)
                        .HealthUnitCode = GetHealthUnitsHealthUnitCode()
                        .PrimaryDoctor = String.Empty
                        .ClaimStatusID = oClaimStatusID.Pending
                        .ClaimEntryID = oEntryModeID.System
                        .LoginID = CurrentUser.LoginID

                    End With

                    lClaims.Add(oClaims)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayTypeID As String = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvExtraCharge.Rows(rowNo).Cells

                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colItemName))
                Dim itemName As String = SubstringLeft(StringEnteredIn(cells, Me.colItemName))
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colExtraChargeQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colExtraChargeUnitPrice, False)
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colExtraChargeAmount, False)

                Dim cashAmount As Decimal = CDec(amount * coPayPercent) / 100
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colNotes)

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Try
                    Using oItems As New SyncSoft.SQLDb.Items()

                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = notes
                            .LastUpdate = visitDate
                            .ItemCategoryID = oItemCategoryID.Extras
                            .ItemStatusID = oItemStatusID.Offered
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID

                        End With

                        lItems.Add(oItems)
                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If coPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Extras
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then

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
                                .ItemName = itemName
                                .BenefitCode = oBenefitCodes.Extras
                                .Quantity = quantity
                                .UnitPrice = unitPrice
                                .Adjustment = 0
                                .Amount = amount
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
                    If CBool(Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, rowNo).Value).Equals(False) Then
                        message = itemName + " item will automatically be marked as offered. You won’t be able to remove it." +
                                                ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Continue For
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, rowNo).Value = True

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcDrRoles.SelectTab(Me.tpgExtraCharge.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgExtraCharge.Name)
            SaveExtraCharge = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyExtraChargeEntries() As Boolean

        Dim oExtraItemCodes As New LookupDataID.ExtraItemCodes()

        Try

            For Each row As DataGridViewRow In Me.dgvExtraCharge.Rows
                If row.IsNewRow Then Exit For
                Dim itemCode As String = SubstringRight(StringEnteredIn(row.Cells, Me.colItemName))
                StringEnteredIn(row.Cells, Me.colItemName, "Item Name!")
                If itemCode.ToUpper().Equals(oExtraItemCodes.COPAYVALUE.ToUpper())  Then
                    DecimalEnteredIn(row.Cells, Me.colExtraChargeUnitPrice, True, "Unit Price!")
                Else : DecimalEnteredIn(row.Cells, Me.colExtraChargeUnitPrice, False, "Unit Price!")
                End If
                DecimalEnteredIn(row.Cells, Me.colExtraChargeAmount, False, "amount!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgExtraCharge.Name)
            VerifyExtraChargeEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveLaboratory() As Boolean

        Dim quantity As Integer = 1

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
            Dim coPayTypeID As String = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvLabTests.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvLabTests.Rows(rowNo).Cells
                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colTest))
                Dim details As String = StringMayBeEnteredIn(cells, Me.ColLabNotes)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colLTUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = details
                            .LastUpdate = visitDate
                            .ItemCategoryID = oItemCategoryID.Test
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID
                        End With

                        lItems.Add(oItems)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Test
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value).Equals(False) Then

                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.dtpVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.LabRequests
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Lab Request(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcDrRoles.SelectTab(Me.tpgLaboratory.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgLaboratory.Name)
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
                StringEnteredIn(row.Cells, Me.colTest, "test!")
                DecimalEnteredIn(row.Cells, Me.colLTUnitPrice, False, "Unit Price!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgLaboratory.Name)
            VerifyLaboratoryEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveRadiology() As Boolean

        Dim quantity As Integer = 1

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
            Dim coPayTypeID As String = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvRadiology.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvRadiology.Rows(rowNo).Cells

                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colExamFullName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colRadiologyUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colRadiologyIndication, "Indication!")
                            .LastUpdate = visitDate
                            .ItemCategoryID = oItemCategoryID.Radiology
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID

                            lItems.Add(oItems)

                        End With

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Radiology
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.dtpVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Radiology
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Radiology sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvRadiology.Item(Me.colRadiologySaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcDrRoles.SelectTab(Me.tpgRadiology.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgRadiology.Name)
            SaveRadiology = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function SavePathology() As Boolean

        Dim quantity As Integer = 1

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
            Dim coPayTypeID As String = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvHistopathologyRequisition.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvHistopathologyRequisition.Rows(rowNo).Cells

                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colPathologyExamFullName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colPathologyUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colPathologyIndication, "Indication!")
                            .LastUpdate = visitDate
                            .ItemCategoryID = oItemCategoryID.Pathology
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID

                            lItems.Add(oItems)

                        End With

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Pathology
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvHistopathologyRequisition.Item(Me.colPathologySaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.dtpVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Pathology
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Pathology sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvHistopathologyRequisition.Item(Me.colPathologySaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcDrRoles.SelectTab(Me.tpgPathology.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgPathology.Name)
            SavePathology = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyRadiologyEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvRadiology.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colExamFullName, "Examination!")
                DecimalEnteredIn(row.Cells, Me.colRadiologyUnitPrice, False, "Unit Price!")
                StringEnteredIn(row.Cells, Me.colRadiologyIndication, "Indication!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgRadiology.Name)
            VerifyRadiologyEntries = False
            Throw ex

        End Try

    End Function

    Private Function VerifyPathologyEntries() As Boolean

        Try

            For Each row As DataGridViewRow In Me.dgvHistopathologyRequisition.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colPathologyExamFullName, "Examination!")
                DecimalEnteredIn(row.Cells, Me.colPathologyUnitPrice, False, "Unit Price!")
                StringEnteredIn(row.Cells, Me.colPathologyIndication, "Indication!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgPathology.Name)
            VerifyPathologyEntries = False
            Throw ex

        End Try

    End Function

    Private Function SavePrescriptions() As Boolean
        Dim oServiceCodes As New LookupDataID.ServiceCodes()
        Dim oVariousOptions As New VariousOptions()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
            Dim coPayTypeID As String = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
            Dim _existingVisitNo As String = RevertText(existingVisitNo)


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim transactions As New List(Of TransactionList(Of DBConnect))
                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim lItemsEXT As New List(Of DBConnect)
                Dim lItemsBalanceDetails As New List(Of DBConnect)

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colDrugNo)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDrugQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDrugUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringMayBeEnteredIn(cells, Me.colDrugFormula)
                            .LastUpdate = visitDate
                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID

                        End With

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lItems.Add(oItems)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Using oItemsEXT As New SyncSoft.SQLDb.ItemsEXT()
                        With oItemsEXT
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .ItemCategoryID = oItemCategoryID.Drug
                            If oVariousOptions.DisableDosageAndDuration Then
                                .Dosage = StringMayBeEnteredIn(cells, Me.colDosage)
                                .Duration = IntegerMayBeEnteredIn(cells, Me.colDuration)
                            Else
                                .Dosage = StringEnteredIn(cells, Me.colDosage)
                                .Duration = IntegerEnteredIn(cells, Me.colDuration)
                            End If

                            .DrQuantity = IntegerEnteredIn(cells, Me.colDrugQuantity)
                        End With
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        lItemsEXT.Add(oItemsEXT)
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItemsEXT, Action.Save))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Using oItemBalanceDetails As New SyncSoft.SQLDb.ItemsBalanceDetails()
                        With oItemBalanceDetails
                            .VisitNo = _existingVisitNo
                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemCode = itemCode
                            '.BalanceStatus = oItemStatusID.Processing
                            .NextVisitNo = visitNo
                        End With
                        lItemsBalanceDetails.Add(oItemBalanceDetails)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItemsBalanceDetails, Action.Update))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                    If coPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Drug
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                            lItemsCASH.Add(oItemsCASH)
                            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        End Using
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    'transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))
                    'transactions.Add(New TransactionList(Of DBConnect)(lItemsEXT, Action.Save))
                    'transactions.Add(New TransactionList(Of DBConnect)(lItemsBalanceDetails, Action.Save))
                    'transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value).Equals(False) Then

                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.dtpVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Prescription
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
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

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcDrRoles.SelectTab(Me.tpgPrescriptions.Name)
                    ErrorMessage(ex)

                End Try
            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgPrescriptions.Name)
            SavePrescriptions = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function UpdateItemsBalanceDetails() As Boolean

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        
        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim _existingVisitNo As String = RevertText(existingVisitNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim transactions As New List(Of TransactionList(Of DBConnect))
                Dim lItemsBalanceDetails As New List(Of DBConnect)

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colDrugNo)
        
                Try

                    Using oItemBalanceDetails As New SyncSoft.SQLDb.ItemsBalanceDetails
                        With oItemBalanceDetails
                            .VisitNo = _existingVisitNo
                            .ItemCategoryID = oItemCategoryID.Drug
                            .ItemCode = itemCode
                            '.BalanceStatus = oItemStatusID.Processing
                            .NextVisitNo = visitNo
                        End With
                        lItemsBalanceDetails.Add(oItemBalanceDetails)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItemsBalanceDetails, Action.Update))

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Catch ex As Exception
                    ErrorMessage(ex)
                End Try

        Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgPrescriptions.Name)
            UpdateItemsBalanceDetails = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyPrescriptionsEntries() As Boolean

        Dim message As String


        Try

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, row.Index).Value).Equals(False) Then

                    Dim oVariousOptions As New VariousOptions()
                    Dim drugNo As String = StringEnteredIn(row.Cells, Me.colDrugNo, "drug!")
                    Dim drugName As String = StringEnteredIn(row.Cells, Me.colDrug)

                    If oVariousOptions.DisableDosageAndDuration Then
                        StringMayBeEnteredIn(row.Cells, Me.colDosage)
                        IntegerMayBeEnteredIn(row.Cells, Me.colDuration)
                    Else
                        StringEnteredIn(row.Cells, Me.colDosage, "dosage!")
                        IntegerEnteredIn(row.Cells, Me.colDuration, "duration!")
                    End If


                    Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colDrugQuantity, "quantity!")
                    DecimalEnteredIn(row.Cells, Me.colDrugUnitPrice, False, "unit price!")
                    StringMayBeEnteredIn(row.Cells, Me.colDrugFormula)
                    Dim averageConsumedStock As Decimal = oVariousOptions.MaximumDrugQtyToGive()
                    Dim availableStock As Integer = GetAvailableStock(drugNo)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(row.Cells, Me.colOrderLevel)
                    Dim halted As Boolean = BooleanMayBeEnteredIn(row.Cells, Me.colHalted)
                    Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(row.Cells, Me.colHasAlternateDrugs)
                    Dim expiryDate As Date = DateMayBeEnteredIn(row.Cells, Me.colExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days
                    If averageConsumedStock > 0 Then
                        If quantity > averageConsumedStock Then
                            message = "The Drug " + drugName + " With Quantity " + quantity.ToString + " is greater than the Average Of " +
                                  averageConsumedStock.ToString() + " which is usually given to Patients. " +
                                   ControlChars.NewLine + "Are you sure, you would like to Proceed ? "
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Continue For

                        End If
                    End If


                    If halted Then

                        If hasAlternateDrugs Then
                            message = "Drug: " + drugName + " is currently on halt and has registered alternatives. " +
                                            "The system does not allow prescription of a drug on halt. " +
                                            ControlChars.NewLine + "Would you like to look at its alternatives? "
                            If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)
                        Else
                            message = "Drug: " + drugName + " is currently on halt and has no registered alternatives. " +
                                        "The system does not allow prescription of a drug on halt!"
                            Throw New ArgumentException(message)
                        End If

                        Throw New ArgumentException("Action Cancelled!")

                    ElseIf quantity > 0 AndAlso availableStock < quantity Then

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
                                Throw New ArgumentException(message)
                            End If
                            Throw New ArgumentException("Action Cancelled!")
                        Else
                            message = "Insufficient stock to dispense for " + drugName +
                                      " with a deficit of " + (quantity - availableStock).ToString() +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then
                                If hasAlternateDrugs Then
                                    message = "Would you like to look at " + drugName + " alternatives? "
                                    If DeleteMessage(message) = Windows.Forms.DialogResult.Yes Then ShowAlternateDrugs(drugNo)
                                End If
                                Throw New ArgumentException("Action Cancelled!")
                            End If
                        End If

                    ElseIf orderLevel >= availableStock - quantity Then
                        message = "Stock level for " + drugName + " is running low. Please notify Pharmacy to re-stock appropriately!"
                        DisplayMessage(message)
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                        If Not oVariousOptions.AllowPrescriptionExpiredDrugs() Then
                            message = "Expiry date for " + drugName + " had reached. " +
                                "The system does not allow to prescribe a drug that is expired. Please notify Pharmacy to re-stock appropriately! "
                            Throw New ArgumentException(message)
                        Else
                            message = "Expiry date for " + drugName + " had reached. " + ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If

                    ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                        message = "Drug: " + drugName + " has " + remainingDaysExpiryDate.ToString() +
                            " remaining day(s) to expire. Please notify Pharmacy to re-stock appropriately!"
                        DisplayMessage(message)

                    ElseIf expiryDate = AppData.NullDateValue Then
                        message = "Expiry date for " + drugName + " is not set. The system can not verify when this drug will expire!"
                        DisplayMessage(message)
                    End If

                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgPrescriptions.Name)
            VerifyPrescriptionsEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveProcedures() As Boolean

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
            Dim coPayTypeID As String = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvProcedures.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvProcedures.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colProcedureCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringMayBeEnteredIn(cells, Me.colProcedureNotes)
                            .LastUpdate = visitDate
                            .ItemCategoryID = oItemCategoryID.Procedure
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID
                        End With

                        lItems.Add(oItems)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Procedure
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value).Equals(False) Then

                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.dtpVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Procedure
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Procedure(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvProcedures.Item(Me.colProceduresSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcDrRoles.SelectTab(Me.tpgProcedures.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgProcedures.Name)
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
                StringEnteredIn(row.Cells, Me.colProcedureCode, "procedure!")
                IntegerEnteredIn(row.Cells, Me.colQuantity, "quantity!")
                DecimalEnteredIn(row.Cells, Me.colUnitPrice, False, "unit price!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgProcedures.Name)
            VerifyProceduresEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveTheatre() As Boolean

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
            Dim coPayTypeID As String = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvTheatre.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvTheatre.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colTheatreCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colTheatreQuantity, "Quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colTheatreUnitPrice, False, "unit price!")
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringMayBeEnteredIn(cells, Me.colTheatreNotes)
                            .LastUpdate = visitDate
                            .ItemCategoryID = oItemCategoryID.Theatre
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID
                        End With

                        lItems.Add(oItems)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Theatre
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value).Equals(False) Then

                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.dtpVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Theatre
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Theatre sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvTheatre.Item(Me.colTheatreSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcDrRoles.SelectTab(Me.tpgTheatre.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgTheatre.Name)
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
                IntegerEnteredIn(row.Cells, Me.colTheatreQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colTheatreUnitPrice, False, "Unit Price!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgTheatre.Name)
            VerifyTheatreEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveDental() As Boolean

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
            Dim coPayTypeID As String = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvDental.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvDental.Rows(rowNo).Cells

                Dim itemCode As String = StringEnteredIn(cells, Me.colDentalCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colDentalQuantity, "Quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colDentalUnitPrice, False, "unit price!")
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colDentalNotes, "Notes!")
                            .LastUpdate = visitDate
                            .ItemCategoryID = oItemCategoryID.Dental
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID
                        End With

                        lItems.Add(oItems)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Dental
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, rowNo).Value).Equals(False) Then

                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.dtpVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Dental
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Dental sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvDental.Item(Me.colDentalSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcDrRoles.SelectTab(Me.tpgDental.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgDental.Name)
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
                IntegerEnteredIn(row.Cells, Me.colDentalQuantity, "Quantity!")
                StringEnteredIn(row.Cells, Me.colDentalNotes, "Notes!")
                DecimalEnteredIn(row.Cells, Me.colDentalUnitPrice, False, "Unit Price!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgDental.Name)
            VerifyDentalEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveOptical() As Boolean

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
            Dim coPayTypeID As String = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvOptical.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvOptical.Rows(rowNo).Cells
                Dim itemCode As String = StringEnteredIn(cells, Me.colOpticalCode)
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colOpticalQuantity, "Quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colOpticalUnitPrice, False, "unit price!")
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems
                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringMayBeEnteredIn(cells, Me.colOpticalNotes)
                            .LastUpdate = visitDate
                            .ItemCategoryID = oItemCategoryID.Optical
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID
                        End With

                        lItems.Add(oItems)

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Optical
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvOptical.Item(Me.colOpticalSaved.Name, rowNo).Value).Equals(False) Then

                        Try
                            If GetShortDate(DateMayBeEnteredIn(Me.dtpVisitDate)) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Optical
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Optical sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvOptical.Item(Me.colOpticalSaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcDrRoles.SelectTab(Me.tpgOptical.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgOptical.Name)
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
                IntegerEnteredIn(row.Cells, Me.colOpticalQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colOpticalUnitPrice, False, "Unit Price!")
            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgOptical.Name)
            VerifyOpticalEntries = False
            Throw ex

        End Try

    End Function

    Private Function SaveConsumables() As Boolean

        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim coPayTypeID As String = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvConsumables.Rows(rowNo).Cells

                Dim consumableNo As String = StringEnteredIn(cells, Me.ColConsumableNo)
                Dim consumableName As String = SubstringLeft(StringEnteredIn(cells, Me.colConsumableName))
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colConsumableQuantity)
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colConsumableUnitPrice, False)
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colConsumableAmount, False)

                Dim cashAmount As Decimal = CDec(amount * coPayPercent) / 100
                Dim notes As String = StringMayBeEnteredIn(cells, Me.colConsumableNotes)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Try
                    Using oItems As New SyncSoft.SQLDb.Items()

                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = consumableNo
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = notes
                            .LastUpdate = visitDate
                            .ItemCategoryID = oItemCategoryID.Consumable
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID

                        End With

                        lItems.Add(oItems)
                    End Using

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If coPayTypeID.ToUpper().Equals(oCoPayTypeID.Percent.ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = consumableNo
                                .ItemCategoryID = oItemCategoryID.Consumable
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value).Equals(False) Then

                        Try
                            If GetShortDate(visitDate) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Consumable
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Consumable(s) sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, rowNo).Value = True
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    Me.tbcDrRoles.SelectTab(Me.tpgConsumables.Name)
                    ErrorMessage(ex)

                End Try

            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgConsumables.Name)
            SaveConsumables = False
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Function

    Private Function VerifyConsumablesEntries() As Boolean

        Dim message As String

        Try

            For Each row As DataGridViewRow In Me.dgvConsumables.Rows
                If row.IsNewRow Then Exit For

                Dim oVariousOptions As New VariousOptions()
                Dim consumableName As String = SubstringLeft(StringEnteredIn(row.Cells, Me.colConsumableName, "Consumable!"))
                Dim quantity As Integer = IntegerEnteredIn(row.Cells, Me.colConsumableQuantity, "Quantity!")
                DecimalEnteredIn(row.Cells, Me.colConsumableUnitPrice, False, "Unit Price!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, row.Index).Value).Equals(False) Then

                    Dim unitsInStock As Integer = IntegerMayBeEnteredIn(row.Cells, Me.colConsumableUnitsInStock)
                    Dim orderLevel As Integer = IntegerMayBeEnteredIn(row.Cells, Me.colConsumableOrderLevel)
                    Dim expiryDate As Date = DateMayBeEnteredIn(row.Cells, Me.colConsumableExpiryDate)
                    Dim warningDaysExpiryDate As Integer = oVariousOptions.ExpiryWarningDays
                    Dim remainingDaysExpiryDate As Integer = (expiryDate - Today).Days
                    Dim deficit As Integer = quantity - unitsInStock

                    If unitsInStock < quantity Then
                        If Not oVariousOptions.AllowPrescriptionToNegative() Then

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

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If expiryDate > AppData.NullDateValue AndAlso expiryDate < Today Then
                        If Not oVariousOptions.AllowPrescriptionExpiredConsumables() Then
                            message = "Expiry date for " + consumableName + " had reached. " + ControlChars.NewLine +
                                "The system does not allow to give a consumable that is expired. Please re-stock appropriately! "
                            Throw New ArgumentException(message)
                        Else
                            message = "Expiry date for " + consumableName + " had reached. " +
                                      ControlChars.NewLine + "Are you sure you want to continue?"
                            If DeleteMessage(message) = Windows.Forms.DialogResult.No Then Throw New ArgumentException("Action Cancelled!")
                        End If

                    ElseIf expiryDate > AppData.NullDateValue AndAlso remainingDaysExpiryDate <= warningDaysExpiryDate Then
                        message = "Consumable: " + consumableName + " has " + remainingDaysExpiryDate.ToString() +
                            " remaining day(s) to expire. Please re-stock appropriately!"
                        DisplayMessage(message)

                    ElseIf expiryDate = AppData.NullDateValue Then
                        message = "Expiry date for " + consumableName + " is not set. The system can not verify when this consumable will expire!"
                        DisplayMessage(message)

                    End If

                End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Next

            Return True

        Catch ex As Exception
            Me.tbcDrRoles.SelectTab(Me.tpgConsumables.Name)
            VerifyConsumablesEntries = False
            Throw ex

        End Try

    End Function

    Private Function CalculateTotalBill() As Decimal

        Dim totalBill As Decimal

        Try

            Dim extraChargeBill As Decimal = CalculateGridAmount(Me.dgvExtraCharge, Me.colExtraChargeAmount)
            Dim labTestsBill As Decimal = CalculateGridAmount(Me.dgvLabTests, Me.colLTUnitPrice)
            Dim radiologyBill As Decimal = CalculateGridAmount(Me.dgvRadiology, Me.colRadiologyUnitPrice)
            Dim prescriptionBill As Decimal = CalculateGridAmount(Me.dgvPrescription, Me.colAmount)
            Dim proceduresBill As Decimal = CalculateGridAmount(Me.dgvProcedures, Me.colUnitPrice)
            Dim theatreBill As Decimal = CalculateGridAmount(Me.dgvTheatre, Me.colTheatreAmount)
            Dim dentalBill As Decimal = CalculateGridAmount(Me.dgvDental, Me.colDentalAmount)
            Dim opticalBill As Decimal = CalculateGridAmount(Me.dgvOptical, Me.colOpticalAmount)
            Dim consumablesBill As Decimal = CalculateGridAmount(Me.dgvConsumables, Me.colConsumableAmount)
            Dim pathologyBill As Decimal = CalculateGridAmount(Me.dgvHistopathologyRequisition, Me.colPathologyUnitPrice)
            Dim cardiologyBill As Decimal = CalculateGridAmount(Me.dgvCardiology, Me.colCardiologyUnitPrice)


            totalBill = extraChargeBill + labTestsBill + radiologyBill + prescriptionBill + cardiologyBill +
                        proceduresBill + theatreBill + dentalBill + opticalBill + consumablesBill + pathologyBill

            Return totalBill

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        End Try

    End Function

#Region " ExtraCharge - Grid "

    Private Sub dgvExtraCharge_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvExtraCharge.CellBeginEdit

        If e.ColumnIndex <> Me.colItemName.Index OrElse Me.dgvExtraCharge.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvExtraCharge.CurrentCell.RowIndex
        _ExtraItemValue = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colItemName)

    End Sub

    Private Sub dgvExtraCharge_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExtraCharge.CellEndEdit

        Try

            If Me.colItemName.Items.Count < 1 Then Return
            Dim selectedRow As Integer = Me.dgvExtraCharge.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colItemName.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvExtraCharge.Rows.Count > 1 Then Me.SetExtraChargeEntries(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colExtraChargeQuantity.Index) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateExtraChargeAmount(selectedRow)
            Me.CalculateBillForExtraCharge()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colExtraChargeUnitPrice.Index) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateExtraChargeAmount(selectedRow)
            Me.CalculateBillForExtraCharge()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetExtraChargeEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colItemName)

            If CBool(Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Extra Item Name (" + _ExtraItemValue + ") can't be edited!")
                Me.dgvExtraCharge.Item(Me.colItemName.Name, selectedRow).Value = _ExtraItemValue
                Me.dgvExtraCharge.Item(Me.colItemName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvExtraCharge.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvExtraCharge.Rows(rowNo).Cells, Me.colItemName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Extra Item Name (" + enteredItem + ") already selected!")
                        Me.dgvExtraCharge.Item(Me.colItemName.Name, selectedRow).Value = _ExtraItemValue
                        Me.dgvExtraCharge.Item(Me.colItemName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim extraItemCode As String = SubstringRight(selectedItem)
            If extraChargeItems Is Nothing OrElse String.IsNullOrEmpty(extraItemCode) Then Return

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(extraItemCode, oItemCategoryID.Extras, billNo, billModesID, Me.GetAssociatedBillNo())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvExtraCharge.Item(Me.colExtraChargeQuantity.Name, selectedRow).Value = quantity
            Me.dgvExtraCharge.Item(Me.colExtraChargeUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateExtraChargeAmount(selectedRow)
            Me.CalculateBillForExtraCharge()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvExtraCharge_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvExtraCharge.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvExtraCharge.Item(Me.colExtraChargeSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvExtraCharge.Item(Me.colItemName.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Extras
            End With

            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub CalculateExtraChargeAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraChargeQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvExtraCharge.Rows(selectedRow).Cells, Me.colExtraChargeUnitPrice)

        Me.dgvExtraCharge.Item(Me.colExtraChargeAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Function CalculateBillForExtraCharge() As Decimal

        ResetControlsIn(Me.pnlBill)

        Try

            Dim totalBill As Decimal = CalculateGridAmount(Me.dgvExtraCharge, Me.colExtraChargeAmount)

            Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
            Me.stbBillWords.Text = NumberToWords(totalBill)

            Return totalBill

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0
        End Try

    End Function

    Private Sub LoadExtraCharge(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvExtraCharge.Rows.Clear()

            ' Load items not yet paid for

            Dim chargeItems As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Extras).Tables("Items")
            If chargeItems Is Nothing OrElse chargeItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To chargeItems.Rows.Count - 1

                Dim row As DataRow = chargeItems.Rows(pos)
                With Me.dgvExtraCharge

                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                    .Item(Me.colItemName.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colExtraChargeQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colExtraChargeUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colExtraChargeAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colExtraChargeSaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForExtraCharge()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim testCode As String = SubstringRight(selectedItem)
            If labTests Is Nothing OrElse String.IsNullOrEmpty(testCode) Then Return

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

            Dim unitPrice As Decimal = GetCustomFee(testCode, oItemCategoryID.Test, billNo, billModesID, Me.GetAssociatedBillNo())

            For Each row As DataRow In labTests.Select("TestCode = '" + testCode + "'")

                Me.dgvLabTests.Item(Me.colLTUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvLabTests.Item(Me.colLTQuantity.Name, selectedRow).Value = 1
                Me.dgvLabTests.Item(Me.colLaboratoryUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                Me.dgvLabTests.Item(Me.colLTItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvLabTests.Item(Me.colLTPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForLaboratory()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvLabTests_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvLabTests.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvLabTests.Item(Me.colLabTestsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvLabTests.Item(Me.colTest.Name, toDeleteRowNo).Value))

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
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Test
            End With

            DisplayMessage(oItems.Delete())

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

    Private Sub dgvLabTests_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvLabTests.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Function CalculateBillForLaboratory() As Decimal

        ResetControlsIn(Me.pnlBill)

        Try

            Dim totalBill As Decimal = CalculateGridAmount(Me.dgvLabTests, Me.colLTUnitPrice)
            Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
            Me.stbBillWords.Text = NumberToWords(totalBill)

            Return totalBill

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        End Try

    End Function

    Private Sub LoadLaboratory(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvLabTests.Rows.Clear()

            ' Load items not yet paid for

            Dim tests As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Test).Tables("Items")
            If tests Is Nothing OrElse tests.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To tests.Rows.Count - 1

                Dim row As DataRow = tests.Rows(pos)
                With Me.dgvLabTests

                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colTest.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colLTQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.ColLabNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colLaboratoryUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                    .Item(Me.colLTUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colLTItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colLTPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colLabTestsSaved.Name, pos).Value = True
                End With

            Next

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

            Dim examCode As String = SubstringRight(selectedItem)
            If radiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

            Dim unitPrice As Decimal = GetCustomFee(examCode, oItemCategoryID.Radiology, billNo, billModesID, Me.GetAssociatedBillNo())

            For Each row As DataRow In radiologyExaminations.Select("ExamCode = '" + examCode + "'")

                Me.dgvRadiology.Item(Me.colRadiologyUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvRadiology.Item(Me.colRadiologyCategory.Name, selectedRow).Value = StringEnteredIn(row, "RadiologyCategories")
                Me.dgvRadiology.Item(Me.colRadiologyQuantity.Name, selectedRow).Value = 1
                Me.dgvRadiology.Item(Me.colRadiologyItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvRadiology.Item(Me.colRadiologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForRadiology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub



    Private Sub dgvRadiology_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvRadiology.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvRadiology.Item(Me.colRadiologySaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvRadiology.Item(Me.colExamFullName.Name, toDeleteRowNo).Value))

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
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Radiology
            End With

            DisplayMessage(oItems.Delete())

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

    Private Function CalculateBillForRadiology() As Decimal

        Try

            ResetControlsIn(Me.pnlBill)

            Dim totalBill As Decimal = CalculateGridAmount(Me.dgvRadiology, Me.colRadiologyUnitPrice)

            Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
            Me.stbBillWords.Text = NumberToWords(totalBill)

            Return totalBill

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0
        End Try

    End Function

    Private Sub ShowRadiologyCategory(ByVal examCode As String, ByVal pos As Integer)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If radiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            For Each row As DataRow In radiologyExaminations.Select("ExamCode = '" + examCode + "'")
                Me.dgvRadiology.Item(Me.colRadiologyCategory.Name, pos).Value = StringMayBeEnteredIn(row, "RadiologyCategories")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadRadiology(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvRadiology.Rows.Clear()

            ' Load items not yet paid for

            Dim radiology As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Radiology).Tables("Items")
            If radiology Is Nothing OrElse radiology.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To radiology.Rows.Count - 1

                Dim row As DataRow = radiology.Rows(pos)
                With Me.dgvRadiology

                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colExamFullName.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colRadiologyIndication.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colRadiologyQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    Me.ShowRadiologyCategory(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colRadiologyUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colRadiologyItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colRadiologyPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colRadiologySaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForRadiology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

    Private Sub dgvHistopathologyRequisition_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvHistopathologyRequisition.CellBeginEdit
        If e.ColumnIndex <> Me.colPathologyExamFullName.Index OrElse Me.dgvHistopathologyRequisition.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvHistopathologyRequisition.CurrentCell.RowIndex
        _ExamNameValue = StringMayBeEnteredIn(Me.dgvHistopathologyRequisition.Rows(selectedRow).Cells, Me.colPathologyExamFullName)

    End Sub

    Private Sub dgvHistopathologyRequisition_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvHistopathologyRequisition.CellEndEdit

        Try

            If Me.colPathologyExamFullName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colPathologyExamFullName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvHistopathologyRequisition.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvHistopathologyRequisition.CurrentCell.RowIndex
                    Me.SetPathologyExaminationsEntries(selectedRow)

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetPathologyExaminationsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvHistopathologyRequisition.Rows(selectedRow).Cells, Me.colPathologyExamFullName)

            If CBool(Me.dgvHistopathologyRequisition.Item(Me.colPathologySaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Pathology Examination (" + _ExamNameValue + ") can't be edited!")
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyExamFullName.Name, selectedRow).Value = _ExamNameValue
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyExamFullName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvHistopathologyRequisition.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvHistopathologyRequisition.Rows(rowNo).Cells, Me.colPathologyExamFullName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Examination (" + enteredItem + ") already selected!")
                        Me.dgvHistopathologyRequisition.Item(Me.colPathologyExamFullName.Name, selectedRow).Value = _ExamNameValue
                        Me.dgvHistopathologyRequisition.Item(Me.colPathologyExamFullName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim examCode As String = SubstringRight(selectedItem)
            If pathologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            Dim unitPrice As Decimal = GetCustomFee(examCode, oItemCategoryID.Pathology, billNo, billModesID, Me.GetAssociatedBillNo())
            For Each row As DataRow In pathologyExaminations.Select("ExamCode = '" + examCode + "'")

                Me.dgvHistopathologyRequisition.Item(Me.colPathologyUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyCategory.Name, selectedRow).Value = StringEnteredIn(row, "PathologyCategories")
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyQuantity.Name, selectedRow).Value = 1
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForPathology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvHistopathologyRequisition_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvHistopathologyRequisition.UserDeletedRow
        Me.CalculateBillForPathology()
    End Sub

    Private Sub dgvHistopathologyRequisition_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvHistopathologyRequisition.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateBillForPathology()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvHistopathologyRequisition.RowCount - 1

            If IsNumeric(Me.dgvHistopathologyRequisition.Item(Me.colPathologyUnitPrice.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvHistopathologyRequisition.Item(Me.colPathologyUnitPrice.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub ShowPathologyCategory(ByVal examCode As String, ByVal pos As Integer)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If pathologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            For Each row As DataRow In pathologyExaminations.Select("ExamCode = '" + examCode + "'")
                Me.dgvHistopathologyRequisition.Item(Me.colPathologyCategory.Name, pos).Value = StringMayBeEnteredIn(row, "PathologyCategories")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadPathology(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvHistopathologyRequisition.Rows.Clear()

            ' Load items not yet paid for
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim pathology As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Pathology).Tables("Items")
            If pathology Is Nothing OrElse pathology.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To pathology.Rows.Count - 1

                Dim row As DataRow = pathology.Rows(pos)
                With Me.dgvHistopathologyRequisition

                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colPathologyExamFullName.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colPathologyIndication.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colPathologyQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    Me.ShowPathologyCategory(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colPathologyUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colPathologyItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colPathologyPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colPathologySaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForPathology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CalculatePathologyAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvHistopathologyRequisition.Rows(selectedRow).Cells, Me.colPathologyQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvHistopathologyRequisition.Rows(selectedRow).Cells, Me.colPathologyUnitPrice)

        Me.dgvHistopathologyRequisition.Item(Me.colPathologyUnitPrice.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

#Region " Prescription - Grid "

    Private Sub dgvPrescription_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPrescription.CellBeginEdit

        If e.ColumnIndex <> Me.colDrug.Index OrElse Me.dgvPrescription.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
        _PrescriptionDrugValue = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrug)

    End Sub

    Private Sub dgvPrescription_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellEndEdit

        Try
         Dim selectedRow As Integer = Me.dgvPrescription.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.colDrugNo.Index) Then

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
            ElseIf e.ColumnIndex.Equals(Me.ColBarCode.Index) Then
                Me.SetDrugsEntriesWithBarCodes(selectedRow)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo))

            Me.SetDrugsEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Drug No (" + Me._DrugNo + ") can't be edited!")
                Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(rowNo).Cells, Me.colDrugNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Drug No (" + enteredItem + ") already selected!")
                        Me.dgvPrescription.Rows.RemoveAt(selectedRow)
                        Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo
                        Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Selected = True
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


    Private Sub SetDrugsEntriesWithBarCodes(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.ColBarCode)

            Me.SetDrugsEntriesWithBarCodes(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDrugsEntriesWithBarCodes(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Bar Code (" + Me._BarCode + ") can't be edited!")
                Me.dgvPrescription.Item(Me.ColBarCode.Name, selectedRow).Value = Me._BarCode
                Me.dgvPrescription.Item(Me.ColBarCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(rowNo).Cells, Me.ColBarCode)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Bar Code (" + enteredItem + ") already selected!")
                        Me.dgvPrescription.Rows.RemoveAt(selectedRow)
                        Me.dgvPrescription.Item(Me.ColBarCode.Name, selectedRow).Value = Me._BarCode
                        Me.dgvPrescription.Item(Me.ColBarCode.Name, selectedRow).Selected = True
                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailBarCodePrescribedDrug(selectedRow)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetConsumableEntriesWithBarCodes(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.ColConsumableBarCode)

            Me.SetConsumableEntriesWithBarCodes(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetConsumableEntriesWithBarCodes(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Bar Code (" + Me._BarCode + ") can't be edited!")
                Me.dgvConsumables.Item(Me.ColConsumableBarCode.Name, selectedRow).Value = Me._BarCode
                Me.dgvConsumables.Item(Me.ColConsumableBarCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(rowNo).Cells, Me.ColConsumableBarCode)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Bar Code (" + enteredItem + ") already selected!")
                        Me.dgvConsumables.Rows.RemoveAt(selectedRow)
                        Me.dgvConsumables.Item(Me.ColConsumableBarCode.Name, selectedRow).Value = Me._BarCode
                        Me.dgvConsumables.Item(Me.ColConsumableBarCode.Name, selectedRow).Selected = True
                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailBarCodeConsumables(selectedRow)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvPrescription_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPrescription.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvPrescription.Item(Me.colDrugNo.Name, toDeleteRowNo).Value))

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
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oItems.Delete())
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

    Private Function CalculateBillForPrescriptions() As Decimal

        Try

            ResetControlsIn(Me.pnlBill)

            Dim totalBill As Decimal = CalculateGridAmount(Me.dgvPrescription, Me.colAmount)
            Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
            Me.stbBillWords.Text = NumberToWords(totalBill)

            Return totalBill

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        End Try

    End Function

    Private Sub DetailPrescribedDrug(ByVal selectedRow As Integer)

        Dim message As String
        Dim drugSelected As String = String.Empty
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim drugNo As String = String.Empty
        Dim oVariousOptions As New VariousOptions()
        Try

            If Me.dgvPrescription.Rows.Count > 1 Then drugNo = SubstringRight(StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo))

            If String.IsNullOrEmpty(drugNo) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
            If drugs Is Nothing OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)

            Dim availableStock As Integer = GetAvailableStock(drugNo)
            Dim drugName As String = StringEnteredIn(row, "DrugName", "Drug Name!")
            Dim unitPrice As Decimal = GetCustomFee(drugNo, oItemCategoryID.Drug, billNo, billModesID, Me.GetAssociatedBillNo())
            Dim halted As Boolean = BooleanMayBeEnteredIn(row, "Halted")
            Dim hasAlternateDrugs As Boolean = BooleanMayBeEnteredIn(row, "HasAlternateDrugs")

            With Me.dgvPrescription
                .Item(Me.colDrugNo.Name, selectedRow).Value = drugNo.ToUpper()
                .Item(Me.colAvailableStock.Name, selectedRow).Value = availableStock
                .Item(Me.colDrug.Name, selectedRow).Value = drugName
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
                If oVariousOptions.DisableDosageAndDuration Then
                    .Item(Me.colDuration.Name, selectedRow).Value = 1
                    .Item(Me.colDosage.Name, selectedRow).Value = "1x1"
                End If
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
            Me.dgvPrescription.Item(Me.colDrugNo.Name, selectedRow).Value = Me._DrugNo.ToUpper()
            Throw ex

        End Try

    End Sub


    Private Sub DetailBarCodePrescribedDrug(ByVal selectedRow As Integer)

        Dim drugSelected As String = String.Empty
        Dim oBarCodeDetails As New SyncSoft.SQLDb.BarCodeDetails
        Dim barCode As String = String.Empty
        Try

            If Me.dgvPrescription.Rows.Count > 1 Then barCode = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.ColBarCode)

            If String.IsNullOrEmpty(barCode) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim electedRow As Integer
            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo))
            Dim barCodeDetails As DataTable = oBarCodeDetails.GetBarCodeDetails(barCode).Tables("BarCodeDetails")
            If barCodeDetails Is Nothing OrElse String.IsNullOrEmpty(barCode) Then Return
            Dim row As DataRow = barCodeDetails.Rows(0)

            With Me.dgvPrescription
                .Item(Me.colDrugNo.Name, selectedRow).Value = StringEnteredIn(row, "ItemCode")
                SetDrugsEntries(selectedRow, selectedItem)

            End With



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception

        End Try

    End Sub

    Private Sub DetailBarCodeConsumables(ByVal selectedRow As Integer)

        Dim oBarCodeDetails As New SyncSoft.SQLDb.BarCodeDetails
        Dim cbarCode As String = String.Empty
        Try

            If Me.dgvConsumables.Rows.Count > 1 Then cbarCode = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.ColConsumableBarCode)

            If String.IsNullOrEmpty(cbarCode) Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'Dim electedRow As Integer
            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.ColConsumableNo)
            Dim barCodeDetails As DataTable = oBarCodeDetails.GetBarCodeDetails(cbarCode).Tables("BarCodeDetails")
            If barCodeDetails Is Nothing OrElse String.IsNullOrEmpty(cbarCode) Then Return
            Dim row As DataRow = barCodeDetails.Rows(0)

            With Me.dgvConsumables
                .Item(Me.ColConsumableNo.Name, selectedRow).Value = StringEnteredIn(row, "ItemCode")

                SetConsumableEntries(selectedRow, selectedItem)

            End With



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


        Catch ex As Exception

        End Try

    End Sub

    Private Sub CalculateDrugAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugUnitPrice)

        If quantity < 0 Then
            Me.dgvPrescription.Item(Me.colDrugQuantity.Name, selectedRow).Value = String.Empty
            Me.dgvPrescription.Item(Me.colAmount.Name, selectedRow).Value = String.Empty
            Throw New ArgumentException("Negative values not allowed for Quantity")

        End If

        Me.dgvPrescription.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Sub CalculateDrugQuantity(ByVal selectedRow As Integer, ByVal calculateDuration As Boolean)
        Dim oVariousOptions As New VariousOptions()
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()
        Dim oDosageCalculationID As New LookupDataID.DosageCalculationID()

        Try
            If Not oVariousOptions.DisableDosageAndDuration Then


                Dim quantity As Single = 0
                Dim drugNo As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDrugNo)

                Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
                If drugs Is Nothing OrElse drugs.Rows.Count < 1 OrElse String.IsNullOrEmpty(drugNo) Then Return
                Dim row As DataRow = drugs.Rows(0)

                Dim dosage As String = StringMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDosage)
                Dim duration As Integer = IntegerMayBeEnteredIn(Me.dgvPrescription.Rows(selectedRow).Cells, Me.colDuration)

                If duration < 0 Then
                    Me.dgvPrescription.Item(Me.colDuration.Name, selectedRow).Value = String.Empty
                    Throw New ArgumentException("Negative values not allowed for Duration")

                End If

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
            End If
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

    Private Sub LoadPrescriptions(ByVal visitNo As String, ByVal fromPreviousVisit As Boolean)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        If fromPreviousVisit = False Then
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
                        .Item(Me.colDrugNo.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                        .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "ItemName")
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

                        'If (Int32.Parse(.Item(Me.colDrugQuantity.Name, pos).Value.ToString) <= 0) Then
                        '    MessageBox.Show(.Item(Me.colDrugQuantity.Name, pos).Value.ToString)
                        '    '.Rows.Remove(Me.dgvPrescription.Rows(pos))
                        '    .Rows.RemoveAt(pos)
                        'End If
                        ' MessageBox.Show(.Item(Me.colDrugQuantity.Name, pos).Value.ToString)

                    End With


                Next

            Catch ex As Exception
                Throw ex

            End Try

        ElseIf fromPreviousVisit = True Then
            Try

                Me.dgvPrescription.Rows.Clear()
                ' Load items not yet paid for
                Dim drugs As DataTable = oItems.GetSelfRequestItems(visitNo, oItemCategoryID.Drug).Tables("Items")
                If drugs Is Nothing OrElse drugs.Rows.Count < 1 Then Return

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For pos As Integer = 0 To drugs.Rows.Count - 1

                    Dim row As DataRow = drugs.Rows(pos)
                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                    With Me.dgvPrescription
                        ' Ensure that you add a new row
                        .Rows.Add()
                        .Item(Me.colDrugNo.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                        .Item(Me.colDrug.Name, pos).Value = StringEnteredIn(row, "ItemName")
                        Me.ShowDrugDetails(StringEnteredIn(row, "ItemCode"), pos)
                        .Item(Me.colDosage.Name, pos).Value = StringMayBeEnteredIn(row, "Dosage")
                        .Item(Me.colDuration.Name, pos).Value = IntegerMayBeEnteredIn(row, "Duration")
                        .Item(Me.colDrugQuantity.Name, pos).Value = IntegerEnteredIn(row, "Balance")
                        .Item(Me.colPrescriptionUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                        .Item(Me.colDrugUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                        .Item(Me.colAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                        .Item(Me.colDrugFormula.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                        .Item(Me.colDrugItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                        .Item(Me.colDrugPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                        .Item(Me.colPrescriptionSaved.Name, pos).Value = True

                        'If (Int32.Parse(.Item(Me.colDrugQuantity.Name, pos).Value.ToString) <= 0) Then
                        '    MessageBox.Show(.Item(Me.colDrugQuantity.Name, pos).Value.ToString)
                        '    '.Rows.Remove(Me.dgvPrescription.Rows(pos))
                        '    .Rows.RemoveAt(pos)
                        'End If
                        ' MessageBox.Show(.Item(Me.colDrugQuantity.Name, pos).Value.ToString)
                    End With
                Next
            Catch ex As Exception
                Throw ex
            End Try
        End If




    End Sub

    Private Function GetDrugs() As DataTable

        Dim drugs As DataTable
        Dim oSetupData As New SetupData()
        Dim oDrugs As New SyncSoft.SQLDb.Drugs()

        Try

            ' Load from drugs

            If Not InitOptions.LoadDrugsAtStart Then
                drugs = oDrugs.GetDrugs().Tables("Drugs")
                oSetupData.Drugs = drugs
            Else : drugs = oSetupData.Drugs
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return drugs
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function

    Private Sub dgvPrescription_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPrescription.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Drugs", "Drug No", "Drug", Me.GetDrugs(), "DrugFullName",
                                                                     "DrugNo", "DrugName", Me.dgvPrescription, Me.colDrugNo, e.RowIndex)

            Me._DrugNo = StringMayBeEnteredIn(Me.dgvPrescription.Rows(e.RowIndex).Cells, Me.colDrugNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColDrugselect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvPrescription.Rows(e.RowIndex).IsNewRow Then

                Me.dgvPrescription.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)

            ElseIf Me.ColDrugselect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnFindByFingerprint_Click(sender As System.Object, e As System.EventArgs) Handles btnFindByFingerprint.Click
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

    Private Sub btnEnrollFingerprint_Click(sender As System.Object, e As System.EventArgs) Handles btnEnrollFingerprint.Click
        Dim oVariousOptions As New VariousOptions()
        Dim oFingerprintDeviceID As New LookupCommDataID.FingerprintDeviceID()

        Try

            If oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.CrossMatch.ToUpper()) Then
                Dim fFingerprintCapture As New FingerprintCapture(CaptureType.Enroll)
                fFingerprintCapture.ShowDialog()
                Me.chkFingerprintCaptured.Checked = (Me.oCrossMatchTemplate.Fingerprint IsNot Nothing)

            ElseIf oVariousOptions.FingerprintDevice.ToUpper().Equals(oFingerprintDeviceID.DigitalPersona.ToUpper()) Then
                Dim fEnrollment As New Enrollment()
                fEnrollment.ShowDialog()
                Me.chkFingerprintCaptured.Checked = (Me.oDigitalPersonaTemplate.Template IsNot Nothing)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

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

            ElseIf e.ColumnIndex.Equals(Me.colUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForProcedures()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

            If procedures Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Procedure, billNo, billModesID, Me.GetAssociatedBillNo())

            For Each row As DataRow In procedures.Select("ProcedureCode = '" + selectedItem + "'")
                Me.dgvProcedures.Item(Me.colUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvProcedures.Item(Me.colICDProcedureCode.Name, selectedRow).Value = selectedItem
                Me.dgvProcedures.Item(Me.colQuantity.Name, selectedRow).Value = 1
                Me.dgvProcedures.Item(Me.colProcedureItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvProcedures.Item(Me.colProcedurePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForProcedures()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvProcedures_UserAddedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvProcedures.UserAddedRow
        Me.dgvProcedures.Item(Me.colQuantity.Name, e.Row.Index - 1).Value = 1
    End Sub

    Private Sub dgvProcedures_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvProcedures.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oItems As New SyncSoft.SQLDb.Items()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvProcedures.Item(Me.colProceduresSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvProcedures.Item(Me.colProcedureCode.Name, toDeleteRowNo).Value))

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
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oItems.Delete())

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

    Private Function CalculateBillForProcedures() As Decimal

        Try
            ResetControlsIn(Me.pnlBill)

            Dim totalBill As Decimal = CalculateGridAmount(Me.dgvProcedures, Me.colUnitPrice)
            Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
            Me.stbBillWords.Text = NumberToWords(totalBill)

            Return totalBill

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        End Try

    End Function

    Private Sub LoadProcedures(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvProcedures.Rows.Clear()

            ' Load items not yet paid for

            Dim procedure As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Procedure).Tables("Items")
            If procedure Is Nothing OrElse procedure.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To procedure.Rows.Count - 1

                Dim row As DataRow = procedure.Rows(pos)

                With Me.dgvProcedures
                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colICDProcedureCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colProcedureNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colProcedureItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colProcedurePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colProceduresSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForProcedures()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTheatreAmount(selectedRow)
            Me.CalculateBillForTheatre()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colTheatreUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTheatreAmount(selectedRow)
            Me.CalculateBillForTheatre()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

            If theatreServices Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Theatre, billNo, billModesID, Me.GetAssociatedBillNo())
            Dim quantity As Integer = 1

            For Each row As DataRow In theatreServices.Select("TheatreCode = '" + selectedItem + "'")
                Me.dgvTheatre.Item(Me.colTheatreUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvTheatre.Item(Me.colICDTheatreCode.Name, selectedRow).Value = selectedItem
                Me.dgvTheatre.Item(Me.colTheatreQuantity.Name, selectedRow).Value = quantity
                Me.dgvTheatre.Item(Me.colTheatreItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvTheatre.Item(Me.colTheatrePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTheatreAmount(selectedRow)
            Me.CalculateBillForTheatre()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvTheatre_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvTheatre.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvTheatre.Item(Me.colTheatreSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = CStr(Me.dgvTheatre.Item(Me.colTheatreCode.Name, toDeleteRowNo).Value)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.btnDelete, AccessRights.Delete)
            If Me.btnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Theatre
            End With

            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub CalculateTheatreAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvTheatre.Rows(selectedRow).Cells, Me.colTheatreUnitPrice)

        Me.dgvTheatre.Item(Me.colTheatreAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Function CalculateBillForTheatre() As Decimal

        Try
            ResetControlsIn(Me.pnlBill)

            Dim totalBill As Decimal = CalculateGridAmount(Me.dgvTheatre, Me.colTheatreAmount)
            Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
            Me.stbBillWords.Text = NumberToWords(totalBill)

            Return totalBill

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        End Try

    End Function

    Private Sub LoadTheatre(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvTheatre.Rows.Clear()

            ' Load items not yet paid for

            Dim theatre As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Theatre).Tables("Items")
            If theatre Is Nothing OrElse theatre.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To theatre.Rows.Count - 1

                Dim row As DataRow = theatre.Rows(pos)
                With Me.dgvTheatre

                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                    .Item(Me.colTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colICDTheatreCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colTheatreNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colTheatreQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colTheatreUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colTheatreAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colTheatreItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colTheatrePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colTheatreSaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForTheatre()
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

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

            If dentalServices Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Dental, billNo, billModesID, Me.GetAssociatedBillNo())
            Dim quantity As Integer = 1

            For Each row As DataRow In dentalServices.Select("DentalCode = '" + selectedItem + "'")
                Me.dgvDental.Item(Me.colDentalUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvDental.Item(Me.colDentalQuantity.Name, selectedRow).Value = quantity
                Me.dgvDental.Item(Me.colDentalItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvDental.Item(Me.colDentalPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateDentalAmount(selectedRow)
            Me.CalculateBillForDental()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvDental_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDental.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvDental.Item(Me.colDentalSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = CStr(Me.dgvDental.Item(Me.colDentalCode.Name, toDeleteRowNo).Value)

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
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Dental
            End With

            DisplayMessage(oItems.Delete())

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

    Private Sub CalculateDentalAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvDental.Rows(selectedRow).Cells, Me.colDentalUnitPrice)

        Me.dgvDental.Item(Me.colDentalAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Function CalculateBillForDental() As Decimal

        Try
            ResetControlsIn(Me.pnlBill)

            Dim totalBill As Decimal = CalculateGridAmount(Me.dgvDental, Me.colDentalAmount)
            Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
            Me.stbBillWords.Text = NumberToWords(totalBill)

            Return totalBill

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        End Try

    End Function

    Private Sub LoadDental(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvDental.Rows.Clear()

            ' Load items not yet paid for

            Dim dental As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Dental).Tables("Items")
            If dental Is Nothing OrElse dental.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To dental.Rows.Count - 1

                Dim row As DataRow = dental.Rows(pos)
                With Me.dgvDental

                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)

                    .Item(Me.colDentalCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colDentalNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colDentalQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colDentalUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colDentalAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colDentalItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colDentalPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colDentalSaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForDental()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadDentalReports(ByVal visitNo As String)

        'Dim oDentalReports As New SyncSoft.SQLDb.DentalReports()

        'Try

        '    ' Load from Lab DentalReports
        '    Dim dentalReports As DataTable = oDentalReports.GetDentalReports(visitNo).Tables("DentalReports")
        '    If dentalReports Is Nothing Then Return

        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '    LoadGridData(Me.dgvDentalReports, dentalReports)
        '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        'Catch ex As Exception
        '    Throw ex

        'End Try

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
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateOpticalAmount(selectedRow)
            Me.CalculateBillForOptical()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf e.ColumnIndex.Equals(Me.colOpticalUnitPrice.Index) Then
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateOpticalAmount(selectedRow)
            Me.CalculateBillForOptical()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

            If opticalServices Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return
            Dim unitPrice As Decimal = GetCustomFee(selectedItem, oItemCategoryID.Optical, billNo, billModesID, Me.GetAssociatedBillNo())
            Dim quantity As Integer = 1

            For Each row As DataRow In opticalServices.Select("OpticalCode = '" + selectedItem + "'")
                Me.dgvOptical.Item(Me.colOpticalUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvOptical.Item(Me.colOpticalCategory.Name, selectedRow).Value = StringEnteredIn(row, "OpticalCategory")
                Me.dgvOptical.Item(Me.colOpticalQuantity.Name, selectedRow).Value = quantity
                Me.dgvOptical.Item(Me.colOpticalItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvOptical.Item(Me.colOpticalPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateOpticalAmount(selectedRow)
            Me.CalculateBillForOptical()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvOptical_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvOptical.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvOptical.Item(Me.colOpticalSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = CStr(Me.dgvOptical.Item(Me.colOpticalCode.Name, toDeleteRowNo).Value)

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
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Optical
            End With

            DisplayMessage(oItems.Delete())

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

    Private Sub CalculateOpticalAmount(ByVal selectedRow As Integer)

        Dim quantity As Single = SingleMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(Me.dgvOptical.Rows(selectedRow).Cells, Me.colOpticalUnitPrice)

        Me.dgvOptical.Item(Me.colOpticalAmount.Name, selectedRow).Value = FormatNumber(quantity * unitPrice, AppData.DecimalPlaces)

    End Sub

    Private Function CalculateBillForOptical() As Decimal

        Try
            ResetControlsIn(Me.pnlBill)

            Dim totalBill As Decimal = CalculateGridAmount(Me.dgvOptical, Me.colOpticalAmount)
            Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
            Me.stbBillWords.Text = NumberToWords(totalBill)

            Return totalBill

        Catch ex As Exception
            ErrorMessage(ex)
            Return 0

        End Try

    End Function

    Private Sub ShowOpticalCategory(ByVal opticalCode As String, ByVal pos As Integer)

        Try

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If opticalServices Is Nothing OrElse String.IsNullOrEmpty(OpticalCode) Then Return

            For Each row As DataRow In opticalServices.Select("OpticalCode = '" + OpticalCode + "'")
                Me.dgvOptical.Item(Me.colOpticalCategory.Name, pos).Value = StringMayBeEnteredIn(row, "OpticalCategory")
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadOptical(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvOptical.Rows.Clear()

            ' Load items not yet paid for

            Dim optical As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Optical).Tables("Items")
            If optical Is Nothing OrElse optical.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To optical.Rows.Count - 1

                Dim row As DataRow = optical.Rows(pos)
                With Me.dgvOptical

                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colOpticalCode.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    Me.ShowOpticalCategory(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colOpticalNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colOpticalQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colOpticalUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    Dim amount As Decimal = IntegerEnteredIn(row, "Quantity") * DecimalEnteredIn(row, "UnitPrice", True)
                    .Item(Me.colOpticalAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colOpticalItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colOpticalPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colOpticalSaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForOptical()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Consumables - Grid "

    Private Sub dgvConsumables_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvConsumables.CellBeginEdit

        If e.ColumnIndex <> Me.ColConsumableNo.Index OrElse Me.dgvConsumables.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex
        _ConsumableItemValue = StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.ColConsumableNo)

    End Sub

    Private Function GetConsumables() As DataTable

        Dim consumables As DataTable
        Dim oSetupData As New SetupData()
        Dim oconsumables As New SyncSoft.SQLDb.ConsumableItems

        Try

            ' Load from Consumable Items

            If Not InitOptions.LoadConsumableItemsAtStart Then
                consumables = oconsumables.GetConsumableItems.Tables("ConsumableItems")
                oSetupData.ConsumableItems = consumables
            Else : consumables = oSetupData.ConsumableItems
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''
            Return consumables
            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)

        End Try

    End Function
    Private Sub dgvConsumables_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("ConsumableItems", "Consumable No", "Consumable", Me.GetConsumables(), "ConsumableFullName",
                                                                     "ConsumableNo", "ConsumableName", Me.dgvConsumables, Me.ColConsumableNo, e.RowIndex)

            Me._ConsumableNo = StringMayBeEnteredIn(Me.dgvConsumables.Rows(e.RowIndex).Cells, Me.ColConsumableNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColConsSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvConsumables.Rows(e.RowIndex).IsNewRow Then

                Me.dgvConsumables.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetConsumableEntries(e.RowIndex)

            ElseIf Me.ColConsSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetConsumableEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub


    Private Sub dgvConsumables_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConsumables.CellEndEdit

        Try
            Dim selectedRow As Integer = Me.dgvConsumables.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.ColConsumableNo.Index) Then
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
            ElseIf e.ColumnIndex.Equals(Me.ColConsumableBarCode.Index) Then
                Me.SetConsumableEntriesWithBarCodes(selectedRow)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub


    Private Sub SetConsumableEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.ColConsumableNo))

            Me.SetConsumableEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetConsumableEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Consumable No (" + Me._ConsumableNo + ") can't be edited!")
                Me.dgvConsumables.Item(Me.ColConsumableNo.Name, selectedRow).Value = Me._ConsumableNo
                Me.dgvConsumables.Item(Me.ColConsumableNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvConsumables.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvConsumables.Rows(rowNo).Cells, Me.ColConsumableNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Consumable No (" + enteredItem + ") already selected!")
                        Me.dgvConsumables.Rows.RemoveAt(selectedRow)
                        Me.dgvConsumables.Item(Me.ColConsumableNo.Name, selectedRow).Value = Me._ConsumableNo
                        Me.dgvConsumables.Item(Me.ColConsumableNo.Name, selectedRow).Selected = True
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

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvConsumables.Item(Me.colConsumablesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvConsumables.Item(Me.ColConsumableNo.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Consumable
            End With

            DisplayMessage(oItems.Delete())

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvConsumables.Rows.Count > 1 Then selectedItem = SubstringRight(StringMayBeEnteredIn(Me.dgvConsumables.Rows(selectedRow).Cells, Me.ColConsumableNo))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim consumableNo As String = (selectedItem)
            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")
            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")
            If consumableItems Is Nothing OrElse String.IsNullOrEmpty(consumableNo) Then Return
            Dim row As DataRow = consumableItems.Rows(0)
            Dim consumableName As String = StringEnteredIn(row, "ConsumableName", "Consumable Name!")
            Dim quantity As Integer = 1
            Dim unitPrice As Decimal = GetCustomFee(consumableNo, oItemCategoryID.Consumable, billNo, billModesID, Me.GetAssociatedBillNo())

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With Me.dgvConsumables
                .Item(Me.ColConsumableNo.Name, selectedRow).Value = consumableNo.ToUpper()
                .Item(Me.colConsumableQuantity.Name, selectedRow).Value = quantity
                .Item(Me.colConsumableName.Name, selectedRow).Value = consumableName
                .Item(Me.colConsumableUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                .Item(Me.colConsumableUnitsInStock.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colConsumableUnitMeasure.Name, selectedRow).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colConsumableExpiryDate.Name, selectedRow).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colConsumableOrderLevel.Name, selectedRow).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colConsumableAlternateName.Name, selectedRow).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colConsumableItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                .Item(Me.colConsumablePayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)
                .Item(Me.colConsumableHalted.Name, selectedRow).Value = BooleanMayBeEnteredIn(row, "Halted")
            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub ShowConsumableDetails(ByVal consumableNo As String, ByVal pos As Integer)

        Dim oConsumableItems As New SyncSoft.SQLDb.ConsumableItems()

        Try

            Dim consumableItems As DataTable = oConsumableItems.GetConsumableItems(consumableNo).Tables("ConsumableItems")

            If consumableItems Is Nothing OrElse consumableNo Is Nothing Then Return
            Dim row As DataRow = consumableItems.Rows(0)

            With Me.dgvConsumables
                .Item(Me.colConsumableUnitsInStock.Name, pos).Value = IntegerMayBeEnteredIn(row, "UnitsInStock")
                .Item(Me.colConsumableUnitMeasure.Name, pos).Value = StringEnteredIn(row, "UnitMeasure")
                .Item(Me.colConsumableExpiryDate.Name, pos).Value = FormatDate(DateMayBeEnteredIn(row, "ExpiryDate"), True)
                .Item(Me.colConsumableOrderLevel.Name, pos).Value = IntegerMayBeEnteredIn(row, "OrderLevel")
                .Item(Me.colConsumableAlternateName.Name, pos).Value = StringMayBeEnteredIn(row, "AlternateName")
                .Item(Me.colConsumableHalted.Name, pos).Value = BooleanMayBeEnteredIn(row, "Halted")
            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadConsumables(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvConsumables.Rows.Clear()

            ' Load items not yet paid for

            Dim consumableItems As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Consumable).Tables("Items")
            If consumableItems Is Nothing OrElse consumableItems.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To consumableItems.Rows.Count - 1

                Dim row As DataRow = consumableItems.Rows(pos)

                With Me.dgvConsumables

                    ' Ensure that you add a new row
                    .Rows.Add()

                    Dim quantity As Integer = IntegerEnteredIn(row, "Quantity")
                    Dim unitPrice As Decimal = DecimalEnteredIn(row, "UnitPrice", True)
                    Dim amount As Decimal = quantity * unitPrice


                    .Item(Me.ColConsumableNo.Name, pos).Value = StringEnteredIn(row, "ItemCode")
                    .Item(Me.colConsumableName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colConsumableQuantity.Name, pos).Value = quantity
                    .Item(Me.colConsumableNotes.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colConsumableUnitPrice.Name, pos).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                    .Item(Me.colConsumableAmount.Name, pos).Value = FormatNumber(amount, AppData.DecimalPlaces)
                    .Item(Me.colConsumablesSaved.Name, pos).Value = True
                    .Item(Me.colConsumableItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colConsumablePayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    Me.ShowConsumableDetails(StringEnteredIn(row, "ItemCode"), pos)

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForConsumables()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Cardiology - Grid "

    Private Sub dgvCardiology_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvCardiology.CellBeginEdit

        If e.ColumnIndex <> Me.colCardiologyExamFullName.Index OrElse Me.dgvCardiology.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvCardiology.CurrentCell.RowIndex
        _ExamNameValue = StringMayBeEnteredIn(Me.dgvCardiology.Rows(selectedRow).Cells, Me.colCardiologyExamFullName)

    End Sub

    Private Sub dgvCardiology_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCardiology.CellEndEdit

        Try

            If Me.colCardiologyExamFullName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colCardiologyExamFullName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvCardiology.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvCardiology.CurrentCell.RowIndex
                    Me.SetCardiologyExaminationsEntries(selectedRow)

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetCardiologyExaminationsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvCardiology.Rows(selectedRow).Cells, Me.colCardiologyExamFullName)

            If CBool(Me.dgvCardiology.Item(Me.colCardiologySaved.Name, selectedRow).Value).Equals(True) Then

                DisplayMessage("Examination (" + _ExamNameValue + ") can't be edited!")
                Me.dgvCardiology.Item(Me.colCardiologyExamFullName.Name, selectedRow).Value = _ExamNameValue
                Me.dgvCardiology.Item(Me.colCardiologyExamFullName.Name, selectedRow).Selected = True

                Return

            End If

            For rowNo As Integer = 0 To Me.dgvCardiology.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvCardiology.Rows(rowNo).Cells, Me.colCardiologyExamFullName)
                    If enteredItem.Equals(selectedItem) Then
                        DisplayMessage("Examination (" + enteredItem + ") already selected!")
                        Me.dgvCardiology.Item(Me.colCardiologyExamFullName.Name, selectedRow).Value = _ExamNameValue
                        Me.dgvCardiology.Item(Me.colCardiologyExamFullName.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column ''''''''''''''''
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim billNo As String = RevertText(StringMayBeEnteredIn(Me.cboBillNo))
            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Bill Mode!")

            
            Dim examCode As String = SubstringRight(selectedItem)
            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

            If cardiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

           
            Dim unitPrice As Decimal = GetCustomFee(examCode, oItemCategoryID.Cardiology, billNo, billModesID, Me.GetAssociatedBillNo())
          
            For Each row As DataRow In CardiologyExaminations.Select("ExamCode = '" + examCode + "'")

                Me.dgvCardiology.Item(Me.colCardiologyUnitPrice.Name, selectedRow).Value = FormatNumber(unitPrice, AppData.DecimalPlaces)
                Me.dgvCardiology.Item(Me.colCardiologyCategory.Name, selectedRow).Value = StringEnteredIn(row, "CardiologyCategories")
                Me.dgvCardiology.Item(Me.ColCardiologySite.Name, selectedRow).Value = StringEnteredIn(row, "CardiologySites")
                Me.dgvCardiology.Item(Me.colCardiologyQuantity.Name, selectedRow).Value = 1
                Me.dgvCardiology.Item(Me.colCardiologyItemStatus.Name, selectedRow).Value = GetLookupDataDes(oItemStatusID.Pending)
                Me.dgvCardiology.Item(Me.ColCardiologyRequest.Name, selectedRow).Value = CurrentUser.FullName
                Me.dgvCardiology.Item(Me.colCardiologyPayStatus.Name, selectedRow).Value = GetLookupDataDes(oPayStatusID.NotPaid)


            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForCardiology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvCardiology_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvCardiology.UserDeletingRow

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItems As New SyncSoft.SQLDb.Items()
            Dim toDeleteRowNo As Integer = e.Row.Index

         
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim itemCode As String = SubstringRight(CStr(Me.dgvCardiology.Item(Me.colCardiologyExamFullName.Name, toDeleteRowNo).Value))

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
            With oItems
                .VisitNo = visitNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Cardiology
            End With

            DisplayMessage(oItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvCardiology_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvCardiology.UserDeletedRow
        Me.CalculateBillForCardiology()
    End Sub

    Private Sub dgvCardiology_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvCardiology.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateBillForCardiology()

        Dim totalBill As Decimal

        ResetControlsIn(Me.pnlBill)

        For rowNo As Integer = 0 To Me.dgvCardiology.RowCount - 1

            If IsNumeric(Me.dgvCardiology.Item(Me.colCardiologyUnitPrice.Name, rowNo).Value) Then
                totalBill += CDec(Me.dgvCardiology.Item(Me.colCardiologyUnitPrice.Name, rowNo).Value)
            Else : totalBill += 0
            End If
        Next

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub ShowCardiologyCategory(ByVal examCode As String, ByVal pos As Integer)

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If CardiologyExaminations Is Nothing OrElse String.IsNullOrEmpty(examCode) Then Return

            For Each row As DataRow In CardiologyExaminations.Select("ExamCode = '" + examCode + "'")
                Me.dgvCardiology.Item(Me.colCardiologyCategory.Name, pos).Value = StringMayBeEnteredIn(row, "CardiologyCategories")
                Me.dgvCardiology.Item(Me.ColCardiologySite.Name, pos).Value = StringMayBeEnteredIn(row, "CardiologySites")
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadCardiologyExaminations()

        Dim oCardiologyExaminations As New SyncSoft.SQLDb.CardiologyExaminations()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from CardiologyExaminations
            If Not InitOptions.LoadCardiologyExaminationsAtStart Then
                cardiologyExaminations = oCardiologyExaminations.GetCardiologyExaminations().Tables("CardiologyExaminations")
                oSetupData.CardiologyExaminations = cardiologyExaminations
            Else : cardiologyExaminations = oSetupData.CardiologyExaminations
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colCardiologyExamFullName, cardiologyExaminations, "ExamFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub LoadCardiology(ByVal visitNo As String)

        Dim oItems As New SyncSoft.SQLDb.Items()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvCardiology.Rows.Clear()

            ' Load items not yet paid for
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim Cardiology As DataTable = oItems.GetItems(visitNo, oItemCategoryID.Cardiology).Tables("Items")
            If Cardiology Is Nothing OrElse Cardiology.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For pos As Integer = 0 To Cardiology.Rows.Count - 1

                Dim row As DataRow = Cardiology.Rows(pos)
                With Me.dgvCardiology

                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colCardiologyExamFullName.Name, pos).Value = StringEnteredIn(row, "ItemFullName")
                    .Item(Me.colCardiologyIndication.Name, pos).Value = StringMayBeEnteredIn(row, "ItemDetails")
                    .Item(Me.colCardiologyQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    Me.ShowCardiologyCategory(StringEnteredIn(row, "ItemCode"), pos)
                    .Item(Me.colCardiologyUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colCardiologyItemStatus.Name, pos).Value = StringEnteredIn(row, "ItemStatus")
                    .Item(Me.colCardiologyPayStatus.Name, pos).Value = StringEnteredIn(row, "PayStatus")
                    .Item(Me.colCardiologyRequest.Name, pos).Value = StringMayBeEnteredIn(row, "CreatorFullName")
                    .Item(Me.colCardiologySaved.Name, pos).Value = True
                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForCardiology()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


    Private Sub SaveCardiology()

        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
        Dim oItemStatusID As New LookupDataID.ItemStatusID()
        Dim oPayStatusID As New LookupDataID.PayStatusID()
        Dim oAlertTypeID As New LookupDataID.AlertTypeID()
        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            Dim visitDate As Date = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
              For Each row As DataGridViewRow In Me.dgvCardiology.Rows
                If row.IsNewRow Then Exit For
                StringEnteredIn(row.Cells, Me.colCardiologyExamFullName, "Examination!")
                DecimalEnteredIn(row.Cells, Me.colCardiologyUnitPrice, False, "Unit Price!")
                StringEnteredIn(row.Cells, Me.colCardiologyIndication, "Indication!")
            Next

            Dim quantity As Integer = 1
            Dim coPayTypeID As String = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
            Dim coPayPercent As Single = Me.nbxCoPayPercent.GetSingle()

            For rowNo As Integer = 0 To Me.dgvCardiology.RowCount - 2

                Dim lItems As New List(Of DBConnect)
                Dim lItemsCASH As New List(Of DBConnect)
                Dim transactions As New List(Of TransactionList(Of DBConnect))

                Dim cells As DataGridViewCellCollection = Me.dgvCardiology.Rows(rowNo).Cells

                Dim itemCode As String = SubstringRight(StringEnteredIn(cells, Me.colCardiologyExamFullName))
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colCardiologyUnitPrice, False)
                Dim cashAmount As Decimal = CDec(quantity * unitPrice * coPayPercent) / 100

                Try

                    Using oItems As New SyncSoft.SQLDb.Items()
                        With oItems

                            .VisitNo = visitNo
                            .ItemCode = itemCode
                            .Quantity = quantity
                            .UnitPrice = unitPrice
                            .ItemDetails = StringEnteredIn(cells, Me.colCardiologyIndication, "Indication!")
                            .LastUpdate = visitDate
                            .ItemCategoryID = oItemCategoryID.Cardiology
                            .ItemStatusID = oItemStatusID.Pending
                            .PayStatusID = oPayStatusID.NotPaid
                            .LoginID = CurrentUser.LoginID

                            lItems.Add(oItems)

                        End With

                    End Using

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lItems, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If coPayTypeID.ToUpper().Equals(GetLookupDataDes(oCoPayTypeID.Percent).ToUpper()) Then
                        Using oItemsCASH As New SyncSoft.SQLDb.ItemsCASH()
                            With oItemsCASH
                                .VisitNo = visitNo
                                .ItemCode = itemCode
                                .ItemCategoryID = oItemCategoryID.Cardiology
                                .CashAmount = cashAmount
                                .CashPayStatusID = oPayStatusID.NotPaid
                            End With
                            lItemsCASH.Add(oItemsCASH)
                        End Using
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        transactions.Add(New TransactionList(Of DBConnect)(lItemsCASH, Action.Save))
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    If CBool(Me.dgvCardiology.Item(Me.colCardiologySaved.Name, rowNo).Value).Equals(False) Then
                        Try
                            If GetShortDate(visitDate) >= GetShortDate(Today.AddHours(-12)) Then

                                Using oAlerts As New SyncSoft.SQLDb.Alerts()
                                    With oAlerts

                                        .AlertTypeID = oAlertTypeID.Cardiology
                                        .VisitNo = visitNo
                                        .StaffNo = String.Empty
                                        .Notes = (rowNo + 1).ToString() + " Cardiology sent"
                                        .LoginID = CurrentUser.LoginID

                                        .Save()

                                    End With
                                End Using
                            End If

                        Catch ex As Exception
                            Exit Try
                        End Try
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.dgvCardiology.Item(Me.colCardiologySaved.Name, rowNo).Value = True
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Catch ex As Exception
                    ErrorMessage(ex)

                End Try

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ''Me.dgvCardiology.Rows.Clear()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#End Region


#Region " SelfRequests Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintSelfRequests()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintSelfRequests()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            dlgPrint.Document = docSelfRequests
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docSelfRequests.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docSelfRequests_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docSelfRequests.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = CSng(e.MarginBounds.Left / 100)
            Dim yPos As Single = CSng(e.MarginBounds.Top / 50)

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Self Request".ToUpper()

            Dim lastName As String = StringMayBeEnteredIn(Me.stbLastName)
            Dim firstName As String = StringMayBeEnteredIn(Me.stbFirstName)
            Dim middleName As String = StringMayBeEnteredIn(Me.stbMiddleName)
            Dim fullName As String = GetFullName(lastName, middleName, firstName)

            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim visitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim visitDate As String = StringMayBeEnteredIn(Me.dtpVisitDate)

            Dim amount As String = FormatNumber(Me.CalculateTotalBill(), AppData.DecimalPlaces)
            Dim amountWords As String = NumberToWords(Me.CalculateTotalBill())
            Dim textLEN As Integer = 35

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 7 * widthTopFirst

                .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                yPos += 3 * lineHeight

                .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(visitNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Total Bill: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(amount, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                If Not String.IsNullOrEmpty(amountWords) Then

                    yPos += lineHeight
                    amountWords = "(" + amountWords.Trim() + " ONLY)"
                    Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedWordsData As List(Of String) = WrapText(amountWords, textLEN)
                    If wrappedWordsData.Count > 1 Then
                        For pos As Integer = 0 To wrappedWordsData.Count - 1
                            amountWordsData.Append(wrappedWordsData(pos).Trim())
                            amountWordsData.Append(ControlChars.NewLine)
                        Next
                    Else : amountWordsData.Append(amountWords)
                    End If

                    .DrawString(amountWordsData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    Dim wordLines As Integer = amountWordsData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight
                End If

                Dim printedBy As String = "Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                                            Now.ToString("hh:mm tt") + " from " + AppData.AppTitle
                Dim footerData As New System.Text.StringBuilder(String.Empty)

                Dim wrappedFooterData As List(Of String) = WrapText(printedBy, textLEN)
                If wrappedFooterData.Count > 1 Then
                    For pos As Integer = 0 To wrappedFooterData.Count - 1
                        footerData.Append(wrappedFooterData(pos).Trim())
                        footerData.Append(ControlChars.NewLine)
                    Next
                Else : footerData.Append(printedBy)
                End If

                .DrawString(footerData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                yPos += lineHeight

            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Popup Menu "

    Private Sub cmsSelfRequests_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsSelfRequests.Opening

        Select Case Me.tbcDrRoles.SelectedTab.Name

            Case Me.tpgExtraCharge.Name
                Me.cmsSelfRequestsQuickSearch.Visible = True

            Case Me.tpgLaboratory.Name
                Me.cmsSelfRequestsQuickSearch.Visible = True

            Case Me.tpgRadiology.Name
                Me.cmsSelfRequestsQuickSearch.Visible = True

            Case Me.tpgPrescriptions.Name
                Me.cmsSelfRequestsQuickSearch.Visible = True

            Case Me.tpgProcedures.Name
                Me.cmsSelfRequestsQuickSearch.Visible = True

            Case Me.tpgTheatre.Name
                Me.cmsSelfRequestsQuickSearch.Visible = True

            Case Me.tpgDental.Name
                Me.cmsSelfRequestsQuickSearch.Visible = True

            Case Me.tpgOptical.Name
                Me.cmsSelfRequestsQuickSearch.Visible = True

            Case Me.tpgConsumables.Name
                Me.cmsSelfRequestsQuickSearch.Visible = True

            Case Else
                Me.cmsSelfRequestsQuickSearch.Visible = False

        End Select

    End Sub

    Private Sub cmsSelfRequestsQuickSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsSelfRequestsQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rowIndex As Integer

            Select Case Me.tbcDrRoles.SelectedTab.Name

                Case Me.tpgExtraCharge.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("ExtraChargeItems", Me.dgvExtraCharge, Me.colItemName)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvExtraCharge.NewRowIndex
                    If rowIndex > 0 Then Me.SetExtraChargeEntries(rowIndex - 1)
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
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Drugs", Me.dgvPrescription, Me.colDrugNo)
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

                Case Me.tpgTheatre.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("TheatreServices", Me.dgvTheatre, Me.colTheatreCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvTheatre.NewRowIndex
                    If rowIndex > 0 Then Me.SetTheatreEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgDental.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("DentalServices", Me.dgvDental, Me.colDentalCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvDental.NewRowIndex
                    If rowIndex > 0 Then Me.SetDentalServiceEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgOptical.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("OpticalServices", Me.dgvOptical, Me.colOpticalCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvOptical.NewRowIndex
                    If rowIndex > 0 Then Me.SetOpticalServiceEntries(rowIndex - 1)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case Me.tpgConsumables.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("ConsumableItems", Me.dgvConsumables, Me.ColConsumableNo)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvConsumables.NewRowIndex
                    If rowIndex > 0 Then Me.SetConsumableEntries(rowIndex - 1)
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
        Me.btnDelete.Visible = True
        Me.btnDelete.Enabled = False
        Me.btnSearch.Visible = True
        Me.chkUseExistingPatient.Checked = False
        Me.stbPatientNo.ReadOnly = False
        Me.stbVisitNo.ReadOnly = False
        Me.btnLoad.Visible = False
        Me.btnFindVisitNo.Visible = True

        Me.ResetControls()

        Me.chkPrintVisitOnSaving.Visible = False
        Me.chkPrintVisitOnSaving.Checked = False
        Me.btnPrint.Enabled = True

        Me.EnableVisitsCTLS(False)
        Me.ResetAssociatedBillControls(False)

    End Sub

    Public Sub Save()

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oVariousOptions As New VariousOptions()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.btnDelete.Visible = False
        Me.btnDelete.Enabled = False
        Me.btnSearch.Visible = False

        Me.stbPatientNo.ReadOnly = InitOptions.PatientNoLocked
        Me.stbVisitNo.ReadOnly = InitOptions.VisitNoLocked
        Me.btnLoad.Visible = True
        Me.btnFindVisitNo.Visible = False

        Me.ResetControls()

        Me.dtpVisitDate.Value = Today
        Me.dtpVisitDate.Checked = True

        Me.cboBillModesID.SelectedValue = oBillModesID.Cash

        Me.chkPrintVisitOnSaving.Visible = True
        Me.chkPrintVisitOnSaving.Checked = False
        Me.btnPrint.Enabled = False

        Me.EnableVisitsCTLS(True)
        Me.ResetAssociatedBillControls(False)

        Me.LoadCASHCustomer()

        Me.chkUseExistingPatient.Checked = True
        Me.ManagePatientStatus(Me.chkUseExistingPatient.Checked)
        Me.chkUseExistingPatient.Enabled = oVariousOptions.AllowGenerateSelfRequestsNo
        Try

            Me.ebnSaveUpdate.Tag = Me.tbcDrRoles.SelectedTab.Tag.ToString()
            Security.Apply(Me.ebnSaveUpdate, AccessRights.Write)

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub DisplayData(ByVal dataSource As DataTable)

        Try

            Me.ebnSaveUpdate.DataSource = dataSource
            Me.ebnSaveUpdate.LoadData(Me)

            Me.ebnSaveUpdate.Enabled = dataSource.Rows.Count > 0
            Me.btnDelete.Enabled = dataSource.Rows.Count > 0

            Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
            Security.Apply(Me.btnDelete, AccessRights.Delete)

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.ebnSaveUpdate.Enabled = False
            Me.btnDelete.Enabled = False
        End If
    End Sub

    Private Sub EnableVisitsCTLS(ByVal state As Boolean)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim oVariousOptions As New VariousOptions()
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Me.pnlPatients.Enabled = state
        Me.chkUseExistingPatient.Enabled = state
        Me.stbPatientNo.Enabled = state
        Me.dtpVisitDate.Enabled = state
        If state Then
            Me.cboBillModesID.Enabled = oVariousOptions.AllowCreditSelfRequests
        Else : Me.cboBillModesID.Enabled = state
        End If
        Me.cboBillNo.Enabled = state
        Me.stbMemberCardNo.Enabled = state
        Me.stbMainMemberName.Enabled = state

    End Sub

#End Region

#Region " Security Method "

    Private Sub ApplySecurity()

        Try

            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))

            Me.ebnSaveUpdate.Tag = Me.tbcDrRoles.SelectedTab.Tag.ToString()
            Me.btnDelete.Tag = Me.tbcDrRoles.SelectedTab.Tag.ToString()

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then
                Security.Apply(Me.ebnSaveUpdate, AccessRights.Write)

            ElseIf Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update AndAlso Not String.IsNullOrEmpty(patientNo) Then
                Security.Apply(Me.ebnSaveUpdate, AccessRights.Update)
                Security.Apply(Me.btnDelete, AccessRights.Delete)

            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region


End Class