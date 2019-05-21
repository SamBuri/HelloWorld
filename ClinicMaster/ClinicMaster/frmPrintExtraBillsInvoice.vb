
Option Strict On
Option Infer On

Imports SyncSoft.Security
Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports SyncSoft.Common.SQL.Classes
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmPrintExtraBillsInvoice

#Region " Fields "

    Dim defaultVisitNo As String = String.Empty

    Private tipCoPayValueWords As New ToolTip()
    Private tipCashAccountBalanceWords As New ToolTip()

    Private padItemNo As Integer = 11
    Private padItemName As Integer = 18
    Private padNotes As Integer = 14
    Private padQuantity As Integer = 4
    Private padUnitPrice As Integer = 12
    Private padAmount As Integer = 12

    Private WithEvents docBillInvoice As New PrintDocument()

    ' The paragraphs.
    Private invoiceParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)
    Private oVisitTypeID As New LookupDataID.VisitTypeID()
#End Region

#Region " Validations "

#End Region

    Private Sub frmPrintExtraBillsInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(defaultVisitNo) Then
                ResetControlsIn(Me.pnlNavigateVisits)
                Me.LoadExtraBillInvoiceData(defaultVisitNo)
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub frmPrintExtraBillsInvoice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbVisitNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbVisitNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub fbnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnClose.Click
        Me.Close()
    End Sub

    Private Sub ClearControls()

        Me.stbFullName.Clear()
        Me.stbVisitDate.Clear()
        Me.stbGender.Clear()
        Me.stbJoinDate.Clear()
        Me.stbAge.Clear()
        Me.stbPatientNo.Clear()
        Me.stbVisitStatus.Clear()
        Me.stbBillNo.Clear()
        Me.stbBillMode.Clear()
        Me.stbBillCustomerName.Clear()
        Me.stbInsuranceName.Clear()
        Me.stbMemberCardNo.Clear()
        Me.stbMainMemberName.Clear()
        Me.stbClaimReferenceNo.Clear()
        Me.chkIncludePaidFor.Checked = False
        Me.stbCoPayType.Clear()
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.nbxCashAccountBalance.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.tipCashAccountBalanceWords.RemoveAll()
        Me.chkIncludeOPDBill.Checked = False
        Me.chkIncludeOPDBill.Enabled = False
        ResetControlsIn(Me.pnlBill)
        Me.dgvExtraBillsInvoice.Rows.Clear()
        Me.dgvOPDBillsInvoice.Rows.Clear()
        Me.dgvReturnedExtraBillItems.Rows.Clear()
        Me.fbnAddBill.Enabled = False

    End Sub

    Private Sub stbVisitNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbVisitNo.Leave

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            ResetControlsIn(Me.pnlNavigateVisits)
            Me.LoadExtraBillInvoiceData(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadExtraBillInvoiceData(ByVal visitNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowPatientDetails(visitNo)
            Me.LoadExtraBillItems(visitNo)
            Me.LoadVisitNotPaidItems(visitNo)
            Me.LoadExtraBillItemAdjustments(visitNo)
            Me.LoadPendingBillItems(visitNo)


            '''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.tbcExtraBillsInvoice.SelectedTab.Name

                Case Me.tpgBillingForm.Name
                    Me.CalculateBillForExtraBills()

                Case Me.tpgOPDBill.Name
                    Me.CalculateBillForOPDBill()

                Case Me.tpgAdjustments.Name
                    Me.CalculateBillForReturnsBill()

                Case Me.tpgPendingBill.Name
                    Me.CalculateBillForPendingBill()

                Case Else
                    ResetControlsIn(Me.pnlBill)
                    ResetControlsIn(Me.pnlNavigateVisits)

            End Select
            '''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkIncludePaidFor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncludePaidFor.CheckedChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return
            Me.LoadExtraBillItems(visitNo)
            Me.LoadVisitNotPaidItems(visitNo)
            Me.LoadExtraBillItemAdjustments(visitNo)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Select Case Me.tbcExtraBillsInvoice.SelectedTab.Name

                Case Me.tpgBillingForm.Name
                    Me.CalculateBillForExtraBills()

                Case Me.tpgOPDBill.Name
                    Me.CalculateBillForOPDBill()

                Case Me.tpgAdjustments.Name
                    Me.CalculateBillForReturnsBill()

                Case Else
                    ResetControlsIn(Me.pnlBill)
                    ResetControlsIn(Me.pnlNavigateVisits)

            End Select
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub stbVisitNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbVisitNo.TextChanged
        Me.ClearControls()
    End Sub

    Private Sub btnFindVisitNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindVisitNo.Click

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim fFindVisitNo As New frmFindAutoNo(Me.stbVisitNo, AutoNumber.VisitNo)
        fFindVisitNo.ShowDialog(Me)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        ResetControlsIn(Me.pnlNavigateVisits)
        Me.LoadExtraBillInvoiceData(visitNo)
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub btnLoadPeriodicVisits_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadPeriodicVisits.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fPeriodicExtraBills As New frmPeriodicExtraBills(Me.stbVisitNo)

            fPeriodicExtraBills.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))

            If String.IsNullOrEmpty(visitNo) Then Return

            ResetControlsIn(Me.pnlNavigateVisits)
            Me.LoadExtraBillInvoiceData(visitNo)
            '''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowPatientDetails(ByVal visitNo As String)

        Dim oVisits As New SyncSoft.SQLDb.Visits()
        Dim oInvoices As New SyncSoft.SQLDb.Invoices()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ClearControls()

            If String.IsNullOrEmpty(visitNo) Then Return

            Dim visits As DataTable = oVisits.GetAdmissionsDetails(visitNo).Tables("Visits")
            Dim row As DataRow = visits.Rows(0)
            Dim patientNo As String = StringEnteredIn(row, "PatientNo")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbGender.Text = StringEnteredIn(row, "Gender")
            Me.stbJoinDate.Text = FormatDate(DateEnteredIn(row, "JoinDate"))
            Me.stbAge.Text = StringEnteredIn(row, "Age")
            Me.stbVisitStatus.Text = StringEnteredIn(row, "VisitStatus")
            Me.stbBillNo.Text = FormatText(StringEnteredIn(row, "BillNo"), "BillCustomers", "AccountNo")
            Me.stbBillCustomerName.Text = StringMayBeEnteredIn(row, "BillCustomerName")
            Me.stbInsuranceName.Text = StringMayBeEnteredIn(row, "InsuranceName")
            Me.stbMemberCardNo.Text = StringMayBeEnteredIn(row, "MemberCardNo")
            Me.stbMainMemberName.Text = StringMayBeEnteredIn(row, "MainMemberName")
            Me.stbClaimReferenceNo.Text = StringMayBeEnteredIn(row, "ClaimReferenceNo")
            Me.stbBillMode.Text = StringEnteredIn(row, "BillMode")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Me.nbxCashAccountBalance.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CashAccountBalance"), AppData.DecimalPlaces)
            Me.tipCashAccountBalanceWords.SetToolTip(Me.nbxCashAccountBalance, NumberToWords(DecimalMayBeEnteredIn(row, "CashAccountBalance")))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.fbnAddBill.Enabled = True
            Security.Apply(Me.fbnAddBill, AccessRights.Write)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadExtraBillItems(ByVal visitNo As String)

        Dim extraBillItems As DataTable
        Dim oExtraBillItems As New SyncSoft.SQLDb.ExtraBillItems()
        Dim oPayStatusID As New LookupDataID.PayStatusID()

        Try

            Me.dgvExtraBillsInvoice.Rows.Clear()

            ' Load items not yet paid for

            If String.IsNullOrEmpty(visitNo) Then Return

            If Me.chkIncludePaidFor.Checked Then
                extraBillItems = oExtraBillItems.GetExtraBillItemsByVisitNo(visitNo).Tables("ExtraBillItems")
            Else : extraBillItems = oExtraBillItems.GetExtraBillItemsByVisitNo(visitNo, oPayStatusID.NotPaid).Tables("ExtraBillItems")
            End If

            If extraBillItems Is Nothing OrElse extraBillItems.Rows.Count < 1 Then
                DisplayMessage("No extra bill item(s) registered for this visit!")
                Return
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvExtraBillsInvoice, extraBillItems)

            For Each row As DataGridViewRow In Me.dgvExtraBillsInvoice.Rows
                If row.IsNewRow Then Exit For
                Me.dgvExtraBillsInvoice.Item(Me.colInclude.Name, row.Index).Value = True
            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.CalculateBillForExtraBills()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub LoadVisitNotPaidItems(ByVal visitNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim items As DataTable
            Dim oItems As New SyncSoft.SQLDb.Items()

            Me.dgvOPDBillsInvoice.Rows.Clear()

            If String.IsNullOrEmpty(visitNo) Then Return

            If Me.chkIncludePaidFor.Checked Then
                items = oItems.GetItemsByVisitNo(visitNo).Tables("Items")
            Else : items = oItems.GetNotPaidItemsByVisitNo(visitNo).Tables("Items")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If items Is Nothing OrElse items.Rows.Count < 1 Then Throw New ArgumentException("No " + Me.tpgOPDBill.Text + " Record(s) found!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvOPDBillsInvoice, items)

            For Each row As DataGridViewRow In Me.dgvOPDBillsInvoice.Rows
                If row.IsNewRow Then Exit For
                Me.dgvOPDBillsInvoice.Item(Me.colOPDInclude.Name, row.Index).Value = True
            Next

            Me.CalculateBillForOPDBill()

            Me.chkIncludeOPDBill.Checked = False
            Me.chkIncludeOPDBill.Enabled = items.Rows.Count > 0
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadExtraBillItemAdjustments(ByVal visitNo As String)

        Dim adjustedBills As DataTable
        Dim oExtraBillItemAdjustments As New SyncSoft.SQLDb.ExtraBillItemAdjustments()
        Dim oPayStatusID As New LookupDataID.PayStatusID()

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.dgvReturnedExtraBillItems.Rows.Clear()

            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkIncludePaidFor.Checked Then
                adjustedBills = oExtraBillItemAdjustments.GetExtraBillItemAdjustmentsByVisitNo(visitNo).Tables("ExtraBillItemAdjustments")
            Else : adjustedBills = oExtraBillItemAdjustments.GetExtraBillItemAdjustmentsByVisitNo(visitNo, oPayStatusID.NotPaid).Tables("ExtraBillItemAdjustments")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If adjustedBills Is Nothing OrElse adjustedBills.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvReturnedExtraBillItems, adjustedBills)

            For Each row As DataGridViewRow In Me.dgvReturnedExtraBillItems.Rows
                If row.IsNewRow Then Exit For
                Me.dgvReturnedExtraBillItems.Item(Me.colReturnsInclude.Name, row.Index).Value = True
            Next

            Me.CalculateBillForReturnsBill()

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadPendingBillItems(ByVal visitNo As String)

        Dim PendingBillItems As DataTable
        Dim oGetPendingBillItems As New SyncSoft.SQLDb.PendingBillItems()

        Try

            Me.Cursor = Cursors.WaitCursor
            chkIncludePendingBill.Enabled = False
            Me.dgvPendingBill.Rows.Clear()

            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            PendingBillItems = oGetPendingBillItems.GetPendingBillItems(visitNo).Tables("PendingBillItems")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If PendingBillItems Is Nothing OrElse PendingBillItems.Rows.Count < 1 Then Return

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPendingBill, PendingBillItems)

            For Each row As DataGridViewRow In Me.dgvPendingBill.Rows
                If row.IsNewRow Then Exit For
                Me.dgvPendingBill.Item(Me.colPendingBillInclude.Name, row.Index).Value = True
            Next


            If dgvPendingBill.Rows.Count > 0 Then
                chkIncludePendingBill.Enabled = True
            ElseIf (dgvPendingBill.Rows.Count <= 0) Then
                chkIncludePendingBill.Enabled = False
            End If

            Select Case Me.tbcExtraBillsInvoice.SelectedTab.Name

                Case Me.tpgPendingBill.Name
                    Me.CalculateBillForPendingBill()
                Case Else

            End Select



            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Function GetBillFormAmount() As Decimal

        Dim totalAmount As Decimal = 0
        For rowNo As Integer = 0 To Me.dgvExtraBillsInvoice.RowCount - 1
            If CBool(Me.dgvExtraBillsInvoice.Item(Me.colInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvExtraBillsInvoice.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colAmount)
                totalAmount += amount
            End If
        Next
        Return totalAmount

    End Function


    Private Sub CalculateBillForExtraBills()

        ResetControlsIn(Me.pnlBill)

        Dim totalBill As Decimal = Me.GetBillFormAmount()

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Function GetOPDBillAmount() As Decimal

        Dim totalAmount As Decimal = 0
        For rowNo As Integer = 0 To Me.dgvOPDBillsInvoice.RowCount - 1
            If CBool(Me.dgvOPDBillsInvoice.Item(Me.colOPDInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvOPDBillsInvoice.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colOPDAmount)
                totalAmount += amount
            End If
        Next
        Return totalAmount

    End Function

    Private Sub CalculateBillForOPDBill()

        ResetControlsIn(Me.pnlBill)

        Dim totalBill As Decimal = Me.GetOPDBillAmount()

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Function GetReturnsBillAmount() As Decimal

        Dim totalAmount As Decimal = 0
        For rowNo As Integer = 0 To Me.dgvReturnedExtraBillItems.RowCount - 1
            If CBool(Me.dgvReturnedExtraBillItems.Item(Me.colReturnsInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvReturnedExtraBillItems.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colReturnsAmount)
                totalAmount += amount
            End If
        Next
        Return totalAmount

    End Function

    Private Function GetPendingBillAmount() As Decimal

        Dim totalAmount As Decimal = 0
        For rowNo As Integer = 0 To Me.dgvPendingBill.RowCount - 1
            If CBool(Me.dgvPendingBill.Item(Me.colPendingBillInclude.Name, rowNo).Value) = True Then
                Dim cells As DataGridViewCellCollection = Me.dgvPendingBill.Rows(rowNo).Cells
                Dim amount As Decimal = DecimalMayBeEnteredIn(cells, Me.colPendingBillAmount)
                totalAmount += amount
            End If
        Next
        Return totalAmount

    End Function

    Private Sub CalculateBillForReturnsBill()

        ResetControlsIn(Me.pnlBill)

        Dim totalBill As Decimal = Me.GetReturnsBillAmount()

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub


    Private Sub CalculateBillForPendingBill()

        ResetControlsIn(Me.pnlBill)

        Dim totalBill As Decimal = Me.GetPendingBillAmount()

        Me.stbBillForItem.Text = FormatNumber(totalBill, AppData.DecimalPlaces)
        Me.stbBillWords.Text = NumberToWords(totalBill)

    End Sub

    Private Sub tbcExtraBillsInvoice_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbcExtraBillsInvoice.SelectedIndexChanged

        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcExtraBillsInvoice.SelectedTab.Name

                Case Me.tpgBillingForm.Name
                    Me.btnPrint.Visible = True
                    Me.btnPrintPreview.Visible = True
                    Me.fbnAddBill.Visible = True
                    Me.lblBillForItem.Text = "Total for " + Me.tpgBillingForm.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForExtraBills()

                Case Me.tpgOPDBill.Name
                    Me.btnPrint.Visible = False
                    Me.btnPrintPreview.Visible = False
                    Me.fbnAddBill.Visible = False
                    Me.lblBillForItem.Text = "Total for " + Me.tpgOPDBill.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForOPDBill()

                Case Me.tpgAdjustments.Name
                    Me.btnPrint.Visible = False
                    Me.btnPrintPreview.Visible = False
                    Me.fbnAddBill.Visible = False
                    Me.lblBillForItem.Text = "Total for " + Me.tpgAdjustments.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForReturnsBill()

                Case Me.tpgPendingBill.Name
                    Me.btnPrint.Visible = False
                    Me.btnPrintPreview.Visible = False
                    Me.fbnAddBill.Visible = False
                    Me.lblBillForItem.Text = "Total for " + Me.tpgPendingBill.Text
                    Me.pnlBill.Visible = True
                    Me.CalculateBillForPendingBill()

                Case Else
                    Me.btnPrint.Visible = False
                    Me.btnPrintPreview.Visible = False
                    Me.fbnAddBill.Visible = False
                    Me.lblBillForItem.Text = "Total for Billing Form"
                    Me.pnlBill.Visible = False
                    ResetControlsIn(Me.pnlBill)

            End Select

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub fbnAddBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles fbnAddBill.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            If String.IsNullOrEmpty(visitNo) Then Return

            Dim fExtraBills As New frmExtraBills(visitNo, oVisitTypeID.InPatient)
            fExtraBills.Save()
            fExtraBills.ShowDialog()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadExtraBillItems(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Bill Form - Grid "

    Private Sub dgvExtraBillsInvoice_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvExtraBillsInvoice.CellEndEdit
        Me.CalculateBillForExtraBills()
    End Sub

#End Region

#Region " OPD Bill - Grid "

    Private Sub dgvOPDBillsInvoice_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOPDBillsInvoice.CellEndEdit
        Me.CalculateBillForOPDBill()
    End Sub

#End Region

#Region " Returns Bill - Grid "

    Private Sub dgvReturnedExtraBillItems_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvReturnedExtraBillItems.CellEndEdit
        Me.CalculateBillForReturnsBill()
    End Sub

#End Region

#Region " Invoice Printing "

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.PrintBillInvoice()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPreview.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ' Make a PrintDocument and attach it to the PrintPreview dialog.
            Dim dlgPrintPreview As New PrintPreviewDialog()

            Me.SetInvoicePrintData()

            With dlgPrintPreview
                .Document = docBillInvoice
                .Document.PrinterSettings.Collate = True
                .ShowIcon = False
                .WindowState = FormWindowState.Maximized
                .ShowDialog()
            End With

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub PrintBillInvoice()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetInvoicePrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docBillInvoice
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docBillInvoice.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub docBillInvoice_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBillInvoice.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Invoice".ToUpper()
            Dim patientName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim invoiceNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim invoiceDate As String = FormatDate(Today)
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)

            Dim billNo As String = StringMayBeEnteredIn(Me.stbBillNo)
            Dim memberCardNo As String = StringMayBeEnteredIn(Me.stbMemberCardNo)
            Dim mainMemberName As String = StringMayBeEnteredIn(Me.stbMainMemberName)
            Dim claimReferenceNo As String = StringMayBeEnteredIn(Me.stbClaimReferenceNo)
            Dim billCustomerName As String = StringMayBeEnteredIn(Me.stbBillCustomerName)
            Dim insuranceName As String = StringMayBeEnteredIn(Me.stbInsuranceName)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 27 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Patient's Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Invoice No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(invoiceNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Invoice Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(invoiceDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    If Not String.IsNullOrEmpty(memberCardNo) Then
                        .DrawString("Member Card No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(memberCardNo, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(mainMemberName) Then
                        .DrawString("Main Member Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(mainMemberName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                        yPos += lineHeight
                    End If

                    If Not String.IsNullOrEmpty(claimReferenceNo) Then
                        .DrawString("Claim Reference No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(claimReferenceNo, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)
                        yPos += lineHeight
                    End If

                    .DrawString("Bill Customer Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billCustomerName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)

                    If Not String.IsNullOrEmpty(insuranceName) Then
                        yPos += lineHeight

                        .DrawString("Bill Insurance Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                        .DrawString(insuranceName, bodyBoldFont, Brushes.Black, xPos + widthTopThird, yPos)

                    End If

                    yPos += 2 * lineHeight

                End If

                Dim _StringFormat As New StringFormat()

                ' Draw the rest of the text left justified,
                ' wrap at words, and don't draw partial lines.

                With _StringFormat
                    .Alignment = StringAlignment.Near
                    .FormatFlags = StringFormatFlags.LineLimit
                    .Trimming = StringTrimming.Word
                End With

                Dim charactersFitted As Integer
                Dim linesFilled As Integer

                If invoiceParagraphs Is Nothing Then Return

                Do While invoiceParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(invoiceParagraphs(1), PrintParagraps)
                    invoiceParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont, _
                        New SizeF(printAreaRectangle.Width, printAreaRectangle.Height), _StringFormat, charactersFitted, linesFilled)

                    ' See if any characters will fit.
                    If charactersFitted > 0 Then
                        ' Draw the text.
                        .DrawString(oPrintParagraps.Text, oPrintParagraps.TheFont, Brushes.Black, printAreaRectangle, _StringFormat)
                        ' Increase the location where we can start, add a little interparagraph spacing.
                        yPos += textSize.Height ' + oPrintParagraps.TheFont.GetHeight(e.Graphics))

                    End If

                    ' See if some of the paragraph didn't fit on the page.
                    If charactersFitted < oPrintParagraps.Text.Length Then
                        ' Some of the paragraph didn't fit, prepare to print the rest on the next page.
                        oPrintParagraps.Text = oPrintParagraps.Text.Substring(charactersFitted)
                        invoiceParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (invoiceParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetInvoicePrintData()

        Dim padTotalAmount As Integer = 44
        Dim footerFont As New Font(printFontName, 9)
        Dim oVariousOptions As New VariousOptions()

        pageNo = 0
        invoiceParagraphs = New Collection()

        Try
            Dim countExtra As Integer
            Dim count As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            If oVariousOptions.CategorizeVisitInvoiceDetails Then

                Dim padItemNo As Integer = 4
                Dim padItemName As Integer = 20
                Dim padQuantity As Integer = 4
                Dim padUnitPrice As Integer = 14
                ' Dim padDiscount As Integer = 12
                Dim padAmount As Integer = 16
                ' Dim padTotalAmount As Integer = 56
                'Dim padAmountTendered As Integer = 53
                'Dim padBalance As Integer = 56

                Dim padCategoryName As Integer = 47
                Dim padCategoryAmount As Integer = 20



                'Dim tableHeader As New System.Text.StringBuilder(String.Empty)
                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Name: ".PadRight(padItemName))
                tableHeader.Append("Qty: ".PadLeft(padQuantity))
                tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                tableHeader.Append("Amount: ".PadLeft(padAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim ExtraBillInvoiceItems = From data In Me.GetExtraBillInvoiceItemsList Group data By CategoryName = data.Item1
                                     Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For Each item In ExtraBillInvoiceItems

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                    ' Dim categoryItemName As String = item.CategoryItemName
                    Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                    'tableData.Append(itemNo.PadRight(padItemNo))
                    tableData.Append(GetSpaces(padItemNo))
                    If categoryName.Length > 47 Then
                        tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName))
                    Else : tableData.Append(categoryName.PadRight(padItemName))
                    End If
                    ''tableData.Append(categoryAmount.PadLeft(padCategoryAmount + 30))
                    tableData.Append(ControlChars.NewLine)
                    tableData.Append(ControlChars.NewLine)

                    Dim categorizedExtraBillInvoiceItems = (From data In Me.GetCategorizedExtraBillInvoiceItemsList Group data By CategoryNameExtra = data.Item1, itemName = data.Item2, itemQuantity = data.Item3, itemUnitPrice = data.Item4,
                                    itemAmount = data.Item5 Into CategoryAmount2 = Sum(data.Item5) Select CategoryNameExtra, itemName, itemQuantity, itemUnitPrice, itemAmount Where
                                    CategoryNameExtra.ToUpper().Equals(FormatText(categoryName, "ItemCategory", "ItemCategory").ToUpper()) Or
                                    CategoryNameExtra.ToUpper().Equals(categoryName.ToUpper()))

                    For Each categorizedExtraBillInvoiceItem In categorizedExtraBillInvoiceItems
                        countExtra += 1
                        Dim categorizedItemNo As String = (countExtra).ToString()
                        Dim itemName As String = categorizedExtraBillInvoiceItem.itemName
                        Dim itemQuantity As String = FormatNumber(categorizedExtraBillInvoiceItem.itemQuantity, AppData.DecimalPlaces)
                        Dim ItemUnitPrice As String = FormatNumber(categorizedExtraBillInvoiceItem.itemUnitPrice, AppData.DecimalPlaces)
                        Dim itemAmount As String = FormatNumber(categorizedExtraBillInvoiceItem.itemAmount, AppData.DecimalPlaces)

                        tableData.Append(categorizedItemNo.PadRight(padItemNo))

                        Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                        If wrappeditemName.Count > 1 Then
                            For pos As Integer = 0 To wrappeditemName.Count - 1
                                tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                                If Not pos = wrappeditemName.Count - 1 Then
                                    tableData.Append(ControlChars.NewLine)
                                    tableData.Append(GetSpaces(padItemNo))
                                Else
                                    tableData.Append(itemQuantity.PadLeft(padQuantity))
                                    tableData.Append(ItemUnitPrice.PadLeft(padUnitPrice))
                                    tableData.Append(itemAmount.PadLeft(padAmount))
                                End If
                            Next

                        Else
                            tableData.Append(FixDataLength(itemName, padItemName))
                            tableData.Append(itemQuantity.PadLeft(padQuantity))
                            tableData.Append(ItemUnitPrice.PadLeft(padUnitPrice))

                            tableData.Append(itemAmount.PadLeft(padAmount))
                        End If
                        tableData.Append(ControlChars.NewLine)
                    Next
                    tableData.Append("SUB TOTAL".PadLeft(padItemName - 7))
                    'tableData.Append(categoryAmount.PadLeft(padAmount + 41))
                    tableData.Append(categoryAmount.PadLeft(padAmount + 29))
                    tableData.Append(ControlChars.NewLine)
                    tableData.Append(ControlChars.NewLine)
                    countExtra = 0
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            ElseIf oVariousOptions.CategorizeVisitInvoiceDetailsByItemCategory Then

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Category: ".PadRight(padItemName + 20))
                tableHeader.Append("Amount: ".PadLeft(padAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))
                'xaxaxa()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim invoiceDetails = From data In Me.GetExtraBillInvoiceItemsList Group data By CategoryName = data.Item1
                                     Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                'Dim invoiceDetailQuantities = From data In Me.GetInvoiceDetailsList Group data By CategoryName = data.Item1
                '                    Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''



                For Each item In invoiceDetails

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)

                    Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                    tableData.Append(itemNo.PadRight(padItemNo))

                    If categoryName.Length > 47 Then
                        tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName + 20))
                    Else : tableData.Append(categoryName.PadRight(padItemName + 20))
                    End If
                    tableData.Append(categoryAmount.PadLeft(padAmount))
                    tableData.Append(ControlChars.NewLine)

                Next
                invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''


            Else
                ' Dim tableHeader As New System.Text.StringBuilder(String.Empty)
                tableHeader.Append("Bill Date: ".PadRight(padItemNo))
                tableHeader.Append("Item Name: ".PadRight(padItemName))
                tableHeader.Append("Notes: ".PadRight(padNotes))
                tableHeader.Append("Qty: ".PadLeft(padQuantity))
                tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                tableHeader.Append("Amount: ".PadLeft(padAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.chkIncludeOPDBill.Checked Then invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.OPDBillData()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ExtraBillsData()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Me.chkIncludePendingBill.Checked Then invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.PendingBillData()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'If Me.dgvReturnedExtraBillItems.Rows.Count > 0 Then
                '    Dim returnsHeader As New System.Text.StringBuilder(String.Empty)
                '    returnsHeader.Append(ControlChars.NewLine)
                '    returnsHeader.Append("Returns: ")
                '    returnsHeader.Append(ControlChars.NewLine)
                '    invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, returnsHeader.ToString()))
                '    invoiceParagraphs.Add(New PrintParagraps(bodyNormalFont, Me.ReturnsBillData()))
                'End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End If

            Dim totalBillInvoice As Decimal
            Dim totalAmount As New System.Text.StringBuilder(String.Empty)

            If Me.chkIncludeOPDBill.Checked Then
                If Me.chkIncludePendingBill.Checked Then
                    totalBillInvoice = Me.GetOPDBillAmount() + Me.GetBillFormAmount() + Me.GetPendingBillAmount() - Me.GetReturnsBillAmount()
                Else
                    totalBillInvoice = Me.GetOPDBillAmount() + Me.GetBillFormAmount() - Me.GetReturnsBillAmount()
                End If

            Else
                If Me.chkIncludePendingBill.Checked Then
                    : totalBillInvoice = Me.GetBillFormAmount() + Me.GetPendingBillAmount() - Me.GetReturnsBillAmount()
                Else
                    : totalBillInvoice = Me.GetBillFormAmount() - Me.GetReturnsBillAmount()
                End If

            End If

            totalAmount.Append(ControlChars.NewLine)
            totalAmount.Append("Total Invoice Amount: " + GetSpaces(5))

            If oVariousOptions.CategorizeVisitInvoiceDetails Then
                totalAmount.Append(FormatNumber(totalBillInvoice).PadLeft(padAmount + 19))
            Else
                totalAmount.Append(FormatNumber(totalBillInvoice).PadLeft(padTotalAmount))
            End If
            totalAmount.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = NumberToWords(totalBillInvoice)
            amountWordsData.Append("(" + amountWords.Trim() + " ONLY)")
            amountWordsData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, amountWordsData.ToString()))

            Dim cashAccountBalance As Decimal = DecimalMayBeEnteredIn(Me.nbxCashAccountBalance, True)
            Dim cashAccountBalanceData As New System.Text.StringBuilder(String.Empty)
            cashAccountBalanceData.Append(ControlChars.NewLine)
            If cashAccountBalance < 0 Then
                cashAccountBalanceData.Append("Cash Account Balance (DR): ")
            Else : cashAccountBalanceData.Append("Cash Account Balance (CR): ")
            End If
            cashAccountBalanceData.Append(FormatNumber(cashAccountBalance, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            cashAccountBalanceData.Append(ControlChars.NewLine)

            Dim balanceDue As Decimal = totalBillInvoice - cashAccountBalance
            cashAccountBalanceData.Append("Balance Due: " + GetSpaces(14))
            cashAccountBalanceData.Append(FormatNumber(balanceDue, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            cashAccountBalanceData.Append(ControlChars.NewLine)

            If Not cashAccountBalance = 0 Then invoiceParagraphs.Add(New PrintParagraps(bodyBoldFont, cashAccountBalanceData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim patientSignData As New System.Text.StringBuilder(String.Empty)
            patientSignData.Append(ControlChars.NewLine)
            patientSignData.Append(ControlChars.NewLine)

            patientSignData.Append("Patient's Sign:   " + GetCharacters("."c, 20))
            patientSignData.Append(GetSpaces(4))
            patientSignData.Append("Date:  " + GetCharacters("."c, 20))
            patientSignData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, patientSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim checkedSignData As New System.Text.StringBuilder(String.Empty)
            checkedSignData.Append(ControlChars.NewLine)

            checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
            checkedSignData.Append(GetSpaces(4))
            checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
            checkedSignData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, checkedSignData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            invoiceParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetExtraBillInvoiceItemsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim invoiceDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvExtraBillsInvoice.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvExtraBillsInvoice.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colItemCategory.Name).Value.ToString()
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")

                invoiceDetails.Add(New Tuple(Of String, Decimal)(category, amount))

            Next

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkIncludeOPDBill.Checked Then

                For rowNo As Integer = 0 To Me.dgvOPDBillsInvoice.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvOPDBillsInvoice.Rows(rowNo).Cells
                    Dim category As String = cells.Item(Me.colOPDItemCategory.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colOPDAmount, False, "amount!")

                    invoiceDetails.Add(New Tuple(Of String, Decimal)(category, amount))

                Next

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkIncludePendingBill.Checked Then

                For rowNo As Integer = 0 To Me.dgvPendingBill.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvPendingBill.Rows(rowNo).Cells
                    Dim category As String = cells.Item(Me.colPendingBillCategory.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colPendingBillAmount, False, "amount!")

                    invoiceDetails.Add(New Tuple(Of String, Decimal)(category, amount))

                Next

            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return invoiceDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Function GetCategorizedExtraBillInvoiceItemsList() As List(Of Tuple(Of String, String, Integer, Decimal, Decimal))

        Try

            ' Create list of tuples with five items each.
            Dim invoiceDetailsExtra2 As New List(Of Tuple(Of String, String, Integer, Decimal, Decimal))

            For rowNo As Integer = 0 To Me.dgvExtraBillsInvoice.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvExtraBillsInvoice.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colItemCategory.Name).Value.ToString()
                Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                Dim quantity As Integer = IntegerEnteredIn(cells, Me.colQuantity, "quantity!")
                Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colUnitPrice, False, "unitPrice!")
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")

                invoiceDetailsExtra2.Add(New Tuple(Of String, String, Integer, Decimal, Decimal)(category, itemName, quantity, unitPrice, amount))

            Next
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkIncludeOPDBill.Checked Then

                For rowNo As Integer = 0 To Me.dgvOPDBillsInvoice.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvOPDBillsInvoice.Rows(rowNo).Cells
                    Dim category As String = cells.Item(Me.colOPDItemCategory.Name).Value.ToString()
                    Dim itemName As String = cells.Item(Me.colOPDItemName.Name).Value.ToString()
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colOPDQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colOPDUnitPrice, False, "unitPrice!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colOPDAmount, False, "amount!")

                    invoiceDetailsExtra2.Add(New Tuple(Of String, String, Integer, Decimal, Decimal)(category, itemName, quantity, unitPrice, amount))

                Next

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkIncludePendingBill.Checked Then

                For rowNo As Integer = 0 To Me.dgvPendingBill.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvPendingBill.Rows(rowNo).Cells
                    Dim category As String = cells.Item(Me.colPendingBillCategory.Name).Value.ToString()
                    Dim itemName As String = cells.Item(Me.colPendingBillItemName.Name).Value.ToString()
                    Dim quantity As Integer = IntegerEnteredIn(cells, Me.colPendingBillQuantity, "quantity!")
                    Dim unitPrice As Decimal = DecimalEnteredIn(cells, Me.colPendingBillUnitPrice, False, "unitPrice!")
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colPendingBillAmount, False, "amount!")

                    invoiceDetailsExtra2.Add(New Tuple(Of String, String, Integer, Decimal, Decimal)(category, itemName, quantity, unitPrice, amount))

                Next

            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Return invoiceDetailsExtra2

        Catch ex As Exception
            Throw ex
        End Try

    End Function


    Public Function ExtraBillsData() As String

        Dim oEntryModeID As New LookupDataID.EntryModeID()

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvExtraBillsInvoice.RowCount - 1

                If CBool(Me.dgvExtraBillsInvoice.Item(Me.colInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvExtraBillsInvoice.Rows(rowNo).Cells

                    Dim billDate As String = FormatDate(DateMayBeEnteredIn(cells, Me.colExtraBillDate), "dd MMM yy")

                    Dim itemName As String = StringMayBeEnteredIn(cells, Me.colItemName)
                    Dim quantity As String = StringMayBeEnteredIn(cells, Me.colQuantity)
                    Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colUnitPrice)
                    Dim amount As String = StringMayBeEnteredIn(cells, Me.colAmount)
                    Dim entryMode As String = StringMayBeEnteredIn(cells, Me.colEntryMode)
                    Dim notes As String = StringMayBeEnteredIn(cells, Me.colNotes)

                    tableData.Append(billDate.PadRight(padItemNo))
                    Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)

                    If wrappeditemName.Count > 1 Then
                        For pos As Integer = 0 To wrappeditemName.Count - 1
                            tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                            If Not pos = wrappeditemName.Count - 1 Then
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padItemNo))
                            Else
                                If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                                    If notes.Length > 14 Then
                                        tableData.Append(notes.Substring(0, 14).PadRight(padNotes))
                                    Else : tableData.Append(notes.PadRight(padNotes))
                                    End If
                                Else : tableData.Append(String.Empty.PadRight(padNotes))

                                End If

                                tableData.Append(quantity.PadLeft(padQuantity))
                                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                tableData.Append(amount.PadLeft(padAmount))

                            End If
                        Next
                    Else
                        tableData.Append(FixDataLength(itemName, padItemName))
                        If entryMode.ToUpper().Equals(GetLookupDataDes(oEntryModeID.Manual).ToUpper()) Then
                            If notes.Length > 14 Then
                                tableData.Append(notes.Substring(0, 14).PadRight(padNotes))
                            Else : tableData.Append(notes.PadRight(padNotes))
                            End If
                        Else : tableData.Append(String.Empty.PadRight(padNotes))
                        End If
                        tableData.Append(quantity.PadLeft(padQuantity))
                        tableData.Append(unitPrice.PadLeft(padUnitPrice))
                        tableData.Append(amount.PadLeft(padAmount))

                    End If
                    tableData.Append(ControlChars.NewLine)


                End If


            Next

            Return tableData.ToString()
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function OPDBillData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim visitDate As String = FormatDate(DateMayBeEnteredIn(Me.stbVisitDate), "dd MMM yy")

            For rowNo As Integer = 0 To Me.dgvOPDBillsInvoice.RowCount - 1

                If CBool(Me.dgvOPDBillsInvoice.Item(Me.colOPDInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvOPDBillsInvoice.Rows(rowNo).Cells

                    Dim itemName As String = StringMayBeEnteredIn(cells, Me.colOPDItemName)
                    Dim quantity As String = StringMayBeEnteredIn(cells, Me.colOPDQuantity)
                    Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colOPDUnitPrice)
                    Dim amount As String = StringMayBeEnteredIn(cells, Me.colOPDAmount)

                    tableData.Append(visitDate.PadRight(padItemNo))
                    Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                    If wrappeditemName.Count > 1 Then
                        For pos As Integer = 0 To wrappeditemName.Count - 1
                            tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                            If Not pos = wrappeditemName.Count - 1 Then
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padItemNo))
                            Else
                                tableData.Append(String.Empty.PadRight(padNotes))
                                tableData.Append(quantity.PadLeft(padQuantity))
                                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                tableData.Append(amount.PadLeft(padAmount))
                            End If
                        Next

                    Else
                        tableData.Append(FixDataLength(itemName, padItemName))
                        tableData.Append(String.Empty.PadRight(padNotes))
                        tableData.Append(quantity.PadLeft(padQuantity))
                        tableData.Append(unitPrice.PadLeft(padUnitPrice))
                        tableData.Append(amount.PadLeft(padAmount))
                    End If
                    tableData.Append(ControlChars.NewLine)
                End If

            Next

            Return tableData.ToString()

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function ReturnsBillData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvReturnedExtraBillItems.RowCount - 1

                If CBool(Me.dgvReturnedExtraBillItems.Item(Me.colReturnsInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvReturnedExtraBillItems.Rows(rowNo).Cells

                    Dim itemName As String = StringMayBeEnteredIn(cells, Me.colReturnsItemName)
                    Dim returnDate As String = FormatDate(DateMayBeEnteredIn(cells, Me.colReturnDate), "dd MMM yy")
                    Dim quantity As String = StringMayBeEnteredIn(cells, Me.colReturnsQuantity)
                    Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colReturnsUnitPrice)
                    Dim amount As String = StringMayBeEnteredIn(cells, Me.colReturnsAmount)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not String.IsNullOrEmpty(quantity) AndAlso Not quantity = "0" Then quantity = "-" + quantity
                    If Not String.IsNullOrEmpty(amount) AndAlso Not amount = "0" Then amount = "-" + amount
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    tableData.Append(returnDate.PadRight(padItemNo))
                    Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                    If wrappeditemName.Count > 1 Then
                        For pos As Integer = 0 To wrappeditemName.Count - 1
                            tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                            If Not pos = wrappeditemName.Count - 1 Then
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padItemNo))
                            Else
                                tableData.Append(String.Empty.PadRight(padNotes))
                                tableData.Append(quantity.PadLeft(padQuantity))
                                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                tableData.Append(amount.PadLeft(padAmount))
                            End If
                        Next

                    Else
                        tableData.Append(FixDataLength(itemName, padItemName))
                        tableData.Append(String.Empty.PadRight(padNotes))
                        tableData.Append(quantity.PadLeft(padQuantity))
                        tableData.Append(unitPrice.PadLeft(padUnitPrice))
                        tableData.Append(amount.PadLeft(padAmount))
                    End If
                    tableData.Append(ControlChars.NewLine)
                End If

            Next
            Return tableData.ToString()
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function PendingBillData() As String

        Try

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            Dim visitDate As String = FormatDate(DateMayBeEnteredIn(Me.stbVisitDate), "dd MMM yy")

            For rowNo As Integer = 0 To Me.dgvPendingBill.RowCount - 1

                If CBool(Me.dgvPendingBill.Item(Me.colPendingBillInclude.Name, rowNo).Value) = True Then

                    Dim cells As DataGridViewCellCollection = Me.dgvPendingBill.Rows(rowNo).Cells

                    Dim itemName As String = StringMayBeEnteredIn(cells, Me.colPendingBillItemName)
                    Dim quantity As String = StringMayBeEnteredIn(cells, Me.colPendingBillQuantity)
                    Dim unitPrice As String = StringMayBeEnteredIn(cells, Me.colPendingBillUnitPrice)
                    Dim amount As String = StringMayBeEnteredIn(cells, Me.colPendingBillAmount)

                    tableData.Append(visitDate.PadRight(padItemNo))
                    Dim wrappeditemName As List(Of String) = WrapText(itemName, padItemName)
                    If wrappeditemName.Count > 1 Then
                        For pos As Integer = 0 To wrappeditemName.Count - 1
                            tableData.Append(FixDataLength(wrappeditemName(pos).Trim(), padItemName))
                            If Not pos = wrappeditemName.Count - 1 Then
                                tableData.Append(ControlChars.NewLine)
                                tableData.Append(GetSpaces(padItemNo))
                            Else
                                tableData.Append(String.Empty.PadRight(padNotes))
                                tableData.Append(quantity.PadLeft(padQuantity))
                                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                                tableData.Append(amount.PadLeft(padAmount))
                            End If
                        Next

                    Else
                        tableData.Append(FixDataLength(itemName, padItemName))
                        tableData.Append(String.Empty.PadRight(padNotes))
                        tableData.Append(quantity.PadLeft(padQuantity))
                        tableData.Append(unitPrice.PadLeft(padUnitPrice))
                        tableData.Append(amount.PadLeft(padAmount))
                    End If
                    tableData.Append(ControlChars.NewLine)
                End If

            Next
            Return tableData.ToString()
        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region " Visits Navigate "

    Private Sub EnableNavigateVisitsCTLS(ByVal state As Boolean)

        Dim startPosition As Integer
        Dim oVisits As New SyncSoft.SQLDb.Visits()

        Try

            Me.Cursor = Cursors.WaitCursor

            If state Then

                Dim visitNo As String = RevertText(StringEnteredIn(Me.stbVisitNo, "Visit No!"))
                Dim patientNo As String = RevertText(StringEnteredIn(Me.stbPatientNo, "Patient No!"))

                Dim visits As DataTable = oVisits.GetVisitsByPatientNo(patientNo).Tables("Visits")

                For pos As Integer = 0 To visits.Rows.Count - 1
                    If visitNo.ToUpper().Equals(visits.Rows(pos).Item("VisitNo").ToString().ToUpper()) Then
                        startPosition = pos + 1
                        Exit For
                    Else : startPosition = 1
                    End If
                Next

                Me.navVisits.DataSource = visits
                Me.navVisits.Navigate(startPosition)

            Else : Me.navVisits.Clear()
            End If

        Catch eX As Exception
            Me.chkNavigateVisits.Checked = False
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub chkNavigateVisits_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNavigateVisits.Click
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Me.EnableNavigateVisitsCTLS(Me.chkNavigateVisits.Checked)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    End Sub

    Private Sub OnCurrentValue(ByVal currentValue As Object) Handles navVisits.OnCurrentValue

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(currentValue.ToString())
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If String.IsNullOrEmpty(visitNo) Then Return
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.LoadExtraBillInvoiceData(visitNo)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch eX As Exception
            ErrorMessage(eX)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

#Region " Invoice Details Extras "

    Private Sub cmsInvoiceDetails_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmsInvoiceDetails.Opening

        Select Case Me.tbcExtraBillsInvoice.SelectedTab.Name

            Case Me.tpgBillingForm.Name

                Me.cmsInvoiceDetailsEditBill.Visible = True
                Me.cmsInvoiceDetailsEditReturns.Visible = False

                If Me.dgvExtraBillsInvoice.ColumnCount < 1 OrElse Me.dgvExtraBillsInvoice.RowCount < 1 Then
                    Me.cmsInvoiceDetailsCopy.Enabled = False
                    Me.cmsInvoiceDetailsSelectAll.Enabled = False
                    Me.cmsInvoiceDetailsEditBill.Enabled = False
                    Me.cmsInvoiceDetailsEditReturns.Enabled = False
                Else
                    Me.cmsInvoiceDetailsCopy.Enabled = True
                    Me.cmsInvoiceDetailsSelectAll.Enabled = True
                    Me.cmsInvoiceDetailsEditBill.Enabled = True
                    Me.cmsInvoiceDetailsEditReturns.Enabled = True
                    Security.Apply(Me.cmsInvoiceDetails, AccessRights.Edit)
                End If

            Case Me.tpgOPDBill.Name

                Me.cmsInvoiceDetailsEditBill.Visible = False
                Me.cmsInvoiceDetailsEditReturns.Visible = False

                If Me.dgvOPDBillsInvoice.ColumnCount < 1 OrElse Me.dgvOPDBillsInvoice.RowCount < 1 Then
                    Me.cmsInvoiceDetailsCopy.Enabled = False
                    Me.cmsInvoiceDetailsSelectAll.Enabled = False
                    Me.cmsInvoiceDetailsEditBill.Enabled = False
                    Me.cmsInvoiceDetailsEditReturns.Enabled = False
                Else
                    Me.cmsInvoiceDetailsCopy.Enabled = True
                    Me.cmsInvoiceDetailsSelectAll.Enabled = True
                    Me.cmsInvoiceDetailsEditBill.Enabled = True
                    Me.cmsInvoiceDetailsEditReturns.Enabled = True
                    Security.Apply(Me.cmsInvoiceDetails, AccessRights.Edit)
                End If

            Case Me.tpgAdjustments.Name

                Me.cmsInvoiceDetailsEditBill.Visible = False
                Me.cmsInvoiceDetailsEditReturns.Visible = True

                If Me.dgvReturnedExtraBillItems.ColumnCount < 1 OrElse Me.dgvReturnedExtraBillItems.RowCount < 1 Then
                    Me.cmsInvoiceDetailsCopy.Enabled = False
                    Me.cmsInvoiceDetailsSelectAll.Enabled = False
                    Me.cmsInvoiceDetailsEditBill.Enabled = False
                    Me.cmsInvoiceDetailsEditReturns.Enabled = False
                Else
                    Me.cmsInvoiceDetailsCopy.Enabled = True
                    Me.cmsInvoiceDetailsSelectAll.Enabled = True
                    Me.cmsInvoiceDetailsEditBill.Enabled = True
                    Me.cmsInvoiceDetailsEditReturns.Enabled = True
                    Security.Apply(Me.cmsInvoiceDetails, AccessRights.Edit)
                End If

        End Select

    End Sub

    Private Sub cmsInvoiceDetailsCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsCopy.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcExtraBillsInvoice.SelectedTab.Name

                Case Me.tpgBillingForm.Name

                    If Me.dgvExtraBillsInvoice.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvExtraBillsInvoice))

                Case Me.tpgOPDBill.Name

                    If Me.dgvOPDBillsInvoice.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvOPDBillsInvoice))

                Case Me.tpgAdjustments.Name

                    If Me.dgvReturnedExtraBillItems.SelectedCells.Count < 1 Then Return
                    Clipboard.SetText(CopyFromControl(Me.dgvReturnedExtraBillItems))

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub cmsInvoiceDetailsSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsSelectAll.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            Select Case Me.tbcExtraBillsInvoice.SelectedTab.Name

                Case Me.tpgBillingForm.Name
                    Me.dgvExtraBillsInvoice.SelectAll()

                Case Me.tpgOPDBill.Name
                    Me.dgvOPDBillsInvoice.SelectAll()

                Case Me.tpgAdjustments.Name
                    Me.dgvReturnedExtraBillItems.SelectAll()

            End Select

        Catch ex As Exception
            Return

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    

    Private Sub cmsInvoiceDetailsEditReturns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmsInvoiceDetailsEditReturns.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim rowIndex As Integer = Me.dgvReturnedExtraBillItems.CurrentCell.RowIndex
            Dim extraBillNo As String = RevertText(StringMayBeEnteredIn(Me.dgvReturnedExtraBillItems.Rows(rowIndex).Cells, Me.colReturnsExtraBillNo))

            Dim fReturnedExtraBillItems As New frmBillAdjustments(extraBillNo)
            fReturnedExtraBillItems.ShowDialog()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
            Me.LoadExtraBillItems(visitNo)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#End Region

    Private Sub chkIncludePendingBill_CheckedChanged(sender As Object, e As EventArgs) Handles chkIncludePendingBill.CheckedChanged
        Dim visitNo As String = RevertText(StringMayBeEnteredIn(Me.stbVisitNo))
        If String.IsNullOrEmpty(visitNo) Then Return
        ResetControlsIn(Me.pnlNavigateVisits)
       
    End Sub

End Class