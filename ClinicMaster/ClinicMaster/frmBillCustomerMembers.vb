
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

Public Class frmBillCustomerMembers

#Region " Fields "
    Private billCustomers As DataTable
    Private _ItemCategoryIDValue As String = String.Empty
#End Region

#Region " Validations "

    Private Sub PolicyRangeDate(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) _
                              Handles dtpPolicyStartDate.Validating, dtpPolicyEndDate.Validating

        Try

            Dim policyStartDate As Date = DateMayBeEnteredIn(Me.dtpPolicyStartDate)
            Dim policyEndDate As Date = DateMayBeEnteredIn(Me.dtpPolicyEndDate)

            If policyEndDate = AppData.NullDateValue Then Return

            If policyEndDate < policyStartDate Then
                Dim errorMSG As String = "Policy end date can't be before policy start date!"
                ErrProvider.SetError(Me.dtpPolicyEndDate, errorMSG)
                Me.dtpPolicyEndDate.Focus()
                e.Cancel = True
                Return
            Else : ErrProvider.SetError(Me.dtpPolicyEndDate, String.Empty)
            End If

        Catch ex As Exception
            Return
        End Try

    End Sub

#End Region

    Private Sub frmBillCustomerMembers_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.LoadBillCustomers()
            Me.MemberStatus()
            Me.LoadMemberBenefits()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmBillCustomerMembers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
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

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboAccountNo, billCustomers, "BillCustomerFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

    Private Sub stbMedicalCardNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub cboAccountNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountNo.TextChanged
        Me.CallOnKeyEdit()
    End Sub

    Private Sub cboAccountNo_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccountNo.Leave

        Try

            Me.stbBillCustomerName.Clear()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim accountNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboAccountNo))).ToUpper()
            Me.cboAccountNo.Text = FormatText(accountNo, "BillCustomers", "AccountNo")

            For Each row As DataRow In billCustomers.Select("AccountNo = '" + accountNo + "'")
                Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub MemberStatus()

        Dim oLookupData As New LookupData()
        Dim oStatusID As New LookupCommDataID.StatusID()

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim statusLookupData As DataTable = oLookupData.GetLookupData(LookupCommObjects.Status).Tables("LookupData")
            If statusLookupData Is Nothing Then Return

            For Each row As DataRow In statusLookupData.Rows
                If oStatusID.Active.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
                    oStatusID.Inactive.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) Then
                    Continue For
                Else : row.Delete()
                End If
            Next

            Me.fcbStatusID.DataSource = statusLookupData

            Me.fcbStatusID.DisplayMember = "DataDes"
            Me.fcbStatusID.ValueMember = "DataID"
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oBillCustomerMembers As New SyncSoft.SQLDb.BillCustomerMembers()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return

            oBillCustomerMembers.MedicalCardNo = SubstringRight(RevertText(StringEnteredIn(cboMedicalCardNo, "Medical Card No!")))
            oBillCustomerMembers.AccountNo = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            DisplayMessage(oBillCustomerMembers.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            ResetControlsIn(Me.tpgMemberLimits)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oBillCustomerMembers As New SyncSoft.SQLDb.BillCustomerMembers()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim medicalCardNo As String = SubstringRight(RevertText(StringEnteredIn(Me.cboMedicalCardNo, "Medical Card No!")))
            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No"))

            Dim dataSource As DataTable = oBillCustomerMembers.GetBillCustomerMembers(medicalCardNo, accountNo).Tables("BillCustomerMembers")
            Me.DisplayData(dataSource)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadMemberLimits(medicalCardNo, accountNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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

            Dim oBillCustomerMembers As New SyncSoft.SQLDb.BillCustomerMembers()
            Dim lBillCustomerMembers As New List(Of DBConnect)

            With oBillCustomerMembers

                .MedicalCardNo = SubstringRight(RevertText(StringEnteredIn(cboMedicalCardNo, "Medical Card No!")))
                .AccountNo = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!")).ToUpper()
                .Surname = StringEnteredIn(Me.stbSurname, "Surname!")
                .FirstName = StringEnteredIn(Me.stbFirstName, "First Name!")
                .MiddleName = StringMayBeEnteredIn(Me.stbMiddleName)
                .PolicyStartDate = DateMayBeEnteredIn(Me.dtpPolicyStartDate)
                .PolicyEndDate = DateMayBeEnteredIn(Me.dtpPolicyEndDate)
                .CreditLimit = Me.nbxCreditLimit.GetDecimal(False)
                .MemberStatusID = StringValueEnteredIn(Me.fcbStatusID, "Member Status!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                ValidateEntriesIn(Me, ErrProvider)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lBillCustomerMembers.Add(oBillCustomerMembers)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If IsCharacterInString(oBillCustomerMembers.MedicalCardNo) Then
                        Dim message As String = "Medical Card No contains a space (' '), an invalid character. " +
                                   ControlChars.NewLine + "Are you sure you want to save?"
                        If WarningMessage(message) = Windows.Forms.DialogResult.No Then Me.cboMedicalCardNo.Focus() : Return
                    End If

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lBillCustomerMembers, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(MemberLimitsList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                    ResetControlsIn(Me.tpgMemberLimits)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    transactions.Add(New TransactionList(Of DBConnect)(lBillCustomerMembers, Action.Save))
                    transactions.Add(New TransactionList(Of DBConnect)(MemberLimitsList, Action.Save))

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    records = DoTransactions(transactions)
                    DisplayMessage(records.ToString() + " record(s) updated!")
                    Me.CallOnKeyEdit()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End Select

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            For rowNo As Integer = 0 To Me.dgvMemberLimits.RowCount - 2
                Me.dgvMemberLimits.Item(Me.colMemberLimitsSaved.Name, rowNo).Value = True
            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Function MemberLimitsList() As List(Of DBConnect)

        Dim lMemberLimits As New List(Of DBConnect)

        Try

            Dim medicalCardNo As String = SubstringRight(RevertText(StringEnteredIn(cboMedicalCardNo, "Medical Card No!")))
            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))

            For rowNo As Integer = 0 To Me.dgvMemberLimits.RowCount - 2

                Using oMemberLimits As New SyncSoft.SQLDb.MemberLimits()

                    Dim cells As DataGridViewCellCollection = Me.dgvMemberLimits.Rows(rowNo).Cells

                    With oMemberLimits
                        .MedicalCardNo = medicalCardNo
                        .AccountNo = accountNo
                        .BenefitCode = StringEnteredIn(cells, Me.colBenefitCode, "Benefit Name!")
                        .MemberLimit = DecimalEnteredIn(cells, Me.colMemberLimit, False, "Member Limit!")
                    End With

                    lMemberLimits.Add(oMemberLimits)

                End Using

            Next

            Return lMemberLimits

        Catch ex As Exception
            Throw ex

        End Try

    End Function

#Region " MemberLimits - Grid "

    Private Sub dgvMemberLimits_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles dgvMemberLimits.CellBeginEdit

        If e.ColumnIndex <> Me.colBenefitCode.Index OrElse Me.dgvMemberLimits.Rows.Count <= 1 Then Return
        Dim selectedRow As Integer = Me.dgvMemberLimits.CurrentCell.RowIndex
        _ItemCategoryIDValue = StringMayBeEnteredIn(Me.dgvMemberLimits.Rows(selectedRow).Cells, Me.colBenefitCode)

    End Sub

    Private Sub dgvMemberLimits_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvMemberLimits.CellEndEdit

        Try

            If e.ColumnIndex.Equals(Me.colBenefitCode.Index) Then

                ' Ensure unique entry in the combo column

                If Me.dgvMemberLimits.Rows.Count > 1 Then

                    Dim selectedRow As Integer = Me.dgvMemberLimits.CurrentCell.RowIndex
                    Dim selectedItem As String = StringMayBeEnteredIn(Me.dgvMemberLimits.Rows(selectedRow).Cells, Me.colBenefitCode)

                    If CBool(Me.dgvMemberLimits.Item(Me.colMemberLimitsSaved.Name, selectedRow).Value).Equals(True) Then
                        DisplayMessage("Benefit Name (" + GetLookupDataDes(_ItemCategoryIDValue) + ") can't be edited!")
                        Me.dgvMemberLimits.Item(Me.colBenefitCode.Name, selectedRow).Value = _ItemCategoryIDValue
                        Me.dgvMemberLimits.Item(Me.colBenefitCode.Name, selectedRow).Selected = True
                        Return
                    End If

                    For rowNo As Integer = 0 To Me.dgvMemberLimits.RowCount - 2

                        If Not rowNo.Equals(selectedRow) Then
                            Dim enteredItem As String = StringMayBeEnteredIn(Me.dgvMemberLimits.Rows(rowNo).Cells, Me.colBenefitCode)
                            If enteredItem.Trim().ToUpper().Equals(selectedItem.Trim().ToUpper()) Then
                                DisplayMessage("Benefit Name (" + GetLookupDataDes(enteredItem) + ") already entered!")
                                Me.dgvMemberLimits.Item(Me.colBenefitCode.Name, selectedRow).Value = _ItemCategoryIDValue
                                Me.dgvMemberLimits.Item(Me.colBenefitCode.Name, selectedRow).Selected = True
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

    Private Sub dgvMemberLimits_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles dgvMemberLimits.UserDeletingRow

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oMemberLimits As New SyncSoft.SQLDb.MemberLimits()
            Dim toDeleteRowNo As Integer = e.Row.Index

            If CBool(Me.dgvMemberLimits.Item(Me.colMemberLimitsSaved.Name, toDeleteRowNo).Value) = False Then Return

            Dim medicalCardNo As String = SubstringRight(RevertText(StringEnteredIn(cboMedicalCardNo, "Medical Card No!")))
            Dim accountNo As String = RevertText(StringEnteredIn(Me.cboAccountNo, "Account No!"))
            Dim benefitCode As String = CStr(Me.dgvMemberLimits.Item(Me.colBenefitCode.Name, toDeleteRowNo).Value)

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
            With oMemberLimits
                .MedicalCardNo = medicalCardNo
                .AccountNo = accountNo
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

    Private Sub dgvMemberLimits_DataError(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgvMemberLimits.DataError
        ErrorMessage(e.Exception)
        e.Cancel = True
    End Sub

    Private Sub LoadMemberLimits(ByVal medicalCardNo As String, ByVal accountNo As String)

        Dim oMemberLimits As New SyncSoft.SQLDb.MemberLimits()

        Try

            Me.dgvMemberLimits.Rows.Clear()

            Dim memberLimits As DataTable = oMemberLimits.GetMemberLimits(medicalCardNo, accountNo).Tables("MemberLimits")
            If memberLimits Is Nothing OrElse memberLimits.Rows.Count < 1 Then Return

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvMemberLimits, memberLimits)

            For Each row As DataGridViewRow In Me.dgvMemberLimits.Rows
                If row.IsNewRow Then Exit For
                Me.dgvMemberLimits.Item(Me.colMemberLimitsSaved.Name, row.Index).Value = True
            Next

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadBillCustomerMembers()

        Dim oBillCustomerMember As New SyncSoft.SQLDb.BillCustomerMembers()

        Try
            Me.Cursor = Cursors.WaitCursor


            Dim billCustomerMember As DataTable = oBillCustomerMember.GetBillCustomerMembers().Tables("BillCustomerMembers")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboMedicalCardNo, billCustomerMember, "BillCustomerMemberFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

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
        LoadBillCustomerMembers()

        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True
        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgMemberLimits)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False
        ResetControlsIn(Me)
        ResetControlsIn(Me.tpgMemberLimits)

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

    Private Sub cboAccountNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboAccountNo.SelectedIndexChanged

    End Sub



#End Region

End Class