
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations

Imports System.Collections.Generic


Public Class frmInsurancePolicies

#Region " Fields "
    Private insurances As DataTable
#End Region

    Private Sub frmInsurancePolicies_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            Me.LoadInsurances()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmInsurancePolicies_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub stbPolicyNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.CallOnKeyEdit()
    End Sub

    Private Sub LoadInsurances()

        Dim oInsurances As New SyncSoft.SQLDb.Insurances()

        Try
            Me.Cursor = Cursors.WaitCursor

            ' Load all from Insurances

            insurances = oInsurances.GetInsurances().Tables("Insurances")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadComboData(Me.cboInsuranceNo, insurances, "InsuranceFullName")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ClearControls()
        Me.stbInsuranceName.Clear()

    End Sub

    Private Sub ClearInsuranceName(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInsuranceNo.SelectedIndexChanged, cboInsuranceNo.TextChanged
        If Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update Then Return
        Me.ClearControls()
    End Sub

    Private Sub cboInsuranceNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboInsuranceNo.Leave

        Dim insuranceName As String

        Try
            Dim insuranceNo As String = RevertText(SubstringRight(StringMayBeEnteredIn(Me.cboInsuranceNo)))
            Me.cboInsuranceNo.Text = FormatText(insuranceNo, "Insurances", "InsuranceNo")
            If String.IsNullOrEmpty(insuranceNo) Then Return

            For Each row As DataRow In insurances.Select("InsuranceNo = '" + insuranceNo + "'")

                If Not IsDBNull(row.Item("InsuranceName")) Then
                    insuranceName = StringEnteredIn(row, "InsuranceName")
                    insuranceNo = StringMayBeEnteredIn(row, "InsuranceNo")
                    Me.cboInsuranceNo.Text = FormatText(insuranceNo.ToUpper(), "Insurances", "InsuranceNo")
                Else
                    insuranceName = String.Empty
                    insuranceNo = String.Empty
                End If

                Me.stbInsuranceName.Text = insuranceName
            Next

            Me.SetNextPolicyNo(insuranceNo)

        Catch ex As Exception
            ErrorMessage(ex)
        End Try

    End Sub

    Private Sub SetNextPolicyNo(ByVal insuranceNo As String)

        Try

            Dim oInsurancePolicies As New SyncSoft.SQLDb.InsurancePolicies()
            Dim oAutoNumbers As New SyncSoft.Options.SQL.AutoNumbers()

            Dim autoNumbers As DataTable = oAutoNumbers.GetAutoNumbers("InsurancePolicies", "PolicyNo").Tables("AutoNumbers")
            Dim row As DataRow = autoNumbers.Rows(0)

            Dim paddingLEN As Integer = IntegerEnteredIn(row, "PaddingLEN")
            Dim paddingCHAR As Char = CChar(StringEnteredIn(row, "PaddingCHAR"))

            Dim policyID As String = oInsurancePolicies.GetNextPolicyID(insuranceNo).ToString()
            policyID = policyID.PadLeft(paddingLEN, paddingCHAR)

            Me.cboPolicyNo.Text = FormatText(insuranceNo + policyID.Trim(), "InsurancePolicies", "PolicyNo")

        Catch ex As Exception
            Return
        End Try

    End Sub

    Private Sub fbnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnDelete.Click

        Dim oInsurancePolicies As New SyncSoft.SQLDb.InsurancePolicies()

        Try
            Me.Cursor = Cursors.WaitCursor()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If DeleteMessage() = Windows.Forms.DialogResult.No Then Return
            oInsurancePolicies.PolicyNo = RevertText(StringEnteredIn(Me.cboPolicyNo, "Policy No!"))
            DisplayMessage(oInsurancePolicies.Delete())
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ResetControlsIn(Me)
            Me.CallOnKeyEdit()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub fbnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnSearch.Click

        Dim oInsurancePolicies As New SyncSoft.SQLDb.InsurancePolicies()

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim policyNo As String = RevertText(StringEnteredIn(Me.cboPolicyNo, "Policy No!"))
            Dim dataSource As DataTable = oInsurancePolicies.GetInsurancePolicies(policyNo).Tables("InsurancePolicies")
            Me.DisplayData(dataSource)

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

            Dim oInsurancePolicies As New SyncSoft.SQLDb.InsurancePolicies()
            Dim lInsurancePolicies As New List(Of DBConnect)

            With oInsurancePolicies

                .InsuranceNo = RevertText(StringEnteredIn(Me.cboInsuranceNo, "Insurance No!"))
                .PolicyNo = RevertText(StringEnteredIn(Me.cboPolicyNo, "Policy No!"))
                .PolicyName = StringEnteredIn(Me.stbPolicyName, "Policy Name!")
                .LoginID = CurrentUser.LoginID

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ValidateEntriesIn(Me)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            lInsurancePolicies.Add(oInsurancePolicies)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Select Case Me.ebnSaveUpdate.ButtonText

                Case ButtonCaption.Save

                    transactions.Add(New TransactionList(Of DBConnect)(lInsurancePolicies, Action.Save))

                    records = DoTransactions(transactions)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    ResetControlsIn(Me)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                Case ButtonCaption.Update

                    transactions.Add(New TransactionList(Of DBConnect)(lInsurancePolicies, Action.Update, "InsurancePolicies"))

                    records = DoTransactions(transactions)

                    DisplayMessage(records.ToString() + " record(s) updated!")

                    Me.CallOnKeyEdit()

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

#Region " Edit Methods "

    Public Sub Edit()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Update
        LoadInsurancePolicies()
        Me.ebnSaveUpdate.Enabled = False
        Me.fbnDelete.Visible = True
        Me.fbnDelete.Enabled = False
        Me.fbnSearch.Visible = True

        Me.cboPolicyNo.Enabled = True
        Me.cboInsuranceNo.Enabled = True

        ResetControlsIn(Me)

    End Sub

    Public Sub Save()

        Me.ebnSaveUpdate.ButtonText = ButtonCaption.Save
        Me.ebnSaveUpdate.Enabled = True
        Me.fbnDelete.Visible = False
        Me.fbnDelete.Enabled = True
        Me.fbnSearch.Visible = False

        Me.cboPolicyNo.Enabled = InitOptions.PolicyNoLocked
        Me.cboInsuranceNo.Enabled = True

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


    Private Sub cboPolicyNo_Leave(sender As Object, e As EventArgs) Handles cboPolicyNo.Leave
        stbPolicyName.Text = SubstringLeft(RevertText(StringMayBeEnteredIn(Me.cboPolicyNo)))
        cboPolicyNo.Text = SubstringRight(RevertText(StringMayBeEnteredIn(Me.cboPolicyNo)))
    End Sub

    Private Sub LoadInsurancePolicies()

        Dim oInsurancePolicy As New SyncSoft.SQLDb.InsurancePolicies()
        Dim insurancesPolicy As DataTable = Nothing
        cboPolicyNo.DataSource = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor
            Dim insurance As String = SubstringRight(RevertText(StringMayBeEnteredIn(Me.cboInsuranceNo)))

            If String.IsNullOrEmpty(insurance) Then
                insurancesPolicy = oInsurancePolicy.GetInsurancePolicies().Tables("InsurancePolicies")
            Else
                insurancesPolicy = oInsurancePolicy.GetInsurancePoliciesByInsuranceNo(insurance).Tables("InsurancePolicies")

            End If
            LoadComboData(cboPolicyNo, insurancesPolicy, "InsurancePolicyFullName")

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboPolicyNo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPolicyNo.SelectedIndexChanged

    End Sub


#End Region

End Class