
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
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Public Class frmInsuranceSchemes

#Region " Fields "

    Private companies As DataTable
    Private services As DataTable
    Private drugs As DataTable
    Private labTests As DataTable
    Private radiologyExaminations As DataTable
    Private procedures As DataTable

    Private _BenefitCodeValue As String = String.Empty
    Private _ServiceNameValue As String = String.Empty
    Private _DrugNameValue As String = String.Empty
    Private _TestNameValue As String = String.Empty
    Private _RadiologyNameValue As String = String.Empty
    Private _ProcedureNameValue As String = String.Empty

#End Region

#Region " Validations "

    Private Sub SchemeStartDate(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
            Handles dtpSchemeJoinDate.Validating, dtpSchemeStartDate.Validating

        Dim errorMSG As String = "Scheme start date can't be before scheme join date!"

        Try

            Dim schemeJoinDate As Date = DateMayBeEnteredIn(Me.dtpSchemeJoinDate)
            Dim schemeStartDate As Date = DateMayBeEnteredIn(Me.dtpSchemeStartDate)

            If schemeStartDate = AppData.NullDateValue Then Return

            If schemeStartDate < schemeJoinDate Then
                ErrProvider.SetError(Me.dtpSchemeStartDate, errorMSG)
                Me.dtpSchemeStartDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpSchemeStartDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub SchemeEndDate(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
            Handles dtpSchemeStartDate.Validating, dtpSchemeEndDate.Validating

        Dim errorMSG As String = "Scheme end date can't be before scheme start date!"

        Try

            Dim schemeStartDate As Date = DateMayBeEnteredIn(Me.dtpSchemeStartDate)
            Dim schemeEndDate As Date = DateMayBeEnteredIn(Me.dtpSchemeEndDate)

            If schemeEndDate = AppData.NullDateValue Then Return

            If schemeEndDate < schemeStartDate Then
                ErrProvider.SetError(Me.dtpSchemeEndDate, errorMSG)
                Me.dtpSchemeEndDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpSchemeEndDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmInsuranceSchemes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.dtpSchemeJoinDate.MaxDate = Today

            LoadLookupDataCombo(Me.cboCoPayTypeID, LookupObjects.CoPayType, True)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SchemeStatus()
            Me.LoadCompanies()
            Me.LoadInsurances()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadMemberBenefits()
            Me.LoadServices()
            Me.LoadDrugs()
            Me.LoadLabTests()
            Me.LoadRadiologyExaminations()
            Me.LoadProcedures()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmInsuranceSchemes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub SetCoPayDefault()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
            '''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboCoPayTypeID.SelectedValue = oCoPayTypeID.NA
            '''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SchemeStatus()

        Dim oLookupData As New LookupData()
        Dim oStatusID As New LookupCommDataID.StatusID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusLookupData As DataTable = oLookupData.GetLookupData(LookupCommObjects.Status).Tables("LookupData")
            If statusLookupData Is Nothing Then Return

            For Each row As DataRow In statusLookupData.Rows
                If oStatusID.Active.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
                    oStatusID.Inactive.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) Then
                    Continue For
                Else : row.Delete()
                End If
            Next

            Me.cboSchemeStatusID.DataSource = statusLookupData

            Me.cboSchemeStatusID.DisplayMember = "DataDes"
            Me.cboSchemeStatusID.ValueMember = "DataID"

            Me.cboSchemeStatusID.SelectedValue = oStatusID.Active
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCompanies()

        Dim oCompanies As New SyncSoft.SQLDb.Companies()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from companies

            companies = oCompanies.GetCompanies().Tables("Companies")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboCompanyNo, companies, "companyFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim insurances As DataTable = oInsurances.GetInsurances().Tables("Insurances")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboInsuranceNo.Sorted = False
            Me.cboInsuranceNo.DataSource = insurances
            Me.cboInsuranceNo.DisplayMember = "InsuranceName"
            Me.cboInsuranceNo.ValueMember = "InsuranceNo"

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadMemberBenefits()

        Dim oMemberBenefits As New SyncSoft.SQLDb.MemberBenefits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from MemberBenefits
            Dim memberBenefits As DataTable = oMemberBenefits.GetMemberBenefits().Tables("MemberBenefits")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colBenefitCode.Sorted = False
            LoadComboData(Me.colBenefitCode, memberBenefits, "BenefitCode", "BenefitName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadServices()

        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Services except NA

            services = oServices.GetServices().Tables("Services")

            For Each row As DataRow In services.Rows
                If (oServiceCodes.NA.ToUpper().Equals(row.Item("ServiceCode").ToString().ToUpper())) Then row.Delete()
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colServiceCode.Sorted = False
            LoadComboData(Me.colServiceCode, services, "ServiceCode", "ServiceName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDrugNo.Sorted = False
            LoadComboData(Me.colDrugNo, drugs, "DrugNo", "DrugName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colTestCode.Sorted = False
            LoadComboData(Me.colTestCode, labTests, "TestCode", "TestName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colExamCode.Sorted = False
            LoadComboData(Me.colExamCode, radiologyExaminations, "ExamCode", "ExamName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub ClearControls()
        Me.stbCompanyName.Clear()
    End Sub

    Private Sub ResetCoPayControls()

        Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
        Dim coPayTypeID As String = StringValueMayBeEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")

        Select Case coPayTypeID

            Case oCoPayTypeID.NA

                Me.nbxCoPayPercent.Value = 0.ToString()
                Me.nbxCoPayPercent.Enabled = False
                Me.nbxCoPayValue.Value = 0.ToString()
                Me.nbxCoPayValue.Enabled = False

            Case oCoPayTypeID.Percent

                Me.nbxCoPayPercent.Value = String.Empty
                Me.nbxCoPayPercent.Enabled = True
                Me.nbxCoPayValue.Value = 0.0.ToString()
                Me.nbxCoPayValue.Enabled = False

            Case oCoPayTypeID.Value

                Me.nbxCoPayPercent.Value = 0.ToString()
                Me.nbxCoPayPercent.Enabled = False
                Me.nbxCoPayValue.Value = String.Empty
                Me.nbxCoPayValue.Enabled = True

            Case Else

                Me.nbxCoPayPercent.Value = String.Empty
                Me.nbxCoPayPercent.Enabled = True
                Me.nbxCoPayValue.Value = String.Empty
                Me.nbxCoPayValue.Enabled = True

        End Select

    End Sub

    Private Sub ClearCompanyName(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCompanyNo.SelectedIndexChanged, cboCompanyNo.TextChanged
        Me.CallOnKeyEdit()
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub cboCompanyNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCompanyNo.Leave

        Dim companyName As String

        Try
            Dim companyNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboCompanyNo)))

            Me.cboCompanyNo.Text = FormatText(companyNo, "Companies", "CompanyNo")

            If String.IsNullOrEmpty(companyNo) Then Return

            For Each row As DataRow In companies.Select("companyNo = '" + companyNo + "'")

                If Not IsDBNull(row.Item("companyName")) Then
                    companyName = StringEnteredIn(row, "companyName")
                    companyNo = StringMayBeEnteredIn(row, "companyNo")
                    Me.cboCompanyNo.Text = FormatText(companyNo.ToUpper(), "Companies", "companyNo")
                Else
                    companyName = String.Empty
                    companyNo = String.Empty
                End If

                Me.stbCompanyName.Text = companyName
            Next


        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub cboPolicyNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPolicyNo.SelectedIndexChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub cboCoPayTypeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoPayTypeID.SelectedIndexChanged
        Me.ResetCoPayControls()
    End Sub

#Region " Insurance Policies "

    Private Sub cboInsuranceNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsuranceNo.SelectedIndexChanged

        Try

            Dim insuranceNo As String
            If Me.cboInsuranceNo.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboInsuranceNo.SelectedValue.ToString()) Then
                insuranceNo = String.Empty
            Else : insuranceNo = StringValueEnteredIn(Me.cboInsuranceNo, "Insurance Policy!")
            End If

            Me.LoadInsurancePolicies(insuranceNo)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub LoadInsurancePolicies(ByVal insuranceNo As String)

        Dim oInsurancePolicies As New SyncSoft.SQLDb.InsurancePolicies()

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.cboPolicyNo.DataSource = Nothing
            If String.IsNullOrEmpty(insuranceNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Load all from InsurancePolicies
            Dim insurancePolicies As DataTable = oInsurancePolicies.GetInsurancePoliciesByInsuranceNo(insuranceNo).Tables("InsurancePolicies")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboPolicyNo.Sorted = False
            Me.cboPolicyNo.DataSource = insurancePolicies
            Me.cboPolicyNo.DisplayMember = "PolicyName"
            Me.cboPolicyNo.ValueMember = "PolicyNo"

            Me.cboPolicyNo.SelectedIndex = -1
            Me.cboPolicyNo.SelectedIndex = -1
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oInsuranceSchemes As New SyncSoft.SQLDb.InsuranceSchemes()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oInsuranceSchemes.CompanyNo = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            oInsuranceSchemes.PolicyNo = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))

            DisplayMessage(oInsuranceSchemes.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.tpgPolicyLimits)
            ResetControlsIn(Me.tpgInsuranceExcludedServices)
            ResetControlsIn(Me.tpgInsuranceExcludedDrugs)
            ResetControlsIn(Me.tpgInsuranceExcludedLabTests)
            ResetControlsIn(Me.tpgInsuranceExcludedRadiology)
            ResetControlsIn(Me.tpgInsuranceExcludedProcedures)
            ResetControlsIn(Me.pnlCoPayTypeID)

            Me.CallOnKeyEdit()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ResetCoPayControls()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oInsuranceSchemes As New SyncSoft.SQLDb.InsuranceSchemes()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))

            Dim dataSource As DataTable = oInsuranceSchemes.GetInsuranceSchemes(companyNo, policyNo).Tables("InsuranceSchemes")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim _InsuranceSchemes As EnumerableRowCollection(Of DataRow) = dataSource.AsEnumerable()
            Dim insuranceNo As String = (From data In _InsuranceSchemes Select data.Field(Of String)("InsuranceNo")).First()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(insuranceNo) Then Me.LoadInsurancePolicies(insuranceNo)
            Me.cboPolicyNo.SelectedValue = policyNo

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.DisplayData(dataSource)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadPolicyLimits(companyNo, policyNo)
            Me.LoadInsuranceExcludedServices(companyNo, policyNo)
            Me.LoadInsuranceExcludedDrugs(companyNo, policyNo)
            Me.LoadInsuranceExcludedLabTests(companyNo, policyNo)
            Me.LoadInsuranceExcludedRadiology(companyNo, policyNo)
            Me.LoadInsuranceExcludedProcedures(companyNo, policyNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oInsuranceSchemes As New SyncSoft.SQLDb.InsuranceSchemes()
            Dim lInsuranceSchemes As New List(Of DBConnect)

            With oInsuranceSchemes

                .CompanyNo = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
                StringValueEnteredIn(Me.cboInsuranceNo, "Insurance Name!")
                .PolicyNo = StringValueEnteredIn(Me.cboPolicyNo, "Policy Name!")
                .SchemeJoinDate = DateEnteredIn(Me.dtpSchemeJoinDate, "Scheme Join Date!")
                .SchemeStartDate = DateEnteredIn(Me.dtpSchemeStartDate, "Scheme Start Date!")
                .SchemeEndDate = DateEnteredIn(Me.dtpSchemeEndDate, "Scheme End Date!")
                .CoPayTypeID = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
                .CoPayPercent = Me.nbxCoPayPercent.GetSingle()
                .CoPayValue = Me.nbxCoPayValue.GetDecimal(False)
                .AnnualPremium = Me.nbxAnnualPremium.GetDecimal(False)
                .MemberPremium = Me.nbxMemberPremium.GetDecimal(False)
                .SmartCardApplicable = Me.chkSmartCardApplicable.Checked
                .SchemeStatusID = StringValueEnteredIn(Me.cboSchemeStatusID, "Scheme Status!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lInsuranceSchemes.Add(oInsuranceSchemes)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If oInsuranceSchemes.MemberPremium > oInsuranceSchemes.AnnualPremium Then
                Throw New ArgumentException("Member Premium can't be more than Annual Premium!")
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInsuranceSchemes, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(PolicyLimitsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedServicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedDrugsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedLabTestsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedRadiologyList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedProceduresList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgPolicyLimits)
                    ResetControlsIn(Me.tpgInsuranceExcludedServices)
                    ResetControlsIn(Me.tpgInsuranceExcludedDrugs)
                    ResetControlsIn(Me.tpgInsuranceExcludedLabTests)
                    ResetControlsIn(Me.tpgInsuranceExcludedRadiology)
                    ResetControlsIn(Me.tpgInsuranceExcludedProcedures)
                    Me.ResetCoPayControls()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInsuranceSchemes, Action.Update, "InsuranceSchemes"))
                    transactions.Add(New TransactionList(Of DBConnect)(PolicyLimitsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedServicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedDrugsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedLabTestsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedRadiologyList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedProceduresList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    DisplayMessage(records.ToString() + " record(s) updated!")
                    Me.CallOnKeyEdit()

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvPolicyLimits.RowCount - 2
                Me.dgvPolicyLimits.Item(Me.colPolicyLimitsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedServices.RowCount - 2
                Me.dgvInsuranceExcludedServices.Item(Me.colInsuranceExcludedServicesSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedDrugs.RowCount - 2
                Me.dgvInsuranceExcludedDrugs.Item(Me.colInsuranceExcludedDrugsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedLabTests.RowCount - 2
                Me.dgvInsuranceExcludedLabTests.Item(Me.colInsuranceExcludedLabTestsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedRadiology.RowCount - 2
                Me.dgvInsuranceExcludedRadiology.Item(Me.colInsuranceExcludedRadiologySaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedProcedures.RowCount - 2
                Me.dgvInsuranceExcludedProcedures.Item(Me.colInsuranceExcludedProceduresSaved.Name, rowNo).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function PolicyLimitsList() As List(Of DBConnect)

        Dim lPolicyLimits As New List(Of DBConnect)

        Try

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))

            For rowNo As Integer = 0 To Me.dgvPolicyLimits.RowCount - 2

                Using oPolicyLimits As New SyncSoft.SQLDb.PolicyLimits()

                    Dim cells As DataGridViewCellCollection = Me.dgvPolicyLimits.Rows(rowNo).Cells

                    With oPolicyLimits
                        .CompanyNo = companyNo
                        .PolicyNo = policyNo
                        .BenefitCode = StringEnteredIn(cells, Me.colBenefitCode, "Benefit Name!")
                        .PolicyLimit = DecimalEnteredIn(cells, Me.colPolicyLimit, False, "Policy Limit!")

                    End With

                    lPolicyLimits.Add(oPolicyLimits)

                End Using

            Next

            Return lPolicyLimits

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function InsuranceExcludedServicesList() As List(Of DBConnect)

        Dim lInsuranceExcludedServices As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedServices.RowCount - 2

                Using oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceExcludedServices.Rows(rowNo).Cells

                    With oInsuranceExcludedItems

                        .CompanyNo = companyNo
                        .PolicyNo = policyNo
                        .ItemCode = StringEnteredIn(cells, Me.colServiceCode, "Service Code!")
                        .ItemCategoryID = oItemCategoryID.Service

                    End With

                    lInsuranceExcludedServices.Add(oInsuranceExcludedItems)

                End Using

            Next

            Return lInsuranceExcludedServices

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function InsuranceExcludedDrugsList() As List(Of DBConnect)

        Dim lInsuranceExcludedDrugs As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedDrugs.RowCount - 2

                Using oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceExcludedDrugs.Rows(rowNo).Cells

                    With oInsuranceExcludedItems

                        .CompanyNo = companyNo
                        .PolicyNo = policyNo
                        .ItemCode = StringEnteredIn(cells, Me.colDrugNo, "Drug No!")
                        .ItemCategoryID = oItemCategoryID.Drug

                    End With

                    lInsuranceExcludedDrugs.Add(oInsuranceExcludedItems)

                End Using

            Next

            Return lInsuranceExcludedDrugs

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function InsuranceExcludedLabTestsList() As List(Of DBConnect)

        Dim lInsuranceExcludedLabTests As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedLabTests.RowCount - 2

                Using oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceExcludedLabTests.Rows(rowNo).Cells

                    With oInsuranceExcludedItems

                        .CompanyNo = companyNo
                        .PolicyNo = policyNo
                        .ItemCode = StringEnteredIn(cells, Me.colTestCode, "Test Code!")
                        .ItemCategoryID = oItemCategoryID.Test

                    End With

                    lInsuranceExcludedLabTests.Add(oInsuranceExcludedItems)

                End Using

            Next

            Return lInsuranceExcludedLabTests

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function InsuranceExcludedRadiologyList() As List(Of DBConnect)

        Dim lInsuranceExcludedRadiology As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedRadiology.RowCount - 2

                Using oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceExcludedRadiology.Rows(rowNo).Cells

                    With oInsuranceExcludedItems

                        .CompanyNo = companyNo
                        .PolicyNo = policyNo
                        .ItemCode = StringEnteredIn(cells, Me.colExamCode, "Exam Code!")
                        .ItemCategoryID = oItemCategoryID.Radiology

                    End With

                    lInsuranceExcludedRadiology.Add(oInsuranceExcludedItems)

                End Using

            Next

            Return lInsuranceExcludedRadiology

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function InsuranceExcludedProceduresList() As List(Of DBConnect)

        Dim lInsuranceExcludedProcedures As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedProcedures.RowCount - 2

                Using oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceExcludedProcedures.Rows(rowNo).Cells

                    With oInsuranceExcludedItems

                        .CompanyNo = companyNo
                        .PolicyNo = policyNo
                        .ItemCode = StringEnteredIn(cells, Me.colProcedureCode, "Procedure Code!")
                        .ItemCategoryID = oItemCategoryID.Procedure

                    End With

                    lInsuranceExcludedProcedures.Add(oInsuranceExcludedItems)

                End Using

            Next

            Return lInsuranceExcludedProcedures

        Catch ex As Exception
            Throw ex

        End Try

    End Function

#Region " PolicyLimits - Grid "

    Private Sub dgvPolicyLimits_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvPolicyLimits.CellBeginEdit

        If e.ColumnIndex <> Me.colBenefitCode.Index OrElse Me.dgvPolicyLimits.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvPolicyLimits.CurrentCell.RowIndex
        _BenefitCodeValue = StringMayBeEnteredIn(Me.dgvPolicyLimits.Rows(selectedRow).Cells, Me.colBenefitCode)

    End Sub

    Private Sub dgvPolicyLimits_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPolicyLimits.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colBenefitCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvPolicyLimits.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvPolicyLimits.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvPolicyLimits.Rows(selectedRow).Cells, Me.colBenefitCode)

                    If CBool(Me.dgvPolicyLimits.Item(Me.colPolicyLimitsSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Benefit Name (" + GetLookupDataDes(_BenefitCodeValue) + ") can't be edited!")
                        Me.dgvPolicyLimits.Item(Me.colBenefitCode.Name, selectedRow).Value = _BenefitCodeValue
                        Me.dgvPolicyLimits.Item(Me.colBenefitCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvPolicyLimits.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvPolicyLimits.Rows(rowNo).Cells, Me.colBenefitCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                DisplayMessage("Benefit Name (" + GetLookupDataDes(enteredItem) + ") already entered!")
                                Me.dgvPolicyLimits.Item(Me.colBenefitCode.Name, selectedRow).Value = _BenefitCodeValue
                                Me.dgvPolicyLimits.Item(Me.colBenefitCode.Name, selectedRow).Selected = True
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

    Private Sub dgvPolicyLimits_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPolicyLimits.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPolicyLimits As New SyncSoft.SQLDb.PolicyLimits()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPolicyLimits.Item(Me.colPolicyLimitsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))
            Dim benefitCode As String = CStr(Me.dgvPolicyLimits.Item(Me.colBenefitCode.Name, toDeleteRowNo).Value)

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

            With oPolicyLimits
                .CompanyNo = companyNo
                .PolicyNo = policyNo
                .BenefitCode = benefitCode
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

    Private Sub dgvPolicyLimits_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPolicyLimits.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadPolicyLimits(ByVal companyNo As String, ByVal policyNo As String)

        Dim oPolicyLimits As New SyncSoft.SQLDb.PolicyLimits()

        Try

            Me.dgvPolicyLimits.Rows.Clear()

            Dim policyLimits As DataTable = oPolicyLimits.GetPolicyLimits(companyNo, policyNo).Tables("PolicyLimits")
            If policyLimits Is Nothing OrElse policyLimits.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPolicyLimits, policyLimits)

            For Each row As DataGridViewRow In Me.dgvPolicyLimits.Rows
                If row.IsNewRow Then Exit For
                Me.dgvPolicyLimits.Item(Me.colPolicyLimitsSaved.Name, row.Index).Value = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Services - Grid "

    Private Sub dgvInsuranceExcludedServices_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvInsuranceExcludedServices.CellBeginEdit

        If e.ColumnIndex <> Me.colServiceCode.Index OrElse Me.dgvInsuranceExcludedServices.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvInsuranceExcludedServices.CurrentCell.RowIndex
        _ServiceNameValue = StringMayBeEnteredIn(Me.dgvInsuranceExcludedServices.Rows(selectedRow).Cells, Me.colServiceCode)

    End Sub

    Private Sub dgvInsuranceExcludedServices_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInsuranceExcludedServices.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colServiceCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvInsuranceExcludedServices.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvInsuranceExcludedServices.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvInsuranceExcludedServices.Rows(selectedRow).Cells, Me.colServiceCode)

                    If CBool(Me.dgvInsuranceExcludedServices.Item(Me.colInsuranceExcludedServicesSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Services As EnumerableRowCollection(Of DataRow) = services.AsEnumerable()
                        Dim ServiceDisplay As String = (From data In _Services
                                            Where data.Field(Of String)("ServiceCode").ToUpper().Equals(_ServiceNameValue.ToUpper())
                                            Select data.Field(Of String)("ServiceName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Service (" + ServiceDisplay + ") can't be edited!")
                        Me.dgvInsuranceExcludedServices.Item(Me.colServiceCode.Name, selectedRow).Value = _ServiceNameValue
                        Me.dgvInsuranceExcludedServices.Item(Me.colServiceCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvInsuranceExcludedServices.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvInsuranceExcludedServices.Rows(rowNo).Cells, Me.colServiceCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Services As EnumerableRowCollection(Of DataRow) = services.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Services
                                                    Where data.Field(Of String)("ServiceCode").ToUpper().Equals(enteredItem.ToUpper())
                                                    Select data.Field(Of String)("ServiceName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Service (" + enteredDisplay + ") already entered!")
                                Me.dgvInsuranceExcludedServices.Item(Me.colServiceCode.Name, selectedRow).Value = _ServiceNameValue
                                Me.dgvInsuranceExcludedServices.Item(Me.colServiceCode.Name, selectedRow).Selected = True
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

    Private Sub dgvInsuranceExcludedServices_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvInsuranceExcludedServices.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceExcludedServices.Item(Me.colInsuranceExcludedServicesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))
            Dim itemCode As String = CStr(Me.dgvInsuranceExcludedServices.Item(Me.colServiceCode.Name, toDeleteRowNo).Value)

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
            With oInsuranceExcludedItems
                .CompanyNo = companyNo
                .PolicyNo = policyNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Service
            End With

            DisplayMessage(oInsuranceExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvInsuranceExcludedServices_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvInsuranceExcludedServices.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadInsuranceExcludedServices(ByVal companyNo As String, ByVal policyNo As String)

        Dim insuranceExcludedServices As DataTable
        Dim oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvInsuranceExcludedServices.Rows.Clear()

            ' Load items not yet paid for

            insuranceExcludedServices = oInsuranceExcludedItems.GetInsuranceExcludedItems(companyNo, policyNo, oItemCategoryID.Service).Tables("InsuranceExcludedItems")

            If insuranceExcludedServices Is Nothing OrElse insuranceExcludedServices.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInsuranceExcludedServices, insuranceExcludedServices)

            For Each row As DataGridViewRow In Me.dgvInsuranceExcludedServices.Rows
                If row.IsNewRow Then Exit For
                Me.dgvInsuranceExcludedServices.Item(Me.colInsuranceExcludedServicesSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Drugs - Grid "

    Private Sub dgvInsuranceExcludedDrugs_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvInsuranceExcludedDrugs.CellBeginEdit

        If e.ColumnIndex <> Me.colDrugNo.Index OrElse Me.dgvInsuranceExcludedDrugs.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvInsuranceExcludedDrugs.CurrentCell.RowIndex
        _DrugNameValue = StringMayBeEnteredIn(Me.dgvInsuranceExcludedDrugs.Rows(selectedRow).Cells, Me.colDrugNo)

    End Sub

    Private Sub dgvInsuranceExcludedDrugs_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInsuranceExcludedDrugs.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colDrugNo.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvInsuranceExcludedDrugs.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvInsuranceExcludedDrugs.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvInsuranceExcludedDrugs.Rows(selectedRow).Cells, Me.colDrugNo)

                    If CBool(Me.dgvInsuranceExcludedDrugs.Item(Me.colInsuranceExcludedDrugsSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Drugs As EnumerableRowCollection(Of DataRow) = drugs.AsEnumerable()
                        Dim DrugDisplay As String = (From data In _Drugs
                                            Where data.Field(Of String)("DrugNo").ToUpper().Equals(_DrugNameValue.ToUpper())
                                            Select data.Field(Of String)("DrugName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Drug (" + DrugDisplay + ") can't be edited!")
                        Me.dgvInsuranceExcludedDrugs.Item(Me.colDrugNo.Name, selectedRow).Value = _DrugNameValue
                        Me.dgvInsuranceExcludedDrugs.Item(Me.colDrugNo.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvInsuranceExcludedDrugs.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvInsuranceExcludedDrugs.Rows(rowNo).Cells, Me.colDrugNo)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Drugs As EnumerableRowCollection(Of DataRow) = drugs.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Drugs
                                                    Where data.Field(Of String)("DrugNo").ToUpper().Equals(enteredItem.ToUpper())
                                                    Select data.Field(Of String)("DrugName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Drug (" + enteredDisplay + ") already entered!")
                                Me.dgvInsuranceExcludedDrugs.Item(Me.colDrugNo.Name, selectedRow).Value = _DrugNameValue
                                Me.dgvInsuranceExcludedDrugs.Item(Me.colDrugNo.Name, selectedRow).Selected = True
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

    Private Sub dgvInsuranceExcludedDrugs_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvInsuranceExcludedDrugs.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceExcludedDrugs.Item(Me.colInsuranceExcludedDrugsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))
            Dim itemCode As String = CStr(Me.dgvInsuranceExcludedDrugs.Item(Me.colDrugNo.Name, toDeleteRowNo).Value)

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
            With oInsuranceExcludedItems
                .CompanyNo = companyNo
                .PolicyNo = policyNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oInsuranceExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvInsuranceExcludedDrugs_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvInsuranceExcludedDrugs.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadInsuranceExcludedDrugs(ByVal companyNo As String, ByVal policyNo As String)

        Dim insuranceExcludedDrugs As DataTable
        Dim oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvInsuranceExcludedDrugs.Rows.Clear()

            ' Load items not yet paid for

            insuranceExcludedDrugs = oInsuranceExcludedItems.GetInsuranceExcludedItems(companyNo, policyNo, oItemCategoryID.Drug).Tables("InsuranceExcludedItems")

            If insuranceExcludedDrugs Is Nothing OrElse insuranceExcludedDrugs.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInsuranceExcludedDrugs, insuranceExcludedDrugs)

            For Each row As DataGridViewRow In Me.dgvInsuranceExcludedDrugs.Rows
                If row.IsNewRow Then Exit For
                Me.dgvInsuranceExcludedDrugs.Item(Me.colInsuranceExcludedDrugsSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " LabTests - Grid "

    Private Sub dgvInsuranceExcludedLabTests_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvInsuranceExcludedLabTests.CellBeginEdit

        If e.ColumnIndex <> Me.colTestCode.Index OrElse Me.dgvInsuranceExcludedLabTests.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvInsuranceExcludedLabTests.CurrentCell.RowIndex
        _TestNameValue = StringMayBeEnteredIn(Me.dgvInsuranceExcludedLabTests.Rows(selectedRow).Cells, Me.colTestCode)

    End Sub

    Private Sub dgvInsuranceExcludedLabTests_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInsuranceExcludedLabTests.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colTestCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvInsuranceExcludedLabTests.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvInsuranceExcludedLabTests.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvInsuranceExcludedLabTests.Rows(selectedRow).Cells, Me.colTestCode)

                    If CBool(Me.dgvInsuranceExcludedLabTests.Item(Me.colInsuranceExcludedLabTestsSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _LabTests As EnumerableRowCollection(Of DataRow) = labTests.AsEnumerable()
                        Dim testDisplay As String = (From data In _LabTests _
                                            Where data.Field(Of String)("TestCode").ToUpper().Equals(_TestNameValue.ToUpper())
                                            Select data.Field(Of String)("TestName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Test (" + testDisplay + ") can't be edited!")
                        Me.dgvInsuranceExcludedLabTests.Item(Me.colTestCode.Name, selectedRow).Value = _TestNameValue
                        Me.dgvInsuranceExcludedLabTests.Item(Me.colTestCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvInsuranceExcludedLabTests.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvInsuranceExcludedLabTests.Rows(rowNo).Cells, Me.colTestCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _LabTests As EnumerableRowCollection(Of DataRow) = labTests.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _LabTests
                                                    Where data.Field(Of String)("TestCode").ToUpper().Equals(enteredItem.ToUpper())
                                                    Select data.Field(Of String)("TestName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Test (" + enteredDisplay + ") already entered!")
                                Me.dgvInsuranceExcludedLabTests.Item(Me.colTestCode.Name, selectedRow).Value = _TestNameValue
                                Me.dgvInsuranceExcludedLabTests.Item(Me.colTestCode.Name, selectedRow).Selected = True
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

    Private Sub dgvInsuranceExcludedLabTests_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvInsuranceExcludedLabTests.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceExcludedLabTests.Item(Me.colInsuranceExcludedLabTestsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))
            Dim itemCode As String = CStr(Me.dgvInsuranceExcludedLabTests.Item(Me.colTestCode.Name, toDeleteRowNo).Value)

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
            With oInsuranceExcludedItems
                .CompanyNo = companyNo
                .PolicyNo = policyNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Test
            End With

            DisplayMessage(oInsuranceExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvInsuranceExcludedLabTests_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvInsuranceExcludedLabTests.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadInsuranceExcludedLabTests(ByVal companyNo As String, ByVal policyNo As String)

        Dim insuranceExcludedLabTests As DataTable
        Dim oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvInsuranceExcludedLabTests.Rows.Clear()

            ' Load items not yet paid for

            insuranceExcludedLabTests = oInsuranceExcludedItems.GetInsuranceExcludedItems(companyNo, policyNo, oItemCategoryID.Test).Tables("InsuranceExcludedItems")

            If insuranceExcludedLabTests Is Nothing OrElse insuranceExcludedLabTests.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInsuranceExcludedLabTests, insuranceExcludedLabTests)

            For Each row As DataGridViewRow In Me.dgvInsuranceExcludedLabTests.Rows
                If row.IsNewRow Then Exit For
                Me.dgvInsuranceExcludedLabTests.Item(Me.colInsuranceExcludedLabTestsSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Radiology - Grid "

    Private Sub dgvInsuranceExcludedRadiology_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvInsuranceExcludedRadiology.CellBeginEdit

        If e.ColumnIndex <> Me.colExamCode.Index OrElse Me.dgvInsuranceExcludedRadiology.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvInsuranceExcludedRadiology.CurrentCell.RowIndex
        _RadiologyNameValue = StringMayBeEnteredIn(Me.dgvInsuranceExcludedRadiology.Rows(selectedRow).Cells, Me.colExamCode)

    End Sub

    Private Sub dgvInsuranceExcludedRadiology_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInsuranceExcludedRadiology.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colExamCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvInsuranceExcludedRadiology.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvInsuranceExcludedRadiology.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvInsuranceExcludedRadiology.Rows(selectedRow).Cells, Me.colExamCode)

                    If CBool(Me.dgvInsuranceExcludedRadiology.Item(Me.colInsuranceExcludedRadiologySaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Radiology As EnumerableRowCollection(Of DataRow) = radiologyExaminations.AsEnumerable()
                        Dim radiologyDisplay As String = (From data In _Radiology
                                            Where data.Field(Of String)("ExamCode").ToUpper().Equals(_RadiologyNameValue.ToUpper())
                                            Select data.Field(Of String)("ExamName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Radiology (" + radiologyDisplay + ") can't be edited!")
                        Me.dgvInsuranceExcludedRadiology.Item(Me.colExamCode.Name, selectedRow).Value = _RadiologyNameValue
                        Me.dgvInsuranceExcludedRadiology.Item(Me.colExamCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvInsuranceExcludedRadiology.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvInsuranceExcludedRadiology.Rows(rowNo).Cells, Me.colExamCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Radiology As EnumerableRowCollection(Of DataRow) = radiologyExaminations.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Radiology
                                                    Where data.Field(Of String)("ExamCode").ToUpper().Equals(enteredItem.ToUpper())
                                                    Select data.Field(Of String)("ExamName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Radiology (" + enteredDisplay + ") already entered!")
                                Me.dgvInsuranceExcludedRadiology.Item(Me.colExamCode.Name, selectedRow).Value = _RadiologyNameValue
                                Me.dgvInsuranceExcludedRadiology.Item(Me.colExamCode.Name, selectedRow).Selected = True
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

    Private Sub dgvInsuranceExcludedRadiology_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvInsuranceExcludedRadiology.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceExcludedRadiology.Item(Me.colInsuranceExcludedRadiologySaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))
            Dim itemCode As String = CStr(Me.dgvInsuranceExcludedRadiology.Item(Me.colExamCode.Name, toDeleteRowNo).Value)

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
            With oInsuranceExcludedItems
                .CompanyNo = companyNo
                .PolicyNo = policyNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Radiology
            End With

            DisplayMessage(oInsuranceExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvInsuranceExcludedRadiology_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvInsuranceExcludedRadiology.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadInsuranceExcludedRadiology(ByVal companyNo As String, ByVal policyNo As String)

        Dim insuranceExcludedRadiology As DataTable
        Dim oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvInsuranceExcludedRadiology.Rows.Clear()

            ' Load items not yet paid for

            insuranceExcludedRadiology = oInsuranceExcludedItems.GetInsuranceExcludedItems(companyNo, policyNo, oItemCategoryID.Radiology).Tables("InsuranceExcludedItems")

            If insuranceExcludedRadiology Is Nothing OrElse insuranceExcludedRadiology.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInsuranceExcludedRadiology, insuranceExcludedRadiology)

            For Each row As DataGridViewRow In Me.dgvInsuranceExcludedRadiology.Rows
                If row.IsNewRow Then Exit For
                Me.dgvInsuranceExcludedRadiology.Item(Me.colInsuranceExcludedRadiologySaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Procedures - Grid "

    Private Sub dgvInsuranceExcludedProcedures_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvInsuranceExcludedProcedures.CellBeginEdit

        If e.ColumnIndex <> Me.colProcedureCode.Index OrElse Me.dgvInsuranceExcludedProcedures.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvInsuranceExcludedProcedures.CurrentCell.RowIndex
        _ProcedureNameValue = StringMayBeEnteredIn(Me.dgvInsuranceExcludedProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

    End Sub

    Private Sub dgvInsuranceExcludedProcedures_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInsuranceExcludedProcedures.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colProcedureCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvInsuranceExcludedProcedures.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvInsuranceExcludedProcedures.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvInsuranceExcludedProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

                    If CBool(Me.dgvInsuranceExcludedProcedures.Item(Me.colInsuranceExcludedProceduresSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                        Dim procedureDisplay As String = (From data In _Procedures
                                            Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(_ProcedureNameValue.ToUpper())
                                            Select data.Field(Of String)("ProcedureName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Procedure (" + procedureDisplay + ") can't be edited!")
                        Me.dgvInsuranceExcludedProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                        Me.dgvInsuranceExcludedProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvInsuranceExcludedProcedures.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvInsuranceExcludedProcedures.Rows(rowNo).Cells, Me.colProcedureCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Procedures
                                                    Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(enteredItem.ToUpper())
                                                    Select data.Field(Of String)("ProcedureName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Procedure (" + enteredDisplay + ") already entered!")
                                Me.dgvInsuranceExcludedProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                                Me.dgvInsuranceExcludedProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
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

    Private Sub dgvInsuranceExcludedProcedures_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvInsuranceExcludedProcedures.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceExcludedProcedures.Item(Me.colInsuranceExcludedProceduresSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim companyNo As String = RevertText(StringEnteredIn(Me.cboCompanyNo, "Company No!"))
            Dim policyNo As String = RevertText(StringValueEnteredIn(Me.cboPolicyNo, "Policy No!"))
            Dim itemCode As String = CStr(Me.dgvInsuranceExcludedProcedures.Item(Me.colProcedureCode.Name, toDeleteRowNo).Value)

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
            With oInsuranceExcludedItems
                .CompanyNo = companyNo
                .PolicyNo = policyNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oInsuranceExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvInsuranceExcludedProcedures_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvInsuranceExcludedProcedures.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadInsuranceExcludedProcedures(ByVal companyNo As String, ByVal policyNo As String)

        Dim insuranceExcludedProcedures As DataTable
        Dim oInsuranceExcludedItems As New SyncSoft.SQLDb.InsuranceExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvInsuranceExcludedProcedures.Rows.Clear()

            ' Load items not yet paid for

            insuranceExcludedProcedures = oInsuranceExcludedItems.GetInsuranceExcludedItems(companyNo, policyNo, oItemCategoryID.Procedure).Tables("InsuranceExcludedItems")

            If insuranceExcludedProcedures Is Nothing OrElse insuranceExcludedProcedures.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvInsuranceExcludedProcedures, insuranceExcludedProcedures)

            For Each row As DataGridViewRow In Me.dgvInsuranceExcludedProcedures.Rows
                If row.IsNewRow Then Exit For
                Me.dgvInsuranceExcludedProcedures.Item(Me.colInsuranceExcludedProceduresSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

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

        Me.pnlStatusID.Enabled = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgPolicyLimits)
        ResetControlsIn(Me.tpgInsuranceExcludedServices)
        ResetControlsIn(Me.tpgInsuranceExcludedDrugs)
        ResetControlsIn(Me.tpgInsuranceExcludedLabTests)
        ResetControlsIn(Me.tpgInsuranceExcludedRadiology)
        ResetControlsIn(Me.tpgInsuranceExcludedProcedures)
        ResetControlsIn(Me.pnlStatusID)
        ResetControlsIn(Me.pnlCoPayTypeID)

        Me.ResetCoPayControls()

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.pnlStatusID.Enabled = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgPolicyLimits)
        ResetControlsIn(Me.tpgInsuranceExcludedServices)
        ResetControlsIn(Me.tpgInsuranceExcludedDrugs)
        ResetControlsIn(Me.tpgInsuranceExcludedLabTests)
        ResetControlsIn(Me.tpgInsuranceExcludedRadiology)
        ResetControlsIn(Me.tpgInsuranceExcludedProcedures)

        Me.SetCoPayDefault()
        Me.ResetCoPayControls()
        Me.SchemeStatus()

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