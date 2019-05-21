
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.Enumerations
Imports SyncSoft.Common.SQL.Enumerations
Imports System.Collections.Generic
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports LookupCommObjects = SyncSoft.Common.Lookup.LookupCommObjects
Imports LookupCommDataID = SyncSoft.Common.Lookup.LookupCommDataID

Public Class frmBillCustomers

#Region " Fields "

    Private billCustomers As DataTable
    Private services As DataTable
    Private drugs As DataTable
    Private labTests As DataTable
    Private radiologyExaminations As DataTable
    Private procedures As DataTable
    Private dentalServices As DataTable
    Private pathologyExaminations As DataTable
    Private opticalServices As DataTable
    Private extraChargeItems As DataTable

    Private _ServiceNameValue As String = String.Empty
    Private _DrugNameValue As String = String.Empty
    Private _TestNameValue As String = String.Empty
    Private _RadiologyNameValue As String = String.Empty
    Private _ProcedureNameValue As String = String.Empty
    Private _OpticalServiceValue As String = String.Empty
    Private _DentalServiceValue As String = String.Empty
    Private _PathologyValue As String = String.Empty
    Private _AccountNoValue As String = String.Empty
    Private _ExtraChargeItemNameValue As String = String.Empty
    Private _DrugNo As String = String.Empty
    Private _TestNo As String = String.Empty
    Private _ServiceCode As String = String.Empty

