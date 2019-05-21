
Option Strict On
Option Infer On

Imports SyncSoft.Common.Methods
Imports SyncSoft.Common.Structures
Imports SyncSoft.Lookup.SQL.Methods
Imports SyncSoft.Common.SQL.Methods
Imports LookupDataID = SyncSoft.SQLDb.Lookup.LookupDataID
Imports LookupObjects = SyncSoft.SQLDb.Lookup.LookupObjects

Imports System.Drawing.Printing
Imports System.Collections.Generic

Public Class frmPrintCashReceipts

#Region " Fields "

    Private bPPayTypeID As String
    Private cBFPPayTypeID As String
    Private tipCoPayValueWords As New ToolTip()
    Private tipBFPCoPayValueWords As New ToolTip()
    Private cashierPrinterPaperSize As String = String.Empty
    Private CashIPDThermalReceiptParagraphs As Collection
    Private oVariousOptions As New VariousOptions()
    Private WithEvents docCashReceipt As New PrintDocument()
    Private WithEvents docCashThermalReceipt As New PrintDocument()
    Private WithEvents docIPDCashThermalReceipt As New PrintDocument()
    Private WithEvents docBillFormReceipt As New PrintDocument()
    Private WithEvents docBPReceipt As New PrintDocument()
    Private WithEvents docBPThermalReceipt As New PrintDocument()
    Private WithEvents docCBFPReceipt As New PrintDocument()
    Private WithEvents docCBFPThermalReceipt As New PrintDocument()
    Private WithEvents docAccounts As New PrintDocument()
    Private WithEvents docThermalAccounts As New PrintDocument()
    Private WithEvents docOtherIncome As New PrintDocument()
    Private WithEvents docRefunds As New PrintDocument()
    Private WithEvents docExpenditure As New PrintDocument()

    ' The paragraphs.
    Private CashThermalReceiptParagraphs As Collection
    Private cashParagraphs As Collection
    Private billFormParagraphs As Collection
    Private bPParagraphs As Collection
    Private bPThermalParagraphs As Collection
    Private cBFPParagraphs As Collection
    Private CBFPThermalParagraphs As Collection
    Private pageNo As Integer
    Private printFontName As String = "Courier New"
    Private bodyBoldFont As New Font(printFontName, 10, FontStyle.Bold)
    Private bodyNormalFont As New Font(printFontName, 10)

