
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports System.Collections.Generic
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID

Public Class frmInsurances

#Region " Fields "

    Private services As DataTable
    Private drugs As DataTable
    Private labTests As DataTable
    Private radiologyExaminations As DataTable
    Private procedures As DataTable

    Private _ServiceNameValue As String = String.Empty
    Private _DrugNameValue As String = String.Empty
    Private _TestNameValue As String = String.Empty
    Private _RadiologyNameValue As String = String.Empty
    Private _ProcedureNameValue As String = String.Empty

#End Region

    Private Sub frmInsurances_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
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

    Private Sub stbInsuranceNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbInsuranceNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub btnLoadLogoPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadLogoPhoto.Click
        Me.spbLogoPhoto.LoadPhoto(Me.spbLogoPhoto.ImageSizeLimit)
    End Sub

    Private Sub btnClearLogoPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLogoPhoto.Click
        Me.spbLogoPhoto.DeletePhoto()
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

    Private Sub SetNextInsuranceNo()

        Dim yearL2 As String = Today.Year.ToString().Substring(2)

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim oInsurances As New SyncSoft.SQLDb.Insurances()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("Insurances", "InsuranceNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim nextInsuranceNo As String = CStr(oInsurances.GetNextInsuranceID).PadLeft(paddingLEN, paddingCHAR)
            Me.cboInsuranceNo.Text = FormatText(("I" + yearL2 + nextInsuranceNo).Trim(), "Insurances", "InsuranceNo")

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oInsurances.InsuranceNo = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))
            DisplayMessage(oInsurances.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.tpgInsuranceExcludedServices)
            ResetControlsIn(Me.tpgInsuranceExcludedDrugs)
            ResetControlsIn(Me.tpgInsuranceExcludedLabTests)
            ResetControlsIn(Me.tpgInsuranceExcludedRadiology)
            ResetControlsIn(Me.tpgInsuranceExcludedProcedures)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim insuranceNo As String = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))
            Dim dataSource As DataTable = oInsurances.GetInsurances(insuranceNo).Tables("Insurances")
            Me.DisplayData(dataSource)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadInsuranceExcludedServices(insuranceNo)
            Me.LoadInsuranceExcludedDrugs(insuranceNo)
            Me.LoadInsuranceExcludedLabTests(insuranceNo)
            Me.LoadInsuranceExcludedRadiology(insuranceNo)
            Me.LoadInsuranceExcludedProcedures(insuranceNo)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim oInsurances As New SyncSoft.SQLDb.Insurances()
            Dim lInsurances As New List(Of DBConnect)

            With oInsurances

                .InsuranceNo = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))
                .InsuranceName = StringEnteredIn(Me.stbInsuranceName, "Insurance Name!")
                .ContactPerson = StringMayBeEnteredIn(Me.stbContactPerson)
                .Address = StringMayBeEnteredIn(Me.stbAddress)
                .Phone = StringMayBeEnteredIn(Me.stbPhone)
                .Fax = StringMayBeEnteredIn(Me.stbFax)
                .Email = StringMayBeEnteredIn(Me.stbEmail)
                .Website = StringMayBeEnteredIn(Me.stbWebsite)
                .LogoPhoto = BytesMayBeEnteredIn(Me.spbLogoPhoto)
                .MemberDeclaration = StringEnteredIn(Me.stbMemberDeclaration, "Member Declaration!")
                .DoctorDeclaration = StringEnteredIn(Me.stbDoctorDeclaration, "Doctor Declaration!")
                .UseCustomFee = Me.chkUseCustomFee.Checked
                .Hidden = Me.chkHidden.Checked

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lInsurances.Add(oInsurances)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInsurances, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedServicesList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedDrugsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedLabTestsList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedRadiologyList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(InsuranceExcludedProceduresList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgInsuranceExcludedServices)
                    ResetControlsIn(Me.tpgInsuranceExcludedDrugs)
                    ResetControlsIn(Me.tpgInsuranceExcludedLabTests)
                    ResetControlsIn(Me.tpgInsuranceExcludedRadiology)
                    ResetControlsIn(Me.tpgInsuranceExcludedProcedures)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetNextInsuranceNo()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lInsurances, Action.Update, "Insurances"))
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

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function InsuranceExcludedServicesList() As List(Of DBConnect)

        Dim lInsuranceExcludedServices As New List(Of DBConnect)
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Dim insuranceNo As String = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedServices.RowCount - 2

                Using oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceExcludedServices.Rows(rowNo).Cells

                    With oInsuranceExclusions

                        .InsuranceNo = insuranceNo
                        .ItemCode = StringEnteredIn(cells, Me.colServiceCode, "Service Code!")
                        .ItemCategoryID = oItemCategoryID.Service

                    End With

                    lInsuranceExcludedServices.Add(oInsuranceExclusions)

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

            Dim insuranceNo As String = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedDrugs.RowCount - 2

                Using oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceExcludedDrugs.Rows(rowNo).Cells

                    With oInsuranceExclusions

                        .InsuranceNo = insuranceNo
                        .ItemCode = StringEnteredIn(cells, Me.colDrugNo, "Drug No!")
                        .ItemCategoryID = oItemCategoryID.Drug

                    End With

                    lInsuranceExcludedDrugs.Add(oInsuranceExclusions)

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

            Dim insuranceNo As String = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedLabTests.RowCount - 2

                Using oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceExcludedLabTests.Rows(rowNo).Cells

                    With oInsuranceExclusions

                        .InsuranceNo = insuranceNo
                        .ItemCode = StringEnteredIn(cells, Me.colTestCode, "Test Code!")
                        .ItemCategoryID = oItemCategoryID.Test

                    End With

                    lInsuranceExcludedLabTests.Add(oInsuranceExclusions)

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

            Dim insuranceNo As String = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedRadiology.RowCount - 2

                Using oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceExcludedRadiology.Rows(rowNo).Cells

                    With oInsuranceExclusions

                        .InsuranceNo = insuranceNo
                        .ItemCode = StringEnteredIn(cells, Me.colExamCode, "Exam Code!")
                        .ItemCategoryID = oItemCategoryID.Radiology

                    End With

                    lInsuranceExcludedRadiology.Add(oInsuranceExclusions)

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

            Dim insuranceNo As String = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))

            For rowNo As Integer = 0 To Me.dgvInsuranceExcludedProcedures.RowCount - 2

                Using oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()

                    Dim cells As DataGridViewCellCollection = Me.dgvInsuranceExcludedProcedures.Rows(rowNo).Cells

                    With oInsuranceExclusions

                        .InsuranceNo = insuranceNo
                        .ItemCode = StringEnteredIn(cells, Me.colProcedureCode, "Procedure Code!")
                        .ItemCategoryID = oItemCategoryID.Procedure

                    End With

                    lInsuranceExcludedProcedures.Add(oInsuranceExclusions)

                End Using

            Next

            Return lInsuranceExcludedProcedures

        Catch ex As Exception
            Throw ex

        End Try

    End Function

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
            Dim oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceExcludedServices.Item(Me.colInsuranceExcludedServicesSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim insuranceNo As String = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))
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
            With oInsuranceExclusions
                .InsuranceNo = insuranceNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Service
            End With

            DisplayMessage(oInsuranceExclusions.Delete())

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

    Private Sub LoadInsuranceExcludedServices(ByVal insuranceNo As String)

        Dim insuranceExcludedServices As DataTable
        Dim oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvInsuranceExcludedServices.Rows.Clear()

            ' Load items not yet paid for

            insuranceExcludedServices = oInsuranceExclusions.GetInsuranceExclusions(insuranceNo, oItemCategoryID.Service).Tables("InsuranceExclusions")

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
            Dim oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceExcludedDrugs.Item(Me.colInsuranceExcludedDrugsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim insuranceNo As String = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))
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
            With oInsuranceExclusions
                .InsuranceNo = insuranceNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Drug
            End With

            DisplayMessage(oInsuranceExclusions.Delete())

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

    Private Sub LoadInsuranceExcludedDrugs(ByVal insuranceNo As String)

        Dim insuranceExcludedDrugs As DataTable
        Dim oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvInsuranceExcludedDrugs.Rows.Clear()

            ' Load items not yet paid for

            insuranceExcludedDrugs = oInsuranceExclusions.GetInsuranceExclusions(insuranceNo, oItemCategoryID.Drug).Tables("InsuranceExclusions")

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
                        Dim testDisplay As String = (From data In _LabTests
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
            Dim oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceExcludedLabTests.Item(Me.colInsuranceExcludedLabTestsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim insuranceNo As String = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))
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
            With oInsuranceExclusions
                .InsuranceNo = insuranceNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Test
            End With

            DisplayMessage(oInsuranceExclusions.Delete())

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

    Private Sub LoadInsuranceExcludedLabTests(ByVal insuranceNo As String)

        Dim insuranceExcludedLabTests As DataTable
        Dim oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvInsuranceExcludedLabTests.Rows.Clear()

            ' Load items not yet paid for

            insuranceExcludedLabTests = oInsuranceExclusions.GetInsuranceExclusions(insuranceNo, oItemCategoryID.Test).Tables("InsuranceExclusions")

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
            Dim oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceExcludedRadiology.Item(Me.colInsuranceExcludedRadiologySaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim insuranceNo As String = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))
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
            With oInsuranceExclusions
                .InsuranceNo = insuranceNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Radiology
            End With

            DisplayMessage(oInsuranceExclusions.Delete())

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

    Private Sub LoadInsuranceExcludedRadiology(ByVal insuranceNo As String)

        Dim insuranceExcludedRadiology As DataTable
        Dim oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvInsuranceExcludedRadiology.Rows.Clear()

            ' Load items not yet paid for

            insuranceExcludedRadiology = oInsuranceExclusions.GetInsuranceExclusions(insuranceNo, oItemCategoryID.Radiology).Tables("InsuranceExclusions")

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
            Dim oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvInsuranceExcludedProcedures.Item(Me.colInsuranceExcludedProceduresSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim insuranceNo As String = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))
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
            With oInsuranceExclusions
                .InsuranceNo = insuranceNo
                .ItemCode = itemCode
                .ItemCategoryID = oItemCategoryID.Procedure
            End With

            DisplayMessage(oInsuranceExclusions.Delete())

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

    Private Sub LoadInsuranceExcludedProcedures(ByVal insuranceNo As String)

        Dim insuranceExcludedProcedures As DataTable
        Dim oInsuranceExclusions As New SyncSoft.SQLDb.InsuranceExclusions()
        Dim oItemCategoryID As New LookupDataID.ItemCategoryID()

        Try

            Me.dgvInsuranceExcludedProcedures.Rows.Clear()

            ' Load items not yet paid for

            insuranceExcludedProcedures = oInsuranceExclusions.GetInsuranceExclusions(insuranceNo, oItemCategoryID.Procedure).Tables("InsuranceExclusions")

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
        LoadInsurances()
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.cboInsuranceNo.Enabled = True
        Me.chkHidden.Enabled = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgInsuranceExcludedServices)
        ResetControlsIn(Me.tpgInsuranceExcludedDrugs)
        ResetControlsIn(Me.tpgInsuranceExcludedLabTests)
        ResetControlsIn(Me.tpgInsuranceExcludedRadiology)
        ResetControlsIn(Me.tpgInsuranceExcludedProcedures)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.cboInsuranceNo.Enabled = InitOptions.InsuranceNoLocked
        Me.chkHidden.Enabled = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgInsuranceExcludedServices)
        ResetControlsIn(Me.tpgInsuranceExcludedDrugs)
        ResetControlsIn(Me.tpgInsuranceExcludedLabTests)
        ResetControlsIn(Me.tpgInsuranceExcludedRadiology)
        ResetControlsIn(Me.tpgInsuranceExcludedProcedures)

        Me.SetNextInsuranceNo()

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

    Private Sub cboInsuranceNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboInsuranceNo.SelectedIndexChanged

    End Sub

    Private Sub cboInsuranceNo_Leave(sender As Object, e As EventArgs) Handles cboInsuranceNo.Leave
        If ebnSaveUpdate.ButtonText = ButtonCaption.Update Then
            Me.stbInsuranceName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(cboInsuranceNo)))
            Me.cboInsuranceNo.Text = SubstringRight(RevertText(StringMayBeEnteredIn(cboInsuranceNo)))
        End If
    End Sub

    Private Sub LoadInsurances()

        Dim oInsurance As New SyncSoft.SQLDb.Insurances()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim insurance As DataTable = oInsurance.GetInsurances().Tables("Insurances")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboInsuranceNo, insurance, "InsuranceFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


#End Region

End Class