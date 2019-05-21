
Option Strict On

Imports SyncSoft.SQLDb
Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports SyncSoft.Common.Win.Controls
Imports SyncSoft.Common.SQL.Enumerations
Imports LookupData = SyncSoft.Lookup.SQL.LookupData
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Public Class frmFindObject

#Region " Fields "
    Private _ObjectName As ObjectName
#End Region

    Private Sub frmFindObject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim oBillModesID As New LookupDataID.BillModesID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.LoadBillModes()

            If _ObjectName = ObjectName.SchemeMembers Then
                Me.Text = "Find Scheme Member"

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Me.cboBillModesID.SelectedValue = oBillModesID.Insurance
                Me.cboBillModesID.Enabled = False
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ElseIf _ObjectName = ObjectName.PatientNo Then
                Me.Text = "Find Patient No"
            ElseIf _ObjectName = ObjectName.InvoiceNo Then
                Me.Text = "Find Invoice No"
                Me.lblFindNo.Text = "Invoice No"
                Me.lblBillModesID.Visible = False
                Me.cboBillModesID.Visible = False
            End If
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmFindObject_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub frmFindObject_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        FadeClosingForm(Me, 200)
    End Sub

    Public Function GetInvoiceNo() As DataTable

        Try

            Dim oInvoices As New SyncSoft.SQLDb.Invoices
            Dim findNo As String = RevertText(StringEnteredIn(Me.stbFindNo, Me.lblFindNo.Text + "!"))

            Dim Invoices As DataTable = oInvoices.GetVisitNoByInvoiceNo(findNo).Tables("Invoices")

            Return Invoices

        Catch ex As Exception
            Throw ex

        End Try

    End Function


    Public Function GetIPDInvoiceNo() As DataTable

        Try

            Dim oInvoices As New SyncSoft.SQLDb.Invoices
            Dim findNo As String = RevertText(StringEnteredIn(Me.stbFindNo, Me.lblFindNo.Text + "!"))

            Dim Invoices As DataTable = oInvoices.GetIPDVisitNoByInvoiceNo(findNo).Tables("Invoices")

            Return Invoices

        Catch ex As Exception
            Throw ex

        End Try

    End Function


    Private Sub LoadBillModes()

        Dim oLookupData As New LookupData()
        Dim oBillModesID As New LookupDataID.BillModesID()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim billModesLookupData As DataTable = oLookupData.GetLookupData(LookupObjects.BillModes).Tables("LookupData")

            If billModesLookupData IsNot Nothing Then

                For Each row As DataRow In billModesLookupData.Rows
                    If Not (oBillModesID.Insurance.ToUpper().Equals(row.Item("DataID").ToString().ToUpper()) OrElse
                            oBillModesID.Account.ToUpper().Equals(row.Item("DataID").ToString().ToUpper())) Then
                        row.Delete()
                    End If
                Next

                Me.cboBillModesID.DataSource = billModesLookupData

                Me.cboBillModesID.DisplayMember = "DataDes"
                Me.cboBillModesID.ValueMember = "DataID"

                Me.cboBillModesID.SelectedIndex = -1
                Me.cboBillModesID.SelectedIndex = -1

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cboBillModesID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBillModesID.SelectedIndexChanged

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oBillModesID As New LookupDataID.BillModesID()

            Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBillModesID, "Account Category!")
            If String.IsNullOrEmpty(billModesID) Then Return

            Select Case billModesID.ToUpper()

                Case oBillModesID.Cash.ToUpper()
                    Me.lblFindNo.Text = "Default Medical Card No"

                Case oBillModesID.Account.ToUpper()
                    Me.lblFindNo.Text = "Default Member Card No"

                Case oBillModesID.Insurance.ToUpper()
                    Me.lblFindNo.Text = "Default Medical Card No"

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Public Function GetSchemeMember() As DataTable

        Try

            Dim oSchemeMembers As New SyncSoft.SQLDb.SchemeMembers()
            Dim findNo As String = RevertText(StringEnteredIn(Me.stbFindNo, Me.lblFindNo.Text + "!"))
            Dim schemeMembers As DataTable = oSchemeMembers.GetSchemeMembers(findNo).Tables("SchemeMembers")

            Return schemeMembers

        Catch ex As Exception
            Throw ex

        End Try

    End Function

    Public Function GetPatientNo() As String

        Try

            Dim oBillModesID As New LookupDataID.BillModesID()
            Dim oPatients As New SyncSoft.SQLDb.Patients()
            Dim billModesID As String = StringValueEnteredIn(Me.cboBillModesID, "To-Bill Mode!")
            Dim findNo As String = StringEnteredIn(Me.stbFindNo, Me.lblFindNo.Text + "!")

            If billModesID.ToUpper().Equals(oBillModesID.Insurance.ToUpper()) Then
                Return oPatients.GetPatientNoByBillNo(findNo)

            ElseIf billModesID.ToUpper().Equals(oBillModesID.Account.ToUpper()) Then
                Return oPatients.GetPatientNoByMemberCardNo(findNo)

            Else : Return oPatients.GetPatientNoByBillNo(findNo)
            End If

        Catch ex As Exception
            Throw ex

        End Try

    End Function

End Class