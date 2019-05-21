
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports System.Collections.Generic

Public Class frmClaims

#Region " Fields "
    Private diseases As DataTable
    Private _DiagnosisValue As String = String.Empty
    Private _ItemNameValue As String = String.Empty
#End Region

#Region " Validations "

    Private Sub dtpVisitDate_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles dtpVisitDate.Validating

        Dim errorMSG As String = "Visit date can't be before join date!"

        Try

            Dim joinDate As Date = DateMayBeEnteredIn(Me.stbJoinDate)
            Dim visitDate As Date = DateMayBeEnteredIn(Me.dtpVisitDate)

            If visitDate = AppData.NullDateValue Then Return

            If visitDate < joinDate Then
                ErrProvider.SetError(Me.dtpVisitDate, errorMSG)
                Me.dtpVisitDate.Focus()
                e.Cancel = True
            Else : ErrProvider.SetError(Me.dtpVisitDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmClaims_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Me.Cursor = Cursors.WaitCursor()
            Me.dtpVisitDate.MaxDate = Today
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadLookupDataCombo(Me.cboClaimStatusID, LookupObjects.ClaimStatus, False)
            LoadLookupDataCombo(Me.cboClaimEntryID, LookupObjects.EntryMode, True)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadHealthUnits()
            Me.LoadDiseases()
            Me.LoadMemberBenefits()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmClaims_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbClaimNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbClaimNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub SetDefaultEntryMode()

        Try

            Dim oEntryModeID As New LookupDataID.EntryModeID()
            Me.cboClaimEntryID.SelectedValue = oEntryModeID.Manual

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub SetNextClaimNo(ByVal medicalCardNo As String)

        Try

            Me.stbClaimNo.Text = FormatText(GetNextClaimNo(medicalCardNo), "Claims", "ClaimNo")

        Catch ex As Exception
            Return
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

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbAge.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbMemberType.Clear()
        Me.stbMainMemberName.Clear()
        Me.stbCompanyName.Clear()
        Me.stbInsuranceName.Clear()
        Me.stbPolicyName.Clear()
        Me.stbPolicyStartDate.Clear()
        Me.stbPolicyEndDate.Clear()

    End Sub

    Private Sub stbMedicalCardNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbMedicalCardNo.Leave
        Me.ShowSchemeMembersDetails()
    End Sub

    Private Sub ShowSchemeMembersDetails()

        Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()

        Try
            Me.Cursor = Cursors.WaitCursor

            Dim medicalCardNo As String = RevertText(StringMayBeEnteredIn(Me.stbMedicalCardNo))
            If String.IsNullOrEmpty(medicalCardNo) Then Return

            Me.ClearControls()

            Dim row As DataRow = oSchemeMembers.GetSchemeMembers(medicalCardNo).Tables("SchemeMembers").Rows(0)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbMedicalCardNo.Text = FormatText(medicalCardNo, "SchemeMembers", "MedicalCardNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbMemberType.Text = StringEnteredIn(row, "MemberType")
            Me.stbMainMemberName.Text = StringMayBeEnteredIn(row, "MainMemberName")
            Me.stbCompanyName.Text = StringEnteredIn(row, "CompanyName")
            Me.stbInsuranceName.Text = StringEnteredIn(row, "InsuranceName")
            Me.stbPolicyName.Text = StringEnteredIn(row, "PolicyName")
            Me.stbPolicyStartDate.Text = FormatDate(DateEnteredIn(row, "PolicyStartDate"))
            Me.stbPolicyEndDate.Text = FormatDate(DateEnteredIn(row, "PolicyEndDate"))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetNextClaimNo(medicalCardNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            Me.ClearControls()
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbMedicalCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbMedicalCardNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub btnFindClaimNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindClaimNo.Click
        Dim fFindClaimNo As New frmFindAutoNo(Me.stbClaimNo, AutoNumber.ClaimNo)
        fFindClaimNo.ShowDialog(Me)
        Me.stbClaimNo.Focus()
    End Sub

    Private Sub LoadHealthUnits()

        Dim oHealthUnits As New SyncSoft.SQLDb.HealthUnits()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from HealthUnits
            Dim healthUnits As DataTable = oHealthUnits.GetHealthUnits().Tables("HealthUnits")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.cboHealthUnitCode.Sorted = False
            LoadComboData(Me.cboHealthUnitCode, healthUnits, "HealthUnitCode", "HealthUnitName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDiseases()

        Dim oDiseases As New SyncSoft.SQLDb.Diseases()
        Dim oSetupData As New SetupData()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Diseases
            If Not InitOptions.LoadDiseasesAtStart Then
                diseases = oDiseases.GetDiseases().Tables("Diseases")
                oSetupData.Diseases = diseases
            Else : diseases = oSetupData.Diseases
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.colDiseaseCode.Sorted = False
            LoadComboData(Me.colDiseaseCode, diseases, "DiseaseCode", "DiseaseName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadClaimsData(ByVal claimNo As String)

        Dim oClaims As New SyncSoft.SQLDb.Claims()

        Try
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim claims As DataTable = oClaims.GetClaims(claimNo).Tables("Claims")
            Me.DisplayData(claims)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadClaimDiagnosis(claimNo)
            Me.LoadClaimDetails(claimNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oClaims As New SyncSoft.SQLDb.Claims()

        Try
            Me.Cursor = Cursors.WaitCursor()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oClaims.ClaimNo = RevertText(StringEnteredIn(Me.stbClaimNo, "Claim No!"))
            DisplayMessage(oClaims.Delete())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.tpgClaimDiagnosis)
            ResetControlsIn(Me.tpgClaimDetails)
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

            Dim claimNo As String = RevertText(StringEnteredIn(Me.stbClaimNo, "Claim No!"))
            Me.LoadClaimsData(claimNo)
            ResetControlsIn(Me.pnlNavigateClaims)

        Catch ex As Exception
            ErrorMessage(ex)
            ResetControlsIn(Me.pnlNavigateClaims)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim oClaims As New SyncSoft.SQLDb.Claims()
            Dim lClaims As New List(Of DBConnect)

            With oClaims

                .MedicalCardNo = RevertText(StringEnteredIn(Me.stbMedicalCardNo, "Medical Card No!"))
                .ClaimNo = RevertText(StringEnteredIn(Me.stbClaimNo, "Claim No!"))
                .PatientNo = StringMayBeEnteredIn(Me.stbPatientNo)
                .VisitDate = DateEnteredIn(Me.dtpVisitDate, "Visit Date!")
                .VisitTime = TimeMayBeEnteredIn(Me.stpVisitTime)
                .HealthUnitCode = StringValueEnteredIn(Me.cboHealthUnitCode, "Health Unit Code!")
                .PrimaryDoctor = StringEnteredIn(Me.stbPrimaryDoctor, "Primary Doctor!")
                .ClaimStatusID = StringValueEnteredIn(Me.cboClaimStatusID, "Claim Status!")
                .ClaimEntryID = StringValueEnteredIn(Me.cboClaimEntryID, "Claim Entry!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lClaims.Add(oClaims)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    Dim message As String

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If oClaims.IsClaimDateSaved(oClaims.MedicalCardNo, oClaims.VisitDate) Then
                        message = "You already have a claim on " + FormatDate(oClaims.VisitDate) +
                                                          ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                    End If

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lClaims, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(Me.ClaimDiagnosisList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(Me.ClaimDetailsList, Action.Save))

                    records = DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgClaimDiagnosis)
                    ResetControlsIn(Me.tpgClaimDetails)

                    Me.SetDefaultEntryMode()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lClaims, Action.Update, "Claims"))
                    transactions.Add(New TransactionList(Of DBConnect)(ClaimDiagnosisList, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ClaimDetailsList, Action.Save))

                    records = DoTransactions(transactions)

                    DisplayMessage(records.ToString() + " record(s) updated!")
                    Me.CallOnKeyEdit()

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 2
                Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, rowNo).Value = True
            Next

            For rowNo As Integer = 0 To Me.dgvClaimDetails.RowCount - 2
                Me.dgvClaimDetails.Item(Me.colClaimDetailsSaved.Name, rowNo).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function ClaimDiagnosisList() As List(Of DBConnect)

        Dim lClaimDiagnosis As New List(Of DBConnect)

        Try

            Dim claimNo As String = RevertText(StringEnteredIn(Me.stbClaimNo, "claim No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvDiagnosis.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one Diagnosis!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 2

                Using oClaimDiagnosis As New SyncSoft.SQLDb.ClaimDiagnosis()

                    Dim cells As DataGridViewCellCollection = Me.dgvDiagnosis.Rows(rowNo).Cells

                    With oClaimDiagnosis

                        .ClaimNo = claimNo
                        .DiseaseCode = StringEnteredIn(cells, Me.colDiseaseCode, "Disease Code!")

                    End With

                    lClaimDiagnosis.Add(oClaimDiagnosis)

                End Using

            Next

            Return lClaimDiagnosis

        Catch ex As Exception
            Me.tbcClaims.SelectTab(Me.tpgClaimDiagnosis)
            Throw ex

        End Try

    End Function

    Private Function ClaimDetailsList() As List(Of DBConnect)

        Dim lClaimDetails As New List(Of DBConnect)

        Try

            Dim claimNo As String = RevertText(StringEnteredIn(Me.stbClaimNo, "claim No!"))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvClaimDetails.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one Service!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvClaimDetails.RowCount - 2

                Using oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

                    Dim cells As DataGridViewCellCollection = Me.dgvClaimDetails.Rows(rowNo).Cells

                    With oClaimDetails

                        .ClaimNo = claimNo
                        .ItemName = StringEnteredIn(cells, Me.colItemName, "Item Name!")
                        .BenefitCode = StringEnteredIn(cells, Me.colBenefitCode, "Benefit Name!")
                        .Quantity = IntegerEnteredIn(cells, Me.colQuantity, "Quantity!")
                        .UnitPrice = DecimalEnteredIn(cells, Me.colUnitPrice, False, "Unit Price!")
                        .Adjustment = DecimalEnteredIn(cells, Me.colAdjustment, False, "Adjustment!")
                        .Amount = DecimalEnteredIn(cells, Me.colAmount, False, "Amount!")
                        .Notes = StringMayBeEnteredIn(cells, Me.colNotes)
                        .LimitAmount = DecimalEnteredIn(cells, Me.colLimitAmount, True, "Limit Amount!")
                        .ConsumedAmount = DecimalEnteredIn(cells, Me.colConsumedAmount, True, "Consumed Amount!")
                        .LimitBalance = DecimalEnteredIn(cells, Me.colLimitBalance, True, "Limit Balance!")

                    End With

                    lClaimDetails.Add(oClaimDetails)

                End Using

            Next

            Return lClaimDetails

        Catch ex As Exception
            Me.tbcClaims.SelectTab(Me.tpgClaimDetails)
            Throw ex

        End Try

    End Function

#Region " Diagnosis - Grid "

    Private Sub dgvDiagnosis_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvDiagnosis.CellBeginEdit

        If e.ColumnIndex <> Me.colDiseaseCode.Index OrElse Me.dgvDiagnosis.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvDiagnosis.CurrentCell.RowIndex
        _DiagnosisValue = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

    End Sub

    Private Sub dgvDiagnosis_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDiagnosis.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvDiagnosis.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colDiseaseCode.Index) Then
                ' Ensure unique entry in the combo column
                If Me.dgvDiagnosis.Rows.Count > 1 Then Me.SetDiagnosisEntries(selectedRow)
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub SetDiagnosisEntries(ByVal selectedRow As Integer)

        Try

            Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(selectedRow).Cells, Me.colDiseaseCode)

            If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, selectedRow).Value).Equals(True) Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                Dim diagnosisDisplay As String = (From data In diagnosis
                                    Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(_DiagnosisValue.ToUpper())
                                    Select data.Field(Of String)("DiseaseName")).First()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                DisplayMessage("Diagnosis (" + diagnosisDisplay + ") can't be edited!")
                Me.dgvDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Value = _DiagnosisValue
                Me.dgvDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Selected = True
                Return
            End If

            For rowNo As Integer = 0 To Me.dgvDiagnosis.RowCount - 2

                If Not rowNo.Equals(selectedRow) Then
                    Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvDiagnosis.Rows(rowNo).Cells, Me.colDiseaseCode)
                    If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        Dim diagnosis As EnumerableRowCollection(Of DataRow) = diseases.AsEnumerable()
                        Dim enteredDisplay As String = (From data In diagnosis
                                            Where data.Field(Of String)("DiseaseCode").ToUpper().Equals(enteredItem.ToUpper())
                                            Select data.Field(Of String)("DiseaseName")).First()
                        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                        DisplayMessage("Diagnosis (" + enteredDisplay + ") already entered!")
                        Me.dgvDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Value = _DiagnosisValue
                        Me.dgvDiagnosis.Item(Me.colDiseaseCode.Name, selectedRow).Selected = True
                        Return
                    End If
                End If

            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            '''''''''''''' Populate other columns based upon what is entered in combo column '''''''''''''''''''''''''''''''''
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If diseases Is Nothing OrElse String.IsNullOrEmpty(selectedItem) Then Return

            For Each row As DataRow In diseases.Select("DiseaseCode = '" + selectedItem + "'")
                Me.dgvDiagnosis.Item(Me.colDiseaseCategory.Name, selectedRow).Value = StringEnteredIn(row, "DiseaseCategories")
            Next
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvDiagnosis_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvDiagnosis.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oClaimDiagnosis As New SyncSoft.SQLDb.ClaimDiagnosis()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvDiagnosis.Item(Me.colDiagnosisSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim claimNo As String = RevertText(StringEnteredIn(Me.stbClaimNo, "Claim's No!"))
            Dim diagnosis As String = CStr(Me.dgvDiagnosis.Item(Me.colDiseaseCode.Name, toDeleteRowNo).Value)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Security.Apply(Me.fbnDelete, AccessRights.Delete)
            If Me.fbnDelete.Enabled = False Then
                DisplayMessage("You do not have permission to delete this record!")
                e.Cancel = True
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oClaimDiagnosis
                .ClaimNo = claimNo
                .DiseaseCode = diagnosis
                DisplayMessage(.Delete())
            End With
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvDiagnosis_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvDiagnosis.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadClaimDiagnosis(ByVal claimNo As String)

        Dim oClaimDiagnosis As New SyncSoft.SQLDb.ClaimDiagnosis()

        Try

            Me.dgvDiagnosis.Rows.Clear()

            ' Load items not yet paid for

            Dim claimDiagnosis As DataTable = oClaimDiagnosis.GetClaimDiagnosis(claimNo).Tables("ClaimDiagnosis")
            If claimDiagnosis Is Nothing OrElse claimDiagnosis.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For pos As Integer = 0 To claimDiagnosis.Rows.Count - 1

                Dim row As DataRow = claimDiagnosis.Rows(pos)

                With Me.dgvDiagnosis
                    ' Ensure that you add a new row
                    .Rows.Add()
                    .Item(Me.colDiseaseCode.Name, pos).Value = StringEnteredIn(row, "DiseaseCode")
                    .Item(Me.colDiseaseCategory.Name, pos).Value = StringMayBeEnteredIn(row, "DiseaseCategories")
                    .Item(Me.colDiagnosisSaved.Name, pos).Value = True
                End With
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Claim Details - Grid "

    Private Sub dgvClaimDetails_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvClaimDetails.CellBeginEdit

        If e.ColumnIndex <> Me.colItemName.Index OrElse Me.dgvClaimDetails.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvClaimDetails.CurrentCell.RowIndex
        _ItemNameValue = StringMayBeEnteredIn(Me.dgvClaimDetails.Rows(selectedRow).Cells, Me.colItemName)

    End Sub

    Private Sub dgvClaimDetails_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClaimDetails.CellEndEdit

        Try

            Dim selectedRow As Integer = Me.dgvClaimDetails.CurrentCell.RowIndex

            If e.ColumnIndex.Equals(Me.colItemName.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvClaimDetails.Rows.Count > 1 Then

                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvClaimDetails.Rows(selectedRow).Cells, Me.colItemName)

                    If CBool(Me.dgvClaimDetails.Item(Me.colClaimDetailsSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Item Name (" + _ItemNameValue + ") can't be edited!")
                        Me.dgvClaimDetails.Item(Me.colItemName.Name, selectedRow).Value = _ItemNameValue
                        Me.dgvClaimDetails.Item(Me.colItemName.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvClaimDetails.RowCount - 2
                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvClaimDetails.Rows(rowNo).Cells, Me.colItemName)
                            If enteredItem.Equals(selectedItem) Then
                                DisplayMessage("Item Name (" + enteredItem + ") already selected!")
                                Me.dgvClaimDetails.Item(Me.colItemName.Name, selectedRow).Value = _ItemNameValue
                                Me.dgvClaimDetails.Item(Me.colItemName.Name, selectedRow).Selected = True
                            End If
                        End If
                    Next

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ' Populate other columns based upon what is entered in key column
                    Me.CalculateAmount(selectedRow)
                    Me.CalculateTotalAmount()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                End If

            ElseIf e.ColumnIndex.Equals(Me.colBenefitCode.Index) Then
                Me.DetailPolicyLimits(selectedRow)

            ElseIf e.ColumnIndex.Equals(Me.colQuantity.Index) Then
                Me.CalculateAmount(selectedRow)
                Me.CalculateTotalAmount()

            ElseIf e.ColumnIndex.Equals(Me.colUnitPrice.Index) Then
                Me.CalculateAmount(selectedRow)
                Me.CalculateTotalAmount()

            ElseIf e.ColumnIndex.Equals(Me.colAdjustment.Index) Then
                Me.CalculateAmount(selectedRow)
                Me.CalculateTotalAmount()
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub dgvClaimDetails_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvClaimDetails.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvClaimDetails.Item(Me.colClaimDetailsSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim claimNo As String = RevertText(StringEnteredIn(Me.stbClaimNo, "Claim's No!"))
            Dim itemName As String = CStr(Me.dgvClaimDetails.Item(Me.colItemName.Name, toDeleteRowNo).Value)

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
            With oClaimDetails
                .ClaimNo = claimNo
                .ItemName = itemName
            End With

            DisplayMessage(oClaimDetails.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvClaimDetails_UserAddedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvClaimDetails.UserAddedRow
        Me.dgvClaimDetails.Item(Me.colQuantity.Name, e.Row.Index - 1).Value = 1
        Me.dgvClaimDetails.Item(Me.colAdjustment.Name, e.Row.Index - 1).Value = 0
    End Sub

    Private Sub dgvClaimDetails_UserDeletedRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvClaimDetails.UserDeletedRow
        Me.CalculateTotalAmount()
    End Sub

    Private Sub dgvClaimDetails_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvClaimDetails.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateTotalAmount()

        Dim totalAmount As Decimal

        For rowNo As Integer = 0 To Me.dgvClaimDetails.RowCount - 1

            If IsNumeric(Me.dgvClaimDetails.Item(Me.colAmount.Name, rowNo).Value) Then
                totalAmount += CDec(Me.dgvClaimDetails.Item(Me.colAmount.Name, rowNo).Value)
            Else : totalAmount += 0
            End If
        Next

        Me.stbTotalAmount.Text = FormatNumber(totalAmount, AppData.DecimalPlaces)
        Me.stbAmountWords.Text = NumberToWords(totalAmount)

    End Sub

    Private Sub CalculateAmount(ByVal selectedRow As Integer)

        Dim cells As DataGridViewCellCollection = Me.dgvClaimDetails.Rows(selectedRow).Cells

        Dim quantity As Single = SingleMayBeEnteredIn(cells, Me.colQuantity)
        Dim unitPrice As Decimal = DecimalMayBeEnteredIn(cells, Me.colUnitPrice)
        Dim adjustment As Decimal = DecimalMayBeEnteredIn(cells, Me.colAdjustment)

        Dim amount As Decimal = (CDec(quantity) * unitPrice) - adjustment

        Me.dgvClaimDetails.Item(Me.colAmount.Name, selectedRow).Value = FormatNumber(amount, AppData.DecimalPlaces)

    End Sub

    Private Sub DetailPolicyLimits(ByVal selectedRow As Integer)

        Dim limitBalance As Decimal
        Dim styleLimit As New DataGridViewCellStyle()
        Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)

        Dim medicalCardNo As String = RevertText(StringEnteredIn(Me.stbMedicalCardNo, "Medical Card No!"))
        Dim cells As DataGridViewCellCollection = Me.dgvClaimDetails.Rows(selectedRow).Cells

        Dim benefitCode As String = StringMayBeEnteredIn(cells, Me.colBenefitCode)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        styleLimit.BackColor = Color.MistyRose
        styleLimit.Font = font

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim limitAmount As Decimal = GetPolicyLimit(medicalCardNo, benefitCode)
        Dim consumedAmount As Decimal = GetPolicyConsumedAmount(medicalCardNo, benefitCode)
        If limitAmount > 0 Then
            limitBalance = limitAmount - consumedAmount
        Else : limitBalance = 0
        End If

        Me.dgvClaimDetails.Item(Me.colLimitAmount.Name, selectedRow).Value = FormatNumber(limitAmount, AppData.DecimalPlaces)
        Me.dgvClaimDetails.Item(Me.colConsumedAmount.Name, selectedRow).Value = FormatNumber(consumedAmount, AppData.DecimalPlaces)
        Me.dgvClaimDetails.Item(Me.colLimitBalance.Name, selectedRow).Value = FormatNumber(limitBalance, AppData.DecimalPlaces)

        If limitBalance < 0 Then
            DisplayMessage("Scheme member with Medical Card No: " + medicalCardNo + ", has consumed beyond allowed limit!")
            Me.dgvClaimDetails.Rows(selectedRow).Cells(Me.colLimitBalance.Name).Style.ApplyStyle(styleLimit)
        End If

    End Sub

    Private Sub LoadClaimDetails(ByVal claimNo As String)

        Dim styleLimit As New DataGridViewCellStyle()
        Dim font As New Font("Microsoft Sans Serif", 9, FontStyle.Bold)
        Dim oClaimDetails As New SyncSoft.SQLDb.ClaimDetails()

        Try

            Me.dgvClaimDetails.Rows.Clear()

            ' Load ClaimDetails

            Dim claimDetails As DataTable = oClaimDetails.GetClaimDetails(claimNo).Tables("ClaimDetails")

            If claimDetails Is Nothing OrElse claimDetails.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            styleLimit.BackColor = Color.MistyRose
            styleLimit.Font = font

            For pos As Integer = 0 To claimDetails.Rows.Count - 1

                Dim row As DataRow = claimDetails.Rows(pos)

                With Me.dgvClaimDetails
                    ' Ensure that you add a new row
                    .Rows.Add()

                    .Item(Me.colItemName.Name, pos).Value = StringEnteredIn(row, "ItemName")
                    .Item(Me.colBenefitCode.Name, pos).Value = StringMayBeEnteredIn(row, "BenefitCode")
                    .Item(Me.colQuantity.Name, pos).Value = IntegerEnteredIn(row, "Quantity")
                    .Item(Me.colUnitPrice.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "UnitPrice", True), AppData.DecimalPlaces)
                    .Item(Me.colAdjustment.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "Adjustment", True), AppData.DecimalPlaces)
                    .Item(Me.colAmount.Name, pos).Value = FormatNumber(DecimalEnteredIn(row, "Amount", True))
                    .Item(Me.colNotes.Name, pos).Value = StringMayBeEnteredIn(row, "Notes")
                    .Item(Me.colLimitAmount.Name, pos).Value = FormatNumber(DecimalMayBeEnteredIn(row, "LimitAmount", True), AppData.DecimalPlaces)
                    .Item(Me.colConsumedAmount.Name, pos).Value = FormatNumber(DecimalMayBeEnteredIn(row, "ConsumedAmount", True), AppData.DecimalPlaces)
                    Dim limitBalance As Decimal = DecimalMayBeEnteredIn(row, "LimitBalance", True)
                    .Item(Me.colLimitBalance.Name, pos).Value = FormatNumber(limitBalance, AppData.DecimalPlaces)
                    .Item(Me.colClaimDetailsSaved.Name, pos).Value = True

                    If limitBalance < 0 Then Me.dgvClaimDetails.Rows(pos).Cells(Me.colLimitBalance.Name).Style.ApplyStyle(styleLimit)

                End With

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateTotalAmount()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

#Region " Claims Navigate "

    Private Sub EnableNavigateClaimsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim claims As DataTable
        Dim oClaims As New SyncSoft.SQLDb.Claims()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim claimNo As String = RevertText(StringEnteredIn(Me.stbClaimNo, "Claim No!"))
                Dim medicalCardNo As String = RevertText(StringEnteredIn(Me.stbMedicalCardNo, "Medical Card No!"))

                claims = oClaims.GetClaimsByMedicalCardNo(medicalCardNo).Tables("Claims")

                For pos As Integer = 0 To claims.Rows.Count - 1
                    If claimNo.ToUpper().Equals(claims.Rows(pos).Item("ClaimNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navClaims.DataSource = claims
                Me.navClaims.Navigate(startPosition)

            Else : Me.navClaims.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateClaims.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateClaims_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateClaims.Click
        Me.EnableNavigateClaimsCTLS(Me.chkNavigateClaims.Checked)
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navClaims.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim claimNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(claimNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbClaimNo.Text = FormatText(claimNo, "Claims", "ClaimNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadClaimsData(claimNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Popup Menu "

    Private Sub cmsClaims_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsClaims.Opening

        Select Case Me.tbcClaims.SelectedTab.Name

            Case Me.tpgClaimDiagnosis.Name
                Me.cmsClaimsQuickSearch.Visible = True

            Case Else
                Me.cmsClaimsQuickSearch.Visible = False

        End Select

    End Sub

    Private Sub cmsClaimsQuickSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsClaimsQuickSearch.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim rowIndex As Integer

            Select Case Me.tbcClaims.SelectedTab.Name

                Case Me.tpgClaimDiagnosis.Name

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim fQuickSearch As New SyncSoft.SQL.Win.Forms.QuickSearch("Diseases", Me.dgvDiagnosis, Me.colDiseaseCode)
                    fQuickSearch.ShowDialog(Me)

                    rowIndex = Me.dgvDiagnosis.NewRowIndex
                    If rowIndex > 0 Then Me.SetDiagnosisEntries(rowIndex - 1)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

        Me.stbClaimNo.ReadOnly = False
        Me.stbMedicalCardNo.Enabled = False
        Me.btnFindClaimNo.Visible = True
        Me.pnlNavigateClaims.Enabled = True

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgClaimDiagnosis)
        ResetControlsIn(Me.tpgClaimDetails)
        ResetControlsIn(Me.pnlNavigateClaims)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.stbClaimNo.ReadOnly = InitOptions.ClaimNoLocked
        Me.stbMedicalCardNo.Enabled = True
        Me.btnFindClaimNo.Visible = False
        Me.pnlNavigateClaims.Enabled = False

        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgClaimDiagnosis)
        ResetControlsIn(Me.tpgClaimDetails)
        ResetControlsIn(Me.pnlNavigateClaims)

        Me.SetDefaultEntryMode()

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