#End Region

    Private Sub frmBillCustomers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            Me.LoadBillCustomersInsurance()

            LoadLookupDataCombo(Me.fcbBillCustomerTypeID, LookupObjects.BillCustomerType, False)
            LoadLookupDataCombo(Me.cboCoPayTypeID, LookupObjects.CoPayType, True)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.AccountStatus()
            Me.LoadBillCustomers()
            Me.LoadRadiologyExaminations()
            Me.LoadProcedures()
            Me.LoadPathologyExaminations()
            Me.LoadDentalCategoryService()
            Me.LoadOpticalServices()
            Me.LoadExtraChargeItems()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmBillCustomers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub cboAccountNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub cboAccountNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountNo.Leave

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim accountNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboAccountNo))).ToUpper()
            Me.cboAccountNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo")

            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Return

            For Each row As DataRow In billCustomers.Select("AccountNo = '" + accountNo + "'")
                Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub btnLoadLogoPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadLogoPhoto.Click
        Me.spbLogoPhoto.LoadPhoto(Me.spbLogoPhoto.ImageSizeLimit)
    End Sub

    Private Sub btnClearLogoPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLogoPhoto.Click
        Me.spbLogoPhoto.DeletePhoto()
    End Sub

    Private Sub AccountStatus()

        Dim oLookupData As New LookupData()
        Dim oStatusID As New LookupCommDataID.StatusID()
        Dim statusLookupData As New DataTable()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            statusLookupData = oLookupData.GetLookupData(LookupCommObjects.Status).Tables("LookupData")
            If statusLookupData Is Nothing Then Return

            For Each row As DataRow In statusLookupData.Rows
                If oStatusID.Active.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) _
                OrElse oStatusID.Inactive.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) Then
                    Continue For
                Else : row.Delete()
                End If
            Next

            Me.cboAccountStatusID.DataSource = statusLookupData

            Me.cboAccountStatusID.DisplayMember = "DataDes"
            Me.cboAccountStatusID.ValueMember = "DataID"

            Me.cboAccountStatusID.SelectedValue = oStatusID.Active
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetCoPayDefault()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oCoPayTypeID As New LookupDataID.CoPayTypeID()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboCoPayTypeID.SelectedValue = oCoPayTypeID.NA
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub LoadBillCustomers(ByVal populate As Boolean)

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If populate Then
                LoadComboData(Me.cboAccountNo, billCustomers, "BillCustomerFullName")
            Else : Me.cboAccountNo.Items.Clear()
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function GetServices() As DataTable

        Dim oServices As New SyncSoft.SQLDb.Services()
        Dim oServiceCodes As New LookupDataID.ServiceCodes()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Services 

            services = oServices.GetServices().Tables("Services")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return services
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)


        End Try

    End Function

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

    Private Function GetLabTests() As DataTable

        Dim labTests As DataTable
        Dim oSetupData As New SetupData()
        Dim oLabTests As New SyncSoft.SQLDb.LabTests()

        Try

            ' Load from LabTests
            If Not InitOptions.LoadLabTestsAtStart Then
                labTests = oLabTests.GetLabTests().Tables("LabTests")
                oSetupData.LabTests = labTests
            Else : labTests = oSetupData.LabTests
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Return labTests
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw (ex)
        End Try

    End Function

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colProcedureCode.Sorted = False
            LoadComboData(Me.colProcedureCode, procedures, "ProcedureCode", "ProcedureName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPathologyExaminations()

        Dim oPathologyExaminations As New SyncSoft.SQLDb.PathologyExaminations()
         Try
            Me.Cursor = Cursors.WaitCursor

            'Load Pathology Examinations
             pathologyExaminations = oPathologyExaminations.GetPathologyExaminations().Tables("PathologyExaminations")
            
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colPathologyExamFullName, pathologyExaminations, "ExamCode", "ExamName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDentalCategoryService()

        Dim oDentalServices As New SyncSoft.SQLDb.DentalServices()
        Dim oDentalCategoryID As New LookupDataID.DentalCategoryID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from DentalServices
            dentalServices = oDentalServices.GetDentalServices.Tables("DentalServices")
           
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDentalCode.Sorted = False
            LoadComboData(Me.colDentalCode, dentalServices, "DentalCode", "DentalName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            opticalServices = oOpticalServices.GetOpticalServices().Tables("OpticalServices")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colOpticalCode.Sorted = False
            LoadComboData(Me.colOpticalCode, opticalServices, "OpticalCode", "OpticalName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetNextAccountNo()

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("BillCustomers", "AccountNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextAccountNo As String = CStr(oBillCustomers.GetNextAccountID).PadLeft(paddingLEN, paddingCHAR)
            Me.cboAccountNo.Text = FormatText(("A" + yearL2 + nextAccountNo).Trim(), "BillCustomers", "AccountNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBillCustomersInsurance()

        Dim billCustomersInsurance As DataTable
        Dim oBillCustomersInsurance As New SyncSoft.SQLDb.BillCustomers()
        Dim oBillCustomerTypeID As New LookupDataID.BillCustomerTypeID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from BillCustomersInsurance
            billCustomersInsurance = oBillCustomersInsurance.GetBillCustomersInsurance(oBillCustomerTypeID.Insurance).Tables("BillCustomers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboInsuranceNo, billCustomersInsurance, "BillCustomerFullName")
            Me.cboInsuranceNo.Items.Insert(0, "")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

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

    Private Sub EnableStateControls(ByVal state As Boolean)

        Me.chkUseCustomFee.Checked = state
        Me.chkCaptureMemberCardNo.Checked = state
        Me.chkCaptureClaimReferenceNo.Checked = state

    End Sub

    Private Sub cboCoPayTypeID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCoPayTypeID.SelectedIndexChanged
        Me.ResetCoPayControls()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oBillCustomers.AccountNo = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            DisplayMessage(oBillCustomers.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ResetControlsIn(Me)
            ResetControlsIn(Me.tpgBillExcludedServices)
            ResetControlsIn(Me.tpgBillExcludedDrugs)
            ResetControlsIn(Me.tpgBillExcludedLabTests)
            ResetControlsIn(Me.tpgBillExcludedRadiology)
            ResetControlsIn(Me.tpgBillExcludedProcedures)
            ResetControlsIn(Me.tpgAssociatedBillCustomers)
            ResetControlsIn(Me.pnlCoPayTypeID)
            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No"))

            Me.Cursor = Cursors.WaitCursor

            Me.cboAccountNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo")
            Dim dataSource As DataTable = oBillCustomers.GetBillCustomers(accountNo).Tables("BillCustomers")
            Me.DisplayData(dataSource)

            Me.LoadBillExcludedServices(accountNo)
            Me.LoadBillExcludedDrugs(accountNo)
            Me.LoadBillExcludedLabTests(accountNo)
            Me.LoadBillExcludedRadiology(accountNo)
            Me.LoadBillExcludedProcedures(accountNo)
            Me.LoadBillExcludedExtraChargeItems(accountNo)
            Me.LoadAssociatedBillCustomers(accountNo)
            Me.LoadBillExcludedDentalServices(accountNo)
            Me.LoadBillPathologyServices(accountNo)
            Me.LoadBillExcludedOpticalServices(accountNo)
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Me.Cursor = Cursors.WaitCursor
            Dim oBillCustomers As New SyncSoft.SQLDb.BillCustomers()
            Dim lBillCustomers As New List(Of DBConnect)

            With oBillCustomers

                .AccountNo = RevertText(StringEnteredIn(Me.cboAccountNo, "Account Number!")).ToUpper()
                .BillCustomerName = StringEnteredIn(Me.stbBillCustomerName, "To-Bill Customer Name!")
                .BillCustomerTypeID = StringValueEnteredIn(Me.fcbBillCustomerTypeID, "To-Bill Customer Type!")
                If Me.cboInsuranceNo.Text IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.cboInsuranceNo.Text) Then
                    .InsuranceNo = SubstringEnteredIn(Me.cboInsuranceNo, "To-Bill Customer Insurance!")
                Else : .InsuranceNo = String.Empty
                End If
                .ContactPerson = StringMayBeEnteredIn(Me.stbContactPerson)
                .Address = StringMayBeEnteredIn(Me.stbAddress)
                .Phone = StringMayBeEnteredIn(Me.stbPhone)
                .Fax = StringMayBeEnteredIn(Me.stbFax)
                .Email = StringMayBeEnteredIn(Me.stbEmail)
                .Website = StringMayBeEnteredIn(Me.stbWebsite)
                .LogoPhoto = BytesMayBeEnteredIn(Me.spbLogoPhoto)
                .MemberDeclaration = StringMayBeEnteredIn(Me.stbMemberDeclaration)
                .DoctorDeclaration = StringMayBeEnteredIn(Me.stbDoctorDeclaration)
                .CoPayTypeID = StringValueEnteredIn(Me.cboCoPayTypeID, "Co-Pay Type!")
                .CoPayPercent = Me.nbxCoPayPercent.GetSingle()
                .CoPayValue = Me.nbxCoPayValue.GetDecimal(False)
                .CreditLimit = Me.nbxCreditLimit.GetDecimal(False)
                .AllowOnlyListedMember = Me.chkAllowOnlyListedMember.Checked
                .UseCustomFee = Me.chkUseCustomFee.Checked
                .SmartCardApplicable = Me.chkSmartCardApplicable.Checked
                .CaptureMemberCardNo = Me.chkCaptureMemberCardNo.Checked
                .CaptureClaimReferenceNo = Me.chkCaptureClaimReferenceNo.Checked
                .Hidden = Me.chkHidden.Checked
                .AccountStatusID = StringValueEnteredIn(Me.cboAccountStatusID, "Account Status!")

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lBillCustomers.Add(oBillCustomers)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If oBillCustomers.Hidden.Equals(True) Then
                Dim message As String = "You have chosen to hide this To-Bill Customer and won’t be presented for selection. " +
                                        ControlChars.NewLine + "Are you sure you want to save?"
                If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.chkHidden.Focus() : Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lBillCustomers, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedServicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedDrugsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedLabTestsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedRadiologyList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedProceduresList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(AssociatedBillCustomersList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedExtraChargeItems, Action.Save))
                      transactions.Add(New TransactionList(Of DBConnect)(BillExcludedDentalservicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedPathologyList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedOpticalServicesList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgBillExcludedServices)
                    ResetControlsIn(Me.tpgBillExcludedDrugs)
                    ResetControlsIn(Me.tpgBillExcludedLabTests)
                    ResetControlsIn(Me.tpgBillExcludedRadiology)
                    ResetControlsIn(Me.tpgBillExcludedProcedures)
                    ResetControlsIn(Me.tpgAssociatedBillCustomers)
                    ResetControlsIn(Me.tpgBillExcludedExtraChargeItems)
                    ResetControlsIn(Me.tpgBillExcludedDentalServices)
                    ResetControlsIn(Me.tpgBillExcludedPathology)
                    ResetControlsIn(Me.tpgBillExcludedOpticalservices)
                    Me.ResetCoPayControls()

                    Me.SetNextAccountNo()
                    Me.EnableStateControls(True)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lBillCustomers, Action.Update, "BillCustomers"))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedServicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedDrugsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedLabTestsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedRadiologyList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedProceduresList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(AssociatedBillCustomersList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedExtraChargeItems, Action.Save))
                     transactions.Add(New TransactionList(Of DBConnect)(BillExcludedDentalservicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedPathologyList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(BillExcludedOpticalServicesList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    DisplayMessage(records.ToString() + " record(s) updated!")
                    Me.CallOnKeyEdit()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvBillExcludedServices.RowCount - 2
                Me.dgvBillExcludedServices.Item(Me.colBillExcludedServicesSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvBillExcludedDrugs.RowCount - 2
                Me.dgvBillExcludedDrugs.Item(Me.colBillExcludedDrugsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvBillExcludedLabTests.RowCount - 2
                Me.dgvBillExcludedLabTests.Item(Me.colBillExcludedLabTestsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvBillExcludedRadiology.RowCount - 2
                Me.dgvBillExcludedRadiology.Item(Me.colBillExcludedRadiologySaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvBillExcludedProcedures.RowCount - 2
                Me.dgvBillExcludedProcedures.Item(Me.colBillExcludedProceduresSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvAssociatedBillCustomers.RowCount - 2
                Me.dgvAssociatedBillCustomers.Item(Me.colAssociatedBillCustomersSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvBillExcludedExtraChargeItems.RowCount - 2
                Me.dgvBillExcludedExtraChargeItems.Item(Me.colBillExcludedExtraChargeItemsSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvBillExcludedDentalServices.RowCount - 2
                Me.dgvBillExcludedDentalServices.Item(Me.colBillExcludedDentalServicesSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvBillExcludedPathology.RowCount - 2
                Me.dgvBillExcludedPathology.Item(Me.colBillExcludedPathologySaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvBillExcludedOpticalServices.RowCount - 2
                Me.dgvBillExcludedOpticalServices.Item(Me.colBillExcludedOtherOpticalSaved.Name, rowNo).Value = True
            Next



            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function BillExcludedServicesList() As List(Of DBConnect)

        Dim lBillExcludedServices As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            For rowNo As Integer = 0 To Me.dgvBillExcludedServices.RowCount - 2

                Using oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillExcludedServices.Rows(rowNo).Cells

                    With oBillExcludedItems

                        .AccountNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.ColExTServiceCode, "Service Code!")
                        .ItemCategoryID = oItemCategoryID.Service

                    End With

                    lBillExcludedServices.Add(oBillExcludedItems)

                End Using

            Next

            Return lBillExcludedServices

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function BillExcludedDrugsList() As List(Of DBConnect)

        Dim lBillExcludedDrugs As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            For rowNo As Integer = 0 To Me.dgvBillExcludedDrugs.RowCount - 2

                Using oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillExcludedDrugs.Rows(rowNo).Cells

                    With oBillExcludedItems

                        .AccountNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.colEXTDrugNo, "Drug No!")
                        .ItemCategoryID = oItemCategoryID.Drug

                    End With

                    lBillExcludedDrugs.Add(oBillExcludedItems)

                End Using

            Next

            Return lBillExcludedDrugs

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function BillExcludedLabTestsList() As List(Of DBConnect)

        Dim lBillExcludedLabTests As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            For rowNo As Integer = 0 To Me.dgvBillExcludedLabTests.RowCount - 2

                Using oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillExcludedLabTests.Rows(rowNo).Cells

                    With oBillExcludedItems

                        .AccountNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.ColEXTTestNo, "Test Code!")
                        .ItemCategoryID = oItemCategoryID.Test

                    End With

                    lBillExcludedLabTests.Add(oBillExcludedItems)

                End Using

            Next

            Return lBillExcludedLabTests

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function BillExcludedRadiologyList() As List(Of DBConnect)

        Dim lBillExcludedRadiology As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            For rowNo As Integer = 0 To Me.dgvBillExcludedRadiology.RowCount - 2

                Using oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillExcludedRadiology.Rows(rowNo).Cells

                    With oBillExcludedItems

                        .AccountNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.colExamCode, "Exam Code!")
                        .ItemCategoryID = oItemCategoryID.Radiology

                    End With

                    lBillExcludedRadiology.Add(oBillExcludedItems)

                End Using

            Next

            Return lBillExcludedRadiology

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function BillExcludedProceduresList() As List(Of DBConnect)

        Dim lBillExcludedProcedures As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            For rowNo As Integer = 0 To Me.dgvBillExcludedProcedures.RowCount - 2

                Using oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillExcludedProcedures.Rows(rowNo).Cells

                    With oBillExcludedItems

                        .AccountNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.colProcedureCode, "Procedure Code!")
                        .ItemCategoryID = oItemCategoryID.Procedure

                    End With

                    lBillExcludedProcedures.Add(oBillExcludedItems)

                End Using

            Next

            Return lBillExcludedProcedures

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function BillExcludedDentalservicesList() As List(Of DBConnect)

        Dim lBillExcludedDentalservicesList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            For rowNo As Integer = 0 To Me.dgvBillExcludedDentalServices.RowCount - 2

                Using oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillExcludedDentalServices.Rows(rowNo).Cells

                    With oBillExcludedItems

                        .AccountNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.colDentalCode, "Dental Services!")
                        .ItemCategoryID = oItemCategoryID.Dental

                    End With

                    lBillExcludedDentalservicesList.Add(oBillExcludedItems)

                End Using

            Next

            Return lBillExcludedDentalservicesList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function BillExcludedPathologyList() As List(Of DBConnect)

        Dim lBillExcludedPathologyList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            For rowNo As Integer = 0 To Me.dgvBillExcludedPathology.RowCount - 2

                Using oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillExcludedPathology.Rows(rowNo).Cells

                    With oBillExcludedItems

                        .AccountNo = accountNo
                        .ItemCode = SubstringRight(StringEnteredIn(cells, Me.colPathologyExamFullName, "Pathology Exam Full Name!"))
                        .ItemCategoryID = oItemCategoryID.Pathology

                    End With

                    lBillExcludedPathologyList.Add(oBillExcludedItems)

                End Using

            Next

            Return lBillExcludedPathologyList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function BillExcludedOpticalServicesList() As List(Of DBConnect)

        Dim lBillExcludedOpticalServicesList As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            For rowNo As Integer = 0 To Me.dgvBillExcludedOpticalServices.RowCount - 2

                Using oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillExcludedOpticalServices.Rows(rowNo).Cells

                    With oBillExcludedItems

                        .AccountNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.colOpticalCode, "Optical Code!")
                        .ItemCategoryID = oItemCategoryID.Optical

                    End With

                    lBillExcludedOpticalServicesList.Add(oBillExcludedItems)

                End Using

            Next

            Return lBillExcludedOpticalServicesList

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Private Function AssociatedBillCustomersList() As List(Of DBConnect)

        Dim lAssociatedBillCustomers As New List(Of DBConnect)

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            For rowNo As Integer = 0 To Me.dgvAssociatedBillCustomers.RowCount - 2

                Using oAssociatedBillCustomers As New SyncSoft.SQLDb.AssociatedBillCustomers()

                    Dim cells As DataGridViewCellCollection = Me.dgvAssociatedBillCustomers.Rows(rowNo).Cells

                    With oAssociatedBillCustomers
                        .AccountNo = accountNo
                        .AssociatedBillNo = StringEnteredIn(cells, Me.colBillCustomerName, "To-Bill Associated Account Name!")
                    End With

                    lAssociatedBillCustomers.Add(oAssociatedBillCustomers)

                End Using

            Next

            Return lAssociatedBillCustomers

        Catch ex As Exception
            Me.tbcBillCustomers.SelectTab(Me.tpgAssociatedBillCustomers.Name)
            Throw ex

        End Try

    End Function

    Private Function BillExcludedExtraChargeItems() As List(Of DBConnect)

        Dim lBillExcludedExtraChargeItems As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            For rowNo As Integer = 0 To Me.dgvBillExcludedExtraChargeItems.RowCount - 2

                Using oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

                    Dim cells As DataGridViewCellCollection = Me.dgvBillExcludedExtraChargeItems.Rows(rowNo).Cells

                    With oBillExcludedItems

                        .AccountNo = accountNo
                        .ItemCode = StringEnteredIn(cells, Me.colExtraChargeItems, "Extra Charge!")
                        .ItemCategoryID = oItemCategoryID.Extras

                    End With

                    lBillExcludedExtraChargeItems.Add(oBillExcludedItems)

                End Using

            Next

            Return lBillExcludedExtraChargeItems

        Catch ex As Exception
            Throw ex

        End Try

    End Function

#Region " Services - Grid "

    Private Sub dgvBillExcludedServices_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBillExcludedServices.CellBeginEdit

        If e.ColumnIndex <> Me.colServiceCode.Index OrElse Me.dgvBillExcludedServices.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvBillExcludedServices.CurrentCell.RowIndex
        _ServiceNameValue = StringMayBeEnteredIn(Me.dgvBillExcludedServices.Rows(selectedRow).Cells, Me.colServiceCode)

    End Sub

    Private Sub dgvBillExcludedServices_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedServices.CellEndEdit

          Try
            Dim selectedRow As Integer = Me.dgvBillExcludedServices.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.ColExTServiceCode.Index) Then

                If Me.dgvBillExcludedServices.Rows.Count > 1 Then Me.SetServicesEntries(selectedRow)


            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvBillExcludedServices_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillExcludedServices.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvBillExcludedServices.Item(Me.colBillExcludedServicesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            Dim itemCode As String = CStr(Me.dgvBillExcludedServices.Item(Me.ColExTServiceCode.Name, toDeleteRowNo).Value)

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
            With oBillExcludedItems
                .AccountNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Service
            End With

            DisplayMessage(oBillExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvBillExcludedServices_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillExcludedServices.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadBillExcludedServices(ByVal accountNo As String)

        Dim billExcludedServices As DataTable
        Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvBillExcludedServices.Rows.Clear()

            ' Load items not yet paid for

            billExcludedServices = oBillExcludedItems.GetBillExcludedItems(accountNo, oItemCategoryID.Service).Tables("BillExcludedItems")

            If billExcludedServices Is Nothing OrElse billExcludedServices.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillExcludedServices, billExcludedServices)

            For Each row As DataGridViewRow In Me.dgvBillExcludedServices.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillExcludedServices.Item(Me.colBillExcludedServicesSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvBillExcludedServices_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedServices.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Services", "Service Code", "Service", Me.GetServices(), "ServiceFullName",
                                                                     "ServiceCode", "ServiceName", Me.dgvBillExcludedServices, Me.ColExTServiceCode, e.RowIndex)

            Me._ServiceCode = StringMayBeEnteredIn(Me.dgvBillExcludedServices.Rows(e.RowIndex).Cells, Me.ColExTServiceCode)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColEXTServiceSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvBillExcludedServices.Rows(e.RowIndex).IsNewRow Then

                Me.dgvBillExcludedServices.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetServicesEntries(e.RowIndex)
            ElseIf Me.ColEXTServiceSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetServicesEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetServicesEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedServices.Rows(selectedRow).Cells, Me.ColExTServiceCode)
            Me.SetServicesEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetServicesEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvBillExcludedServices.Item(Me.colBillExcludedServicesSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Service Code (" + Me._ServiceCode + ") can't be edited!")
                Me.dgvBillExcludedServices.Item(Me.ColExTServiceCode.Name, selectedRow).Value = Me._ServiceCode
                Me.dgvBillExcludedServices.Item(Me.ColExTServiceCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvBillExcludedServices.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedServices.Rows(rowNo).Cells, Me.ColExTServiceCode)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Service Code (" + enteredItem + ") already selected!")
                        Me.dgvBillExcludedServices.Rows.RemoveAt(selectedRow)
                        Me.dgvBillExcludedServices.Item(Me.ColExTServiceCode.Name, selectedRow).Value = Me._ServiceCode
                        Me.dgvBillExcludedServices.Item(Me.ColExTServiceCode.Name, selectedRow).Selected = True


                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailEnteredService(selectedRow)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailEnteredService(ByVal selectedRow As Integer)
        Try

            Dim oService As New SyncSoft.SQLDb.Services()
            Dim serviceCode As String = String.Empty

            If Me.dgvBillExcludedServices.Rows.Count > 1 Then serviceCode = SubstringRight(StringMayBeEnteredIn(Me.dgvBillExcludedServices.Rows(selectedRow).Cells, Me.ColExTServiceCode))

            If String.IsNullOrEmpty(serviceCode) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim services As DataTable = oService.GetServices(serviceCode).Tables("Services")
            If services Is Nothing OrElse String.IsNullOrEmpty(serviceCode) Then Return
            Dim row As DataRow = services.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim serviceName As String = StringEnteredIn(row, "ServiceName", "Service Name!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvBillExcludedServices
                .Item(Me.ColExTServiceCode.Name, selectedRow).Value = serviceCode.ToUpper()
                .Item(Me.colServiceCode.Name, selectedRow).Value = serviceName

            End With


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvBillExcludedServices.Item(Me.ColExTServiceCode.Name, selectedRow).Value = Me._ServiceCode.ToUpper()
            Throw ex

        End Try

    End Sub


#End Region

#Region " Drugs - Grid "

    Private Sub dgvBillExcludedDrugs_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBillExcludedDrugs.CellBeginEdit

        If e.ColumnIndex <> Me.colDrugName.Index OrElse Me.dgvBillExcludedDrugs.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvBillExcludedDrugs.CurrentCell.RowIndex
        _DrugNameValue = StringMayBeEnteredIn(Me.dgvBillExcludedDrugs.Rows(selectedRow).Cells, Me.colDrugName)


    End Sub

     Private Sub dgvBillExcludedDrugs_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillExcludedDrugs.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvBillExcludedDrugs.Item(Me.colBillExcludedDrugsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            Dim itemCode As String = CStr(Me.dgvBillExcludedDrugs.Item(Me.colEXTDrugNo.Name, toDeleteRowNo).Value)

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
            With oBillExcludedItems
                .AccountNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oBillExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvBillExcludedDrugs_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillExcludedDrugs.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadBillExcludedDrugs(ByVal accountNo As String)

        Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvBillExcludedDrugs.Rows.Clear()

            ' Load items not yet paid for

            Dim billExcludedDrugs As DataTable = oBillExcludedItems.GetBillExcludedItems(accountNo, oItemCategoryID.Drug).Tables("BillExcludedItems")

            If billExcludedDrugs Is Nothing OrElse billExcludedDrugs.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillExcludedDrugs, billExcludedDrugs)

            For Each row As DataGridViewRow In Me.dgvBillExcludedDrugs.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillExcludedDrugs.Item(Me.colBillExcludedDrugsSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvBillExcludedDrugs_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedDrugs.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("Drugs", "Drug No", "Drug", Me.GetDrugs(), "DrugFullName",
                                                                     "DrugNo", "DrugName", Me.dgvBillExcludedDrugs, Me.colEXTDrugNo, e.RowIndex)

            Me._DrugNo = StringMayBeEnteredIn(Me.dgvBillExcludedDrugs.Rows(e.RowIndex).Cells, Me.colEXTDrugNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.colSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvBillExcludedDrugs.Rows(e.RowIndex).IsNewRow Then

                Me.dgvBillExcludedDrugs.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetDrugsEntries(e.RowIndex)
            ElseIf Me.colSelect.Index.Equals(e.ColumnIndex) Then

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

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvBillExcludedDrugs.Rows(selectedRow).Cells, Me.colEXTDrugNo))
            Me.SetDrugsEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetDrugsEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvBillExcludedDrugs.Item(Me.colBillExcludedDrugsSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Drug No (" + Me._DrugNo + ") can't be edited!")
                Me.dgvBillExcludedDrugs.Item(Me.colEXTDrugNo.Name, selectedRow).Value = Me._DrugNo
                Me.dgvBillExcludedDrugs.Item(Me.colEXTDrugNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvBillExcludedDrugs.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedDrugs.Rows(rowNo).Cells, Me.colEXTDrugNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Drug No (" + enteredItem + ") already selected!")
                        Me.dgvBillExcludedDrugs.Rows.RemoveAt(selectedRow)
                        Me.dgvBillExcludedDrugs.Item(Me.colEXTDrugNo.Name, selectedRow).Value = Me._DrugNo
                        Me.dgvBillExcludedDrugs.Item(Me.colEXTDrugNo.Name, selectedRow).Selected = True


                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailEnteredDrug(selectedRow)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailEnteredDrug(ByVal selectedRow As Integer)
        Try

            Dim drugSelected As String = String.Empty
            Dim oDrugs As New SyncSoft.SQLDb.Drugs()
            Dim drugNo As String = String.Empty

            If Me.dgvBillExcludedDrugs.Rows.Count > 1 Then drugNo = SubstringRight(StringMayBeEnteredIn(Me.dgvBillExcludedDrugs.Rows(selectedRow).Cells, Me.colEXTDrugNo))

            If String.IsNullOrEmpty(drugNo) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim drugs As DataTable = oDrugs.GetDrugs(drugNo).Tables("Drugs")
            If drugs Is Nothing OrElse String.IsNullOrEmpty(drugNo) Then Return
            Dim row As DataRow = drugs.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim drugName As String = StringEnteredIn(row, "DrugName", "Drug Name!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvBillExcludedDrugs
                .Item(Me.colEXTDrugNo.Name, selectedRow).Value = drugNo.ToUpper()
                .Item(Me.colDrugName.Name, selectedRow).Value = drugName

            End With


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvBillExcludedDrugs.Item(Me.colEXTDrugNo.Name, selectedRow).Value = Me._DrugNo.ToUpper()
            Throw ex

        End Try

    End Sub

    Private Sub dgvBillExcludedDrugs_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedDrugs.CellEndEdit

        Try
            Dim selectedRow As Integer = Me.dgvBillExcludedDrugs.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.colEXTDrugNo.Index) Then

                If Me.dgvBillExcludedDrugs.Rows.Count > 1 Then Me.SetDrugsEntries(selectedRow)


            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try
    End Sub

#End Region

#Region " LabTests - Grid "

    Private Sub dgvBillExcludedLabTests_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBillExcludedLabTests.CellBeginEdit

        If e.ColumnIndex <> Me.colTestName.Index OrElse Me.dgvBillExcludedLabTests.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvBillExcludedLabTests.CurrentCell.RowIndex
        _TestNameValue = StringMayBeEnteredIn(Me.dgvBillExcludedLabTests.Rows(selectedRow).Cells, Me.colTestName)

    End Sub

    Private Sub dgvBillExcludedLabTests_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedLabTests.CellEndEdit

        Try
            Dim selectedRow As Integer = Me.dgvBillExcludedLabTests.CurrentCell.RowIndex
            If e.ColumnIndex.Equals(Me.ColEXTTestNo.Index) Then

                If Me.dgvBillExcludedLabTests.Rows.Count > 1 Then Me.SetLabTestEntries(selectedRow)


            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvBillExcludedLabTests_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillExcludedLabTests.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvBillExcludedLabTests.Item(Me.colBillExcludedLabTestsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            Dim itemCode As String = CStr(Me.dgvBillExcludedLabTests.Item(Me.ColEXTTestNo.Name, toDeleteRowNo).Value)

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
            With oBillExcludedItems
                .AccountNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Test
            End With

            DisplayMessage(oBillExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvBillExcludedLabTests_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillExcludedLabTests.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadBillExcludedLabTests(ByVal accountNo As String)

        Dim billExcludedLabTests As DataTable
        Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvBillExcludedLabTests.Rows.Clear()

            ' Load items not yet paid for

            billExcludedLabTests = oBillExcludedItems.GetBillExcludedItems(accountNo, oItemCategoryID.Test).Tables("BillExcludedItems")

            If billExcludedLabTests Is Nothing OrElse billExcludedLabTests.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillExcludedLabTests, billExcludedLabTests)

            For Each row As DataGridViewRow In Me.dgvBillExcludedLabTests.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillExcludedLabTests.Item(Me.colBillExcludedLabTestsSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvBillExcludedLabTests_CellClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedLabTests.CellClick
        Try

            Me.Cursor = Cursors.WaitCursor

            If e.RowIndex < 0 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fSelectItem As New SyncSoft.SQL.Win.Forms.SelectItem("LabTests", "Test Code", "Test", Me.GetLabTests(), "TestFullName",
                                                                     "TestCode", "TestName", Me.dgvBillExcludedLabTests, Me.ColEXTTestNo, e.RowIndex)

            Me._TestNo = StringMayBeEnteredIn(Me.dgvBillExcludedLabTests.Rows(e.RowIndex).Cells, Me.ColEXTTestNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ColLabSelect.Index.Equals(e.ColumnIndex) AndAlso Me.dgvBillExcludedLabTests.Rows(e.RowIndex).IsNewRow Then

                Me.dgvBillExcludedLabTests.Rows.Add()

                fSelectItem.ShowDialog(Me)
                Me.SetLabTestEntries(e.RowIndex)
            ElseIf Me.ColLabSelect.Index.Equals(e.ColumnIndex) Then

                fSelectItem.ShowDialog(Me)
                Me.SetLabTestEntries(e.RowIndex)

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub SetLabTestEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = SubstringRight(StringMayBeEnteredIn(Me.dgvBillExcludedLabTests.Rows(selectedRow).Cells, Me.ColEXTTestNo))
            Me.SetLabTestEntries(selectedRow, selectedItem)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetLabTestEntries(ByVal selectedRow As Integer, selectedItem As String)

        Try
            If CBool(Me.dgvBillExcludedLabTests.Item(Me.colBillExcludedLabTestsSaved.Name, selectedRow).Value).Equals(True) Then
                DisplayMessage("Test No (" + Me._TestNo + ") can't be edited!")
                Me.dgvBillExcludedLabTests.Item(Me.ColEXTTestNo.Name, selectedRow).Value = Me._TestNo
                Me.dgvBillExcludedLabTests.Item(Me.ColEXTTestNo.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvBillExcludedLabTests.RowCount - 2
                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedLabTests.Rows(rowNo).Cells, Me.ColEXTTestNo)
                    If enteredItem.ToUpper().Equals(selectedItem.ToUpper()) Then
                        DisplayMessage("Test No (" + enteredItem + ") already selected!")
                        Me.dgvBillExcludedLabTests.Rows.RemoveAt(selectedRow)
                        Me.dgvBillExcludedLabTests.Item(Me.ColEXTTestNo.Name, selectedRow).Value = Me._TestNo
                        Me.dgvBillExcludedLabTests.Item(Me.ColEXTTestNo.Name, selectedRow).Selected = True


                    End If
                End If
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ' Populate other columns based upon what is entered in combo column
            Me.DetailEnteredLabTest(selectedRow)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub DetailEnteredLabTest(ByVal selectedRow As Integer)
        Try

            Dim oLabTests As New SyncSoft.SQLDb.LabTests
            Dim labTest As String = String.Empty

            If Me.dgvBillExcludedLabTests.Rows.Count > 1 Then labTest = SubstringRight(StringMayBeEnteredIn(Me.dgvBillExcludedLabTests.Rows(selectedRow).Cells, Me.ColEXTTestNo))

            If String.IsNullOrEmpty(labTest) Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim labTests As DataTable = oLabTests.GetLabTests(labTest).Tables("LabTests")
            If labTests Is Nothing OrElse String.IsNullOrEmpty(labTest) Then Return
            Dim row As DataRow = labTests.Rows(0)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim labTestName As String = StringEnteredIn(row, "TestName", "Test Name!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With Me.dgvBillExcludedLabTests
                .Item(Me.ColEXTTestNo.Name, selectedRow).Value = labTest.ToUpper()
                .Item(Me.colTestName.Name, selectedRow).Value = labTestName

            End With


            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Me.dgvBillExcludedLabTests.Item(Me.ColEXTTestNo.Name, selectedRow).Value = Me._TestNo.ToUpper()
            Throw ex

        End Try

    End Sub

#End Region

#Region " Radiology - Grid "

    Private Sub dgvBillExcludedRadiology_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBillExcludedRadiology.CellBeginEdit

        If e.ColumnIndex <> Me.colExamCode.Index OrElse Me.dgvBillExcludedRadiology.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvBillExcludedRadiology.CurrentCell.RowIndex
        _RadiologyNameValue = StringMayBeEnteredIn(Me.dgvBillExcludedRadiology.Rows(selectedRow).Cells, Me.colExamCode)

    End Sub

    Private Sub dgvBillExcludedRadiology_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedRadiology.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colExamCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvBillExcludedRadiology.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvBillExcludedRadiology.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedRadiology.Rows(selectedRow).Cells, Me.colExamCode)

                    If CBool(Me.dgvBillExcludedRadiology.Item(Me.colBillExcludedRadiologySaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Radiology As EnumerableRowCollection(Of DataRow) = radiologyExaminations.AsEnumerable()
                        Dim radiologyDisplay As String = (From data In _Radiology _
                                            Where data.Field(Of String)("ExamCode").ToUpper().Equals(_RadiologyNameValue.ToUpper()) _
                                            Select data.Field(Of String)("ExamName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Radiology (" + radiologyDisplay + ") can't be edited!")
                        Me.dgvBillExcludedRadiology.Item(Me.colExamCode.Name, selectedRow).Value = _RadiologyNameValue
                        Me.dgvBillExcludedRadiology.Item(Me.colExamCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvBillExcludedRadiology.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedRadiology.Rows(rowNo).Cells, Me.colExamCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Radiology As EnumerableRowCollection(Of DataRow) = radiologyExaminations.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Radiology _
                                                    Where data.Field(Of String)("ExamCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("ExamName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Radiology (" + enteredDisplay + ") already entered!")
                                Me.dgvBillExcludedRadiology.Item(Me.colExamCode.Name, selectedRow).Value = _RadiologyNameValue
                                Me.dgvBillExcludedRadiology.Item(Me.colExamCode.Name, selectedRow).Selected = True
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

    Private Sub dgvBillExcludedRadiology_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillExcludedRadiology.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvBillExcludedRadiology.Item(Me.colBillExcludedRadiologySaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            Dim itemCode As String = CStr(Me.dgvBillExcludedRadiology.Item(Me.colExamCode.Name, toDeleteRowNo).Value)

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
            With oBillExcludedItems
                .AccountNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Radiology
            End With

            DisplayMessage(oBillExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvBillExcludedRadiology_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillExcludedRadiology.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadBillExcludedRadiology(ByVal accountNo As String)

        Dim billExcludedRadiology As DataTable
        Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvBillExcludedRadiology.Rows.Clear()

            ' Load items not yet paid for

            billExcludedRadiology = oBillExcludedItems.GetBillExcludedItems(accountNo, oItemCategoryID.Radiology).Tables("BillExcludedItems")

            If billExcludedRadiology Is Nothing OrElse billExcludedRadiology.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillExcludedRadiology, billExcludedRadiology)

            For Each row As DataGridViewRow In Me.dgvBillExcludedRadiology.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillExcludedRadiology.Item(Me.colBillExcludedRadiologySaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Procedures - Grid "

    Private Sub dgvBillExcludedProcedures_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBillExcludedProcedures.CellBeginEdit

        If e.ColumnIndex <> Me.colProcedureCode.Index OrElse Me.dgvBillExcludedProcedures.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvBillExcludedProcedures.CurrentCell.RowIndex
        _ProcedureNameValue = StringMayBeEnteredIn(Me.dgvBillExcludedProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

    End Sub

    Private Sub dgvBillExcludedProcedures_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedProcedures.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colProcedureCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvBillExcludedProcedures.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvBillExcludedProcedures.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedProcedures.Rows(selectedRow).Cells, Me.colProcedureCode)

                    If CBool(Me.dgvBillExcludedProcedures.Item(Me.colBillExcludedProceduresSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                        Dim procedureDisplay As String = (From data In _Procedures _
                                            Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(_ProcedureNameValue.ToUpper()) _
                                            Select data.Field(Of String)("ProcedureName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Procedure (" + procedureDisplay + ") can't be edited!")
                        Me.dgvBillExcludedProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                        Me.dgvBillExcludedProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvBillExcludedProcedures.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedProcedures.Rows(rowNo).Cells, Me.colProcedureCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Procedures As EnumerableRowCollection(Of DataRow) = procedures.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Procedures _
                                                    Where data.Field(Of String)("ProcedureCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("ProcedureName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Procedure (" + enteredDisplay + ") already entered!")
                                Me.dgvBillExcludedProcedures.Item(Me.colProcedureCode.Name, selectedRow).Value = _ProcedureNameValue
                                Me.dgvBillExcludedProcedures.Item(Me.colProcedureCode.Name, selectedRow).Selected = True
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

    Private Sub dgvBillExcludedProcedures_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillExcludedProcedures.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvBillExcludedProcedures.Item(Me.colBillExcludedProceduresSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            Dim itemCode As String = CStr(Me.dgvBillExcludedProcedures.Item(Me.colProcedureCode.Name, toDeleteRowNo).Value)

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
            With oBillExcludedItems
                .AccountNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oBillExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvBillExcludedProcedures_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillExcludedProcedures.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadBillExcludedProcedures(ByVal accountNo As String)

        Dim billExcludedProcedures As DataTable
        Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvBillExcludedProcedures.Rows.Clear()

            ' Load items not yet paid for

            billExcludedProcedures = oBillExcludedItems.GetBillExcludedItems(accountNo, oItemCategoryID.Procedure).Tables("BillExcludedItems")

            If billExcludedProcedures Is Nothing OrElse billExcludedProcedures.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillExcludedProcedures, billExcludedProcedures)

            For Each row As DataGridViewRow In Me.dgvBillExcludedProcedures.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillExcludedProcedures.Item(Me.colBillExcludedProceduresSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region "Dental Services -Grid"

    Private Sub dgvBillExcludedDentalServices_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBillExcludedDentalServices.CellBeginEdit
        If e.ColumnIndex <> Me.colDentalCode.Index OrElse Me.dgvBillExcludedDentalServices.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvBillExcludedDentalServices.CurrentCell.RowIndex
        _DentalServiceValue = StringMayBeEnteredIn(Me.dgvBillExcludedDentalServices.Rows(selectedRow).Cells, Me.colDentalCode)

    End Sub

    Private Sub dgvBillExcludedDentalServices_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedDentalServices.CellEndEdit
        Try

            If e.ColumnIndex.Equals(Me.colDentalCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvBillExcludedDentalServices.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvBillExcludedDentalServices.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedDentalServices.Rows(selectedRow).Cells, Me.colDentalCode)

                    If CBool(Me.dgvBillExcludedDentalServices.Item(Me.colBillExcludedDentalServicesSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _dental As EnumerableRowCollection(Of DataRow) = dentalServices.AsEnumerable()
                        Dim dentalServicesDisplay As String = (From data In _dental _
                                            Where data.Field(Of String)("DentalCode").ToUpper().Equals(_DentalServiceValue.ToUpper()) _
                                            Select data.Field(Of String)("DentalName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Dental Services (" + dentalServicesDisplay + ") can't be edited!")
                        Me.dgvBillExcludedDentalServices.Item(Me.colDentalCode.Name, selectedRow).Value = _DentalServiceValue
                        Me.dgvBillExcludedDentalServices.Item(Me.colDentalCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvBillExcludedDentalServices.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedDentalServices.Rows(rowNo).Cells, Me.colDentalCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _dental As EnumerableRowCollection(Of DataRow) = dentalServices.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _dental _
                                                    Where data.Field(Of String)("DentalCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("DentalName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Dental Services (" + enteredDisplay + ") already entered!")
                                Me.dgvBillExcludedDentalServices.Item(Me.colDentalCode.Name, selectedRow).Value = _DentalServiceValue
                                Me.dgvBillExcludedDentalServices.Item(Me.colDentalCode.Name, selectedRow).Selected = True
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

    Private Sub dgvBillExcludedDentalServices_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillExcludedDentalServices.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub dgvBillExcludedDentalServices_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillExcludedDentalServices.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvBillExcludedDentalServices.Item(Me.colBillExcludedDentalServicesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            Dim itemCode As String = CStr(Me.dgvBillExcludedDentalServices.Item(Me.colDentalCode.Name, toDeleteRowNo).Value)

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
            With oBillExcludedItems
                .AccountNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Dental
            End With

            DisplayMessage(oBillExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBillExcludedDentalServices(ByVal accountNo As String)

        Dim billExcludedDentalServices As DataTable
        Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvBillExcludedDentalServices.Rows.Clear()
            billExcludedDentalServices = oBillExcludedItems.GetBillExcludedItems(accountNo, oItemCategoryID.Dental).Tables("BillExcludedItems")

            If billExcludedDentalServices Is Nothing OrElse billExcludedDentalServices.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillExcludedDentalServices, billExcludedDentalServices)

            For Each row As DataGridViewRow In Me.dgvBillExcludedDentalServices.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillExcludedDentalServices.Item(Me.colBillExcludedDentalServicesSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub



#End Region

#Region "Pathology -Grid"

    Private Sub dgvBillExcludedPathology_CellBeginEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBillExcludedPathology.CellBeginEdit
        If e.ColumnIndex <> Me.colPathologyExamFullName.Index OrElse Me.dgvBillExcludedPathology.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvBillExcludedPathology.CurrentCell.RowIndex
        _PathologyValue = StringMayBeEnteredIn(Me.dgvBillExcludedPathology.Rows(selectedRow).Cells, Me.colPathologyExamFullName)

    End Sub

    Private Sub dgvBillExcludedPathology_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedPathology.CellEndEdit
        Try

            If e.ColumnIndex.Equals(Me.colPathologyExamFullName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvBillExcludedPathology.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvBillExcludedPathology.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedPathology.Rows(selectedRow).Cells, Me.colPathologyExamFullName)

                    If CBool(Me.dgvBillExcludedPathology.Item(Me.colBillExcludedPathologySaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _Pathology As EnumerableRowCollection(Of DataRow) = pathologyExaminations.AsEnumerable()
                        Dim pathologyDisplay As String = (From data In _Pathology _
                                            Where data.Field(Of String)("ExamCode").ToUpper().Equals(_PathologyValue.ToUpper()) _
                                            Select data.Field(Of String)("ExamName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Pathology (" + pathologyDisplay + ") can't be edited!")
                        Me.dgvBillExcludedPathology.Item(Me.colPathologyExamFullName.Name, selectedRow).Value = _PathologyValue
                        Me.dgvBillExcludedPathology.Item(Me.colPathologyExamFullName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvBillExcludedPathology.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedPathology.Rows(rowNo).Cells, Me.colPathologyExamFullName)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _Pathologys As EnumerableRowCollection(Of DataRow) = pathologyExaminations.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _Pathologys _
                                                    Where data.Field(Of String)("ExamCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("ExamName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Pathology (" + enteredDisplay + ") already entered!")
                                Me.dgvBillExcludedPathology.Item(Me.colPathologyExamFullName.Name, selectedRow).Value = _PathologyValue
                                Me.dgvBillExcludedPathology.Item(Me.colPathologyExamFullName.Name, selectedRow).Selected = True
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

    Private Sub dgvBillExcludedPathology_UserDeletingRow(sender As System.Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillExcludedPathology.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvBillExcludedPathology.Item(Me.colBillExcludedPathologySaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            Dim itemCode As String = CStr(Me.dgvBillExcludedPathology.Item(Me.colPathologyExamFullName.Name, toDeleteRowNo).Value)

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
            With oBillExcludedItems
                .AccountNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Pathology
            End With

            DisplayMessage(oBillExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvBillExcludedPathology_DataError(sender As Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillExcludedPathology.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadBillPathologyServices(ByVal accountNo As String)

        Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvBillExcludedPathology.Rows.Clear()



            Dim billExcludedPathology As DataTable = oBillExcludedItems.GetBillExcludedItems(accountNo, oItemCategoryID.Pathology).Tables("BillExcludedItems")

            If billExcludedPathology Is Nothing OrElse billExcludedPathology.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillExcludedPathology, billExcludedPathology)

            For Each row As DataGridViewRow In Me.dgvBillExcludedPathology.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillExcludedPathology.Item(Me.colBillExcludedPathologySaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub


#End Region

#Region "Optical Services -Grid"
    Private Sub dgvBillExcludedOpticalServices_CellBeginEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBillExcludedOpticalServices.CellBeginEdit
        If e.ColumnIndex <> Me.colOpticalCode.Index OrElse Me.dgvBillExcludedOpticalServices.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvBillExcludedOpticalServices.CurrentCell.RowIndex
        _OpticalServiceValue = StringMayBeEnteredIn(Me.dgvBillExcludedOpticalServices.Rows(selectedRow).Cells, Me.colOpticalCode)

    End Sub

    Private Sub dgvBillExcludedOpticalServices_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedOpticalServices.CellEndEdit
        Try

            If e.ColumnIndex.Equals(Me.colOpticalCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvBillExcludedOpticalServices.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvBillExcludedOpticalServices.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedOpticalServices.Rows(selectedRow).Cells, Me.colOpticalCode)

                    If CBool(Me.dgvBillExcludedOpticalServices.Item(Me.colBillExcludedOtherOpticalSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _OpticalServices As EnumerableRowCollection(Of DataRow) = opticalServices.AsEnumerable()
                        Dim OpticalServicesDisplay As String = (From data In _OpticalServices _
                                            Where data.Field(Of String)("OpticalCode").ToUpper().Equals(_OpticalServiceValue.ToUpper()) _
                                            Select data.Field(Of String)("OpticalName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Optical Name (" + OpticalServicesDisplay + ") can't be edited!")
                        Me.dgvBillExcludedOpticalServices.Item(Me.colOpticalCode.Name, selectedRow).Value = _OpticalServiceValue
                        Me.dgvBillExcludedOpticalServices.Item(Me.colOpticalCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvBillExcludedOpticalServices.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedOpticalServices.Rows(rowNo).Cells, Me.colOpticalCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _OpticalServices As EnumerableRowCollection(Of DataRow) = opticalServices.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _OpticalServices _
                                                    Where data.Field(Of String)("OpticalCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("OpticalName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Optical Name (" + enteredDisplay + ") already entered!")
                                Me.dgvBillExcludedOpticalServices.Item(Me.colOpticalCode.Name, selectedRow).Value = _OpticalServiceValue
                                Me.dgvBillExcludedOpticalServices.Item(Me.colOpticalCode.Name, selectedRow).Selected = True
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

    Private Sub dgvBillExcludedOpticalServices_DataError(sender As System.Object, e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillExcludedOpticalServices.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub dgvBillExcludedOpticalServices_UserDeletingRow(sender As Object, e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillExcludedOpticalServices.UserDeletingRow
        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvBillExcludedOpticalServices.Item(Me.colBillExcludedOtherOpticalSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            Dim itemCode As String = CStr(Me.dgvBillExcludedOpticalServices.Item(Me.colOpticalCode.Name, toDeleteRowNo).Value)

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
            With oBillExcludedItems
                .AccountNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Optical
            End With

            DisplayMessage(oBillExcludedItems.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try
    End Sub

    Private Sub LoadBillExcludedOpticalServices(ByVal accountNo As String)

        Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvBillExcludedOpticalServices.Rows.Clear()



            Dim billExcludedOpticalServices As DataTable = oBillExcludedItems.GetBillExcludedItems(accountNo, oItemCategoryID.Optical).Tables("BillExcludedItems")

            If billExcludedOpticalServices Is Nothing OrElse billExcludedOpticalServices.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillExcludedOpticalServices, billExcludedOpticalServices)

            For Each row As DataGridViewRow In Me.dgvBillExcludedOpticalServices.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillExcludedOpticalServices.Item(Me.colBillExcludedOtherOpticalSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub
#End Region

#Region " AssociatedBillCustomers - Grid "

    Private Sub dgvAssociatedBillCustomers_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvAssociatedBillCustomers.CellBeginEdit

        If e.ColumnIndex <> Me.colBillCustomerName.Index OrElse Me.dgvAssociatedBillCustomers.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvAssociatedBillCustomers.CurrentCell.RowIndex
        _AccountNoValue = StringMayBeEnteredIn(Me.dgvAssociatedBillCustomers.Rows(selectedRow).Cells, Me.colBillCustomerName)

    End Sub

    Private Sub dgvAssociatedBillCustomers_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvAssociatedBillCustomers.CellEndEdit

        Try

            If Me.colBillCustomerName.Items.Count < 1 Then Return

            If e.ColumnIndex.Equals(Me.colBillCustomerName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvAssociatedBillCustomers.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvAssociatedBillCustomers.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvAssociatedBillCustomers.Rows(selectedRow).Cells, Me.colBillCustomerName)

                    If CBool(Me.dgvAssociatedBillCustomers.Item(Me.colAssociatedBillCustomersSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                        Dim billCustomerName As String = (From data In _BillCustomers _
                                            Where data.Field(Of String)("AccountNo").ToUpper().Equals(_AccountNoValue.ToUpper()) _
                                            Select data.Field(Of String)("BillCustomerName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Associated To-Bill No (" + billCustomerName + ") can't be edited!")
                        Me.dgvAssociatedBillCustomers.Item(Me.colBillCustomerName.Name, selectedRow).Value = _AccountNoValue
                        Me.dgvAssociatedBillCustomers.Item(Me.colBillCustomerName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvAssociatedBillCustomers.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvAssociatedBillCustomers.Rows(rowNo).Cells, Me.colBillCustomerName)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _BillCustomers As EnumerableRowCollection(Of DataRow) = billCustomers.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _BillCustomers _
                                                    Where data.Field(Of String)("AccountNo").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("BillCustomerName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Associated To-Bill No (" + enteredDisplay + ") already entered!")
                                Me.dgvAssociatedBillCustomers.Item(Me.colBillCustomerName.Name, selectedRow).Value = _AccountNoValue
                                Me.dgvAssociatedBillCustomers.Item(Me.colBillCustomerName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.DetailAssociatedBillCustomers()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub DetailAssociatedBillCustomers()

        Dim selectedRow As Integer
        Dim selectedItem As String = String.Empty

        Try

            If Me.dgvAssociatedBillCustomers.Rows.Count > 1 Then
                selectedRow = Me.dgvAssociatedBillCustomers.CurrentCell.RowIndex
                selectedItem = StringMayBeEnteredIn(Me.dgvAssociatedBillCustomers.Rows(selectedRow).Cells, Me.colBillCustomerName)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(selectedItem) Then
                Me.dgvAssociatedBillCustomers.Item(Me.colAssociatedBillNo.Name, selectedRow).Value = selectedItem
            Else : Me.dgvAssociatedBillCustomers.Item(Me.colAssociatedBillNo.Name, selectedRow).Value = String.Empty
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvAssociatedBillCustomers_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvAssociatedBillCustomers.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oAssociatedBillCustomers As New SyncSoft.SQLDb.AssociatedBillCustomers()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvAssociatedBillCustomers.Item(Me.colAssociatedBillCustomersSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            Dim associatedBillNo As String = CStr(Me.dgvAssociatedBillCustomers.Item(Me.colBillCustomerName.Name, toDeleteRowNo).Value)

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
            With oAssociatedBillCustomers
                .AccountNo = accountNo
                .AssociatedBillNo = associatedBillNo
            End With

            DisplayMessage(oAssociatedBillCustomers.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvAssociatedBillCustomers_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvAssociatedBillCustomers.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadAssociatedBillCustomers(ByVal accountNo As String)

        Dim oAssociatedBillCustomers As New SyncSoft.SQLDb.AssociatedBillCustomers()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim associatedBillCustomers As DataTable = oAssociatedBillCustomers.GetAssociatedBillCustomers(accountNo).Tables("AssociatedBillCustomers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvAssociatedBillCustomers, associatedBillCustomers)

            For Each row As DataGridViewRow In Me.dgvAssociatedBillCustomers.Rows
                If row.IsNewRow Then Exit For
                Me.dgvAssociatedBillCustomers.Item(Me.colAssociatedBillCustomersSaved.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region "Extra Charge - Grid"
    Private Sub LoadExtraChargeItems()

        Dim oExtraChargeItems As New SyncSoft.SQLDb.ExtraChargeItems()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from ExtraChargeItems
            extraChargeItems = oExtraChargeItems.GetExtraChargeItems().Tables("ExtraChargeItems")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colExtraChargeItems, extraChargeItems, "ExtraItemCode", "ExtraItemName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBillExcludedExtraChargeItems(ByVal accountNo As String)

        Dim billExcludedExtraCharge As DataTable
        Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvBillExcludedExtraChargeItems.Rows.Clear()

            ' Load items not yet paid for

            billExcludedExtraCharge = oBillExcludedItems.GetBillExcludedItems(accountNo, oItemCategoryID.Extras).Tables("BillExcludedItems")

            If billExcludedExtraCharge Is Nothing OrElse billExcludedExtraCharge.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillExcludedExtraChargeItems, billExcludedExtraCharge)

            For Each row As DataGridViewRow In Me.dgvBillExcludedExtraChargeItems.Rows
                If row.IsNewRow Then Exit For
                Me.dgvBillExcludedExtraChargeItems.Item(Me.colBillExcludedExtraChargeItemsSaved.Name, row.Index).Value = True
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub dgvBillExcludedExtraChargeItems_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvBillExcludedExtraChargeItems.CellBeginEdit
        If e.ColumnIndex <> Me.colExtraChargeItems.Index OrElse Me.dgvBillExcludedExtraChargeItems.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvBillExcludedExtraChargeItems.CurrentCell.RowIndex
        _ExtraChargeItemNameValue = StringMayBeEnteredIn(Me.dgvBillExcludedExtraChargeItems.Rows(selectedRow).Cells, Me.colExtraChargeItems)
    End Sub

    Private Sub dgvBillExcludedExtraChargeItems_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvBillExcludedExtraChargeItems.CellEndEdit
        Try
            If e.ColumnIndex.Equals(Me.colExtraChargeItems.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvBillExcludedExtraChargeItems.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvBillExcludedExtraChargeItems.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedExtraChargeItems.Rows(selectedRow).Cells, Me.colExtraChargeItems)

                    If CBool(Me.dgvBillExcludedExtraChargeItems.Item(Me.colBillExcludedExtraChargeItemsSaved.Name, selectedRow).Value).Equals(True) Then
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim _ExtraChargeItems As EnumerableRowCollection(Of DataRow) = extraChargeItems.AsEnumerable()
                        Dim ExtraChargeItemsDisplay As String = (From data In _ExtraChargeItems _
                                            Where data.Field(Of String)("ExtraItemCode").ToUpper().Equals(_ExtraChargeItemNameValue.ToUpper()) _
                                            Select data.Field(Of String)("ExtraItemFullName")).First()
                        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Extra Charge Item (" + ExtraChargeItemsDisplay + ") can't be edited!")
                        Me.dgvBillExcludedExtraChargeItems.Item(Me.colExtraChargeItems.Name, selectedRow).Value = _ExtraChargeItemNameValue
                        Me.dgvBillExcludedExtraChargeItems.Item(Me.colExtraChargeItems.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvBillExcludedExtraChargeItems.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvBillExcludedExtraChargeItems.Rows(rowNo).Cells, Me.colExtraChargeItems)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                Dim _ExtraChargeItems As EnumerableRowCollection(Of DataRow) = extraChargeItems.AsEnumerable()
                                Dim enteredDisplay As String = (From data In _ExtraChargeItems _
                                                    Where data.Field(Of String)("ExtraItemCode").ToUpper().Equals(enteredItem.ToUpper()) _
                                                    Select data.Field(Of String)("ExtraItemFullName")).First()
                                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                                DisplayMessage("Extra Charge Item (" + enteredDisplay + ") already entered!")
                                Me.dgvBillExcludedExtraChargeItems.Item(Me.colExtraChargeItems.Name, selectedRow).Value = _ExtraChargeItemNameValue
                                Me.dgvBillExcludedExtraChargeItems.Item(Me.colExtraChargeItems.Name, selectedRow).Selected = True
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

    Private Sub dgvBillExcludedExtraChargeItems_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvBillExcludedExtraChargeItems.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub dgvBillExcludedExtraChargeItems_UserDeletingRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvBillExcludedExtraChargeItems.UserDeletingRow
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oItemCategoryID As New LookupDataID.ItemCategoryID()
            Dim oBillExcludedItems As New SyncSoft.SQLDb.BillExcludedItems()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvBillExcludedExtraChargeItems.Item(Me.colExtraChargeItems.Name, toDeleteRowNo).Value) = False Then Return

            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            Dim itemCode As String = CStr(Me.dgvBillExcludedExtraChargeItems.Item(Me.colExtraChargeItems.Name, toDeleteRowNo).Value)

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
            With oBillExcludedItems
                .AccountNo = accountNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Extras
            End With

            DisplayMessage(oBillExcludedItems.Delete())

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

        Me.cboAccountNo.Enabled = True
        Me.cboAccountNo.MaxLength = 64
        Me.LoadBillCustomers(True)
        Me.chkHidden.Enabled = True

        Me.pnlStatusID.Enabled = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgBillExcludedServices)
        ResetControlsIn(Me.tpgBillExcludedDrugs)
        ResetControlsIn(Me.tpgBillExcludedLabTests)
        ResetControlsIn(Me.tpgBillExcludedRadiology)
        ResetControlsIn(Me.tpgBillExcludedProcedures)
        ResetControlsIn(Me.tpgAssociatedBillCustomers)
        ResetControlsIn(Me.tpgBillExcludedExtraChargeItems)
        ResetControlsIn(Me.tpgBillExcludedOpticalservices)
        ResetControlsIn(Me.tpgBillExcludedPathology)
        ResetControlsIn(Me.tpgBillExcludedDentalServices)
        ResetControlsIn(Me.pnlCoPayTypeID)
        ResetControlsIn(Me.pnlStatusID)

        Me.ResetCoPayControls()
        Me.EnableStateControls(False)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.btnSearch.Visible = False

        Me.cboAccountNo.Enabled = Not InitOptions.AccountNoLocked
        Me.cboAccountNo.MaxLength = 20
        Me.LoadBillCustomers(False)
        Me.chkHidden.Enabled = False

        Me.pnlStatusID.Enabled = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgBillExcludedServices)
        ResetControlsIn(Me.tpgBillExcludedDrugs)
        ResetControlsIn(Me.tpgBillExcludedLabTests)
        ResetControlsIn(Me.tpgBillExcludedRadiology)
        ResetControlsIn(Me.tpgBillExcludedProcedures)
        ResetControlsIn(Me.tpgAssociatedBillCustomers)
        ResetControlsIn(Me.tpgBillExcludedExtraChargeItems)
        ResetControlsIn(Me.tpgBillExcludedOpticalservices)
        ResetControlsIn(Me.tpgBillExcludedPathology)
        ResetControlsIn(Me.tpgBillExcludedDentalServices)

        Me.SetNextAccountNo()
        Me.SetCoPayDefault()
        Me.ResetCoPayControls()
        Me.EnableStateControls(True)
        Me.AccountStatus()

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