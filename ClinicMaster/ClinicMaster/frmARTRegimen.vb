
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.SQL.Enumerations
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.Win.Controls
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Collections.Generic

Public Class frmARTRegimen

#Region " Fields "
    Private _PrescriptionDrugValue As String = String.Empty
#End Region

#Region " Validations "

#End Region

    Private Sub frmARTRegimen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.LoadDrugCombinations()
        Me.LoadStaff()

        Me.dtpStartDate.MaxDate = Today

        Try
            Me.Cursor = Cursors.WaitCursor

            LoadLookupDataCombo(Me.cboWHOStageID, LookupObjects.WHOStage, False)
            LoadLookupDataCombo(Me.cboDrugLinesID, LookupObjects.DrugLines, True)
            LoadLookupDataCombo(Me.cboARTCategoryID, LookupObjects.ARTCategory, True)
            LoadLookupDataCombo(Me.clbWhyEligible, LookupObjects.WhyEligible, False)
            LoadLookupDataCombo(Me.clbARTSwitchReasons, LookupObjects.ARTSwitchReasons, False)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmARTRegimen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub LoadDrugCombinations()

        Dim oDrugCombinations As New SyncSoft.SQLDb.DrugCombinations()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load from Drug Combinatios
            Dim drugCombinations As DataTable = oDrugCombinations.GetDrugCombinations().Tables("DrugCombinations")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboCombination, drugCombinations, "Combination")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboStaffNo, staff, "StaffFullName")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadDrugCombinationDetails()

        Dim oDrugCombinationDetails As New SyncSoft.SQLDb.DrugCombinationDetails()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.dgvPrescription.Rows.Clear()
            Me.colDrug.Items.Clear()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim combination As String = Me.cboCombination.Text
            If String.IsNullOrEmpty(combination) Then Return

            ' Load from DrugCombinationDetails
            Dim drugCombinationDetails As DataTable = oDrugCombinationDetails.GetDrugCombinationDetails(combination).Tables("DrugCombinationDetails")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.colDrug, drugCombinationDetails, "DrugFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboCombination_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCombination.SelectedIndexChanged
        Me.LoadDrugCombinationDetails()
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.ShowPatientDetails(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicVisits As New frmPeriodicVisits(Me.stbVisitNo)
            fPeriodicVisits.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.ShowPatientDetails(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        Me.CallOnKeyEdit()
        Me.ClearControls()
    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        Me.ShowPatientDetails(visitNo)

    End Sub

    Private Sub ClearControls()

        Me.stbPatientNo.Clear()
        Me.stbFullName.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        Me.stbVisitCategory.Clear()
        Me.stbVisitDate.Clear()

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return
            Dim visits As DataTable = oVisits.GetVisits(visitNo).Tables("Visits")

            Dim row As DataRow = visits.Rows(0)

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(StringEnteredIn(row, "PatientNo"), "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbVisitCategory.Text = StringEnteredIn(row, "VisitCategory")

            Me.stbVisitNo.Text = FormatText(visitNo, "visits", "visitNo")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save Then Me.dtpStartDate.Value = DateEnteredIn(row, "VisitDate")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboARTCategoryID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboARTCategoryID.SelectedIndexChanged

        Dim oARTCategoryID As New LookupDataID.ARTCategoryID()

        If Me.cboARTCategoryID.SelectedValue Is Nothing OrElse String.IsNullOrEmpty(Me.cboARTCategoryID.SelectedValue.ToString()) Then Return
        Dim _ARTCategoryID As String = Me.cboARTCategoryID.SelectedValue.ToString()

        If Not _ARTCategoryID.ToUpper().Equals(oARTCategoryID.Starting.ToUpper()) Then
            For Each checkedIndex As Integer In Me.clbWhyEligible.CheckedIndices
                Me.clbWhyEligible.SetItemCheckState(checkedIndex, CheckState.Unchecked)
            Next
            Me.clbWhyEligible.Enabled = False
        Else : Me.clbWhyEligible.Enabled = True
        End If

        If Not _ARTCategoryID.ToUpper().Equals(oARTCategoryID.Switching.ToUpper()) Then
            For Each checkedIndex As Integer In Me.clbARTSwitchReasons.CheckedIndices
                Me.clbARTSwitchReasons.SetItemCheckState(checkedIndex, CheckState.Unchecked)
            Next
            Me.clbARTSwitchReasons.Enabled = False
        Else : Me.clbARTSwitchReasons.Enabled = True
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim oARTRegimen As New SyncSoft.SQLDb.ARTRegimen()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oARTRegimen.VisitNo = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
            DisplayMessage(oARTRegimen.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim oARTRegimen As New SyncSoft.SQLDb.ARTRegimen()

        Try

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            Me.Cursor = Cursors.WaitCursor

            Dim dataSource As DataTable = oARTRegimen.GetARTRegimen(visitNo).Tables("ARTRegimen")
            Me.DisplayData(dataSource)

            Me.LoadDrugCombinationDetails()
            Me.LoadPrescriptions(visitNo)

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ebnSaveUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ebnSaveUpdate.Click

        Dim records As Integer

        Dim oARTCategoryID As New LookupDataID.ARTCategoryID()
        Dim oARTStatusID As New LookupDataID.ARTStatusID()
        Dim transactions As New List(Of TransactionList(Of DBConnect))

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oARTRegimen As New SyncSoft.SQLDb.ARTRegimen()
            Dim lARTRegimen As New List(Of DBConnect)

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            With oARTRegimen

                .VisitNo = visitNo
                .Combination = StringEnteredIn(Me.cboCombination, "Combination!")
                .StartDate = DateEnteredIn(Me.dtpStartDate, "Start Date!")
                .WHOStageID = StringValueEnteredIn(Me.cboWHOStageID, "WHO Stage!")
                .DrugLinesID = StringValueEnteredIn(Me.cboDrugLinesID, "Drug Line!")
                .StaffNo = SubstringEnteredIn(Me.cboStaffNo, "Staff No!")
                .ARTCategoryID = StringValueEnteredIn(Me.cboARTCategoryID, "ART Category!")

                If .ARTCategoryID.ToUpper().Equals(oARTCategoryID.Starting.ToUpper()) Then
                    .WhyEligible = StringToSplitSelectedInAtleastOne(Me.clbWhyEligible, LookupObjects.WhyEligible, "Why Eligible!")
                Else : .WhyEligible = StringToSplitSelectedIn(Me.clbWhyEligible, LookupObjects.WhyEligible)
                End If

                If .ARTCategoryID.ToUpper().Equals(oARTCategoryID.Switching.ToUpper()) Then
                    .ARTSwitchReasons = StringToSplitSelectedInAtleastOne(Me.clbARTSwitchReasons, LookupObjects.ARTSwitchReasons, "ART Switch Reason(s)")
                Else : .ARTSwitchReasons = StringToSplitSelectedIn(Me.clbARTSwitchReasons, LookupObjects.ARTSwitchReasons)
                End If

                .Notes = StringMayBeEnteredIn(Me.stbNotes)
                .ARTStatusID = oARTStatusID.On
                .RefillDuration = Me.nbxRefillDuration.GetInteger
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lARTRegimen.Add(oARTRegimen)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    Dim message As String = "Start date is before visit date. " + ControlChars.NewLine +
                                            "Are you sure you want to save?"
                    Dim visitDate As Date = DateMayBeEnteredIn(Me.stbVisitDate)

                    If oARTRegimen.StartDate < visitDate Then If WarningMessage(message) = Windows.Forms.DialogResult.No Then Return

                    transactions.Add(New TransactionList(Of DBConnect)(lARTRegimen, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(ARTRegimenDetailsList, Action.Save))

                    records = DoTransactions(transactions)
                    ResetControlsIn(Me)

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lARTRegimen, Action.Update, "ARTRegimen"))
                    transactions.Add(New TransactionList(Of DBConnect)(ARTRegimenDetailsList, Action.Save))

                    records = DoTransactions(transactions)

                    DisplayMessage(records.ToString() + " record(s) updated!")

                    Me.CallOnKeyEdit()

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2
                Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, rowNo).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function ARTRegimenDetailsList() As List(Of DBConnect)

        Dim lARTRegimenDetails As New List(Of DBConnect)

        Try

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPrescription.RowCount <= 1 Then Throw New ArgumentException("Must Register At least one drug!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Using oARTRegimenDetails As New SyncSoft.SQLDb.ARTRegimenDetails()

                    Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells

                    With oARTRegimenDetails

                        .VisitNo = visitNo
                        .DrugNo = SubstringRight(StringEnteredIn(cells, Me.colDrug, "drug!"))
                        .Dosage = StringEnteredIn(cells, Me.colDosage, "dosage!")
                        .Duration = IntegerEnteredIn(cells, Me.colDuration, "duration!")
                        .Quantity = IntegerEnteredIn(cells, Me.colDrugQuantity, "quantity!")
                        .Formula = StringMayBeEnteredIn(cells, Me.colDrugFormula)
                    End With

                    lARTRegimenDetails.Add(oARTRegimenDetails)

                End Using

            Next

            Return lARTRegimenDetails

        Catch ex As Exception
            Throw ex

        End Try

    End Function

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
            Me.CalculateQuantity(selectedRow, True)
            Me.SetRefillDuration()

            ElseIf e.ColumnIndex.Equals(Me.colDuration.Index) Then
            Me.CalculateQuantity(selectedRow, False)
            Me.SetRefillDuration()

            ElseIf e.ColumnIndex.Equals(Me.colDrugQuantity.Index) Then
            'Me.CalculateQuantity(selectedRow,False)

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
            Me.CalculateQuantity(selectedRow, False)
            Me.SetRefillDuration()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub dgvPrescription_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvPrescription.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oARTRegimenDetails As New SyncSoft.SQLDb.ARTRegimenDetails()

            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, toDeleteRowNo).Value).Equals(False) Then Return

            Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit's No!"))
            Dim drugNo As String = SubstringRight(CStr(Me.dgvPrescription.Item(Me.colDrug.Name, toDeleteRowNo).Value))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            If DeleteMessage() = Windows.Forms.DialogResult.No Then
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim message As String = "You do not have permission to delete this record!"
            If Me.btnDelete.Enabled = False Then
                DisplayMessage(message)
                e.Cancel = True
                Return
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            With oARTRegimenDetails
                .VisitNo = visitNo
                .DrugNo = drugNo
            End With

            DisplayMessage(oARTRegimenDetails.Delete())

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
            e.Cancel = True

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPrescriptions(ByVal visitNo As String)

        Dim oARTRegimenDetails As New SyncSoft.SQLDb.ARTRegimenDetails()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load items not yet paid for

            Dim drugs As DataTable = oARTRegimenDetails.GetARTRegimenDetails(RevertText(visitNo)).Tables("ARTRegimenDetails")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPrescription, drugs)

            For Each row As DataGridViewRow In Me.dgvPrescription.Rows
                If row.IsNewRow Then Exit For
                Me.dgvPrescription.Item(Me.colPrescriptionSaved.Name, row.Index).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub dgvPrescription_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvPrescription.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub CalculateQuantity(ByVal selectedRow As Integer, ByVal calculateDuration As Boolean)

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

    Private Sub SetRefillDuration()

        Try

            Dim refillDuration As Integer

            For rowNo As Integer = 0 To Me.dgvPrescription.RowCount - 2

                Dim cells As DataGridViewCellCollection = Me.dgvPrescription.Rows(rowNo).Cells
                Dim temp As Integer = IntegerMayBeEnteredIn(cells, Me.colDuration)

                If refillDuration <= 0 OrElse temp < refillDuration Then refillDuration = temp

            Next

            If refillDuration <= 0 Then Return
            Me.nbxRefillDuration.Value = CStr(refillDuration)

        Catch eX As Exception
            Throw eX

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

        ResetControlsIn(Me)
        ResetControlsIn(Me.pnlDrugLine)
        ResetControlsIn(Me.pnlARTCategory)

        Me.pnlARTCategory.Enabled = False

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.btnDelete.Visible = False
        Me.btnDelete.Enabled = True
        Me.btnSearch.Visible = False

        ResetControlsIn(Me)

        Me.dtpStartDate.Value = Today
        Me.dtpStartDate.Checked = True
        Me.pnlARTCategory.Enabled = True

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

#End Region

End Class