
Option Strict On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.Win.Controls

Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects
Imports SyncSoft.SQLDb.Lookup

Public Class frmBankPaymentDetails
    Private bankAccount As String
    Private bankNamesID As String
#Region " Fields "
    Dim oPayModesID As New LookupDataID.PayModesID()
#End Region

    Private Sub frmBankPaymentDetails_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor()

            LoadLookupDataCombo(Me.cboBankNamesID, LookupObjects.BankNamesID, False)

            If Me.payModeID.Equals(oPayModesID.Cheque()) Then
                Me.cboAccountNo.DropDownStyle = ComboBoxStyle.Simple
            End If

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try

    End Sub

    Private Sub frmBankPaymentDetails_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub


    Public Function BankName() As String
        Return Me.bankNamesID
    End Function

    Public Function AccountNo() As String
        Return Me.bankAccount
    End Function

#Region " Edit Methods "

    Private Sub LoadAccountNames()

        Dim oBankAccount As New SyncSoft.SQLDb.BankAccounts()
        Dim bankID As String = StringValueMayBeEnteredIn(cboBankNamesID)
        If String.IsNullOrEmpty(bankID) Then Return

        Try
            Me.Cursor = Cursors.WaitCursor
            cboAccountNo.DataSource = Nothing
            If String.IsNullOrEmpty(bankID) Then Return

            Dim bankAccount As DataTable = oBankAccount.GetBankAccountsByBankID(bankID).Tables("BankAccounts")

            If bankAccount.Rows.Count() < 0 Then Return

            cboAccountNo.DataSource = bankAccount
            cboAccountNo.DisplayMember = "AccountName"
            cboAccountNo.ValueMember = "AccountNo"

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBankNamesID_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBankNamesID.SelectedIndexChanged
        LoadAccountNames()
    End Sub

    Private Sub btnDone_Click(sender As Object, e As EventArgs) Handles btnDone.Click

        Try
            Me.Cursor = Cursors.WaitCursor()

            Dim BankNamesID As String = StringValueEnteredIn(Me.cboBankNamesID, "Bank Name!")
            Dim accountNo As String = StringEnteredIn(Me.cboAccountNo, "Account No!")
            If Not Me.payModeID.Equals(oPayModesID.Cheque()) Then
                accountNo = StringValueEnteredIn(Me.cboAccountNo, "Account No!")
            End If
            Me.bankNamesID = BankNamesID
            Me.bankAccount = accountNo
            Me.Close()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default()

        End Try
    End Sub





#End Region

End Class