#End Region

    Private Sub frmPrintCashReceipts_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.SetDefaultPrinter()
    End Sub
  
    Private Sub frmPrintCashReceipts_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub stbReceiptNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbReceiptNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbBFPReceiptNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbBFPReceiptNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbBPReceiptNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbBPReceiptNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbCBFPReceiptNo_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbCBFPReceiptNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbAccountTranNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbAccountTranNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbIncomeNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbIncomeNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbRefundNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbRefundNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub stbExpenditureNo_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles stbExpenditureNo.KeyDown
        If e.KeyCode = Keys.Enter Then Me.ProcessTabKey(True)
    End Sub

    Private Sub ClearCashPaymentControls()

        Me.stbFullName.Clear()
        Me.stbPatientNo.Clear()
        Me.stbVisitDate.Clear()
        Me.stbVisitNo.Clear()
        Me.stbPayDate.Clear()
        Me.stbPayModes.Clear()
        Me.stbCoPayType.Clear()
        Me.chkSendBalanceToAccount.Checked = False
        Me.chkUseAccountBalance.Checked = False
        Me.nbxCoPayPercent.Value = String.Empty
        Me.nbxCoPayValue.Value = String.Empty
        Me.tipCoPayValueWords.RemoveAll()
        Me.stbDocumentNo.Clear()
        Me.stbNotes.Clear()
        Me.stbTotalAmountPaid.Clear()
        Me.nbxAmountTendered.Value = String.Empty
        Me.nbxExchangeRate.Value = String.Empty
        Me.nbxCashPaymentAmountRefunded.Value = String.Empty
        Me.stbChange.Clear()
        Me.stbAmountWords.Clear()
        Me.stbCurrency.Clear()
        Me.dgvPaymentDetails.Rows.Clear()

    End Sub

    Private Sub ClearBillFormPaymentControls()

        Me.stbBFPFullName.Clear()
        Me.stbBFPPatientNo.Clear()
        Me.stbBFPVisitDate.Clear()
        Me.stbBFPVisitNo.Clear()
        Me.stbBFPPayDate.Clear()
        Me.stbBFPPayModes.Clear()
        Me.stbBFPCoPayType.Clear()
        Me.chkBFPSendBalanceToAccount.Checked = False
        Me.chkBFPUseAccountBalance.Checked = False
        Me.nbxBFPCoPayPercent.Value = String.Empty
        Me.nbxBFPCoPayValue.Value = String.Empty
        Me.tipBFPCoPayValueWords.RemoveAll()
        Me.stbBFPDocumentNo.Clear()
        Me.stbBFPNotes.Clear()
        Me.stbBFPTotalAmountPaid.Clear()
        Me.nbxBFPAmountTendered.Value = String.Empty
        Me.nbxBFPExchangeRate.Value = String.Empty
        Me.nbxBillFormAmountRefunded.Value = String.Empty
        Me.stbBFPChange.Clear()
        Me.stbBFPAmountWords.Clear()
        Me.stbBFPCurrency.Clear()
        Me.dgvPaymentExtraBillItems.Rows.Clear()

    End Sub

    Private Sub ClearBillsPaymentControls()

        bPPayTypeID = String.Empty
        Me.stbBPPayType.Clear()
        Me.stbBPBillCustomerName.Clear()
        Me.stbBPBillAccountNo.Clear()
        Me.stbBPPayDate.Clear()
        Me.stbBPPayModes.Clear()
        Me.chkBPSendBalanceToAccount.Checked = False
        Me.chkBPUseAccountBalance.Checked = False
        Me.stbBPDocumentNo.Clear()
        Me.stbBPNotes.Clear()
        Me.stbBPTotalBill.Clear()
        Me.nbxBPAmountTendered.Value = String.Empty
        Me.nbxBPExchangeRate.Value = String.Empty
        Me.stbBPChange.Clear()
        Me.stbBPAmountWords.Clear()
        Me.stbBPCurrency.Clear()
        Me.dgvBillsPaymentDetails.Rows.Clear()

    End Sub

    Private Sub ClearCreditBillFormPaymentControls()

        cBFPPayTypeID = String.Empty
        Me.stbCBFPPayType.Clear()
        Me.stbCBFPBillCustomerName.Clear()
        Me.stbCBFPBillAccountNo.Clear()
        Me.stbCBFPPayDate.Clear()
        Me.stbCBFPPayModes.Clear()
        Me.chkCBFPSendBalanceToAccount.Checked = False
        Me.chkCBFPUseAccountBalance.Checked = False
        Me.stbCBFPDocumentNo.Clear()
        Me.stbCBFPNotes.Clear()
        Me.stbCBFPTotalBill.Clear()
        Me.nbxCBFPAmountTendered.Value = String.Empty
        Me.nbxCBFPExchangeRate.Value = String.Empty
        Me.stbCBFPChange.Clear()
        Me.stbCBFPAmountWords.Clear()
        Me.stbCBFPCurrency.Clear()
        Me.dgvCreditBillFormPaymentDetails.Rows.Clear()

    End Sub

    Private Sub ClearManageAccountsControls()

        Me.stbTransactionDate.Clear()
        Me.stbBillModes.Clear()
        Me.stbAccountNo.Clear()
        Me.stbAccountName.Clear()
        Me.stbAccountPayModes.Clear()
        Me.stbAccountAction.Clear()
        Me.stbAccountCurrency.Clear()
        Me.nbxAccountAmountTendered.Value = String.Empty
        Me.nbxAccountExchangeRate.Value = String.Empty
        Me.nbxAccountAmount.Value = String.Empty
        Me.stbAccountChange.Clear()
        Me.stbAccountDocumentNo.Clear()
        Me.stbAccountNotes.Clear()

    End Sub

    Private Sub ClearOtherIncomeControls()

        Me.stbIncomeDate.Clear()
        Me.stbIncomeSources.Clear()
        Me.stbOIPayModes.Clear()
        Me.stbOICurrency.Clear()
        Me.nbxOIAmountTendered.Value = String.Empty
        Me.nbxOIExchangeRate.Value = String.Empty
        Me.nbxOIAmount.Value = String.Empty
        Me.stbOIChange.Clear()
        Me.stbOIDocumentNo.Clear()
        Me.stbOINotes.Clear()

    End Sub

    Private Sub ClearRefundsControls()

        Me.stbRefundDate.Clear()
        Me.nbxRefundAmount.Value = String.Empty
        Me.stbRefundAmountWords.Clear()
        Me.stbRefundReceiptNo.Clear()
        Me.stbPayeeName.Clear()
        Me.stbRefundPayDate.Clear()
        Me.stbRefundAmountPaid.Clear()
        Me.stbRefundNotes.Clear()

    End Sub

    Private Sub ClearExpenditureControls()

        Me.stbSpentDate.Clear()
        Me.stbExpenditureCategory.Clear()
        Me.stbGivenTo.Clear()
        Me.nbxEXAmount.Value = String.Empty
        Me.stbEXDetails.Clear()

    End Sub

    Private Sub stbReceiptNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbReceiptNo.TextChanged
        Me.ClearCashPaymentControls()
    End Sub

    Private Sub stbBFPReceiptNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbBFPReceiptNo.TextChanged
        Me.ClearBillFormPaymentControls()
    End Sub

    Private Sub stbBPReceiptNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbBPReceiptNo.TextChanged
        Me.ClearBillsPaymentControls()
    End Sub

    Private Sub stbCBFPReceiptNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbCBFPReceiptNo.TextChanged
        Me.ClearCreditBillFormPaymentControls()
    End Sub

    Private Sub stbAccountTranNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbAccountTranNo.TextChanged
        Me.ClearManageAccountsControls()
    End Sub

    Private Sub stbIncomeNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbIncomeNo.TextChanged
        Me.ClearOtherIncomeControls()
    End Sub

    Private Sub stbRefundNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbRefundNo.TextChanged
        Me.ClearRefundsControls()
    End Sub

    Private Sub stbExpenditureNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stbExpenditureNo.TextChanged
        Me.ClearExpenditureControls()
    End Sub

    Private Sub stbReceiptNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbReceiptNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ShowCashPaymentData()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub SetDefaultPrinter()

        Try
            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not String.IsNullOrEmpty(InitOptions.CashierPrinterPaperSize) Then
                Me.cashierPrinterPaperSize = GetLookupDataDes(GetLookupDataID(LookupObjects.PrinterPaperSize, InitOptions.CashierPrinterPaperSize))
                'DisplayMessage(pharmacyPrinterPaperSize)
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Catch ex As Exception
            ErrorMessage(ex)
        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub


    Private Sub ShowCashPaymentData()

        Try

            Dim receiptNo As String = RevertText(StringMayBeEnteredIn(Me.stbReceiptNo))
            If String.IsNullOrEmpty(receiptNo) Then Return

            Me.ClearCashPaymentControls()
            Me.LoadCashPayment(receiptNo)
            Me.LoadCashPaymentDetails(receiptNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbBFPReceiptNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbBFPReceiptNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ShowBillFormPaymentData()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowBillFormPaymentData()

        Try

            Dim receiptNo As String = RevertText(StringMayBeEnteredIn(Me.stbBFPReceiptNo))
            If String.IsNullOrEmpty(receiptNo) Then Return

            Me.ClearBillFormPaymentControls()
            Me.LoadBillFormPayment(receiptNo)
            Me.LoadPaymentExtraBillItems(receiptNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbBPReceiptNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbBPReceiptNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ShowBillsPaymentData()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowBillsPaymentData()

        Try

            Dim receiptNo As String = RevertText(StringMayBeEnteredIn(Me.stbBPReceiptNo))
            If String.IsNullOrEmpty(receiptNo) Then Return

            Me.ClearBillsPaymentControls()
            Me.LoadBillsPayment(receiptNo)
            Me.LoadBillsPaymentDetails(receiptNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbCBFPReceiptNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbCBFPReceiptNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ShowCreditBillFormPaymentData()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowCreditBillFormPaymentData()

        Try

            Dim receiptNo As String = RevertText(StringMayBeEnteredIn(Me.stbCBFPReceiptNo))
            If String.IsNullOrEmpty(receiptNo) Then Return

            Me.ClearCreditBillFormPaymentControls()
            Me.LoadCreditBillFormPayment(receiptNo)
            Me.LoadBillsPaymentExtraBillItems(receiptNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbAccountTranNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbAccountTranNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ShowAccountsData()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowAccountsData()

        Try

            Dim transactionNo As String = RevertText(StringMayBeEnteredIn(Me.stbAccountTranNo))
            If String.IsNullOrEmpty(transactionNo) Then Return

            Me.ClearManageAccountsControls()
            Me.LoadAccounts(transactionNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbIncomeNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbIncomeNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ShowOtherIncomeData()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowOtherIncomeData()

        Try

            Dim incomeNo As String = RevertText(StringMayBeEnteredIn(Me.stbIncomeNo))
            If String.IsNullOrEmpty(incomeNo) Then Return

            Me.ClearOtherIncomeControls()
            Me.LoadOtherIncome(incomeNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbRefundNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbRefundNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ShowRefundsData()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowRefundsData()

        Try

            Dim refundNo As String = RevertText(StringMayBeEnteredIn(Me.stbRefundNo))
            If String.IsNullOrEmpty(refundNo) Then Return

            Me.ClearRefundsControls()
            Me.LoadRefunds(refundNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub stbExpenditureNo_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles stbExpenditureNo.Leave

        Try

            Me.Cursor = Cursors.WaitCursor

            Me.ShowExpenditureData()

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub ShowExpenditureData()

        Try

            Dim expenditureNo As String = RevertText(StringMayBeEnteredIn(Me.stbExpenditureNo))
            If String.IsNullOrEmpty(expenditureNo) Then Return

            Me.ClearExpenditureControls()
            Me.LoadExpenditure(expenditureNo)

        Catch ex As Exception
            ErrorMessage(ex)

        End Try

    End Sub

    Private Sub btnLoadCashPayments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadCashPayments.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oPayTypeID As New LookupDataID.PayTypeID()
            Dim fCashReceipts As New frmCashReceipts(Me.stbReceiptNo, oPayTypeID.VisitBill)
            fCashReceipts.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowCashPaymentData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadBillFormPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadBillFormPayment.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oPayTypeID As New LookupDataID.PayTypeID()
            Dim fCashReceipts As New frmCashReceipts(Me.stbBFPReceiptNo, oPayTypeID.ExtraBill)
            fCashReceipts.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowBillFormPaymentData()

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadBillsPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadBillsPayment.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oVisitTypeID As New LookupDataID.VisitTypeID()
            Dim fBillsPaymentReceipts As New frmBillsPaymentReceipts(Me.stbBPReceiptNo, oVisitTypeID.OutPatient)
            fBillsPaymentReceipts.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowBillsPaymentData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadCreditBillFormPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadCreditBillFormPayment.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oVisitTypeID As New LookupDataID.VisitTypeID()
            Dim fBillsPaymentReceipts As New frmBillsPaymentReceipts(Me.stbCBFPReceiptNo, oVisitTypeID.InPatient)
            fBillsPaymentReceipts.ShowDialog(Me)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowCreditBillFormPaymentData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadManageAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadManageAccounts.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fAccountsReceipts As New frmAccountsReceipts(Me.stbAccountTranNo)
            fAccountsReceipts.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowAccountsData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadOtherIncome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadOtherIncome.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fOtherIncomeReceipts As New frmOtherIncomeReceipts(Me.stbIncomeNo)
            fOtherIncomeReceipts.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowOtherIncomeData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadRefunds_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadRefunds.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fRefundsReceipts As New frmRefundsReceipts(Me.stbRefundNo)
            fRefundsReceipts.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowRefundsData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub btnLoadExpenditure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadExpenditure.Click

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim fExpenditureReceipts As New frmExpenditureReceipts(Me.stbExpenditureNo)
            fExpenditureReceipts.ShowDialog(Me)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.ShowExpenditureData()
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCashPayment(ByVal receiptNo As String)

        Dim oPayments As New SyncSoft.SQLDb.Payments()

        Try

            Dim payments As DataTable = oPayments.GetCashPayments(receiptNo).Tables("Payments")
            Dim row As DataRow = payments.Rows(0)

            Dim patientNo As String = RevertText(StringEnteredIn(row, "PatientNo"))
            Dim visitNo As String = RevertText(StringEnteredIn(row, "VisitNo"))

            Me.stbReceiptNo.Text = FormatText(receiptNo, "Payments", "ReceiptNo")

            Me.stbFullName.Text = StringEnteredIn(row, "ClientFullName")
            Me.stbPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbPayDate.Text = FormatDate(DateEnteredIn(row, "PayDate"))
            Me.stbPayModes.Text = StringEnteredIn(row, "PayModes")
            Me.chkSendBalanceToAccount.Checked = BooleanMayBeEnteredIn(row, "SendBalanceToAccount")
            Me.chkUseAccountBalance.Checked = BooleanMayBeEnteredIn(row, "UseAccountBalance")
            Me.stbCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipCoPayValueWords.SetToolTip(Me.nbxCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Me.stbDocumentNo.Text = StringMayBeEnteredIn(row, "DocumentNo")
            Me.stbNotes.Text = StringMayBeEnteredIn(row, "Notes")
            Me.stbTotalAmountPaid.Text = FormatNumber(DecimalMayBeEnteredIn(row, "AmountPaid"), AppData.DecimalPlaces)
            Me.nbxAmountTendered.Value = FormatNumber(DecimalMayBeEnteredIn(row, "AmountTendered"), AppData.DecimalPlaces)
            Me.nbxExchangeRate.Text = FormatNumber(DecimalMayBeEnteredIn(row, "ExchangeRate"), AppData.DecimalPlaces)
            Me.stbChange.Text = FormatNumber(DecimalMayBeEnteredIn(row, "Change"), AppData.DecimalPlaces)
            Me.stbAmountWords.Text = StringMayBeEnteredIn(row, "AmountWords")
            Me.stbCurrency.Text = StringMayBeEnteredIn(row, "Currency")
            Me.nbxCashPaymentAmountRefunded.Value = FormatNumber(DecimalMayBeEnteredIn(row, "AmountRefunded"), AppData.DecimalPlaces)

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadCashPaymentDetails(ByVal receiptNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPaymentDetails As New SyncSoft.SQLDb.PaymentDetails()
            Me.dgvPaymentDetails.Rows.Clear()

            Dim paymentDetails As DataTable = oPaymentDetails.GetPaymentDetails(receiptNo).Tables("PaymentDetails")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPaymentDetails, paymentDetails)
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBillFormPayment(ByVal receiptNo As String)

        Dim oPayments As New SyncSoft.SQLDb.Payments()

        Try

            Dim payments As DataTable = oPayments.GetBillFormPayment(receiptNo).Tables("Payments")
            Dim row As DataRow = payments.Rows(0)

            Dim patientNo As String = RevertText(StringEnteredIn(row, "PatientNo"))
            Dim visitNo As String = RevertText(StringEnteredIn(row, "VisitNo"))

            Me.stbBFPReceiptNo.Text = FormatText(receiptNo, "Payments", "ReceiptNo")

            Me.stbBFPFullName.Text = StringEnteredIn(row, "FullName")
            Me.stbBFPPatientNo.Text = FormatText(patientNo, "Patients", "PatientNo")
            Me.stbBFPVisitDate.Text = FormatDate(DateEnteredIn(row, "VisitDate"))
            Me.stbBFPVisitNo.Text = FormatText(visitNo, "Visits", "VisitNo")
            Me.stbBFPPayDate.Text = FormatDate(DateEnteredIn(row, "PayDate"))
            Me.stbBFPPayModes.Text = StringEnteredIn(row, "PayModes")
            Me.chkBFPSendBalanceToAccount.Checked = BooleanMayBeEnteredIn(row, "SendBalanceToAccount")
            Me.chkBFPUseAccountBalance.Checked = BooleanMayBeEnteredIn(row, "UseAccountBalance")
            Me.stbBFPCoPayType.Text = StringMayBeEnteredIn(row, "CoPayType")
            Me.nbxBFPCoPayPercent.Value = SingleMayBeEnteredIn(row, "CoPayPercent").ToString()
            Me.nbxBFPCoPayValue.Value = FormatNumber(DecimalMayBeEnteredIn(row, "CoPayValue"), AppData.DecimalPlaces)
            Me.tipBFPCoPayValueWords.SetToolTip(Me.nbxBFPCoPayValue, NumberToWords(DecimalMayBeEnteredIn(row, "CoPayValue")))
            Me.stbBFPDocumentNo.Text = StringMayBeEnteredIn(row, "DocumentNo")
            Me.stbBFPNotes.Text = StringMayBeEnteredIn(row, "Notes")
            Me.stbBFPTotalAmountPaid.Text = FormatNumber(DecimalMayBeEnteredIn(row, "AmountPaid"), AppData.DecimalPlaces)
            Me.nbxBFPAmountTendered.Value = FormatNumber(DecimalMayBeEnteredIn(row, "AmountTendered"), AppData.DecimalPlaces)
            Me.nbxBFPExchangeRate.Text = FormatNumber(DecimalMayBeEnteredIn(row, "ExchangeRate"), AppData.DecimalPlaces)
            Me.stbBFPChange.Text = FormatNumber(DecimalMayBeEnteredIn(row, "Change"), AppData.DecimalPlaces)
            Me.stbBFPAmountWords.Text = StringMayBeEnteredIn(row, "AmountWords")
            Me.stbBFPCurrency.Text = StringMayBeEnteredIn(row, "Currency")
            Me.nbxBillFormAmountRefunded.Value = FormatNumber(DecimalMayBeEnteredIn(row, "AmountRefunded"), AppData.DecimalPlaces)

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadPaymentExtraBillItems(ByVal receiptNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPaymentExtraBillItems As New SyncSoft.SQLDb.PaymentExtraBillItems()
            Me.dgvPaymentExtraBillItems.Rows.Clear()

            Dim paymentExtraBillItems As DataTable = oPaymentExtraBillItems.GetPaymentExtraBillItems(receiptNo).Tables("PaymentExtraBillItems")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvPaymentExtraBillItems, paymentExtraBillItems)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadBillsPayment(ByVal receiptNo As String)

        Dim fullName As String = String.Empty
        Dim oPayTypeID As New LookupDataID.PayTypeID()
        Dim oPayments As New SyncSoft.SQLDb.Payments()

        Try

            Dim payments As DataTable = oPayments.GetBillsPayment(receiptNo).Tables("Payments")
            Dim row As DataRow = payments.Rows(0)

            Dim payNo As String = RevertText(StringEnteredIn(row, "PayNo"))
            Dim billCustomerName As String = StringEnteredIn(row, "BillCustomerName")

            Dim filterNo As String = RevertText(StringMayBeEnteredIn(row, "FilterNo"))
            If String.IsNullOrEmpty(filterNo) Then
                fullName = String.Empty
            Else : fullName = GetPatientFullName(filterNo)
            End If

            Me.stbBPReceiptNo.Text = FormatText(receiptNo, "Payments", "ReceiptNo")

            If String.IsNullOrEmpty(fullName) Then
                Me.stbBPBillCustomerName.Text = billCustomerName
            Else : Me.stbBPBillCustomerName.Text = billCustomerName + " (" + fullName + ")"
            End If

            Me.stbBPPayType.Text = StringEnteredIn(row, "PayType")
            bPPayTypeID = StringEnteredIn(row, "PayTypeID")

            If bPPayTypeID.ToUpper().Equals(oPayTypeID.InsuranceBill.ToUpper()) Then
                Me.lblBPBillAccountNo.Text = "To-Bill Insurance Number"
                Me.lblBPBillCustomerName.Text = "To-Bill Insurance Name"
                Me.stbBPBillAccountNo.Text = FormatText(payNo, "Insurances", "InsuranceNo").ToUpper()
            Else
                Me.lblBPBillAccountNo.Text = "To-Bill Account Number"
                Me.lblBPBillCustomerName.Text = "To-Bill Customer Name"
                Me.stbBPBillAccountNo.Text = FormatText(payNo, "BillCustomers", "AccountNo").ToUpper()
            End If

            Me.stbBPPayDate.Text = FormatDate(DateEnteredIn(row, "PayDate"))
            Me.stbBPPayModes.Text = StringEnteredIn(row, "PayModes")
            Me.chkBPSendBalanceToAccount.Checked = BooleanMayBeEnteredIn(row, "SendBalanceToAccount")
            Me.chkBPUseAccountBalance.Checked = BooleanMayBeEnteredIn(row, "UseAccountBalance")
            Me.stbBPDocumentNo.Text = StringMayBeEnteredIn(row, "DocumentNo")
            Me.stbBPNotes.Text = StringMayBeEnteredIn(row, "Notes")
            Me.stbBPTotalBill.Text = FormatNumber(DecimalMayBeEnteredIn(row, "AmountPaid"), AppData.DecimalPlaces)
            Me.nbxBPWithholdingTax.Value = FormatNumber(DecimalMayBeEnteredIn(row, "WithholdingTax"), AppData.DecimalPlaces)
            Me.nbxBPGrandDiscount.Value = FormatNumber(DecimalMayBeEnteredIn(row, "GrandDiscount"), AppData.DecimalPlaces)
            Me.nbxBPAmountTendered.Value = FormatNumber(DecimalMayBeEnteredIn(row, "AmountTendered"), AppData.DecimalPlaces)
            Me.nbxBPExchangeRate.Text = FormatNumber(DecimalMayBeEnteredIn(row, "ExchangeRate"), AppData.DecimalPlaces)
            Me.stbBPChange.Text = FormatNumber(DecimalMayBeEnteredIn(row, "Change"), AppData.DecimalPlaces)
            Me.stbBPAmountWords.Text = StringMayBeEnteredIn(row, "AmountWords")
            Me.stbBPCurrency.Text = StringMayBeEnteredIn(row, "Currency")

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadBillsPaymentDetails(ByVal receiptNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPaymentDetails As New SyncSoft.SQLDb.PaymentDetails()
            Me.dgvBillsPaymentDetails.Rows.Clear()
            Dim paymentDetails As DataTable = oPaymentDetails.GetPaymentDetails(receiptNo).Tables("PaymentDetails")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvBillsPaymentDetails, paymentDetails)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadCreditBillFormPayment(ByVal receiptNo As String)

        Dim fullName As String = String.Empty
        Dim oPayTypeID As New LookupDataID.PayTypeID()
        Dim oPayments As New SyncSoft.SQLDb.Payments()

        Try

            Dim payments As DataTable = oPayments.GetCreditBillFormPayment(receiptNo).Tables("Payments")
            Dim row As DataRow = payments.Rows(0)

            Dim payNo As String = RevertText(StringEnteredIn(row, "PayNo"))
            Dim billCustomerName As String = StringEnteredIn(row, "BillCustomerName")

            Dim filterNo As String = RevertText(StringMayBeEnteredIn(row, "FilterNo"))
            If String.IsNullOrEmpty(filterNo) Then
                fullName = String.Empty
            Else : fullName = GetPatientFullName(filterNo)
            End If

            Me.stbCBFPReceiptNo.Text = FormatText(receiptNo, "Payments", "ReceiptNo")

            If String.IsNullOrEmpty(fullName) Then
                Me.stbCBFPBillCustomerName.Text = billCustomerName
            Else : Me.stbCBFPBillCustomerName.Text = billCustomerName + " (" + fullName + ")"
            End If

            Me.stbCBFPPayType.Text = StringEnteredIn(row, "PayType")
            cBFPPayTypeID = StringEnteredIn(row, "PayTypeID")

            If cBFPPayTypeID.ToUpper().Equals(oPayTypeID.InsuranceBill.ToUpper()) Then
                Me.lblCBFPBillAccountNo.Text = "To-Bill Insurance Number"
                Me.lblCBFPBillCustomerName.Text = "To-Bill Insurance Name"
                Me.stbCBFPBillAccountNo.Text = FormatText(payNo, "Insurances", "InsuranceNo").ToUpper()
            Else
                Me.lblCBFPBillAccountNo.Text = "To-Bill Account Number"
                Me.lblCBFPBillCustomerName.Text = "To-Bill Customer Name"
                Me.stbCBFPBillAccountNo.Text = FormatText(payNo, "BillCustomers", "AccountNo").ToUpper()
            End If

            Me.stbCBFPPayDate.Text = FormatDate(DateEnteredIn(row, "PayDate"))
            Me.stbCBFPPayModes.Text = StringEnteredIn(row, "PayModes")
            Me.chkCBFPSendBalanceToAccount.Checked = BooleanMayBeEnteredIn(row, "SendBalanceToAccount")
            Me.chkCBFPUseAccountBalance.Checked = BooleanMayBeEnteredIn(row, "UseAccountBalance")
            Me.stbCBFPDocumentNo.Text = StringMayBeEnteredIn(row, "DocumentNo")
            Me.stbCBFPNotes.Text = StringMayBeEnteredIn(row, "Notes")
            Me.stbCBFPTotalBill.Text = FormatNumber(DecimalMayBeEnteredIn(row, "AmountPaid"), AppData.DecimalPlaces)
            Me.nbxCBFPWithholdingTax.Value = FormatNumber(DecimalMayBeEnteredIn(row, "WithholdingTax"), AppData.DecimalPlaces)
            Me.nbxCBFPGrandDiscount.Value = FormatNumber(DecimalMayBeEnteredIn(row, "GrandDiscount"), AppData.DecimalPlaces)
            Me.nbxCBFPAmountTendered.Value = FormatNumber(DecimalMayBeEnteredIn(row, "AmountTendered"), AppData.DecimalPlaces)
            Me.nbxCBFPExchangeRate.Text = FormatNumber(DecimalMayBeEnteredIn(row, "ExchangeRate"), AppData.DecimalPlaces)
            Me.stbCBFPChange.Text = FormatNumber(DecimalMayBeEnteredIn(row, "Change"), AppData.DecimalPlaces)
            Me.stbCBFPAmountWords.Text = StringMayBeEnteredIn(row, "AmountWords")
            Me.stbCBFPCurrency.Text = StringMayBeEnteredIn(row, "Currency")

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadBillsPaymentExtraBillItems(ByVal receiptNo As String)

        Try

            Me.Cursor = Cursors.WaitCursor

            Dim oPaymentExtraBillItems As New SyncSoft.SQLDb.PaymentExtraBillItems()
            Me.dgvCreditBillFormPaymentDetails.Rows.Clear()
            Dim paymentExtraBillItems As DataTable = oPaymentExtraBillItems.GetPaymentExtraBillItems(receiptNo).Tables("PaymentExtraBillItems")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            LoadGridData(Me.dgvCreditBillFormPaymentDetails, paymentExtraBillItems)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

    Private Sub LoadAccounts(ByVal tranNo As String)

        Dim oAccounts As New SyncSoft.SQLDb.Accounts()

        Try

            Dim accounts As DataTable = oAccounts.GetAccounts(tranNo).Tables("Accounts")
            Dim row As DataRow = accounts.Rows(0)

            Me.stbAccountTranNo.Text = FormatText(tranNo, "Accounts", "TranNo")

            Me.stbTransactionDate.Text = FormatDate(DateEnteredIn(row, "TranDate"))
            Me.stbBillModes.Text = StringMayBeEnteredIn(row, "AccountCategory")
            Me.stbAccountNo.Text = StringMayBeEnteredIn(row, "AccountBillNo")
            Me.stbAccountName.Text = StringMayBeEnteredIn(row, "AccountName")
            Me.stbAccountPayModes.Text = StringMayBeEnteredIn(row, "PayModes")
            Me.stbAccountAction.Text = StringMayBeEnteredIn(row, "AccountAction")
            Me.stbAccountCurrency.Text = StringMayBeEnteredIn(row, "Currency")
            Me.nbxAccountAmountTendered.Value = FormatNumber(DecimalMayBeEnteredIn(row, "AmountTendered"), AppData.DecimalPlaces)
            Me.nbxAccountExchangeRate.Value = FormatNumber(DecimalMayBeEnteredIn(row, "ExchangeRate"), AppData.DecimalPlaces)
            Me.nbxAccountAmount.Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount"), AppData.DecimalPlaces)
            Me.stbAccountChange.Text = FormatNumber(DecimalMayBeEnteredIn(row, "Change"), AppData.DecimalPlaces)
            Me.stbAccountDocumentNo.Text = StringMayBeEnteredIn(row, "DocumentNo")
            Me.stbAccountGroup.Text = StringMayBeEnteredIn(row, "AccountGroup")
            Me.stbAccountNotes.Text = StringMayBeEnteredIn(row, "Notes")

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadOtherIncome(ByVal incomeNo As String)

        Dim oOtherIncome As New SyncSoft.SQLDb.OtherIncome()

        Try

            Dim otherIncome As DataTable = oOtherIncome.GetOtherIncome(incomeNo).Tables("OtherIncome")
            Dim row As DataRow = otherIncome.Rows(0)

            Me.stbIncomeNo.Text = FormatText(incomeNo, "OtherIncome", "IncomeNo")
            Me.stbIncomeDate.Text = FormatDate(DateEnteredIn(row, "IncomeDate"))
            Me.stbIncomeSources.Text = StringMayBeEnteredIn(row, "IncomeSource")
            Me.stbOIPayModes.Text = StringMayBeEnteredIn(row, "PayModes")
            Me.stbOICurrency.Text = StringMayBeEnteredIn(row, "Currency")
            Me.nbxOIAmountTendered.Value = FormatNumber(DecimalMayBeEnteredIn(row, "AmountTendered"), AppData.DecimalPlaces)
            Me.nbxOIExchangeRate.Value = FormatNumber(DecimalMayBeEnteredIn(row, "ExchangeRate"), AppData.DecimalPlaces)
            Me.nbxOIAmount.Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount"), AppData.DecimalPlaces)
            Me.stbOIChange.Text = FormatNumber(DecimalMayBeEnteredIn(row, "Change"), AppData.DecimalPlaces)
            Me.stbOIDocumentNo.Text = StringMayBeEnteredIn(row, "DocumentNo")
            Me.stbOINotes.Text = StringMayBeEnteredIn(row, "Notes")

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadRefunds(ByVal refundNo As String)

        Dim oRefunds As New SyncSoft.SQLDb.Refunds()

        Try

            Dim refunds As DataTable = oRefunds.GetRefunds(refundNo).Tables("Refunds")
            Dim row As DataRow = refunds.Rows(0)

            Me.stbRefundNo.Text = FormatText(refundNo, "Refunds", "RefundNo")
            Me.stbRefundDate.Text = FormatDate(DateMayBeEnteredIn(row, "RefundDate"))
            Me.nbxRefundAmount.Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount"), AppData.DecimalPlaces)
            Me.stbRefundAmountWords.Text = StringMayBeEnteredIn(row, "AmountWords")
            Me.stbRefundReceiptNo.Text = StringMayBeEnteredIn(row, "ReceiptNo")
            Me.stbPayeeName.Text = StringMayBeEnteredIn(row, "PayeeName")
            Me.stbRefundPayDate.Text = FormatDate(DateMayBeEnteredIn(row, "PayDate"))
            Me.stbRefundAmountPaid.Text = FormatNumber(DecimalMayBeEnteredIn(row, "AmountPaid"), AppData.DecimalPlaces)
            Me.stbRefundNotes.Text = StringMayBeEnteredIn(row, "Notes")

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub LoadExpenditure(ByVal expenditureNo As String)

        Dim oExpenditure As New SyncSoft.SQLDb.Expenditure()

        Try

            Dim expenditure As DataTable = oExpenditure.GetExpenditure(expenditureNo).Tables("Expenditure")
            Dim row As DataRow = expenditure.Rows(0)

            Me.stbExpenditureNo.Text = FormatText(expenditureNo, "Expenditure", "ExpenditureNo")
            Me.stbSpentDate.Text = FormatDate(DateMayBeEnteredIn(row, "SpentDate"))
            Me.stbExpenditureCategory.Text = StringMayBeEnteredIn(row, "ExpenditureCategory")
            Me.stbGivenTo.Text = StringMayBeEnteredIn(row, "GivenTo")
            Me.stbEXDocumentNo.Text = StringMayBeEnteredIn(row, "DocumentNo")
            Me.nbxEXAmount.Value = FormatNumber(DecimalMayBeEnteredIn(row, "Amount"), AppData.DecimalPlaces)
            Me.stbEXDetails.Text = StringMayBeEnteredIn(row, "Details")

        Catch eX As Exception
            Throw eX

        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
       
        Try

            Me.Cursor = Cursors.WaitCursor

            Dim docTypeID As New LookupDataID.DocumentTypeID()
            Dim patientNo As String = RevertText(StringMayBeEnteredIn(Me.stbPatientNo))
            Dim docNo As String = RevertText(StringMayBeEnteredIn(Me.stbReceiptNo))
            Dim bfpdocNo As String = RevertText(StringMayBeEnteredIn(Me.stbBFPReceiptNo))
            Dim bfppatientNo As String = RevertText(StringMayBeEnteredIn(Me.stbBFPPatientNo))

            Dim bpdocNo As String = RevertText(StringMayBeEnteredIn(Me.stbBPReceiptNo))
            Dim bppatientNo As String = RevertText(StringMayBeEnteredIn(Me.stbBPBillAccountNo))

            Dim cbfpdocNo As String = RevertText(StringMayBeEnteredIn(Me.stbCBFPReceiptNo))
            Dim cbfppatientNo As String = RevertText(StringMayBeEnteredIn(Me.stbCBFPBillAccountNo))

            Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgCashPayment.Name
                    Me.PrintCashReceipt()

                    SavePrintDetails(patientNo, docNo, (stbFullName.Text + " 's" + " Copy Cash Receipt"), docTypeID.CopyReceipt)

                Case Me.tpgBillFormPayment.Name
                    Me.PrintBillFormReceipt()
                    SavePrintDetails(bfppatientNo, bfpdocNo, (stbBFPFullName.Text + " 's" + " Copy Bill Form Receipt"), docTypeID.CopyReceipt)

                Case Me.tpgBillsPayment.Name
                    Me.PrintBPReceipt()
                    SavePrintDetails(bppatientNo, bpdocNo, (stbBPBillCustomerName.Text + " 's" + " Copy Bills Payment Receipt"), docTypeID.CopyReceipt)

                Case Me.tpgCreditBillFormPayment.Name
                    Me.PrintCBFPReceipt()
                    SavePrintDetails(cbfppatientNo, cbfpdocNo, (stbCBFPBillCustomerName.Text + " 's" + " Copy Credit Bill Form Receipt"), docTypeID.CopyReceipt)

                Case Me.tpgManageAccounts.Name
                    Me.PrintAccounts()

                Case Me.tpgOtherIncome.Name
                    Me.PrintOtherIncome()

                Case Me.tpgRefunds.Name
                    Me.PrintRefunds()

                Case Me.tpgExpenditure.Name
                    Me.PrintExpenditure()

            End Select

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

            Select Case Me.tbcCashier.SelectedTab.Name

                Case Me.tpgCashPayment.Name

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.dgvPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on payment details!")

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetCashPrintData()

                    With dlgPrintPreview
                        .Document = docCashReceipt
                        .Document.PrinterSettings.Collate = True
                        .ShowIcon = False
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With

                Case Me.tpgBillFormPayment.Name

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.dgvPaymentExtraBillItems.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on bill form payment details!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetBillFormPrintData()

                    With dlgPrintPreview
                        .Document = docBillFormReceipt
                        .Document.PrinterSettings.Collate = True
                        .ShowIcon = False
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With

                Case Me.tpgBillsPayment.Name

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.dgvBillsPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on bills payment details!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetBPPrintData()

                    With dlgPrintPreview
                        .Document = docBPReceipt
                        .Document.PrinterSettings.Collate = True
                        .ShowIcon = False
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With

                Case Me.tpgCreditBillFormPayment.Name

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.dgvCreditBillFormPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on credit bill form payment details!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetCBFPPrintData()

                    With dlgPrintPreview
                        .Document = docCBFPReceipt
                        .Document.PrinterSettings.Collate = True
                        .ShowIcon = False
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With

                Case Me.tpgManageAccounts.Name

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    StringEnteredIn(Me.stbAccountTranNo, "Transaction No!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With dlgPrintPreview
                        .Document = docAccounts
                        .Document.PrinterSettings.Collate = True
                        .ShowIcon = False
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With

                Case Me.tpgOtherIncome.Name

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    StringEnteredIn(Me.stbIncomeNo, "Income No!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With dlgPrintPreview
                        .Document = docOtherIncome
                        .Document.PrinterSettings.Collate = True
                        .ShowIcon = False
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With

                Case Me.tpgRefunds.Name

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    StringEnteredIn(Me.stbRefundNo, "Refund No!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With dlgPrintPreview
                        .Document = docRefunds
                        .Document.PrinterSettings.Collate = True
                        .ShowIcon = False
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With

                Case Me.tpgExpenditure.Name

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    StringEnteredIn(Me.stbExpenditureNo, "Expenditure No!")

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    With dlgPrintPreview
                        .Document = docExpenditure
                        .Document.PrinterSettings.Collate = True
                        .ShowIcon = False
                        .WindowState = FormWindowState.Maximized
                        .ShowDialog()
                    End With

            End Select

        Catch ex As Exception
            ErrorMessage(ex)

        Finally
            Me.Cursor = Cursors.Default

        End Try

    End Sub

#Region " Cash Printing "

    Private Sub PrintCashReceipt()

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()

        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry on payment details!")

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           Select Case cashierPrinterPaperSize
                Case GetLookupDataDes(oprinterPaperSize.A4)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                     Me.SetCashPrintData()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    dlgPrint.Document = docCashReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docCashReceipt.Print()

                Case String.Empty
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Me.SetCashPrintData()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    dlgPrint.Document = docCashReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docCashReceipt.Print()

                Case GetLookupDataDes(oprinterPaperSize.EightyMillimeters)
                    Me.PrintCashierThermalReceipt()

            End Select


        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default

        End Try


    End Sub

    Private Sub docCashReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docCashReceipt.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Cash Receipt (copy)".ToUpper()
            Dim fromName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbReceiptNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim payDate As String = FormatDate(DateMayBeEnteredIn(Me.stbPayDate))
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim notes As String = StringMayBeEnteredIn(Me.stbNotes)
            Dim textLEN As Integer = 75

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
                    If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Received from: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fromName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Receipt No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Pay Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                    If Not String.IsNullOrEmpty(notes) Then

                        yPos += lineHeight
                        notes = "Notes: " + notes.Trim()
                        Dim notesData As New System.Text.StringBuilder(String.Empty)
                        Dim wrappedWordsData As List(Of String) = WrapText(notes, textLEN)
                        If wrappedWordsData.Count > 1 Then
                            For pos As Integer = 0 To wrappedWordsData.Count - 1
                                notesData.Append(wrappedWordsData(pos).Trim())
                                notesData.Append(ControlChars.NewLine)
                            Next
                        Else : notesData.Append(notes)
                        End If

                        .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                        Dim wordLines As Integer = notesData.ToString().Split(CChar(ControlChars.NewLine)).Length
                        If wordLines < 2 Then wordLines = 2
                        yPos += wordLines * lineHeight

                    Else : yPos += 2 * lineHeight
                    End If

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

                If cashParagraphs Is Nothing Then Return

                Do While cashParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(cashParagraphs(1), PrintParagraps)
                    cashParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(e.MarginBounds.Left, yPos, e.MarginBounds.Width, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
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
                        cashParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (cashParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetCashPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 12
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 56
        Dim padAmountTendered As Integer = 53
        Dim padAmountRefunded As Integer = 53
        Dim padAccountBalance As Integer = 43
        Dim padChange As Integer = 40

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        cashParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim count As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            If oVariousOptions.HideCashPaymentReceiptDetails Then
                ' Header goes here!

            ElseIf oVariousOptions.CategorizeVisitPaymentDetails Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Category: ".PadRight(padCategoryName))
                tableHeader.Append("Amount: ".PadLeft(padCategoryAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentDetails = From data In Me.GetPaymentDetailsList Group data By CategoryName = data.Item1
                                     Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For Each item In paymentDetails

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                    Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If categoryName.Length > 47 Then
                        tableData.Append(categoryName.Substring(0, 47).PadRight(padCategoryName))
                    Else : tableData.Append(categoryName.PadRight(padItemName))
                    End If
                    tableData.Append(categoryAmount.PadLeft(padCategoryAmount + 26))

                    tableData.Append(ControlChars.NewLine)

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                cashParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Name: ".PadRight(padItemName))
                tableHeader.Append("Qty: ".PadLeft(padQuantity))
                tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                tableHeader.Append("Discount: ".PadLeft(padDiscount))
                tableHeader.Append("Amount: ".PadLeft(padAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                    Dim quantity As String = cells.Item(Me.colQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                    Dim discount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colAmount.Name).Value.ToString()

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 20 Then
                        tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(discount.PadLeft(padDiscount))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                cashParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            
            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbTotalAmountPaid, True)
            totalAmount.Append(ControlChars.NewLine)

            If oVariousOptions.HideCashPaymentReceiptDetails Then
                totalAmount.Append("Medical Treatment Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount - 18))

            ElseIf oVariousOptions.CategorizeVisitPaymentDetails Then
                totalAmount.Append("Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            Else
                totalAmount.Append("Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            End If

            totalAmount.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbAmountWords)
            totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim amountTenderedData As New System.Text.StringBuilder(String.Empty)
            Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)
            Dim amountRefundedData As New System.Text.StringBuilder(String.Empty)

            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxExchangeRate, True)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbChange, True)
            Dim currency As String = StringMayBeEnteredIn(Me.stbCurrency)
            Dim cashPaymentAmountRefunded As Decimal = DecimalMayBeEnteredIn(Me.nbxCashPaymentAmountRefunded, True)
            Dim amountTenderedLocalCurrency As Decimal = amountTendered * exchangeRate

            amountTenderedData.Append(ControlChars.NewLine)
            amountTenderedData.Append("Amount Tendered: ")
            amountTenderedData.Append(FormatNumber(amountTenderedLocalCurrency, AppData.DecimalPlaces).PadLeft(padAmountTendered))
            amountTenderedData.Append(ControlChars.NewLine)

            If Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                foreignCurrencyData.Append(ControlChars.NewLine)
            End If

            If Me.chkUseAccountBalance.Checked OrElse (Me.chkSendBalanceToAccount.Checked AndAlso Not change = 0) OrElse
                Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, amountTenderedData.ToString()))
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                cashParagraphs.Add(New PrintParagraps(bodyNormalFont, foreignCurrencyData.ToString()))
            End If

            If cashPaymentAmountRefunded > 0 Then
                amountRefundedData.Append("Amount Refunded: ")
                amountRefundedData.Append(FormatNumber(cashPaymentAmountRefunded, AppData.DecimalPlaces).PadLeft(padAmountRefunded))
                amountRefundedData.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, amountRefundedData.ToString()))
            End If

            If Me.chkUseAccountBalance.Checked Then

                Dim accountData As New System.Text.StringBuilder(String.Empty)
                Dim balanceFromAccount As Decimal = totalBill - amountTenderedLocalCurrency + change

                accountData.Append("Balance used from account: ")
                accountData.Append(FormatNumber(balanceFromAccount, AppData.DecimalPlaces).PadLeft(padAccountBalance))
                accountData.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, accountData.ToString()))

            End If

            If Me.chkSendBalanceToAccount.Checked AndAlso Not change = 0 Then

                Dim balanceData As New System.Text.StringBuilder(String.Empty)

                If change < 0 Then
                    balanceData.Append("Balance sent to account (DR): ")
                Else : balanceData.Append("Balance sent to account (CR): ")
                End If
                balanceData.Append(FormatNumber(change, AppData.DecimalPlaces).PadLeft(padChange))
                balanceData.Append(ControlChars.NewLine)
                cashParagraphs.Add(New PrintParagraps(bodyBoldFont, balanceData.ToString()))

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            cashParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetPaymentDetailsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentDetails As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colCategory.Name).Value.ToString()
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colAmount, False, "amount!")

                paymentDetails.Add(New Tuple(Of String, Decimal)(category, amount))

            Next

            Return paymentDetails

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "Cashier THERMAL RECEIPT PRINTOUT"

    Private Sub PrintCashierThermalReceipt()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for lab request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim nonSelected As Boolean = False

          If nonSelected Then Throw New ArgumentException("Must include at least one entry for lab request!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetCashierThermalReceiptPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docCashThermalReceipt
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docCashThermalReceipt.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docCashierThermalReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docCashThermalReceipt.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = CSng(e.MarginBounds.Left / 10)
            Dim yPos As Single = CSng(e.MarginBounds.Top / 8)

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + ControlChars.NewLine + "Cashier PrintOut".ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbFullName)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbPatientNo)
            Dim VisitNo As String = StringMayBeEnteredIn(Me.stbVisitNo)
            Dim VisitDate As String = StringMayBeEnteredIn(Me.stbVisitDate)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbPayModes)
           
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 11 * widthTopFirst

                If pageNo < 2 Then

                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(VisitNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(VisitDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Pay Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    
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

                If CashThermalReceiptParagraphs Is Nothing Then Return

                Do While CashThermalReceiptParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(CashThermalReceiptParagraphs(1), PrintParagraps)
                    CashThermalReceiptParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(xPos, yPos, e.PageBounds.Width - xPos, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
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
                        CashThermalReceiptParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (CashThermalReceiptParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetCashierThermalReceiptPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 16
        Dim padQuantity As Integer = 8
        Dim padIAmount As Integer = 10


        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        CashThermalReceiptParagraphs = New Collection()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append(ControlChars.NewLine)
            tableHeader.Append(ControlChars.NewLine)
            CashThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            Dim Amount As Double = 0.0
            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvPaymentDetails.RowCount - 1

                         Dim cells As DataGridViewCellCollection = Me.dgvPaymentDetails.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim ItemName As String = cells.Item(Me.colItemName.Name).Value.ToString()
                    Dim itemQuantity As String = cells.Item(Me.colQuantity.Name).Value.ToString()
                    Dim itemUnitPrice As String = cells.Item(Me.colUnitPrice.Name).Value.ToString()
                    Dim itemDicount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                    Dim itemAmount As String = cells.Item(Me.colAmount.Name).Value.ToString()
                    tableData.Append(itemNo.PadRight(padItemNo))
                    tableData.Append(ItemName.PadRight(padItemName))
                    tableData.Append(ControlChars.NewLine)
                    tableData.Append(String.Empty.PadRight(padItemNo))
                    tableData.Append("Quantity:  ".PadRight(padQuantity + 1))
                    tableData.Append(itemQuantity.PadRight(padQuantity + 1))
                    tableData.Append(ControlChars.NewLine)
                    tableData.Append(String.Empty.PadRight(padItemNo))
                    tableData.Append("UnitPrice: ".PadRight(padQuantity))
                    tableData.Append(itemUnitPrice.PadRight(padQuantity))
                    tableData.Append(ControlChars.NewLine)
                    tableData.Append(String.Empty.PadRight(padItemNo))
                    tableData.Append("Discount:  ".PadRight(padQuantity + 1))
                    tableData.Append(itemDicount.PadRight(padQuantity + 1))
                    tableData.Append(ControlChars.NewLine)
                    tableData.Append(String.Empty.PadRight(padItemNo))
                    tableData.Append("Amount: ".PadRight(padIAmount + 1))
                    tableData.Append(itemAmount.PadRight(padIAmount))
                    tableData.Append(ControlChars.NewLine)
                    tableData.Append(ControlChars.NewLine)

            Next

            CashThermalReceiptParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim paymentDetailsItemTotals = From data In Me.GetPaymentDetailsList Group data By ItemName = data.Item1
                                 Into Totals = Sum(data.Item2) Select ItemName, Totals

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            For Each item In paymentDetailsItemTotals
                Dim totals As Double = Convert.ToInt32(item.Totals)
                Amount += totals
            Next
            Dim receiptAmount As String = FormatNumber(Amount, AppData.DecimalPlaces)
            totalAmount.Append("Total Amount:  ".PadRight(padItemNo))
            totalAmount.Append(receiptAmount.PadRight(padIAmount))

            totalAmount.Append(ControlChars.NewLine)

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            CashThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            CashThermalReceiptParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
#End Region


#Region " Bill Form Printing "

    Private Sub PrintBillFormReceipt()

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()
        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPaymentExtraBillItems.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on bill form payment details!")



            Select Case cashierPrinterPaperSize
                Case GetLookupDataDes(oprinterPaperSize.A4)
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.SetBillFormPrintData()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docBillFormReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docBillFormReceipt.Print()

                Case String.Empty
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.SetBillFormPrintData()
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docBillFormReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docBillFormReceipt.Print()

                Case GetLookupDataDes(oprinterPaperSize.EightyMillimeters)
                    Me.PrintIPDCashierThermalReceipt()

            End Select

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docBillFormReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBillFormReceipt.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper() + " Cash Receipt (copy)".ToUpper()
            Dim fromName As String = StringMayBeEnteredIn(Me.stbBFPFullName)
            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbBFPReceiptNo)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbBFPPatientNo)
            Dim payDate As String = FormatDate(DateMayBeEnteredIn(Me.stbBFPPayDate))
            Dim visitDate As String = StringMayBeEnteredIn(Me.stbBFPVisitDate)
            Dim notes As String = StringMayBeEnteredIn(Me.stbBFPNotes)
            Dim textLEN As Integer = 75

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
                    If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Received from: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fromName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Receipt No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Pay Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(visitDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                    If Not String.IsNullOrEmpty(notes) Then

                        yPos += lineHeight
                        notes = "Notes: " + notes.Trim()
                        Dim notesData As New System.Text.StringBuilder(String.Empty)
                        Dim wrappedWordsData As List(Of String) = WrapText(notes, textLEN)
                        If wrappedWordsData.Count > 1 Then
                            For pos As Integer = 0 To wrappedWordsData.Count - 1
                                notesData.Append(wrappedWordsData(pos).Trim())
                                notesData.Append(ControlChars.NewLine)
                            Next
                        Else : notesData.Append(notes)
                        End If

                        .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                        Dim wordLines As Integer = notesData.ToString().Split(CChar(ControlChars.NewLine)).Length
                        If wordLines < 2 Then wordLines = 2
                        yPos += wordLines * lineHeight

                    Else : yPos += 2 * lineHeight
                    End If

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

                If billFormParagraphs Is Nothing Then Return

                Do While billFormParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(billFormParagraphs(1), PrintParagraps)
                    billFormParagraphs.Remove(1)

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
                        billFormParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (billFormParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetBillFormPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 12
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 56
        Dim padAmountTendered As Integer = 53
        Dim padAmountRefunded As Integer = 53
        Dim padAccountBalance As Integer = 43
        Dim padChange As Integer = 40

        Dim padCategoryName As Integer = 47
        Dim padCategoryAmount As Integer = 20

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        billFormParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim count As Integer
            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            If oVariousOptions.HideBillFormPaymentReceiptDetails Then
                ' Header goes here!

            ElseIf oVariousOptions.CategorizeBillFormPaymentDetails Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Category: ".PadRight(padCategoryName))
                tableHeader.Append("Amount: ".PadLeft(padCategoryAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                billFormParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentExtraBillItems = From data In Me.GetPaymentExtraBillItemsList Group data By CategoryName = data.Item1
                                     Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For Each item In paymentExtraBillItems

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                    Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If categoryName.Length > 47 Then
                        tableData.Append(categoryName.Substring(0, 47).PadRight(padCategoryName))
                    Else : tableData.Append(categoryName.PadRight(padItemName))
                    End If
                    tableData.Append(categoryAmount.PadLeft(padCategoryAmount + 26))

                    tableData.Append(ControlChars.NewLine)

                Next

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                billFormParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Name: ".PadRight(padItemName))
                tableHeader.Append("Qty: ".PadLeft(padQuantity))
                tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
                tableHeader.Append("Discount: ".PadLeft(padDiscount))
                tableHeader.Append("Amount: ".PadLeft(padAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                billFormParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For rowNo As Integer = 0 To Me.dgvPaymentExtraBillItems.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvPaymentExtraBillItems.Rows(rowNo).Cells
                   
                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim itemName As String = cells.Item(Me.colBFPItemName.Name).Value.ToString()
                    Dim quantity As String = cells.Item(Me.colBFPQuantity.Name).Value.ToString()
                    Dim unitPrice As String = cells.Item(Me.colBFPUnitPrice.Name).Value.ToString()
                    Dim discount As String = cells.Item(Me.colBFPDiscount.Name).Value.ToString()
                    Dim amount As String = cells.Item(Me.colBFPAmount.Name).Value.ToString()

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If itemName.Length > 20 Then
                        tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                    Else : tableData.Append(itemName.PadRight(padItemName))
                    End If
                    tableData.Append(quantity.PadLeft(padQuantity))
                    tableData.Append(unitPrice.PadLeft(padUnitPrice))
                    tableData.Append(discount.PadLeft(padDiscount))
                    tableData.Append(amount.PadLeft(padAmount))

                    tableData.Append(ControlChars.NewLine)

                Next

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                billFormParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            Dim totalBill As Decimal = DecimalMayBeEnteredIn(Me.stbBFPTotalAmountPaid, True)
            totalAmount.Append(ControlChars.NewLine)

            If oVariousOptions.HideBillFormPaymentReceiptDetails Then
                totalAmount.Append("Medical Treatment Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount - 18))

            ElseIf oVariousOptions.CategorizeBillFormPaymentDetails Then
                totalAmount.Append("Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            Else
                totalAmount.Append("Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount))
            End If

            totalAmount.Append(ControlChars.NewLine)
            billFormParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))

            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            Dim amountWords As String = StringMayBeEnteredIn(Me.stbBFPAmountWords)
            totalAmountWords.Append("(" + amountWords.Trim() + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            billFormParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim amountTenderedData As New System.Text.StringBuilder(String.Empty)
            Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)
            Dim amountRefundedData As New System.Text.StringBuilder(String.Empty)

            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxBFPAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxBFPExchangeRate, True)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbBFPChange, True)
            Dim currency As String = StringMayBeEnteredIn(Me.stbBFPCurrency)
            Dim billFormAmountRefunded As Decimal = DecimalMayBeEnteredIn(Me.nbxBillFormAmountRefunded, True)
            Dim amountTenderedLocalCurrency As Decimal = amountTendered * exchangeRate

            amountTenderedData.Append(ControlChars.NewLine)
            amountTenderedData.Append("Amount Tendered: ")
            amountTenderedData.Append(FormatNumber(amountTenderedLocalCurrency, AppData.DecimalPlaces).PadLeft(padAmountTendered))
            amountTenderedData.Append(ControlChars.NewLine)

            If Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                foreignCurrencyData.Append(ControlChars.NewLine)
            End If

            If Me.chkBFPUseAccountBalance.Checked OrElse (Me.chkBFPSendBalanceToAccount.Checked AndAlso Not change = 0) OrElse
                Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                billFormParagraphs.Add(New PrintParagraps(bodyBoldFont, amountTenderedData.ToString()))
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                billFormParagraphs.Add(New PrintParagraps(bodyNormalFont, foreignCurrencyData.ToString()))
            End If

            If billFormAmountRefunded > 0 Then
                amountRefundedData.Append("Amount Refunded: ")
                amountRefundedData.Append(FormatNumber(billFormAmountRefunded, AppData.DecimalPlaces).PadLeft(padAmountRefunded))
                amountRefundedData.Append(ControlChars.NewLine)
                billFormParagraphs.Add(New PrintParagraps(bodyBoldFont, amountRefundedData.ToString()))
            End If

            If Me.chkBFPUseAccountBalance.Checked Then

                Dim accountData As New System.Text.StringBuilder(String.Empty)
                Dim balanceFromAccount As Decimal = totalBill - amountTenderedLocalCurrency + change

                accountData.Append("Balance used from account: ")
                accountData.Append(FormatNumber(balanceFromAccount, AppData.DecimalPlaces).PadLeft(padAccountBalance))
                accountData.Append(ControlChars.NewLine)
                billFormParagraphs.Add(New PrintParagraps(bodyBoldFont, accountData.ToString()))

            End If

            If Me.chkBFPSendBalanceToAccount.Checked AndAlso Not change = 0 Then

                Dim balanceData As New System.Text.StringBuilder(String.Empty)

                If change < 0 Then
                    balanceData.Append("Balance sent to account (DR): ")
                Else : balanceData.Append("Balance sent to account (CR): ")
                End If
                balanceData.Append(FormatNumber(change, AppData.DecimalPlaces).PadLeft(padChange))
                balanceData.Append(ControlChars.NewLine)
                billFormParagraphs.Add(New PrintParagraps(bodyBoldFont, balanceData.ToString()))

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            billFormParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                              Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            billFormParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetPaymentExtraBillItemsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentExtraBillItems As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvPaymentExtraBillItems.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvPaymentExtraBillItems.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colBFPCategory.Name).Value.ToString()
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colBFPAmount, False, "amount!")

                paymentExtraBillItems.Add(New Tuple(Of String, Decimal)(category, amount))
            Next

            Return paymentExtraBillItems

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#End Region

#Region "Cashier IPD THERMAL RECEIPT PRINTOUT"

    Private Sub PrintIPDCashierThermalReceipt()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvPaymentExtraBillItems.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Payments!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
           
            Me.SetIPDCashierThermalReceiptPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docIPDCashThermalReceipt
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docIPDCashThermalReceipt.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docIPDCashierThermalReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docIPDCashThermalReceipt.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = CSng(e.MarginBounds.Left / 10)
            Dim yPos As Single = CSng(e.MarginBounds.Top / 8)

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper()

            Dim fullName As String = StringMayBeEnteredIn(Me.stbBFPFullName)
            Dim patientNo As String = StringMayBeEnteredIn(Me.stbBFPPatientNo)
            Dim VisitNo As String = StringMayBeEnteredIn(Me.stbBFPVisitNo)
            Dim VisitDate As String = StringMayBeEnteredIn(Me.stbBFPVisitDate)
            Dim billMode As String = StringMayBeEnteredIn(Me.stbBFPPayModes)
            Dim ReceiptNo As String = StringMayBeEnteredIn(Me.stbBFPReceiptNo)

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 11 * widthTopFirst

                If pageNo < 2 Then

                    '.DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    'yPos += 3 * lineHeight
                    If (title.Length > 25) Then
                        .DrawString(title.Substring(0, 25), titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString(title.Substring(25), titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("IPD CASHIER RECEIPT (COPY)".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 3 * lineHeight
                    Else
                        .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("IPD RECEIPT (COPY)".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 3 * lineHeight
                    End If

                    .DrawString("Received From: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    If (fullName.Length > 15) Then
                        .DrawString(fullName.Substring(0, 14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                        .DrawString(fullName.Substring(14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    Else
                        .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If

                    .DrawString("Receipt No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(ReceiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Patient No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(patientNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Visit No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(VisitNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Visit Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(VisitDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Bill Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

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

                If CashIPDThermalReceiptParagraphs Is Nothing Then Return

                Do While CashIPDThermalReceiptParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(CashIPDThermalReceiptParagraphs(1), PrintParagraps)
                    CashIPDThermalReceiptParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(xPos, yPos, e.PageBounds.Width - xPos, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
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
                        CashIPDThermalReceiptParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (CashIPDThermalReceiptParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetIPDCashierThermalReceiptPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 16
        Dim padQuantity As Integer = 8
        Dim padIAmount As Integer = 10

        Dim padQty As Integer = 4
        Dim padUp As Integer = 9
        Dim padDc As Integer = 8
        Dim padTl As Integer = 13

        Dim count As Integer
        Dim tableHeader As New System.Text.StringBuilder(String.Empty)
        Dim tableData As New System.Text.StringBuilder(String.Empty)
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        CashIPDThermalReceiptParagraphs = New Collection()
        Dim totalAmount As New System.Text.StringBuilder(String.Empty)
        Dim Amount As Double = 0.0

        Try


            If oVariousOptions.CategorizeVisitPaymentDetails Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Category: ".PadRight(padItemName))
                tableHeader.Append("Amount: ".PadLeft(padIAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                CashIPDThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentExtraBillItems = From data In Me.GetPaymentExtraBillItemsList Group data By CategoryName = data.Item1
                                     Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For Each item In paymentExtraBillItems

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                    Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If categoryName.Length > 47 Then
                        tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName))
                    Else : tableData.Append(categoryName.PadRight(padItemName))
                    End If
                    tableData.Append(categoryAmount.PadLeft(padIAmount))

                    tableData.Append(ControlChars.NewLine)

                Next

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(ControlChars.NewLine)
                CashIPDThermalReceiptParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentDetailsItemTotals = From data In Me.GetPaymentExtraBillItemsList Group data By ItemName = data.Item1
                                     Into Totals = Sum(data.Item2) Select ItemName, Totals

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                For Each item In paymentDetailsItemTotals
                    Dim totals As Double = Convert.ToInt32(item.Totals)
                    Amount += totals
                Next
                Dim receiptAmount As String = FormatNumber(Amount, AppData.DecimalPlaces)
                totalAmount.Append("Total Amount:  ".PadRight(padQty))
                totalAmount.Append(GetSpaces(3).PadRight(padQty))
                totalAmount.Append(receiptAmount.PadLeft(padTl))

                totalAmount.Append(ControlChars.NewLine)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CashIPDThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else

                tableHeader.Append(ControlChars.NewLine)
                '--------------------------------------------------------------------------------------------------
                tableHeader.Append("Description".PadRight(padItemName))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append("Qty".PadRight(padQty))
                tableHeader.Append("Price".PadLeft(padUp))
                ' tableHeader.Append("Disc%".PadLeft(padDc))
                tableHeader.Append(" Total".PadLeft(padTl))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append("-------------------------------".PadRight(padItemName))
                '--------------------------------------------------------------------------------------------------
                CashIPDThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))



                For rowNo As Integer = 0 To Me.dgvPaymentExtraBillItems.RowCount - 1

                  
                        Dim cells As DataGridViewCellCollection = Me.dgvPaymentExtraBillItems.Rows(rowNo).Cells

                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim ItemName As String = cells.Item(Me.colBFPItemName.Name).Value.ToString()
                        Dim itemQuantity As String = cells.Item(Me.colBFPQuantity.Name).Value.ToString()
                        Dim itemUnitPrice As String = cells.Item(Me.colBFPUnitPrice.Name).Value.ToString()
                        'Dim itemDicount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                        Dim itemAmount As String = cells.Item(Me.colBFPAmount.Name).Value.ToString()
                        'tableData.Append(itemNo.PadRight(padItemNo))
                        tableData.Append(ItemName.PadRight(padItemNo))
                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(itemQuantity.PadRight(padQty))
                        tableData.Append(itemUnitPrice.PadLeft(padUp))
                        'tableData.Append(itemDicount.PadLeft(padDc))
                        tableData.Append(itemAmount.PadLeft(padTl))
                        tableData.Append(ControlChars.NewLine)

                Next

                tableData.Append(ControlChars.NewLine)
                CashIPDThermalReceiptParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentDetailsItemTotals = From data In Me.GetPaymentExtraBillItemsList Group data By ItemName = data.Item1
                                     Into Totals = Sum(data.Item2) Select ItemName, Totals

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                For Each item In paymentDetailsItemTotals
                    Dim totals As Double = Convert.ToInt32(item.Totals)
                    Amount += totals
                Next
                Dim receiptAmount As String = FormatNumber(Amount, AppData.DecimalPlaces)
                totalAmount.Append("Total Amount:  ".PadRight(padQty))
                totalAmount.Append(GetSpaces(3).PadRight(padQty))
                totalAmount.Append(receiptAmount.PadLeft(padTl))

                totalAmount.Append(ControlChars.NewLine)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CashIPDThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing ***")
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            CashIPDThermalReceiptParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("On " + FormatDate(Now))
            footerData.Append(ControlChars.NewLine)
            footerData.Append("At " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            CashIPDThermalReceiptParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Bills Payment Printing "

    Private Sub PrintBPReceipt()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()
        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvBillsPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on bills payment details!")


            Select Case cashierPrinterPaperSize
                Case GetLookupDataDes(oprinterPaperSize.A4)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.SetBPPrintData()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docBPReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docBPReceipt.Print()

                Case String.Empty
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.SetBPPrintData()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docBPReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docBPReceipt.Print()

                Case GetLookupDataDes(oprinterPaperSize.EightyMillimeters)
                    Me.PrintBPThermalReceipt()

            End Select

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docBPReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBPReceipt.PrintPage

        Try

            Dim oPayTypeID As New LookupDataID.PayTypeID()
            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String = AppData.ProductOwner.ToUpper() + " Bills Payment Receipt (Copy)".ToUpper()

            Dim payMode As String

            Dim fromName As String = StringMayBeEnteredIn(Me.stbBPBillCustomerName)
            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbBPReceiptNo)
            Dim billAccountNo As String = StringMayBeEnteredIn(Me.stbBPBillAccountNo)
            Dim payDate As String = FormatDate(DateMayBeEnteredIn(Me.stbBPPayDate))
            Dim documentNo As String = StringMayBeEnteredIn(Me.stbBPDocumentNo)
            If String.IsNullOrEmpty(documentNo) Then
                payMode = StringMayBeEnteredIn(Me.stbBPPayModes)
            Else : payMode = StringMayBeEnteredIn(Me.stbBPPayModes) + " (No: " + documentNo + ")"
            End If

            Dim notes As String = StringMayBeEnteredIn(Me.stbBPNotes)
            Dim textLEN As Integer = 75

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 29 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Received from: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fromName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Receipt No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    If bPPayTypeID.ToUpper().Equals(oPayTypeID.InsuranceBill.ToUpper()) Then
                        .DrawString("Insurance No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    Else : .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    End If
                    .DrawString(billAccountNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Pay Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    .DrawString("Mode of Payment: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(payMode, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                    If Not String.IsNullOrEmpty(notes) Then

                        yPos += lineHeight
                        notes = "Notes: " + notes.Trim()
                        Dim notesData As New System.Text.StringBuilder(String.Empty)
                        Dim wrappedWordsData As List(Of String) = WrapText(notes, textLEN)
                        If wrappedWordsData.Count > 1 Then
                            For pos As Integer = 0 To wrappedWordsData.Count - 1
                                notesData.Append(wrappedWordsData(pos).Trim())
                                notesData.Append(ControlChars.NewLine)
                            Next
                        Else : notesData.Append(notes)
                        End If

                        .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                        Dim wordLines As Integer = notesData.ToString().Split(CChar(ControlChars.NewLine)).Length
                        If wordLines < 2 Then wordLines = 2
                        yPos += wordLines * lineHeight

                    Else : yPos += 2 * lineHeight
                    End If

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

                If bPParagraphs Is Nothing Then Return

                Do While bPParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(bPParagraphs(1), PrintParagraps)
                    bPParagraphs.Remove(1)

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
                        bPParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (bPParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub SetBPPrintData()

        Dim padVisitNo As Integer = 14
        Dim padItemName As Integer = 18
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 12
        Dim padDiscount As Integer = 10
        Dim padAmount As Integer = 14
        Dim padTotalAmount As Integer = 58
        Dim padAmountTendered As Integer = 55
        Dim padAccountBalance As Integer = 45
        Dim padChange As Integer = 42

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        bPParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("Visit No: ".PadRight(padVisitNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Qty: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Discount: ".PadLeft(padDiscount))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)

            If Not oVariousOptions.HideCreditBillsPaymentReceiptDetails Then
                tableHeader.Append(ControlChars.NewLine)
                bPParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))
            End If

            Dim tableData As New System.Text.StringBuilder(String.Empty)
            For rowNo As Integer = 0 To Me.dgvBillsPaymentDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvBillsPaymentDetails.Rows(rowNo).Cells

                Dim visitNo As String = cells.Item(Me.colBPVisitNo.Name).Value.ToString()
                Dim itemName As String = cells.Item(Me.colBPItemName.Name).Value.ToString()
                Dim quantity As String = cells.Item(Me.colBPQuantity.Name).Value.ToString()
                Dim unitPrice As String = cells.Item(Me.colBPUnitPrice.Name).Value.ToString()
                Dim discount As String = cells.Item(Me.colBPDiscount.Name).Value.ToString()
                Dim amount As String = cells.Item(Me.colBPAmount.Name).Value.ToString()

                tableData.Append(visitNo.PadRight(padVisitNo))
                If itemName.Length > 18 Then
                    tableData.Append(itemName.Substring(0, 18).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(discount.PadLeft(padDiscount))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)
            Next

            If Not oVariousOptions.HideCreditBillsPaymentReceiptDetails Then
                bPParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
            End If

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)
            Dim totalBill As Decimal = CalculateGridAmount(dgvBillsPaymentDetails, colBPAmount)
           Dim withholdingTaxLine As New System.Text.StringBuilder(String.Empty)
            Dim grandDiscountLine As New System.Text.StringBuilder(String.Empty)
            Dim netBillLine As New System.Text.StringBuilder(String.Empty)
            Dim withholdingTax As Decimal = DecimalMayBeEnteredIn(nbxBPWithholdingTax)
            Dim grandDiscount As Decimal = DecimalMayBeEnteredIn(Me.nbxBPGrandDiscount)
            Dim netBill = totalBill - (withholdingTax + grandDiscount)
            totalAmount.Append(ControlChars.NewLine)

            If Not oVariousOptions.HideCreditBillsPaymentReceiptDetails Then
                totalAmount.Append("Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount))
                If withholdingTax > 0 Then
                    withholdingTaxLine.Append("Withholding Tax: ")
                    withholdingTaxLine.Append(FormatNumber(withholdingTax, AppData.DecimalPlaces).PadLeft(padTotalAmount - 3))
                End If
                If grandDiscount > 0 Then
                    grandDiscountLine.Append("Grand Discount: ")
                    grandDiscountLine.Append(FormatNumber(grandDiscount, AppData.DecimalPlaces).PadLeft(padTotalAmount - 2))
                End If
                If withholdingTax > 0 OrElse grandDiscount > 0 Then
                    netBillLine.Append("Net Bill: ")
                    netBillLine.Append(FormatNumber(netBill, AppData.DecimalPlaces).PadLeft(padTotalAmount + 4))
                End If
            Else
                totalAmount.Append("Medical Bills Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount - 14))
                If withholdingTax > 0 Then
                    withholdingTaxLine.Append("Withholding Tax: ")
                    withholdingTaxLine.Append(FormatNumber(withholdingTax, AppData.DecimalPlaces).PadLeft(padTotalAmount - 4))
                End If
                If grandDiscount > 0 Then
                    grandDiscountLine.Append("Grand Discount: ")
                    grandDiscountLine.Append(FormatNumber(grandDiscount, AppData.DecimalPlaces).PadLeft(padTotalAmount - 2))
                End If
                If withholdingTax > 0 OrElse grandDiscount > 0 Then
                    netBillLine.Append("Net Bill: ")
                    netBillLine.Append(FormatNumber(netBill, AppData.DecimalPlaces).PadLeft(padTotalAmount + 4))
                End If
            End If

            totalAmount.Append(ControlChars.NewLine)
            bPParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))
            bPParagraphs.Add(New PrintParagraps(bodyBoldFont, withholdingTaxLine.ToString()))
            bPParagraphs.Add(New PrintParagraps(bodyBoldFont, grandDiscountLine.ToString()))
            bPParagraphs.Add(New PrintParagraps(bodyBoldFont, netBillLine.ToString()))

            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            totalAmountWords.Append("(" + NumberToWords(netBill) + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            bPParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim amountTenderedData As New System.Text.StringBuilder(String.Empty)
            Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxBPAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxBPExchangeRate, True)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbBPChange, True)
            Dim currency As String = StringMayBeEnteredIn(Me.stbBPCurrency)
            Dim amountTenderedLocalCurrency As Decimal = amountTendered * exchangeRate

            amountTenderedData.Append(ControlChars.NewLine)
            amountTenderedData.Append("Amount Tendered: ")
            amountTenderedData.Append(FormatNumber(amountTenderedLocalCurrency, AppData.DecimalPlaces).PadLeft(padAmountTendered))
            amountTenderedData.Append(ControlChars.NewLine)

            If Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                foreignCurrencyData.Append(ControlChars.NewLine)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkBPUseAccountBalance.Checked OrElse (Me.chkBPSendBalanceToAccount.Checked AndAlso Not change = 0) OrElse
                  Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                bPParagraphs.Add(New PrintParagraps(bodyBoldFont, amountTenderedData.ToString()))
            End If

            If Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                bPParagraphs.Add(New PrintParagraps(bodyNormalFont, foreignCurrencyData.ToString()))
            End If

            If Me.chkBPUseAccountBalance.Checked Then

                Dim accountData As New System.Text.StringBuilder(String.Empty)
                Dim balanceFromAccount As Decimal = totalBill - amountTenderedLocalCurrency + change

                accountData.Append("Balance used from account: ")
                accountData.Append(FormatNumber(balanceFromAccount, AppData.DecimalPlaces).PadLeft(padAccountBalance))
                accountData.Append(ControlChars.NewLine)
                bPParagraphs.Add(New PrintParagraps(bodyBoldFont, accountData.ToString()))

            End If

            If Me.chkBPSendBalanceToAccount.Checked AndAlso Not change = 0 Then

                Dim balanceData As New System.Text.StringBuilder(String.Empty)

                If change < 0 Then
                    balanceData.Append("Balance sent to account (DR): ")
                Else : balanceData.Append("Balance sent to account (CR): ")
                End If
                balanceData.Append(FormatNumber(change, AppData.DecimalPlaces).PadLeft(padChange))
                balanceData.Append(ControlChars.NewLine)
                bPParagraphs.Add(New PrintParagraps(bodyBoldFont, balanceData.ToString()))

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            bPParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                                Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            bPParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Function GetPaymentBPItemsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentbP As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvBillsPaymentDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvBillsPaymentDetails.Rows(rowNo).Cells
                Dim category As String = cells.Item(Me.colBPCategory.Name).Value.ToString()
                Dim amount As Decimal = DecimalEnteredIn(cells, Me.colBPAmount, False, "amount!")

                paymentbP.Add(New Tuple(Of String, Decimal)(category, amount))

            Next

            Return paymentbP

        Catch ex As Exception
            Throw ex
        End Try

    End Function

#Region "Bills Payment THERMAL RECEIPT PRINTOUT"

    Private Sub PrintBPThermalReceipt()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvBillsPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Payments!")

         
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetBPThermalReceiptPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docBPThermalReceipt
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docBPThermalReceipt.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docBPThermalReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docBPThermalReceipt.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = CSng(e.MarginBounds.Left / 10)
            Dim yPos As Single = CSng(e.MarginBounds.Top / 8)

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper()


            Dim fullName As String
            Dim payMode As String
            'Dim billModesID As String = StringValueMayBeEnteredIn(Me.cboBPBillModesID)
            Dim fromName As String = StringMayBeEnteredIn(Me.stbBPBillCustomerName)

            fullName = StringEnteredIn(Me.stbBPBillCustomerName)


            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbBPReceiptNo)
            Dim billAccountNo As String = StringMayBeEnteredIn(Me.stbBPBillAccountNo)
            Dim payDate As String = FormatDate(Today)
            Dim documentNo As String = StringMayBeEnteredIn(Me.stbBPDocumentNo)
            If String.IsNullOrEmpty(documentNo) Then
                payMode = StringMayBeEnteredIn(Me.stbBPPayModes)
            Else : payMode = StringMayBeEnteredIn(Me.stbBPPayModes) + " (No: " + documentNo + ")"
            End If
            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 11 * widthTopFirst

                If pageNo < 2 Then

                    '.DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    'yPos += 3 * lineHeight
                    If (title.Length > 25) Then
                        .DrawString(title.Substring(0, 25), titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString(title.Substring(25), titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("Bills Payment Receipt".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 3 * lineHeight
                    Else
                        .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("Bills Payment Receipt".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 3 * lineHeight
                    End If

                    .DrawString("Received From: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    If (fullName.Length > 15) Then
                        .DrawString(fullName.Substring(0, 14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                        .DrawString(fullName.Substring(14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    Else
                        .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If

                    .DrawString("Receipt No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(ReceiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billAccountNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight


                    .DrawString("Pay Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Payment Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

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

                If bPThermalParagraphs Is Nothing Then Return

                Do While bPThermalParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(bPThermalParagraphs(1), PrintParagraps)
                    bPThermalParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(xPos, yPos, e.PageBounds.Width - xPos, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
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
                        bPThermalParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (bPThermalParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try



    End Sub



    Private Sub SetBPThermalReceiptPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 16
        Dim padQuantity As Integer = 8
        Dim padIAmount As Integer = 10

        Dim padQty As Integer = 4
        Dim padUp As Integer = 9
        Dim padDc As Integer = 8
        Dim padTl As Integer = 13

        Dim count As Integer
        Dim tableHeader As New System.Text.StringBuilder(String.Empty)
        Dim tableData As New System.Text.StringBuilder(String.Empty)
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        bPThermalParagraphs = New Collection()
        Dim totalAmount As New System.Text.StringBuilder(String.Empty)
        Dim Amount As Double = 0.0

        Try


            If oVariousOptions.CategorizeVisitPaymentDetails Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Category: ".PadRight(padItemName))
                tableHeader.Append("Amount: ".PadLeft(padIAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                bPThermalParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentBPItems = From data In Me.GetPaymentBPItemsList Group data By CategoryName = data.Item1
                                     Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For Each item In paymentBPItems

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                    Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If categoryName.Length > 47 Then
                        tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName))
                    Else : tableData.Append(categoryName.PadRight(padItemName))
                    End If
                    tableData.Append(categoryAmount.PadLeft(padIAmount))

                    tableData.Append(ControlChars.NewLine)

                Next

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(ControlChars.NewLine)
                bPThermalParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentDetailsItemTotals = From data In Me.GetPaymentBPItemsList Group data By ItemName = data.Item1
                                     Into Totals = Sum(data.Item2) Select ItemName, Totals

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                For Each item In paymentDetailsItemTotals
                    Dim totals As Double = Convert.ToInt32(item.Totals)
                    Amount += totals
                Next
                Dim receiptAmount As String = FormatNumber(Amount, AppData.DecimalPlaces)
                totalAmount.Append("Total Amount:  ".PadRight(padQty))
                totalAmount.Append(GetSpaces(3).PadRight(padQty))
                totalAmount.Append(receiptAmount.PadLeft(padTl))

                totalAmount.Append(ControlChars.NewLine)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                bPThermalParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else

                tableHeader.Append(ControlChars.NewLine)
                '--------------------------------------------------------------------------------------------------
                tableHeader.Append("Description".PadRight(padItemName))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append("Qty".PadRight(padQty))
                tableHeader.Append("Price".PadLeft(padUp))
                ' tableHeader.Append("Disc%".PadLeft(padDc))
                tableHeader.Append(" Total".PadLeft(padTl))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append("-------------------------------".PadRight(padItemName))
                '--------------------------------------------------------------------------------------------------
                bPThermalParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))



                For rowNo As Integer = 0 To Me.dgvBillsPaymentDetails.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvBillsPaymentDetails.Rows(rowNo).Cells

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim ItemName As String = cells.Item(Me.colBPItemName.Name).Value.ToString()
                    Dim itemQuantity As String = cells.Item(Me.colBPQuantity.Name).Value.ToString()
                    Dim itemUnitPrice As String = cells.Item(Me.colBPUnitPrice.Name).Value.ToString()
                    'Dim itemDicount As String = cells.Item(Me.colDiscount.Name).Value.ToString()
                    Dim itemAmount As String = cells.Item(Me.colBPAmount.Name).Value.ToString()
                    'tableData.Append(itemNo.PadRight(padItemNo))
                    tableData.Append(ItemName.PadRight(padItemNo))


                    tableData.Append(ControlChars.NewLine)
                    tableData.Append(itemQuantity.PadRight(padQty))
                    tableData.Append(itemUnitPrice.PadLeft(padUp))
                    'tableData.Append(itemDicount.PadLeft(padDc))
                    tableData.Append(itemAmount.PadLeft(padTl))
                    tableData.Append(ControlChars.NewLine)

                Next

                tableData.Append(ControlChars.NewLine)
                bPThermalParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentDetailsItemTotals = From data In Me.GetPaymentBPItemsList Group data By ItemName = data.Item1
                                     Into Totals = Sum(data.Item2) Select ItemName, Totals

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                For Each item In paymentDetailsItemTotals
                    Dim totals As Double = Convert.ToInt32(item.Totals)
                    Amount += totals
                Next
                Dim receiptAmount As String = FormatNumber(Amount, AppData.DecimalPlaces)
                totalAmount.Append("Total Amount:  ".PadRight(padQty))
                totalAmount.Append(GetSpaces(3).PadRight(padQty))
                totalAmount.Append(receiptAmount.PadLeft(padTl))

                totalAmount.Append(ControlChars.NewLine)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                bPThermalParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing ***")
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            bPThermalParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("On " + FormatDate(Now))
            footerData.Append(ControlChars.NewLine)
            footerData.Append("At " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            bPThermalParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region
#End Region


#Region " Credit Bill Form Payment Printing "

    Private Sub PrintCBFPReceipt()

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()
        Try

            Me.Cursor = Cursors.WaitCursor

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvCreditBillFormPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must set at least one entry on credit bill form payment details!")
            
            Select Case cashierPrinterPaperSize

                Case GetLookupDataDes(oprinterPaperSize.A4)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.SetCBFPPrintData()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docCBFPReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docCBFPReceipt.Print()
                Case String.Empty

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    Me.SetCBFPPrintData()
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                    dlgPrint.Document = docCBFPReceipt
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docCBFPReceipt.Print()

                Case GetLookupDataDes(oprinterPaperSize.EightyMillimeters)
                    Me.PrintCBPThermalReceipt()

            End Select

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docCBFPReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docCBFPReceipt.PrintPage

        Try

            Dim oPayTypeID As New LookupDataID.PayTypeID()
            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String = AppData.ProductOwner.ToUpper() + " CR Bill Form Payment Receipt (Copy)".ToUpper()

            Dim payMode As String

            Dim fromName As String = StringMayBeEnteredIn(Me.stbCBFPBillCustomerName)
            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbCBFPReceiptNo)
            Dim billAccountNo As String = StringMayBeEnteredIn(Me.stbCBFPBillAccountNo)
            Dim payDate As String = FormatDate(DateMayBeEnteredIn(Me.stbCBFPPayDate))
            Dim documentNo As String = StringMayBeEnteredIn(Me.stbCBFPDocumentNo)
            If String.IsNullOrEmpty(documentNo) Then
                payMode = StringMayBeEnteredIn(Me.stbCBFPPayModes)
            Else : payMode = StringMayBeEnteredIn(Me.stbCBFPPayModes) + " (No: " + documentNo + ")"
            End If

            Dim notes As String = StringMayBeEnteredIn(Me.stbCBFPNotes)
            Dim textLEN As Integer = 75

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                'Dim widthTop As Single = .MeasureString("Received from width", titleFont).Width

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 19 * widthTopFirst
                Dim widthTopFourth As Single = 29 * widthTopFirst

                If pageNo < 2 Then

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    yPos += 3 * lineHeight

                    .DrawString("Received from: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(fromName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Receipt No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    If cBFPPayTypeID.ToUpper().Equals(oPayTypeID.InsuranceBill.ToUpper()) Then
                        .DrawString("Insurance No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    Else : .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    End If
                    .DrawString(billAccountNo, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                    yPos += lineHeight

                    .DrawString("Pay Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                    .DrawString("Mode of Payment: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                    .DrawString(payMode, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)

                    If Not String.IsNullOrEmpty(notes) Then

                        yPos += lineHeight
                        notes = "Notes: " + notes.Trim()
                        Dim notesData As New System.Text.StringBuilder(String.Empty)
                        Dim wrappedWordsData As List(Of String) = WrapText(notes, textLEN)
                        If wrappedWordsData.Count > 1 Then
                            For pos As Integer = 0 To wrappedWordsData.Count - 1
                                notesData.Append(wrappedWordsData(pos).Trim())
                                notesData.Append(ControlChars.NewLine)
                            Next
                        Else : notesData.Append(notes)
                        End If

                        .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                        Dim wordLines As Integer = notesData.ToString().Split(CChar(ControlChars.NewLine)).Length
                        If wordLines < 2 Then wordLines = 2
                        yPos += wordLines * lineHeight

                    Else : yPos += 2 * lineHeight
                    End If

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

                If cBFPParagraphs Is Nothing Then Return

                Do While cBFPParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(cBFPParagraphs(1), PrintParagraps)
                    cBFPParagraphs.Remove(1)

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
                        cBFPParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (cBFPParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Function GetPaymentCBFPItemsList() As List(Of Tuple(Of String, Decimal))

        Try

            ' Create list of tuples with two items each.
            Dim paymentbP As New List(Of Tuple(Of String, Decimal))

            For rowNo As Integer = 0 To Me.dgvCreditBillFormPaymentDetails.RowCount - 1

                
                    Dim cells As DataGridViewCellCollection = Me.dgvCreditBillFormPaymentDetails.Rows(rowNo).Cells
                    Dim category As String = cells.Item(Me.colCBFPCategory.Name).Value.ToString()
                    Dim amount As Decimal = DecimalEnteredIn(cells, Me.colCBFPAmount, False, "amount!")

                    paymentbP.Add(New Tuple(Of String, Decimal)(category, amount))

            Next

            Return paymentbP

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Private Sub SetCBFPPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 20
        Dim padQuantity As Integer = 4
        Dim padUnitPrice As Integer = 14
        Dim padDiscount As Integer = 12
        Dim padAmount As Integer = 16
        Dim padTotalAmount As Integer = 56
        Dim padAmountTendered As Integer = 53
        Dim padAccountBalance As Integer = 43
        Dim padChange As Integer = 40

        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        cBFPParagraphs = New Collection()
        Dim oVariousOptions As New VariousOptions()

        Try

            Dim tableHeader As New System.Text.StringBuilder(String.Empty)
            tableHeader.Append("No: ".PadRight(padItemNo))
            tableHeader.Append("Item Name: ".PadRight(padItemName))
            tableHeader.Append("Qty: ".PadLeft(padQuantity))
            tableHeader.Append("Unit Price: ".PadLeft(padUnitPrice))
            tableHeader.Append("Discount: ".PadLeft(padDiscount))
            tableHeader.Append("Amount: ".PadLeft(padAmount))
            tableHeader.Append(ControlChars.NewLine)

            If Not oVariousOptions.HideCreditBillFormPaymentReceiptDetails Then
                tableHeader.Append(ControlChars.NewLine)
                cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))
            End If

            Dim count As Integer
            Dim tableData As New System.Text.StringBuilder(String.Empty)

            For rowNo As Integer = 0 To Me.dgvCreditBillFormPaymentDetails.RowCount - 1

                Dim cells As DataGridViewCellCollection = Me.dgvCreditBillFormPaymentDetails.Rows(rowNo).Cells

                count += 1

                Dim itemNo As String = (count).ToString()
                Dim itemName As String = cells.Item(Me.colCBFPItemName.Name).Value.ToString()
                Dim quantity As String = cells.Item(Me.colCBFPQuantity.Name).Value.ToString()
                Dim unitPrice As String = cells.Item(Me.colCBFPUnitPrice.Name).Value.ToString()
                Dim discount As String = cells.Item(Me.colCBFPDiscount.Name).Value.ToString()
                Dim amount As String = cells.Item(Me.colCBFPAmount.Name).Value.ToString()

                tableData.Append(itemNo.PadRight(padItemNo))
                If itemName.Length > 20 Then
                    tableData.Append(itemName.Substring(0, 20).PadRight(padItemName))
                Else : tableData.Append(itemName.PadRight(padItemName))
                End If
                tableData.Append(quantity.PadLeft(padQuantity))
                tableData.Append(unitPrice.PadLeft(padUnitPrice))
                tableData.Append(discount.PadLeft(padDiscount))
                tableData.Append(amount.PadLeft(padAmount))

                tableData.Append(ControlChars.NewLine)

            Next

            If Not oVariousOptions.HideCreditBillFormPaymentReceiptDetails Then
                cBFPParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))
            End If

            Dim totalAmount As New System.Text.StringBuilder(String.Empty)

            Dim totalBill As Decimal = CalculateGridAmount(dgvCreditBillFormPaymentDetails, colCBFPAmount)
            Dim withholdingTaxLine As New System.Text.StringBuilder(String.Empty)
            Dim grandDiscountLine As New System.Text.StringBuilder(String.Empty)
            Dim netBillLine As New System.Text.StringBuilder(String.Empty)
            Dim withholdingTax As Decimal = DecimalMayBeEnteredIn(nbxCBFPWithholdingTax)
            Dim grandDiscount As Decimal = DecimalMayBeEnteredIn(Me.nbxCBFPGrandDiscount)
            Dim netBill = totalBill - (withholdingTax + grandDiscount)

            totalAmount.Append(ControlChars.NewLine)

            If Not oVariousOptions.HideCreditBillFormPaymentReceiptDetails Then
                totalAmount.Append("Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount))
                If withholdingTax > 0 Then
                    withholdingTaxLine.Append("Withholding Tax: ")
                    withholdingTaxLine.Append(FormatNumber(withholdingTax, AppData.DecimalPlaces).PadLeft(padTotalAmount - 3))
                End If
                If grandDiscount > 0 Then
                    grandDiscountLine.Append("Grand Discount: ")
                    grandDiscountLine.Append(FormatNumber(grandDiscount, AppData.DecimalPlaces).PadLeft(padTotalAmount - 2))
                End If
                If withholdingTax > 0 OrElse grandDiscount > 0 Then
                    netBillLine.Append("Net Bill: ")
                    netBillLine.Append(FormatNumber(netBill, AppData.DecimalPlaces).PadLeft(padTotalAmount + 4))
                End If
            Else
                 totalAmount.Append("Medical CR Bill Form Total Amount: ")
                totalAmount.Append(FormatNumber(totalBill, AppData.DecimalPlaces).PadLeft(padTotalAmount - 21))
                If withholdingTax > 0 Then
                    withholdingTaxLine.Append("Withholding Tax: ")
                    withholdingTaxLine.Append(FormatNumber(withholdingTax, AppData.DecimalPlaces).PadLeft(padTotalAmount - 4))
                End If
                If grandDiscount > 0 Then
                    grandDiscountLine.Append("Grand Discount: ")
                    grandDiscountLine.Append(FormatNumber(grandDiscount, AppData.DecimalPlaces).PadLeft(padTotalAmount - 2))
                End If
                If withholdingTax > 0 OrElse grandDiscount > 0 Then
                    netBillLine.Append("Net Bill: ")
                    netBillLine.Append(FormatNumber(netBill, AppData.DecimalPlaces).PadLeft(padTotalAmount + 4))
                End If
            End If

            totalAmount.Append(ControlChars.NewLine)
            cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))
            cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, withholdingTaxLine.ToString()))
            cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, grandDiscountLine.ToString()))
            cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, netBillLine.ToString()))
            Dim totalAmountWords As New System.Text.StringBuilder(String.Empty)
            totalAmountWords.Append("(" + NumberToWords(netBill) + " ONLY)")
            totalAmountWords.Append(ControlChars.NewLine)
            cBFPParagraphs.Add(New PrintParagraps(footerFont, totalAmountWords.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim oCurrenciesID As New LookupDataID.CurrenciesID()
            Dim amountTenderedData As New System.Text.StringBuilder(String.Empty)
            Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

            Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxCBFPAmountTendered, True)
            Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxCBFPExchangeRate, True)
            Dim change As Decimal = DecimalMayBeEnteredIn(Me.stbCBFPChange, True)
            Dim currency As String = StringMayBeEnteredIn(Me.stbCBFPCurrency)
            Dim amountTenderedLocalCurrency As Decimal = amountTendered * exchangeRate

            amountTenderedData.Append(ControlChars.NewLine)
            amountTenderedData.Append("Amount Tendered: ")
            amountTenderedData.Append(FormatNumber(amountTenderedLocalCurrency, AppData.DecimalPlaces).PadLeft(padAmountTendered))
            amountTenderedData.Append(ControlChars.NewLine)

            If Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                foreignCurrencyData.Append(ControlChars.NewLine)
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.chkCBFPUseAccountBalance.Checked OrElse (Me.chkCBFPSendBalanceToAccount.Checked AndAlso Not change = 0) OrElse
                  Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, amountTenderedData.ToString()))
            End If

            If Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then
                cBFPParagraphs.Add(New PrintParagraps(bodyNormalFont, foreignCurrencyData.ToString()))
            End If

            If Me.chkCBFPUseAccountBalance.Checked Then

                Dim accountData As New System.Text.StringBuilder(String.Empty)
                Dim balanceFromAccount As Decimal = totalBill - amountTenderedLocalCurrency + change

                accountData.Append("Balance used from account: ")
                accountData.Append(FormatNumber(balanceFromAccount, AppData.DecimalPlaces).PadLeft(padAccountBalance))
                accountData.Append(ControlChars.NewLine)
                cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, accountData.ToString()))

            End If

            If Me.chkCBFPSendBalanceToAccount.Checked AndAlso Not change = 0 Then

                Dim balanceData As New System.Text.StringBuilder(String.Empty)

                If change < 0 Then
                    balanceData.Append("Balance sent to account (DR): ")
                Else : balanceData.Append("Balance sent to account (CR): ")
                End If
                balanceData.Append(FormatNumber(change, AppData.DecimalPlaces).PadLeft(padChange))
                balanceData.Append(ControlChars.NewLine)
                cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, balanceData.ToString()))

            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            cBFPParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " + Now.ToString("hh:mm tt") +
                                " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            cBFPParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#Region "Credit Bills Payment THERMAL RECEIPT PRINT OUT"

    Private Sub PrintCBPThermalReceipt()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If Me.dgvCreditBillFormPaymentDetails.RowCount < 1 Then Throw New ArgumentException("Must include at least one entry for Payments!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Me.SetCBFPThermalReceiptPrintData()
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            dlgPrint.Document = docCBFPThermalReceipt
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docCBFPThermalReceipt.Print()

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

    Private Sub docCBFPThermalReceipt_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docCBFPThermalReceipt.PrintPage

        Try

            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = CSng(e.MarginBounds.Left / 10)
            Dim yPos As Single = CSng(e.MarginBounds.Top / 8)

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)

            Dim title As String = AppData.ProductOwner.ToUpper()


            Dim fullName As String
            Dim payMode As String
            Dim fromName As String = StringMayBeEnteredIn(Me.stbCBFPBillCustomerName)

            fullName = StringEnteredIn(Me.stbCBFPBillCustomerName)
            Dim receiptNo As String = StringMayBeEnteredIn(Me.stbCBFPReceiptNo)
            Dim billAccountNo As String = StringMayBeEnteredIn(Me.stbCBFPBillAccountNo)
            Dim payDate As String = FormatDate(Today)
            Dim documentNo As String = StringMayBeEnteredIn(Me.stbCBFPDocumentNo)
            If String.IsNullOrEmpty(documentNo) Then
                payMode = StringMayBeEnteredIn(Me.stbCBFPPayModes)
            Else : payMode = StringMayBeEnteredIn(Me.stbCBFPPayModes) + " (No: " + documentNo + ")"
            End If

            ' Increment the page number.
            pageNo += 1

            With e.Graphics

                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 11 * widthTopFirst

                If pageNo < 2 Then

                    '.DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                    'yPos += 3 * lineHeight
                    If (title.Length > 25) Then
                        .DrawString(title.Substring(0, 25), titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString(title.Substring(25), titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("Credit Bills Payment Receipt".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 3 * lineHeight
                    Else
                        .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                        yPos += lineHeight
                        .DrawString("Credit Bills Payment Receipt".ToUpper(), titleFont, Brushes.Black, xPos, yPos)
                        yPos += 3 * lineHeight
                    End If

                    .DrawString("Received From: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    If (fullName.Length > 15) Then
                        .DrawString(fullName.Substring(0, 14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                        .DrawString(fullName.Substring(14), bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    Else
                        .DrawString(fullName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                        yPos += lineHeight
                    End If

                    .DrawString("Receipt No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(receiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(billAccountNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Pay Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    .DrawString("Payment Mode: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(payMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

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

                If CBFPThermalParagraphs Is Nothing Then Return

                Do While CBFPThermalParagraphs.Count > 0

                    ' Print the next paragraph.
                    Dim oPrintParagraps As PrintParagraps = DirectCast(CBFPThermalParagraphs(1), PrintParagraps)
                    CBFPThermalParagraphs.Remove(1)

                    ' Get the area available for this paragraph.
                    Dim printAreaRectangle As RectangleF = New RectangleF(xPos, yPos, e.PageBounds.Width - xPos, e.MarginBounds.Bottom - yPos)

                    ' If the printing area rectangle's height < 1, make it 1.
                    If printAreaRectangle.Height < 1 Then printAreaRectangle.Height = 1

                    ' See how big the text will be and how many characters will fit.
                    Dim textSize As SizeF = .MeasureString(oPrintParagraps.Text, oPrintParagraps.TheFont,
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
                        CBFPThermalParagraphs.Add(oPrintParagraps, Before:=1)
                        Exit Do
                    End If
                Loop

                ' If we have more paragraphs, we have more pages.
                e.HasMorePages = (CBFPThermalParagraphs.Count > 0)

            End With

        Catch ex As Exception
            Throw ex
        End Try



    End Sub



    Private Sub SetCBFPThermalReceiptPrintData()

        Dim padItemNo As Integer = 4
        Dim padItemName As Integer = 16
        Dim padQuantity As Integer = 8
        Dim padIAmount As Integer = 10

        Dim padQty As Integer = 4
        Dim padUp As Integer = 9
        Dim padDc As Integer = 8
        Dim padTl As Integer = 13

        Dim count As Integer
        Dim tableHeader As New System.Text.StringBuilder(String.Empty)
        Dim tableData As New System.Text.StringBuilder(String.Empty)
        Dim footerFont As New Font(printFontName, 9)

        pageNo = 0
        CBFPThermalParagraphs = New Collection()
        Dim totalAmount As New System.Text.StringBuilder(String.Empty)
        Dim Amount As Double = 0.0

        Try


            If oVariousOptions.CategorizeVisitPaymentDetails Then

                tableHeader.Append("No: ".PadRight(padItemNo))
                tableHeader.Append("Item Category: ".PadRight(padItemName))
                tableHeader.Append("Amount: ".PadLeft(padIAmount))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append(ControlChars.NewLine)
                CBFPThermalParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentBPItems = From data In Me.GetPaymentCBFPItemsList Group data By CategoryName = data.Item1
                                     Into CategoryAmount = Sum(data.Item2) Select CategoryName, CategoryAmount

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For Each item In paymentBPItems

                    count += 1

                    Dim itemNo As String = (count).ToString()
                    Dim categoryName As String = GetPrintableItemCategoryDes(item.CategoryName)
                    Dim categoryAmount As String = FormatNumber(item.CategoryAmount, AppData.DecimalPlaces)

                    tableData.Append(itemNo.PadRight(padItemNo))
                    If categoryName.Length > 47 Then
                        tableData.Append(categoryName.Substring(0, 47).PadRight(padItemName))
                    Else : tableData.Append(categoryName.PadRight(padItemName))
                    End If
                    tableData.Append(categoryAmount.PadLeft(padIAmount))

                    tableData.Append(ControlChars.NewLine)

                Next

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                tableData.Append(ControlChars.NewLine)
                CBFPThermalParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentDetailsItemTotals = From data In Me.GetPaymentCBFPItemsList Group data By ItemName = data.Item1
                                     Into Totals = Sum(data.Item2) Select ItemName, Totals

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                For Each item In paymentDetailsItemTotals
                    Dim totals As Double = Convert.ToInt32(item.Totals)
                    Amount += totals
                Next
                Dim receiptAmount As String = FormatNumber(Amount, AppData.DecimalPlaces)
                totalAmount.Append("Total Amount:  ".PadRight(padQty))
                totalAmount.Append(GetSpaces(3).PadRight(padQty))
                totalAmount.Append(receiptAmount.PadLeft(padTl))

                totalAmount.Append(ControlChars.NewLine)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CBFPThermalParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Else

                tableHeader.Append(ControlChars.NewLine)
                '--------------------------------------------------------------------------------------------------
                tableHeader.Append("Description".PadRight(padItemName))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append("Qty".PadRight(padQty))
                tableHeader.Append("Price".PadLeft(padUp))
                ' tableHeader.Append("Disc%".PadLeft(padDc))
                tableHeader.Append(" Total".PadLeft(padTl))
                tableHeader.Append(ControlChars.NewLine)
                tableHeader.Append("-------------------------------".PadRight(padItemName))
                '--------------------------------------------------------------------------------------------------
                CBFPThermalParagraphs.Add(New PrintParagraps(bodyBoldFont, tableHeader.ToString()))



                For rowNo As Integer = 0 To Me.dgvCreditBillFormPaymentDetails.RowCount - 1

                    Dim cells As DataGridViewCellCollection = Me.dgvCreditBillFormPaymentDetails.Rows(rowNo).Cells

                        count += 1

                        Dim itemNo As String = (count).ToString()
                        Dim ItemName As String = cells.Item(Me.colCBFPItemName.Name).Value.ToString()
                        Dim itemQuantity As String = cells.Item(Me.colCBFPQuantity.Name).Value.ToString()
                        Dim itemUnitPrice As String = cells.Item(Me.colCBFPUnitPrice.Name).Value.ToString()
                        Dim itemAmount As String = cells.Item(Me.colCBFPAmount.Name).Value.ToString()
                        'tableData.Append(itemNo.PadRight(padItemNo))
                        tableData.Append(ItemName.PadRight(padItemNo))


                        tableData.Append(ControlChars.NewLine)
                        tableData.Append(itemQuantity.PadRight(padQty))
                        tableData.Append(itemUnitPrice.PadLeft(padUp))
                        'tableData.Append(itemDicount.PadLeft(padDc))
                        tableData.Append(itemAmount.PadLeft(padTl))
                        tableData.Append(ControlChars.NewLine)

                Next

                tableData.Append(ControlChars.NewLine)
                CBFPThermalParagraphs.Add(New PrintParagraps(bodyNormalFont, tableData.ToString()))


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim paymentDetailsItemTotals = From data In Me.GetPaymentCBFPItemsList Group data By ItemName = data.Item1
                                     Into Totals = Sum(data.Item2) Select ItemName, Totals

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                For Each item In paymentDetailsItemTotals
                    Dim totals As Double = Convert.ToInt32(item.Totals)
                    Amount += totals
                Next
                Dim receiptAmount As String = FormatNumber(Amount, AppData.DecimalPlaces)
                totalAmount.Append("Total Amount:  ".PadRight(padQty))
                totalAmount.Append(GetSpaces(3).PadRight(padQty))
                totalAmount.Append(receiptAmount.PadLeft(padTl))

                totalAmount.Append(ControlChars.NewLine)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CBFPThermalParagraphs.Add(New PrintParagraps(bodyBoldFont, totalAmount.ToString()))
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End If
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim appreciationData As New System.Text.StringBuilder(String.Empty)
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** Thank you for choosing ***")
            appreciationData.Append(ControlChars.NewLine)
            appreciationData.Append("*** " + AppData.ProductOwner + " ***")
            appreciationData.Append(ControlChars.NewLine)
            CBFPThermalParagraphs.Add(New PrintParagraps(bodyBoldFont, appreciationData.ToString()))
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            Dim footerData As New System.Text.StringBuilder(String.Empty)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("Printed by " + CurrentUser.FullName)
            footerData.Append(ControlChars.NewLine)
            footerData.Append("On " + FormatDate(Now))
            footerData.Append(ControlChars.NewLine)
            footerData.Append("At " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
            footerData.Append(ControlChars.NewLine)
            CBFPThermalParagraphs.Add(New PrintParagraps(footerFont, footerData.ToString()))

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region


#End Region

#Region " Accounts Printing "

    Private Sub PrintAccounts()

        Dim dlgPrint As New PrintDialog()
        Dim oprinterPaperSize As New LookupDataID.PrinterPaperSize()

        Try

            Select Case cashierPrinterPaperSize

                Case GetLookupDataDes(oprinterPaperSize.A4)

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    dlgPrint.Document = docAccounts
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docAccounts.Print()

                Case String.Empty
                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    dlgPrint.Document = docAccounts
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docAccounts.Print()

                Case GetLookupDataDes(oprinterPaperSize.EightyMillimeters)
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    dlgPrint.Document = docThermalAccounts
                    dlgPrint.Document.PrinterSettings.Collate = True
                    If dlgPrint.ShowDialog = DialogResult.OK Then docThermalAccounts.Print()

            End Select

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub


    Private Sub docAccounts_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docAccounts.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String = AppData.ProductOwner.ToUpper() + " Account Receipt (copy)".ToUpper()

            With e.Graphics

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                yPos += 3 * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 10 * widthTopFirst
                Dim widthTopThird As Single = 17 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                Dim oAccountActionID As New LookupDataID.AccountActionID()

                Dim accountName As String = StringMayBeEnteredIn(Me.stbAccountName)
                Dim accountNo As String = StringMayBeEnteredIn(Me.stbAccountNo)
                Dim accountCategory As String = StringMayBeEnteredIn(Me.stbBillModes)
                Dim transactionNo As String = StringMayBeEnteredIn(Me.stbAccountTranNo)
                Dim transactionDate As String = FormatDate(DateMayBeEnteredIn(Me.stbTransactionDate))
                Dim payMode As String = StringMayBeEnteredIn(Me.stbAccountPayModes)
                Dim accountAction As String = StringMayBeEnteredIn(Me.stbAccountAction)
                Dim documentNo As String = StringMayBeEnteredIn(Me.stbAccountDocumentNo)
                Dim amount As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxAccountAmount, True), AppData.DecimalPlaces)
                Dim amountWords As String = NumberToWords(DecimalMayBeEnteredIn(Me.nbxAccountAmount, True))
                Dim notes As String = StringMayBeEnteredIn(Me.stbAccountNotes)
                Dim textLEN As Integer = 75
                Dim wordLines As Integer

                .DrawString("Account Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(accountName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(accountNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                .DrawString("Account Category: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                .DrawString(accountCategory, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                yPos += lineHeight

                .DrawString("Transaction No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(transactionNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                .DrawString("Transaction Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                .DrawString(transactionDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                yPos += lineHeight

                .DrawString("Mode of Payment: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(payMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                .DrawString("Account Action: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                .DrawString(accountAction, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                yPos += lineHeight

                .DrawString("Document No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(documentNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                If String.IsNullOrEmpty(accountAction) Then
                    .DrawString("Amount: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                ElseIf accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Debit).ToUpper()) Then
                    .DrawString("Amount Debited: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                ElseIf accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Credit).ToUpper()) Then
                    .DrawString("Amount Credited: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                Else : .DrawString("Amount: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                End If
                .DrawString(amount, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                If Not String.IsNullOrEmpty(amountWords) Then
                    yPos += lineHeight
                    amountWords = "(" + amountWords.Trim() + " ONLY)"
                    Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedWordsData As List(Of String) = WrapText(amountWords, textLEN)
                    If wrappedWordsData.Count > 1 Then
                        For pos As Integer = 0 To wrappedWordsData.Count - 1
                            amountWordsData.Append(wrappedWordsData(pos).Trim())
                            amountWordsData.Append(ControlChars.NewLine)
                        Next
                    Else : amountWordsData.Append(amountWords)
                    End If

                    .DrawString(amountWordsData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    wordLines = amountWordsData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim oCurrenciesID As New LookupDataID.CurrenciesID()
                Dim currency As String = StringMayBeEnteredIn(Me.stbAccountCurrency)

                If Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then

                    Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

                    Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered, True)
                    Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate, False)
                    Dim amountTenderedLocalCurrency As String = FormatNumber(amountTendered * exchangeRate, AppData.DecimalPlaces)

                    .DrawString("Amount Tendered: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(amountTenderedLocalCurrency, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                    yPos += lineHeight

                    foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                    foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                    foreignCurrencyData.Append(ControlChars.NewLine)
                    .DrawString(foreignCurrencyData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not String.IsNullOrEmpty(notes) Then
                    notes = "Notes: " + notes.Trim()
                    Dim notesData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedNotesData As List(Of String) = WrapText(notes, textLEN)
                    If wrappedNotesData.Count > 1 Then
                        For pos As Integer = 0 To wrappedNotesData.Count - 1
                            notesData.Append(wrappedNotesData(pos).Trim())
                            notesData.Append(ControlChars.NewLine)
                        Next
                    Else : notesData.Append(notes)
                    End If

                    .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    wordLines = notesData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Debit).ToUpper()) Then

                    Dim patientSignData As New System.Text.StringBuilder(String.Empty)

                    patientSignData.Append("Patient's Sign:   " + GetCharacters("."c, 20))
                    patientSignData.Append(GetSpaces(4))
                    patientSignData.Append("Date:  " + GetCharacters("."c, 20))
                    .DrawString(patientSignData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    Dim checkedSignData As New System.Text.StringBuilder(String.Empty)

                    checkedSignData.Append("Checked By:       " + GetCharacters("."c, 20))
                    checkedSignData.Append(GetSpaces(4))
                    checkedSignData.Append("Date:  " + GetCharacters("."c, 20))
                    .DrawString(checkedSignData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim printedBy As String = "Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) + " at " +
                    Now.ToString("hh:mm tt") + " from " + AppData.AppTitle
                Dim footerData As New System.Text.StringBuilder(String.Empty)

                Dim wrappedFooterData As List(Of String) = WrapText(printedBy, textLEN)
                If wrappedFooterData.Count > 1 Then
                    For pos As Integer = 0 To wrappedFooterData.Count - 1
                        footerData.Append(wrappedFooterData(pos).Trim())
                        footerData.Append(ControlChars.NewLine)
                    Next
                Else : footerData.Append(printedBy)
                End If

                .DrawString(footerData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                yPos += lineHeight
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub docThermalAccounts_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docThermalAccounts.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String

            title = "Account Receipt".ToUpper()

            With e.Graphics

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                yPos += 3 * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 10 * widthTopFirst
                Dim widthTopThird As Single = 17 * widthTopFirst
                Dim widthTopFourth As Single = 30 * widthTopFirst

                ' Dim oAccountActionID As New LookupDataID.AccountActionID()

                Dim accountName As String = StringMayBeEnteredIn(Me.stbAccountName)
                Dim accountNo As String = StringMayBeEnteredIn(Me.stbAccountNo)
                Dim accountCategory As String = StringMayBeEnteredIn(Me.stbBillModes)
                Dim transactionNo As String = StringMayBeEnteredIn(Me.stbAccountTranNo)
                Dim transactionDate As String = StringMayBeEnteredIn(Me.stbTransactionDate)
                Dim payMode As String = StringMayBeEnteredIn(Me.stbAccountPayModes)
                Dim accountAction As String = StringMayBeEnteredIn(Me.stbAccountAction)
                Dim documentNo As String = StringMayBeEnteredIn(Me.stbAccountDocumentNo)
                Dim balance As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxAccountAmount, True), AppData.DecimalPlaces)
                Dim amount As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxAccountAmount, True), AppData.DecimalPlaces)
                Dim amountWords As String = NumberToWords(DecimalMayBeEnteredIn(Me.nbxAccountAmount, True))
                Dim notes As String = StringMayBeEnteredIn(Me.stbAccountNotes)

                Dim textLEN As Integer = 75
                Dim wordLines As Integer

                .DrawString("Account Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(accountName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Account No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(accountNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight
                .DrawString("Account Category: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(accountCategory, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Transaction No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(transactionNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight
                .DrawString("Transaction Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(transactionDate, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Mode of Payment: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(payMode, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight
                .DrawString("Account Action: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(accountAction, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Document No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(documentNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                'If String.IsNullOrEmpty(accountAction) Then
                '    .DrawString("Amount: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                'ElseIf accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Debit).ToUpper()) Then
                '    .DrawString("Amount Debited: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                'ElseIf accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Credit).ToUpper()) Then
                .DrawString("Amount: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(amount, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                If Not String.IsNullOrEmpty(amountWords) Then
                    yPos += lineHeight
                    amountWords = "(" + amountWords.Trim() + " ONLY)"
                    Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedWordsData As List(Of String) = WrapText(amountWords, textLEN)
                    If wrappedWordsData.Count > 1 Then
                        For pos As Integer = 0 To wrappedWordsData.Count - 1
                            amountWordsData.Append(wrappedWordsData(pos).Trim())
                            amountWordsData.Append(ControlChars.NewLine)
                        Next
                    Else : amountWordsData.Append(amountWords)
                    End If

                    .DrawString(amountWordsData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    wordLines = amountWordsData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += lineHeight

                End If

                '    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Dim oCurrenciesID As New LookupDataID.CurrenciesID()
                'Dim currenciesID As String = StringValueMayBeEnteredIn(Me.stbAccountCurrency, "Currency!")

                'If Not currenciesID.ToUpper().Equals(oCurrenciesID.UgandaShillings.ToUpper()) Then

                '    Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

                '    Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountAmountTendered, True)
                '    Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxAccountExchangeRate, False)
                '    Dim amountTenderedLocalCurrency As String = FormatNumber(amountTendered * exchangeRate, AppData.DecimalPlaces)
                '    Dim currency As String = StringMayBeEnteredIn(Me.stbAccountCurrency)

                '    .DrawString("Amount Tendered: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                '    .DrawString(amountTenderedLocalCurrency, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                '    yPos += lineHeight

                '    foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                '    foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                '    foreignCurrencyData.Append(ControlChars.NewLine)
                '    .DrawString(foreignCurrencyData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                '    yPos += lineHeight

                'End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not String.IsNullOrEmpty(notes) Then
                    notes = "Notes: " + notes.Trim()
                    Dim notesData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedNotesData As List(Of String) = WrapText(notes, textLEN)
                    If wrappedNotesData.Count > 1 Then
                        For pos As Integer = 0 To wrappedNotesData.Count - 1
                            notesData.Append(wrappedNotesData(pos).Trim())
                            notesData.Append(ControlChars.NewLine)
                        Next
                    Else : notesData.Append(notes)
                    End If

                    .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    wordLines = notesData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += lineHeight

                End If



                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'If accountAction.ToUpper().Equals(GetLookupDataDes(oAccountActionID.Debit).ToUpper()) Then

                'Dim patientSignData As New System.Text.StringBuilder(String.Empty)

                'patientSignData.Append("Patient's Sign: " + GetCharacters("."c, 15))
                'patientSignData.Append(ControlChars.NewLine)
                'yPos += lineHeight
                'patientSignData.Append("Date: " + GetCharacters("."c, 15))
                '.DrawString(patientSignData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)

                'yPos += lineHeight
                ' '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                'Dim checkedSignData As New System.Text.StringBuilder(String.Empty)

                'checkedSignData.Append("Checked By: " + GetCharacters("."c, 15))
                'checkedSignData.Append(ControlChars.NewLine)
                'yPos += lineHeight
                'checkedSignData.Append("Date: " + GetCharacters("."c, 15))
                '.DrawString(checkedSignData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)

                'yPos += lineHeight
                ' End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim footerData As New System.Text.StringBuilder(String.Empty)
                footerData.Append(ControlChars.NewLine)
                footerData.Append("Printed by " + CurrentUser.FullName)
                footerData.Append(ControlChars.NewLine)
                footerData.Append("On " + FormatDate(Now))
                footerData.Append(ControlChars.NewLine)
                footerData.Append("At " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle)
                footerData.Append(ControlChars.NewLine)
                .DrawString(footerData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                yPos += lineHeight

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub


#End Region

#Region " Other Income Printing "

    Private Sub PrintOtherIncome()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor


            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            StringEnteredIn(Me.stbIncomeNo, "Income No!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docOtherIncome
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docOtherIncome.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub docOtherIncome_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docOtherIncome.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String = AppData.ProductOwner.ToUpper() + " Other Income Receipt (copy)".ToUpper()

            With e.Graphics

                Dim lineWidth As Single = .MeasureString("W", titleFont).Width * 12

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                yPos += 3 * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim incomeNo As String = StringMayBeEnteredIn(Me.stbIncomeNo)
                Dim incomeDate As String = FormatDate(DateMayBeEnteredIn(Me.stbIncomeDate))
                Dim incomeSource As String = StringMayBeEnteredIn(Me.stbIncomeSources)
                Dim payMode As String = StringMayBeEnteredIn(Me.stbOIPayModes)
                Dim documentNo As String = StringMayBeEnteredIn(Me.stbOIDocumentNo)
                Dim amount As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxOIAmount, True), AppData.DecimalPlaces)
                Dim amountWords As String = NumberToWords(DecimalMayBeEnteredIn(Me.nbxOIAmount, True))
                Dim notes As String = StringMayBeEnteredIn(Me.stbOINotes)
                Dim textLEN As Integer = 75

                .DrawString("Income No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(incomeNo, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Income Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(incomeDate, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Income Source: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(incomeSource, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Mode of Payment: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(payMode, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Document No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(documentNo, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Amount: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(amount, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)

                If Not String.IsNullOrEmpty(amountWords) Then

                    yPos += lineHeight
                    amountWords = "(" + amountWords.Trim() + " ONLY)"
                    Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedWordsData As List(Of String) = WrapText(amountWords, textLEN)
                    If wrappedWordsData.Count > 1 Then
                        For pos As Integer = 0 To wrappedWordsData.Count - 1
                            amountWordsData.Append(wrappedWordsData(pos).Trim())
                            amountWordsData.Append(ControlChars.NewLine)
                        Next
                    Else : amountWordsData.Append(amountWords)
                    End If

                    .DrawString(amountWordsData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    Dim wordLines As Integer = amountWordsData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim oCurrenciesID As New LookupDataID.CurrenciesID()
                Dim currency As String = StringMayBeEnteredIn(Me.stbOICurrency)

                If Not currency.ToUpper().Equals(GetLookupDataDes(oCurrenciesID.UgandaShillings).ToUpper()) Then

                    Dim foreignCurrencyData As New System.Text.StringBuilder(String.Empty)

                    Dim amountTendered As Decimal = DecimalMayBeEnteredIn(Me.nbxOIAmountTendered, True)
                    Dim exchangeRate As Decimal = DecimalMayBeEnteredIn(Me.nbxOIExchangeRate, False)
                    Dim amountTenderedLocalCurrency As String = FormatNumber(amountTendered * exchangeRate, AppData.DecimalPlaces)

                    .DrawString("Amount Tendered: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                    .DrawString(amountTenderedLocalCurrency, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                    yPos += lineHeight

                    foreignCurrencyData.Append("(" + currency + ": " + FormatNumber(amountTendered, AppData.DecimalPlaces))
                    foreignCurrencyData.Append(", Exchange Rate: " + FormatNumber(exchangeRate, AppData.DecimalPlaces) + ")")
                    foreignCurrencyData.Append(ControlChars.NewLine)
                    .DrawString(foreignCurrencyData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    yPos += 2 * lineHeight

                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                If Not String.IsNullOrEmpty(notes) Then

                    yPos += lineHeight
                    notes = "Notes: " + notes.Trim()
                    Dim notesData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedWordsData As List(Of String) = WrapText(notes, textLEN)
                    If wrappedWordsData.Count > 1 Then
                        For pos As Integer = 0 To wrappedWordsData.Count - 1
                            notesData.Append(wrappedWordsData(pos).Trim())
                            notesData.Append(ControlChars.NewLine)
                        Next
                    Else : notesData.Append(notes)
                    End If

                    .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    Dim wordLines As Integer = notesData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight
                End If

                Dim printedBy As String = "Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) +
                                          " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle
                Dim footerData As New System.Text.StringBuilder(String.Empty)

                Dim wrappedFooterData As List(Of String) = WrapText(printedBy, textLEN)
                If wrappedFooterData.Count > 1 Then
                    For pos As Integer = 0 To wrappedFooterData.Count - 1
                        footerData.Append(wrappedFooterData(pos).Trim())
                        footerData.Append(ControlChars.NewLine)
                    Next
                Else : footerData.Append(printedBy)
                End If

                .DrawString(footerData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                yPos += lineHeight

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Refunds Printing "

    Private Sub PrintRefunds()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            StringEnteredIn(Me.stbRefundNo, "Refund No!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docRefunds
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docRefunds.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub docRefunds_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docRefunds.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String = AppData.ProductOwner.ToUpper() + " Refunds Receipt (copy)".ToUpper()

            With e.Graphics

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                yPos += 3 * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim widthTopFirst As Single = .MeasureString("W", titleFont).Width
                Dim widthTopSecond As Single = 9 * widthTopFirst
                Dim widthTopThird As Single = 17 * widthTopFirst
                Dim widthTopFourth As Single = 26 * widthTopFirst

                Dim payeeName As String = StringMayBeEnteredIn(Me.stbPayeeName)
                Dim receiptNo As String = StringMayBeEnteredIn(Me.stbRefundReceiptNo)
                Dim receiptAmount As String = FormatNumber(DecimalMayBeEnteredIn(Me.stbRefundAmountPaid, True), AppData.DecimalPlaces)
                Dim refundNo As String = StringMayBeEnteredIn(Me.stbRefundNo)
                Dim refundDate As String = FormatDate(DateMayBeEnteredIn(Me.stbRefundDate))
                Dim refundAmount As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxRefundAmount, True), AppData.DecimalPlaces)
                Dim refundAmountWords As String = NumberToWords(DecimalMayBeEnteredIn(Me.nbxRefundAmount, True))
                Dim notes As String = StringMayBeEnteredIn(Me.stbRefundNotes)
                Dim textLEN As Integer = 75
                Dim wordLines As Integer

                .DrawString("Full Name: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(payeeName, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                yPos += lineHeight

                .DrawString("Receipt No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(receiptNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                .DrawString("Receipt Amount: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                .DrawString(receiptAmount, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                yPos += lineHeight

                .DrawString("Refund No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(refundNo, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)
                .DrawString("Refund Date: ", bodyNormalFont, Brushes.Black, xPos + widthTopThird, yPos)
                .DrawString(refundDate, bodyBoldFont, Brushes.Black, xPos + widthTopFourth, yPos)
                yPos += lineHeight

                .DrawString("Refund Amount: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(refundAmount, bodyBoldFont, Brushes.Black, xPos + widthTopSecond, yPos)

                If Not String.IsNullOrEmpty(refundAmountWords) Then

                    yPos += lineHeight
                    refundAmountWords = "(" + refundAmountWords.Trim() + " ONLY)"
                    Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedWordsData As List(Of String) = WrapText(refundAmountWords, textLEN)
                    If wrappedWordsData.Count > 1 Then
                        For pos As Integer = 0 To wrappedWordsData.Count - 1
                            amountWordsData.Append(wrappedWordsData(pos).Trim())
                            amountWordsData.Append(ControlChars.NewLine)
                        Next
                    Else : amountWordsData.Append(refundAmountWords)
                    End If

                    .DrawString(amountWordsData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    wordLines = amountWordsData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight
                End If

                If Not String.IsNullOrEmpty(notes) Then

                    yPos += lineHeight
                    notes = "Notes: " + notes.Trim()
                    Dim notesData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedWordsData As List(Of String) = WrapText(notes, textLEN)
                    If wrappedWordsData.Count > 1 Then
                        For pos As Integer = 0 To wrappedWordsData.Count - 1
                            notesData.Append(wrappedWordsData(pos).Trim())
                            notesData.Append(ControlChars.NewLine)
                        Next
                    Else : notesData.Append(notes)
                    End If

                    .DrawString(notesData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    wordLines = notesData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight
                End If

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim signatureData As New System.Text.StringBuilder(String.Empty)

                signatureData.Append("Received By:  " + GetCharacters("."c, 20))
                signatureData.Append(GetSpaces(4))
                signatureData.Append("Sign:  " + GetCharacters("."c, 20))
                signatureData.Append(ControlChars.NewLine)
                signatureData.Append(ControlChars.NewLine)

                signatureData.Append("Checked By:   " + GetCharacters("."c, 20))
                signatureData.Append(GetSpaces(4))
                signatureData.Append("Sign:  " + GetCharacters("."c, 20))
                .DrawString(signatureData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                yPos += 4 * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim refundAmountFooter As String = "*** This refund requires that receipt no: " + receiptNo + ", be returned ***"
                Dim refundAmountData As New System.Text.StringBuilder(String.Empty)
                Dim wrappedRefundAmountData As List(Of String) = WrapText(refundAmountFooter, textLEN)

                If wrappedRefundAmountData.Count > 1 Then
                    For pos As Integer = 0 To wrappedRefundAmountData.Count - 1
                        refundAmountData.Append(wrappedRefundAmountData(pos).Trim())
                        refundAmountData.Append(ControlChars.NewLine)
                    Next
                Else : refundAmountData.Append(refundAmountFooter)
                End If

                .DrawString(refundAmountData.ToString(), bodyBoldFont, Brushes.Black, xPos, yPos)
                wordLines = refundAmountData.ToString().Split(CChar(ControlChars.NewLine)).Length
                If wordLines < 2 Then wordLines = 2
                yPos += wordLines * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim footerData As New System.Text.StringBuilder(String.Empty)
                Dim printedBy As String = "Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) +
                                          " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle
                Dim wrappedFooterData As List(Of String) = WrapText(printedBy, textLEN)
                If wrappedFooterData.Count > 1 Then
                    For pos As Integer = 0 To wrappedFooterData.Count - 1
                        footerData.Append(wrappedFooterData(pos).Trim())
                        footerData.Append(ControlChars.NewLine)
                    Next
                Else : footerData.Append(printedBy)
                End If

                .DrawString(footerData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                yPos += lineHeight
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            End With

        Catch ex As Exception
            Throw ex
        End Try

    End Sub

#End Region

#Region " Expenditure Printing "

    Private Sub PrintExpenditure()

        Dim dlgPrint As New PrintDialog()

        Try

            Me.Cursor = Cursors.WaitCursor

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            StringEnteredIn(Me.stbExpenditureNo, "Expenditure No!")

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            dlgPrint.Document = docExpenditure
            'dlgPrint.AllowPrintToFile = True
            'dlgPrint.AllowSelection = True
            'dlgPrint.AllowSomePages = True
            dlgPrint.Document.PrinterSettings.Collate = True
            If dlgPrint.ShowDialog = DialogResult.OK Then docExpenditure.Print()

        Catch ex As Exception
            Throw ex

        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub docExpenditure_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles docExpenditure.PrintPage

        Try

            Dim oVariousOptions As New VariousOptions()
            Dim titleFont As New Font(printFontName, 12, FontStyle.Bold)

            Dim xPos As Single = e.MarginBounds.Left
            Dim yPos As Single = e.MarginBounds.Top

            Dim lineHeight As Single = bodyNormalFont.GetHeight(e.Graphics)
            Dim title As String = AppData.ProductOwner.ToUpper() + " Expenditure Receipt (copy)".ToUpper()

            With e.Graphics

                Dim lineWidth As Single = .MeasureString("W", titleFont).Width * 12

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                If Not oVariousOptions.HideCashReceiptHeader Then yPos = PrintPageHeader(e, bodyNormalFont, bodyBoldFont)

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                .DrawString(title, titleFont, Brushes.Black, xPos, yPos)
                yPos += 3 * lineHeight

                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Dim expenditureNo As String = StringMayBeEnteredIn(Me.stbExpenditureNo)
                Dim spentDate As String = FormatDate(DateMayBeEnteredIn(Me.stbSpentDate))
                Dim givenTo As String = StringMayBeEnteredIn(Me.stbGivenTo)
                Dim documentNo As String = StringMayBeEnteredIn(Me.stbEXDocumentNo)
                Dim amount As String = FormatNumber(DecimalMayBeEnteredIn(Me.nbxEXAmount, True), AppData.DecimalPlaces)
                Dim amountWords As String = NumberToWords(DecimalMayBeEnteredIn(Me.nbxEXAmount, True))
                Dim details As String = StringMayBeEnteredIn(Me.stbEXDetails)
                Dim textLEN As Integer = 75

                .DrawString("Expenditure No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(expenditureNo, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Spent Date: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(spentDate, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Given To: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(givenTo, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Document No: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(documentNo, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)
                yPos += lineHeight

                .DrawString("Amount: ", bodyNormalFont, Brushes.Black, xPos, yPos)
                .DrawString(amount, bodyBoldFont, Brushes.Black, xPos + lineWidth, yPos)

                If Not String.IsNullOrEmpty(amountWords) Then

                    yPos += lineHeight
                    amountWords = "(" + amountWords.Trim() + " ONLY)"
                    Dim amountWordsData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedWordsData As List(Of String) = WrapText(amountWords, textLEN)
                    If wrappedWordsData.Count > 1 Then
                        For pos As Integer = 0 To wrappedWordsData.Count - 1
                            amountWordsData.Append(wrappedWordsData(pos).Trim())
                            amountWordsData.Append(ControlChars.NewLine)
                        Next
                    Else : amountWordsData.Append(amountWords)
                    End If

                    .DrawString(amountWordsData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    Dim wordLines As Integer = amountWordsData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight
                End If

                If Not String.IsNullOrEmpty(details) Then

                    yPos += lineHeight
                    details = "Details: " + details.Trim()
                    Dim detailsData As New System.Text.StringBuilder(String.Empty)
                    Dim wrappedWordsData As List(Of String) = WrapText(details, textLEN)
                    If wrappedWordsData.Count > 1 Then
                        For pos As Integer = 0 To wrappedWordsData.Count - 1
                            detailsData.Append(wrappedWordsData(pos).Trim())
                            detailsData.Append(ControlChars.NewLine)
                        Next
                    Else : detailsData.Append(details)
                    End If

                    .DrawString(detailsData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                    Dim wordLines As Integer = detailsData.ToString().Split(CChar(ControlChars.NewLine)).Length
                    If wordLines < 2 Then wordLines = 2
                    yPos += wordLines * lineHeight

                Else : yPos += 2 * lineHeight
                End If

                Dim footerData As New System.Text.StringBuilder(String.Empty)

                footerData.Append("Received By:  " + GetCharacters("."c, 20))
                footerData.Append(GetSpaces(4))
                footerData.Append("Sign:  " + GetCharacters("."c, 20))
                footerData.Append(ControlChars.NewLine)
                footerData.Append(ControlChars.NewLine)

                footerData.Append("Checked By:   " + GetCharacters("."c, 20))
                footerData.Append(GetSpaces(4))
                footerData.Append("Sign:  " + GetCharacters("."c, 20))
                footerData.Append(ControlChars.NewLine)
                footerData.Append(ControlChars.NewLine)

                Dim printedBy As String = "Printed by " + CurrentUser.FullName + " on " + FormatDate(Now) +
                    " at " + Now.ToString("hh:mm tt") + " from " + AppData.AppTitle

                Dim wrappedFooterData As List(Of String) = WrapText(printedBy, textLEN)
                If wrappedFooterData.Count > 1 Then
                    For pos As Integer = 0 To wrappedFooterData.Count - 1
                        footerData.Append(wrappedFooterData(pos).Trim())
                        footerData.Append(ControlChars.NewLine)
                    Next
                Else : footerData.Append(printedBy)
                End If

                .DrawString(footerData.ToString(), bodyNormalFont, Brushes.Black, xPos, yPos)
                yPos += lineHeight

            End With

        Catch ex As Exception
            Throw ex

        End Try

    End Sub

#End Region

 
End Class